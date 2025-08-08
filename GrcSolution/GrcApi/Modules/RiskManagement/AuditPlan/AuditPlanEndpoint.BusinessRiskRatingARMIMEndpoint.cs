using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 10/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint allow Internal Audit officer perform risk rating on the business entities
*/
    public class BusinessRiskRatingARMIMEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARMIM business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armIM"></param>
        /// <param name="strategy"></param>
        /// <param name="straOperation"></param>
        /// <param name="straOperationsett"></param>
        /// <param name="straregstrar"></param>
        /// <param name="strategyOpration"></param>
        /// <param name="straFundadmin"></param>
        /// <param name="strategyFundAcct"></param>
        /// <param name="strategyResearch"></param>
        /// <param name="straBD"></param>
        /// <param name="strategyARMIM"></param>
        /// <param name="strategyARMIMRating"></param>
        /// <param name="operation"></param>
        /// <param name="operBD"></param>
        /// <param name="operFinancialAcct"></param>
        /// <param name="operFundAdmin"></param>
        /// <param name="operationRetail"></param>
        /// <param name="operRegis"></param>
        /// <param name="operSettle"></param>
        /// <param name="operControl"></param>
        /// <param name="operResearch"></param>
        /// <param name="operationIM"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="operationARMIM"></param>
        /// <param name="finance"></param>
        /// <param name="financeOp"></param>
        /// <param name="financeOpSettle"></param>
        /// <param name="financeRegis"></param>
        /// <param name="financeRetailOp"></param>
        /// <param name="financeARMIM"></param>
        /// <param name="financeResearch"></param>
        /// <param name="financeFundAd"></param>
        /// <param name="financeFundAcct"></param>
        /// <param name="financeBD"></param>
        /// <param name="financeIM"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceOpCtrl"></param>
        /// <param name="complianceOpSettl"></param>
        /// <param name="complianceRegis"></param>
        /// <param name="complianceReatilOp"></param>
        /// <param name="complianceFundAd"></param>
        /// <param name="complianceFundAcct"></param>
        /// <param name="complianceBD"></param>
        /// <param name="complianceARMIM"></param>
        /// <param name="complianceResearch"></param>
        /// <param name="complianceIM"></param>
        /// <param name="timeSinceLastAuditIM"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMIMRequest request, IRepository<BusinessRiskRating> busnessRiskRating,

            IRepository<ARMIMBusinessRiskRating> armIM, IRepository<StrategyImBusinessRating> strategy, IRepository<StrategyIMRatingOperationControl> straOperation,
            IRepository<StrategyIMRatingOperationSettlement> straOperationsett, IRepository<StrategyIMRatingARMRegistrar> straregstrar, IRepository<StrategyIMRatingRetailOperation> strategyOpration,
            IRepository<StrategyIMRatingFundAdmin> straFundadmin, IRepository<StrategyIMRatingFundAccount> strategyFundAcct, IRepository<StrategyIMRatingResearch> strategyResearch,
            IRepository<StrategyIMRatingBDPWMIAMIMRetail> straBD, IRepository<StrategyIMRating> strategyARMIM, IRepository<StrategyIMRatingARMIM> strategyARMIMRating,
           
            IRepository<OperationIMBusinessRating> operation, IRepository<OperationIMRatingBDPWMIAMIMRetail> operBD, IRepository<OperationIMRatingFundAccount> operFinancialAcct,
            IRepository<OperationIMRatingFundAdmin> operFundAdmin, IRepository<OperationIMRatingRetailOperation> operationRetail, IRepository<OperationIMRatingARMRegistrar> operRegis,
            IRepository<OperationIMRatingOperationSettlement> operSettle, IRepository<OperationIMRatingOperationControl> operControl, IRepository<OperationIMRatingResearch> operResearch,
            IRepository<OperationIMUnitRating> operationIM, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating, IRepository<OperationARMIMRating> operationARMIM,

            IRepository<FinancialIMBusinessRating> finance, IRepository<FinacialIMRatingOperationControl> financeOp, IRepository<FinacialIMRatingOperationSettlement> financeOpSettle,
            IRepository<FinacialIMRatingARMRegistrar> financeRegis, IRepository<FinacialIMRatingRetailOperation> financeRetailOp, IRepository<FinacialARMIMRating> financeARMIM, IRepository<FinacialIMRatingResearch> financeResearch,
            IRepository<FinacialIMRatingFundAdmin> financeFundAd, IRepository<FinacialIMRatingFundAccount> financeFundAcct, IRepository<FinacialIMRatingBDPWMIAMIMRetail> financeBD, IRepository<FinacialIMBusinessRating> financeIM,

            IRepository<ComplianceIMBusinessRating> compliance, IRepository<ComplianceIMRatingOperationControl> complianceOpCtrl, IRepository<ComplianceIMRatingOperationSettlement> complianceOpSettl,
            IRepository<ComplianceIMRatingARMRegistrar> complianceRegis, IRepository<ComplianceIMRatingRetailOperation> complianceReatilOp, IRepository<ComplianceIMRatingFundAdmin> complianceFundAd,
            IRepository<ComplianceIMRatingFundAccount> complianceFundAcct, IRepository<ComplianceIMRatingBDPWMIAMIMRetail> complianceBD, IRepository<ComplianceIMRatingARMIM> complianceARMIM,
            IRepository<ComplianceIMRatingResearch> complianceResearch, IRepository<ComplianceIMRating> complianceIM, IRepository<TimeSinceLastAuditIMBusinessRating> timeSinceLastAuditIM,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                //get the id by the requester email
                //var year = DateTime.Now.Year;
                var getByEmail = armIM.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARMIM for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    var armIMLog = ARMIMBusinessRiskRating.Create(getUser.Id, request.ARMIM.Status, requesterName);
                    await armIM.AddAsync(armIMLog);

                    var strategyLog = StrategyImBusinessRating.Create(armIMLog.Id, request.ARMIM.Strategy.Comment);
                    await strategy.AddAsync(strategyLog);                 

                    var strategyARMIMRatingLog = StrategyIMRatingARMIM.Create(strategyLog.Id, request.ARMIM);
                    await strategyARMIMRating.AddAsync(strategyARMIMRatingLog);

                    var strategyARMIMLog = StrategyIMRating.Create(strategyLog.Id, request.ARMIM);
                    await strategyARMIM.AddAsync(strategyARMIMLog);

                    var straOperationLog = StrategyIMRatingOperationControl.Create(strategyLog.Id, request.ARMIM);
                    await straOperation.AddAsync(straOperationLog);

                    var strategyResearchLog = StrategyIMRatingResearch.Create(strategyLog.Id, request.ARMIM);
                    await strategyResearch.AddAsync(strategyResearchLog);

                    var straOperationsettLog = StrategyIMRatingOperationSettlement.Create(strategyLog.Id, request.ARMIM);
                    await straOperationsett.AddAsync(straOperationsettLog);

                    var straregstrarLog = StrategyIMRatingARMRegistrar.Create(strategyLog.Id, request.ARMIM);
                    await straregstrar.AddAsync(straregstrarLog);

                    var strategyOprationLog = StrategyIMRatingRetailOperation.Create(strategyLog.Id, request.ARMIM);
                    await strategyOpration.AddAsync(strategyOprationLog);

                    var straFundadminLog = StrategyIMRatingFundAdmin.Create(strategyLog.Id, request.ARMIM);
                    await straFundadmin.AddAsync(straFundadminLog);

                    var strategyFundAcctLog = StrategyIMRatingFundAccount.Create(strategyLog.Id, request.ARMIM);
                    await strategyFundAcct.AddAsync(strategyFundAcctLog);

                    var straBDLog = StrategyIMRatingBDPWMIAMIMRetail.Create(strategyLog.Id, request.ARMIM);
                    await straBD.AddAsync(straBDLog);

                    var operationLog = OperationIMBusinessRating.Create(armIMLog.Id, request.ARMIM.Operations.Comment);
                    await operation.AddAsync(operationLog);

                    var operationARMIMLog = OperationARMIMRating.Create(operationLog.Id, request.ARMIM);
                    await operationARMIM.AddAsync(operationARMIMLog);

                    var operResearchLog = OperationIMRatingResearch.Create(operationLog.Id, request.ARMIM);
                    await operResearch.AddAsync(operResearchLog); 

                    var operBDLog = OperationIMRatingBDPWMIAMIMRetail.Create(operationLog.Id, request.ARMIM);
                    await operBD.AddAsync(operBDLog);

                    var operFinancialAcctLog = OperationIMRatingFundAccount.Create(operationLog.Id, request.ARMIM);
                    await operFinancialAcct.AddAsync(operFinancialAcctLog);

                    var operFundAdminLog = OperationIMRatingFundAdmin.Create(operationLog.Id, request.ARMIM);
                    await operFundAdmin.AddAsync(operFundAdminLog);

                    var operationRetailLog = OperationIMRatingRetailOperation.Create(operationLog.Id, request.ARMIM);
                    await operationRetail.AddAsync(operationRetailLog);

                    var operRegisLog = OperationIMRatingARMRegistrar.Create(operationLog.Id, request.ARMIM);
                    await operRegis.AddAsync(operRegisLog);

                    var operSettleLog = OperationIMRatingOperationSettlement.Create(operationLog.Id, request.ARMIM);
                    await operSettle.AddAsync(operSettleLog);

                    var operControlOlg = OperationIMRatingOperationControl.Create(operationLog.Id, request.ARMIM);
                    await operControl.AddAsync(operControlOlg);

                    var operationIMLog = OperationIMUnitRating.Create(operationLog.Id, request.ARMIM);
                    await operationIM.AddAsync(operationIMLog);                                        

                    var financeLog = FinancialIMBusinessRating.Create(armIMLog.Id, request.ARMIM.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog);

                    var financeARMIMLog = FinacialARMIMRating.Create(financeLog.Id, request.ARMIM);
                    await financeARMIM.AddAsync(financeARMIMLog);

                    var financeOpLog = FinacialIMRatingOperationControl.Create(financeLog.Id, request.ARMIM);
                    await financeOp.AddAsync(financeOpLog);

                    var financeOpSettleLog = FinacialIMRatingOperationSettlement.Create(financeLog.Id, request.ARMIM);
                    await financeOpSettle.AddAsync(financeOpSettleLog);

                    var financeResearchLog = FinacialIMRatingResearch.Create(financeLog.Id, request.ARMIM);
                    await financeResearch.AddAsync(financeResearchLog);  

                    var financeRegisLog = FinacialIMRatingARMRegistrar.Create(financeLog.Id, request.ARMIM);
                    await financeRegis.AddAsync(financeRegisLog);

                    var financeRetailOpLog = FinacialIMRatingRetailOperation.Create(financeLog.Id, request.ARMIM);
                    await financeRetailOp.AddAsync(financeRetailOpLog);

                    var financeFundAdLog = FinacialIMRatingFundAdmin.Create(financeLog.Id, request.ARMIM);
                    await financeFundAd.AddAsync(financeFundAdLog);

                    var financeFundAcctLog = FinacialIMRatingFundAccount.Create(financeLog.Id, request.ARMIM);
                    await financeFundAcct.AddAsync(financeFundAcctLog);

                    var financeBDLog = FinacialIMRatingBDPWMIAMIMRetail.Create(financeLog.Id, request.ARMIM);
                    await financeBD.AddAsync(financeBDLog);

                    var financeIMLog = FinacialIMBusinessRating.Create(financeLog.Id, request.ARMIM);
                    await financeIM.AddAsync(financeIMLog);

                    var complianceLog = ComplianceIMBusinessRating.Create(armIMLog.Id, request.ARMIM.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);  

                    var complianceARMIMLog = ComplianceIMRatingARMIM.Create(complianceLog.Id, request.ARMIM);
                    await complianceARMIM.AddAsync(complianceARMIMLog);

                    var complianceOpCtrlLog = ComplianceIMRatingOperationControl.Create(complianceLog.Id, request.ARMIM);
                    await complianceOpCtrl.AddAsync(complianceOpCtrlLog);

                    var complianceOpSettlLog = ComplianceIMRatingOperationSettlement.Create(complianceLog.Id, request.ARMIM);
                    await complianceOpSettl.AddAsync(complianceOpSettlLog);

                    var complianceRegisLog = ComplianceIMRatingARMRegistrar.Create(complianceLog.Id, request.ARMIM);
                    await complianceRegis.AddAsync(complianceRegisLog);

                    var complianceReatilOpLog = ComplianceIMRatingRetailOperation.Create(complianceLog.Id, request.ARMIM);
                    await complianceReatilOp.AddAsync(complianceReatilOpLog);

                    var complianceFundAdLog = ComplianceIMRatingFundAdmin.Create(complianceLog.Id, request.ARMIM);
                    await complianceFundAd.AddAsync(complianceFundAdLog);

                    var complianceFundAcctLog = ComplianceIMRatingFundAccount.Create(complianceLog.Id, request.ARMIM);
                    await complianceFundAcct.AddAsync(complianceFundAcctLog);

                    var complianceBDLog = ComplianceIMRatingBDPWMIAMIMRetail.Create(complianceLog.Id, request.ARMIM);
                    await complianceBD.AddAsync(complianceBDLog);

                    var complianceResearchLog = ComplianceIMRatingResearch.Create(complianceLog.Id, request.ARMIM);
                    await complianceResearch.AddAsync(complianceResearchLog);  

                    var complianceIMLog = ComplianceIMRating.Create(complianceLog.Id, request.ARMIM);
                    await complianceIM.AddAsync(complianceIMLog);

                    var timeSinceLastAuditIMLog = TimeSinceLastAuditIMBusinessRating.Create(armIMLog.Id, request.ARMIM);
                    await timeSinceLastAuditIM.AddAsync(timeSinceLastAuditIMLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMIM", requesterName, request.ARMIM.Status);
                    await ratedBusinessRiskRating.AddAsync(logratedBusinessRiskRating);
                    await ratedBusinessRiskRating.SaveChangesAsync();

                    BusinessRiskRatingResponse response = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = getUser.Id
                    };

                    return TypedResults.Created($"apra/{response}", response);
                }

                if (getUser == null)
                {
                    var logRequest = BusinessRiskRating.Create(requesterName);
                    await busnessRiskRating.AddAsync(logRequest);

                    var armIMLog2 = ARMIMBusinessRiskRating.Create(logRequest.Id, request.ARMIM.Status, requesterName);
                    await armIM.AddAsync(armIMLog2);                   

                    var strategyLog2 = StrategyImBusinessRating.Create(armIMLog2.Id, request.ARMIM.Strategy.Comment);
                    await strategy.AddAsync(strategyLog2);

                    var strategyARMIMRatingLog2 = StrategyIMRatingARMIM.Create(strategyLog2.Id, request.ARMIM);
                    await strategyARMIMRating.AddAsync(strategyARMIMRatingLog2);

                    var strategyARMIMLog2 = StrategyIMRating.Create(strategyLog2.Id, request.ARMIM);
                    await strategyARMIM.AddAsync(strategyARMIMLog2);

                    var straOperationLog2 = StrategyIMRatingOperationControl.Create(strategyLog2.Id, request.ARMIM);
                    await straOperation.AddAsync(straOperationLog2);

                    var straOperationsettLog2 = StrategyIMRatingOperationSettlement.Create(strategyLog2.Id, request.ARMIM);
                    await straOperationsett.AddAsync(straOperationsettLog2);

                    var strategyResearchLog2 = StrategyIMRatingResearch.Create(strategyLog2.Id, request.ARMIM);
                    await strategyResearch.AddAsync(strategyResearchLog2);

                    var straregstrarLog2 = StrategyIMRatingARMRegistrar.Create(strategyLog2.Id, request.ARMIM);
                    await straregstrar.AddAsync(straregstrarLog2);

                    var strategyOprationLog2 = StrategyIMRatingRetailOperation.Create(strategyLog2.Id, request.ARMIM);
                    await strategyOpration.AddAsync(strategyOprationLog2);

                    var straFundadminLog2 = StrategyIMRatingFundAdmin.Create(strategyLog2.Id, request.ARMIM);
                    await straFundadmin.AddAsync(straFundadminLog2);

                    var strategyFundAcctLog2 = StrategyIMRatingFundAccount.Create(strategyLog2.Id, request.ARMIM);
                    await strategyFundAcct.AddAsync(strategyFundAcctLog2);

                    var straBDLog2 = StrategyIMRatingBDPWMIAMIMRetail.Create(strategyLog2.Id, request.ARMIM);
                    await straBD.AddAsync(straBDLog2);

                    var operationLog2 = OperationIMBusinessRating.Create(armIMLog2.Id, request.ARMIM.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operationARMIMLog2 = OperationARMIMRating.Create(operationLog2.Id, request.ARMIM);
                    await operationARMIM.AddAsync(operationARMIMLog2);

                    var operBDLog2 = OperationIMRatingBDPWMIAMIMRetail.Create(operationLog2.Id, request.ARMIM);
                    await operBD.AddAsync(operBDLog2);

                    var operResearchLog2 = OperationIMRatingResearch.Create(operationLog2.Id, request.ARMIM);
                    await operResearch.AddAsync(operResearchLog2);

                    var operFinancialAcctLog2 = OperationIMRatingFundAccount.Create(operationLog2.Id, request.ARMIM);
                    await operFinancialAcct.AddAsync(operFinancialAcctLog2);

                    var operFundAdminLog2 = OperationIMRatingFundAdmin.Create(operationLog2.Id, request.ARMIM);
                    await operFundAdmin.AddAsync(operFundAdminLog2);

                    var operationRetailLog2 = OperationIMRatingRetailOperation.Create(operationLog2.Id, request.ARMIM);
                    await operationRetail.AddAsync(operationRetailLog2);

                    var operRegisLog2 = OperationIMRatingARMRegistrar.Create(operationLog2.Id, request.ARMIM);
                    await operRegis.AddAsync(operRegisLog2);

                    var operSettleLog2 = OperationIMRatingOperationSettlement.Create(operationLog2.Id, request.ARMIM);
                    await operSettle.AddAsync(operSettleLog2);

                    var operControlOlg2 = OperationIMRatingOperationControl.Create(operationLog2.Id, request.ARMIM);
                    await operControl.AddAsync(operControlOlg2);

                    var operationIMLog2 = OperationIMUnitRating.Create(operationLog2.Id, request.ARMIM);
                    await operationIM.AddAsync(operationIMLog2);

                    var financeLog2 = FinancialIMBusinessRating.Create(armIMLog2.Id, request.ARMIM.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog2);

                    var financeARMIMLog2 = FinacialARMIMRating.Create(financeLog2.Id, request.ARMIM);
                    await financeARMIM.AddAsync(financeARMIMLog2);

                    var financeOpLog2 = FinacialIMRatingOperationControl.Create(financeLog2.Id, request.ARMIM);
                    await financeOp.AddAsync(financeOpLog2);

                    var financeOpSettleLog2 = FinacialIMRatingOperationSettlement.Create(financeLog2.Id, request.ARMIM);
                    await financeOpSettle.AddAsync(financeOpSettleLog2);

                    var financeRegisLog2 = FinacialIMRatingARMRegistrar.Create(financeLog2.Id, request.ARMIM);
                    await financeRegis.AddAsync(financeRegisLog2);

                    var financeResearchLog2 = FinacialIMRatingResearch.Create(financeLog2.Id, request.ARMIM);
                    await financeResearch.AddAsync(financeResearchLog2);

                    var financeRetailOpLog2 = FinacialIMRatingRetailOperation.Create(financeLog2.Id, request.ARMIM);
                    await financeRetailOp.AddAsync(financeRetailOpLog2);

                    var financeFundAdLog2 = FinacialIMRatingFundAdmin.Create(financeLog2.Id, request.ARMIM);
                    await financeFundAd.AddAsync(financeFundAdLog2);

                    var financeFundAcctLog2 = FinacialIMRatingFundAccount.Create(financeLog2.Id, request.ARMIM);
                    await financeFundAcct.AddAsync(financeFundAcctLog2);

                    var financeBDLog2 = FinacialIMRatingBDPWMIAMIMRetail.Create(financeLog2.Id, request.ARMIM);
                    await financeBD.AddAsync(financeBDLog2);

                    var financeIMLog2 = FinacialIMBusinessRating.Create(financeLog2.Id, request.ARMIM);
                    await financeIM.AddAsync(financeIMLog2);

                    var complianceLog2 = ComplianceIMBusinessRating.Create(armIMLog2.Id, request.ARMIM.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var complianceARMIMLog2 = ComplianceIMRatingARMIM.Create(complianceLog2.Id, request.ARMIM);
                    await complianceARMIM.AddAsync(complianceARMIMLog2);

                    var complianceOpCtrlLog2 = ComplianceIMRatingOperationControl.Create(complianceLog2.Id, request.ARMIM);
                    await complianceOpCtrl.AddAsync(complianceOpCtrlLog2);

                    var complianceOpSettlLog2 = ComplianceIMRatingOperationSettlement.Create(complianceLog2.Id, request.ARMIM);
                    await complianceOpSettl.AddAsync(complianceOpSettlLog2);

                    var complianceRegisLog2 = ComplianceIMRatingARMRegistrar.Create(complianceLog2.Id, request.ARMIM);
                    await complianceRegis.AddAsync(complianceRegisLog2);

                    var complianceReatilOpLog2 = ComplianceIMRatingRetailOperation.Create(complianceLog2.Id, request.ARMIM);
                    await complianceReatilOp.AddAsync(complianceReatilOpLog2);

                    var complianceFundAdLog2 = ComplianceIMRatingFundAdmin.Create(complianceLog2.Id, request.ARMIM);
                    await complianceFundAd.AddAsync(complianceFundAdLog2);

                    var complianceFundAcctLog2 = ComplianceIMRatingFundAccount.Create(complianceLog2.Id, request.ARMIM);
                    await complianceFundAcct.AddAsync(complianceFundAcctLog2);

                    var complianceBDLog2 = ComplianceIMRatingBDPWMIAMIMRetail.Create(complianceLog2.Id, request.ARMIM);
                    await complianceBD.AddAsync(complianceBDLog2);

                    var complianceResearchLog2 = ComplianceIMRatingResearch.Create(complianceLog2.Id, request.ARMIM);
                    await complianceResearch.AddAsync(complianceResearchLog2);

                    var complianceIMLog2 = ComplianceIMRating.Create(complianceLog2.Id, request.ARMIM);
                    await complianceIM.AddAsync(complianceIMLog2);

                    var timeSinceLastAuditIMLog2 = TimeSinceLastAuditIMBusinessRating.Create(armIMLog2.Id, request.ARMIM);
                    await timeSinceLastAuditIM.AddAsync(timeSinceLastAuditIMLog2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMIM", requesterName, request.ARMIM.Status);
                    await ratedBusinessRiskRating.AddAsync(logratedBusinessRiskRating2);
                    await ratedBusinessRiskRating.SaveChangesAsync();

                    BusinessRiskRatingResponse response = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = logRequest.Id
                    };

                    return TypedResults.Created($"apra/{response}", response);
                }
                return TypedResults.BadRequest("Unable to submit the request");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
