using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Admin;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.Admin
{
    public class CreateAdminEndpoint
    {
        /// <summary>
        /// This endpoint enable super admin to create admins for different modules
        /// </summary>
        /// <param name="adminDto"></param>
        /// <param name="userRepo"></param>
        /// <param name="userRoleMapRepo"></param>
        /// <param name="businessRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            AdminDto adminDto, IRepository<User> userRepo, IRepository<UserRoleMap> userRoleMapRepo,
            IRepository<BusinessEntity>  businessRepo, ICurrentUserService currentUserService
        )
        {
            var moduleType = new Dictionary<string, ModuleType>
            {
                {"internal audit", ModuleType.InternalAudit },
                {"risk management", ModuleType.RiskManagement },
                {"compliance", ModuleType.Compliance },
                {"internal control", ModuleType.InternalControl },
                {"operation control", ModuleType.OperationControl },
                {"information security",  ModuleType.InformationSecurity}
            };

            var module = adminDto.Module.ToLower();

            if (!moduleType.ContainsKey(module))
                return TypedResults.BadRequest("Please enter one of the recommmended modules");

            var admin = userRepo.GetContextByConditon(u => u.Email.ToLower() == adminDto.Email.ToLower())
                                .Include(u => u.UserRoleMap)
                                .ThenInclude(m => m.Role)
                                .FirstOrDefault();

            if (admin is not null)
            {
                var roles = admin.UserRoleMap.Select(r => r.Role.Name);

                if(roles.Contains(GRCUserRole.Admin))
                    return TypedResults.BadRequest($"{admin.Name} already exist as an {GRCUserRole.Admin}");

                admin.AddModule(moduleType[module]);
                admin.SetModifiedBy(currentUserService.CurrentUserFullName);
                admin.SetModifiedOnUtc(DateTime.Now);
                userRoleMapRepo.Add(UserRoleMap.Create(userId: admin.Id, roleId: new Guid(UserRoleSeedGuids.Admin)));
                userRoleMapRepo.SaveChanges();

                return TypedResults.Created($"ar/{admin.Id}", admin.Id);
            }

            var business = businessRepo.GetContextByConditon(b => b.Name.ToLower() == adminDto.Business.ToLower())
                                        .Include(b => b.Departments)
                                        .ThenInclude(d => d.Units)
                                        .FirstOrDefault();

            if (business is null)
                return TypedResults.BadRequest("Business does not exist");

            var dept = business.Departments.Where(d => d.Name.ToLower() == adminDto.Department.ToLower())
                                .FirstOrDefault();

            if (dept is null)
                return TypedResults.BadRequest($"Department does not exist in the selected business {business}");

            var unit = dept.Units.Where(u => u.Name.ToLower() == adminDto.Unit.ToLower())
                            .FirstOrDefault();

            if(unit is null)
                return TypedResults.BadRequest($"Unit does not exist in the selected department {dept}");

            var user = User.Create(adminDto.Name, adminDto.Email, adminDto.Business, adminDto.Unit, unit.Id, adminDto.Department, moduleType[module]);
            user.SetCreatedBy(currentUserService.CurrentUserFullName);
            user.SetModifiedBy(currentUserService.CurrentUserFullName);
            user.SetModifiedOnUtc(DateTime.Now);
            userRepo.Add(user);
            
            userRoleMapRepo.Add(UserRoleMap.Create(userId: user.Id, roleId: new Guid(UserRoleSeedGuids.Admin)));
            userRoleMapRepo.SaveChanges();

            var response = user.Id;

            return TypedResults.Created($"ar/{response}", response);
        }
    }
}
