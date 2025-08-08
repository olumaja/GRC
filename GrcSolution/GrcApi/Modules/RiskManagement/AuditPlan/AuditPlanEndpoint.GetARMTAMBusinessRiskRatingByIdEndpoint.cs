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
    public class GetARMTAMBusinessRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Service to get ARMTAM business risk rating by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armTAM"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyTAM"></param>
        /// <param name="operation"></param>
        /// <param name="operTAM"></param>
        /// <param name="finance"></param>
        /// <param name="financeTAM"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceTAM"></param>
        /// <param name="timeSinceLastARMTAMAudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMTAMBusinessRiskRating> armTAM, IRepository<StrategyBusinessARMTAM> strategy,
            IRepository<StrategyBusinessTAMRating> strategyTAM,

            IRepository<OperationBusinessARMTAM> operation, IRepository<OperationBusinessTAMRating> operTAM,

            IRepository<FinancialBusinessARMTAM> finance, IRepository<FinacialBusinessTAMRating> financeTAM,

            IRepository<ComplianceBusinessARMTAM> compliance, IRepository<ComplianceBusinessTAMRating> complianceTAM,
            IRepository<TimeSinceLastBusinessARMTAMAudit> timeSinceLastARMTAMAudit,
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
                    var gebusinessRating = armTAM.GetContextByConditon(x => x.BusinessRiskRatingId == id).FirstOrDefault();

                    var getstrategylog = strategy.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                    var getstrategyTAM = strategyTAM.GetContextByConditon(x => x.StrategyBusinessARMTAMId == getstrategylog.Id).FirstOrDefault();

                    var getoperation = operation.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                    var getoperTAM = operTAM.GetContextByConditon(x => x.OperationBusinessARMTAMId == getoperation.Id).FirstOrDefault();

                    var getfinance = finance.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                    var getfinanceTAM = financeTAM.GetContextByConditon(x => x.FinancialBusinessARMTAMId == getfinance.Id).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                    var getcomplianceTAM = complianceTAM.GetContextByConditon(x => x.ComplianceBusinessARMTAMId == getcompliance.Id).FirstOrDefault();

                    var gettimeSinceLastARMTAMAudit = timeSinceLastARMTAMAudit.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                    ARMTAMRequest resp = new ARMTAMRequest
                    {
                        ARMTAM = new ARMTAMBusinessRiskRatingReq
                        {
                            Status = gebusinessRating.Status,
                            Strategy = new StrategyBusinessARMTAMReq
                            {
                                ARMTAM = new StrategyBusinessTAMRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyTAM.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyTAM.CurrencyDevaluation,

                                    Increasedleverage = getstrategyTAM.Increasedleverage,

                                    LiquidityPressures = getstrategyTAM.LiquidityPressures,

                                    ReputationalRisk = getstrategyTAM.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyTAM.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyTAM.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyTAM.InformationSecurityRisk,

                                    CreditRisk = getstrategyTAM.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyTAM.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyTAM.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyTAM.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyTAM.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyTAM.DropinFundandFundManagerRatings,
                                    HarshMacroeconomicConditionsegInflation = getstrategyTAM.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyTAM.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyTAM.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyTAM.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyTAM.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyTAM.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyTAM.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyTAM.InvestmentRisk,

                                    FailureofInvestor = getstrategyTAM.FailureofInvestor,

                                    ExitRisk = getstrategyTAM.ExitRisk,

                                    SocialRisk = getstrategyTAM.SocialRisk,

                                    EnvironmentalRisk = getstrategyTAM.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyTAM.SustainabilityRisk,

                                    BCPandDRP = getstrategyTAM.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyTAM.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyTAM.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyTAM.EmergingRisks,

                                    ProductivityRisk = getstrategyTAM.ProductivityRisk,

                                    Total = getstrategyTAM.Total
                                },
                                Comment = getstrategylog.Comment
                            },
                            Operations = new OperationBusinessARMTAMReq
                            {
                                ARMTAM = new OperationBusinessTAMRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperTAM.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperTAM.TheftorFraudRisk,
                                    PoorCustomerService = getoperTAM.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperTAM.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperTAM.ThirdpartyRisk,
                                    TAT = getoperTAM.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperTAM.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperTAM.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperTAM.RecruitmentRisk,
                                    ConfidentialityIntegrityandAvailabilityofData = getoperTAM.ConfidentialityIntegrityandAvailabilityofData,
                                    UnauthorizedAccess = getoperTAM.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperTAM.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperTAM.ErroneousDataEntry,
                                    Miscommunication = getoperTAM.Miscommunication,
                                    ErrorDetectionRisk = getoperTAM.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperTAM.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperTAM.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperTAM.ProductivityRisk,
                                    BudgetOverruns = getoperTAM.BudgetOverruns,
                                    Total = getoperTAM.Total
                                },
                                Comment = getoperation.Comment
                            },
                            FinancialReporting = new FinancialBusinessARMTAMReq
                            {
                                ARMTAM = new FinacialBusinessTAMRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceTAM.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceTAM.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceTAM.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceTAM.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceTAM.TAT,

                                    ErrororControlRisk = getfinanceTAM.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceTAM.TheftorFraudRisk,

                                    Total = getfinanceTAM.Total
                                },
                                Comment = getfinance.Comment
                            },
                            Compliance = new ComplianceBusinessARMTAMReq
                            {
                                ARMTAM = new ComplianceBusinessTAMRatingReq
                                {
                                    AMLCFT = getcomplianceTAM.AMLCFT,
                                    LitigationRisk = getcomplianceTAM.LitigationRisk,
                                    ChangingRegulations = getcomplianceTAM.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceTAM.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceTAM.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceTAM.KYCChecks,
                                    GDPROrNDPR = getcomplianceTAM.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceTAM.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceTAM.DisclosureRisk,
                                    CorporateGovernance = getcomplianceTAM.CorporateGovernance,
                                    TAT = getcomplianceTAM.TAT,
                                    Total = getcomplianceTAM.Total
                                },
                                Comment = getcompliance.Comment
                            },
                            LastReportOverallRating = new TimeSinceLastBusinessARMTAMAuditReq
                            {
                                ARMTAM = gettimeSinceLastARMTAMAudit.ARMTAM,
                                Comment = gettimeSinceLastARMTAMAudit.Comment
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
