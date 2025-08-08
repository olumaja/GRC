using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GrcApi.Modules.IncidentManagement;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class FIMLog : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        [ForeignKey(nameof(LogManagement))]
        public Guid LogManagementId { get; private set; }
        public string? EventName { get; private set; }
        public string? EventDescription { get; private set; }
        public string? ConfigurationObject { get; private set; }
        public string? ConfigurationDetail { get; private set; }
        public string? SourceIPAddress { get; private set; }
        public string? SourcePort { get; private set; }
        public string? SourceFQDN { get; private set; }
        public string? SourceHostName { get; private set; }
        public string? SourceUserName { get; private set; }
        public string? DestinationIpAddress { get; private set; }
        public string? DestinationPort { get; private set; }
        public string? DestinationHostName { get; private set; }
        public string? DestinationFQDN { get; private set; }
        public string? DestinationUserName { get; private set; }
        public string? NATIPAddress { get; private set; }
        public string? NATPort { get; private set; }
        public string? MaliciousReputation { get; private set; }
        public string? EventId { get; private set; }
        public string? SecurityTool { get; private set; }
        public string? Observation { get; private set; }
        public LogManagement LogManagement { get; set; }

        public static FIMLog Create(LogFIMRequest request)
        {
            return new FIMLog
            {
                LogManagementId = request.LogManagementId,
                EventName = request.EventName,
                EventDescription = request.EventDescription,
                EventId = request.EventID,
                ConfigurationObject = request.ConfigurationObject,
                ConfigurationDetail = request.ConfigurationDetails,
                SourceIPAddress = request.SourceIPAddress,
                SourcePort = request.SourcePort,
                SourceFQDN = request.SourceFQDN,
                SourceHostName = request.SourceHostName,
                SourceUserName = request.SourceUserName,
                DestinationIpAddress = request.DestinationIPAddress,
                DestinationPort = request.DestinationPort,
                DestinationHostName = request.DestinationHostName,
                DestinationFQDN = request.DestinationFQDN,
                DestinationUserName = request.DestinationUserName,
                NATIPAddress = request.NATIPAddress,
                NATPort = request.NATPort,
                MaliciousReputation = request.MaliciousRepution,
                SecurityTool = request.SecurityTools,
                Observation = request.Observation
            };
        }
    }
}
