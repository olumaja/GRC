using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using Azure;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    public class BusinessRiskRatingARMSharedServiceEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARMSharedService business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="shared"></param>
        /// <param name="strategy"></param>
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
        /// <param name="strategyFinCtrl"></param>
        /// <param name="strategyDataAnaly"></param>
        /// <param name="strategyCompliance"></param>
        /// <param name="operation"></param>
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
        /// <param name="opDataAna"></param>
        /// <param name="opFinCtrl"></param>
        /// <param name="opCompliance"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceCustExp"></param>
        /// <param name="complianceCTO"></param>
        /// <param name="compliancemccL"></param>
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
        /// <param name="complianceComp"></param>
        /// <param name="complianceFinCtrl"></param>
        /// <param name="compliancetreasury"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="timeSinceLastSharedAudit"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMSharedServiceRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMSharedServiceRating> shared, IRepository<StrategySharedService> strategy,
            IRepository<StrategySharedServiceRatingTreasury> straTreasury, IRepository<StrategySharedServiceRatingCorporatestrategy> strategycorpstra,
            IRepository<StrategySharedServiceRatingInternalControl> strategyintctrl, IRepository<StrategySharedServiceRatingInformationSecurity> strategyinfsec,
            IRepository<StrategySharedServiceRatingCustomerexperience> strategycustexp, IRepository<StrategySharedServiceRatingCTO> strategyCTO,
            IRepository<StrategySharedServiceRatingMCC> strategymcc, IRepository<StrategySharedServiceRatingLegal> strategylegal,
            IRepository<StrategySharedServiceRatingAcademy> strategyacade, IRepository<StrategySharedServiceRatingRiskManagement> strategyriskmgt,
            IRepository<StrategySharedServiceRatingIT> strategyIt, IRepository<StrategySharedServiceRatingProcurementAndAdmin> strategyadmin,
            IRepository<StrategySharedServiceRatingHCM> strategyhcm, IRepository<StrategySharedServiceFinancialControl> strategyFinCtrl,
            IRepository<StrategySharedServiceDataAnalytic> strategyDataAnaly, IRepository<StrategySharedServiceCompliance> strategyCompliance,

            IRepository<OperationSharedService> operation, IRepository<OperationSharedServiceRatingTreasury> opertreasury,
            IRepository<OperationSharedServiceRatingCorporatestrategy> operationcorpat, IRepository<OperationSharedServiceRatingInternalControl> operIntCtrl, IRepository<OperationSharedServiceRatingInformationSecurity> operinfosec,
            IRepository<OperationSharedServiceRatingCustomerexperience> operationcustexp, IRepository<OperationSharedServiceRatingCTO> operCTO, IRepository<OperationSharedServiceRatingMCC> opermcc,
            IRepository<OperationSharedServiceRatingLegal> operationclegal, IRepository<OperationSharedServiceRatingRiskManagement> operriskmgt, IRepository<OperationSharedServiceRatingAcademy> operacademy,
            IRepository<OperationSharedServiceRatingIT> operationit, IRepository<OperationSharedServiceRatingProcurementAndAdmin> operadmin, IRepository<OperationSharedServiceRatingHCM> operhcm,
            IRepository<OperationSharedServiceDataAnalyticRating> opDataAna, IRepository<OperationSharedServiceFinancialControlRating> opFinCtrl,
            IRepository<OperationSharedServiceComplianceRating> opCompliance,

            IRepository<ComplianceSharedService> compliance, IRepository<ComplianceSharedServiceRatingCustomerexperience> complianceCustExp,
            IRepository<ComplianceSharedServiceRatingCTO> complianceCTO, IRepository<ComplianceSharedServiceRatingMCC> compliancemccL,
            IRepository<ComplianceSharedServiceRatingIT> complianceIt, IRepository<ComplianceSharedServiceRatingHCM> compliancemchcm,
            IRepository<ComplianceSharedServiceRatingLegal> complianceLegal, IRepository<ComplianceSharedServiceRatingRiskManagement> complianceriskmgt,
            IRepository<ComplianceSharedServiceRatingAcademy> complianceacademy, IRepository<ComplianceSharedServiceRatingProcurementAndAdmin> complianceadmin,
            IRepository<ComplianceSharedServiceRatingCorporatestrategy> compliancecorperat, IRepository<ComplianceSharedServiceRatingInternalControl> complianceintctrl,
            IRepository<ComplianceSharedServiceRatingInformationSecurity> complianceinfosec, IRepository<ComplianceSharedServiceDataAnalyticRating> complianceDataAna,
            IRepository<ComplianceSharedServiceComplianceRating> complianceComp, IRepository<ComplianceSharedServiceFinancialControlRating> complianceFinCtrl,
            IRepository<ComplianceSharedServiceRatingTreasury> compliancetreasury, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating,
            IRepository<TimeSinceLastSharedServiceAudit> timeSinceLastSharedAudit, ICurrentUserService currentUserService,
            IConfiguration config, IEmailService EmailService, ClaimsPrincipal user)
        {
            try
            {               

                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;

                var getByEmail = shared.GetContextByConditon(x => x.RequesterEmail == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARMSharedService for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    var sharedLog = ARMSharedServiceRating.Create(getUser.Id, request.ARMSharedService.Status, requesterName);
                    await shared.AddAsync(sharedLog);

                    var strategyLog = StrategySharedService.Create(sharedLog.Id, request.ARMSharedService.Strategy.Comment);
                    await strategy.AddAsync(strategyLog);

                    var straTreasuryLog = StrategySharedServiceRatingTreasury.Create(strategyLog.Id, request.ARMSharedService);
                    await straTreasury.AddAsync(straTreasuryLog);

                    var strategycorpstraLog = StrategySharedServiceRatingCorporatestrategy.Create(strategyLog.Id, request.ARMSharedService);
                    await strategycorpstra.AddAsync(strategycorpstraLog);

                    var strategyintctrlLog = StrategySharedServiceRatingInternalControl.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyintctrl.AddAsync(strategyintctrlLog);

                    var strategyinfsecLog = StrategySharedServiceRatingInformationSecurity.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyinfsec.AddAsync(strategyinfsecLog);

                    var strategycustexpLog = StrategySharedServiceRatingCustomerexperience.Create(strategyLog.Id, request.ARMSharedService);
                    await strategycustexp.AddAsync(strategycustexpLog);

                    var strategyCTOLog = StrategySharedServiceRatingCTO.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyCTO.AddAsync(strategyCTOLog);

                    var strategymccLog = StrategySharedServiceRatingMCC.Create(strategyLog.Id, request.ARMSharedService);
                    await strategymcc.AddAsync(strategymccLog);

                    var strategylegalLog = StrategySharedServiceRatingLegal.Create(strategyLog.Id, request.ARMSharedService);
                    await strategylegal.AddAsync(strategylegalLog);

                    var strategyacadeLog = StrategySharedServiceRatingAcademy.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyacade.AddAsync(strategyacadeLog);

                    var strategyriskmgtLog = StrategySharedServiceRatingRiskManagement.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyriskmgt.AddAsync(strategyriskmgtLog);

                    var strategyItLog = StrategySharedServiceRatingIT.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyIt.AddAsync(strategyItLog);

                    var strategyadminLog = StrategySharedServiceRatingProcurementAndAdmin.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyadmin.AddAsync(strategyadminLog);

                    var strategyhcmLog = StrategySharedServiceRatingHCM.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyhcm.AddAsync(strategyhcmLog);

                    var strategyCompLog = StrategySharedServiceCompliance.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyCompliance.AddAsync(strategyCompLog);

                    var strategysharedFinctrlLog = StrategySharedServiceFinancialControl.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyFinCtrl.AddAsync(strategysharedFinctrlLog);


                    var strategyDataLog = StrategySharedServiceDataAnalytic.Create(strategyLog.Id, request.ARMSharedService);
                    await strategyDataAnaly.AddAsync(strategyDataLog);

                    var operationLog = OperationSharedService.Create(sharedLog.Id, request.ARMSharedService.Operations.Comment);
                    await operation.AddAsync(operationLog);

                    //var operFinservLog = StrategySharedServiceDataAnalytic.Create(operationLog.Id, request.ARMSharedService);
                    //await strategyDataAnaly.AddAsync(operFinservLog);

                    var opertreasuryLog = OperationSharedServiceRatingTreasury.Create(operationLog.Id, request.ARMSharedService);
                    await opertreasury.AddAsync(opertreasuryLog);

                    var operationcorpatLog = OperationSharedServiceRatingCorporatestrategy.Create(operationLog.Id, request.ARMSharedService);
                    await operationcorpat.AddAsync(operationcorpatLog);

                    var operIntCtrlLog = OperationSharedServiceRatingInternalControl.Create(operationLog.Id, request.ARMSharedService);
                    await operIntCtrl.AddAsync(operIntCtrlLog);

                    var operinfosecLog = OperationSharedServiceRatingInformationSecurity.Create(operationLog.Id, request.ARMSharedService);
                    await operinfosec.AddAsync(operinfosecLog);

                    var operationcustexpLog = OperationSharedServiceRatingCustomerexperience.Create(operationLog.Id, request.ARMSharedService);
                    await operationcustexp.AddAsync(operationcustexpLog);

                    var operCTOLog = OperationSharedServiceRatingCTO.Create(operationLog.Id, request.ARMSharedService);
                    await operCTO.AddAsync(operCTOLog);

                    var opermccLog = OperationSharedServiceRatingMCC.Create(operationLog.Id, request.ARMSharedService);
                    await opermcc.AddAsync(opermccLog);

                    var operationclegalLog = OperationSharedServiceRatingLegal.Create(operationLog.Id, request.ARMSharedService);
                    await operationclegal.AddAsync(operationclegalLog);

                    var operriskmgtLog = OperationSharedServiceRatingRiskManagement.Create(operationLog.Id, request.ARMSharedService);
                    await operriskmgt.AddAsync(operriskmgtLog);

                    var operacademyLog = OperationSharedServiceRatingAcademy.Create(operationLog.Id, request.ARMSharedService);
                    await operacademy.AddAsync(operacademyLog);

                    var operationitLog = OperationSharedServiceRatingIT.Create(operationLog.Id, request.ARMSharedService);
                    await operationit.AddAsync(operationitLog);

                    var operadminLog = OperationSharedServiceRatingProcurementAndAdmin.Create(operationLog.Id, request.ARMSharedService);
                    await operadmin.AddAsync(operadminLog);

                    var operhcmLog = OperationSharedServiceRatingHCM.Create(operationLog.Id, request.ARMSharedService);
                    await operhcm.AddAsync(operhcmLog);

                    var operationsharedDataLog = OperationSharedServiceDataAnalyticRating.Create(operationLog.Id, request.ARMSharedService);
                    await opDataAna.AddAsync(operationsharedDataLog);

                    var operationsharedFinCtrlLog = OperationSharedServiceFinancialControlRating.Create(operationLog.Id, request.ARMSharedService);
                    await opFinCtrl.AddAsync(operationsharedFinCtrlLog);

                    var operationsharedCompLog = OperationSharedServiceComplianceRating.Create(operationLog.Id, request.ARMSharedService);
                    await opCompliance.AddAsync(operationsharedCompLog);

                    var complianceLog = ComplianceSharedService.Create(sharedLog.Id, request.ARMSharedService.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);

                    var complianceCustExpLog = ComplianceSharedServiceRatingCustomerexperience.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceCustExp.AddAsync(complianceCustExpLog);

                    var complianceCTOLog = ComplianceSharedServiceRatingCTO.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceCTO.AddAsync(complianceCTOLog);

                    var compliancemccLLog = ComplianceSharedServiceRatingMCC.Create(complianceLog.Id, request.ARMSharedService);
                    await compliancemccL.AddAsync(compliancemccLLog);

                    var complianceItLog = ComplianceSharedServiceRatingIT.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceIt.AddAsync(complianceItLog);

                    var compliancemchcmLog = ComplianceSharedServiceRatingHCM.Create(complianceLog.Id, request.ARMSharedService);
                    await compliancemchcm.AddAsync(compliancemchcmLog);

                    var complianceLegalLog = ComplianceSharedServiceRatingLegal.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceLegal.AddAsync(complianceLegalLog);

                    var complianceriskmgtLog = ComplianceSharedServiceRatingRiskManagement.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceriskmgt.AddAsync(complianceriskmgtLog);

                    var complianceacademyLog = ComplianceSharedServiceRatingAcademy.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceacademy.AddAsync(complianceacademyLog);

                    var complianceadminLog = ComplianceSharedServiceRatingProcurementAndAdmin.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceadmin.AddAsync(complianceadminLog);

                    var compliancecorperatLog = ComplianceSharedServiceRatingCorporatestrategy.Create(complianceLog.Id, request.ARMSharedService);
                    await compliancecorperat.AddAsync(compliancecorperatLog);

                    var complianceintctrlLog = ComplianceSharedServiceRatingInternalControl.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceintctrl.AddAsync(complianceintctrlLog);

                    var complianceinfosecLog = ComplianceSharedServiceRatingInformationSecurity.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceinfosec.AddAsync(complianceinfosecLog);

                    var compliancetreasuryLog = ComplianceSharedServiceRatingTreasury.Create(complianceLog.Id, request.ARMSharedService);
                    await compliancetreasury.AddAsync(compliancetreasuryLog);

                    var complianceCompLog = ComplianceSharedServiceComplianceRating.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceComp.AddAsync(complianceCompLog);

                    var complianceDataLog = ComplianceSharedServiceDataAnalyticRating.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceDataAna.AddAsync(complianceDataLog);

                    var compliancesharedFinCtrlLog = ComplianceSharedServiceFinancialControlRating.Create(complianceLog.Id, request.ARMSharedService);
                    await complianceFinCtrl.AddAsync(compliancesharedFinCtrlLog);

                    var timeSinceLastSharedAuditLog = TimeSinceLastSharedServiceAudit.Create(sharedLog.Id, request.ARMSharedService);
                    await timeSinceLastSharedAudit.AddAsync(timeSinceLastSharedAuditLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMSharedService", requesterName, request.ARMSharedService.Status);
                    await ratedBusinessRiskRating.AddAsync(logratedBusinessRiskRating);
                    await ratedBusinessRiskRating.SaveChangesAsync();

                    BusinessRiskRatingResponse response = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = getUser.Id
                    };

                    #region Send email to the Excecutive Management Concern Assessment 
                    string subject = $"Internal Audit FY {DateTime.Now.AddYears(1).Year} Plan - Excecutive Management Concern Assessment";
                    string emailTo = config["EmailConfiguration:EmailToGroupCEOAndDeputy"];
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                    string MondayDecember11 = new DateTime(DateTime.Now.Year, 12, 13).ToString("dd MMMM yyyy");
                    var linkToGRCToolEMC = string.Format(config["EmailConfiguration:EMCConcernsLink"], getUser.Id);
                    var linkToGRCToolMC = string.Format(config["EmailConfiguration:ManagementConcernsLink"], getUser.Id);
                    string body = $"Dear EMC, <br><br>Trust you are doing well.<br><br>The Internal Audit unit is in the process of developing the FY {DateTime.Now.AddYears(1).Year} Internal Audit plan for the different Businesses and Shared Service functions.<br><br>One of the key factors considered during this exercise is “EMC’s Concern”. This helps us to put Executive Management’s concerns around the various Businesses, Business units and Shared Service functions into consideration when developing the audit plan, in order to ensure that all significant risk and significant interest areas are adequately catered for in our plan.<br><br>Kindly complete the form in the link below with your feedback on the different areas.<br><br>Please sign in using your Active Directory user name and password.<br><br><a href={linkToGRCToolEMC}>GRC Link</a>.<br><br>We would appreciate completion of this form by close of business on {MondayDecember11}.<br><br>Thank you.<br><br>Internal Audit";

                    var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, getUser.Id, emailTo, toCC);

                    #endregion

                    #region Send email to the Management Concern Assessment 
                    string subjectMC = $"Internal Audit FY {DateTime.Now.AddYears(1).Year} Plan - Management Concern Assessment";
                    string emailToMC = config["EmailConfiguration:EmailToBusinessMD"];
                    string bodyMC = $"Dear All, <br><br>The Internal Audit unit is in the process of developing the FY {DateTime.Now.AddYears(1).Year} audit plan for the different Businesses and Shared Service functions. <br><br>One of the key factors considered during this exercise is “Management’s Concerns”. This helps us to put Management’s concerns or worries over their Business, Business units and Shared Service units into consideration when developing the audit plan, in order to ensure that all significant risk and significant interest areas are adequately catered for in our plan.<br><br>Kindly complete the form in the link below with your feedback on the different areas.<br><br><a href={linkToGRCToolMC}>GRC Link</a>.<br><br>Please sign in using your Active Directory user name and password.<br><br>We would appreciate completion by close of business on {MondayDecember11}.<br><br>Thank you.<br><br>Internal Audit";

                    var logEmailRequest2 = await EmailService.LogEmailRequestAssync(subject: subjectMC, message: bodyMC, ModuleType.InternalAudit, getUser.Id, emailToMC, toCC);
                    if (logEmailRequest == false)
                    {
                        return TypedResults.Ok($"EMC: Request created successfully {getUser.Id} but email message was not logged");
                    }
                    #endregion

                    return TypedResults.Created($"apra/{response}", response);
                }

                if (getUser == null)
                {
                    var logRequest = BusinessRiskRating.Create(requesterName);
                    await busnessRiskRating.AddAsync(logRequest);

                    var sharedLog2 = ARMSharedServiceRating.Create(getUser.Id, request.ARMSharedService.Status, requesterName);
                    await shared.AddAsync(sharedLog2);

                    var strategyLog2 = StrategySharedService.Create(sharedLog2.Id, request.ARMSharedService.Strategy.Comment);
                    await strategy.AddAsync(strategyLog2);

                    var straTreasuryLog2 = StrategySharedServiceRatingTreasury.Create(strategyLog2.Id, request.ARMSharedService);
                    await straTreasury.AddAsync(straTreasuryLog2);

                    var strategycorpstraLog2 = StrategySharedServiceRatingCorporatestrategy.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategycorpstra.AddAsync(strategycorpstraLog2);

                    var strategyintctrlLog2 = StrategySharedServiceRatingInternalControl.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyintctrl.AddAsync(strategyintctrlLog2);

                    var strategyinfsecLog2 = StrategySharedServiceRatingInformationSecurity.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyinfsec.AddAsync(strategyinfsecLog2);

                    var strategycustexpLog2 = StrategySharedServiceRatingCustomerexperience.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategycustexp.AddAsync(strategycustexpLog2);

                    var strategyCTOLog2 = StrategySharedServiceRatingCTO.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyCTO.AddAsync(strategyCTOLog2);

                    var strategymccLog2 = StrategySharedServiceRatingMCC.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategymcc.AddAsync(strategymccLog2);

                    var strategylegalLog2 = StrategySharedServiceRatingLegal.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategylegal.AddAsync(strategylegalLog2);

                    var strategyacadeLog2 = StrategySharedServiceRatingAcademy.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyacade.AddAsync(strategyacadeLog2);

                    var strategyriskmgtLog2 = StrategySharedServiceRatingRiskManagement.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyriskmgt.AddAsync(strategyriskmgtLog2);

                    var strategyItLog2 = StrategySharedServiceRatingIT.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyIt.AddAsync(strategyItLog2);

                    var strategyadminLog2 = StrategySharedServiceRatingProcurementAndAdmin.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyadmin.AddAsync(strategyadminLog2);

                    var strategyhcmLog2 = StrategySharedServiceRatingHCM.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyhcm.AddAsync(strategyhcmLog2);

                    var strategyCompLog2 = StrategySharedServiceCompliance.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyCompliance.AddAsync(strategyCompLog2);

                    var strategysharedFinctrlLog2 = StrategySharedServiceFinancialControl.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyFinCtrl.AddAsync(strategysharedFinctrlLog2);

                    var strategyDataLog2 = StrategySharedServiceDataAnalytic.Create(strategyLog2.Id, request.ARMSharedService);
                    await strategyDataAnaly.AddAsync(strategyDataLog2);

                    var operationLog2 = OperationSharedService.Create(sharedLog2.Id, request.ARMSharedService.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operationsharedDataLog = OperationSharedServiceDataAnalyticRating.Create(operationLog2.Id, request.ARMSharedService);
                    await opDataAna.AddAsync(operationsharedDataLog);

                    var operationsharedFinCtrlLog = OperationSharedServiceFinancialControlRating.Create(operationLog2.Id, request.ARMSharedService);
                    await opFinCtrl.AddAsync(operationsharedFinCtrlLog);

                    var operationsharedCompLog = OperationSharedServiceComplianceRating.Create(operationLog2.Id, request.ARMSharedService);
                    await opCompliance.AddAsync(operationsharedCompLog);

                    var opertreasuryLog2 = OperationSharedServiceRatingTreasury.Create(operationLog2.Id, request.ARMSharedService);
                    await opertreasury.AddAsync(opertreasuryLog2);

                    var operationcorpatLog2 = OperationSharedServiceRatingCorporatestrategy.Create(operationLog2.Id, request.ARMSharedService);
                    await operationcorpat.AddAsync(operationcorpatLog2);

                    var operIntCtrlLog2 = OperationSharedServiceRatingInternalControl.Create(operationLog2.Id, request.ARMSharedService);
                    await operIntCtrl.AddAsync(operIntCtrlLog2);

                    var operinfosecLog = OperationSharedServiceRatingInformationSecurity.Create(operationLog2.Id, request.ARMSharedService);
                    await operinfosec.AddAsync(operinfosecLog);

                    var operationcustexpLog2 = OperationSharedServiceRatingCustomerexperience.Create(operationLog2.Id, request.ARMSharedService);
                    await operationcustexp.AddAsync(operationcustexpLog2);

                    var operCTOLog2 = OperationSharedServiceRatingCTO.Create(operationLog2.Id, request.ARMSharedService);
                    await operCTO.AddAsync(operCTOLog2);

                    var opermccLog2 = OperationSharedServiceRatingMCC.Create(operationLog2.Id, request.ARMSharedService);
                    await opermcc.AddAsync(opermccLog2);

                    var operationclegalLog2 = OperationSharedServiceRatingLegal.Create(operationLog2.Id, request.ARMSharedService);
                    await operationclegal.AddAsync(operationclegalLog2);

                    var operriskmgtLog2 = OperationSharedServiceRatingRiskManagement.Create(operationLog2.Id, request.ARMSharedService);
                    await operriskmgt.AddAsync(operriskmgtLog2);

                    var operacademyLog2 = OperationSharedServiceRatingAcademy.Create(operationLog2.Id, request.ARMSharedService);
                    await operacademy.AddAsync(operacademyLog2);

                    var operationitLog2 = OperationSharedServiceRatingIT.Create(operationLog2.Id, request.ARMSharedService);
                    await operationit.AddAsync(operationitLog2);

                    var operadminLog2 = OperationSharedServiceRatingProcurementAndAdmin.Create(operationLog2.Id, request.ARMSharedService);
                    await operadmin.AddAsync(operadminLog2);

                    var operhcmLog2 = OperationSharedServiceRatingHCM.Create(operationLog2.Id, request.ARMSharedService);
                    await operhcm.AddAsync(operhcmLog2);

                    var operationsharedDataLog2 = OperationSharedServiceDataAnalyticRating.Create(operationLog2.Id, request.ARMSharedService);
                    await opDataAna.AddAsync(operationsharedDataLog2);

                    var operationsharedFinCtrlLog2 = OperationSharedServiceFinancialControlRating.Create(operationLog2.Id, request.ARMSharedService);
                    await opFinCtrl.AddAsync(operationsharedFinCtrlLog2);

                    var operationsharedCompLog2 = OperationSharedServiceComplianceRating.Create(operationLog2.Id, request.ARMSharedService);
                    await opCompliance.AddAsync(operationsharedCompLog2);

                    var complianceLog2 = ComplianceSharedService.Create(sharedLog2.Id, request.ARMSharedService.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var complianceCustExpLog = ComplianceSharedServiceRatingCustomerexperience.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceCustExp.AddAsync(complianceCustExpLog);

                    var complianceCTOLog2 = ComplianceSharedServiceRatingCTO.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceCTO.AddAsync(complianceCTOLog2);

                    var compliancemccLLog2 = ComplianceSharedServiceRatingMCC.Create(complianceLog2.Id, request.ARMSharedService);
                    await compliancemccL.AddAsync(compliancemccLLog2);

                    var complianceItLog2 = ComplianceSharedServiceRatingIT.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceIt.AddAsync(complianceItLog2);

                    var compliancemchcmLog2 = ComplianceSharedServiceRatingHCM.Create(complianceLog2.Id, request.ARMSharedService);
                    await compliancemchcm.AddAsync(compliancemchcmLog2);

                    var complianceLegalLog2 = ComplianceSharedServiceRatingLegal.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceLegal.AddAsync(complianceLegalLog2);

                    var complianceriskmgtLog2 = ComplianceSharedServiceRatingRiskManagement.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceriskmgt.AddAsync(complianceriskmgtLog2);

                    var complianceacademyLog2 = ComplianceSharedServiceRatingAcademy.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceacademy.AddAsync(complianceacademyLog2);

                    var complianceadminLog2 = ComplianceSharedServiceRatingProcurementAndAdmin.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceadmin.AddAsync(complianceadminLog2);

                    var compliancecorperatLog2 = ComplianceSharedServiceRatingCorporatestrategy.Create(complianceLog2.Id, request.ARMSharedService);
                    await compliancecorperat.AddAsync(compliancecorperatLog2);

                    var complianceintctrlLog2 = ComplianceSharedServiceRatingInternalControl.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceintctrl.AddAsync(complianceintctrlLog2);

                    var complianceinfosecLog2 = ComplianceSharedServiceRatingInformationSecurity.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceinfosec.AddAsync(complianceinfosecLog2);

                    var compliancetreasuryLog2 = ComplianceSharedServiceRatingTreasury.Create(complianceLog2.Id, request.ARMSharedService);
                    await compliancetreasury.AddAsync(compliancetreasuryLog2);

                    var complianceCompLog2 = ComplianceSharedServiceComplianceRating.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceComp.AddAsync(complianceCompLog2);

                    var complianceDataLog2 = ComplianceSharedServiceDataAnalyticRating.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceDataAna.AddAsync(complianceDataLog2);

                    var compliancesharedFinCtrlLog2 = ComplianceSharedServiceFinancialControlRating.Create(complianceLog2.Id, request.ARMSharedService);
                    await complianceFinCtrl.AddAsync(compliancesharedFinCtrlLog2);

                    var timeSinceLastSharedAuditLog2 = TimeSinceLastSharedServiceAudit.Create(sharedLog2.Id, request.ARMSharedService);
                    await timeSinceLastSharedAudit.AddAsync(timeSinceLastSharedAuditLog2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMSharedService", requesterName, request.ARMSharedService.Status);
                    await ratedBusinessRiskRating.AddAsync(logratedBusinessRiskRating2);
                    await ratedBusinessRiskRating.SaveChangesAsync();

                    BusinessRiskRatingResponse response = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = logRequest.Id
                    };
                    #region Send email to the Excecutive Management Concern Assessment 
                    string subject = $"Internal Audit FY {DateTime.Now.AddYears(1).Year} Plan - Excecutive Management Concern Assessment";
                    string emailTo = config["EmailConfiguration:EmailToGroupCEOAndDeputy"];
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                    string MondayDecember11 = new DateTime(DateTime.Now.Year, 12, 13).ToString("dd MMMM yyyy");
                    var linkToGRCToolEMC2 = string.Format(config["EmailConfiguration:EMCConcernsLink"], logRequest.Id);
                    var linkToGRCToolMC2 = string.Format(config["EmailConfiguration:ManagementConcernsLink"], logRequest.Id);
                    string body = $"Dear EMC, <br><br>Trust you are doing well.<br><br>.The Internal Audit unit is in the process of developing the FY {DateTime.Now.AddYears(1).Year} Internal Audit plan for the different Businesses and Shared Service functions.<br><br>One of the key factors considered during this exercise is “EMC’s Concern”. This helps us to put Executive Management’s concerns around the various Businesses, Business units and Shared Service functions into consideration when developing the audit plan, in order to ensure that all significant risk and significant interest areas are adequately catered for in our plan.<br><br>Kindly complete the form in the link below with your feedback on the different areas.<br><br>Please sign in using your Active Directory user name and password.<br><br><a href={linkToGRCToolEMC2}>GRC Link</a>.<br><br>We would appreciate completion of this form by close of business on {MondayDecember11}.<br><br>Thank you.<br><br>Internal Audit";

                    var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, getUser.Id, emailTo, toCC);

                    #endregion

                    #region Send email to the Management Concern Assessment 
                    string subjectMC = $"Internal Audit FY {DateTime.Now.AddYears(1).Year} Plan - Management Concern Assessment";
                    string emailToMC = config["EmailConfiguration:EmailToBusinessMD"];
                    string bodyMC = $"Dear All, <br><br>The Internal Audit unit is in the process of developing the FY {DateTime.Now.AddYears(1).Year} audit plan for the different Businesses and Shared Service functions. <br><br>One of the key factors considered during this exercise is “Management’s Concerns”. This helps us to put Management’s concerns or worries over their Business, Business units and Shared Service units into consideration when developing the audit plan, in order to ensure that all significant risk and significant interest areas are adequately catered for in our plan.<br><br>Kindly complete the form in the link below with your feedback on the different areas.<br><br><a href={linkToGRCToolMC2}>GRC Link</a>.<br><br>Please sign in using your Active Directory user name and password.<br><br>We would appreciate completion by close of business on {MondayDecember11}.<br><br>Thank you.<br><br>Internal Audit";

                    var logEmailRequest2 = await EmailService.LogEmailRequestAssync(subject: subjectMC, message: bodyMC, ModuleType.InternalAudit, getUser.Id, emailToMC, toCC);
                    if (logEmailRequest == false)
                    {
                        return TypedResults.Ok($"EMC: Request created successfully {getUser.Id} but email message was not logged");
                    }
                    #endregion
                    return TypedResults.Created($"apra/{response}", response);
                }
                return TypedResults.Ok("submit the request");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
