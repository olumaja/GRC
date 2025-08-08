using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.Win32;
using Org.BouncyCastle.Ocsp;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 04/18/2024
 * Development Group: Audit Development Plan - GRCTools
 * This endpoint get audit universe summary
 */
    public class GetMonthlyAuditUniverseSummary
    {
        /// <summary>
        /// Audit universe summary
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="armholdcoauditUniverse"></param>
        /// <param name="armholdco"></param>
        /// <param name="armHoldCoTreasurySale"></param>
        /// <param name="dfsreq"></param>
        /// <param name="dfsRate"></param>
        /// <param name="capitalreq"></param>
        /// <param name="capitalRate"></param>
        /// <param name="armimauditUniverse"></param>
        /// <param name="imunit"></param>
        /// <param name="operationControl"></param>
        /// <param name="fundAdmin"></param>
        /// <param name="registrar"></param>
        /// <param name="bDPWMIAMIMRetail"></param>
        /// <param name="operationSettlement"></param>
        /// <param name="retailOperation"></param>
        /// <param name="research"></param>
        /// <param name="fundAccount"></param>
        /// <param name="secReq"></param>
        /// <param name="stockBroking"></param>
        /// <param name="trusteeReq"></param>
        /// <param name="privateTrust"></param>
        /// <param name="commercialTrust"></param>
        /// <param name="hillreq"></param>
        /// <param name="hillarmhill"></param>
        /// <param name="agrreq"></param>
        /// <param name="agraafml"></param>
        /// <param name="agrirfl"></param>
        /// <param name="sharedServiceAuditUniverse"></param>
        /// <param name="sharedServicecorporateStrategy"></param>
        /// <param name="sharedServicehcm"></param>
        /// <param name="sharedServiceprocurementandAdmin"></param>
        /// <param name="sharedServiceinternalControl"></param>
        /// <param name="sharedServiceacademy"></param>
        /// <param name="sharedServicelegal"></param>
        /// <param name="dataAna"></param>
        /// <param name="sharedServiceriskManagement"></param>
        /// <param name="sharedServicemcc"></param>
        /// <param name="sharedServiceit"></param>
        /// <param name="sharedServicetreasure"></param>
        /// <param name="sharedServiceCTO"></param>
        /// <param name="sharedServicecustomerExperience"></param>
        /// <param name="informationSecurity"></param>
        /// <param name="finCtrl"></param>
        /// <param name="comp"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<AnualAuditUniverseRiskRating> repo, IRepository<ARMHoldingCompanyAnnualAuditUniverse> armholdcoauditUniverse,
            IRepository<AuditUniverseARMHoldingCompany> armholdco, IRepository<AuditUniverseARMHoldCoTreasurySale> armHoldCoTreasurySale,
            IRepository<DigitalFinancialServiceAuditUniverse> dfsreq, IRepository<AuditUniverseDigitalFinancialServiceRating> dfsRate,
            IRepository<ARMCapitalAuditUniverse> capitalreq, IRepository<AuditUniverseARMCapitalRating> capitalRate,
            IRepository<ARMIMAuditUniverse> armimauditUniverse, IRepository<AuditUniverseARMIMIMUnit> imunit, IRepository<AuditUniverseARMIMRating> armim, 
            IRepository<AuditUniverseARMIMOperationControl> operationControl, IRepository<AuditUniverseARMIMFundAdmin> fundAdmin,
            IRepository<AuditUniverseARMIMRegistrar> registrar, IRepository<AuditUniverseARMIMBDPWMIAMIMRetail> bDPWMIAMIMRetail,
            IRepository<AuditUniverseARMIMOperationSettlement> operationSettlement, IRepository<AuditUniverseARMIMRetailOperation> retailOperation,
            IRepository<AuditUniverseARMIMResearch> research, IRepository<AuditUniverseARMIMFundAccount> fundAccount,
            IRepository<ARMSecurityAnnualAuditUniverse> secReq, IRepository<AuditUniverseARMSecurityStockBroking> stockBroking,
            IRepository<ARMTrusteeAuditUniverse> trusteeReq, IRepository<AuditUniverseARMTrusteePrivateTrust> privateTrust,
            IRepository<AuditUniverseARMTrusteeCommercialTrust> commercialTrust, IRepository<ARMHillAuditUniverse> hillreq, IRepository<AuditUniverseARMHill> hillarmhill,
            IRepository<ARMAgribusinessAuditUniverse> agrreq, IRepository<AuditUniverseARMAgribusinessAAFML> agraafml, IRepository<AuditUniverseARMAgribusinessRFL> agrirfl,

            IRepository<ARMSharedAuditUniverse> sharedServiceAuditUniverse, IRepository<ARMSharedAuditUniverseCorporatestrategy> sharedServicecorporateStrategy,
            IRepository<ARMSharedAuditUniverseHCM> sharedServicehcm, IRepository<ARMSharedAuditUniverseProcurementAndAdmin> sharedServiceprocurementandAdmin, IRepository<ARMSharedAuditUniverseInternalControl> sharedServiceinternalControl,
            IRepository<ARMSharedAuditUniverseAcademy> sharedServiceacademy, IRepository<ARMSharedAuditUniverseLegal> sharedServicelegal, IRepository<ARMSharedAuditUniverseDataAnalytic> dataAna,
            IRepository<ARMSharedAuditUniverseRiskManagement> sharedServiceriskManagement, IRepository<ARMSharedAuditUniverseMCC> sharedServicemcc, IRepository<ARMSharedAuditUniverseIT> sharedServiceit,
            IRepository<ARMSharedAuditUniverseTreasury> sharedServicetreasure, IRepository<ARMSharedAuditUniverseCTO> sharedServiceCTO, IRepository<ARMSharedAuditUniverseCustomerExperience> sharedServicecustomerExperience,
            IRepository<ARMSharedAuditUniverseInformationSecurity> informationSecurity, IRepository<ARMSharedAuditUniverseFinancialControl> finCtrl, IRepository<ARMSharedAuditUniverseCompliance> comp,


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

                List<AuditUniverseReports> resp = new List<AuditUniverseReports>();
                var getAuditUniverse = repo.GetContextByConditon(c => c.Id != null).ToList();
                if (getAuditUniverse == null)
                {
                    return TypedResults.NotFound("No record found");
                }
               

                if (getAuditUniverse != null)
                {
                    foreach (var item in getAuditUniverse)
                    {

                        //Holdco
                        var getArmHoldco = armholdcoauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getArmHoldco == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHoldingCompany");
                        }
                        var getarmholdco = armholdco.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getArmHoldco.Id).FirstOrDefault();
                        var getarmHoldCoTreasurySale = armHoldCoTreasurySale.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getArmHoldco.Id).FirstOrDefault();

                        //DFS
                        var getAuditRating = dfsreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getAuditRating == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                        }
                        var getdfsRate = dfsRate.GetContextByConditon(x => x.DigitalFinancialServiceAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                        //capital
                        var getcapitalAuditRating = capitalreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getcapitalAuditRating == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                        }
                        var getcapitalRate = capitalRate.GetContextByConditon(x => x.ARMCapitalAuditUniverseId == getcapitalAuditRating.Id).FirstOrDefault();
                                                
                        //security
                        var getSecAuditRating = secReq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getSecAuditRating == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMSecurity");
                        }
                        var getstockBroking = stockBroking.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == getSecAuditRating.Id).FirstOrDefault();

                        //trustee
                        var getTrusteeAuditRating = trusteeReq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getTrusteeAuditRating == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMTrustee");
                        }
                        var getprivateTrust = privateTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == getTrusteeAuditRating.Id).FirstOrDefault();
                        var getcommercialTrust = commercialTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == getTrusteeAuditRating.Id).FirstOrDefault();

                        //hill
                        var getHillAuditRating = hillreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getHillAuditRating == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                        }
                        var getarmhill = hillarmhill.GetContextByConditon(x => x.ARMHillAuditUniverseId == getHillAuditRating.Id).FirstOrDefault();

                        //agri
                        var getAgriAuditRating = agrreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getAgriAuditRating == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMAgribusiness");
                        }
                        var getrfl = agrirfl.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == getAgriAuditRating.Id).FirstOrDefault();
                        var getaafml = agraafml.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == getAgriAuditRating.Id).FirstOrDefault();

                        //shared
                        var getSharedAuditRating = sharedServiceAuditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getSharedAuditRating == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMSharedService");
                        }
                        var getcomp = comp.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getfinCtrl = finCtrl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getcorporateStrategy = sharedServicecorporateStrategy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var gethcm = sharedServicehcm.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var gettreasure = sharedServicetreasure.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getriskManagement = sharedServiceriskManagement.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getacademy = sharedServiceacademy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getCTO = sharedServiceCTO.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getIT = sharedServiceit.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getMCC = sharedServicemcc.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getlegal = sharedServicelegal.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getinternalControl = sharedServiceinternalControl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getprocurementandAdmin = sharedServiceprocurementandAdmin.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getdataAna = dataAna.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getcustomerExperience = sharedServicecustomerExperience.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();
                        var getinformationSecurity = informationSecurity.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getSharedAuditRating.Id).FirstOrDefault();

                        //IM
                        var getIMAuditRating = armimauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == item.Id).FirstOrDefault();
                        if (getIMAuditRating == null)
                        {
                            return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMIM");
                        }
                        var getimunit = imunit.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getoperationControl = operationControl.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getregistrar = registrar.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getbDPWMIAMIMRetail = bDPWMIAMIMRetail.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getoperationSettlement = operationSettlement.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getfundAdmin = fundAdmin.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getfundAccount = fundAccount.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getretailOperation = retailOperation.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getresearch = research.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();
                        var getarmim = armim.GetContextByConditon(x => x.ARMIMAuditUniverseId == getIMAuditRating.Id).FirstOrDefault();

                        resp.Add(new AuditUniverseReports
                        {
                            ARMIM = new ARMIMAuditUniverseReport
                            {
                                ARMIM = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getarmim.BusinessManagerConcern,
                                    DirectorConcern = getarmim.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getarmim.RiskScore ?? string.Empty,
                                    RiskRating = getarmim.RiskRating ?? string.Empty,
                                    Recommentation = getarmim.Recommentation ?? string.Empty,
                                    January = getarmim.January ?? string.Empty,
                                    February = getarmim.February ?? string.Empty,
                                    March = getarmim.March ?? string.Empty,
                                    April = getarmim.April ?? string.Empty,
                                    May = getarmim.May ?? string.Empty,
                                    June = getarmim.June ?? string.Empty,
                                    July = getarmim.July ?? string.Empty,
                                    August = getarmim.August ?? string.Empty,
                                    September = getarmim.September ?? string.Empty,
                                    October = getarmim.October ?? string.Empty,
                                    November = getarmim.November ?? string.Empty,
                                    December = getarmim.December ?? string.Empty

                                },
                                ARMRegistrar = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getregistrar.BusinessManagerConcern,
                                    DirectorConcern = getregistrar.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getregistrar.RiskScore ?? string.Empty,
                                    RiskRating = getregistrar.RiskRating ?? string.Empty,
                                    Recommentation = getregistrar.Recommentation ?? string.Empty,
                                    January = getregistrar.January ?? string.Empty,
                                    February = getregistrar.February ?? string.Empty,
                                    March = getregistrar.March ?? string.Empty,
                                    April = getregistrar.April ?? string.Empty,
                                    May = getregistrar.May ?? string.Empty,
                                    June = getregistrar.June ?? string.Empty,
                                    July = getregistrar.July ?? string.Empty,
                                    August = getregistrar.August ?? string.Empty,
                                    September = getregistrar.September ?? string.Empty,
                                    October = getregistrar.October ?? string.Empty,
                                    November = getregistrar.November ?? string.Empty,
                                    December = getregistrar.December ?? string.Empty
                                },
                                BDPWMIAMIMRetail = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getbDPWMIAMIMRetail.BusinessManagerConcern,
                                    DirectorConcern = getbDPWMIAMIMRetail.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getbDPWMIAMIMRetail.RiskScore ?? string.Empty,
                                    RiskRating = getbDPWMIAMIMRetail.RiskRating ?? string.Empty,
                                    Recommentation = getbDPWMIAMIMRetail.Recommentation ?? string.Empty,
                                    January = getbDPWMIAMIMRetail.January ?? string.Empty,
                                    February = getbDPWMIAMIMRetail.February ?? string.Empty,
                                    March = getbDPWMIAMIMRetail.March ?? string.Empty,
                                    April = getbDPWMIAMIMRetail.April ?? string.Empty,
                                    May = getbDPWMIAMIMRetail.May ?? string.Empty,
                                    June = getbDPWMIAMIMRetail.June ?? string.Empty,
                                    July = getbDPWMIAMIMRetail.July ?? string.Empty,
                                    August = getbDPWMIAMIMRetail.August ?? string.Empty,
                                    September = getbDPWMIAMIMRetail.September ?? string.Empty,
                                    October = getbDPWMIAMIMRetail.October ?? string.Empty,
                                    November = getbDPWMIAMIMRetail.November ?? string.Empty,
                                    December = getbDPWMIAMIMRetail.December ?? string.Empty
                                },
                                FundAccount = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getfundAccount.BusinessManagerConcern,
                                    DirectorConcern = getfundAccount.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getfundAccount.RiskScore ?? string.Empty,
                                    RiskRating = getfundAccount.RiskRating ?? string.Empty,
                                    Recommentation = getfundAccount.Recommentation ?? string.Empty,
                                    January = getfundAccount.January ?? string.Empty,
                                    February = getfundAccount.February ?? string.Empty,
                                    March = getfundAccount.March ?? string.Empty,
                                    April = getfundAccount.April ?? string.Empty,
                                    May = getfundAccount.May ?? string.Empty,
                                    June = getfundAccount.June ?? string.Empty,
                                    July = getfundAccount.July ?? string.Empty,
                                    August = getfundAccount.August ?? string.Empty,
                                    September = getfundAccount.September ?? string.Empty,
                                    October = getfundAccount.October ?? string.Empty,
                                    November = getfundAccount.November ?? string.Empty,
                                    December = getfundAccount.December ?? string.Empty
                                },
                                FundAdmin = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getfundAdmin.BusinessManagerConcern,
                                    DirectorConcern = getfundAdmin.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getfundAdmin.RiskScore ?? string.Empty,
                                    RiskRating = getfundAdmin.RiskRating ?? string.Empty,
                                    Recommentation = getfundAdmin.Recommentation ?? string.Empty,
                                    January = getfundAdmin.January ?? string.Empty,
                                    February = getfundAdmin.February ?? string.Empty,
                                    March = getfundAdmin.March ?? string.Empty,
                                    April = getfundAdmin.April ?? string.Empty,
                                    May = getfundAdmin.May ?? string.Empty,
                                    June = getfundAdmin.June ?? string.Empty,
                                    July = getfundAdmin.July ?? string.Empty,
                                    August = getfundAdmin.August ?? string.Empty,
                                    September = getfundAdmin.September ?? string.Empty,
                                    October = getfundAdmin.October ?? string.Empty,
                                    November = getfundAdmin.November ?? string.Empty,
                                    December = getfundAdmin.December ?? string.Empty
                                },
                                OperationSettlement = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getoperationSettlement.BusinessManagerConcern,
                                    DirectorConcern = getoperationSettlement.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getoperationSettlement.RiskScore ?? string.Empty,
                                    RiskRating = getoperationSettlement.RiskRating ?? string.Empty,
                                    Recommentation = getoperationSettlement.Recommentation ?? string.Empty,
                                    January = getoperationSettlement.January ?? string.Empty,
                                    February = getoperationSettlement.February ?? string.Empty,
                                    March = getoperationSettlement.March ?? string.Empty,
                                    April = getoperationSettlement.April ?? string.Empty,
                                    May = getoperationSettlement.May ?? string.Empty,
                                    June = getoperationSettlement.June ?? string.Empty,
                                    July = getoperationSettlement.July ?? string.Empty,
                                    August = getoperationSettlement.August ?? string.Empty,
                                    September = getoperationSettlement.September ?? string.Empty,
                                    October = getoperationSettlement.October ?? string.Empty,
                                    November = getoperationSettlement.November ?? string.Empty,
                                    December = getoperationSettlement.December ?? string.Empty
                                },
                                IMUnit = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getimunit.BusinessManagerConcern,
                                    DirectorConcern = getimunit.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getimunit.RiskScore ?? string.Empty,
                                    RiskRating = getimunit.RiskRating ?? string.Empty,
                                    Recommentation = getimunit.Recommentation ?? string.Empty,
                                    January = getimunit.January ?? string.Empty,
                                    February = getimunit.February ?? string.Empty,
                                    March = getimunit.March ?? string.Empty,
                                    April = getimunit.April ?? string.Empty,
                                    May = getimunit.May ?? string.Empty,
                                    June = getimunit.June ?? string.Empty,
                                    July = getimunit.July ?? string.Empty,
                                    August = getimunit.August ?? string.Empty,
                                    September = getimunit.September ?? string.Empty,
                                    October = getimunit.October ?? string.Empty,
                                    November = getimunit.November ?? string.Empty,
                                    December = getimunit.December ?? string.Empty
                                },
                                OperationControl = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getoperationControl.BusinessManagerConcern,
                                    DirectorConcern = getoperationControl.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getoperationControl.RiskScore ?? string.Empty,
                                    RiskRating = getoperationControl.RiskRating ?? string.Empty,
                                    Recommentation = getoperationControl.Recommentation ?? string.Empty,
                                    January = getoperationControl.January ?? string.Empty,
                                    February = getoperationControl.February ?? string.Empty,
                                    March = getoperationControl.March ?? string.Empty,
                                    April = getoperationControl.April ?? string.Empty,
                                    May = getoperationControl.May ?? string.Empty,
                                    June = getoperationControl.June ?? string.Empty,
                                    July = getoperationControl.July ?? string.Empty,
                                    August = getoperationControl.August ?? string.Empty,
                                    September = getoperationControl.September ?? string.Empty,
                                    October = getoperationControl.October ?? string.Empty,
                                    November = getoperationControl.November ?? string.Empty,
                                    December = getoperationControl.December ?? string.Empty
                                },
                                RetailOperation = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getretailOperation.BusinessManagerConcern,
                                    DirectorConcern = getretailOperation.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getretailOperation.RiskScore ?? string.Empty,
                                    RiskRating = getretailOperation.RiskRating ?? string.Empty,
                                    Recommentation = getretailOperation.Recommentation ?? string.Empty,
                                    January = getretailOperation.January ?? string.Empty,
                                    February = getretailOperation.February ?? string.Empty,
                                    March = getretailOperation.March ?? string.Empty,
                                    April = getretailOperation.April ?? string.Empty,
                                    May = getretailOperation.May ?? string.Empty,
                                    June = getretailOperation.June ?? string.Empty,
                                    July = getretailOperation.July ?? string.Empty,
                                    August = getretailOperation.August ?? string.Empty,
                                    September = getretailOperation.September ?? string.Empty,
                                    October = getretailOperation.October ?? string.Empty,
                                    November = getretailOperation.November ?? string.Empty,
                                    December = getretailOperation.December ?? string.Empty
                                },
                                Research = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getresearch.BusinessManagerConcern,
                                    DirectorConcern = getresearch.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getresearch.RiskScore ?? string.Empty,
                                    RiskRating = getresearch.RiskRating ?? string.Empty,
                                    Recommentation = getresearch.Recommentation ?? string.Empty,
                                    January = getresearch.January ?? string.Empty,
                                    February = getresearch.February ?? string.Empty,
                                    March = getresearch.March ?? string.Empty,
                                    April = getresearch.April ?? string.Empty,
                                    May = getresearch.May ?? string.Empty,
                                    June = getresearch.June ?? string.Empty,
                                    July = getresearch.July ?? string.Empty,
                                    August = getresearch.August ?? string.Empty,
                                    September = getresearch.September ?? string.Empty,
                                    October = getresearch.October ?? string.Empty,
                                    November = getresearch.November ?? string.Empty,
                                    December = getresearch.December ?? string.Empty
                                }

                            },
                            ARMHoldingCompany = new ARMHoldCoAuditUniverseReport
                            {
                                ARMHoldingCompany = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getarmholdco.BusinessManagerConcern,
                                    DirectorConcern = getarmholdco.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getarmholdco.RiskScore ?? string.Empty,
                                    RiskRating = getarmholdco.RiskRating ?? string.Empty,
                                    Recommentation = getarmholdco.Recommentation ?? string.Empty,
                                    January = getarmholdco.January ?? string.Empty,
                                    February = getarmholdco.February ?? string.Empty,
                                    March = getarmholdco.March ?? string.Empty,
                                    April = getarmholdco.April ?? string.Empty,
                                    May = getarmholdco.May ?? string.Empty,
                                    June = getarmholdco.June ?? string.Empty,
                                    July = getarmholdco.July ?? string.Empty,
                                    August = getarmholdco.August ?? string.Empty,
                                    September = getarmholdco.September ?? string.Empty,
                                    October = getarmholdco.October ?? string.Empty,
                                    November = getarmholdco.November ?? string.Empty,
                                    December = getarmholdco.December ?? string.Empty
                                },
                                TreasurySale = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getarmHoldCoTreasurySale.BusinessManagerConcern,
                                    DirectorConcern = getarmHoldCoTreasurySale.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getarmHoldCoTreasurySale.RiskScore ?? string.Empty,
                                    RiskRating = getarmHoldCoTreasurySale.RiskRating ?? string.Empty,
                                    Recommentation = getarmHoldCoTreasurySale.Recommentation ?? string.Empty,
                                    January = getarmHoldCoTreasurySale.January ?? string.Empty,
                                    February = getarmHoldCoTreasurySale.February ?? string.Empty,
                                    March = getarmHoldCoTreasurySale.March ?? string.Empty,
                                    April = getarmHoldCoTreasurySale.April ?? string.Empty,
                                    May = getarmHoldCoTreasurySale.May ?? string.Empty,
                                    June = getarmHoldCoTreasurySale.June ?? string.Empty,
                                    July = getarmHoldCoTreasurySale.July ?? string.Empty,
                                    August = getarmHoldCoTreasurySale.August ?? string.Empty,
                                    September = getarmHoldCoTreasurySale.September ?? string.Empty,
                                    October = getarmHoldCoTreasurySale.October ?? string.Empty,
                                    November = getarmHoldCoTreasurySale.November ?? string.Empty,
                                    December = getarmHoldCoTreasurySale.December ?? string.Empty
                                }
                            },
                            DigitalFinancialService = new DFSAuditUniverseReport
                            {
                                DigitalFinancialServices = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getdfsRate.BusinessManagerConcern,
                                    DirectorConcern = getdfsRate.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getdfsRate.RiskScore ?? string.Empty,
                                    RiskRating = getdfsRate.RiskRating ?? string.Empty,
                                    Recommentation = getdfsRate.Recommentation ?? string.Empty,
                                    January = getdfsRate.January ?? string.Empty,
                                    February = getdfsRate.February ?? string.Empty,
                                    March = getdfsRate.March ?? string.Empty,
                                    April = getdfsRate.April ?? string.Empty,
                                    May = getdfsRate.May ?? string.Empty,
                                    June = getdfsRate.June ?? string.Empty,
                                    July = getdfsRate.July ?? string.Empty,
                                    August = getdfsRate.August ?? string.Empty,
                                    September = getdfsRate.September ?? string.Empty,
                                    October = getdfsRate.October ?? string.Empty,
                                    November = getdfsRate.November ?? string.Empty,
                                    December = getdfsRate.December ?? string.Empty
                                }

                            },
                            ARMCapital = new ARMCapitalAuditUniverseReport
                            {
                                ARMCapital = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getcapitalRate.BusinessManagerConcern,
                                    DirectorConcern = getcapitalRate.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getcapitalRate.RiskScore ?? string.Empty,
                                    RiskRating = getcapitalRate.RiskRating ?? string.Empty,
                                    Recommentation = getcapitalRate.Recommentation ?? string.Empty,
                                    January = getcapitalRate.January ?? string.Empty,
                                    February = getcapitalRate.February ?? string.Empty,
                                    March = getcapitalRate.March ?? string.Empty,
                                    April = getcapitalRate.April ?? string.Empty,
                                    May = getcapitalRate.May ?? string.Empty,
                                    June = getcapitalRate.June ?? string.Empty,
                                    July = getcapitalRate.July ?? string.Empty,
                                    August = getcapitalRate.August ?? string.Empty,
                                    September = getcapitalRate.September ?? string.Empty,
                                    October = getcapitalRate.October ?? string.Empty,
                                    November = getcapitalRate.November ?? string.Empty,
                                    December = getcapitalRate.December ?? string.Empty
                                }
                            },

                            ARMHill = new ARMHillAuditUniverseReport
                            {
                                ARMHill = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getarmhill.BusinessManagerConcern,
                                    DirectorConcern = getarmhill.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getarmhill.RiskScore ?? string.Empty,
                                    RiskRating = getimunit.RiskRating ?? string.Empty,
                                    Recommentation = getimunit.Recommentation ?? string.Empty,
                                    January = getimunit.January ?? string.Empty,
                                    February = getimunit.February ?? string.Empty,
                                    March = getarmhill.March ?? string.Empty,
                                    April = getarmhill.April ?? string.Empty,
                                    May = getarmhill.May ?? string.Empty,
                                    June = getarmhill.June ?? string.Empty,
                                    July = getarmhill.July ?? string.Empty,
                                    August = getarmhill.August ?? string.Empty,
                                    September = getarmhill.September ?? string.Empty,
                                    October = getarmhill.October ?? string.Empty,
                                    November = getarmhill.November ?? string.Empty,
                                    December = getarmhill.December ?? string.Empty
                                }
                            },

                            ARMSecurity = new ARMSecurityAuditUniverseReport
                            {
                                StockBroking = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getstockBroking.BusinessManagerConcern,
                                    DirectorConcern = getstockBroking.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getstockBroking.RiskScore ?? string.Empty,
                                    RiskRating = getstockBroking.RiskRating ?? string.Empty,
                                    Recommentation = getstockBroking.Recommentation ?? string.Empty,
                                    January = getstockBroking.January ?? string.Empty,
                                    February = getstockBroking?.February ?? string.Empty,
                                    March = getstockBroking.March ?? string.Empty,
                                    April = getstockBroking.April ?? string.Empty,
                                    May = getstockBroking.May ?? string.Empty,
                                    June = getstockBroking.June ?? string.Empty,
                                    July = getstockBroking.July ?? string.Empty,
                                    August = getstockBroking.August ?? string.Empty,
                                    September = getstockBroking.September ?? string.Empty,
                                    October = getstockBroking.October ?? string.Empty,
                                    November = getstockBroking.November ?? string.Empty,
                                    December = getstockBroking.December ?? string.Empty
                                }
                            },

                            ARMTrustee = new ARMTrusteeAuditUniverseReport
                            {
                                CommercialTrust = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getcommercialTrust.BusinessManagerConcern,
                                    DirectorConcern = getcommercialTrust.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getcommercialTrust.RiskScore ?? string.Empty,
                                    RiskRating = getcommercialTrust.RiskRating ?? string.Empty,
                                    Recommentation = getcommercialTrust.Recommentation ?? string.Empty,
                                    January = getcommercialTrust.January ?? string.Empty,
                                    February = getcommercialTrust.February ?? string.Empty,
                                    March = getcommercialTrust.March ?? string.Empty,
                                    April = getcommercialTrust.April ?? string.Empty,
                                    May = getcommercialTrust.May ?? string.Empty,
                                    June = getcommercialTrust.June ?? string.Empty,
                                    July = getcommercialTrust.July ?? string.Empty,
                                    August = getcommercialTrust.August ?? string.Empty,
                                    September = getcommercialTrust.September ?? string.Empty,
                                    October = getcommercialTrust.October ?? string.Empty,
                                    November = getcommercialTrust.November ?? string.Empty,
                                    December = getcommercialTrust.December ?? string.Empty
                                },
                                PrivateTrust = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getprivateTrust.BusinessManagerConcern,
                                    DirectorConcern = getprivateTrust.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getprivateTrust.RiskScore ?? string.Empty,
                                    RiskRating = getprivateTrust.RiskRating ?? string.Empty,
                                    Recommentation = getprivateTrust.Recommentation ?? string.Empty,
                                    January = getprivateTrust.January ?? string.Empty,
                                    February = getprivateTrust.February ?? string.Empty,
                                    March = getprivateTrust.March ?? string.Empty,
                                    April = getprivateTrust.April ?? string.Empty,
                                    May = getprivateTrust.May ?? string.Empty,
                                    June = getprivateTrust.June ?? string.Empty,
                                    July = getprivateTrust.July ?? string.Empty,
                                    August = getprivateTrust.August ?? string.Empty,
                                    September = getprivateTrust.September ?? string.Empty,
                                    October = getprivateTrust.October ?? string.Empty,
                                    November = getprivateTrust.November ?? string.Empty,
                                    December = getprivateTrust.December ?? string.Empty
                                },

                            },

                            ARMAgribusiness = new ARMAgriAuditUniverseReport
                            {
                                RFl = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getrfl.BusinessManagerConcern,
                                    DirectorConcern = getrfl.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getrfl.RiskScore ?? string.Empty,
                                    RiskRating = getrfl.RiskRating ?? string.Empty,
                                    Recommentation = getrfl.Recommentation ?? string.Empty,
                                    January = getrfl.January ?? string.Empty,
                                    February = getrfl.February ?? string.Empty,
                                    March = getrfl.March ?? string.Empty,
                                    April = getrfl.April ?? string.Empty,
                                    May = getrfl.May ?? string.Empty,
                                    June = getrfl.June ?? string.Empty,
                                    July = getrfl.July ?? string.Empty,
                                    August = getrfl.August ?? string.Empty,
                                    September = getrfl.September ?? string.Empty,
                                    October = getrfl.October ?? string.Empty,
                                    November = getrfl.November ?? string.Empty,
                                    December = getrfl.December ?? string.Empty
                                },
                                AAFML = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getaafml.BusinessManagerConcern,
                                    DirectorConcern = getaafml.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getaafml.RiskScore ?? string.Empty,
                                    RiskRating = getaafml.RiskRating ?? string.Empty,
                                    Recommentation = getaafml.Recommentation ?? string.Empty,
                                    January = getaafml.January ?? string.Empty,
                                    February = getaafml.February ?? string.Empty,
                                    March = getaafml.March ?? string.Empty,
                                    April = getaafml.April ?? string.Empty,
                                    May = getaafml.May ?? string.Empty,
                                    June = getaafml.June ?? string.Empty,
                                    July = getaafml.July ?? string.Empty,
                                    August = getaafml.August ?? string.Empty,
                                    September = getaafml.September ?? string.Empty,
                                    October = getaafml.October ?? string.Empty,
                                    November = getaafml.November ?? string.Empty,
                                    December = getaafml.December ?? string.Empty
                                }

                            },
                            ARMSharedService = new ARMSharedAuditUniverseReport
                            {
                                HCM = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = gethcm.BusinessManagerConcern,
                                    DirectorConcern = gethcm.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = gethcm.RiskScore ?? string.Empty,
                                    RiskRating = gethcm.RiskRating ?? string.Empty,
                                    Recommentation = gethcm.Recommentation ?? string.Empty,
                                    January = gethcm.January ?? string.Empty,
                                    February = gethcm.February ?? string.Empty,
                                    March = gethcm.March ?? string.Empty,
                                    April = gethcm.April ?? string.Empty,
                                    May = gethcm.May ?? string.Empty,
                                    June = gethcm.June ?? string.Empty,
                                    July = gethcm.July ?? string.Empty,
                                    August = gethcm.August ?? string.Empty,
                                    September = gethcm.September ?? string.Empty,
                                    October = gethcm.October ?? string.Empty,
                                    November = gethcm.November ?? string.Empty,
                                    December = gethcm.December ?? string.Empty
                                },
                                IT = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getIT.BusinessManagerConcern,
                                    DirectorConcern = getIT.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getIT.RiskScore ?? string.Empty,
                                    RiskRating = getIT.RiskRating ?? string.Empty,
                                    Recommentation = getIT.Recommentation ?? string.Empty,
                                    January = getIT.January ?? string.Empty,
                                    February = getIT.February ?? string.Empty,
                                    March = getIT.March ?? string.Empty,
                                    April = getIT.April ?? string.Empty,
                                    May = getIT.May ?? string.Empty,
                                    June = getIT.June ?? string.Empty,
                                    July = getIT.July ?? string.Empty,
                                    August = getIT.August ?? string.Empty,
                                    September = getIT.September ?? string.Empty,
                                    October = getIT.October ?? string.Empty,
                                    November = getIT.November ?? string.Empty,
                                    December = getIT.December ?? string.Empty

                                },
                                CTO = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getCTO.BusinessManagerConcern,
                                    DirectorConcern = getCTO.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getCTO.RiskScore ?? string.Empty,
                                    RiskRating = getCTO.RiskRating ?? string.Empty,
                                    Recommentation = getCTO.Recommentation ?? string.Empty,
                                    January = getCTO.January ?? string.Empty,
                                    February = getCTO.February ?? string.Empty,
                                    March = getCTO.March ?? string.Empty,
                                    April = getCTO.April ?? string.Empty,
                                    May = getCTO.May ?? string.Empty,
                                    June = getCTO.June ?? string.Empty,
                                    July = getCTO.July ?? string.Empty,
                                    August = getCTO.August ?? string.Empty,
                                    September = getCTO.September ?? string.Empty,
                                    October = getCTO.October ?? string.Empty,
                                    November = getCTO.November ?? string.Empty,
                                    December = getCTO.December ?? string.Empty
                                },
                                InformationSecurity = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getinformationSecurity.BusinessManagerConcern,
                                    DirectorConcern = getinformationSecurity.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getinformationSecurity.RiskScore ?? string.Empty,
                                    RiskRating = getinformationSecurity.RiskRating ?? string.Empty,
                                    Recommentation = getinformationSecurity.Recommentation ?? string.Empty,
                                    January = getinformationSecurity.January ?? string.Empty,
                                    February = getinformationSecurity.February ?? string.Empty,
                                    March = getinformationSecurity.March ?? string.Empty,
                                    April = getinformationSecurity.April ?? string.Empty,
                                    May = getinformationSecurity.May ?? string.Empty,
                                    June = getinformationSecurity.June ?? string.Empty,
                                    July = getinformationSecurity.July ?? string.Empty,
                                    August = getinformationSecurity.August ?? string.Empty,
                                    September = getinformationSecurity.September ?? string.Empty,
                                    October = getinformationSecurity.October ?? string.Empty,
                                    November = getinformationSecurity.November ?? string.Empty,
                                    December = getinformationSecurity.December ?? string.Empty
                                },
                                Academy = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getacademy.BusinessManagerConcern,
                                    DirectorConcern = getacademy.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getacademy.RiskScore ?? string.Empty,
                                    RiskRating = getacademy.RiskRating ?? string.Empty,
                                    Recommentation = getacademy.Recommentation ?? string.Empty,
                                    January = getacademy.January ?? string.Empty,
                                    February = getacademy.February ?? string.Empty,
                                    March = getacademy.March ?? string.Empty,
                                    April = getacademy.April ?? string.Empty,
                                    May = getacademy.May ?? string.Empty,
                                    June = getacademy.June ?? string.Empty,
                                    July = getacademy.July ?? string.Empty,
                                    August = getacademy.August ?? string.Empty,
                                    September = getacademy.September ?? string.Empty,
                                    October = getacademy.October ?? string.Empty,
                                    November = getacademy.November ?? string.Empty,
                                    December = getacademy.December ?? string.Empty
                                },
                                Compliance = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getcomp.BusinessManagerConcern,
                                    DirectorConcern = getcomp.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getcomp.RiskScore ?? string.Empty,
                                    RiskRating = getcomp.RiskRating ?? string.Empty,
                                    Recommentation = getcomp.Recommentation ?? string.Empty,
                                    January = getcomp.January ?? string.Empty,
                                    February = getcomp.February ?? string.Empty,
                                    March = getcomp.March ?? string.Empty,
                                    April = getcomp.April ?? string.Empty,
                                    May = getcomp.May ?? string.Empty,
                                    June = getcomp.June ?? string.Empty,
                                    July = getcomp.July ?? string.Empty,
                                    August = getcomp.August ?? string.Empty,
                                    September = getcomp.September ?? string.Empty,
                                    October = getcomp.October ?? string.Empty,
                                    November = getcomp.November ?? string.Empty,
                                    December = getcomp.December ?? string.Empty
                                },
                                DataAnalytic = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getdataAna.BusinessManagerConcern,
                                    DirectorConcern = getdataAna.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getdataAna.RiskScore ?? string.Empty,
                                    RiskRating = getdataAna.RiskRating ?? string.Empty,
                                    Recommentation = getdataAna.Recommentation ?? string.Empty,
                                    January = getdataAna.January ?? string.Empty,
                                    February = getdataAna.February ?? string.Empty,
                                    March = getdataAna.March ?? string.Empty,
                                    April = getdataAna.April ?? string.Empty,
                                    May = getdataAna.May ?? string.Empty,
                                    June = getdataAna.June ?? string.Empty,
                                    July = getdataAna.July ?? string.Empty,
                                    August = getdataAna.August ?? string.Empty,
                                    September = getdataAna.September ?? string.Empty,
                                    October = getdataAna.October ?? string.Empty,
                                    November = getdataAna.November ?? string.Empty,
                                    December = getdataAna.December ?? string.Empty
                                },
                                ProcurementAndAdmin = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getprocurementandAdmin.BusinessManagerConcern,
                                    DirectorConcern = getprocurementandAdmin.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getprocurementandAdmin.RiskScore ?? string.Empty,
                                    RiskRating = getprocurementandAdmin.RiskRating ?? string.Empty,
                                    Recommentation = getprocurementandAdmin.Recommentation ?? string.Empty,
                                    January = getprocurementandAdmin.January ?? string.Empty,
                                    February = getprocurementandAdmin.February ?? string.Empty,
                                    March = getprocurementandAdmin.March ?? string.Empty,
                                    April = getprocurementandAdmin.April ?? string.Empty,
                                    May = getprocurementandAdmin.May ?? string.Empty,
                                    June = getprocurementandAdmin.June ?? string.Empty,
                                    July = getprocurementandAdmin.July ?? string.Empty,
                                    August = getprocurementandAdmin.August ?? string.Empty,
                                    September = getprocurementandAdmin.September ?? string.Empty,
                                    October = getprocurementandAdmin.October ?? string.Empty,
                                    November = getprocurementandAdmin.November ?? string.Empty,
                                    December = getprocurementandAdmin.December ?? string.Empty
                                },
                                Corporatestrategy = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getcorporateStrategy.BusinessManagerConcern,
                                    DirectorConcern = getcorporateStrategy.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getcorporateStrategy.RiskScore ?? string.Empty,
                                    RiskRating = getcorporateStrategy.RiskRating ?? string.Empty,
                                    Recommentation = getcorporateStrategy.Recommentation ?? string.Empty,
                                    January = getcorporateStrategy.January ?? string.Empty,
                                    February = getcorporateStrategy.February ?? string.Empty,
                                    March = getcorporateStrategy.March ?? string.Empty,
                                    April = getcorporateStrategy.April ?? string.Empty,
                                    May = getcorporateStrategy.May ?? string.Empty,
                                    June = getcorporateStrategy.June ?? string.Empty,
                                    July = getcorporateStrategy.July ?? string.Empty,
                                    August = getcorporateStrategy.August ?? string.Empty,
                                    September = getcorporateStrategy.September ?? string.Empty,
                                    October = getcorporateStrategy.October ?? string.Empty,
                                    November = getcorporateStrategy.November ?? string.Empty,
                                    December = getcorporateStrategy.December ?? string.Empty
                                },
                                CustomerExperience = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getcustomerExperience.BusinessManagerConcern,
                                    DirectorConcern = getcustomerExperience.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getcustomerExperience.RiskScore ?? string.Empty,
                                    RiskRating = getcustomerExperience.RiskRating ?? string.Empty,
                                    Recommentation = getcustomerExperience.Recommentation ?? string.Empty,
                                    January = getcustomerExperience.January ?? string.Empty,
                                    February = getcustomerExperience.February ?? string.Empty,
                                    March = getcustomerExperience.March ?? string.Empty,
                                    April = getcustomerExperience.April ?? string.Empty,
                                    May = getcustomerExperience.May ?? string.Empty,
                                    June = getcustomerExperience.June ?? string.Empty,
                                    July = getcustomerExperience.July ?? string.Empty,
                                    August = getcustomerExperience.August ?? string.Empty,
                                    September = getcustomerExperience.September ?? string.Empty,
                                    October = getcustomerExperience.October ?? string.Empty,
                                    November = getcustomerExperience.November ?? string.Empty,
                                    December = getcustomerExperience.December ?? string.Empty
                                },
                                InternalControl = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getinternalControl.BusinessManagerConcern,
                                    DirectorConcern = getinternalControl.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getinternalControl.RiskScore ?? string.Empty,
                                    RiskRating = getinternalControl.RiskRating ?? string.Empty,
                                    Recommentation = getinternalControl.Recommentation ?? string.Empty,
                                    January = getinternalControl.January ?? string.Empty,
                                    February = getinternalControl.February ?? string.Empty,
                                    March = getinternalControl.March ?? string.Empty,
                                    April = getinternalControl.April ?? string.Empty,
                                    May = getinternalControl.May ?? string.Empty,
                                    June = getinternalControl.June ?? string.Empty,
                                    July = getinternalControl.July ?? string.Empty,
                                    August = getinternalControl.August ?? string.Empty,
                                    September = getinternalControl.September ?? string.Empty,
                                    October = getinternalControl.October ?? string.Empty,
                                    November = getinternalControl.November ?? string.Empty,
                                    December = getinternalControl.December ?? string.Empty
                                },
                                Legal = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getlegal.BusinessManagerConcern,
                                    DirectorConcern = getlegal.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getlegal.RiskScore ?? string.Empty,
                                    RiskRating = getlegal.RiskRating ?? string.Empty,
                                    Recommentation = getlegal.Recommentation ?? string.Empty,
                                    January = getlegal.January ?? string.Empty,
                                    February = getlegal.February ?? string.Empty,
                                    March = getlegal.March ?? string.Empty,
                                    April = getlegal.April ?? string.Empty,
                                    May = getlegal.May ?? string.Empty,
                                    June = getlegal.June ?? string.Empty,
                                    July = getlegal.July ?? string.Empty,
                                    August = getlegal.August ?? string.Empty,
                                    September = getlegal.September ?? string.Empty,
                                    October = getlegal.October ?? string.Empty,
                                    November = getlegal.November ?? string.Empty,
                                    December = getlegal.December ?? string.Empty
                                },
                                FinancialControl = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getfinCtrl.BusinessManagerConcern,
                                    DirectorConcern = getfinCtrl.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getfinCtrl.RiskScore ?? string.Empty,
                                    RiskRating = getfinCtrl.RiskRating ?? string.Empty,
                                    Recommentation = getfinCtrl.Recommentation ?? string.Empty,
                                    January = getfinCtrl.January ?? string.Empty,
                                    February = getfinCtrl.February ?? string.Empty,
                                    March = getfinCtrl.March ?? string.Empty,
                                    April = getfinCtrl.April ?? string.Empty,
                                    May = getfinCtrl.May ?? string.Empty,
                                    June = getfinCtrl.June ?? string.Empty,
                                    July = getfinCtrl.July ?? string.Empty,
                                    August = getfinCtrl.August ?? string.Empty,
                                    September = getfinCtrl.September ?? string.Empty,
                                    October = getfinCtrl.October ?? string.Empty,
                                    November = getfinCtrl.November ?? string.Empty,
                                    December = getfinCtrl.December ?? string.Empty
                                },
                                MCC = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getMCC.BusinessManagerConcern,
                                    DirectorConcern = getMCC.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getMCC.RiskScore ?? string.Empty,
                                    RiskRating = getMCC.RiskRating ?? string.Empty,
                                    Recommentation = getMCC.Recommentation ?? string.Empty,
                                    January = getMCC.January ?? string.Empty,
                                    February = getMCC.February ?? string.Empty,
                                    March = getMCC.March ?? string.Empty,
                                    April = getMCC.April ?? string.Empty,
                                    May = getMCC.May ?? string.Empty,
                                    June = getMCC.June ?? string.Empty,
                                    July = getMCC.July ?? string.Empty,
                                    August = getMCC.August ?? string.Empty,
                                    September = getMCC.September ?? string.Empty,
                                    October = getMCC.October ?? string.Empty,
                                    November = getMCC.November ?? string.Empty,
                                    December = getMCC.December ?? string.Empty
                                },
                                RiskManagement = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = getriskManagement.BusinessManagerConcern,
                                    DirectorConcern = getriskManagement.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = getriskManagement.RiskScore ?? string.Empty,
                                    RiskRating = getriskManagement.RiskRating ?? string.Empty,
                                    Recommentation = getriskManagement.Recommentation ?? string.Empty,
                                    January = getriskManagement.January ?? string.Empty,
                                    February = getriskManagement.February ?? string.Empty,
                                    March = getriskManagement.March ?? string.Empty,
                                    April = getriskManagement.April ?? string.Empty,
                                    May = getriskManagement.May ?? string.Empty,
                                    June = getriskManagement.June ?? string.Empty,
                                    July = getriskManagement.July ?? string.Empty,
                                    August = getriskManagement.August ?? string.Empty,
                                    September = getriskManagement.September ?? string.Empty,
                                    October = getriskManagement.October ?? string.Empty,
                                    November = getriskManagement.November ?? string.Empty,
                                    December = getriskManagement.December ?? string.Empty
                                },
                                Treasury = new AuditUniverseSummaryReport
                                {
                                    BusinessManagerConcern = gettreasure.BusinessManagerConcern,
                                    DirectorConcern = gettreasure.DirectorConcern,
                                    OldRiskScore = "Low",
                                    RiskScore = gettreasure.RiskScore ?? string.Empty,
                                    RiskRating = gettreasure.RiskRating ?? string.Empty,
                                    Recommentation = gettreasure.Recommentation ?? string.Empty,
                                    January = gettreasure.January ?? string.Empty,
                                    February = gettreasure.February ?? string.Empty,
                                    March = gettreasure.March ?? string.Empty,
                                    April = gettreasure.April ?? string.Empty,
                                    May = gettreasure.May ?? string.Empty,
                                    June = gettreasure.June ?? string.Empty,
                                    July = gettreasure.July ?? string.Empty,
                                    August = gettreasure.August ?? string.Empty,
                                    September = gettreasure.September ?? string.Empty,
                                    October = gettreasure.October ?? string.Empty,
                                    November = gettreasure.November ?? string.Empty,
                                    December = gettreasure.December ?? string.Empty
                                }
                            }
                        });

                    }
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
