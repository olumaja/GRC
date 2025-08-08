using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Migrations;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 13/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* Endpoint to View Audit Execution Plan for the year
*/
    public class ViewTeamAwaitingReportEndpoint
    {
        /// <summary>
        /// Endpoint to View Audit Execution Plan for the year
        /// </summary>
        /// <param name="annualAuditUniverseId"></param>
        /// <param name="auditAnnouncementMemo"></param>
        /// <param name="auditProgram"></param>
        /// <param name="workPaper"></param>
        /// <param name="auditFinding"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid annualAuditUniverseId, IRepository<AuditAnnouncementMemoAuditExecution> auditAnnouncementMemo,
            IRepository<AuditProgramAuditExecution> auditProgram, IRepository<AuditFindings> auditFinding, IRepository<InternalAuditReport> internalAuditReport,
            IRepository<CommenceEngagementAuditexecution> commenceEng, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
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
                List<GetTeamCompletedEngagementResp> viewResp = new List<GetTeamCompletedEngagementResp>();
                var getRating = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == annualAuditUniverseId && x.Status == BusinessRiskRatingStatus.Approved && x.EngagementPlan == BusinessRiskRatingStatus.Approved && x.WorkPaper == BusinessRiskRatingStatus.Approved && x.Findingstatus == BusinessRiskRatingStatus.Approved).ToList();
                if (getRating == null)
                {
                    return TypedResults.NotFound("Commenced engagement or work papers or findings have not been approved");
                }
               
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                         Guid auditId = Guid.Empty;
                        var getauditReportId = internalAuditReport.GetContextByConditon(a => a.CommenceEngagementAuditexecutionId == item.Id).FirstOrDefault();
                        if (getauditReportId != null) { auditId = getauditReportId.Id; }
                        string unit = "ARMShareService";
                        if (item.Team == "ARMTAM") { unit = "ARMTAM"; }
                        if (item.Team == "Digital Financial Service") { unit = "Digital Financial Service"; }
                        if (item.Team == "ARMHill") { unit = "ARMHill"; }
                        if (item.Team == "ARMCapital") { unit = "ARMCapital"; }
                        if (item.Team == "Stock Broking") { unit = "ARMSecurity"; }
                        if (item.Team == "Private Trust" || item.Team == "Commercial Trust") { unit = "ARMTrustee"; }
                        if (item.Team == "RFL" || item.Team == "AAFML") { unit = "ARMAgribusiness"; }
                        if (item.Team == "IMUnit" || item.Team == "Research" || item.Team == "BDPWMIAMIMRetail" || item.Team == "Fund Account" || item.Team == "Fund Admin" || item.Team == "Retail Operation" || item.Team == "ARM Register" || item.Team == "Operation Settlement" || item.Team == "Operation Control") { unit = "ARMIM"; }
                        viewResp.Add(new GetTeamCompletedEngagementResp
                        {                           
                            UnitDetail = new TeamCompletedEngagementResp
                            {
                                CommenceEngagementId = item.Id,
                                Unit = unit,
                                Team = item.Team,
                                AuditReportId = auditId
                            }
                        });

                    }
                    return TypedResults.Ok(viewResp);
                }

                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }

        }
    }
}
