using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.RiskManagement.AuditPlan;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class AuditPlanningMemoAuditExecutionReq
    {
        [Required]
        public string? Team { get; set; }
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        [Required]
        public string BusinessDescription { get; set; }
        [Required]
        public string StrategicObjective { get; set; }
        [Required]
        public string ImplementationPlan { get; set; }
        [Required]
        public string RiskIdentified { get; set; }
        [Required]
        public string ScopeAndControlTesting { get; set; }
        [Required]
        public string PriorAuditObservation { get; set; }
        public string? SystemOverview { get; set; }
        public string? Policies { get; set; }
        public string? RegulatoryConsideration { get; set; }
        public List<PlanningTimeline> PlanningTimeline { get; set; }
    }

    public class UpdateAuditPlanningMemoAuditExecutionReq
    {
        public Guid CommenceEngagementId { get; set; }
        public string BusinessDescription { get; set; }
        public string StrategicObjective { get; set; }
        public string ImplementationPlan { get; set; }
        public string RiskIdentified { get; set; }
        public string ScopeAndControlTesting { get; set; }
        public string PriorAuditObservation { get; set; }
        public string? SystemOverview { get; set; }
        public string? Policies { get; set; }
        public string? RegulatoryConsideration { get; set; }
        public List<PlanningTimeline> PlanningTimeline { get; set; }
    }

    public class UpdateAuditPlanningMemoAuditExecutionReqValidation : AbstractValidator<UpdateAuditPlanningMemoAuditExecutionReq>
    {
        public UpdateAuditPlanningMemoAuditExecutionReqValidation()
        {
            RuleFor(x => x.CommenceEngagementId).NotEmpty();
        }
    }


    public class PlanningTimeline
    {
        public string? Tasks { get; set; } = null;
        public DateTime? PlannedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? Responsibility { get; set; } = string.Empty;
       
    }

    public class AuditPlanningMemoAuditExecutionReqValidation : AbstractValidator<AuditPlanningMemoAuditExecutionReq>
    {
        public AuditPlanningMemoAuditExecutionReqValidation()
        {
            RuleFor(x => x.AnualAuditUniverseRiskRatingId).NotEmpty();
            RuleFor(x => x.BusinessDescription).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.StrategicObjective).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.ImplementationPlan).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.RiskIdentified).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.ScopeAndControlTesting).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.PriorAuditObservation).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class TeamCompletedEngagementResp
    {
        public Guid CommenceEngagementId { get; set; }
        public string? Unit { get; set; }
        public string? Team { get; set; }
        public Guid AuditReportId { get; set; }
       
    }
    public class TeamCompletedEngagementByIdResp
    {
        public Guid CommenceEngagementId { get; set; }
        public string? Unit { get; set; }
        public string? Team { get; set; }
        public string? DetailedFinding { get; set; }
        public string? IssueRating { get; set; }
        public string? PotentialMaterialisedImpact { get; set; }
        public List<DetailFindingList> FindingDetail { get; set; }       
        public string? InternalAuditRating { get; set; }
        public string? EngagementStatus { get; set; }
        public string? WorkPaperStatus { get; set; }
        public string? FindingStatus { get; set; }
        public string? ReportComment { get; set; }
        //public List<DetailsfindingsReq> DetailedFindings { get; set; }

    }
    public class GetRecommendation
    {
        public string? Observation { get; set; }
        public string? ActionOwner { get; set; }
        public string? ManagementResponse { get; set; }
        public string? Destination { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class GetReportDetailfindingList
    {
        public string? DescriptionOfFinding { get; set; }
        public string? ImpactRating { get; set; }
        public string? DetailedFindings { get; set; }
        public string? PotentialMaterialisedImpact { get; set; }
        public string? Recommendation { get; set; }
    }
    public class ReportDetailfindingListResp
    {
        public string? DescriptionOfIssue { get; set; }
        public string? ImpactRating { get; set; }
        public string? DetailedFindings { get; set; }
        public string? Recommendation { get; set; }
    }
    
    public class GetManagemetRespList
    {
        public string? ActionPointToResolve { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; }
        public string? Designation { get; set; }       
        public DateTime? DueDate { get; set; }       
    }
    public class DetailFindingList
    {
        public string? ImpactRating { get; set; }
        public string? Observation { get; set; }
        public string? RootCause { get; set; }
        public string? Recommendation { get; set; }
        public string IssueRating { get; set; }
        public string? ActionToResolve { get; set; }
        public string? ActionOwner { get; set; }
        public string? ActionOwnerUnit { get; set; }
        public string? Designation { get; set; }
        public DateTime ActionDueDate { get; set; }
    }
    public class CAFDetailFindingList
    {       
        public string? Recommendation { get; set; }      
    }
    public class ManagementResponseResp
    {
        public string? ActionToResolve { get; set; }
        public string? ActionOwner { get; set; }
        public string? ActionOwnerUnit { get; set; }
        public DateTime ActionDueDate { get; set; }
    }

    public class GetTeamCompletedEngagementResp
    {
        public TeamCompletedEngagementResp UnitDetail {  get; set; }             
    }
    public class GetTeamCompletedEngagementByIdResp
    {
        public TeamCompletedEngagementByIdResp UnitDetail { get; set; }
    }
   
    public class GetAuditPlanningMemoAuditExecutionResp
    {
        public Guid CommenceEngagementId { get; set; }
        public string Team { get; set; }
        public Guid AuditPlanningMemoId { get; set; }
        public string Status { get; set; }

        public string BusinessDescription { get; set; }

        public string StrategicObjective { get; set; }

        public string ImplementationPlan { get; set; }

        public string RiskIdentified { get; set; }
        public string? RegulatoryConsideration { get; set; }

        public string ScopeAndControlTesting { get; set; }

        public string PriorAuditObservation { get; set; }
        public List<PlanningTimeline> PlanningTimeline { get; set; }
        public string? ReasonForRejection { get; set; }
    }

    public class InformationRequirementRequest
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        [Required]
        public string? Team { get; set; }
        public List<InformationRequirementReq> InformationRequirement { get; set; }
    }
    public class UpdateInformationRequirementRequest
    {
        public Guid CommenceEngagementId { get; set; }
        public List<InformationRequirementReq> InformationRequirement { get; set; }
    }
    public class InformationRequirementReq
    {
        public string? InformationRequest { get; set; }
        public string? ResponsibleOfficer { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? DateProvided { get; set; } 
    }
    public class UpdateInformationRequirementRequestValidation : AbstractValidator<UpdateInformationRequirementRequest>
    {
        public UpdateInformationRequirementRequestValidation()
        {
            RuleFor(x => x.CommenceEngagementId).NotEmpty();
            RuleFor(x => x.InformationRequirement).NotEmpty();
            RuleForEach(u => u.InformationRequirement).SetValidator(new InformationRequirementReqValidation());
        }
    }

    public class InformationRequirementRequestValidation : AbstractValidator<InformationRequirementRequest>
    {
        public InformationRequirementRequestValidation()
        {
            RuleFor(x => x.AnualAuditUniverseRiskRatingId).NotEmpty();
            RuleFor(x => x.InformationRequirement).NotEmpty();
            RuleForEach(u => u.InformationRequirement).SetValidator(new InformationRequirementReqValidation());
        }
    }

    public class InformationRequirementReqValidation : AbstractValidator<InformationRequirementReq>
    {
        public InformationRequirementReqValidation()
        {
            RuleFor(x => x.InformationRequest).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.ResponsibleOfficer).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.RequestDate).NotEmpty();
        }
    }

    public class GetInformationRequirementDetails
    {
        public List<GetInformationRequirementResp> InformationRequirement { get; set; }
    }
    public class GetInformationRequirementResp
    {
        public Guid CommenceEngagementId { get; set; }
        public Guid InformationRequirementId { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string? InformationRequest { get; set; }
        public string? ResponsibleOfficer { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? DateProvided { get; set; }
        public string? ReasonForRejection { get; set; }
    }

    public class UpdateEngagementLetterAuditExecutionReq
    {       
        public Guid CommenceEngagementId { get; set; }
        public string? AuditTitle { get; set; }
        public string? AuditType { get; set; }
        public string? BusinessUnit { get; set; }
        public string? IssueBy { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? ResponsibleExecutive { get; set; }
        public string? BusinessOwner { get; set; }
        public string? BriefBackgroundObjective { get; set; }
        public string? KeyRisk { get; set; }
        public string? Mandate { get; set; }
        public string? ResponsibilityOfInternalAudit { get; set; }
        public string? AuditObjective { get; set; }
        public string? AuditScope { get; set; }
        public string? ScopeLimitation { get; set; }
        public string? Comment { get; set; }
        public string? CommunicationProtocol { get; set; }
        public List<EngagementLetterAuditExecutionDurationReq> EngagementLetterAuditExecutionDuration { get; set; }
        public List<EngagementLetterReportDistributionListReq> EngagementLetterReportDistributionList { get; set; }
    }

    public class UpdateEngagementLetterAuditExecutionReqValidation : AbstractValidator<UpdateEngagementLetterAuditExecutionReq>
    {
        public UpdateEngagementLetterAuditExecutionReqValidation()
        {
            RuleFor(x => x.CommenceEngagementId).NotNull();               
        }
    }

    public class EngagementLetterAuditExecutionReq
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        [Required]
        public string? Team { get; set; }
        [Required]
        public string? AuditTitle { get; set; }
        [Required]
        public string? AuditType { get; set; }
        public string? BusinessUnit { get; set; }
        public string? IssueBy { get; set; }
        public DateTime Date { get; set; }
        public string? ResponsibleExecutive { get; set; }
        public string? BusinessOwner { get; set; }
        public string? BriefBackgroundObjective { get; set; }
        public string? KeyRisk { get; set; }
        public string? Mandate { get; set; }
        public string? ResponsibilityOfInternalAudit { get; set; }
        public string? AuditObjective { get; set; }
        public string? AuditScope { get; set; }
        public string? ScopeLimitation { get; set; }
        public string? Comment { get; set; }
        public string? CommunicationProtocol { get; set; }        
        public List<EngagementLetterAuditExecutionDurationReq> EngagementLetterAuditExecutionDuration { get; set; }
        public List<EngagementLetterReportDistributionListReq> EngagementLetterReportDistributionList { get; set; }
    }
    public class EngagementLetterReportDistributionListReq
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? BusinessUnit { get; set; }       
    }
    public class EngagementLetterAuditExecutionDurationReq
    {
        [Required]
        public string? Action { get; set; }  
        [Required]
        public string? Timing { get; set; } 
    }

    public class EngagementLetterReportDistributionListReqValidation : AbstractValidator<EngagementLetterReportDistributionListReq>
    {
        public EngagementLetterReportDistributionListReqValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.Title).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.BusinessUnit).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class EngagementLetterAuditExecutionDurationReqValidatio : AbstractValidator<EngagementLetterAuditExecutionDurationReq>
    {
        public EngagementLetterAuditExecutionDurationReqValidatio()
        {
            RuleFor(x => x.Action).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.Timing).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class EngagementLetterAuditExecutionReqValidation : AbstractValidator<EngagementLetterAuditExecutionReq>
    {
        public EngagementLetterAuditExecutionReqValidation()
        {
            RuleFor(c => c.AnualAuditUniverseRiskRatingId).NotEmpty();
            RuleFor(x => x.AuditTitle).NotEmpty()                
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.AuditType).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.BusinessUnit).NotEmpty()
                .WithMessage("{PropertyName }must not be empty or null");
            RuleFor(x => x.IssueBy).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(c => c.Date).NotEmpty();
            RuleFor(x => x.ResponsibleExecutive).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.BusinessOwner).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.BriefBackgroundObjective).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.KeyRisk).NotEmpty()
                .WithMessage("{PropertyName}must not be empty or null");
            RuleFor(x => x.Mandate).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.ResponsibilityOfInternalAudit).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.AuditObjective).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.AuditScope).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.ScopeLimitation).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.CommunicationProtocol).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            RuleFor(x => x.Comment).NotEmpty()
                .WithMessage("{PropertyName} must not be empty or null");
            //RuleFor(x => x.AuditTitle).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.AuditType).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.BusinessUnit).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.IssueBy).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(c => c.Date).NotEmpty();
            //RuleFor(x => x.ResponsibleExecutive).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.BusinessOwner).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.BriefBackgroundObjective).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.KeyRisk).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.Mandate).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.ResponsibilityOfInternalAudit).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.AuditObjective).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.AuditScope).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.ScopeLimitation).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.CommunicationProtocol).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(x => x.Comment).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.EngagementLetterAuditExecutionDuration).NotEmpty();
            RuleForEach(x => x.EngagementLetterAuditExecutionDuration).SetValidator(new EngagementLetterAuditExecutionDurationReqValidatio());
            RuleFor(x => x.EngagementLetterReportDistributionList).NotEmpty();
            RuleForEach(x => x.EngagementLetterReportDistributionList).SetValidator(new EngagementLetterReportDistributionListReqValidation());

        }
    }

    public class GetEngagementLetterAuditExecutionResp
    {
        public Guid CommenceEngagementId { get; set; }
        public Guid EngagementLetterId { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }

        public string? AuditTitle { get; set; }

        public string? AuditType { get; set; }

        public string? BusinessUnit { get; set; }

        public string? IssueBy { get; set; }
        public DateTime Date { get; set; }

        public string? ResponsibleExecutive { get; set; }

        public string? BusinessOwner { get; set; }

        public string? BriefBackgroundObjective { get; set; }

        public string? KeyRisk { get; set; }

        public string? Mandate { get; set; }

        public string? ResponsibilityOfInternalAudit { get; set; }

        public string? AuditObjective { get; set; }

        public string? AuditScope { get; set; }

        public string? ScopeLimitation { get; set; }

        public string? Comment { get; set; }
        public string? CommunicationProtocol { get; set; }
        public List<EngagementLetterAuditExecutionDurationReq> EngagementLetterAuditExecutionDuration { get; set; }
        public List<EngagementLetterReportDistributionListReq> EngagementLetterReportDistributionList { get; set; }
        public string? ReasonForRejection { get; set; }
    }
    public class GetAuditAnnouncementMemoAuditExecutionResp
    {
        public Guid CommenceEngagementId { get; set; }
        public Guid AuditAnnouncementMemoId { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string Salutation { get; set; }
        public string AuditScoped { get; set; }
        public string WorkApproach { get; set; }
        public string Role { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public DateTime? PreviousFrom { get; set; }
        public DateTime? PreviousTo { get; set; }
        public string? RecipientEmailAddrtess { get; set; }
        public string? RecipientUnitEmail { get; set; }
        public string? ReasonForRejection { get; set; }

    }

    public class UpdateAuditAnnouncementMemoRequest      
    {       
        public string? Recommendation { get; set; } = null;
        public DateTime CommenceDate { get; set; }
        public DateTime periodFrom { get; set; }
        public DateTime periodTo { get; set; }
        public DateTime PreviousFrom { get; set; }
        public DateTime PreviousTo { get; set; }
        public string? RecipientEmail { get; set; } = null;
        public Guid CommenceEngagementId { get; set; }
    }

    public class AuditAnnouncementMemoRequest      
    {
        [Required]
        public string Team { get; set; }
        [Required]
        public string Salutation { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public string Recommendation { get; set; }
        [Required]
        public DateTime CommenceDate { get; set; }
        [Required]
        public DateTime periodFrom { get; set; }
        [Required]
        public DateTime periodTo { get; set; }
        [Required]
        public DateTime PreviousFrom { get; set; }
        [Required]
        public DateTime PreviousTo { get; set; }
        [Required]
        public string RecipientEmail { get; set; }
        [Required]
        public string? RecipientUnitEmail { get; set; } = null;
        [Required]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
    }


    public class AuditAnnouncementMemoRequestValidation : AbstractValidator<AuditAnnouncementMemoRequest>
    {
        public AuditAnnouncementMemoRequestValidation()
        {
            RuleFor(x => x.Salutation).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.Unit).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.Recommendation).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.CommenceDate).NotEmpty();
            RuleFor(x => x.RecipientEmail).NotEmpty();
            RuleFor(x => x.periodFrom).NotEmpty();
            RuleFor(x => x.periodTo).NotEmpty();
            RuleFor(x => x.PreviousFrom).NotEmpty();
            RuleFor(x => x.PreviousTo).NotEmpty();
            // RuleFor(x => x.periodFrom).NotEmpty().GreaterThanOrEqualTo(DateTime.Today).WithMessage("periodFrom date cannot be earlier than today's date");

            RuleFor(x => x.AnualAuditUniverseRiskRatingId).NotEmpty();
        }
    }

    public class UpdateAuditAnnouncementMemoRequestValidation : AbstractValidator<UpdateAuditAnnouncementMemoRequest>
    {
        public UpdateAuditAnnouncementMemoRequestValidation()
        {
           
            RuleFor(x => x.CommenceEngagementId).NotEmpty();
        }
    }
}
