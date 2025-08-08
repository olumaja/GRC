using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.BIA;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public class GetAllBusinessImpactAnalysisForRiskChampionHeadEndpoint
    {
        public static async Task<IResult> HandleAsync(IRepository<BusinessImpactAnalysisUnit> biaUnitRepo, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            //var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));

            //if (email is null)
            //{
            //    return TypedResults.BadRequest("User must be logged in");
            //}
            //var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

            //if (unitIdValue is null)
            //{
            //    return TypedResults.Ok("Unit was not found");
            //}

            //Guid unitId = new Guid(unitIdValue.Value);
            
            var biaList = biaUnitRepo.GetAll()
            .Where(r => r.Stage.Equals(BIAStage.RiskChampionHeadInitiateBIA))
            .Select(r => new GetAllBIAForRiskChampionDto(
                r.Id, 
                r.BusinessImpactAnalysis.Id, 
                r.Unit.Name, r.UnitId, r.Status, 
                r.BusinessImpactAnalysis.CreatedOnUtc, 
                r.BusinessImpactAnalysis.PeriodFrom, 
                r.BusinessImpactAnalysis.PeriodTo, 
                r.BusinessImpactAnalysis.StartDate, 
                r.BusinessImpactAnalysis.EndDate
            )).ToList();

            if (biaList.Count > 0)
            {
                return TypedResults.Ok(biaList);

            }
            return TypedResults.NotFound("Record not found");
        }
    }
}
