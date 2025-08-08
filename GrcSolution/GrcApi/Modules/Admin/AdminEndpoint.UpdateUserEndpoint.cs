using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Admin;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.Admin
{
    public class UpdateUserEndpoint
    {
        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="updateUserDto"></param>
        /// <param name="userRepo"></param>
        /// <param name="roleRepo"></param>
        /// <param name="businessRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
           UpdateUserDto updateUserDto, IRepository<User> userRepo, IRepository<UserRole> roleRepo,
           IRepository<BusinessEntity> businessRepo, ICurrentUserService currentUserService
        )
        {
            if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin) && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.SuperAdmin))
                return TypedResults.Unauthorized();

            var userExist = userRepo.GetContextByConditon(u => u.Id == updateUserDto.UserId)
                                .Include(u => u.UserRoleMap)
                                .ThenInclude(m => m.Role)
                                .FirstOrDefault();

            if (userExist is null)
                return TypedResults.NotFound("User does not exist");

            if (currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin))
            {
                //Check the module that the admin belong to
                var moduleOfAdmin = (await userRepo.FirstOrDefaultAsync(m => m.Email == currentUserService.CurrentUserEmail)).ModuleItemType;
                var rolesWithinAdminModule = roleRepo.GetContextByConditon(r => r.ModuleItemType == moduleOfAdmin)
                                                .Select(r => r.Name)
                                                .ToList();

                var existingUserRoles = userExist.UserRoleMap.Select(r => r.Role.Name)
                                                    .ToList();

                var rolesCommonToAdminAndUser = rolesWithinAdminModule.Intersect(existingUserRoles);

                if (rolesCommonToAdminAndUser.Count() == 0)
                    return TypedResults.BadRequest("You can only Update users within your module");
            }

            var business = businessRepo.GetContextByConditon(b => b.Name.ToLower() == updateUserDto.Business.ToLower())
                                        .Include(b => b.Departments)
                                        .ThenInclude(d => d.Units)
                                        .FirstOrDefault();

            if (business is null)
                return TypedResults.BadRequest("Business does not exist");

            var dept = business.Departments.Where(d => d.Name.ToLower() == updateUserDto.Department.ToLower())
                                .FirstOrDefault();

            if (dept is null)
                return TypedResults.BadRequest($"Department does not exist in the selected business {business}");

            var unit = dept.Units.Where(u => u.Name.ToLower() == updateUserDto.Unit.ToLower())
                            .FirstOrDefault();

            if (unit is null)
                return TypedResults.BadRequest($"Unit does not exist in the selected department {dept}");

            userExist.Update(new UpdateUser(
                Name: updateUserDto.Name,
                Email: updateUserDto.Email,
                Business: updateUserDto.Business,
                Department: updateUserDto.Department,
                Unit: updateUserDto.Unit,
                UnitId: unit.Id
            ));
            
            userExist.SetModifiedBy(currentUserService.CurrentUserFullName);
            userExist.SetModifiedOnUtc(DateTime.Now);
            userRepo.Update(userExist);
            userRepo.SaveChanges();
            return TypedResults.Ok("User update successful");
        }
    }
}
