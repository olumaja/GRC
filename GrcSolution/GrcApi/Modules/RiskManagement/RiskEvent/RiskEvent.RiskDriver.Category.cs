using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class RiskDriverCategory : BaseEntity
    {
        public Guid RiskDriverId { get; private set; }

        public RiskDriver RiskDriver { get; private set; } = null!;

        public List<RiskDriverSubCategory> RiskDriverSubCategories { get; private set; } = new List<RiskDriverSubCategory>();

        public static RiskDriverCategory Create(
            Guid riskDriverId,
            string name
            )
        {
            return new RiskDriverCategory
            {
                RiskDriverId = riskDriverId,
                Name = name 
            };
        }

        public static RiskDriverCategory Create(
            Guid riskDriverId,
            string name,
            Guid id
            )
        {
            return new RiskDriverCategory
            {
                RiskDriverId = riskDriverId,
                Name = name,
                Id = id
            };
        }
    }
}
