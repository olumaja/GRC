using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace GrcApi.Modules.RiskManagement.BIA
{
    /*
     * Author: Olusegun Adaramaja
     * Date created: 08/12/2023
     * Development Group: GRCTools
     * The endpoint get all business impact analysis for risk management after risk champion unit head approved
     */
    public class GetAllBusinessImpactAnalysisForRiskManagementEndpoint
    {
        /// <summary>
        /// Get all business impact analysis for risk management after risk champion unit head approved
        /// </summary>
        /// <param name="biaUnitRepo"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<BusinessImpactAnalysisUnit> biaUnitRepo, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
            var biaList = biaUnitRepo.GetAll()
            .Where(r => r.Stage.Equals(BIAStage.RiskManagementFinal) || r.Stage.Equals(BIAStage.End))
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

            return TypedResults.Ok(biaList);
        }
    }
}
