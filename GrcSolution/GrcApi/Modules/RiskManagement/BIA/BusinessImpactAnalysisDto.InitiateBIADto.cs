using FluentValidation;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public record InitiateBIADto(
        Guid BusinessImpactAnalysisUnitId,
        List<InitiateBIAProcessDetailsDto> InitiateBIAProcessDetails
    );

    public record InitiateBIAResponseDto(Guid BusinessImpactAnalysisUnitId);

    public class InitiateBIADtoValidator : AbstractValidator<InitiateBIADto>
    {
        public InitiateBIADtoValidator()
        {
            RuleFor(model => model.BusinessImpactAnalysisUnitId).NotEmpty();
            RuleFor(model => model.InitiateBIAProcessDetails).NotEmpty();
            RuleForEach(model => model.InitiateBIAProcessDetails).SetValidator(new InitiateBIAProcessDetailsDtoValidator()); 
        }
    }
}
