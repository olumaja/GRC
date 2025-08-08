using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Admin;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.SessionManagement;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.Admin
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 19/03/2025
        * Development Group: GRCTools
        * Get User by Id Endpoint.     
        */
    public class ViewUserByIdEndpoint
    {
        /// <summary>
        /// View User detail by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repository"></param>
        /// <param name="lastLogin"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
             Guid id, IRepository<User> repository, IRepository<SessionTracker> lastLogin, IRepository<Department> deptRepo, IRepository<Unit> unitRepo
         )
        {
            var getById = repository.GetContextByConditon(x => x.Id == id)
                .Include(u => u.UserRoleMap)
                .ThenInclude(r => r.Role)
                .ThenInclude(s => s.UserRolePermissions)
                .ThenInclude(p => p.Permission)
                .FirstOrDefault();

            if (getById is null) return TypedResults.NotFound($"User was not found");
            var unitId = getById.UnitId;
            var unit = await unitRepo.GetByIdAsync(unitId);
            var dept = await deptRepo.GetByIdAsync(unit.DepartmentId);
            var businessId = dept.BusinessEntityId;

            var getlastLogin = lastLogin.GetContextByConditon(x => x.Email == getById.Email).FirstOrDefault();
            DateTime? lastlogon = null;

            if (getlastLogin != null) { lastlogon = getlastLogin.LastLogin; }

            var roles = getById.UserRoleMap.Select(x => x.Role.Name)
                                .ToList();

            var permissions = getById.UserRoleMap.SelectMany(x =>
                 x.Role.UserRolePermissions.Select(u => new PermissionResponse
                 {
                     Name = u.Permission.Name,
                     Module = u.Permission.Module
                 }).ToList()
            ).ToList();

            var response = new ViewUserResp
            {
                UserId = getById.Id,
                Name = getById.Name,
                Entity = getById.Business,
                BusinessId = businessId,
                Department = dept.Name,
                DepartmentId = dept.Id,
                Unit = getById.Unit,
                UnitId = getById.UnitId,
                Status = getById.Status.ToString(),
                Email = getById.Email,
                Role = string.Join(",", roles),
                Module = getById.ModuleItemType.ToString(),
                DateCreated = getById.CreatedOnUtc,
                LastUpdated = getById.ModifiedOnUtc,
                LastLogon = lastlogon,
                Permissions = permissions
            };

            return TypedResults.Ok(response);
        }
    }
}
