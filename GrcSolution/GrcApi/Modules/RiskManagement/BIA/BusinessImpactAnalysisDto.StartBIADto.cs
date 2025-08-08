using FluentValidation;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public record StartBIADto(
        DateOnly PeriodFrom,
        DateOnly PeriodTo,
        DateOnly StartDate,
        DateOnly EndDate,
        List<CreateBusinessImpactAnalysisUnitDto> BusinessImpactAnalysisUnits
        );

    public record CreateBusinessImpactAnalysisUnitDto(Guid UnitId);

    public record StartBIAResponseDto(Guid BusinessImpactAnalysisId, List<BIAUnitDto> BusinessImpactAnalysisUnits);

    public class StartBusinessImpactAnalysisDtoValidator : AbstractValidator<StartBIADto>
    {
        public StartBusinessImpactAnalysisDtoValidator()
        {
            RuleFor(model => model.PeriodFrom).NotEmpty();
            RuleFor(model => model.PeriodTo).NotEmpty();
            RuleFor(model => model.StartDate).NotEmpty();
            RuleFor(model => model.EndDate).NotEmpty();
            RuleFor(model => model.BusinessImpactAnalysisUnits).NotEmpty();
            RuleForEach(model => model.BusinessImpactAnalysisUnits).SetValidator(new CreateBusinessImpactAnalysisUnitDtoValidator());
        }
    }

    public class CreateBusinessImpactAnalysisUnitDtoValidator : AbstractValidator<CreateBusinessImpactAnalysisUnitDto> {
        public CreateBusinessImpactAnalysisUnitDtoValidator()
        {
            RuleFor(x => x.UnitId).NotEmpty();
        }
    }
}
