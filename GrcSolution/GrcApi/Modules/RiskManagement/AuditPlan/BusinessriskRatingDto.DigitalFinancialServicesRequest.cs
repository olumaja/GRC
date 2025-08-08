using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    #region  DFS 
    public class DigitalFinancialServicesRequest
    {
        public DigitalFinancialServicesBusinessRiskRatingReq DigitalFinancialServices { get; set; }
    }

    public class DigitalFinancialServicesRequestValidation : AbstractValidator<DigitalFinancialServicesRequest>
    {
        public DigitalFinancialServicesRequestValidation()
        {
            RuleFor(a => a.DigitalFinancialServices).NotEmpty();
        }
    }

    public class DigitalFinancialServicesBusinessRiskRatingReq
    {
        public StrategyBusinessDigitalFinancialServicesReq Strategy { get; set; }
        public OperationBusinessDigitalFinancialServiceReq Operations { get; set; }
        public FinancialDigitalFinancialServicesReq FinancialReporting { get; set; }
        public ComplianceDigitalFinancialServicesReq Compliance { get; set; }
        public TimeSinceLastAuditDigitalFinancialServicesReq LastReportOverallRating { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
    }

    public class DigitalFinancialServicesBusinessRiskRatingReqValidation : AbstractValidator<DigitalFinancialServicesBusinessRiskRatingReq>
    {
        public DigitalFinancialServicesBusinessRiskRatingReqValidation()
        {
            RuleFor(c => c.Strategy).NotEmpty();
            RuleFor(c => c.Operations).NotEmpty();
            RuleFor(c => c.FinancialReporting).NotEmpty();
            RuleFor(c => c.Compliance).NotEmpty();
            RuleFor(c => c.LastReportOverallRating).NotEmpty();
            RuleFor(c => c.Status).NotEmpty();
        }
    }

    public class StrategyBusinessDigitalFinancialServicesReq
    {
        public StrategyBusinessDigitalFinancialServiceRequest DigitalFinancialServices { get; set; }

        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }
    }

    public class StrategyBusinessDigitalFinancialServicesReqValidation : AbstractValidator<StrategyBusinessDigitalFinancialServicesReq>
    {
        public StrategyBusinessDigitalFinancialServicesReqValidation()
        {
            RuleFor(x => x.DigitalFinancialServices).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class StrategyBusinessDigitalFinancialServiceRequest
    {
        public int FlunCTOatingInterestRates { get; set; }
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

    public class OperationBusinessDigitalFinancialServiceReq
    {
        public OperationDigitalFinancialServiceRatingReq DigitalFinancialService { get; set; }
        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }
    }

    public class OperationBusinessDigitalFinancialServiceReqValidation : AbstractValidator<OperationBusinessDigitalFinancialServiceReq>
    {
        public OperationBusinessDigitalFinancialServiceReqValidation()
        {
            RuleFor(x => x.DigitalFinancialService).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class OperationDigitalFinancialServiceRatingReq
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

    public class FinancialDigitalFinancialServicesReq
    {
        public FinacialDigitalFinancialServiceRating DigitalFinancialService { get; set; }
        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }
    }

    public class FinancialDigitalFinancialServicesReqValidation : AbstractValidator<FinancialDigitalFinancialServicesReq>
    {
        public FinancialDigitalFinancialServicesReqValidation()
        {
            RuleFor(x => x.DigitalFinancialService).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class FinacialDigitalFinancialServiceRating
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

    public class ComplianceDigitalFinancialServicesReq
    {
        public ComplianceDigitalFinancialServiceRating DigitalFinancialService { get; set; }

        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }

    }

    public class ComplianceDigitalFinancialServicesReqValidation : AbstractValidator<ComplianceDigitalFinancialServicesReq>
    {
        public ComplianceDigitalFinancialServicesReqValidation()
        {
            RuleFor(x => x.DigitalFinancialService).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class ComplianceDigitalFinancialServiceRating
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

    public class TimeSinceLastAuditDigitalFinancialServicesReq
    {
        public int DigitalFinancialService { get; set; }

        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }
    }

    public class TimeSinceLastAuditDigitalFinancialServicesReqValidation : AbstractValidator<TimeSinceLastAuditDigitalFinancialServicesReq>
    {
        public TimeSinceLastAuditDigitalFinancialServicesReqValidation()
        {
            RuleFor(x => x.DigitalFinancialService).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    #endregion

    #region  ARM Capital 
    public class ARMCapitalRequest
    {
        public ARMCapitalBusinessRiskRatingReq ARMCapital { get; set; }
    }

    public class ARMCapitalRequestValidation : AbstractValidator<ARMCapitalRequest>
    {
        public ARMCapitalRequestValidation()
        {
            RuleFor(a => a.ARMCapital).NotEmpty();
        }
    }

    public class ARMCapitalBusinessRiskRatingReq
    {
        public StrategyBusinessARMCapitalReq Strategy { get; set; }
        public OperationBusinessARMCapitalReq Operations { get; set; }
        public FinancialARMCapitalReq FinancialReporting { get; set; }
        public ComplianceARMCapitalReq Compliance { get; set; }
        public TimeSinceLastAuditARMCapitalReq LastReportOverallRating { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
    }

    public class ARMCapitalBusinessRiskRatingReqValidation : AbstractValidator<ARMCapitalBusinessRiskRatingReq>
    {
        public ARMCapitalBusinessRiskRatingReqValidation()
        {
            RuleFor(c => c.Strategy).NotEmpty();
            RuleFor(c => c.Operations).NotEmpty();
            RuleFor(c => c.FinancialReporting).NotEmpty();
            RuleFor(c => c.Compliance).NotEmpty();
            RuleFor(c => c.LastReportOverallRating).NotEmpty();
            RuleFor(c => c.Status).NotEmpty();
        }
    }

    public class StrategyBusinessARMCapitalReq
    {
        public StrategyBusinessARMCapitalRequest ARMCapital { get; set; }

        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }
    }

    public class StrategyBusinessARMCapitalReqValidation : AbstractValidator<StrategyBusinessARMCapitalReq>
    {
        public StrategyBusinessARMCapitalReqValidation()
        {
            RuleFor(x => x.ARMCapital).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class StrategyBusinessARMCapitalRequest
    {
        public int FlunCTOatingInterestRates { get; set; }
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

    public class OperationBusinessARMCapitalReq
    {
        public OperationDigitalFinancialServiceRatingReq ARMCapital { get; set; }
        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }
    }

    public class OperationBusinessARMCapitalReqValidation : AbstractValidator<OperationBusinessARMCapitalReq>
    {
        public OperationBusinessARMCapitalReqValidation()
        {
            RuleFor(x => x.ARMCapital).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class OperationARMCapitalRatingReq
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

    public class FinancialARMCapitalReq
    {
        public FinacialARMCapitalRating ARMCapital { get; set; }
        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }
    }

    public class FinancialARMCapitalReqValidation : AbstractValidator<FinancialARMCapitalReq>
    {
        public FinancialARMCapitalReqValidation()
        {
            RuleFor(x => x.ARMCapital).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class FinacialARMCapitalRating
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

    public class ComplianceARMCapitalReq
    {
        public ComplianceARMCapitalRating ARMCapital { get; set; }

        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }

    }

    public class ComplianceARMCapitalReqValidation : AbstractValidator<ComplianceARMCapitalReq>
    {
        public ComplianceARMCapitalReqValidation()
        {
            RuleFor(x => x.ARMCapital).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class ComplianceARMCapitalRating
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

    public class TimeSinceLastAuditARMCapitalReq
    {
        public int ARMCapital { get; set; }

        [RegularExpression("^[a-zA-Z0-9#$%&()-:;\"\"?/,.']*$")]
        public string? Comment { get; set; }
    }

    public class TimeSinceLastAuditARMCapitalReqValidation : AbstractValidator<TimeSinceLastAuditARMCapitalReq>
    {
        public TimeSinceLastAuditARMCapitalReqValidation()
        {
            RuleFor(x => x.ARMCapital).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    #endregion
}
