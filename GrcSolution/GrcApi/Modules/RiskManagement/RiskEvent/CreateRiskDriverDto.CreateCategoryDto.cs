using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateRiskDriverCategoryDto(Guid RiskDriverId,  string Name);
}
