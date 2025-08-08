using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class SIEMLog : AuditEntity2
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
        public string? Observation { get; private set; }
        public string? SecurityTool { get; private set; }
        public LogManagement LogManagement { get; set; }

        public static SIEMLog Create(SIEMLogRequest siemRequest)
        {
            return new SIEMLog
            {
                LogManagementId = siemRequest.LogMgtId,
                EventName = siemRequest.EventName,
                EventDescription = siemRequest.EventDescription,
                ConfigurationDetail = siemRequest.ConfigurationDetail,
                ConfigurationObject = siemRequest.ConfigurationObject,
                SourceIPAddress = siemRequest.SourceIPAddress,
                SourcePort = siemRequest.SourcePort,
                SourceHostName = siemRequest.SourceHostName,
                SourceFQDN = siemRequest.SourceFQDN,
                SourceUserName = siemRequest.SourceUserName,
                DestinationIpAddress = siemRequest.DestinationIpAddress,
                DestinationPort = siemRequest.DestinationPort,
                DestinationHostName = siemRequest.DestinationHostName,
                DestinationFQDN = siemRequest.DestinationFQDN,
                DestinationUserName = siemRequest.DestinationUserName,
                NATIPAddress = siemRequest.NATIPAddress,
                NATPort = siemRequest.NATPort,
                MaliciousReputation = siemRequest.MaliciousReputation,
                EventId = siemRequest.EventId,
                Observation = siemRequest.Observation,
                SecurityTool = siemRequest.SecurityTool
            }; 
        }
    }
}
