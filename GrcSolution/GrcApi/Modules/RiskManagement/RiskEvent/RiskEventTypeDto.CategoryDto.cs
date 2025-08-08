using Arm.GrcTool.Domain.Risk;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement
{
    public record RiskEventTypeCategoryDto(Guid id,  string riskEventTypeCategoryName, IList<RiskEventTypeSubcategoryDto> Subcategories);
}
