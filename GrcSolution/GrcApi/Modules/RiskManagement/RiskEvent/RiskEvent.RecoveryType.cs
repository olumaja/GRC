using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class RecoveryType : BaseEntity
    {
        public static RecoveryType Create(Guid recoveryTypeId, string name)
        {
            return new RecoveryType
            {
                Id = recoveryTypeId,
                Name = name
            };
        }
    }
}
