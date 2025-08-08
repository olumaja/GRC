using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Admin;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.SessionManagement;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.Admin
{
    /// <summary>
    /// The endpoint get roles and their permissions
    /// </summary>
    public class RoleEndpoint
    {
        public static async Task<IResult> HandleAsync(IRepository<UserRole> userRoleRepo, IRepository<User> userRepo, ICurrentUserService currentUserService)
        {
            if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin) && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.SuperAdmin))
                return TypedResults.Unauthorized();

            var roles = userRoleRepo.GetContextByConditon(u => u.Name != GRCUserRole.Admin && u.Name != GRCUserRole.SuperAdmin)
                                    .Include(r => r.UserRolePermissions)
                                    .ThenInclude(p => p.Permission)
                                    .ToList();

            if (currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin))
            {
                var currentUser = await userRepo.FirstOrDefaultAsync(u => u.Email == currentUserService.CurrentUserEmail);
                roles = roles.Where(r => r.ModuleItemType == currentUser.ModuleItemType)
                    .ToList();
            }

            var response = roles.Select(r => new RoleResponse {
                RoleId = r.Id, 
                RoleName = r.Name,
                Permissions = r.UserRolePermissions.Select(r => new PermissionResponse { Name = r.Permission.Name, Module = r.Permission.Module }).ToList(),
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
