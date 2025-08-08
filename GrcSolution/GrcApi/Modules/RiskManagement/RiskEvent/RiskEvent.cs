using Arm.GrcApi.Modules.Shared;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public class RiskEvent : AuditEntity
    {
        public enum Status {
            Pending,
            Treated
        }
        private RiskEvent() 
        { 
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateOnly DateOfIdentification { get; private set; }
        public DateOnly DateOfOccurence { get; private set; }
        public string Description { get; private set; } = null!;
        public decimal EstimatedLoss { get; private set; }
        public Guid BusinessEntityId { get; private set; }
        public Guid DepartmentId { get; private set; }
        public Guid UnitId { get; private set; }
        public Status AssesmentStatus { get;private set; } = Status.Pending;
        public string ReportedByUsername { get; private set; } = null!;
        public string RiskEventDescription { get; private set; } = null!;
        public string? Requester { get; set; }
        public string? Approval { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public static RiskEvent Create(
            DateOnly dateOfIdentification,
            DateOnly dateOfOcurrence,
            string description,
            decimal estimatedLoss,
            Guid locationId,
            Guid departmentId,
            Guid unitId,
            string reportedByUsername,
            string initiator
        ) 
        {
            return new RiskEvent {  
                DateOfIdentification = dateOfIdentification,
                DateOfOccurence = dateOfOcurrence,
                Description = description, 
                EstimatedLoss = estimatedLoss,
                BusinessEntityId = locationId,
                DepartmentId = departmentId,
                UnitId = unitId,
                ReportedByUsername = reportedByUsername,
                RiskEventDescription = description,
                Requester = initiator
            };
        }

        public void SetRiskEventStatus(Status status)
        {
            AssesmentStatus = status;
        }
        
    }
}
