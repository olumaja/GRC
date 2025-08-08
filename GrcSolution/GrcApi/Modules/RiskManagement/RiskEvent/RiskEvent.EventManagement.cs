using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class RiskEventManagement : AuditEntity
    {
        private RiskEventManagement() { }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid RiskEventId { get; private set; }

        public Guid EventTypeId { get; private set; }

        public Guid EventCategoryId { get; private set; }

        public Guid EventSubCategoryId { get; private set; }

        public Guid BoundaryEventId { get; private set; }

        public Guid RiskDriverId { get; private set; }

        public Guid RiskDriverCategoryId { get; private set; }

        public Guid RiskDriverSubCategoryId { get; private set; }

        public string RiskDriverDescription { get; private set; } = null!;

        public static RiskEventManagement Create(
            Guid riskEventId,
            Guid eventTypeId,
            Guid eventCategoryId,
            Guid eventSubCategoryId,
            Guid boundaryEventId,
            Guid riskDriverId,
            Guid riskDriverCategoryId,
            Guid riskDriverSubCategoryId,
            string riskDriverDescription
            )
        {
            return new RiskEventManagement
            {
                RiskEventId = riskEventId,
                EventTypeId = eventTypeId,
                EventCategoryId = eventCategoryId,
                EventSubCategoryId = eventSubCategoryId,
                BoundaryEventId = boundaryEventId,
                RiskDriverId = riskDriverId,
                RiskDriverCategoryId = riskDriverCategoryId,
                RiskDriverSubCategoryId = riskDriverSubCategoryId,
                RiskDriverDescription = riskDriverDescription
            };
        }
    }
}
