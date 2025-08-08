using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BIAUnitProcessDetails;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace GrcApi.Modules.RiskManagement.BIA
{
    public record GetBIAUnitDto(
        Guid BIAUnitId,  string UnitName, string? requester, string? Approval, DateTime? ApprovalDate, string Comment,
        BIAStatus Status, BIAStage Stage,
        List<GetBIAProcessDetailsDto> ProcessDetials
    );

    public record GetBIAProcessDetailsDto(
         string BusinessProcessDescriptionSummary,
         Guid ProcessId,
          string ProcessName,
          string FinancialImpact,
          string CustomerExperience,
          string OtherProcessesOrPeople,
          string RegulatoryOrLegal,
          string Reputation,
          string ThirdPartyImpact,
          string MinimumBusinessContinuityObjective,
          string MaximumAllowableOutage,
          string RecoveryTimeObjective,
          string RecoveryPointObjective,
         BIAPriority Priority,
          string ApplicationsUsedToRunProcess,
          string KeyVendors,
          string AnyNonElectronicVitalRecords,
          string AlternativeWorkarounds,
          string PrimaryRecoverStrategyAndSolution,
         BIAPeakPeriod PeakPeriod,
          string RemoteWorking,
         //List<ResponsibleBusinessUnit> ResponsibleBusinessUnits,
         List<BusinessUnitsToRunProcess> BusinessUnitsToRunProcess
    );
    
    public record ResponsibleBusinessUnit(Guid UnitId,  string ResponsibleBusinessUnitName);

    public record BusinessUnitsToRunProcess(Guid UnitId,  string BusinessUnitsToRunProcessName);

}
