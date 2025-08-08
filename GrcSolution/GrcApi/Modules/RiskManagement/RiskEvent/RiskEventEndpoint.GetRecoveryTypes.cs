using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public class RiskEventEndpointGetRecoveryTypes
    {
        public static async Task<IResult> HandleAsync(IRepository<RecoveryType> repository, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            IList<RecoveryTypeDto> recoveryTypes = (await repository.GetAllAsync())
                .Select(r => new RecoveryTypeDto(r.Id, r.Name)).ToList();
            
            return TypedResults.Ok(recoveryTypes);
        }
    }

    public record RecoveryTypeDto(Guid Id, string Name);
}
