using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GrcApi.Modules.IncidentManagement;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class DLPLog : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        [ForeignKey(nameof(LogManagement))]
        public Guid LogManagementId { get; private set; }
        public string? DLPPolicy { get; private set; }
        public string? DLPRuleMatch { get; private set; }
        public string? DLPRuleAction { get; private set; }
        public string? ActionTaken { get; private set; }
        public string? ResponsibleStaff { get; private set; }
        public LogManagement LogManagement { get; set; }

        public static DLPLog Create(LogDLPRequest request)
        {
            return new DLPLog
            {
                LogManagementId = request.LogManagementId,
                DLPPolicy = request.DLPPolicy,
                DLPRuleMatch = request.DLPRuleMatched,
                DLPRuleAction = request.DLPRuleAction,
                ActionTaken = request.ActionTaken,
                ResponsibleStaff = request.ResponsibleStaff
            };
        }
    }
}
