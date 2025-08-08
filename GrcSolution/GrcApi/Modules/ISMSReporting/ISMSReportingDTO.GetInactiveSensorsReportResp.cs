using Arm.GrcApi.Modules.AntivirusAssessment;

namespace Arm.GrcApi.Modules.ISMSReporting
{
    public record GetInactiveSensorsReportResp(
        string? ComputerName,
        string? LastSeenOnCrowdStrike,
        string? MACAddress,
        string? SystemProductName,
        string? SystemVersion,
        string? LoggedOnUser,
        string? LastSeenOnManageEngine,
        string? Comment,
        string? ActionOwnerComment,
        string? Status,
        string? Supervisorstatus,       
        string? ActionOwner,
        string? Actionownerunit,
        string? ReasonForRejection,
        string? ApprovedBy,
        DateTime? DateApproved,
        string? InfosecFeedbackStatus,
        string? RequestBy,
        DateTime? RequestedDate
    );

    public record GetReducedFunctionalityModeReportResp(
       string? ComputerName,
       string? LastSeenOnCrowdStrike,
       string? MACAddress,
       string? SystemVersion,
       string? LoggedOnUser,
       string? LastSeenOnManageEngine,
       string? Comment,
       string? ActionOwnerComment,
       string? Status,
       string? Supervisorstatus,
       string? ActionOwner,
       string? Actionownerunit,
       string? ReasonForRejection,
       string? ApprovedBy,
       DateTime? DateApproved,
       string? InfosecFeedbackStatus,
       string? RequestBy,
       DateTime? RequestedDate
   );

    public record RiskAssessmentReportResponse(string Unit, int RiskCount);

    public class UnitRiskAssessment
    {
        public string Asset { get; set; }
        public string AssetDescription { get; set; }
        public DateTime? RiskAssessmentDate { get; set; }
        public string Category { get; set; }
        public string ActionOwner { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Status { get; set; }
    }
    public class UnitRiskAssessmentReportResponse
    {
        public string? Asset { get; set; }
        public string? AssetDescription { get; set; }
        public DateTime? RiskAssessmentDate { get; set; }
        public string? Category { get; set; }
        public string? ConfidentialityRating { get; set; }
        public string? IntegrityRating { get; set; }
        public string? AvailabilityRating { get; set; }
        public string? AssetValue { get; set; }
        public string? AssetScore { get; set; }
        public string? Vulnerability { get; set; }
        public string? VulnerabilityRating { get; set; }
        public string? Threats { get; set; }
        public string? ExistingPrimaryControl { get; set; }
        public string? ImpactRating { get; set; }
        public string? LikelihoodofThreatOccurring { get; set; }
        public string? RiskScore { get; set; }
        public string? RiskValue { get; set; }
        public string? RiskOptions { get; set; }
        public string? PlannedControl { get; set; }
        public string? ControlEffectiveness { get; set; }
        public string? ResidualRisk { get; set; }
        public string? RiskOwner { get; set; }
        public string? ActionOwner { get; set; }
        public string? AdditionalInformation { get; set; }
        public DateTime? ProposedClosureDate { get; set; }
        public string? RemediationStatus { get; set; }
        public string? RequestedBy { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}
