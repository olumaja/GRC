using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public record UpdatePostAuditFindingsRequest
    (
        Guid AuditFindingId,
        string ActionToResolve,
        string ActionToPreventReoccurence,
        DateTime ActionDueDate,
        string ActionOwner,
        string ActionOwnerUnit
    );
    public class UpdatePostAuditFindingsRequestValidation : AbstractValidator<UpdatePostAuditFindingsRequest>
    {
        public UpdatePostAuditFindingsRequestValidation()
        {
            RuleFor(x => x.AuditFindingId).NotEmpty();           
        }
    }
    public record PostAuditFindingsRequest
    (
        Guid AuditProgramId,
        string Team,
        string ActionToResolve,
        string ActionToPreventReoccurence,
        DateTime ActionDueDate,
        string ActionOwner,
        string ActionOwnerUnit
    );

    public class PostAuditFindingsRequestValidation : AbstractValidator<PostAuditFindingsRequest>
    {
        public PostAuditFindingsRequestValidation()
        {
            RuleFor(x => x.AuditProgramId).NotEmpty();

            RuleFor(x => x.Team).NotEmpty()
              .Must(CharacterValidation.IsInvalidCharacter)
              .WithMessage("{PropertyName} contains one or more special charaters that are not allow");


            RuleFor(x => x.ActionToResolve).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.ActionToPreventReoccurence).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.ActionDueDate).NotEmpty();

            RuleFor(x => x.ActionOwner).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.ActionOwnerUnit).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");
        }
    }

    public record AuditFindingsResponse(Guid AuditFindingsId);

    //public record GetAduitFindingsResponse(
    //    Guid AduitProgramId,
    //    Guid WorkpaperId,
    //    Guid AuditFindingsId,
    //    string Process,
    //    string IssueSummary,
    //    string RootCause,
    //    string Impact,
    //    string Recommendation,
    //    string IssueRating,
    //    string ActionToResolve,
    //    string ActionToPreventReOccurrence,
    //    DateTime ActionDueDate,
    //    string ActionOwner,
    //    string ActionOwnerUnit,
    //    string Team
    //);

    public class GetAduitFindingsResponse
    {
        public Guid AuditProgramId { get; set; }
        public Guid WorkpaperId { get; set; }
        public Guid AuditFindingsId { get; set; }
        public string Team { get; set; }
        public string Process { get; set; }
        public string IssueSummary { get; set; }
        public string RootCause { get; set; }
        public string Impact { get; set; }
        public string Recommendation { get; set; }
        public string IssueRating { get; set; }
        public string ActionToResolve { get; set; }
        public string ActionToPreventReOccurrence { get; set; }
        public DateTime ActionDueDate { get; set; }
        public string ActionOwner { get; set; }
        public string ActionOwnerUnit { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ReasonForRejection { get; set; }
        public string? Status { get; set; }
    }
}
