using Arm.GrcApi.Modules.RiskManagement.PRA;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.PRA
{
    public record GetAllProductRiskAssessentDto(
        Guid ProductRiskAssessmentId,
         string BusinessName,
         string DepartmentName,
         string UnitName,
        PRAStatus Status,
        PRAStage Stage,
        DateTime DateInitiated
    );

    public record ProductRiskAssessentDto(
        Guid ProductRiskAssessmentId,
        Guid BusinessId,
        Guid DepartmentId,
        Guid UnitId,
        PRAStatus Status,
        PRAStage Stage,
        DateTime DateInitiated
    );
}
