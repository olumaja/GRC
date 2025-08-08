using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskControlSelfAssessment
{
    public class DocumentRSCAProcessLog : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid DocumentRSCAProcessId { get; private set; }

        public DocumentRSCAProcess DocumentRSCAProcess { get; private set; } = null!;

        public string DocumentRSCAProcessJsonDump { get; private set; } = null!;

        public static DocumentRSCAProcessLog Create(Guid documentRSCAProcessId, string documentRSCAProcessJsonDump)
        {
            return new DocumentRSCAProcessLog
            {
                DocumentRSCAProcessId = documentRSCAProcessId,
                DocumentRSCAProcessJsonDump = documentRSCAProcessJsonDump
            };
        }
    }
}
