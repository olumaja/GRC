using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
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
    public class ViewArmHillAudiPlanExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMHill Audit Execution Plan By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="hillannualaudit"></param>
        /// <param name="hillreq"></param>
        /// <param name="commenceEng"></param>
        /// <param name="hillarmhill"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> hillannualaudit,
            IRepository<ARMHillAuditUniverse> hillreq, IRepository<CommenceEngagementAuditexecution> commenceEng, IRepository<AuditProgramAuditExecution> auditProgram,
            IRepository<AuditUniverseARMHill> hillarmhill, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                var getcommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == anualAuditUniverseId).FirstOrDefault();
                if (getcommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement must be done first");
                }
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
                Guid getcommenceEngIdHill = Guid.Empty;
                var workPaperHill = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusHill = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngHill = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "ARMHill").FirstOrDefault();
                if (getCommenceEngHill != null)
                {
                    workPaperHill = getCommenceEngHill.WorkPaper.ToString();
                    findingStatusHill = getCommenceEngHill.WorkPaper.ToString();
                    getcommenceEngIdHill = getCommenceEngHill.Id;
                }
                BusinessRiskRatingStatus engstatus = BusinessRiskRatingStatus.Pending;
                var getauditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEng.Id).FirstOrDefault();
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "ARMHill")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "ARMHill")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                var getarmhill = hillarmhill.GetContextByConditon(x => x.ARMHillAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string month = null;
                string recommendation = null;
                if (!string.IsNullOrEmpty(getarmhill.January))
                {
                    month = "January";
                    recommendation = getarmhill.January;
                }
                if (!string.IsNullOrEmpty(getarmhill.February))
                {
                    month = "February";
                    recommendation = getarmhill.February;
                }
                if (!string.IsNullOrEmpty(getarmhill.March))
                {
                    month = "March";
                    recommendation = getarmhill.March;
                }
                if (!string.IsNullOrEmpty(getarmhill.April))
                {
                    month = "April";
                    recommendation = getarmhill.April;
                }
                if (!string.IsNullOrEmpty(getarmhill.May))
                {
                    month = "May";
                    recommendation = getarmhill.May;
                }
                if (!string.IsNullOrEmpty(getarmhill.June))
                {
                    month = "June";
                    recommendation = getarmhill.June;
                }
                if (!string.IsNullOrEmpty(getarmhill.July))
                {
                    month = "July";
                    recommendation = getarmhill.July;
                }
                if (!string.IsNullOrEmpty(getarmhill.August))
                {
                    month = "August";
                    recommendation = getarmhill.August;
                }
                if (!string.IsNullOrEmpty(getarmhill.September))
                {
                    month = "September";
                    recommendation = getarmhill.September;
                }
                if (!string.IsNullOrEmpty(getarmhill.October))
                {
                    month = "October";
                    recommendation = getarmhill.October;
                }
                if (!string.IsNullOrEmpty(getarmhill.November))
                {
                    month = "November";
                    recommendation = getarmhill.November;
                }
                if (!string.IsNullOrEmpty(getarmhill.December))
                {
                    month = "December";
                    recommendation = getarmhill.December;
                }
                ViewARMHillAudiPlanExecutionByIdResp resp = new ViewARMHillAudiPlanExecutionByIdResp
                {
                    ARMHill = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "ARMHill",
                        Recommendation = recommendation,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperHill,
                        FindingStatus = findingStatusHill,
                        CommenceEngagementId = getcommenceEngIdHill
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
