using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 26/04/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 */
    public class ViewArmSecurityAudiPlanExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to get ARMSecurity Audit execution Plan By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="req"></param>
        /// <param name="stockBroking"></param>
        /// <param name="commenceEng"></param>
        /// <param name="auditProgram"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMSecurityAnnualAuditUniverse> req, IRepository<AuditUniverseARMSecurityStockBroking> stockBroking,
            IRepository<CommenceEngagementAuditexecution> commenceEng, IRepository<AuditProgramAuditExecution> auditProgram,
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
                var getcommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == anualAuditUniverseId).FirstOrDefault();
                if (getcommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement must be done first");
                }
                var getRating = annualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = req.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMSecurity");
                }
              
                Guid getcommenceEngIdSTO = Guid.Empty;
                var workPaperSTO = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusSTO = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngSTO = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Stock Broking").FirstOrDefault();
                if (getCommenceEngSTO != null)
                {
                    workPaperSTO = getCommenceEngSTO.WorkPaper.ToString();
                    findingStatusSTO = getCommenceEngSTO.Findingstatus.ToString();
                    getcommenceEngIdSTO = getCommenceEngSTO.Id;
                }

                BusinessRiskRatingStatus engstatus = BusinessRiskRatingStatus.Pending;
                var getauditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEng.Id).FirstOrDefault();
               
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Stock Broking")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
              
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Stock Broking")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                var getstockBroking = stockBroking.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string month = null;
                string recommendation = null;
                if (!string.IsNullOrEmpty(getstockBroking.January))
                {
                    month = "January";
                    recommendation = getstockBroking.January;
                }
                if (!string.IsNullOrEmpty(getstockBroking.February))
                {
                    month = "February";
                    recommendation = getstockBroking.February;
                }
                if (!string.IsNullOrEmpty(getstockBroking.March))
                {
                    month = "March";
                    recommendation = getstockBroking.March;
                }
                if (!string.IsNullOrEmpty(getstockBroking.April))
                {
                    month = "April";
                    recommendation = getstockBroking.April;
                }
                if (!string.IsNullOrEmpty(getstockBroking.May))
                {
                    month = "May";
                    recommendation = getstockBroking.May;
                }
                if (!string.IsNullOrEmpty(getstockBroking.June))
                {
                    month = "June";
                    recommendation = getstockBroking.June;
                }
                if (!string.IsNullOrEmpty(getstockBroking.July))
                {
                    month = "July";
                    recommendation = getstockBroking.July;
                }
                if (!string.IsNullOrEmpty(getstockBroking.August))
                {
                    month = "August";
                    recommendation = getstockBroking.August;
                }
                if (!string.IsNullOrEmpty(getstockBroking.September))
                {
                    month = "September";
                    recommendation = getstockBroking.September;
                }
                if (!string.IsNullOrEmpty(getstockBroking.October))
                {
                    month = "October";
                    recommendation = getstockBroking.October;
                }
                if (!string.IsNullOrEmpty(getstockBroking.November))
                {
                    month = "November";
                    recommendation = getstockBroking.November;
                }
                if (!string.IsNullOrEmpty(getstockBroking.December))
                {
                    month = "December";
                    recommendation = getstockBroking.December;
                }
                ViewARMSecurityAudiPlanExecutionByIdResp resp = new ViewARMSecurityAudiPlanExecutionByIdResp
                {                  
                    StockBroking = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "Stock Broking",
                        Recommendation = recommendation,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperSTO,
                        FindingStatus = findingStatusSTO,
                        CommenceEngagementId = getcommenceEngIdSTO
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
