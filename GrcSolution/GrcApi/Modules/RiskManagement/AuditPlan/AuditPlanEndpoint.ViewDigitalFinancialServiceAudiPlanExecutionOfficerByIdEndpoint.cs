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
    public class ViewDigitalFinancialServiceAudiPlanExecutionOfficerByIdEndpoint
    {
        /// <summary>
        ///  Endpoint to Get Digital Financial Service Audit Execution Plan By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="dfsAnnualaudit"></param>
        /// <param name="dfsReq"></param>
        /// <param name="dfsRating"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> dfsAnnualaudit,
            IRepository<DigitalFinancialServiceAuditUniverse> dfsReq, IRepository<AuditUniverseDigitalFinancialServiceRating> dfsRating, IRepository<CommenceEngagementAuditexecution> commenceEng,
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
                Guid getcommenceEngId = Guid.Empty;
                var engagementPlan = BusinessRiskRatingStatus.Pending.ToString();
                var workPaper = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatus = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId  && x.Team == "Digital Financial Service").FirstOrDefault();
                if (getCommenceEng != null)
                {
                    engagementPlan = getCommenceEng.EngagementPlan.ToString();
                    workPaper = getCommenceEng.WorkPaper.ToString(); 
                    findingStatus = getCommenceEng.Findingstatus.ToString(); 
                    getcommenceEngId = getCommenceEng.Id;
                }
                var gettamRating = dfsRating.GetContextByConditon(x => x.DigitalFinancialServiceAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string month = "January";
                string recommendation = "Full Scope";
                if (!string.IsNullOrEmpty(gettamRating.January))
                {
                    month = "January";
                    recommendation = gettamRating.January;
                }
                if (!string.IsNullOrEmpty(gettamRating.February))
                {
                    month = "February";
                    recommendation = gettamRating.February;
                }
                if (!string.IsNullOrEmpty(gettamRating.March))
                {
                    month = "March";
                    recommendation = gettamRating.March;
                }
                if (!string.IsNullOrEmpty(gettamRating.April))
                {
                    month = "April";
                    recommendation = gettamRating.April;
                }
                if (!string.IsNullOrEmpty(gettamRating.May))
                {
                    month = "May";
                    recommendation = gettamRating.May;
                }
                if (!string.IsNullOrEmpty(gettamRating.June))
                {
                    month = "June";
                    recommendation = gettamRating.June;
                }
                if (!string.IsNullOrEmpty(gettamRating.July))
                {
                    month = "July";
                    recommendation = gettamRating.July;
                }
                if (!string.IsNullOrEmpty(gettamRating.August))
                {
                    month = "August";
                    recommendation = gettamRating.August;
                }
                if (!string.IsNullOrEmpty(gettamRating.September))
                {
                    month = "September";
                    recommendation = gettamRating.September;
                }
                if (!string.IsNullOrEmpty(gettamRating.October))
                {
                    month = "October";
                    recommendation = gettamRating.October;
                }
                if (!string.IsNullOrEmpty(gettamRating.November))
                {
                    month = "November";
                    recommendation = gettamRating.November;
                }
                if (!string.IsNullOrEmpty(gettamRating.December))
                {
                    month = "December";
                    recommendation = gettamRating.December;
                }

                ViewDigitalFinancialServiceAudiPlanExecutionByIdResp resp = new ViewDigitalFinancialServiceAudiPlanExecutionByIdResp
                {
                    DigitalFinancialService = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "Digital Financial Service",
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
