using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.ISMSReporting;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.VulnerabilityManagement;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using System.Net.Mail;

namespace Arm.GrcApi.Modules.ISMSReporting
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 07/18/2025
     * Development Group: GRCTools
     * Get Antivirus Reports Endpoint
     */
    public class GetAntivirusReportsEndpoint
    {
        /// <summary>
        /// Get Antivirus Reports Endpoint
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="reportType"></param>
        /// <param name="status"></param>
        /// <param name="repo"></param>
        /// <param name="inactiveSensors"></param>
        /// <param name="reduce"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="isDownload"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(DateTime? startDate, DateTime? endDate, string? reportType, string? status, 
            IRepository<AntivirusAssessmentModel> repo, IRepository<InactiveSensors> inactiveSensors, IRepository<ReducedFunctionalityMode> reduce, ICurrentUserService currentUserService, IHttpContextAccessor httpContext, int pageSize = 10, int pageNumber = 1, bool isDownload = false)
        {
            try
            {               
                var query = repo.GetContextByConditon(q => q.Id != default).OrderByDescending(r => r.CreatedOnUtc);
                var getinactiveSensors = inactiveSensors.GetContextByConditon(q => q.Id != default).Include(p => p.AntivirusAssessmentModel).OrderByDescending(r => r.CreatedOnUtc);
                var getreduce = reduce.GetContextByConditon(q => q.Id != default).Include(p => p.AntivirusAssessmentModel).OrderByDescending(r => r.CreatedOnUtc);

                if (startDate > endDate)
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                
                if (startDate != null || endDate != null)
                {
                    query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                                  .OrderByDescending(r => r.CreatedOnUtc);
                }

                if (!string.IsNullOrEmpty(reportType) && (reportType.ToLower() != "Inactive sensors".ToLower() || reportType.ToLower() != "Reduced functionality Mode".ToLower()))
                {
                    return TypedResults.BadRequest("Oops, Report Type can only be 'Inactive sensors' or 'Reduced functionality Mode'");
                }

                if (isDownload == true && reportType == null)
                {
                    return TypedResults.BadRequest("Oops, Report Type must be 'Inactive sensors' or 'Reduced functionality Mode'");
                }
                if (!string.IsNullOrEmpty(status) && string.IsNullOrEmpty(reportType) && isDownload == false)
                {
                    return TypedResults.BadRequest("Oops, Report Type must not be null and isDownload must be true");
                }
                if (!string.IsNullOrEmpty(status) && !string.IsNullOrEmpty(reportType) && isDownload == false)
                {
                    return TypedResults.BadRequest("Oops, Report Type must not be null and isDownload must be true");
                }
                if (isDownload == false && !string.IsNullOrEmpty(reportType))
                {
                    return TypedResults.BadRequest("Oops, IsDownload must be true");
                }
                if (isDownload == false && !string.IsNullOrEmpty(reportType) && startDate != null || endDate != null)
                {
                    return TypedResults.BadRequest("Oops, IsDownload must be true");
                }
                if (!string.IsNullOrEmpty(status))
                {
                    var getstatus = status.ToLower();
                    var statusRecommended = new Dictionary<string, AntivirusStatus>
                    {
                      {"resolved", AntivirusStatus.Resolved}, {"unresolved", AntivirusStatus.UnResolved},
                      {"pending", AntivirusStatus.Pending}, {"approve", AntivirusStatus.Approve}, {"rejected", AntivirusStatus.Rejected},
                      {"completed", AntivirusStatus.Completed}, {"awaiting validation", AntivirusStatus.Awaiting_Validation}
                    };

                    if (!statusRecommended.ContainsKey(getstatus))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");
                    query = query.Where(d => d.AntivirusStatus == statusRecommended[getstatus])
                                .OrderByDescending(r => r.CreatedOnUtc);
                }

                if (isDownload)
                {
                    if(reportType.ToLower() == "Inactive sensors".ToLower())
                    {
                        var inactiveSensorsrecords = getinactiveSensors.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new GetInactiveSensorsReportResp(
                            ComputerName: t.ComputerName,
                            LastSeenOnCrowdStrike: t.LastSeenOnCrowdStrike,
                            MACAddress: t.MACAddress,
                            SystemProductName: t.SystemProductName,
                            SystemVersion: t.SystemVersion,
                            LoggedOnUser: t.LoggedOnUser,
                            LastSeenOnManageEngine: t.LastSeenOnManageEngine,
                            Comment: t.Comment,
                            ActionOwnerComment: t.ActionOwnerComment,
                            Status: t.Status.ToString(),
                            Supervisorstatus: t.Action.ToString(),
                            ActionOwner: t.AntivirusAssessmentModel.ActionOwner,
                            Actionownerunit: t.AntivirusAssessmentModel.ActionOwnerUnit,
                            ReasonForRejection: t.AntivirusAssessmentModel.ReasonForRejection,
                            ApprovedBy: t.AntivirusAssessmentModel.ApprovedBy,
                            DateApproved: t.AntivirusAssessmentModel.DateApproved,
                            InfosecFeedbackStatus: t.AntivirusAssessmentModel.InfosecFeedbackStatus.ToString(),
                            RequestBy: t.CreatedBy,
                            RequestedDate: t.CreatedOnUtc
                        )).ToList();
                        var excelSheetName = "Inactive Sensors Reports";
                        var columnHeaders = new List<string>
                         {
                             "Computer Name","Last Seen On Crowd Strike", "MAC Address", "System Product Name", "System Version", "Logged On User", "Last Seen On Manage Engine", "Comment", "Action Owner Comment", "Status", "Supervisor Status", "Action Owner", "Action Owner Unit",
                             "Reason For Rejection", "Approved By", "Date Approved", "Infosec Feedback Status", "Request By", "Requested Date"
                         };

                        var report = ReportDocument.GenerateExcelDocument(excelSheetName, columnHeaders, inactiveSensorsrecords);

                        return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                    }
                    if (reportType.ToLower() == "Reduced functionality Mode".ToLower())
                    {
                        var getreducerecords = getreduce.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new GetReducedFunctionalityModeReportResp(
                            ComputerName: t.ComputerName,
                            LastSeenOnCrowdStrike: t.LastSeenOnCrowdStrike,
                            MACAddress: t.MACAddress,
                            SystemVersion: t.SystemVersion,
                            LoggedOnUser: t.LoggedOnUser,
                            LastSeenOnManageEngine: t.LastSeenOnManageEngine,
                            Comment: t.Comment,
                            ActionOwnerComment: t.ActionOwnerComment,
                            Status: t.Status.ToString(),
                            Supervisorstatus: t.Action.ToString(),
                            ActionOwner: t.AntivirusAssessmentModel.ActionOwner,
                            Actionownerunit: t.AntivirusAssessmentModel.ActionOwnerUnit,
                            ReasonForRejection: t.AntivirusAssessmentModel.ReasonForRejection,
                            ApprovedBy: t.AntivirusAssessmentModel.ApprovedBy,
                            DateApproved: t.AntivirusAssessmentModel.DateApproved,
                            InfosecFeedbackStatus: t.AntivirusAssessmentModel.InfosecFeedbackStatus.ToString(),
                            RequestBy: t.CreatedBy,
                            RequestedDate: t.CreatedOnUtc
                        )).ToList();
                        var excelSheetName2 = "Reduced Functionality Mode Reports";
                        var columnHeaders2 = new List<string>
                         {
                             "Computer Name","Last Seen On Crowd Strike", "MAC Address", "System Version", "Logged On User", "Last Seen On Manage Engine", "Comment", "Action Owner Comment", "Status", "Supervisor Status", "Action Owner", "Action Owner Unit",
                             "Reason For Rejection", "Approved By", "Date Approved", "Infosec Feedback Status", "Request By", "Requested Date"
                         };

                        var report = ReportDocument.GenerateExcelDocument(excelSheetName2, columnHeaders2, getreducerecords);

                        return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName2}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                    }

                    if (reportType.ToLower() == "Inactive sensors".ToLower() && startDate != null || endDate != null)
                    {
                        getinactiveSensors = getinactiveSensors.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                                 .OrderByDescending(r => r.CreatedOnUtc);
                        var inactiveSensorsrecords = getinactiveSensors.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new GetInactiveSensorsReportResp(
                            ComputerName: t.ComputerName,
                            LastSeenOnCrowdStrike: t.LastSeenOnCrowdStrike,
                            MACAddress: t.MACAddress,
                            SystemProductName: t.SystemProductName,
                            SystemVersion: t.SystemVersion,
                            LoggedOnUser: t.LoggedOnUser,
                            LastSeenOnManageEngine: t.LastSeenOnManageEngine,
                            Comment: t.Comment,
                            ActionOwnerComment: t.ActionOwnerComment,
                            Status: t.Status.ToString(),
                            Supervisorstatus: t.Action.ToString(),
                            ActionOwner: t.AntivirusAssessmentModel.ActionOwner,
                            Actionownerunit: t.AntivirusAssessmentModel.ActionOwnerUnit,
                            ReasonForRejection: t.AntivirusAssessmentModel.ReasonForRejection,
                            ApprovedBy: t.AntivirusAssessmentModel.ApprovedBy,
                            DateApproved: t.AntivirusAssessmentModel.DateApproved,
                            InfosecFeedbackStatus: t.AntivirusAssessmentModel.InfosecFeedbackStatus.ToString(),
                            RequestBy: t.CreatedBy,
                            RequestedDate: t.CreatedOnUtc
                        )).ToList();
                        var excelSheetName = "Inactive Sensors Reports";
                        var columnHeaders = new List<string>
                         {
                             "Computer Name","Last Seen On Crowd Strike", "MAC Address", "System Product Name", "System Version", "Logged On User", "Last Seen On Manage Engine", "Comment", "Action Owner Comment", "Status", "Supervisor Status", "Action Owner", "Action Owner Unit",
                             "Reason For Rejection", "Approved By", "Date Approved", "Infosec Feedback Status", "Request By", "Requested Date"
                         };

                        var report = ReportDocument.GenerateExcelDocument(excelSheetName, columnHeaders, inactiveSensorsrecords);

                        return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                    }
                    if (reportType.ToLower() == "Reduced functionality Mode".ToLower() && startDate != null || endDate != null)
                    {
                        getreduce = getreduce.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                                 .OrderByDescending(r => r.CreatedOnUtc);
                        var getreducerecords = getreduce.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new GetReducedFunctionalityModeReportResp(
                            ComputerName: t.ComputerName,
                            LastSeenOnCrowdStrike: t.LastSeenOnCrowdStrike,
                            MACAddress: t.MACAddress,
                            SystemVersion: t.SystemVersion,
                            LoggedOnUser: t.LoggedOnUser,
                            LastSeenOnManageEngine: t.LastSeenOnManageEngine,
                            Comment: t.Comment,
                            ActionOwnerComment: t.ActionOwnerComment,
                            Status: t.Status.ToString(),
                            Supervisorstatus: t.Action.ToString(),
                            ActionOwner: t.AntivirusAssessmentModel.ActionOwner,
                            Actionownerunit: t.AntivirusAssessmentModel.ActionOwnerUnit,
                            ReasonForRejection: t.AntivirusAssessmentModel.ReasonForRejection,
                            ApprovedBy: t.AntivirusAssessmentModel.ApprovedBy,
                            DateApproved: t.AntivirusAssessmentModel.DateApproved,
                            InfosecFeedbackStatus: t.AntivirusAssessmentModel.InfosecFeedbackStatus.ToString(),
                            RequestBy: t.CreatedBy,
                            RequestedDate: t.CreatedOnUtc
                        )).ToList();
                        var excelSheetName2 = "Reduced Functionality Mode Reports";
                        var columnHeaders2 = new List<string>
                         {
                             "Computer Name","Last Seen On Crowd Strike", "MAC Address", "System Version", "Logged On User", "Last Seen On Manage Engine", "Comment", "Action Owner Comment", "Status", "Supervisor Status", "Action Owner", "Action Owner Unit",
                             "Reason For Rejection", "Approved By", "Date Approved", "Infosec Feedback Status", "Request By", "Requested Date"
                         };

                        var report = ReportDocument.GenerateExcelDocument(excelSheetName2, columnHeaders2, getreducerecords);

                        return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName2}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                    }

                    if (reportType.ToLower() == "Inactive sensors".ToLower() && !string.IsNullOrEmpty(status))
                    {
                        var getstatus = status.ToLower();
                        var statusRecommended = new Dictionary<string, AntivirusStatus>
                        {
                            {"resolved", AntivirusStatus.Resolved}, {"unresolved", AntivirusStatus.UnResolved}
                        };

                        if (!statusRecommended.ContainsKey(getstatus))
                            return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");
                        getinactiveSensors = getinactiveSensors.Where(d => d.Status == statusRecommended[getstatus])
                                    .OrderByDescending(r => r.CreatedOnUtc);

                        var inactiveSensorsrecords = getinactiveSensors.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new GetInactiveSensorsReportResp(
                            ComputerName: t.ComputerName,
                            LastSeenOnCrowdStrike: t.LastSeenOnCrowdStrike,
                            MACAddress: t.MACAddress,
                            SystemProductName: t.SystemProductName,
                            SystemVersion: t.SystemVersion,
                            LoggedOnUser: t.LoggedOnUser,
                            LastSeenOnManageEngine: t.LastSeenOnManageEngine,
                            Comment: t.Comment,
                            ActionOwnerComment: t.ActionOwnerComment,
                            Status: t.Status.ToString(),
                            Supervisorstatus: t.Action.ToString(),
                            ActionOwner: t.AntivirusAssessmentModel.ActionOwner,
                            Actionownerunit: t.AntivirusAssessmentModel.ActionOwnerUnit,
                            ReasonForRejection: t.AntivirusAssessmentModel.ReasonForRejection,
                            ApprovedBy: t.AntivirusAssessmentModel.ApprovedBy,
                            DateApproved: t.AntivirusAssessmentModel.DateApproved,
                            InfosecFeedbackStatus: t.AntivirusAssessmentModel.InfosecFeedbackStatus.ToString(),
                            RequestBy: t.CreatedBy,
                            RequestedDate: t.CreatedOnUtc
                        )).ToList();
                        var excelSheetName = "Inactive Sensors Reports";
                        var columnHeaders = new List<string>
                         {
                             "Computer Name","Last Seen On Crowd Strike", "MAC Address", "System Product Name", "System Version", "Logged On User", "Last Seen On Manage Engine", "Comment", "Action Owner Comment", "Status", "Supervisor Status", "Action Owner", "Action Owner Unit",
                             "Reason For Rejection", "Approved By", "Date Approved", "Infosec Feedback Status", "Request By", "Requested Date"
                         };

                        var report = ReportDocument.GenerateExcelDocument(excelSheetName, columnHeaders, inactiveSensorsrecords);

                        return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                    }
                    if (reportType.ToLower() == "Reduced functionality Mode".ToLower() && !string.IsNullOrEmpty(status))
                    {
                        var getstatus = status.ToLower();
                        var statusRecommended = new Dictionary<string, AntivirusStatus>
                        {
                            {"resolved", AntivirusStatus.Resolved}, {"unresolved", AntivirusStatus.UnResolved}
                        };

                        if (!statusRecommended.ContainsKey(getstatus))
                            return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");
                        getinactiveSensors = getinactiveSensors.Where(d => d.Status == statusRecommended[getstatus])
                                    .OrderByDescending(r => r.CreatedOnUtc);

                        var getreducerecords = getreduce.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new GetReducedFunctionalityModeReportResp(
                            ComputerName: t.ComputerName,
                            LastSeenOnCrowdStrike: t.LastSeenOnCrowdStrike,
                            MACAddress: t.MACAddress,
                            SystemVersion: t.SystemVersion,
                            LoggedOnUser: t.LoggedOnUser,
                            LastSeenOnManageEngine: t.LastSeenOnManageEngine,
                            Comment: t.Comment,
                            ActionOwnerComment: t.ActionOwnerComment,
                            Status: t.Status.ToString(),
                            Supervisorstatus: t.Action.ToString(),
                            ActionOwner: t.AntivirusAssessmentModel.ActionOwner,
                            Actionownerunit: t.AntivirusAssessmentModel.ActionOwnerUnit,
                            ReasonForRejection: t.AntivirusAssessmentModel.ReasonForRejection,
                            ApprovedBy: t.AntivirusAssessmentModel.ApprovedBy,
                            DateApproved: t.AntivirusAssessmentModel.DateApproved,
                            InfosecFeedbackStatus: t.AntivirusAssessmentModel.InfosecFeedbackStatus.ToString(),
                            RequestBy: t.CreatedBy,
                            RequestedDate: t.CreatedOnUtc
                        )).ToList();
                        var excelSheetName2 = "Reduced Functionality Mode Reports";
                        var columnHeaders2 = new List<string>
                         {
                             "Computer Name","Last Seen On Crowd Strike", "MAC Address", "System Version", "Logged On User", "Last Seen On Manage Engine", "Comment", "Action Owner Comment", "Status", "Supervisor Status", "Action Owner", "Action Owner Unit",
                             "Reason For Rejection", "Approved By", "Date Approved", "Infosec Feedback Status", "Request By", "Requested Date"
                         };

                        var report = ReportDocument.GenerateExcelDocument(excelSheetName2, columnHeaders2, getreducerecords);

                        return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName2}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                    }

                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<AntivirusAssessmentModel>.Create(query, pageNumber, pageSize);

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

                var response = new PaginatedGetAntivirusAssessmentResp(
                    paginationMeta,
                    paginatedTasks.OrderByDescending(x => x.CreatedOnUtc).Select(p => new GetAntivirusAssessmentResponse
                    {                       
                        AntivirusAssessmentFileId = p.Id,
                        Date = p.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                        AssessmentType = p.AssessmentType,
                        AssessmentTitle = p.TitleOfAssessment,
                        Initiator = p.CreatedBy,
                        ActionOwner = p.ActionOwner,
                        Status = p.AntivirusStatus.ToString()

                    }).ToList()
                );

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Exception: antivirus record was not found");
            }
        }

    }
}
