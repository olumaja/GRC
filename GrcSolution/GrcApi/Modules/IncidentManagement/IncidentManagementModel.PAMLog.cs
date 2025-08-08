using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class PAMLog : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        [ForeignKey(nameof(LogManagement))]
        public Guid LogManagementId { get; private set; }
        public string? EventName { get; private set; }
        public string? IncidentDescription { get; private set; }
        public string? CorrectiveActionCarriedOut { get; private set; }
        public DateTime? DatecarriedOut { get; private set; }
        public LogManagement LogManagement { get; set; }

        public static PAMLog Create(NewPAMReq req)
        {
            return new PAMLog
            {
                LogManagementId = req.LogManagementModelId,
                IncidentDescription = req.EventDescription,
                CorrectiveActionCarriedOut = req.CorrectiveActionCarriedOut,
                DatecarriedOut = req.DateCarriedOut,
            };
        }
    }
}
