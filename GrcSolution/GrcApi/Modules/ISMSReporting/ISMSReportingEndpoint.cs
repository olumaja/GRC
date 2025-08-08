using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.ISMSReporting
{
    public class ISMSLogReportingEndpoint
    {
        public static async Task<IResult> HandleAsync(
            string? logType, DateTime? startDate, DateTime? endDate, IRepository<LogManagement> logRepo, IHttpContextAccessor httpContext,
            int pageNumber = 1, int pageSize = 10,  bool isDownload = false
        )
        {
            int totalClosed = 0;
            int totalOpened = 0;
            var logManagement = logRepo.GetAll();

            var caspCount = logManagement.Where(l => l.LogType == LogType.CASP).Count();
            var damCount = logManagement.Where(l => l.LogType == LogType.DAM).Count();
            var dlpCount = logManagement.Where(l => l.LogType == LogType.DLP).Count();
            var edrCount = logManagement.Where(l => l.LogType == LogType.EDR).Count();
            var fimCount = logManagement.Where(l => l.LogType == LogType.FIM).Count();
            var pamCount = logManagement.Where(l => l.LogType == LogType.PAM).Count();
            var siemCount = logManagement.Where(l => l.LogType == LogType.SIEM).Count();
            var logDic = new Dictionary<string, LogType> {
                    {"CASP", LogType.CASP}, {"DAM", LogType.DAM}, {"DLP", LogType.DLP}, {"EDR", LogType.EDR},
                    {"FIM", LogType.FIM}, {"PAM", LogType.PAM}, {"SIEM", LogType.SIEM}
            };

            if (!string.IsNullOrWhiteSpace(logType))
            {
                logType = logType.ToUpper();
                
                if (!logDic.ContainsKey(logType))
                    return TypedResults.BadRequest($"Log type allow are {string.Join(",", logDic.Keys)}");

                logManagement = logManagement.Where(l => l.LogType == logDic[logType]);
            }

            totalClosed = logManagement.Where(l => l.Status == LogMgtStatus.Closed).Count();
            totalOpened = logManagement.Where(l => l.Status != LogMgtStatus.Closed).Count();

            if (startDate.HasValue && endDate.HasValue)
            {

                if (startDate > endDate)
                    return TypedResults.BadRequest("Start date cannot be greater than end date");

                logManagement = logManagement.Where(l => l.CreatedOnUtc.Date >= startDate.Value.Date && l.CreatedOnUtc.Date <= endDate.Value.Date);
            }

            //Export report to excel
            if (isDownload)
            {
                if (string.IsNullOrWhiteSpace(logType))
                    return TypedResults.BadRequest("Kindly select a log type to export");

                if(logManagement.Count() == 0)
                    return TypedResults.BadRequest("No record");

                byte[] excelByte;
                var reportName = string.Empty;
                var headers = new List<string> {
                    "Log Type", "Event Name", "Requester", "Requested Date", "Approved By", "Approved Date", "Action Owner",
                    "Action Owner Recommendation", "Status", "Date Alert Generated", "Propose EndDate", "Business Justification", "InfoSec Recommendation",
                    "User Approval Obtain"
                };

                if (logDic[logType] == LogType.CASP) {

                    reportName = "CASPReport";
                    headers.AddRange(new List<string> { 
                        "Responsible Staff", "Source IP Address", "Source HostName", "Source Location", "Source UserName", "Source FileName",
                        "Source Device", "Destination Email", "Object Identifier", "Security Tool", "Observation", "Application"
                    });
                    var casp = logManagement.Include(l => l.CASP);

                    var caspReports = casp.Select(c => new CASPReport
                    {
                        LogType = c.LogType.GetEnumDestription(),
                        EventName = c.EventName,
                        Requester = c.CreatedBy,
                        RequestedDate = c.CreatedOnUtc.Date,
                        ApprovedBy = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedBy : null,
                        ApprovedDate = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedOnUtc.Value.Date : null,
                        ActionOwner = c.ActionownerName,
                        ActionOwnerRemark = c.ActionOwnerRemarks,
                        Status = c.Status.GetEnumDestription(),
                        DateAlertGenerated = c.DateAlertGenerated.Value.Date,
                        ProposeEndDate = c.ProposeEndDate.Value.Date,
                        BusinessJustification = c.BusinessJustification,
                        InfoSecRemark = c.InfoSecRemarks,
                        UserApprovalObtain = c.UserApprovalObtained,
                        ResponsibleStaff = c.CASP.ResponsibleStaff,
                        SourceIPAddress = c.CASP.SourceIPAddress,
                        SourceHostName = c.CASP.SourceHostName,
                        SourceLocation = c.CASP.SourceLocation,
                        SourceUserName = c.CASP.SourceUserName,
                        SourceFileName = c.CASP.SourceFileName,
                        SourceDevice = c.CASP.SourceDevice,
                        DestinationEmail = c.CASP.DestinationEmailAddress,
                        ObjectIdentifier = c.CASP.ObjectIdentifier,
                        SecurityTool = c.CASP.SecurityTool,
                        Observation = c.CASP.Observation,
                        Application = c.CASP.Application
                    }).ToList();
                    excelByte = ReportDocument.GenerateExcelDocument(reportName, headers, caspReports);
                }

                else if (logDic[logType] == LogType.DAM) {

                    reportName = "DAMReport";
                    headers.AddRange(new List<string> {
                        "Event Description", "Configuration Object", "Configuration Detail", "Source IP Address", "Source Port", "Source FQDN",
                        "Source HostName", "Source UserName", "Destination IP Address", "Destination Port", "Destination HostName", "Destination FQDN",
                        "Destination UserName", "NAT IP Address", "NAT Port", "Malicious Reputation", "Event Id", "UserAuthorized", "Observation",
                        "Security Tool"
                    });

                    var dam = logManagement.Include(l => l.DAM);
                    var damReports = dam.Select(c => new DAMReport
                    {
                        LogType = c.LogType.GetEnumDestription(),
                        EventName = c.EventName,
                        Requester = c.CreatedBy,
                        RequestedDate = c.CreatedOnUtc.Date,
                        ApprovedBy = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedBy : null,
                        ApprovedDate = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedOnUtc.Value.Date : null,
                        ActionOwner = c.ActionownerName,
                        ActionOwnerRemark = c.ActionOwnerRemarks,
                        Status = c.Status.GetEnumDestription(),
                        DateAlertGenerated = c.DateAlertGenerated.Value.Date,
                        ProposeEndDate = c.ProposeEndDate.Value.Date,
                        BusinessJustification = c.BusinessJustification,
                        InfoSecRemark = c.InfoSecRemarks,
                        UserApprovalObtain = c.UserApprovalObtained,
                        EventDescription = c.DAM.EventDescription,
                        ConfigurationObject = c.DAM.ConfigurationObject,
                        ConfigurationDetail = c.DAM.ConfigurationDetail,
                        SourceIPAddress = c.DAM.SourceIPAddress,
                        SourcePort = c.DAM.SourcePort,
                        SourceFQDN = c.DAM.SourceFQDN,
                        SourceHostName = c.DAM.SourceHostName,
                        SourceUserName = c.DAM.SourceUserName,
                        DestinationIPAddress = c.DAM.DestinationIpAddress,
                        DestinationPort = c.DAM.DestinationPort,
                        DestinationHostName = c.DAM.DestinationHostName,
                        DestinationFQDN = c.DAM.DestinationFQDN,
                        DestinationUserName = c.DAM.DestinationUserName,
                        NATIPAddress = c.DAM.NATIPAddress,
                        NATPort = c.DAM.NATPort,
                        MaliciousReputation = c.DAM.MaliciousReputation,
                        EventId = c.DAM.EventId,
                        UserAuthorized = c.DAM.UserAuthorized,
                        Observation = c.DAM.Observation,
                        SecurityTool = c.DAM.SecurityTool
                    }).ToList();
                    excelByte = ReportDocument.GenerateExcelDocument(reportName, headers, damReports);
                }

                else if(logDic[logType] == LogType.DLP) {

                    reportName = "DLPReport";
                    headers.AddRange(new List<string> {
                        "DLP Policy", "DLP Rule Match", "DLP Rule Action", "Action Taken", "Responsible Staff"
                    });
                    var dlp = logManagement.Include(l => l.DLP);
                    var dlpReports = dlp.Select(c => new DLPReport
                    {
                        LogType = c.LogType.GetEnumDestription(),
                        EventName = c.EventName,
                        Requester = c.CreatedBy,
                        RequestedDate = c.CreatedOnUtc.Date,
                        ApprovedBy = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedBy : null,
                        ApprovedDate = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedOnUtc.Value.Date : null,
                        ActionOwner = c.ActionownerName,
                        ActionOwnerRemark = c.ActionOwnerRemarks,
                        Status = c.Status.GetEnumDestription(),
                        DateAlertGenerated = c.DateAlertGenerated.Value.Date,
                        ProposeEndDate = c.ProposeEndDate.Value.Date,
                        BusinessJustification = c.BusinessJustification,
                        InfoSecRemark = c.InfoSecRemarks,
                        UserApprovalObtain = c.UserApprovalObtained,
                        DLPPolicy = c.DLP.DLPPolicy,
                        DLPRuleMatch = c.DLP.DLPRuleMatch,
                        DLPRuleAction = c.DLP.DLPRuleAction,
                        ActionTaken = c.DLP.ActionTaken,
                        ResponsibleStaff = c.DLP.ResponsibleStaff
                    }).ToList();
                    excelByte = ReportDocument.GenerateExcelDocument(reportName, headers, dlpReports);
                }

                else if(logDic[logType] == LogType.EDR) {

                    reportName = "EDRReport";
                    headers.AddRange(new List<string> {
                        "Event Description", "Configuration Detail", "Source IP Address", "Source FQDN", "Source FileName",
                        "Severity", "Destination FQDN", "Destination UserName", "Destination IP Address", "Destination HostName",
                        "Event Id", "Security Tool", "Action Taken", "Technique", "FileHash", "Observation"
                    });
                    var edr = logManagement.Include(l => l.EDR);
                    var edrReport = edr.Select(c => new EDRReport
                    {
                        LogType = c.LogType.GetEnumDestription(),
                        EventName = c.EventName,
                        Requester = c.CreatedBy,
                        RequestedDate = c.CreatedOnUtc.Date,
                        ApprovedBy = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedBy : null,
                        ApprovedDate = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedOnUtc.Value.Date : null,
                        ActionOwner = c.ActionownerName,
                        ActionOwnerRemark = c.ActionOwnerRemarks,
                        Status = c.Status.GetEnumDestription(),
                        DateAlertGenerated = c.DateAlertGenerated.Value.Date,
                        ProposeEndDate = c.ProposeEndDate.Value.Date,
                        BusinessJustification = c.BusinessJustification,
                        InfoSecRemark = c.InfoSecRemarks,
                        UserApprovalObtain = c.UserApprovalObtained,
                        EventDescription = c.EDR.EventDescription,
                        ConfigurationDetail = c.EDR.ConfigurationDetail,
                        SourceIPAddress = c.EDR.SourceIPAddress,
                        SourceFQDN = c.EDR.SourceFQDN,
                        SourceFileName = c.EDR.SourceFileName,
                        Severity = c.EDR.Severity,
                        DestinationFQDN = c.EDR.DestinationFQDN,
                        DestinationUserName = c.EDR.DestinationUserName,
                        DestinationIPAddress = c.EDR.DestinationIPAddress,
                        DestinationHostName = c.EDR.DestinationHostName,
                        EventId = c.EDR.EventId,
                        SecurityTool = c.EDR.SecurityTool,
                        ActionTakenByUs = c.EDR.ActionTakenByUs,
                        Technique = c.EDR.Technique,
                        FileHash = c.EDR.FileHash,
                        Observation = c.EDR.Observation
                    }).ToList();
                    excelByte = ReportDocument.GenerateExcelDocument(reportName, headers, edrReport);
                }

                else if(logDic[logType] == LogType.FIM) {

                    reportName = "FIMReport";
                    headers.AddRange(new List<string> {
                        "Event Description", "Configuration Object", "Configuration Detail", "Source IP Address", "Source Port", "Source FQDN", 
                        "Source HostName", "Source UserName", "Destination IP Address", "Destination Port", "Destination HostName", "Destination FQDN",
                        "Destination UserName", "NAT IP Address", "NAT Port", "Malicious Reputation", "Event Id", "Security Tool", "Observation"
                    });
                    var fim = logManagement.Include(l => l.FIM);
                    var fimReport = fim.Select(c => new FIMReport
                    {
                        LogType = c.LogType.GetEnumDestription(),
                        EventName = c.EventName,
                        Requester = c.CreatedBy,
                        RequestedDate = c.CreatedOnUtc.Date,
                        ApprovedBy = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedBy : null,
                        ApprovedDate = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedOnUtc.Value.Date : null,
                        ActionOwner = c.ActionownerName,
                        ActionOwnerRemark = c.ActionOwnerRemarks,
                        Status = c.Status.GetEnumDestription(),
                        DateAlertGenerated = c.DateAlertGenerated.Value.Date,
                        ProposeEndDate = c.ProposeEndDate.Value.Date,
                        BusinessJustification = c.BusinessJustification,
                        InfoSecRemark = c.InfoSecRemarks,
                        UserApprovalObtain = c.UserApprovalObtained,
                        EventDescription = c.FIM.EventDescription,
                        ConfigurationObject = c.FIM.ConfigurationObject,
                        ConfigurationDetail = c.FIM.ConfigurationDetail,
                        SourceIPAddress = c.FIM.SourceIPAddress,
                        SourcePort = c.FIM.SourcePort,
                        SourceFQDN = c.FIM.SourceFQDN,
                        SourceHostName = c.FIM.SourceHostName,
                        SourceUserName = c.FIM.SourceUserName,
                        DestinationIpAddress = c.FIM.DestinationIpAddress,
                        DestinationPort = c.FIM.DestinationPort,
                        DestinationHostName = c.FIM.DestinationHostName,
                        DestinationFQDN = c.FIM.DestinationFQDN,
                        DestinationUserName = c.FIM.DestinationUserName,
                        NATIPAddress = c.FIM.NATIPAddress,
                        NATPort = c.FIM.NATPort,
                        MaliciousReputation = c.FIM.MaliciousReputation,
                        EventId = c.FIM.EventId,
                        SecurityTool = c.FIM.SecurityTool,
                        Observation = c.FIM.Observation
                    }).ToList();
                    excelByte = ReportDocument.GenerateExcelDocument(reportName, headers, fimReport);
                }

                else if(logDic[logType] == LogType.PAM) {

                    reportName = "PAMReport";
                    headers.AddRange(new List<string> {
                        "Incident Description", "Corrective Action Carriedout", "Date Carriedout"
                    });
                    //var heads = new List<string>
                    //{
                    //    "Log Type", "Event Name", "Requester", "Requested Date", "Approved By", "Approved Date", "Action Owner",
                    //"Action Owne rRemark", "Status", "Date Alert Generated", "Propose EndDate", "Business Justification", "InfoSec Remark",
                    //"User Approval Obtain", "Incident Description", "Corrective Action Carriedout", "Date Carriedout"
                    //};
                    var pam = logManagement.Include(l => l.PAM);
                    var pamReport = pam.Select(c => new PAMReport
                    {
                        LogType = c.LogType.GetEnumDestription(),
                        EventName = c.EventName,
                        Requester = c.CreatedBy,
                        RequestedDate = c.CreatedOnUtc,
                        ApprovedBy = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedBy : null,
                        ApprovedDate = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedOnUtc.Value.Date : null,
                        ActionOwner = c.ActionownerName,
                        ActionOwnerRemark = c.ActionOwnerRemarks,
                        Status = c.Status.GetEnumDestription(),
                        DateAlertGenerated = c.DateAlertGenerated,
                        ProposeEndDate = c.ProposeEndDate,
                        BusinessJustification = c.BusinessJustification,
                        InfoSecRemark = c.InfoSecRemarks,
                        UserApprovalObtain = c.UserApprovalObtained,
                        IncidentDescription = c.PAM.IncidentDescription,
                        CorrectiveActionCarriedOut = c.PAM.CorrectiveActionCarriedOut,
                        DatecarriedOut = c.PAM.DatecarriedOut
                    }).ToList();
                    excelByte = ReportDocument.GenerateExcelDocument(reportName, headers, pamReport);
                }

                else
                {
                    reportName = "SIEMReport";
                    headers.AddRange(new List<string> {
                        "Event Description", "Configuration Object", "Configuration Detail", "Source IP Address", "Source Port",
                        "Source FQDN", "Source HostName", "Source UserName", "Destination IP Address", "Destination Port", "Destination HostName",
                        "Destination FQDN", "Destination UserName", "NAT IP Address", "NAT Port", "Malicious Reputation", "Event Id", "Observation",
                        "SecurityTool"
                    });
                    var siem = logManagement.Include(l => l.SIEM);
                    var siemReport = siem.Select(c => new SIEMReport
                    {
                        LogType = c.LogType.GetEnumDestription(),
                        EventName = c.EventName,
                        Requester = c.CreatedBy,
                        RequestedDate = c.CreatedOnUtc.Date,
                        ApprovedBy = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedBy : null,
                        ApprovedDate = c.Status == LogMgtStatus.Closed || c.Status == LogMgtStatus.Rejected ? c.ModifiedOnUtc.Value.Date : null,
                        ActionOwner = c.ActionownerName,
                        ActionOwnerRemark = c.ActionOwnerRemarks,
                        Status = c.Status.GetEnumDestription(),
                        DateAlertGenerated = c.DateAlertGenerated.Value.Date,
                        ProposeEndDate = c.ProposeEndDate.Value.Date,
                        BusinessJustification = c.BusinessJustification,
                        InfoSecRemark = c.InfoSecRemarks,
                        UserApprovalObtain = c.UserApprovalObtained,
                        EventDescription = c.SIEM.EventDescription,
                        ConfigurationObject = c.SIEM.ConfigurationObject,
                        ConfigurationDetail = c.SIEM.ConfigurationDetail,
                        SourceIPAddress = c.SIEM.SourceIPAddress,
                        SourcePort = c.SIEM.SourcePort,
                        SourceFQDN = c.SIEM.SourceFQDN,
                        SourceHostName = c.SIEM.SourceHostName,
                        SourceUserName = c.SIEM.SourceUserName,
                        DestinationIpAddress = c.SIEM.DestinationIpAddress,
                        DestinationPort = c.SIEM.DestinationPort,
                        DestinationHostName = c.SIEM.DestinationHostName,
                        DestinationFQDN = c.SIEM.DestinationFQDN,
                        DestinationUserName = c.SIEM.DestinationUserName,
                        NATIPAddress = c.SIEM.NATIPAddress,
                        NATPort = c.SIEM.NATPort,
                        MaliciousReputation = c.SIEM.MaliciousReputation,
                        EventId = c.SIEM.EventId,
                        Observation = c.SIEM.Observation,
                        SecurityTool = c.SIEM.SecurityTool
                    }).ToList();
                    excelByte = ReportDocument.GenerateExcelDocument(reportName, headers, siemReport);
                }

                return TypedResults.File(excelByte, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{reportName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
            }

            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;

            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedTasks = Pagination<LogManagement>.Create(logManagement.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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

            var result = new LogReportResponse(
                PaginationMeta: paginationMeta,
                Response: new ISMSLog(
                    SIEMCount: siemCount, DAMCount: damCount, FIMCount: fimCount, CASPCount: caspCount, DLPCount: dlpCount,
                    EDRCount: edrCount, PAMCount: pamCount, TotalClosed: totalClosed, TotalOpen: totalOpened,
                    Reports: paginatedTasks.Select(p => new ISMSLogReportingResponse
                    {
                        LogType = p.LogType.GetEnumDestription(),
                        TimeStamp = p.CreatedOnUtc,
                        EventName = p.EventName,
                        Requester = p.CreatedBy,
                        RequestedDate = p.CreatedOnUtc.Date,
                        ApprovedBy = p.Status == LogMgtStatus.Closed || p.Status == LogMgtStatus.Rejected ? p.ModifiedBy : null,
                        ApprovedDate = p.Status == LogMgtStatus.Closed || p.Status == LogMgtStatus.Rejected ? p.ModifiedOnUtc.Value.Date : null,
                        ActionOwner = p.ActionownerName,
                        Status = p.Status.GetEnumDestription()
                    }).ToList()
                ));
            
            return TypedResults.Ok(result);
        }
    }
}
