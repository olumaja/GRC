using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain.RiskEvent;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateEffectManagementDto(
            Guid RiskEventId,
            EffectType EffectType,
            Guid EffectCategoryId,
            decimal LossValue,
              string RationaleForGrossLossValue,
              string EffectDescription
    );

    public class CreateEffectManagementDtoValidator : AbstractValidator<CreateEffectManagementDto>
    {
        public CreateEffectManagementDtoValidator()
        {
            RuleFor(x => x.RiskEventId).NotEmpty();
            //RuleFor(x => x.EffectType).NotEmpty();
            //RuleFor(x => x.EffectCategoryId).NotEmpty();
            //RuleFor(x => x.LossValue).NotEmpty();
            RuleFor(x => x.RationaleForGrossLossValue).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.EffectDescription).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record EffectManagementDto(
        Guid RiskEventId,
        //Guid EffectTypeId,
        EffectType EffectType,
        Guid EffectCategoryId,
        decimal LossValue,
         string RationaleForGrossLossValue,
         string EffectDescription
    );

    
}
