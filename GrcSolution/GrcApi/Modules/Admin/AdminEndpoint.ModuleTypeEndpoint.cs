using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Admin;

namespace Arm.GrcApi.Modules.Admin
{
    public class ModuleTypeEndpoint
    {
        public static async Task<IResult> HandleAsync(IRepository<UserRole> roleRepo, ICurrentUserService currentUserService)
        {
            if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.SuperAdmin) && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.Admin))
                return TypedResults.Unauthorized();

            var modules = roleRepo.GetContextByConditon(r => r.ModuleItemType != null)
                                    .Select(r => r.ModuleItemType.Value.GetEnumDestription())
                                    .ToHashSet();

            var response = modules.Select(module => new ModuleTypeResponse {Name = module})
                                    .ToList();

            return TypedResults.Ok(response);
        }
    }
}
