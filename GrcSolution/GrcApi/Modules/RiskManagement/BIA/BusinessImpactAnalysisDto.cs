namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public record BusinessImpactAnalysisDto
    {
        public Guid BusinessImpactAnalysisId { get; init; }

        public DateTime CreatedDate { get; init; }

        public int NumberOfRiskControlSelfAssessmentUnits { get; init; }

        public DateOnly PeriodFrom { get; init; }

        public DateOnly PeriodTo { get; init; }

        public DateOnly StartDate { get; init; }

        public DateOnly EndDate { get; init; }

        public List<BIAUnitDto> BusinessImpactAnalysisUnits { get; init; } = new List<BIAUnitDto>();
    }

    public record BIAUnitDto(Guid BusinessImpactAnalysisUnitId);
}
