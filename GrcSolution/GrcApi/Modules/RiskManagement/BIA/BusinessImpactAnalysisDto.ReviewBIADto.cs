using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.BIA
{
    public record ApproveInitiateBIADto(Guid BusinessImpactAnalysisUnitId);

    public record RejectInitiateBIADto(Guid BusinessImpactAnalysisUnitId, string Comment);

    public class ApproveInitiateBIAValidator : AbstractValidator<ApproveInitiateBIADto>
    {
        public ApproveInitiateBIAValidator()
        {
            RuleFor(input =>  input.BusinessImpactAnalysisUnitId).NotEmpty();
        }
    }

    public class RejectInitiateBIAValidator : AbstractValidator<RejectInitiateBIADto>
    {
        public RejectInitiateBIAValidator()
        {
            RuleFor(input => input.BusinessImpactAnalysisUnitId).NotEmpty();
            RuleFor(input => input.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }



}
