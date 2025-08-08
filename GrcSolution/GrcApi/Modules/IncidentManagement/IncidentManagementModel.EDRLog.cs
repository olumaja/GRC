using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class EDRLog : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        [ForeignKey(nameof(LogManagement))]
        public Guid LogManagementId { get; private set; }
        public string? EventName { get; private set; }
        public string? EventDescription { get; private set; }
        public string? ConfigurationDetail { get; private set; }
        public string? SourceIPAddress { get; private set; }
        public string? SourceFQDN { get; private set; }
        public string? SourceFileName { get; private set; }
        public string? Severity { get; private set; }
        public string? DestinationFQDN { get; private set; }
        public string? DestinationUserName { get; private set; }
        public string? DestinationIPAddress { get; private set; }
        public string? DestinationHostName { get; private set; }
        public string? EventId { get; private set; }
        public string? SecurityTool { get; private set; }
        public string? ActionTakenByUs { get; private set; }
        public string? Technique { get; private set; }
        public string? FileHash { get; private set; }
        public string? Observation { get; private set; }
        public LogManagement LogManagement { get; set; }

        public static EDRLog Create(LogEDRRequest request)
        {
            return new EDRLog
            {
                LogManagementId = request.LogManagementId,
                EventName = request.EventName,
                EventDescription = request.EventDescription,
                EventId = request.EventID,
                ConfigurationDetail = request.ConfigurationDetails,
                SourceIPAddress = request.SourceIPAddress,
                Severity = request.Severity,
                DestinationFQDN = request.DestinationFQDN,
                SourceFileName = request.SourceOrFileName,
                DestinationUserName = request.DestinationUserName,
                DestinationIPAddress = request.DestinationIPAddress,
                DestinationHostName = request.DestinationHostName,
                SecurityTool = request.SecurityTools,
                ActionTakenByUs = request.ActionTakenByCS,
                Technique = request.Technique,
                FileHash = request.FileHash,
                Observation = request.Observation
            };
        }
    }
}
