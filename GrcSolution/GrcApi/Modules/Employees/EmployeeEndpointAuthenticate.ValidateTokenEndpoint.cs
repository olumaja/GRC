using Arm.GrcApi.Modules.Security;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.SessionManagement;
using System.Security.Claims;

namespace GrcApi.Modules.Employees
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 5/07/2024
      * Development Group: GRCTools
      * Validate access token.     
      */
    public class ValidateTokenEndpoint
    {
        /// <summary>
        /// Validate access token
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="sessionRepo"></param>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        /// <param name="jwtTokenGenerator"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ValidateTokenDto payload, IRepository<SessionTracker> sessionRepo, IConfiguration configuration,
            Serilog.ILogger logger, IJwtTokenGenerator jwtTokenGenerator
        )
        {
            try
            {
                var validIssuer = configuration["JwtSettings:Issuer"];
                var secret = configuration["JwtSettings:Secret"];
                var principal = TokenValidation.GetPrincipalFromExpiredToken(payload.AccessToken, validIssuer, secret);

                if (principal is null || principal.Claims.First(claim => claim.Type == ClaimTypes.Email).Value is null)
                    return TypedResults.Unauthorized();

                // Check if the user token has not expired
                var expiredTimeStamp = Convert.ToInt64(jwtTokenGenerator.DecodeToken("exp", payload.AccessToken));
                var tokenExpiryDate = DateTimeOffset.FromUnixTimeSeconds(expiredTimeStamp);

                if (tokenExpiryDate < DateTime.Now)
                    return TypedResults.Unauthorized();

                var currentEmail = principal.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
                var currentUser = await sessionRepo.FirstOrDefaultAsync(x => x.Email == currentEmail);

                if (currentUser is null || currentUser.Token != payload.AccessToken)
                    return TypedResults.Unauthorized();

                return TypedResults.Ok("Token validation successful");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return TypedResults.Problem("Unable to submit the request");
            }
        }
    }

    public record ValidateTokenDto(string AccessToken);

    public class ValidateTokenDtoValidator : AbstractValidator<ValidateTokenDto>
    {
        public ValidateTokenDtoValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty();
        }
    }
}
