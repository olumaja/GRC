using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 20/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* Endpoint to approve business risk rating
*/
    public class ApproveARMIMBusinessRiskRatingEndpoint
    {
        /// <summary>
        /// Endpoint to approve armIM business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="armIMReq"></param>
        /// <param name="repo"></param>
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
        /// <param name="strategyARMIMRate"></param>
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
        /// <param name="financeResearch"></param>
        /// <param name="financeRegis"></param>
        /// <param name="financeRetailOp"></param>
        /// <param name="financeARMIM"></param>
        /// <param name="financeFundAd"></param>
        /// <param name="financeFundAcct"></param>
        /// <param name="financeBD"></param>
        /// <param name="financeIM"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceOpCtrl"></param>
        /// <param name="complianceOpSettl"></param>
        /// <param name="complianceRegis"></param>
        /// <param name="complianceBD"></param>
        /// <param name="compARMIM"></param>
        /// <param name="complianceReatilOp"></param>
        /// <param name="complianceFundAd"></param>
        /// <param name="complianceResearch"></param>
        /// <param name="complianceFundAcct"></param>
        /// <param name="complianceIM"></param>
        /// <param name="timeSinceLastAuditIM"></param>
        /// <param name="emcRating"></param>
        /// <param name="armIMEMCRating"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="mgtARMIM"></param>
        /// <param name="mgtARMIMRatingbusiness"></param>
        /// <param name="mgtARMIMRatingservice"></param>
        /// <param name="annualaudit"></param>
        /// <param name="armimannual"></param>
        /// <param name="imaudit"></param>
        /// <param name="bdRetailAudit"></param>
        /// <param name="registrarAudit"></param>
        /// <param name="fundAcctAudit"></param>
        /// <param name="operationSettlementAudit"></param>
        /// <param name="fundAdminAudit"></param>
        /// <param name="retailOperationaudit"></param>
        /// <param name="researchaudit"></param>
        /// <param name="operationControlaudit"></param>
        /// <param name="armImAnnualAudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, [FromBody] ARMIMBusinessRiskRatingReq armIMReq, IRepository<ARMIMBusinessRiskRating> repo,
            IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMIMBusinessRiskRating> armIM, IRepository<StrategyImBusinessRating> strategy, IRepository<StrategyIMRatingOperationControl> straOperation,
            IRepository<StrategyIMRatingOperationSettlement> straOperationsett, IRepository<StrategyIMRatingARMRegistrar> straregstrar, IRepository<StrategyIMRatingRetailOperation> strategyOpration,
            IRepository<StrategyIMRatingFundAdmin> straFundadmin, IRepository<StrategyIMRatingFundAccount> strategyFundAcct, IRepository<StrategyIMRatingResearch> strategyResearch,
            IRepository<StrategyIMRatingBDPWMIAMIMRetail> straBD, IRepository<StrategyIMRating> strategyARMIM, IRepository<StrategyIMRatingARMIM> strategyARMIMRate,

            IRepository<OperationIMBusinessRating> operation, IRepository<OperationIMRatingBDPWMIAMIMRetail> operBD, IRepository<OperationIMRatingFundAccount> operFinancialAcct,
            IRepository<OperationIMRatingFundAdmin> operFundAdmin, IRepository<OperationIMRatingRetailOperation> operationRetail, IRepository<OperationIMRatingARMRegistrar> operRegis,
            IRepository<OperationIMRatingOperationSettlement> operSettle, IRepository<OperationIMRatingOperationControl> operControl,
            IRepository<OperationIMUnitRating> operationIM, IRepository<OperationIMUnitRating> operationARMIM, IRepository<OperationIMRatingResearch> operationResearch,

            IRepository<FinancialIMBusinessRating> finance, IRepository<FinacialIMRatingOperationControl> financeOp, IRepository<FinacialIMRatingOperationSettlement> financeOpSettle, IRepository<FinacialIMRatingResearch> financeResearch,
            IRepository<FinacialIMRatingARMRegistrar> financeRegis, IRepository<FinacialIMRatingRetailOperation> financeRetailOp, IRepository<FinacialARMIMRating> financeARMIM,
            IRepository<FinacialIMRatingFundAdmin> financeFundAd, IRepository<FinacialIMRatingFundAccount> financeFundAcct, IRepository<FinacialIMRatingBDPWMIAMIMRetail> financeBD, IRepository<FinacialIMBusinessRating> financeIM,

            IRepository<ComplianceIMBusinessRating> compliance, IRepository<ComplianceIMRatingOperationControl> complianceOpCtrl, IRepository<ComplianceIMRatingOperationSettlement> complianceOpSettl,
            IRepository<ComplianceIMRatingARMRegistrar> complianceRegis, IRepository<ComplianceIMRatingBDPWMIAMIMRetail> complianceBD, IRepository<ComplianceIMRatingARMIM> compARMIM,
            IRepository<ComplianceIMRatingRetailOperation> complianceReatilOp, IRepository<ComplianceIMRatingFundAdmin> complianceFundAd, IRepository<ComplianceIMRatingResearch> complianceResearch,
            IRepository<ComplianceIMRatingFundAccount> complianceFundAcct, IRepository<ComplianceIMRating> complianceIM, IRepository<TimeSinceLastAuditIMBusinessRating> timeSinceLastAuditIM,
            IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMIMEMCRating> armIMEMCRating,
            IRepository<ManagementConcernRiskRating> managementConcernRating, IRepository<ManagementConcernARMIM> mgtARMIM, IRepository<ManagementConcernBusinessUnitARMIMRating> mgtARMIMRatingbusiness, IRepository<ManagementConcernSharedServiceARMIMRating> mgtARMIMRatingservice,

            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMIMAuditUniverse> armimannual, IRepository<AuditUniverseARMIMIMUnit> imaudit, IRepository<AuditUniverseARMIMBDPWMIAMIMRetail> bdRetailAudit,
            IRepository<AuditUniverseARMIMRegistrar> registrarAudit, IRepository<AuditUniverseARMIMFundAccount> fundAcctAudit, IRepository<AuditUniverseARMIMOperationSettlement> operationSettlementAudit,
            IRepository<AuditUniverseARMIMFundAdmin> fundAdminAudit, IRepository<AuditUniverseARMIMRetailOperation> retailOperationaudit, IRepository<AuditUniverseARMIMResearch> researchaudit,
            IRepository<AuditUniverseARMIMOperationControl> operationControlaudit, IRepository<AuditUniverseARMIMRating> armImAnnualAudit,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }

                var getBusinessRiskRating = repo.GetContextByConditon(c => c.BusinessRiskRatingId == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getBusinessRiskRating == null) { return TypedResults.NotFound("The record has been previouly approved"); }
                var getRating = busnessRiskRating.GetContextByConditon(x => x.Id == businessriskratingId).FirstOrDefault();
                var businesses = await armIM.GetAllAsync();
                if (getRating == null) { return TypedResults.NotFound(); }
                var getarmIMRating = businesses.Find(x => x.BusinessRiskRatingId.Equals(businessriskratingId));

                var getstrategylog = strategy.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                var getstrategyARMIMrating = strategyARMIMRate.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstrategyrating = strategyARMIM.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstraOperationCtrl = straOperation.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstraOperationsett = straOperationsett.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstraregstrarTotal = straregstrar.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstraFundadmin = straFundadmin.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstrategyFundAcct = strategyFundAcct.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstraBD = straBD.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstrategyResearch = strategyResearch.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();
                var getstrategyRetailOpration = strategyOpration.GetContextByConditon(x => x.StrategyImBusinessRatingId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();

                var getoperationlog = operation.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                var getoperationARMIM = operationARMIM.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperationIM = operationIM.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperationResearch = operationResearch.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperControl = operControl.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperFundAdmin = operFundAdmin.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperFinancialAcct = operFinancialAcct.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperBD = operBD.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperationRetail = operationRetail.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperRegis = operRegis.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();
                var getoperSettle = operSettle.GetContextByConditon(x => x.OperationIMBusinessRatingId == getoperationlog.Id).Select(x => x.Total).FirstOrDefault();

                var getfinancelog = finance.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                var getfinanceARMIMrating = financeARMIM.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinancerating = financeIM.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceOprCtrl = financeOp.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceOpSettle = financeOpSettle.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceFundAd = financeFundAd.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceFundAcct = financeFundAcct.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceRetailOp = financeRetailOp.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceBD = financeBD.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceResearch = financeResearch.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceRegist = financeRegis.GetContextByConditon(x => x.FinancialIMBusinessRatingId == getfinancelog.Id).Select(x => x.Total).FirstOrDefault();

                var getcomplianceRating = compliance.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                var getcompARMIM = compARMIM.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceIM = complianceIM.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceOpCtrl = complianceOpCtrl.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceFundAcct = complianceFundAcct.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceFundAd = complianceFundAd.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceRegis = complianceRegis.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceOpSettl = complianceOpSettl.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceReatilOp = complianceReatilOp.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceResearch = complianceResearch.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceBD = complianceBD.GetContextByConditon(x => x.ComplianceIMBusinessRatingId == getcomplianceRating.Id).Select(x => x.Total).FirstOrDefault();

                var gettimesinceaudit = timeSinceLastAuditIM.GetContextByConditon(x => x.ARMIMBusinessRiskRatingId == getarmIMRating.Id).FirstOrDefault();

                ////emc rating
                //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getEmcConcernARMIMRating = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();

                ////mc concern rating
                //var getMCRatingRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getMCConcernARMIMRating = mgtARMIM.GetContextByConditon(x => x.ManagementConcernRiskRatingId == getMCRatingRating.Id).FirstOrDefault();

                //var getMgtRatingbusiness = mgtARMIMRatingbusiness.GetContextByConditon(x => x.ManagementConcernARMIMId == getMCConcernARMIMRating.Id).FirstOrDefault();
                //var getMgtSharedService = mgtARMIMRatingservice.GetContextByConditon(x => x.ManagementConcernARMIMId == getMCConcernARMIMRating.Id).FirstOrDefault();

                //var getBusinessMCConcernARMIMRating = getMgtRatingbusiness.ARMIM + getMgtRatingbusiness.OperationSettlement + getMgtRatingbusiness.IMUnit + getMgtRatingbusiness.RetailOperation + getMgtRatingbusiness.OperationControl + getMgtRatingbusiness.FundAdmin + getMgtRatingbusiness.FundAccount + getMgtRatingbusiness.ARMRegistrar + getMgtRatingbusiness.BDOrIMRetail;
                //var getSharedServiceMCConcernARMIMRating = getMgtSharedService.Academy + getMgtSharedService.HCM + getMgtSharedService.ProcurementAndAdmin + getMgtSharedService.IT + getMgtSharedService.RiskManagement + getMgtSharedService.Legal + getMgtSharedService.MCC + getMgtSharedService.CTO + getMgtSharedService.CustomerExperience + getMgtSharedService.Compliance + getMgtSharedService.FinancialControl + getMgtSharedService.DataAnalytic + getMgtSharedService.InformationSecurity + getMgtSharedService.InternalControl + getMgtSharedService.CorporateStrategy + getMgtSharedService.Treasury;

                var maximumPossibleStrategyBusinessMgtRating = 3 * 32;
                var maximumPossibleOperationBusinessMgtRating = 3 * 20;
                var maximumPossibleFinanceBusinessMgtRating = 3 * 7;
                var maximumPossibleComplianceBusinessMgtRating = 3 * 11;
                var maximumPossibleTimeSinceLastAuditBusinessMgtRating = 3 * 1;
                var maximumPossibledirectorConcernRating = 3 * 2;
                var strategyWeight = 0.20;  
                var operationWeight = 0.20; 
                var financialReportWeight = 0.15; 
                var complianceWeight = 0.15; 
                var magtConcernWeight = 0.15m; 
                var timeSinceLastAuditWeight = 0.15; 

                #region MC and EMC Concern
                //  //EMC                             
                var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allEmcConcernARMIM = new List<decimal>();
                var allEmcConcernIMUnit = new List<decimal>();
                var allEmcConcernOperationControl = new List<decimal>();
                var allEmcConcernOperationSettlement = new List<decimal>();
                var allEmcConcernARMRegistrar = new List<decimal>();
                var allEmcConcernFundAdmin = new List<decimal>();
                var allEmcConcernFundAccount = new List<decimal>();
                var allEmcConcernBDOrIMRetail = new List<decimal>();
                var allEmcConcernRetailOperation = new List<decimal>();
                var allEmcConcernResearch = new List<decimal>();

                foreach (var item1 in getEMCRating)
                {
                    var getEmcConcernARMIM = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMIM).ToList();
                    allEmcConcernARMIM.AddRange(getEmcConcernARMIM); 
                   
                    var getEmcConcernIMUnit = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.IMUnit).ToList();
                    allEmcConcernIMUnit.AddRange(getEmcConcernIMUnit);

                    var getEmcConcernOperationControl = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.OperationControl).ToList();
                    allEmcConcernOperationControl.AddRange(getEmcConcernOperationControl);

                    var getEmcConcernOperationSettlement = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.OperationSetlement).ToList();
                    allEmcConcernOperationSettlement.AddRange(getEmcConcernOperationSettlement);

                    var getEmcConcernARMRegistrar = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMRegisterar).ToList();
                    allEmcConcernARMRegistrar.AddRange(getEmcConcernARMRegistrar);

                    var getEmcConcernFundAdmin = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.FundAdmin).ToList();
                    allEmcConcernFundAdmin.AddRange(getEmcConcernFundAdmin);

                    var getEmcConcernFundAccount = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Fundaccount).ToList();
                    allEmcConcernFundAccount.AddRange(getEmcConcernFundAccount);

                    var getEmcConcernBDOrIMRetail = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.BDOrIMRetail).ToList();
                    allEmcConcernBDOrIMRetail.AddRange(getEmcConcernBDOrIMRetail);

                    var getEmcConcernRetailOperation = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.RetailOperations).ToList();
                    allEmcConcernRetailOperation.AddRange(getEmcConcernRetailOperation);

                    var getEmcConcernResearch = armIMEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Research).ToList();
                    allEmcConcernResearch.AddRange(getEmcConcernResearch);
                }
                // Calculate the sum and average for the first three records
                var recordARMIM = allEmcConcernARMIM.ToList();
                var recordIMUnit = allEmcConcernIMUnit.ToList();
                var recordOperationControl = allEmcConcernOperationControl.ToList();
                var recordOperationSettlement = allEmcConcernOperationSettlement.ToList();
                var recordARMRegistrar = allEmcConcernARMRegistrar.ToList();
                var recordFundAdmin = allEmcConcernFundAdmin.ToList();
                var recordFundAccount = allEmcConcernFundAccount.ToList();
                var recordBDOrIMRetail = allEmcConcernBDOrIMRetail.ToList();
                var recordRetailOperation = allEmcConcernRetailOperation.ToList();
                var recordResearch = allEmcConcernResearch.ToList();

                //decimal sumARMIM = recordARMIM.Sum();
               
                decimal averageEMCARMIM = recordARMIM.Any() ? recordARMIM.Average() : 0;
                decimal averageEMCIMUnit = recordIMUnit.Any() ? recordIMUnit.Average() : 0;
                decimal averageEMCOperationControl = recordOperationControl.Any() ? recordOperationControl.Average() : 0;
                decimal averageEMCOperationSettlement = recordOperationSettlement.Any() ? recordOperationSettlement.Average() : 0;
                decimal averageEMCARMRegistrar = recordARMRegistrar.Any() ? recordARMRegistrar.Average() : 0;
                decimal averageEMCFundAdmin = recordFundAdmin.Any() ? recordFundAdmin.Average() : 0;
                decimal averageEMCFundAccount = recordFundAccount.Any() ? recordFundAccount.Average() : 0;
                decimal averageEMCBDOrIMRetail = recordBDOrIMRetail.Any() ? recordBDOrIMRetail.Average() : 0;
                decimal averageEMCRetailOperation = recordRetailOperation.Any() ? recordRetailOperation.Average() : 0;
                decimal averageEMCResearch = recordResearch.Any() ? recordResearch.Average() : 0;

                //  //emc rating

                var getMCRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allMCConcernARMIM = new List<decimal>();
                var allMCConcernIMUnit = new List<decimal>();
                var allMCConcernOperationControl = new List<decimal>();
                var allMCConcernOperationSettlement = new List<decimal>();
                var allMCConcernARMRegistrar = new List<decimal>();
                var allMCConcernFundAdmin = new List<decimal>();
                var allMCConcernFundAccount = new List<decimal>();
                var allMCConcernBDOrIMRetail = new List<decimal>();
                var allMCConcernRetailOperation = new List<decimal>();
                var allMCConcernResearch = new List<decimal>();
                foreach (var item2 in getMCRating)
                {
                    var getMCConcern = mgtARMIM.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                    if (getMCConcern.Any())
                    {
                        var getbusMCRatingARMIM = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.ARMIM).ToList();
                        allMCConcernARMIM.AddRange(getbusMCRatingARMIM);

                        var getbusMCRatingIMUnit = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.IMUnit).ToList();
                        allMCConcernIMUnit.AddRange(getbusMCRatingIMUnit);


                        var getbusMCRatingOperationControl = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.OperationControl).ToList();
                        allMCConcernOperationControl.AddRange(getbusMCRatingOperationControl);


                        var getbusMCRatingOperationSettlement = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.OperationSettlement).ToList();
                        allMCConcernOperationSettlement.AddRange(getbusMCRatingOperationSettlement);


                        var getbusMCRatingARMRegistrar = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.ARMRegistrar).ToList();
                        allMCConcernARMRegistrar.AddRange(getbusMCRatingARMRegistrar);


                        var getbusMCRatingFundAdmin = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.FundAdmin).ToList();
                        allMCConcernFundAdmin.AddRange(getbusMCRatingFundAdmin);


                        var getbusMCRatingFundAccount = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.FundAccount).ToList();
                        allMCConcernFundAccount.AddRange(getbusMCRatingFundAccount);


                        var getbusMCRatingBDOrIMRetail = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.BDOrIMRetail).ToList();
                        allMCConcernBDOrIMRetail.AddRange(getbusMCRatingBDOrIMRetail);

                        var getbusMCRatingRetailOperation = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.RetailOperation).ToList();
                        allMCConcernRetailOperation.AddRange(getbusMCRatingRetailOperation);

                        var getbusMCRatingResearch = mgtARMIMRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMIMId)).Select(x => x.Research).ToList();
                        allMCConcernResearch.AddRange(getbusMCRatingResearch);
                    }
                }
                var recordMCARMIM = allMCConcernARMIM.ToList();
                var recordMCIMUnit = allMCConcernIMUnit.ToList();
                var recordMCOperationControl = allMCConcernOperationControl.ToList();
                var recordMCOperationSettlement = allMCConcernOperationSettlement.ToList();
                var recordMCARMRegistrar = allMCConcernARMRegistrar.ToList();
                var recordMCFundAdmin = allMCConcernFundAdmin.ToList();
                var recordMCFundAccount = allMCConcernFundAccount.ToList();
                var recordMCBDOrIMRetail = allMCConcernBDOrIMRetail.ToList();
                var recordMCRetailOperation = allMCConcernRetailOperation.ToList();
                var recordMCResearch = allMCConcernResearch.ToList();
                //  decimal sumMC = recordMC.Sum();
                decimal averageMCARMIM = recordMCARMIM.Any() ? recordMCARMIM.Average() : 0;
                decimal averageMCIMUnit = recordMCIMUnit.Any() ? recordMCIMUnit.Average() : 0;
                decimal averageMCOperationControl = recordMCOperationControl.Any() ? recordMCOperationControl.Average() : 0;
                decimal averageMCOperationSettlement = recordMCOperationSettlement.Any() ? recordMCOperationSettlement.Average() : 0;
                decimal averageMCARMRegistrar = recordMCARMRegistrar.Any() ? recordMCARMRegistrar.Average() : 0;
                decimal averageMCFundAdmin = recordMCFundAdmin.Any() ? recordMCFundAdmin.Average() : 0;
                decimal averageMCFundAccount = recordMCFundAccount.Any() ? recordMCFundAccount.Average() : 0;
                decimal averageMCBDOrIMRetail = recordMCBDOrIMRetail.Any() ? recordMCBDOrIMRetail.Average() : 0;
                decimal averageMCRetailOperation = recordMCRetailOperation.Any() ? recordMCRetailOperation.Average() : 0;
                decimal averageMCResearch = recordMCResearch.Any() ? recordMCResearch.Average() : 0;

                var businessManagerConcernARMIM = averageMCARMIM;
                var businessManagerConcernIMUnit = averageMCIMUnit;
                var businessManagerConcernOperationCtrl = averageMCOperationControl;
                var businessManagerConcernOperationSettle = averageMCOperationSettlement;
                var businessManagerConcernRegistrar = averageMCARMRegistrar;
                var businessManagerConcernFundAdmin = averageMCFundAdmin;
                var businessManagerConcernFundAcct = averageMCFundAccount;
                var businessManagerConcernBD = averageMCBDOrIMRetail;
                var businessManagerConcernRetailoperation = averageMCRetailOperation;
                var businessManagerConcernResearch = averageMCResearch;

                var directoraverageEMCARMIM = averageEMCARMIM;
                var directorIMUnit = averageEMCIMUnit;
                var directorOperationControl = averageEMCOperationControl;
                var directorOperationSettlement = averageEMCOperationSettlement;
                var directorARMRegistrar = averageEMCARMRegistrar;
                var directorFundAdmin = averageEMCFundAdmin;
                var directorFundAccount = averageEMCFundAccount;
                var directorBDOrIMRetail = averageEMCBDOrIMRetail;
                var directorRetailOperation = averageEMCRetailOperation;
                var directorResearch = averageEMCResearch;

                // individual director Concern

                var directorConcernARMIM = businessManagerConcernARMIM + directoraverageEMCARMIM;
                var directorConcernIM = businessManagerConcernIMUnit + directorIMUnit;
                var directorConcernOperationControl = businessManagerConcernOperationCtrl + directorOperationControl;
                var directorConcernBDOrIMRetail = businessManagerConcernBD + directorBDOrIMRetail;
                var directorConcernRetailOperations = businessManagerConcernRetailoperation + directorRetailOperation;
                var directorConcernOperationSetlement = businessManagerConcernOperationSettle + directorOperationSettlement;
                var directorConcernARMRegisterar = businessManagerConcernRegistrar + directorARMRegistrar;
                var directorConcernFundaccount = businessManagerConcernFundAcct + directorFundAccount;
                var directorConcernFundAdmin = businessManagerConcernFundAdmin + directorFundAdmin;
                var directorConcernResearch = businessManagerConcernResearch + directorResearch;

                #endregion

                #region ARMIMRating
                string riskRating = "";
                string recommentation = "";
                var riskScoreStrategyIM = (getstrategyARMIMrating / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var riskScoreOperationIM = (getoperationARMIM / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreFinanceIM = (getfinanceARMIMrating / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var riskScoreComplianceIM = (getcompARMIM / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var riskScoreTimesinceLastauditIM = (gettimesinceaudit.ARMIM / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcern = (directorConcernARMIM / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var scoreARMIM = (decimal)riskScoreStrategyIM + (decimal)riskScoreFinanceIM + (decimal)riskScoreComplianceIM + riskScoredirectorConcern;

                var riskScore = (scoreARMIM / 65) * 100;

                var oldRiskScore = 0;
                
                if (riskScore < 0.4m)
                {
                    riskRating = "Very Low";
                    recommentation = "Spot Check";
                }
                if (riskScore >= 0.4m && riskScore < 0.5m)
                {
                    riskRating = "Low";
                    recommentation = "Spot Check";
                }
                if (riskScore >= 0.5m && riskScore < 0.65m)
                {
                    riskRating = "Medium";
                    recommentation = "Partial Scope";
                }
                if (riskScore >= 0.65m && riskScore < 0.8m)
                {
                    riskRating = "High";
                    recommentation = "Full Scope";
                }
                if (riskScore >= 0.8m)
                {
                    riskRating = "Very High";
                    recommentation = "Full Scope";
                }

                #endregion

                #region IM Unit Rating

                string riskRatingIMUnit = "";
                string recommentationIMUnit = "";
                var riskScoreStrategyIMUnit = (getstrategyrating / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var riskScoreOperationIMUnit = (getoperationIM / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreFinanceIMUnit = (getfinancerating / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var riskScoreComplianceIMUnit = (getcomplianceIM / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var riskScoreTimesinceLastauditIMUnit = (gettimesinceaudit.IMUnit / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernIMUnit = (directorConcernIM / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var scoreIMUnit = (decimal)riskScoreOperationIMUnit + (decimal)riskScoreTimesinceLastauditIMUnit + riskScoredirectorConcernIMUnit;
                var riskScoreIMUnit = (scoreIMUnit / 50) * 100;
                var oldRiskScoreIMUnit = 0;
               
                if (riskScoreIMUnit < 0.4m)
                {
                    riskRatingIMUnit = "Very Low";
                    recommentationIMUnit = "Spot Check";
                }
                if (riskScoreIMUnit >= 0.4m && riskScoreIMUnit < 0.5m)
                {
                    riskRatingIMUnit = "Low";
                    recommentationIMUnit = "Spot Check";
                }
                if (riskScoreIMUnit >= 0.5m && riskScoreIMUnit < 0.65m)
                {
                    riskRatingIMUnit = "Medium";
                    recommentationIMUnit = "Partial Scope";
                }
                if (riskScoreIMUnit >= 0.65m && riskScoreIMUnit < 0.8m)
                {
                    riskRatingIMUnit = "High";
                    recommentationIMUnit = "Full Scope";
                }
                if (riskScoreIMUnit >= 0.8m)
                {
                    riskRatingIMUnit = "Very High";
                    recommentationIMUnit = "Full Scope";
                }

                #endregion

                #region OperationControl

                string riskRatingOpCtrl = "";
                string recommentationOpCtrl = "";
                var riskScoreStrategyOpCtrl = (getstraOperationCtrl / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var riskScoreOperationOpCtrl = (getoperControl / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreFinanceOpCtrl = (getfinanceOprCtrl / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var riskScoreComplianceOpCtrl = (getcomplianceOpCtrl / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var riskScoreTimesinceLastauditOpCtrl = (gettimesinceaudit.OperationControl / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernOpCtrl = (directorConcernOperationControl / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var scoreOpCtrl = (decimal)riskScoreOperationOpCtrl + (decimal)riskScoreTimesinceLastauditOpCtrl + riskScoredirectorConcernOpCtrl;
                var riskScoreOpCtrl = (scoreOpCtrl / 50) * 100;

                var oldRiskScoreOpCtrl = 0;
               
                if (riskScoreOpCtrl < 0.4m)
                {
                    riskRatingOpCtrl = "Very Low";
                    recommentationOpCtrl = "Spot Check";
                }
                if (riskScoreOpCtrl >= 0.4m && riskScoreOpCtrl < 0.5m)
                {
                    riskRatingOpCtrl = "Low";
                    recommentationOpCtrl = "Spot Check";
                }
                if (riskScoreOpCtrl >= 0.5m && riskScoreOpCtrl < 0.65m)
                {
                    riskRatingOpCtrl = "Medium";
                    recommentationOpCtrl = "Partial Scope";
                }
                if (riskScoreOpCtrl >= 0.65m && riskScoreOpCtrl < 0.8m)
                {
                    riskRatingOpCtrl = "High";
                    recommentationOpCtrl = "Full Scope";
                }
                if (riskScoreOpCtrl >= 0.8m)
                {
                    riskRatingOpCtrl = "Very High";
                    recommentationOpCtrl = "Full Scope";
                }

                #endregion

                #region BDOrIMRetail

                string riskRatingbdp = "";
                string recommentationbdp = "";
                var riskScoreStrategybdp = (getstraBD / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var riskScoreOperationbdp = (getoperBD / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreFinancebdp = (getfinanceBD / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var riskScoreCompliancebdp = (getcomplianceBD / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var riskScoreTimesinceLastauditbdp = (gettimesinceaudit.BDPWMIAMIMRetail / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernbdp = (directorConcernBDOrIMRetail / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var scorebdp = (decimal)riskScoreOperationbdp + (decimal)riskScoreTimesinceLastauditbdp + riskScoredirectorConcernbdp;
                var riskScorebdp = (scorebdp / 50) * 100;

                var oldRiskScorebdp = 0;
                
                if (riskScorebdp < 0.4m)
                {
                    riskRatingbdp = "Very Low";
                    recommentationbdp = "Spot Check";
                }
                if (riskScorebdp >= 0.4m && riskScorebdp < 0.5m)
                {
                    riskRatingbdp = "Low";
                    recommentationbdp = "Spot Check";
                }
                if (riskScorebdp >= 0.5m && riskScorebdp < 0.65m)
                {
                    riskRatingbdp = "Medium";
                    recommentationbdp = "Partial Scope";
                }
                if (riskScorebdp >= 0.65m && riskScorebdp < 0.8m)
                {
                    riskRatingbdp = "High";
                    recommentationbdp = "Full Scope";
                }
                if (riskScorebdp >= 0.8m)
                {
                    riskRatingbdp = "Very High";
                    recommentationbdp = "Full Scope";
                }
                #endregion

                #region RetailOperations 

                string riskRatingRetailOp = "";
                string recommentationRetailOp = "";
                var riskScoreStrategyRetailOp = (getstrategyRetailOpration / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var riskScoreOperationRetailOp = (getoperationRetail / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreFinanceRetailOp = (getfinanceRetailOp / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var riskScoreComplianceRetailOp = (getcomplianceReatilOp / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var riskScoreTimesinceLastauditRetailOp = (gettimesinceaudit.RetailOperation / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernRetailOp = (directorConcernRetailOperations / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var scoreRetailOp = (decimal)riskScoreOperationRetailOp + (decimal)riskScoreTimesinceLastauditRetailOp + riskScoredirectorConcernRetailOp;
                var riskScoreRetailOp = (scoreRetailOp / 50) * 100;
                var oldRiskScoreRetailOp = 0;
                
                if (riskScoreRetailOp < 0.4m)
                {
                    riskRatingRetailOp = "Very Low";
                    recommentationRetailOp = "Spot Check";
                }
                if (riskScoreRetailOp >= 0.4m && riskScoreRetailOp < 0.5m)
                {
                    riskRatingRetailOp = "Low";
                    recommentationRetailOp = "Spot Check";
                }
                if (riskScoreRetailOp >= 0.5m && riskScoreRetailOp < 0.65m)
                {
                    riskRatingRetailOp = "Medium";
                    recommentationRetailOp = "Partial Scope";
                }
                if (riskScoreRetailOp >= 0.65m && riskScoreRetailOp < 0.8m)
                {
                    riskRatingRetailOp = "High";
                    recommentationRetailOp = "Full Scope";
                }
                if (riskScoreRetailOp >= 0.8m)
                {
                    riskRatingRetailOp = "Very High";
                    recommentationRetailOp = "Full Scope";
                }

                #endregion

                #region FundAcct

                string riskRatingFacct = "";
                string recommentationFacct = "";
                var riskScoreOperationFacct = (getoperFinancialAcct / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreTimesinceLastauditFacct = (gettimesinceaudit.FundAccount / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernFacct = (directorConcernFundaccount / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var scoreFacct = (decimal)riskScoreOperationFacct + (decimal)riskScoreTimesinceLastauditFacct + riskScoredirectorConcernFacct;

                var riskScoreFacct = (scoreFacct / 50) * 100;
                var oldRiskScoreFacct = 0;
              
                if (riskScoreFacct < 0.4m)
                {
                    riskRatingFacct = "Very Low";
                    recommentationFacct = "Spot Check";
                }
                if (riskScoreFacct >= 0.4m && riskScoreFacct < 0.5m)
                {
                    riskRatingFacct = "Low";
                    recommentationFacct = "Spot Check";
                }
                if (riskScoreFacct >= 0.5m && riskScoreFacct < 0.65m)
                {
                    riskRatingFacct = "Medium";
                    recommentationFacct = "Partial Scope";
                }
                if (riskScoreFacct >= 0.65m && riskScoreFacct < 0.8m)
                {
                    riskRatingFacct = "High";
                    recommentationFacct = "Full Scope";
                }
                if (riskScoreFacct >= 0.8m)
                {
                    riskRatingFacct = "Very High";
                    recommentationFacct = "Full Scope";
                }

                #endregion

                #region Operationsett

                string riskRatingOpset = "";
                string recommentationOpset = "";
                var riskScoreOperationOpset = (getoperSettle / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreTimesinceLastauditOpset = (gettimesinceaudit.OperationSettlement / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernOpset = (directorConcernOperationSetlement / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var scoreOpset = (decimal)riskScoreOperationOpset + (decimal)riskScoreTimesinceLastauditOpset + riskScoredirectorConcernOpset;
                var riskScoreOpset = (scoreOpset / 50) * 100;
                var oldRiskScoreOpset = 0;
                
                if (riskScoreOpset < 0.4m)
                {
                    riskRatingOpset = "Very Low";
                    recommentationOpset = "Spot Check";
                }
                if (riskScoreOpset >= 0.4m && riskScoreOpset < 0.5m)
                {
                    riskRatingOpset = "Low";
                    recommentationOpset = "Spot Check";
                }
                if (riskScoreOpset >= 0.5m && riskScoreOpset < 0.65m)
                {
                    riskRatingOpset = "Medium";
                    recommentationOpset = "Partial Scope";
                }
                if (riskScoreOpset >= 0.65m && riskScoreOpset < 0.8m)
                {
                    riskRatingOpset = "High";
                    recommentationOpset = "Full Scope";
                }
                if (riskScoreOpset >= 0.8m)
                {
                    riskRatingOpset = "Very High";
                    recommentationOpset = "Full Scope";
                }

                #endregion

                #region Fund Admin

                string riskRatingFadmin = "";
                string recommentationFadmin = "";
                var riskScoreOperationFadmin = (getoperFundAdmin / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreTimesinceLastauditFadmin = (gettimesinceaudit.FundAdmin / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernFadmin = (directorConcernFundAdmin / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;
                var scoreFadmin = (decimal)riskScoreOperationFadmin + (decimal)riskScoreTimesinceLastauditFadmin + riskScoredirectorConcernFadmin;
                var riskScoreFadmin = (scoreFadmin / 50) * 100;
                var oldRiskScoreFadmin = 0;
                
                if (riskScoreFadmin < 0.4m)
                {
                    riskRatingFadmin = "Very Low";
                    recommentationFadmin = "Spot Check";
                }
                if (riskScoreFadmin >= 0.4m && riskScoreFadmin < 0.5m)
                {
                    riskRatingFadmin = "Low";
                    recommentationFadmin = "Spot Check";
                }
                if (riskScoreFadmin >= 0.5m && riskScoreFadmin < 0.65m)
                {
                    riskRatingFadmin = "Medium";
                    recommentationFadmin = "Partial Scope";
                }
                if (riskScoreFadmin >= 0.65m && riskScoreFadmin < 0.8m)
                {
                    riskRatingFadmin = "High";
                    recommentationFadmin = "Full Scope";
                }
                if (riskScoreFadmin >= 0.8m)
                {
                    riskRatingFadmin = "Very High";
                    recommentationFadmin = "Full Scope";
                }

                #endregion

                #region ARMRegistrer

                string riskRatingReg = "";
                string recommentationReg = "";
                var riskScoreOperationReg = (getoperRegis / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreTimesinceLastauditReg = (gettimesinceaudit.ARMRegistrar / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernReg = (directorConcernARMRegisterar / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var scoreReg = (decimal)riskScoreOperationReg + (decimal)riskScoreTimesinceLastauditReg + riskScoredirectorConcernReg;

                var riskScoreReg = (scoreReg / 50) * 100;
                var oldRiskScoreReg = 0;
               
                if (riskScoreReg < 0.4m)
                {
                    riskRatingReg = "Very Low";
                    recommentationReg = "Spot Check";
                }
                if (riskScoreReg >= 0.4m && riskScoreReg < 0.5m)
                {
                    riskRatingReg = "Low";
                    recommentationReg = "Spot Check";
                }
                if (riskScoreReg >= 0.5m && riskScoreReg < 0.65m)
                {
                    riskRatingReg = "Medium";
                    recommentationReg = "Partial Scope";
                }
                if (riskScoreReg >= 0.65m && riskScoreReg < 0.8m)
                {
                    riskRatingReg = "High";
                    recommentationReg = "Full Scope";
                }
                if (riskScoreReg >= 0.8m)
                {
                    riskRatingReg = "Very High";
                    recommentationReg = "Full Scope";
                }

                #endregion
               
                #region Research 

                string riskRatingResearch = "";
                string recommentationResearch = "";
                //str: getstrategyResearch
                //fina: getfinanceResearch
                //com: getcomplianceResearch
                var riskScoreOperationResearch = (getoperationResearch / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var riskScoreTimesinceLastauditResearch = (gettimesinceaudit.Research / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var riskScoredirectorConcernResearch = (directorConcernResearch / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;
                var scoreResearch = (decimal)riskScoreOperationResearch + (decimal)riskScoreTimesinceLastauditResearch + riskScoredirectorConcernResearch;
                var riskScoreResearch = (scoreResearch / 50) * 100;
                var oldRiskScoreResearch = 0;

                if (riskScoreResearch < 0.4m)
                {
                    riskRatingResearch = "Very Low";
                    recommentationResearch = "Spot Check";
                }
                if (riskScoreResearch >= 0.4m && riskScoreResearch < 0.5m)
                {
                    riskRatingResearch = "Low";
                    recommentationResearch = "Spot Check";
                }
                if (riskScoreResearch >= 0.5m && riskScoreResearch < 0.65m)
                {
                    riskRatingResearch = "Medium";
                    recommentationFadmin = "Partial Scope";
                }
                if (riskScoreResearch >= 0.65m && riskScoreResearch < 0.8m)
                {
                    riskRatingResearch = "High";
                    recommentationResearch = "Full Scope";
                }
                if (riskScoreResearch >= 0.8m)
                {
                    riskRatingResearch = "Very High";
                    recommentationResearch = "Full Scope";
                }

                #endregion

                #region  Log audit universe   

                var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                if (getannualauditId == null)
                {
                    var logRequestId = AnualAuditUniverseRiskRating.Create(getRating.RequesterName, businessriskratingId);
                    await annualaudit.AddAsync(logRequestId);

                    var logarmimannual = ARMIMAuditUniverse.Create(getRating.RequesterName, logRequestId.Id);
                    await armimannual.AddAsync(logarmimannual);

                    var logimauditArmIm = AuditUniverseARMIMRating.Create(logarmimannual.Id, oldRiskScore.ToString("0.000"), businessManagerConcernARMIM, directoraverageEMCARMIM,
                                        riskScore.ToString("0.000"), riskRating, recommentation);
                    await armImAnnualAudit.AddAsync(logimauditArmIm);

                    var logimaudit = AuditUniverseARMIMIMUnit.Create(logarmimannual.Id, oldRiskScoreIMUnit.ToString("0.000"), businessManagerConcernIMUnit, directorIMUnit,
                                       riskScoreIMUnit.ToString("0.000"), riskRatingIMUnit, recommentationIMUnit);
                    await imaudit.AddAsync(logimaudit);

                    var logoperationControlaudit = AuditUniverseARMIMOperationControl.Create(logarmimannual.Id, oldRiskScoreOpCtrl.ToString("0.000"), businessManagerConcernOperationCtrl, directorOperationControl,
                                       riskScoreOpCtrl.ToString("0.000"), riskRatingOpCtrl, recommentationOpCtrl);
                    await operationControlaudit.AddAsync(logoperationControlaudit);

                    var logbdRetailAudit = AuditUniverseARMIMBDPWMIAMIMRetail.Create(logarmimannual.Id, oldRiskScorebdp.ToString("0.000"), businessManagerConcernBD, directorBDOrIMRetail,
                                      riskScorebdp.ToString("0.000"), riskRatingbdp, recommentationbdp);
                    await bdRetailAudit.AddAsync(logbdRetailAudit);

                    var logretailOperationaudit = AuditUniverseARMIMRetailOperation.Create(logarmimannual.Id, oldRiskScoreRetailOp.ToString("0.000"), businessManagerConcernRetailoperation, directorRetailOperation,
                                      riskScoreRetailOp.ToString("0.000"), riskRatingRetailOp, recommentationRetailOp);
                    await retailOperationaudit.AddAsync(logretailOperationaudit);

                    var logfundAcctAudit = AuditUniverseARMIMFundAccount.Create(logarmimannual.Id, oldRiskScoreFacct.ToString("0.000"), businessManagerConcernFundAcct, directorFundAccount,
                                     riskScoreFacct.ToString("0.000"), riskRatingFacct, recommentationFacct);
                    await fundAcctAudit.AddAsync(logfundAcctAudit);

                    var logoperationSettlementAudit = AuditUniverseARMIMOperationSettlement.Create(logarmimannual.Id, oldRiskScoreOpset.ToString("0.000"), businessManagerConcernOperationSettle, directorOperationSettlement,
                                      riskScoreOpset.ToString("0.000"), riskRatingOpset, recommentationOpset);
                    await operationSettlementAudit.AddAsync(logoperationSettlementAudit);

                    var logResearchAudit = AuditUniverseARMIMResearch.Create(logarmimannual.Id, oldRiskScoreResearch.ToString("0.000"), businessManagerConcernResearch, directorResearch,
                                      riskScoreResearch.ToString("0.000"), riskRatingResearch, recommentationResearch);
                    await researchaudit.AddAsync(logResearchAudit);

                    var logfundAdminAudit = AuditUniverseARMIMFundAdmin.Create(logarmimannual.Id, oldRiskScoreFadmin.ToString("0.000"), businessManagerConcernFundAdmin, directorFundAdmin,
                                     riskScoreFadmin.ToString("0.000"), riskRatingFadmin, recommentationFadmin);
                    await fundAdminAudit.AddAsync(logfundAdminAudit);

                    var logregistrarAudit = AuditUniverseARMIMRegistrar.Create(logarmimannual.Id, oldRiskScoreReg.ToString("0.000"), businessManagerConcernRegistrar, directorARMRegistrar,
                                      riskScoreReg.ToString("0.000"), riskRatingReg, recommentationReg);
                    await registrarAudit.AddAsync(logregistrarAudit);
                    getBusinessRiskRating.ApproveBusinessRating();
                    await repo.SaveChangesAsync();
                    return TypedResults.Ok("Approved successfully");
                }
                if (getannualauditId != null)
                {
                    var getaudit = armimannual.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                    if (getaudit != null)
                    {
                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();
                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getaudit == null)
                    {
                        var logarmimannual2 = ARMIMAuditUniverse.Create(getRating.RequesterName, getannualauditId.Id);
                        await armimannual.AddAsync(logarmimannual2);

                        var logimauditArmIm2 = AuditUniverseARMIMRating.Create(logarmimannual2.Id, oldRiskScore.ToString("0.000"), businessManagerConcernARMIM, directoraverageEMCARMIM,
                                         riskScore.ToString("0.000"), riskRating, recommentation);
                        await armImAnnualAudit.AddAsync(logimauditArmIm2);

                        var logimaudit2 = AuditUniverseARMIMIMUnit.Create(logarmimannual2.Id, oldRiskScoreIMUnit.ToString("0.000"), businessManagerConcernIMUnit, directorIMUnit,
                                           riskScoreIMUnit.ToString("0.000"), riskRatingIMUnit, recommentationIMUnit);
                        await imaudit.AddAsync(logimaudit2);

                        var logoperationControlaudit2 = AuditUniverseARMIMOperationControl.Create(logarmimannual2.Id, oldRiskScoreOpCtrl.ToString("0.000"), businessManagerConcernOperationCtrl, directorOperationControl,
                                           riskScoreOpCtrl.ToString("0.000"), riskRatingOpCtrl, recommentationOpCtrl);
                        await operationControlaudit.AddAsync(logoperationControlaudit2);

                        var logbdRetailAudit2 = AuditUniverseARMIMBDPWMIAMIMRetail.Create(logarmimannual2.Id, oldRiskScorebdp.ToString("0.000"), businessManagerConcernBD, directorBDOrIMRetail,
                                          riskScorebdp.ToString("0.000"), riskRatingbdp, recommentationbdp);
                        await bdRetailAudit.AddAsync(logbdRetailAudit2);

                        var logResearchAudit2 = AuditUniverseARMIMResearch.Create(logarmimannual2.Id, oldRiskScoreResearch.ToString("0.000"), businessManagerConcernResearch, directorResearch,
                                   riskScoreResearch.ToString("0.000"), riskRatingResearch, recommentationResearch);
                        await researchaudit.AddAsync(logResearchAudit2);

                        var logretailOperationaudit2 = AuditUniverseARMIMRetailOperation.Create(logarmimannual2.Id, oldRiskScoreRetailOp.ToString("0.000"), businessManagerConcernRetailoperation, directorRetailOperation,
                                          riskScoreRetailOp.ToString("0.000"), riskRatingRetailOp, recommentationRetailOp);
                        await retailOperationaudit.AddAsync(logretailOperationaudit2);

                        var logfundAcctAudit2 = AuditUniverseARMIMFundAccount.Create(logarmimannual2.Id, oldRiskScoreFacct.ToString("0.000"), businessManagerConcernFundAcct, directorFundAccount,
                                         riskScoreFacct.ToString("0.000"), riskRatingFacct, recommentationFacct);
                        await fundAcctAudit.AddAsync(logfundAcctAudit2);

                        var logoperationSettlementAudit2 = AuditUniverseARMIMOperationSettlement.Create(logarmimannual2.Id, oldRiskScoreOpset.ToString("0.000"), businessManagerConcernOperationSettle, directorOperationSettlement,
                                          riskScoreOpset.ToString("0.000"), riskRatingOpset, recommentationOpset);
                        await operationSettlementAudit.AddAsync(logoperationSettlementAudit2);

                        var logfundAdminAudit2 = AuditUniverseARMIMFundAdmin.Create(logarmimannual2.Id, oldRiskScoreFadmin.ToString("0.000"), businessManagerConcernFundAdmin, directorFundAdmin,
                                         riskScoreFadmin.ToString("0.000"), riskRatingFadmin, recommentationFadmin);
                        await fundAdminAudit.AddAsync(logfundAdminAudit2);

                        var logregistrarAudit2 = AuditUniverseARMIMRegistrar.Create(logarmimannual2.Id, oldRiskScoreReg.ToString("0.000"), businessManagerConcernRegistrar, directorARMRegistrar,
                                          riskScoreReg.ToString("0.000"), riskRatingReg, recommentationReg);
                        await registrarAudit.AddAsync(logregistrarAudit2);
                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();
                        return TypedResults.Ok("Approved successfully");
                    }

                }
                #endregion
                getBusinessRiskRating.ApproveBusinessRating();
                await repo.SaveChangesAsync();
                return TypedResults.Ok("Approved successfully");

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }
        }

    }
}
