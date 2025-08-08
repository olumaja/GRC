using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.InternalControl;
using GrcApi.Modules.Shared.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;



namespace Arm.GrcApi.Modules.InternalControl
{
    /*
    * Original Author: Olusegun Adaramaja
    * Date Created: 22/11/2024
    * Development Group: GRCTools
    * Internal Control: This endpoint fetch dashboard task report using filters, also download the generated report    
    */

    public class InternalControlTaskReportEndpoint
    {
        /// <summary>
        /// The endpoint generate dashboard task report
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="status"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="repository"></param>
        /// <param name="httpContext"></param>
        /// <param name="isDownload"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? status, DateTime dateFrom, DateTime dateTo, IRepository<InternalControlDashboard> repository,
            IHttpContextAccessor httpContext, bool isDownload = false, bool isDownloadToPDF = false
        )
        {
            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (dateFrom == default || dateTo == default)
                return TypedResults.BadRequest("Enter valid date for Date From and Date To");

            if (dateFrom > dateTo)
                return TypedResults.BadRequest($"Date From {dateFrom} cannot be greater than Date To {dateFrom}");

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;

            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var tasks = repository.GetAll();
            tasks = tasks.Where(t => t.CreatedOnUtc >= dateFrom.Date && t.CreatedOnUtc.Date <= dateTo);

            if (!string.IsNullOrEmpty(status))
            {
                var allowSatus = new Dictionary<string, InternalControlDashboardStatus>
                {
                    {"work in progress", InternalControlDashboardStatus.Work_In_Progress},
                    {"on hold", InternalControlDashboardStatus.On_Hold},
                    {"completed", InternalControlDashboardStatus.Completed}
                };

                var statusType = status.ToLower();

                if (!allowSatus.ContainsKey(statusType))
                    return TypedResults.BadRequest("Please enter one of the recommended status");

                tasks = tasks.Where(t => t.Status == allowSatus[statusType]);
            }

            var totalTask = tasks.Count();
            var completedTaskCount = tasks.Where(t => t.Status == InternalControlDashboardStatus.Completed).Count();
            var taskInProgessCount = tasks.Where(t => t.Status == InternalControlDashboardStatus.Work_In_Progress).Count();
            var taskOnHoldCount = tasks.Where(t => t.Status == InternalControlDashboardStatus.On_Hold).Count();

            if (isDownload)
            {
                var records = tasks.ToList().Select(r => new InternalControlTaskReport(
                    Activity: r.Activity,
                    ActivityInterval: r.ActivityIntervals.ToString(),
                    DateInitiated: r.CreatedOnUtc,
                    ProposeCompletionDate: r.ProposedCompletionDate,
                    DateModified: r.ModifiedOnUtc,
                    DateCompleted: r.DateTaskCompleted,
                    ActionOwner: r.ActionOwner,
                    NumberOfTransaction: r.NumberOfTransactionsReviewed,
                    Remark: r.Remarks,
                    Comment: r.Comment,
                    Status: r.Status.ToString()

                )).ToList();

                var excelSheetName = "InternalControlDashBoardReport";
                var columnHeaders = new List<string>
                {
                    "Activity", "Activity Interval", "Date Initiated" , "Propose Completion Date", "Date Modified", "Date Completed", "Action Owner",
                    "Number Of Transaction Reviewed", "Remarks","Comments", "Status"
                };

                var report = ReportDocument.GenerateExcelDocument(excelSheetName, columnHeaders, records);

                if (report == null)
                    return TypedResults.UnprocessableEntity("System fail to generate report, please try again later");

                return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
            }

            if (isDownloadToPDF) 
            {
                var pdfname = "InternalControlDashBoardReport";
                var pdfRecords = tasks.ToList().Select(r => new InternalControlTaskReportPDF(
                   Activity: r.Activity,
                   ActionOwner: r.ActionOwner,
                   Status: r.Status.ToString(),
                   ProposeCompletionDate: r.ProposedCompletionDate,
                   DateCompleted: r.DateTaskCompleted                 
                   
               )).ToList();

                    // Column headers for the report
                var columnHeaders = new List<string>
                {
                    "Activity", "Action Owner", "Status", "Propose Completion Date",  "Date Completed"                    
                };
               
                // Generate PDF Report (replace GenerateExcelDocument with a PDF generator)
                var pdfReport = ReportDocument.GeneratePdfDocument2(pdfname, columnHeaders, pdfRecords);

                if (pdfReport == null)
                    return TypedResults.UnprocessableEntity("System failed to generate report, please try again later");

                // Return the PDF file
                return TypedResults.File(pdfReport, "application/pdf", $"{pdfname}{DateTime.Now:yyyyMMddhhmmss}.pdf");

            }
            var paginatedTasks = Pagination<InternalControlDashboard>.Create(tasks.OrderByDescending(t => t.CreatedOnUtc), pageNumber, pageSize);

            var paginationMeta = new PaginationMeta
            (
                HasNextPage: paginatedTasks.HasNextPage,
                HasPreviousPage: paginatedTasks.HasPreviousPage,
                CurrentPage: paginatedTasks.CurrentPage,
                PageSize: paginatedTasks.PageSize,
                TotalPages: paginatedTasks.TotalPages,
                TotalCount: paginatedTasks.TotalCount
            );

            httpContext.HttpContext.Response.AddPagination(paginationMeta);

            var response = new InternalControlTaskReportReponse (
                PaginationMeta: paginationMeta,
                TotalTask: totalTask,
                CompletedTask: completedTaskCount,
                TaskInProgress: taskInProgessCount,
                TaskOnHold: taskOnHoldCount,
                Reports: paginatedTasks.Select(r => new InternalControlTaskReport(
                    Activity: r.Activity,
                    ActivityInterval: r.ActivityIntervals.ToString(),
                    DateInitiated: r.CreatedOnUtc,
                    ProposeCompletionDate: r.ProposedCompletionDate,
                    DateModified: r.ModifiedOnUtc,
                    DateCompleted: r.DateTaskCompleted,
                    ActionOwner: r.ActionOwner,
                    NumberOfTransaction: r.NumberOfTransactionsReviewed,
                    Remark: r.Remarks,
                    Comment: r.Comment,
                    Status: r.Status.ToString()

                )).ToList()
            );

            return TypedResults.Ok(response);
        }
   }
}
