using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public record UpdatePostWorkPaperRequest(
       Guid WorkpapperId,
       string Reference,
       string Reoccurence,
       string ExceptionNoted,
       string IssueSummary,
       string RootCause,
       string Impact,
       string Recommendation,
       string ReviewResult,
       IssueRating IssueRating
   );
    public class UpdatePostWorkPaperRequestValidation : AbstractValidator<UpdatePostWorkPaperRequest>
    {
        public UpdatePostWorkPaperRequestValidation()
        {
            RuleFor(x => x.WorkpapperId).NotEmpty();           
        }
    }
    public record PostWorkPaperRequest(
        Guid AuditProgramId,
        string Team,
        string Reference,
        string Reoccurence,
        string ExceptionNoted,
        string IssueSummary,
        string RootCause,
        string Impact,
        string Recommendation,
        string ReviewResult,
        IssueRating IssueRating
    );

    public class PostWorkPaperRequestValidation : AbstractValidator<PostWorkPaperRequest>
    {
        public PostWorkPaperRequestValidation()
        {
            RuleFor(x => x.AuditProgramId).NotEmpty();

            RuleFor(x => x.Team).NotEmpty()
               .Must(CharacterValidation.IsInvalidCharacter)
               .WithMessage("{PropertyName} contains one or more special charaters that are not allow");


            RuleFor(x => x.Reference).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.Reoccurence).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.ExceptionNoted).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow"); ;

            RuleFor(x => x.IssueSummary).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.RootCause).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.Impact).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.Recommendation).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special charaters that are not allow");
            RuleFor(x => x.ReviewResult).NotEmpty()
              .Must(CharacterValidation.IsInvalidCharacter)
              .WithMessage("{PropertyName} contains one or more special charaters that are not allow");

            RuleFor(x => x.IssueRating).NotEmpty(); 
        }
    }

    public record WorkPaperResponse (Guid WorkpaperId);
       
    public class GetWorkpaperResponse
    {
        public Guid AuditProgramId { get; set; }
        public Guid WorkPaperId { get; set; }
        public string Team { get; set; }
        public string Process { get; set; }
        public string SubProcess { get; set; }
        public string RiskDescription { get; set; }
        public string ControlDescription { get; set; }
        public string ControlObjectives { get; set; }
        public string ReviewProcedure { get; set; }
        public string InformationRequired { get; set; }
        public string Comments { get; set; }
        public string IssueSummary { get; set; }
        public string RootCause { get; set; }
        public string IssueRating { get; set; }
        public string ReviewResult { get; set; }
        public string Recommendation { get; set; }
        public string Impact { get; set; }        
        public DateTime DateCreated { get; set; }        
        public string? ReasonForRejection { get; set; }        
        public string? Status { get; set; }        
    }


}
