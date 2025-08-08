using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 20/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint allow Internal Audit officer perform risk rating on the business entities
*/
    public class GetARMTrusteeBusinessRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get ARMTrustee business risk rating by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="trustee"></param>
        /// <param name="strategy"></param>
        /// <param name="straCommercialTru"></param>
        /// <param name="straPrivate"></param>
        /// <param name="operation"></param>
        /// <param name="operCommercialtrus"></param>
        /// <param name="operationPrivateTru"></param>
        /// <param name="finance"></param>
        /// <param name="financePrivate"></param>
        /// <param name="financecommercialTru"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceComercial"></param>
        /// <param name="compliancePrivate"></param>
        /// <param name="timeSinceLastTrusteeAudit"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMTrusteeRating> trustee, IRepository<StrategyBusinessRatingTrustee> strategy,
            IRepository<StrategyTrusteeRatingCommercialTrust> straCommercialTru, IRepository<StrategyTrusteeRatingPrivateTrust> straPrivate,

            IRepository<OperationTrustee> operation, IRepository<OperationTrusteeRatingCommercialTrust> operCommercialtrus,
            IRepository<OperationTrusteeRatingPrivateTrust> operationPrivateTru,

            IRepository<FinancialTrusteeReporting> finance,
            IRepository<FinacialTrusteeRatingPrivateTrust> financePrivate, IRepository<FinacialTrusteeRatingCommercialTrust> financecommercialTru,

            IRepository<ComplianceBusinessRatingTrustee> compliance, IRepository<ComplianceTrusteeRatingCommercialTrust> complianceComercial,
            IRepository<ComplianceTrusteeRatingPrivateTrust> compliancePrivate, IRepository<TimeSinceLastTrusteeAudit> timeSinceLastTrusteeAudit, ICurrentUserService currentUserService,
           ClaimsPrincipal user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                //string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                //if (requesterUnit != "Internal Audit")
                //{ return TypedResults.Forbid(); }
                var getRating = busnessRiskRating.GetContextByConditon(x => x.Id == id).FirstOrDefault();
                if (getRating != null)
                {
                    var gettrustee = trustee.GetContextByConditon(x => x.BusinessRiskRatingId == id).FirstOrDefault();

                    var getstrategy = strategy.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    var getstraCommercialTru = straCommercialTru.GetContextByConditon(x => x.StrategyBusinessRatingTrusteeId == getstrategy.Id).FirstOrDefault();
                    var getstraPrivate = straPrivate.GetContextByConditon(x => x.StrategyBusinessRatingTrusteeId == getstrategy.Id).FirstOrDefault();


                    var getoperation = operation.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    var getoperCommercialtrus = operCommercialtrus.GetContextByConditon(x => x.OperationTrusteeId == getoperation.Id).FirstOrDefault();
                    var getoperationPrivateTru = operationPrivateTru.GetContextByConditon(x => x.OperationTrusteeId == getoperation.Id).FirstOrDefault();

                    var getfinance = finance.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    var getfinancePrivate = financePrivate.GetContextByConditon(x => x.FinancialTrusteeReportingId == getfinance.Id).FirstOrDefault();
                    var getfinancecommercialTru = financecommercialTru.GetContextByConditon(x => x.FinancialTrusteeReportingId == getfinance.Id).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    var getcomplianceComercial = complianceComercial.GetContextByConditon(x => x.ComplianceBusinessRatingTrusteeId == getcompliance.Id).FirstOrDefault();
                    var getcompliancePrivate = compliancePrivate.GetContextByConditon(x => x.ComplianceBusinessRatingTrusteeId == getcompliance.Id).FirstOrDefault();

                    var gettimeSinceLastTrusteeAudit = timeSinceLastTrusteeAudit.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    ARMTrusteeRequest resp = new ARMTrusteeRequest
                    {
                        ARMTrustee = new ARMTrusteeRatingReq
                        {
                            Status = gettrustee.Status,
                            Strategy = new StrategyTrusteeReq
                            {
                                CommercialTrust = new StrategyTrusteeRatingReq
                                {
                                    flunctuatingInterestRates = getstraCommercialTru.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstraCommercialTru.CurrencyDevaluation,

                                    Increasedleverage = getstraCommercialTru.Increasedleverage,

                                    LiquidityPressures = getstraCommercialTru.LiquidityPressures,

                                    ReputationalRisk = getstraCommercialTru.ReputationalRisk,

                                    PeopleRetentionRisk = getstraCommercialTru.PeopleRetentionRisk,

                                    TechnologicalRisk = getstraCommercialTru.TechnologicalRisk,

                                    InformationSecurityRisk = getstraCommercialTru.InformationSecurityRisk,

                                    CreditRisk = getstraCommercialTru.CreditRisk,

                                    AllianceandPartnershipRisks = getstraCommercialTru.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstraCommercialTru.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstraCommercialTru.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstraCommercialTru.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstraCommercialTru.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstraCommercialTru.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstraCommercialTru.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstraCommercialTru.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstraCommercialTru.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstraCommercialTru.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstraCommercialTru.PoliticalRisk,

                                    ProjectManagementRisk = getstraCommercialTru.ProjectManagementRisk,

                                    InvestmentRisk = getstraCommercialTru.InvestmentRisk,

                                    FailureofInvestor = getstraCommercialTru.FailureofInvestor,

                                    ExitRisk = getstraCommercialTru.ExitRisk,

                                    SocialRisk = getstraCommercialTru.SocialRisk,

                                    EnvironmentalRisk = getstraCommercialTru.EnvironmentalRisk,

                                    SustainabilityRisk = getstraCommercialTru.SustainabilityRisk,

                                    BCPandDRP = getstraCommercialTru.BCPandDRP,

                                    MyLegacyIssuesProperty = getstraCommercialTru.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstraCommercialTru.HealthandSafetyRisks,

                                    EmergingRisks = getstraCommercialTru.EnvironmentalRisk,

                                    ProductivityRisk = getstraCommercialTru.ProductivityRisk,

                                    Total = getstraCommercialTru.Total
                                },
                                PrivateTrust = new StrategyTrusteeRatingReq
                                {
                                    flunctuatingInterestRates = getstraPrivate.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstraPrivate.CurrencyDevaluation,

                                    Increasedleverage = getstraPrivate.Increasedleverage,

                                    LiquidityPressures = getstraPrivate.LiquidityPressures,

                                    ReputationalRisk = getstraPrivate.ReputationalRisk,

                                    PeopleRetentionRisk = getstraPrivate.PeopleRetentionRisk,

                                    TechnologicalRisk = getstraPrivate.TechnologicalRisk,

                                    InformationSecurityRisk = getstraPrivate.InformationSecurityRisk,

                                    CreditRisk = getstraPrivate.CreditRisk,

                                    AllianceandPartnershipRisks = getstraPrivate.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstraPrivate.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstraPrivate.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstraPrivate.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstraPrivate.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstraPrivate.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstraPrivate.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstraPrivate.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstraPrivate.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstraPrivate.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstraPrivate.PoliticalRisk,

                                    ProjectManagementRisk = getstraPrivate.ProjectManagementRisk,

                                    InvestmentRisk = getstraPrivate.InvestmentRisk,

                                    FailureofInvestor = getstraPrivate.FailureofInvestor,

                                    ExitRisk = getstraPrivate.ExitRisk,

                                    SocialRisk = getstraPrivate.SocialRisk,

                                    EnvironmentalRisk = getstraPrivate.EnvironmentalRisk,

                                    SustainabilityRisk = getstraPrivate.SustainabilityRisk,

                                    BCPandDRP = getstraPrivate.BCPandDRP,

                                    MyLegacyIssuesProperty = getstraPrivate.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstraPrivate.HealthandSafetyRisks,

                                    EmergingRisks = getstraPrivate.EnvironmentalRisk,

                                    ProductivityRisk = getstraPrivate.ProductivityRisk,

                                    Total = getstraPrivate.Total

                                },
                                Comment = getstrategy.Comment
                            },
                            Operations = new OperationTrusteeReq
                            {
                                CommercialTrust = new OperationTrusteeRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperCommercialtrus.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperCommercialtrus.TheftorFraudRisk,
                                    PoorCustomerService = getoperCommercialtrus.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getoperCommercialtrus.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getoperCommercialtrus.ThirdpartyRisk,

                                    TAT = getoperCommercialtrus.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperCommercialtrus.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperCommercialtrus.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperCommercialtrus.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getoperCommercialtrus.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperCommercialtrus.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperCommercialtrus.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperCommercialtrus.ErroneousDataEntry,

                                    Miscommunication = getoperCommercialtrus.Miscommunication,

                                    ErrorDetectionRisk = getoperCommercialtrus.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperCommercialtrus.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperCommercialtrus.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperCommercialtrus.ProductivityRisk,
                                    BudgetOverruns = getoperCommercialtrus.BudgetOverruns,
                                    Total = getoperCommercialtrus.Total
                                },
                                PrivateTrust = new OperationTrusteeRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationPrivateTru.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationPrivateTru.TheftorFraudRisk,
                                    PoorCustomerService = getoperationPrivateTru.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getoperationPrivateTru.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getoperationPrivateTru.ThirdpartyRisk,

                                    TAT = getoperationPrivateTru.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationPrivateTru.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperationPrivateTru.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperationPrivateTru.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getoperationPrivateTru.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperationPrivateTru.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperationPrivateTru.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperationPrivateTru.ErroneousDataEntry,

                                    Miscommunication = getoperationPrivateTru.Miscommunication,

                                    ErrorDetectionRisk = getoperationPrivateTru.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperationPrivateTru.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationPrivateTru.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationPrivateTru.ProductivityRisk,
                                    BudgetOverruns = getoperationPrivateTru.BudgetOverruns,
                                    Total = getoperationPrivateTru.Total
                                },
                                Comment = getoperation.Comment
                            },
                            FinancialReporting = new FinancialTrusteeReportingReq
                            {
                                CommercialTrust = new FinacialTrusteeRatingReq
                                {
                                    IncomeAssuranceRisk = getfinancecommercialTru.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinancecommercialTru.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinancecommercialTru.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinancecommercialTru.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinancecommercialTru.TAT,

                                    ErrororControlRisk = getfinancecommercialTru.ErrororControlRisk,

                                    TheftorFraudRisk = getfinancecommercialTru.TheftorFraudRisk,

                                    Total = getfinancecommercialTru.Total
                                },
                                PrivateTrust = new FinacialTrusteeRatingReq
                                {
                                    IncomeAssuranceRisk = getfinancePrivate.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinancePrivate.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinancePrivate.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinancePrivate.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinancePrivate.TAT,

                                    ErrororControlRisk = getfinancePrivate.ErrororControlRisk,

                                    TheftorFraudRisk = getfinancePrivate.TheftorFraudRisk,

                                    Total = getfinancePrivate.Total
                                },
                                Comment = getfinance.Comment
                            },
                            Compliance = new ComplianceTrusteeReq
                            {
                                CommercialTrust = new ComplianceTrusteeRatingReq
                                {
                                    AMLCFT = getcomplianceComercial.AMLCFT,
                                    LitigationRisk = getcomplianceComercial.LitigationRisk,
                                    ChangingRegulations = getcomplianceComercial.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceComercial.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceComercial.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceComercial.KYCChecks,
                                    GDPROrNDPR = getcomplianceComercial.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceComercial.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    CorporateGovernance = getcomplianceComercial.CorporateGovernance,
                                    DisclosureRisk = getcomplianceComercial.DisclosureRisk,
                                    TAT = getcomplianceComercial.TAT,
                                    Total = getcomplianceComercial.Total
                                },
                                PrivateTrust = new ComplianceTrusteeRatingReq
                                {
                                    AMLCFT = getcompliancePrivate.AMLCFT,
                                    LitigationRisk = getcompliancePrivate.LitigationRisk,
                                    ChangingRegulations = getcompliancePrivate.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcompliancePrivate.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcompliancePrivate.NonComplianceWithContracts,
                                    KYCChecks = getcompliancePrivate.KYCChecks,
                                    GDPROrNDPR = getcompliancePrivate.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcompliancePrivate.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcompliancePrivate.DisclosureRisk,
                                    CorporateGovernance = getcompliancePrivate.CorporateGovernance,
                                    TAT = getcompliancePrivate.TAT,
                                    Total = getcompliancePrivate.Total
                                },
                                Comment = getcompliance.Comment
                            },
                            LastReportOverallRating = new TimeSinceLastTrusteeAuditReq
                            {
                                CommercialTrust = gettimeSinceLastTrusteeAudit.CommercialTrust,
                                PrivateTrust = gettimeSinceLastTrusteeAudit.PrivateTrust,
                                Comment = gettimeSinceLastTrusteeAudit.Comment
                            }
                        }


                    };
                    return TypedResults.Ok(resp);

                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
