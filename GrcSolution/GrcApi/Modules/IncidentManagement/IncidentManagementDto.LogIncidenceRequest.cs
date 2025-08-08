using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.IncidentManagement
{  
    public record LogIncidenceRequest(
    string SecurityIncident,
    string[] SecurityArea,
    string Severity,
    string DescriptionOfIncident,
    string TypeOfAsset,
    string AssetDescription,
    DateTime DateOfIncidence,
    string DescriptionOfActionTaken,
    string RootCause,
    string[] Impact,
    string RecommendationToPreventFutureReoccurence,
    string LessonLearnt,
    string Status,
    DateTime DateOfClosure,
    string? Comment,
    string ReportingUnit
    );

    public class LogIncidenceRequestValidator : AbstractValidator<LogIncidenceRequest>
    {
        public LogIncidenceRequestValidator()
        {
            RuleFor(x => x.SecurityIncident).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Severity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.DescriptionOfIncident).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.TypeOfAsset).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.AssetDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.DescriptionOfActionTaken).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.RootCause).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.RecommendationToPreventFutureReoccurence).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.LessonLearnt).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.DateOfClosure).NotEmpty();
            RuleFor(x => x.DateOfIncidence).NotEmpty();           
            RuleFor(x => x.ReportingUnit).NotEmpty();           
        }
    }

    public record LogIncidence(
    string SecurityIncident,
    string SecurityArea,
    SeverityCategory Severity,
    string DescriptionOfIncident,
    string TypeOfAsset,
    string AssetDescription,
    DateTime DateOfIncidence,
    string DescriptionOfActionTaken,
    string RootCause,
    string Impact,
    string RecommendationToPreventFutureReoccurence,
    string LessonLearnt,
    ActionStatus Status,
    DateTime DateOfClosure,
    string? Comment,
    string ReportingUnit,
    string ReportingStaff,
    string ReportingStaffEmailAddress
    );

    public record LogIncidenceResponse(Guid IncidenceId);
    public record LogMgtResponse(Guid logMgtId);

    public record PaginatedGetLogIncidenceResp(PaginationMeta PaginationMeta, List<GetLogIncidenceResponse> Response);
   
    public class GetLogIncidenceResponse
    {        
        public Guid IncidenceId { get; set; }
        public string SecurityIncident { get; set; }
        public string SecurityAreas { get; set; }
        public string Severity { get; set; }
        public string DescriptionOfIncident { get; set; }
        public string TypeOfAsset { get; set; }
        public string ReportingUnit { get; set; }
        public string ReportingStaff { get; set; }
        public DateTime? DateOfReporting { get; set; }
        public DateTime? DateOfIncidence { get; set; }
        public DateTime? DateOfClosure { get; set; }
        public string Status { get; set; }
    }

    public record InfosecAssignLogIncidenceReq(
      Guid IncidenceId,
      string IncidentTag,
      string Recommendation,
      string Status,
      string? ActionOwnerName,
      string? ActionOwnerEmailAddress,
      string? ActionOwnerUnit
   );

    public class InfosecAssignLogIncidenceReqValidator : AbstractValidator<InfosecAssignLogIncidenceReq>
    {
        public InfosecAssignLogIncidenceReqValidator()
        {
            RuleFor(x => x.IncidenceId).NotEmpty();
            RuleFor(x => x.IncidentTag).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Recommendation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record GetLogIncidenceById(
      Guid IncidenceId,
      string SecurityIncident,
      string[] SecurityAreas,
      string Severity,
      string DescriptionOfIncident,
      string TypeOfAsset,
      string AssetDescription,
      DateTime? DateOfReporting,
      DateTime? DateOfIncidence,
      string DescriptionOfActionTaken,
      string RootCause,
      string[] Impact,
      string RecommendationToPreventFutureReoccurence,
      string LessonLearnt,
      string Status,
      DateTime? DateOfClosure,
      string? Comment,
      DateTime? ReportingStaffCommentDate,
      string ReportingStaff,
      string ReportingStaffEmailAddress,
      string ReportingStaffComment,
      string? ActionOwnerName,
      string? ActionOwnerComment,
      string? IncidentTag,
      string? ReportingUnit,
      string? InfoSecStaffName,
      string? InfoSecRecommendation,
      DateTime? InfoSecStaffCommentDate,
      DateTime? ActionOwnerCommentDate,
      string? ActionOwnerUnit
  );

    public record ActionownerResponseReq(
     Guid IncidenceId,
     string Status,
     string Comment     
     );

    public class ActionownerResponseReqValidator : AbstractValidator<ActionownerResponseReq>
    {
        public ActionownerResponseReqValidator()
        {
            RuleFor(x => x.IncidenceId).NotEmpty();
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Comment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record UpdateStatusToClosed(
    Guid IncidenceId   
    );

    public class UpdateStatusToClosedValidator : AbstractValidator<UpdateStatusToClosed>
    {
        public UpdateStatusToClosedValidator()
        {
            RuleFor(x => x.IncidenceId).NotEmpty();
        }
    }

    public record PaginatedGetLogMgtResp(PaginationMeta PaginationMeta, List<GetLogMgtResponse> Response);

    public class GetLogMgtResponse
    {
        public Guid LogMgtId { get; set; }
        public string LogType { get; set; }
        public string? Timestamp { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public string Actionowner { get; set; }       
        public string Status { get; set; }
    }

    public record ActionownerFeedbackReq(
    Guid LogMgtId,
    string BusinessJustification,
    string? UserApprovalObtained,
    string Remarks
    );  

    public class ActionownerFeedbackReqValidator : AbstractValidator<ActionownerFeedbackReq>
    {
        public ActionownerFeedbackReqValidator()
        {
            RuleFor(x => x.LogMgtId).NotEmpty();
            RuleFor(x => x.BusinessJustification).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Remarks).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record InfoSecResponseReq(
   Guid LogMgtId,
   string Status,
   string Remarks
   );

    public class InfoSecResponseReqValidator : AbstractValidator<InfoSecResponseReq>
    {
        public InfoSecResponseReqValidator()
        {
            RuleFor(x => x.LogMgtId).NotEmpty();
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Remarks).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record GetLogMgtSIEMById(
     Guid LogMgtId,
     string LogType,     
     string TimeStamp,     
     DateTime? DateAlertGenerated,
     DateTime? DateOfReport,
     DateTime? ProposeEndDate,
     string? EventName,
     string? EventDescription,
     string? ConfigurationObject,
     string? ConfigurationDetail,
     string? SourceIPAddress,
     string? SourcePort,
     string? SourceFQDN,
     string? SourceHostName,
     string? SourceUserName,
     string? DestinationIpAddress,
     string? DestinationPort,
     string? DestinationHostName,
     string? DestinationFQDN,
     string? DestinationUserName,
     string? NATIPAddress,
     string? NATPort,
     string? MaliciousReputation,
     string? EventId,
     string? SecurityTool,
     string? ActionownerName,
     string? RequesterName,
     string? BusinessJustification,
     string? UserApprovalObtained,
     string? ActionOwnerRemarks,
     string? Recommendation,
     string? Observation,
     string? Remarks,
     string? Status,
     string? ActionOwnerUnit,
     string? InfosecReviewer,
     List<GetAttachedReportResponse> Attachments
 );

    public record GetLogMgtDAMById(
     Guid LogMgtId,
     string LogType,
     string TimeStamp,
     DateTime? DateAlertGenerated,
     DateTime? DateOfReport,
     DateTime? ProposeEndDate,
     string? EventName,
     string? EventDescription,
     string? ConfigurationObject,
     string? ConfigurationDetail,
     string? SourceIPAddress,
     string? SourcePort,
     string? SourceFQDN,
     string? SourceHostName,
     string? SourceUserName,
     string? DestinationIpAddress,
     string? DestinationPort,
     string? DestinationHostName,
     string? DestinationFQDN,
     string? DestinationUserName,
     string? NATIPAddress,
     string? NATPort,
     string? EventId,
     string? UserAuthorized,
     string? Observation,     
     string? SecurityTool,     
     string? ActionownerName,
     string? RequesterName,
     string? BusinessJustification,
     string? UserApprovalObtained,
     string? ActionOwnerRemarks,
     string? Recommendation,
     string? Remarks,
     string? Status,
     string? ActionOwnerUnit,
     string? InfosecReviewer,
     List<GetAttachedReportResponse> Attachments
 );

    public record GetLogMgtCASPById(
    Guid LogMgtId,
    string LogType,
    string TimeStamp,
    DateTime? DateAlertGenerated,
    DateTime? DateOfReport,
    DateTime? ProposeEndDate,
    string? EventName,
    string? ResponsibleStaff,
    string? SourceIPAddress,
    string? SourceHostName,
    string? SourceLocation,
    string? SourceUserName,
    string? DestinationEmailAddress,
    string? SourceFileName,
    string? SourceDevice,
    string? ObjectIdentifier,
    string? Application,   
    string? Observation,
    string? SecurityTool,
    string? ActionownerName,
    string? BusinessJustification,
    string? UserApprovalObtained,
    string? ActionOwnerRemarks,
    string? Recommendation,
    string? Remarks,
    string? Status,
    string? ActionOwnerUnit,
    string? InfosecReviewer,
    List<GetAttachedReportResponse> Attachments
    );

    public record GetLogMgtEDRById(
       Guid LogMgtId,
       string LogType,
       string TimeStamp,
       DateTime? DateAlertGenerated,
       DateTime? DateOfReport,
       DateTime? ProposeEndDate,
       string? EventName,
       string? RequesterName,
       string? SourceIPAddress,
       string? Severity,
       string? EventDescription,
       string? CondigurationDetail,
       string? DestinationFQDN,
       string? DestinationUserName,
       string? DestinationIPAddress,
       string? DestinationHostName,
       string? SourceOrFileName,
       string? EventId,
       string? ActionTakenByCS,
       string? Technique,
       string? FileHash,      
       string? Observation,
       string? SecurityTool,
       string? ActionownerName,
       string? BusinessJustification,
       string? UserApprovalObtained,
       string? ActionOwnerRemarks,
       string? Recommendation,
       string? Remarks,
       string? Status,
       string? ActionOwnerUnit,
       string? InfosecReviewer,
       List<GetAttachedReportResponse> Attachments
   );

    public record GetLogMgtDLPById(
      Guid LogMgtId,
      string LogType,
      string TimeStamp,
      DateTime? DateAlertGenerated,
      DateTime? DateOfReport,
      DateTime? ProposeEndDate,
      string? ResponsibleStaff,
      string? DLPPolicy,
      string? DLPRuleMatch,
      string? DLPRuleAction,
      string? ActionTaken,   
      string? ActionownerName,
      string? BusinessJustification,
      string? UserApprovalObtained,
      string? ActionOwnerRemarks,
      string? Recommendation,
      string? Remarks,
      string? Status,
      string? ActionOwnerUnit,
      string? InfosecReviewer,
      List<GetAttachedReportResponse> Attachments
  );

    public record GetLogMgtPAMById(
     Guid LogMgtId,
     string LogType,
     string TimeStamp,
     DateTime? DateAlertGenerated,
     DateTime? DateOfReport,
     DateTime? ProposeEndDate,
     string? EventName,
     string? IncidentDescription,
     string? CorrectiveActionCarriedOut,
     DateTime? DatecarriedOut,
     string? ResponsibleStaff,
     string? ActionownerName,
     string? BusinessJustification,
     string? UserApprovalObtained,
     string? ActionOwnerRemarks,
     string? Recommendation,
     string? Remarks,
     string? Status,
     string? ActionOwnerUnit,
     string? InfosecReviewer,
     List<GetAttachedReportResponse> Attachments
 );

    public record GetLogMgtFIMById(
     Guid LogMgtId,
     string LogType,
     string TimeStamp,
     DateTime? DateAlertGenerated,
     DateTime? DateOfReport,
     DateTime? ProposeEndDate,
     string? EventName,
     string? EventDescription,
     string? ConfigurationObject,
     string? ConfigurationDetail,
     string? SourceIPAddress,
     string? SourcePort,
     string? SourceFQDN,
     string? SourceHostName,
     string? SourceUserName,
     string? DestinationIpAddress,
     string? DestinationPort,
     string? DestinationHostName,
     string? DestinationFQDN,
     string? DestinationUserName,
     string? NATIPAddress,
     string? NATPort,
     string? MaliciousReputation,
     string? EventId,
     string? SecurityTool,
     string? Observation,
     string? ResponsibleStaff,
     string? ActionownerName,
     string? BusinessJustification,
     string? UserApprovalObtained,
     string? ActionOwnerRemarks,
     string? Recommendation,
     string? Remarks,
     string? Status,
     string? ActionOwnerUnit,
     string? InfosecReviewer,
     List<GetAttachedReportResponse> Attachments
    );

    public class LogMgtReport
    {
        public string LogType { get; set; }
        public string Timestamp { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public string Status { get; set; }
    }

    public class LogManagementReport : LogMgtReport
    {
        public Guid Id { get; set; }
    }

    public class SIEMLogMgtReport
    {
        public DateTime? DateAlertGenerated { get; set; }
        public DateTime DateofReport { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? SourceIP { get; set; }
        public string? SourceHostname { get; set; }
        public string? SourceFQDN { get; set; }
        public string? SourceUsername { get; set; }
        public string? DestinationIP { get; set; }
        public string? DestinationPort { get; set; }
        public string? DestinationHostname { get; set; }
        public string? DestionFQDN { get; set; }
        public string? DestionUsername { get; set; }
        public string? EventId { get; set; }
        public string? Observation { get; set; }
        public string? Recommendation { get; set; }
        public string? SecurityTool { get; set; }
        public string? Requester { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? BusinessJustification { get; set; }
        public string? Status { get; set; }
    }

    public class PAMLogMgtReport
    {
        public DateTime? DateAlertGenerated { get; set; }
        public string? EventName { get; set; }
        public string? IncidentDescription { get; set; }
        public string? CorrectiveAction { get; set;}
        public string? Status { get; set; }
    }

    public class CASPLogMgtReport
    {
        public DateTime? DateAlertGenerated { get; set; }
        public DateTime DateofReport { get; set; }
        public string? EventName { get; set; }
        public string? ResponsibleStaff { get; set; }
        public string? SourceIP { get; set; }
        public string? SourceHostname { get; set; }
        public string? SourceUsername { get; set; }
        public string? SecurityTool { get; set; }
        public string? DestinationEmail { get; set; }
        public string? Application { get; set; }
        public string? Observation { get; set; }
        public string? Recommendation { get; set; }
        public string? TreatedBy { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? BusinessJustification { get; set; }
        public string? Status { get; set; }
    }

    public class DAMLogMgtReport
    {
        public DateTime? DateAlertGenerated { get; set; }
        public DateTime DateofReport { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }
        public string? SourceHostname { get; set; }
        public string? SourceUsername { get; set; }
        public string? Observation { get; set; }
        public string? Recommendation { get; set; }
        public string? SecurityTool { get; set; }
        public string? Requester { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? BusinessJustification { get; set; }
        public string? Status { get; set; }
    }

    public class DLPLogMgtReport
    {
        public DateTime? DateAlertGenerated { get; set; }
        public string? DLPPolicy { get; set; }
        public string? DLPRuleMatch { get; set; }
        public string? DLPRuleAction { get; set; }
        public string? ActionTaken { get; set; }
        public string? ResponsibleStaff { get; set; }
        public string? TreatedBy { get; set; }
        public DateTime? DateClosed { get; set; }
        public string? Status { get; set; }
    }

    public class EDRLogMgtReport
    {
        public DateTime? DateAlertGenerated { get; set; }
        public DateTime DateofReport { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? SourceIP { get; set; }
        public string? DestinationHostname { get; set; }
        public string? DestionUsername { get; set; }
        public string? Observation { get; set; }
        public string? Recommendation { get; set; }
        public string? SecurityTool { get; set; }
        public string? Requester { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? Status { get; set; }
    }

    public class FIMLogMgtReport
    {
        public DateTime? DateAlertGenerated { get; set; }
        public DateTime DateofReport { get; set; }
        public string? EventName { get; set; }
        public string? Description { get; set; }
        public string? SourceIP { get; set; }
        public string? SourceHostname { get; set; }
        public string? SourceFQDN { get; set; }
        public string? SourceUsername { get; set; }
        public string? DestinationIP { get; set; }
        public string? DestinationPort { get; set; }
        public string? DestinationHostname { get; set; }
        public string? DestionationFQDN { get; set; }
        public string? DestionUsername { get; set; }
        public string? EventId { get; set; }
        public string? Observation { get; set; }
        public string? Recommendation { get; set; }
        public string? SecurityTool { get; set; }
        public string? Requester { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? BusinessJustification { get; set; }
        public string? Status { get; set; }
    }
    public record LogMgtReportRespose(
        int TotalRecords,
        int TotalClosedRecords,
        int TotalRejectRecords,
        int TotalProgressRecords,
        PaginationMeta PaginationMeta,
        List<LogManagementReport> Reports
    );


}
