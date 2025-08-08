using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.Risk
{
    public class RiskEventTypeSubCategory : BaseEntity
    {
        public Guid RiskEventTypeCategoryId { get; private set; }
        public RiskEventTypeCategory? RiskEventTypeCategory { get; private set; }

        public static RiskEventTypeSubCategory Create(Guid riskEventTypeCategoryId, string name)
        {
            return new RiskEventTypeSubCategory
            {
                RiskEventTypeCategoryId = riskEventTypeCategoryId,
                Name = name
            };
        }
    }
}
