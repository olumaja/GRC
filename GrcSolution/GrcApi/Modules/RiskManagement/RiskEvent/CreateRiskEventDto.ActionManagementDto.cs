using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateActionManagementDto(
            Guid RiskEventId,
             string Action,
               string ActionOwner,
            DateOnly ActionResolutionDate,
             string ActionProgress,
            ActionState ActionStatus
    );

    public class CreateActionManagementDtoValidator : AbstractValidator<CreateActionManagementDto>
    {
        public CreateActionManagementDtoValidator()
        {
            RuleFor(x => x.RiskEventId).NotEmpty();
            RuleFor(x => x.Action).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwner).NotEmpty().EmailAddress();
                //.Must(CharacterValidation.IsInvalidCharacter)
                //.WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionResolutionDate).NotEmpty();
            RuleFor(x => x.ActionProgress).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(x => x.ActionStatus).NotEmpty();
        }
    }

    public record ActionManagementDto(
        Guid RiskEventId,
         string Action,
           string ActionOwner,
        DateOnly ActionResolutionDate,
           string ActionProgress,
        ActionState ActionStatus
    );

}
