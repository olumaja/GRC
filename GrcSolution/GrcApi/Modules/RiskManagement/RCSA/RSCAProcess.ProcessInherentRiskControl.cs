using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;

using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcTool.Domain.RiskControlSelfAssessment
{
    public class ProcessInherentRiskControl : AuditEntity
    {
        public enum PIRCActionState 
        {
            Open,
            Pending,
            Complete
        }       
        public Guid Id { get; init; } = Guid.NewGuid(); 
        public Guid ProcessId { get; private set; }
        public string? InherentRisk { get; private set; }
        public string? Control { get; private set; }
        public string? TestToApply { get; private set; }
        public Guid DocumentRCSAProcessId { get; private set; }
        
        [JsonIgnore]
        public DocumentRSCAProcess DocumentRCSAProcess { get; private set; }

        public string? TestResult { get; private set; }

        public Guid? TestResultAttachmentId { get; private set; }

        public ModuleType TestResultAttachmentModuleType { get; private set; } = ModuleType.RiskManagement;

        public string? ColourEffectiveness { get; private set; }

        public string? ResidualRisks { get; private set; }

        public int? ResidualRiskRating { get; private set; }

        public string? ResidualRiskLevel { get; private set; }

        public string? CorrectiveActions { get; private set; }

        public string? ActionOwnerUserName { get; private set; }

        public DateOnly? TimeLine {  get; private set; }

        public string? Comment { get; private set; }

        public string? ActionProgress { get; private set; } = null!;
        public PIRCActionState ActionStatus { get; private set; } = PIRCActionState.Open;

        public static ProcessInherentRiskControl Create(Guid processId, Guid documentRCSAProcessId, string inherentRisk, string control)
        {
            return new ProcessInherentRiskControl
            {
                ProcessId = processId,
                DocumentRCSAProcessId = documentRCSAProcessId,
                InherentRisk = inherentRisk,
                Control = control
            };
        }

        public void UpdateRiskRatingInformation(
            string testResult,
            Guid? testResultAttachmentId,
            string colourEffectiveness,
            string residualRisks,
            int residualRiskRating,
            string residualRiskLevel,
            string correctiveActions,
            string actionOwnerUserName,
            DateOnly timeLine
            )
        {
            TestResult = testResult;
            TestResultAttachmentId = testResultAttachmentId;
            ColourEffectiveness = colourEffectiveness;
            ResidualRisks = residualRisks;
            ResidualRiskRating = residualRiskRating;
            ResidualRiskLevel = residualRiskLevel;
            CorrectiveActions = correctiveActions;
            ActionOwnerUserName = actionOwnerUserName;
            TimeLine = timeLine;
        }

        public void ApplyTest(string testToApply)
        {
            TestToApply = testToApply;
        }

        public void UpdateActionProgressAndActionState(string actionProgress, PIRCActionState actionStatus)
        {
            ActionProgress = actionProgress;
            ActionStatus = actionStatus;
        }
    }
}
