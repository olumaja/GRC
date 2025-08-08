using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.Risk
{
    public class RiskEventTypeCategory : BaseEntity
    {
        public Guid RiskEventTypeId { get; private set; }
        public RiskEventType? RiskEventType { get; private set; }
        public List<RiskEventTypeSubCategory> RiskEventTypeSubCategories { get; private set; } = new List<RiskEventTypeSubCategory>();

        public static RiskEventTypeCategory Create(Guid riskEventTypeId, string name)
        {
            return new RiskEventTypeCategory
            {
                RiskEventTypeId = riskEventTypeId,
                Name = name
            };
        }

        public static RiskEventTypeCategory Create(Guid id, Guid riskEventTypeId, string name)
        {
            return new RiskEventTypeCategory
            {
                Id = id,
                RiskEventTypeId = riskEventTypeId,
                Name = name
            };
        }
    }
}
