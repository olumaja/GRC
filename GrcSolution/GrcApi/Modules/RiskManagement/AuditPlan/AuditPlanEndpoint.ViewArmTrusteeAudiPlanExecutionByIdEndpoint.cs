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
* This endpoint get Annual Audit Universe By anualAuditUniverseId
*/
    public class ViewArmTrusteeAudiPlanExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to get ARMTrustee Audit Execution Plan By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="req"></param>
        /// <param name="privateTrust"></param>
        /// <param name="commenceEng"></param>
        /// <param name="commercialTrust"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMTrusteeAuditUniverse> req, IRepository<AuditUniverseARMTrusteePrivateTrust> privateTrust, IRepository<CommenceEngagementAuditexecution> commenceEng,
            IRepository<AuditUniverseARMTrusteeCommercialTrust> commercialTrust, IRepository<AuditProgramAuditExecution> auditProgram,
            ICurrentUserService currentUserService,
            ClaimsPrincipal user)
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
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMTrustee");
                }
                Guid getcommenceEngIdPr = Guid.Empty;
                var workPaperPr = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusPr = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngPr = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Private Trust").FirstOrDefault();
                if (getCommenceEngPr != null)
                {
                    workPaperPr = getCommenceEngPr.WorkPaper.ToString();
                    findingStatusPr = getCommenceEngPr.Findingstatus.ToString();
                    getcommenceEngIdPr = getCommenceEngPr.Id;
                }
                Guid getcommenceEngIdCOM = Guid.Empty;
                var workPaperCOM = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusCOM = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngCOM = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Commercial Trust").FirstOrDefault();
                if (getCommenceEngCOM != null)
                {
                    workPaperCOM = getCommenceEngCOM.WorkPaper.ToString();
                    findingStatusCOM = getCommenceEngCOM.Findingstatus.ToString();
                    getcommenceEngIdCOM = getCommenceEngCOM.Id;
                }

                BusinessRiskRatingStatus engstatus = BusinessRiskRatingStatus.Pending;
                var getauditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEng.Id).FirstOrDefault();
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Private Trust")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "Commercial Trust")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Private Trust")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "Commercial Trust")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }

                var getprivateTrust = privateTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getcommercialTrust = commercialTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string month = null;
                string recommendation = null;
                if (!string.IsNullOrEmpty(getprivateTrust.January))
                {
                    month = "January";
                    recommendation = getprivateTrust.January;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.February))
                {
                    month = "February";
                    recommendation = getprivateTrust.February;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.March))
                {
                    month = "March";
                    recommendation = getprivateTrust.March;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.April))
                {
                    month = "April";
                    recommendation = getprivateTrust.April;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.May))
                {
                    month = "May";
                    recommendation = getprivateTrust.May;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.June))
                {
                    month = "June";
                    recommendation = getprivateTrust.June;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.July))
                {
                    month = "July";
                    recommendation = getprivateTrust.July;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.August))
                {
                    month = "August";
                    recommendation = getprivateTrust.August;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.September))
                {
                    month = "September";
                    recommendation = getprivateTrust.September;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.October))
                {
                    month = "October";
                    recommendation = getprivateTrust.October;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.November))
                {
                    month = "November";
                    recommendation = getprivateTrust.November;
                }
                if (!string.IsNullOrEmpty(getprivateTrust.December))
                {
                    month = "December";
                    recommendation = getprivateTrust.December;
                }

                string monthCom = null;
                string recommendationCom = null;
                if (!string.IsNullOrEmpty(getcommercialTrust.January))
                {
                    monthCom = "January";
                    recommendationCom = getcommercialTrust.January;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.February))
                {
                    monthCom = "February";
                    recommendationCom = getcommercialTrust.February;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.March))
                {
                    monthCom = "March";
                    recommendationCom = getcommercialTrust.March;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.April))
                {
                    monthCom = "April";
                    recommendationCom = getcommercialTrust.April;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.May))
                {
                    monthCom = "May";
                    recommendationCom = getcommercialTrust.May;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.June))
                {
                    monthCom = "June";
                    recommendationCom = getcommercialTrust.June;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.July))
                {
                    monthCom = "July";
                    recommendationCom = getcommercialTrust.July;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.August))
                {
                    monthCom = "August";
                    recommendationCom = getcommercialTrust.August;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.September))
                {
                    monthCom = "September";
                    recommendationCom = getcommercialTrust.September;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.October))
                {
                    monthCom = "October";
                    recommendationCom = getcommercialTrust.October;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.November))
                {
                    monthCom = "November";
                    recommendationCom = getcommercialTrust.November;
                }
                if (!string.IsNullOrEmpty(getcommercialTrust.December))
                {
                    monthCom = "December";
                    recommendationCom = getcommercialTrust.December;
                }

                ViewARMTrusteeAudiPlanExecutionByIdResp resp = new ViewARMTrusteeAudiPlanExecutionByIdResp
                {
                    PrivateTrust = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "Private Trust",
                        Recommendation = recommendation,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperPr,
                        FindingStatus = findingStatusPr,
                        CommenceEngagementId = getcommenceEngIdPr
                    },
                    CommercialTrust = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthCom,
                        Team = "Commercial Trust",
                        Recommendation = recommendationCom,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperCOM,
                        FindingStatus = findingStatusCOM,
                        CommenceEngagementId = getcommenceEngIdCOM
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
