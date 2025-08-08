using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
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
    public class GetARMHoldingCompanyBusinessRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get ARMHoldCo Business Risk Rating by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armHoldcorating"></param>
        /// <param name="strategylog"></param>
        /// <param name="strategyrating"></param>
        /// <param name="strategytreasurysale"></param>
        /// <param name="operationlog"></param>
        /// <param name="operationrating"></param>
        /// <param name="operationtreasurysale"></param>
        /// <param name="financelog"></param>
        /// <param name="financerating"></param>
        /// <param name="financeTreasurysale"></param>
        /// <param name="complianceRating"></param>
        /// <param name="compliancelog"></param>
        /// <param name="complianceTreasurysale"></param>
        /// <param name="timesinceaudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMHoldingCompanyBusinessRating> armHoldcorating, IRepository<StrategyBusinessRatingARMHoldCo> strategylog, IRepository<StrategyBusinessArmHoldCo> strategyrating,
            IRepository<StrategyBusinessTreasurySale> strategytreasurysale, IRepository<OperationBusinessRatingARMHoldCo> operationlog, IRepository<OperationBusinessArmHolco> operationrating,
            IRepository<OperationBusinessTreasurySale> operationtreasurysale, IRepository<FinancialReportingBusinessratingARMHoldCo> financelog,
            IRepository<FinacialRatingBusinessratingARMHoldCo> financerating, IRepository<FinacialRatingBusinessratingTreasurySale> financeTreasurysale,
            IRepository<ComplianceBusinessRatingARMHoldCo> complianceRating, IRepository<CompliancesBusinessRiskRatingARMHoldCo> compliancelog,
            IRepository<CompliancesBusinessTreasurySale> complianceTreasurysale, IRepository<TimeSinceLastAuditBusinessRatingARMHoldCo> timesinceaudit,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                    var getarmholdcoRating = armHoldcorating.GetContextByConditon(x => x.BusinessRiskRatingId == id).FirstOrDefault();

                    var getstrategylog = strategylog.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == getarmholdcoRating.Id).FirstOrDefault();

                    var getstrategyrating = strategyrating.GetContextByConditon(x => x.StrategyBusinessRatingARMHoldCoId == getstrategylog.Id).FirstOrDefault();
                    var getstrategytreasurysale = strategytreasurysale.GetContextByConditon(x => x.StrategyBusinessRatingARMHoldCoId == getstrategylog.Id).FirstOrDefault();

                    var getoperationlog = operationlog.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == getarmholdcoRating.Id).FirstOrDefault();

                    var getoperationrating = operationrating.GetContextByConditon(x => x.OperationBusinessRatingARMHoldCoId == getoperationlog.Id).FirstOrDefault();
                    var getoperationtreasurysale = operationtreasurysale.GetContextByConditon(x => x.OperationBusinessRatingARMHoldCoId == getoperationlog.Id).FirstOrDefault();

                    var getfinancelog = financelog.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == getarmholdcoRating.Id).FirstOrDefault();

                    var getfinancerating = financerating.GetContextByConditon(x => x.FinancialReportingBusinessratingARMHoldCoId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceTreasurysale = financeTreasurysale.GetContextByConditon(x => x.FinancialReportingBusinessratingARMHoldCoId == getfinancelog.Id).FirstOrDefault();

                    var getcomplianceRating = complianceRating.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == getarmholdcoRating.Id).FirstOrDefault();

                    var getcompliancelog = compliancelog.GetContextByConditon(x => x.ComplianceBusinessRatingARMHoldCoId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceTreasurysale = complianceTreasurysale.GetContextByConditon(x => x.ComplianceBusinessRatingARMHoldCoId == getcomplianceRating.Id).FirstOrDefault();

                    var gettimesinceaudit = timesinceaudit.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == getarmholdcoRating.Id).FirstOrDefault();


                    ARMHoldingCompanyRequest resp = new ARMHoldingCompanyRequest
                    {
                        ARMHoldingCompany = new ARMHoldingCompanyRatingReq
                        {
                            Status = getarmholdcoRating.Status,
                            Strategy = new StrategyReq
                            {
                                ARMHoldingCompany = new StrategyRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyrating.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyrating.CurrencyDevaluation,

                                    Increasedleverage = getstrategyrating.Increasedleverage,

                                    LiquidityPressures = getstrategyrating.LiquidityPressures,

                                    ReputationalRisk = getstrategyrating.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyrating.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyrating.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyrating.InformationSecurityRisk,

                                    CreditRisk = getstrategyrating.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyrating.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyrating.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyrating.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyrating.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyrating.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyrating.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyrating.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyrating.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyrating.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyrating.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyrating.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyrating.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyrating.InvestmentRisk,

                                    FailureofInvestor = getstrategyrating.FailureofInvestor,

                                    ExitRisk = getstrategyrating.ExitRisk,

                                    SocialRisk = getstrategyrating.SocialRisk,

                                    EnvironmentalRisk = getstrategyrating.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyrating.SustainabilityRisk,

                                    BCPandDRP = getstrategyrating.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyrating.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyrating.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyrating.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyrating.ProductivityRisk,

                                    Total = getstrategyrating.Total
                                },
                                TreasurySale = new StrategyRatingReq
                                {
                                    flunctuatingInterestRates = getstrategytreasurysale.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategytreasurysale.CurrencyDevaluation,

                                    Increasedleverage = getstrategytreasurysale.Increasedleverage,

                                    LiquidityPressures = getstrategytreasurysale.LiquidityPressures,

                                    ReputationalRisk = getstrategytreasurysale.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategytreasurysale.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategytreasurysale.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategytreasurysale.InformationSecurityRisk,

                                    CreditRisk = getstrategytreasurysale.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategytreasurysale.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategytreasurysale.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategytreasurysale.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategytreasurysale.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategytreasurysale.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategytreasurysale.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategytreasurysale.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategytreasurysale.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategytreasurysale.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategytreasurysale.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategytreasurysale.PoliticalRisk,

                                    ProjectManagementRisk = getstrategytreasurysale.ProjectManagementRisk,

                                    InvestmentRisk = getstrategytreasurysale.InvestmentRisk,

                                    FailureofInvestor = getstrategytreasurysale.FailureofInvestor,

                                    ExitRisk = getstrategytreasurysale.ExitRisk,

                                    SocialRisk = getstrategytreasurysale.SocialRisk,

                                    EnvironmentalRisk = getstrategytreasurysale.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategytreasurysale.SustainabilityRisk,

                                    BCPandDRP = getstrategytreasurysale.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategytreasurysale.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategytreasurysale.HealthandSafetyRisks,

                                    EmergingRisks = getstrategytreasurysale.EnvironmentalRisk,

                                    ProductivityRisk = getstrategytreasurysale.ProductivityRisk,

                                    Total = getstrategytreasurysale.Total
                                },
                                Comment = getstrategylog.Comment
                            },
                            Operations = new OperationReq
                            {
                                ARMHoldingCompany = new OperationRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationrating.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationrating.TheftorFraudRisk,
                                    PoorCustomerService = getoperationrating.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationrating.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationrating.ThirdpartyRisk,
                                    TAT = getoperationrating.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationrating.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationrating.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationrating.RecruitmentRisk,
                                    ConfidentialityIntegrityandAvailabilityofData = getoperationrating.ConfidentialityIntegrityandAvailabilityofData,
                                    UnauthorizedAccess = getoperationrating.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationrating.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationrating.ErroneousDataEntry,
                                    Miscommunication = getoperationrating.Miscommunication,
                                    ErrorDetectionRisk = getoperationrating.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationrating.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationrating.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationrating.ProductivityRisk,
                                    BudgetOverruns = getoperationrating.BudgetOverruns,
                                    Total = getoperationrating.Total
                                },
                                TreasurySale = new OperationRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationtreasurysale.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationtreasurysale.TheftorFraudRisk,
                                    PoorCustomerService = getoperationtreasurysale.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationtreasurysale.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationtreasurysale.ThirdpartyRisk,
                                    TAT = getoperationtreasurysale.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationtreasurysale.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationtreasurysale.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationtreasurysale.RecruitmentRisk,
                                    ConfidentialityIntegrityandAvailabilityofData = getoperationtreasurysale.ConfidentialityIntegrityandAvailabilityofData,
                                    UnauthorizedAccess = getoperationtreasurysale.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationtreasurysale.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationtreasurysale.ErroneousDataEntry,
                                    Miscommunication = getoperationtreasurysale.Miscommunication,
                                    ErrorDetectionRisk = getoperationtreasurysale.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationtreasurysale.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationtreasurysale.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationtreasurysale.ProductivityRisk,
                                    BudgetOverruns = getoperationtreasurysale.BudgetOverruns,
                                    Total = getoperationtreasurysale.Total
                                },
                                Comment = getoperationlog.Comment
                            },
                            FinancialReporting = new FinancialReportingReq
                            {
                                ARMHoldingCompany = new FinacialRatingReq
                                {
                                    IncomeAssuranceRisk = getfinancerating.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinancerating.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinancerating.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinancerating.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinancerating.TAT,

                                    ErrororControlRisk = getfinancerating.ErrororControlRisk,

                                    TheftorFraudRisk = getfinancerating.TheftorFraudRisk,

                                    Total = getfinancerating.Total
                                },
                                TreasurySale = new FinacialRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceTreasurysale.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceTreasurysale.IncomeAssuranceRisk,

                                    AdherencetoFinancialStandards = getfinanceTreasurysale.IncomeAssuranceRisk,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceTreasurysale.IncomeAssuranceRisk,

                                    TAT = getfinanceTreasurysale.IncomeAssuranceRisk,

                                    ErrororControlRisk = getfinanceTreasurysale.IncomeAssuranceRisk,

                                    TheftorFraudRisk = getfinanceTreasurysale.IncomeAssuranceRisk,

                                    Total = getfinanceTreasurysale.IncomeAssuranceRisk
                                },
                                Comment = getfinancelog.Comment
                            },
                            Compliance = new CompliancesReq
                            {
                                ARMHoldingCompany = new ComplianceRatingReq
                                {
                                    AMLCFT = getcompliancelog.AMLCFT,
                                    LitigationRisk = getcompliancelog.LitigationRisk,
                                    ChangingRegulations = getcompliancelog.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcompliancelog.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcompliancelog.NonComplianceWithContracts,
                                    KYCChecks = getcompliancelog.KYCChecks,
                                    GDPROrNDPR = getcompliancelog.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcompliancelog.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcompliancelog.DisclosureRisk,
                                    CorporateGovernance = getcompliancelog.CorporateGovernance,
                                    TAT = getcompliancelog.TAT,
                                    Total = getcompliancelog.Total
                                },
                                TreasurySale = new ComplianceRatingReq
                                {
                                    AMLCFT = getcomplianceTreasurysale.AMLCFT,
                                    LitigationRisk = getcomplianceTreasurysale.LitigationRisk,
                                    ChangingRegulations = getcomplianceTreasurysale.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceTreasurysale.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceTreasurysale.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceTreasurysale.KYCChecks,
                                    GDPROrNDPR = getcomplianceTreasurysale.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceTreasurysale.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceTreasurysale.DisclosureRisk,
                                    CorporateGovernance = getcomplianceTreasurysale.CorporateGovernance,
                                    TAT = getcomplianceTreasurysale.TAT,
                                    Total = getcomplianceTreasurysale.Total
                                },
                                Comment = getcomplianceRating.Comment
                            },
                            LastReportOverallRating = new TimeSinceLastAuditReq
                            {
                                ARMHoldingCompany = gettimesinceaudit.ARMHoldingCompany,
                                TreasurySale = gettimesinceaudit.TreasurySale,
                                Comment = gettimesinceaudit.Comment
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
