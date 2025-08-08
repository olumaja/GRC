using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace GrcApi.Modules.RiskManagement.BIA
{
    public record GetAllBIAForRiskChampionDto(
        Guid BusinessImpactAnalysisUnitId,
        Guid BusinessImpactAnalysisId,
         string UnitName, Guid UnitId,
        BIAStatus Status,
        DateTime CreatedDate,
        DateOnly PeriodFrom,
        DateOnly PeriodTo,
        DateOnly StartDate,
        DateOnly EndDate
    );
    
}
