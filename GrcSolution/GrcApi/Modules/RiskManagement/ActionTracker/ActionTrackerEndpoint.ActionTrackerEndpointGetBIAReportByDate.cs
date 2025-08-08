using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BIAUnitProcessDetails;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 27/12/2023
      * Development Group: GRCTools
      * The endpoint get BIA report within specified date range
     */
    public class ActionTrackerEndpointGetBIAReportByDate
    {
        /// <summary>
        /// The endpoint get BIA report within specified date range
        /// </summary>
        /// <param name="unitRepo"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="biaRepo"></param>
        /// <param name="biaUnitRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            DateOnly startDate, DateOnly endDate, IRepository<BusinessImpactAnalysis> biaRepo, IRepository<BusinessImpactAnalysisUnit> biaUnitRepo,
            IRepository<Unit> unitRepo, IRepository<RSCAProcess> processRepo, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                if (startDate == default || endDate == default)
                {
                    return TypedResults.BadRequest("Enter valid date format");
                }

                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Enter valid date range");
                }

                var units = await unitRepo.GetAllAsync();
                var processes = await processRepo.GetAllAsync();
                var response = new List<BIAReportDto>();
                var biaReport = biaRepo.GetContextByConditon(b => b.StartDate >= startDate && b.EndDate <= endDate)
                                       .Include(b => b.BusinessImpactAnalysisUnits)
                                       .ThenInclude(p => p.BIAUnitProcessDetails)
                                       .ThenInclude(d => d.BusinessUnitsToRunProcess)
                                       .OrderBy(b => b.CreatedOnUtc)
                                       .ToList();

                foreach (var bia in biaReport)
                {
                    foreach (var biaUnit in bia.BusinessImpactAnalysisUnits)
                    {
                        var unitName = units.FirstOrDefault(b => b.Id == biaUnit.UnitId)?.Name;

                        if (biaUnit.BIAUnitProcessDetails.Count > 0)
                        {
                            foreach (var biaUnitProcess in biaUnit.BIAUnitProcessDetails)
                            {
                                var processName = processes.FirstOrDefault(p => p.Id == biaUnitProcess.ProcessId)?.Name;
                                var responsibleBusinessUnitIds = biaUnitProcess.BusinessUnitsToRunProcess
                                                                            .Select(r => r.Id);
                                var responsibleBusinessUnits = units.Where(u => responsibleBusinessUnitIds.Contains(u.Id)).Select(u => u.Name);
                                string priority = "";
                                string peakPeriod = "";
                                if (biaUnitProcess.Priority == BIAPriority.Critical)
                                {
                                    priority = "Critical";
                                }
                                if (biaUnitProcess.Priority == BIAPriority.NonCritical)
                                {
                                    priority = "NonCritical";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.Daily)
                                {
                                    peakPeriod = "Daily";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.Weekly)
                                {
                                    peakPeriod = "Weekly";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.Monthly)
                                {
                                    peakPeriod = "Monthly";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.Quaterly)
                                {
                                    peakPeriod = "Quarterly";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.Bi_Annually)
                                {
                                    peakPeriod = "Bi_Annually";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.Yearly)
                                {
                                    peakPeriod = "Yearly";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.EOD)
                                {
                                    peakPeriod = "EOD";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.EOM)
                                {
                                    peakPeriod = "EOM";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.EOQ)
                                {
                                    peakPeriod = "EOQ";
                                }
                                if (biaUnitProcess.PeakPeriod == BIAPeakPeriod.EOY)
                                {
                                    peakPeriod = "EOY";
                                }

                                response.Add(new BIAReportDto
                                {
                                    DateStarted = bia.StartDate,
                                    EndDate = bia.EndDate,
                                    PeriodFrom = bia.PeriodFrom,
                                    PeriodTo = bia.PeriodTo,
                                    BusinessUnitCount = bia.BusinessImpactAnalysisUnits.Count,
                                    BuinessUnitName = unitName,
                                    Process = processName,
                                    FinancialImpact = biaUnitProcess.FinancialImpact,
                                    CustomerExperience = biaUnitProcess.CustomerExperience,
                                    OtherProcessPeople = biaUnitProcess.OtherProcessesOrPeople,
                                    RegulatoryLegal = biaUnitProcess.RegulatoryOrLegal,
                                    Reputation = biaUnitProcess.Reputation,
                                    ThirdPartyImpact = biaUnitProcess.ThirdPartyImpact,
                                    MBCO = biaUnitProcess.MinimumBusinessContinuityObjective,
                                    MAO = biaUnitProcess.MaximumAllowableOutage,
                                    RTO = biaUnitProcess.RecoveryTimeObjective,
                                    RPO = biaUnitProcess.RecoveryPointObjective,
                                    Priority = priority,
                                    ResponsibleBusinessUnit = string.Join(" ", responsibleBusinessUnits),
                                    ApplicationUsedToRunProcess = biaUnitProcess.ApplicationsUsedToRunProcess,
                                    KeyVendors = biaUnitProcess.KeyVendors,
                                    AnyNonElectronicVitalRecord = biaUnitProcess.AnyNonElectronicVitalRecords,
                                    AlternativeWorkaround = biaUnitProcess.AlternativeWorkarounds,
                                    PrimaryRecoveryStrategy = biaUnitProcess.PrimaryRecoverStrategyAndSolution,
                                    PeakPeriod = peakPeriod,
                                    RemoteWork = biaUnitProcess.RemoteWorking,
                                    Status = biaUnit.Status
                                });
                            }
                        }
                        else
                        {
                            response.Add(new BIAReportDto
                            {
                                DateStarted = bia.StartDate,
                                EndDate = bia.EndDate,
                                PeriodFrom = bia.PeriodFrom,
                                PeriodTo = bia.PeriodTo,
                                Status = biaUnit.Status,
                                BusinessUnitCount = bia.BusinessImpactAnalysisUnits.Count,
                                BuinessUnitName = unitName,
                                Process = null,
                                FinancialImpact = null,
                                CustomerExperience = null,
                                OtherProcessPeople = null,
                                RegulatoryLegal = null,
                                Reputation = null,
                                ThirdPartyImpact = null,
                                MBCO = null,
                                MAO = null,
                                RTO = null,
                                RPO = null,
                                Priority = null,
                                ResponsibleBusinessUnit = null,
                                ApplicationUsedToRunProcess = null,
                                KeyVendors = null,
                                AnyNonElectronicVitalRecord = null,
                                AlternativeWorkaround = null,
                                PrimaryRecoveryStrategy = null,
                                PeakPeriod = null,
                                RemoteWork = null
                            });
                        }
                    }
                }

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
