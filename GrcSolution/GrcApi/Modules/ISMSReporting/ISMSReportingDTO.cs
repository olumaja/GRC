using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.ISMSReporting
{
    public class ISMSLogReportingResponse
    {
        public string LogType { get; set; }
        public DateTime TimeStamp { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ActionOwner { get; set; }
        public string Status { get; set; }
    }

    public record ISMSLog(
        int SIEMCount, int DAMCount, int FIMCount, int CASPCount, int DLPCount,
        int EDRCount, int PAMCount, int TotalClosed, int TotalOpen, List<ISMSLogReportingResponse> Reports
    );
    
    public record LogReportResponse(PaginationMeta PaginationMeta, ISMSLog Response);

    public class CASPReport
    {
        public string LogType { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ActionOwner { get; set; }
        public string Status { get; set; }
        public DateTime DateAlertGenerated { get; set; }
        public DateTime ProposeEndDate { get; set; }
        public string? BusinessJustification { get; set; }
        public string? InfoSecRemark { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? UserApprovalObtain { get; set; }
        public string? ResponsibleStaff { get; set; }
        public string? SourceIPAddress { get; set; }
        public string? SourceHostName { get; set; }
        public string? SourceLocation { get; set; }
        public string? SourceUserName { get; set; }
        public string? SourceFileName { get; set; }
        public string? SourceDevice { get; set; }
        public string? DestinationEmail { get; set; }
        public string? ObjectIdentifier { get; set; }
        public string? SecurityTool { get; set; }
        public string? Observation { get; set; }
        public string? Application { get; set; }
    }

    public class DAMReport {
        public string LogType { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ActionOwner { get; set; }
        public string Status { get; set; }
        public DateTime DateAlertGenerated { get; set; }
        public DateTime ProposeEndDate { get; set; }
        public string? BusinessJustification { get; set; }
        public string? InfoSecRemark { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? UserApprovalObtain { get; set; }
        public string? EventDescription { get; set; }
        public string? ConfigurationObject { get; set; }
        public string? ConfigurationDetail { get; set; }
        public string? SourceIPAddress { get; set; }
        public string? SourcePort { get; set; }
        public string? SourceFQDN { get; set; }
        public string? SourceHostName { get; set; }
        public string? SourceUserName { get; set; }
        public string? DestinationIPAddress { get; set; }
        public string? DestinationPort { get; set; }
        public string? DestinationHostName { get; set; }
        public string? DestinationFQDN { get; set; }
        public string? DestinationUserName { get; set; }
        public string? NATIPAddress { get; set; }
        public string? NATPort { get; set; }
        public string? MaliciousReputation { get; set; }
        public string? EventId { get; set; }
        public string? UserAuthorized { get; set; }
        public string? Observation { get; set; }
        public string? SecurityTool { get; set; }
    }

    public class DLPReport
    {
        public string LogType { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ActionOwner { get; set; }
        public string Status { get; set; }
        public DateTime DateAlertGenerated { get; set; }
        public DateTime ProposeEndDate { get; set; }
        public string? BusinessJustification { get; set; }
        public string? InfoSecRemark { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? UserApprovalObtain { get; set; }
        public string? DLPPolicy { get; set; }
        public string? DLPRuleMatch { get; set; }
        public string? DLPRuleAction { get; set; }
        public string? ActionTaken { get; set; }
        public string? ResponsibleStaff { get; set; }
    }

    public class EDRReport {
        public string LogType { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ActionOwner { get; set; }
        public string Status { get; set; }
        public DateTime DateAlertGenerated { get; set; }
        public DateTime ProposeEndDate { get; set; }
        public string? BusinessJustification { get; set; }
        public string? InfoSecRemark { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? UserApprovalObtain { get; set; }
        public string? EventDescription { get; set; }
        public string? ConfigurationDetail { get; set; }
        public string? SourceIPAddress { get; set; }
        public string? SourceFQDN { get; set; }
        public string? SourceFileName { get; set; }
        public string? Severity { get; set; }
        public string? DestinationFQDN { get; set; }
        public string? DestinationUserName { get; set; }
        public string? DestinationIPAddress { get; set; }
        public string? DestinationHostName { get; set; }
        public string? EventId { get; set; }
        public string? SecurityTool { get; set; }
        public string? ActionTakenByUs { get; set; }
        public string? Technique { get; set; }
        public string? FileHash { get; set; }
        public string? Observation { get; set; }
    }

    public class FIMReport
    {
        public string LogType { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ActionOwner { get; set; }
        public string Status { get; set; }
        public DateTime DateAlertGenerated { get; set; }
        public DateTime ProposeEndDate { get; set; }
        public string? BusinessJustification { get; set; }
        public string? InfoSecRemark { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? UserApprovalObtain { get; set; }
        public string? EventDescription { get; set; }
        public string? ConfigurationObject { get; set; }
        public string? ConfigurationDetail { get; set; }
        public string? SourceIPAddress { get; set; }
        public string? SourcePort { get; set; }
        public string? SourceFQDN { get; set; }
        public string? SourceHostName { get; set; }
        public string? SourceUserName { get; set; }
        public string? DestinationIpAddress { get; set; }
        public string? DestinationPort { get; set; }
        public string? DestinationHostName { get; set; }
        public string? DestinationFQDN { get; set; }
        public string? DestinationUserName { get; set; }
        public string? NATIPAddress { get; set; }
        public string? NATPort { get; set; }
        public string? MaliciousReputation { get; set; }
        public string? EventId { get; set; }
        public string? SecurityTool { get; set; }
        public string? Observation { get; set; }
    }

    public class PAMReport {
        public string LogType { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ActionOwner { get; set; }
        public string Status { get; set; }
        public DateTime? DateAlertGenerated { get; set; }
        public DateTime? ProposeEndDate { get; set; }
        public string? BusinessJustification { get; set; }
        public string? InfoSecRemark { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? UserApprovalObtain { get; set; }
        public string? IncidentDescription { get; set; }
        public string? CorrectiveActionCarriedOut { get; set; }
        public DateTime? DatecarriedOut { get; set; }
    }

    public class SIEMReport
    {
        public string LogType { get; set; }
        public string EventName { get; set; }
        public string Requester { get; set; }
        public DateTime RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ActionOwner { get; set; }
        public string Status { get; set; }
        public DateTime DateAlertGenerated { get; set; }
        public DateTime ProposeEndDate { get; set; }
        public string? BusinessJustification { get; set; }
        public string? InfoSecRemark { get; set; }
        public string? ActionOwnerRemark { get; set; }
        public string? UserApprovalObtain { get; set; }
        public string? EventDescription { get; set; }
        public string? ConfigurationObject { get; set; }
        public string? ConfigurationDetail { get; set; }
        public string? SourceIPAddress { get; set; }
        public string? SourcePort { get; set; }
        public string? SourceFQDN { get; set; }
        public string? SourceHostName { get; set; }
        public string? SourceUserName { get; set; }
        public string? DestinationIpAddress { get; set; }
        public string? DestinationPort { get; set; }
        public string? DestinationHostName { get; set; }
        public string? DestinationFQDN { get; set; }
        public string? DestinationUserName { get; set; }
        public string? NATIPAddress { get; set; }
        public string? NATPort { get; set; }
        public string? MaliciousReputation { get; set; }
        public string? EventId { get; set; }
        public string? Observation { get; set; }
        public string? SecurityTool { get; set; }
    }
}
