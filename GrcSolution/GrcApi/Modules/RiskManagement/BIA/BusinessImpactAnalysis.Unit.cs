using Arm.GrcApi.Modules.Shared;

using GrcApi.Modules.Shared;

using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcTool.Domain.BusinessImpactAnalysis
{
    public class BusinessImpactAnalysisUnit : AuditEntity
    {
        public enum BIAStatus
        {
            Pending = 0,
            Approved,
            Rejected,
            Treated
        }

        public enum BIAStage
        {
            RiskManagementFinal,
            RiskChampionInitiateBIA,
            RiskChampionHeadInitiateBIA,
            End
        }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid BusinessImpactAnalysisId { get; private set; }

        [JsonIgnore]
        public virtual BusinessImpactAnalysis BusinessImpactAnalysis { get; private set; } = null!;

        [ForeignKey(nameof(Unit))]
        public Guid UnitId { get; private set; }

        public virtual Unit Unit { get; private set; } = null!;

        public BIAStatus Status { get; private set; }

        public BIAStage Stage { get; private set; } = BIAStage.RiskChampionInitiateBIA;

        public string? Comment { get; private set; }
        public string? Requester { get; private set; }
        public string? Approval { get; private set; }
        public DateTime? ApprovalDate { get; private set; }

        public virtual List<BIAUnitProcessDetails> BIAUnitProcessDetails { get; private set; } = new();

        [JsonIgnore]
        public virtual List<BusinessImpactAnalysisUnitLog> BusinessImpactAnalysisUnitLogs { get; private set; } = new();

        public static BusinessImpactAnalysisUnit Create(
            Guid unitId
            )
        {
            var newBusinessImpactAnalysisUnit = new BusinessImpactAnalysisUnit { UnitId = unitId };
            newBusinessImpactAnalysisUnit.UpdateBusinessImpactAnalysisUnitLog();
            return newBusinessImpactAnalysisUnit;
        }

        public void AddBIAUnitProcessDetails(List<BIAUnitProcessDetails> bIAUnitProcessDetails)
        {
            BIAUnitProcessDetails = bIAUnitProcessDetails;
        }

        /// <summary>
        /// Updates bia status and comment
        /// </summary>
        /// <param name="status"></param>
        /// <param name="comment"></param>
        public void UpdateStatus(BIAStatus status, string comment = null)
        {
            Status = status;
            Comment = comment;
        }

        /// <summary>
        /// Updates bia stage
        /// </summary>
        /// <param name="bIAStage"></param>
        public void UpdateStage(BIAStage bIAStage)
        {
            Stage = bIAStage;
        }

        public void UpdateBusinessImpactAnalysisUnitLog()
        {
            BusinessImpactAnalysisUnitLogs.Add(BusinessImpactAnalysisUnitLog.Create(this.ToJsonString()));
        }

        public BusinessImpactAnalysisUnitLog CreateBusinessImpactAnalysisUnitLog()
        {
            return BusinessImpactAnalysisUnitLog.Create(this.ToJsonString(), Id);
        }

        public void AddRequester(string? requester) { 
            Requester = requester;
        }

        public void AddApproval(string? approval)
        {
            Approval = approval;
            ApprovalDate = DateTime.Now;
        }
    }
}
