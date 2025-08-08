using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.RCSA
{
    public record GetAllRCSAForRiskChampionDto
    {
        public Guid RiskControlSelfAssessmentUnitId { get; init; }

        public DateTime CreatedDate { get; init; }
        

        public string Status { get; init; } = null!;

        public DateOnly PeriodFrom { get; init; }

        public DateOnly PeriodTo { get; init; }

        public DateOnly StartDate { get; init; }

        public DateOnly EndDate { get; init; }
        

        public string UnitName { get; init; } = null!;

        public Guid RCSAId { get; init; }
    }
}
