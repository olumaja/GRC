using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public enum EffectType
    {
        None,
        ActualLoss,
        PotentialLoss,
        NearMiss
    }
    public class RiskEffectManagement : AuditEntity
    {

        private RiskEffectManagement() { }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid RiskEventId { get; private set; }

        public EffectType EffectType { get; private set; }

        public Guid EffectCategoryId { get; private set; }

        public decimal LossValue { get; private set; }

        public string RationaleForGrossLossValue { get; private set; } = null!;

        public string EffectDescription { get; private set; } = null!;

        public static RiskEffectManagement Create(
            Guid riskEventId,
            EffectType effectType,
            Guid effectCategoryId,
            decimal lossValue,
            string rationaleForGrossLossValue,
            string effectDescription
            ) 
        {
            return new RiskEffectManagement
            {
                RiskEventId = riskEventId,
                EffectType = effectType,
                EffectCategoryId = effectCategoryId,
                LossValue = lossValue,
                RationaleForGrossLossValue = rationaleForGrossLossValue,
                EffectDescription = effectDescription
            };
        }

        internal static RiskEffectManagement Create(Guid riskEventId, object effectType)
        {
            throw new NotImplementedException();
        }
    }
}
