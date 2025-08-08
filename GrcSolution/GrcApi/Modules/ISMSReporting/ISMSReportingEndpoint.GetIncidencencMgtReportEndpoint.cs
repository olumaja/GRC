using Arm.GrcApi.Modules.InfosecRiskAssessment;
using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcApi.Modules.IncidentManagement;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.ISMSReporting
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 07/18/2025
   * Development Group: GRCTools
   * Get Incidencenc Management Report Endpoint
   */
    public class GetIncidencencMgtReportEndpoint
    {
        /// <summary>
        /// Get Incidencenc Management Report Endpoint
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="isDownload"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(DateTime? startDate, DateTime? endDate,
            IRepository<IncidentManagementLog> repo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext, int pageSize = 10, int pageNumber = 1, bool isDownload = false)
        {
            try
            {               
                
                if (startDate > endDate)
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");

                var query = repo.GetContextByConditon(q => q.Id != default)
                                .OrderByDescending(r => r.CreatedOnUtc);
                if (startDate != null || endDate != null)
                {
                    query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                                  .OrderByDescending(r => r.CreatedOnUtc);
                }

                if (isDownload)
                {
                    var records = query.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new GetIncidencencMgtReportResp(
                        SecurityIncident: t.SecurityIncident,
                        SecurityArea: t.SecurityArea.ToString(),
                        Severity: t.Severity.ToString(),
                        DescriptionOfIncident: t.DescriptionOfIncident,
                        TypeOfAsset: t.TypeOfAsset,
                        AssetDescription: t.AssetDescription,
                        ReportingStaff: t.ReportingStaff,
                        DateOfReporting: t.DateOfReporting,
                        DescriptionOfActionTaken: t.DescriptionOfActionTaken,
                        RootCause: t.RootCause,
                        Impact: t.Impact,
                        RecommendationToPreventFutureReoccurence: t.RecommendationToPreventFutureReoccurence,
                        LessonLearnt: t.LessonLearnt,
                        ReportingStaffComment: t.ReportingStaffComment,
                        ReportingUnit: t.ReportingUnit,
                        Status: t.Status.ToString(),
                        DateOfClosure: t.DateOfClosure,
                        ActionOwner: t.ActionOwnerName,
                        ActionOwnerComment: t.ActionOwnerComment,
                        IncidentTag: t.IncidentTag.ToString(),
                        InfoSecStaffName: t.InfoSecStaffName,
                        InfoSecRecommendation: t.InfoSecRecommendation,
                        ReportingStaffCommentDate: t.ReportingStaffCommentDate,
                        InfoSecStaffCommentDate: t.InfoSecStaffCommentDate,
                        ActionOwnerCommentDate: t.ActionOwnerCommentDate
                    )).ToList();
                    var excelSheetName = "IncidencencManagementReport";
                    var columnHeaders = new List<string>
                    {
                        "Security Incident", "Security Area", "Severity" , "Description Of Incident", "Type Of Asset", "Asset Description", "Reporting Staff",
                        "Date Of Reporting", "Description Of Action Taken", "Root Cause" , "Impact", "Recommendation To Prevent Future Reoccurence", "Lesson Learnt", "Reporting Staff Comment",
                        "Reporting Unit", "Status", "Date Of Closure", "Action Owner", "Action Owner Comment", "Incident Tag", "InfoSec Staff Name",
                        "InfoSec Recommendation", "Reporting Staff Comment Date","InfoSec Staff Comment Date", "Action Owner Comment Date"
                    };

                    var report = ReportDocument.GenerateExcelDocument(excelSheetName, columnHeaders, records);

                    return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<IncidentManagementLog>.Create(query, pageNumber, pageSize);

                var paginationMeta = new PaginationMeta
                    (
                        paginatedTasks.HasNextPage,
                        paginatedTasks.HasPreviousPage,
                        paginatedTasks.CurrentPage,
                        paginatedTasks.PageSize,
                        paginatedTasks.TotalPages,
                        paginatedTasks.TotalCount
                    );

                httpContext.HttpContext.Response.AddPagination(paginationMeta);

                var response = new PaginatedGetLogIncidenceResp(
                    paginationMeta,
                    paginatedTasks.OrderByDescending(x => x.CreatedOnUtc).Select(p => new GetLogIncidenceResponse
                    {
                         IncidenceId = p.Id,
                         SecurityIncident = p.SecurityIncident,
                         SecurityAreas = p.SecurityAreas,
                         Severity = p.Severity.ToString(),
                         DescriptionOfIncident = p.DescriptionOfIncident,
                         TypeOfAsset = p.TypeOfAsset,
                         ReportingUnit = p.ReportingUnit,
                         ReportingStaff = p.ReportingStaff,
                         DateOfReporting = p.DateOfReporting,
                         DateOfIncidence = p.DateOfReporting,
                         DateOfClosure = p.DateOfClosure,
                        Status = p.Status.ToString(),
                    }).ToList()
                );

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Exception: Incidence management record was not found");
            }
        }
    }
}
