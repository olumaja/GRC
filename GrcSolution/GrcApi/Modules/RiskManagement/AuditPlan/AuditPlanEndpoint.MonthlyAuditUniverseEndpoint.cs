using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 27/02/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint allow Monthly Audit Universe on the subsidiary
*/
    public class MonthlyAuditUniverseEndpoint
    {
        /// <summary>
        /// Monthly audit universe 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="annualaudit"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="agrireq"></param>
        /// <param name="aafml"></param>
        /// <param name="rfl"></param>
        /// <param name="armholdcoauditUniverse"></param>
        /// <param name="armholdco"></param>
        /// <param name="armHoldCoTreasurySale"></param>
        /// <param name="armimauditUniverse"></param>
        /// <param name="armIm"></param>
        /// <param name="imunit"></param>
        /// <param name="operationControl"></param>
        /// <param name="fundAdmin"></param>
        /// <param name="registrar"></param>
        /// <param name="bDPWMIAMIMRetail"></param>
        /// <param name="operationSettlement"></param>
        /// <param name="retailOperation"></param>
        /// <param name="fundAccount"></param>
        /// <param name="armtamReq"></param>
        /// <param name="armtam"></param>
        /// <param name="armsecreq"></param>
        /// <param name="research"></param>
        /// <param name="stockBroking"></param>
        /// <param name="InvestmentBanking"></param>
        /// <param name="armtrusteereq"></param>
        /// <param name="privateTrust"></param>
        /// <param name="commercialTrust"></param>
        /// <param name="armhillreq"></param>
        /// <param name="armhill"></param>
        /// <param name="dfsAuditUniverse"></param>
        /// <param name="dfsRate"></param>
        /// <param name="req"></param>
        /// <param name="hcm"></param>
        /// <param name="procurementandAdmin"></param>
        /// <param name="academy"></param>
        /// <param name="legal"></param>
        /// <param name="finCtrl"></param>
        /// <param name="riskManagement"></param>
        /// <param name="mcc"></param>
        /// <param name="internalControl"></param>
        /// <param name="treasury"></param>
        /// <param name="CTO"></param>
        /// <param name="it"></param>
        /// <param name="customerExperience"></param>
        /// <param name="infoSec"></param>
        /// <param name="corporateStrategy"></param>
        /// <param name="currentUserService"></param>
        /// <param name="dataAna"></param>
        /// <param name="compl"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] MonthlyAuditUniverseReq request, IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<BusinessRiskRating> busnessRiskRating,
            //agri            
            IRepository<ARMAgribusinessAuditUniverse> agrireq, IRepository<AuditUniverseARMAgribusinessAAFML> aafml, IRepository<AuditUniverseARMAgribusinessRFL> rfl,
            //holdco
            IRepository<ARMHoldingCompanyAnnualAuditUniverse> armholdcoauditUniverse, IRepository<AuditUniverseARMHoldingCompany> armholdco,
            IRepository<AuditUniverseARMHoldCoTreasurySale> armHoldCoTreasurySale,
            //im
            IRepository<ARMIMAuditUniverse> armimauditUniverse, IRepository<AuditUniverseARMIMIMUnit> imunit,
            IRepository<AuditUniverseARMIMOperationControl> operationControl, IRepository<AuditUniverseARMIMFundAdmin> fundAdmin,
            IRepository<AuditUniverseARMIMRegistrar> registrar, IRepository<AuditUniverseARMIMBDPWMIAMIMRetail> bDPWMIAMIMRetail,
            IRepository<AuditUniverseARMIMOperationSettlement> operationSettlement, IRepository<AuditUniverseARMIMResearch> research,
            IRepository<AuditUniverseARMIMRetailOperation> retailOperation, IRepository<AuditUniverseARMIMFundAccount> fundAccount,

            //security
            IRepository<ARMSecurityAnnualAuditUniverse> armsecreq, IRepository<AuditUniverseARMSecurityStockBroking> stockBroking, 

            //trustee
            IRepository<ARMTrusteeAuditUniverse> armtrusteereq, IRepository<AuditUniverseARMTrusteePrivateTrust> privateTrust,
            IRepository<AuditUniverseARMTrusteeCommercialTrust> commercialTrust,

            //hill
            IRepository<ARMHillAuditUniverse> armhillreq, IRepository<AuditUniverseARMHill> armhill,

             //DFS
             IRepository<DigitalFinancialServiceAuditUniverse> dfsAuditUniverse, IRepository<AuditUniverseDigitalFinancialServiceRating> dfsRate,

             //ARMCapital
             IRepository<ARMCapitalAuditUniverse> armCapitalAuditUniverse, IRepository<AuditUniverseARMCapitalRating> armCapitalRate,

            //shareservice
            IRepository<ARMSharedAuditUniverse> req, IRepository<ARMSharedAuditUniverseHCM> hcm, IRepository<ARMSharedAuditUniverseProcurementAndAdmin> procurementandAdmin,
            IRepository<ARMSharedAuditUniverseAcademy> academy, IRepository<ARMSharedAuditUniverseLegal> legal, IRepository<ARMSharedAuditUniverseFinancialControl> finCtrl,
            IRepository<ARMSharedAuditUniverseRiskManagement> riskManagement, IRepository<ARMSharedAuditUniverseMCC> mcc, IRepository<ARMSharedAuditUniverseInternalControl> internalControl,
            IRepository<ARMSharedAuditUniverseTreasury> treasury, IRepository<ARMSharedAuditUniverseCTO> CTO, IRepository<ARMSharedAuditUniverseIT> it,
            IRepository<ARMSharedAuditUniverseCustomerExperience> customerExperience, IRepository<ARMSharedAuditUniverseInformationSecurity> infoSec,
            IRepository<ARMSharedAuditUniverseCorporatestrategy> corporateStrategy, ICurrentUserService currentUserService,
            IRepository<ARMSharedAuditUniverseDataAnalytic> dataAna, IRepository<ARMSharedAuditUniverseCompliance> compl,

            ClaimsPrincipal user)
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
                var getbusnessRiskRating = busnessRiskRating.GetContextByConditon(x => x.Id == request.BusinessRiskRatingId).FirstOrDefault();
                if (getbusnessRiskRating == null)
                {
                    return TypedResults.NotFound($"The Business Risk Rating Id '{request.BusinessRiskRatingId}' was not found");

                }               
                var auditUniverse = await annualaudit.GetAllAsync();
                var getaudit = auditUniverse.Find(x => x.BusinessRiskRatingId.Equals(request.BusinessRiskRatingId));
                if (getaudit != null)
                {
                    getaudit.Update(getbusnessRiskRating.RequesterName);

                    #region ARMholdCo
                    var checkIfItHasBeenRated = armholdcoauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id).FirstOrDefault();
                    checkIfItHasBeenRated.Update(getbusnessRiskRating.RequesterName);

                    var updatearmholdco = armholdco.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
                    updatearmholdco.UpdateMonth(request.ARMHoldingCompany.ArmHoldingcompany.January, request.ARMHoldingCompany.ArmHoldingcompany.February, request.ARMHoldingCompany.ArmHoldingcompany.March, request.ARMHoldingCompany.ArmHoldingcompany.April, request.ARMHoldingCompany.ArmHoldingcompany.May, request.ARMHoldingCompany.ArmHoldingcompany.June, request.ARMHoldingCompany.ArmHoldingcompany.July, request.ARMHoldingCompany.ArmHoldingcompany.August, request.ARMHoldingCompany.ArmHoldingcompany.September, request.ARMHoldingCompany.ArmHoldingcompany.October, request.ARMHoldingCompany.ArmHoldingcompany.November, request.ARMHoldingCompany.ArmHoldingcompany.December);

                    var updateTreasurySale = armHoldCoTreasurySale.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
                    updateTreasurySale.UpdateMonth(request.ARMHoldingCompany.TreasurySale.January, request.ARMHoldingCompany.TreasurySale.February, request.ARMHoldingCompany.TreasurySale.March, request.ARMHoldingCompany.TreasurySale.April, request.ARMHoldingCompany.TreasurySale.May, request.ARMHoldingCompany.TreasurySale.June, request.ARMHoldingCompany.TreasurySale.July, request.ARMHoldingCompany.TreasurySale.August, request.ARMHoldingCompany.TreasurySale.September, request.ARMHoldingCompany.TreasurySale.October, request.ARMHoldingCompany.TreasurySale.November, request.ARMHoldingCompany.TreasurySale.December);

                    #endregion

                    #region DigitalFinancialService
                    var checkdfsAuditUniversereq = dfsAuditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkdfsAuditUniversereq.Update(getbusnessRiskRating.RequesterName);

                    var updatedfsRate = dfsRate.GetContextByConditon(x => x.DigitalFinancialServiceAuditUniverseId == checkdfsAuditUniversereq.Id).FirstOrDefault();
                    updatedfsRate.UpdateMonth(request.DigitalFinancialService.DigitalFinancialService.January, request.DigitalFinancialService.DigitalFinancialService.February, request.DigitalFinancialService.DigitalFinancialService.March, request.DigitalFinancialService.DigitalFinancialService.April, request.DigitalFinancialService.DigitalFinancialService.May, request.DigitalFinancialService.DigitalFinancialService.June, request.DigitalFinancialService.DigitalFinancialService.July, request.DigitalFinancialService.DigitalFinancialService.August, request.DigitalFinancialService.DigitalFinancialService.September, request.DigitalFinancialService.DigitalFinancialService.October, request.DigitalFinancialService.DigitalFinancialService.November, request.DigitalFinancialService.DigitalFinancialService.December);

                    dfsRate.SaveChanges();
                    #endregion

                    #region ARMCapital
                    var checkARMCapitalAuditUniversereq = armCapitalAuditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkARMCapitalAuditUniversereq.Update(getbusnessRiskRating.RequesterName);

                    var updateARMCapitalRate = armCapitalRate.GetContextByConditon(x => x.ARMCapitalAuditUniverseId == checkARMCapitalAuditUniversereq.Id).FirstOrDefault();
                    updateARMCapitalRate.UpdateMonth(request.ARMCapital.ARMCapital.January, request.ARMCapital.ARMCapital.February, request.ARMCapital.ARMCapital.March, request.ARMCapital.ARMCapital.April, request.ARMCapital.ARMCapital.May, request.ARMCapital.ARMCapital.June, request.ARMCapital.ARMCapital.July, request.ARMCapital.ARMCapital.August, request.ARMCapital.ARMCapital.September, request.ARMCapital.ARMCapital.October, request.ARMCapital.ARMCapital.November, request.ARMCapital.ARMCapital.December);

                    armCapitalRate.SaveChanges();
                    #endregion

                    #region ARMIM
                    var checkIarmim = armimauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id).FirstOrDefault();
                    checkIarmim.Update(getbusnessRiskRating.RequesterName);

                    var updateimunit = imunit.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateimunit.UpdateMonth(request.ARMIM.IMUnit.January, request.ARMIM.IMUnit.February, request.ARMIM.IMUnit.March, request.ARMIM.IMUnit.April, request.ARMIM.IMUnit.May, request.ARMIM.IMUnit.June, request.ARMIM.IMUnit.July, request.ARMIM.IMUnit.August, request.ARMIM.IMUnit.September, request.ARMIM.IMUnit.October, request.ARMIM.IMUnit.November, request.ARMIM.IMUnit.December);

                    var updateoperationControl = operationControl.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateoperationControl.UpdateMonth(request.ARMIM.OperationControl.January, request.ARMIM.OperationControl.February, request.ARMIM.OperationControl.March, request.ARMIM.OperationControl.April, request.ARMIM.OperationControl.May, request.ARMIM.OperationControl.June, request.ARMIM.OperationControl.July, request.ARMIM.OperationControl.August, request.ARMIM.OperationControl.September, request.ARMIM.OperationControl.October, request.ARMIM.OperationControl.November, request.ARMIM.OperationControl.December);

                    var updatefundAdmin = fundAdmin.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updatefundAdmin.UpdateMonth(request.ARMIM.FundAdmin.January, request.ARMIM.FundAdmin.February, request.ARMIM.FundAdmin.March, request.ARMIM.FundAdmin.April, request.ARMIM.FundAdmin.May, request.ARMIM.FundAdmin.June, request.ARMIM.FundAdmin.July, request.ARMIM.FundAdmin.August, request.ARMIM.FundAdmin.September, request.ARMIM.FundAdmin.October, request.ARMIM.FundAdmin.November, request.ARMIM.FundAdmin.December);

                    var updateregistrar = registrar.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateregistrar.UpdateMonth(request.ARMIM.Registrar.January, request.ARMIM.Registrar.February, request.ARMIM.Registrar.March, request.ARMIM.Registrar.April, request.ARMIM.Registrar.May, request.ARMIM.Registrar.June, request.ARMIM.Registrar.July, request.ARMIM.Registrar.August, request.ARMIM.Registrar.September, request.ARMIM.Registrar.October, request.ARMIM.Registrar.November, request.ARMIM.Registrar.December);

                    var updatebDPWMIAMIMRetail = bDPWMIAMIMRetail.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updatebDPWMIAMIMRetail.UpdateMonth(request.ARMIM.BDPWMIAMIMRetail.January, request.ARMIM.BDPWMIAMIMRetail.February, request.ARMIM.BDPWMIAMIMRetail.March, request.ARMIM.BDPWMIAMIMRetail.April, request.ARMIM.BDPWMIAMIMRetail.May, request.ARMIM.BDPWMIAMIMRetail.June, request.ARMIM.BDPWMIAMIMRetail.July, request.ARMIM.BDPWMIAMIMRetail.August, request.ARMIM.BDPWMIAMIMRetail.September, request.ARMIM.BDPWMIAMIMRetail.October, request.ARMIM.BDPWMIAMIMRetail.November, request.ARMIM.BDPWMIAMIMRetail.December);

                    var updateoperationSettlement = operationSettlement.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateoperationSettlement.UpdateMonth(request.ARMIM.OperationSettlement.January, request.ARMIM.OperationSettlement.February, request.ARMIM.OperationSettlement.March, request.ARMIM.OperationSettlement.April, request.ARMIM.OperationSettlement.May, request.ARMIM.OperationSettlement.June, request.ARMIM.OperationSettlement.July, request.ARMIM.OperationSettlement.August, request.ARMIM.OperationSettlement.September, request.ARMIM.OperationSettlement.October, request.ARMIM.OperationSettlement.November, request.ARMIM.OperationSettlement.December);

                    var updateretailOperation = retailOperation.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateretailOperation.UpdateMonth(request.ARMIM.RetailOperation.January, request.ARMIM.RetailOperation.February, request.ARMIM.RetailOperation.March, request.ARMIM.RetailOperation.April, request.ARMIM.RetailOperation.May, request.ARMIM.RetailOperation.June, request.ARMIM.RetailOperation.July, request.ARMIM.RetailOperation.August, request.ARMIM.RetailOperation.September, request.ARMIM.RetailOperation.October, request.ARMIM.RetailOperation.November, request.ARMIM.RetailOperation.December);

                    var uopdateresearch = research.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    uopdateresearch.UpdateMonth(request.ARMIM.Research.January, request.ARMIM.Research.February, request.ARMIM.Research.March, request.ARMIM.Research.April, request.ARMIM.Research.May, request.ARMIM.Research.June, request.ARMIM.Research.July, request.ARMIM.Research.August, request.ARMIM.Research.September, request.ARMIM.Research.October, request.ARMIM.Research.November, request.ARMIM.Research.December);

                    var updatefundAccount = fundAccount.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updatefundAccount.UpdateMonth(request.ARMIM.FundAccount.January, request.ARMIM.FundAccount.February, request.ARMIM.FundAccount.March, request.ARMIM.FundAccount.April, request.ARMIM.FundAccount.May, request.ARMIM.FundAccount.June, request.ARMIM.FundAccount.July, request.ARMIM.FundAccount.August, request.ARMIM.FundAccount.September, request.ARMIM.FundAccount.October, request.ARMIM.FundAccount.November, request.ARMIM.FundAccount.December);
                    fundAccount.SaveChanges();
                    #endregion 

                    #region ARMSecurity
                    var checkarmsecreq = armsecreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id).FirstOrDefault();
                    checkarmsecreq.Update(getbusnessRiskRating.RequesterName);

                    var updateStockBroking = stockBroking.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkarmsecreq.Id).FirstOrDefault();
                    updateStockBroking.UpdateMonth(request.ARMSecurity.StockBroking.January, request.ARMSecurity.StockBroking.February, request.ARMSecurity.StockBroking.March, request.ARMSecurity.StockBroking.April, request.ARMSecurity.StockBroking.May, request.ARMSecurity.StockBroking.June, request.ARMSecurity.StockBroking.July, request.ARMSecurity.StockBroking.August, request.ARMSecurity.StockBroking.September, request.ARMSecurity.StockBroking.October, request.ARMSecurity.StockBroking.November, request.ARMSecurity.StockBroking.December);

                    stockBroking.SaveChanges();
                    #endregion

                    #region ARMTrustee
                    var checkarmtrusteereq = armtrusteereq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id).FirstOrDefault();
                    checkarmtrusteereq.Update(getbusnessRiskRating.RequesterName);

                    var updateprivateTrust = privateTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkarmtrusteereq.Id).FirstOrDefault();
                    updateprivateTrust.UpdateMonth(request.ARMTrustee.PrivateTrust.January, request.ARMTrustee.PrivateTrust.February, request.ARMTrustee.PrivateTrust.March, request.ARMTrustee.PrivateTrust.April, request.ARMTrustee.PrivateTrust.May, request.ARMTrustee.PrivateTrust.June, request.ARMTrustee.PrivateTrust.July, request.ARMTrustee.PrivateTrust.August, request.ARMTrustee.PrivateTrust.September, request.ARMTrustee.PrivateTrust.October, request.ARMTrustee.PrivateTrust.November, request.ARMTrustee.PrivateTrust.December);

                    var updatecommercialTrust = commercialTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkarmtrusteereq.Id).FirstOrDefault();
                    updatecommercialTrust.UpdateMonth(request.ARMTrustee.CommercialTrust.January, request.ARMTrustee.CommercialTrust.February, request.ARMTrustee.CommercialTrust.March, request.ARMTrustee.CommercialTrust.April, request.ARMTrustee.CommercialTrust.May, request.ARMTrustee.CommercialTrust.June, request.ARMTrustee.CommercialTrust.July, request.ARMTrustee.CommercialTrust.August, request.ARMTrustee.CommercialTrust.September, request.ARMTrustee.CommercialTrust.October, request.ARMTrustee.CommercialTrust.November, request.ARMTrustee.CommercialTrust.December);

                    commercialTrust.SaveChanges();
                    #endregion

                    #region ARMAgribusiness
                    var checkagrireq = agrireq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id).FirstOrDefault();
                    checkagrireq.Update(getbusnessRiskRating.RequesterName);

                    var updateaafml = aafml.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkagrireq.Id).FirstOrDefault();
                    updateaafml.UpdateMonth(request.ARMAgribusiness.AAFML.January, request.ARMAgribusiness.AAFML.February, request.ARMAgribusiness.AAFML.March, request.ARMAgribusiness.AAFML.April, request.ARMAgribusiness.AAFML.May, request.ARMAgribusiness.AAFML.June, request.ARMAgribusiness.AAFML.July, request.ARMAgribusiness.AAFML.August, request.ARMAgribusiness.AAFML.September, request.ARMAgribusiness.AAFML.October, request.ARMAgribusiness.AAFML.November, request.ARMAgribusiness.AAFML.December);

                    var updaterfl = rfl.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkagrireq.Id).FirstOrDefault();
                    updaterfl.UpdateMonth(request.ARMAgribusiness.RFL.January, request.ARMAgribusiness.RFL.February, request.ARMAgribusiness.RFL.March, request.ARMAgribusiness.RFL.April, request.ARMAgribusiness.RFL.May, request.ARMAgribusiness.RFL.June, request.ARMAgribusiness.RFL.July, request.ARMAgribusiness.RFL.August, request.ARMAgribusiness.RFL.September, request.ARMAgribusiness.RFL.October, request.ARMAgribusiness.RFL.November, request.ARMAgribusiness.RFL.December);

                    rfl.SaveChanges();
                    #endregion

                    #region ARMHill
                    var checkarmhillreq = armhillreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id).FirstOrDefault();
                    checkarmhillreq.Update(getbusnessRiskRating.RequesterName);

                    var updatearmhill = armhill.GetContextByConditon(x => x.ARMHillAuditUniverseId == checkarmhillreq.Id).FirstOrDefault();
                    updatearmhill.UpdateMonth(request.ARMHill.ARMHill.January, request.ARMHill.ARMHill.February, request.ARMHill.ARMHill.March, request.ARMHill.ARMHill.April, request.ARMHill.ARMHill.May, request.ARMHill.ARMHill.June, request.ARMHill.ARMHill.July, request.ARMHill.ARMHill.August, request.ARMHill.ARMHill.September, request.ARMHill.ARMHill.October, request.ARMHill.ARMHill.November, request.ARMHill.ARMHill.December);

                    armhill.SaveChanges();
                    #endregion

                    #region ARMSharedService
                    var checkSharedReq = req.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id).FirstOrDefault();
                    checkSharedReq.Update(getbusnessRiskRating.RequesterName);

                    var updatedataAna = dataAna.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatedataAna.UpdateMonth(request.ARMSharedService.DataAnalytic.January, request.ARMSharedService.DataAnalytic.February, request.ARMSharedService.DataAnalytic.March, request.ARMSharedService.DataAnalytic.April, request.ARMSharedService.DataAnalytic.May, request.ARMSharedService.DataAnalytic.June, request.ARMSharedService.DataAnalytic.July, request.ARMSharedService.DataAnalytic.August, request.ARMSharedService.DataAnalytic.September, request.ARMSharedService.DataAnalytic.October, request.ARMSharedService.DataAnalytic.November, request.ARMSharedService.DataAnalytic.December);

                    var updatefinCtrl = finCtrl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatefinCtrl.UpdateMonth(request.ARMSharedService.FinancialControl.January, request.ARMSharedService.FinancialControl.February, request.ARMSharedService.FinancialControl.March, request.ARMSharedService.FinancialControl.April, request.ARMSharedService.FinancialControl.May, request.ARMSharedService.FinancialControl.June, request.ARMSharedService.FinancialControl.July, request.ARMSharedService.FinancialControl.August, request.ARMSharedService.FinancialControl.September, request.ARMSharedService.FinancialControl.October, request.ARMSharedService.FinancialControl.November, request.ARMSharedService.FinancialControl.December);

                    var updatehcm = hcm.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatehcm.UpdateMonth(request.ARMSharedService.HCM.January, request.ARMSharedService.HCM.February, request.ARMSharedService.HCM.March, request.ARMSharedService.HCM.April, request.ARMSharedService.HCM.May, request.ARMSharedService.HCM.June, request.ARMSharedService.HCM.July, request.ARMSharedService.HCM.August, request.ARMSharedService.HCM.September, request.ARMSharedService.HCM.October, request.ARMSharedService.HCM.November, request.ARMSharedService.HCM.December);

                    var updatetreasury = treasury.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatetreasury.UpdateMonth(request.ARMSharedService.Treasury.January, request.ARMSharedService.Treasury.February, request.ARMSharedService.Treasury.March, request.ARMSharedService.Treasury.April, request.ARMSharedService.Treasury.May, request.ARMSharedService.Treasury.June, request.ARMSharedService.Treasury.July, request.ARMSharedService.Treasury.August, request.ARMSharedService.Treasury.September, request.ARMSharedService.Treasury.October, request.ARMSharedService.Treasury.November, request.ARMSharedService.Treasury.December);

                    var updateprocurementandAdmin = procurementandAdmin.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateprocurementandAdmin.UpdateMonth(request.ARMSharedService.ProcurementandAdmin.January, request.ARMSharedService.ProcurementandAdmin.February, request.ARMSharedService.ProcurementandAdmin.March, request.ARMSharedService.ProcurementandAdmin.April, request.ARMSharedService.ProcurementandAdmin.May, request.ARMSharedService.ProcurementandAdmin.June, request.ARMSharedService.ProcurementandAdmin.July, request.ARMSharedService.ProcurementandAdmin.August, request.ARMSharedService.ProcurementandAdmin.September, request.ARMSharedService.ProcurementandAdmin.October, request.ARMSharedService.ProcurementandAdmin.November, request.ARMSharedService.ProcurementandAdmin.December);

                    var updateacademy = academy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateacademy.UpdateMonth(request.ARMSharedService.Academy.January, request.ARMSharedService.Academy.February, request.ARMSharedService.Academy.March, request.ARMSharedService.Academy.April, request.ARMSharedService.Academy.May, request.ARMSharedService.Academy.June, request.ARMSharedService.Academy.July, request.ARMSharedService.Academy.August, request.ARMSharedService.Academy.September, request.ARMSharedService.Academy.October, request.ARMSharedService.Academy.November, request.ARMSharedService.Academy.December);

                    var updatecorporateStrategy = corporateStrategy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatecorporateStrategy.UpdateMonth(request.ARMSharedService.CorporateStrategy.January, request.ARMSharedService.CorporateStrategy.February, request.ARMSharedService.CorporateStrategy.March, request.ARMSharedService.CorporateStrategy.April, request.ARMSharedService.CorporateStrategy.May, request.ARMSharedService.CorporateStrategy.June, request.ARMSharedService.CorporateStrategy.July, request.ARMSharedService.CorporateStrategy.August, request.ARMSharedService.CorporateStrategy.September, request.ARMSharedService.CorporateStrategy.October, request.ARMSharedService.CorporateStrategy.November, request.ARMSharedService.CorporateStrategy.December);

                    var updatelegal = legal.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatelegal.UpdateMonth(request.ARMSharedService.Legal.January, request.ARMSharedService.Legal.February, request.ARMSharedService.Legal.March, request.ARMSharedService.Legal.April, request.ARMSharedService.Legal.May, request.ARMSharedService.Legal.June, request.ARMSharedService.Legal.July, request.ARMSharedService.Legal.August, request.ARMSharedService.Legal.September, request.ARMSharedService.Legal.October, request.ARMSharedService.Legal.November, request.ARMSharedService.Legal.December);

                    var updatecompl = compl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatecompl.UpdateMonth(request.ARMSharedService.Compliance.January, request.ARMSharedService.Compliance.February, request.ARMSharedService.Compliance.March, request.ARMSharedService.Compliance.April, request.ARMSharedService.Compliance.May, request.ARMSharedService.Compliance.June, request.ARMSharedService.Compliance.July, request.ARMSharedService.Compliance.August, request.ARMSharedService.Compliance.September, request.ARMSharedService.Compliance.October, request.ARMSharedService.Compliance.November, request.ARMSharedService.Compliance.December);

                    var updateCTO = CTO.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateCTO.UpdateMonth(request.ARMSharedService.CTO.January, request.ARMSharedService.CTO.February, request.ARMSharedService.CTO.March, request.ARMSharedService.CTO.April, request.ARMSharedService.CTO.May, request.ARMSharedService.CTO.June, request.ARMSharedService.CTO.July, request.ARMSharedService.CTO.August, request.ARMSharedService.CTO.September, request.ARMSharedService.CTO.October, request.ARMSharedService.CTO.November, request.ARMSharedService.CTO.December);

                    var updateMCC = mcc.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateMCC.UpdateMonth(request.ARMSharedService.MCC.January, request.ARMSharedService.MCC.February, request.ARMSharedService.MCC.March, request.ARMSharedService.MCC.April, request.ARMSharedService.MCC.May, request.ARMSharedService.MCC.June, request.ARMSharedService.MCC.July, request.ARMSharedService.MCC.August, request.ARMSharedService.MCC.September, request.ARMSharedService.MCC.October, request.ARMSharedService.MCC.November, request.ARMSharedService.MCC.December);

                    var updateIT = it.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateIT.UpdateMonth(request.ARMSharedService.IT.January, request.ARMSharedService.IT.February, request.ARMSharedService.IT.March, request.ARMSharedService.IT.April, request.ARMSharedService.IT.May, request.ARMSharedService.IT.June, request.ARMSharedService.IT.July, request.ARMSharedService.IT.August, request.ARMSharedService.IT.September, request.ARMSharedService.IT.October, request.ARMSharedService.IT.November, request.ARMSharedService.IT.December);

                    var updateInternalControl = internalControl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateInternalControl.UpdateMonth(request.ARMSharedService.InternalControl.January, request.ARMSharedService.InternalControl.February, request.ARMSharedService.InternalControl.March, request.ARMSharedService.InternalControl.April, request.ARMSharedService.InternalControl.May, request.ARMSharedService.InternalControl.June, request.ARMSharedService.InternalControl.July, request.ARMSharedService.InternalControl.August, request.ARMSharedService.InternalControl.September, request.ARMSharedService.InternalControl.October, request.ARMSharedService.InternalControl.November, request.ARMSharedService.InternalControl.December);

                    var updatecustomerExperience = customerExperience.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatecustomerExperience.UpdateMonth(request.ARMSharedService.CustomerExperience.January, request.ARMSharedService.CustomerExperience.February, request.ARMSharedService.CustomerExperience.March, request.ARMSharedService.CustomerExperience.April, request.ARMSharedService.CustomerExperience.May, request.ARMSharedService.CustomerExperience.June, request.ARMSharedService.CustomerExperience.July, request.ARMSharedService.CustomerExperience.August, request.ARMSharedService.CustomerExperience.September, request.ARMSharedService.CustomerExperience.October, request.ARMSharedService.CustomerExperience.November, request.ARMSharedService.CustomerExperience.December);

                    var updateinfoSec = infoSec.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateinfoSec.UpdateMonth(request.ARMSharedService.InformationSecurity.January, request.ARMSharedService.InformationSecurity.February, request.ARMSharedService.InformationSecurity.March, request.ARMSharedService.InformationSecurity.April, request.ARMSharedService.InformationSecurity.May, request.ARMSharedService.InformationSecurity.June, request.ARMSharedService.InformationSecurity.July, request.ARMSharedService.InformationSecurity.August, request.ARMSharedService.InformationSecurity.September, request.ARMSharedService.InformationSecurity.October, request.ARMSharedService.InformationSecurity.November, request.ARMSharedService.InformationSecurity.December);

                    var updateRiskManagement = riskManagement.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateRiskManagement.UpdateMonth(request.ARMSharedService.RiskManagement.January, request.ARMSharedService.RiskManagement.February, request.ARMSharedService.RiskManagement.March, request.ARMSharedService.RiskManagement.April, request.ARMSharedService.RiskManagement.May, request.ARMSharedService.RiskManagement.June, request.ARMSharedService.RiskManagement.July, request.ARMSharedService.RiskManagement.August, request.ARMSharedService.RiskManagement.September, request.ARMSharedService.RiskManagement.October, request.ARMSharedService.RiskManagement.November, request.ARMSharedService.RiskManagement.December);
                    riskManagement.SaveChanges();
                    #endregion

                    return TypedResults.Ok($"You have performed Monthly rating with anualAuditUniverseId => '{getaudit.Id}' for the year {DateTime.Now.Year}");
                }

                if (getaudit == null)
                {
                    var logReq = AnualAuditUniverseRiskRating.Create(getbusnessRiskRating.RequesterName, request.BusinessRiskRatingId);
                    annualaudit.AddAsync(logReq);
                    logReq.Update(getbusnessRiskRating.RequesterName);

                    #region ARMholdCo
                    var checkIfItHasBeenRated = armholdcoauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == logReq.Id).FirstOrDefault();
                    checkIfItHasBeenRated.Update(getbusnessRiskRating.RequesterName);

                    var updatearmholdco = armholdco.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
                    updatearmholdco.UpdateMonth(request.ARMHoldingCompany.ArmHoldingcompany.January, request.ARMHoldingCompany.ArmHoldingcompany.February, request.ARMHoldingCompany.ArmHoldingcompany.March, request.ARMHoldingCompany.ArmHoldingcompany.April, request.ARMHoldingCompany.ArmHoldingcompany.May, request.ARMHoldingCompany.ArmHoldingcompany.June, request.ARMHoldingCompany.ArmHoldingcompany.July, request.ARMHoldingCompany.ArmHoldingcompany.August, request.ARMHoldingCompany.ArmHoldingcompany.September, request.ARMHoldingCompany.ArmHoldingcompany.October, request.ARMHoldingCompany.ArmHoldingcompany.November, request.ARMHoldingCompany.ArmHoldingcompany.December);

                    var updateTreasurySale = armHoldCoTreasurySale.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
                    updateTreasurySale.UpdateMonth(request.ARMHoldingCompany.TreasurySale.January, request.ARMHoldingCompany.TreasurySale.February, request.ARMHoldingCompany.TreasurySale.March, request.ARMHoldingCompany.TreasurySale.April, request.ARMHoldingCompany.TreasurySale.May, request.ARMHoldingCompany.TreasurySale.June, request.ARMHoldingCompany.TreasurySale.July, request.ARMHoldingCompany.TreasurySale.August, request.ARMHoldingCompany.TreasurySale.September, request.ARMHoldingCompany.TreasurySale.October, request.ARMHoldingCompany.TreasurySale.November, request.ARMHoldingCompany.TreasurySale.December);

                    armHoldCoTreasurySale.SaveChanges();
                    #endregion

                    #region DigitalFinancialService
                    var checkdfsAuditUniversereq = dfsAuditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == logReq.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkdfsAuditUniversereq.Update(getbusnessRiskRating.RequesterName);

                    var updatedfsRate = dfsRate.GetContextByConditon(x => x.DigitalFinancialServiceAuditUniverseId == checkdfsAuditUniversereq.Id).FirstOrDefault();
                    updatedfsRate.UpdateMonth(request.DigitalFinancialService.DigitalFinancialService.January, request.DigitalFinancialService.DigitalFinancialService.February, request.DigitalFinancialService.DigitalFinancialService.March, request.DigitalFinancialService.DigitalFinancialService.April, request.DigitalFinancialService.DigitalFinancialService.May, request.DigitalFinancialService.DigitalFinancialService.June, request.DigitalFinancialService.DigitalFinancialService.July, request.DigitalFinancialService.DigitalFinancialService.August, request.DigitalFinancialService.DigitalFinancialService.September, request.DigitalFinancialService.DigitalFinancialService.October, request.DigitalFinancialService.DigitalFinancialService.November, request.DigitalFinancialService.DigitalFinancialService.December);

                    dfsRate.SaveChanges();
                    #endregion

                    #region ARMCapital
                    var checkARMCapitalAuditUniversereq2 = armCapitalAuditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == logReq.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkARMCapitalAuditUniversereq2.Update(getbusnessRiskRating.RequesterName);

                    var updateARMCapitalRate2 = armCapitalRate.GetContextByConditon(x => x.ARMCapitalAuditUniverseId == checkARMCapitalAuditUniversereq2.Id).FirstOrDefault();
                    updateARMCapitalRate2.UpdateMonth(request.ARMCapital.ARMCapital.January, request.ARMCapital.ARMCapital.February, request.ARMCapital.ARMCapital.March, request.ARMCapital.ARMCapital.April, request.ARMCapital.ARMCapital.May, request.ARMCapital.ARMCapital.June, request.ARMCapital.ARMCapital.July, request.ARMCapital.ARMCapital.August, request.ARMCapital.ARMCapital.September, request.ARMCapital.ARMCapital.October, request.ARMCapital.ARMCapital.November, request.ARMCapital.ARMCapital.December);

                    armCapitalRate.SaveChanges();
                    #endregion

                    #region ARMIM
                    var checkIarmim = armimauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == logReq.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkIarmim.Update(getbusnessRiskRating.RequesterName);
                                      
                    var updateimunit = imunit.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateimunit.UpdateMonth(request.ARMIM.IMUnit.January, request.ARMIM.IMUnit.February, request.ARMIM.IMUnit.March, request.ARMIM.IMUnit.April, request.ARMIM.IMUnit.May, request.ARMIM.IMUnit.June, request.ARMIM.IMUnit.July, request.ARMIM.IMUnit.August, request.ARMIM.IMUnit.September, request.ARMIM.IMUnit.October, request.ARMIM.IMUnit.November, request.ARMIM.IMUnit.December);

                    var updateoperationControl = operationControl.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateoperationControl.UpdateMonth(request.ARMIM.OperationControl.January, request.ARMIM.OperationControl.February, request.ARMIM.OperationControl.March, request.ARMIM.OperationControl.April, request.ARMIM.OperationControl.May, request.ARMIM.OperationControl.June, request.ARMIM.OperationControl.July, request.ARMIM.OperationControl.August, request.ARMIM.OperationControl.September, request.ARMIM.OperationControl.October, request.ARMIM.OperationControl.November, request.ARMIM.OperationControl.December);

                    var updatefundAdmin = fundAdmin.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updatefundAdmin.UpdateMonth(request.ARMIM.FundAdmin.January, request.ARMIM.FundAdmin.February, request.ARMIM.FundAdmin.March, request.ARMIM.FundAdmin.April, request.ARMIM.FundAdmin.May, request.ARMIM.FundAdmin.June, request.ARMIM.FundAdmin.July, request.ARMIM.FundAdmin.August, request.ARMIM.FundAdmin.September, request.ARMIM.FundAdmin.October, request.ARMIM.FundAdmin.November, request.ARMIM.FundAdmin.December);

                    var updateregistrar = registrar.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateregistrar.UpdateMonth(request.ARMIM.Registrar.January, request.ARMIM.Registrar.February, request.ARMIM.Registrar.March, request.ARMIM.Registrar.April, request.ARMIM.Registrar.May, request.ARMIM.Registrar.June, request.ARMIM.Registrar.July, request.ARMIM.Registrar.August, request.ARMIM.Registrar.September, request.ARMIM.Registrar.October, request.ARMIM.Registrar.November, request.ARMIM.Registrar.December);

                    var updatebDPWMIAMIMRetail = bDPWMIAMIMRetail.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updatebDPWMIAMIMRetail.UpdateMonth(request.ARMIM.BDPWMIAMIMRetail.January, request.ARMIM.BDPWMIAMIMRetail.February, request.ARMIM.BDPWMIAMIMRetail.March, request.ARMIM.BDPWMIAMIMRetail.April, request.ARMIM.BDPWMIAMIMRetail.May, request.ARMIM.BDPWMIAMIMRetail.June, request.ARMIM.BDPWMIAMIMRetail.July, request.ARMIM.BDPWMIAMIMRetail.August, request.ARMIM.BDPWMIAMIMRetail.September, request.ARMIM.BDPWMIAMIMRetail.October, request.ARMIM.BDPWMIAMIMRetail.November, request.ARMIM.BDPWMIAMIMRetail.December);

                    var updateoperationSettlement = operationSettlement.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateoperationSettlement.UpdateMonth(request.ARMIM.OperationSettlement.January, request.ARMIM.OperationSettlement.February, request.ARMIM.OperationSettlement.March, request.ARMIM.OperationSettlement.April, request.ARMIM.OperationSettlement.May, request.ARMIM.OperationSettlement.June, request.ARMIM.OperationSettlement.July, request.ARMIM.OperationSettlement.August, request.ARMIM.OperationSettlement.September, request.ARMIM.OperationSettlement.October, request.ARMIM.OperationSettlement.November, request.ARMIM.OperationSettlement.December);

                    var uopdateresearch = research.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    uopdateresearch.UpdateMonth(request.ARMIM.Research.January, request.ARMIM.Research.February, request.ARMIM.Research.March, request.ARMIM.Research.April, request.ARMIM.Research.May, request.ARMIM.Research.June, request.ARMIM.Research.July, request.ARMIM.Research.August, request.ARMIM.Research.September, request.ARMIM.Research.October, request.ARMIM.Research.November, request.ARMIM.Research.December);

                    var updateretailOperation = retailOperation.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updateretailOperation.UpdateMonth(request.ARMIM.RetailOperation.January, request.ARMIM.RetailOperation.February, request.ARMIM.RetailOperation.March, request.ARMIM.RetailOperation.April, request.ARMIM.RetailOperation.May, request.ARMIM.RetailOperation.June, request.ARMIM.RetailOperation.July, request.ARMIM.RetailOperation.August, request.ARMIM.RetailOperation.September, request.ARMIM.RetailOperation.October, request.ARMIM.RetailOperation.November, request.ARMIM.RetailOperation.December);

                    var updatefundAccount = fundAccount.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIarmim.Id).FirstOrDefault();
                    updatefundAccount.UpdateMonth(request.ARMIM.FundAccount.January, request.ARMIM.FundAccount.February, request.ARMIM.FundAccount.March, request.ARMIM.FundAccount.April, request.ARMIM.FundAccount.May, request.ARMIM.FundAccount.June, request.ARMIM.FundAccount.July, request.ARMIM.FundAccount.August, request.ARMIM.FundAccount.September, request.ARMIM.FundAccount.October, request.ARMIM.FundAccount.November, request.ARMIM.FundAccount.December);

                    fundAccount.SaveChanges();
                    #endregion

                    #region ARMSecurity
                    var checkarmsecreq = armsecreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == logReq.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkarmsecreq.Update(getbusnessRiskRating.RequesterName);

                    var updateStockBroking = stockBroking.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkarmsecreq.Id).FirstOrDefault();
                    updateStockBroking.UpdateMonth(request.ARMSecurity.StockBroking.January, request.ARMSecurity.StockBroking.February, request.ARMSecurity.StockBroking.March, request.ARMSecurity.StockBroking.April, request.ARMSecurity.StockBroking.May, request.ARMSecurity.StockBroking.June, request.ARMSecurity.StockBroking.July, request.ARMSecurity.StockBroking.August, request.ARMSecurity.StockBroking.September, request.ARMSecurity.StockBroking.October, request.ARMSecurity.StockBroking.November, request.ARMSecurity.StockBroking.December);

                    stockBroking.SaveChanges();
                    #endregion

                    #region ARMTrustee
                    var checkarmtrusteereq = armtrusteereq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == logReq.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkarmtrusteereq.Update(getbusnessRiskRating.RequesterName);

                    var updateprivateTrust = privateTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkarmtrusteereq.Id).FirstOrDefault();
                    updateprivateTrust.UpdateMonth(request.ARMTrustee.PrivateTrust.January, request.ARMTrustee.PrivateTrust.February, request.ARMTrustee.PrivateTrust.March, request.ARMTrustee.PrivateTrust.April, request.ARMTrustee.PrivateTrust.May, request.ARMTrustee.PrivateTrust.June, request.ARMTrustee.PrivateTrust.July, request.ARMTrustee.PrivateTrust.August, request.ARMTrustee.PrivateTrust.September, request.ARMTrustee.PrivateTrust.October, request.ARMTrustee.PrivateTrust.November, request.ARMTrustee.PrivateTrust.December);

                    var updatecommercialTrust = commercialTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkarmtrusteereq.Id).FirstOrDefault();
                    updatecommercialTrust.UpdateMonth(request.ARMTrustee.CommercialTrust.January, request.ARMTrustee.CommercialTrust.February, request.ARMTrustee.CommercialTrust.March, request.ARMTrustee.CommercialTrust.April, request.ARMTrustee.CommercialTrust.May, request.ARMTrustee.CommercialTrust.June, request.ARMTrustee.CommercialTrust.July, request.ARMTrustee.CommercialTrust.August, request.ARMTrustee.CommercialTrust.September, request.ARMTrustee.CommercialTrust.October, request.ARMTrustee.CommercialTrust.November, request.ARMTrustee.CommercialTrust.December);

                    commercialTrust.SaveChanges();
                    #endregion

                    #region ARMAgribusiness
                    var checkagrireq = agrireq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == logReq.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();

                    checkIfItHasBeenRated.Update(getbusnessRiskRating.RequesterName);

                    var updateaafml = aafml.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkagrireq.Id).FirstOrDefault();
                    updateaafml.UpdateMonth(request.ARMAgribusiness.AAFML.January, request.ARMAgribusiness.AAFML.February, request.ARMAgribusiness.AAFML.March, request.ARMAgribusiness.AAFML.April, request.ARMAgribusiness.AAFML.May, request.ARMAgribusiness.AAFML.June, request.ARMAgribusiness.AAFML.July, request.ARMAgribusiness.AAFML.August, request.ARMAgribusiness.AAFML.September, request.ARMAgribusiness.AAFML.October, request.ARMAgribusiness.AAFML.November, request.ARMAgribusiness.AAFML.December);

                    var updaterfl = rfl.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkagrireq.Id).FirstOrDefault();
                    updaterfl.UpdateMonth(request.ARMAgribusiness.RFL.January, request.ARMAgribusiness.RFL.February, request.ARMAgribusiness.RFL.March, request.ARMAgribusiness.RFL.April, request.ARMAgribusiness.RFL.May, request.ARMAgribusiness.RFL.June, request.ARMAgribusiness.RFL.July, request.ARMAgribusiness.RFL.August, request.ARMAgribusiness.RFL.September, request.ARMAgribusiness.RFL.October, request.ARMAgribusiness.RFL.November, request.ARMAgribusiness.RFL.December);

                    rfl.SaveChanges();
                    #endregion

                    #region ARMHill
                    var checkarmhillreq = armhillreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == logReq.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkarmhillreq.Update(getbusnessRiskRating.RequesterName);

                    var updatearmhill = armhill.GetContextByConditon(x => x.ARMHillAuditUniverseId == checkarmhillreq.Id).FirstOrDefault();
                    updatearmhill.UpdateMonth(request.ARMHill.ARMHill.January, request.ARMHill.ARMHill.February, request.ARMHill.ARMHill.March, request.ARMHill.ARMHill.April, request.ARMHill.ARMHill.May, request.ARMHill.ARMHill.June, request.ARMHill.ARMHill.July, request.ARMHill.ARMHill.August, request.ARMHill.ARMHill.September, request.ARMHill.ARMHill.October, request.ARMHill.ARMHill.November, request.ARMHill.ARMHill.December);

                    armhill.SaveChanges();
                    #endregion

                    #region ARMSharedService
                    var checkSharedReq = req.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id && x.RequesterName == getbusnessRiskRating.RequesterName).FirstOrDefault();
                    checkSharedReq.Update(getbusnessRiskRating.RequesterName);

                    var updatedataAna = dataAna.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatedataAna.UpdateMonth(request.ARMSharedService.DataAnalytic.January, request.ARMSharedService.DataAnalytic.February, request.ARMSharedService.DataAnalytic.March, request.ARMSharedService.DataAnalytic.April, request.ARMSharedService.DataAnalytic.May, request.ARMSharedService.DataAnalytic.June, request.ARMSharedService.DataAnalytic.July, request.ARMSharedService.DataAnalytic.August, request.ARMSharedService.DataAnalytic.September, request.ARMSharedService.DataAnalytic.October, request.ARMSharedService.DataAnalytic.November, request.ARMSharedService.DataAnalytic.December);

                    var updatefinCtrl = finCtrl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatefinCtrl.UpdateMonth(request.ARMSharedService.FinancialControl.January, request.ARMSharedService.FinancialControl.February, request.ARMSharedService.FinancialControl.March, request.ARMSharedService.FinancialControl.April, request.ARMSharedService.FinancialControl.May, request.ARMSharedService.FinancialControl.June, request.ARMSharedService.FinancialControl.July, request.ARMSharedService.FinancialControl.August, request.ARMSharedService.FinancialControl.September, request.ARMSharedService.FinancialControl.October, request.ARMSharedService.FinancialControl.November, request.ARMSharedService.FinancialControl.December);

                    var updatehcm = hcm.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatehcm.UpdateMonth(request.ARMSharedService.HCM.January, request.ARMSharedService.HCM.February, request.ARMSharedService.HCM.March, request.ARMSharedService.HCM.April, request.ARMSharedService.HCM.May, request.ARMSharedService.HCM.June, request.ARMSharedService.HCM.July, request.ARMSharedService.HCM.August, request.ARMSharedService.HCM.September, request.ARMSharedService.HCM.October, request.ARMSharedService.HCM.November, request.ARMSharedService.HCM.December);

                    var updatetreasury = treasury.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatetreasury.UpdateMonth(request.ARMSharedService.Treasury.January, request.ARMSharedService.Treasury.February, request.ARMSharedService.Treasury.March, request.ARMSharedService.Treasury.April, request.ARMSharedService.Treasury.May, request.ARMSharedService.Treasury.June, request.ARMSharedService.Treasury.July, request.ARMSharedService.Treasury.August, request.ARMSharedService.Treasury.September, request.ARMSharedService.Treasury.October, request.ARMSharedService.Treasury.November, request.ARMSharedService.Treasury.December);

                    var updateprocurementandAdmin = procurementandAdmin.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateprocurementandAdmin.UpdateMonth(request.ARMSharedService.ProcurementandAdmin.January, request.ARMSharedService.ProcurementandAdmin.February, request.ARMSharedService.ProcurementandAdmin.March, request.ARMSharedService.ProcurementandAdmin.April, request.ARMSharedService.ProcurementandAdmin.May, request.ARMSharedService.ProcurementandAdmin.June, request.ARMSharedService.ProcurementandAdmin.July, request.ARMSharedService.ProcurementandAdmin.August, request.ARMSharedService.ProcurementandAdmin.September, request.ARMSharedService.ProcurementandAdmin.October, request.ARMSharedService.ProcurementandAdmin.November, request.ARMSharedService.ProcurementandAdmin.December);

                    var updateacademy = academy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateacademy.UpdateMonth(request.ARMSharedService.Academy.January, request.ARMSharedService.Academy.February, request.ARMSharedService.Academy.March, request.ARMSharedService.Academy.April, request.ARMSharedService.Academy.May, request.ARMSharedService.Academy.June, request.ARMSharedService.Academy.July, request.ARMSharedService.Academy.August, request.ARMSharedService.Academy.September, request.ARMSharedService.Academy.October, request.ARMSharedService.Academy.November, request.ARMSharedService.Academy.December);

                    var updatecorporateStrategy = corporateStrategy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatecorporateStrategy.UpdateMonth(request.ARMSharedService.CorporateStrategy.January, request.ARMSharedService.CorporateStrategy.February, request.ARMSharedService.CorporateStrategy.March, request.ARMSharedService.CorporateStrategy.April, request.ARMSharedService.CorporateStrategy.May, request.ARMSharedService.CorporateStrategy.June, request.ARMSharedService.CorporateStrategy.July, request.ARMSharedService.CorporateStrategy.August, request.ARMSharedService.CorporateStrategy.September, request.ARMSharedService.CorporateStrategy.October, request.ARMSharedService.CorporateStrategy.November, request.ARMSharedService.CorporateStrategy.December);

                    var updatelegal = legal.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatelegal.UpdateMonth(request.ARMSharedService.Legal.January, request.ARMSharedService.Legal.February, request.ARMSharedService.Legal.March, request.ARMSharedService.Legal.April, request.ARMSharedService.Legal.May, request.ARMSharedService.Legal.June, request.ARMSharedService.Legal.July, request.ARMSharedService.Legal.August, request.ARMSharedService.Legal.September, request.ARMSharedService.Legal.October, request.ARMSharedService.Legal.November, request.ARMSharedService.Legal.December);

                    var updatecompl = compl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatecompl.UpdateMonth(request.ARMSharedService.Compliance.January, request.ARMSharedService.Compliance.February, request.ARMSharedService.Compliance.March, request.ARMSharedService.Compliance.April, request.ARMSharedService.Compliance.May, request.ARMSharedService.Compliance.June, request.ARMSharedService.Compliance.July, request.ARMSharedService.Compliance.August, request.ARMSharedService.Compliance.September, request.ARMSharedService.Compliance.October, request.ARMSharedService.Compliance.November, request.ARMSharedService.Compliance.December);

                    var updateCTO = CTO.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateCTO.UpdateMonth(request.ARMSharedService.CTO.January, request.ARMSharedService.CTO.February, request.ARMSharedService.CTO.March, request.ARMSharedService.CTO.April, request.ARMSharedService.CTO.May, request.ARMSharedService.CTO.June, request.ARMSharedService.CTO.July, request.ARMSharedService.CTO.August, request.ARMSharedService.CTO.September, request.ARMSharedService.CTO.October, request.ARMSharedService.CTO.November, request.ARMSharedService.CTO.December);

                    var updateMCC = mcc.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateMCC.UpdateMonth(request.ARMSharedService.MCC.January, request.ARMSharedService.MCC.February, request.ARMSharedService.MCC.March, request.ARMSharedService.MCC.April, request.ARMSharedService.MCC.May, request.ARMSharedService.MCC.June, request.ARMSharedService.MCC.July, request.ARMSharedService.MCC.August, request.ARMSharedService.MCC.September, request.ARMSharedService.MCC.October, request.ARMSharedService.MCC.November, request.ARMSharedService.MCC.December);

                    var updateIT = it.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateIT.UpdateMonth(request.ARMSharedService.IT.January, request.ARMSharedService.IT.February, request.ARMSharedService.IT.March, request.ARMSharedService.IT.April, request.ARMSharedService.IT.May, request.ARMSharedService.IT.June, request.ARMSharedService.IT.July, request.ARMSharedService.IT.August, request.ARMSharedService.IT.September, request.ARMSharedService.IT.October, request.ARMSharedService.IT.November, request.ARMSharedService.IT.December);

                    var updateInternalControl = internalControl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateInternalControl.UpdateMonth(request.ARMSharedService.InternalControl.January, request.ARMSharedService.InternalControl.February, request.ARMSharedService.InternalControl.March, request.ARMSharedService.InternalControl.April, request.ARMSharedService.InternalControl.May, request.ARMSharedService.InternalControl.June, request.ARMSharedService.InternalControl.July, request.ARMSharedService.InternalControl.August, request.ARMSharedService.InternalControl.September, request.ARMSharedService.InternalControl.October, request.ARMSharedService.InternalControl.November, request.ARMSharedService.InternalControl.December);

                    var updatecustomerExperience = customerExperience.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updatecustomerExperience.UpdateMonth(request.ARMSharedService.CustomerExperience.January, request.ARMSharedService.CustomerExperience.February, request.ARMSharedService.CustomerExperience.March, request.ARMSharedService.CustomerExperience.April, request.ARMSharedService.CustomerExperience.May, request.ARMSharedService.CustomerExperience.June, request.ARMSharedService.CustomerExperience.July, request.ARMSharedService.CustomerExperience.August, request.ARMSharedService.CustomerExperience.September, request.ARMSharedService.CustomerExperience.October, request.ARMSharedService.CustomerExperience.November, request.ARMSharedService.CustomerExperience.December);

                    var updateinfoSec = infoSec.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateinfoSec.UpdateMonth(request.ARMSharedService.InformationSecurity.January, request.ARMSharedService.InformationSecurity.February, request.ARMSharedService.InformationSecurity.March, request.ARMSharedService.InformationSecurity.April, request.ARMSharedService.InformationSecurity.May, request.ARMSharedService.InformationSecurity.June, request.ARMSharedService.InformationSecurity.July, request.ARMSharedService.InformationSecurity.August, request.ARMSharedService.InformationSecurity.September, request.ARMSharedService.InformationSecurity.October, request.ARMSharedService.InformationSecurity.November, request.ARMSharedService.InformationSecurity.December);

                    var updateRiskManagement = riskManagement.GetContextByConditon(x => x.ARMSharedAuditUniverseId == checkSharedReq.Id).FirstOrDefault();
                    updateRiskManagement.UpdateMonth(request.ARMSharedService.RiskManagement.January, request.ARMSharedService.RiskManagement.February, request.ARMSharedService.RiskManagement.March, request.ARMSharedService.RiskManagement.April, request.ARMSharedService.RiskManagement.May, request.ARMSharedService.RiskManagement.June, request.ARMSharedService.RiskManagement.July, request.ARMSharedService.RiskManagement.August, request.ARMSharedService.RiskManagement.September, request.ARMSharedService.RiskManagement.October, request.ARMSharedService.RiskManagement.November, request.ARMSharedService.RiskManagement.December);
                    riskManagement.SaveChanges();
                    #endregion
                    AnualAuditUniverseResp response = new AnualAuditUniverseResp
                    {
                        AnualAuditUniverseId = logReq.Id
                    };
                    return TypedResults.Created($"apra/{response}", response);
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
