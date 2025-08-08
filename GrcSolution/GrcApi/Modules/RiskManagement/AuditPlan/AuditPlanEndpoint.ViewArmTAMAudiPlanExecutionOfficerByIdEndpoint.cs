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
    public class ViewArmTAMAudiPlanExecutionOfficerByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMTAM Audit Execution Plan By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="tamannualaudit"></param>
        /// <param name="tamreq"></param>
        /// <param name="tamRating"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> tamannualaudit,
            IRepository<ARMTAMAuditUniverse> tamreq, IRepository<AuditUniverseARMTAM> tamRating, IRepository<CommenceEngagementAuditexecution> commenceEng,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var year = DateTime.Now.Year;

                var getRating = tamannualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = tamreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                }
                Guid getcommenceEngId = Guid.Empty;
                var engagementPlan = BusinessRiskRatingStatus.Pending.ToString();
                var workPaper = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatus = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getCommenceEng != null)
                {
                    engagementPlan = BusinessRiskRatingStatus.Completed.ToString();
                    workPaper = BusinessRiskRatingStatus.Completed.ToString();
                    findingStatus = BusinessRiskRatingStatus.Completed.ToString();
                    getcommenceEngId = getCommenceEng.Id;
                }
                var gettamRating = tamRating.GetContextByConditon(x => x.ARMTAMAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                ViewARMTAMAudiPlanExecutionByIdResp resp = new ViewARMTAMAudiPlanExecutionByIdResp
                {
                    ArmTAM = new ViewAudiPlanExecutionResponse
                    {
                        Month = "May",
                        Team = "ARMTAM",
                        Recommendation = gettamRating.Recommentation,
                        EngagementPlan = engagementPlan,
                        WorkPaper = engagementPlan,
                        FindingStatus = engagementPlan,
                        CommenceEngagementId = getcommenceEngId
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
