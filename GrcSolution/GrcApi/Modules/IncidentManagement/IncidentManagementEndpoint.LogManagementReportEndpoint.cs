using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class LogManagementReportEndpoint
    {
        public static async Task<IResult> HandleAsync(
            string? logtype, string? status, string? requester, DateTime? startDate, DateTime? endDate, string? search, IRepository<LogManagement> mgtRepo,
            IHttpContextAccessor httpContext, int pageSize = 10, int pageNumber = 1, bool isDownload = false
        )
        {
            var logMgts = mgtRepo.GetAll();
            var totalRecords = logMgts.Count();
            var totalClosedRecords = logMgts.Where(l => l.Status == LogMgtStatus.Closed).Count();
            var totalRejectRecords = logMgts.Where(l => l.Status == LogMgtStatus.Rejected).Count();
            var totalProgressRecords = logMgts.Where(l => l.Status == LogMgtStatus.Work_In_Progress).Count();

            var types = new Dictionary<string, LogType>
            {
                {"SIEM", LogType.SIEM }, {"PAM", LogType.PAM }, {"CASP", LogType.CASP }, {"DAM", LogType.DAM },
                {"DLP", LogType.DLP }, {"EDR", LogType.EDR }, {"FIM", LogType.FIM }
            };

            if (!string.IsNullOrWhiteSpace(logtype))
            {
                logtype = logtype.ToUpper();
                
                if (!types.ContainsKey(logtype))
                    return TypedResults.BadRequest($"The recommended log type are {string.Join(", ", types.Keys)}");

                logMgts = logMgts.Where(l => l.LogType == types[logtype]);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                status = status.ToLower();
                var allStatus = new Dictionary<string, LogMgtStatus> {
                    { "open", LogMgtStatus.Open}, {"work in progress" , LogMgtStatus.Work_In_Progress}, {"rejected" , LogMgtStatus.Rejected}, {"closed", LogMgtStatus.Closed}
                };

                if (!allStatus.ContainsKey(status))
                    return TypedResults.BadRequest($"The recommended status are {string.Join(", ", allStatus.Keys)}");

                logMgts = logMgts.Where(l => l.Status == allStatus[status]);
            }

            if (!string.IsNullOrWhiteSpace(requester))
                logMgts = logMgts.Where(l => l.CreatedBy.ToLower() == requester.ToLower());

            if (!string.IsNullOrWhiteSpace(search))
            {
                logMgts = logMgts.Where(l => l.CreatedBy.ToLower().StartsWith(search.ToLower()) || (l.ActionOwnerUnit != null && l.ActionOwnerUnit.ToLower().StartsWith(search.ToLower())));
            }

            if (startDate != null && endDate != null)
            {
                if (startDate > endDate)
                    return TypedResults.BadRequest($"Start date cannot be greater than end date");

                logMgts = logMgts.Where(l => l.CreatedOnUtc.Date >= startDate.Value.Date && l.CreatedOnUtc.Date <= endDate.Value.Date);
            }

            #region Download report
            if (isDownload)
            {
                //Download to export
                if (logMgts.Count() == 0)
                    return TypedResults.BadRequest("No record");

                if (string.IsNullOrWhiteSpace(logtype))
                    return TypedResults.BadRequest("To export report, kindly select log type (e.g SIEM)");

                byte[]? report = null;
                var reportName = "Log Management Report";
                var columnHeadersExcel = new List<string>();

                if (types[logtype] == LogType.SIEM)
                {
                    var header = new List<string> { 
                        "Date Alert Generated", "Date of Report", "Event Name", "Description", "Source IP", "Source Hostname", "Source FQDN", "Source Username", 
                        "Destination IP", "Destination Port", "Destination Hostname", "DESTINATION FQDN", "DESTINATION USERNAME", "EVENT ID", 
                        "OBSERVATION/COMMENT", "RECOMMENDATION(S)", "Security Tool", "Requester", "Action Owner Remark", "Business Justification", "Status"
                    };

                    columnHeadersExcel.AddRange(header);
                    logMgts = logMgts.Include(l => l.SIEM);
                    var records = logMgts.Select(l => new SIEMLogMgtReport
                    {
                        DateAlertGenerated = l.DateAlertGenerated,
                        DateofReport = l.CreatedOnUtc,
                        EventName = l.EventName,
                        Description = l.SIEM.EventDescription,
                        SourceIP = l.SIEM.SourceIPAddress,
                        SourceHostname = l.SIEM.SourceHostName,
                        SourceFQDN = l.SIEM.SourceFQDN,
                        SourceUsername = l.SIEM.SourceUserName,
                        DestinationIP = l.SIEM.DestinationIpAddress,
                        DestinationPort = l.SIEM.DestinationPort,
                        DestinationHostname = l.SIEM.DestinationHostName,
                        DestionFQDN = l.SIEM.DestinationFQDN,
                        DestionUsername = l.SIEM.DestinationUserName,
                        EventId = l.SIEM.EventId,
                        Observation = l.SIEM.Observation,
                        Recommendation = l.InfoSecRemarks,
                        SecurityTool = l.SIEM.SecurityTool,
                        Requester = l.CreatedBy,
                        ActionOwnerRemark = l.ActionOwnerRemarks,
                        BusinessJustification = l.BusinessJustification,
                        Status = l.Status.GetEnumDestription()
                    }).ToList();

                    reportName = $"SIEM {reportName}";
                    report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, records);
                }
                else if (types[logtype] == LogType.PAM)
                {
                    var header = new List<string> {
                        "Date Alert Generated", "Event Name", "Incident Description", "Corrective Action Carried Out", "Status"
                    };

                    columnHeadersExcel.AddRange(header);
                    logMgts = logMgts.Include(l => l.PAM);
                    var records = logMgts.Select(l => new PAMLogMgtReport
                    {
                        DateAlertGenerated = l.DateAlertGenerated,
                        EventName = l.EventName,
                        IncidentDescription = l.PAM.IncidentDescription,
                        CorrectiveAction = l.PAM.CorrectiveActionCarriedOut,
                        Status = l.Status.GetEnumDestription()
                    }).ToList();

                    reportName = $"PAM {reportName}";
                    report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, records);
                }
                else if (types[logtype] == LogType.CASP)
                {
                    var header = new List<string> {
                        "Date Alert Generated", "Date of Report", "Event Name", "Responsible Staff", "Source IP Address", "Source Hostname", "Source Username",
                        "Security Tool", "Destination Email Address", "Application", "Observation/Comment", "Recommendation(s)", "Treated By", "Action Owner Remark",
                        "Business Justification", "Status"
                    };

                    columnHeadersExcel.AddRange(header);
                    logMgts = logMgts.Include(l => l.CASP);
                    var records = logMgts.Select(l => new CASPLogMgtReport
                    {
                        DateAlertGenerated = l.DateAlertGenerated,
                        DateofReport = l.CreatedOnUtc,
                        EventName = l.EventName,
                        ResponsibleStaff = l.CASP.ResponsibleStaff,
                        SourceIP = l.CASP.SourceIPAddress,
                        SourceHostname = l.CASP.SourceHostName,
                        SourceUsername = l.CASP.SourceUserName,
                        SecurityTool = l.CASP.SecurityTool,
                        DestinationEmail = l.CASP.DestinationEmailAddress,
                        Application = l.CASP.Application,
                        Observation = l.CASP.Observation,
                        Recommendation = l.InfoSecRemarks,
                        TreatedBy = l.ActionownerName,
                        ActionOwnerRemark = l.ActionOwnerRemarks,
                        BusinessJustification = l.BusinessJustification,
                        Status = l.Status.GetEnumDestription()
                    }).ToList();

                    reportName = $"CASP {reportName}";
                    report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, records);
                }
                else if (types[logtype] == LogType.DAM)
                {
                    var header = new List<string> {
                        "Date Alert Generated", "Date of Report", "Event Name", "Event Description", "Source Hostname", "Source Username", "Observation/Comment", 
                        "Recommendation(S)", "Security Tool", "Requester", "Action Owner Remark", "Business Justification", "Status"
                    };

                    columnHeadersExcel.AddRange(header);
                    logMgts = logMgts.Include(l => l.DAM);
                    var records = logMgts.Select(l => new DAMLogMgtReport
                    {
                        DateAlertGenerated = l.DateAlertGenerated,
                        DateofReport = l.CreatedOnUtc,
                        EventName = l.EventName,
                        EventDescription = l.DAM.EventDescription,
                        SourceHostname = l.DAM.SourceHostName,
                        SourceUsername = l.DAM.SourceUserName,
                        Observation = l.DAM.Observation,
                        Recommendation = l.InfoSecRemarks,
                        SecurityTool = l.DAM.SecurityTool,
                        Requester = l.CreatedBy,
                        ActionOwnerRemark = l.ActionOwnerRemarks,
                        BusinessJustification = l.BusinessJustification,
                        Status = l.Status.GetEnumDestription()
                    }).ToList();

                    reportName = $"DAM {reportName}";
                    report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, records);
                }
                else if (types[logtype] == LogType.DLP)
                {
                    var header = new List<string> {
                        "Date Alert Generated", "DLP Policy", "DLP Rule Matched", "DLP Rule Action", "Action Taken", "Responsible Staff", "Treated By", "Date Closed", "Status"
                    };

                    columnHeadersExcel.AddRange(header);
                    logMgts = logMgts.Include(l => l.DLP);
                    var records = logMgts.Select(l => new DLPLogMgtReport
                    {
                        DateAlertGenerated = l.DateAlertGenerated,
                        DLPPolicy = l.DLP.DLPPolicy,
                        DLPRuleMatch = l.DLP.DLPRuleMatch,
                        DLPRuleAction = l.DLP.DLPRuleAction,
                        ActionTaken = l.DLP.ActionTaken,
                        ResponsibleStaff = l.DLP.ResponsibleStaff,
                        TreatedBy = l.ActionownerName,
                        DateClosed = l.ProposeEndDate,
                        Status = l.Status.GetEnumDestription()
                    }).ToList();

                    reportName = $"DLP {reportName}";
                    report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, records);
                }
                else if (types[logtype] == LogType.EDR)
                {
                    var header = new List<string> {
                        "Date Alert Generated", "Date of Report", "Event Name", "Description", "Source IP Address", "Destination Hostname", "Destination Username",
                        "Observation/Comment", "RECOMMENDATION(S)", "Security Tool", "Requester", "Action Owner Remark", "Status"
                    };

                    columnHeadersExcel.AddRange(header);
                    logMgts = logMgts.Include(l => l.EDR);
                    var records = logMgts.Select(l => new EDRLogMgtReport
                    {
                        DateAlertGenerated = l.DateAlertGenerated,
                        DateofReport = l.CreatedOnUtc,
                        EventName = l.EventName,
                        Description = l.EDR.EventDescription,
                        SourceIP = l.EDR.SourceIPAddress,
                        DestinationHostname = l.EDR.DestinationHostName,
                        DestionUsername = l.EDR.DestinationUserName,
                        Observation = l.EDR.Observation,
                        Recommendation = l.InfoSecRemarks,
                        SecurityTool = l.EDR.SecurityTool,
                        Requester = l.CreatedBy,
                        ActionOwnerRemark = l.ActionOwnerRemarks,
                        Status = l.Status.GetEnumDestription()
                    }).ToList();

                    reportName = $"EDR {reportName}";
                    report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, records);
                }
                else if (types[logtype] == LogType.FIM)
                {
                    var header = new List<string> {
                        "Date Alert Generated", "Date of Report", "Event Name", "Description", "Source IP", "Source Hostname", "Source FQDN", "Source Username",
                        "Destination IP", "Destination Port", "Destination Hostname", "Destination FQDN", "Destination Username", "Event Id",
                        "Observation/Comment", "Recommendation(S)", "Security Tool", "Requester", "Action Owner Remark", "Business Justification", "Status"
                    };

                    columnHeadersExcel.AddRange(header);
                    logMgts = logMgts.Include(l => l.FIM);
                    var records = logMgts.Select(l => new FIMLogMgtReport
                    {
                        DateAlertGenerated = l.DateAlertGenerated,
                        DateofReport = l.CreatedOnUtc,
                        EventName = l.EventName,
                        Description = l.FIM.EventDescription,
                        SourceIP = l.FIM.SourceIPAddress,
                        SourceHostname = l.FIM.SourceHostName,
                        SourceFQDN = l.FIM.SourceFQDN,
                        SourceUsername = l.FIM.SourceUserName,
                        DestinationIP = l.FIM.DestinationIpAddress,
                        DestinationPort = l.FIM.DestinationPort,
                        DestinationHostname = l.FIM.DestinationHostName,
                        DestionationFQDN = l.FIM.DestinationFQDN,
                        DestionUsername = l.FIM.DestinationUserName,
                        EventId = l.FIM.EventId,
                        Observation = l.FIM.Observation,
                        Recommendation = l.InfoSecRemarks,
                        SecurityTool = l.FIM.SecurityTool,
                        Requester = l.CreatedBy,
                        ActionOwnerRemark = l.ActionOwnerRemarks,
                        BusinessJustification = l.BusinessJustification,
                        Status = l.Status.GetEnumDestription()
                    }).ToList();

                    reportName = $"FIM {reportName}";
                    report = ReportDocument.GenerateExcelDocument(reportName, columnHeadersExcel, records);
                }

                if (report is null)
                    return TypedResults.BadRequest("System fail to generate report, please try again later");

                return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{reportName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
            }
            #endregion

            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;

            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedReport = Pagination<LogManagement>.Create(logMgts.OrderByDescending(l => l.CreatedOnUtc), pageNumber, pageSize);
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

            var response = new LogMgtReportRespose(
                TotalRecords: totalRecords,
                TotalClosedRecords: totalClosedRecords,
                TotalRejectRecords: totalRejectRecords,
                TotalProgressRecords: totalProgressRecords,
                PaginationMeta: paginationMeta,
                Reports: paginatedReport.Select(p => new LogManagementReport
                {
                    Id = p.Id,
                    LogType = p.LogType.GetEnumDestription(),
                    Timestamp = p.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                    EventName = p.EventName,
                    Requester = p.CreatedBy,
                    Status = p.Status.GetEnumDestription()
                }).ToList()
            );

            return TypedResults.Ok(response);
        }
    }
}

