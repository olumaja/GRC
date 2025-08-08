using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared;
using Microsoft.EntityFrameworkCore;
using GrcApi.Modules.Admin;

namespace Arm.GrcApi.Modules.Admin
{
    public class CreateUserEndpoint
    {
        /// <summary>
        /// This endpoint enable Admin and Super admin to create users
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <param name="userRepo"></param>
        /// <param name="userRoleMapRepo"></param>
        /// <param name="roleRepo"></param>
        /// <param name="businessRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            CreateUserDto createUserDto, IRepository<User> userRepo, IRepository<UserRoleMap> userRoleMapRepo, IRepository<UserRole> roleRepo, 
            IRepository<BusinessEntity> businessRepo, ICurrentUserService currentUserService
        )
        {
            if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin) && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.SuperAdmin))
                return TypedResults.Unauthorized();

            var newUserRole = await roleRepo.FirstOrDefaultAsync(r => r.Name == createUserDto.Role);

            if (newUserRole is null)
                return TypedResults.BadRequest($"{createUserDto.Role} is not among the recommended roles");

            if (currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin))
            {
                //Check the module that the admin belong to
                var moduleOfAdmin = (await userRepo.FirstOrDefaultAsync(m => m.Email == currentUserService.CurrentUserEmail)).ModuleItemType;

                if (moduleOfAdmin != newUserRole.ModuleItemType)
                    return TypedResults.BadRequest("You can only create users in your module");
            }
            
            var userExist = userRepo.GetContextByConditon(u => u.Email.ToLower() == createUserDto.Email.ToLower())
                                .Include(u => u.UserRoleMap)
                                .ThenInclude(m => m.Role)
                                .FirstOrDefault();

            if (userExist is not null)
            {
                var roles = userExist.UserRoleMap.Select(r => r.Role.Name);

                if (roles.Contains(createUserDto.Role))
                    return TypedResults.BadRequest($"{userExist.Name} already exist as an {createUserDto.Role}");

                userExist.SetModifiedBy(currentUserService.CurrentUserFullName);
                userExist.SetModifiedOnUtc(DateTime.Now);
                userRoleMapRepo.Add(UserRoleMap.Create(userId: userExist.Id, roleId: newUserRole.Id));
                userRoleMapRepo.SaveChanges();

                return TypedResults.Created($"ar/{userExist.Id}", userExist.Id);
            }

            var business = businessRepo.GetContextByConditon(b => b.Name.ToLower() == createUserDto.Business.ToLower())
                                        .Include(b => b.Departments)
                                        .ThenInclude(d => d.Units)
                                        .FirstOrDefault();

            if (business is null)
                return TypedResults.BadRequest("Business does not exist");

            var dept = business.Departments.Where(d => d.Name.ToLower() == createUserDto.Department.ToLower())
                                .FirstOrDefault();

            if (dept is null)
                return TypedResults.BadRequest($"Department does not exist in the selected business {business}");

            var unit = dept.Units.Where(u => u.Name.ToLower() == createUserDto.Unit.ToLower())
                            .FirstOrDefault();

            if (unit is null)
                return TypedResults.BadRequest($"Unit does not exist in the selected department {dept}");

            var user = User.Create(createUserDto.Name, createUserDto.Email, createUserDto.Business, createUserDto.Unit, unit.Id, createUserDto.Department);
            user.SetCreatedBy(currentUserService.CurrentUserFullName);
            user.SetModifiedBy(currentUserService.CurrentUserFullName);
            user.SetModifiedOnUtc(DateTime.Now);
            userRepo.Add(user);

            userRoleMapRepo.Add(UserRoleMap.Create(userId: user.Id, roleId: newUserRole.Id));
            userRoleMapRepo.SaveChanges();

            var response = user.Id;

            return TypedResults.Created($"ar/{response}", response);
        }
    }
}
