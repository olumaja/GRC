using Arm.GrcApi.Modules.Security;
using Arm.GrcTool.Domain.Employee;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.SessionManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.WsFed;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GrcApi.Modules.Employees
{
    public class RefreshTokenEndpoint
    {
        public static async Task<IResult> HandleAsync(
            RefreshTokenDto payload, IRepository<SessionTracker> sessionRepo, IConfiguration configuration, IRepository<User> userRepo,
            IJwtTokenGenerator jwtTokenGenerator, Serilog.ILogger logger
        )
        {
            try
            {
                var validIssuer = configuration["JwtSettings:Issuer"];
                var secret = configuration["JwtSettings:Secret"];
                var principal = TokenValidation.GetPrincipalFromExpiredToken(payload.AccessToken, validIssuer, secret);

                if (principal is null || principal.Claims.First(claim => claim.Type == ClaimTypes.Email).Value is null)
                    return TypedResults.Unauthorized();

                var currentEmail = principal.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
                var currentUser = await sessionRepo.FirstOrDefaultAsync(x => x.Email == currentEmail);

                if (currentUser is null || currentUser.RefreshToken != payload.RefreshToken || currentUser.RefreshTokenExpiryDate < DateTime.Now)
                    return TypedResults.Unauthorized();

                var userDetails = userRepo.GetContextByConditon(u => u.Email.Equals(currentEmail))
                                          .Include(u => u.UserRoleMap)
                                          .ThenInclude(m => m.Role)
                                          .ToList();

                var department = jwtTokenGenerator.DecodeToken("department", payload.AccessToken);
                var jwtToken = string.Empty;

                if (userDetails.Count == 0)
                {
                    jwtToken = jwtTokenGenerator.GenerateToken(currentEmail, department);
                    currentUser.UpdateToken(jwtToken);
                    sessionRepo.SaveChanges();

                    return TypedResults.Ok(await Task.FromResult(new AuthenticateResponseDto
                        (
                            AccessToken: jwtToken,
                            TokenType: "Bearer",
                            ExpiresIn: Convert.ToInt32(jwtTokenGenerator.GetJwtSettings().ExpiryMinutes),
                            RefreshToken: payload.RefreshToken
                        )));
                }

                var roles = new List<string>();

                foreach (var detail in userDetails)
                {
                    foreach (var mapUserRole in detail.UserRoleMap)
                    {
                        roles.Add(mapUserRole.Role.Name);
                    }
                }

                var tokenizeUserDetails = new AuthenticatedUserDto(
                    Name: userDetails[0].Name,
                    Email: userDetails[0].Email,
                    Business: userDetails[0].Business,
                    Department: department,
                    Unit: userDetails[0].Unit,
                    UnitId: userDetails[0].UnitId.ToString(),
                    Roles: roles
                );

                jwtToken = jwtTokenGenerator.GenerateToken(tokenizeUserDetails);
                currentUser.UpdateToken(jwtToken);
                sessionRepo.SaveChanges();

                return TypedResults.Ok(await Task.FromResult(new AuthenticateResponseDto
                (
                    AccessToken: jwtToken,
                    TokenType: "Bearer",
                    ExpiresIn: Convert.ToInt32(jwtTokenGenerator.GetJwtSettings().ExpiryMinutes),
                    RefreshToken: payload.RefreshToken
                )));
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                return TypedResults.Problem("Unable to submit the request");
            }
        }
    }

    public record RefreshTokenDto(string AccessToken, string RefreshToken);

    public class RefreshTokenDtoValidator : AbstractValidator<RefreshTokenDto>
    {
        public RefreshTokenDtoValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty();
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
