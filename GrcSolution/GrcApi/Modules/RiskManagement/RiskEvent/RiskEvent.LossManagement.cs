using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class LossManagement : AuditEntity
    {
        private LossManagement() { }

        public Guid Id { get; set; }

        public Guid RiskEventId { get; private set; }

        public decimal GrossLossValue { get; private set; }

        public decimal TotalRecoveredAmount { get; private set; }

        public DateOnly RecoveryDate { get; private set; }

        public decimal RecoveredAmount { get; private set; }

        public Guid RecoveryTypeId { get; private set; }

        public string RecoveryDescription { get; private set; } = null!;

        public decimal NetLoss { get; private set; }

        public string AccountImpacted { get; private set; } = null!;

        public static LossManagement Create(
            Guid riskEventId,
            decimal grossLossValue,
            decimal totalRecoveredAmount,
            DateOnly recoveryDate,
            decimal recoveredAmount,
            Guid recoveryTypeId,
            string recoveryDescription,
            decimal netLoss,
            string accountImpacted
            )
        {
            return new LossManagement
            {
                RiskEventId = riskEventId,
                GrossLossValue = grossLossValue,
                TotalRecoveredAmount = totalRecoveredAmount,
                RecoveryDate = recoveryDate,
                RecoveredAmount = recoveredAmount,
                RecoveryTypeId = recoveryTypeId,
                RecoveryDescription = recoveryDescription,
                NetLoss = netLoss,
                AccountImpacted = accountImpacted
            };
        }

    }
}
