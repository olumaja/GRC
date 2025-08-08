using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ARMIMRequest
    {
        public ARMIMBusinessRiskRatingReq ARMIM { get; set; }
    }

    public class ARMIMRequestValidation : AbstractValidator<ARMIMRequest>
    {
        public ARMIMRequestValidation()
        {
            RuleFor(x => x.ARMIM).NotEmpty();
        }
    }

    public class ARMIMBusinessRiskRatingReq
    {
        public StrategyImBusinessRatingReq Strategy { get; set; }
        public OperationIMBusinessRatingReq Operations { get; set; }
        public FinancialIMBusinessRatingReq FinancialReporting { get; set; }
        public ComplianceIMBusinessRatingReq Compliance { get; set; }
        public TimeSinceLastAuditIMBusinessRatingReq LastReportOverallRating { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
    }

    public class ARMIMBusinessRiskRatingReqValidation : AbstractValidator<ARMIMBusinessRiskRatingReq>
    {
        public ARMIMBusinessRiskRatingReqValidation()
        {
            RuleFor(x => x.Strategy).NotEmpty();
            RuleFor(x => x.Operations).NotEmpty();
            RuleFor(x => x.FinancialReporting).NotEmpty();
            RuleFor(x => x.Compliance).NotEmpty();
            RuleFor(x => x.LastReportOverallRating).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }

    public class StrategyImBusinessRatingReq
    {
        public StrategyIMRatingReq ARMIM { get; set; }
        public StrategyIMRatingReq IMUnit { get; set; }
        public StrategyIMRatingReq BDPWMIAMIMRetail { get; set; }
        public StrategyIMRatingReq FundAccount { get; set; }
        public StrategyIMRatingReq FundAdmin { get; set; }
        public StrategyIMRatingReq RetailOperation { get; set; }
        public StrategyIMRatingReq ARMRegistrar { get; set; }
        public StrategyIMRatingReq OperationSettlement { get; set; }
        public StrategyIMRatingReq OperationControl { get; set; }
        public StrategyIMRatingReq Research  { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class StrategyIMRatingReq
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

    public class OperationIMBusinessRatingReq
    {
        public OperationIMUnitRatingReq ARMIM { get; set; }
        public OperationIMUnitRatingReq IMUnit { get; set; }
        public OperationIMUnitRatingReq BDPWMIAMIMRetail { get; set; }
        public OperationIMUnitRatingReq FundAccount { get; set; }
        public OperationIMUnitRatingReq FundAdmin { get; set; }
        public OperationIMUnitRatingReq RetailOperation { get; set; }
        public OperationIMUnitRatingReq ARMRegistrar { get; set; }
        public OperationIMUnitRatingReq OperationSettlement { get; set; }
        public OperationIMUnitRatingReq OperationControl { get; set; }
        public OperationIMUnitRatingReq Research { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class OperationIMUnitRatingReq
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

    public class FinancialIMBusinessRatingReq
    {
        public FinacialIMBusinessRatingReq ARMIM { get; set; }
        public FinacialIMBusinessRatingReq IMUnit { get; set; }
        public FinacialIMBusinessRatingReq BDPWMIAMIMRetail { get; set; }
        public FinacialIMBusinessRatingReq FundAccount { get; set; }
        public FinacialIMBusinessRatingReq FundAdmin { get; set; }
        public FinacialIMBusinessRatingReq RetailOperation { get; set; }
        public FinacialIMBusinessRatingReq ARMRegistrar { get; set; }
        public FinacialIMBusinessRatingReq OperationSettlement { get; set; }
        public FinacialIMBusinessRatingReq OperationControl { get; set; }
        public FinacialIMBusinessRatingReq Research { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class FinacialIMBusinessRatingReq
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

    public class ComplianceIMBusinessRatingReq
    {
        public ComplianceIMRatingReq ARMIM { get; set; }
        public ComplianceIMRatingReq IMUnit { get; set; }
        public ComplianceIMRatingReq BDPWMIAMIMRetail { get; set; }
        public ComplianceIMRatingReq FundAccount { get; set; }
        public ComplianceIMRatingReq FundAdmin { get; set; }
        public ComplianceIMRatingReq RetailOperation { get; set; }
        public ComplianceIMRatingReq ARMRegistrar { get; set; }
        public ComplianceIMRatingReq OperationSettlement { get; set; }
        public ComplianceIMRatingReq OperationControl { get; set; }
        public ComplianceIMRatingReq Research { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }

    }

    public class ComplianceIMRatingReq
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

    public class TimeSinceLastAuditIMBusinessRatingReq
    {
        public int ARMIM { get; set; }
        public int IMUnit { get; set; }
        public int BDPWMIAMIMRetail { get; set; }
        public int FundAccount { get; set; }
        public int FundAdmin { get; set; }
        public int RetailOperation { get; set; }
        public int ARMRegistrar { get; set; }
        public int OperationSettlement { get; set; }
        public int OperationControl { get; set; }
        public int Research { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

}
