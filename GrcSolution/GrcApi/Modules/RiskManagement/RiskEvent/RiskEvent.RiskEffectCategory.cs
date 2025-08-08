using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class RiskEffectCategory : BaseEntity
    {
        public static RiskEffectCategory Create(string name)
        {
            return new RiskEffectCategory
            {
                Name = name
            };
        }
    }
}
