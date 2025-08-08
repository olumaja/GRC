using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class RiskDriverSubCategory : BaseEntity
    {
        public Guid RiskDriverCategoryId { get; private set; }

        public RiskDriverCategory RiskDriverCategory { get; private set; } = null!;

        public static RiskDriverSubCategory Create(
            Guid riskDriverCategoryId,
            string name
            )
        {
            return new RiskDriverSubCategory
            {
                RiskDriverCategoryId = riskDriverCategoryId,
                Name = name
            };
        }

        public static RiskDriverSubCategory Create(
            Guid riskDriverCategoryId,
            string name,
            Guid id
            )
        {
            return new RiskDriverSubCategory
            {
                RiskDriverCategoryId = riskDriverCategoryId,
                Name = name,
                Id = id
            };
        }
    }
}