using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Collections.Generic;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 26/04/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class ViewArmHoldCoAudiPlanExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMHoldingCompany audit Plan Execution By Id
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
            IRepository<AuditUniverseARMHoldingCompany> armholdco, IRepository<AuditUniverseARMHoldCoTreasurySale> armHoldCoTreasurySale,
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
                var getArmHoldco = armholdcoauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getArmHoldco == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHoldingCompany");
                }

                Guid getcommenceEngIdHoldco = Guid.Empty;
                var workPaperHoldco = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusHoldco = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngHoldco = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getArmHoldco.AnualAuditUniverseRiskRatingId && x.Team == "ARM Holding Company").FirstOrDefault();
                if (getCommenceEngHoldco != null)
                {
                    workPaperHoldco = getCommenceEngHoldco.WorkPaper.ToString();
                    findingStatusHoldco = getCommenceEngHoldco.Findingstatus.ToString();
                    getcommenceEngIdHoldco = getCommenceEngHoldco.Id;
                }

                Guid getcommenceEngIdSales = Guid.Empty;
                var workPaperSales = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusSales = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngSales = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getArmHoldco.AnualAuditUniverseRiskRatingId && x.Team == "Treasury Sale").FirstOrDefault();
                if (getCommenceEngSales != null)
                {
                    workPaperSales = getCommenceEngSales.WorkPaper.ToString();
                    findingStatusSales = getCommenceEngSales.Findingstatus.ToString();
                    getcommenceEngIdSales = getCommenceEngSales.Id;
                }

                BusinessRiskRatingStatus engstatus = BusinessRiskRatingStatus.Pending;
                var getauditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEng.Id).FirstOrDefault();
                if(getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "ARM Holding Company")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }               
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Treasury Sale")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "ARM Holding Company")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Treasury Sale")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                var getarmholdcom = armholdco.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getArmHoldco.Id).FirstOrDefault();
                var getarmHoldCoTreasurySale = armHoldCoTreasurySale.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getArmHoldco.Id).FirstOrDefault();
                string month = null;
                string recommendation = null;
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

                string monthTr = null;
                string recommendationTr = null;
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
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperHoldco,
                        FindingStatus = findingStatusHoldco,
                        CommenceEngagementId = getcommenceEngIdHoldco
                    },
                    TreasurySale = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthTr,
                        Team = "Treasury Sale",
                        Recommendation = recommendationTr,
                        EngagementPlan = engstatus.ToString(),
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
