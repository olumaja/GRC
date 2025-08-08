using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateLossManagementDto(
        Guid RiskEventId,
        decimal GrossLossValue,
        decimal TotalRecoveredAmount,
        DateOnly RecoveryDate,
        decimal RecoveredAmount,
         string RecoveryDescription,
        decimal NetLoss,
         string AccountImpacted
    );

    public class CreateLossManagementDtoValidator : AbstractValidator<CreateLossManagementDto>
    {
        public CreateLossManagementDtoValidator()
        {
            RuleFor(x => x.RiskEventId).NotEmpty();
            RuleFor(x => x.RecoveryDate).NotEmpty();
            RuleFor(x => x.RecoveryDescription).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.AccountImpacted).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record LossManagementDto(
        Guid RiskEventId,
        decimal GrossLossValue,
        decimal TotalRecoveredAmount,
        DateOnly RecoveryDate,
        decimal RecoveredAmount,
        Guid RecoveryTypeId,
         string RecoveryDescription,
        decimal NetLoss,
         string AccountImpacted
    );
}
