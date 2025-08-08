using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public enum IssueRating
    {
        Low = 1,
        Medium,
        High,
        Very_High,
        Very_Low,
        None
    }

    public class WorkPaper : AuditEntity
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid AuditProgramId { get; private set; }
        [ForeignKey(nameof(AuditProgramId))]
        public AuditProgramAuditExecution AuditProgramAuditExecution { get; set; }
        public string? Team { get; private set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Reference { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Reoccurrence { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ExceptionsNoted { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string IssueSummary { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string RootCause { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Impact { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string ReviewResult { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Recommendation { get; private set; }
        public IssueRating IssueRating { get; private set; }
        public bool IsAuditFindingInitiated { get; set; } = false;
        public AuditFindings AuditFindings { get; set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Pending;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; set; }
       
        public static WorkPaper Create(
        Guid auditProgramId,string team, string reference, string reoccurence, string exceptionsNoted,
        string issueSummary, string rootCause, string impact, string recommendation, IssueRating issueRating, string reviewResult
        )
        {
            return new WorkPaper
            {
                AuditProgramId = auditProgramId,
                Team = team,
                Reference = reference,
                Reoccurrence = reoccurence,
                ExceptionsNoted = exceptionsNoted,
                IssueSummary = issueSummary,
                RootCause = rootCause,
                Impact = impact,
                Recommendation = recommendation,
                IssueRating = issueRating,
                ReviewResult = reviewResult

            };
        }

        public void UpdateWorkPaper(Guid id, Guid auditProgramId, string reference, string reoccurence, string exceptionsNoted,
       string issueSummary, string rootCause, string impact, string recommendation, IssueRating issueRating, string reviewResult
       )
        {
            Id = id;
            AuditProgramId = auditProgramId;
            Reference = reference;
            Reoccurrence = reoccurence;
            ExceptionsNoted = exceptionsNoted;
            IssueSummary = issueSummary;
            RootCause = rootCause;
            Impact = impact;
            Recommendation = recommendation;
            IssueRating = issueRating;
            ReviewResult = reviewResult;
            Status = BusinessRiskRatingStatus.Completed;
        }

        public void ApproveWorkPaperStatus(string? team)
        {
            Team = team;
            Status = BusinessRiskRatingStatus.Approved;
        }

        public void RejectWorkPaperStatus(string? team, string reason)
        {
            Team = team;
            ReasonForRejection = reason;
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }

}
