using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public enum BusinessRiskRatingStatus
    {
        Saved = 1,
        Pending,
        Approved,
        Rejected,
        Completed,
        Supervisor_Edited,
        Not_Yet_Due,
        Due,
        Past_Due,
        Resolved,
        Implemented,
        Closed
    }

    public class BusinessRiskRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? RequesterName { get; set; }
        public ARMHoldingCompanyBusinessRating ARMHoldingCompany { get; set; }

        public ARMTAMBusinessRiskRating ARMTAM { get; set; }

        public ARMIMBusinessRiskRating ARMIM { get; set; }

        public ARMSecurityRating ARMSecurity { get; set; }

        public ARMTrusteeRating ARMTrustee { get; set; }

        public ARMHillRating ARMHill { get; set; }

        public ARMAgribusinessRating ARMAgribusiness { get; set; }

        public DigitalFinancialServiceBusinessRiskRating DigitalFinancialService { get; set; }

        public ARMSharedServiceRating ARMSharedService { get; set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;
        public bool IsEMCRated { get; set; } = false;
        public bool IsManagementRated { get; set; } = false;
        public string? OverAllComment { get; set; } = null;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; set; } = null;

        public static BusinessRiskRating Create(string requesterName)
        {
            return new BusinessRiskRating
            {
                RequesterName = requesterName,
            };
        }
        public void ApproveBusinessRiskRatingStatus()
        {
            Status = BusinessRiskRatingStatus.Approved;
            IsEMCRated = true;
            IsManagementRated = true;
        }
        public void RejectBusinessRiskRatingStatus(string reason)
        {
            Status = BusinessRiskRatingStatus.Rejected;
            ReasonForRejection = reason;
        }
        public void UpdateIsEMCRated()
        {
            IsEMCRated = true;
        }
        public void UpdateIsManagementRated()
        {
            IsManagementRated = true;
        }
    }
    #region ARM Holding Company 
    public class ARMHoldingCompanyBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategyBusinessRatingARMHoldCo Strategy { get; set; }
        public OperationBusinessRatingARMHoldCo Operations { get; set; }
        public FinancialReportingBusinessratingARMHoldCo FinancialReporting { get; set; }
        public ComplianceBusinessRatingARMHoldCo Compliance { get; set; }
        public TimeSinceLastAuditBusinessRatingARMHoldCo TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterName { get; set; }
        public static ARMHoldingCompanyBusinessRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string requesterName)
        {
            return new ARMHoldingCompanyBusinessRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterName = requesterName
            };
        }
        public void Update(Guid businessRiskRatingId, BusinessRiskRatingStatus status)
        {
            BusinessRiskRatingId = businessRiskRatingId;
            Status = status;
        }

        public void ApproveARMHoldingCompanyBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectARMHoldingCompanyBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategyBusinessRatingARMHoldCo : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRating))]
        public Guid ARMHoldingCompanyBusinessRatingId { get; set; }
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRatingId))]
        public ARMHoldingCompanyBusinessRating ARMHoldingCompanyBusinessRating { get; set; }
        public StrategyBusinessArmHoldCo ARMHoldingCompany { get; set; }
        public StrategyBusinessTreasurySale TreasurySale { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static StrategyBusinessRatingARMHoldCo Create(Guid aRMHoldingCompanyBusinessRatingId, string comment)
        {
            return new StrategyBusinessRatingARMHoldCo
            {
                ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId,
                Comment = comment
            };
        }
        public void Update(Guid aRMHoldingCompanyBusinessRatingId, string comment)
        {
            ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId;
            Comment = comment;
        }

    }
    public class StrategyBusinessTreasurySale : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyBusinessRatingARMHoldCo))]
        public Guid StrategyBusinessRatingARMHoldCoId { get; set; }
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
        public static StrategyBusinessTreasurySale Create(Guid strategyBusinessRatingARMHoldCoId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new StrategyBusinessTreasurySale
            {
                StrategyBusinessRatingARMHoldCoId = strategyBusinessRatingARMHoldCoId,
                FluidityofTechnologicalSolutions = aRMHoldingCompany.Strategy.TreasurySale.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = aRMHoldingCompany.Strategy.TreasurySale.CurrencyDevaluation,
                Increasedleverage = aRMHoldingCompany.Strategy.TreasurySale.Increasedleverage,
                SocialRisk = aRMHoldingCompany.Strategy.TreasurySale.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = aRMHoldingCompany.Strategy.TreasurySale.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = aRMHoldingCompany.Strategy.TreasurySale.DropinFundandFundManagerRatings,
                BCPandDRP = aRMHoldingCompany.Strategy.TreasurySale.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = aRMHoldingCompany.Strategy.TreasurySale.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = aRMHoldingCompany.Strategy.TreasurySale.AllianceandPartnershipRisks,
                EmergingRisks = aRMHoldingCompany.Strategy.TreasurySale.EmergingRisks,
                EnvironmentalRisk = aRMHoldingCompany.Strategy.TreasurySale.EnvironmentalRisk,
                ErosionofStatutoryCapital = aRMHoldingCompany.Strategy.TreasurySale.ErosionofStatutoryCapital,
                ReputationalRisk = aRMHoldingCompany.Strategy.TreasurySale.ReputationalRisk,
                RisktoProfitabilityorPerformance = aRMHoldingCompany.Strategy.TreasurySale.RisktoProfitabilityorPerformance,
                CreditRisk = aRMHoldingCompany.Strategy.TreasurySale.CreditRisk,
                SustainabilityRisk = aRMHoldingCompany.Strategy.TreasurySale.SustainabilityRisk,
                HealthandSafetyRisks = aRMHoldingCompany.Strategy.TreasurySale.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = aRMHoldingCompany.Strategy.TreasurySale.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = aRMHoldingCompany.Strategy.TreasurySale.FailureofInvestor,
                FlunCTOatingInterestRates = aRMHoldingCompany.Strategy.TreasurySale.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = aRMHoldingCompany.Strategy.TreasurySale.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = aRMHoldingCompany.Strategy.TreasurySale.InformationSecurityRisk,
                ExitRisk = aRMHoldingCompany.Strategy.TreasurySale.ExitRisk,
                InvestmentRisk = aRMHoldingCompany.Strategy.TreasurySale.InvestmentRisk,
                LiquidityPressures = aRMHoldingCompany.Strategy.TreasurySale.LiquidityPressures,
                MyLegacyIssuesProperty = aRMHoldingCompany.Strategy.TreasurySale.MyLegacyIssuesProperty,
                PoliticalRisk = aRMHoldingCompany.Strategy.TreasurySale.PoliticalRisk,
                PeopleRetentionRisk = aRMHoldingCompany.Strategy.TreasurySale.PeopleRetentionRisk,
                ProductivityRisk = aRMHoldingCompany.Strategy.TreasurySale.ProductivityRisk,
                ProjectManagementRisk = aRMHoldingCompany.Strategy.TreasurySale.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = aRMHoldingCompany.Strategy.TreasurySale.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = aRMHoldingCompany.Strategy.TreasurySale.TechnologicalRisk,
                Total = aRMHoldingCompany.Strategy.TreasurySale.Total
            };
        }

        public void Update(Guid strategyBusinessRatingARMHoldCoId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            StrategyBusinessRatingARMHoldCoId = strategyBusinessRatingARMHoldCoId;
            FluidityofTechnologicalSolutions = aRMHoldingCompany.Strategy.TreasurySale.FluidityofTechnologicalSolutions;
            CurrencyDevaluation = aRMHoldingCompany.Strategy.TreasurySale.CurrencyDevaluation;
            Increasedleverage = aRMHoldingCompany.Strategy.TreasurySale.Increasedleverage;
            SocialRisk = aRMHoldingCompany.Strategy.TreasurySale.SocialRisk;
            StiffCompetitionandPoorVisibilityOftheBusiness = aRMHoldingCompany.Strategy.TreasurySale.StiffCompetitionandPoorVisibilityOftheBusiness;
            DropinFundandFundManagerRatings = aRMHoldingCompany.Strategy.TreasurySale.DropinFundandFundManagerRatings;
            BCPandDRP = aRMHoldingCompany.Strategy.TreasurySale.DropinFundandFundManagerRatings;
            RiskofDeclineinMarketShare = aRMHoldingCompany.Strategy.TreasurySale.RiskofDeclineinMarketShare;
            AllianceandPartnershipRisks = aRMHoldingCompany.Strategy.TreasurySale.AllianceandPartnershipRisks;
            EmergingRisks = aRMHoldingCompany.Strategy.TreasurySale.EmergingRisks;
            EnvironmentalRisk = aRMHoldingCompany.Strategy.TreasurySale.EnvironmentalRisk;
            ErosionofStatutoryCapital = aRMHoldingCompany.Strategy.TreasurySale.ErosionofStatutoryCapital;
            ReputationalRisk = aRMHoldingCompany.Strategy.TreasurySale.ReputationalRisk;
            RisktoProfitabilityorPerformance = aRMHoldingCompany.Strategy.TreasurySale.RisktoProfitabilityorPerformance;
            CreditRisk = aRMHoldingCompany.Strategy.TreasurySale.CreditRisk;
            SustainabilityRisk = aRMHoldingCompany.Strategy.TreasurySale.SustainabilityRisk;
            HealthandSafetyRisks = aRMHoldingCompany.Strategy.TreasurySale.HealthandSafetyRisks;
            HarshMacroeconomicConditionsegInflation = aRMHoldingCompany.Strategy.TreasurySale.HarshMacroeconomicConditionsegInflation;
            FailureofInvestor = aRMHoldingCompany.Strategy.TreasurySale.FailureofInvestor;
            FlunCTOatingInterestRates = aRMHoldingCompany.Strategy.TreasurySale.flunctuatingInterestRates;
            PortfolioProductandFundPerformanceRisk = aRMHoldingCompany.Strategy.TreasurySale.PortfolioProductandFundPerformanceRisk;
            InformationSecurityRisk = aRMHoldingCompany.Strategy.TreasurySale.InformationSecurityRisk;
            ExitRisk = aRMHoldingCompany.Strategy.TreasurySale.ExitRisk;
            InvestmentRisk = aRMHoldingCompany.Strategy.TreasurySale.InvestmentRisk;
            LiquidityPressures = aRMHoldingCompany.Strategy.TreasurySale.LiquidityPressures;
            MyLegacyIssuesProperty = aRMHoldingCompany.Strategy.TreasurySale.MyLegacyIssuesProperty;
            PoliticalRisk = aRMHoldingCompany.Strategy.TreasurySale.PoliticalRisk;
            PeopleRetentionRisk = aRMHoldingCompany.Strategy.TreasurySale.PeopleRetentionRisk;
            ProductivityRisk = aRMHoldingCompany.Strategy.TreasurySale.ProductivityRisk;
            ProjectManagementRisk = aRMHoldingCompany.Strategy.TreasurySale.ProjectManagementRisk;
            UnregulatedUnstruCTOredlandscape = aRMHoldingCompany.Strategy.TreasurySale.UnregulatedUnstruCTOredlandscape;
            TechnologicalRisk = aRMHoldingCompany.Strategy.TreasurySale.TechnologicalRisk;
            Total = aRMHoldingCompany.Strategy.TreasurySale.Total;
        }

    }

    public class StrategyBusinessArmHoldCo : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyBusinessRatingARMHoldCo))]
        public Guid StrategyBusinessRatingARMHoldCoId { get; set; }
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
        public static StrategyBusinessArmHoldCo Create(Guid strategyBusinessRatingARMHoldCoId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new StrategyBusinessArmHoldCo
            {
                StrategyBusinessRatingARMHoldCoId = strategyBusinessRatingARMHoldCoId,
                FluidityofTechnologicalSolutions = aRMHoldingCompany.Strategy.ARMHoldingCompany.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = aRMHoldingCompany.Strategy.ARMHoldingCompany.CurrencyDevaluation,
                Increasedleverage = aRMHoldingCompany.Strategy.ARMHoldingCompany.Increasedleverage,
                SocialRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = aRMHoldingCompany.Strategy.ARMHoldingCompany.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = aRMHoldingCompany.Strategy.ARMHoldingCompany.DropinFundandFundManagerRatings,
                BCPandDRP = aRMHoldingCompany.Strategy.ARMHoldingCompany.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = aRMHoldingCompany.Strategy.ARMHoldingCompany.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = aRMHoldingCompany.Strategy.ARMHoldingCompany.AllianceandPartnershipRisks,
                EmergingRisks = aRMHoldingCompany.Strategy.ARMHoldingCompany.EmergingRisks,
                EnvironmentalRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.EnvironmentalRisk,
                ErosionofStatutoryCapital = aRMHoldingCompany.Strategy.ARMHoldingCompany.ErosionofStatutoryCapital,
                ReputationalRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.ReputationalRisk,
                RisktoProfitabilityorPerformance = aRMHoldingCompany.Strategy.ARMHoldingCompany.RisktoProfitabilityorPerformance,
                CreditRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.CreditRisk,
                SustainabilityRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.SustainabilityRisk,
                HealthandSafetyRisks = aRMHoldingCompany.Strategy.ARMHoldingCompany.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = aRMHoldingCompany.Strategy.ARMHoldingCompany.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = aRMHoldingCompany.Strategy.ARMHoldingCompany.FailureofInvestor,
                FlunCTOatingInterestRates = aRMHoldingCompany.Strategy.ARMHoldingCompany.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.InformationSecurityRisk,
                ExitRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.ExitRisk,
                InvestmentRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.InvestmentRisk,
                LiquidityPressures = aRMHoldingCompany.Strategy.ARMHoldingCompany.LiquidityPressures,
                MyLegacyIssuesProperty = aRMHoldingCompany.Strategy.ARMHoldingCompany.MyLegacyIssuesProperty,
                PoliticalRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.PoliticalRisk,
                PeopleRetentionRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.PeopleRetentionRisk,
                ProductivityRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.ProductivityRisk,
                ProjectManagementRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = aRMHoldingCompany.Strategy.ARMHoldingCompany.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.TechnologicalRisk,
                Total = aRMHoldingCompany.Strategy.ARMHoldingCompany.Total
            };
        }

        public void Update(Guid strategyBusinessRatingARMHoldCoId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            StrategyBusinessRatingARMHoldCoId = strategyBusinessRatingARMHoldCoId;
            FluidityofTechnologicalSolutions = aRMHoldingCompany.Strategy.ARMHoldingCompany.FluidityofTechnologicalSolutions;
            CurrencyDevaluation = aRMHoldingCompany.Strategy.ARMHoldingCompany.CurrencyDevaluation;
            Increasedleverage = aRMHoldingCompany.Strategy.ARMHoldingCompany.Increasedleverage;
            SocialRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.SocialRisk;
            StiffCompetitionandPoorVisibilityOftheBusiness = aRMHoldingCompany.Strategy.ARMHoldingCompany.StiffCompetitionandPoorVisibilityOftheBusiness;
            DropinFundandFundManagerRatings = aRMHoldingCompany.Strategy.ARMHoldingCompany.DropinFundandFundManagerRatings;
            BCPandDRP = aRMHoldingCompany.Strategy.ARMHoldingCompany.DropinFundandFundManagerRatings;
            RiskofDeclineinMarketShare = aRMHoldingCompany.Strategy.ARMHoldingCompany.RiskofDeclineinMarketShare;
            AllianceandPartnershipRisks = aRMHoldingCompany.Strategy.ARMHoldingCompany.AllianceandPartnershipRisks;
            EmergingRisks = aRMHoldingCompany.Strategy.ARMHoldingCompany.EmergingRisks;
            EnvironmentalRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.EnvironmentalRisk;
            ErosionofStatutoryCapital = aRMHoldingCompany.Strategy.ARMHoldingCompany.ErosionofStatutoryCapital;
            ReputationalRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.ReputationalRisk;
            RisktoProfitabilityorPerformance = aRMHoldingCompany.Strategy.ARMHoldingCompany.RisktoProfitabilityorPerformance;
            CreditRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.CreditRisk;
            SustainabilityRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.SustainabilityRisk;
            HealthandSafetyRisks = aRMHoldingCompany.Strategy.ARMHoldingCompany.HealthandSafetyRisks;
            HarshMacroeconomicConditionsegInflation = aRMHoldingCompany.Strategy.ARMHoldingCompany.HarshMacroeconomicConditionsegInflation;
            FailureofInvestor = aRMHoldingCompany.Strategy.ARMHoldingCompany.FailureofInvestor;
            FlunCTOatingInterestRates = aRMHoldingCompany.Strategy.ARMHoldingCompany.flunctuatingInterestRates;
            PortfolioProductandFundPerformanceRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.PortfolioProductandFundPerformanceRisk;
            InformationSecurityRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.InformationSecurityRisk;
            ExitRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.ExitRisk;
            InvestmentRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.InvestmentRisk;
            LiquidityPressures = aRMHoldingCompany.Strategy.ARMHoldingCompany.LiquidityPressures;
            MyLegacyIssuesProperty = aRMHoldingCompany.Strategy.ARMHoldingCompany.MyLegacyIssuesProperty;
            PoliticalRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.PoliticalRisk;
            PeopleRetentionRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.PeopleRetentionRisk;
            ProductivityRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.ProductivityRisk;
            ProjectManagementRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.ProjectManagementRisk;
            UnregulatedUnstruCTOredlandscape = aRMHoldingCompany.Strategy.ARMHoldingCompany.UnregulatedUnstruCTOredlandscape;
            TechnologicalRisk = aRMHoldingCompany.Strategy.ARMHoldingCompany.TechnologicalRisk;
            Total = aRMHoldingCompany.Strategy.ARMHoldingCompany.Total;
        }

    }

    public class OperationBusinessRatingARMHoldCo : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRating))]
        public Guid ARMHoldingCompanyBusinessRatingId { get; set; }
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRatingId))]
        public ARMHoldingCompanyBusinessRating ARMHoldingCompanyBusinessRating { get; set; }
        public OperationBusinessArmHolco ARMHoldingCompany { get; set; }
        public OperationBusinessTreasurySale TreasurySale { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationBusinessRatingARMHoldCo Create(Guid aRMHoldingCompanyBusinessRatingId, string comment)
        {
            return new OperationBusinessRatingARMHoldCo
            {
                ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId,
                Comment = comment
            };
        }
        public void Update(Guid aRMHoldingCompanyBusinessRatingId, string comment)
        {
            ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId;
            Comment = comment;
        }

    }

    public class OperationBusinessTreasurySale : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationBusinessRatingARMHoldCo))]
        public Guid OperationBusinessRatingARMHoldCoId { get; set; }
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
        public static OperationBusinessTreasurySale Create(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new OperationBusinessTreasurySale
            {
                OperationBusinessRatingARMHoldCoId = aRMHoldingCompanyBusinessRatingId,
                AdoptionandImplementationofPolicies = aRMHoldingCompany.Operations.TreasurySale.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = aRMHoldingCompany.Operations.TreasurySale.StrategyMonitoringRisk,
                BudgetOverruns = aRMHoldingCompany.Operations.TreasurySale.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = aRMHoldingCompany.Operations.TreasurySale.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = aRMHoldingCompany.Operations.TreasurySale.OverorUnderpaymentofClient,
                TheftorFraudRisk = aRMHoldingCompany.Operations.TreasurySale.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = aRMHoldingCompany.Operations.TreasurySale.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = aRMHoldingCompany.Operations.TreasurySale.TAT,
                ThirdpartyRisk = aRMHoldingCompany.Operations.TreasurySale.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = aRMHoldingCompany.Operations.TreasurySale.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = aRMHoldingCompany.Operations.TreasurySale.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = aRMHoldingCompany.Operations.TreasurySale.MalwareorVirusorWebsiteAttacks,
                Miscommunication = aRMHoldingCompany.Operations.TreasurySale.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = aRMHoldingCompany.Operations.TreasurySale.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = aRMHoldingCompany.Operations.TreasurySale.ProductivityRisk,
                RecruitmentRisk = aRMHoldingCompany.Operations.TreasurySale.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = aRMHoldingCompany.Operations.TreasurySale.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = aRMHoldingCompany.Operations.TreasurySale.ErrorDetectionRisk,
                PoorCustomerService = aRMHoldingCompany.Operations.TreasurySale.PoorCustomerService,
                UnauthorizedAccess = aRMHoldingCompany.Operations.TreasurySale.UnauthorizedAccess,
                Total = aRMHoldingCompany.Operations.TreasurySale.Total

            };
        }

        public void Update(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            OperationBusinessRatingARMHoldCoId = aRMHoldingCompanyBusinessRatingId;
            AdoptionandImplementationofPolicies = aRMHoldingCompany.Operations.TreasurySale.AdoptionandImplementationofPolicies;
            StrategyMonitoringRisk = aRMHoldingCompany.Operations.TreasurySale.StrategyMonitoringRisk;
            BudgetOverruns = aRMHoldingCompany.Operations.TreasurySale.BudgetOverruns;
            ConfidentialityIntegrityandAvailabilityofData = aRMHoldingCompany.Operations.TreasurySale.ConfidentialityIntegrityandAvailabilityofData;
            OverorUnderpaymentofClient = aRMHoldingCompany.Operations.TreasurySale.OverorUnderpaymentofClient;
            TheftorFraudRisk = aRMHoldingCompany.Operations.TreasurySale.TheftorFraudRisk;
            TheftLeakageorMisuseofIntelleCTOalProperty = aRMHoldingCompany.Operations.TreasurySale.TheftLeakageorMisuseofIntelleCTOalProperty;
            TAT = aRMHoldingCompany.Operations.TreasurySale.TAT;
            ThirdpartyRisk = aRMHoldingCompany.Operations.TreasurySale.ThirdpartyRisk;
            ITInfrastruCTOreDowntime = aRMHoldingCompany.Operations.TreasurySale.ITInfrastruCTOreDowntime;
            ErroneousDataEntry = aRMHoldingCompany.Operations.TreasurySale.ErroneousDataEntry;
            MalwareorVirusorWebsiteAttacks = aRMHoldingCompany.Operations.TreasurySale.MalwareorVirusorWebsiteAttacks;
            Miscommunication = aRMHoldingCompany.Operations.TreasurySale.Miscommunication;
            InadequateProfilingOfClientsToEffectivelySellProduct = aRMHoldingCompany.Operations.TreasurySale.InadequateProfilingOfClientsToEffectivelySellProduct;
            ProductivityRisk = aRMHoldingCompany.Operations.TreasurySale.ProductivityRisk;
            RecruitmentRisk = aRMHoldingCompany.Operations.TreasurySale.RecruitmentRisk;
            RelevanceandRecencyofModelToolsandTechniques = aRMHoldingCompany.Operations.TreasurySale.RelevanceandRecencyofModelToolsandTechniques;
            ErrorDetectionRisk = aRMHoldingCompany.Operations.TreasurySale.ErrorDetectionRisk;
            PoorCustomerService = aRMHoldingCompany.Operations.TreasurySale.PoorCustomerService;
            UnauthorizedAccess = aRMHoldingCompany.Operations.TreasurySale.UnauthorizedAccess;
            Total = aRMHoldingCompany.Operations.TreasurySale.Total;
        }

    }

    public class OperationBusinessArmHolco : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationBusinessRatingARMHoldCo))]
        public Guid OperationBusinessRatingARMHoldCoId { get; set; }
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
        public static OperationBusinessArmHolco Create(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new OperationBusinessArmHolco
            {
                OperationBusinessRatingARMHoldCoId = aRMHoldingCompanyBusinessRatingId,
                AdoptionandImplementationofPolicies = aRMHoldingCompany.Operations.ARMHoldingCompany.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.StrategyMonitoringRisk,
                BudgetOverruns = aRMHoldingCompany.Operations.ARMHoldingCompany.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = aRMHoldingCompany.Operations.ARMHoldingCompany.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = aRMHoldingCompany.Operations.ARMHoldingCompany.OverorUnderpaymentofClient,
                TheftorFraudRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = aRMHoldingCompany.Operations.ARMHoldingCompany.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = aRMHoldingCompany.Operations.ARMHoldingCompany.TAT,
                ThirdpartyRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = aRMHoldingCompany.Operations.ARMHoldingCompany.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = aRMHoldingCompany.Operations.ARMHoldingCompany.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = aRMHoldingCompany.Operations.ARMHoldingCompany.MalwareorVirusorWebsiteAttacks,
                Miscommunication = aRMHoldingCompany.Operations.ARMHoldingCompany.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = aRMHoldingCompany.Operations.ARMHoldingCompany.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.ProductivityRisk,
                RecruitmentRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = aRMHoldingCompany.Operations.ARMHoldingCompany.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.ErrorDetectionRisk,
                PoorCustomerService = aRMHoldingCompany.Operations.ARMHoldingCompany.PoorCustomerService,
                UnauthorizedAccess = aRMHoldingCompany.Operations.ARMHoldingCompany.UnauthorizedAccess,
                Total = aRMHoldingCompany.Operations.ARMHoldingCompany.Total

            };
        }

        public void Update(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            OperationBusinessRatingARMHoldCoId = aRMHoldingCompanyBusinessRatingId;
            AdoptionandImplementationofPolicies = aRMHoldingCompany.Operations.ARMHoldingCompany.AdoptionandImplementationofPolicies;
            StrategyMonitoringRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.StrategyMonitoringRisk;
            BudgetOverruns = aRMHoldingCompany.Operations.ARMHoldingCompany.BudgetOverruns;
            ConfidentialityIntegrityandAvailabilityofData = aRMHoldingCompany.Operations.ARMHoldingCompany.ConfidentialityIntegrityandAvailabilityofData;
            OverorUnderpaymentofClient = aRMHoldingCompany.Operations.ARMHoldingCompany.OverorUnderpaymentofClient;
            TheftorFraudRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.TheftorFraudRisk;
            TheftLeakageorMisuseofIntelleCTOalProperty = aRMHoldingCompany.Operations.ARMHoldingCompany.TheftLeakageorMisuseofIntelleCTOalProperty;
            TAT = aRMHoldingCompany.Operations.ARMHoldingCompany.TAT;
            ThirdpartyRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.ThirdpartyRisk;
            ITInfrastruCTOreDowntime = aRMHoldingCompany.Operations.ARMHoldingCompany.ITInfrastruCTOreDowntime;
            ErroneousDataEntry = aRMHoldingCompany.Operations.ARMHoldingCompany.ErroneousDataEntry;
            MalwareorVirusorWebsiteAttacks = aRMHoldingCompany.Operations.ARMHoldingCompany.MalwareorVirusorWebsiteAttacks;
            Miscommunication = aRMHoldingCompany.Operations.ARMHoldingCompany.Miscommunication;
            InadequateProfilingOfClientsToEffectivelySellProduct = aRMHoldingCompany.Operations.ARMHoldingCompany.InadequateProfilingOfClientsToEffectivelySellProduct;
            ProductivityRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.ProductivityRisk;
            RecruitmentRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.RecruitmentRisk;
            RelevanceandRecencyofModelToolsandTechniques = aRMHoldingCompany.Operations.ARMHoldingCompany.RelevanceandRecencyofModelToolsandTechniques;
            ErrorDetectionRisk = aRMHoldingCompany.Operations.ARMHoldingCompany.ErrorDetectionRisk;
            PoorCustomerService = aRMHoldingCompany.Operations.ARMHoldingCompany.PoorCustomerService;
            UnauthorizedAccess = aRMHoldingCompany.Operations.ARMHoldingCompany.UnauthorizedAccess;
            Total = aRMHoldingCompany.Operations.ARMHoldingCompany.Total;
        }

    }

    public class FinancialReportingBusinessratingARMHoldCo : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRating))]
        public Guid ARMHoldingCompanyBusinessRatingId { get; set; }
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRatingId))]
        public ARMHoldingCompanyBusinessRating ARMHoldingCompanyBusinessRating { get; set; }
        public FinacialRatingBusinessratingARMHoldCo ARMHoldingCompany { get; set; }
        public FinacialRatingBusinessratingTreasurySale TreasurySale { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialReportingBusinessratingARMHoldCo Create(Guid aRMHoldingCompanyBusinessRatingId, string comment)
        {
            return new FinancialReportingBusinessratingARMHoldCo
            {
                ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId,
                Comment = comment
            };
        }
        public void Update(Guid aRMHoldingCompanyBusinessRatingId, string comment)
        {
            ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId;
            Comment = comment;
        }

    }

    public class FinacialRatingBusinessratingTreasurySale : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialReportingBusinessratingARMHoldCo))]
        public Guid FinancialReportingBusinessratingARMHoldCoId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialRatingBusinessratingTreasurySale Create(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new FinacialRatingBusinessratingTreasurySale
            {
                FinancialReportingBusinessratingARMHoldCoId = aRMHoldingCompanyBusinessRatingId,
                AdherencetoFinancialStandards = aRMHoldingCompany.FinancialReporting.TreasurySale.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = aRMHoldingCompany.FinancialReporting.TreasurySale.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = aRMHoldingCompany.FinancialReporting.TreasurySale.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = aRMHoldingCompany.FinancialReporting.TreasurySale.ErrororControlRisk,
                IncomeAssuranceRisk = aRMHoldingCompany.FinancialReporting.TreasurySale.IncomeAssuranceRisk,
                TAT = aRMHoldingCompany.FinancialReporting.TreasurySale.TAT,
                TheftorFraudRisk = aRMHoldingCompany.FinancialReporting.TreasurySale.TheftorFraudRisk,
                Total = aRMHoldingCompany.FinancialReporting.TreasurySale.Total
            };
        }

        public void Update(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            FinancialReportingBusinessratingARMHoldCoId = aRMHoldingCompanyBusinessRatingId;
            AdherencetoFinancialStandards = aRMHoldingCompany.FinancialReporting.TreasurySale.AdherencetoFinancialStandards;
            StatutoryDeductionsandTaxes = aRMHoldingCompany.FinancialReporting.TreasurySale.StatutoryDeductionsandTaxes;
            AdoptionandImplementationofPoliciesAdherence = aRMHoldingCompany.FinancialReporting.TreasurySale.AdoptionandImplementationofPoliciesAdherence;
            ErrororControlRisk = aRMHoldingCompany.FinancialReporting.TreasurySale.ErrororControlRisk;
            IncomeAssuranceRisk = aRMHoldingCompany.FinancialReporting.TreasurySale.IncomeAssuranceRisk;
            TAT = aRMHoldingCompany.FinancialReporting.TreasurySale.TAT;
            TheftorFraudRisk = aRMHoldingCompany.FinancialReporting.TreasurySale.TheftorFraudRisk;
            Total = aRMHoldingCompany.FinancialReporting.TreasurySale.Total;
        }

    }

    public class FinacialRatingBusinessratingARMHoldCo : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialReportingBusinessratingARMHoldCo))]
        public Guid FinancialReportingBusinessratingARMHoldCoId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialRatingBusinessratingARMHoldCo Create(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new FinacialRatingBusinessratingARMHoldCo
            {
                FinancialReportingBusinessratingARMHoldCoId = aRMHoldingCompanyBusinessRatingId,
                AdherencetoFinancialStandards = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.ErrororControlRisk,
                IncomeAssuranceRisk = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.IncomeAssuranceRisk,
                TAT = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.TAT,
                TheftorFraudRisk = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.TheftorFraudRisk,
                Total = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.Total
            };
        }

        public void Update(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            FinancialReportingBusinessratingARMHoldCoId = aRMHoldingCompanyBusinessRatingId;
            AdherencetoFinancialStandards = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.AdherencetoFinancialStandards;
            StatutoryDeductionsandTaxes = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.StatutoryDeductionsandTaxes;
            AdoptionandImplementationofPoliciesAdherence = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.AdoptionandImplementationofPoliciesAdherence;
            ErrororControlRisk = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.ErrororControlRisk;
            IncomeAssuranceRisk = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.IncomeAssuranceRisk;
            TAT = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.TAT;
            TheftorFraudRisk = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.TheftorFraudRisk;
            Total = aRMHoldingCompany.FinancialReporting.ARMHoldingCompany.Total;
        }

    }

    public class ComplianceBusinessRatingARMHoldCo : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRating))]
        public Guid ARMHoldingCompanyBusinessRatingId { get; set; }
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRatingId))]
        public ARMHoldingCompanyBusinessRating ARMHoldingCompanyBusinessRating { get; set; }
        public CompliancesBusinessRiskRatingARMHoldCo ARMHoldingCompany { get; set; }
        public CompliancesBusinessTreasurySale TreasurySale { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceBusinessRatingARMHoldCo Create(Guid aRMHoldingCompanyBusinessRatingId, string comment)
        {
            return new ComplianceBusinessRatingARMHoldCo
            {
                ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId,
                Comment = comment
            };
        }

        public void Update(Guid aRMHoldingCompanyBusinessRatingId, string comment)
        {
            ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId;
            Comment = comment;
        }

    }

    public class CompliancesBusinessTreasurySale : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceBusinessRatingARMHoldCo))]
        public Guid ComplianceBusinessRatingARMHoldCoId { get; set; }
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
        public static CompliancesBusinessTreasurySale Create(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new CompliancesBusinessTreasurySale
            {
                ComplianceBusinessRatingARMHoldCoId = aRMHoldingCompanyBusinessRatingId,
                DisclosureRisk = aRMHoldingCompany.Compliance.TreasurySale.DisclosureRisk,
                CorporateGovernance = aRMHoldingCompany.Compliance.TreasurySale.CorporateGovernance,
                GDPROrNDPR = aRMHoldingCompany.Compliance.TreasurySale.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = aRMHoldingCompany.Compliance.TreasurySale.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = aRMHoldingCompany.Compliance.TreasurySale.AMLCFT,
                TAT = aRMHoldingCompany.Compliance.TreasurySale.TAT,
                ChangingRegulations = aRMHoldingCompany.Compliance.TreasurySale.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = aRMHoldingCompany.Compliance.TreasurySale.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = aRMHoldingCompany.Compliance.TreasurySale.KYCChecks,
                NonComplianceWithContracts = aRMHoldingCompany.Compliance.TreasurySale.NonComplianceWithContracts,
                LitigationRisk = aRMHoldingCompany.Compliance.TreasurySale.LitigationRisk,
                Total = aRMHoldingCompany.Compliance.TreasurySale.Total
            };
        }

        public void Update(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            ComplianceBusinessRatingARMHoldCoId = aRMHoldingCompanyBusinessRatingId;
            DisclosureRisk = aRMHoldingCompany.Compliance.TreasurySale.DisclosureRisk;
            CorporateGovernance = aRMHoldingCompany.Compliance.TreasurySale.CorporateGovernance;
            GDPROrNDPR = aRMHoldingCompany.Compliance.TreasurySale.GDPROrNDPR;
            AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = aRMHoldingCompany.Compliance.TreasurySale.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses;
            AMLCFT = aRMHoldingCompany.Compliance.TreasurySale.AMLCFT;
            TAT = aRMHoldingCompany.Compliance.TreasurySale.TAT;
            ChangingRegulations = aRMHoldingCompany.Compliance.TreasurySale.ChangingRegulations;
            InaccurateComputationofRegulatoryRemittancesDelayedFilings = aRMHoldingCompany.Compliance.TreasurySale.InaccurateComputationofRegulatoryRemittancesDelayedFilings;
            KYCChecks = aRMHoldingCompany.Compliance.TreasurySale.KYCChecks;
            NonComplianceWithContracts = aRMHoldingCompany.Compliance.TreasurySale.NonComplianceWithContracts;
            LitigationRisk = aRMHoldingCompany.Compliance.TreasurySale.LitigationRisk;
            Total = aRMHoldingCompany.Compliance.TreasurySale.Total;
        }

    }

    public class CompliancesBusinessRiskRatingARMHoldCo : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceBusinessRatingARMHoldCo))]
        public Guid ComplianceBusinessRatingARMHoldCoId { get; set; }
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
        public static CompliancesBusinessRiskRatingARMHoldCo Create(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new CompliancesBusinessRiskRatingARMHoldCo
            {
                ComplianceBusinessRatingARMHoldCoId = aRMHoldingCompanyBusinessRatingId,
                DisclosureRisk = aRMHoldingCompany.Compliance.ARMHoldingCompany.DisclosureRisk,
                CorporateGovernance = aRMHoldingCompany.Compliance.ARMHoldingCompany.CorporateGovernance,
                GDPROrNDPR = aRMHoldingCompany.Compliance.ARMHoldingCompany.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = aRMHoldingCompany.Compliance.ARMHoldingCompany.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = aRMHoldingCompany.Compliance.ARMHoldingCompany.AMLCFT,
                TAT = aRMHoldingCompany.Compliance.ARMHoldingCompany.TAT,
                ChangingRegulations = aRMHoldingCompany.Compliance.ARMHoldingCompany.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = aRMHoldingCompany.Compliance.ARMHoldingCompany.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = aRMHoldingCompany.Compliance.ARMHoldingCompany.KYCChecks,
                NonComplianceWithContracts = aRMHoldingCompany.Compliance.ARMHoldingCompany.NonComplianceWithContracts,
                LitigationRisk = aRMHoldingCompany.Compliance.ARMHoldingCompany.LitigationRisk,
                Total = aRMHoldingCompany.Compliance.ARMHoldingCompany.Total
            };
        }

        public void Update(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            ComplianceBusinessRatingARMHoldCoId = aRMHoldingCompanyBusinessRatingId;
            DisclosureRisk = aRMHoldingCompany.Compliance.ARMHoldingCompany.DisclosureRisk;
            CorporateGovernance = aRMHoldingCompany.Compliance.ARMHoldingCompany.CorporateGovernance;
            GDPROrNDPR = aRMHoldingCompany.Compliance.ARMHoldingCompany.GDPROrNDPR;
            AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = aRMHoldingCompany.Compliance.ARMHoldingCompany.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses;
            AMLCFT = aRMHoldingCompany.Compliance.ARMHoldingCompany.AMLCFT;
            TAT = aRMHoldingCompany.Compliance.ARMHoldingCompany.TAT;
            ChangingRegulations = aRMHoldingCompany.Compliance.ARMHoldingCompany.ChangingRegulations;
            InaccurateComputationofRegulatoryRemittancesDelayedFilings = aRMHoldingCompany.Compliance.ARMHoldingCompany.InaccurateComputationofRegulatoryRemittancesDelayedFilings;
            KYCChecks = aRMHoldingCompany.Compliance.ARMHoldingCompany.KYCChecks;
            NonComplianceWithContracts = aRMHoldingCompany.Compliance.ARMHoldingCompany.NonComplianceWithContracts;
            LitigationRisk = aRMHoldingCompany.Compliance.ARMHoldingCompany.LitigationRisk;
            Total = aRMHoldingCompany.Compliance.ARMHoldingCompany.Total;
        }

    }

    public class TimeSinceLastAuditBusinessRatingARMHoldCo : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHoldingCompanyBusinessRating))]
        public Guid ARMHoldingCompanyBusinessRatingId { get; set; }
        public int ARMHoldingCompany { get; set; }
        public int TreasurySale { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static TimeSinceLastAuditBusinessRatingARMHoldCo Create(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            return new TimeSinceLastAuditBusinessRatingARMHoldCo
            {
                ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId,
                ARMHoldingCompany = aRMHoldingCompany.LastReportOverallRating.ARMHoldingCompany,
                TreasurySale = aRMHoldingCompany.LastReportOverallRating.TreasurySale,
                Comment = aRMHoldingCompany.LastReportOverallRating.Comment
            };
        }

        public void Update(Guid aRMHoldingCompanyBusinessRatingId, ARMHoldingCompanyRatingReq aRMHoldingCompany)
        {
            ARMHoldingCompanyBusinessRatingId = aRMHoldingCompanyBusinessRatingId;
            ARMHoldingCompany = aRMHoldingCompany.LastReportOverallRating.ARMHoldingCompany;
            TreasurySale = aRMHoldingCompany.LastReportOverallRating.TreasurySale;
            //TreasuryOperation = aRMHoldingCompany.TimeSinceLastAudit.TreasuryOperation;
            //FinancialControl = aRMHoldingCompany.TimeSinceLastAudit.FinancialControl;
            //Compliance = aRMHoldingCompany.TimeSinceLastAudit.Compliance;
            Comment = aRMHoldingCompany.LastReportOverallRating.Comment;
        }


    }

    #endregion

    #region ARM TAM 
    public class ARMTAMBusinessRiskRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategyBusinessARMTAM Strategy { get; set; }
        public OperationBusinessARMTAM Operations { get; set; }
        public FinancialBusinessARMTAM FinancialReporting { get; set; }
        public ComplianceBusinessARMTAM Compliance { get; set; }
        public TimeSinceLastBusinessARMTAMAudit TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterName { get; set; }
        public static ARMTAMBusinessRiskRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string requesterName)
        {
            return new ARMTAMBusinessRiskRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterName = requesterName
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategyBusinessARMTAM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTAMBusinessRiskRating))]
        public Guid ARMTAMBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMTAMBusinessRiskRatingId))]
        public ARMTAMBusinessRiskRating ARMTAMBusinessRiskRating { get; set; }
        public StrategyBusinessTAMRating ARMTAM { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategyBusinessARMTAM Create(Guid aarmtamBusinessRatingId, string comment)
        {
            return new StrategyBusinessARMTAM
            {
                ARMTAMBusinessRiskRatingId = aarmtamBusinessRatingId,
                Comment = comment
            };
        }

    }

    public class StrategyBusinessTAMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyBusinessARMTAM))]
        public Guid StrategyBusinessARMTAMId { get; set; }
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

        public static StrategyBusinessTAMRating Create(Guid strategyBusinessARMTAMId, ARMTAMBusinessRiskRatingReq armTAM)
        {
            return new StrategyBusinessTAMRating
            {
                StrategyBusinessARMTAMId = strategyBusinessARMTAMId,
                FluidityofTechnologicalSolutions = armTAM.Strategy.ARMTAM.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armTAM.Strategy.ARMTAM.CurrencyDevaluation,
                Increasedleverage = armTAM.Strategy.ARMTAM.Increasedleverage,
                SocialRisk = armTAM.Strategy.ARMTAM.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armTAM.Strategy.ARMTAM.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armTAM.Strategy.ARMTAM.DropinFundandFundManagerRatings,
                BCPandDRP = armTAM.Strategy.ARMTAM.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armTAM.Strategy.ARMTAM.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armTAM.Strategy.ARMTAM.AllianceandPartnershipRisks,
                EmergingRisks = armTAM.Strategy.ARMTAM.EmergingRisks,
                EnvironmentalRisk = armTAM.Strategy.ARMTAM.EnvironmentalRisk,
                ErosionofStatutoryCapital = armTAM.Strategy.ARMTAM.ErosionofStatutoryCapital,
                ReputationalRisk = armTAM.Strategy.ARMTAM.ReputationalRisk,
                RisktoProfitabilityorPerformance = armTAM.Strategy.ARMTAM.RisktoProfitabilityorPerformance,
                CreditRisk = armTAM.Strategy.ARMTAM.CreditRisk,
                SustainabilityRisk = armTAM.Strategy.ARMTAM.SustainabilityRisk,
                HealthandSafetyRisks = armTAM.Strategy.ARMTAM.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armTAM.Strategy.ARMTAM.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armTAM.Strategy.ARMTAM.FailureofInvestor,
                FlunCTOatingInterestRates = armTAM.Strategy.ARMTAM.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armTAM.Strategy.ARMTAM.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armTAM.Strategy.ARMTAM.InformationSecurityRisk,
                ExitRisk = armTAM.Strategy.ARMTAM.ExitRisk,
                InvestmentRisk = armTAM.Strategy.ARMTAM.InvestmentRisk,
                LiquidityPressures = armTAM.Strategy.ARMTAM.LiquidityPressures,
                MyLegacyIssuesProperty = armTAM.Strategy.ARMTAM.MyLegacyIssuesProperty,
                PoliticalRisk = armTAM.Strategy.ARMTAM.PoliticalRisk,
                PeopleRetentionRisk = armTAM.Strategy.ARMTAM.PeopleRetentionRisk,
                ProductivityRisk = armTAM.Strategy.ARMTAM.ProductivityRisk,
                ProjectManagementRisk = armTAM.Strategy.ARMTAM.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armTAM.Strategy.ARMTAM.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armTAM.Strategy.ARMTAM.TechnologicalRisk,
                Total = armTAM.Strategy.ARMTAM.Total
            };
        }

    }

    public class OperationBusinessARMTAM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTAMBusinessRiskRating))]
        public Guid ARMTAMBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMTAMBusinessRiskRatingId))]
        public ARMTAMBusinessRiskRating ARMTAMBusinessRiskRating { get; set; }
        public OperationBusinessTAMRating ARMTAM { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationBusinessARMTAM Create(Guid armTAMBusinessRiskRatingId, string comment)
        {
            return new OperationBusinessARMTAM
            {
                ARMTAMBusinessRiskRatingId = armTAMBusinessRiskRatingId,
                Comment = comment
            };
        }

    }

    public class OperationBusinessTAMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationBusinessARMTAM))]
        public Guid OperationBusinessARMTAMId { get; set; }
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
        public static OperationBusinessTAMRating Create(Guid operationBusinessARMTAMId, ARMTAMBusinessRiskRatingReq armTAM)
        {
            return new OperationBusinessTAMRating
            {
                OperationBusinessARMTAMId = operationBusinessARMTAMId,
                AdoptionandImplementationofPolicies = armTAM.Operations.ARMTAM.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armTAM.Operations.ARMTAM.StrategyMonitoringRisk,
                BudgetOverruns = armTAM.Operations.ARMTAM.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armTAM.Operations.ARMTAM.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armTAM.Operations.ARMTAM.OverorUnderpaymentofClient,
                TheftorFraudRisk = armTAM.Operations.ARMTAM.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armTAM.Operations.ARMTAM.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armTAM.Operations.ARMTAM.TAT,
                ThirdpartyRisk = armTAM.Operations.ARMTAM.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armTAM.Operations.ARMTAM.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armTAM.Operations.ARMTAM.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armTAM.Operations.ARMTAM.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armTAM.Operations.ARMTAM.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armTAM.Operations.ARMTAM.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armTAM.Operations.ARMTAM.ProductivityRisk,
                RecruitmentRisk = armTAM.Operations.ARMTAM.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armTAM.Operations.ARMTAM.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armTAM.Operations.ARMTAM.ErrorDetectionRisk,
                PoorCustomerService = armTAM.Operations.ARMTAM.PoorCustomerService,
                UnauthorizedAccess = armTAM.Operations.ARMTAM.UnauthorizedAccess,
                Total = armTAM.Operations.ARMTAM.Total

            };
        }

    }

    public class FinancialBusinessARMTAM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTAMBusinessRiskRating))]
        public Guid ARMTAMBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMTAMBusinessRiskRatingId))]
        public ARMTAMBusinessRiskRating ARMTAMBusinessRiskRating { get; set; }
        public FinacialBusinessTAMRating ARMTAM { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialBusinessARMTAM Create(Guid armTAMBusinessRiskRatingId, string comment)
        {
            return new FinancialBusinessARMTAM
            {
                ARMTAMBusinessRiskRatingId = armTAMBusinessRiskRatingId,
                Comment = comment
            };
        }
    }

    public class FinacialBusinessTAMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialBusinessARMTAM))]
        public Guid FinancialBusinessARMTAMId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialBusinessTAMRating Create(Guid financialBusinessARMTAMId, ARMTAMBusinessRiskRatingReq armTAM)
        {
            return new FinacialBusinessTAMRating
            {
                FinancialBusinessARMTAMId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armTAM.FinancialReporting.ARMTAM.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armTAM.FinancialReporting.ARMTAM.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armTAM.FinancialReporting.ARMTAM.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armTAM.FinancialReporting.ARMTAM.ErrororControlRisk,
                IncomeAssuranceRisk = armTAM.FinancialReporting.ARMTAM.IncomeAssuranceRisk,
                TAT = armTAM.FinancialReporting.ARMTAM.TAT,
                TheftorFraudRisk = armTAM.FinancialReporting.ARMTAM.TheftorFraudRisk,
                Total = armTAM.FinancialReporting.ARMTAM.Total
            };
        }

    }

    public class ComplianceBusinessARMTAM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTAMBusinessRiskRating))]
        public Guid ARMTAMBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMTAMBusinessRiskRatingId))]
        public ARMTAMBusinessRiskRating ARMTAMBusinessRiskRating { get; set; }
        public ComplianceBusinessTAMRating ARMTAM { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceBusinessARMTAM Create(Guid armTAMBusinessRiskRatingId, string comment)
        {
            return new ComplianceBusinessARMTAM
            {
                ARMTAMBusinessRiskRatingId = armTAMBusinessRiskRatingId,
                Comment = comment
            };
        }

    }

    public class ComplianceBusinessTAMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceBusinessARMTAM))]
        public Guid ComplianceBusinessARMTAMId { get; set; }
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
        public static ComplianceBusinessTAMRating Create(Guid complianceTAMId, ARMTAMBusinessRiskRatingReq armTAM)
        {
            return new ComplianceBusinessTAMRating
            {
                ComplianceBusinessARMTAMId = complianceTAMId,
                DisclosureRisk = armTAM.Compliance.ARMTAM.DisclosureRisk,
                CorporateGovernance = armTAM.Compliance.ARMTAM.CorporateGovernance,
                GDPROrNDPR = armTAM.Compliance.ARMTAM.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armTAM.Compliance.ARMTAM.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armTAM.Compliance.ARMTAM.AMLCFT,
                TAT = armTAM.Compliance.ARMTAM.TAT,
                ChangingRegulations = armTAM.Compliance.ARMTAM.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armTAM.Compliance.ARMTAM.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armTAM.Compliance.ARMTAM.KYCChecks,
                NonComplianceWithContracts = armTAM.Compliance.ARMTAM.NonComplianceWithContracts,
                LitigationRisk = armTAM.Compliance.ARMTAM.LitigationRisk,
                //TheftorFraudRisk = armTAM.Compliance.ARMTAM.TheftorFraudRisk,
                Total = armTAM.Compliance.ARMTAM.Total
            };
        }
    }

    public class TimeSinceLastBusinessARMTAMAudit : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTAMBusinessRiskRating))]
        public Guid ARMTAMBusinessRiskRatingId { get; set; }
        public int ARMTAM { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static TimeSinceLastBusinessARMTAMAudit Create(Guid aRMTAMBusinessRiskRatingId, ARMTAMBusinessRiskRatingReq armTAM)
        {
            return new TimeSinceLastBusinessARMTAMAudit
            {
                ARMTAMBusinessRiskRatingId = aRMTAMBusinessRiskRatingId,
                ARMTAM = armTAM.LastReportOverallRating.ARMTAM,
                //TreasuryOperation = armTAM.TimeSinceLastAudit.TreasuryOperation,
                //FinancialControl = armTAM.TimeSinceLastAudit.FinancialControl,
                Comment = armTAM.LastReportOverallRating.Comment
            };
        }
    }
    #endregion

    #region ARM Security
    public class ARMSecurityRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategySecurityBusinessRating Strategy { get; set; }
        public OperationSecurityBusinessRating Operations { get; set; }
        public FinancialSecurityReporting FinancialReporting { get; set; }
        public ComplianceSecurity Compliance { get; set; }
        public TimeSinceLastSecurityAudit TimeSinceLastAudit { get; set; }
        public string? RequesterName { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public static ARMSecurityRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string requesterName)
        {
            return new ARMSecurityRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterName = requesterName
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategySecurityBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityRating))]
        public Guid ARMSecurityRatingId { get; set; }
        [ForeignKey(nameof(ARMSecurityRatingId))]
        public ARMSecurityRating ARMSecurityRating { get; set; }
        public StrategySecurityRatingStockBroking StockBroking { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategySecurityBusinessRating Create(Guid armSecurityRatingId, string comment)
        {
            return new StrategySecurityBusinessRating
            {
                ARMSecurityRatingId = armSecurityRatingId,
                Comment = comment
            };
        }
    }

    public class StrategySecurityRatingStockBroking : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySecurityBusinessRating))]
        public Guid StrategySecurityBusinessRatingId { get; set; }
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
        public static StrategySecurityRatingStockBroking Create(Guid strategySecurityBusinessRatingId, ARMSecurityRatingReq armsecurity)
        {
            return new StrategySecurityRatingStockBroking
            {
                StrategySecurityBusinessRatingId = strategySecurityBusinessRatingId,
                FluidityofTechnologicalSolutions = armsecurity.Strategy.StockBroking.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armsecurity.Strategy.StockBroking.CurrencyDevaluation,
                Increasedleverage = armsecurity.Strategy.StockBroking.Increasedleverage,
                SocialRisk = armsecurity.Strategy.StockBroking.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armsecurity.Strategy.StockBroking.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armsecurity.Strategy.StockBroking.DropinFundandFundManagerRatings,
                BCPandDRP = armsecurity.Strategy.StockBroking.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armsecurity.Strategy.StockBroking.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armsecurity.Strategy.StockBroking.AllianceandPartnershipRisks,
                EmergingRisks = armsecurity.Strategy.StockBroking.EmergingRisks,
                EnvironmentalRisk = armsecurity.Strategy.StockBroking.EnvironmentalRisk,
                ErosionofStatutoryCapital = armsecurity.Strategy.StockBroking.ErosionofStatutoryCapital,
                ReputationalRisk = armsecurity.Strategy.StockBroking.ReputationalRisk,
                RisktoProfitabilityorPerformance = armsecurity.Strategy.StockBroking.RisktoProfitabilityorPerformance,
                CreditRisk = armsecurity.Strategy.StockBroking.CreditRisk,
                SustainabilityRisk = armsecurity.Strategy.StockBroking.SustainabilityRisk,
                HealthandSafetyRisks = armsecurity.Strategy.StockBroking.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armsecurity.Strategy.StockBroking.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armsecurity.Strategy.StockBroking.FailureofInvestor,
                FlunCTOatingInterestRates = armsecurity.Strategy.StockBroking.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armsecurity.Strategy.StockBroking.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armsecurity.Strategy.StockBroking.InformationSecurityRisk,
                ExitRisk = armsecurity.Strategy.StockBroking.ExitRisk,
                InvestmentRisk = armsecurity.Strategy.StockBroking.InvestmentRisk,
                LiquidityPressures = armsecurity.Strategy.StockBroking.LiquidityPressures,
                MyLegacyIssuesProperty = armsecurity.Strategy.StockBroking.MyLegacyIssuesProperty,
                PoliticalRisk = armsecurity.Strategy.StockBroking.PoliticalRisk,
                PeopleRetentionRisk = armsecurity.Strategy.StockBroking.PeopleRetentionRisk,
                ProductivityRisk = armsecurity.Strategy.StockBroking.ProductivityRisk,
                ProjectManagementRisk = armsecurity.Strategy.StockBroking.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armsecurity.Strategy.StockBroking.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armsecurity.Strategy.StockBroking.TechnologicalRisk,
                Total = armsecurity.Strategy.StockBroking.Total
            };
        }

    }
  
    public class OperationSecurityBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityRating))]
        public Guid ARMSecurityRatingId { get; set; }
        public ARMSecurityRating ARMSecurityRating { get; set; }
        public OperationSecurityRatingStockBroking StockBroking { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationSecurityBusinessRating Create(Guid armSecurityRatingId, string comment)
        {
            return new OperationSecurityBusinessRating
            {
                ARMSecurityRatingId = armSecurityRatingId,
                Comment = comment
            };
        }
    }
    public class OperationSecurityRatingStockBroking : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSecurityBusinessRating))]
        public Guid OperationSecurityBusinessRatingId { get; set; }
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
        public static OperationSecurityRatingStockBroking Create(Guid operationSecurityId, ARMSecurityRatingReq armsecurity)
        {
            return new OperationSecurityRatingStockBroking
            {
                OperationSecurityBusinessRatingId = operationSecurityId,
                AdoptionandImplementationofPolicies = armsecurity.Operations.StockBroking.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armsecurity.Operations.StockBroking.StrategyMonitoringRisk,
                BudgetOverruns = armsecurity.Operations.StockBroking.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armsecurity.Operations.StockBroking.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armsecurity.Operations.StockBroking.OverorUnderpaymentofClient,
                TheftorFraudRisk = armsecurity.Operations.StockBroking.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armsecurity.Operations.StockBroking.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armsecurity.Operations.StockBroking.TAT,
                ThirdpartyRisk = armsecurity.Operations.StockBroking.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armsecurity.Operations.StockBroking.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armsecurity.Operations.StockBroking.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armsecurity.Operations.StockBroking.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armsecurity.Operations.StockBroking.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armsecurity.Operations.StockBroking.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armsecurity.Operations.StockBroking.ProductivityRisk,
                RecruitmentRisk = armsecurity.Operations.StockBroking.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armsecurity.Operations.StockBroking.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armsecurity.Operations.StockBroking.ErrorDetectionRisk,
                PoorCustomerService = armsecurity.Operations.StockBroking.PoorCustomerService,
                UnauthorizedAccess = armsecurity.Operations.StockBroking.UnauthorizedAccess,
                Total = armsecurity.Operations.StockBroking.Total

            };
        }


    }
    public class FinancialSecurityReporting : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityRating))]
        public Guid ARMSecurityRatingId { get; set; }
        public ARMSecurityRating ARMSecurityRating { get; set; }
        public FinacialSecurityRatingStockBroking StockBroking { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialSecurityReporting Create(Guid armSecurityRatingId, string comment)
        {
            return new FinancialSecurityReporting
            {
                ARMSecurityRatingId = armSecurityRatingId,
                Comment = comment
            };
        }
    }
    public class FinacialSecurityRatingStockBroking : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialSecurityReporting))]
        public Guid FinancialSecurityReportingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialSecurityRatingStockBroking Create(Guid financialSecurityReportingId, ARMSecurityRatingReq armsecurity)
        {
            return new FinacialSecurityRatingStockBroking
            {
                FinancialSecurityReportingId = financialSecurityReportingId,
                AdherencetoFinancialStandards = armsecurity.FinancialReporting.StockBroking.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armsecurity.FinancialReporting.StockBroking.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armsecurity.FinancialReporting.StockBroking.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armsecurity.FinancialReporting.StockBroking.ErrororControlRisk,
                IncomeAssuranceRisk = armsecurity.FinancialReporting.StockBroking.IncomeAssuranceRisk,
                TAT = armsecurity.FinancialReporting.StockBroking.TAT,
                TheftorFraudRisk = armsecurity.FinancialReporting.StockBroking.TheftorFraudRisk,
                Total = armsecurity.FinancialReporting.StockBroking.Total
            };
        }

    }
    public class ComplianceSecurity : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityRating))]
        public Guid ARMSecurityRatingId { get; set; }
        [ForeignKey(nameof(ARMSecurityRatingId))]
        public ARMSecurityRating ARMSecurityRating { get; set; }
        public ComplianceSecurityRatingStockBroking StockBroking { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceSecurity Create(Guid armSecurityRatingId, string comment)
        {
            return new ComplianceSecurity
            {
                ARMSecurityRatingId = armSecurityRatingId,
                Comment = comment
            };
        }

    }
    public class ComplianceSecurityRatingStockBroking : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSecurity))]
        public Guid ComplianceSecurityId { get; set; }
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
        public static ComplianceSecurityRatingStockBroking Create(Guid complianceSecurityId, ARMSecurityRatingReq armsecurity)
        {
            return new ComplianceSecurityRatingStockBroking
            {
                ComplianceSecurityId = complianceSecurityId,
                DisclosureRisk = armsecurity.Compliance.StockBroking.DisclosureRisk,
                CorporateGovernance = armsecurity.Compliance.StockBroking.CorporateGovernance,
                GDPROrNDPR = armsecurity.Compliance.StockBroking.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armsecurity.Compliance.StockBroking.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armsecurity.Compliance.StockBroking.AMLCFT,
                TAT = armsecurity.Compliance.StockBroking.TAT,
                ChangingRegulations = armsecurity.Compliance.StockBroking.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armsecurity.Compliance.StockBroking.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armsecurity.Compliance.StockBroking.KYCChecks,
                NonComplianceWithContracts = armsecurity.Compliance.StockBroking.NonComplianceWithContracts,
                LitigationRisk = armsecurity.Compliance.StockBroking.LitigationRisk,
                Total = armsecurity.Compliance.StockBroking.Total
            };
        }
    }
    public class TimeSinceLastSecurityAudit : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityRating))]
        public Guid ARMSecurityRatingId { get; set; }
        public int StockBroking { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static TimeSinceLastSecurityAudit Create(Guid armSecurityRatingId, ARMSecurityRatingReq armsecurity)
        {
            return new TimeSinceLastSecurityAudit
            {
                ARMSecurityRatingId = armSecurityRatingId,
                StockBroking = armsecurity.LastReportOverallRating.StockBroking,
                Comment = armsecurity.LastReportOverallRating.Comment

            };
        }
    }

    #endregion

    #region ARM Trustee
    public class ARMTrusteeRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategyBusinessRatingTrustee Strategy { get; set; }
        public OperationTrustee Operations { get; set; }
        public FinancialTrusteeReporting FinancialReporting { get; set; }
        public ComplianceBusinessRatingTrustee Compliance { get; set; }
        public TimeSinceLastTrusteeAudit TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterName { get; set; }
        public static ARMTrusteeRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string requesterName)
        {
            return new ARMTrusteeRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterName = requesterName
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategyBusinessRatingTrustee : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTrusteeRating))]
        public Guid ARMTrusteeRatingId { get; set; }
        public ARMTrusteeRating ARMTrusteeRating { get; set; }
        public StrategyTrusteeRatingPrivateTrust PrivateTrust { get; set; }
        public StrategyTrusteeRatingCommercialTrust CommercialTrust { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategyBusinessRatingTrustee Create(Guid armTrusteeRatingId, string comment)
        {
            return new StrategyBusinessRatingTrustee
            {
                ARMTrusteeRatingId = armTrusteeRatingId,
                Comment = comment
            };
        }

    }
    public class StrategyTrusteeRatingCommercialTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyBusinessRatingTrustee))]
        public Guid StrategyBusinessRatingTrusteeId { get; set; }
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
        public static StrategyTrusteeRatingCommercialTrust Create(Guid strategyTrusteeRatingId, ARMTrusteeRatingReq armTrustee)
        {
            return new StrategyTrusteeRatingCommercialTrust
            {
                StrategyBusinessRatingTrusteeId = strategyTrusteeRatingId,
                FluidityofTechnologicalSolutions = armTrustee.Strategy.CommercialTrust.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armTrustee.Strategy.CommercialTrust.CurrencyDevaluation,
                Increasedleverage = armTrustee.Strategy.CommercialTrust.Increasedleverage,
                SocialRisk = armTrustee.Strategy.CommercialTrust.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armTrustee.Strategy.CommercialTrust.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armTrustee.Strategy.CommercialTrust.DropinFundandFundManagerRatings,
                BCPandDRP = armTrustee.Strategy.CommercialTrust.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armTrustee.Strategy.CommercialTrust.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armTrustee.Strategy.CommercialTrust.AllianceandPartnershipRisks,
                EmergingRisks = armTrustee.Strategy.CommercialTrust.EmergingRisks,
                EnvironmentalRisk = armTrustee.Strategy.CommercialTrust.EnvironmentalRisk,
                ErosionofStatutoryCapital = armTrustee.Strategy.CommercialTrust.ErosionofStatutoryCapital,
                ReputationalRisk = armTrustee.Strategy.CommercialTrust.ReputationalRisk,
                RisktoProfitabilityorPerformance = armTrustee.Strategy.CommercialTrust.RisktoProfitabilityorPerformance,
                CreditRisk = armTrustee.Strategy.CommercialTrust.CreditRisk,
                SustainabilityRisk = armTrustee.Strategy.CommercialTrust.SustainabilityRisk,
                HealthandSafetyRisks = armTrustee.Strategy.CommercialTrust.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armTrustee.Strategy.CommercialTrust.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armTrustee.Strategy.CommercialTrust.FailureofInvestor,
                FlunCTOatingInterestRates = armTrustee.Strategy.CommercialTrust.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armTrustee.Strategy.CommercialTrust.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armTrustee.Strategy.CommercialTrust.InformationSecurityRisk,
                ExitRisk = armTrustee.Strategy.CommercialTrust.ExitRisk,
                InvestmentRisk = armTrustee.Strategy.CommercialTrust.InvestmentRisk,
                LiquidityPressures = armTrustee.Strategy.CommercialTrust.LiquidityPressures,
                MyLegacyIssuesProperty = armTrustee.Strategy.CommercialTrust.MyLegacyIssuesProperty,
                PoliticalRisk = armTrustee.Strategy.CommercialTrust.PoliticalRisk,
                PeopleRetentionRisk = armTrustee.Strategy.CommercialTrust.PeopleRetentionRisk,
                ProductivityRisk = armTrustee.Strategy.CommercialTrust.ProductivityRisk,
                ProjectManagementRisk = armTrustee.Strategy.CommercialTrust.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armTrustee.Strategy.CommercialTrust.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armTrustee.Strategy.CommercialTrust.TechnologicalRisk,
                Total = armTrustee.Strategy.CommercialTrust.Total
            };
        }

    }
    public class StrategyTrusteeRatingPrivateTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyBusinessRatingTrustee))]
        public Guid StrategyBusinessRatingTrusteeId { get; set; }
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
        public static StrategyTrusteeRatingPrivateTrust Create(Guid strategyTrusteeRatingId, ARMTrusteeRatingReq armTrustee)
        {
            return new StrategyTrusteeRatingPrivateTrust
            {
                StrategyBusinessRatingTrusteeId = strategyTrusteeRatingId,
                FluidityofTechnologicalSolutions = armTrustee.Strategy.PrivateTrust.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armTrustee.Strategy.PrivateTrust.CurrencyDevaluation,
                Increasedleverage = armTrustee.Strategy.PrivateTrust.Increasedleverage,
                SocialRisk = armTrustee.Strategy.PrivateTrust.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armTrustee.Strategy.PrivateTrust.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armTrustee.Strategy.PrivateTrust.DropinFundandFundManagerRatings,
                BCPandDRP = armTrustee.Strategy.PrivateTrust.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armTrustee.Strategy.PrivateTrust.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armTrustee.Strategy.PrivateTrust.AllianceandPartnershipRisks,
                EmergingRisks = armTrustee.Strategy.PrivateTrust.EmergingRisks,
                EnvironmentalRisk = armTrustee.Strategy.PrivateTrust.EnvironmentalRisk,
                ErosionofStatutoryCapital = armTrustee.Strategy.PrivateTrust.ErosionofStatutoryCapital,
                ReputationalRisk = armTrustee.Strategy.PrivateTrust.ReputationalRisk,
                RisktoProfitabilityorPerformance = armTrustee.Strategy.PrivateTrust.RisktoProfitabilityorPerformance,
                CreditRisk = armTrustee.Strategy.PrivateTrust.CreditRisk,
                SustainabilityRisk = armTrustee.Strategy.PrivateTrust.SustainabilityRisk,
                HealthandSafetyRisks = armTrustee.Strategy.PrivateTrust.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armTrustee.Strategy.PrivateTrust.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armTrustee.Strategy.PrivateTrust.FailureofInvestor,
                FlunCTOatingInterestRates = armTrustee.Strategy.PrivateTrust.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armTrustee.Strategy.PrivateTrust.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armTrustee.Strategy.PrivateTrust.InformationSecurityRisk,
                ExitRisk = armTrustee.Strategy.PrivateTrust.ExitRisk,
                InvestmentRisk = armTrustee.Strategy.PrivateTrust.InvestmentRisk,
                LiquidityPressures = armTrustee.Strategy.PrivateTrust.LiquidityPressures,
                MyLegacyIssuesProperty = armTrustee.Strategy.PrivateTrust.MyLegacyIssuesProperty,
                PoliticalRisk = armTrustee.Strategy.PrivateTrust.PoliticalRisk,
                PeopleRetentionRisk = armTrustee.Strategy.PrivateTrust.PeopleRetentionRisk,
                ProductivityRisk = armTrustee.Strategy.PrivateTrust.ProductivityRisk,
                ProjectManagementRisk = armTrustee.Strategy.PrivateTrust.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armTrustee.Strategy.PrivateTrust.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armTrustee.Strategy.PrivateTrust.TechnologicalRisk,
                Total = armTrustee.Strategy.PrivateTrust.Total
            };
        }

    }

    public class OperationTrustee : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTrusteeRating))]
        public Guid ARMTrusteeRatingId { get; set; }
        public ARMTrusteeRating ARMTrusteeRating { get; set; }
        public OperationTrusteeRatingPrivateTrust PrivateTrust { get; set; }
        public OperationTrusteeRatingCommercialTrust CommercialTrust { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationTrustee Create(Guid armTrusteeRatingId, string comment)
        {
            return new OperationTrustee
            {
                ARMTrusteeRatingId = armTrusteeRatingId,
                Comment = comment
            };
        }
    }

    public class OperationTrusteeRatingCommercialTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationTrustee))]
        public Guid OperationTrusteeId { get; set; }
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
        public static OperationTrusteeRatingCommercialTrust Create(Guid operationTrusteeId, ARMTrusteeRatingReq armTrustee)
        {
            return new OperationTrusteeRatingCommercialTrust
            {
                OperationTrusteeId = operationTrusteeId,
                AdoptionandImplementationofPolicies = armTrustee.Operations.CommercialTrust.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armTrustee.Operations.CommercialTrust.StrategyMonitoringRisk,
                BudgetOverruns = armTrustee.Operations.CommercialTrust.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armTrustee.Operations.CommercialTrust.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armTrustee.Operations.CommercialTrust.OverorUnderpaymentofClient,
                TheftorFraudRisk = armTrustee.Operations.CommercialTrust.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armTrustee.Operations.CommercialTrust.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armTrustee.Operations.CommercialTrust.TAT,
                ThirdpartyRisk = armTrustee.Operations.CommercialTrust.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armTrustee.Operations.CommercialTrust.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armTrustee.Operations.CommercialTrust.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armTrustee.Operations.CommercialTrust.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armTrustee.Operations.CommercialTrust.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armTrustee.Operations.CommercialTrust.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armTrustee.Operations.CommercialTrust.ProductivityRisk,
                RecruitmentRisk = armTrustee.Operations.CommercialTrust.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armTrustee.Operations.CommercialTrust.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armTrustee.Operations.CommercialTrust.ErrorDetectionRisk,
                PoorCustomerService = armTrustee.Operations.CommercialTrust.PoorCustomerService,
                UnauthorizedAccess = armTrustee.Operations.CommercialTrust.UnauthorizedAccess,
                Total = armTrustee.Operations.CommercialTrust.Total

            };
        }


    }
    public class OperationTrusteeRatingPrivateTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationTrustee))]
        public Guid OperationTrusteeId { get; set; }
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
        public static OperationTrusteeRatingPrivateTrust Create(Guid operationTrusteeId, ARMTrusteeRatingReq armTrustee)
        {
            return new OperationTrusteeRatingPrivateTrust
            {
                OperationTrusteeId = operationTrusteeId,
                AdoptionandImplementationofPolicies = armTrustee.Operations.PrivateTrust.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armTrustee.Operations.PrivateTrust.StrategyMonitoringRisk,
                BudgetOverruns = armTrustee.Operations.PrivateTrust.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armTrustee.Operations.PrivateTrust.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armTrustee.Operations.PrivateTrust.OverorUnderpaymentofClient,
                TheftorFraudRisk = armTrustee.Operations.PrivateTrust.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armTrustee.Operations.PrivateTrust.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armTrustee.Operations.PrivateTrust.TAT,
                ThirdpartyRisk = armTrustee.Operations.PrivateTrust.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armTrustee.Operations.PrivateTrust.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armTrustee.Operations.PrivateTrust.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armTrustee.Operations.PrivateTrust.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armTrustee.Operations.PrivateTrust.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armTrustee.Operations.PrivateTrust.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armTrustee.Operations.PrivateTrust.ProductivityRisk,
                RecruitmentRisk = armTrustee.Operations.PrivateTrust.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armTrustee.Operations.PrivateTrust.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armTrustee.Operations.PrivateTrust.ErrorDetectionRisk,
                PoorCustomerService = armTrustee.Operations.PrivateTrust.PoorCustomerService,
                UnauthorizedAccess = armTrustee.Operations.PrivateTrust.UnauthorizedAccess,
                Total = armTrustee.Operations.PrivateTrust.Total

            };
        }


    }

    public class FinancialTrusteeReporting : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTrusteeRating))]
        public Guid ARMTrusteeRatingId { get; set; }
        public ARMTrusteeRating ARMTrusteeRating { get; set; }
        public FinacialTrusteeRatingPrivateTrust PrivateTrust { get; set; }
        public FinacialTrusteeRatingCommercialTrust CommercialTrust { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialTrusteeReporting Create(Guid armTrusteeRatingId, string comment)
        {
            return new FinancialTrusteeReporting
            {
                ARMTrusteeRatingId = armTrusteeRatingId,
                Comment = comment
            };
        }
    }
    public class FinacialTrusteeRatingCommercialTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialTrusteeReporting))]
        public Guid FinancialTrusteeReportingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialTrusteeRatingCommercialTrust Create(Guid financialTrusteeReportingId, ARMTrusteeRatingReq armTrustee)
        {
            return new FinacialTrusteeRatingCommercialTrust
            {
                FinancialTrusteeReportingId = financialTrusteeReportingId,
                AdherencetoFinancialStandards = armTrustee.FinancialReporting.CommercialTrust.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armTrustee.FinancialReporting.CommercialTrust.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armTrustee.FinancialReporting.CommercialTrust.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armTrustee.FinancialReporting.CommercialTrust.ErrororControlRisk,
                IncomeAssuranceRisk = armTrustee.FinancialReporting.CommercialTrust.IncomeAssuranceRisk,
                TAT = armTrustee.FinancialReporting.CommercialTrust.TAT,
                TheftorFraudRisk = armTrustee.FinancialReporting.CommercialTrust.TheftorFraudRisk,
                Total = armTrustee.FinancialReporting.CommercialTrust.Total
            };
        }


    }
    public class FinacialTrusteeRatingPrivateTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialTrusteeReporting))]
        public Guid FinancialTrusteeReportingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialTrusteeRatingPrivateTrust Create(Guid financialTrusteeReportingId, ARMTrusteeRatingReq armTrustee)
        {
            return new FinacialTrusteeRatingPrivateTrust
            {
                FinancialTrusteeReportingId = financialTrusteeReportingId,
                AdherencetoFinancialStandards = armTrustee.FinancialReporting.PrivateTrust.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armTrustee.FinancialReporting.PrivateTrust.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armTrustee.FinancialReporting.PrivateTrust.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armTrustee.FinancialReporting.PrivateTrust.ErrororControlRisk,
                IncomeAssuranceRisk = armTrustee.FinancialReporting.PrivateTrust.IncomeAssuranceRisk,
                TAT = armTrustee.FinancialReporting.PrivateTrust.TAT,
                TheftorFraudRisk = armTrustee.FinancialReporting.PrivateTrust.TheftorFraudRisk,
                Total = armTrustee.FinancialReporting.PrivateTrust.Total
            };
        }


    }

    public class ComplianceBusinessRatingTrustee : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTrusteeRating))]
        public Guid ARMTrusteeRatingId { get; set; }
        [ForeignKey(nameof(ARMTrusteeRatingId))]
        public ARMTrusteeRating ARMTrusteeRating { get; set; }
        public ComplianceTrusteeRatingPrivateTrust PrivateTrust { get; set; }
        public ComplianceTrusteeRatingCommercialTrust CommercialTrust { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceBusinessRatingTrustee Create(Guid armTrusteeRatingId, string comment)
        {
            return new ComplianceBusinessRatingTrustee
            {
                ARMTrusteeRatingId = armTrusteeRatingId,
                Comment = comment
            };
        }

    }

    public class ComplianceTrusteeRatingCommercialTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceBusinessRatingTrustee))]
        public Guid ComplianceBusinessRatingTrusteeId { get; set; }
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
        public static ComplianceTrusteeRatingCommercialTrust Create(Guid complianceTrusteeId, ARMTrusteeRatingReq armtrustee)
        {
            return new ComplianceTrusteeRatingCommercialTrust
            {
                ComplianceBusinessRatingTrusteeId = complianceTrusteeId,
                DisclosureRisk = armtrustee.Compliance.CommercialTrust.DisclosureRisk,
                CorporateGovernance = armtrustee.Compliance.CommercialTrust.CorporateGovernance,
                GDPROrNDPR = armtrustee.Compliance.CommercialTrust.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armtrustee.Compliance.CommercialTrust.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armtrustee.Compliance.CommercialTrust.AMLCFT,
                TAT = armtrustee.Compliance.CommercialTrust.TAT,
                ChangingRegulations = armtrustee.Compliance.CommercialTrust.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armtrustee.Compliance.CommercialTrust.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armtrustee.Compliance.CommercialTrust.KYCChecks,
                NonComplianceWithContracts = armtrustee.Compliance.CommercialTrust.NonComplianceWithContracts,
                LitigationRisk = armtrustee.Compliance.CommercialTrust.LitigationRisk,
                Total = armtrustee.Compliance.CommercialTrust.Total
            };
        }
    }
    public class ComplianceTrusteeRatingPrivateTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceBusinessRatingTrustee))]
        public Guid ComplianceBusinessRatingTrusteeId { get; set; }
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
        public static ComplianceTrusteeRatingPrivateTrust Create(Guid complianceTrusteeId, ARMTrusteeRatingReq armtrustee)
        {
            return new ComplianceTrusteeRatingPrivateTrust
            {
                ComplianceBusinessRatingTrusteeId = complianceTrusteeId,
                DisclosureRisk = armtrustee.Compliance.PrivateTrust.DisclosureRisk,
                CorporateGovernance = armtrustee.Compliance.PrivateTrust.CorporateGovernance,
                GDPROrNDPR = armtrustee.Compliance.PrivateTrust.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armtrustee.Compliance.PrivateTrust.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armtrustee.Compliance.PrivateTrust.AMLCFT,
                TAT = armtrustee.Compliance.PrivateTrust.TAT,
                ChangingRegulations = armtrustee.Compliance.PrivateTrust.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armtrustee.Compliance.PrivateTrust.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armtrustee.Compliance.PrivateTrust.KYCChecks,
                NonComplianceWithContracts = armtrustee.Compliance.PrivateTrust.NonComplianceWithContracts,
                LitigationRisk = armtrustee.Compliance.PrivateTrust.LitigationRisk,
                Total = armtrustee.Compliance.PrivateTrust.Total
            };
        }
    }

    public class TimeSinceLastTrusteeAudit : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTrusteeRating))]
        public Guid ARMTrusteeRatingId { get; set; }
        public int PrivateTrust { get; set; }
        public int CommercialTrust { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static TimeSinceLastTrusteeAudit Create(Guid armTrusteeRatingId, ARMTrusteeRatingReq armtrustee)
        {
            return new TimeSinceLastTrusteeAudit
            {
                ARMTrusteeRatingId = armTrusteeRatingId,
                PrivateTrust = armtrustee.LastReportOverallRating.PrivateTrust,
                CommercialTrust = armtrustee.LastReportOverallRating.CommercialTrust,
                Comment = armtrustee.LastReportOverallRating.Comment

            };
        }
    }

    #endregion

    #region ARM Hill
    public class ARMHillRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategyBusinessRatingARMHill Strategy { get; set; }
        public OperationBusinessRatingHill Operations { get; set; }
        public FinancialHillReporting FinancialReporting { get; set; }
        public ComplianceBusinessRatingHill Compliance { get; set; }
        public TimeSinceLastHillAudit TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterEmail { get; set; }
        public static ARMHillRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string email)
        {
            return new ARMHillRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterEmail = email
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategyBusinessRatingARMHill : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHillRating))]
        public Guid ARMHillRatingId { get; set; }
        [ForeignKey(nameof(ARMHillRatingId))]
        public ARMHillRating ARMHillRating { get; set; }
        public StrategyHillRating ARMHill { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategyBusinessRatingARMHill Create(Guid armHillRatingId, string comment)
        {
            return new StrategyBusinessRatingARMHill
            {
                ARMHillRatingId = armHillRatingId,
                Comment = comment
            };
        }
    }

    public class StrategyHillRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyBusinessRatingARMHill))]
        public Guid StrategyBusinessRatingARMHillId { get; set; }
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
        public static StrategyHillRating Create(Guid strategyTrusteeRatingId, ARMHillRatingReq armhill)
        {
            return new StrategyHillRating
            {
                StrategyBusinessRatingARMHillId = strategyTrusteeRatingId,
                FluidityofTechnologicalSolutions = armhill.Strategy.ARMHill.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armhill.Strategy.ARMHill.CurrencyDevaluation,
                Increasedleverage = armhill.Strategy.ARMHill.Increasedleverage,
                SocialRisk = armhill.Strategy.ARMHill.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armhill.Strategy.ARMHill.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armhill.Strategy.ARMHill.DropinFundandFundManagerRatings,
                BCPandDRP = armhill.Strategy.ARMHill.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armhill.Strategy.ARMHill.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armhill.Strategy.ARMHill.AllianceandPartnershipRisks,
                EmergingRisks = armhill.Strategy.ARMHill.EmergingRisks,
                EnvironmentalRisk = armhill.Strategy.ARMHill.EnvironmentalRisk,
                ErosionofStatutoryCapital = armhill.Strategy.ARMHill.ErosionofStatutoryCapital,
                ReputationalRisk = armhill.Strategy.ARMHill.ReputationalRisk,
                RisktoProfitabilityorPerformance = armhill.Strategy.ARMHill.RisktoProfitabilityorPerformance,
                CreditRisk = armhill.Strategy.ARMHill.CreditRisk,
                SustainabilityRisk = armhill.Strategy.ARMHill.SustainabilityRisk,
                HealthandSafetyRisks = armhill.Strategy.ARMHill.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armhill.Strategy.ARMHill.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armhill.Strategy.ARMHill.FailureofInvestor,
                FlunCTOatingInterestRates = armhill.Strategy.ARMHill.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armhill.Strategy.ARMHill.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armhill.Strategy.ARMHill.InformationSecurityRisk,
                ExitRisk = armhill.Strategy.ARMHill.ExitRisk,
                InvestmentRisk = armhill.Strategy.ARMHill.InvestmentRisk,
                LiquidityPressures = armhill.Strategy.ARMHill.LiquidityPressures,
                MyLegacyIssuesProperty = armhill.Strategy.ARMHill.MyLegacyIssuesProperty,
                PoliticalRisk = armhill.Strategy.ARMHill.PoliticalRisk,
                PeopleRetentionRisk = armhill.Strategy.ARMHill.PeopleRetentionRisk,
                ProductivityRisk = armhill.Strategy.ARMHill.ProductivityRisk,
                ProjectManagementRisk = armhill.Strategy.ARMHill.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armhill.Strategy.ARMHill.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armhill.Strategy.ARMHill.TechnologicalRisk,
                Total = armhill.Strategy.ARMHill.Total
            };
        }

    }

    public class OperationBusinessRatingHill : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHillRating))]
        public Guid ARMHillRatingId { get; set; }
        [ForeignKey(nameof(ARMHillRatingId))]
        public ARMHillRating ARMHillRating { get; set; }
        public OperationHillRating ARMHill { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationBusinessRatingHill Create(Guid armHillRatingId, string comment)
        {
            return new OperationBusinessRatingHill
            {
                ARMHillRatingId = armHillRatingId,
                Comment = comment
            };
        }
    }
    public class OperationHillRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationBusinessRatingHill))]
        public Guid OperationBusinessRatingHillId { get; set; }
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
        public static OperationHillRating Create(Guid operationTrusteeId, ARMHillRatingReq armhill)
        {
            return new OperationHillRating
            {
                OperationBusinessRatingHillId = operationTrusteeId,
                AdoptionandImplementationofPolicies = armhill.Operations.ARMHill.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armhill.Operations.ARMHill.StrategyMonitoringRisk,
                BudgetOverruns = armhill.Operations.ARMHill.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armhill.Operations.ARMHill.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armhill.Operations.ARMHill.OverorUnderpaymentofClient,
                TheftorFraudRisk = armhill.Operations.ARMHill.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armhill.Operations.ARMHill.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armhill.Operations.ARMHill.TAT,
                ThirdpartyRisk = armhill.Operations.ARMHill.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armhill.Operations.ARMHill.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armhill.Operations.ARMHill.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armhill.Operations.ARMHill.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armhill.Operations.ARMHill.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armhill.Operations.ARMHill.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armhill.Operations.ARMHill.ProductivityRisk,
                RecruitmentRisk = armhill.Operations.ARMHill.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armhill.Operations.ARMHill.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armhill.Operations.ARMHill.ErrorDetectionRisk,
                PoorCustomerService = armhill.Operations.ARMHill.PoorCustomerService,
                UnauthorizedAccess = armhill.Operations.ARMHill.UnauthorizedAccess,
                Total = armhill.Operations.ARMHill.Total

            };
        }

    }

    public class FinancialHillReporting : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHillRating))]
        public Guid ARMHillRatingId { get; set; }
        [ForeignKey(nameof(ARMHillRatingId))]
        public ARMHillRating ARMHillRating { get; set; }
        public FinacialHillRating ARMHill { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialHillReporting Create(Guid armHillRatingId, string comment)
        {
            return new FinancialHillReporting
            {
                ARMHillRatingId = armHillRatingId,
                Comment = comment
            };
        }
    }
    public class FinacialHillRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialHillReporting))]
        public Guid FinancialHillReportingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialHillRating Create(Guid financialHillReportingId, ARMHillRatingReq armhill)
        {
            return new FinacialHillRating
            {
                FinancialHillReportingId = financialHillReportingId,
                AdherencetoFinancialStandards = armhill.FinancialReporting.ARMHill.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armhill.FinancialReporting.ARMHill.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armhill.FinancialReporting.ARMHill.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armhill.FinancialReporting.ARMHill.ErrororControlRisk,
                IncomeAssuranceRisk = armhill.FinancialReporting.ARMHill.IncomeAssuranceRisk,
                TAT = armhill.FinancialReporting.ARMHill.TAT,
                TheftorFraudRisk = armhill.FinancialReporting.ARMHill.TheftorFraudRisk,
                Total = armhill.FinancialReporting.ARMHill.Total
            };
        }

    }

    public class ComplianceBusinessRatingHill : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHillRating))]
        public Guid ARMHillRatingId { get; set; }
        public ARMHillRating ARMHillRating { get; set; }
        public ComplianceHillRating ARMHill { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceBusinessRatingHill Create(Guid armHillRatingId, string comment)
        {
            return new ComplianceBusinessRatingHill
            {
                ARMHillRatingId = armHillRatingId,
                Comment = comment
            };
        }

    }

    public class ComplianceHillRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceBusinessRatingHill))]
        public Guid ComplianceBusinessRatingHillId { get; set; }
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
        public static ComplianceHillRating Create(Guid complianceHillId, ARMHillRatingReq armhill)
        {
            return new ComplianceHillRating
            {
                ComplianceBusinessRatingHillId = complianceHillId,
                DisclosureRisk = armhill.Compliance.ARMHill.DisclosureRisk,
                CorporateGovernance = armhill.Compliance.ARMHill.CorporateGovernance,
                GDPROrNDPR = armhill.Compliance.ARMHill.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armhill.Compliance.ARMHill.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armhill.Compliance.ARMHill.AMLCFT,
                TAT = armhill.Compliance.ARMHill.TAT,
                ChangingRegulations = armhill.Compliance.ARMHill.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armhill.Compliance.ARMHill.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armhill.Compliance.ARMHill.KYCChecks,
                NonComplianceWithContracts = armhill.Compliance.ARMHill.NonComplianceWithContracts,
                LitigationRisk = armhill.Compliance.ARMHill.LitigationRisk,
                Total = armhill.Compliance.ARMHill.Total
            };
        }
    }

    public class TimeSinceLastHillAudit : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHillRating))]
        public Guid ARMHillRatingId { get; set; }
        public int ARMHill { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static TimeSinceLastHillAudit Create(Guid armHillRatingId, ARMHillRatingReq armhill)
        {
            return new TimeSinceLastHillAudit
            {
                ARMHillRatingId = armHillRatingId,
                ARMHill = armhill.LastReportOverallRating.ARMHill,

                Comment = armhill.LastReportOverallRating.Comment

            };
        }
    }

    #endregion

    #region ARM Agribusiness
    public class ARMAgribusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategyAgribusiness Strategy { get; set; }
        public OperationAgribusiness Operations { get; set; }
        public FinancialAgribusinessReporting FinancialReporting { get; set; }
        public ComplianceAgribusiness Compliance { get; set; }
        public TimeSinceLastAgribusinessAudit TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterEmail { get; set; }
        public static ARMAgribusinessRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string email)
        {
            return new ARMAgribusinessRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterEmail = email
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategyAgribusiness : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMAgribusinessRating))]
        public Guid ARMAgribusinessRatingId { get; set; }
        [ForeignKey(nameof(ARMAgribusinessRatingId))]
        public ARMAgribusinessRating ARMAgribusinessRating { get; set; }
        public StrategyAgribusinessRatingRFl RFl { get; set; }
        public StrategyAgribusinessRatingAAFML AAFML { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategyAgribusiness Create(Guid armAgribusinessRatingId, string comment)
        {
            return new StrategyAgribusiness
            {
                ARMAgribusinessRatingId = armAgribusinessRatingId,
                Comment = comment
            };
        }
    }
    public class StrategyAgribusinessRatingAAFML : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyAgribusiness))]
        public Guid StrategyAgribusinessId { get; set; }
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
        public static StrategyAgribusinessRatingAAFML Create(Guid strategyAgribusinessId, ARMAgribusinessRatingReq armAgribus)
        {
            return new StrategyAgribusinessRatingAAFML
            {
                StrategyAgribusinessId = strategyAgribusinessId,
                FluidityofTechnologicalSolutions = armAgribus.Strategy.AAFML.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armAgribus.Strategy.AAFML.CurrencyDevaluation,
                Increasedleverage = armAgribus.Strategy.AAFML.Increasedleverage,
                SocialRisk = armAgribus.Strategy.AAFML.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armAgribus.Strategy.AAFML.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armAgribus.Strategy.AAFML.DropinFundandFundManagerRatings,
                BCPandDRP = armAgribus.Strategy.AAFML.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armAgribus.Strategy.AAFML.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armAgribus.Strategy.AAFML.AllianceandPartnershipRisks,
                EmergingRisks = armAgribus.Strategy.AAFML.EmergingRisks,
                EnvironmentalRisk = armAgribus.Strategy.AAFML.EnvironmentalRisk,
                ErosionofStatutoryCapital = armAgribus.Strategy.AAFML.ErosionofStatutoryCapital,
                ReputationalRisk = armAgribus.Strategy.AAFML.ReputationalRisk,
                RisktoProfitabilityorPerformance = armAgribus.Strategy.AAFML.RisktoProfitabilityorPerformance,
                CreditRisk = armAgribus.Strategy.AAFML.CreditRisk,
                SustainabilityRisk = armAgribus.Strategy.AAFML.SustainabilityRisk,
                HealthandSafetyRisks = armAgribus.Strategy.AAFML.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armAgribus.Strategy.AAFML.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armAgribus.Strategy.AAFML.FailureofInvestor,
                FlunCTOatingInterestRates = armAgribus.Strategy.AAFML.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armAgribus.Strategy.AAFML.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armAgribus.Strategy.AAFML.InformationSecurityRisk,
                ExitRisk = armAgribus.Strategy.AAFML.ExitRisk,
                InvestmentRisk = armAgribus.Strategy.AAFML.InvestmentRisk,
                LiquidityPressures = armAgribus.Strategy.AAFML.LiquidityPressures,
                MyLegacyIssuesProperty = armAgribus.Strategy.AAFML.MyLegacyIssuesProperty,
                PoliticalRisk = armAgribus.Strategy.AAFML.PoliticalRisk,
                PeopleRetentionRisk = armAgribus.Strategy.AAFML.PeopleRetentionRisk,
                ProductivityRisk = armAgribus.Strategy.AAFML.ProductivityRisk,
                ProjectManagementRisk = armAgribus.Strategy.AAFML.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armAgribus.Strategy.AAFML.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armAgribus.Strategy.AAFML.TechnologicalRisk,
                Total = armAgribus.Strategy.AAFML.Total
            };
        }

    }
    public class StrategyAgribusinessRatingRFl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyAgribusiness))]
        public Guid StrategyAgribusinessId { get; set; }
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
        public static StrategyAgribusinessRatingRFl Create(Guid strategyAgribusinessId, ARMAgribusinessRatingReq armAgribus)
        {
            return new StrategyAgribusinessRatingRFl
            {
                StrategyAgribusinessId = strategyAgribusinessId,
                FluidityofTechnologicalSolutions = armAgribus.Strategy.RFl.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armAgribus.Strategy.RFl.CurrencyDevaluation,
                Increasedleverage = armAgribus.Strategy.RFl.Increasedleverage,
                SocialRisk = armAgribus.Strategy.RFl.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armAgribus.Strategy.RFl.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armAgribus.Strategy.RFl.DropinFundandFundManagerRatings,
                BCPandDRP = armAgribus.Strategy.RFl.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armAgribus.Strategy.RFl.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armAgribus.Strategy.RFl.AllianceandPartnershipRisks,
                EmergingRisks = armAgribus.Strategy.RFl.EmergingRisks,
                EnvironmentalRisk = armAgribus.Strategy.RFl.EnvironmentalRisk,
                ErosionofStatutoryCapital = armAgribus.Strategy.RFl.ErosionofStatutoryCapital,
                ReputationalRisk = armAgribus.Strategy.RFl.ReputationalRisk,
                RisktoProfitabilityorPerformance = armAgribus.Strategy.RFl.RisktoProfitabilityorPerformance,
                CreditRisk = armAgribus.Strategy.RFl.CreditRisk,
                SustainabilityRisk = armAgribus.Strategy.RFl.SustainabilityRisk,
                HealthandSafetyRisks = armAgribus.Strategy.RFl.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armAgribus.Strategy.RFl.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armAgribus.Strategy.RFl.FailureofInvestor,
                FlunCTOatingInterestRates = armAgribus.Strategy.RFl.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armAgribus.Strategy.RFl.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armAgribus.Strategy.RFl.InformationSecurityRisk,
                ExitRisk = armAgribus.Strategy.RFl.ExitRisk,
                InvestmentRisk = armAgribus.Strategy.RFl.InvestmentRisk,
                LiquidityPressures = armAgribus.Strategy.RFl.LiquidityPressures,
                MyLegacyIssuesProperty = armAgribus.Strategy.RFl.MyLegacyIssuesProperty,
                PoliticalRisk = armAgribus.Strategy.RFl.PoliticalRisk,
                PeopleRetentionRisk = armAgribus.Strategy.RFl.PeopleRetentionRisk,
                ProductivityRisk = armAgribus.Strategy.RFl.ProductivityRisk,
                ProjectManagementRisk = armAgribus.Strategy.RFl.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armAgribus.Strategy.RFl.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armAgribus.Strategy.RFl.TechnologicalRisk,
                Total = armAgribus.Strategy.RFl.Total
            };
        }

    }

    public class OperationAgribusiness : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMAgribusinessRating))]
        public Guid ARMAgribusinessRatingId { get; set; }
        [ForeignKey(nameof(ARMAgribusinessRatingId))]
        public ARMAgribusinessRating ARMAgribusinessRating { get; set; }
        public OperationAgribusinessRatingRFl RFl { get; set; }
        public OperationAgribusinessRatingAAFML AAFML { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationAgribusiness Create(Guid armAgribusinessRatingId, string comment)
        {
            return new OperationAgribusiness
            {
                ARMAgribusinessRatingId = armAgribusinessRatingId,
                Comment = comment
            };
        }
    }
    public class OperationAgribusinessRatingAAFML : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationAgribusiness))]
        public Guid OperationAgribusinessId { get; set; }
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
        public static OperationAgribusinessRatingAAFML Create(Guid operationAgribusinessId, ARMAgribusinessRatingReq armagri)
        {
            return new OperationAgribusinessRatingAAFML
            {
                OperationAgribusinessId = operationAgribusinessId,
                AdoptionandImplementationofPolicies = armagri.Operations.AAFML.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armagri.Operations.AAFML.StrategyMonitoringRisk,
                BudgetOverruns = armagri.Operations.AAFML.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armagri.Operations.AAFML.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armagri.Operations.AAFML.OverorUnderpaymentofClient,
                TheftorFraudRisk = armagri.Operations.AAFML.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armagri.Operations.AAFML.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armagri.Operations.AAFML.TAT,
                ThirdpartyRisk = armagri.Operations.AAFML.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armagri.Operations.AAFML.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armagri.Operations.AAFML.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armagri.Operations.AAFML.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armagri.Operations.AAFML.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armagri.Operations.AAFML.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armagri.Operations.AAFML.ProductivityRisk,
                RecruitmentRisk = armagri.Operations.AAFML.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armagri.Operations.AAFML.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armagri.Operations.AAFML.ErrorDetectionRisk,
                PoorCustomerService = armagri.Operations.AAFML.PoorCustomerService,
                UnauthorizedAccess = armagri.Operations.AAFML.UnauthorizedAccess,
                Total = armagri.Operations.AAFML.Total

            };
        }


    }
    public class OperationAgribusinessRatingRFl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationAgribusiness))]
        public Guid OperationAgribusinessId { get; set; }
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
        public static OperationAgribusinessRatingRFl Create(Guid operationAgribusinessId, ARMAgribusinessRatingReq armagri)
        {
            return new OperationAgribusinessRatingRFl
            {
                OperationAgribusinessId = operationAgribusinessId,
                AdoptionandImplementationofPolicies = armagri.Operations.RFl.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armagri.Operations.RFl.StrategyMonitoringRisk,
                BudgetOverruns = armagri.Operations.RFl.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armagri.Operations.RFl.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armagri.Operations.RFl.OverorUnderpaymentofClient,
                TheftorFraudRisk = armagri.Operations.RFl.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armagri.Operations.RFl.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armagri.Operations.RFl.TAT,
                ThirdpartyRisk = armagri.Operations.RFl.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armagri.Operations.RFl.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armagri.Operations.RFl.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armagri.Operations.RFl.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armagri.Operations.RFl.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armagri.Operations.RFl.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armagri.Operations.RFl.ProductivityRisk,
                RecruitmentRisk = armagri.Operations.RFl.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armagri.Operations.RFl.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armagri.Operations.RFl.ErrorDetectionRisk,
                PoorCustomerService = armagri.Operations.RFl.PoorCustomerService,
                UnauthorizedAccess = armagri.Operations.RFl.UnauthorizedAccess,
                Total = armagri.Operations.RFl.Total

            };
        }


    }
    public class FinancialAgribusinessReporting : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMAgribusinessRating))]
        public Guid ARMAgribusinessRatingId { get; set; }
        [ForeignKey(nameof(ARMAgribusinessRatingId))]
        public ARMAgribusinessRating ARMAgribusinessRating { get; set; }
        public FinacialAgribusinessRatingRFl RFl { get; set; }
        public FinacialAgribusinessRatingAAFML AAFML { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialAgribusinessReporting Create(Guid armAgribusinessRatingId, string comment)
        {
            return new FinancialAgribusinessReporting
            {
                ARMAgribusinessRatingId = armAgribusinessRatingId,
                Comment = comment
            };
        }
    }

    public class FinacialAgribusinessRatingAAFML : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialAgribusinessReporting))]
        public Guid FinancialAgribusinessReportingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialAgribusinessRatingAAFML Create(Guid financialAgribusinessReportingId, ARMAgribusinessRatingReq armagri)
        {
            return new FinacialAgribusinessRatingAAFML
            {
                FinancialAgribusinessReportingId = financialAgribusinessReportingId,
                AdherencetoFinancialStandards = armagri.FinancialReporting.AAFML.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armagri.FinancialReporting.AAFML.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armagri.FinancialReporting.AAFML.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armagri.FinancialReporting.AAFML.ErrororControlRisk,
                IncomeAssuranceRisk = armagri.FinancialReporting.AAFML.IncomeAssuranceRisk,
                TAT = armagri.FinancialReporting.AAFML.TAT,
                TheftorFraudRisk = armagri.FinancialReporting.AAFML.TheftorFraudRisk,
                Total = armagri.FinancialReporting.AAFML.Total
            };
        }


    }

    public class FinacialAgribusinessRatingRFl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialAgribusinessReporting))]
        public Guid FinancialAgribusinessReportingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialAgribusinessRatingRFl Create(Guid financialAgribusinessReportingId, ARMAgribusinessRatingReq armagri)
        {
            return new FinacialAgribusinessRatingRFl
            {
                FinancialAgribusinessReportingId = financialAgribusinessReportingId,
                AdherencetoFinancialStandards = armagri.FinancialReporting.RFl.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armagri.FinancialReporting.RFl.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armagri.FinancialReporting.RFl.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armagri.FinancialReporting.RFl.ErrororControlRisk,
                IncomeAssuranceRisk = armagri.FinancialReporting.RFl.IncomeAssuranceRisk,
                TAT = armagri.FinancialReporting.RFl.TAT,
                TheftorFraudRisk = armagri.FinancialReporting.RFl.TheftorFraudRisk,
                Total = armagri.FinancialReporting.RFl.Total
            };
        }


    }

    public class ComplianceAgribusiness : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMAgribusinessRating))]
        public Guid ARMAgribusinessRatingId { get; set; }
        [ForeignKey(nameof(ARMAgribusinessRatingId))]
        public ARMAgribusinessRating ARMAgribusinessRating { get; set; }
        public ComplianceAgribusinessRatingRFl RFl { get; set; }
        public ComplianceAgribusinessRatingAAFML AAFML { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceAgribusiness Create(Guid armAgribusinessRatingId, string comment)
        {
            return new ComplianceAgribusiness
            {
                ARMAgribusinessRatingId = armAgribusinessRatingId,
                Comment = comment
            };
        }

    }
    public class ComplianceAgribusinessRatingAAFML : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceAgribusiness))]
        public Guid ComplianceAgribusinessId { get; set; }
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
        public static ComplianceAgribusinessRatingAAFML Create(Guid complianceAgribusinessId, ARMAgribusinessRatingReq armagri)
        {
            return new ComplianceAgribusinessRatingAAFML
            {
                ComplianceAgribusinessId = complianceAgribusinessId,
                DisclosureRisk = armagri.Compliance.AAFML.DisclosureRisk,
                CorporateGovernance = armagri.Compliance.AAFML.CorporateGovernance,
                GDPROrNDPR = armagri.Compliance.AAFML.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armagri.Compliance.AAFML.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armagri.Compliance.AAFML.AMLCFT,
                TAT = armagri.Compliance.AAFML.TAT,
                ChangingRegulations = armagri.Compliance.AAFML.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armagri.Compliance.AAFML.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armagri.Compliance.AAFML.KYCChecks,
                NonComplianceWithContracts = armagri.Compliance.AAFML.NonComplianceWithContracts,
                LitigationRisk = armagri.Compliance.AAFML.LitigationRisk,
                Total = armagri.Compliance.AAFML.Total
            };
        }
    }

    public class ComplianceAgribusinessRatingRFl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceAgribusiness))]
        public Guid ComplianceAgribusinessId { get; set; }
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
        public static ComplianceAgribusinessRatingRFl Create(Guid complianceAgribusinessId, ARMAgribusinessRatingReq armagri)
        {
            return new ComplianceAgribusinessRatingRFl
            {
                ComplianceAgribusinessId = complianceAgribusinessId,
                DisclosureRisk = armagri.Compliance.RFl.DisclosureRisk,
                CorporateGovernance = armagri.Compliance.RFl.CorporateGovernance,
                GDPROrNDPR = armagri.Compliance.RFl.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armagri.Compliance.RFl.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armagri.Compliance.RFl.AMLCFT,
                TAT = armagri.Compliance.RFl.TAT,
                ChangingRegulations = armagri.Compliance.RFl.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armagri.Compliance.RFl.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armagri.Compliance.RFl.KYCChecks,
                NonComplianceWithContracts = armagri.Compliance.RFl.NonComplianceWithContracts,
                LitigationRisk = armagri.Compliance.RFl.LitigationRisk,
                Total = armagri.Compliance.RFl.Total
            };
        }
    }

    public class TimeSinceLastAgribusinessAudit : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMAgribusinessRating))]
        public Guid ARMAgribusinessRatingId { get; set; }
        public int RFl { get; set; }
        public int AAFML { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static TimeSinceLastAgribusinessAudit Create(Guid armAgribusinessRatingId, ARMAgribusinessRatingReq armagri)
        {
            return new TimeSinceLastAgribusinessAudit
            {
                ARMAgribusinessRatingId = armAgribusinessRatingId,
                RFl = armagri.LastReportOverallRating.RFl,
                AAFML = armagri.LastReportOverallRating.AAFML,
                Comment = armagri.LastReportOverallRating.Comment

            };
        }
    }

    #endregion

    #region ARM IM 
    public class ARMIMBusinessRiskRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategyImBusinessRating Strategy { get; set; }
        public OperationIMBusinessRating Operations { get; set; }
        public FinancialIMBusinessRating FinancialReporting { get; set; }
        public ComplianceIMBusinessRating Compliance { get; set; }
        public TimeSinceLastAuditIMBusinessRating TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterName { get; set; }
        public static ARMIMBusinessRiskRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string name)
        {
            return new ARMIMBusinessRiskRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterName = name
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }

    public class StrategyImBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMBusinessRiskRating))]
        public Guid ARMIMBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMIMBusinessRiskRatingId))]
        public ARMIMBusinessRiskRating ARMIMBusinessRiskRating { get; set; }
        public StrategyIMRatingARMIM ARMIM { get; set; }
        public StrategyIMRating IMUnit { get; set; }
        public StrategyIMRatingBDPWMIAMIMRetail BDPWMIAMIMRetail { get; set; }
        public StrategyIMRatingFundAccount FundAccount { get; set; }
        public StrategyIMRatingFundAdmin FundAdmin { get; set; }
        public StrategyIMRatingRetailOperation RetailOperation { get; set; }
        public StrategyIMRatingARMRegistrar ARMRegistrar { get; set; }
        public StrategyIMRatingOperationSettlement OperationSettlement { get; set; }
        public StrategyIMRatingOperationControl OperationControl { get; set; }
        public StrategyIMRatingResearch Research { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategyImBusinessRating Create(Guid armIMBusinessRiskRatingId, string comment)
        {
            return new StrategyImBusinessRating
            {
                ARMIMBusinessRiskRatingId = armIMBusinessRiskRatingId,
                Comment = comment
            };
        }

    }
    public class StrategyIMRatingResearch : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRatingResearch Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingResearch
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.Research.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.Research.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.Research.Increasedleverage,
                SocialRisk = armIM.Strategy.Research.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.Research.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.Research.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.Research.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.Research.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.Research.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.Research.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.Research.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.Research.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.Research.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.Research.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.Research.CreditRisk,
                SustainabilityRisk = armIM.Strategy.Research.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.Research.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.Research.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.Research.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.Research.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.Research.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.Research.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.Research.ExitRisk,
                InvestmentRisk = armIM.Strategy.Research.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.Research.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.Research.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.Research.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.Research.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.Research.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.Research.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.Research.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.Research.TechnologicalRisk,
                Total = armIM.Strategy.Research.Total
            };
        }

    }

    public class StrategyIMRatingARMIM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRatingARMIM Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingARMIM
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.ARMIM.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.ARMIM.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.ARMIM.Increasedleverage,
                SocialRisk = armIM.Strategy.ARMIM.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.ARMIM.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.ARMIM.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.ARMIM.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.ARMIM.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.ARMIM.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.ARMIM.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.ARMIM.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.ARMIM.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.ARMIM.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.ARMIM.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.ARMIM.CreditRisk,
                SustainabilityRisk = armIM.Strategy.ARMIM.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.ARMIM.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.ARMIM.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.ARMIM.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.ARMIM.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.ARMIM.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.ARMIM.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.ARMIM.ExitRisk,
                InvestmentRisk = armIM.Strategy.ARMIM.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.ARMIM.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.ARMIM.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.ARMIM.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.ARMIM.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.ARMIM.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.ARMIM.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.ARMIM.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.ARMIM.TechnologicalRisk,
                Total = armIM.Strategy.ARMIM.Total
            };
        }

    }

    public class StrategyIMRatingOperationControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
        //public StrategyImBusinessRating StrategyImBusinessRating { get; set; }
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

        public static StrategyIMRatingOperationControl Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingOperationControl
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.OperationControl.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.OperationControl.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.OperationControl.Increasedleverage,
                SocialRisk = armIM.Strategy.OperationControl.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.OperationControl.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.OperationControl.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.OperationControl.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.OperationControl.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.OperationControl.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.OperationControl.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.OperationControl.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.OperationControl.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.OperationControl.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.OperationControl.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.OperationControl.CreditRisk,
                SustainabilityRisk = armIM.Strategy.OperationControl.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.OperationControl.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.OperationControl.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.OperationControl.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.OperationControl.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.OperationControl.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.OperationControl.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.OperationControl.ExitRisk,
                InvestmentRisk = armIM.Strategy.OperationControl.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.OperationControl.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.OperationControl.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.OperationControl.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.OperationControl.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.OperationControl.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.OperationControl.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.OperationControl.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.OperationControl.TechnologicalRisk,
                Total = armIM.Strategy.OperationControl.Total
            };
        }

    }
    public class StrategyIMRatingOperationSettlement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRatingOperationSettlement Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingOperationSettlement
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.OperationSettlement.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.OperationSettlement.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.OperationSettlement.Increasedleverage,
                SocialRisk = armIM.Strategy.OperationSettlement.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.OperationSettlement.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.OperationSettlement.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.OperationSettlement.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.OperationSettlement.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.OperationSettlement.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.OperationSettlement.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.OperationSettlement.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.OperationSettlement.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.OperationSettlement.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.OperationControl.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.OperationSettlement.CreditRisk,
                SustainabilityRisk = armIM.Strategy.OperationSettlement.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.OperationSettlement.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.OperationSettlement.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.OperationSettlement.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.OperationSettlement.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.OperationSettlement.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.OperationSettlement.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.OperationSettlement.ExitRisk,
                InvestmentRisk = armIM.Strategy.OperationSettlement.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.OperationSettlement.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.OperationSettlement.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.OperationSettlement.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.OperationSettlement.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.OperationSettlement.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.OperationSettlement.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.OperationSettlement.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.OperationSettlement.TechnologicalRisk,
                Total = armIM.Strategy.OperationSettlement.Total
            };
        }

    }
    public class StrategyIMRatingARMRegistrar : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRatingARMRegistrar Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingARMRegistrar
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.ARMRegistrar.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.ARMRegistrar.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.ARMRegistrar.Increasedleverage,
                SocialRisk = armIM.Strategy.ARMRegistrar.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.ARMRegistrar.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.ARMRegistrar.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.ARMRegistrar.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.ARMRegistrar.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.ARMRegistrar.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.ARMRegistrar.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.ARMRegistrar.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.ARMRegistrar.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.ARMRegistrar.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.ARMRegistrar.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.ARMRegistrar.CreditRisk,
                SustainabilityRisk = armIM.Strategy.ARMRegistrar.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.ARMRegistrar.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.ARMRegistrar.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.ARMRegistrar.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.ARMRegistrar.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.ARMRegistrar.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.ARMRegistrar.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.ARMRegistrar.ExitRisk,
                InvestmentRisk = armIM.Strategy.ARMRegistrar.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.ARMRegistrar.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.ARMRegistrar.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.ARMRegistrar.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.ARMRegistrar.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.ARMRegistrar.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.ARMRegistrar.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.ARMRegistrar.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.ARMRegistrar.TechnologicalRisk,
                Total = armIM.Strategy.ARMRegistrar.Total
            };
        }

    }
    public class StrategyIMRatingRetailOperation : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRatingRetailOperation Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingRetailOperation
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.RetailOperation.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.RetailOperation.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.RetailOperation.Increasedleverage,
                SocialRisk = armIM.Strategy.RetailOperation.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.RetailOperation.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.RetailOperation.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.RetailOperation.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.RetailOperation.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.RetailOperation.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.RetailOperation.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.RetailOperation.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.RetailOperation.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.RetailOperation.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.RetailOperation.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.RetailOperation.CreditRisk,
                SustainabilityRisk = armIM.Strategy.RetailOperation.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.RetailOperation.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.RetailOperation.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.RetailOperation.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.RetailOperation.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.RetailOperation.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.RetailOperation.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.RetailOperation.ExitRisk,
                InvestmentRisk = armIM.Strategy.RetailOperation.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.RetailOperation.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.RetailOperation.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.RetailOperation.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.RetailOperation.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.RetailOperation.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.RetailOperation.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.RetailOperation.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.RetailOperation.TechnologicalRisk,
                Total = armIM.Strategy.RetailOperation.Total
            };
        }

    }
    public class StrategyIMRatingFundAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRatingFundAdmin Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingFundAdmin
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.FundAdmin.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.FundAdmin.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.FundAdmin.Increasedleverage,
                SocialRisk = armIM.Strategy.FundAdmin.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.FundAdmin.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.FundAdmin.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.FundAdmin.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.FundAdmin.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.FundAdmin.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.FundAdmin.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.FundAdmin.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.FundAdmin.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.FundAdmin.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.FundAdmin.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.FundAdmin.CreditRisk,
                SustainabilityRisk = armIM.Strategy.FundAdmin.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.FundAdmin.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.FundAdmin.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.FundAdmin.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.FundAdmin.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.FundAdmin.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.FundAdmin.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.FundAdmin.ExitRisk,
                InvestmentRisk = armIM.Strategy.FundAdmin.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.FundAdmin.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.FundAdmin.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.FundAdmin.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.FundAdmin.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.FundAdmin.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.FundAdmin.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.FundAdmin.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.FundAdmin.TechnologicalRisk,
                Total = armIM.Strategy.FundAdmin.Total
            };
        }

    }
    public class StrategyIMRatingFundAccount : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRatingFundAccount Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingFundAccount
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.FundAccount.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.FundAccount.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.FundAccount.Increasedleverage,
                SocialRisk = armIM.Strategy.FundAccount.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.FundAccount.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.FundAccount.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.FundAccount.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.FundAccount.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.FundAccount.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.FundAccount.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.FundAccount.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.FundAccount.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.FundAccount.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.FundAccount.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.FundAccount.CreditRisk,
                SustainabilityRisk = armIM.Strategy.FundAccount.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.FundAccount.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.FundAccount.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.FundAccount.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.FundAccount.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.FundAccount.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.FundAccount.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.FundAccount.ExitRisk,
                InvestmentRisk = armIM.Strategy.FundAccount.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.FundAccount.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.FundAccount.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.FundAccount.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.FundAccount.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.FundAccount.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.FundAccount.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.FundAccount.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.FundAccount.TechnologicalRisk,
                Total = armIM.Strategy.FundAccount.Total
            };
        }

    }
    public class StrategyIMRatingBDPWMIAMIMRetail : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRatingBDPWMIAMIMRetail Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRatingBDPWMIAMIMRetail
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.BDPWMIAMIMRetail.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.BDPWMIAMIMRetail.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.BDPWMIAMIMRetail.Increasedleverage,
                SocialRisk = armIM.Strategy.BDPWMIAMIMRetail.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.BDPWMIAMIMRetail.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.BDPWMIAMIMRetail.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.BDPWMIAMIMRetail.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.BDPWMIAMIMRetail.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.BDPWMIAMIMRetail.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.BDPWMIAMIMRetail.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.BDPWMIAMIMRetail.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.BDPWMIAMIMRetail.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.BDPWMIAMIMRetail.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.BDPWMIAMIMRetail.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.BDPWMIAMIMRetail.CreditRisk,
                SustainabilityRisk = armIM.Strategy.BDPWMIAMIMRetail.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.BDPWMIAMIMRetail.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.BDPWMIAMIMRetail.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.BDPWMIAMIMRetail.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.BDPWMIAMIMRetail.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.BDPWMIAMIMRetail.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.BDPWMIAMIMRetail.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.BDPWMIAMIMRetail.ExitRisk,
                InvestmentRisk = armIM.Strategy.BDPWMIAMIMRetail.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.BDPWMIAMIMRetail.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.BDPWMIAMIMRetail.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.BDPWMIAMIMRetail.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.BDPWMIAMIMRetail.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.BDPWMIAMIMRetail.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.BDPWMIAMIMRetail.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.BDPWMIAMIMRetail.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.BDPWMIAMIMRetail.TechnologicalRisk,
                Total = armIM.Strategy.BDPWMIAMIMRetail.Total
            };
        }

    }
    public class StrategyIMRating : AuditEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyImBusinessRating))]
        public Guid StrategyImBusinessRatingId { get; set; }
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
        public static StrategyIMRating Create(Guid strategyImBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new StrategyIMRating
            {
                StrategyImBusinessRatingId = strategyImBusinessRatingId,
                FluidityofTechnologicalSolutions = armIM.Strategy.IMUnit.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = armIM.Strategy.IMUnit.CurrencyDevaluation,
                Increasedleverage = armIM.Strategy.IMUnit.Increasedleverage,
                SocialRisk = armIM.Strategy.IMUnit.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = armIM.Strategy.IMUnit.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = armIM.Strategy.IMUnit.DropinFundandFundManagerRatings,
                BCPandDRP = armIM.Strategy.IMUnit.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = armIM.Strategy.IMUnit.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = armIM.Strategy.IMUnit.AllianceandPartnershipRisks,
                EmergingRisks = armIM.Strategy.IMUnit.EmergingRisks,
                EnvironmentalRisk = armIM.Strategy.IMUnit.EnvironmentalRisk,
                ErosionofStatutoryCapital = armIM.Strategy.IMUnit.ErosionofStatutoryCapital,
                ReputationalRisk = armIM.Strategy.IMUnit.ReputationalRisk,
                RisktoProfitabilityorPerformance = armIM.Strategy.IMUnit.RisktoProfitabilityorPerformance,
                CreditRisk = armIM.Strategy.IMUnit.CreditRisk,
                SustainabilityRisk = armIM.Strategy.IMUnit.SustainabilityRisk,
                HealthandSafetyRisks = armIM.Strategy.IMUnit.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = armIM.Strategy.IMUnit.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = armIM.Strategy.IMUnit.FailureofInvestor,
                FlunCTOatingInterestRates = armIM.Strategy.IMUnit.flunctuatingInterestRates,
                PortfolioProductandFundPerformanceRisk = armIM.Strategy.IMUnit.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = armIM.Strategy.IMUnit.InformationSecurityRisk,
                ExitRisk = armIM.Strategy.IMUnit.ExitRisk,
                InvestmentRisk = armIM.Strategy.IMUnit.InvestmentRisk,
                LiquidityPressures = armIM.Strategy.IMUnit.LiquidityPressures,
                MyLegacyIssuesProperty = armIM.Strategy.IMUnit.MyLegacyIssuesProperty,
                PoliticalRisk = armIM.Strategy.IMUnit.PoliticalRisk,
                PeopleRetentionRisk = armIM.Strategy.IMUnit.PeopleRetentionRisk,
                ProductivityRisk = armIM.Strategy.IMUnit.ProductivityRisk,
                ProjectManagementRisk = armIM.Strategy.IMUnit.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = armIM.Strategy.IMUnit.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = armIM.Strategy.IMUnit.TechnologicalRisk,
                Total = armIM.Strategy.IMUnit.Total
            };
        }

    }
    public class OperationIMBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMBusinessRiskRating))]
        public Guid ARMIMBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMIMBusinessRiskRatingId))]
        public ARMIMBusinessRiskRating ARMIMBusinessRiskRating { get; set; }
        public OperationARMIMRating ARMIM { get; set; }
        public OperationIMUnitRating IMUnit { get; set; }
        public OperationIMRatingBDPWMIAMIMRetail BDPWMIAMIMRetail { get; set; }
        public OperationIMRatingFundAccount FundAccount { get; set; }
        public OperationIMRatingFundAdmin FundAdmin { get; set; }
        public OperationIMRatingRetailOperation RetailOperation { get; set; }
        public OperationIMRatingARMRegistrar ARMRegistrar { get; set; }
        public OperationIMRatingOperationSettlement OperationSettlement { get; set; }
        public OperationIMRatingOperationControl OperationControl { get; set; }
        public OperationIMRatingResearch Research { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationIMBusinessRating Create(Guid armIMBusinessRiskRatingId, string comment)
        {
            return new OperationIMBusinessRating
            {
                ARMIMBusinessRiskRatingId = armIMBusinessRiskRatingId,
                Comment = comment
            };
        }
    }

    public class OperationIMRatingResearch : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMRatingResearch Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMRatingResearch
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.Research.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.Research.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.Research.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.Research.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.Research.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.Research.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.Research.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.Research.TAT,
                ThirdpartyRisk = armIM.Operations.Research.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.Research.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.Research.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.Research.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.Research.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.Research.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.Research.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.Research.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.Research.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.Research.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.Research.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.Research.UnauthorizedAccess,
                Total = armIM.Operations.Research.Total

            };
        }

    }


    public class OperationIMRatingBDPWMIAMIMRetail : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMRatingBDPWMIAMIMRetail Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMRatingBDPWMIAMIMRetail
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.BDPWMIAMIMRetail.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.BDPWMIAMIMRetail.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.BDPWMIAMIMRetail.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.BDPWMIAMIMRetail.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.BDPWMIAMIMRetail.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.BDPWMIAMIMRetail.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.BDPWMIAMIMRetail.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.BDPWMIAMIMRetail.TAT,
                ThirdpartyRisk = armIM.Operations.BDPWMIAMIMRetail.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.BDPWMIAMIMRetail.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.BDPWMIAMIMRetail.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.BDPWMIAMIMRetail.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.BDPWMIAMIMRetail.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.BDPWMIAMIMRetail.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.BDPWMIAMIMRetail.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.BDPWMIAMIMRetail.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.BDPWMIAMIMRetail.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.BDPWMIAMIMRetail.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.BDPWMIAMIMRetail.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.BDPWMIAMIMRetail.UnauthorizedAccess,
                Total = armIM.Operations.BDPWMIAMIMRetail.Total

            };
        }

    }

    public class OperationIMRatingFundAccount : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMRatingFundAccount Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMRatingFundAccount
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.FundAccount.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.FundAccount.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.FundAccount.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.FundAccount.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.FundAccount.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.FundAccount.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.FundAccount.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.FundAccount.TAT,
                ThirdpartyRisk = armIM.Operations.FundAccount.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.FundAccount.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.FundAccount.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.FundAccount.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.FundAccount.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.FundAccount.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.FundAccount.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.FundAccount.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.FundAccount.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.FundAccount.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.FundAccount.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.FundAccount.UnauthorizedAccess,
                Total = armIM.Operations.FundAccount.Total

            };
        }

    }

    public class OperationIMRatingFundAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMRatingFundAdmin Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMRatingFundAdmin
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.FundAdmin.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.FundAdmin.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.FundAdmin.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.FundAdmin.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.FundAdmin.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.FundAdmin.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.FundAdmin.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.FundAdmin.TAT,
                ThirdpartyRisk = armIM.Operations.FundAdmin.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.FundAdmin.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.FundAdmin.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.FundAdmin.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.FundAdmin.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.FundAdmin.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.FundAdmin.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.FundAdmin.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.FundAdmin.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.FundAdmin.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.FundAdmin.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.FundAdmin.UnauthorizedAccess,
                Total = armIM.Operations.FundAdmin.Total

            };
        }

    }
    public class OperationIMRatingRetailOperation : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMRatingRetailOperation Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMRatingRetailOperation
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.RetailOperation.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.RetailOperation.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.RetailOperation.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.RetailOperation.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.RetailOperation.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.RetailOperation.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.RetailOperation.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.RetailOperation.TAT,
                ThirdpartyRisk = armIM.Operations.RetailOperation.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.RetailOperation.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.RetailOperation.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.RetailOperation.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.RetailOperation.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.RetailOperation.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.RetailOperation.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.RetailOperation.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.RetailOperation.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.RetailOperation.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.RetailOperation.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.RetailOperation.UnauthorizedAccess,
                Total = armIM.Operations.RetailOperation.Total

            };
        }


    }
    public class OperationIMRatingARMRegistrar : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMRatingARMRegistrar Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMRatingARMRegistrar
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.ARMRegistrar.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.ARMRegistrar.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.ARMRegistrar.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.ARMRegistrar.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.ARMRegistrar.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.ARMRegistrar.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.ARMRegistrar.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.ARMRegistrar.TAT,
                ThirdpartyRisk = armIM.Operations.ARMRegistrar.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.ARMRegistrar.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.ARMRegistrar.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.ARMRegistrar.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.ARMRegistrar.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.ARMRegistrar.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.ARMRegistrar.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.ARMRegistrar.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.ARMRegistrar.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.ARMRegistrar.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.ARMRegistrar.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.ARMRegistrar.UnauthorizedAccess,
                Total = armIM.Operations.ARMRegistrar.Total

            };
        }


    }
    public class OperationARMIMRating : AuditEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationARMIMRating Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationARMIMRating
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.ARMIM.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.ARMIM.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.ARMIM.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.ARMIM.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.ARMIM.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.ARMIM.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.ARMIM.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.ARMIM.TAT,
                ThirdpartyRisk = armIM.Operations.ARMIM.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.ARMIM.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.ARMIM.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.ARMIM.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.ARMIM.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.ARMIM.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.ARMIM.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.ARMIM.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.ARMIM.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.ARMIM.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.ARMIM.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.ARMIM.UnauthorizedAccess,
                Total = armIM.Operations.ARMIM.Total

            };
        }


    }
    public class OperationIMRatingOperationSettlement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMRatingOperationSettlement Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMRatingOperationSettlement
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.OperationSettlement.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.OperationSettlement.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.OperationSettlement.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.OperationSettlement.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.FundAdmin.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.OperationSettlement.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.OperationSettlement.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.OperationSettlement.TAT,
                ThirdpartyRisk = armIM.Operations.OperationSettlement.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.OperationSettlement.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.OperationSettlement.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.OperationSettlement.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.OperationSettlement.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.OperationSettlement.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.OperationSettlement.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.OperationSettlement.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.OperationSettlement.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.OperationSettlement.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.OperationSettlement.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.OperationSettlement.UnauthorizedAccess,
                Total = armIM.Operations.OperationSettlement.Total

            };
        }


    }
    public class OperationIMRatingOperationControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMRatingOperationControl Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMRatingOperationControl
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.OperationControl.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.OperationControl.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.OperationControl.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.OperationControl.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.OperationControl.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.OperationControl.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.OperationControl.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.OperationControl.TAT,
                ThirdpartyRisk = armIM.Operations.OperationControl.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.OperationControl.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.OperationControl.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.OperationControl.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.OperationControl.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.OperationControl.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.OperationControl.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.OperationControl.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.OperationControl.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.OperationControl.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.OperationControl.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.OperationControl.UnauthorizedAccess,
                Total = armIM.Operations.OperationControl.Total

            };
        }


    }
    public class OperationIMUnitRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationIMBusinessRating))]
        public Guid OperationIMBusinessRatingId { get; set; }
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
        public static OperationIMUnitRating Create(Guid operationIMBusinessRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new OperationIMUnitRating
            {
                OperationIMBusinessRatingId = operationIMBusinessRatingId,
                AdoptionandImplementationofPolicies = armIM.Operations.IMUnit.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armIM.Operations.IMUnit.StrategyMonitoringRisk,
                BudgetOverruns = armIM.Operations.IMUnit.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = armIM.Operations.IMUnit.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = armIM.Operations.IMUnit.OverorUnderpaymentofClient,
                TheftorFraudRisk = armIM.Operations.IMUnit.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armIM.Operations.IMUnit.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armIM.Operations.IMUnit.TAT,
                ThirdpartyRisk = armIM.Operations.IMUnit.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armIM.Operations.IMUnit.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armIM.Operations.IMUnit.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armIM.Operations.IMUnit.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armIM.Operations.IMUnit.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = armIM.Operations.IMUnit.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = armIM.Operations.IMUnit.ProductivityRisk,
                RecruitmentRisk = armIM.Operations.IMUnit.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armIM.Operations.IMUnit.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armIM.Operations.IMUnit.ErrorDetectionRisk,
                PoorCustomerService = armIM.Operations.IMUnit.PoorCustomerService,
                UnauthorizedAccess = armIM.Operations.IMUnit.UnauthorizedAccess,
                Total = armIM.Operations.IMUnit.Total

            };
        }


    }
    public class FinancialIMBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMBusinessRiskRating))]
        public Guid ARMIMBusinessRiskRatingId { get; set; }
        public ARMIMBusinessRiskRating ARMIMBusinessRiskRating { get; set; }
        public FinacialARMIMRating ARMIM { get; set; }
        public FinacialIMBusinessRating IMUnit { get; set; }
        public FinacialIMRatingBDPWMIAMIMRetail BDPWMIAMIMRetail { get; set; }
        public FinacialIMRatingFundAccount FundAccount { get; set; }
        public FinacialIMRatingFundAdmin FundAdmin { get; set; }
        public FinacialIMRatingRetailOperation RetailOperation { get; set; }
        public FinacialIMRatingARMRegistrar ARMRegistrar { get; set; }
        public FinacialIMRatingOperationSettlement OperationSettlement { get; set; }
        public FinacialIMRatingOperationControl OperationControl { get; set; }
        public FinacialIMRatingResearch  Research { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialIMBusinessRating Create(Guid armIMBusinessRiskRatingId, string comment)
        {
            return new FinancialIMBusinessRating
            {
                ARMIMBusinessRiskRatingId = armIMBusinessRiskRatingId,
                Comment = comment
            };
        }
    }

    public class FinacialIMRatingResearch : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }
        public int StatutoryDeductionsandTaxes { get; set; }
        public int AdherencetoFinancialStandards { get; set; }
        public int AdoptionandImplementationofPoliciesAdherence { get; set; }
        public int TAT { get; set; }
        public int ErrororControlRisk { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int Total { get; set; }
        public static FinacialIMRatingResearch Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMRatingResearch
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.Research.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.Research.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.Research.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.Research.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.Research.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.Research.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.Research.TheftorFraudRisk,
                Total = armIM.FinancialReporting.Research.Total
            };
        }

    }

    public class FinacialIMRatingOperationControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialIMRatingOperationControl Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMRatingOperationControl
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.OperationControl.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.OperationControl.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.OperationControl.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.OperationControl.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.OperationControl.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.OperationControl.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.OperationControl.TheftorFraudRisk,
                Total = armIM.FinancialReporting.OperationControl.Total
            };
        }

    }
    public class FinacialIMRatingOperationSettlement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialIMRatingOperationSettlement Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMRatingOperationSettlement
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.OperationSettlement.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.OperationSettlement.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.OperationSettlement.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.OperationSettlement.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.OperationSettlement.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.OperationSettlement.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.OperationSettlement.TheftorFraudRisk,
                Total = armIM.FinancialReporting.OperationSettlement.Total
            };
        }


    }
    public class FinacialARMIMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }
        public int StatutoryDeductionsandTaxes { get; set; }
        public int AdherencetoFinancialStandards { get; set; }
        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialARMIMRating Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialARMIMRating
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.ARMIM.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.ARMIM.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.ARMIM.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.ARMIM.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.ARMIM.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.ARMIM.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.ARMIM.TheftorFraudRisk,
                Total = armIM.FinancialReporting.ARMIM.Total
            };
        }


    }
    public class FinacialIMRatingARMRegistrar : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialIMRatingARMRegistrar Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMRatingARMRegistrar
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.ARMRegistrar.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.ARMRegistrar.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.ARMRegistrar.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.ARMRegistrar.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.ARMRegistrar.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.ARMRegistrar.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.ARMRegistrar.TheftorFraudRisk,
                Total = armIM.FinancialReporting.ARMRegistrar.Total
            };
        }


    }
    public class FinacialIMRatingRetailOperation : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialIMRatingRetailOperation Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMRatingRetailOperation
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.RetailOperation.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.RetailOperation.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.RetailOperation.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.RetailOperation.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.RetailOperation.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.RetailOperation.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.RetailOperation.TheftorFraudRisk,
                Total = armIM.FinancialReporting.RetailOperation.Total
            };
        }


    }
    public class FinacialIMRatingFundAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialIMRatingFundAdmin Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMRatingFundAdmin
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.FundAdmin.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.FundAdmin.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.FundAdmin.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.FundAdmin.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.FundAdmin.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.FundAdmin.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.FundAdmin.TheftorFraudRisk,
                Total = armIM.FinancialReporting.FundAdmin.Total
            };
        }


    }
    public class FinacialIMRatingFundAccount : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialIMRatingFundAccount Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMRatingFundAccount
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.FundAccount.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.FundAccount.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.FundAccount.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.FundAccount.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.FundAccount.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.FundAccount.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.FundAccount.TheftorFraudRisk,
                Total = armIM.FinancialReporting.FundAccount.Total
            };
        }


    }
    public class FinacialIMRatingBDPWMIAMIMRetail : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        // public FinancialIMBusinessRating FinancialIMBusinessRating { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialIMRatingBDPWMIAMIMRetail Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMRatingBDPWMIAMIMRetail
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.BDPWMIAMIMRetail.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.BDPWMIAMIMRetail.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.BDPWMIAMIMRetail.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.BDPWMIAMIMRetail.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.BDPWMIAMIMRetail.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.BDPWMIAMIMRetail.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.BDPWMIAMIMRetail.TheftorFraudRisk,
                Total = armIM.FinancialReporting.BDPWMIAMIMRetail.Total
            };
        }


    }
    public class FinacialIMBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FinancialIMBusinessRating))]
        public Guid FinancialIMBusinessRatingId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialIMBusinessRating Create(Guid financialBusinessARMTAMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new FinacialIMBusinessRating
            {
                FinancialIMBusinessRatingId = financialBusinessARMTAMId,
                AdherencetoFinancialStandards = armIM.FinancialReporting.IMUnit.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = armIM.FinancialReporting.IMUnit.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = armIM.FinancialReporting.IMUnit.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = armIM.FinancialReporting.IMUnit.ErrororControlRisk,
                IncomeAssuranceRisk = armIM.FinancialReporting.IMUnit.IncomeAssuranceRisk,
                TAT = armIM.FinancialReporting.IMUnit.TAT,
                TheftorFraudRisk = armIM.FinancialReporting.IMUnit.TheftorFraudRisk,
                Total = armIM.FinancialReporting.IMUnit.Total
            };
        }

    }
    public class ComplianceIMBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMBusinessRiskRating))]
        public Guid ARMIMBusinessRiskRatingId { get; set; }
        public ARMIMBusinessRiskRating ARMIMBusinessRiskRating { get; set; }
        public ComplianceIMRatingARMIM ARMIM { get; set; }
        public ComplianceIMRating IMUnit { get; set; }
        public ComplianceIMRatingBDPWMIAMIMRetail BDPWMIAMIMRetail { get; set; }
        public ComplianceIMRatingFundAccount FundAccount { get; set; }
        public ComplianceIMRatingFundAdmin FundAdmin { get; set; }
        public ComplianceIMRatingRetailOperation RetailOperation { get; set; }
        public ComplianceIMRatingARMRegistrar ARMRegistrar { get; set; }
        public ComplianceIMRatingOperationSettlement OperationSettlement { get; set; }
        public ComplianceIMRatingOperationControl OperationControl { get; set; }
        public ComplianceIMRatingResearch Research { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceIMBusinessRating Create(Guid armIMBusinessRiskRatingId, string comment)
        {
            return new ComplianceIMBusinessRating
            {
                ARMIMBusinessRiskRatingId = armIMBusinessRiskRatingId,
                Comment = comment
            };
        }

    }
    public class ComplianceIMRatingResearch : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRatingResearch Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingResearch
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.Research.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.Research.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.Research.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.Research.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.Research.AMLCFT,
                TAT = armIM.Compliance.Research.TAT,
                ChangingRegulations = armIM.Compliance.Research.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.Research.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.Research.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.Research.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.Research.LitigationRisk,
                Total = armIM.Compliance.Research.Total
            };
        }
    }

    public class ComplianceIMRatingOperationControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRatingOperationControl Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingOperationControl
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.OperationControl.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.OperationControl.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.OperationControl.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.OperationControl.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.OperationControl.AMLCFT,
                TAT = armIM.Compliance.OperationControl.TAT,
                ChangingRegulations = armIM.Compliance.OperationControl.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.OperationControl.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.OperationControl.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.OperationControl.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.OperationControl.LitigationRisk,
                Total = armIM.Compliance.OperationControl.Total
            };
        }
    }
    public class ComplianceIMRatingOperationSettlement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRatingOperationSettlement Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingOperationSettlement
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.OperationSettlement.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.OperationSettlement.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.OperationSettlement.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.OperationSettlement.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.OperationSettlement.AMLCFT,
                TAT = armIM.Compliance.OperationSettlement.TAT,
                ChangingRegulations = armIM.Compliance.OperationSettlement.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.OperationSettlement.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.OperationSettlement.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.OperationSettlement.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.OperationSettlement.LitigationRisk,
                Total = armIM.Compliance.OperationSettlement.Total
            };
        }
    }
    public class ComplianceIMRatingARMIM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRatingARMIM Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingARMIM
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.ARMIM.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.ARMIM.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.ARMIM.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.ARMIM.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.ARMIM.AMLCFT,
                TAT = armIM.Compliance.ARMIM.TAT,
                ChangingRegulations = armIM.Compliance.ARMIM.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.ARMIM.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.ARMIM.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.ARMIM.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.ARMIM.LitigationRisk,
                Total = armIM.Compliance.ARMIM.Total
            };
        }
    }

    public class ComplianceIMRatingARMRegistrar : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRatingARMRegistrar Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingARMRegistrar
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.ARMRegistrar.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.ARMRegistrar.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.ARMRegistrar.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.ARMRegistrar.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.ARMRegistrar.AMLCFT,
                TAT = armIM.Compliance.ARMRegistrar.TAT,
                ChangingRegulations = armIM.Compliance.ARMRegistrar.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.ARMRegistrar.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.ARMRegistrar.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.ARMRegistrar.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.ARMRegistrar.LitigationRisk,
                Total = armIM.Compliance.ARMRegistrar.Total
            };
        }
    }
    public class ComplianceIMRatingRetailOperation : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRatingRetailOperation Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingRetailOperation
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.RetailOperation.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.RetailOperation.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.RetailOperation.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.RetailOperation.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.RetailOperation.AMLCFT,
                TAT = armIM.Compliance.RetailOperation.TAT,
                ChangingRegulations = armIM.Compliance.RetailOperation.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.RetailOperation.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.RetailOperation.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.RetailOperation.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.RetailOperation.LitigationRisk,
                Total = armIM.Compliance.RetailOperation.Total
            };
        }
    }
    public class ComplianceIMRatingFundAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRatingFundAdmin Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingFundAdmin
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.FundAdmin.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.FundAdmin.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.FundAdmin.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.FundAdmin.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.FundAdmin.AMLCFT,
                TAT = armIM.Compliance.FundAdmin.TAT,
                ChangingRegulations = armIM.Compliance.FundAdmin.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.FundAdmin.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.FundAdmin.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.FundAdmin.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.FundAdmin.LitigationRisk,
                Total = armIM.Compliance.FundAdmin.Total
            };
        }
    }
    public class ComplianceIMRatingFundAccount : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRatingFundAccount Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingFundAccount
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.FundAccount.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.FundAccount.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.FundAccount.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.FundAccount.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.FundAccount.AMLCFT,
                TAT = armIM.Compliance.FundAccount.TAT,
                ChangingRegulations = armIM.Compliance.FundAccount.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.FundAccount.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.FundAccount.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.FundAccount.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.FundAccount.LitigationRisk,
                Total = armIM.Compliance.FundAccount.Total
            };
        }
    }
    public class ComplianceIMRatingBDPWMIAMIMRetail : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
        //public ComplianceIMBusinessRating ComplianceIMBusinessRating { get; set; }
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
        public static ComplianceIMRatingBDPWMIAMIMRetail Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRatingBDPWMIAMIMRetail
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.BDPWMIAMIMRetail.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.BDPWMIAMIMRetail.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.BDPWMIAMIMRetail.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.BDPWMIAMIMRetail.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.BDPWMIAMIMRetail.AMLCFT,
                TAT = armIM.Compliance.BDPWMIAMIMRetail.TAT,
                ChangingRegulations = armIM.Compliance.BDPWMIAMIMRetail.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.BDPWMIAMIMRetail.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.BDPWMIAMIMRetail.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.BDPWMIAMIMRetail.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.BDPWMIAMIMRetail.LitigationRisk,
                Total = armIM.Compliance.BDPWMIAMIMRetail.Total
            };
        }
    }
    public class ComplianceIMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceIMBusinessRating))]
        public Guid ComplianceIMBusinessRatingId { get; set; }
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
        public static ComplianceIMRating Create(Guid complianceIMId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new ComplianceIMRating
            {
                ComplianceIMBusinessRatingId = complianceIMId,
                DisclosureRisk = armIM.Compliance.IMUnit.DisclosureRisk,
                CorporateGovernance = armIM.Compliance.IMUnit.CorporateGovernance,
                GDPROrNDPR = armIM.Compliance.IMUnit.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = armIM.Compliance.IMUnit.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = armIM.Compliance.IMUnit.AMLCFT,
                TAT = armIM.Compliance.IMUnit.TAT,
                ChangingRegulations = armIM.Compliance.IMUnit.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armIM.Compliance.IMUnit.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armIM.Compliance.IMUnit.KYCChecks,
                NonComplianceWithContracts = armIM.Compliance.IMUnit.NonComplianceWithContracts,
                LitigationRisk = armIM.Compliance.IMUnit.LitigationRisk,
                Total = armIM.Compliance.IMUnit.Total
            };
        }
    }

    public class TimeSinceLastAuditIMBusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(ARMIMBusinessRiskRating))]
        public Guid ARMIMBusinessRiskRatingId { get; set; }
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
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static TimeSinceLastAuditIMBusinessRating Create(Guid armIMBusinessRiskRatingId, ARMIMBusinessRiskRatingReq armIM)
        {
            return new TimeSinceLastAuditIMBusinessRating
            {
                ARMIMBusinessRiskRatingId = armIMBusinessRiskRatingId,
                ARMIM = armIM.LastReportOverallRating.ARMIM,
                IMUnit = armIM.LastReportOverallRating.IMUnit,
                BDPWMIAMIMRetail = armIM.LastReportOverallRating.BDPWMIAMIMRetail,
                FundAccount = armIM.LastReportOverallRating.FundAccount,
                FundAdmin = armIM.LastReportOverallRating.FundAdmin,
                ARMRegistrar = armIM.LastReportOverallRating.ARMRegistrar,
                OperationControl = armIM.LastReportOverallRating.OperationControl,
                OperationSettlement = armIM.LastReportOverallRating.OperationSettlement,
                RetailOperation = armIM.LastReportOverallRating.RetailOperation,
                Research = armIM.LastReportOverallRating.Research,
                Comment = armIM.LastReportOverallRating.Comment

            };
        }
    }

    #endregion

    #region Digital Financial Service
    public class DigitalFinancialServiceBusinessRiskRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategyDigitalFinancialService Strategy { get; set; }
        public OperationDigitalFinancialService Operations { get; set; }
        public FinancialDigitalFinancialService FinancialReporting { get; set; }
        public ComplianceDigitalFinancialService Compliance { get; set; }
        public TimeSinceLastAuditDigitalFinancialService TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterName { get; set; }
        public static DigitalFinancialServiceBusinessRiskRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string requesterName)
        {
            return new DigitalFinancialServiceBusinessRiskRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterName = requesterName
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategyDigitalFinancialService : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRating))]
        public Guid DigitalFinancialServiceBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRatingId))]
        public DigitalFinancialServiceBusinessRiskRating DigitalFinancialServiceBusinessRiskRating { get; set; }
        public StrategyDigitalFinancialServiceRating DigitalFinancialService { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategyDigitalFinancialService Create(Guid digitalFinancialServiceBusinessRiskRatingId, string comment)
        {
            return new StrategyDigitalFinancialService
            {
                DigitalFinancialServiceBusinessRiskRatingId = digitalFinancialServiceBusinessRiskRatingId,
                Comment = comment
            };
        }

    }

    public class StrategyDigitalFinancialServiceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyDigitalFinancialService))]
        public Guid StrategyDigitalFinancialServiceId { get; set; }
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

        public static StrategyDigitalFinancialServiceRating Create(Guid strategyDigitalFinancialServiceId, DigitalFinancialServicesBusinessRiskRatingReq dfs)
        {
            return new StrategyDigitalFinancialServiceRating
            {
                StrategyDigitalFinancialServiceId = strategyDigitalFinancialServiceId,
                FluidityofTechnologicalSolutions = dfs.Strategy.DigitalFinancialServices.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = dfs.Strategy.DigitalFinancialServices.CurrencyDevaluation,
                Increasedleverage = dfs.Strategy.DigitalFinancialServices.Increasedleverage,
                SocialRisk = dfs.Strategy.DigitalFinancialServices.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = dfs.Strategy.DigitalFinancialServices.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = dfs.Strategy.DigitalFinancialServices.DropinFundandFundManagerRatings,
                BCPandDRP = dfs.Strategy.DigitalFinancialServices.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = dfs.Strategy.DigitalFinancialServices.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = dfs.Strategy.DigitalFinancialServices.AllianceandPartnershipRisks,
                EmergingRisks = dfs.Strategy.DigitalFinancialServices.EmergingRisks,
                EnvironmentalRisk = dfs.Strategy.DigitalFinancialServices.EnvironmentalRisk,
                ErosionofStatutoryCapital = dfs.Strategy.DigitalFinancialServices.ErosionofStatutoryCapital,
                ReputationalRisk = dfs.Strategy.DigitalFinancialServices.ReputationalRisk,
                RisktoProfitabilityorPerformance = dfs.Strategy.DigitalFinancialServices.RisktoProfitabilityorPerformance,
                CreditRisk = dfs.Strategy.DigitalFinancialServices.CreditRisk,
                SustainabilityRisk = dfs.Strategy.DigitalFinancialServices.SustainabilityRisk,
                HealthandSafetyRisks = dfs.Strategy.DigitalFinancialServices.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = dfs.Strategy.DigitalFinancialServices.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = dfs.Strategy.DigitalFinancialServices.FailureofInvestor,
                FlunCTOatingInterestRates = dfs.Strategy.DigitalFinancialServices.FlunCTOatingInterestRates,
                PortfolioProductandFundPerformanceRisk = dfs.Strategy.DigitalFinancialServices.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = dfs.Strategy.DigitalFinancialServices.InformationSecurityRisk,
                ExitRisk = dfs.Strategy.DigitalFinancialServices.ExitRisk,
                InvestmentRisk = dfs.Strategy.DigitalFinancialServices.InvestmentRisk,
                LiquidityPressures = dfs.Strategy.DigitalFinancialServices.LiquidityPressures,
                MyLegacyIssuesProperty = dfs.Strategy.DigitalFinancialServices.MyLegacyIssuesProperty,
                PoliticalRisk = dfs.Strategy.DigitalFinancialServices.PoliticalRisk,
                PeopleRetentionRisk = dfs.Strategy.DigitalFinancialServices.PeopleRetentionRisk,
                ProductivityRisk = dfs.Strategy.DigitalFinancialServices.ProductivityRisk,
                ProjectManagementRisk = dfs.Strategy.DigitalFinancialServices.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = dfs.Strategy.DigitalFinancialServices.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = dfs.Strategy.DigitalFinancialServices.TechnologicalRisk,
                Total = dfs.Strategy.DigitalFinancialServices.Total
            };
        }

    }

    public class OperationDigitalFinancialService : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRating))]
        public Guid DigitalFinancialServiceBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRatingId))]
        public DigitalFinancialServiceBusinessRiskRating DigitalFinancialServiceBusinessRiskRating { get; set; }
        public OperationDigitalFinancialServiceRating DigitalFinancialService { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationDigitalFinancialService Create(Guid digitalFinancialServiceBusinessRiskRatingId, string comment)
        {
            return new OperationDigitalFinancialService
            {
                DigitalFinancialServiceBusinessRiskRatingId = digitalFinancialServiceBusinessRiskRatingId,
                Comment = comment
            };
        }

    }

    public class OperationDigitalFinancialServiceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationDigitalFinancialService))]
        public Guid OperationDigitalFinancialServiceId { get; set; }
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
        public static OperationDigitalFinancialServiceRating Create(Guid operationDigitalFinancialServiceId, DigitalFinancialServicesBusinessRiskRatingReq dfs)
        {
            return new OperationDigitalFinancialServiceRating
            {
                OperationDigitalFinancialServiceId = operationDigitalFinancialServiceId,
                AdoptionandImplementationofPolicies = dfs.Operations.DigitalFinancialService.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = dfs.Operations.DigitalFinancialService.StrategyMonitoringRisk,
                BudgetOverruns = dfs.Operations.DigitalFinancialService.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = dfs.Operations.DigitalFinancialService.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = dfs.Operations.DigitalFinancialService.OverorUnderpaymentofClient,
                TheftorFraudRisk = dfs.Operations.DigitalFinancialService.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = dfs.Operations.DigitalFinancialService.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = dfs.Operations.DigitalFinancialService.TAT,
                ThirdpartyRisk = dfs.Operations.DigitalFinancialService.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = dfs.Operations.DigitalFinancialService.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = dfs.Operations.DigitalFinancialService.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = dfs.Operations.DigitalFinancialService.MalwareorVirusorWebsiteAttacks,
                Miscommunication = dfs.Operations.DigitalFinancialService.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = dfs.Operations.DigitalFinancialService.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = dfs.Operations.DigitalFinancialService.ProductivityRisk,
                RecruitmentRisk = dfs.Operations.DigitalFinancialService.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = dfs.Operations.DigitalFinancialService.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = dfs.Operations.DigitalFinancialService.ErrorDetectionRisk,
                PoorCustomerService = dfs.Operations.DigitalFinancialService.PoorCustomerService,
                UnauthorizedAccess = dfs.Operations.DigitalFinancialService.UnauthorizedAccess,
                Total = dfs.Operations.DigitalFinancialService.Total

            };
        }

    }

    public class FinancialDigitalFinancialService : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRating))]
        public Guid DigitalFinancialServiceBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRatingId))]
        public DigitalFinancialServiceBusinessRiskRating DigitalFinancialServiceBusinessRiskRating { get; set; }
        public FinacialBusinessDigitalFinancialServiceRating DigitalFinancialService { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialDigitalFinancialService Create(Guid digitalFinancialServiceBusinessRiskRatingId, string comment)
        {
            return new FinancialDigitalFinancialService
            {
                DigitalFinancialServiceBusinessRiskRatingId = digitalFinancialServiceBusinessRiskRatingId,
                Comment = comment
            };
        }
    }

    public class FinacialBusinessDigitalFinancialServiceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialDigitalFinancialService))]
        public Guid FinancialDigitalFinancialServiceId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialBusinessDigitalFinancialServiceRating Create(Guid financialDigitalFinancialServiceId, DigitalFinancialServicesBusinessRiskRatingReq dfs)
        {
            return new FinacialBusinessDigitalFinancialServiceRating
            {
                FinancialDigitalFinancialServiceId = financialDigitalFinancialServiceId,
                AdherencetoFinancialStandards = dfs.FinancialReporting.DigitalFinancialService.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = dfs.FinancialReporting.DigitalFinancialService.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = dfs.FinancialReporting.DigitalFinancialService.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = dfs.FinancialReporting.DigitalFinancialService.ErrororControlRisk,
                IncomeAssuranceRisk = dfs.FinancialReporting.DigitalFinancialService.IncomeAssuranceRisk,
                TAT = dfs.FinancialReporting.DigitalFinancialService.TAT,
                TheftorFraudRisk = dfs.FinancialReporting.DigitalFinancialService.TheftorFraudRisk,
                Total = dfs.FinancialReporting.DigitalFinancialService.Total
            };
        }

    }

    public class ComplianceDigitalFinancialService : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRating))]
        public Guid DigitalFinancialServiceBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRatingId))]
        public DigitalFinancialServiceBusinessRiskRating DigitalFinancialServiceBusinessRiskRating { get; set; }
        public ComplianceBusinessDigitalFinancialServiceRating DigitalFinancialService { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceDigitalFinancialService Create(Guid digitalFinancialServiceBusinessRiskRatingId, string comment)
        {
            return new ComplianceDigitalFinancialService
            {
                DigitalFinancialServiceBusinessRiskRatingId = digitalFinancialServiceBusinessRiskRatingId,
                Comment = comment
            };
        }

    }

    public class ComplianceBusinessDigitalFinancialServiceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceDigitalFinancialService))]
        public Guid ComplianceDigitalFinancialServiceId { get; set; }
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
        public static ComplianceBusinessDigitalFinancialServiceRating Create(Guid complianceDigitalFinancialServiceId, DigitalFinancialServicesBusinessRiskRatingReq dfs)
        {
            return new ComplianceBusinessDigitalFinancialServiceRating
            {
                ComplianceDigitalFinancialServiceId = complianceDigitalFinancialServiceId,
                DisclosureRisk = dfs.Compliance.DigitalFinancialService.DisclosureRisk,
                CorporateGovernance = dfs.Compliance.DigitalFinancialService.CorporateGovernance,
                GDPROrNDPR = dfs.Compliance.DigitalFinancialService.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = dfs.Compliance.DigitalFinancialService.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = dfs.Compliance.DigitalFinancialService.AMLCFT,
                TAT = dfs.Compliance.DigitalFinancialService.TAT,
                ChangingRegulations = dfs.Compliance.DigitalFinancialService.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = dfs.Compliance.DigitalFinancialService.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = dfs.Compliance.DigitalFinancialService.KYCChecks,
                NonComplianceWithContracts = dfs.Compliance.DigitalFinancialService.NonComplianceWithContracts,
                LitigationRisk = dfs.Compliance.DigitalFinancialService.LitigationRisk,
                Total = dfs.Compliance.DigitalFinancialService.Total
            };
        }
    }

    public class TimeSinceLastAuditDigitalFinancialService : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRating))]
        public Guid DigitalFinancialServiceBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(DigitalFinancialServiceBusinessRiskRatingId))]
        public DigitalFinancialServiceBusinessRiskRating DigitalFinancialServiceBusinessRiskRating { get; set; }
        public int DigitalFinancialService { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static TimeSinceLastAuditDigitalFinancialService Create(Guid digitalFinancialServiceBusinessRiskRatingId, DigitalFinancialServicesBusinessRiskRatingReq dfs)
        {
            return new TimeSinceLastAuditDigitalFinancialService
            {
                DigitalFinancialServiceBusinessRiskRatingId = digitalFinancialServiceBusinessRiskRatingId,
                DigitalFinancialService = dfs.LastReportOverallRating.DigitalFinancialService,

                Comment = dfs.LastReportOverallRating.Comment
            };
        }
    }
    #endregion

    #region ARM Capital
    public class ARMCapitalBusinessRiskRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategyARMCapital Strategy { get; set; }
        public OperationARMCapital Operations { get; set; }
        public FinancialARMCapital FinancialReporting { get; set; }
        public ComplianceARMCapital Compliance { get; set; }
        public TimeSinceLastAuditARMCapital TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterName { get; set; }
        public static ARMCapitalBusinessRiskRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string requesterName)
        {
            return new ARMCapitalBusinessRiskRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterName = requesterName
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategyARMCapital : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMCapitalBusinessRiskRating))]
        public Guid ARMCapitalBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMCapitalBusinessRiskRatingId))]
        public ARMCapitalBusinessRiskRating ARMCapitalBusinessRiskRating { get; set; }
        public StrategyARMCapitalRating ARMCapital { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategyARMCapital Create(Guid armCapitalBusinessRiskRatingId, string comment)
        {
            return new StrategyARMCapital
            {
                ARMCapitalBusinessRiskRatingId = armCapitalBusinessRiskRatingId,
                Comment = comment
            };
        }

    }

    public class StrategyARMCapitalRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategyARMCapital))]
        public Guid StrategyARMCapitalId { get; set; }
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

        public static StrategyARMCapitalRating Create(Guid strategyARMCapitalId, ARMCapitalBusinessRiskRatingReq dfs)
        {
            return new StrategyARMCapitalRating
            {
                StrategyARMCapitalId = strategyARMCapitalId,
                FluidityofTechnologicalSolutions = dfs.Strategy.ARMCapital.FluidityofTechnologicalSolutions,
                CurrencyDevaluation = dfs.Strategy.ARMCapital.CurrencyDevaluation,
                Increasedleverage = dfs.Strategy.ARMCapital.Increasedleverage,
                SocialRisk = dfs.Strategy.ARMCapital.SocialRisk,
                StiffCompetitionandPoorVisibilityOftheBusiness = dfs.Strategy.ARMCapital.StiffCompetitionandPoorVisibilityOftheBusiness,
                DropinFundandFundManagerRatings = dfs.Strategy.ARMCapital.DropinFundandFundManagerRatings,
                BCPandDRP = dfs.Strategy.ARMCapital.DropinFundandFundManagerRatings,
                RiskofDeclineinMarketShare = dfs.Strategy.ARMCapital.RiskofDeclineinMarketShare,
                AllianceandPartnershipRisks = dfs.Strategy.ARMCapital.AllianceandPartnershipRisks,
                EmergingRisks = dfs.Strategy.ARMCapital.EmergingRisks,
                EnvironmentalRisk = dfs.Strategy.ARMCapital.EnvironmentalRisk,
                ErosionofStatutoryCapital = dfs.Strategy.ARMCapital.ErosionofStatutoryCapital,
                ReputationalRisk = dfs.Strategy.ARMCapital.ReputationalRisk,
                RisktoProfitabilityorPerformance = dfs.Strategy.ARMCapital.RisktoProfitabilityorPerformance,
                CreditRisk = dfs.Strategy.ARMCapital.CreditRisk,
                SustainabilityRisk = dfs.Strategy.ARMCapital.SustainabilityRisk,
                HealthandSafetyRisks = dfs.Strategy.ARMCapital.HealthandSafetyRisks,
                HarshMacroeconomicConditionsegInflation = dfs.Strategy.ARMCapital.HarshMacroeconomicConditionsegInflation,
                FailureofInvestor = dfs.Strategy.ARMCapital.FailureofInvestor,
                FlunCTOatingInterestRates = dfs.Strategy.ARMCapital.FlunCTOatingInterestRates,
                PortfolioProductandFundPerformanceRisk = dfs.Strategy.ARMCapital.PortfolioProductandFundPerformanceRisk,
                InformationSecurityRisk = dfs.Strategy.ARMCapital.InformationSecurityRisk,
                ExitRisk = dfs.Strategy.ARMCapital.ExitRisk,
                InvestmentRisk = dfs.Strategy.ARMCapital.InvestmentRisk,
                LiquidityPressures = dfs.Strategy.ARMCapital.LiquidityPressures,
                MyLegacyIssuesProperty = dfs.Strategy.ARMCapital.MyLegacyIssuesProperty,
                PoliticalRisk = dfs.Strategy.ARMCapital.PoliticalRisk,
                PeopleRetentionRisk = dfs.Strategy.ARMCapital.PeopleRetentionRisk,
                ProductivityRisk = dfs.Strategy.ARMCapital.ProductivityRisk,
                ProjectManagementRisk = dfs.Strategy.ARMCapital.ProjectManagementRisk,
                UnregulatedUnstruCTOredlandscape = dfs.Strategy.ARMCapital.UnregulatedUnstruCTOredlandscape,
                TechnologicalRisk = dfs.Strategy.ARMCapital.TechnologicalRisk,
                Total = dfs.Strategy.ARMCapital.Total
            };
        }

    }

    public class OperationARMCapital : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMCapitalBusinessRiskRating))]
        public Guid ARMCapitalBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMCapitalBusinessRiskRatingId))]
        public ARMCapitalBusinessRiskRating ARMCapitalBusinessRiskRating { get; set; }
        public OperationARMCapitalRating ARMCapital { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationARMCapital Create(Guid armCapitalBusinessRiskRatingId, string comment)
        {
            return new OperationARMCapital
            {
                ARMCapitalBusinessRiskRatingId = armCapitalBusinessRiskRatingId,
                Comment = comment
            };
        }

    }

    public class OperationARMCapitalRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationARMCapital))]
        public Guid OperationARMCapitalId { get; set; }
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
        public static OperationARMCapitalRating Create(Guid operationARMCapitalId, ARMCapitalBusinessRiskRatingReq dfs)
        {
            return new OperationARMCapitalRating
            {
                OperationARMCapitalId = operationARMCapitalId,
                AdoptionandImplementationofPolicies = dfs.Operations.ARMCapital.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = dfs.Operations.ARMCapital.StrategyMonitoringRisk,
                BudgetOverruns = dfs.Operations.ARMCapital.BudgetOverruns,
                ConfidentialityIntegrityandAvailabilityofData = dfs.Operations.ARMCapital.ConfidentialityIntegrityandAvailabilityofData,
                OverorUnderpaymentofClient = dfs.Operations.ARMCapital.OverorUnderpaymentofClient,
                TheftorFraudRisk = dfs.Operations.ARMCapital.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = dfs.Operations.ARMCapital.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = dfs.Operations.ARMCapital.TAT,
                ThirdpartyRisk = dfs.Operations.ARMCapital.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = dfs.Operations.ARMCapital.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = dfs.Operations.ARMCapital.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = dfs.Operations.ARMCapital.MalwareorVirusorWebsiteAttacks,
                Miscommunication = dfs.Operations.ARMCapital.Miscommunication,
                InadequateProfilingOfClientsToEffectivelySellProduct = dfs.Operations.ARMCapital.InadequateProfilingOfClientsToEffectivelySellProduct,
                ProductivityRisk = dfs.Operations.ARMCapital.ProductivityRisk,
                RecruitmentRisk = dfs.Operations.ARMCapital.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = dfs.Operations.ARMCapital.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = dfs.Operations.ARMCapital.ErrorDetectionRisk,
                PoorCustomerService = dfs.Operations.ARMCapital.PoorCustomerService,
                UnauthorizedAccess = dfs.Operations.ARMCapital.UnauthorizedAccess,
                Total = dfs.Operations.ARMCapital.Total

            };
        }

    }

    public class FinancialARMCapital : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMCapitalBusinessRiskRating))]
        public Guid ARMCapitalBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMCapitalBusinessRiskRatingId))]
        public ARMCapitalBusinessRiskRating ARMCapitalBusinessRiskRating { get; set; }
        public FinacialBusinessARMCapitalRating ARMCapital { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static FinancialARMCapital Create(Guid armCapitalBusinessRiskRatingId, string comment)
        {
            return new FinancialARMCapital
            {
                ARMCapitalBusinessRiskRatingId = armCapitalBusinessRiskRatingId,
                Comment = comment
            };
        }
    }

    public class FinacialBusinessARMCapitalRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(FinancialARMCapital))]
        public Guid FinancialARMCapitalId { get; set; }
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }
        public static FinacialBusinessARMCapitalRating Create(Guid financialARMCapitalId, ARMCapitalBusinessRiskRatingReq dfs)
        {
            return new FinacialBusinessARMCapitalRating
            {
                FinancialARMCapitalId = financialARMCapitalId,
                AdherencetoFinancialStandards = dfs.FinancialReporting.ARMCapital.AdherencetoFinancialStandards,
                StatutoryDeductionsandTaxes = dfs.FinancialReporting.ARMCapital.StatutoryDeductionsandTaxes,
                AdoptionandImplementationofPoliciesAdherence = dfs.FinancialReporting.ARMCapital.AdoptionandImplementationofPoliciesAdherence,
                ErrororControlRisk = dfs.FinancialReporting.ARMCapital.ErrororControlRisk,
                IncomeAssuranceRisk = dfs.FinancialReporting.ARMCapital.IncomeAssuranceRisk,
                TAT = dfs.FinancialReporting.ARMCapital.TAT,
                TheftorFraudRisk = dfs.FinancialReporting.ARMCapital.TheftorFraudRisk,
                Total = dfs.FinancialReporting.ARMCapital.Total
            };
        }

    }

    public class ComplianceARMCapital : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMCapitalBusinessRiskRating))]
        public Guid ARMCapitalBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMCapitalBusinessRiskRatingId))]
        public ARMCapitalBusinessRiskRating ARMCapitalBusinessRiskRating { get; set; }
        public ComplianceBusinessARMCapitalRating ARMCapital { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceARMCapital Create(Guid armCapitalBusinessRiskRatingId, string comment)
        {
            return new ComplianceARMCapital
            {
                ARMCapitalBusinessRiskRatingId = armCapitalBusinessRiskRatingId,
                Comment = comment
            };
        }

    }

    public class ComplianceBusinessARMCapitalRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceARMCapital))]
        public Guid ComplianceARMCapitalId { get; set; }
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
        public static ComplianceBusinessARMCapitalRating Create(Guid complianceARMCapitalId, ARMCapitalBusinessRiskRatingReq dfs)
        {
            return new ComplianceBusinessARMCapitalRating
            {
                ComplianceARMCapitalId = complianceARMCapitalId,
                DisclosureRisk = dfs.Compliance.ARMCapital.DisclosureRisk,
                CorporateGovernance = dfs.Compliance.ARMCapital.CorporateGovernance,
                GDPROrNDPR = dfs.Compliance.ARMCapital.GDPROrNDPR,
                AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = dfs.Compliance.ARMCapital.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                AMLCFT = dfs.Compliance.ARMCapital.AMLCFT,
                TAT = dfs.Compliance.ARMCapital.TAT,
                ChangingRegulations = dfs.Compliance.ARMCapital.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = dfs.Compliance.ARMCapital.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = dfs.Compliance.ARMCapital.KYCChecks,
                NonComplianceWithContracts = dfs.Compliance.ARMCapital.NonComplianceWithContracts,
                LitigationRisk = dfs.Compliance.ARMCapital.LitigationRisk,
                Total = dfs.Compliance.ARMCapital.Total
            };
        }
    }

    public class TimeSinceLastAuditARMCapital : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMCapitalBusinessRiskRating))]
        public Guid ARMCapitalBusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(ARMCapitalBusinessRiskRatingId))]
        public ARMCapitalBusinessRiskRating ARMCapitalBusinessRiskRating { get; set; }
        public int ARMCapital { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static TimeSinceLastAuditARMCapital Create(Guid armCapitalBusinessRiskRatingId, ARMCapitalBusinessRiskRatingReq dfs)
        {
            return new TimeSinceLastAuditARMCapital
            {
                ARMCapitalBusinessRiskRatingId = armCapitalBusinessRiskRatingId,
                ARMCapital = dfs.LastReportOverallRating.ARMCapital,
                Comment = dfs.LastReportOverallRating.Comment
            };
        }
    }
    #endregion

    #region ARM SharedService
    public class ARMSharedServiceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public StrategySharedService Strategy { get; set; }
        public OperationSharedService Operations { get; set; }
        public ComplianceSharedService Compliance { get; set; }
        public TimeSinceLastSharedServiceAudit TimeSinceLastAudit { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public string? RequesterEmail { get; set; }
        public static ARMSharedServiceRating Create(Guid businessRiskRatingId, BusinessRiskRatingStatus status, string email)
        {
            return new ARMSharedServiceRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Status = status,
                RequesterEmail = email
            };
        }

        public void ApproveBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectBusinessRating()
        {
            Status = BusinessRiskRatingStatus.Rejected;
        }
    }
    public class StrategySharedService : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedServiceRating))]
        public Guid ARMSharedServiceRatingId { get; set; }
        [ForeignKey(nameof(ARMSharedServiceRatingId))]
        public ARMSharedServiceRating ARMSharedServiceRating { get; set; }
        public StrategySharedServiceFinancialControl FinancialControl { get; set; }
        public StrategySharedServiceCompliance Compliance { get; set; }
        public StrategySharedServiceRatingHCM HCM { get; set; }
        public StrategySharedServiceRatingProcurementAndAdmin ProcurementAndAdmin { get; set; }
        public StrategySharedServiceRatingIT IT { get; set; }
        public StrategySharedServiceRatingRiskManagement RiskManagement { get; set; }
        public StrategySharedServiceRatingAcademy Academy { get; set; }
        public StrategySharedServiceRatingLegal Legal { get; set; }
        public StrategySharedServiceRatingMCC MCC { get; set; }
        public StrategySharedServiceRatingCTO CTO { get; set; }
        public StrategySharedServiceRatingCustomerexperience CustomerExperience { get; set; }
        public StrategySharedServiceRatingInformationSecurity InformationSecurity { get; set; }
        public StrategySharedServiceRatingInternalControl InternalControl { get; set; }
        public StrategySharedServiceRatingCorporatestrategy CorporateStrategy { get; set; }
        public StrategySharedServiceRatingTreasury Treasury { get; set; }
        public StrategySharedServiceDataAnalytic DataAnalytic { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static StrategySharedService Create(Guid armSharedServiceRatingId, string comment)
        {
            return new StrategySharedService
            {
                ARMSharedServiceRatingId = armSharedServiceRatingId,
                Comment = comment
            };
        }
    }
    public class StrategySharedServiceFinancialControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceFinancialControl Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceFinancialControl
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.FinancialControl.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.FinancialControl.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.FinancialControl.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.FinancialControl.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.FinancialControl.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.FinancialControl.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.FinancialControl.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.FinancialControl.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.FinancialControl.TechnologicalRisk,
                Total = armSharedService.Strategy.FinancialControl.Total
            };
        }

    }
    public class StrategySharedServiceCompliance : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceCompliance Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceCompliance
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.Compliance.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.Compliance.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.Compliance.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.Compliance.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.Compliance.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.Compliance.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.Compliance.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.Compliance.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.Compliance.TechnologicalRisk,
                Total = armSharedService.Strategy.Compliance.Total
            };
        }

    }
    public class StrategySharedServiceRatingTreasury : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingTreasury Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingTreasury
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.Treasury.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.Treasury.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.Treasury.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.Treasury.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.Treasury.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.Treasury.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.Treasury.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.Treasury.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.Treasury.TechnologicalRisk,
                Total = armSharedService.Strategy.Treasury.Total
            };
        }

    }
    public class StrategySharedServiceRatingCorporatestrategy : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingCorporatestrategy Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingCorporatestrategy
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.Corporatestrategy.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.Corporatestrategy.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.Corporatestrategy.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.Corporatestrategy.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.Corporatestrategy.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.Corporatestrategy.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.Corporatestrategy.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.Corporatestrategy.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.Corporatestrategy.TechnologicalRisk,
                Total = armSharedService.Strategy.Corporatestrategy.Total
            };
        }

    }
    public class StrategySharedServiceRatingInternalControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingInternalControl Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingInternalControl
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.InternalControl.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.InternalControl.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.InternalControl.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.InternalControl.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.InternalControl.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.InternalControl.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.InternalControl.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.InternalControl.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.InternalControl.TechnologicalRisk,
                Total = armSharedService.Strategy.InternalControl.Total
            };
        }
    }
    public class StrategySharedServiceRatingInformationSecurity : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingInformationSecurity Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingInformationSecurity
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.InformationSecurity.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.InformationSecurity.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.InformationSecurity.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.InformationSecurity.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.InformationSecurity.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.InformationSecurity.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.InformationSecurity.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.InformationSecurity.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.InformationSecurity.TechnologicalRisk,
                Total = armSharedService.Strategy.InformationSecurity.Total
            };
        }

    }
    public class StrategySharedServiceRatingCustomerexperience : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingCustomerexperience Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingCustomerexperience
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.CustomerExperience.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.CustomerExperience.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.CustomerExperience.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.CustomerExperience.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.CustomerExperience.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.CustomerExperience.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.CustomerExperience.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.CustomerExperience.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.CustomerExperience.TechnologicalRisk,
                Total = armSharedService.Strategy.CustomerExperience.Total
            };
        }

    }
    public class StrategySharedServiceRatingCTO : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingCTO Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingCTO
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.CTO.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.CTO.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.CTO.ReputationalRisk,
                InformationSecurityRisk = armSharedService.Strategy.CTO.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.CTO.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.CTO.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.CTO.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.CTO.TechnologicalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.CTO.HealthandSafetyRisks,
                Total = armSharedService.Strategy.CTO.Total
            };
        }

    }
    public class StrategySharedServiceRatingMCC : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingMCC Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingMCC
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.MCC.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.MCC.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.MCC.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.MCC.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.MCC.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.MCC.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.MCC.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.MCC.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.MCC.TechnologicalRisk,
                Total = armSharedService.Strategy.MCC.Total

            };
        }

    }
    public class StrategySharedServiceRatingLegal : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingLegal Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingLegal
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.Legal.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.Legal.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.Legal.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.Legal.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.Legal.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.Legal.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.Legal.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.Legal.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.Legal.TechnologicalRisk,
                Total = armSharedService.Strategy.Legal.Total
            };
        }

    }
    public class StrategySharedServiceRatingAcademy : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingAcademy Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingAcademy
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.Academy.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.Academy.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.Academy.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.Academy.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.Academy.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.Academy.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.Academy.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.Academy.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.Academy.TechnologicalRisk,
                Total = armSharedService.Strategy.Academy.Total
            };
        }

    }
    public class StrategySharedServiceRatingRiskManagement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingRiskManagement Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingRiskManagement
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.RiskManagement.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.RiskManagement.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.RiskManagement.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.RiskManagement.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.RiskManagement.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.RiskManagement.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.RiskManagement.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.RiskManagement.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.RiskManagement.TechnologicalRisk,
                Total = armSharedService.Strategy.RiskManagement.Total
            };
        }

    }
    public class StrategySharedServiceRatingIT : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingIT Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingIT
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.IT.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.IT.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.IT.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.IT.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.IT.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.IT.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.IT.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.IT.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.IT.TechnologicalRisk,
                Total = armSharedService.Strategy.IT.Total
            };
        }

    }
    public class StrategySharedServiceRatingProcurementAndAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingProcurementAndAdmin Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingProcurementAndAdmin
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.ProcurementAndAdmin.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.ProcurementAndAdmin.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.ProcurementAndAdmin.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.ProcurementAndAdmin.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.ProcurementAndAdmin.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.ProcurementAndAdmin.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.ProcurementAndAdmin.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.ProcurementAndAdmin.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.ProcurementAndAdmin.TechnologicalRisk,
                Total = armSharedService.Strategy.ProcurementAndAdmin.Total
            };
        }
    }
    public class StrategySharedServiceRatingHCM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceRatingHCM Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceRatingHCM
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.HCM.FluidityofTechnologicalSolutions,
                ReputationalRisk = armSharedService.Strategy.HCM.ReputationalRisk,
                InformationSecurityRisk = armSharedService.Strategy.HCM.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.HCM.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.HCM.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.HCM.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.HCM.TechnologicalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.HCM.HealthandSafetyRisks,
                EmergingRisks = armSharedService.Strategy.HCM.EmergingRisks,
                Total = armSharedService.Strategy.HCM.Total
            };
        }
    }
    public class StrategySharedServiceDataAnalytic : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(StrategySharedService))]
        public Guid StrategySharedServiceId { get; set; }
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
        public static StrategySharedServiceDataAnalytic Create(Guid strategySharedServiceId, ARMSharedServiceRatingReq armSharedService)
        {
            return new StrategySharedServiceDataAnalytic
            {
                StrategySharedServiceId = strategySharedServiceId,
                FluidityofTechnologicalSolutions = armSharedService.Strategy.DataAnalytic.FluidityofTechnologicalSolutions,
                EmergingRisks = armSharedService.Strategy.DataAnalytic.EmergingRisks,
                ReputationalRisk = armSharedService.Strategy.DataAnalytic.ReputationalRisk,
                HealthandSafetyRisks = armSharedService.Strategy.DataAnalytic.HealthandSafetyRisks,
                InformationSecurityRisk = armSharedService.Strategy.DataAnalytic.InformationSecurityRisk,
                PeopleRetentionRisk = armSharedService.Strategy.DataAnalytic.PeopleRetentionRisk,
                ProductivityRisk = armSharedService.Strategy.DataAnalytic.ProductivityRisk,
                ProjectManagementRisk = armSharedService.Strategy.DataAnalytic.ProjectManagementRisk,
                TechnologicalRisk = armSharedService.Strategy.DataAnalytic.TechnologicalRisk,
                Total = armSharedService.Strategy.DataAnalytic.Total
            };
        }
    }
    public class OperationSharedService : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedServiceRating))]
        public Guid ARMSharedServiceRatingId { get; set; }
        [ForeignKey(nameof(ARMSharedServiceRatingId))]
        public ARMSharedServiceRating ARMSharedServiceRating { get; set; }
        public OperationSharedServiceRatingHCM HCM { get; set; }
        public OperationSharedServiceComplianceRating Compliance { get; set; }
        public OperationSharedServiceFinancialControlRating FinancialControl { get; set; }
        public OperationSharedServiceDataAnalyticRating DataAnalytic { get; set; }
        public OperationSharedServiceRatingProcurementAndAdmin ProcurementAndAdmin { get; set; }
        public OperationSharedServiceRatingIT IT { get; set; }
        public OperationSharedServiceRatingRiskManagement RiskManagement { get; set; }
        public OperationSharedServiceRatingAcademy Academy { get; set; }
        public OperationSharedServiceRatingLegal Legal { get; set; }
        public OperationSharedServiceRatingMCC MCC { get; set; }
        public OperationSharedServiceRatingCTO CTO { get; set; }
        public OperationSharedServiceRatingCustomerexperience CustomerExperience { get; set; }
        public OperationSharedServiceRatingInformationSecurity InformationSecurity { get; set; }
        public OperationSharedServiceRatingInternalControl InternalControl { get; set; }
        public OperationSharedServiceRatingCorporatestrategy CorporateStrategy { get; set; }
        public OperationSharedServiceRatingTreasury Treasury { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static OperationSharedService Create(Guid armSharedServiceRatingId, string comment)
        {
            return new OperationSharedService
            {
                ARMSharedServiceRatingId = armSharedServiceRatingId,
                Comment = comment
            };
        }
    }
    public class OperationSharedServiceDataAnalyticRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceDataAnalyticRating Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceDataAnalyticRating
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.DataAnalytic.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.DataAnalytic.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.DataAnalytic.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.DataAnalytic.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.DataAnalytic.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.DataAnalytic.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.DataAnalytic.TAT,
                ThirdpartyRisk = armshared.Operations.DataAnalytic.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.DataAnalytic.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.DataAnalytic.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.DataAnalytic.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.DataAnalytic.Miscommunication,
                RecruitmentRisk = armshared.Operations.DataAnalytic.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.DataAnalytic.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.DataAnalytic.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.DataAnalytic.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.DataAnalytic.UnauthorizedAccess,
                VendorManagement = armshared.Operations.DataAnalytic.VendorManagement,
                QualityManagament = armshared.Operations.DataAnalytic.QualityManagament,
                AssentMaintenance = armshared.Operations.DataAnalytic.AssentMaintenance,
                BCPandDRP = armshared.Operations.DataAnalytic.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.DataAnalytic.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.DataAnalytic.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.DataAnalytic.ObsoleteTechnology,
                Total = armshared.Operations.DataAnalytic.Total

            };
        }

    }
    public class OperationSharedServiceComplianceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int QualityManagament { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceComplianceRating Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceComplianceRating
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.Compliance.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.Compliance.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.Compliance.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.Compliance.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.Compliance.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.Compliance.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.Compliance.TAT,
                ThirdpartyRisk = armshared.Operations.Compliance.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.Compliance.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.Compliance.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.Compliance.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.Compliance.Miscommunication,
                RecruitmentRisk = armshared.Operations.Compliance.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.Compliance.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.Compliance.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.Compliance.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.Compliance.UnauthorizedAccess,
                VendorManagement = armshared.Operations.Compliance.VendorManagement,
                QualityManagament = armshared.Operations.Compliance.QualityManagament,
                AssentMaintenance = armshared.Operations.Compliance.AssentMaintenance,
                BCPandDRP = armshared.Operations.Compliance.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.Compliance.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.Compliance.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.Compliance.ObsoleteTechnology,
                Total = armshared.Operations.Compliance.Total

            };
        }

    }
    public class OperationSharedServiceFinancialControlRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceFinancialControlRating Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceFinancialControlRating
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.Financialcontrol.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.Financialcontrol.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.Financialcontrol.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.Financialcontrol.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.Financialcontrol.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.Financialcontrol.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.Financialcontrol.TAT,
                ThirdpartyRisk = armshared.Operations.Financialcontrol.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.Financialcontrol.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.Financialcontrol.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.Financialcontrol.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.Financialcontrol.Miscommunication,
                RecruitmentRisk = armshared.Operations.Financialcontrol.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.Financialcontrol.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.Financialcontrol.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.Financialcontrol.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.Financialcontrol.UnauthorizedAccess,
                VendorManagement = armshared.Operations.Financialcontrol.VendorManagement,
                QualityManagament = armshared.Operations.Financialcontrol.QualityManagament,
                AssentMaintenance = armshared.Operations.Financialcontrol.AssentMaintenance,
                BCPandDRP = armshared.Operations.Financialcontrol.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.Financialcontrol.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.Financialcontrol.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.Financialcontrol.ObsoleteTechnology,
                Total = armshared.Operations.Financialcontrol.Total

            };
        }

    }
    public class OperationSharedServiceRatingTreasury : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingTreasury Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingTreasury
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.Treasury.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.Treasury.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.Treasury.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.Treasury.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.Treasury.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.Treasury.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.Treasury.TAT,
                ThirdpartyRisk = armshared.Operations.Treasury.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.Treasury.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.Treasury.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.Treasury.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.Treasury.Miscommunication,
                RecruitmentRisk = armshared.Operations.Treasury.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.Treasury.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.Treasury.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.Treasury.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.Treasury.UnauthorizedAccess,
                VendorManagement = armshared.Operations.Treasury.VendorManagement,
                QualityManagament = armshared.Operations.Treasury.QualityManagament,
                AssentMaintenance = armshared.Operations.Treasury.AssentMaintenance,
                BCPandDRP = armshared.Operations.Treasury.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.Treasury.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.Treasury.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.Treasury.ObsoleteTechnology,
                Total = armshared.Operations.Treasury.Total

            };
        }


    }
    public class OperationSharedServiceRatingCorporatestrategy : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingCorporatestrategy Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingCorporatestrategy
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.Corporatestrategy.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.Corporatestrategy.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.Corporatestrategy.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.Corporatestrategy.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.Corporatestrategy.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.Corporatestrategy.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.Corporatestrategy.TAT,
                ThirdpartyRisk = armshared.Operations.Corporatestrategy.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.Corporatestrategy.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.Corporatestrategy.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.Corporatestrategy.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.Corporatestrategy.Miscommunication,
                RecruitmentRisk = armshared.Operations.Corporatestrategy.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.Corporatestrategy.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.Corporatestrategy.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.Corporatestrategy.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.Corporatestrategy.UnauthorizedAccess,
                VendorManagement = armshared.Operations.Corporatestrategy.VendorManagement,
                QualityManagament = armshared.Operations.Corporatestrategy.QualityManagament,
                AssentMaintenance = armshared.Operations.Corporatestrategy.AssentMaintenance,
                BCPandDRP = armshared.Operations.Corporatestrategy.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.Corporatestrategy.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.Corporatestrategy.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.Corporatestrategy.ObsoleteTechnology,
                Total = armshared.Operations.Corporatestrategy.Total

            };
        }


    }
    public class OperationSharedServiceRatingInternalControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingInternalControl Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingInternalControl
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.InternalControl.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.InternalControl.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.InternalControl.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.InternalControl.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.InternalControl.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.InternalControl.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.InternalControl.TAT,
                ThirdpartyRisk = armshared.Operations.InternalControl.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.InternalControl.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.InternalControl.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.InternalControl.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.InternalControl.Miscommunication,
                RecruitmentRisk = armshared.Operations.InternalControl.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.InternalControl.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.InternalControl.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.InternalControl.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.InternalControl.UnauthorizedAccess,
                VendorManagement = armshared.Operations.InternalControl.VendorManagement,
                QualityManagament = armshared.Operations.InternalControl.QualityManagament,
                AssentMaintenance = armshared.Operations.InternalControl.AssentMaintenance,
                BCPandDRP = armshared.Operations.InternalControl.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.InternalControl.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.InternalControl.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.InternalControl.ObsoleteTechnology,
                Total = armshared.Operations.InternalControl.Total

            };
        }


    }
    public class OperationSharedServiceRatingInformationSecurity : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingInformationSecurity Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingInformationSecurity
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.InformationSecurity.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.InformationSecurity.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.InformationSecurity.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.InformationSecurity.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.InformationSecurity.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.InformationSecurity.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.InformationSecurity.TAT,
                ThirdpartyRisk = armshared.Operations.InformationSecurity.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.InformationSecurity.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.InformationSecurity.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.InformationSecurity.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.InformationSecurity.Miscommunication,
                RecruitmentRisk = armshared.Operations.InformationSecurity.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.InformationSecurity.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.InformationSecurity.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.InformationSecurity.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.InformationSecurity.UnauthorizedAccess,
                VendorManagement = armshared.Operations.InformationSecurity.VendorManagement,
                QualityManagament = armshared.Operations.InformationSecurity.QualityManagament,
                AssentMaintenance = armshared.Operations.InformationSecurity.AssentMaintenance,
                BCPandDRP = armshared.Operations.InformationSecurity.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.InformationSecurity.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.InformationSecurity.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.InformationSecurity.ObsoleteTechnology,
                Total = armshared.Operations.InformationSecurity.Total

            };
        }


    }
    public class OperationSharedServiceRatingCustomerexperience : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingCustomerexperience Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingCustomerexperience
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.CustomerExperience.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.CustomerExperience.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.CustomerExperience.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.CustomerExperience.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.CustomerExperience.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.CustomerExperience.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.CustomerExperience.TAT,
                ThirdpartyRisk = armshared.Operations.CustomerExperience.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.CustomerExperience.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.CustomerExperience.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.CustomerExperience.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.CustomerExperience.Miscommunication,
                RecruitmentRisk = armshared.Operations.CustomerExperience.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.CustomerExperience.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.CustomerExperience.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.CustomerExperience.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.CustomerExperience.UnauthorizedAccess,
                VendorManagement = armshared.Operations.CustomerExperience.VendorManagement,
                QualityManagament = armshared.Operations.CustomerExperience.QualityManagament,
                AssentMaintenance = armshared.Operations.CustomerExperience.AssentMaintenance,
                BCPandDRP = armshared.Operations.CustomerExperience.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.CustomerExperience.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.CustomerExperience.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.CustomerExperience.ObsoleteTechnology,
                Total = armshared.Operations.CustomerExperience.Total

            };
        }


    }
    public class OperationSharedServiceRatingCTO : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingCTO Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingCTO
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.CTO.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.CTO.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.CTO.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.CTO.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.CTO.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.CTO.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.CTO.TAT,
                ThirdpartyRisk = armshared.Operations.CTO.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.CTO.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.CTO.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.CTO.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.CTO.Miscommunication,
                RecruitmentRisk = armshared.Operations.CTO.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.CTO.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.CTO.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.CTO.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.CTO.UnauthorizedAccess,
                VendorManagement = armshared.Operations.CTO.VendorManagement,
                QualityManagament = armshared.Operations.CTO.QualityManagament,
                AssentMaintenance = armshared.Operations.CTO.AssentMaintenance,
                BCPandDRP = armshared.Operations.CTO.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.CTO.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.CTO.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.CTO.ObsoleteTechnology,
                Total = armshared.Operations.CTO.Total
            };
        }

    }
    public class OperationSharedServiceRatingMCC : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingMCC Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingMCC
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.MCC.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.MCC.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.MCC.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.MCC.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.MCC.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.MCC.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.MCC.TAT,
                ThirdpartyRisk = armshared.Operations.MCC.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.MCC.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.MCC.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.MCC.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.MCC.Miscommunication,
                RecruitmentRisk = armshared.Operations.MCC.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.MCC.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.MCC.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.MCC.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.MCC.UnauthorizedAccess,
                VendorManagement = armshared.Operations.MCC.VendorManagement,
                QualityManagament = armshared.Operations.MCC.QualityManagament,
                AssentMaintenance = armshared.Operations.MCC.AssentMaintenance,
                BCPandDRP = armshared.Operations.MCC.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.MCC.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.MCC.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.MCC.ObsoleteTechnology,
                Total = armshared.Operations.MCC.Total

            };
        }

    }
    public class OperationSharedServiceRatingLegal : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingLegal Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingLegal
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.Legal.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.Legal.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.Legal.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.Legal.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.Legal.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.Legal.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.Legal.TAT,
                ThirdpartyRisk = armshared.Operations.Legal.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.Legal.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.Legal.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.Legal.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.Legal.Miscommunication,
                RecruitmentRisk = armshared.Operations.Legal.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.Legal.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.Legal.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.Legal.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.Legal.UnauthorizedAccess,
                VendorManagement = armshared.Operations.Legal.VendorManagement,
                QualityManagament = armshared.Operations.Legal.QualityManagament,
                AssentMaintenance = armshared.Operations.Legal.AssentMaintenance,
                BCPandDRP = armshared.Operations.Legal.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.Legal.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.Legal.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.Legal.ObsoleteTechnology,
                Total = armshared.Operations.Legal.Total

            };
        }

    }
    public class OperationSharedServiceRatingRiskManagement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int BCPandDRP { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingRiskManagement Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingRiskManagement
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.RiskManagement.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.RiskManagement.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.RiskManagement.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.RiskManagement.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.RiskManagement.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.RiskManagement.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.RiskManagement.TAT,
                ThirdpartyRisk = armshared.Operations.RiskManagement.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.RiskManagement.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.RiskManagement.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.RiskManagement.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.RiskManagement.Miscommunication,
                RecruitmentRisk = armshared.Operations.RiskManagement.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.RiskManagement.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.RiskManagement.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.RiskManagement.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.RiskManagement.UnauthorizedAccess,
                VendorManagement = armshared.Operations.RiskManagement.VendorManagement,
                QualityManagament = armshared.Operations.RiskManagement.QualityManagament,
                AssentMaintenance = armshared.Operations.RiskManagement.AssentMaintenance,
                BCPandDRP = armshared.Operations.RiskManagement.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.RiskManagement.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.RiskManagement.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.RiskManagement.ObsoleteTechnology,
                Total = armshared.Operations.RiskManagement.Total
            };
        }

    }
    public class OperationSharedServiceRatingAcademy : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingAcademy Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingAcademy
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.Academy.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.Academy.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.Academy.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.Academy.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.Academy.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.Academy.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.Academy.TAT,
                ThirdpartyRisk = armshared.Operations.Academy.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.Academy.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.Academy.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.Academy.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.Academy.Miscommunication,
                RecruitmentRisk = armshared.Operations.Academy.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.Academy.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.Academy.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.Academy.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.Academy.UnauthorizedAccess,
                VendorManagement = armshared.Operations.Academy.VendorManagement,
                QualityManagament = armshared.Operations.Academy.QualityManagament,
                AssentMaintenance = armshared.Operations.Academy.AssentMaintenance,
                BCPandDRP = armshared.Operations.Academy.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.Academy.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.Academy.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.Academy.ObsoleteTechnology,
                Total = armshared.Operations.Academy.Total
            };
        }

    }
    public class OperationSharedServiceRatingIT : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingIT Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingIT
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.IT.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.IT.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.IT.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.IT.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.IT.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.IT.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.IT.TAT,
                ThirdpartyRisk = armshared.Operations.IT.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.IT.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.IT.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.IT.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.IT.Miscommunication,
                RecruitmentRisk = armshared.Operations.IT.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.IT.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.IT.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.IT.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.IT.UnauthorizedAccess,
                VendorManagement = armshared.Operations.IT.VendorManagement,
                QualityManagament = armshared.Operations.IT.QualityManagament,
                AssentMaintenance = armshared.Operations.IT.AssentMaintenance,
                BCPandDRP = armshared.Operations.IT.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.IT.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.IT.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.IT.ObsoleteTechnology,
                Total = armshared.Operations.IT.Total

            };
        }

    }
    public class OperationSharedServiceRatingProcurementAndAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingProcurementAndAdmin Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingProcurementAndAdmin
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.ProcurementAndAdmin.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.ProcurementAndAdmin.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.ProcurementAndAdmin.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.ProcurementAndAdmin.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.ProcurementAndAdmin.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.ProcurementAndAdmin.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.ProcurementAndAdmin.TAT,
                ThirdpartyRisk = armshared.Operations.ProcurementAndAdmin.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.ProcurementAndAdmin.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.ProcurementAndAdmin.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.ProcurementAndAdmin.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.ProcurementAndAdmin.Miscommunication,
                RecruitmentRisk = armshared.Operations.ProcurementAndAdmin.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.ProcurementAndAdmin.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.ProcurementAndAdmin.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.ProcurementAndAdmin.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.ProcurementAndAdmin.UnauthorizedAccess,
                VendorManagement = armshared.Operations.ProcurementAndAdmin.VendorManagement,
                QualityManagament = armshared.Operations.ProcurementAndAdmin.QualityManagament,
                AssentMaintenance = armshared.Operations.ProcurementAndAdmin.AssentMaintenance,
                BCPandDRP = armshared.Operations.ProcurementAndAdmin.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.ProcurementAndAdmin.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.ProcurementAndAdmin.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.ProcurementAndAdmin.ObsoleteTechnology,
                Total = armshared.Operations.ProcurementAndAdmin.Total

            };
        }

    }
    public class OperationSharedServiceRatingHCM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(OperationSharedService))]
        public Guid OperationSharedServiceId { get; set; }
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
        public static OperationSharedServiceRatingHCM Create(Guid operationSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new OperationSharedServiceRatingHCM
            {
                OperationSharedServiceId = operationSharedServiceId,
                AdoptionandImplementationofPolicies = armshared.Operations.HCM.AdoptionandImplementationofPolicies,
                StrategyMonitoringRisk = armshared.Operations.HCM.StrategyMonitoringRisk,
                BudgetOverruns = armshared.Operations.HCM.BudgetOverruns,
                OverorUnderpaymentofClient = armshared.Operations.HCM.OverorUnderpaymentofClient,
                TheftorFraudRisk = armshared.Operations.HCM.TheftorFraudRisk,
                TheftLeakageorMisuseofIntelleCTOalProperty = armshared.Operations.HCM.TheftLeakageorMisuseofIntelleCTOalProperty,
                TAT = armshared.Operations.HCM.TAT,
                ThirdpartyRisk = armshared.Operations.HCM.ThirdpartyRisk,
                ITInfrastruCTOreDowntime = armshared.Operations.HCM.ITInfrastruCTOreDowntime,
                ErroneousDataEntry = armshared.Operations.HCM.ErroneousDataEntry,
                MalwareorVirusorWebsiteAttacks = armshared.Operations.HCM.MalwareorVirusorWebsiteAttacks,
                Miscommunication = armshared.Operations.HCM.Miscommunication,
                RecruitmentRisk = armshared.Operations.HCM.RecruitmentRisk,
                RelevanceandRecencyofModelToolsandTechniques = armshared.Operations.HCM.RelevanceandRecencyofModelToolsandTechniques,
                ErrorDetectionRisk = armshared.Operations.HCM.ErrorDetectionRisk,
                PoorCustomerService = armshared.Operations.HCM.PoorCustomerService,
                UnauthorizedAccess = armshared.Operations.HCM.UnauthorizedAccess,
                VendorManagement = armshared.Operations.HCM.VendorManagement,
                QualityManagament = armshared.Operations.HCM.QualityManagament,
                AssentMaintenance = armshared.Operations.HCM.AssentMaintenance,
                BCPandDRP = armshared.Operations.HCM.BCPandDRP,
                ChangeNoticeManagement = armshared.Operations.HCM.ChangeNoticeManagement,
                DisclosureCorruptionOfSensitiveData = armshared.Operations.HCM.DisclosureCorruptionOfSensitiveData,
                ObsoleteTechnology = armshared.Operations.HCM.ObsoleteTechnology,
                Total = armshared.Operations.HCM.Total

            };
        }

    }

    public class ComplianceSharedService : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedServiceRating))]
        public Guid ARMSharedServiceRatingId { get; set; }
        [ForeignKey(nameof(ARMSharedServiceRatingId))]
        public ARMSharedServiceRating ARMSharedServiceRating { get; set; }
        public ComplianceSharedServiceRatingHCM HCM { get; set; }
        public ComplianceSharedServiceRatingProcurementAndAdmin ProcurementAndAdmin { get; set; }
        public ComplianceSharedServiceRatingIT IT { get; set; }
        public ComplianceSharedServiceRatingRiskManagement RiskManagement { get; set; }
        public ComplianceSharedServiceRatingAcademy Academy { get; set; }
        public ComplianceSharedServiceRatingLegal Legal { get; set; }
        public ComplianceSharedServiceRatingMCC MCC { get; set; }
        public ComplianceSharedServiceRatingCTO CTO { get; set; }
        public ComplianceSharedServiceRatingCustomerexperience Customerexperience { get; set; }
        public ComplianceSharedServiceRatingInformationSecurity InformationSecurity { get; set; }
        public ComplianceSharedServiceRatingInternalControl InternalControl { get; set; }
        public ComplianceSharedServiceRatingCorporatestrategy Corporatestrategy { get; set; }
        public ComplianceSharedServiceRatingTreasury Treasury { get; set; }
        public ComplianceSharedServiceDataAnalyticRating DataAnalytic { get; set; }
        public ComplianceSharedServiceFinancialControlRating FinancialControl { get; set; }
        public ComplianceSharedServiceComplianceRating Compliance { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ComplianceSharedService Create(Guid armSharedServiceRatingId, string comment)
        {
            return new ComplianceSharedService
            {
                ARMSharedServiceRatingId = armSharedServiceRatingId,
                Comment = comment
            };
        }


    }
    public class ComplianceSharedServiceComplianceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceComplianceRating Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceComplianceRating
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.Compliance.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.Compliance.GDPROrNDPR,
                AMLCFT = armshared.Compliance.Compliance.AMLCFT,
                ChangingRegulations = armshared.Compliance.Compliance.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.Compliance.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.Compliance.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.Compliance.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.Compliance.LitigationRisk,
                Total = armshared.Compliance.Compliance.Total
            };
        }

    }
    public class ComplianceSharedServiceFinancialControlRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceFinancialControlRating Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceFinancialControlRating
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.FinancialControl.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.FinancialControl.GDPROrNDPR,
                AMLCFT = armshared.Compliance.FinancialControl.AMLCFT,
                ChangingRegulations = armshared.Compliance.FinancialControl.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.FinancialControl.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.FinancialControl.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.FinancialControl.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.FinancialControl.LitigationRisk,
                Total = armshared.Compliance.FinancialControl.Total
            };
        }

    }
    public class ComplianceSharedServiceDataAnalyticRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceDataAnalyticRating Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceDataAnalyticRating
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.DataAnalytic.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.DataAnalytic.GDPROrNDPR,
                AMLCFT = armshared.Compliance.DataAnalytic.AMLCFT,
                ChangingRegulations = armshared.Compliance.DataAnalytic.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.DataAnalytic.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.DataAnalytic.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.DataAnalytic.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.DataAnalytic.LitigationRisk,
                Total = armshared.Compliance.DataAnalytic.Total
            };
        }

    }
    public class ComplianceSharedServiceRatingCustomerexperience : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingCustomerexperience Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingCustomerexperience
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.Customerexperience.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.Customerexperience.GDPROrNDPR,
                AMLCFT = armshared.Compliance.Customerexperience.AMLCFT,
                ChangingRegulations = armshared.Compliance.Customerexperience.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.Customerexperience.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.Customerexperience.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.Customerexperience.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.Customerexperience.LitigationRisk,
                Total = armshared.Compliance.Customerexperience.Total
            };
        }

    }
    public class ComplianceSharedServiceRatingCTO : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingCTO Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingCTO
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.CTO.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.CTO.GDPROrNDPR,
                AMLCFT = armshared.Compliance.CTO.AMLCFT,
                ChangingRegulations = armshared.Compliance.CTO.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.CTO.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.CTO.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.CTO.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.CTO.LitigationRisk,
                Total = armshared.Compliance.CTO.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingMCC : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingMCC Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingMCC
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.MCC.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.MCC.GDPROrNDPR,
                AMLCFT = armshared.Compliance.MCC.AMLCFT,
                ChangingRegulations = armshared.Compliance.MCC.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.MCC.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.MCC.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.MCC.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.MCC.LitigationRisk,
                Total = armshared.Compliance.MCC.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingLegal : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingLegal Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingLegal
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.Legal.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.Legal.GDPROrNDPR,
                AMLCFT = armshared.Compliance.Legal.AMLCFT,
                ChangingRegulations = armshared.Compliance.Legal.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.Legal.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.Legal.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.Legal.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.Legal.LitigationRisk,
                Total = armshared.Compliance.Legal.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingIT : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingIT Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingIT
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.IT.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.IT.GDPROrNDPR,
                AMLCFT = armshared.Compliance.IT.AMLCFT,
                ChangingRegulations = armshared.Compliance.IT.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.IT.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.IT.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.IT.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.IT.LitigationRisk,
                Total = armshared.Compliance.IT.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingHCM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingHCM Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingHCM
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.HCM.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.HCM.GDPROrNDPR,
                AMLCFT = armshared.Compliance.HCM.AMLCFT,
                ChangingRegulations = armshared.Compliance.HCM.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.HCM.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.HCM.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.HCM.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.HCM.LitigationRisk,
                Total = armshared.Compliance.HCM.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingRiskManagement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingRiskManagement Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingRiskManagement
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.RiskManagement.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.RiskManagement.GDPROrNDPR,
                AMLCFT = armshared.Compliance.RiskManagement.AMLCFT,
                ChangingRegulations = armshared.Compliance.RiskManagement.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.RiskManagement.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.RiskManagement.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.RiskManagement.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.RiskManagement.LitigationRisk,
                Total = armshared.Compliance.RiskManagement.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingAcademy : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingAcademy Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingAcademy
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.Academy.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.Academy.GDPROrNDPR,
                AMLCFT = armshared.Compliance.Academy.AMLCFT,
                ChangingRegulations = armshared.Compliance.Academy.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.Academy.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.Academy.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.Academy.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.Academy.LitigationRisk,
                Total = armshared.Compliance.Academy.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingProcurementAndAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingProcurementAndAdmin Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingProcurementAndAdmin
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.ProcurementAndAdmin.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.ProcurementAndAdmin.GDPROrNDPR,
                AMLCFT = armshared.Compliance.ProcurementAndAdmin.AMLCFT,
                ChangingRegulations = armshared.Compliance.ProcurementAndAdmin.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.ProcurementAndAdmin.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.ProcurementAndAdmin.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.ProcurementAndAdmin.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.ProcurementAndAdmin.LitigationRisk,
                Total = armshared.Compliance.ProcurementAndAdmin.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingCorporatestrategy : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingCorporatestrategy Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingCorporatestrategy
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.Corporatestrategy.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.Corporatestrategy.GDPROrNDPR,
                AMLCFT = armshared.Compliance.Corporatestrategy.AMLCFT,
                ChangingRegulations = armshared.Compliance.Corporatestrategy.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.Corporatestrategy.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.Corporatestrategy.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.Corporatestrategy.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.Corporatestrategy.LitigationRisk,
                Total = armshared.Compliance.Corporatestrategy.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingInternalControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingInternalControl Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingInternalControl
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.InternalControl.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.InternalControl.GDPROrNDPR,
                AMLCFT = armshared.Compliance.InternalControl.AMLCFT,
                ChangingRegulations = armshared.Compliance.InternalControl.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.InternalControl.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.InternalControl.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.InternalControl.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.InternalControl.LitigationRisk,
                Total = armshared.Compliance.InternalControl.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingInformationSecurity : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingInformationSecurity Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingInformationSecurity
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.InformationSecurity.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.InformationSecurity.GDPROrNDPR,
                AMLCFT = armshared.Compliance.InformationSecurity.AMLCFT,
                ChangingRegulations = armshared.Compliance.InformationSecurity.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.InformationSecurity.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.InformationSecurity.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.InformationSecurity.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.InformationSecurity.LitigationRisk,
                Total = armshared.Compliance.InformationSecurity.Total
            };
        }
    }
    public class ComplianceSharedServiceRatingTreasury : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ComplianceSharedService))]
        public Guid ComplianceSharedServiceId { get; set; }
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
        public static ComplianceSharedServiceRatingTreasury Create(Guid complianceSharedServiceId, ARMSharedServiceRatingReq armshared)
        {
            return new ComplianceSharedServiceRatingTreasury
            {
                ComplianceSharedServiceId = complianceSharedServiceId,
                DisclosureRisk = armshared.Compliance.Treasury.DisclosureRisk,
                GDPROrNDPR = armshared.Compliance.Treasury.GDPROrNDPR,
                AMLCFT = armshared.Compliance.Treasury.AMLCFT,
                ChangingRegulations = armshared.Compliance.Treasury.ChangingRegulations,
                InaccurateComputationofRegulatoryRemittancesDelayedFilings = armshared.Compliance.Treasury.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                KYCChecks = armshared.Compliance.Treasury.KYCChecks,
                NonComplianceWithContracts = armshared.Compliance.Treasury.NonComplianceWithContracts,
                LitigationRisk = armshared.Compliance.Treasury.LitigationRisk,
                Total = armshared.Compliance.Treasury.Total
            };
        }
    }
    public class TimeSinceLastSharedServiceAudit : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedServiceRating))]
        public Guid ARMSharedServiceRatingId { get; set; }
        public int HCM { get; set; }
        public int ProcurementAndAdmind { get; set; }
        public int IT { get; set; }
        public int RiskManagement { get; set; }
        public int Academy { get; set; }
        public int Legal { get; set; }
        public int MCC { get; set; }
        public int CTO { get; set; }
        public int Customerexperience { get; set; }
        public int InformationSecurity { get; set; }
        public int InternalControl { get; set; }
        public int Corporatestrategy { get; set; }
        public int Treasury { get; set; }
        public int Compliance { get; set; }
        public int DataAnalytic { get; set; }
        public int FinancialControl { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static TimeSinceLastSharedServiceAudit Create(Guid armSharedServiceRatingId, ARMSharedServiceRatingReq armshared)
        {
            return new TimeSinceLastSharedServiceAudit
            {
                ARMSharedServiceRatingId = armSharedServiceRatingId,
                RiskManagement = armshared.LastReportOverallRating.RiskManagement,
                HCM = armshared.LastReportOverallRating.HCM,
                ProcurementAndAdmind = armshared.LastReportOverallRating.ProcurementAndAdmind,
                FinancialControl = armshared.LastReportOverallRating.FinancialControl,
                DataAnalytic = armshared.LastReportOverallRating.DataAnalytic,
                Compliance = armshared.LastReportOverallRating.Compliance,
                Academy = armshared.LastReportOverallRating.Academy,
                InformationSecurity = armshared.LastReportOverallRating.InformationSecurity,
                Legal = armshared.LastReportOverallRating.Legal,
                IT = armshared.LastReportOverallRating.IT,
                Corporatestrategy = armshared.LastReportOverallRating.Corporatestrategy,
                Customerexperience = armshared.LastReportOverallRating.Customerexperience,
                CTO = armshared.LastReportOverallRating.CTO,
                MCC = armshared.LastReportOverallRating.MCC,
                InternalControl = armshared.LastReportOverallRating.InternalControl,
                Treasury = armshared.LastReportOverallRating.Treasury,
                Comment = armshared.LastReportOverallRating.Comment
            };
        }
    }

    #endregion
}
