
using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Infrastructure.Data
{
    public class Email : AuditEntity
    {
        public Guid EmailId { get; private set; }
        public string To { get; private set; } = null;
        public string? CC { get; private set; } = null;
        public string Subject { get; private set; } = null;
        public string Message { get; private set; } = null;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? DeliveryDate { get; private set; } = null;
        public ModuleType ModuleItemType { get; private set; }
        public Guid ModuleItemId { get; private set; }
        public bool IsMessageSent { get; private set; } = false;          
        public Email Create( 
             Guid emailId,
             string to,
             string cc,
             string subject,
             string message,
             ModuleType moduleItemType,
             Guid moduleItemId,
             DateTime createdAt,
             DateTime? deliveryDate
            )
        {
            return new Email
            {
                EmailId = emailId,
                To = to,
                CC = cc,
                Subject = subject,
                Message = message,
                ModuleItemType = moduleItemType,
                ModuleItemId = moduleItemId,
                CreatedAt = createdAt,
                DeliveryDate = deliveryDate
            };
        }
        public void UpdateDeliveryStatus(bool status)
        {
            DeliveryDate = DateTime.Now;
            IsMessageSent = status;
        }
    }


}
