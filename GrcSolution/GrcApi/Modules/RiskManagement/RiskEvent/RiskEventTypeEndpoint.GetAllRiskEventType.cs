using Arm.GrcTool.Domain.Risk;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement
{
    public class RiskEventTypeEndpointGetAllRiskEventType
    {
        public static async Task<IResult> HandleAsync(IRepository<RiskEventType> repository, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                IList<RiskEventType> riskEvents = await repository.GetAllAsync();
                IList<RiskEventTypeDto> riskEventTypeDtos = riskEvents.Select(r => new RiskEventTypeDto(r.Id, r.Name)).ToList();
                return TypedResults.Ok(riskEventTypeDtos);
            }
			catch (Exception ex)
			{

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
