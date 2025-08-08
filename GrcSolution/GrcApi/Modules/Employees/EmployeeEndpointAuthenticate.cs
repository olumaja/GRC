using Arm.GrcApi.Modules.Security;
using Arm.GrcTool.Domain.Employee;
using Arm.GrcTool.Infrastructure;
using Azure.Core;
using FluentValidation;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.SessionManagement;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.ModelBinding;

namespace GrcApi.Modules.Employees
{
    public class EmployeeEndpointAuthenticate
    {
        public static async Task<IResult> HandleAsync(
             AuthenticateDto authenticateDto, IRepository<User> userRepo, IRepository<UserRole> roleRepo
            , IEmployeeService employeeService, IConfiguration config, IRepository<SessionTracker> sessionRepo
            , IJwtTokenGenerator jwtTokenGenerator, Serilog.ILogger logger
        )
        {
            try
            {
                var userSession = sessionRepo.GetContextByConditon(e => e.Email == authenticateDto.Email)
                                            .FirstOrDefault();

                if (userSession is not null && userSession.IsLock)
                    return TypedResults.Problem("Your account is locked, please contact the admin.", null, 401);

                if (userSession is not null && userSession.Token is not null)
                {
                    // Check if the user token has not expired
                    var expiredTimeStamp = Convert.ToInt64(jwtTokenGenerator.DecodeToken("exp", userSession.Token));
                    var tokenExpiryDate = DateTimeOffset.FromUnixTimeSeconds(expiredTimeStamp);

                    if(tokenExpiryDate >= DateTime.Now)
                        return TypedResults.Problem("You current have an existing session, kindly logout to continue", null, 401);
                }
                 
                Employee? employee = await employeeService.Authenticate(authenticateDto.Email, authenticateDto.Password);

                if (employee == null)
                {
                    if (userSession is not null)
                    {
                        userSession.UpdateNumberOfTry(userSession.NumberOfTry + 1);
                        userSession.UpdateLock(userSession.NumberOfTry >= Convert.ToInt32(config["UserLoginSetting:MaximumNumberOfTry"]) ? true : false);
                        userRepo.SaveChanges();
                    }

                    return TypedResults.Problem("Invalid email or password.", null, 401);
                }

                if (userSession is null)
                {
                    userSession = SessionTracker.Create(employee.UserName.ToLower(), employee.UserName.ToLower(), DateTime.Now, DateTime.Now);
                    sessionRepo.Add(userSession);
                }
                else
                {
                    userSession.UpdateLastLogin(DateTime.Now);
                }

                //Reset number of try after successful login
                userSession.UpdateNumberOfTry();
                var userDetails = userRepo.GetContextByConditon(u => u.Email.Equals(employee.UserName))
                                        .Include(u => u.UserRoleMap)
                                        .ThenInclude(m => m.Role)
                                        .FirstOrDefault();

                if (userDetails is not null && userDetails.Status == UserStatus.Disabled)
                    return TypedResults.Problem("Your account has been disabled, kindly contact the admin", null, 401);

                var jwtToken = string.Empty;
                var refreshToken = jwtTokenGenerator.GenerateRefreshToken();

                if (userDetails is null)
                {
                    jwtToken = jwtTokenGenerator.GenerateToken(employee.UserName, employee.Department);
                    userSession.UpdateToken(jwtToken);
                    userSession.UpdateRefreshToken(refreshToken, DateTime.Now.AddHours(Convert.ToDouble(config["JwtSettings:RefreshTokenExpiryHours"])));
                    sessionRepo.SaveChanges();

                    return TypedResults.Ok(await Task.FromResult(new AuthenticateResponseDto
                    (
                        AccessToken: jwtToken,
                        TokenType: "Bearer",
                        ExpiresIn: Convert.ToInt32(jwtTokenGenerator.GetJwtSettings().ExpiryMinutes),
                        RefreshToken: refreshToken
                    )));
                }

              var roles = userDetails.UserRoleMap.Select(u => u.Role.Name).ToList();

                var tokenizeUserDetails = new AuthenticatedUserDto(
                    //Name: fullName,
                    Name: userDetails.Name,
                    Email: userDetails.Email,
                    Business: userDetails.Business,
                    Department: employee.Department,
                    Unit: userDetails.Unit,
                    UnitId: userDetails.UnitId.ToString(),
                    Roles: roles
                );

                jwtToken = jwtTokenGenerator.GenerateToken(tokenizeUserDetails);
                userSession.UpdateToken(jwtToken);
                userSession.UpdateRefreshToken(refreshToken, DateTime.Now.AddHours(Convert.ToDouble(config["JwtSettings:RefreshTokenExpiryHours"])));
                sessionRepo.SaveChanges();

                return TypedResults.Ok(await Task.FromResult(new AuthenticateResponseDto
                (
                    AccessToken: jwtToken,
                    TokenType: "Bearer",
                    ExpiresIn: Convert.ToInt32(jwtTokenGenerator.GetJwtSettings().ExpiryMinutes),
                    RefreshToken: refreshToken
                )));
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                return TypedResults.Problem("Unable to submit the request");
            }
            
        }
    }

    public class AuthenticateDtoValidation : AbstractValidator<AuthenticateDto>
    {
        public AuthenticateDtoValidation()
        {
            RuleFor(x => x.Email).EmailAddress()
                .NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }

    public record AuthenticateDto(string Email, string Password);
    public record AuthenticateResponseDto(string AccessToken, string TokenType, int ExpiresIn, string RefreshToken);
    public record AuthenticatedUserDto(
         string Name, string Email, string Business, string Department, string Unit, string UnitId,
        List<string> Roles
    );
}
