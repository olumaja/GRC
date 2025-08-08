using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.BusinessImpactAnalysis
{
    public class BusinessImpactAnalysis : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateOnly PeriodFrom { get; private set; }

        public DateOnly PeriodTo { get; private set; }

        public DateOnly StartDate { get; private set; }

        public DateOnly EndDate { get; private set; }

        public virtual List<BusinessImpactAnalysisUnit> BusinessImpactAnalysisUnits { get; private set; } = new();

        public static BusinessImpactAnalysis Create(DateOnly periodFrom, DateOnly periodTo, DateOnly startDate,
                                                    DateOnly endDate, List<BusinessImpactAnalysisUnit> businessImpactAnalysisUnits)
        {
            return new BusinessImpactAnalysis
            {
                PeriodFrom = periodFrom,
                PeriodTo = periodTo,
                StartDate = startDate,
                EndDate = endDate,
                BusinessImpactAnalysisUnits = businessImpactAnalysisUnits
            };
        }
    }
}
