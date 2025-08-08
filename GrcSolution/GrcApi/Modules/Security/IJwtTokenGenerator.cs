using GrcApi.Modules.Employees;

namespace Arm.GrcApi.Modules.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username, string department);
        string GenerateToken(AuthenticatedUserDto userDetails);
        string GenerateRefreshToken();
        JwtSettings GetJwtSettings();
        string DecodeToken(string claimType, string token);
    }
}