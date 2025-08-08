using Arm.GrcApi.Modules.RiskManagement.BIA;
using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.PRA
{
    public record InitiateAssessRiskDto(
        Guid ProductRiskAssessmentId, string QuestionOrRecomendation, List<AssessRiskDto> AssessRisks
    );
    
    public record AssessRiskDto(
        string ProductRiskCategory,
        string Description,
        PARRating Rating
    );

    public class InitiateAssessRiskDtoValidator : AbstractValidator<InitiateAssessRiskDto>
    {
        public InitiateAssessRiskDtoValidator()
        {
            RuleFor(model => model.ProductRiskAssessmentId).NotEmpty();
            RuleFor(model => model.QuestionOrRecomendation).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.AssessRisks).NotEmpty();
            RuleForEach(model => model.AssessRisks).SetValidator(new AssessRiskDtoValidator());
        }
    }

    public class AssessRiskDtoValidator : AbstractValidator<AssessRiskDto>
    {
        public AssessRiskDtoValidator()
        {
            RuleFor(model => model.ProductRiskCategory).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.Description).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(model => model.Rating).NotEmpty();
        }
    }
}
