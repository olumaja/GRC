using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class GetAuditProgram
    {
        public Guid AuditProgramId { get; set; }

        public string Team { get; set; }
        public string Process { get; set; }

        public string SubProcess { get; set; }

        public string RiskDescription { get; set; }

        public string ControlDescription { get; set; }

        public string ControlObjectives { get; set; }

        public string ReviewProcedure { get; set; }

        public string InformationRequired { get; set; }
        public string Comment { get; set; }
        public string ReasonForRejection { get; set; }
        public string Status { get; set; }
        public bool IsWorkPaperInitiated { get; set; }
    };

    public record GetAuditProgramResponse(Guid CommenceEngagementAuditexecutionId, List<GetAuditProgram> AuditPrograms);
}
