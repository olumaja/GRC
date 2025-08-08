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
    public class GetARMHillBusinessRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get ARMHill business risk rating by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="hill"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyArmhill"></param>
        /// <param name="operation"></param>
        /// <param name="operARMHill"></param>
        /// <param name="finance"></param>
        /// <param name="financeArmHill"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceARMHill"></param>
        /// <param name="timeSinceLastHillAudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMHillRating> hill, IRepository<StrategyBusinessRatingARMHill> strategy, IRepository<StrategyHillRating> strategyArmhill,

            IRepository<OperationBusinessRatingHill> operation, IRepository<OperationHillRating> operARMHill,

            IRepository<FinancialHillReporting> finance, IRepository<FinacialHillRating> financeArmHill,

            IRepository<ComplianceBusinessRatingHill> compliance, IRepository<ComplianceHillRating> complianceARMHill,
            IRepository<TimeSinceLastHillAudit> timeSinceLastHillAudit, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                    var gethill = hill.GetContextByConditon(x => x.BusinessRiskRatingId == id).FirstOrDefault();

                    var getstrategylog = strategy.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    var getstrategyArmhill = strategyArmhill.GetContextByConditon(x => x.StrategyBusinessRatingARMHillId == getstrategylog.Id).FirstOrDefault();

                    var getoperation = operation.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    var getoperARMHill = operARMHill.GetContextByConditon(x => x.OperationBusinessRatingHillId == getoperation.Id).FirstOrDefault();

                    var getfinance = finance.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    var getfinanceArmHill = financeArmHill.GetContextByConditon(x => x.FinancialHillReportingId == getfinance.Id).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    var getcomplianceARMHill = complianceARMHill.GetContextByConditon(x => x.ComplianceBusinessRatingHillId == getcompliance.Id).FirstOrDefault();

                    var gettimesinceaudit = timeSinceLastHillAudit.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    ARMHillRequest resp = new ARMHillRequest
                    {
                        ARMHill = new ARMHillRatingReq
                        {
                            Status = gethill.Status,
                            Strategy = new StrategyHillReq
                            {
                                ARMHill = new StrategyHillRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyArmhill.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyArmhill.CurrencyDevaluation,

                                    Increasedleverage = getstrategyArmhill.Increasedleverage,

                                    LiquidityPressures = getstrategyArmhill.LiquidityPressures,

                                    ReputationalRisk = getstrategyArmhill.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyArmhill.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyArmhill.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyArmhill.InformationSecurityRisk,

                                    CreditRisk = getstrategyArmhill.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyArmhill.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyArmhill.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyArmhill.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyArmhill.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyArmhill.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyArmhill.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyArmhill.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyArmhill.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyArmhill.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyArmhill.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyArmhill.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyArmhill.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyArmhill.InvestmentRisk,

                                    FailureofInvestor = getstrategyArmhill.FailureofInvestor,

                                    ExitRisk = getstrategyArmhill.ExitRisk,

                                    SocialRisk = getstrategyArmhill.SocialRisk,

                                    EnvironmentalRisk = getstrategyArmhill.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyArmhill.SustainabilityRisk,

                                    BCPandDRP = getstrategyArmhill.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyArmhill.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyArmhill.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyArmhill.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyArmhill.ProductivityRisk,

                                    Total = getstrategyArmhill.Total
                                },
                                Comment = getstrategylog.Comment
                            },
                            Operations = new OperationHillReq
                            {
                                ARMHill = new OperationHillRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperARMHill.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperARMHill.TheftorFraudRisk,
                                    PoorCustomerService = getoperARMHill.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getoperARMHill.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getoperARMHill.ThirdpartyRisk,

                                    TAT = getoperARMHill.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperARMHill.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperARMHill.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperARMHill.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getoperARMHill.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperARMHill.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperARMHill.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperARMHill.ErroneousDataEntry,

                                    Miscommunication = getoperARMHill.Miscommunication,

                                    ErrorDetectionRisk = getoperARMHill.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperARMHill.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperARMHill.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperARMHill.ProductivityRisk,
                                    BudgetOverruns = getoperARMHill.BudgetOverruns,
                                    Total = getoperARMHill.Total
                                },
                                Comment = getoperation.Comment
                            },
                            FinancialReporting = new FinancialHillReportingReq
                            {
                                ARMHill = new FinacialHillRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceArmHill.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceArmHill.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceArmHill.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceArmHill.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceArmHill.TAT,

                                    ErrororControlRisk = getfinanceArmHill.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceArmHill.TheftorFraudRisk,

                                    Total = getfinanceArmHill.Total
                                },
                                Comment = getfinance.Comment
                            },
                            Compliance = new ComplianceHillReq
                            {
                                ARMHill = new ComplianceHillRatingReq
                                {
                                    AMLCFT = getcomplianceARMHill.AMLCFT,
                                    LitigationRisk = getcomplianceARMHill.LitigationRisk,
                                    ChangingRegulations = getcomplianceARMHill.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceARMHill.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceARMHill.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceARMHill.KYCChecks,
                                    GDPROrNDPR = getcomplianceARMHill.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceARMHill.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceARMHill.DisclosureRisk,
                                    CorporateGovernance = getcomplianceARMHill.CorporateGovernance,
                                    TAT = getcomplianceARMHill.TAT,
                                    Total = getcomplianceARMHill.Total
                                },
                                Comment = getcompliance.Comment
                            },
                            LastReportOverallRating = new TimeSinceLastHillAuditReq
                            {
                                ARMHill = gettimesinceaudit.ARMHill,
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
