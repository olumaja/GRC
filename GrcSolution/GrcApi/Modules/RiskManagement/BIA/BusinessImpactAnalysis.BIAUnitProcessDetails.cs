using Arm.GrcApi.Modules.Shared;
using Newtonsoft.Json;

namespace Arm.GrcTool.Domain.BusinessImpactAnalysis
{
    public class BIAUnitProcessDetails : AuditEntity
    {
        public enum BIAPriority
        {
            Critical = 0,
            NonCritical
        }

        public enum BIAPeakPeriod
        {
            Daily = 0,
            Weekly,
            Monthly,
            Quaterly,
            Bi_Annually,
            Yearly,
            EOD,
            EOM,
            EOQ,
            EOY
        }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid BusinessImpactAnalysisUnitId { get; private set; }

        [JsonIgnore]
        public virtual BusinessImpactAnalysisUnit BusinessImpactAnalysisUnit { get; private set; } = null!;

        public Guid ProcessId { get; private set; }

        public string BusinessProcessDescriptionSummary { get; private set; } = null!;

        //public virtual List<BIAUnitProcessDetailsResponsibleBusinessUnit> ResponsibleBusinessUnits { get; private set; } = new();

        public string FinancialImpact { get; private set; } = null!;

        public string CustomerExperience { get; private set; } = null!;

        public string OtherProcessesOrPeople { get; private set; } = null!;

        public string RegulatoryOrLegal { get; private set; } = null!;

        public string Reputation { get; private set; } = null!;

        public string ThirdPartyImpact { get; private set; } = null!;

        public string MinimumBusinessContinuityObjective { get; private set; } = null!;

        public string MaximumAllowableOutage { get; private set; } = null!;

        public string RecoveryTimeObjective { get; private set; } = null!;

        public string RecoveryPointObjective { get; private set; } = null!;

        public BIAPriority Priority { get; private set; }

        public string ApplicationsUsedToRunProcess { get; private set; } = null!;

        public virtual List<BIAUnitProcessDetailsBusinessUnitToRunProcess> BusinessUnitsToRunProcess { get; private set; } = new();

        public string KeyVendors { get; private set; } = null!;

        public string AnyNonElectronicVitalRecords { get; private set; } = null!;

        public string AlternativeWorkarounds { get; private set; } = null!;

        public string PrimaryRecoverStrategyAndSolution { get; private set; } = null!;

        public BIAPeakPeriod PeakPeriod { get; private set; }

        public string RemoteWorking { get; private set; } = null!;

        public static BIAUnitProcessDetails Create(
            Guid businessImpactAnalysisUnitId, Guid processId, string businessProcessDescriptionSummary, string financialImpact,
            string customerExperience, string otherProcessesOrPeople, string regulatoryOrLegal, string reputation, string thirdPartyImpact,
            string minimumBusinessContinuityObjective, string maximumAllowableOutage, string recoveryTimeObjective, string recoveryPointObjective, 
            BIAPriority priority, string applicationsUsedToRunProcess,string keyVendors, string anyNonElectronicVitalRecords, string alternativeWorkarounds,
            string primaryRecoverStrategyAndSolution, BIAPeakPeriod peakPeriod,string remoteWorking
            , //List<BIAUnitProcessDetailsResponsibleBusinessUnit> responsibleBusinessUnits, 
            List<BIAUnitProcessDetailsBusinessUnitToRunProcess> businessUnitsToRunProcess
        )
        {
            return new BIAUnitProcessDetails
            {
                BusinessImpactAnalysisUnitId = businessImpactAnalysisUnitId,
                ProcessId = processId,
                BusinessProcessDescriptionSummary = businessProcessDescriptionSummary,
                FinancialImpact = financialImpact, 
                CustomerExperience = customerExperience,
                OtherProcessesOrPeople = otherProcessesOrPeople,
                RegulatoryOrLegal = regulatoryOrLegal,
                Reputation = reputation,
                ThirdPartyImpact = thirdPartyImpact,
                MinimumBusinessContinuityObjective = minimumBusinessContinuityObjective,
                MaximumAllowableOutage = maximumAllowableOutage,
                RecoveryTimeObjective = recoveryTimeObjective,
                RecoveryPointObjective = recoveryPointObjective,
                Priority = priority,
                ApplicationsUsedToRunProcess = applicationsUsedToRunProcess,
                KeyVendors = keyVendors,
                AnyNonElectronicVitalRecords = anyNonElectronicVitalRecords,
                AlternativeWorkarounds = alternativeWorkarounds,
                PrimaryRecoverStrategyAndSolution = primaryRecoverStrategyAndSolution,
                PeakPeriod = peakPeriod,
                RemoteWorking = remoteWorking,
                //ResponsibleBusinessUnits = responsibleBusinessUnits,
                BusinessUnitsToRunProcess = businessUnitsToRunProcess
            };
        }

        public static BIAUnitProcessDetails Create(
            Guid businessImpactAnalysisUnitId, Guid processId, string businessProcessDescriptionSummary, string financialImpact,
            string customerExperience, string otherProcessesOrPeople, string regulatoryOrLegal, string reputation, string thirdPartyImpact,
            string minimumBusinessContinuityObjective, string maximumAllowableOutage, string recoveryTimeObjective, string recoveryPointObjective,
            BIAPriority priority, string applicationsUsedToRunProcess, string keyVendors, string anyNonElectronicVitalRecords, string alternativeWorkarounds,
            string primaryRecoverStrategyAndSolution, BIAPeakPeriod peakPeriod, string remoteWorking
        )
        {
            return new BIAUnitProcessDetails
            {
                BusinessImpactAnalysisUnitId = businessImpactAnalysisUnitId,
                ProcessId = processId,
                BusinessProcessDescriptionSummary = businessProcessDescriptionSummary,
                FinancialImpact = financialImpact,
                CustomerExperience = customerExperience,
                OtherProcessesOrPeople = otherProcessesOrPeople,
                RegulatoryOrLegal = regulatoryOrLegal,
                Reputation = reputation,
                ThirdPartyImpact = thirdPartyImpact,
                MinimumBusinessContinuityObjective = minimumBusinessContinuityObjective,
                MaximumAllowableOutage = maximumAllowableOutage,
                RecoveryTimeObjective = recoveryTimeObjective,
                RecoveryPointObjective = recoveryPointObjective,
                Priority = priority,
                ApplicationsUsedToRunProcess = applicationsUsedToRunProcess,
                KeyVendors = keyVendors,
                AnyNonElectronicVitalRecords = anyNonElectronicVitalRecords,
                AlternativeWorkarounds = alternativeWorkarounds,
                PrimaryRecoverStrategyAndSolution = primaryRecoverStrategyAndSolution,
                PeakPeriod = peakPeriod,
                RemoteWorking = remoteWorking
            };
        }
    }
}
