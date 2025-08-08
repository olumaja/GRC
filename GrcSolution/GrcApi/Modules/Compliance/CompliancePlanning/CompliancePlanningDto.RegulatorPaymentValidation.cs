using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public record ApprovePaymentDto(Guid ComplianceRegulatoryPaymentId);
    
    public record RejectPaymentDto(Guid ComplianceRegulatoryPaymentId, string Reason);

    public class ApprovePaymentDtoValidation : AbstractValidator<ApprovePaymentDto>
    {
        public ApprovePaymentDtoValidation()
        {
            RuleFor(x => x.ComplianceRegulatoryPaymentId).NotEmpty();
        }
    }

    public class RejectPaymentDtoValidation : AbstractValidator<RejectPaymentDto>
    {
        public RejectPaymentDtoValidation()
        {
            RuleFor(x => x.ComplianceRegulatoryPaymentId).NotEmpty();
            RuleFor(x => x.Reason).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
}
