using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GrcApi.Modules.Employees;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace Arm.GrcApi.Modules.Security
{


    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private JwtSettings _jwtSettings;

        public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(string userName, string department)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256
            );
            string email = userName;
            string[] parts = email.Split('@');
            string[] nameParts = parts[0].Split('.'); 
            string firstName = nameParts[0];

            string lastName = nameParts.Length > 1 ? nameParts[1] : "";

            string fullName = firstName + " " + lastName;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name,fullName.ToUpper()),
                //new Claim(JwtRegisteredClaimNames.Name,userName),
                new Claim(JwtRegisteredClaimNames.Email,userName),
                new Claim("department",department),
                new Claim("role", "Staff"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public string GenerateToken(AuthenticatedUserDto userDetails)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256
            );
            string email = userDetails.Email;
            string[] parts = email.Split('@');
            string[] nameParts = parts[0].Split('.');            
            string firstName = nameParts[0];
            //string fullName = firstName;
            string lastName = nameParts.Length > 1 ? nameParts[1] : "";
            string fullName = firstName + " " + lastName;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, fullName.ToUpper()),
                //new Claim(JwtRegisteredClaimNames.Name, userDetails.Name),
                new Claim(JwtRegisteredClaimNames.Email, userDetails.Email),
                new Claim("business", userDetails.Business),
                new Claim("department", userDetails.Department),
                new Claim("unit", userDetails.Unit),
                new Claim("unitId", userDetails.UnitId),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            foreach(var role in userDetails.Roles)
            {
                claims.Add(
                    new Claim("role", role)
                );
            }

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using(var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }

        public JwtSettings GetJwtSettings()
        {
            return _jwtSettings;
        }

        public string DecodeToken(string claimType, string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            return jsonToken.Claims.First(claim => claim.Type == claimType).Value;
        }
    }

    public class JwtSettings {

        public const string SectionName = "JwtSettings";
        public string Issuer { get; init; } = null!;
        public string Secret { get; init;} = null!;
        public double ExpiryMinutes { get; init;}
        public int RefreshTokenExpiryHours { get; init; }

    }
}


