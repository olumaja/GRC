using Arm.GrcApi.Modules.Shared;

using Newtonsoft.Json;

using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

namespace Arm.GrcTool.Domain.RiskControlSelfAssessment
{
    public class DocumentRSCAProcess : AuditEntity
    {
        public enum Stage
        {
            RiskManagementEnterTestToBeApplied,
            RiskChampionInitiateRCSA,
            RiskChampionHeadInitiateRCSA,
            RiskChampionReviewTestApplied,
            RiskChampionHeadReviewTestApplied,
            RiskManagementFinal,
            End
        }

        public Guid Id { get; init; } = Guid.NewGuid();

        public Guid RiskControlSelfAssessmentUnitId { get; private set; }

        [JsonIgnore]
        public RiskControlSelfAssessmentUnit RiskControlSelfAssessmentUnit { get; private set; } = null!;

        public Stage RCSAStage { get; private set; }
        public RCSAStatus Status { get; private set; } = RCSAStatus.Pending;
        public string? Comment { get; private set; }

        public List<ProcessInherentRiskControl> ProcessInherentRiskControls { get; set; } = new();

        [JsonIgnore]
        public List<DocumentRSCAProcessLog> DocumentRSCAProcessLogs { get; private set; } = new();

        public static DocumentRSCAProcess Create(Guid RiskControlSelfAssessmentUnitId, Stage stage) 
        {
            return new DocumentRSCAProcess
            {
                RiskControlSelfAssessmentUnitId = RiskControlSelfAssessmentUnitId,
                RCSAStage = stage
            };
        }

        public static DocumentRSCAProcess Create(Stage stage)
        {
            return new DocumentRSCAProcess
            {
                RCSAStage = stage
            };
        }

        public void UpdateApprovalStatus(RCSAStatus status, string? comment = null)
        {
            Comment = comment ?? string.Empty;
            Status = status;
        }

        public void UpdateStage(Stage stage)
        {
            RCSAStage = stage;
        }
    }
}
