using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 10/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* Get shareservice business risk rating by Id
*/
    public class GetARMSharedServicebusinessRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get shareservice business risk rating by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="shared"></param>
        /// <param name="strategy"></param>
        /// <param name="straFinaCtrl"></param>
        /// <param name="straTreasury"></param>
        /// <param name="strategycorpstra"></param>
        /// <param name="strategyintctrl"></param>
        /// <param name="strategyinfsec"></param>
        /// <param name="strategycustexp"></param>
        /// <param name="strategycto"></param>
        /// <param name="strategymcc"></param>
        /// <param name="strategylegal"></param>
        /// <param name="strategyacade"></param>
        /// <param name="strategyriskmgt"></param>
        /// <param name="strategyIt"></param>
        /// <param name="strategyadmin"></param>
        /// <param name="strategyhcm"></param>
        /// <param name="strategyComp"></param>
        /// <param name="strategyDataana"></param>
        /// <param name="operation"></param>
        /// <param name="operFinCtrl"></param>
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
        /// <param name="operationDataAna"></param>
        /// <param name="operationComp"></param>
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
        /// <param name="complianceComp"></param>
        /// <param name="compliancetreasury"></param>
        /// <param name="complianceFinCtrl"></param>
        /// <param name="complianceDataAna"></param>
        /// <param name="timeSinceLastSharedAudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMSharedServiceRating> shared, IRepository<StrategySharedService> strategy, IRepository<StrategySharedServiceFinancialControl> straFinaCtrl,
            IRepository<StrategySharedServiceRatingTreasury> straTreasury, IRepository<StrategySharedServiceRatingCorporatestrategy> strategycorpstra,
            IRepository<StrategySharedServiceRatingInternalControl> strategyintctrl, IRepository<StrategySharedServiceRatingInformationSecurity> strategyinfsec,
            IRepository<StrategySharedServiceRatingCustomerexperience> strategycustexp, IRepository<StrategySharedServiceRatingCTO> strategycto,
            IRepository<StrategySharedServiceRatingMCC> strategymcc, IRepository<StrategySharedServiceRatingLegal> strategylegal,
            IRepository<StrategySharedServiceRatingAcademy> strategyacade, IRepository<StrategySharedServiceRatingRiskManagement> strategyriskmgt,
            IRepository<StrategySharedServiceRatingIT> strategyIt, IRepository<StrategySharedServiceRatingProcurementAndAdmin> strategyadmin,
            IRepository<StrategySharedServiceRatingHCM> strategyhcm, IRepository<StrategySharedServiceCompliance> strategyComp,
            IRepository<StrategySharedServiceDataAnalytic> strategyDataana,

            IRepository<OperationSharedService> operation, IRepository<OperationSharedServiceFinancialControlRating> operFinCtrl, IRepository<OperationSharedServiceRatingTreasury> opertreasury,
            IRepository<OperationSharedServiceRatingCorporatestrategy> operationcorpat, IRepository<OperationSharedServiceRatingInternalControl> operIntCtrl, IRepository<OperationSharedServiceRatingInformationSecurity> operinfosec,
            IRepository<OperationSharedServiceRatingCustomerexperience> operationcustexp, IRepository<OperationSharedServiceRatingCTO> operCTO, IRepository<OperationSharedServiceRatingMCC> opermcc,
            IRepository<OperationSharedServiceRatingLegal> operationclegal, IRepository<OperationSharedServiceRatingRiskManagement> operriskmgt, IRepository<OperationSharedServiceRatingAcademy> operacademy,
            IRepository<OperationSharedServiceRatingIT> operationit, IRepository<OperationSharedServiceRatingProcurementAndAdmin> operadmin, IRepository<OperationSharedServiceRatingHCM> operhcm,
            IRepository<OperationSharedServiceDataAnalyticRating> operationDataAna, IRepository<OperationSharedServiceComplianceRating> operationComp,

            IRepository<ComplianceSharedService> compliance, IRepository<ComplianceSharedServiceRatingCustomerexperience> complianceCustExp,
            IRepository<ComplianceSharedServiceRatingCTO> complianceCTO, IRepository<ComplianceSharedServiceRatingMCC> compliancemcc,
            IRepository<ComplianceSharedServiceRatingIT> complianceIt, IRepository<ComplianceSharedServiceRatingHCM> compliancemchcm,
            IRepository<ComplianceSharedServiceRatingLegal> complianceLegal, IRepository<ComplianceSharedServiceRatingRiskManagement> complianceriskmgt,
            IRepository<ComplianceSharedServiceRatingAcademy> complianceacademy, IRepository<ComplianceSharedServiceRatingProcurementAndAdmin> complianceadmin,
            IRepository<ComplianceSharedServiceRatingCorporatestrategy> compliancecorperat, IRepository<ComplianceSharedServiceRatingInternalControl> complianceintctrl,
            IRepository<ComplianceSharedServiceRatingInformationSecurity> complianceinfosec, IRepository<ComplianceSharedServiceComplianceRating> complianceComp,
            IRepository<ComplianceSharedServiceRatingTreasury> compliancetreasury, IRepository<ComplianceSharedServiceFinancialControlRating> complianceFinCtrl,
            IRepository<ComplianceSharedServiceDataAnalyticRating> complianceDataAna, IRepository<TimeSinceLastSharedServiceAudit> timeSinceLastSharedAudit,

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
                    var getshared = shared.GetContextByConditon(x => x.BusinessRiskRatingId == id).FirstOrDefault();

                    var getstrategy = strategy.GetContextByConditon(x => x.ARMSharedServiceRatingId == getshared.Id).FirstOrDefault();

                    var getstraFinservice = straFinaCtrl.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstraCompl = strategyComp.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstraTreasury = straTreasury.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategycorpstra = strategycorpstra.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyintctrl = strategyintctrl.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyinfsec = strategyinfsec.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategycustexp = strategycustexp.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyCTO = strategycto.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategymcc = strategymcc.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategylegal = strategylegal.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyacade = strategyacade.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyriskmgt = strategyriskmgt.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyIt = strategyIt.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyadmin = strategyadmin.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyhcm = strategyhcm.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();
                    var getstrategyDataana = strategyDataana.GetContextByConditon(x => x.StrategySharedServiceId == getstrategy.Id).FirstOrDefault();

                    var getoperation = operation.GetContextByConditon(x => x.ARMSharedServiceRatingId == getshared.Id).FirstOrDefault();

                    var getoperFinCtrl = operFinCtrl.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperDataAna = operationDataAna.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getopertreasury = opertreasury.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperationcorpat = operationcorpat.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperIntCtrl = operIntCtrl.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperinfosec = operinfosec.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperationcustexp = operationcustexp.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperCTO = operCTO.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getopermcc = opermcc.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperationclegal = operationclegal.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperriskmgt = operriskmgt.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperacademy = operacademy.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperationit = operationit.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperadmin = operadmin.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperhcm = operhcm.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();
                    var getoperationCompl = operationComp.GetContextByConditon(x => x.OperationSharedServiceId == getoperation.Id).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMSharedServiceRatingId == getshared.Id).FirstOrDefault();

                    var getcomplianceCustExp = complianceCustExp.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceCTO = complianceCTO.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcompliancemcc = compliancemcc.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceIt = complianceIt.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcompliancemchcm = compliancemchcm.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceLegal = complianceLegal.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceriskmgt = complianceriskmgt.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceacademy = complianceacademy.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceadmin = complianceadmin.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcompliancecorperat = compliancecorperat.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceintctrl = complianceintctrl.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceinfosec = complianceinfosec.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceComp = complianceComp.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcompliancetreasury = compliancetreasury.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceFinCtrl = complianceFinCtrl.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();
                    var getcomplianceDataAna = complianceDataAna.GetContextByConditon(x => x.ComplianceSharedServiceId == getcompliance.Id).FirstOrDefault();

                    var gettimeSinceLastSharedAudit = timeSinceLastSharedAudit.GetContextByConditon(x => x.ARMSharedServiceRatingId == getshared.Id).FirstOrDefault();


                    ARMSharedServiceRequest resp = new ARMSharedServiceRequest
                    {
                        ARMSharedService = new ARMSharedServiceRatingReq
                        {
                            Status = getshared.Status,
                            Strategy = new StrategySharedServiceReq
                            {
                                HCM = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyhcm.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyhcm.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyhcm.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyhcm.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyhcm.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyhcm.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyhcm.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyhcm.EmergingRisks,

                                    ProductivityRisk = getstrategyhcm.ProductivityRisk,

                                    Total = getstrategyhcm.Total
                                },
                                DataAnalytic = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyDataana.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyDataana.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyDataana.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyDataana.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyDataana.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyDataana.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyDataana.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyDataana.EmergingRisks,

                                    ProductivityRisk = getstrategyDataana.ProductivityRisk,

                                    Total = getstrategyDataana.Total
                                },
                                FinancialControl = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstraFinservice.ReputationalRisk,

                                    PeopleRetentionRisk = getstraFinservice.PeopleRetentionRisk,

                                    TechnologicalRisk = getstraFinservice.TechnologicalRisk,

                                    InformationSecurityRisk = getstraFinservice.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstraFinservice.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstraFinservice.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstraFinservice.HealthandSafetyRisks,

                                    EmergingRisks = getstraFinservice.EmergingRisks,

                                    ProductivityRisk = getstraFinservice.ProductivityRisk,

                                    Total = getstraFinservice.Total
                                },
                                Compliance = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstraCompl.ReputationalRisk,

                                    PeopleRetentionRisk = getstraCompl.PeopleRetentionRisk,

                                    TechnologicalRisk = getstraCompl.TechnologicalRisk,

                                    InformationSecurityRisk = getstraCompl.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstraCompl.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstraCompl.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstraCompl.HealthandSafetyRisks,

                                    EmergingRisks = getstraCompl.EmergingRisks,

                                    ProductivityRisk = getstraCompl.ProductivityRisk,

                                    Total = getstraCompl.Total
                                },
                                IT = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyIt.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyIt.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyIt.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyIt.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyIt.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyIt.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyIt.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyIt.EmergingRisks,

                                    ProductivityRisk = getstrategyIt.ProductivityRisk,

                                    Total = getstrategyIt.Total
                                },
                                InformationSecurity = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyinfsec.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyinfsec.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyinfsec.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyinfsec.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyinfsec.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyinfsec.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyinfsec.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyinfsec.EmergingRisks,

                                    ProductivityRisk = getstrategyinfsec.ProductivityRisk,

                                    Total = getstrategyinfsec.Total
                                },
                                Academy = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyacade.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyacade.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyacade.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyacade.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyacade.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyacade.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyacade.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyacade.EmergingRisks,

                                    ProductivityRisk = getstrategyacade.ProductivityRisk,

                                    Total = getstrategyacade.Total
                                },
                                ProcurementAndAdmin = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyadmin.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyadmin.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyadmin.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyadmin.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyadmin.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyadmin.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyadmin.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyadmin.EmergingRisks,

                                    ProductivityRisk = getstrategyadmin.ProductivityRisk,

                                    Total = getstrategyadmin.Total
                                },
                                CTO = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyCTO.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyCTO.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyCTO.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyCTO.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyCTO.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyCTO.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyCTO.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyCTO.EmergingRisks,

                                    ProductivityRisk = getstrategyCTO.ProductivityRisk,

                                    Total = getstrategyCTO.Total
                                },
                                Corporatestrategy = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategycorpstra.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategycorpstra.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategycorpstra.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategycorpstra.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategycorpstra.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategycorpstra.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategycorpstra.HealthandSafetyRisks,

                                    EmergingRisks = getstrategycorpstra.EmergingRisks,

                                    ProductivityRisk = getstrategycorpstra.ProductivityRisk,

                                    Total = getstrategycorpstra.Total
                                },
                                Treasury = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstraTreasury.ReputationalRisk,

                                    PeopleRetentionRisk = getstraTreasury.PeopleRetentionRisk,

                                    TechnologicalRisk = getstraTreasury.TechnologicalRisk,

                                    InformationSecurityRisk = getstraTreasury.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstraTreasury.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstraTreasury.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstraTreasury.HealthandSafetyRisks,

                                    EmergingRisks = getstraTreasury.EmergingRisks,

                                    ProductivityRisk = getstraTreasury.ProductivityRisk,

                                    Total = getstraTreasury.Total
                                },
                                InternalControl = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyintctrl.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyintctrl.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyintctrl.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyintctrl.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyintctrl.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyintctrl.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyintctrl.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyintctrl.EmergingRisks,

                                    ProductivityRisk = getstrategyintctrl.ProductivityRisk,

                                    Total = getstrategyintctrl.Total
                                },
                                CustomerExperience = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategycustexp.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategycustexp.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategycustexp.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategycustexp.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategycustexp.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategycustexp.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategycustexp.HealthandSafetyRisks,

                                    EmergingRisks = getstrategycustexp.EmergingRisks,

                                    ProductivityRisk = getstrategycustexp.ProductivityRisk,

                                    Total = getstrategycustexp.Total
                                },
                                Legal = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategylegal.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategylegal.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategylegal.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategylegal.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategylegal.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategylegal.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategylegal.HealthandSafetyRisks,

                                    EmergingRisks = getstrategylegal.EmergingRisks,

                                    ProductivityRisk = getstrategylegal.ProductivityRisk,

                                    Total = getstrategylegal.Total
                                },
                                MCC = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategymcc.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategymcc.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategymcc.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategymcc.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategymcc.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategymcc.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategymcc.HealthandSafetyRisks,

                                    EmergingRisks = getstrategymcc.EmergingRisks,

                                    ProductivityRisk = getstrategymcc.ProductivityRisk,

                                    Total = getstrategymcc.Total
                                },
                                RiskManagement = new StrategySharedServiceRatingReq
                                {
                                    ReputationalRisk = getstrategyriskmgt.ReputationalRisk,

                                    PeopleRetentionRisk = getstrategyriskmgt.PeopleRetentionRisk,

                                    TechnologicalRisk = getstrategyriskmgt.TechnologicalRisk,

                                    InformationSecurityRisk = getstrategyriskmgt.InformationSecurityRisk,

                                    FluidityofTechnologicalSolutions = getstrategyriskmgt.FluidityofTechnologicalSolutions,

                                    ProjectManagementRisk = getstrategyriskmgt.ProjectManagementRisk,

                                    HealthandSafetyRisks = getstrategyriskmgt.HealthandSafetyRisks,

                                    EmergingRisks = getstrategyriskmgt.EmergingRisks,

                                    ProductivityRisk = getstrategyriskmgt.ProductivityRisk,

                                    Total = getstrategyriskmgt.Total
                                },
                                Comment = getstrategy.Comment
                            },
                            Operations = new OperationSharedServiceReq
                            {
                                DataAnalytic = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperDataAna.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperDataAna.TheftorFraudRisk,
                                    PoorCustomerService = getoperDataAna.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperDataAna.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperDataAna.ThirdpartyRisk,
                                    TAT = getoperDataAna.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperDataAna.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperDataAna.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperDataAna.RecruitmentRisk,
                                    UnauthorizedAccess = getoperDataAna.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperDataAna.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperDataAna.ErroneousDataEntry,
                                    Miscommunication = getoperDataAna.Miscommunication,
                                    ErrorDetectionRisk = getoperDataAna.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperDataAna.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperDataAna.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperDataAna.BudgetOverruns,
                                    ObsoleteTechnology = getoperDataAna.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperDataAna.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperDataAna.BCPandDRP,
                                    AssentMaintenance = getoperDataAna.AssentMaintenance,
                                    ChangeNoticeManagement = getoperDataAna.ChangeNoticeManagement,
                                    QualityManagament = getoperDataAna.QualityManagament,
                                    VendorManagement = getoperDataAna.VendorManagement,
                                    Total = getoperDataAna.Total
                                },
                                Compliance = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationCompl.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationCompl.TheftorFraudRisk,
                                    PoorCustomerService = getoperationCompl.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationCompl.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationCompl.ThirdpartyRisk,
                                    TAT = getoperationCompl.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationCompl.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationCompl.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationCompl.RecruitmentRisk,
                                    UnauthorizedAccess = getoperationCompl.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationCompl.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationCompl.ErroneousDataEntry,
                                    Miscommunication = getoperationCompl.Miscommunication,
                                    ErrorDetectionRisk = getoperationCompl.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationCompl.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationCompl.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperationCompl.BudgetOverruns,
                                    ObsoleteTechnology = getoperationCompl.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperationCompl.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperationCompl.BCPandDRP,
                                    AssentMaintenance = getoperationCompl.AssentMaintenance,
                                    ChangeNoticeManagement = getoperationCompl.ChangeNoticeManagement,
                                    QualityManagament = getoperationCompl.QualityManagament,
                                    VendorManagement = getoperationCompl.VendorManagement,
                                    Total = getoperationCompl.Total
                                },
                                Financialcontrol = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperFinCtrl.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperFinCtrl.TheftorFraudRisk,
                                    PoorCustomerService = getoperFinCtrl.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperFinCtrl.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperFinCtrl.ThirdpartyRisk,
                                    TAT = getoperFinCtrl.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperFinCtrl.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getoperFinCtrl.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getoperFinCtrl.RecruitmentRisk,

                                    UnauthorizedAccess = getoperFinCtrl.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getoperFinCtrl.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getoperFinCtrl.ErroneousDataEntry,

                                    Miscommunication = getoperFinCtrl.Miscommunication,

                                    ErrorDetectionRisk = getoperFinCtrl.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getoperFinCtrl.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperFinCtrl.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperFinCtrl.BudgetOverruns,
                                    ObsoleteTechnology = getoperFinCtrl.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperFinCtrl.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperFinCtrl.BCPandDRP,
                                    AssentMaintenance = getoperFinCtrl.AssentMaintenance,
                                    ChangeNoticeManagement = getoperFinCtrl.ChangeNoticeManagement,
                                    QualityManagament = getoperFinCtrl.QualityManagament,
                                    VendorManagement = getoperFinCtrl.VendorManagement,
                                    Total = getoperFinCtrl.Total
                                },
                                Treasury = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getopertreasury.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getopertreasury.TheftorFraudRisk,
                                    PoorCustomerService = getopertreasury.PoorCustomerService,

                                    ITInfrastruCTOreDowntime = getopertreasury.ITInfrastruCTOreDowntime,

                                    ThirdpartyRisk = getopertreasury.ThirdpartyRisk,

                                    TAT = getopertreasury.TAT,

                                    TheftLeakageorMisuseofIntelleCTOalProperty = getopertreasury.TheftLeakageorMisuseofIntelleCTOalProperty,

                                    OverorUnderpaymentofClient = getopertreasury.OverorUnderpaymentofClient,

                                    RecruitmentRisk = getopertreasury.RecruitmentRisk,

                                    UnauthorizedAccess = getopertreasury.UnauthorizedAccess,

                                    MalwareorVirusorWebsiteAttacks = getopertreasury.MalwareorVirusorWebsiteAttacks,

                                    ErroneousDataEntry = getopertreasury.ErroneousDataEntry,

                                    Miscommunication = getopertreasury.Miscommunication,

                                    ErrorDetectionRisk = getopertreasury.ErrorDetectionRisk,

                                    StrategyMonitoringRisk = getopertreasury.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getopertreasury.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getopertreasury.BudgetOverruns,
                                    ObsoleteTechnology = getopertreasury.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getopertreasury.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getopertreasury.BCPandDRP,
                                    AssentMaintenance = getopertreasury.AssentMaintenance,
                                    ChangeNoticeManagement = getopertreasury.ChangeNoticeManagement,
                                    QualityManagament = getopertreasury.QualityManagament,
                                    VendorManagement = getopertreasury.VendorManagement,
                                    Total = getopertreasury.Total
                                },
                                Academy = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperacademy.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperacademy.TheftorFraudRisk,
                                    PoorCustomerService = getoperacademy.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperacademy.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperacademy.ThirdpartyRisk,
                                    TAT = getoperacademy.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperacademy.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperacademy.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperacademy.RecruitmentRisk,
                                    UnauthorizedAccess = getoperacademy.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperacademy.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperacademy.ErroneousDataEntry,
                                    Miscommunication = getoperacademy.Miscommunication,
                                    ErrorDetectionRisk = getoperacademy.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperacademy.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperacademy.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperacademy.BudgetOverruns,
                                    ObsoleteTechnology = getoperacademy.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperacademy.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperacademy.BCPandDRP,
                                    AssentMaintenance = getoperacademy.AssentMaintenance,
                                    ChangeNoticeManagement = getoperacademy.ChangeNoticeManagement,
                                    QualityManagament = getoperacademy.QualityManagament,
                                    VendorManagement = getoperacademy.VendorManagement,
                                    Total = getoperacademy.Total
                                },
                                InformationSecurity = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperinfosec.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperinfosec.TheftorFraudRisk,
                                    PoorCustomerService = getoperinfosec.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperinfosec.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperinfosec.ThirdpartyRisk,
                                    TAT = getoperinfosec.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperinfosec.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperinfosec.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperinfosec.RecruitmentRisk,
                                    UnauthorizedAccess = getoperinfosec.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperinfosec.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperinfosec.ErroneousDataEntry,
                                    Miscommunication = getoperinfosec.Miscommunication,
                                    ErrorDetectionRisk = getoperinfosec.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperinfosec.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperinfosec.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperinfosec.BudgetOverruns,
                                    ObsoleteTechnology = getoperinfosec.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperinfosec.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperinfosec.BCPandDRP,
                                    AssentMaintenance = getoperinfosec.AssentMaintenance,
                                    ChangeNoticeManagement = getoperinfosec.ChangeNoticeManagement,
                                    QualityManagament = getoperinfosec.QualityManagament,
                                    VendorManagement = getoperinfosec.VendorManagement,
                                    Total = getoperinfosec.Total
                                },
                                IT = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationit.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationit.TheftorFraudRisk,
                                    PoorCustomerService = getoperationit.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationit.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationit.ThirdpartyRisk,
                                    TAT = getoperationit.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationit.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationit.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationit.RecruitmentRisk,
                                    UnauthorizedAccess = getoperationit.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationit.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationit.ErroneousDataEntry,
                                    Miscommunication = getoperationit.Miscommunication,
                                    ErrorDetectionRisk = getoperationit.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationit.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationit.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperationit.BudgetOverruns,
                                    ObsoleteTechnology = getoperationit.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperationit.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperationit.BCPandDRP,
                                    AssentMaintenance = getoperationit.AssentMaintenance,
                                    ChangeNoticeManagement = getoperationit.ChangeNoticeManagement,
                                    QualityManagament = getoperationit.QualityManagament,
                                    VendorManagement = getoperationit.VendorManagement,
                                    Total = getoperationit.Total
                                },
                                InternalControl = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperIntCtrl.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperIntCtrl.TheftorFraudRisk,
                                    PoorCustomerService = getoperIntCtrl.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperIntCtrl.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperIntCtrl.ThirdpartyRisk,
                                    TAT = getoperIntCtrl.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperIntCtrl.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperIntCtrl.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperIntCtrl.RecruitmentRisk,
                                    UnauthorizedAccess = getoperIntCtrl.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperIntCtrl.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperIntCtrl.ErroneousDataEntry,
                                    Miscommunication = getoperIntCtrl.Miscommunication,
                                    ErrorDetectionRisk = getoperIntCtrl.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperIntCtrl.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperIntCtrl.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperIntCtrl.BudgetOverruns,
                                    ObsoleteTechnology = getoperIntCtrl.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperIntCtrl.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperIntCtrl.BCPandDRP,
                                    AssentMaintenance = getoperIntCtrl.AssentMaintenance,
                                    ChangeNoticeManagement = getoperIntCtrl.ChangeNoticeManagement,
                                    QualityManagament = getoperIntCtrl.QualityManagament,
                                    VendorManagement = getoperIntCtrl.VendorManagement,
                                    Total = getoperIntCtrl.Total
                                },
                                Corporatestrategy = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationcorpat.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationcorpat.TheftorFraudRisk,
                                    PoorCustomerService = getoperationcorpat.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationcorpat.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationcorpat.ThirdpartyRisk,
                                    TAT = getoperationcorpat.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationcorpat.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationcorpat.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationcorpat.RecruitmentRisk,
                                    UnauthorizedAccess = getoperationcorpat.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationcorpat.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationcorpat.ErroneousDataEntry,
                                    Miscommunication = getoperationcorpat.Miscommunication,
                                    ErrorDetectionRisk = getoperationcorpat.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationcorpat.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationcorpat.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperationcorpat.BudgetOverruns,
                                    ObsoleteTechnology = getoperationcorpat.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperationcorpat.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperationcorpat.BCPandDRP,
                                    AssentMaintenance = getoperationcorpat.AssentMaintenance,
                                    ChangeNoticeManagement = getoperationcorpat.ChangeNoticeManagement,
                                    QualityManagament = getoperationcorpat.QualityManagament,
                                    VendorManagement = getoperationcorpat.VendorManagement,
                                    Total = getoperationcorpat.Total
                                },
                                CustomerExperience = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationcustexp.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationcustexp.TheftorFraudRisk,
                                    PoorCustomerService = getoperationcustexp.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationcustexp.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationcustexp.ThirdpartyRisk,
                                    TAT = getoperationcustexp.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationcustexp.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationcustexp.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationcustexp.RecruitmentRisk,
                                    UnauthorizedAccess = getoperationcustexp.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationcustexp.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationcustexp.ErroneousDataEntry,
                                    Miscommunication = getoperationcustexp.Miscommunication,
                                    ErrorDetectionRisk = getoperationcustexp.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationcustexp.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationcustexp.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperationcustexp.BudgetOverruns,
                                    ObsoleteTechnology = getoperationcustexp.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperationcustexp.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperationcustexp.BCPandDRP,
                                    AssentMaintenance = getoperationcustexp.AssentMaintenance,
                                    ChangeNoticeManagement = getoperationcustexp.ChangeNoticeManagement,
                                    QualityManagament = getoperationcustexp.QualityManagament,
                                    VendorManagement = getoperationcustexp.VendorManagement,
                                    Total = getoperationcustexp.Total
                                },
                                Legal = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperationclegal.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperationclegal.TheftorFraudRisk,
                                    PoorCustomerService = getoperationclegal.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperationclegal.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperationclegal.ThirdpartyRisk,
                                    TAT = getoperationclegal.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperationclegal.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperationclegal.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperationclegal.RecruitmentRisk,
                                    UnauthorizedAccess = getoperationclegal.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperationclegal.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperationclegal.ErroneousDataEntry,
                                    Miscommunication = getoperationclegal.Miscommunication,
                                    ErrorDetectionRisk = getoperationclegal.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperationclegal.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperationclegal.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperationclegal.BudgetOverruns,
                                    ObsoleteTechnology = getoperationclegal.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperationclegal.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperationclegal.BCPandDRP,
                                    AssentMaintenance = getoperationclegal.AssentMaintenance,
                                    ChangeNoticeManagement = getoperationclegal.ChangeNoticeManagement,
                                    QualityManagament = getoperationclegal.QualityManagament,
                                    VendorManagement = getoperationclegal.VendorManagement,
                                    Total = getoperationclegal.Total
                                },
                                MCC = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getopermcc.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getopermcc.TheftorFraudRisk,
                                    PoorCustomerService = getopermcc.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getopermcc.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getopermcc.ThirdpartyRisk,
                                    TAT = getopermcc.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getopermcc.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getopermcc.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getopermcc.RecruitmentRisk,
                                    UnauthorizedAccess = getopermcc.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getopermcc.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getopermcc.ErroneousDataEntry,
                                    Miscommunication = getopermcc.Miscommunication,
                                    ErrorDetectionRisk = getopermcc.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getopermcc.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getopermcc.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getopermcc.BudgetOverruns,
                                    ObsoleteTechnology = getopermcc.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getopermcc.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getopermcc.BCPandDRP,
                                    AssentMaintenance = getopermcc.AssentMaintenance,
                                    ChangeNoticeManagement = getopermcc.ChangeNoticeManagement,
                                    QualityManagament = getopermcc.QualityManagament,
                                    VendorManagement = getopermcc.VendorManagement,
                                    Total = getopermcc.Total
                                },
                                RiskManagement = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperriskmgt.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperriskmgt.TheftorFraudRisk,
                                    PoorCustomerService = getoperriskmgt.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperriskmgt.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperriskmgt.ThirdpartyRisk,
                                    TAT = getoperriskmgt.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperriskmgt.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperriskmgt.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperriskmgt.RecruitmentRisk,
                                    UnauthorizedAccess = getoperriskmgt.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperriskmgt.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperriskmgt.ErroneousDataEntry,
                                    Miscommunication = getoperriskmgt.Miscommunication,
                                    ErrorDetectionRisk = getoperriskmgt.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperriskmgt.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperriskmgt.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperriskmgt.BudgetOverruns,
                                    ObsoleteTechnology = getoperriskmgt.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperriskmgt.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperriskmgt.BCPandDRP,
                                    AssentMaintenance = getoperriskmgt.AssentMaintenance,
                                    ChangeNoticeManagement = getoperriskmgt.ChangeNoticeManagement,
                                    QualityManagament = getoperriskmgt.QualityManagament,
                                    VendorManagement = getoperriskmgt.VendorManagement,
                                    Total = getoperriskmgt.Total
                                },
                                HCM = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperhcm.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperhcm.TheftorFraudRisk,
                                    PoorCustomerService = getoperhcm.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperhcm.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperhcm.ThirdpartyRisk,
                                    TAT = getoperhcm.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperhcm.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperhcm.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperhcm.RecruitmentRisk,
                                    UnauthorizedAccess = getoperhcm.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperhcm.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperhcm.ErroneousDataEntry,
                                    Miscommunication = getoperhcm.Miscommunication,
                                    ErrorDetectionRisk = getoperhcm.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperhcm.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperhcm.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperhcm.BudgetOverruns,
                                    ObsoleteTechnology = getoperhcm.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperhcm.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperhcm.BCPandDRP,
                                    AssentMaintenance = getoperhcm.AssentMaintenance,
                                    ChangeNoticeManagement = getoperhcm.ChangeNoticeManagement,
                                    QualityManagament = getoperhcm.QualityManagament,
                                    VendorManagement = getoperhcm.VendorManagement,
                                    Total = getoperhcm.Total
                                },
                                ProcurementAndAdmin = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperadmin.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperadmin.TheftorFraudRisk,
                                    PoorCustomerService = getoperadmin.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperadmin.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperadmin.ThirdpartyRisk,
                                    TAT = getoperadmin.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperadmin.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperadmin.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperadmin.RecruitmentRisk,
                                    UnauthorizedAccess = getoperadmin.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperadmin.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperadmin.ErroneousDataEntry,
                                    Miscommunication = getoperadmin.Miscommunication,
                                    ErrorDetectionRisk = getoperadmin.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperadmin.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperadmin.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperadmin.BudgetOverruns,
                                    ObsoleteTechnology = getoperadmin.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperadmin.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperadmin.BCPandDRP,
                                    AssentMaintenance = getoperadmin.AssentMaintenance,
                                    ChangeNoticeManagement = getoperadmin.ChangeNoticeManagement,
                                    QualityManagament = getoperadmin.QualityManagament,
                                    VendorManagement = getoperadmin.VendorManagement,
                                    Total = getoperadmin.Total
                                },
                                CTO = new OperationSharedServiceRatingReq
                                {
                                    AdoptionandImplementationofPolicies = getoperCTO.AdoptionandImplementationofPolicies,
                                    TheftorFraudRisk = getoperCTO.TheftorFraudRisk,
                                    PoorCustomerService = getoperCTO.PoorCustomerService,
                                    ITInfrastruCTOreDowntime = getoperCTO.ITInfrastruCTOreDowntime,
                                    ThirdpartyRisk = getoperCTO.ThirdpartyRisk,
                                    TAT = getoperCTO.TAT,
                                    TheftLeakageorMisuseofIntelleCTOalProperty = getoperCTO.TheftLeakageorMisuseofIntelleCTOalProperty,
                                    OverorUnderpaymentofClient = getoperCTO.OverorUnderpaymentofClient,
                                    RecruitmentRisk = getoperCTO.RecruitmentRisk,
                                    UnauthorizedAccess = getoperCTO.UnauthorizedAccess,
                                    MalwareorVirusorWebsiteAttacks = getoperCTO.MalwareorVirusorWebsiteAttacks,
                                    ErroneousDataEntry = getoperCTO.ErroneousDataEntry,
                                    Miscommunication = getoperCTO.Miscommunication,
                                    ErrorDetectionRisk = getoperCTO.ErrorDetectionRisk,
                                    StrategyMonitoringRisk = getoperCTO.StrategyMonitoringRisk,
                                    RelevanceandRecencyofModelToolsandTechniques = getoperCTO.RelevanceandRecencyofModelToolsandTechniques,
                                    BudgetOverruns = getoperCTO.BudgetOverruns,
                                    ObsoleteTechnology = getoperCTO.ObsoleteTechnology,
                                    DisclosureCorruptionOfSensitiveData = getoperCTO.DisclosureCorruptionOfSensitiveData,
                                    BCPandDRP = getoperCTO.BCPandDRP,
                                    AssentMaintenance = getoperCTO.AssentMaintenance,
                                    ChangeNoticeManagement = getoperCTO.ChangeNoticeManagement,
                                    QualityManagament = getoperCTO.QualityManagament,
                                    VendorManagement = getoperCTO.VendorManagement,
                                    Total = getoperCTO.Total
                                },
                                Comment = getoperation.Comment
                            },
                            Compliance = new ComplianceSharedServiceReq
                            {
                                HCM = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcompliancemchcm.AMLCFT,
                                    LitigationRisk = getcompliancemchcm.LitigationRisk,
                                    ChangingRegulations = getcompliancemchcm.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcompliancemchcm.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcompliancemchcm.NonComplianceWithContracts,
                                    KYCChecks = getcompliancemchcm.KYCChecks,
                                    GDPROrNDPR = getcompliancemchcm.GDPROrNDPR,
                                    DisclosureRisk = getcompliancemchcm.DisclosureRisk,
                                    Total = getcompliancemchcm.Total
                                },
                                DataAnalytic = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceDataAna.AMLCFT,
                                    LitigationRisk = getcomplianceDataAna.LitigationRisk,
                                    ChangingRegulations = getcomplianceDataAna.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceDataAna.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceDataAna.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceDataAna.KYCChecks,
                                    GDPROrNDPR = getcomplianceDataAna.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceDataAna.DisclosureRisk,
                                    Total = getcomplianceDataAna.Total
                                },
                                InformationSecurity = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceinfosec.AMLCFT,
                                    LitigationRisk = getcomplianceinfosec.LitigationRisk,
                                    ChangingRegulations = getcomplianceinfosec.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceinfosec.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceinfosec.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceinfosec.KYCChecks,
                                    GDPROrNDPR = getcomplianceinfosec.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceinfosec.DisclosureRisk,
                                    Total = getcomplianceinfosec.Total
                                },
                                IT = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceIt.AMLCFT,
                                    LitigationRisk = getcomplianceIt.LitigationRisk,
                                    ChangingRegulations = getcomplianceIt.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceIt.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceIt.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceIt.KYCChecks,
                                    GDPROrNDPR = getcomplianceIt.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceIt.DisclosureRisk,
                                    Total = getcomplianceIt.Total
                                },
                                InternalControl = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceintctrl.AMLCFT,
                                    LitigationRisk = getcomplianceintctrl.LitigationRisk,
                                    ChangingRegulations = getcomplianceintctrl.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceintctrl.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceintctrl.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceintctrl.KYCChecks,
                                    GDPROrNDPR = getcomplianceintctrl.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceintctrl.DisclosureRisk,
                                    Total = getcomplianceintctrl.Total
                                },
                                Legal = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceLegal.AMLCFT,
                                    LitigationRisk = getcomplianceLegal.LitigationRisk,
                                    ChangingRegulations = getcomplianceLegal.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceLegal.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceLegal.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceLegal.KYCChecks,
                                    GDPROrNDPR = getcomplianceLegal.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceLegal.DisclosureRisk,
                                    Total = getcomplianceLegal.Total
                                },
                                MCC = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcompliancemcc.AMLCFT,
                                    LitigationRisk = getcompliancemcc.LitigationRisk,
                                    ChangingRegulations = getcompliancemcc.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcompliancemcc.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcompliancemcc.NonComplianceWithContracts,
                                    KYCChecks = getcompliancemcc.KYCChecks,
                                    GDPROrNDPR = getcompliancemcc.GDPROrNDPR,
                                    DisclosureRisk = getcompliancemcc.DisclosureRisk,
                                    Total = getcompliancemcc.Total
                                },
                                ProcurementAndAdmin = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceadmin.AMLCFT,
                                    LitigationRisk = getcomplianceadmin.LitigationRisk,
                                    ChangingRegulations = getcomplianceadmin.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceadmin.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceadmin.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceadmin.KYCChecks,
                                    GDPROrNDPR = getcomplianceadmin.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceadmin.DisclosureRisk,
                                    Total = getcomplianceadmin.Total
                                },
                                RiskManagement = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceriskmgt.AMLCFT,
                                    LitigationRisk = getcomplianceriskmgt.LitigationRisk,
                                    ChangingRegulations = getcomplianceriskmgt.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceriskmgt.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceriskmgt.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceriskmgt.KYCChecks,
                                    GDPROrNDPR = getcomplianceriskmgt.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceriskmgt.DisclosureRisk,
                                    Total = getcomplianceriskmgt.Total
                                },
                                Treasury = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcompliancetreasury.AMLCFT,
                                    LitigationRisk = getcompliancetreasury.LitigationRisk,
                                    ChangingRegulations = getcompliancetreasury.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcompliancetreasury.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcompliancetreasury.NonComplianceWithContracts,
                                    KYCChecks = getcompliancetreasury.KYCChecks,
                                    GDPROrNDPR = getcompliancetreasury.GDPROrNDPR,
                                    DisclosureRisk = getcompliancetreasury.DisclosureRisk,
                                    Total = getcompliancetreasury.Total
                                },
                                Compliance = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceComp.AMLCFT,
                                    LitigationRisk = getcomplianceComp.LitigationRisk,
                                    ChangingRegulations = getcomplianceComp.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceComp.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceComp.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceComp.KYCChecks,
                                    GDPROrNDPR = getcomplianceComp.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceComp.DisclosureRisk,
                                    Total = getcomplianceComp.Total
                                },
                                FinancialControl = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceFinCtrl.AMLCFT,
                                    LitigationRisk = getcomplianceFinCtrl.LitigationRisk,
                                    ChangingRegulations = getcomplianceFinCtrl.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceFinCtrl.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceFinCtrl.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceFinCtrl.KYCChecks,
                                    GDPROrNDPR = getcomplianceFinCtrl.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceFinCtrl.DisclosureRisk,
                                    Total = getcomplianceFinCtrl.Total
                                },
                                Academy = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceacademy.AMLCFT,
                                    LitigationRisk = getcomplianceacademy.LitigationRisk,
                                    ChangingRegulations = getcomplianceacademy.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceacademy.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceacademy.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceacademy.KYCChecks,
                                    GDPROrNDPR = getcomplianceacademy.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceacademy.DisclosureRisk,
                                    Total = getcomplianceacademy.Total
                                },
                                Corporatestrategy = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcompliancecorperat.AMLCFT,
                                    LitigationRisk = getcompliancecorperat.LitigationRisk,
                                    ChangingRegulations = getcompliancecorperat.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcompliancecorperat.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcompliancecorperat.NonComplianceWithContracts,
                                    KYCChecks = getcompliancecorperat.KYCChecks,
                                    GDPROrNDPR = getcompliancecorperat.GDPROrNDPR,
                                    DisclosureRisk = getcompliancecorperat.DisclosureRisk,
                                    Total = getcompliancecorperat.Total
                                },
                                CTO = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceCTO.AMLCFT,
                                    LitigationRisk = getcomplianceCTO.LitigationRisk,
                                    ChangingRegulations = getcomplianceCTO.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceCTO.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceCTO.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceCTO.KYCChecks,
                                    GDPROrNDPR = getcomplianceCTO.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceCTO.DisclosureRisk,
                                    Total = getcomplianceCTO.Total
                                },
                                Customerexperience = new ComplianceSharedServiceRatingReq
                                {
                                    AMLCFT = getcomplianceCustExp.AMLCFT,
                                    LitigationRisk = getcomplianceCustExp.LitigationRisk,
                                    ChangingRegulations = getcomplianceCustExp.ChangingRegulations,
                                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = getcomplianceCustExp.InaccurateComputationofRegulatoryRemittancesDelayedFilings,
                                    NonComplianceWithContracts = getcomplianceCustExp.NonComplianceWithContracts,
                                    KYCChecks = getcomplianceCustExp.KYCChecks,
                                    GDPROrNDPR = getcomplianceCustExp.GDPROrNDPR,
                                    DisclosureRisk = getcomplianceCustExp.DisclosureRisk,
                                    Total = getcomplianceCustExp.Total
                                },
                                Comment = getcompliance.Comment
                            },
                            LastReportOverallRating = new TimeSinceLastSharedServiceAuditReq
                            {
                                Compliance = gettimeSinceLastSharedAudit.Compliance,
                                FinancialControl = gettimeSinceLastSharedAudit.FinancialControl,
                                Academy = gettimeSinceLastSharedAudit.Academy,
                                ProcurementAndAdmind = gettimeSinceLastSharedAudit.ProcurementAndAdmind,
                                DataAnalytic = gettimeSinceLastSharedAudit.DataAnalytic,
                                InformationSecurity = gettimeSinceLastSharedAudit.InformationSecurity,
                                InternalControl = gettimeSinceLastSharedAudit.InternalControl,
                                IT = gettimeSinceLastSharedAudit.IT,
                                Corporatestrategy = gettimeSinceLastSharedAudit.Corporatestrategy,
                                CTO = gettimeSinceLastSharedAudit.CTO,
                                Customerexperience = gettimeSinceLastSharedAudit.Customerexperience,
                                HCM = gettimeSinceLastSharedAudit.HCM,
                                Legal = gettimeSinceLastSharedAudit.Legal,
                                MCC = gettimeSinceLastSharedAudit.MCC,
                                RiskManagement = gettimeSinceLastSharedAudit.RiskManagement,
                                Treasury = gettimeSinceLastSharedAudit.Treasury,
                                Comment = gettimeSinceLastSharedAudit.Comment
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
