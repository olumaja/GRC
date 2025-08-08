using Arm.GrcTool.Domain.Risk;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement
{
    public class RiskEventTypeEndpointGetEventCategory
    {
        public static IResult HandleAsync(Guid riskEventTypeId, IRepository<RiskEventTypeCategory> repository,ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
			try
			{
                //var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));
                var email = currentUserService.CurrentUserEmail;

                if (string.IsNullOrWhiteSpace(email))
                {
                    return TypedResults.Unauthorized();
                }

                var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

                if (unitIdValue is null)
                {
                    return TypedResults.Ok("Unit was not found");
                }

                Guid unitId = new Guid(unitIdValue.Value);
                var eventTypeCategories = repository
                    .GetContextByConditon(e => e.RiskEventTypeId.Equals(riskEventTypeId))
                    .Include(e => e.RiskEventTypeSubCategories).ToList();

                IList<RiskEventTypeCategoryDto> categoryDtos = eventTypeCategories
                    .Select(c => new RiskEventTypeCategoryDto(c.Id, c.Name, c.RiskEventTypeSubCategories
                    .Select(b => new RiskEventTypeSubcategoryDto(b.Id, b.Name)).ToList()
                    )).ToList();

                return TypedResults.Ok(categoryDtos);
            }
			catch (Exception ex)
			{

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
