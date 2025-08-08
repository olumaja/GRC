using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 08/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class GetTeamCompletedEngagementEndpoint
    {
        /// <summary>
        /// Endpoint to Get Team completed engagement By commencedEngagementId
        /// </summary>
        /// <param name="annualAuditUniverseId"></param>
        /// <param name="team"></param>
        /// <param name="auditmemo"></param>
        /// <param name="auditAnnouncementMemo"></param>
        /// <param name="auditProgram"></param>
        /// <param name="workPaper"></param>
        /// <param name="auditFinding"></param>
        /// <param name="commenceEng"></param>
        /// <param name="internalAuditReport"></param>
        /// <param name="internalAuditRatingReport"></param>
        /// <param name="observationListAuditReport"></param>
        /// <param name="auditFindingAuditReport"></param>
        /// <param name="managementResponseAuditReport"></param>
        /// <param name="citationAuditReport"></param>
        /// <param name="annualAudit"></param>
        /// <param name="distributionList"></param>
        /// <param name="businessRiskRating"></param>
        /// <param name="engagementLetter"></param>
        /// <param name="assessmentOfDigitalInitiative"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid annualAuditUniverseId, string team, IRepository<AuditPlanningMemoAuditExecution> auditmemo, IRepository<AuditAnnouncementMemoAuditExecution> auditAnnouncementMemo, 
            IRepository<AuditProgramAuditExecution> auditProgram, IRepository<WorkPaper> workPaper, IRepository<AuditFindings> auditFinding,
            IRepository<CommenceEngagementAuditexecution> commenceEng, IRepository<ReportDetailfindings> reportDetailfindings,
            IRepository<InternalAuditReport> internalAuditReport, IRepository<InternalAuditRatingReport> internalAuditRatingReport,
            IRepository<ObservationListAuditReport> observationListAuditReport, IRepository<AuditFindingAuditReport> auditFindingAuditReport, IRepository<ManagementResponseAuditReport> managementResponseAuditReport,
            IRepository<CitationAuditReport> citationAuditReport, IRepository<AnualAuditUniverseRiskRating> annualAudit,           
            IRepository<EngagementLetterReportDistributionList> distributionList, IRepository<BusinessRiskRating> businessRiskRating,
            IRepository<EngagementLetterAuditExecution> engagementLetter, IRepository<AssessmentOfDigitalInitiativeList> assessmentOfDigitalInitiative,

            ClaimsPrincipal user, ICurrentUserService currentUserService
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
                var year = DateTime.Now.Year;
                var getCommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == annualAuditUniverseId && x.Team == team && x.EngagementPlan == BusinessRiskRatingStatus.Approved && x.WorkPaper == BusinessRiskRatingStatus.Approved && x.Findingstatus == BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getCommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement process has not been completed, ensure work paper and finding are approved for the team.");
                }
                var getreport = internalAuditReport.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == team).FirstOrDefault();
                string detailedFinding = null;
                string comment = null;
                if (getreport != null)
                {
                    detailedFinding = getreport.DetailedFinding;
                    comment = getreport.ReportComment;
                }
                var getauditAnnouncementMemo = auditAnnouncementMemo.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == team).FirstOrDefault();
                if (getauditAnnouncementMemo == null)
                {
                    return TypedResults.NotFound($"Announcement memo has not been completed for the team.");
                }
                var getAuditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == team).FirstOrDefault();
                if (getAuditProgram == null)
                {
                    return TypedResults.NotFound($"Audit Program has not been completed for the team.");
                }
                var getWorkPaper = workPaper.GetContextByConditon(x => x.AuditProgramId == getAuditProgram.Id && x.Team == team).FirstOrDefault();
                string issueRating = null;   
                string impact = null;   
                if (getWorkPaper == null)
                {
                    issueRating = null;
                    impact = null;
                }

                var getWorkpaperRatings = workPaper.GetContextByConditon(a => a.CreatedOnUtc.Year == year && a.Team == team && a.ExceptionsNoted.ToLower() == "yes").OrderBy(x => x.CreatedOnUtc);
                var getauditFinding = auditFinding.GetContextByConditon(a => a.CreatedOnUtc.Year == year && a.Team == team).OrderBy(x => x.CreatedOnUtc);
                //var getauditFinding = auditFinding.GetContextByConditon(a => a.CreatedOnUtc.Year == year && a.Team == team);
                var getWorkpaperRatingsResp = getWorkpaperRatings.Select(p => new DetailFindingList
                {
                    ImpactRating = p.Impact,
                    Recommendation = p.Recommendation,
                    RootCause = p.RootCause,
                    Observation = p.IssueSummary,
                    IssueRating = p.IssueRating.ToString(),
                    ActionToResolve = p.AuditFindings.ActionToResolve,
                    ActionOwner = p.AuditFindings.ActionOwner,
                    ActionOwnerUnit = p.AuditFindings.ActionOwnerUnit,
                    ActionDueDate = p.AuditFindings.ActionDueDate,
                    Designation = "",

                }).ToList();

                
                string unit = "ARMShareService";
                if (getCommenceEng.Team == "ARMTAM") { unit = "ARMTAM"; }
                if (getCommenceEng.Team == "Digital Financial Service") { unit = "Digital Financial Service"; }
                if (getCommenceEng.Team == "ARMHill") { unit = "ARMHill"; }
                if (getCommenceEng.Team == "ARMCapital") { unit = "ARMCapital"; }
                if (getCommenceEng.Team == "Stock Broking") { unit = "ARMSecurity"; }
                if (getCommenceEng.Team == "Private Trust" || getCommenceEng.Team == "Commercial Trust") { unit = "ARMTrustee"; }
                if (getCommenceEng.Team == "RFL" || getCommenceEng.Team == "AAFML") { unit = "ARMAgribusiness"; }
                if (getCommenceEng.Team == "IMUnit" || getCommenceEng.Team == "Research" || getCommenceEng.Team == "BDPWMIAMIMRetail" || getCommenceEng.Team == "Fund Account" || getCommenceEng.Team == "Fund Admin" || getCommenceEng.Team == "Retail Operation" || getCommenceEng.Team == "ARM Register" || getCommenceEng.Team == "Operation Settlement" || getCommenceEng.Team == "Operation Control") { unit = "ARMIM"; }

                GetTeamCompletedEngagementByIdResp resp = new GetTeamCompletedEngagementByIdResp
                {                  
                   UnitDetail = new TeamCompletedEngagementByIdResp
                   {                       
                       CommenceEngagementId = getCommenceEng.Id,
                       Unit = unit,
                       Team = team,
                       DetailedFinding = detailedFinding,
                       IssueRating = getWorkPaper.IssueRating.ToString() ?? issueRating,
                       PotentialMaterialisedImpact = getWorkPaper.Impact ?? impact,
                       FindingDetail = getWorkpaperRatingsResp,                      
                       InternalAuditRating = $"Internal Audit Rating Based on the audit work performed and subject to our findings detailed herein, this report has been assigned an overall rating of Minor Improvement Required. The assigned rating represents the independent opinion of Internal Audit based on the results of the audit. The evaluation by Internal Audit for the current review period {getauditAnnouncementMemo.PeriodFrom.Value.ToString("MMMM yyyy")} - {getauditAnnouncementMemo.PeriodTo.Value.ToString("MMMM yyyy")} in comparison with the previous review period {getauditAnnouncementMemo.PreviousFrom.Value.ToString("MMMM yyyy")} - {getauditAnnouncementMemo.PreviousTo.Value.ToString("MMMM yyyy")} is presented in the table below:",
                       EngagementStatus = getCommenceEng.EngagementPlan.ToString(),
                       WorkPaperStatus = getCommenceEng.WorkPaper.ToString(),
                       FindingStatus = getCommenceEng.Findingstatus.ToString(),                       
                       ReportComment = comment,
                       //DetailedFindings = getreportDetailfindingList
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
