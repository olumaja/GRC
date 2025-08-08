using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    public class AddBusinessToRuleDto
    {
        public Guid ComplianceRuleId { get; set; }
        public string? BusinessInvolved { get; set; }
    }


    public class AddBusinessToRuleDtoDtoValidator : AbstractValidator<AddBusinessToRuleDto>
    {
        public AddBusinessToRuleDtoDtoValidator()
        {
            RuleFor(x => x.BusinessInvolved).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

}
