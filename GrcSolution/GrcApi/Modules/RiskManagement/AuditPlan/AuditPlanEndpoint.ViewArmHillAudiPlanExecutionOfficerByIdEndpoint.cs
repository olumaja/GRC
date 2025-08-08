using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 02/04/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * This endpoint get Annual Audit Universe By anualAuditUniverseId
  */
    public class ViewArmHillAudiPlanExecutionOfficerByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMHill Audit Execution Plan By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="hillannualaudit"></param>
        /// <param name="hillreq"></param>
        /// <param name="hillRating"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> hillannualaudit,
            IRepository<ARMHillAuditUniverse> hillreq, IRepository<AuditUniverseARMHill> hillRating, IRepository<CommenceEngagementAuditexecution> commenceEng,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var getRating = hillannualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = hillreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                }
                Guid getcommenceEngId = Guid.Empty;
                var engagementPlan = BusinessRiskRatingStatus.Pending.ToString();
                var workPaper = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatus = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "ARMHill").FirstOrDefault();
                if (getCommenceEng != null)
                {
                    engagementPlan = getCommenceEng.EngagementPlan.ToString();
                    workPaper = getCommenceEng.WorkPaper.ToString();
                    findingStatus = getCommenceEng.WorkPaper.ToString();
                    getcommenceEngId = getCommenceEng.Id;
                }
                var gethillRating = hillRating.GetContextByConditon(x => x.ARMHillAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string month = "January";
                string recommendation = "Full Scope";
                if (!string.IsNullOrEmpty(gethillRating.January))
                {
                    month = "January";
                    recommendation = gethillRating.January;
                }
                if (!string.IsNullOrEmpty(gethillRating.February))
                {
                    month = "February";
                    recommendation = gethillRating.February;
                }
                if (!string.IsNullOrEmpty(gethillRating.March))
                {
                    month = "March";
                    recommendation = gethillRating.March;
                }
                if (!string.IsNullOrEmpty(gethillRating.April))
                {
                    month = "April";
                    recommendation = gethillRating.April;
                }
                if (!string.IsNullOrEmpty(gethillRating.May))
                {
                    month = "May";
                    recommendation = gethillRating.May;
                }
                if (!string.IsNullOrEmpty(gethillRating.June))
                {
                    month = "June";
                    recommendation = gethillRating.June;
                }
                if (!string.IsNullOrEmpty(gethillRating.July))
                {
                    month = "July";
                    recommendation = gethillRating.July;
                }
                if (!string.IsNullOrEmpty(gethillRating.August))
                {
                    month = "August";
                    recommendation = gethillRating.August;
                }
                if (!string.IsNullOrEmpty(gethillRating.September))
                {
                    month = "September";
                    recommendation = gethillRating.September;
                }
                if (!string.IsNullOrEmpty(gethillRating.October))
                {
                    month = "October";
                    recommendation = gethillRating.October;
                }
                if (!string.IsNullOrEmpty(gethillRating.November))
                {
                    month = "November";
                    recommendation = gethillRating.November;
                }
                if (!string.IsNullOrEmpty(gethillRating.December))
                {
                    month = "December";
                    recommendation = gethillRating.December;
                }

                ViewARMHillAudiPlanExecutionByIdResp resp = new ViewARMHillAudiPlanExecutionByIdResp
                {
                    ARMHill = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "ARMHill",
                        Recommendation = recommendation,
                        EngagementPlan = engagementPlan,
                        WorkPaper = workPaper,
                        FindingStatus = findingStatus,
                        CommenceEngagementId = getcommenceEngId

                    }
                };
                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
