using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 07/11/2023
     * Development Group: GRCTools
     * This endpoint fetches all the started BIA from BusinessImpactAnalysis table on GrcToolDB.
     * The list of the records are paginated
    */
    public class GetAllStartedBIAEndpoint
    {
        /// <summary>
        /// This endpoint fetches all the started BIA from BusinessImpactAnalysis table on GrcToolDB.
        /// The list of the records are paginated
        /// </summary>
        /// <param name="user"></param>
        /// <param name="getAllStartedBIA"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(IRepository<BusinessImpactAnalysis> getAllStartedBIA, ClaimsPrincipal user, ICurrentUserService currentUserService, 
            int pageNumber = 0, int pageSize = 0
        )
        {
            //var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));
            var email = currentUserService.CurrentUserEmail;

            var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

            if (unitIdValue is null)
            {
                return TypedResults.Ok("Unit was not found");
            }

            Guid unitId = new Guid(unitIdValue.Value);
            var startedBIA = await getAllStartedBIA.GetAllPagedAsync(pageNumber, pageSize, t => t.Include(e => e.BusinessImpactAnalysisUnits).Select(r => new BusinessImpactAnalysisDto
            {
                BusinessImpactAnalysisId = r.Id,
                CreatedDate = r.CreatedOnUtc,
                PeriodFrom = r.PeriodFrom,
                PeriodTo = r.PeriodTo,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                BusinessImpactAnalysisUnits = r.BusinessImpactAnalysisUnits.Select(u => new BIAUnitDto(u.Unit.Id)).ToList(),
                NumberOfRiskControlSelfAssessmentUnits = r.BusinessImpactAnalysisUnits.Count()
            }));

            return TypedResults.Ok(startedBIA);
        }

    }
}
