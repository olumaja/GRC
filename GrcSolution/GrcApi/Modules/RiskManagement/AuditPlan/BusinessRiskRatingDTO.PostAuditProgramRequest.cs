using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class PostAuditProgramRequest
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        [Required]
        public string Team { get; set; }
        public List<AuditProgramme> auditProgrammes { get; set; }
    }

    public record PostAuditProgramResponse(string AuditProgramId);

    public class AuditProgramme
    {
        public string Process { get; set; }
        public string SubProcess { get; set; }
        public string RiskDescription { get; set; }
        public string ControlDescription { get; set; }
        public string ControlObjectives { get; set; }
        public string ReviewProcedure { get; set; }
        public string InformationRequired { get; set; }
        public string Comment { get; set; }
    }

    public class PostAuditProgramRequestValidation : AbstractValidator<PostAuditProgramRequest>
    {
        public PostAuditProgramRequestValidation()
        {
            RuleFor(x => x.AnualAuditUniverseRiskRatingId).NotEmpty();
            RuleFor(x => x.auditProgrammes).NotEmpty();
            RuleForEach(u => u.auditProgrammes).SetValidator(new AuditProgrammeValidation());
        }
    }

    public class AuditProgrammeValidation : AbstractValidator<AuditProgramme>
    {
        public AuditProgrammeValidation()
        {
            RuleFor(x => x.Process).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow"); 
            RuleFor(x => x.SubProcess).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.RiskDescription).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.ControlDescription).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.ControlObjectives).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.ReviewProcedure).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.InformationRequired).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class UpdateAuditProgramRequest
    {
        public Guid CommenceEngagementId { get; set; }
        public List<AuditProgrammeToBeUpdated> AuditProgrammes { get; set; }
    }

    public class AuditProgrammeToBeUpdated
    {
        public Guid AuditProgramId { get; set; }
        public string? Process { get; set; }
        public string? SubProcess { get; set; }
        public string? RiskDescription { get; set; }
        public string? ControlDescription { get; set; }
        public string? ControlObjectives { get; set; }
        public string? ReviewProcedure { get; set; }
        public string? InformationRequired { get; set; }
        public string? Comment { get; set; }
    }

    public class UpdateAuditProgramRequestValidation : AbstractValidator<UpdateAuditProgramRequest>
    {
        public UpdateAuditProgramRequestValidation()
        {
            RuleFor(u => u.CommenceEngagementId).NotEmpty();
            RuleFor(u => u.AuditProgrammes).NotEmpty();
            RuleForEach(u => u.AuditProgrammes).SetValidator(new AuditProgrammeToBeUpdatedValidation());
        }
    }

    public class AuditProgrammeToBeUpdatedValidation : AbstractValidator<AuditProgrammeToBeUpdated>
    {
        public AuditProgrammeToBeUpdatedValidation()
        {
            RuleFor(a => a.AuditProgramId).NotEmpty();
            //RuleFor(a => a.Process).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(a => a.SubProcess).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(a => a.RiskDescription).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(a => a.ControlDescription).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(a => a.ControlObjectives).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(a => a.ReviewProcedure).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(a => a.InformationRequired).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            //RuleFor(a => a.Comment).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

}
