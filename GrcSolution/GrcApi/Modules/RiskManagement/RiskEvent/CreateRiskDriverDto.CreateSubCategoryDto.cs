using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateRiskDriverSubCategoryDto(Guid RiskDriverCategoryId,  string Name);
}
