using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class RiskDriver : BaseEntity
    {
        public List<RiskDriverCategory> RiskDriverCategories { get; private set; } = new List<RiskDriverCategory>();

        public static RiskDriver Create(
            string name
            )
        {
            return new RiskDriver
            {
                Name = name
            };
        }

        public static RiskDriver Create(
            string name,
            Guid id
            )
        {
            return new RiskDriver
            {
                Name = name,
                Id = id
            };
        }
    }
}
