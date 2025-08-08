using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Office.Word;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 01/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint get emc's concern risk rating by Id or get all emc's concern risk rating
 */
    public class GetEMCConcernSummaryRatingByIdEndpoint
    {

        /// <summary>
        /// Get EMC's concern risk rating by Id or get all emc's concern risk rating
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getEmcConcern"></param>
        /// <param name="armholdco"></param>
        /// <param name="armim"></param>
        /// <param name="armsecurity"></param>
        /// <param name="armtrustee"></param>
        /// <param name="armhill"></param>
        /// <param name="armtarmagri"></param>
        /// <param name="armshareservice"></param>
        /// <param name="user"></param>   
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(Guid id, IRepository<EMCConcernRiskRating> getEmcConcern, IRepository<ARMHoldingCompanyEMCRating> armholdco, IRepository<ARMIMEMCRating> armim,
            IRepository<ARMSecurityEMCRating> armsecurity, IRepository<ARMTrusteeEMCRating> armtrustee, IRepository<ARMHILLEMCRating> armhill, IRepository<ARMAgribusinessEMCRating> armtarmagri, 
            IRepository<DigitalFinancialServiceEMCRating> dfs, IRepository<ARMCapitalEMCRating> armCapital, IRepository<ARMTAMEMCRating> tam,
            IRepository<ARMSharedServiceEMCRating> armshareservice, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var checkIfBusinesIdExist = getEmcConcern.GetContextByConditon(x => x.Id == id).FirstOrDefault();                
                
                if (checkIfBusinesIdExist == null)
                {
                    return TypedResults.NotFound();
                }

                if (id != default && checkIfBusinesIdExist != null)
                {                   
                    //  //EMC                             
                    var getEMCRating = getEmcConcern.GetContextByConditon(x => x.BusinessRiskRatingId == checkIfBusinesIdExist.BusinessRiskRatingId).ToList();
                    var holdco = new List<decimal>();
                    var treasurysale = new List<decimal>();                                       
                    var armtam = new List<decimal>();
                    var armdfs = new List<decimal>();
                    var capital = new List<decimal>();
                    var armHILL = new List<decimal>();
                    var stockBroking = new List<decimal>();
                    var commercialTrust = new List<decimal>();
                    var privateTrust = new List<decimal>();
                    var aafml = new List<decimal>();
                    var rfl = new List<decimal>();
                    var armimrate = new List<decimal>();
                    var bdOrIMRetail = new List<decimal>();
                    var fundAdmin = new List<decimal>();
                    var registerar = new List<decimal>();
                    var imUnit = new List<decimal>();
                    var fundaccount = new List<decimal>();
                    var operationControl = new List<decimal>();
                    var operationSetlement = new List<decimal>();
                    var retailOperations = new List<decimal>();
                    var research = new List<decimal>();
                    var cto = new List<decimal>();
                    var it = new List<decimal>();
                    var mcc = new List<decimal>();
                    var hcm = new List<decimal>();
                    var procurementAndAdmin = new List<decimal>();
                    var academy = new List<decimal>();
                    var corporateStrategy = new List<decimal>();
                    var legal = new List<decimal>();
                    var customerExperience = new List<decimal>();
                    var infoSecurity = new List<decimal>();
                    var internalControl = new List<decimal>();
                    var riskManagement = new List<decimal>();
                    var treasury = new List<decimal>();
                    var financialControl = new List<decimal>();
                    var compliance = new List<decimal>();
                    var dataAnalytic = new List<decimal>();

                    foreach (var item1 in getEMCRating)
                    {
                        //holdco
                        var getARMHoldco = armholdco.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMHoldingCompany).ToList();
                        holdco.AddRange(getARMHoldco);
                        var getTreasurysale = armholdco.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.TreasurySales).ToList();
                        treasurysale.AddRange(getTreasurysale);

                        //Tam
                        var getarmtam = tam.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMTAM).ToList();
                        armtam.AddRange(getarmtam);

                        //arm Capital
                        var getCapital = armCapital.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMCapital).ToList();
                        capital.AddRange(getCapital);

                        //hill
                        var getarmHILL = armhill.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMHILL).ToList();
                        armHILL.AddRange(getarmHILL);

                        //dfs
                        var getDFS = dfs.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.DigitalFinancialService).ToList();
                        armdfs.AddRange(getDFS);

                        //security
                        var getStockBroking = armsecurity.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.StockBroking).ToList();
                        stockBroking.AddRange(getStockBroking);

                        //Trustee
                        var getcommercialTrust = armtrustee.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.CommercialTrust).ToList();
                        commercialTrust.AddRange(getcommercialTrust);

                        var gePrivateTrust = armtrustee.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.PrivateTrust).ToList();
                        privateTrust.AddRange(gePrivateTrust);

                        //Agri
                        var getAAFML = armtarmagri.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.AAFML).ToList();
                        aafml.AddRange(getAAFML);
                        var getRFL = armtarmagri.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.RFL).ToList();
                        rfl.AddRange(getRFL);

                        //armIM
                        var getarmimrate = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMIM).ToList();
                        armimrate.AddRange(getarmimrate);
                        var getBD = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.BDOrIMRetail).ToList();
                        bdOrIMRetail.AddRange(getBD);
                        var getfundAdmin = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.FundAdmin).ToList();
                        fundAdmin.AddRange(getfundAdmin);
                        var getregisterar = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMRegisterar).ToList();
                        registerar.AddRange(getregisterar);
                        var getimUnit = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.IMUnit).ToList();
                        imUnit.AddRange(getimUnit);
                        var getfundaccount = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Fundaccount).ToList();
                        fundaccount.AddRange(getfundaccount);
                        var getoperationControl = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.OperationControl).ToList();
                        operationControl.AddRange(getoperationControl);
                        var getoperationSetlement = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.OperationSetlement).ToList();
                        operationSetlement.AddRange(getoperationSetlement);
                        var getretailOperations = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.RetailOperations).ToList();
                        retailOperations.AddRange(getretailOperations);
                        var getrecordResearch = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Research).ToList();
                        research.AddRange(getrecordResearch);

                        //sharedservice
                        var getCTO = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.CTO).ToList();
                        cto.AddRange(getCTO);
                        var getIT = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.IT).ToList();
                        it.AddRange(getIT);
                        var getMCC = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.MCC).ToList();
                        mcc.AddRange(getMCC);
                        var getLegal = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Legal).ToList();
                        legal.AddRange(getLegal);
                        var getprocurementAndAdmin = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ProcurementAndAdmin).ToList();
                        procurementAndAdmin.AddRange(getprocurementAndAdmin);
                        var getacademy = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Academy).ToList();
                        academy.AddRange(getacademy);
                        var getcorporateStrategy = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.CorporateStrategy).ToList();
                        corporateStrategy.AddRange(getcorporateStrategy);
                        var gethcm = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.HCM).ToList();
                        hcm.AddRange(gethcm);
                        var getcustomerExperience = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.CustomerExperience).ToList();
                        customerExperience.AddRange(getcustomerExperience);
                        var getinfoSecurity = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.InfoSecurity).ToList();
                        infoSecurity.AddRange(getinfoSecurity);
                        var getinternalControl = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.InternalControl).ToList();
                        internalControl.AddRange(getinternalControl);
                        var getriskManagement = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.RiskManagement).ToList();
                        riskManagement.AddRange(getriskManagement);
                        var gettreasury = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Treasury).ToList();
                        treasury.AddRange(gettreasury);
                        var getfinancialControl = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.FinancialControl).ToList();
                        financialControl.AddRange(getfinancialControl);
                        var getcompliance = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.Compliance).ToList();
                        compliance.AddRange(getcompliance);
                        var getdataAnalytic = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.DataAnalytic).ToList();
                        dataAnalytic.AddRange(getdataAnalytic);


                    }
                    // Calculate the sum and average for the first three records

                    var recordARMHoldco = holdco.ToList();
                    var recordTresurySale = treasurysale.ToList();
                    var recordTAM = armtam.ToList();
                    var recordDFS = armdfs.ToList();
                    var recordCapital = capital.ToList();
                    var recordARMHILL = armHILL.ToList();
                    var recordStockBroking = stockBroking.ToList();
                    var recordCommercialTrust = commercialTrust.ToList();
                    var recordPrivateTrust = privateTrust.ToList();
                    var recordAAFML = aafml.ToList();
                    var recordRFL = rfl.ToList();
                    var recordARMIM = armimrate.ToList();
                    var recordBDOrIMRetail = bdOrIMRetail.ToList();
                    var recordFundAdmin = fundAdmin.ToList();
                    var recordARMRegisterar = registerar.ToList();
                    var recordIMUnit = imUnit.ToList();
                    var recordFundaccount = fundaccount.ToList();
                    var recordOperationControl = operationControl.ToList();
                    var recordOperationSetlement = operationSetlement.ToList();
                    var recordRetailOperations = retailOperations.ToList();
                    var recordResearch = research.ToList();
                    var recordIT = it.ToList();
                    var recordAcademy = academy.ToList();
                    var recordProcurementAndAdmin = procurementAndAdmin.ToList();
                    var recordLegal = legal.ToList();
                    var recordMCC = mcc.ToList();
                    var recordHCM = hcm.ToList();
                    var recordCorporateStrategy = corporateStrategy.ToList();
                    var recordCTO = cto.ToList();
                    var recordCustomerExperience = customerExperience.ToList();
                    var recordInfoSecurity = infoSecurity.ToList();
                    var recordInternalControl = internalControl.ToList();
                    var recordRiskManagement = riskManagement.ToList();
                    var recordTreasury = treasury.ToList();
                    var recordFinancialControl = financialControl.ToList();
                    var recordCompliance = compliance.ToList();
                    var recordDataAnalytic = dataAnalytic.ToList();
                  
                    //decimal sumRFL = recordRFL.Sum();
                    
                    decimal averageOperationControl = recordOperationControl.Any() ? recordOperationControl.Average() : 0;
                    decimal averageOperationSetlement = recordOperationSetlement.Any() ? recordOperationSetlement.Average() : 0;
                    decimal averageRetailOperations = recordRetailOperations.Any() ? recordRetailOperations.Average() : 0;
                    decimal averageResearch = recordResearch.Any() ? recordResearch.Average() : 0;
                    decimal averagARMHoldco = recordARMHoldco.Any() ? recordARMHoldco.Average() : 0;
                    decimal averageTreasurySale = recordTresurySale.Any() ? recordTresurySale.Average() : 0;
                    decimal averageTam = recordTresurySale.Any() ? recordTresurySale.Average() : 0;
                    decimal averageTAM = recordTAM.Any() ? recordTAM.Average() : 0;
                    decimal averageDFS = recordDFS.Any() ? recordDFS.Average() : 0;
                    decimal averageCapital = recordCapital.Any() ? recordCapital.Average() : 0;
                    decimal averageARMHILL = recordARMHILL.Any() ? recordARMHILL.Average() : 0;
                    decimal averageStockBroking = recordStockBroking.Any() ? recordStockBroking.Average() : 0;
                    decimal averageCommercialTrust = recordCommercialTrust.Any() ? recordCommercialTrust.Average() : 0;
                    decimal averagePrivateTrust = recordPrivateTrust.Any() ? recordPrivateTrust.Average() : 0;
                    decimal averageAAFML = recordAAFML.Any() ? recordAAFML.Average() : 0;
                    decimal averageRFL = recordRFL.Any() ? recordRFL.Average() : 0;
                    decimal averageARMIM = recordARMIM.Any() ? recordARMIM.Average() : 0;
                    decimal averageBDOrIMRetail = recordBDOrIMRetail.Any() ? recordBDOrIMRetail.Average() : 0;
                    decimal averageFundAdmin = recordFundAdmin.Any() ? recordFundAdmin.Average() : 0;
                    decimal averageARMRegisterar = recordARMRegisterar.Any() ? recordARMRegisterar.Average() : 0;
                    decimal averageIMUnit = recordIMUnit.Any() ? recordIMUnit.Average() : 0;
                    decimal averageFundaccount = recordFundaccount.Any() ? recordFundaccount.Average() : 0;
                    decimal averageHCM = recordHCM.Any() ? recordHCM.Average() : 0;
                    decimal averageCorporateStrategy = recordCorporateStrategy.Any() ? recordCorporateStrategy.Average() : 0;
                    decimal averageCTO = recordCTO.Any() ? recordCTO.Average() : 0;
                    decimal averageIT = recordIT.Any() ? recordIT.Average() : 0;
                    decimal averageAcademy = recordAcademy.Any() ? recordAcademy.Average() : 0;
                    decimal averageProcurementAndAdmin = recordProcurementAndAdmin.Any() ? recordProcurementAndAdmin.Average() : 0;
                    decimal averageLegal = recordLegal.Any() ? recordLegal.Average() : 0;
                    decimal averageMCC = recordMCC.Any() ? recordMCC.Average() : 0;
                    decimal averageInfoSecurity = recordInfoSecurity.Any() ? recordInfoSecurity.Average() : 0;
                    decimal averageCustomerExperience = recordCustomerExperience.Any() ? recordCustomerExperience.Average() : 0;
                    decimal averageInternalControl = recordInternalControl.Any() ? recordInternalControl.Average() : 0;
                    decimal averageRiskManagement = recordRiskManagement.Any() ? recordRiskManagement.Average() : 0;
                    decimal averageTreasury = recordTreasury.Any() ? recordTreasury.Average() : 0;
                    decimal averageFinancialControl = recordFinancialControl.Any() ? recordFinancialControl.Average() : 0;
                    decimal averageCompliance = recordCompliance.Any() ? recordCompliance.Average() : 0;
                    decimal averageDataAnalytic = recordDataAnalytic.Any() ? recordDataAnalytic.Average() : 0;

                    GetEmcConcernRatingResp resp = new GetEmcConcernRatingResp
                    {
                        Id = id,
                        ARMHoldingCompany = new ARMHoldingCompanyResponse
                        {
                            ARMHoldingCompany = averagARMHoldco, 
                            TreasurySales = averageTreasurySale
                        },
                        ARMTAM = new EMCARMTAMResponse
                        {
                            ARMTAM = averageTAM
                        },
                        DigitalFinancialService = new EMCDigitalFinancialServiceResponse
                        {
                            DigitalFinancialService = averageDFS
                        },
                        ARMCapital = new EMCARMCapitalResponse
                        {
                            ARMCapital = averageCapital
                        },
                        ARMIM = new ARMIMResponse
                        {
                            ARMIM = averageARMIM,
                            ARMRegisterar = averageARMRegisterar,
                            FundAdmin = averageFundAdmin,
                            IMUnit = averageIMUnit,
                            BDOrIMRetail = averageBDOrIMRetail,
                            Fundaccount = averageFundaccount,
                            OperationControl = averageOperationControl,
                            OperationSetlement = averageOperationSetlement,
                            RetailOperations = averageRetailOperations,
                            Research = averageResearch,
                        },
                        ARMHILL = new ARMHILLResponse
                        {
                            ARMHILL = averageARMHILL
                        },
                        ARMTrustee = new ARMTrusteeResponse
                        {
                            CommercialTrust = averageCommercialTrust,
                            PrivateTrust = averagePrivateTrust
                        },
                        ARMSecurity = new ARMSecurityResponse
                        {
                            StockBroking = averageStockBroking,
                        },
                        ARMAgribusiness = new ARMAgribusinessResponse
                        {
                            AAFML = averageAAFML,
                            RFL = averageRFL
                        },
                        ARMSharedService = new ARMSharedServiceResponse
                        {
                            HCM = averageHCM,
                            CorporateStrategy = averageCorporateStrategy,
                            CTO = averageCTO,
                            IT = averageIT,
                            Academy = averageAcademy,
                            ProcurementAndAdmin = averageProcurementAndAdmin,
                            Legal = averageLegal,
                            MCC = averageMCC,
                            CustomerExperience = averageCustomerExperience,
                            InfoSecurity = averageInfoSecurity,
                            InternalControl = averageInternalControl,
                            RiskManagement = averageRiskManagement,
                            Treasury = averageTreasury,
                            FinancialControl = averageFinancialControl,
                            Compliance = averageCompliance,
                            DataAnalytic = averageDataAnalytic
                        },
                        Comment = checkIfBusinesIdExist.Comment
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
