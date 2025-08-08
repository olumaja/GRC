using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;

namespace Arm.GrcApi.Modules.OperationControl
{
    /*
    * Original Author: Olusegun Adaramaja
    * Date Created: 14/02/2025
    * Development Group: GRCTools
    * This method generate excel document 
    */
    public class ExceptionReportEndpoint
    {
        /// <summary>
        /// The endpoint fetch and download operation control exception reports
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="operationActivity"></param>
        /// <param name="resolutionStatus"></param>
        /// <param name="exceptionCategory"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="search"></param>
        /// <param name="operationRepo"></param>
        /// <param name="httpContext"></param>
        /// <param name="logger"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="isDownload"></param>
        /// <param name="downloadFormat"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            string? unit, string? operationActivity, string? resolutionStatus, string? exceptionCategory, DateTime? startDate, DateTime? endDate, 
            string? search, IRepository<OperationControl> operationRepo, IHttpContextAccessor httpContext, Serilog.ILogger logger, ICurrentUserService currentUserService,
            int pageSize = 10, int pageNumber = 1, bool isDownload = false, string downloadFormat = "excel"
        )
        {
            try
            {
                if (!currentUserService.CurrentUserRoles.Contains("OperationControlOfficer") && !currentUserService.CurrentUserRoles.Contains("OperationControlSupervisor"))
                {
                    return TypedResults.Unauthorized();
                }

                var operationControls = operationRepo.GetAll();

                if (startDate is not null && endDate is not null)
                {
                    if (startDate > endDate)
                        return TypedResults.BadRequest("Start date cannot be greater the end date");

                    operationControls = operationControls.Where(o => o.CreatedOnUtc.Date >= startDate.Value.Date && o.CreatedOnUtc.Date <= endDate.Value.Date);
                }

                if (!string.IsNullOrWhiteSpace(unit))
                    operationControls = operationControls.Where(o => o.Unit.ToLower() == unit.ToLower());

                if (!string.IsNullOrWhiteSpace(operationActivity))
                    operationControls = operationControls.Where(o => o.OperationActivity.ToLower() == operationActivity.ToLower());


                if (!string.IsNullOrWhiteSpace(resolutionStatus))
                {
                    var status = new Dictionary<string, ExceptionStatus> { { "open", ExceptionStatus.Open }, { "rejected", ExceptionStatus.Rejected }, { "submitted", ExceptionStatus.Submitted }, { "approved as exception", ExceptionStatus.Approved_As_Exception }, { "approved as observation", ExceptionStatus.Approved_As_Observation } };
                    var inputStatus = resolutionStatus.ToLower();

                    if (!status.ContainsKey(inputStatus))
                        return TypedResults.BadRequest("The recommended status are Open, Submitted, Approved As Observation, Approved As Exception, Rejected");

                    operationControls = operationControls.Where(o => o.ResolutionStatus == status[inputStatus]);
                }

                if (!string.IsNullOrWhiteSpace(exceptionCategory))
                {
                    var category = new Dictionary<string, ExceptionCategory>{
                        { "minor", ExceptionCategory.Minor}, { "medium", ExceptionCategory.Medium}, { "major", ExceptionCategory.Major }
                    };
                    var inputCategory = exceptionCategory.ToLower();

                    if (!category.ContainsKey(inputCategory))
                        return TypedResults.BadRequest($"The recommended categories are Minor, Medium and Major");

                    operationControls = operationControls.Where(o => o.ExceptionCategory == category[inputCategory]);
                }

                if (!string.IsNullOrWhiteSpace(search)) //exceptionCategory
                {                    
                    operationControls = operationControls.Where(o => o.ExceptionDescription.Contains(search) || o.ActionOwner.Contains(search) || o.ReAssignedOfficer.Contains(search) ||
                      o.OperationActivity.Contains(search) || o.CreatedBy.Contains(search) || o.Unit.Contains(search)); 
                }

                #region Download report
                  if(isDownload)
                  {
                    
                    if (operationControls.Count() == 0)
                            return TypedResults.BadRequest("No record");

                        var format = downloadFormat.ToLower();  
                        var records = operationControls.ToList()
                            .Select(r => new ExceptionReportDownload(
                                ExceptionCategory: r.ExceptionCategory.ToString(),
                                DateRaised: DateOnly.FromDateTime(r.CreatedOnUtc),
                                DateClosed: r.DateResolved.HasValue ? DateOnly.FromDateTime(r.DateResolved.Value) : null,
                                DueDate: DateOnly.FromDateTime(r.CompletionDate),
                                DaysOverDue: r.ResolutionStatus == ExceptionStatus.Open && r.CompletionDate < DateTime.Today ? (DateTime.Today - r.CompletionDate.Date).Days : 0,
                                LoggedBy: r.CreatedBy,
                                Status: r.Status.ToString(),
                                ActionOwner: r.ActionOwner,
                                ActionOwnerResponse: r.ActionOwnerComment
                            )).ToList();

                    var Excelrecords = operationControls.ToList()
                        .Select(r => new ExceptionReportExcelDownload(
                             ExceptionDescription: r.ExceptionDescription,
                             ExceptionCategory: r.ExceptionCategory.ToString(),
                             DateRaised: DateOnly.FromDateTime(r.CreatedOnUtc),
                             DateClosed: r.DateResolved.HasValue ? DateOnly.FromDateTime(r.DateResolved.Value) : null,
                             DueDate: DateOnly.FromDateTime(r.CompletionDate),
                             DaysOverDue: r.ResolutionStatus == ExceptionStatus.Open && r.CompletionDate < DateTime.Today ? (DateTime.Today - r.CompletionDate.Date).Days : 0,
                             LoggedBy: r.CreatedBy,
                             ReassignedTo: r.ReAssignedOfficer,
                             ActionOwner: r.ActionOwner,
                             ActionOwnerResponse: r.ActionOwnerComment,
                             Status: r.Status.ToString()      
                        )).ToList();

                    var reportName = "Exception Report";
                        var columnHeaders = new List<string>
                        {
                                "EXCEPTION CATEGORY", "DATE RAISED", "DATE CLOSED", "DUE DATE" , "DAYS OVERDUE", "LOGGED BY", "STATUS",
                                "ACTION OWNER", "ACTION OWNER'S RESPONSE"
                        };
                   
                    var columnHeadersExcel = new List<string>
                        {
                                "EXCEPTION DESCRIPTION", "EXCEPTION CATEGORY", "DATE RAISED", "DATE CLOSED", "DUE DATE" , "DAYS OVERDUE", "LOGGED BY", "REASSIGNED TO",
                                "ACTION OWNER", "ACTION OWNER'S RESPONSE", "STATUS"
                        };
                    if (format == "excel")
                        {
                                var report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, Excelrecords);

                                if (report == null)
                                    return TypedResults.UnprocessableEntity("System fail to generate report, please try again later");

                                return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{reportName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                        }
                        else if (format == "pdf")
                        {
                            var report = ReportDocument.GeneratePdfDocument2(reportName, columnHeaders, records);

                            if (report == null)
                                return TypedResults.UnprocessableEntity("System fail to generate report, please try again later");

                            return TypedResults.File(report, "application/pdf", $"{reportName}{DateTime.Now:yyyyMMddhhmmss}.pdf");
                        }
                        else
                            return TypedResults.BadRequest("You can only download excel or pdf format");
                    }
                #endregion

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedReport = Pagination<OperationControl>.Create(operationControls.OrderByDescending(o => o.CreatedOnUtc), pageNumber, pageSize);
                var paginationMeta = new PaginationMeta
                (
                    paginatedReport.HasNextPage,
                    paginatedReport.HasPreviousPage,
                    paginatedReport.CurrentPage,
                    paginatedReport.PageSize,
                    paginatedReport.TotalPages,
                    paginatedReport.TotalCount
                );

                httpContext.HttpContext.Response.AddPagination(paginationMeta);
                var response = new ExceptionRecordResponse(
                    paginationMeta,
                    reports: paginatedReport.Select(r => new ExceptionReport(
                        OperationControlId: r.Id,
                        BusinessUnit: r.Unit,
                        OperationalActivity: r.OperationActivity,
                        ActionOwner: r.ActionOwner,
                        ExceptionDescription: r.ExceptionDescription,
                        ExceptionCategory: r.ExceptionCategory.ToString(),
                        DateRaised: DateOnly.FromDateTime(r.CreatedOnUtc),
                        DateClosed: r.DateResolved.HasValue ? DateOnly.FromDateTime(r.DateResolved.Value) : null,
                        DueDate: DateOnly.FromDateTime(r.CompletionDate),
                        DaysOverDue: r.ResolutionStatus == ExceptionStatus.Open && r.CompletionDate < DateTime.Today ? (DateTime.Today - r.CompletionDate.Date).Days : 0,
                        LoggedBy: r.CreatedBy,
                        ReassignedTo: r.ReAssignedOfficer,
                        Status: r.ResolutionStatus.ToString()
                    )).ToList()
                );

                return TypedResults.Ok(response);
            }
            catch( Exception ex )
            {
                logger.Error($"Error from {nameof(ExceptionReportEndpoint)} ==> Message: {ex.Message}; Stack Track: {ex}");
                return TypedResults.Problem($"Error: please try again later", null, 500);
            }
        }
    }
}
