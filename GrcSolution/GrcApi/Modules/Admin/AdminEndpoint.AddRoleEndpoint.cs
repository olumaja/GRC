using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Admin;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.Admin
{
    public class AddRoleEndpoint
    {
        public static async Task<IResult> HandleAsync(ChangeUserRole changeUserRole, IRepository<User> userRepo, IRepository<UserRole> roleRepo,
            IRepository<UserRoleMap> userRoleMapRepo, ICurrentUserService currentUserService
        )
        {
            if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.SuperAdmin) && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin))
                return TypedResults.Unauthorized();

            var user = await userRepo.FirstOrDefaultAsync(m => m.Email == changeUserRole.UserEmail);

            if (user is null)
                return TypedResults.BadRequest($"User {changeUserRole.UserName} does not exist");

            var role = await roleRepo.FirstOrDefaultAsync(r => r.Name == changeUserRole.Role);

            if (role is null)
                return TypedResults.BadRequest($"Role {changeUserRole.Role} does not exist");

            if (currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin))
            {
                //Check the module that the admin belong to
                var moduleOfAdmin = (await userRepo.FirstOrDefaultAsync(m => m.Email == currentUserService.CurrentUserEmail)).ModuleItemType;

                if (moduleOfAdmin != role.ModuleItemType)
                    return TypedResults.BadRequest("You can only add new roles within your module to user");
            }

            //Add new role to user
            var userRoleMap = await userRoleMapRepo.FirstOrDefaultAsync(u => u.UserId == user.Id && u.RoleId == role.Id);

            if (userRoleMap != null)
                return TypedResults.BadRequest($"Role {changeUserRole.Role} has already been added to {changeUserRole.UserName}");

            user.SetModifiedBy(currentUserService.CurrentUserFullName);
            user.SetModifiedOnUtc(DateTime.Now);
            userRoleMapRepo.Add(UserRoleMap.Create(user.Id, role.Id));
            userRoleMapRepo.SaveChanges();

            return TypedResults.Ok($"Role {changeUserRole.Role} has been added to {changeUserRole.UserName}");
        }
    }
}
