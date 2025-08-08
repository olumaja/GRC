using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskControlSelfAssessment
{
    public class RiskControlSelfAssessment : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateOnly PeriodFrom { get; private set; }

        public DateOnly PeriodTo { get; private set; }

        public DateOnly StartDate { get; private set; }

        public DateOnly EndDate { get; private set; }

        public List<RiskControlSelfAssessmentUnit> RiskControlSelfAssessmentUnits { get; private set; } = new List<RiskControlSelfAssessmentUnit>();

        public static RiskControlSelfAssessment Create(DateOnly periodFrom, DateOnly periodTo, DateOnly startDate, 
                                                        DateOnly endDate, List<RiskControlSelfAssessmentUnit> riskControlSelfAssessmentUnits)
        {
            return new RiskControlSelfAssessment
            {
                PeriodFrom = periodFrom,
                PeriodTo = periodTo,
                StartDate = startDate,
                EndDate = endDate,
                RiskControlSelfAssessmentUnits = riskControlSelfAssessmentUnits
            };
        }
      
    }
}
