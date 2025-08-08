using Arm.GrcApi.Modules.Shared;

using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;

using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

namespace Arm.GrcTool.Domain.RiskControlSelfAssessment
{
    public class RiskControlSelfAssessmentUnit : AuditEntity
    {
        public enum RCSAStatus
        {
            Pending = 0,
            Approved,
            Rejected,
            Treated
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        
        public Guid RiskControlSelfAssessmentId { get; private set; }

        public virtual RiskControlSelfAssessment RiskControlSelfAssessment { get; private set; } = null!;

        [ForeignKey(nameof(Unit))]
        public Guid UnitId { get; private set; }

        public virtual Unit Unit { get; private set; } = null!;
        public string? Requester { get; private set; }
        public string? Approval { get; private set; }
        public DateTime? ApprovalDate { get; private set; }

        [JsonIgnore]
        public DocumentRSCAProcess DocumentRSCAProcess { get; private set; } = null!;

        public static RiskControlSelfAssessmentUnit Create(Guid unitId, DocumentRSCAProcess documentRSCAProcess)
        {
            return new RiskControlSelfAssessmentUnit
            {
                UnitId = unitId,
                DocumentRSCAProcess = documentRSCAProcess
            };
        }

        public static RiskControlSelfAssessmentUnit Create(Guid unitId)
        {
            return new RiskControlSelfAssessmentUnit
            {
                UnitId = unitId,
                DocumentRSCAProcess = DocumentRSCAProcess.Create(Stage.RiskChampionInitiateRCSA)
            };
        }

        public void AddRequester(string? requester)
        {
            Requester = requester;
        }

        public void AddApproval(string? approval)
        {
            Approval = approval;
            ApprovalDate = DateTime.Now;
        }
    }
}
