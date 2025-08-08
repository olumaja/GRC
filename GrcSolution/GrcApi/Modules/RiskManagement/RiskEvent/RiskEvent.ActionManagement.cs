using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class ActionManagement : AuditEntity
    {
        public enum ActionState
        {
            Open,
            Pending,
            Closed
        }
        private ActionManagement() { }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid RiskEventId { get; private set; }

        public string Action { get; private set; } = null!;

        public string ActionOwner { get; private set; } = null!;

        public DateOnly ActionResolutionDate { get; private set; }

        public string ActionProgress { get; private set; } = null!;

        public ActionState ActionStatus { get; private set; } = ActionState.Open;

        public static ActionManagement Create(
            Guid riskEventId,
            string action,
            string actionOwner,
            DateOnly actionResolutionDate,
            string actionProgress,
            ActionState actionStatus
            )
        {
            return new ActionManagement
            {
                RiskEventId = riskEventId,
                Action = action,
                ActionOwner = actionOwner,
                ActionResolutionDate = actionResolutionDate,
                ActionProgress = actionProgress,
                ActionStatus = actionStatus
            };
        }

        public void UpdateActionProgressAndActionState(string actionProgress, ActionState actionStatus)
        {
            ActionProgress = actionProgress;
            ActionStatus = actionStatus;
        }
       
    }
}
