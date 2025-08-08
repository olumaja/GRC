using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace GrcApi.Modules.RiskManagement.ActionTracker
{
    public record UpdateActionProgressAndStatusDto(
        Guid ActionManagementId,
        string ActionProgress,
        ActionState ActionStatus
    );
    
    public class UpdateActionProgressAndStatusDtoValidator : AbstractValidator<UpdateActionProgressAndStatusDto>
    {
        public UpdateActionProgressAndStatusDtoValidator()
        {
            RuleFor(model => model.ActionManagementId).NotEmpty();
            RuleFor(model => model.ActionProgress).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(model => model.ActionStatus).NotNull();
        }
    }
}
