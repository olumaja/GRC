using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class CASPLog : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        [ForeignKey(nameof(LogManagement))]
        public Guid LogManagementId { get; private set; }
        public string? EventName { get; private set; }
        public string? ResponsibleStaff { get; private set; }
        public string? SourceIPAddress { get; private set; }
        public string? SourceHostName { get; private set; }
        public string? SourceLocation { get; private set; }
        public string? SourceUserName { get; private set; }
        public string? SourceFileName { get; private set; }
        public string? SourceDevice { get; private set; }
        public string? DestinationEmailAddress { get; private set; }
        public string? ObjectIdentifier { get; private set; }
        public string? Application { get; private set; }
        public string? Observation { get; private set; }
        public string? SecurityTool { get; private set; }
        public LogManagement LogManagement { get; set; }
        public static CASPLog Create(NewCASPReq req)
        {
            return new CASPLog
            {
                LogManagementId = req.LogManagementModelId,
                EventName = req.EventName,
                ResponsibleStaff = req.ResponsibleStaff,
                SourceIPAddress = req.SourceIPAddress,
                SourceHostName = req.SourceHostName,
                SourceLocation = req.SourceLocation,
                SourceUserName = req.SourceUserName,
                DestinationEmailAddress = req.DestinationEmailAddress,
                SourceFileName = req.SourceFileName,
                SourceDevice = req.SourceDevice,
                ObjectIdentifier = req.ObjectIdentifier,
                Application = req.Application,
                Observation = req.Observation,
                SecurityTool = req.SecurityTool
            };
        }
    }
}
