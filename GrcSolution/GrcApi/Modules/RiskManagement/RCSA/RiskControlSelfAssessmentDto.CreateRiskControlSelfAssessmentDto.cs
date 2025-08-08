using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateRiskControlSelfAssessmentDto(
        DateTime PeriodFrom,
        DateTime PeriodTo,
        DateTime StartDate,
        DateTime EndDate,
        IList<CreateRiskControlSelfAssessmentUnitDto> RiskControlSelfAssessmentUnits 
    );

    public record CreateRiskControlSelfAssessmentUnitDto(Guid UnitId);

    public record CreateRiskControlSelfAssessmentResponseDto(Guid RiskControlSelfAssessmentId);

    public record RiskControlSelfAssessmentRejectDto(Guid RiskControlSelfAssessmentUnitId, string Comment);

    public class RiskControlSelfAssessmentRejectDtoValidator : AbstractValidator<RiskControlSelfAssessmentRejectDto>
    {
        public RiskControlSelfAssessmentRejectDtoValidator()
        {
            RuleFor(x => x.RiskControlSelfAssessmentUnitId).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class CreateRiskControlSelfAssessmentDtoValidator : AbstractValidator<CreateRiskControlSelfAssessmentDto>
    {
        public CreateRiskControlSelfAssessmentDtoValidator()
        {
            RuleFor(model => model.PeriodFrom).NotEmpty();
            RuleFor(model => model.PeriodTo).NotEmpty();
            RuleFor(model => model.StartDate).NotEmpty();
            RuleFor(model => model.EndDate).NotEmpty();
            RuleFor(model => model.RiskControlSelfAssessmentUnits).NotEmpty();
            RuleForEach(model => model.RiskControlSelfAssessmentUnits).SetValidator(new CreateRiskControlSelfAssessmentUnitDtoValidator());
        }
    }

    public class CreateRiskControlSelfAssessmentUnitDtoValidator : AbstractValidator<CreateRiskControlSelfAssessmentUnitDto>
    {
        public CreateRiskControlSelfAssessmentUnitDtoValidator()
        {
            RuleFor(x => x.UnitId).NotEmpty();
        }
    }
}
