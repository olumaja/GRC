using Microsoft.IdentityModel.Protocols.WsFed;
using System.Security.Claims;

namespace GrcApi.Modules.Shared.Helpers
{
    public interface ICurrentUserService
    {
        string? CurrentUserEmail { get; }
        string? CurrentUserFullName { get; }
        string? CurrentUserBusiness { get; }
        string? CurrentUserDepartment { get; }
        Guid? CurrentUserUnitId { get; }
        string? CurrentUserUnitName { get; }
        List<string> CurrentUserRoles { get; }
        long? CurrentUserTokenExpire { get; }
    }

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string? CurrentUserEmail {
            get
            {
                return httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
            }
        }

        public string? CurrentUserFullName
        {
            get
            {
                return httpContextAccessor.HttpContext?.User.FindFirst("name")?.Value;
            }
        }

        public string? CurrentUserBusiness
        {
            get
            {
                return httpContextAccessor.HttpContext?.User.FindFirst("business")?.Value;
            }
        }

        public string? CurrentUserDepartment
        {
            get
            {
                return httpContextAccessor.HttpContext?.User.FindFirst("department")?.Value;
            }
        }

        public Guid? CurrentUserUnitId
        {
            get
            {
                var unitId = httpContextAccessor.HttpContext?.User.FindFirst("unitId")?.Value;
                if(!string.IsNullOrWhiteSpace(unitId))
                    return Guid.Parse(unitId);

                return null;
            }
        }

        public string? CurrentUserUnitName
        {
            get
            {
                return httpContextAccessor.HttpContext?.User.FindFirst("unit")?.Value;
            }
        }

        public List<string> CurrentUserRoles
        {
            get
            {
                var type = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
                var roles = httpContextAccessor.HttpContext?.User.Claims.Where(r => r.Type == type)
                                            .Select(r => r.Value)
                                            .ToList();
                return roles;
            }
        }

        public long? CurrentUserTokenExpire
        {
            get {
                var exp = httpContextAccessor.HttpContext?.User.FindFirst("exp")?.Value;
                if(!string.IsNullOrWhiteSpace(exp))
                    return Convert.ToInt64(exp);

                return null;
            }
        }
    }
}
