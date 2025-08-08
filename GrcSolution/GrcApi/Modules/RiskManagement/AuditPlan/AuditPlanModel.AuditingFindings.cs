using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class AuditFindings : AuditEntity
    {
        public Guid Id { get; set; }
        public Guid WorkerPaperId { get; set; }
        [ForeignKey(nameof(WorkerPaperId))]
        public WorkPaper WorkPaper { get; set; }
        public string? Team { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ActionToResolve { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ActionToPreventReoccurrence { get; set; }
        public DateTime ActionDueDate { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ActionOwner { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ActionOwnerUnit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Pending;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; set; }
        public static AuditFindings Create(
            Guid workPaperId, string team, string actionToResolve, string actionToPreventReoccurrence, DateTime actionDueDate, string actionOwner,
            string actionOwnerUnit
        )
        {
            return new AuditFindings
            {
                WorkerPaperId = workPaperId,
                Team = team,
                ActionToResolve = actionToResolve,
                ActionToPreventReoccurrence = actionToPreventReoccurrence,
                ActionDueDate = actionDueDate,
                ActionOwner = actionOwner,
                ActionOwnerUnit = actionOwnerUnit
            };

        }
        public void UpdateAuditFindings(Guid id, Guid workerPaperId, string actionToResolve, string actionToPreventReoccurrence, DateTime actionDueDate, string actionOwner,
           string actionOwnerUnit
       )
        {
            Id = id;
            WorkerPaperId = workerPaperId;
            ActionToResolve = actionToResolve;
            ActionToPreventReoccurrence = actionToPreventReoccurrence;
            ActionDueDate = actionDueDate;
            ActionOwner = actionOwner;
            ActionOwnerUnit = actionOwnerUnit;
            Status = BusinessRiskRatingStatus.Completed;

        }

        public void ApproveFindingStatus(string? team)
        {
            Team = team;
            Status = BusinessRiskRatingStatus.Approved;
        }

        public void RejectFindingStatus(string? team, string reason)
        {
            Team = team;
            ReasonForRejection = reason;
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }

}
