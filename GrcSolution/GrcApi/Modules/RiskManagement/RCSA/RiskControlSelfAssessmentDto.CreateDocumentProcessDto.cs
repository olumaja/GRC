using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

namespace Arm.GrcTool.Domain
{
    public record RiskControlSelfAssessmentCreateDocumentProcessDto(
        Guid RiskControlSelfAssessmentUnitId, List<CreateProcessInherentRiskControlDto> ProcessInherentRiskControls
    );

    public record ProcessInherentRiskControlDto(
      Guid ProcessInherentRiskControlId,  Guid ProcessId, string InherentRisk, string Control, string TestToApply, string ProcessName
    );

    public class ProcessInherentRiskControlDtoValidator : AbstractValidator<ProcessInherentRiskControlDto>
    {
        public ProcessInherentRiskControlDtoValidator()
        {
            RuleFor(x => x.ProcessInherentRiskControlId).NotEmpty();
            RuleFor(x => x.ProcessId).NotEmpty();
            RuleFor(x => x.InherentRisk).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Control).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.TestToApply).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ProcessName).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record CreateProcessInherentRiskControlDto(
        Guid ProcessId, string InherentRisk, string Control
    );

    public record CreateDocumentProcessResponseDto
    {
        public Guid DocumentRCSAProcessId { get; set; }
    }

    public record ApplyTestProcessInherentRiskControlDto(Guid RiskControlSelfAssessmentUnitId, List<TestToApplyDto> applyTests);
    public record TestToApplyDto(Guid ProcessInherentRiskControlId,  string testToApply);

    public class ApplyTestProcessInherentRiskControlDtoValidator : AbstractValidator<ApplyTestProcessInherentRiskControlDto>
    {
        public ApplyTestProcessInherentRiskControlDtoValidator()
        {
            RuleFor(model => model.applyTests).NotEmpty();
            RuleForEach(model => model.applyTests).SetValidator(new TestToApplyDtoValidator());
            RuleFor(model => model.RiskControlSelfAssessmentUnitId).NotEmpty();
        }
    }

    public class TestToApplyDtoValidator : AbstractValidator<TestToApplyDto>
    {
        public TestToApplyDtoValidator()
        {
            RuleFor(x => x.testToApply).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class RiskControlSelfAssessmentCreateDocumentProcessDtoValidator : AbstractValidator<RiskControlSelfAssessmentCreateDocumentProcessDto>
    {
        public RiskControlSelfAssessmentCreateDocumentProcessDtoValidator()
        {
            RuleFor(model => model.RiskControlSelfAssessmentUnitId).NotEmpty();
            RuleFor(model => model.ProcessInherentRiskControls).NotEmpty();

            RuleForEach(model => model.ProcessInherentRiskControls).SetValidator(new CreateProcessInherentRiskControlDtoValidator());
        }
    }

    public class CreateProcessInherentRiskControlDtoValidator : AbstractValidator<CreateProcessInherentRiskControlDto>
    {
        public CreateProcessInherentRiskControlDtoValidator()
        {
            RuleFor(model => model.ProcessId).NotEmpty();
            RuleFor(model => model.InherentRisk).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.Control).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
}
