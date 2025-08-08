using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 04/24/2025
        * Development Group: GRCTools
        * Get logged mgt by Id Endpoint.
        */
    public class GetLoggedMgtByIdEndpoint
    {
        /// <summary>
        /// Get logged mgt by Id Endpoint.
        /// </summary>
        /// <param name="logmgtId"></param>
        /// <param name="repository"></param>
        /// <param name="siem"></param>
        /// <param name="pam"></param>
        /// <param name="fim"></param>
        /// <param name="edr"></param>
        /// <param name="dlp"></param>
        /// <param name="dam"></param>
        /// <param name="casp"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid logmgtId, IRepository<LogManagement> repository,
            IRepository<SIEMLog> siem, IRepository<PAMLog> pam, IRepository<FIMLog> fim, IRepository<EDRLog> edr,
           IRepository<DLPLog> dlp, IRepository<DAMLog> dam, IRepository<CASPLog> casp, IRepository<Document> docRepo, ICurrentUserService currentUserService
        )
        {
            var logMgt = repository.GetContextByConditon(r => r.Id == logmgtId).FirstOrDefault();
            if (logMgt is null)
                return TypedResults.NotFound("Log Mgt record not found");
            var attachments = await docRepo.GetContextByConditon(d => d.ModuleItemId == logMgt.Id && d.ModuleItemType == ModuleType.InformationSecurity)
                        .Select(d => new GetAttachedReportResponse
                        {
                            DocumentId = d.Id,
                            DateCreated = d.CreatedOnUtc,
                            DocumentName = d.Name
                        }).ToListAsync();
            if (logMgt.LogType == LogType.SIEM)
            {
                var getsiem = siem.GetContextByConditon(r => r.LogManagementId == logMgt.Id).FirstOrDefault();
                if (getsiem is null) { return TypedResults.NotFound($"Log type SIEM was not found"); }
                return TypedResults.Ok(new GetLogMgtSIEMById(
                  LogMgtId: logMgt.Id,
                  LogType: logMgt.LogType.ToString(),
                  TimeStamp: logMgt.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                  ProposeEndDate: logMgt.ProposeEndDate,
                  DateAlertGenerated: logMgt.DateAlertGenerated,
                  DateOfReport: logMgt.CreatedOnUtc,
                  EventName: logMgt.EventName,
                  EventDescription: getsiem.EventDescription,
                  ConfigurationObject: getsiem.ConfigurationObject,
                  ConfigurationDetail: getsiem.ConfigurationDetail,
                  SourceIPAddress: getsiem.SourceIPAddress,
                  SourcePort: getsiem.SourcePort,
                  SourceFQDN: getsiem.SourceFQDN,
                  SourceHostName: getsiem.SourceHostName,
                  SourceUserName: getsiem.SourceUserName,
                  DestinationIpAddress: getsiem.DestinationIpAddress,
                  DestinationPort: getsiem.DestinationPort,
                  DestinationHostName: getsiem.DestinationHostName,
                  DestinationFQDN: getsiem.DestinationFQDN,
                  DestinationUserName: getsiem.DestinationUserName,
                  NATIPAddress: getsiem.NATIPAddress,
                  NATPort: getsiem.NATPort,
                  MaliciousReputation: getsiem.MaliciousReputation,
                  EventId: getsiem.EventId,
                  SecurityTool: getsiem.SecurityTool,
                  ActionownerName: logMgt.ActionownerName,
                  RequesterName: logMgt.CreatedBy,
                  BusinessJustification: logMgt.BusinessJustification,
                  UserApprovalObtained: logMgt.UserApprovalObtained,
                  ActionOwnerRemarks: logMgt.ActionOwnerRemarks,
                  Recommendation: logMgt.InfoSecRemarks,
                  Observation: getsiem.Observation,
                  Remarks: logMgt.ReasonForRejection,
                  Status: logMgt.Status.ToString(),
                  ActionOwnerUnit: logMgt.ActionOwnerUnit,
                  InfosecReviewer: logMgt.ModifiedBy,
                  Attachments: attachments

                ));
            }
            if (logMgt.LogType == LogType.DAM)
            {
                var getdam = dam.GetContextByConditon(r => r.LogManagementId == logMgt.Id).FirstOrDefault();
                if (getdam is null) { return TypedResults.NotFound($"Log type DAM was not found"); }
                return TypedResults.Ok(new GetLogMgtDAMById(
                  LogMgtId: logMgt.Id,
                  LogType: logMgt.LogType.ToString(),
                  TimeStamp: logMgt.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                  DateAlertGenerated: logMgt.DateAlertGenerated,
                  DateOfReport: logMgt.CreatedOnUtc,
                  ProposeEndDate: logMgt.ProposeEndDate,
                  EventName: logMgt.EventName,
                  EventDescription: getdam.EventDescription,
                  ConfigurationObject: getdam.ConfigurationObject,
                  ConfigurationDetail: getdam.ConfigurationDetail,
                  SourceIPAddress: getdam.SourceIPAddress,
                  SourcePort: getdam.SourcePort,
                  SourceFQDN: getdam.SourceFQDN,
                  SourceHostName: getdam.SourceHostName,
                  SourceUserName: getdam.SourceUserName,
                  DestinationIpAddress: getdam.DestinationIpAddress,
                  DestinationPort: getdam.DestinationPort,
                  DestinationHostName: getdam.DestinationHostName,
                  DestinationFQDN: getdam.DestinationFQDN,
                  DestinationUserName: getdam.DestinationUserName,
                  NATIPAddress: getdam.NATIPAddress,
                  NATPort: getdam.NATPort,
                  EventId: getdam.EventId,
                  UserAuthorized: getdam.UserAuthorized,
                  Observation: getdam.Observation,
                  SecurityTool: getdam.SecurityTool,
                  ActionownerName: logMgt.ActionownerName,
                  RequesterName: logMgt.CreatedBy,
                  BusinessJustification: logMgt.BusinessJustification,
                  UserApprovalObtained: logMgt.UserApprovalObtained,
                  ActionOwnerRemarks: logMgt.ActionOwnerRemarks,
                  Recommendation: logMgt.InfoSecRemarks,
                  Remarks: logMgt.ReasonForRejection,
                  Status: logMgt.Status.ToString(),
                  ActionOwnerUnit: logMgt.ActionOwnerUnit,
                  InfosecReviewer: logMgt.ModifiedBy,
                  Attachments: attachments
                ));
            }
            if (logMgt.LogType == LogType.CASP)
            {
                var getcasp = casp.GetContextByConditon(r => r.LogManagementId == logMgt.Id).FirstOrDefault();
                if (getcasp is null) { return TypedResults.NotFound($"Log type CASP was not found"); }
                return TypedResults.Ok(new GetLogMgtCASPById(
                  LogMgtId: logMgt.Id,
                  LogType: logMgt.LogType.ToString(),
                  TimeStamp: logMgt.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                  DateAlertGenerated: logMgt.DateAlertGenerated,
                  DateOfReport: logMgt.CreatedOnUtc,
                  ProposeEndDate: logMgt.ProposeEndDate,
                  EventName: logMgt.EventName,
                  ResponsibleStaff: logMgt.CreatedBy,
                  SourceIPAddress: getcasp.SourceIPAddress,
                  SourceHostName: getcasp.SourceHostName,
                  SourceLocation: getcasp.SourceLocation,
                  SourceUserName: getcasp.SourceUserName,
                  DestinationEmailAddress: getcasp.DestinationEmailAddress,
                  SourceFileName: getcasp.SourceFileName,
                  SourceDevice: getcasp.SourceDevice,
                  ObjectIdentifier: getcasp.ObjectIdentifier,
                  Application: getcasp.Application,
                  Observation: getcasp.Observation,
                  SecurityTool: getcasp.SecurityTool,
                  ActionownerName: logMgt.ActionownerName,
                  BusinessJustification: logMgt.BusinessJustification,
                  UserApprovalObtained: logMgt.UserApprovalObtained,
                  ActionOwnerRemarks: logMgt.ActionOwnerRemarks,
                  Recommendation: logMgt.InfoSecRemarks,
                  Remarks: logMgt.ReasonForRejection,
                  Status: logMgt.Status.ToString(),
                  ActionOwnerUnit: logMgt.ActionOwnerUnit,
                  InfosecReviewer: logMgt.ModifiedBy,
                  Attachments: attachments
                ));

            }
            if (logMgt.LogType == LogType.EDR)
            {
                var getedr = edr.GetContextByConditon(r => r.LogManagementId == logMgt.Id).FirstOrDefault();
                if (getedr is null) { return TypedResults.NotFound($"Log type EDR was not found"); }
                return TypedResults.Ok(new GetLogMgtEDRById(
                  LogMgtId: logMgt.Id,
                  LogType: logMgt.LogType.ToString(),
                  TimeStamp: logMgt.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                  DateAlertGenerated: logMgt.DateAlertGenerated,
                  DateOfReport: logMgt.CreatedOnUtc,
                  RequesterName: logMgt.CreatedBy,
                  ProposeEndDate: logMgt.ProposeEndDate,
                  EventName: logMgt.EventName,
                  SourceIPAddress: getedr.SourceIPAddress,
                  Severity: getedr.Severity,
                  EventDescription: getedr.EventDescription,
                  CondigurationDetail: getedr.ConfigurationDetail,
                  DestinationFQDN: getedr.DestinationFQDN,
                  DestinationUserName: getedr.DestinationUserName,
                  DestinationIPAddress: getedr.DestinationIPAddress,
                  SourceOrFileName: getedr.SourceFileName,
                  EventId: getedr.EventId,
                  DestinationHostName: getedr.DestinationHostName,
                  ActionTakenByCS: getedr.ActionTakenByUs,
                  Technique: getedr.Technique,
                  FileHash: getedr.FileHash,
                  Observation: getedr.Observation,
                  SecurityTool: getedr.SecurityTool,
                  ActionownerName: logMgt.ActionownerName,
                  BusinessJustification: logMgt.BusinessJustification,
                  UserApprovalObtained: logMgt.UserApprovalObtained,
                  ActionOwnerRemarks: logMgt.ActionOwnerRemarks,
                  Recommendation: logMgt.InfoSecRemarks,
                  Remarks: logMgt.ReasonForRejection,
                  Status: logMgt.Status.ToString(),
                  ActionOwnerUnit: logMgt.ActionOwnerUnit,
                  InfosecReviewer: logMgt.ModifiedBy,
                  Attachments: attachments
                ));

            }
            if (logMgt.LogType == LogType.DLP)
            {
                var getdlp = dlp.GetContextByConditon(r => r.LogManagementId == logMgt.Id).FirstOrDefault();
                if (getdlp is null) { return TypedResults.NotFound($"Log type DLP was not found"); }
                return TypedResults.Ok(new GetLogMgtDLPById(
                  LogMgtId: logMgt.Id,
                  LogType: logMgt.LogType.ToString(),
                  TimeStamp: logMgt.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                  DateAlertGenerated: logMgt.DateAlertGenerated,
                  DateOfReport: logMgt.CreatedOnUtc,
                  ProposeEndDate: logMgt.ProposeEndDate,
                  ResponsibleStaff: logMgt.CreatedBy,
                  DLPPolicy: getdlp.DLPPolicy,
                  DLPRuleMatch: getdlp.DLPRuleMatch,
                  DLPRuleAction: getdlp.DLPRuleAction,
                  ActionTaken: getdlp.ActionTaken,
                  ActionownerName: logMgt.ActionownerName,
                  BusinessJustification: logMgt.BusinessJustification,
                  UserApprovalObtained: logMgt.UserApprovalObtained,
                  ActionOwnerRemarks: logMgt.ActionOwnerRemarks,
                  Recommendation: logMgt.InfoSecRemarks,
                  Remarks: logMgt.ReasonForRejection,
                  Status: logMgt.Status.ToString(),
                  ActionOwnerUnit: logMgt.ActionOwnerUnit,
                  InfosecReviewer: logMgt.ModifiedBy,
                  Attachments: attachments
                ));
            }
            if (logMgt.LogType == LogType.PAM)
            {
                var getpam = pam.GetContextByConditon(r => r.LogManagementId == logMgt.Id).FirstOrDefault();
                if (getpam is null) { return TypedResults.NotFound($"Log type PAM was not found"); }
                return TypedResults.Ok(new GetLogMgtPAMById(
                  LogMgtId: logMgt.Id,
                  LogType: logMgt.LogType.ToString(),
                  TimeStamp: logMgt.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                  DateAlertGenerated: logMgt.DateAlertGenerated,
                  DateOfReport: logMgt.CreatedOnUtc,
                  ProposeEndDate: logMgt.ProposeEndDate,
                  EventName: logMgt.EventName,
                  IncidentDescription: getpam.IncidentDescription,
                  CorrectiveActionCarriedOut: getpam.CorrectiveActionCarriedOut,
                  DatecarriedOut: getpam.DatecarriedOut,
                  ResponsibleStaff: logMgt.CreatedBy,
                  ActionownerName: logMgt.ActionownerName,
                  BusinessJustification: logMgt.BusinessJustification,
                  UserApprovalObtained: logMgt.UserApprovalObtained,
                  ActionOwnerRemarks: logMgt.ActionOwnerRemarks,
                  Recommendation: logMgt.InfoSecRemarks,
                  Remarks: logMgt.ReasonForRejection,
                  Status: logMgt.Status.ToString(),
                  ActionOwnerUnit: logMgt.ActionOwnerUnit,
                  InfosecReviewer: logMgt.ModifiedBy,
                  Attachments: attachments
                ));
            }
            if (logMgt.LogType == LogType.FIM)
            {
                var getfim = fim.GetContextByConditon(r => r.LogManagementId == logMgt.Id).FirstOrDefault();
                if (getfim is null) { return TypedResults.NotFound($"Log type FIM was not found"); }
                return TypedResults.Ok(new GetLogMgtFIMById(
                  LogMgtId: logMgt.Id,
                  LogType: logMgt.LogType.ToString(),
                  TimeStamp: logMgt.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                  DateAlertGenerated: logMgt.DateAlertGenerated,
                  DateOfReport: logMgt.CreatedOnUtc,
                  ProposeEndDate: logMgt.ProposeEndDate,
                  EventName: logMgt.EventName,
                  EventDescription: getfim.EventDescription,
                  ConfigurationObject: getfim.ConfigurationObject,
                  ConfigurationDetail: getfim.ConfigurationDetail,
                  DestinationUserName: getfim.DestinationUserName,
                  NATIPAddress: getfim.NATIPAddress,
                  NATPort: getfim.NATPort,
                  EventId: getfim.EventId,
                  Observation: getfim.Observation,
                  SecurityTool: getfim.SecurityTool,
                  MaliciousReputation: getfim.MaliciousReputation,
                  SourceIPAddress: getfim.SourceIPAddress,
                  SourcePort: getfim.SourcePort,
                  SourceFQDN: getfim.SourceFQDN,
                  SourceHostName: getfim.SourceHostName,
                  SourceUserName: getfim.SourceUserName,
                  DestinationIpAddress: getfim.DestinationIpAddress,
                  DestinationPort: getfim.DestinationPort,
                  DestinationHostName: getfim.DestinationHostName,
                  DestinationFQDN: getfim.DestinationFQDN,
                  ResponsibleStaff: logMgt.CreatedBy,
                  ActionownerName: logMgt.ActionownerName,
                  BusinessJustification: logMgt.BusinessJustification,
                  UserApprovalObtained: logMgt.UserApprovalObtained,
                  ActionOwnerRemarks: logMgt.ActionOwnerRemarks,
                  Recommendation: logMgt.InfoSecRemarks,
                  Remarks: logMgt.ReasonForRejection,
                  Status: logMgt.Status.ToString(),
                  ActionOwnerUnit: logMgt.ActionOwnerUnit,
                  InfosecReviewer: logMgt.ModifiedBy,
                  Attachments: attachments
                ));
            }
            return TypedResults.NotFound("Record not found");
        }
    }
}
