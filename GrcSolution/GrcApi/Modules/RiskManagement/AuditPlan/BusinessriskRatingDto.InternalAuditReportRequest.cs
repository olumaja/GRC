using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using System.Reflection;
using Arm.GrcApi.Modules.RiskManagement.BIA;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
   
    public class InternalAuditReportDto
    {       
        public Guid BusinessRiskRatingId { get; set; }
        public string? Unit { get; set; }
        public string? Team { get; set; }
        public string? Summary { get; set; }
        public string? Scope { get; set; }
        public string? ScopeLimitation { get; set; }
        public string? ExecutiveSummary { get; set; }
        public List<AuditFindingAudit> AuditFinding { get; set; }
        public string? GoodPractiseInclude { get; set; }
        public List<InternalAuditRating> InternalAuditRating { get; set; }
        public string? AdditionalDescription { get; set; }
        public string? OverAllManagementComment { get; set; }
        public string? SignedBy { get; set; }
        public string? DescriptionOfIssue { get; set; }
        public string? IssueRating { get; set; }
        public string? Observation { get; set; }
        public string? PotentialMaterialisedImpact { get; set; }
        public List<ManagementResponseAudit> ManagementResponse { get; set; }
        public string? AssessmentOfDigitalInitiative { get; set; }
        public string? OtherImprovementArea { get; set; }
        public List<ObservationListAudit> ObservationList { get; set; }
        public List<CitationAudit>? Citation { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
    }


    public class InternalAuditReportRequest
    {
        public Guid CommenceengagementId { get; set; }
        public string? Unit { get; set; } = null;
        public string? Team { get; set; } = null;
        public string? Summary { get; set; } = null;
        public string? Scope { get; set; } = null;
        public string? ScopeLimitation { get; set; } = null;
        public string? ExecutiveSummary { get; set; } = null;
        public List<DistributionList> Distributionlists { get; set; }
        public string? Comment { get; set; } = null;
        public List<AuditFindingAudit> AuditFinding { get; set; }
        public string? GoodPractiseInclude { get; set; } = null;
        public InternalAuditRating InternalAuditRating { get; set; }
        public string? DetailedFinding { get; set; } = null;
        public string? AdditionalDescription { get; set; } = null;
        public string? OverAllManagementComment { get; set; } = null;
        public string? SignedBy { get; set; } = null;
        public List<DetailsfindingsReq> DetailedFindings { get; set; }
        public List<ManagementResponseAudit> ManagementResponse { get; set; }
        public string? AssessmentOfDigitalInitiative { get; set; } = null;
        public List<ObservationListAudit> AssessmentOfDigitalInitiativeList { get; set; }
        public string? OtherImprovementArea { get; set; } = null;
        public List<ObservationListAudit> ObservationList { get; set; }
        public List<CitationAudit>? Citation { get; set; }
    }

    public class UpdateInternalAuditReportRequest
    {
        public Guid AuditReportId { get; set; }       
        public string? Summary { get; set; } = null;
        public string? Scope { get; set; } = null;
        public string? ScopeLimitation { get; set; } = null;
        public string? ExecutiveSummary { get; set; } = null;
        public string? Comment { get; set; } = null;
        public string? GoodPractiseInclude { get; set; } = null;
        public string? DetailedFinding { get; set; } = null;
        public string? AdditionalDescription { get; set; } = null;
        public string? OverAllManagementComment { get; set; } = null;
        public string? SignedBy { get; set; } = null;
        public string? OtherImprovementArea { get; set; } = null;
        public string? AssessmentOfDigitalInitiative { get; set; } = null;
        public List<DistributionList> Distributionlists { get; set; }
        public List<AuditFindingAudit> AuditFinding { get; set; }
        public InternalAuditRating InternalAuditRating { get; set; }
        public List<DetailsfindingsReq> DetailedFindings { get; set; }
        public List<ManagementResponseAudit> ManagementResponse { get; set; }       
        public List<ObservationListAudit> AssessmentOfDigitalInitiativeList { get; set; }
        public List<ObservationListAudit> ObservationList { get; set; }
        public List<CitationAudit>? Citation { get; set; }
    }

    public class CitationAudit
    {
        public string? Description { get; set; } = null;
        public string? Placement { get; set; } = null;
    }
    public class DetailsfindingsReq
    {
        public string? DescriptionOfIssue { get; set; } = null;
        public string? IssueRating { get; set; } = null;
        public string? Observation { get; set; } = null;
        public string? PotentialMaterialisedImpact { get; set; } = null;
        public string? Recommendation { get; set; } = null;
    }

  
    public class ObservationListAudit
    {
        public string? Observation { get; set; } = null;
        public string? Recommendation { get; set; } = null;
        public string? ActionOwner { get; set; } = null;
        public string? ManagementResponse { get; set; } = null;
        public string? Destination { get; set; } = null;
        public DateTime DueDate { get; set; } 
    }
    public class ObservationListAuditResp
    {
        public string? Recommendation { get; set; } = null;
        public string? ManagmentResponseAsAtTimeOfEngagement { get; set; } = null;
    }

    
    public class ManagementResponseAudit
    {
        public string? ActionPointToResolve { get; set; } = null;
        public string? ActionOwner { get; set; } = null;
        public string? Unit { get; set; } = null;
        public string? Designation { get; set; } = null;
        public DateTime DueDate { get; set; } 
    }

    public class ManagementResponseAuditDetail
    {
        public string? ActionOwner { get; set; } = null;
        public string? Unit { get; set; } = null;
        public string? Entity { get; set; } = null;
        public DateTime? ActionDueDate { get; set; }
        public string? ActionToResolve { get; set; }
        public string? Designation { get; set; }
    }
      
    public class InternalAuditRating
    {
        public string? AuditArea { get; set; } = null;
        public string? CurrentRating { get; set; } = null;
        public string? PreviousRating { get; set; } = null;
    }

      
    public class DistributionList
    {
        public string? Designation { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? ForAction { get; set; } = null;
        public string? ForDistribution { get; set; } = null;
    }

    public class AuditFindingAudit
    {
        public string? AuditFinding { get; set; } = null;
        public string? NameOrRecurring { get; set; } = null;
        public string? ControlType { get; set; } = null;
        public string? ControlDesignOrEffectively { get; set; } = null;
        public string? Rating { get; set; } = null;
    }
    public class AuditFindingAuditResp
    {
        public string? Level1 { get; set; } = null;       
    }



    public class InternalAuditReportResponse
    {
        public Guid CommenceEngagementId { get; set; }
        public Guid AuditReportId { get; set; }
        public string? Unit { get; set; }
        public string? Team { get; set; }
        public string? Summary { get; set; }
        public string? Scope { get; set; }
        public string? DetailedFinding { get; set; }
        public string? ScopeLimitation { get; set; }
        public string? ExecutiveSummary { get; set; }
        public List<AuditFindingAudit> AuditFinding { get; set; }
        public string? GoodPractiseInclude { get; set; }
        public InternalAuditRating InternalAuditRating { get; set; }
        public string? AdditionalDescription { get; set; }
        public string? OverAllManagementComment { get; set; }
        public string? SignedBy { get; set; }
        public string? DescriptionOfIssue { get; set; }
        public string? IssueRating { get; set; }
        public string? Observation { get; set; }
        public string? PotentialMaterialisedImpact { get; set; }
        public string? RootCause { get; set; }
        public string? Impact { get; set; }
        public string Recommendation { get; set; }
        public List<ManagementResponseAudit> ManagementResponse { get; set; }
        public string? AssessmentOfDigitalInitiative { get; set; }
        public List<ObservationListAudit> AssessmentOfDigitalInitiativeList { get; set; }
        public string? OtherImprovementArea { get; set; }
        public List<ObservationListAudit> ObservationList { get; set; }
        public List<CitationAudit>? Citation { get; set; }
        public List<DistributionList>? ReportDistributionList { get; set; }
        public List<DetailsfindingsReq>? DetailedFindings { get; set; }
        public string? Status { get; set; }
        public string? ReportComment { get; set; }
        public string? ReasonForRejection { get; set; }
    }

    public class UpdateInternalAuditReport
    {
        public Guid AuditReportId { get; set; }
        public string? Unit { get; set; } = null;
        public string? Team { get; set; } = null;
        public string? Summary { get; set; } = null;
        public string? Scope { get; set; } = null;
        public string? ScopeLimitation { get; set; } = null;
        public string? ExecutiveSummary { get; set; } = null;
        public string? DetailedFinding { get; set; } = null;
        public string? Impact { get; set; } = null;
        public string? RootCause { get; set; } = null;
        public string? GoodPractiseInclude { get; set; } = null;
        public string? AdditionalDescription { get; set; } = null;
        public string? OverAllManagementComment { get; set; } = null;
        public string? SignedBy { get; set; } = null;
        public string? DescriptionOfIssue { get; set; } = null;
        public string? IssueRating { get; set; } = null;
        public string? Observation { get; set; } = null;
        public string? PotentialMaterialisedImpact { get; set; } = null;
        public string? AssessmentOfDigitalInitiative { get; set; } = null;
        public string? OtherImprovementArea { get; set; } = null;
        public string? Comment { get; set; } = null;
        public string? Recommendation { get; set; } = null;
        public string? ReasonForRejection { get; set; } = null;
    }
}
