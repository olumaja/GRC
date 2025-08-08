using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace GrcApi.Modules.RiskManagement.ActionTracker
{
    public class ViewEventDescriptionDTO
    {
        public Guid ActionManagementId { get; set; }
        public DateOnly DueDate { get; set; }
        
        public string? ActionOwner { get; set; }
        
        public string? CorrectiveActions { get; set; }
        
        public string? ActionProgress { get; set; }
        
        public string Status { get; set; }
        public int NoOfDaysLeft { get; set; }
        
        public string? EventDescription { get; set; }
    }
}
