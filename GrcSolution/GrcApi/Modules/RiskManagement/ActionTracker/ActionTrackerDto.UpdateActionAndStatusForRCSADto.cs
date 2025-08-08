using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;

namespace GrcApi.Modules.RiskManagement.ActionTracker
{
    public record UpdateActionAndStatusForRCSADto(
        Guid ProcessInhereRiskControlId,
        string ActionProgress,
        PIRCActionState ActionStatus
    );

        public class UpdateActionAndStatusForRCSADtoValidator : AbstractValidator<UpdateActionAndStatusForRCSADto>
    {
        public UpdateActionAndStatusForRCSADtoValidator()
        {
            RuleFor(model => model.ProcessInhereRiskControlId).NotEmpty();
            RuleFor(model => model.ActionProgress).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(model => model.ActionStatus).NotNull();
        }
    }

}
