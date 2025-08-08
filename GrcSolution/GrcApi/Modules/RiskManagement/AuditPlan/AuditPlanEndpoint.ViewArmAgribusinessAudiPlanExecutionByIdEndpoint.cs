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
  * This endpoint get Annual Audit Execution By anualAuditUniverseId
  */
    public class ViewArmAgribusinessAudiPlanExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMAgribusiness Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="agrreq"></param>
        /// <param name="agraafml"></param>
        /// <param name="commenceEng"></param>
        /// <param name="agrirfl"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>       
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMAgribusinessAuditUniverse> agrreq, IRepository<AuditUniverseARMAgribusinessAAFML> agraafml, IRepository<CommenceEngagementAuditexecution> commenceEng,
            IRepository<AuditUniverseARMAgribusinessRFL> agrirfl, IRepository<AuditProgramAuditExecution> auditProgram, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                var getAuditRating = agrreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMAgribusiness");
                }
                Guid getcommenceEngIdRFL = Guid.Empty;
                var workPaperRFL = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusRFL = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngRFL = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "RFL").FirstOrDefault();
                if (getCommenceEngRFL != null)
                {
                    workPaperRFL = getCommenceEngRFL.WorkPaper.ToString();
                    findingStatusRFL = getCommenceEngRFL.Findingstatus.ToString();
                    getcommenceEngIdRFL = getCommenceEngRFL.Id;
                }
                Guid getcommenceEngIdAAFML = Guid.Empty;
                var workPaperAAFML = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusAAFML = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngAAFML = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "AAFML").FirstOrDefault();
                if (getCommenceEngAAFML != null)
                {
                    workPaperAAFML = getCommenceEngAAFML.WorkPaper.ToString();
                    findingStatusAAFML = getCommenceEngAAFML.Findingstatus.ToString();
                    getcommenceEngIdAAFML = getCommenceEngAAFML.Id;
                }

                BusinessRiskRatingStatus engstatus = BusinessRiskRatingStatus.Pending;
                var getauditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEng.Id).FirstOrDefault();
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "RFL")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "RFL")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Approved && getauditProgram.Team == "AAFML")
                {
                    engstatus = BusinessRiskRatingStatus.Approved;
                }
                if (getauditProgram.Status == BusinessRiskRatingStatus.Completed && getauditProgram.Team == "AAFML")
                {
                    engstatus = BusinessRiskRatingStatus.Completed;
                }
                var getrfl = agrirfl.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getaafml = agraafml.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthCom = null;
                string recommendationCom = null;
                if (!string.IsNullOrEmpty(getrfl.January))
                {
                    monthCom = "January";
                    recommendationCom = getrfl.January;
                }
                if (!string.IsNullOrEmpty(getrfl.February))
                {
                    monthCom = "February";
                    recommendationCom = getrfl.February;
                }
                if (!string.IsNullOrEmpty(getrfl.March))
                {
                    monthCom = "March";
                    recommendationCom = getrfl.March;
                }
                if (!string.IsNullOrEmpty(getrfl.April))
                {
                    monthCom = "April";
                    recommendationCom = getrfl.April;
                }
                if (!string.IsNullOrEmpty(getrfl.May))
                {
                    monthCom = "May";
                    recommendationCom = getrfl.May;
                }
                if (!string.IsNullOrEmpty(getrfl.June))
                {
                    monthCom = "June";
                    recommendationCom = getrfl.June;
                }
                if (!string.IsNullOrEmpty(getrfl.July))
                {
                    monthCom = "July";
                    recommendationCom = getrfl.July;
                }
                if (!string.IsNullOrEmpty(getrfl.August))
                {
                    monthCom = "August";
                    recommendationCom = getrfl.August;
                }
                if (!string.IsNullOrEmpty(getrfl.September))
                {
                    monthCom = "September";
                    recommendationCom = getrfl.September;
                }
                if (!string.IsNullOrEmpty(getrfl.October))
                {
                    monthCom = "October";
                    recommendationCom = getrfl.October;
                }
                if (!string.IsNullOrEmpty(getrfl.November))
                {
                    monthCom = "November";
                    recommendationCom = getrfl.November;
                }
                if (!string.IsNullOrEmpty(getrfl.December))
                {
                    monthCom = "December";
                    recommendationCom = getrfl.December;
                }

                string month = null;
                string recommendation = null;
                if (!string.IsNullOrEmpty(getaafml.January))
                {
                    month = "January";
                    recommendation = getaafml.January;
                }
                if (!string.IsNullOrEmpty(getaafml.February))
                {
                    month = "February";
                    recommendation = getaafml.February;
                }
                if (!string.IsNullOrEmpty(getaafml.March))
                {
                    month = "March";
                    recommendation = getaafml.March;
                }
                if (!string.IsNullOrEmpty(getaafml.April))
                {
                    month = "April";
                    recommendation = getaafml.April;
                }
                if (!string.IsNullOrEmpty(getaafml.May))
                {
                    month = "May";
                    recommendation = getaafml.May;
                }
                if (!string.IsNullOrEmpty(getaafml.June))
                {
                    month = "June";
                    recommendation = getaafml.June;
                }
                if (!string.IsNullOrEmpty(getaafml.July))
                {
                    month = "July";
                    recommendation = getaafml.July;
                }
                if (!string.IsNullOrEmpty(getaafml.August))
                {
                    month = "August";
                    recommendation = getaafml.August;
                }
                if (!string.IsNullOrEmpty(getaafml.September))
                {
                    month = "September";
                    recommendation = getaafml.September;
                }
                if (!string.IsNullOrEmpty(getaafml.October))
                {
                    month = "October";
                    recommendation = getaafml.October;
                }
                if (!string.IsNullOrEmpty(getaafml.November))
                {
                    month = "November";
                    recommendation = getaafml.November;
                }
                if (!string.IsNullOrEmpty(getaafml.December))
                {
                    month = "December";
                    recommendation = getaafml.December;
                }
                ViewARMAgribusinessAudiPlanExecutionByIdResp resp = new ViewARMAgribusinessAudiPlanExecutionByIdResp
                {
                    RFL = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthCom,
                        Team = "RFL",
                        Recommendation = recommendationCom,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperRFL,
                        FindingStatus = findingStatusRFL,
                        CommenceEngagementId = getcommenceEngIdRFL
                    },
                    AAFML = new ViewAudiPlanExecutionResponse
                    {
                        Month = month,
                        Team = "AAFML",
                        Recommendation = recommendation,
                        EngagementPlan = engstatus.ToString(),
                        WorkPaper = workPaperAAFML,
                        FindingStatus = findingStatusAAFML,
                        CommenceEngagementId = getcommenceEngIdAAFML
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
