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
    public class ViewARMCapitalAudiPlanExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMCapital Audit Execution Plan By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="dfsAnnualaudit"></param>
        /// <param name="dfsReq"></param>
        /// <param name="commenceEng"></param>
        /// <param name="dfsRating"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> dfsAnnualaudit,
            IRepository<ARMCapitalAuditUniverse> dfsReq, IRepository<CommenceEngagementAuditexecution> commenceEng,
            IRepository<AuditUniverseARMCapitalRating> dfsRating, IRepository<AuditProgramAuditExecution> auditProgram, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                var getRating = dfsAnnualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = dfsReq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                }
                Guid getcommenceEngIdDFS = Guid.Empty;
                var workPaperDFS = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusDFS = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngDFS = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "ARMCapital").FirstOrDefault();
                if (getCommenceEngDFS != null)
                {
                    workPaperDFS = getCommenceEngDFS.WorkPaper.ToString();
                    findingStatusDFS = getCommenceEngDFS.Findingstatus.ToString();
                    getcommenceEngIdDFS = getCommenceEngDFS.Id;
                }

                BusinessRiskRatingStatus engstatus = BusinessRiskRatingStatus.Pending;
                var getauditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEng.Id).FirstOrDefault();
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "ARMCapital")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "ARMCapital")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                var getdfsRating = dfsRating.GetContextByConditon(x => x.ARMCapitalAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string month = null;
                string recommendation = null;
                if (!string.IsNullOrEmpty(getdfsRating.January))
                {
                    month = "January";
                    recommendation = getdfsRating.January;
                }
                if (!string.IsNullOrEmpty(getdfsRating.February))
                {
                    month = "February";
                    recommendation = getdfsRating.February;
                }
                if (!string.IsNullOrEmpty(getdfsRating.March))
                {
                    month = "March";
                    recommendation = getdfsRating.March;
                }
                if (!string.IsNullOrEmpty(getdfsRating.April))
                {
                    month = "April";
                    recommendation = getdfsRating.April;
                }
                if (!string.IsNullOrEmpty(getdfsRating.May))
                {
                    month = "May";
                    recommendation = getdfsRating.May;
                }
                if (!string.IsNullOrEmpty(getdfsRating.June))
                {
                    month = "June";
                    recommendation = getdfsRating.June;
                }
                if (!string.IsNullOrEmpty(getdfsRating.July))
                {
                    month = "July";
                    recommendation = getdfsRating.July;
                }
                if (!string.IsNullOrEmpty(getdfsRating.August))
                {
                    month = "August";
                    recommendation = getdfsRating.August;
                }
                if (!string.IsNullOrEmpty(getdfsRating.September))
                {
                    month = "September";
                    recommendation = getdfsRating.September;
                }
                if (!string.IsNullOrEmpty(getdfsRating.October))
                {
                    month = "October";
                    recommendation = getdfsRating.October;
                }
                if (!string.IsNullOrEmpty(getdfsRating.November))
                {
                    month = "November";
                    recommendation = getdfsRating.November;
                }
                if (!string.IsNullOrEmpty(getdfsRating.December))
                {
                    month = "December";
                    recommendation = getdfsRating.December;
                }
                ViewARMCapitalAudiPlanExecutionByIdResp resp = new ViewARMCapitalAudiPlanExecutionByIdResp
                {
                    ARMCapital = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "ARMCapital",
                        Recommendation = recommendation,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperDFS,
                        FindingStatus = findingStatusDFS,
                        CommenceEngagementId = getcommenceEngIdDFS
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
