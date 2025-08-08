using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ARMHillRequest
    {
        public ARMHillRatingReq ARMHill { get; set; }

    }
    public class ARMHillRatingReq
    {
        public StrategyHillReq Strategy { get; set; }
        public OperationHillReq Operations { get; set; }
        public FinancialHillReportingReq FinancialReporting { get; set; }
        public ComplianceHillReq Compliance { get; set; }
        public TimeSinceLastHillAuditReq LastReportOverallRating { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
    }
    public class StrategyHillReq
    {
        public StrategyHillRatingReq ARMHill { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class StrategyHillRatingReq
    {
        public int flunctuatingInterestRates { get; set; }
        public int CurrencyDevaluation { get; set; }

        public int Increasedleverage { get; set; }

        public int LiquidityPressures { get; set; }

        public int ReputationalRisk { get; set; }

        public int PeopleRetentionRisk { get; set; }

        public int TechnologicalRisk { get; set; }

        public int InformationSecurityRisk { get; set; }

        public int CreditRisk { get; set; }

        public int AllianceandPartnershipRisks { get; set; }

        public int PortfolioProductandFundPerformanceRisk { get; set; }

        public int RisktoProfitabilityorPerformance { get; set; }

        public int RiskofDeclineinMarketShare { get; set; }

        public int DropinFundandFundManagerRatings { get; set; }
        public int HarshMacroeconomicConditionsegInflation { get; set; }
        public int StiffCompetitionandPoorVisibilityOftheBusiness { get; set; }
        public int ErosionofStatutoryCapital { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }

        public int UnregulatedUnstruCTOredlandscape { get; set; }

        public int PoliticalRisk { get; set; }

        public int ProjectManagementRisk { get; set; }

        public int InvestmentRisk { get; set; }

        public int FailureofInvestor { get; set; }

        public int ExitRisk { get; set; }

        public int SocialRisk { get; set; }

        public int EnvironmentalRisk { get; set; }

        public int SustainabilityRisk { get; set; }

        public int BCPandDRP { get; set; }

        public int MyLegacyIssuesProperty { get; set; }

        public int HealthandSafetyRisks { get; set; }

        public int EmergingRisks { get; set; }

        public int ProductivityRisk { get; set; }

        public int Total { get; set; }
    }
    public class OperationHillReq
    {
        public OperationHillRatingReq ARMHill { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class OperationHillRatingReq
    {
        public int AdoptionandImplementationofPolicies { get; set; }
        public int InadequateProfilingOfClientsToEffectivelySellProduct { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }

        public int ITInfrastruCTOreDowntime { get; set; }

        public int ThirdpartyRisk { get; set; }

        public int TAT { get; set; }

        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }

        public int OverorUnderpaymentofClient { get; set; }

        public int RecruitmentRisk { get; set; }

        public int ConfidentialityIntegrityandAvailabilityofData { get; set; }

        public int UnauthorizedAccess { get; set; }

        public int MalwareorVirusorWebsiteAttacks { get; set; }

        public int ErroneousDataEntry { get; set; }

        public int Miscommunication { get; set; }

        public int ErrorDetectionRisk { get; set; }

        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int ProductivityRisk { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }

    }

    public class FinancialHillReportingReq
    {
        public FinacialHillRatingReq ARMHill { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class FinacialHillRatingReq
    {
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }

    }

    public class ComplianceHillReq
    {
        public ComplianceHillRatingReq ARMHill { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }

    }

    public class ComplianceHillRatingReq
    {
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }

        public int NonComplianceWithContracts { get; set; }

        public int KYCChecks { get; set; }

        public int GDPROrNDPR { get; set; }

        public int AdoptionandIimplementationOfPoliciesandAdherenceToProcesses { get; set; }
        public int DisclosureRisk { get; set; }
        public int CorporateGovernance { get; set; }
        public int TAT { get; set; }
        public int Total { get; set; }
    }

    public class TimeSinceLastHillAuditReq
    {
        public int ARMHill { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

}
