using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 02/04/2024
   * Development Group: Audit plan Risk Assessment - GRCTools
   * This endpoint get Annual Audit Universe By anualAuditUniverseId
   */
    public class ViewArmTAMAudiPlanExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMTAM Audit Execution Plan By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="tamAnnualaudit"></param>
        /// <param name="tamreq"></param>
        /// <param name="commenceEng"></param>
        /// <param name="armTam"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> tamAnnualaudit,
            IRepository<ARMTAMAuditUniverse> tamreq, IRepository<CommenceEngagementAuditexecution> commenceEng,
            IRepository<AuditUniverseARMTAM> armTam, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                var year = DateTime.Now.Year;
                var getcommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == anualAuditUniverseId && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getcommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement must be done first");
                }
                var getRating = tamAnnualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = tamreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                }
                var getarmTam = armTam.GetContextByConditon(x => x.ARMTAMAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                ViewARMTAMAudiPlanExecutionByIdResp resp = new ViewARMTAMAudiPlanExecutionByIdResp
                {
                    ArmTAM = new ViewAudiPlanExecutionResponse
                    {
                        Month = "August",
                        Team = "ARMTAM",
                        Recommendation = getarmTam.Recommentation,
                        EngagementPlan = getAuditRating.EngagementPlan.ToString(),
                        WorkPaper = getAuditRating.WorkPaper.ToString(),
                        FindingStatus = getAuditRating.Findingstatus.ToString(),
                        CommenceEngagementId = getcommenceEng.Id
                    }
                };
                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
