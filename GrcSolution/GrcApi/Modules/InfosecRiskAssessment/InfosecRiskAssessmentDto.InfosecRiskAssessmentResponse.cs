using Arm.GrcTool.Domain;
using DocumentFormat.OpenXml.Office2010.Excel;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class InfosecRiskAssessmentResponse
    {
        public Guid Id { get; set; }
        public DateTime DateIndentified { get; set; }
        public string Category { get; set; }
        public string Asset { get; set; }
        public string DescriptionOfAsset { get; set; }
        public string Status { get; set; }
    }

    public record PaginatedInfosecRiskAssessmentResponse(PaginationMeta PaginationMeta, List<InfosecRiskAssessmentResponse> Response);

    public class GetUnitTitleResponse
    {
        public Guid Id { get; set; }
        public DateTime DateIdentify { get; set; }
        public string? Unit { get; set; }
        public string? Category { get; set; }
        public string? Asset { get; set; }
        public string? DescriptionOfAsset { get; set; }
        public string? Status { get; set; }
    }

    public record PaginatedGetUnitTitleResponse(PaginationMeta PaginationMeta, List<GetUnitTitleResponse> Response);

    public record GetUnitTitleReports(
       string? Unit,
       string? Objective,
       string? Asset,
       string? AssetDescription,
       DateTime? RiskAssessmentDate,
       string? Category,
       string? ConfidentialityRating,
       string? IntegrityRating,
       string? AvailabilityRating,
       string AssetValue,
       string? AssetScore,
       string? Vulnerability,
       string? VulnerabilityRating,
       string? Threat,
       string? ImpactRating,
       string? LikehoodOfThreatOccuring,
       string RiskScore,
       string RiskValue,
       string? RiskOption,
       string? ControlEffective,
       string ResidualRisk,
       string? RiskOwner,
       string? ActionOwner,
       string? ReasonForRejection,
       string? ApprovedBy,
       DateTime? DateApproved,
       string? AdditionalInformation,
       DateTime? ProposedClosureDate,
       string? RemediationStatus,
       string? Status,
       DateTime? DateLogged
   );

}
