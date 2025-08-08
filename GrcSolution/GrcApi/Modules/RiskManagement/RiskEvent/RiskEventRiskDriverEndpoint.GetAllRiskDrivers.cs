using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public class RiskEventRiskDriverEndpointGetAllRiskDrivers
    {
        public static async Task<IResult> HandleAsync(IRepository<RiskDriver> repository, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            IList<RiskDriverDto> riskDriverDtos = (await repository.GetAllAsync()).Select(d =>
                        new RiskDriverDto(
                            d.Name,
                            d.Id
                            )).ToList();
            return TypedResults.Ok(riskDriverDtos);
        }
    }
}
