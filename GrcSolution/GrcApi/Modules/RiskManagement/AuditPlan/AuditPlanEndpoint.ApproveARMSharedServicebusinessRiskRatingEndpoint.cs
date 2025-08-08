using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.IO;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 20/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * Endpoint to approve business risk rating
 */
    public class ApproveARMSharedServicebusinessRiskRatingEndpoint
    {
        /// <summary>
        /// Endpoint to approve armsharedservice business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="armShared"></param>
        /// <param name="repo"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="shared"></param>
        /// <param name="strategy"></param>
        /// <param name="straFinCtrl"></param>
        /// <param name="straTreasury"></param>
        /// <param name="strategycorpstra"></param>
        /// <param name="strategyintctrl"></param>
        /// <param name="strategyinfsec"></param>
        /// <param name="strategycustexp"></param>
        /// <param name="strategyCTO"></param>
        /// <param name="strategymcc"></param>
        /// <param name="strategylegal"></param>
        /// <param name="strategyacade"></param>
        /// <param name="strategyriskmgt"></param>
        /// <param name="strategyIt"></param>
        /// <param name="strategyadmin"></param>
        /// <param name="strategyhcm"></param>
        /// <param name="strategyCompl"></param>
        /// <param name="strategyDataAna"></param>
        /// <param name="operation"></param>
        /// <param name="operCompl"></param>
        /// <param name="opertreasury"></param>
        /// <param name="operationcorpat"></param>
        /// <param name="operIntCtrl"></param>
        /// <param name="operinfosec"></param>
        /// <param name="operationcustexp"></param>
        /// <param name="operCTO"></param>
        /// <param name="opermcc"></param>
        /// <param name="operationclegal"></param>
        /// <param name="operriskmgt"></param>
        /// <param name="operacademy"></param>
        /// <param name="operationit"></param>
        /// <param name="operadmin"></param>
        /// <param name="operhcm"></param>
        /// <param name="operationFinCtrl"></param>
        /// <param name="operationDataAna"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceCustExp"></param>
        /// <param name="complianceCTO"></param>
        /// <param name="compliancemcc"></param>
        /// <param name="complianceIt"></param>
        /// <param name="compliancemchcm"></param>
        /// <param name="complianceLegal"></param>
        /// <param name="complianceriskmgt"></param>
        /// <param name="complianceacademy"></param>
        /// <param name="complianceadmin"></param>
        /// <param name="compliancecorperat"></param>
        /// <param name="complianceintctrl"></param>
        /// <param name="complianceinfosec"></param>
        /// <param name="complianceDataAna"></param>
        /// <param name="compliancetreasury"></param>
        /// <param name="complianceFinTrl"></param>
        /// <param name="compCompl"></param>
        /// <param name="timeSinceLastSharedAudit"></param>
        /// <param name="emcRating"></param>
        /// <param name="emcRiskRating"></param>
        /// <param name="annualaudit"></param>
        /// <param name="sharedaudit"></param>
        /// <param name="dataAudit"></param>
        /// <param name="hcmaudit"></param>
        /// <param name="procurementandAdmin"></param>
        /// <param name="corporateStrategy"></param>
        /// <param name="academyaudit"></param>
        /// <param name="legalaudit"></param>
        /// <param name="compAudit"></param>
        /// <param name="riskManagement"></param>
        /// <param name="mccAudit"></param>
        /// <param name="internalControl"></param>
        /// <param name="treasureaudit"></param>
        /// <param name="CTOaudit"></param>
        /// <param name="itAudit"></param>
        /// <param name="customerExperience"></param>
        /// <param name="informationSecurityAudit"></param>
        /// <param name="finCtrlAudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, ARMSharedServiceRatingReq armShared, IRepository<ARMSharedServiceRating> repo,
            IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMSharedServiceRating> shared, IRepository<StrategySharedService> strategy, IRepository<StrategySharedServiceFinancialControl> straFinCtrl,
            IRepository<StrategySharedServiceRatingTreasury> straTreasury, IRepository<StrategySharedServiceRatingCorporatestrategy> strategycorpstra,
            IRepository<StrategySharedServiceRatingInternalControl> strategyintctrl, IRepository<StrategySharedServiceRatingInformationSecurity> strategyinfsec,
            IRepository<StrategySharedServiceRatingCustomerexperience> strategycustexp, IRepository<StrategySharedServiceRatingCTO> strategyCTO,
            IRepository<StrategySharedServiceRatingMCC> strategymcc, IRepository<StrategySharedServiceRatingLegal> strategylegal,
            IRepository<StrategySharedServiceRatingAcademy> strategyacade, IRepository<StrategySharedServiceRatingRiskManagement> strategyriskmgt,
            IRepository<StrategySharedServiceRatingIT> strategyIt, IRepository<StrategySharedServiceRatingProcurementAndAdmin> strategyadmin,
            IRepository<StrategySharedServiceRatingHCM> strategyhcm, IRepository<StrategySharedServiceCompliance> strategyCompl,
            IRepository<StrategySharedServiceDataAnalytic> strategyDataAna,

            IRepository<OperationSharedService> operation, IRepository<OperationSharedServiceComplianceRating> operCompl, IRepository<OperationSharedServiceRatingTreasury> opertreasury,
            IRepository<OperationSharedServiceRatingCorporatestrategy> operationcorpat, IRepository<OperationSharedServiceRatingInternalControl> operIntCtrl, IRepository<OperationSharedServiceRatingInformationSecurity> operinfosec,
            IRepository<OperationSharedServiceRatingCustomerexperience> operationcustexp, IRepository<OperationSharedServiceRatingCTO> operCTO, IRepository<OperationSharedServiceRatingMCC> opermcc,
            IRepository<OperationSharedServiceRatingLegal> operationclegal, IRepository<OperationSharedServiceRatingRiskManagement> operriskmgt, IRepository<OperationSharedServiceRatingAcademy> operacademy,
            IRepository<OperationSharedServiceRatingIT> operationit, IRepository<OperationSharedServiceRatingProcurementAndAdmin> operadmin, IRepository<OperationSharedServiceRatingHCM> operhcm,
            IRepository<OperationSharedServiceFinancialControlRating> operationFinCtrl, IRepository<OperationSharedServiceDataAnalyticRating> operationDataAna,

            IRepository<ComplianceSharedService> compliance, IRepository<ComplianceSharedServiceRatingCustomerexperience> complianceCustExp,
            IRepository<ComplianceSharedServiceRatingCTO> complianceCTO, IRepository<ComplianceSharedServiceRatingMCC> compliancemcc,
            IRepository<ComplianceSharedServiceRatingIT> complianceIt, IRepository<ComplianceSharedServiceRatingHCM> compliancemchcm,
            IRepository<ComplianceSharedServiceRatingLegal> complianceLegal, IRepository<ComplianceSharedServiceRatingRiskManagement> complianceriskmgt,
            IRepository<ComplianceSharedServiceRatingAcademy> complianceacademy, IRepository<ComplianceSharedServiceRatingProcurementAndAdmin> complianceadmin,
            IRepository<ComplianceSharedServiceRatingCorporatestrategy> compliancecorperat, IRepository<ComplianceSharedServiceRatingInternalControl> complianceintctrl,
            IRepository<ComplianceSharedServiceRatingInformationSecurity> complianceinfosec, IRepository<ComplianceSharedServiceDataAnalyticRating> complianceDataAna,
            IRepository<ComplianceSharedServiceRatingTreasury> compliancetreasury, IRepository<ComplianceSharedServiceFinancialControlRating> complianceFinTrl,
            IRepository<ComplianceSharedServiceComplianceRating> compCompl, IRepository<TimeSinceLastSharedServiceAudit> timeSinceLastSharedAudit,
            IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMSharedServiceEMCRating> emcRiskRating,
           
            //busness mgt concern rating
            IRepository<ManagementConcernRiskRating> mcRating, IRepository<ManagementConcernRiskRating> mcRiskRating,

            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMSharedAuditUniverse> sharedaudit, IRepository<ARMSharedAuditUniverseDataAnalytic> dataAudit,
            IRepository<ARMSharedAuditUniverseHCM> hcmaudit, IRepository<ARMSharedAuditUniverseProcurementAndAdmin> procurementandAdmin, IRepository<ARMSharedAuditUniverseCorporatestrategy> corporateStrategy,
            IRepository<ARMSharedAuditUniverseAcademy> academyaudit, IRepository<ARMSharedAuditUniverseLegal> legalaudit, IRepository<ARMSharedAuditUniverseCompliance> compAudit,
            IRepository<ARMSharedAuditUniverseRiskManagement> riskManagement, IRepository<ARMSharedAuditUniverseMCC> mccAudit, IRepository<ARMSharedAuditUniverseInternalControl> internalControl,
            IRepository<ARMSharedAuditUniverseTreasury> treasureaudit, IRepository<ARMSharedAuditUniverseCTO> CTOaudit, IRepository<ARMSharedAuditUniverseIT> itAudit,
            IRepository<ARMSharedAuditUniverseCustomerExperience> customerExperience, IRepository<ARMSharedAuditUniverseInformationSecurity> informationSecurityAudit,
            IRepository<ARMSharedAuditUniverseFinancialControl> finCtrlAudit,

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
                if (getRating == null) { return TypedResults.NotFound(); }
                getRating.ApproveBusinessRiskRatingStatus();
                var businesses = await shared.GetAllAsync();
                if (getRating != null)
                {
                    var getshared = businesses.Find(x => x.BusinessRiskRatingId.Equals(businessriskratingId));
                    var getstrategy = strategy.GetContextByConditon(x => x.ARMSharedServiceRatingId == getshared.Id).FirstOrDefault();

                    var getstraFinCtrl = straFinCtrl.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyCompl = strategyCompl.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstraTreasury = straTreasury.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategycorpstra = strategycorpstra.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyintctrl = strategyintctrl.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyinfsec = strategyinfsec.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategycustexp = strategycustexp.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyCTO = strategyCTO.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategymcc = strategymcc.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategylegal = strategylegal.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyacade = strategyacade.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyriskmgt = strategyriskmgt.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyIt = strategyIt.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyadmin = strategyadmin.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyhcm = strategyhcm.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstrategyDataAna = strategyDataAna.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();

                    var getoperation = operation.GetContextByConditon(x => x.ARMSharedServiceRatingId == getshared.Id).FirstOrDefault();

                    var getoperationFinCtrl = operationFinCtrl.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperCompl = operCompl.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getopertreasury = opertreasury.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperationcorpat = operationcorpat.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperIntCtrl = operIntCtrl.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperinfosec = operinfosec.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperationcustexp = operationcustexp.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperCTO = operCTO.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getopermcc = opermcc.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperationclegal = operationclegal.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperriskmgt = operriskmgt.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperacademy = operacademy.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperationit = operationit.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperadmin = operadmin.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperhcm = operhcm.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperationDataAna = operationDataAna.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).Select(x => x.Total).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMSharedServiceRatingId == getshared.Id).FirstOrDefault();
                    
                    var getcomplianceCustExp = complianceCustExp.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceCTO = complianceCTO.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcompliancemcc = compliancemcc.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceIt = complianceIt.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcompliancemchcm = compliancemchcm.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceLegal = complianceLegal.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceriskmgt = complianceriskmgt.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceacademy = complianceacademy.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceadmin = complianceadmin.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcompliancecorperat = compliancecorperat.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceintctrl = complianceintctrl.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceinfosec = complianceinfosec.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceDataAna = complianceDataAna.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcompliancetreasury = compliancetreasury.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcomplianceFinTrl = complianceFinTrl.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcompCompl = compCompl.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();

                    var gettimeSinceLastSharedAudit = timeSinceLastSharedAudit.GetContextByConditon(x => x.ARMSharedServiceRatingId == getshared.Id).FirstOrDefault();

                    ////emc rating
                    //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                    //var getEmcConcernRating = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();

                    var maximumPossibleStrategyBusinessMgtRating = 3 * 9;
                    var maximumPossibleOperationBusinessMgtRating = 3 * 24;
                    var maximumPossibleComplianceBusinessMgtRating = 3 * 8;
                    var maximumPossibleTimeSinceLastAuditBusinessMgtRating = 3 * 1;
                    var maximumPossibleEMCConcernMgtRating = 3 * 2;

                    var strategyWeight = 0.10; 
                    var operationWeight = 0.50; 
                    var complianceWeight = 0.10;
                    decimal magtConcernWeight = 0.15m; 
                    var timeSinceLastAuditWeight = 0.15;

                    //var businessManagerConcernHCM = getEmcConcernRating.HCM;
                    //var businessManagerConcernInformationSecurity = getEmcConcernRating.InfoSecurity;
                    //var businessManagerConcernTreasury = getEmcConcernRating.Treasury;
                    //var businessManagerConcernCorporatestrategy = getEmcConcernRating.CorporateStrategy;
                    //var businessManagerConcernInternalControl = getEmcConcernRating.InternalControl;
                    //var businessManagerConcernAcademy = getEmcConcernRating.Academy;
                    //var businessManagerConcernCustomerexperience = getEmcConcernRating.CustomerExperience;
                    //var businessManagerConcernCTO = getEmcConcernRating.CTO;
                    //var businessManagerConcernMCC = getEmcConcernRating.MCC;
                    //var businessManagerConcernLegal = getEmcConcernRating.Legal;
                    //var businessManagerConcernComp = getEmcConcernRating.Compliance;
                    //var businessManagerConcernFinCtrl = getEmcConcernRating.FinancialControl;
                    //var businessManagerConcernDataAna = getEmcConcernRating.DataAnalytic;
                    //var businessManagerConcernProAdmin = getEmcConcernRating.ProcurementAndAdmin;
                    //var businessManagerConcernIT = getEmcConcernRating.IT;
                    //var businessManagerConcernRiskMgt = getEmcConcernRating.RiskManagement;

                    #region MC and EMC Concern
                    //  //EMC                             
                    var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                    var allEmcConcernHCM = new List<decimal>();
                    var allEmcConcernIT = new List<decimal>();
                    var allEmcConcernCTO = new List<decimal>();
                    var allEmcConcernAcademy = new List<decimal>();
                    var allEmcConcernDataAnalytic = new List<decimal>();
                    var allEmcConcernCorporateStrategy = new List<decimal>();
                    var allEmcConcernInternalControl = new List<decimal>();
                    var allEmcConcernRiskManagement = new List<decimal>();
                    var allEmcConcernTreasury = new List<decimal>();
                    var allEmcConcernLegal = new List<decimal>();
                    var allEmcConcernMCC = new List<decimal>();
                    var allEmcConcernFinancialControl = new List<decimal>();
                    var allEmcConcernCompliance = new List<decimal>();
                    var allEmcConcernCustomerExperience = new List<decimal>();
                    var allEmcConcernInfoSecurity = new List<decimal>();
                    var allEmcConcernProcurementAndAdmin = new List<decimal>();
                    
                    foreach (var item1 in getEMCRating)
                    {
                        var getEmcConcernHCM = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.HCM).ToList();
                        allEmcConcernHCM.AddRange(getEmcConcernHCM);

                        var getEmcConcernIT = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.IT).ToList();
                        allEmcConcernIT.AddRange(getEmcConcernIT);

                        var getEmcConcernCTO = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.CTO).ToList();
                        allEmcConcernCTO.AddRange(getEmcConcernCTO);

                        var getEmcConcernAcademy = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Academy).ToList();
                        allEmcConcernAcademy.AddRange(getEmcConcernAcademy);

                        var getEmcConcernDataAnalytic = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.DataAnalytic).ToList();
                        allEmcConcernDataAnalytic.AddRange(getEmcConcernDataAnalytic);

                        var getEmcConcernCorporateStrategy = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.CorporateStrategy).ToList();
                        allEmcConcernCorporateStrategy.AddRange(getEmcConcernCorporateStrategy);

                        var getEmcConcernRiskManagement = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.RiskManagement).ToList();
                        allEmcConcernRiskManagement.AddRange(getEmcConcernRiskManagement);

                        var getEmcConcernInternalControl = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.InternalControl).ToList();
                        allEmcConcernInternalControl.AddRange(getEmcConcernInternalControl);

                        var getEmcConcernTreasury = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Treasury).ToList();
                        allEmcConcernTreasury.AddRange(getEmcConcernTreasury);

                        var getEmcConcernLegal = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Legal).ToList();
                        allEmcConcernLegal.AddRange(getEmcConcernLegal);

                        var getEmcConcernMCC = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.MCC).ToList();
                        allEmcConcernMCC.AddRange(getEmcConcernMCC);

                        var getEmcConcernFinancialControl = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.FinancialControl).ToList();
                        allEmcConcernFinancialControl.AddRange(getEmcConcernFinancialControl);

                        var getEmcConcernCompliance = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Compliance).ToList();
                        allEmcConcernCompliance.AddRange(getEmcConcernCompliance);

                        var getEmcConcernCustomerExperience = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.CustomerExperience).ToList();
                        allEmcConcernCustomerExperience.AddRange(getEmcConcernCustomerExperience);

                        var getEmcConcernInfoSecurity = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.InfoSecurity).ToList();
                        allEmcConcernInfoSecurity.AddRange(getEmcConcernInfoSecurity);

                        var getEmcConcernProcurementAndAdmin = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ProcurementAndAdmin).ToList();
                        allEmcConcernProcurementAndAdmin.AddRange(getEmcConcernProcurementAndAdmin);

                    }
                    // Calculate the sum and average for the first three records
                    var recordHCM = allEmcConcernHCM.ToList();
                    var recordIT = allEmcConcernIT.ToList();
                    var recordCTO = allEmcConcernCTO.ToList();
                    var recordAcademy = allEmcConcernAcademy.ToList();
                    var recordDataAnalytic = allEmcConcernDataAnalytic.ToList();
                    var recordCorporateStrategy = allEmcConcernCorporateStrategy.ToList();
                    var recordInternalControl = allEmcConcernInternalControl.ToList();
                    var recordRiskManagement = allEmcConcernRiskManagement.ToList();
                    var recordTreasury = allEmcConcernTreasury.ToList();
                    var recordLegal = allEmcConcernLegal.ToList();
                    var recordMCC = allEmcConcernMCC.ToList();
                    var recordFinancialControl = allEmcConcernFinancialControl.ToList();
                    var recordCompliance = allEmcConcernCompliance.ToList();
                    var recordCustomerExperience = allEmcConcernCustomerExperience.ToList();
                    var recordInfoSecurity = allEmcConcernInfoSecurity.ToList();
                    var recordProcurementAndAdmin = allEmcConcernProcurementAndAdmin.ToList();

                    //decimal recordHCM = recordHCM.Sum();

                    decimal averageEMCHCM = recordHCM.Any() ? recordHCM.Average() : 0;
                    decimal averageEMCIT = recordIT.Any() ? recordIT.Average() : 0;
                    decimal averageEMCCTO = recordCTO.Any() ? recordCTO.Average() : 0;
                    decimal averageEMCAcademy = recordAcademy.Any() ? recordAcademy.Average() : 0;
                    decimal averageEMCDataAnalytic = recordDataAnalytic.Any() ? recordDataAnalytic.Average() : 0;
                    decimal averageEMCCorporateStrategy = recordCorporateStrategy.Any() ? recordCorporateStrategy.Average() : 0;
                    decimal averageEMCInternalControl = recordInternalControl.Any() ? recordInternalControl.Average() : 0;
                    decimal averageEMCRiskManagement = recordRiskManagement.Any() ? recordRiskManagement.Average() : 0;
                    decimal averageEMCTreasury = recordTreasury.Any() ? recordTreasury.Average() : 0;
                    decimal averageEMCLegal = recordLegal.Any() ? recordLegal.Average() : 0;
                    decimal averageEMCMCC = recordMCC.Any() ? recordMCC.Average() : 0;
                    decimal averageEMCFinancialControl = recordFinancialControl.Any() ? recordFinancialControl.Average() : 0;
                    decimal averageEMCCompliance = recordCompliance.Any() ? recordCompliance.Average() : 0;
                    decimal averageEMCCustomerExperience = recordCustomerExperience.Any() ? recordCustomerExperience.Average() : 0;
                    decimal averageEMCInfoSecurity = recordInfoSecurity.Any() ? recordInfoSecurity.Average() : 0;
                    decimal averageEMCProcurementAndAdmin = recordProcurementAndAdmin.Any() ? recordProcurementAndAdmin.Average() : 0;
                   
                    
                    var getEmcConcernDataRating = averageEMCDataAnalytic + averageEMCDataAnalytic;
                    var getEmcConcernAcadRating = averageEMCAcademy + averageEMCAcademy;
                    var getEmcConcernCorpSetrRating = averageEMCCorporateStrategy + averageEMCCorporateStrategy;
                    var getEmcConcernInterCtrlRating = averageEMCInternalControl + averageEMCInternalControl;
                    var getEmcConcernRiskMgtRating = averageEMCRiskManagement + averageEMCRiskManagement;
                    var getEmcConcernCTORating = averageEMCCTO + averageEMCCTO;
                    var getEmcConcernTreasuryRating = averageEMCTreasury + averageEMCTreasury;
                    var getEmcConcernHCMRating = averageEMCHCM + averageEMCHCM;
                    var getEmcConcernLegalRating = averageEMCLegal + averageEMCLegal;
                    var getEmcConcernITRating = averageEMCIT + averageEMCIT;
                    var getEmcConcernMCCRating = averageEMCMCC + averageEMCMCC;
                    var getEmcConcernFinCtrlRating = averageEMCFinancialControl + averageEMCFinancialControl;
                    var getEmcConcernCompRating = averageEMCCompliance + averageEMCCompliance;
                    var getEmcConcernCustExpRating = averageEMCCustomerExperience + averageEMCCustomerExperience;
                    var getEmcConcernInfSecRating = averageEMCInfoSecurity + averageEMCInfoSecurity;
                    var getEmcConcernProcRating = averageEMCProcurementAndAdmin + averageEMCProcurementAndAdmin;


                    #endregion


                    #region HCM 

                    string riskRatingHcm = "";
                    string recommentationHcm = "";
                    var RiskScoreStrategyHcm = (getstrategyhcm / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationHcm = (getoperhcm / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreComplianceHcm = (getcompliancemchcm / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastauditHcm = (gettimeSinceLastSharedAudit.HCM / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingHcm = (getEmcConcernHCMRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var riskScoreHcm = (decimal)RiskScoreStrategyHcm + (decimal)RiskScoreOperationHcm + (decimal)RiskScoreComplianceHcm + (decimal)RiskScoreTimesinceLastauditHcm + RiskScoreEMCRatingHcm;
                    var oldRiskScoreHcm = 0;
                   
                    if (riskScoreHcm < 0.4m)
                    {
                        riskRatingHcm = "Very Low";
                        recommentationHcm = "Spot Check";
                    }
                    if (riskScoreHcm >= 0.4m && riskScoreHcm < 0.5m)
                    {
                        riskRatingHcm = "Low";
                        recommentationHcm = "Spot Check";
                    }
                    if (riskScoreHcm >= 0.5m && riskScoreHcm < 0.65m)
                    {
                        riskRatingHcm = "Medium";
                        recommentationHcm = "Partial Scope";
                    }
                    if (riskScoreHcm >= 0.65m && riskScoreHcm < 0.8m)
                    {
                        riskRatingHcm = "High";
                        recommentationHcm = "Full Scope";
                    }
                    if (riskScoreHcm >= 0.8m)
                    {
                        riskRatingHcm = "Very High";
                        recommentationHcm = "Full Scope";
                    }
                    #endregion

                    #region Legal Legal

                    string riskRatingLegal = "";
                    string recommentationLegal = "";
                    var RiskScoreStrategyLegal = (getstrategylegal / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationLegal = (getoperationclegal / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreComplianceLegal = (getcomplianceLegal / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastauditLegal = (gettimeSinceLastSharedAudit.Legal / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingLegal = (getEmcConcernLegalRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var riskScoreLegal = (decimal)RiskScoreStrategyLegal + (decimal)RiskScoreOperationLegal + (decimal)RiskScoreComplianceLegal + (decimal)RiskScoreTimesinceLastauditLegal + RiskScoreEMCRatingLegal;
                    var oldRiskScoreLegal = 0;
                  
                    if (riskScoreLegal < 0.4m)
                    {
                        riskRatingLegal = "Very Low";
                        recommentationLegal = "Spot Check";
                    }
                    if (riskScoreLegal >= 0.4m && riskScoreLegal < 0.5m)
                    {
                        riskRatingLegal = "Low";
                        recommentationLegal = "Spot Check";
                    }
                    if (riskScoreLegal >= 0.5m && riskScoreLegal < 0.65m)
                    {
                        riskRatingLegal = "Medium";
                        recommentationLegal = "Partial Scope";
                    }
                    if (riskScoreLegal >= 0.65m && riskScoreLegal < 0.8m)
                    {
                        riskRatingLegal = "High";
                        recommentationLegal = "Full Scope";
                    }
                    if (riskScoreLegal >= 0.8m)
                    {
                        riskRatingLegal = "Very High";
                        recommentationLegal = "Full Scope";
                    }
                    #endregion

                    #region Finacial ctrl                  
                    string riskRatingFinCtrl = "";
                    string recommentationFinCtrl = "";
                    var RiskScoreStrategyFinCtrl = (getstraFinCtrl / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationFinCtrl = (getoperationFinCtrl / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreComplianceFinCtrl = (getcomplianceFinTrl / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastauditFinCtrl = (gettimeSinceLastSharedAudit.FinancialControl / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingFinCtrl = (getEmcConcernFinCtrlRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    
                    var riskScoreFinCtrl = (decimal)RiskScoreStrategyFinCtrl + (decimal)RiskScoreOperationFinCtrl + (decimal)RiskScoreComplianceFinCtrl + RiskScoreEMCRatingFinCtrl + (decimal)RiskScoreTimesinceLastauditFinCtrl;

                    var oldRiskScoreFinCtrl = 0;
                    
                    if (riskScoreFinCtrl < 0.4m)
                    {
                        riskRatingFinCtrl = "Very Low";
                        recommentationFinCtrl = "Spot Check";
                    }
                    if (riskScoreFinCtrl >= 0.4m && riskScoreFinCtrl < 0.5m)
                    {
                        riskRatingFinCtrl = "Low";
                        recommentationFinCtrl = "Spot Check";
                    }
                    if (riskScoreFinCtrl >= 0.5m && riskScoreFinCtrl < 0.65m)
                    {
                        riskRatingFinCtrl = "Medium";
                        recommentationFinCtrl = "Partial Scope";
                    }
                    if (riskScoreFinCtrl >= 0.65m && riskScoreFinCtrl < 0.8m)
                    {
                        riskRatingFinCtrl = "High";
                        recommentationFinCtrl = "Full Scope";
                    }
                    if (riskScoreFinCtrl >= 0.8m)
                    {
                        riskRatingFinCtrl = "Very High";
                        recommentationFinCtrl = "Full Scope";
                    }
                    #endregion

                    #region Compliance                  

                    string riskRatingCompl = "";
                    string recommentationCompl = "";
                    var RiskScoreStrategyCompl = (getstrategyCompl / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationCompl = (getoperCompl / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreComplianceCompl = (getcompCompl / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastauditCompl = (gettimeSinceLastSharedAudit.Compliance / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingCompl = (getEmcConcernCompRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var riskScoreCompl = (decimal)RiskScoreStrategyCompl + (decimal)RiskScoreOperationCompl + (decimal)RiskScoreComplianceCompl + RiskScoreEMCRatingCompl + (decimal)RiskScoreTimesinceLastauditCompl;

                    var oldRiskScoreCompl = 0;
                  
                    if (riskScoreCompl < 0.4m)
                    {
                        riskRatingCompl = "Very Low";
                        recommentationCompl = "Spot Check";
                    }
                    if (riskScoreCompl >= 0.4m && riskScoreCompl < 0.5m)
                    {
                        riskRatingCompl = "Low";
                        recommentationCompl = "Spot Check";
                    }
                    if (riskScoreCompl >= 0.5m && riskScoreCompl < 0.65m)
                    {
                        riskRatingCompl = "Medium";
                        recommentationCompl = "Partial Scope";
                    }
                    if (riskScoreCompl >= 0.65m && riskScoreCompl < 0.8m)
                    {
                        riskRatingCompl = "High";
                        recommentationCompl = "Full Scope";
                    }
                    if (riskScoreCompl >= 0.8m)
                    {
                        riskRatingCompl = "Very High";
                        recommentationCompl = "Full Scope";
                    }
                    #endregion

                    #region CusExp CusExp

                    string riskRatingCusExp = "";
                    string recommentationCusExp = "";
                    var RiskScoreStrategyCusExp = (getstrategycustexp / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationCusExp = (getoperationcustexp / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreComplianceCusExp = (getcomplianceCustExp / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastauditCusExp = (gettimeSinceLastSharedAudit.Customerexperience / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingCusExp = (getEmcConcernCustExpRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var riskScoreCusExp = (decimal)RiskScoreStrategyCusExp + (decimal)RiskScoreOperationCusExp + (decimal)RiskScoreComplianceCusExp + (decimal)RiskScoreTimesinceLastauditCusExp + RiskScoreEMCRatingCusExp;
                    var oldRiskScoreCusExp = 0;
                   
                    if (riskScoreCusExp < 0.4m)
                    {
                        riskRatingCusExp = "Very Low";
                        recommentationCusExp = "Spot Check";
                    }
                    if (riskScoreCusExp >= 0.4m && riskScoreCusExp < 0.5m)
                    {
                        riskRatingCusExp = "Low";
                        recommentationCusExp = "Spot Check";
                    }
                    if (riskScoreCusExp >= 0.5m && riskScoreCusExp < 0.65m)
                    {
                        riskRatingCusExp = "Medium";
                        recommentationCusExp = "Partial Scope";
                    }
                    if (riskScoreCusExp >= 0.65m && riskScoreCusExp < 0.8m)
                    {
                        riskRatingCusExp = "High";
                        recommentationCusExp = "Full Scope";
                    }
                    if (riskScoreCusExp >= 0.8m)
                    {
                        riskRatingCusExp = "Very High";
                        recommentationCusExp = "Full Scope";
                    }
                    #endregion

                    #region  InfoSecurity

                    string riskRatingInfoSec = "";
                    string recommentationInfoSec = "";
                    var RiskScoreStrategyInfoSec = (getstrategyinfsec / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationInfoSec = (getoperinfosec / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreComplianceInfoSec = (getcomplianceinfosec / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastauditInfoSec = (gettimeSinceLastSharedAudit.InformationSecurity / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingInfoSec = (getEmcConcernInfSecRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var riskScoreInfoSec = (decimal)RiskScoreStrategyInfoSec + (decimal)RiskScoreOperationInfoSec + (decimal)RiskScoreComplianceInfoSec + (decimal)RiskScoreTimesinceLastauditInfoSec + RiskScoreEMCRatingInfoSec;
                    var oldRiskScoreInfoSec = 0;
                   
                    if (riskScoreInfoSec < 0.4m)
                    {
                        riskRatingInfoSec = "Very Low";
                        recommentationInfoSec = "Spot Check";
                    }
                    if (riskScoreInfoSec >= 0.4m && riskScoreInfoSec < 0.5m)
                    {
                        riskRatingInfoSec = "Low";
                        recommentationInfoSec = "Spot Check";
                    }
                    if (riskScoreInfoSec >= 0.5m && riskScoreInfoSec < 0.65m)
                    {
                        riskRatingInfoSec = "Medium";
                        recommentationInfoSec = "Partial Scope";
                    }
                    if (riskScoreInfoSec >= 0.65m && riskScoreInfoSec < 0.8m)
                    {
                        riskRatingInfoSec = "High";
                        recommentationInfoSec = "Full Scope";
                    }
                    if (riskScoreInfoSec >= 0.8m)
                    {
                        riskRatingInfoSec = "Very High";
                        recommentationInfoSec = "Full Scope";
                    }
                    #endregion

                    #region ProcurementAndAdmin

                    string riskRatingProcurementAndAdmin = "";
                    string recommentationProcurementAndAdmin = "";
                    var RiskScoreStrategyProcurementAndAdmin = (getstrategyadmin / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationProcurementAndAdmin = (getoperadmin / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditProcurementAndAdmin = (gettimeSinceLastSharedAudit.ProcurementAndAdmind / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingProcurementAndAdmin = (getEmcConcernProcRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreProc = (decimal)RiskScoreStrategyProcurementAndAdmin + (decimal)RiskScoreOperationProcurementAndAdmin + (decimal)RiskScoreTimesinceLastauditProcurementAndAdmin + RiskScoreEMCRatingProcurementAndAdmin;
                    var riskScoreProcurementAndAdmin = (scoreProc / 90) * 100;
                    var oldRiskScoreProcurementAndAdmin = 0;
                   
                    if (riskScoreProcurementAndAdmin < 0.4m)
                    {
                        riskRatingProcurementAndAdmin = "Very Low";
                        recommentationProcurementAndAdmin = "Spot Check";
                    }
                    if (riskScoreProcurementAndAdmin >= 0.4m && riskScoreProcurementAndAdmin < 0.5m)
                    {
                        riskRatingProcurementAndAdmin = "Low";
                        recommentationProcurementAndAdmin = "Spot Check";
                    }
                    if (riskScoreProcurementAndAdmin >= 0.5m && riskScoreProcurementAndAdmin < 0.65m)
                    {
                        riskRatingProcurementAndAdmin = "Medium";
                        recommentationProcurementAndAdmin = "Partial Scope";
                    }
                    if (riskScoreProcurementAndAdmin >= 0.65m && riskScoreProcurementAndAdmin < 0.8m)
                    {
                        riskRatingProcurementAndAdmin = "High";
                        recommentationProcurementAndAdmin = "Full Scope";
                    }
                    if (riskScoreProcurementAndAdmin >= 0.8m)
                    {
                        riskRatingProcurementAndAdmin = "Very High";
                        recommentationProcurementAndAdmin = "Full Scope";
                    }
                    #endregion

                    #region IT IT

                    string riskRatingIt = "";
                    string recommentationIt = "";
                    var riskScoreStrategyIt = (getstrategyIt / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var riskScoreOperationIt = (getoperationit / (double)maximumPossibleOperationBusinessMgtRating) * strategyWeight;                    
                    var riskScoreTimesinceLastauditIt = (gettimeSinceLastSharedAudit.IT / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var riskScoreEMCRatingIt = (getEmcConcernITRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreIT = (decimal)riskScoreStrategyIt + (decimal)riskScoreOperationIt + (decimal)riskScoreTimesinceLastauditIt + riskScoreEMCRatingIt;
                    var riskScoreIt = (scoreIT / 90) * 100;
                    var oldRiskScoreIt = 0;
                   
                    if (riskScoreIt < 0.4m)
                    {
                        riskRatingIt = "Very Low";
                        recommentationIt = "Spot Check";
                    }
                    if (riskScoreIt >= 0.4m && riskScoreIt < 0.5m)
                    {
                        riskRatingIt = "Low";
                        recommentationIt = "Spot Check";
                    }
                    if (riskScoreIt >= 0.5m && riskScoreIt < 0.65m)
                    {
                        riskRatingIt = "Medium";
                        recommentationIt = "Partial Scope";
                    }
                    if (riskScoreIt >= 0.65m && riskScoreIt < 0.8m)
                    {
                        riskRatingIt = "High";
                        recommentationIt = "Full Scope";
                    }
                    if (riskScoreIt >= 0.8m)
                    {
                        riskRatingIt = "Very High";
                        recommentationIt = "Full Scope";
                    }
                    #endregion

                    #region Data Analytic                  

                    string riskRatingData = "";
                    string recommentationData = "";
                    var RiskScoreStrategyData = (getstrategyDataAna / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationData = (getoperationDataAna / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditData = (gettimeSinceLastSharedAudit.DataAnalytic / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingData = (getEmcConcernDataRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreDataAna = (decimal)RiskScoreStrategyData + (decimal)RiskScoreOperationData + (decimal)RiskScoreTimesinceLastauditData + RiskScoreEMCRatingData;

                    var riskScoreData = (scoreDataAna / 90) * 100;

                    var oldRiskScoreData = 0;
                    
                    if (riskScoreData < 0.4m)
                    {
                        riskRatingData = "Very Low";
                        recommentationData = "Spot Check";
                    }
                    if (riskScoreData >= 0.4m && riskScoreData < 0.5m)
                    {
                        riskRatingData = "Low";
                        recommentationData = "Spot Check";
                    }
                    if (riskScoreData >= 0.5m && riskScoreData < 0.65m)
                    {
                        riskRatingData = "Medium";
                        recommentationData = "Partial Scope";
                    }
                    if (riskScoreData >= 0.65m && riskScoreData < 0.8m)
                    {
                        riskRatingData = "High";
                        recommentationData = "Full Scope";
                    }
                    if (riskScoreData >= 0.8m)
                    {
                        riskRatingData = "Very High";
                        recommentationData = "Full Scope";
                    }
                    #endregion

                    #region MCC MCC

                    string riskRatingMcc = "";
                    string recommentationMcc = "";
                    var RiskScoreStrategyMcc = (getstrategymcc / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationMcc = (getopermcc / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditMcc = (gettimeSinceLastSharedAudit.MCC / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingMcc = (getEmcConcernMCCRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreMCC = (decimal)RiskScoreStrategyMcc + (decimal)RiskScoreOperationMcc + (decimal)RiskScoreTimesinceLastauditMcc + RiskScoreEMCRatingMcc;
                    var riskScoreMcc = (scoreMCC / 90) * 100;
                    var oldRiskScoreMcc = 0;
                    
                    if (riskScoreMcc < 0.4m)
                    {
                        riskRatingMcc = "Very Low";
                        recommentationMcc = "Spot Check";
                    }
                    if (riskScoreMcc >= 0.4m && riskScoreMcc < 0.5m)
                    {
                        riskRatingMcc = "Low";
                        recommentationMcc = "Spot Check";
                    }
                    if (riskScoreMcc >= 0.5m && riskScoreMcc < 0.65m)
                    {
                        riskRatingMcc = "Medium";
                        recommentationMcc = "Partial Scope";
                    }
                    if (riskScoreMcc >= 0.65m && riskScoreMcc < 0.8m)
                    {
                        riskRatingMcc = "High";
                        recommentationMcc = "Full Scope";
                    }
                    if (riskScoreMcc >= 0.8m)
                    {
                        riskRatingMcc = "Very High";
                        recommentationMcc = "Full Scope";
                    }
                    #endregion

                    #region Treasury Treasury

                    string riskRatingTres = "";
                    string recommentationTres = "";
                    var RiskScoreStrategyTres = (getstraTreasury / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationTres = (getopertreasury / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditTres = (gettimeSinceLastSharedAudit.Treasury / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingTres = (getEmcConcernTreasuryRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreTreasury = (decimal)RiskScoreStrategyTres + (decimal)RiskScoreOperationTres + (decimal)RiskScoreTimesinceLastauditTres + RiskScoreEMCRatingTres;
                    var riskScoreTres = (scoreTreasury / 90) * 100;
                    var oldRiskScoreTres = 0;
                    
                    if (riskScoreTres < 0.4m)
                    {
                        riskRatingTres = "Very Low";
                        recommentationTres = "Spot Check";
                    }
                    if (riskScoreTres >= 0.4m && riskScoreTres < 0.5m)
                    {
                        riskRatingTres = "Low";
                        recommentationTres = "Spot Check";
                    }
                    if (riskScoreTres >= 0.5m && riskScoreTres < 0.65m)
                    {
                        riskRatingTres = "Medium";
                        recommentationTres = "Partial Scope";
                    }
                    if (riskScoreTres >= 0.65m && riskScoreTres < 0.8m)
                    {
                        riskRatingTres = "High";
                        recommentationTres = "Full Scope";
                    }
                    if (riskScoreTres >= 0.8m)
                    {
                        riskRatingTres = "Very High";
                        recommentationTres = "Full Scope";
                    }
                    #endregion

                    #region Academy Academy

                    string riskRatingAca = "";
                    string recommentationAca = "";
                    var RiskScoreStrategyAca = (getstrategyacade / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationAca = (getoperacademy / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditAca = (gettimeSinceLastSharedAudit.Academy / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingAca = (getEmcConcernAcadRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreAca = (decimal)RiskScoreStrategyAca + (decimal)RiskScoreOperationAca + (decimal)RiskScoreTimesinceLastauditAca + RiskScoreEMCRatingAca;
                    var riskScoreAca = (scoreAca / 90) * 100;
                    var oldRiskScoreAca = 0;
                   
                    if (riskScoreAca < 0.4m)
                    {
                        riskRatingAca = "Very Low";
                        recommentationAca = "Spot Check";
                    }
                    if (riskScoreAca >= 0.4m && riskScoreAca < 0.5m)
                    {
                        riskRatingAca = "Low";
                        recommentationAca = "Spot Check";
                    }
                    if (riskScoreAca >= 0.5m && riskScoreAca < 0.65m)
                    {
                        riskRatingAca = "Medium";
                        recommentationAca = "Partial Scope";
                    }
                    if (riskScoreAca >= 0.65m && riskScoreAca < 0.8m)
                    {
                        riskRatingAca = "High";
                        recommentationAca = "Full Scope";
                    }
                    if (riskScoreAca >= 0.8m)
                    {
                        riskRatingAca = "Very High";
                        recommentationAca = "Full Scope";
                    }
                    #endregion

                    #region Corporatestrategy

                    string riskRatingCoSt = "";
                    string recommentationCoSt = "";
                    var RiskScoreStrategyCoSt = (getstrategycorpstra / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationCoSt = (getoperationcorpat / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditCoSt = (gettimeSinceLastSharedAudit.Corporatestrategy / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingCoSt = (getEmcConcernCorpSetrRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreCorp = (decimal)RiskScoreStrategyCoSt + (decimal)RiskScoreOperationCoSt + (decimal)RiskScoreTimesinceLastauditCoSt + RiskScoreEMCRatingCoSt;
                    var riskScoreCoSt = (scoreCorp / 90) * 100;
                    var oldRiskScoreCoSt = 0;
                    
                    if (riskScoreCoSt < 0.4m)
                    {
                        riskRatingCoSt = "Very Low";
                        recommentationCoSt = "Spot Check";
                    }
                    if (riskScoreCoSt >= 0.4m && riskScoreCoSt < 0.5m)
                    {
                        riskRatingCoSt = "Low";
                        recommentationCoSt = "Spot Check";
                    }
                    if (riskScoreCoSt >= 0.5m && riskScoreCoSt < 0.65m)
                    {
                        riskRatingCoSt = "Medium";
                        recommentationCoSt = "Partial Scope";
                    }
                    if (riskScoreCoSt >= 0.65m && riskScoreCoSt < 0.8m)
                    {
                        riskRatingCoSt = "High";
                        recommentationCoSt = "Full Scope";
                    }
                    if (riskScoreCoSt >= 0.8m)
                    {
                        riskRatingCoSt = "Very High";
                        recommentationCoSt = "Full Scope";
                    }
                    #endregion

                    #region CTO CTO

                    string riskRatingCTO = "";
                    string recommentationCTO = "";
                    var RiskScoreStrategyCTO = (getstrategyCTO / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationCTO = (getoperCTO / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditCTO = (gettimeSinceLastSharedAudit.CTO / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingCTO = (getEmcConcernCTORating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreCTO = (decimal)RiskScoreStrategyCTO + (decimal)RiskScoreOperationCTO + (decimal)RiskScoreTimesinceLastauditCTO + RiskScoreEMCRatingCTO;
                    var riskScoreCTO = (scoreCTO / 90) * 100;
                    var oldRiskScoreCTO = 0;
                   
                    if (riskScoreCTO < 0.4m)
                    {
                        riskRatingCTO = "Very Low";
                        recommentationCTO = "Spot Check";
                    }
                    if (riskScoreCTO >= 0.4m && riskScoreCTO < 0.5m)
                    {
                        riskRatingCTO = "Low";
                        recommentationCTO = "Spot Check";
                    }
                    if (riskScoreCTO >= 0.5m && riskScoreCTO < 0.65m)
                    {
                        riskRatingCTO = "Medium";
                        recommentationCTO = "Partial Scope";
                    }
                    if (riskScoreCTO >= 0.65m && riskScoreCTO < 0.8m)
                    {
                        riskRatingCTO = "High";
                        recommentationCTO = "Full Scope";
                    }
                    if (riskScoreCTO >= 0.8m)
                    {
                        riskRatingCTO = "Very High";
                        recommentationCTO = "Full Scope";
                    }
                    #endregion

                    #region InternalControl

                    string riskRatingIntCtrl = "";
                    string recommentationIntCtrl = "";
                    var RiskScoreStrategyIntCtrl = (getstrategyintctrl / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationIntCtrl = (getoperIntCtrl / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditIntCtrl = (gettimeSinceLastSharedAudit.InternalControl / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingIntCtrl = (getEmcConcernInterCtrlRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreIntCtrl = (decimal)RiskScoreStrategyIntCtrl + (decimal)RiskScoreOperationIntCtrl + (decimal)RiskScoreTimesinceLastauditIntCtrl + RiskScoreEMCRatingIntCtrl;
                    var riskScoreIntCtrl = (scoreIntCtrl / 90) * 100;
                    var oldRiskScoreIntCtrl = 0;
                   
                    if (riskScoreIntCtrl < 0.4m)
                    {
                        riskRatingIntCtrl = "Very Low";
                        recommentationIntCtrl = "Spot Check";
                    }
                    if (riskScoreIntCtrl >= 0.4m && riskScoreIntCtrl < 0.5m)
                    {
                        riskRatingIntCtrl = "Low";
                        recommentationIntCtrl = "Spot Check";
                    }
                    if (riskScoreIntCtrl >= 0.5m && riskScoreIntCtrl < 0.65m)
                    {
                        riskRatingIntCtrl = "Medium";
                        recommentationIntCtrl = "Partial Scope";
                    }
                    if (riskScoreIntCtrl >= 0.65m && riskScoreIntCtrl < 0.8m)
                    {
                        riskRatingIntCtrl = "High";
                        recommentationIntCtrl = "Full Scope";
                    }
                    if (riskScoreIntCtrl >= 0.8m)
                    {
                        riskRatingIntCtrl = "Very High";
                        recommentationIntCtrl = "Full Scope";
                    }
                    #endregion

                    #region RiskManagement

                    string riskRatingRstMgt = "";
                    string recommentationRstMgt = "";
                    var RiskScoreStrategyRstMgt = (getstrategyriskmgt / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationRstMgt = (getoperriskmgt / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreTimesinceLastauditRstMgt = (gettimeSinceLastSharedAudit.RiskManagement / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoreEMCRatingRstMgt = (getEmcConcernRiskMgtRating / (decimal)maximumPossibleEMCConcernMgtRating) * magtConcernWeight;
                    var scoreRiskMgt = (decimal)RiskScoreStrategyRstMgt + (decimal)RiskScoreOperationRstMgt + (decimal)RiskScoreTimesinceLastauditRstMgt + RiskScoreEMCRatingRstMgt;
                    var riskScoreRstMgt = (scoreRiskMgt / 90) * 100;
                    var oldRiskScoreRstMgt = 0;
                    
                    if (riskScoreRstMgt < 0.4m)
                    {
                        riskRatingRstMgt = "Very Low";
                        recommentationRstMgt = "Spot Check";
                    }
                    if (riskScoreRstMgt >= 0.4m && riskScoreRstMgt < 0.5m)
                    {
                        riskRatingRstMgt = "Low";
                        recommentationRstMgt = "Spot Check";
                    }
                    if (riskScoreRstMgt >= 0.5m && riskScoreRstMgt < 0.65m)
                    {
                        riskRatingRstMgt = "Medium";
                        recommentationRstMgt = "Partial Scope";
                    }
                    if (riskScoreRstMgt >= 0.65m && riskScoreRstMgt < 0.8m)
                    {
                        riskRatingRstMgt = "High";
                        recommentationRstMgt = "Full Scope";
                    }
                    if (riskScoreRstMgt >= 0.8m)
                    {
                        riskRatingRstMgt = "Very High";
                        recommentationRstMgt = "Full Scope";
                    }
                    #endregion


                    #region  Log audit universe   

                    var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                    if (getannualauditId == null)
                    {
                        var logRequestId = AnualAuditUniverseRiskRating.Create(getRating.RequesterName, businessriskratingId);
                        await annualaudit.AddAsync(logRequestId);

                        var logreq = ARMSharedAuditUniverse.Create(getRating.RequesterName, logRequestId.Id);
                        await sharedaudit.AddAsync(logreq);

                        var logCompl = ARMSharedAuditUniverseCompliance.Create(logreq.Id, oldRiskScoreCompl.ToString("0.000"), averageEMCCompliance, averageEMCCompliance,
                                        riskScoreCompl.ToString("0.000"), riskRatingCompl, recommentationCompl);
                        await compAudit.AddAsync(logCompl);

                        var logData = ARMSharedAuditUniverseDataAnalytic.Create(logreq.Id, oldRiskScoreData.ToString("0.000"), averageEMCDataAnalytic, averageEMCDataAnalytic,
                                       riskScoreData.ToString("0.000"), riskRatingData, recommentationData);
                        await dataAudit.AddAsync(logData);

                        var logstraFinCtrl = ARMSharedAuditUniverseFinancialControl.Create(logreq.Id, oldRiskScoreFinCtrl.ToString("0.000"), averageEMCFinancialControl, averageEMCFinancialControl,
                                            riskScoreFinCtrl.ToString("0.000"), riskRatingFinCtrl, recommentationFinCtrl);
                        await finCtrlAudit.AddAsync(logstraFinCtrl);

                        var logacademy = ARMSharedAuditUniverseAcademy.Create(logreq.Id, oldRiskScoreAca.ToString("0.000"), averageEMCAcademy, averageEMCAcademy,
                                        riskScoreAca.ToString("0.000"), riskRatingAca, recommentationAca);
                        await academyaudit.AddAsync(logacademy);

                        var locorporateStrategy = ARMSharedAuditUniverseCorporatestrategy.Create(logreq.Id, oldRiskScoreCoSt.ToString("0.000"), averageEMCCorporateStrategy, averageEMCCorporateStrategy,
                                        riskScoreCoSt.ToString("0.000"), riskRatingCoSt, recommentationCoSt);
                        await corporateStrategy.AddAsync(locorporateStrategy);

                        var logmcc = ARMSharedAuditUniverseMCC.Create(logreq.Id, oldRiskScoreMcc.ToString("0.000"), averageEMCMCC, averageEMCMCC,
                                       riskScoreMcc.ToString("0.000"), riskRatingMcc, recommentationMcc);
                        await mccAudit.AddAsync(logmcc);                                                                                                                        

                        var logtreasure = ARMSharedAuditUniverseTreasury.Create(logreq.Id, oldRiskScoreTres.ToString("0.000"), averageEMCTreasury, averageEMCTreasury,
                                         riskScoreTres.ToString("0.000"), riskRatingTres, recommentationTres);
                        await treasureaudit.AddAsync(logtreasure);

                        var logCTO = ARMSharedAuditUniverseCTO.Create(logreq.Id, oldRiskScoreCTO.ToString("0.000"), averageEMCCTO, averageEMCCTO,
                                          riskScoreCTO.ToString("0.000"), riskRatingCTO, recommentationCTO);
                        await CTOaudit.AddAsync(logCTO);

                        var logcustomerExperience = ARMSharedAuditUniverseCustomerExperience.Create(logreq.Id, oldRiskScoreCusExp.ToString("0.000"), averageEMCCustomerExperience, averageEMCCustomerExperience,
                                          riskScoreCusExp.ToString("0.000"), riskRatingCusExp, recommentationCusExp);
                        await customerExperience.AddAsync(logcustomerExperience);

                        var loginternalControl = ARMSharedAuditUniverseInternalControl.Create(logreq.Id, oldRiskScoreIntCtrl.ToString("0.000"), averageEMCInternalControl, averageEMCInternalControl,
                                           riskScoreIntCtrl.ToString("0.000"), riskRatingIntCtrl, recommentationIntCtrl);
                        await internalControl.AddAsync(loginternalControl);

                        var logprocurementandAdmin = ARMSharedAuditUniverseProcurementAndAdmin.Create(logreq.Id, oldRiskScoreProcurementAndAdmin.ToString("0.000"), averageEMCProcurementAndAdmin, averageEMCProcurementAndAdmin,
                                          riskScoreProcurementAndAdmin.ToString("0.000"), riskRatingProcurementAndAdmin, recommentationProcurementAndAdmin);
                        await procurementandAdmin.AddAsync(logprocurementandAdmin);

                        var loglegal = ARMSharedAuditUniverseLegal.Create(logreq.Id, oldRiskScoreLegal.ToString("0.000"), averageEMCLegal, averageEMCLegal,
                                          riskScoreLegal.ToString("0.000"), riskRatingLegal, recommentationLegal);
                        await legalaudit.AddAsync(loglegal);

                        var logriskManagement = ARMSharedAuditUniverseRiskManagement.Create(logreq.Id, oldRiskScoreRstMgt.ToString("0.000"), averageEMCRiskManagement, averageEMCRiskManagement,
                                          riskScoreRstMgt.ToString("0.000"), riskRatingRstMgt, recommentationRstMgt);
                        await riskManagement.AddAsync(logriskManagement);

                        var logIT = ARMSharedAuditUniverseIT.Create(logreq.Id, oldRiskScoreIt.ToString("0.000"), averageEMCIT, averageEMCIT,
                                            riskScoreIt.ToString("0.000"), riskRatingIt, recommentationIt);
                        await itAudit.AddAsync(logIT);

                        var loghcm = ARMSharedAuditUniverseHCM.Create(logreq.Id, oldRiskScoreHcm.ToString("0.000"), averageEMCHCM, averageEMCHCM,
                                           riskScoreHcm.ToString("0.000"), riskRatingHcm, recommentationHcm);
                        await hcmaudit.AddAsync(loghcm);

                        var loginformationSecurityAudit = ARMSharedAuditUniverseInformationSecurity.Create(logreq.Id, oldRiskScoreInfoSec.ToString("0.000"), averageEMCInfoSecurity, averageEMCInfoSecurity,
                                           riskScoreInfoSec.ToString("0.000"), riskRatingInfoSec, recommentationInfoSec);
                        await informationSecurityAudit.AddAsync(loginformationSecurityAudit);

                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();
                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getannualauditId != null)
                    {
                        var getaudit = sharedaudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                        if (getaudit != null)
                        {
                            getBusinessRiskRating.ApproveBusinessRating();
                            await repo.SaveChangesAsync();
                            return TypedResults.Ok("Approved successfully");
                        }
                        if (getaudit == null)
                        {
                            var logreq2 = ARMSharedAuditUniverse.Create(getRating.RequesterName, getannualauditId.Id);
                            await sharedaudit.AddAsync(logreq2);

                            var logCompl2 = ARMSharedAuditUniverseCompliance.Create(logreq2.Id, oldRiskScoreCompl.ToString("0.000"), averageEMCCompliance, averageEMCCompliance,
                                       riskScoreCompl.ToString("0.000"), riskRatingCompl, recommentationCompl);
                            await compAudit.AddAsync(logCompl2);

                            var logData2 = ARMSharedAuditUniverseDataAnalytic.Create(logreq2.Id, oldRiskScoreData.ToString("0.000"), averageEMCDataAnalytic, averageEMCDataAnalytic,
                                           riskScoreData.ToString("0.000"), riskRatingData, recommentationData);
                            await dataAudit.AddAsync(logData2);

                            var logstraFinCtrl2 = ARMSharedAuditUniverseFinancialControl.Create(logreq2.Id, oldRiskScoreFinCtrl.ToString("0.000"), averageEMCFinancialControl, averageEMCFinancialControl,
                                                riskScoreFinCtrl.ToString("0.000"), riskRatingFinCtrl, recommentationFinCtrl);
                            await finCtrlAudit.AddAsync(logstraFinCtrl2);

                            var logacademy2 = ARMSharedAuditUniverseAcademy.Create(logreq2.Id, oldRiskScoreAca.ToString("0.000"), averageEMCAcademy, averageEMCAcademy,
                                            riskScoreAca.ToString("0.000"), riskRatingAca, recommentationAca);
                            await academyaudit.AddAsync(logacademy2);

                            var locorporateStrategy2 = ARMSharedAuditUniverseCorporatestrategy.Create(logreq2.Id, oldRiskScoreCoSt.ToString("0.000"), averageEMCCorporateStrategy, averageEMCCorporateStrategy,
                                            riskScoreCoSt.ToString("0.000"), riskRatingCoSt, recommentationCoSt);
                            await corporateStrategy.AddAsync(locorporateStrategy2);

                            var logmcc2 = ARMSharedAuditUniverseMCC.Create(logreq2.Id, oldRiskScoreMcc.ToString("0.000"), averageEMCMCC, averageEMCMCC,
                                           riskScoreMcc.ToString("0.000"), riskRatingMcc, recommentationMcc);
                            await mccAudit.AddAsync(logmcc2);

                            var logtreasure2 = ARMSharedAuditUniverseTreasury.Create(logreq2.Id, oldRiskScoreTres.ToString("0.000"), averageEMCTreasury, averageEMCTreasury,
                                             riskScoreTres.ToString("0.000"), riskRatingTres, recommentationTres);
                            await treasureaudit.AddAsync(logtreasure2);                                                                                                                               

                            var logCTO2 = ARMSharedAuditUniverseCTO.Create(logreq2.Id, oldRiskScoreCTO.ToString("0.000"), averageEMCCTO, averageEMCCTO,
                                              riskScoreCTO.ToString("0.000"), riskRatingCTO, recommentationCTO);
                            await CTOaudit.AddAsync(logCTO2);

                            var logcustomerExperience2 = ARMSharedAuditUniverseCustomerExperience.Create(logreq2.Id, oldRiskScoreCusExp.ToString("0.000"), averageEMCCustomerExperience, averageEMCCustomerExperience,
                                              riskScoreCusExp.ToString("0.000"), riskRatingCusExp, recommentationCusExp);
                            await customerExperience.AddAsync(logcustomerExperience2);

                            var loginternalControl2 = ARMSharedAuditUniverseInternalControl.Create(logreq2.Id, oldRiskScoreIntCtrl.ToString("0.000"), averageEMCInternalControl, averageEMCInternalControl,
                                               riskScoreIntCtrl.ToString("0.000"), riskRatingIntCtrl, recommentationIntCtrl);
                            await internalControl.AddAsync(loginternalControl2);

                            var logprocurementandAdmin2 = ARMSharedAuditUniverseProcurementAndAdmin.Create(logreq2.Id, oldRiskScoreProcurementAndAdmin.ToString("0.000"), averageEMCProcurementAndAdmin, averageEMCProcurementAndAdmin,
                                              riskScoreProcurementAndAdmin.ToString("0.000"), riskRatingProcurementAndAdmin, recommentationProcurementAndAdmin);
                            await procurementandAdmin.AddAsync(logprocurementandAdmin2);

                            var loglegal2 = ARMSharedAuditUniverseLegal.Create(logreq2.Id, oldRiskScoreLegal.ToString("0.000"), averageEMCLegal, averageEMCLegal,
                                              riskScoreLegal.ToString("0.000"), riskRatingLegal, recommentationLegal);
                            await legalaudit.AddAsync(loglegal2);

                            var logriskManagement2 = ARMSharedAuditUniverseRiskManagement.Create(logreq2.Id, oldRiskScoreRstMgt.ToString("0.000"), averageEMCRiskManagement, averageEMCRiskManagement,
                                              riskScoreRstMgt.ToString("0.000"), riskRatingRstMgt, recommentationRstMgt);
                            await riskManagement.AddAsync(logriskManagement2);

                            var logIT2 = ARMSharedAuditUniverseIT.Create(logreq2.Id, oldRiskScoreIt.ToString("0.000"), averageEMCIT, averageEMCIT,
                                                riskScoreIt.ToString("0.000"), riskRatingIt, recommentationIt);
                            await itAudit.AddAsync(logIT2);

                            var loghcm2 = ARMSharedAuditUniverseHCM.Create(logreq2.Id, oldRiskScoreHcm.ToString("0.000"), averageEMCHCM, averageEMCHCM,
                                               riskScoreHcm.ToString("0.000"), riskRatingHcm, recommentationHcm);
                            await hcmaudit.AddAsync(loghcm2);

                            var loginformationSecurityAudit2 = ARMSharedAuditUniverseInformationSecurity.Create(logreq2.Id, oldRiskScoreInfoSec.ToString("0.000"), averageEMCInfoSecurity, averageEMCInfoSecurity,
                                               riskScoreInfoSec.ToString("0.000"), riskRatingInfoSec, recommentationInfoSec);
                            await informationSecurityAudit.AddAsync(loginformationSecurityAudit2);
                            getBusinessRiskRating.ApproveBusinessRating();
                            await repo.SaveChangesAsync();
                            return TypedResults.Ok("Approved successfully");
                        }
                    }
                    #endregion                  
                    return TypedResults.Ok("Approved successfully");
                }
                return TypedResults.NotFound();


            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }

    }
}
