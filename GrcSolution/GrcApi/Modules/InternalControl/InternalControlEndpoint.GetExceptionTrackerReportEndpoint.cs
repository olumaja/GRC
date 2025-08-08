using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
    * Original Author: Olusegun Adaramaja
    * Date Created: 02/11/2024
    * Development Group: GRCTools
    * Internal Control: This endpoint fetch exception report using filters, also download the generated report    
    */
    public class GetExceptionTrackerReportEndpoint
    {
        /// <summary>
        /// This endpoint fetch exception report using filters, also download the generated report
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="status"></param>
        /// <param name="impactRating"></param>
        /// <param name="unit"></param>
        /// <param name="exceptRepo"></param>
        /// <param name="isDownload"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, DateTime? dateFrom, DateTime? dateTo, string? status, string? impactRating, string? unit, 
            IRepository<InternalControlExceptionTracker> exceptRepo, IHttpContextAccessor httpContext, bool isDownload = false
        )
        {
            try
            {
                if (dateFrom == default || dateTo == default)
                    return TypedResults.BadRequest("Enter valid date for Date From and Date To");

                if (dateFrom > dateTo)
                    return TypedResults.BadRequest($"Date From {dateFrom} cannot be greater than Date To {dateTo}");

                var exceptions = exceptRepo.GetContextByConditon(t => t.CreatedOnUtc.Date >= dateFrom.Value.Date && t.CreatedOnUtc.Date <= dateTo.Value.Date);

                if (!string.IsNullOrEmpty(status))
                {
                    var allowedStatus = new Dictionary<string, ExceptionTrackerStatus> { { "resolved", ExceptionTrackerStatus.Resolved }, { "not resolved", ExceptionTrackerStatus.Not_Resolved } };
                    var trackerStatus = status.ToLower();

                    if (!allowedStatus.ContainsKey(trackerStatus))
                    {
                        Dictionary<string, ExceptionTrackerStatus>.ValueCollection values = allowedStatus.Values;
                        return TypedResults.BadRequest($"The allowed status are {string.Join(", ", values).Replace('_', ' ')}");
                    }

                    exceptions = exceptions.Where(t => t.ExceptionTrackerStatus == allowedStatus[trackerStatus]);
                }

                if (!string.IsNullOrEmpty(impactRating))
                {
                    var ratings = new List<string> { "very low", "low", "medium", "high", "very high" };
                    var rating = impactRating.ToLower();

                    if (!ratings.Contains(rating))
                        return TypedResults.BadRequest($"The allowed ratings are {string.Join(", ", ratings)}");

                    exceptions = exceptions.Where(t => t.ImpactRating.ToLower() == rating);
                }

                if (!string.IsNullOrEmpty(unit))
                    exceptions = exceptions.Where(t => t.Unit.ToLower() == unit.ToLower());

                if (isDownload)
                {
                    // Download report as excel sheet
                    var records = exceptions.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new InternalControlExceptionReport(
                        Exception: t.Exception,
                        Unit: t.Unit,
                        NatureOfException: t.NatureOfException,
                        ControlImpact: t.ControlImpact,
                        ImpactRating: t.ImpactRating,
                        TransactionCount: t.TransactionCount,
                        ActivityImpacted: t.ActivityImpacted,
                        Recommendation: t.Recommendation,
                        ResponsibleOfficer: t.ResponsibleOfficer,
                        Deadline: t.Deadline,
                        ManagementResponse: t.ManagementResponse,
                        Status: t.ExceptionTrackerStatus.ToString(),
                        DateCreated: t.CreatedOnUtc,
                        ModifiedDate: t.ModifiedOnUtc
                    )).ToList();

                    var excelSheetName = "InternalControlExceptionReport";
                    var columnHeaders = new List<string>
                    {
                        "Exception", "Unit", "Date Created" , "Last Modified", "Nature Of Exception", "Control Impact", "Impact Rating",
                        "Transaction Count", "Activity Impacted","Responsible Officer", "Proposed Deadline", "Recommendation", "Management Response",
                        "Status"
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

                var paginatedTasks = Pagination<InternalControlExceptionTracker>.Create(exceptions.OrderByDescending(x => x.CreatedOnUtc), pageNumber, pageSize);

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

                var response = new PaginatedInternalControlExceptionResponse(
                    paginationMeta,
                    paginatedTasks.Select(t => new InternalControlExceptionResponse(
                    ExceptionTrackerId: t.Id,
                    Exception: t.Exception,
                    Unit: t.Unit,
                    NatureOfException: t.NatureOfException,
                    ControlImpact: t.ControlImpact,
                    ImpactRating: t.ImpactRating,
                    TransactionCount: t.TransactionCount,
                    ActivityImpacted: t.ActivityImpacted,
                    Recommendation: t.Recommendation,
                    ResponsibleOfficer: t.ResponsibleOfficer,
                    Deadline: t.Deadline,
                    ManagementResponse: t.ManagementResponse,
                    Status: t.ExceptionTrackerStatus.ToString(),
                    SupervisorStatus: t.SupervisorStatus.ToString(),
                    DateCreated: t.CreatedOnUtc,
                    ModifiedDate: t.ModifiedOnUtc
                )).ToList());

                return TypedResults.Ok(response);
            }
            catch(Exception e)
            {
                return TypedResults.Problem("Something went wrong");
            }
            
        }
    }
}
