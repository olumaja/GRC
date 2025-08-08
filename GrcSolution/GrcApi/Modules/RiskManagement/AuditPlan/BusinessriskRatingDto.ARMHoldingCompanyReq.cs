using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ARMHoldingCompanyRequest
    {
        public ARMHoldingCompanyRatingReq ARMHoldingCompany { get; set; }
    }

    public class ARMHoldingCompanyRequestValidation : AbstractValidator<ARMHoldingCompanyRequest>
    {
        public ARMHoldingCompanyRequestValidation()
        {
            RuleFor(x => x.ARMHoldingCompany).NotEmpty();
        }
    }

    public class ARMHoldingCompanyRatingReq
    {
        public StrategyReq Strategy { get; set; }
        public OperationReq Operations { get; set; }
        public FinancialReportingReq FinancialReporting { get; set; }
        public CompliancesReq Compliance { get; set; }
        public TimeSinceLastAuditReq LastReportOverallRating { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
    }

    public class ARMHoldingCompanyRatingReqValidation : AbstractValidator<ARMHoldingCompanyRatingReq>
    {
        public ARMHoldingCompanyRatingReqValidation()
        {
            RuleFor(x => x.Strategy).NotEmpty();
            RuleFor(x => x.Operations).NotEmpty();
            RuleFor(x => x.FinancialReporting).NotEmpty();
            RuleFor(x => x.Compliance).NotEmpty();
            RuleFor(x => x.LastReportOverallRating).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }

    public class StrategyReq
    {
        public StrategyRatingReq ARMHoldingCompany { get; set; }
        public StrategyRatingReq TreasurySale { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }

    }

    public class StrategyReqValidation : AbstractValidator<StrategyReq>
    {
        public StrategyReqValidation()
        {
            RuleFor(x => x.ARMHoldingCompany).NotEmpty();
            RuleFor(x => x.TreasurySale).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }

    public class StrategyRatingReq
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

    public class StrategyRatingReqValidation : AbstractValidator<StrategyRatingReq>
    {
        public StrategyRatingReqValidation()
        {
            RuleFor(x => x.flunctuatingInterestRates).NotEmpty();
            RuleFor(x => x.CurrencyDevaluation).NotEmpty();
            RuleFor(x => x.Increasedleverage).NotEmpty();
            RuleFor(x => x.LiquidityPressures).NotEmpty();
            RuleFor(x => x.ReputationalRisk).NotEmpty();
            RuleFor(x => x.PeopleRetentionRisk).NotEmpty();
            RuleFor(x => x.TechnologicalRisk).NotEmpty();
            RuleFor(x => x.InformationSecurityRisk).NotEmpty();
            RuleFor(x => x.CreditRisk).NotEmpty();
            RuleFor(x => x.AllianceandPartnershipRisks).NotEmpty();
            RuleFor(x => x.PortfolioProductandFundPerformanceRisk).NotEmpty();
            RuleFor(x => x.RisktoProfitabilityorPerformance).NotEmpty();
            RuleFor(x => x.RiskofDeclineinMarketShare).NotEmpty();
            RuleFor(x => x.DropinFundandFundManagerRatings).NotEmpty();
            RuleFor(x => x.HarshMacroeconomicConditionsegInflation).NotEmpty();
            RuleFor(x => x.StiffCompetitionandPoorVisibilityOftheBusiness).NotEmpty();
            RuleFor(x => x.ErosionofStatutoryCapital).NotEmpty();
            RuleFor(x => x.FluidityofTechnologicalSolutions).NotEmpty();
            RuleFor(x => x.UnregulatedUnstruCTOredlandscape).NotEmpty();
            RuleFor(x => x.PoliticalRisk).NotEmpty();
            RuleFor(x => x.ProjectManagementRisk).NotEmpty();
            RuleFor(x => x.InvestmentRisk).NotEmpty();
            RuleFor(x => x.FailureofInvestor).NotEmpty();
            RuleFor(x => x.ExitRisk).NotEmpty();
            RuleFor(x => x.SocialRisk).NotEmpty();
            RuleFor(x => x.EnvironmentalRisk).NotEmpty();
            RuleFor(x => x.SustainabilityRisk).NotEmpty();
            RuleFor(x => x.BCPandDRP).NotEmpty();
            RuleFor(x => x.MyLegacyIssuesProperty).NotEmpty();
            RuleFor(x => x.HealthandSafetyRisks).NotEmpty();
            RuleFor(x => x.EmergingRisks).NotEmpty();
            RuleFor(x => x.ProductivityRisk).NotEmpty();
            RuleFor(x => x.Total).NotEmpty();
        }
    }

    public class OperationReq
    {
        public OperationRatingReq ARMHoldingCompany { get; set; }
        public OperationRatingReq TreasurySale { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class OperationReqValidation : AbstractValidator<OperationReq>
    {
        public OperationReqValidation()
        {
            RuleFor(x => x.ARMHoldingCompany).NotEmpty();
            RuleFor(x => x.TreasurySale).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }


    public class OperationRatingReq
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

    public class OperationRatingReqValidation : AbstractValidator<OperationRatingReq>
    {
        public OperationRatingReqValidation()
        {
            RuleFor(x => x.AdoptionandImplementationofPolicies).NotEmpty();
            RuleFor(x => x.TheftorFraudRisk).NotEmpty();
            RuleFor(x => x.PoorCustomerService).NotEmpty();
            RuleFor(x => x.ITInfrastruCTOreDowntime).NotEmpty();
            RuleFor(x => x.ThirdpartyRisk).NotEmpty();
            RuleFor(x => x.TAT).NotEmpty();
            RuleFor(x => x.TheftLeakageorMisuseofIntelleCTOalProperty).NotEmpty();
            RuleFor(x => x.OverorUnderpaymentofClient).NotEmpty();
            RuleFor(x => x.RecruitmentRisk).NotEmpty();
            RuleFor(x => x.ConfidentialityIntegrityandAvailabilityofData).NotEmpty();
            RuleFor(x => x.UnauthorizedAccess).NotEmpty();
            RuleFor(x => x.MalwareorVirusorWebsiteAttacks).NotEmpty();
            RuleFor(x => x.ErroneousDataEntry).NotEmpty();
            RuleFor(x => x.Miscommunication).NotEmpty();
            RuleFor(x => x.ErrorDetectionRisk).NotEmpty();
            RuleFor(x => x.StrategyMonitoringRisk).NotEmpty();
            RuleFor(x => x.RelevanceandRecencyofModelToolsandTechniques).NotEmpty();
            RuleFor(x => x.ProductivityRisk).NotEmpty();
            RuleFor(x => x.BudgetOverruns).NotEmpty();
            RuleFor(x => x.Total).NotEmpty();
        }
    }


    public class FinancialReportingReq
    {
        public FinacialRatingReq ARMHoldingCompany { get; set; }
        public FinacialRatingReq TreasurySale { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class FinancialReportingReqValidation : AbstractValidator<FinancialReportingReq>
    {
        public FinancialReportingReqValidation()
        {
            RuleFor(x => x.ARMHoldingCompany).NotEmpty();
            RuleFor(x => x.TreasurySale).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }


    public class FinacialRatingReq
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

    public class FinacialRatingReqValidation : AbstractValidator<FinacialRatingReq>
    {
        public FinacialRatingReqValidation()
        {
            RuleFor(x => x.IncomeAssuranceRisk).NotEmpty();
            RuleFor(x => x.StatutoryDeductionsandTaxes).NotEmpty();
            RuleFor(x => x.AdherencetoFinancialStandards).NotEmpty();
            RuleFor(x => x.AdoptionandImplementationofPoliciesAdherence).NotEmpty();
            RuleFor(x => x.TAT).NotEmpty();
            RuleFor(x => x.ErrororControlRisk).NotEmpty();
            RuleFor(x => x.TheftorFraudRisk).NotEmpty();
            RuleFor(x => x.Total).NotEmpty();
        }
    }

    public class CompliancesReq
    {
        public ComplianceRatingReq ARMHoldingCompany { get; set; }
        public ComplianceRatingReq TreasurySale { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class CompliancesReqValidation : AbstractValidator<CompliancesReq>
    {
        public CompliancesReqValidation()
        {
            RuleFor(x => x.ARMHoldingCompany).NotEmpty();
            RuleFor(x => x.TreasurySale).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }


    public class ComplianceRatingReq
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

    public class ComplianceRatingReqValidation : AbstractValidator<ComplianceRatingReq>
    {
        public ComplianceRatingReqValidation()
        {
            RuleFor(x => x.AMLCFT).NotEmpty();
            RuleFor(x => x.LitigationRisk).NotEmpty();
            RuleFor(x => x.ChangingRegulations).NotEmpty();
            RuleFor(x => x.InaccurateComputationofRegulatoryRemittancesDelayedFilings).NotEmpty();
            RuleFor(x => x.NonComplianceWithContracts).NotEmpty();
            RuleFor(x => x.KYCChecks).NotEmpty();
            RuleFor(x => x.GDPROrNDPR).NotEmpty();
            RuleFor(x => x.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses).NotEmpty();
            RuleFor(x => x.DisclosureRisk).NotEmpty();
            RuleFor(x => x.CorporateGovernance).NotEmpty();
            RuleFor(x => x.TAT).NotEmpty();
            RuleFor(x => x.Total).NotEmpty();
        }
    }

    public class TimeSinceLastAuditReq
    {
        public int ARMHoldingCompany { get; set; }
        public int TreasurySale { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }

    }

    public class TimeSinceLastAuditReqValidation : AbstractValidator<TimeSinceLastAuditReq>
    {
        public TimeSinceLastAuditReqValidation()
        {
            RuleFor(x => x.ARMHoldingCompany).NotEmpty();
            RuleFor(x => x.TreasurySale).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }


}
