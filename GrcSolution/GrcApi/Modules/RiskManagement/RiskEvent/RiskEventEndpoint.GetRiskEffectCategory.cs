using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement
{
    public class RiskEventEndpointGetRiskEffectCategory
    {
        public static async Task<IResult> HandleAsync(IRepository<RiskEffectCategory> repository, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            IList<RiskEffectCategory> riskEffectCategories = await repository.GetAllAsync();
            IList<RiskEffectCategoryDto> riskEffectCategoryDtos = riskEffectCategories.Select(r => new RiskEffectCategoryDto(r.Id, r.Name)).ToList();
            return TypedResults.Ok(riskEffectCategoryDtos);
        }

        public record RiskEffectCategoryDto(Guid Id, string RiskEffectCategoryName);
    }
}
