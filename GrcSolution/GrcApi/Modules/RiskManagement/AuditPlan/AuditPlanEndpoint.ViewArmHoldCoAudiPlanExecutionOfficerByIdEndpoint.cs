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
    public class ViewArmHoldCoAudiPlanExecutionOfficerByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMHoldingCompany audit Plan Execution By Id - Officer
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="armholdcoauditUniverse"></param>
        /// <param name="armholdco"></param>
        /// <param name="armHoldCoTreasurySale"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMHoldingCompanyAnnualAuditUniverse> armholdcoauditUniverse,
            IRepository<AuditUniverseARMHoldingCompany> armholdco, IRepository<AuditUniverseARMHoldCoTreasurySale> armHoldCoTreasurySale, IRepository<CommenceEngagementAuditexecution> commenceEng,
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
                var getRating = annualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getArmHoldco = armholdcoauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getArmHoldco == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHoldingCompany");
                }
                Guid getcommenceEngId = Guid.Empty;
                var engagementPlan = BusinessRiskRatingStatus.Pending.ToString();
                var workPaper = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatus = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getArmHoldco.AnualAuditUniverseRiskRatingId && x.Team == "ARM Holding Company").FirstOrDefault();
                if (getCommenceEng != null)
                {
                    engagementPlan = BusinessRiskRatingStatus.Completed.ToString();
                    workPaper = getCommenceEng.WorkPaper.ToString();
                    findingStatus = getCommenceEng.Findingstatus.ToString();
                    getcommenceEngId = getCommenceEng.Id;
                }

                Guid getcommenceEngIdSales = Guid.Empty;
                var engagementPlanSales = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperSales = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusSales = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngSales = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getArmHoldco.AnualAuditUniverseRiskRatingId && x.Team == "Treasury Sale").FirstOrDefault();
                if (getCommenceEngSales != null)
                {
                    engagementPlanSales = BusinessRiskRatingStatus.Completed.ToString();
                    workPaperSales = getCommenceEngSales.WorkPaper.ToString();
                    findingStatusSales = getCommenceEngSales.Findingstatus.ToString();
                    getcommenceEngIdSales = getCommenceEngSales.Id;
                }

                var getarmholdcom = armholdco.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getArmHoldco.Id).FirstOrDefault();
                var getarmHoldCoTreasurySale = armHoldCoTreasurySale.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getArmHoldco.Id).FirstOrDefault();

                string month = "January";
                string recommendation = "Full Scope";
                if (!string.IsNullOrEmpty(getarmholdcom.January)) 
                {
                    month = "January";
                    recommendation = getarmholdcom.January;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.February))
                {
                    month = "February";
                    recommendation = getarmholdcom.February;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.March))
                {
                    month = "March";
                    recommendation = getarmholdcom.March;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.April))
                {
                    month = "April";
                    recommendation = getarmholdcom.April;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.May))
                {
                    month = "May";
                    recommendation = getarmholdcom.May;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.June))
                {
                    month = "June";
                    recommendation = getarmholdcom.June;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.July))
                {
                    month = "July";
                    recommendation = getarmholdcom.July;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.August))
                {
                    month = "August";
                    recommendation = getarmholdcom.August;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.September))
                {
                    month = "September";
                    recommendation = getarmholdcom.September;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.October))
                {
                    month = "October";
                    recommendation = getarmholdcom.October;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.November))
                {
                    month = "November";
                    recommendation = getarmholdcom.November;
                }
                if (!string.IsNullOrEmpty(getarmholdcom.December))
                {
                    month = "December";
                    recommendation = getarmholdcom.December; 
                }

                string monthTr = "January";
                string recommendationTr = "Full Scope";
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.January))
                {
                    monthTr = "January";
                    recommendationTr = getarmHoldCoTreasurySale.January;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.February))
                {
                    monthTr = "February";
                    recommendationTr = getarmHoldCoTreasurySale.February;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.March))
                {
                    monthTr = "March";
                    recommendationTr = getarmHoldCoTreasurySale.March;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.April))
                {
                    monthTr = "April";
                    recommendationTr = getarmHoldCoTreasurySale.April;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.May))
                {
                    monthTr = "May";
                    recommendationTr = getarmHoldCoTreasurySale.May;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.June))
                {
                    monthTr = "June";
                    recommendationTr = getarmHoldCoTreasurySale.June;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.July))
                {
                    monthTr = "July";
                    recommendationTr = getarmHoldCoTreasurySale.July;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.August))
                {
                    monthTr = "August";
                    recommendationTr = getarmHoldCoTreasurySale.August;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.September))
                {
                    monthTr = "September";
                    recommendationTr = getarmHoldCoTreasurySale.September;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.October))
                {
                    monthTr = "October";
                    recommendationTr = getarmHoldCoTreasurySale.October;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.November))
                {
                    monthTr = "November";
                    recommendationTr = getarmHoldCoTreasurySale.November;
                }
                if (!string.IsNullOrEmpty(getarmHoldCoTreasurySale.December))
                {
                    monthTr = "December";
                    recommendationTr = getarmHoldCoTreasurySale.December;
                }

                ViewARMHoldCoAudiPlanExecutionByIdResp resp = new ViewARMHoldCoAudiPlanExecutionByIdResp
                {
                    ArmHoldingCompany = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "ARM Holding Company",
                        Recommendation = recommendation, 
                        EngagementPlan = engagementPlan,
                        WorkPaper = workPaper,
                        FindingStatus = findingStatus,
                        CommenceEngagementId = getcommenceEngId
                    },
                    TreasurySale = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthTr,
                        Team = "Treasury Sale",
                        Recommendation = recommendationTr, 
                        EngagementPlan = engagementPlanSales,
                        WorkPaper = workPaperSales,
                        FindingStatus = findingStatusSales,
                        CommenceEngagementId = getcommenceEngIdSales
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
