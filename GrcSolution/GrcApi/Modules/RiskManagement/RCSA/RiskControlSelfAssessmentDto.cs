using GrcApi.Modules.BusinessEntities;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record RiskControlSelfAssessmentDto
    {
        public Guid Id { get; init; }

        public DateTime CreatedDate { get; init; }

        public int NumberOfRiskControlSelfAssessmentUnits { get; init; }

        public DateOnly PeriodFrom { get; init; }

        public DateOnly PeriodTo { get; init; }

        public DateOnly StartDate { get; init; }

        public DateOnly EndDate { get; init; }

        public List<UnitDto> RiskControlSelfAssessmentUnits { get; init; } = new List<UnitDto>();

        public Guid RCSAId { get; init; }
    }


}
