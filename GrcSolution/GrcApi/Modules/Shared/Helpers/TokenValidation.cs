using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GrcApi.Modules.Shared.Helpers
{
    public class TokenValidation
    {
        public static ClaimsPrincipal? GetPrincipalFromExpiredToken(string token, string validIssuer, string secret)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = validIssuer,
                    ValidAudience = validIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(secret)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };

                return new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out _);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
