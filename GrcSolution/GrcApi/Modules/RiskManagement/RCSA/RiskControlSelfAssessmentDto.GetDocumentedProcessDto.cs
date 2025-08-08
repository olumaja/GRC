using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

namespace Arm.GrcTool.Domain
{
    public record GetDocumentedProcessDto
    (
         Guid Id, Guid RiskControlSelfAssessmentUnitId, Stage RCSAStage, RCSAStatus RCSAStatus,  string Comment,
         string? Requester, string? Approval, DateTime? ApprovalDate, List<ProcessInherentRiskControlDto> InherentRiskControls
    );
}
