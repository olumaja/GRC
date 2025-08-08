using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.PRA
{
    public record ApproveProductRiskAssessment(
        Guid ProductRiskAssessementId,
        string  OwnerResponseToRecommendation,
        List<ProductAssessRiskForApproval> AssessRiskForApprovals
    );

    public record  ProductAssessRiskForApproval(Guid ProductAssessRiskId, string ProductOwnerResponse);

    public record RejectProductRiskAssessmentDto(Guid ProductRiskAssessementId, string ReasonForRejection);

    public class ApproveProductRiskAssessmentValidator : AbstractValidator<ApproveProductRiskAssessment>
    {
        public ApproveProductRiskAssessmentValidator()
        {
            RuleFor(model => model.ProductRiskAssessementId).NotEmpty();
            RuleFor(model => model.AssessRiskForApprovals).NotEmpty();
            RuleFor(model => model.OwnerResponseToRecommendation).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleForEach(model => model.AssessRiskForApprovals).SetValidator(new ProductAssessRiskForApprovalValidator());
        }
    }

    public class ProductAssessRiskForApprovalValidator : AbstractValidator<ProductAssessRiskForApproval>
    {
        public ProductAssessRiskForApprovalValidator()
        {
            RuleFor(model => model.ProductAssessRiskId).NotEmpty();
            RuleFor(model => model.ProductOwnerResponse).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class RejectProductRiskAssessmentValidator : AbstractValidator<RejectProductRiskAssessmentDto>
    {
        public RejectProductRiskAssessmentValidator()
        {
            RuleFor(model => model.ProductRiskAssessementId).NotEmpty();
            RuleFor(model => model.ReasonForRejection).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
}
