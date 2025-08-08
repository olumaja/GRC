using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.Risk
{
    public class RiskEventType : BaseEntity
    {
        public List<RiskEventTypeCategory> RiskEventTypeCategories { get; private set; } = new List<RiskEventTypeCategory>();
        public static RiskEventType Create(string name)
        {
            return new RiskEventType
            {
                Name = name
            };
        }

        public static RiskEventType Create(Guid id, string name)
        {
            return new RiskEventType
            {
                Id = id,
                Name = name
            };
        }
    }
}
