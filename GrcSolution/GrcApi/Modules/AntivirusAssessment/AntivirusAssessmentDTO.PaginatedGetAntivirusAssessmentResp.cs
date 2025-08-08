using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public record PaginatedGetAntivirusAssessmentResp(PaginationMeta PaginationMeta, List<GetAntivirusAssessmentResponse> Response);

    public class GetAntivirusAssessmentResponse
    {
        public Guid AntivirusAssessmentFileId { get; set; }
        public string Date { get; set; }
        public string? AssessmentType { get; set; }
        public string? AssessmentTitle { get; set; }
        public string? Initiator { get; set; }
        public string? ActionOwner { get; set; }
        public string? Status { get; set; }
    }

    public record InfosecGetAntivirusAssessmentByIdDetail(
      Guid AntivirusAssessmentFileId,
      string? DocumentTitle,
      List<InactiveSensorsGetByIdResp> InactiveSensors,
      List<ReducedFunctionalityModeGetByIdResp> ReducedFunctionalityMode);

    public class InactiveSensorsGetByIdResp
    {
        public Guid InactiveSensorsId { get; init; }
        public string? ComputerName { get; set; }
        public string? LastSeenOnCrowdStrike { get; set; }
        public string? MACAddress { get; set; }
        public string? SystemProductName { get; set; }
        public string? SystemVersion { get; set; }
        public string? LoggedOnUser { get; set; }
        public string? LastSeenOnManageEngine { get; set; }
    }
   
    public class ReducedFunctionalityModeGetByIdResp
    {
        public Guid ReducedFunctionalityModeId { get; init; } 
        public string? ComputerName { get; set; }
        public string? LastSeenOnCrowdStrike { get; set; }
        public string? MACAddress { get; set; }
        public string? SystemVersion { get; set; }
        public string? LoggedOnUser { get; set; }
        public string? LastSeenOnManageEngine { get; set; }
    }

    public record GetAntivirusAssessmentById(
     Guid AntivirusAssessmentFileId,
     string? AssessmentType,
     string? DocumentTitle,
     string? ActionOwner,
     string? ActionOwnerUnit,
     DateTime? ProposeEndDate,
     string? ApprovedBy,
     DateTime? DateApproved,
     List<InactiveSensorsByIdResp> InactiveSensors,
     List<ReducedFunctionalityModeByIdResp> ReducedFunctionalityMode);

    public class InactiveSensorsByIdResp
    {
        public Guid InactiveSensorsId { get; init; }
        public string? ComputerName { get; set; }
        public string? LastSeenOnCrowdStrike { get; set; }
        public string? MACAddress { get; set; }
        public string? SystemProductName { get; set; }
        public string? SystemVersion { get; set; }
        public string? LoggedOnUser { get; set; }
        public string? LastSeenOnManageEngine { get; set; }
        public string? InfosecComment { get; set; }
        public string? ActionOwnerComment { get; set; }
        public string? Status { get; set; } 
        public string? Action { get; set; }
        public List<GetAttachedReportResponse> Evidence { get; set; }

    }

    public class ReducedFunctionalityModeByIdResp
    {
        public Guid ReducedFunctionalityModeId { get; init; }
        public string? ComputerName { get; set; }
        public string? LastSeenOnCrowdStrike { get; set; }
        public string? MACAddress { get; set; }
        public string? SystemVersion { get; set; }
        public string? LoggedOnUser { get; set; }
        public string? LastSeenOnManageEngine { get; set; }
        public string? InfosecComment { get; set; }
        public string? ActionOwnerComment { get; set; }
        public string? Status { get; set; }
        public string? Action { get; set; }
        public List<GetAttachedReportResponse> Evidence { get; set; }
    }



}
