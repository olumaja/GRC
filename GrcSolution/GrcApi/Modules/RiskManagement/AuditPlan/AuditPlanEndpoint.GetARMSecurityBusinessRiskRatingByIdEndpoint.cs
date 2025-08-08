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
    public class GetARMSecurityBusinessRiskRatingByIdEndpoint
    {
        /// <summary>
        ///  Get ARMSecurity business riisk rating
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="security"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyStockBro"></param>
        /// <param name="operation"></param>
        /// <param name="operStockBro"></param>
        /// <param name="finance"></param>
        /// <param name="financeStockbro"></param>
        /// <param name="compliance"></param>
        /// <param name="compliancestockbro"></param>
        /// <param name="timeSinceLastSecurityAudit"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMSecurityRating> security, IRepository<StrategySecurityBusinessRating> strategy,
            IRepository<StrategySecurityRatingStockBroking> strategyStockBro,

            IRepository<OperationSecurityBusinessRating> operation, IRepository<OperationSecurityRatingStockBroking> operStockBro,

            IRepository<FinancialSecurityReporting> finance, IRepository<FinacialSecurityRatingStockBroking> financeStockbro, 

            IRepository<ComplianceSecurity> compliance, IRepository<ComplianceSecurityRatingStockBroking> compliancestockbro,
            IRepository<TimeSinceLastSecurityAudit> timeSinceLastSecurityAudit, ICurrentUserService currentUserService,
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
                    var getsecurity = security.GetContextByConditon(x => x.BusinessRiskRatingId == id).FirstOrDefault();

                    var getstrategy = strategy.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                    var getstrategyStockBro = strategyStockBro.GetContextByConditon(x => x.StrategySecurityBusinessRatingId == getstrategy.Id).FirstOrDefault();

                    var getoperation = operation.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                    var getoperStockBro = operStockBro.GetContextByConditon(x => x.OperationSecurityBusinessRatingId == getoperation.Id).FirstOrDefault();

                    var getfinance = finance.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                    var getfinanceStockbro = financeStockbro.GetContextByConditon(x => x.FinancialSecurityReportingId == getfinance.Id).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                    var getcompliancestockbro = compliancestockbro.GetContextByConditon(x => x.ComplianceSecurityId == getcompliance.Id).FirstOrDefault();

                    var gettimeSinceLastSecurityAudit = timeSinceLastSecurityAudit.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                    ARMSecurityRequest resp = new ARMSecurityRequest
                    {
                        ARMSecurity = new ARMSecurityRatingReq
                        {
                            Status = getsecurity.Status,
                            Strategy = new StrategySecurityReq
                            {                               
                                StockBroking = new StrategySecurityRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyStockBro.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyStockBro.CurrencyDevaluation,

                                    Increasedleverage = getstrategyStockBro.Increasedleverage,

                                    LiquidityPressures = getstrategyStockBro.LiquidityPressures,

                                    ReputationalRisk = getstrategyStockBro.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyStockBro.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyStockBro.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyStockBro.InformationSecurityRisk,

                                    CreditRisk = getstrategyStockBro.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyStockBro.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyStockBro.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyStockBro.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyStockBro.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyStockBro.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyStockBro.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyStockBro.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyStockBro.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyStockBro.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyStockBro.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyStockBro.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyStockBro.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyStockBro.InvestmentRisk,

                                    FailureofInvestor = getstrategyStockBro.FailureofInvestor,

                                    ExitRisk = getstrategyStockBro.ExitRisk,

                                    SocialRisk = getstrategyStockBro.SocialRisk,

                                    EnvironmentalRisk = getstrategyStockBro.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyStockBro.SustainabilityRisk,

                                    BCPandDRP = getstrategyStockBro.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyStockBro.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyStockBro.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyStockBro.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyStockBro.ProductivityRisk,

                                    Total = getstrategyStockBro.Total
                                },
                                Comment = getstrategy.Comment
                            },
                            Operations = new OperationSecurityReq
                            {
                                StockBroking = new OperationSecurityRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperStockBro.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperStockBro.TheftorFraudRisk,
                                    PoorCustomerService = getoperStockBro.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperStockBro.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperStockBro.ThirdpartyRisk,
                                    TAT = getoperStockBro.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperStockBro.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperStockBro.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperStockBro.RecruitmentRisk,
                                    ConfidentialityIntegrityandAvailabilityofData = getoperStockBro.ConfidentialityIntegrityandAvailabilityofData,
                                    UnauthorizedAccess = getoperStockBro.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperStockBro.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperStockBro.ErroneousDataEntry,
                                    Miscommunication = getoperStockBro.Miscommunication,
                                    ErrorDetectionRisk = getoperStockBro.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperStockBro.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperStockBro.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperStockBro.ProductivityRisk,
                                    BudgetOverruns = getoperStockBro.BudgetOverruns,
                                    Total = getoperStockBro.Total
                                },
                                Comment = getoperation.Comment
                            },
                            FinancialReporting = new FinancialSecurityReportingReq
                            {
                                StockBroking = new FinacialSecurityRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceStockbro.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceStockbro.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceStockbro.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceStockbro.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceStockbro.TAT,

                                    ErrororControlRisk = getfinanceStockbro.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceStockbro.TheftorFraudRisk,

                                    Total = getfinanceStockbro.Total
                                },
                                Comment = getfinance.Comment
                            },
                            Compliance = new ComplianceSecurityReq
                            {                              
                                StockBroking = new ComplianceSecurityRatingReq
                                {
                                    AMLCFT = getcompliancestockbro.AMLCFT,
                                    LitigationRisk = getcompliancestockbro.LitigationRisk,
                                    ChangingRegulations = getcompliancestockbro.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcompliancestockbro.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcompliancestockbro.NonComplianceWithContracts,
                                    KYCChecks = getcompliancestockbro.KYCChecks,
                                    GDPROrNDPR = getcompliancestockbro.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcompliancestockbro.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcompliancestockbro.DisclosureRisk,
                                    CorporateGovernance = getcompliancestockbro.CorporateGovernance,
                                    TAT = getcompliancestockbro.TAT,
                                    Total = getcompliancestockbro.Total
                                },
                                Comment = getcompliance.Comment

                            },
                            LastReportOverallRating = new TimeSinceLastSecurityAuditReq
                            {
                                StockBroking = gettimeSinceLastSecurityAudit.StockBroking,
                                Comment = gettimeSinceLastSecurityAudit.Comment
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
