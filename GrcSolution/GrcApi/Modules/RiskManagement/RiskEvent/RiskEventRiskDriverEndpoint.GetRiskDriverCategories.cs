using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public class RiskEventRiskDriverEndpointGetRiskDriverCategories
    {
        public static IResult HandleAsync(Guid riskDriverId, IRepository<RiskDriverCategory> repository, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            var riskDriverCategories = repository
                .GetContextByConditon(r => r.RiskDriverId.Equals(riskDriverId))
                .Include(r => r.RiskDriverSubCategories).ToList();

            IList<RiskEventRiskDriverCategoryDto> riskDriverCategoryDtos = riskDriverCategories
                .Select(c => new RiskEventRiskDriverCategoryDto(c.Id, c.Name, c.RiskDriverSubCategories
                .Select(s => new RiskEventRiskDriverSubcategoryDto(s.Id, s.Name)).ToList()
                )).ToList();

            return TypedResults.Ok(riskDriverCategoryDtos);
        }
    }
}
