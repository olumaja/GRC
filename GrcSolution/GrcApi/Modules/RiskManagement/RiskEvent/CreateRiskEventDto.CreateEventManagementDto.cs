using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateEventManagementDto(
            Guid RiskEventId,
            Guid EventTypeId,
            Guid EventCategoryId,
            Guid EventSubCategoryId,
            //Guid BoundaryEventId,
            Guid RiskDriverId,
            Guid RiskDriverCategoryId,
            Guid RiskDriverSubCategoryId,
             string RiskDriverDescription
    );

    public class CreateEventManagementDtoValidator : AbstractValidator<CreateEventManagementDto>
    {
        public CreateEventManagementDtoValidator()
        {
            RuleFor(x => x.RiskEventId).NotEmpty();
            //RuleFor(x => x.EventTypeId).NotEmpty();
            //RuleFor(x => x.EventCategoryId).NotEmpty();
            //RuleFor(x => x.EventSubCategoryId).NotEmpty();
            //RuleFor(x => x.BoundaryEventId).NotEmpty();
            //RuleFor(x => x.RiskDriverId).NotEmpty();
            //RuleFor(x => x.RiskDriverCategoryId).NotEmpty();
            //RuleFor(x => x.RiskDriverSubCategoryId).NotEmpty();
            RuleFor(x => x.RiskDriverDescription).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record EventManagementDto(
        Guid RiskEventId,
        Guid EventTypeId,
        Guid EventCategoryId,
        Guid EventSubCategoryId,
        Guid BoundaryEventId,
        Guid RiskDriverId,
        Guid RiskDriverCategoryId,
        Guid RiskDriverSubCategoryId,
         string RiskDriverDescription
    );
}
