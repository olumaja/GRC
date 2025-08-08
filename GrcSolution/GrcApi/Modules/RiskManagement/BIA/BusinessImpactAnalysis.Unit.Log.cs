using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.BusinessImpactAnalysis
{
    public class BusinessImpactAnalysisUnitLog : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid BusinessImpactAnalysisUnitId { get; private set; }

        public virtual BusinessImpactAnalysisUnit BusinessImpactAnalysisUnit { get; private set; } = null!;

        public string BusinessImpactAnalysisUnitJson { get; private set; } = null!;

        public static BusinessImpactAnalysisUnitLog Create(string json)
        {
            return new BusinessImpactAnalysisUnitLog
            {
                BusinessImpactAnalysisUnitJson = json
            };
        }

        public static BusinessImpactAnalysisUnitLog Create(string json, Guid businessImpactAnalysisUnitId)
        {
            return new BusinessImpactAnalysisUnitLog
            {
                BusinessImpactAnalysisUnitJson = json,
                BusinessImpactAnalysisUnitId = businessImpactAnalysisUnitId
            };
        }
    }
}
