using System.ComponentModel.DataAnnotations;

namespace Arm.GrcTool.Domain.RiskEvent
{
    public record RiskEventRiskDriverCategoryDto(Guid Id,  string RiskEventRiskCategoryName, IList<RiskEventRiskDriverSubcategoryDto> Subcategories);
}
