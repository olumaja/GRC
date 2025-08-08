using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.RiskManagement.AuditPlan;
using DocumentFormat.OpenXml.Spreadsheet;
using Arm.GrcApi.Modules.OperationControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ConsolidatedAuditFindingUploadReq
    {
        public string? ReviewType { get; set; }
        public string DateFindingRaised { get; set; }
        public string? Business { get; set; }
        public string? Level1 { get; set; }
        public string? Level2 { get; set; }
        public string? ReportingQuater { get; set; }
        public string? WorkStream { get; set; }
        public string? AuditArea { get; set; }
        public string? ImpactRating { get; set; }
        public string? Recommendation { get; set; }
        public string RevisedDueDate { get; set; }
        public string? EngagementName { get; set; }
        public string? DetailedFindings { get; set; }
        public string? DescriptionOfFinding { get; set; }
        public string ActionDueDate { get; set; }
        public string? ManagmentResponseAsAtTimeOfEngagement { get; set; }
        public string? UpdatedComment { get; set; }


        public string? ResolutionDate { get; set; }
        public string? DescriptionOfIssue { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; } = null;
        public string? Entity { get; set; } = null;
        //public string? Status { get; set; }
        //public string? StatusLevel { get; set; }
        //public string? OPRStatus { get; set; }
    }

    public class ConsolidatedAuditFindingRequest
    {

        public Guid AuditReportId { get; set; }
        [Required]
        public string Business { get; set; }
        public List<ConsolidatedAuditFindingReq> Findings { get; set; }            
        
    }
  
    public class ConsolidatedAuditFindingReq
    {
        public string? ReviewType { get; set; }
        public DateTime DateFindingRaised { get; set; }
        public string? Level1 { get; set; } = null;
        public string? Level2 { get; set; }
        public string? ReportingQuater { get; set; }
        public string? WorkStream { get; set; }
        public string? AuditArea { get; set; }
        public string? EngagementName { get; set; }
        public DateTime? RevisedDueDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string? DescriptionOfIssue { get; set; }
        public string? Recommendation { get; set; }
        public string? ImpactRating { get; set; }
        public string? DetailedFindings { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; } = null;
        public string? Entity { get; set; } = null;
        public DateTime? ActionDueDate { get; set; }
        public string? ManagmentResponseAsAtTimeOfEngagement { get; set; }
        public string? UpdatedComment { get; set; }
    }

    public class ConsolidatedAuditFindingRequestValidator : AbstractValidator<ConsolidatedAuditFindingRequest>
    {
        public ConsolidatedAuditFindingRequestValidator()
        {
            RuleFor(x => x.AuditReportId).NotEmpty();
            RuleFor(x => x.Business).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);            
        }
    }

    public class ActionDetailRequest
    {
        public string? Recommendation { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; }
        public string? EntityToAction { get; set; }
        public DateTime ActionDueDate { get; set; }

    }

    public class ActionDetailRequestValidator : AbstractValidator<ActionDetailRequest>
    {
        public ActionDetailRequestValidator()
        {
            RuleFor(x => x.Recommendation).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwner).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Unit).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.EntityToAction).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionDueDate).NotEmpty();
        }
    }
       
    public class UpdateConsolidatedAuditFindingRequest
    {
        public Guid ConsolidatedAuditFindingId { get; set; }
        public string? ReviewType { get; set; }
        public DateTime DateFindingRaised { get; set; }
        public string? Level1 { get; set; } = null;
        public string? Level2 { get; set; }
        public string? ReportingQuater { get; set; }
        public string? WorkStream { get; set; }
        public string? AuditArea { get; set; }
        public string? Business { get; set; }
        public string? EngagementName { get; set; }
        public DateTime? RevisedDueDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string? DescriptionOfIssue { get; set; }
        public string? Recommendation { get; set; }
        public string? ImpactRating { get; set; }
        public string? DetailedFindings { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; } = null;
        public string? Entity { get; set; } = null;
        public DateTime? ActionDueDate { get; set; }
        public string? ManagmentResponseAsAtTimeOfEngagement { get; set; }
        public string? UpdatedComment { get; set; }
    }
    public class UpdateConsolidatedAuditFindingRequestValidator : AbstractValidator<UpdateConsolidatedAuditFindingRequest>
    {
        public UpdateConsolidatedAuditFindingRequestValidator()
        {
            RuleFor(x => x.ConsolidatedAuditFindingId).NotEmpty();            
        }
    }
    public class UpdateActionDetailRequest
    {
        public Guid ConsolidatedAuditFindingId { get; set; }
        public string? Recommendation { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; }
        public string? EntityToAction { get; set; }
        public DateTime ActionDueDate { get; set; }

    }

    public class GetConsolidatedAuditFindingById
    {
        public Guid ConsolidatedAuditFindingId { get; set; }
        public string? Business { get; set; }
        public string? ReviewType { get; set; }
        public DateTime? DateFindingRaised { get; set; }
        public string? Level1 { get; set; } = null;
        public string? Level2 { get; set; }
        public string? ReportingQuater { get; set; }
        public string? WorkStream { get; set; }
        public string? AuditArea { get; set; }
        public string? EngagementName { get; set; }
        public DateTime? RevisedDueDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string? DescriptionOfIssue { get; set; }
        public string? Recommendation { get; set; }
        public string? ImpactRating { get; set; }
        public string? DetailedFindings { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; } = null;
        public string? Entity { get; set; } = null;
        public DateTime? ActionDueDate { get; set; }
        public string? ManagmentResponseAsAtTimeOfEngagement { get; set; }
        public string? UpdatedComment { get; set; }
        public DateTime DateCreated { get; set; }
        public string? RequesterName { get; set; }
        public string? Status { get; set; }
        public string? StatusLevel { get; set; }
        public string OPRStatus { get; set; }
        public string? DueDay { get; set; }
        public bool FindingExpectedToBeClosed { get; set; }
        public string FindingRaisedYear { get; set; }
        public bool PriorYearFinding { get; set; }
        public bool CurrentYearFinding { get; set; }

    }

    public class GetConsolidatedAuditFindingListResp
    {
        public Guid ConsolidatedAuditFindingId { get; set; }
        public string? Business { get; set; }
        public string? ReviewType { get; set; }
        public DateTime? DateFindingRaised { get; set; }
        public string? ReportingQuater { get; set; }       
        public DateTime? RevisedDueDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string? Status { get; set; }
        public string? StatusLevel { get; set; }
        public string? OPRStatus { get; set; }        
        public DateTime? ActionDueDate { get; set; }       
      
    }
    public record PaginatedGetConsolidatedAuditFindingListResp(PaginationMeta PaginationMeta, int Count, double ClosureRate, int Total, List<GetConsolidatedAuditFindingListResp> Response);


}
