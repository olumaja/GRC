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
    public class GetARMIMBusinessRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get ARMIM business risk rating by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armIM"></param>
        /// <param name="strategy"></param>
        /// <param name="straOperation"></param>
        /// <param name="straOperationsett"></param>
        /// <param name="strategyOpration"></param>
        /// <param name="straregstrar"></param>
        /// <param name="strategyResearch"></param>
        /// <param name="straFundadmin"></param>
        /// <param name="strategyFundAcct"></param>
        /// <param name="straBD"></param>
        /// <param name="strategyIMUnit"></param>
        /// <param name="strategyARMIM"></param>
        /// <param name="operation"></param>
        /// <param name="operBD"></param>
        /// <param name="operFinancialAcct"></param>
        /// <param name="operFundAdmin"></param>
        /// <param name="operationRetail"></param>
        /// <param name="operRegis"></param>
        /// <param name="operSettle"></param>
        /// <param name="operControl"></param>
        /// <param name="operationIM"></param>
        /// <param name="operationARMIM"></param>
        /// <param name="operationResearch"></param>
        /// <param name="finance"></param>
        /// <param name="financeOp"></param>
        /// <param name="financeOpSettle"></param>
        /// <param name="financeRegis"></param>
        /// <param name="financeRetailOp"></param>
        /// <param name="financeFundAd"></param>
        /// <param name="financeFundAcct"></param>
        /// <param name="financeBD"></param>
        /// <param name="financeIM"></param>
        /// <param name="financeARMIM"></param>
        /// <param name="financeResearch"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceOpCtrl"></param>
        /// <param name="complianceOpSettl"></param>
        /// <param name="complianceRegis"></param>
        /// <param name="complianceResearch"></param>
        /// <param name="complianceReatilOp"></param>
        /// <param name="complianceFundAd"></param>
        /// <param name="complianceFundAcct"></param>
        /// <param name="complianceBD"></param>
        /// <param name="complianceIM"></param>
        /// <param name="complianceARMIM"></param>
        /// <param name="timeSinceLastAuditIM"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMIMBusinessRiskRating> armIM, IRepository<StrategyImBusinessRating> strategy, IRepository<StrategyIMRatingOperationControl> straOperation,
            IRepository<StrategyIMRatingOperationSettlement> straOperationsett, IRepository<StrategyIMRatingRetailOperation> strategyOpration,
            IRepository<StrategyIMRatingARMRegistrar> straregstrar, IRepository<StrategyIMRatingResearch> strategyResearch,
            IRepository<StrategyIMRatingFundAdmin> straFundadmin, IRepository<StrategyIMRatingFundAccount> strategyFundAcct,
            IRepository<StrategyIMRatingBDPWMIAMIMRetail> straBD, IRepository<StrategyIMRating> strategyIMUnit, IRepository<StrategyIMRatingARMIM> strategyARMIM,

            IRepository<OperationIMBusinessRating> operation, IRepository<OperationIMRatingBDPWMIAMIMRetail> operBD, IRepository<OperationIMRatingFundAccount> operFinancialAcct,
            IRepository<OperationIMRatingFundAdmin> operFundAdmin, IRepository<OperationIMRatingRetailOperation> operationRetail, IRepository<OperationIMRatingARMRegistrar> operRegis,
            IRepository<OperationIMRatingOperationSettlement> operSettle, IRepository<OperationIMRatingOperationControl> operControl,
            IRepository<OperationIMUnitRating> operationIM, IRepository<OperationARMIMRating> operationARMIM, IRepository<OperationIMRatingResearch> operationResearch,

            IRepository<FinancialIMBusinessRating> finance, IRepository<FinacialIMRatingOperationControl> financeOp, IRepository<FinacialIMRatingOperationSettlement> financeOpSettle,
            IRepository<FinacialIMRatingARMRegistrar> financeRegis, IRepository<FinacialIMRatingRetailOperation> financeRetailOp,
            IRepository<FinacialIMRatingFundAdmin> financeFundAd, IRepository<FinacialIMRatingFundAccount> financeFundAcct, IRepository<FinacialIMRatingBDPWMIAMIMRetail> financeBD,
            IRepository<FinacialIMBusinessRating> financeIM, IRepository<FinacialARMIMRating> financeARMIM, IRepository<FinacialIMRatingResearch> financeResearch,

            IRepository<ComplianceIMBusinessRating> compliance, IRepository<ComplianceIMRatingOperationControl> complianceOpCtrl, IRepository<ComplianceIMRatingOperationSettlement> complianceOpSettl,
            IRepository<ComplianceIMRatingARMRegistrar> complianceRegis, IRepository<ComplianceIMRatingResearch> complianceResearch,
            IRepository<ComplianceIMRatingRetailOperation> complianceReatilOp, IRepository<ComplianceIMRatingFundAdmin> complianceFundAd,
            IRepository<ComplianceIMRatingFundAccount> complianceFundAcct, IRepository<ComplianceIMRatingBDPWMIAMIMRetail> complianceBD,
            IRepository<ComplianceIMRating> complianceIM, IRepository<ComplianceIMRatingARMIM> complianceARMIM, IRepository<TimeSinceLastAuditIMBusinessRating> timeSinceLastAuditIM,
            ICurrentUserService currentUserService,
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
                    var getarmIMRating = armIM.GetContextByConditon(x => x.BusinessRiskRatingId == id).FirstOrDefault();

                    var getstrategylog = strategy.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                    var getstrategARMIMrating = strategyARMIM.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyrating = strategyIMUnit.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyBD = straBD.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyOperationCtrl = straOperation.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyOperationSettle = straOperationsett.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyResgistrar = straregstrar.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyFundAcct = strategyFundAcct.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyFundadmin = straFundadmin.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyResearch = strategyResearch.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();
                    var getstrategyRetailOperation = strategyOpration.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).FirstOrDefault();

                    var getoperationlog = operation.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                    var getoperationARMIMrating = operationARMIM.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getoperationrating = operationIM.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getoperationBDrating = operBD.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getoperationFundAdmin = operFundAdmin.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getoperationFundAcct = operFinancialAcct.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getoperationOperSettle = operSettle.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getOperationControl = operControl.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getOperationOperationRetail = operationRetail.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getoperationResearch = operationResearch.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();
                    var getOperationOperRegis = operRegis.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).FirstOrDefault();

                    var getfinancelog = finance.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                    var getfinanceARMIMrating = financeARMIM.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinancerating = financeIM.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceRetailOp = financeRetailOp.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceRegis = financeRegis.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceOperation = financeOp.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceOpSettle = financeOpSettle.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceFundAcct = financeFundAcct.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceFundAd = financeFundAd.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceResearch = financeResearch.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();
                    var getfinanceBD = financeBD.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).FirstOrDefault();

                    var getcomplianceRating = compliance.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                    var getcomplianceARMIMlog = complianceARMIM.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcompliancelog = complianceIM.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceReatilOp = complianceReatilOp.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceRegis = complianceRegis.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceFundAcct = complianceFundAcct.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceOpSettl = complianceOpSettl.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceOpCtrl = complianceOpCtrl.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceFundAd = complianceFundAd.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceResearch = complianceResearch.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();
                    var getcomplianceBD = complianceBD.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).FirstOrDefault();

                    var gettimesinceaudit = timeSinceLastAuditIM.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();


                    ARMIMRequest resp = new ARMIMRequest
                    {
                        ARMIM = new ARMIMBusinessRiskRatingReq
                        {
                            Status = getarmIMRating.Status,
                            Strategy = new StrategyImBusinessRatingReq
                            {
                                ARMIM = new StrategyIMRatingReq
                                {
                                    flunctuatingInterestRates = getstrategARMIMrating.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategARMIMrating.CurrencyDevaluation,

                                    Increasedleverage = getstrategARMIMrating.Increasedleverage,

                                    LiquidityPressures = getstrategARMIMrating.LiquidityPressures,

                                    ReputationalRisk = getstrategARMIMrating.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategARMIMrating.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategARMIMrating.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategARMIMrating.InformationSecurityRisk,

                                    CreditRisk = getstrategARMIMrating.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategARMIMrating.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategARMIMrating.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategARMIMrating.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategARMIMrating.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategARMIMrating.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategARMIMrating.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategARMIMrating.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategARMIMrating.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategARMIMrating.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategARMIMrating.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategARMIMrating.PoliticalRisk,

                                    ProjectManagementRisk = getstrategARMIMrating.ProjectManagementRisk,

                                    InvestmentRisk = getstrategARMIMrating.InvestmentRisk,

                                    FailureofInvestor = getstrategARMIMrating.FailureofInvestor,

                                    ExitRisk = getstrategARMIMrating.ExitRisk,

                                    SocialRisk = getstrategARMIMrating.SocialRisk,

                                    EnvironmentalRisk = getstrategARMIMrating.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategARMIMrating.SustainabilityRisk,

                                    BCPandDRP = getstrategARMIMrating.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategARMIMrating.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategARMIMrating.HealthandSafetyRisks,

                                    EmergingRisks = getstrategARMIMrating.EnvironmentalRisk,

                                    ProductivityRisk = getstrategARMIMrating.ProductivityRisk,

                                    Total = getstrategARMIMrating.Total
                                },
                                IMUnit = new StrategyIMRatingReq
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
                                BDPWMIAMIMRetail = new StrategyIMRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyBD.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyBD.CurrencyDevaluation,

                                    Increasedleverage = getstrategyBD.Increasedleverage,

                                    LiquidityPressures = getstrategyBD.LiquidityPressures,

                                    ReputationalRisk = getstrategyBD.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyBD.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyBD.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyBD.InformationSecurityRisk,

                                    CreditRisk = getstrategyBD.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyBD.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyBD.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyBD.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyBD.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyBD.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyBD.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyBD.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyBD.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyBD.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyBD.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyBD.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyBD.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyBD.InvestmentRisk,

                                    FailureofInvestor = getstrategyBD.FailureofInvestor,

                                    ExitRisk = getstrategyBD.ExitRisk,

                                    SocialRisk = getstrategyBD.SocialRisk,

                                    EnvironmentalRisk = getstrategyBD.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyBD.SustainabilityRisk,

                                    BCPandDRP = getstrategyBD.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyBD.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyBD.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyBD.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyBD.ProductivityRisk,

                                    Total = getstrategyBD.Total
                                },
                                ARMRegistrar = new StrategyIMRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyResgistrar.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyResgistrar.CurrencyDevaluation,

                                    Increasedleverage = getstrategyResgistrar.Increasedleverage,

                                    LiquidityPressures = getstrategyResgistrar.LiquidityPressures,

                                    ReputationalRisk = getstrategyResgistrar.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyResgistrar.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyResgistrar.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyResgistrar.InformationSecurityRisk,

                                    CreditRisk = getstrategyResgistrar.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyResgistrar.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyResgistrar.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyResgistrar.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyResgistrar.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyResgistrar.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyResgistrar.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyResgistrar.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyResgistrar.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyResgistrar.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyResgistrar.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyResgistrar.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyResgistrar.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyResgistrar.InvestmentRisk,

                                    FailureofInvestor = getstrategyResgistrar.FailureofInvestor,

                                    ExitRisk = getstrategyResgistrar.ExitRisk,

                                    SocialRisk = getstrategyResgistrar.SocialRisk,

                                    EnvironmentalRisk = getstrategyResgistrar.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyResgistrar.SustainabilityRisk,

                                    BCPandDRP = getstrategyResgistrar.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyResgistrar.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyResgistrar.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyResgistrar.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyResgistrar.ProductivityRisk,

                                    Total = getstrategyResgistrar.Total
                                },
                                OperationSettlement = new StrategyIMRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyOperationSettle.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyOperationSettle.CurrencyDevaluation,

                                    Increasedleverage = getstrategyOperationSettle.Increasedleverage,

                                    LiquidityPressures = getstrategyOperationSettle.LiquidityPressures,

                                    ReputationalRisk = getstrategyOperationSettle.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyOperationSettle.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyOperationSettle.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyOperationSettle.InformationSecurityRisk,

                                    CreditRisk = getstrategyOperationSettle.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyOperationSettle.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyOperationSettle.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyOperationSettle.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyOperationSettle.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyOperationSettle.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyOperationSettle.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyOperationSettle.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyOperationSettle.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyOperationSettle.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyOperationSettle.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyOperationSettle.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyOperationSettle.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyOperationSettle.InvestmentRisk,

                                    FailureofInvestor = getstrategyOperationSettle.FailureofInvestor,

                                    ExitRisk = getstrategyOperationSettle.ExitRisk,

                                    SocialRisk = getstrategyOperationSettle.SocialRisk,

                                    EnvironmentalRisk = getstrategyOperationSettle.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyOperationSettle.SustainabilityRisk,

                                    BCPandDRP = getstrategyOperationSettle.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyOperationSettle.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyOperationSettle.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyOperationSettle.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyOperationSettle.ProductivityRisk,

                                    Total = getstrategyOperationSettle.Total
                                },
                                FundAccount = new StrategyIMRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyFundAcct.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyFundAcct.CurrencyDevaluation,

                                    Increasedleverage = getstrategyFundAcct.Increasedleverage,

                                    LiquidityPressures = getstrategyFundAcct.LiquidityPressures,

                                    ReputationalRisk = getstrategyFundAcct.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyFundAcct.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyFundAcct.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyFundAcct.InformationSecurityRisk,

                                    CreditRisk = getstrategyFundAcct.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyFundAcct.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyFundAcct.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyFundAcct.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyFundAcct.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyFundAcct.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyFundAcct.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyFundAcct.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyFundAcct.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyFundAcct.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyFundAcct.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyFundAcct.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyFundAcct.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyFundAcct.InvestmentRisk,

                                    FailureofInvestor = getstrategyFundAcct.FailureofInvestor,

                                    ExitRisk = getstrategyFundAcct.ExitRisk,

                                    SocialRisk = getstrategyFundAcct.SocialRisk,

                                    EnvironmentalRisk = getstrategyFundAcct.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyFundAcct.SustainabilityRisk,

                                    BCPandDRP = getstrategyFundAcct.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyFundAcct.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyFundAcct.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyFundAcct.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyFundAcct.ProductivityRisk,

                                    Total = getstrategyFundAcct.Total
                                },
                                FundAdmin = new StrategyIMRatingReq 
                                {
                                    flunctuatingInterestRates = getstrategyFundadmin.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyFundadmin.CurrencyDevaluation,

                                    Increasedleverage = getstrategyFundadmin.Increasedleverage,

                                    LiquidityPressures = getstrategyFundadmin.LiquidityPressures,

                                    ReputationalRisk = getstrategyFundadmin.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyFundadmin.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyFundadmin.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyFundadmin.InformationSecurityRisk,

                                    CreditRisk = getstrategyFundadmin.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyFundadmin.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyFundadmin.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyFundadmin.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyFundadmin.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyFundadmin.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyFundadmin.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyFundadmin.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyFundadmin.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyFundadmin.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyFundadmin.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyFundadmin.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyFundadmin.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyFundadmin.InvestmentRisk,

                                    FailureofInvestor = getstrategyFundadmin.FailureofInvestor,

                                    ExitRisk = getstrategyFundadmin.ExitRisk,

                                    SocialRisk = getstrategyFundadmin.SocialRisk,

                                    EnvironmentalRisk = getstrategyFundadmin.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyFundadmin.SustainabilityRisk,

                                    BCPandDRP = getstrategyFundadmin.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyFundadmin.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyFundadmin.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyFundadmin.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyFundadmin.ProductivityRisk,

                                    Total = getstrategyFundadmin.Total
                                },
                                Research = new StrategyIMRatingReq 
                                {
                                    flunctuatingInterestRates = getstrategyResearch.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyResearch.CurrencyDevaluation,

                                    Increasedleverage = getstrategyResearch.Increasedleverage,

                                    LiquidityPressures = getstrategyResearch.LiquidityPressures,

                                    ReputationalRisk = getstrategyResearch.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyResearch.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyResearch.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyResearch.InformationSecurityRisk,

                                    CreditRisk = getstrategyResearch.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyResearch.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyResearch.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyResearch.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyResearch.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyResearch.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyResearch.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyResearch.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyResearch.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyResearch.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyResearch.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyResearch.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyResearch.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyResearch.InvestmentRisk,

                                    FailureofInvestor = getstrategyResearch.FailureofInvestor,

                                    ExitRisk = getstrategyResearch.ExitRisk,

                                    SocialRisk = getstrategyResearch.SocialRisk,

                                    EnvironmentalRisk = getstrategyResearch.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyResearch.SustainabilityRisk,

                                    BCPandDRP = getstrategyResearch.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyResearch.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyResearch.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyResearch.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyResearch.ProductivityRisk,

                                    Total = getstrategyResearch.Total
                                },
                                OperationControl = new StrategyIMRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyOperationCtrl.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyOperationCtrl.CurrencyDevaluation,

                                    Increasedleverage = getstrategyOperationCtrl.Increasedleverage,

                                    LiquidityPressures = getstrategyOperationCtrl.LiquidityPressures,

                                    ReputationalRisk = getstrategyOperationCtrl.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyOperationCtrl.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyOperationCtrl.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyOperationCtrl.InformationSecurityRisk,

                                    CreditRisk = getstrategyOperationCtrl.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyOperationCtrl.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyOperationCtrl.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyOperationCtrl.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyOperationCtrl.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyOperationCtrl.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyOperationCtrl.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyOperationCtrl.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyOperationCtrl.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyOperationCtrl.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyOperationCtrl.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyOperationCtrl.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyOperationCtrl.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyOperationCtrl.InvestmentRisk,

                                    FailureofInvestor = getstrategyOperationCtrl.FailureofInvestor,

                                    ExitRisk = getstrategyOperationCtrl.ExitRisk,

                                    SocialRisk = getstrategyOperationCtrl.SocialRisk,

                                    EnvironmentalRisk = getstrategyOperationCtrl.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyOperationCtrl.SustainabilityRisk,

                                    BCPandDRP = getstrategyOperationCtrl.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyOperationCtrl.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyOperationCtrl.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyOperationCtrl.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyOperationCtrl.ProductivityRisk,

                                    Total = getstrategyOperationCtrl.Total
                                },
                                RetailOperation = new StrategyIMRatingReq
                                {
                                    flunctuatingInterestRates = getstrategyRetailOperation.FlunCTOatingInterestRates,
                                    CurrencyDevaluation = getstrategyRetailOperation.CurrencyDevaluation,

                                    Increasedleverage = getstrategyRetailOperation.Increasedleverage,

                                    LiquidityPressures = getstrategyRetailOperation.LiquidityPressures,

                                    ReputationalRisk = getstrategyRetailOperation.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyRetailOperation.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyRetailOperation.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyRetailOperation.InformationSecurityRisk,

                                    CreditRisk = getstrategyRetailOperation.CreditRisk,

                                    AllianceandPartnershipRisks = getstrategyRetailOperation.AllianceandPartnershipRisks,

                                    PortfolioProductandFundPerformanceRisk = getstrategyRetailOperation.PortfolioProductandFundPerformanceRisk,

                                    RisktoProfitabilityorPerformance = getstrategyRetailOperation.RisktoProfitabilityorPerformance,

                                    RiskofDeclineinMarketShare = getstrategyRetailOperation.RiskofDeclineinMarketShare,

                                    DropinFundandFundManagerRatings = getstrategyRetailOperation.DropinFundandFundManagerRatings,

                                    HarshMacroeconomicConditionsegInflation = getstrategyRetailOperation.HarshMacroeconomicConditionsegInflation,

                                    StiffCompetitionandPoorVisibilityOftheBusiness = getstrategyRetailOperation.StiffCompetitionandPoorVisibilityOftheBusiness,

                                    ErosionofStatutoryCapital = getstrategyRetailOperation.ErosionofStatutoryCapital,

                                    FluidityofTechnologicalSolutions = getstrategyRetailOperation.FluidityofTechnologicalSolutions,

                                    UnregulatedUnstruCTOredlandscape = getstrategyRetailOperation.UnregulatedUnstruCTOredlandscape,

                                    PoliticalRisk = getstrategyRetailOperation.PoliticalRisk,

                                    ProjectManagementRisk = getstrategyRetailOperation.ProjectManagementRisk,

                                    InvestmentRisk = getstrategyRetailOperation.InvestmentRisk,

                                    FailureofInvestor = getstrategyRetailOperation.FailureofInvestor,

                                    ExitRisk = getstrategyRetailOperation.ExitRisk,

                                    SocialRisk = getstrategyRetailOperation.SocialRisk,

                                    EnvironmentalRisk = getstrategyRetailOperation.EnvironmentalRisk,

                                    SustainabilityRisk = getstrategyRetailOperation.SustainabilityRisk,

                                    BCPandDRP = getstrategyRetailOperation.BCPandDRP,

                                    MyLegacyIssuesProperty = getstrategyRetailOperation.MyLegacyIssuesProperty,

                                    HealthandSafetyRisks = getstrategyRetailOperation.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyRetailOperation.EnvironmentalRisk,

                                    ProductivityRisk = getstrategyRetailOperation.ProductivityRisk,

                                    Total = getstrategyRetailOperation.Total
                                },
                                Comment = getstrategylog.Comment
                            },
                            Operations = new OperationIMBusinessRatingReq 
                            {
                                ARMIM = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationARMIMrating.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationARMIMrating.TheftorFraudRisk,
                                    PoorCustomerService = getoperationARMIMrating.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationARMIMrating.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationARMIMrating.ThirdpartyRisk,
                                    TAT = getoperationARMIMrating.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationARMIMrating.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationARMIMrating.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationARMIMrating.RecruitmentRisk,
                                    ConfidentialityIntegrityandAvailabilityofData = getoperationARMIMrating.ConfidentialityIntegrityandAvailabilityofData,
                                    UnauthorizedAccess = getoperationARMIMrating.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationARMIMrating.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationARMIMrating.ErroneousDataEntry,
                                    Miscommunication = getoperationARMIMrating.Miscommunication,
                                    ErrorDetectionRisk = getoperationARMIMrating.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationARMIMrating.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationARMIMrating.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationARMIMrating.ProductivityRisk,
                                    BudgetOverruns = getoperationARMIMrating.BudgetOverruns,
                                    Total = getoperationARMIMrating.Total
                                },
                                IMUnit = new OperationIMUnitRatingReq
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
                                BDPWMIAMIMRetail = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationBDrating.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationBDrating.TheftorFraudRisk,
                                    PoorCustomerService = getoperationBDrating.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationBDrating.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationBDrating.ThirdpartyRisk,
                                    TAT = getoperationBDrating.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationBDrating.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationBDrating.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationBDrating.RecruitmentRisk,
                                    ConfidentialityIntegrityandAvailabilityofData = getoperationBDrating.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperationBDrating.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperationBDrating.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperationBDrating.ErroneousDataEntry,

                                    Miscommunication = getoperationBDrating.Miscommunication,

                                    ErrorDetectionRisk = getoperationBDrating.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperationBDrating.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationBDrating.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationBDrating.ProductivityRisk,
                                    BudgetOverruns = getoperationBDrating.BudgetOverruns,
                                    Total = getoperationBDrating.Total
                                },
                                Research = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationResearch.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationResearch.TheftorFraudRisk,
                                    PoorCustomerService = getoperationResearch.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationResearch.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationResearch.ThirdpartyRisk,
                                    TAT = getoperationResearch.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationResearch.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationResearch.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationResearch.RecruitmentRisk,
                                    ConfidentialityIntegrityandAvailabilityofData = getoperationResearch.ConfidentialityIntegrityandAvailabilityofData,
                                    UnauthorizedAccess = getoperationResearch.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationResearch.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationResearch.ErroneousDataEntry,
                                    Miscommunication = getoperationResearch.Miscommunication,
                                    ErrorDetectionRisk = getoperationResearch.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationResearch.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationResearch.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationResearch.ProductivityRisk,
                                    BudgetOverruns = getoperationResearch.BudgetOverruns,
                                    Total = getoperationResearch.Total
                                },
                                OperationSettlement = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationOperSettle.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationOperSettle.TheftorFraudRisk,
                                    PoorCustomerService = getoperationOperSettle.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getoperationOperSettle.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getoperationOperSettle.ThirdpartyRisk,

                                    TAT = getoperationOperSettle.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationOperSettle.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperationOperSettle.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperationOperSettle.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getoperationOperSettle.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperationOperSettle.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperationOperSettle.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperationOperSettle.ErroneousDataEntry,

                                    Miscommunication = getoperationOperSettle.Miscommunication,

                                    ErrorDetectionRisk = getoperationOperSettle.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperationOperSettle.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationOperSettle.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationOperSettle.ProductivityRisk,
                                    BudgetOverruns = getoperationOperSettle.BudgetOverruns,
                                    Total = getoperationOperSettle.Total
                                },
                                ARMRegistrar = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getOperationOperRegis.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getOperationOperRegis.TheftorFraudRisk,
                                    PoorCustomerService = getOperationOperRegis.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getOperationOperRegis.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getOperationOperRegis.ThirdpartyRisk,

                                    TAT = getOperationOperRegis.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getOperationOperRegis.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getOperationOperRegis.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getOperationOperRegis.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getOperationOperRegis.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getOperationOperRegis.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getOperationOperRegis.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getOperationOperRegis.ErroneousDataEntry,

                                    Miscommunication = getOperationOperRegis.Miscommunication,

                                    ErrorDetectionRisk = getOperationOperRegis.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getOperationOperRegis.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getOperationOperRegis.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getOperationOperRegis.ProductivityRisk,
                                    BudgetOverruns = getOperationOperRegis.BudgetOverruns,
                                    Total = getOperationOperRegis.Total
                                },
                                FundAccount = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationFundAcct.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationFundAcct.TheftorFraudRisk,
                                    PoorCustomerService = getoperationFundAcct.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getoperationFundAcct.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getoperationFundAcct.ThirdpartyRisk,

                                    TAT = getoperationFundAcct.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationFundAcct.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperationFundAcct.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperationFundAcct.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getoperationFundAcct.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperationFundAcct.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperationFundAcct.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperationFundAcct.ErroneousDataEntry,

                                    Miscommunication = getoperationFundAcct.Miscommunication,

                                    ErrorDetectionRisk = getoperationFundAcct.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperationFundAcct.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationFundAcct.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationFundAcct.ProductivityRisk,
                                    BudgetOverruns = getoperationFundAcct.BudgetOverruns,
                                    Total = getoperationFundAcct.Total
                                },
                                FundAdmin = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationFundAdmin.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationFundAdmin.TheftorFraudRisk,
                                    PoorCustomerService = getoperationFundAdmin.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getoperationFundAdmin.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getoperationFundAdmin.ThirdpartyRisk,

                                    TAT = getoperationFundAdmin.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationFundAdmin.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperationFundAdmin.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperationFundAdmin.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getoperationFundAdmin.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getoperationFundAdmin.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperationFundAdmin.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperationFundAdmin.ErroneousDataEntry,

                                    Miscommunication = getoperationFundAdmin.Miscommunication,

                                    ErrorDetectionRisk = getoperationFundAdmin.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperationFundAdmin.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationFundAdmin.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getoperationFundAdmin.ProductivityRisk,
                                    BudgetOverruns = getoperationFundAdmin.BudgetOverruns,
                                    Total = getoperationFundAdmin.Total
                                },
                                OperationControl = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getOperationControl.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getOperationControl.TheftorFraudRisk,
                                    PoorCustomerService = getOperationControl.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getOperationControl.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getOperationControl.ThirdpartyRisk,

                                    TAT = getOperationControl.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getOperationControl.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getOperationControl.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getOperationControl.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getOperationControl.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getOperationControl.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getOperationControl.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getOperationControl.ErroneousDataEntry,

                                    Miscommunication = getOperationControl.Miscommunication,

                                    ErrorDetectionRisk = getOperationControl.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getOperationControl.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getOperationControl.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getOperationControl.ProductivityRisk,
                                    BudgetOverruns = getOperationControl.BudgetOverruns,
                                    Total = getOperationControl.Total
                                },
                                RetailOperation = new OperationIMUnitRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getOperationOperationRetail.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getOperationOperationRetail.TheftorFraudRisk,
                                    PoorCustomerService = getOperationOperationRetail.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getOperationOperationRetail.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getOperationOperationRetail.ThirdpartyRisk,
                                    TAT = getOperationOperationRetail.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getOperationOperationRetail.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getOperationOperationRetail.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getOperationOperationRetail.RecruitmentRisk,

                                    ConfidentialityIntegrityandAvailabilityofData = getOperationOperationRetail.ConfidentialityIntegrityandAvailabilityofData,

                                    UnauthorizedAccess = getOperationOperationRetail.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getOperationOperationRetail.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getOperationOperationRetail.ErroneousDataEntry,

                                    Miscommunication = getOperationOperationRetail.Miscommunication,

                                    ErrorDetectionRisk = getOperationOperationRetail.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getOperationOperationRetail.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getOperationOperationRetail.RelevanceandRecencyofModelToolsandTechniques,
                                    ProductivityRisk = getOperationOperationRetail.ProductivityRisk,
                                    BudgetOverruns = getOperationOperationRetail.BudgetOverruns,
                                    Total = getOperationOperationRetail.Total
                                },
                                Comment = getoperationlog.Comment
                            },
                            FinancialReporting = new FinancialIMBusinessRatingReq  
                            {
                                ARMIM = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceARMIMrating.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceARMIMrating.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceARMIMrating.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceARMIMrating.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceARMIMrating.TAT,

                                    ErrororControlRisk = getfinanceARMIMrating.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceARMIMrating.TheftorFraudRisk,

                                    Total = getfinanceARMIMrating.Total
                                },
                                IMUnit = new FinacialIMBusinessRatingReq
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
                                Research = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceResearch.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceResearch.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceResearch.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceResearch.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceResearch.TAT,

                                    ErrororControlRisk = getfinanceResearch.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceResearch.TheftorFraudRisk,

                                    Total = getfinanceResearch.Total
                                },
                                OperationSettlement = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceOpSettle.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceOpSettle.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceOpSettle.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceOpSettle.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceOpSettle.TAT,

                                    ErrororControlRisk = getfinanceOpSettle.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceOpSettle.TheftorFraudRisk,

                                    Total = getfinanceOpSettle.Total
                                },
                                ARMRegistrar = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceRegis.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceRegis.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceRegis.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceRegis.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceRegis.TAT,

                                    ErrororControlRisk = getfinanceRegis.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceRegis.TheftorFraudRisk,

                                    Total = getfinanceRegis.Total
                                },
                                BDPWMIAMIMRetail = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceBD.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceBD.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceBD.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceBD.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceBD.TAT,

                                    ErrororControlRisk = getfinanceBD.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceBD.TheftorFraudRisk,

                                    Total = getfinanceBD.Total
                                },
                                FundAccount = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceFundAcct.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceFundAcct.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceFundAcct.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceFundAcct.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceFundAcct.TAT,

                                    ErrororControlRisk = getfinanceFundAcct.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceFundAcct.TheftorFraudRisk,

                                    Total = getfinanceFundAcct.Total
                                },
                                FundAdmin = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceFundAd.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceFundAd.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceFundAd.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceFundAd.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceFundAd.TAT,

                                    ErrororControlRisk = getfinanceFundAd.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceFundAd.TheftorFraudRisk,

                                    Total = getfinanceFundAd.Total
                                },
                                OperationControl = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceRetailOp.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceRetailOp.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceRetailOp.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceRetailOp.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceRetailOp.TAT,

                                    ErrororControlRisk = getfinanceRetailOp.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceRetailOp.TheftorFraudRisk,

                                    Total = getfinanceRetailOp.Total
                                },
                                RetailOperation = new FinacialIMBusinessRatingReq
                                {
                                    IncomeAssuranceRisk = getfinanceRetailOp.IncomeAssuranceRisk,

                                    StatutoryDeductionsandTaxes = getfinanceRetailOp.StatutoryDeductionsandTaxes,

                                    AdherencetoFinancialStandards = getfinanceRetailOp.AdherencetoFinancialStandards,

                                    AdoptionandImplementationofPoliciesAdherence = getfinanceRetailOp.AdoptionandImplementationofPoliciesAdherence,

                                    TAT = getfinanceRetailOp.TAT,

                                    ErrororControlRisk = getfinanceRetailOp.ErrororControlRisk,

                                    TheftorFraudRisk = getfinanceRetailOp.TheftorFraudRisk,

                                    Total = getfinanceRetailOp.Total
                                },
                                Comment = getfinancelog.Comment
                            },
                            Compliance = new ComplianceIMBusinessRatingReq
                            {
                                ARMIM = new ComplianceIMRatingReq
                                {
                                    AMLCFT = getcomplianceARMIMlog.AMLCFT,
                                    LitigationRisk = getcomplianceARMIMlog.LitigationRisk,
                                    ChangingRegulations = getcomplianceARMIMlog.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceARMIMlog.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceARMIMlog.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceARMIMlog.KYCChecks,
                                    GDPROrNDPR = getcomplianceARMIMlog.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceARMIMlog.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceARMIMlog.DisclosureRisk,
                                    CorporateGovernance = getcomplianceARMIMlog.CorporateGovernance,
                                    TAT = getcomplianceARMIMlog.TAT,
                                    Total = getcomplianceARMIMlog.Total
                                },
                                IMUnit = new ComplianceIMRatingReq
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
                                OperationControl = new ComplianceIMRatingReq
                                {
                                    AMLCFT = getcomplianceOpCtrl.AMLCFT,
                                    LitigationRisk = getcomplianceOpCtrl.LitigationRisk,
                                    ChangingRegulations = getcomplianceOpCtrl.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceOpCtrl.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceOpCtrl.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceOpCtrl.KYCChecks,
                                    GDPROrNDPR = getcomplianceOpCtrl.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceOpCtrl.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceOpCtrl.DisclosureRisk,
                                    CorporateGovernance = getcomplianceOpCtrl.CorporateGovernance,
                                    TAT = getcomplianceOpCtrl.TAT,
                                    Total = getcomplianceOpCtrl.Total
                                },
                                OperationSettlement = new ComplianceIMRatingReq
                                {
                                    AMLCFT = getcomplianceOpSettl.AMLCFT,
                                    LitigationRisk = getcomplianceOpSettl.LitigationRisk,
                                    ChangingRegulations = getcomplianceOpSettl.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceOpSettl.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceOpSettl.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceOpSettl.KYCChecks,
                                    GDPROrNDPR = getcomplianceOpSettl.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceOpSettl.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceOpSettl.DisclosureRisk,
                                    CorporateGovernance = getcomplianceOpSettl.CorporateGovernance,
                                    TAT = getcomplianceOpSettl.TAT,
                                    Total = getcomplianceOpSettl.Total
                                },
                                ARMRegistrar = new ComplianceIMRatingReq
                                {
                                    AMLCFT = getcomplianceRegis.AMLCFT,
                                    LitigationRisk = getcomplianceRegis.LitigationRisk,
                                    ChangingRegulations = getcomplianceRegis.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceRegis.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceRegis.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceRegis.KYCChecks,
                                    GDPROrNDPR = getcomplianceRegis.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceRegis.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceRegis.DisclosureRisk,
                                    CorporateGovernance = getcomplianceRegis.CorporateGovernance,
                                    TAT = getcomplianceRegis.TAT,
                                    Total = getcomplianceRegis.Total
                                },
                                BDPWMIAMIMRetail = new ComplianceIMRatingReq
                                {
                                    AMLCFT = getcomplianceBD.AMLCFT,
                                    LitigationRisk = getcomplianceBD.LitigationRisk,
                                    ChangingRegulations = getcomplianceBD.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceBD.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceBD.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceBD.KYCChecks,
                                    GDPROrNDPR = getcomplianceBD.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceBD.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceBD.DisclosureRisk,
                                    CorporateGovernance = getcomplianceBD.CorporateGovernance,
                                    TAT = getcomplianceBD.TAT,
                                    Total = getcomplianceBD.Total
                                },
                                FundAccount = new ComplianceIMRatingReq
                                {
                                    AMLCFT = getcomplianceFundAcct.AMLCFT,
                                    LitigationRisk = getcomplianceFundAcct.LitigationRisk,
                                    ChangingRegulations = getcomplianceFundAcct.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceFundAcct.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceFundAcct.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceFundAcct.KYCChecks,
                                    GDPROrNDPR = getcomplianceFundAcct.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceFundAcct.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceFundAcct.DisclosureRisk,
                                    CorporateGovernance = getcomplianceFundAcct.CorporateGovernance,
                                    TAT = getcomplianceFundAcct.TAT,
                                    Total = getcomplianceFundAcct.Total
                                },
                                FundAdmin = new ComplianceIMRatingReq 
                                {
                                    AMLCFT = getcomplianceFundAd.AMLCFT,
                                    LitigationRisk = getcomplianceFundAd.LitigationRisk,
                                    ChangingRegulations = getcomplianceFundAd.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceFundAd.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceFundAd.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceFundAd.KYCChecks,
                                    GDPROrNDPR = getcomplianceFundAd.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceFundAd.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceFundAd.DisclosureRisk,
                                    CorporateGovernance = getcomplianceFundAd.CorporateGovernance,
                                    TAT = getcomplianceFundAd.TAT,
                                    Total = getcomplianceFundAd.Total
                                },
                                Research = new ComplianceIMRatingReq
                                {
                                    AMLCFT = getcomplianceResearch.AMLCFT,
                                    LitigationRisk = getcomplianceResearch.LitigationRisk,
                                    ChangingRegulations = getcomplianceResearch.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceResearch.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceResearch.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceResearch.KYCChecks,
                                    GDPROrNDPR = getcomplianceResearch.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceResearch.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceResearch.DisclosureRisk,
                                    CorporateGovernance = getcomplianceResearch.CorporateGovernance,
                                    TAT = getcomplianceResearch.TAT,
                                    Total = getcomplianceResearch.Total
                                },
                                RetailOperation = new ComplianceIMRatingReq
                                {
                                    AMLCFT = getcomplianceReatilOp.AMLCFT,
                                    LitigationRisk = getcomplianceReatilOp.LitigationRisk,
                                    ChangingRegulations = getcomplianceReatilOp.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceReatilOp.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceReatilOp.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceReatilOp.KYCChecks,
                                    GDPROrNDPR = getcomplianceReatilOp.GDPROrNDPR,
                                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = getcomplianceReatilOp.AdoptionandIimplementationOfPoliciesandAdherenceToProcesses,
                                    DisclosureRisk = getcomplianceReatilOp.DisclosureRisk,
                                    CorporateGovernance = getcomplianceReatilOp.CorporateGovernance,
                                    TAT = getcomplianceReatilOp.TAT,
                                    Total = getcomplianceReatilOp.Total
                                },
                                Comment = getcomplianceRating.Comment
                            },
                            LastReportOverallRating = new TimeSinceLastAuditIMBusinessRatingReq
                            {
                                ARMIM = gettimesinceaudit.ARMIM,
                                IMUnit = gettimesinceaudit.IMUnit,
                                ARMRegistrar = gettimesinceaudit.ARMRegistrar,
                                OperationSettlement = gettimesinceaudit.OperationSettlement,
                                BDPWMIAMIMRetail = gettimesinceaudit.BDPWMIAMIMRetail,
                                FundAccount = gettimesinceaudit.FundAccount,
                                FundAdmin = gettimesinceaudit.FundAdmin,
                                OperationControl = gettimesinceaudit.OperationControl,
                                RetailOperation = gettimesinceaudit.RetailOperation,
                                Research = gettimesinceaudit.Research,
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
