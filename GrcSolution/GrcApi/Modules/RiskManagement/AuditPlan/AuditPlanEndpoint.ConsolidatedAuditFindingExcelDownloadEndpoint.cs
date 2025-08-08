using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.VisualBasic;
using System.Linq;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 14/02/2025
     * Development Group: GRCTools
     * This method generate excel document 
     */
    public class ConsolidatedAuditFindingExcelDownloadEndpoint
    {
        /// <summary>
        /// The endpoint fetch and download consolidated audit finding
        /// </summary>
        /// <param name="finding"></param>
        /// <param name="httpContext"></param>
        /// <param name="logger"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>      
        public static async Task<IResult> HandleAsync(IRepository<ConsolidatedAuditFinding> findingRepository,
                    IHttpContextAccessor httpContext, Serilog.ILogger logger, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                var findings = findingRepository.GetAll().ToList();

                if (findings.Count == 0)
                    return TypedResults.BadRequest("No record");

                var reportName = "Consolidated Audit Finding";
                var dateToday = DateTime.Now.Date;

                var excelRecords = findings.Select(f =>
                {
                    string dueDay;
                    bool findingExpectedToBeClosed;
                    string? priorYearFinding = "YES";
                    if (f.ActionDueDate.HasValue)
                    {
                        var dueDate = f.ActionDueDate.Value.Date;
                        var dayDifference = (dueDate - dateToday).Days;
                        switch (f.OPRStatus)
                        {
                            case BusinessRiskRatingStatus.Due:
                            case BusinessRiskRatingStatus.Past_Due:
                                findingExpectedToBeClosed = true;
                                dueDay = dayDifference.ToString();
                                break;
                            case BusinessRiskRatingStatus.Not_Yet_Due:
                                findingExpectedToBeClosed = false;
                                dueDay = "NA";
                                break;
                            default:
                                findingExpectedToBeClosed = false;
                                dueDay = "NA";
                                break;
                        }
                    }
                    else
                    {
                        dueDay = "NA";
                        findingExpectedToBeClosed = false;
                    }
                    if(f.CreatedOnUtc.Year == DateTime.Now.Year)
                    {
                        priorYearFinding = "No";
                    }
                    return new ConsolidatedAuditFindingDownload(
                        ReviewType: f.ReviewType,
                        DateFindingRaised: f.DateFindingRaised,
                        DetailedFindings: f.DetailedFindings,
                        AuditArea: f.AuditArea,
                        Business: f.Business,
                        Level1: f.Level1,
                        Level2: f.Level2,
                        RevisedDueDate: f.RevisedDueDate,
                        Recommendation: f.Recommendation,
                        ImpactRating: f.ImpactRating,
                        WorkStream: f.WorkStream,
                        ReportingQuater: f.ReportingQuater,
                        ActionDueDate: f.ActionDueDate,
                        UpdatedComment: f.UpdatedComment,
                        ManagmentResponseAsAtTimeOfEngagement: f.ManagmentResponseAsAtTimeOfEngagement,
                        DescriptionOfFinding: f.DescriptionOfFinding,
                        ActionOwner: f.ActionOwner,
                        EngagementName: f.EngagementName,
                        Unit: f.Unit,
                        Entity: f.Entity,
                        OPRStatus: f.OPRStatus.ToString(),
                        StatusLevel: f.StatusLevel.ToString(),
                        Status: f.Status.ToString(),
                        DueDay: dueDay,
                        PriorYearFinding: priorYearFinding,
                        CurrentYearFinding: f.CreatedOnUtc.Year,
                        FindingExpectedToBeClose: findingExpectedToBeClosed,
                        FindingRaisedYear: f.DateFindingRaised?.Year ?? 0
                    );
                }).ToList();

                var columnHeadersExcel = new List<string>
                {
                    "Review Type", "Date Finding Raised", "Detailed Findings", "Audit Area", "Business", "Level1", "Level2", "Revised Due Date",
                    "Recommendation", "Impact Rating", "Work Stream", "Reporting Quater", "Action Due Date", "Updated Comment",
                    "Managment Response As At Time Of Engagement", "Description Of Finding", "Action Owner", "Engagement Name", "Unit", "Entity",
                    "OPR Status", "Status Level", "Status", "Due Day", "Prior Year Finding", "Current Year Finding", "Finding Expected To Be Close", "Finding Raised Year"
                };

                var report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, excelRecords);

                if (report == null)
                    return TypedResults.UnprocessableEntity("System failed to generate report. Please try again later.");

                return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{reportName}_{DateTime.Now:yyyyMMddHHmmss}.xlsx");
            }
            catch (Exception ex)
            {
                logger.Error($"Error in {nameof(ConsolidatedAuditFindingExcelDownloadEndpoint)} => {ex}");
                return TypedResults.Problem("Error: please try again later", statusCode: 500);
            }
        }


    }
}
