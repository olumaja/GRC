using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 10/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint allow Internal Audit officer to get agribusiness risk rating by Id
*/
    public class GetARMAgribusinessRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get agribusiness risk rating by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="agri"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyAAFML"></param>
        /// <param name="strategyRFL"></param>
        /// <param name="operation"></param>
        /// <param name="operationAAFML"></param>
        /// <param name="operRFL"></param>
        /// <param name="finance"></param>
        /// <param name="financeAAFML"></param>
        /// <param name="financeRFL"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceAAFML"></param>
        /// <param name="complianceRFL"></param>
        /// <param name="timeSinceLastAgriAudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMAgribusinessRating> agri, IRepository<StrategyAgribusiness> strategy,
            IRepository<StrategyAgribusinessRatingAAFML> strategyAAFML, IRepository<StrategyAgribusinessRatingRFl> strategyRFL,

            IRepository<OperationAgribusiness> operation,
            IRepository<OperationAgribusinessRatingAAFML> operationAAFML, IRepository<OperationAgribusinessRatingRFl> operRFL,

            IRepository<FinancialAgribusinessReporting> finance, IRepository<FinacialAgribusinessRatingAAFML> financeAAFML,
            IRepository<FinacialAgribusinessRatingRFl> financeRFL,

            IRepository<ComplianceAgribusiness> compliance, IRepository<ComplianceAgribusinessRatingAAFML> complianceAAFML,
            IRepository<ComplianceAgribusinessRatingRFl> complianceRFL, IRepository<TimeSinceLastAgribusinessAudit> timeSinceLastAgriAudit,
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
                    var getagri = agri.GetContextByConditon(x => x.BusinessRiskRatingId == id).FirstOrDefault();

                    var getstrategy = strategy.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                    var getstrategyAAFML = strategyAAFML.GetContextByConditon(x => x.StrategyAgribusinessId == getstrategy.Id).FirstOrDefault();
                    var getstrategyRFL = strategyRFL.GetContextByConditon(x => x.StrategyAgribusinessId == getstrategy.Id).FirstOrDefault();

                    var getoperation = operation.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                    var getoperationAAFML = operationAAFML.GetContextByConditon(x => x.OperationAgribusinessId == getoperation.Id).FirstOrDefault();
                    var getoperRFL = operRFL.GetContextByConditon(x => x.OperationAgribusinessId == getoperation.Id).FirstOrDefault();

                    var getfinance = finance.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                    var getfinanceAAFML = financeAAFML.GetContextByConditon(x => x.FinancialAgribusinessReportingId == getfinance.Id).FirstOrDefault();
                    var getfinanceRFL = financeRFL.GetContextByConditon(x => x.FinancialAgribusinessReportingId == getfinance.Id).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                    var getcomplianceAAFML = complianceAAFML.GetContextByConditon(x => x.ComplianceAgribusinessId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceRFL = complianceRFL.GetContextByConditon(x => x.ComplianceAgribusinessId == getcompliance.Id).FirstOrDefault();

                    var gettimeSinceLastAgriAudit = timeSinceLastAgriAudit.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();


                    ARMAgribusinessRequest resp = new ARMAgribusinessRequest
                    {
                        ARMAgribusiness = new ARMAgribusinessRatingReq
                        {
                            Status = getagri.Status,
                            Strategy = new StrategyAgribusinessReq
                            {
                                AAFML = new StrategyAgribusinessRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyAAFML.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyAAFML.CurrencyDevaluation,

                                    Increasedleverage = getstrategyAAFML.Increasedleverage,

                                    LiquidityPressures = getstrategyAAFML.LiquidityPressures,

                                    ReputationalRisk = getstrategyAAFML.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyAAFML.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyAAFML.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyAAFML.InformationSecurityRisk,

                                    CreditRisk = getstrategyAAFML.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyAAFML.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyAAFML.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyAAFML.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyAAFML.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyAAFML.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyAAFML.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyAAFML.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyAAFML.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyAAFML.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyAAFML.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyAAFML.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyAAFML.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyAAFML.InvestmentRisk,

                                    FailureofInvestor = getstrategyAAFML.FailureofInvestor,

                                    ExitRisk = getstrategyAAFML.ExitRisk,

                                    SocialRisk = getstrategyAAFML.SocialRisk,

                                    EnvironmentalRisk = getstrategyAAFML.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyAAFML.SustainabilityRisk,

                                    BCPandDRP = getstrategyAAFML.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyAAFML.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyAAFML.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyAAFML.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyAAFML.ProductivityRisk,

                                    Total = getstrategyAAFML.Total
                                },
                                RFl = new StrategyAgribusinessRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyRFL.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyRFL.CurrencyDevaluation,

                                    Increasedleverage = getstrategyRFL.Increasedleverage,

                                    LiquidityPressures = getstrategyRFL.LiquidityPressures,

                                    ReputationalRisk = getstrategyRFL.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyRFL.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyRFL.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyRFL.InformationSecurityRisk,

                                    CreditRisk = getstrategyRFL.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyRFL.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyRFL.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyRFL.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyRFL.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyRFL.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyRFL.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyRFL.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyRFL.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyRFL.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyRFL.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyRFL.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyRFL.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyRFL.InvestmentRisk,

                                    FailureofInvestor = getstrategyRFL.FailureofInvestor,

                                    ExitRisk = getstrategyRFL.ExitRisk,

                                    SocialRisk = getstrategyRFL.SocialRisk,

                                    EnvironmentalRisk = getstrategyRFL.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyRFL.SustainabilityRisk,

                                    BCPandDRP = getstrategyRFL.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyRFL.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyRFL.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyRFL.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyRFL.ProductivityRisk,

                                    Total = getstrategyRFL.Total
                                },
                                Comment = getstrategy.Comment
                            },
                            Operations = new OperationAgribusinessReq
                            {
                                AAFML = new OperationAgribusinessRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationAAFML.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationAAFML.TheftorFraudRisk,
                                    PoorCustomerService = getoperationAAFML.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getoperationAAFML.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getoperationAAFML.ThirdpartyRisk,

                                    TAT = getoperationAAFML.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationAAFML.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperationAAFML.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperationAAFML.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getoperationAAFML.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperationAAFML.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperationAAFML.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperationAAFML.ErroneousDataEntry,

                                    Miscommunication = getoperationAAFML.Miscommunication,

                                    ErrorDetectionRisk = getoperationAAFML.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperationAAFML.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationAAFML.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationAAFML.ProductivityRisk,
                                    BudgetOverruns = getoperationAAFML.BudgetOverruns,
                                    Total = getoperationAAFML.Total
                                },
                                RFl = new OperationAgribusinessRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperRFL.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperRFL.TheftorFraudRisk,
                                    PoorCustomerService = getoperRFL.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getoperRFL.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getoperRFL.ThirdpartyRisk,

                                    TAT = getoperRFL.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperRFL.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperRFL.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperRFL.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getoperRFL.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperRFL.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperRFL.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperRFL.ErroneousDataEntry,

                                    Miscommunication = getoperRFL.Miscommunication,

                                    ErrorDetectionRisk = getoperRFL.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperRFL.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperRFL.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperRFL.ProductivityRisk,
                                    BudgetOverruns = getoperRFL.BudgetOverruns,
                                    Total = getoperRFL.Total
                                },
                                Comment = getoperation.Comment
                            },
                            FinancialReporting = new FinancialAgribusinessReportingReq
                            {
                                AAFML = new FinacialAgribusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceAAFML.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceAAFML.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceAAFML.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceAAFML.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceAAFML.TAT,

                                    ErrororControlRisk = getfinanceAAFML.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceAAFML.TheftorFraudRisk,

                                    Total = getfinanceAAFML.Total
                                },
                                RFl = new FinacialAgribusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceRFL.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceRFL.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceRFL.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceRFL.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceRFL.TAT,

                                    ErrororControlRisk = getfinanceRFL.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceRFL.TheftorFraudRisk,

                                    Total = getfinanceRFL.Total
                                },
                                Comment = getfinance.Comment
                            },
                            Compliance = new ComplianceAgribusinessReq
                            {
                                AAFML = new ComplianceAgribusinessRatingReq
                                {
                                    AMLCFT = getcomplianceAAFML.AMLCFT,
                                    LitigationRisk = getcomplianceAAFML.LitigationRisk,
                                    ChangingRegulations = getcomplianceAAFML.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceAAFML.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceAAFML.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceAAFML.KYCChecks,
                                    GDPROrNDPR = getcomplianceAAFML.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceAAFML.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceAAFML.DisclosureRisk,
                                    CorporateGovernance = getcomplianceAAFML.CorporateGovernance,
                                    TAT = getcomplianceAAFML.TAT,
                                    Total = getcomplianceAAFML.Total
                                },
                                RFl = new ComplianceAgribusinessRatingReq
                                {
                                    AMLCFT = getcomplianceRFL.AMLCFT,
                                    LitigationRisk = getcomplianceRFL.LitigationRisk,
                                    ChangingRegulations = getcomplianceRFL.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceRFL.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceRFL.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceRFL.KYCChecks,
                                    GDPROrNDPR = getcomplianceRFL.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceRFL.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceRFL.DisclosureRisk,
                                    CorporateGovernance = getcomplianceRFL.CorporateGovernance,
                                    TAT = getcomplianceRFL.TAT,
                                    Total = getcomplianceRFL.Total
                                },
                                Comment = getcompliance.Comment
                            },
                            LastReportOverallRating = new TimeSinceLastAgribusinessAuditReq
                            {
                                AAFML = gettimeSinceLastAgriAudit.AAFML,
                                RFl = gettimeSinceLastAgriAudit.RFl,
                                Comment = gettimeSinceLastAgriAudit.Comment
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
