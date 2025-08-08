using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;

namespace GrcApi.Modules.RiskManagement.ActionTracker
{
    public class ViewActionItemSummaryDTO
    {
        public Guid ProcessInherentRiskId { get; set; }
        
        public string? Process { get; set; }
        
        public string? InherentRisk { get; set; }
        
        public string? Control { get; set; }
        
        public string? ResidualRisk { get; set; }
        
        public string? ActionProgress { get; set; }
        
        public string Status { get; set; }
        public int NoOfDaysLeft { get; set; }
        
        public string? CorrectiveAction { get; set; }
    }
}
