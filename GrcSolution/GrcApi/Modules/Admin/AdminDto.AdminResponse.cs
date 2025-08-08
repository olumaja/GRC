using GrcApi.Modules.Shared.Helpers;

namespace GrcApi.Modules.Admin
{
    public record AdminResponse(int TotoalUser, int SuperAdminCount, int AdminCount, PaginationMeta PaginationMeta, List<AdminResp> Admins);
    public record AdminResp(Guid Id, string Name, string Email, DateTime DateCreated, string Role, string Status, DateTime? LastModified);

    public record UserResponse(int TotoalUser, int TotalActiveUser, int TotalDisabledUser, PaginationMeta PaginationMeta, List<UserResp> Users);
    public record UserResp(
        Guid Id, string Name, string Email, string Business, string? Department, string Unit, DateTime DateCreated, string Role, 
        DateTime? LastLogin, string Status, DateTime? LastModified
    );

    public class Usersession {
        public string Email { get; set; }
        public DateTime Lastlogin { get; set; }
    }

    public class ModuleTypeResponse {
       public string Name { get; set; }
    }
}
