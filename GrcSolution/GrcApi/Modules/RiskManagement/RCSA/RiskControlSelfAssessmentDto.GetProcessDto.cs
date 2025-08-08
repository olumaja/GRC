using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement
{
    public record RiskControlSelfAssessmentGetProcessDto(Guid Id,  string Name, Guid UnitId );
    
}
