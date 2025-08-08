using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 03/06/2024
   * Development Group: Audit plan Risk Assessment - GRCTools
   */
    public class GetFindingAvailableForCAFEndpoint
    {
        /// <summary>
        /// Get rated business risk rating
        /// </summary>
        /// <param name="auditreportId"></param>
        /// <param name="team"></param>
        /// <param name="repo"></param>
        /// <param name="auditFindingAuditReport"></param>
        /// <param name="reportDetailfindings"></param>
        /// <param name="observationListAuditReport"></param>
        /// <param name="managementResponseAuditReport"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid auditreportId, string team, IRepository<InternalAuditReport> repo, 
            IRepository<AuditFindingAuditReport> auditFindingAuditReport, IRepository<ReportDetailfindings> reportDetailfindings, IRepository<ObservationListAuditReport> observationListAuditReport,
             IRepository<ManagementResponseAuditReport> managementResponseAuditReport, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                var getReport = repo.GetContextByConditon(c => c.Id == auditreportId && c.Team == team && c.Status == BusinessRiskRatingStatus.Approved).FirstOrDefault();

                if (getReport != null)
                {                   
                    var getreportDetailfindings = reportDetailfindings.GetContextByConditon(c => c.InternalAuditReportId == auditreportId).OrderBy(x => x.CreatedOnUtc);
                    var getreportDetailfindingsList = getreportDetailfindings.Select(p => new ReportDetailfindingListResp
                    {
                        DescriptionOfIssue = p.DescriptionOfIssue,
                        ImpactRating = p.IssueRating,
                        DetailedFindings = p.Observation,
                        Recommendation = p.Recommendation,
                    }).ToList();

                    var getmanagementResponseAudit = managementResponseAuditReport.GetContextByConditon(x => x.InternalAuditReportId == auditreportId).OrderBy(x => x.CreatedOnUtc);
                    var getmanagementResponseAuditResp = getmanagementResponseAudit.Select(p => new ManagementResponseAuditDetail
                    {
                        ActionOwner = p.ActionOwner,
                        Unit = p.Unit,
                        Entity = null,
                        ActionDueDate = p.DueDate,
                        ActionToResolve = p.ActionPointToResolve,
                        Designation = p.Designation
                    }).ToList();
                   
                    var getobservationListAudit = observationListAuditReport.GetContextByConditon(x => x.InternalAuditReportId == auditreportId).OrderBy(x => x.CreatedOnUtc);
                    var getobservationListAuditResp = getobservationListAudit.Select(p => new ObservationListAuditResp
                    {                       
                        Recommendation = p.Recommendation,
                        ManagmentResponseAsAtTimeOfEngagement = p.ManagementResponse
                    }).ToList();
                    
                    var getauditFindingAudit = auditFindingAuditReport.GetContextByConditon(x => x.InternalAuditReportId == auditreportId).OrderBy(x => x.CreatedOnUtc);
                    var getauditFindingAuditResp = getauditFindingAudit.Select(p => new AuditFindingAuditResp
                    {                       
                        Level1 = p.ControlType                       
                    }).ToList();
                    string unit = "ARMShareService";
                    if (getReport.Team == "ARMTAM") { unit = "ARMTAM"; }
                    if (getReport.Team == "Digital Financial Service") { unit = "Digital Financial Service"; }
                    if (getReport.Team == "ARMHill") { unit = "ARMHill"; }
                    if (getReport.Team == "ARMCapital") { unit = "ARMCapital"; }
                    if (getReport.Team == "Stock Broking") { unit = "ARMSecurity"; }
                    if (getReport.Team == "Private Trust" || getReport.Team == "Commercial Trust") { unit = "ARMTrustee"; }
                    if (getReport.Team == "RFL" || getReport.Team == "AAFML") { unit = "ARMAgribusiness"; }
                    if (getReport.Team == "IMUnit" || getReport.Team == "Research" || getReport.Team == "BDPWMIAMIMRetail" || getReport.Team == "Fund Account" || getReport.Team == "Fund Admin" || getReport.Team == "Retail Operation" || getReport.Team == "ARM Register" || getReport.Team == "Operation Settlement" || getReport.Team == "Operation Control") { unit = "ARMIM"; }


                    var detail = new TeamAvailableForCAFResp
                    {
                        AuditReportId = auditreportId,
                        DateFindingRaised = getReport.CreatedOnUtc,
                        Business = unit,
                        Level2 = null,
                        AuditArea = getReport.Unit,
                        ReportingQuater = null,
                        WorkStream = null,
                        EngagementName = getReport.Unit,
                        RevisedDueDate = null,
                        ResolutionDate = null,
                        UpdatedComment = null,
                        Findings = getreportDetailfindingsList,
                        ActionDetail = getmanagementResponseAuditResp,
                        Observation = getobservationListAuditResp,
                        Level1 = getauditFindingAuditResp
                    };
                    return TypedResults.Ok(detail);
                }
                return TypedResults.NotFound("Record was not found");

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound();
            }

        }
    }

}
