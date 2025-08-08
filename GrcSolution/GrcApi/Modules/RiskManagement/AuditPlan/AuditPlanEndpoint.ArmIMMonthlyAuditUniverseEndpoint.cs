//using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
//using Arm.GrcTool.Infrastructure;
//using GrcApi.Modules.RiskManagement.AuditPlan;
//using Microsoft.Win32;
//using System.Security.Claims;

//namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
//{
//    /*
//* Original Author: Sodiq Quadre
//* Date Created: 27/02/2024
//* Development Group: Audit plan Risk Assessment - GRCTools
//* This endpoint allow Monthly Audit Universe on the subsidiary
//*/
//    public class ArmIMMonthlyAuditUniverseEndpoint
//    {

//        /// <summary>
//        /// ARMIM Monthly audit universe       
//        /// </summary>
//        /// <param name="request"></param>
//        /// <param name="annualaudit"></param>
//        /// <param name="armholdcoauditUniverse"></param>
//        /// <param name="armholdco"></param>
//        /// <param name="armHoldCoTreasurySale"></param>
//        /// <param name="armholdcoTreasuryOperation"></param>
//        /// <param name="armHoldCoFinancialControl"></param>
//        /// <param name="armholdcoCompliance"></param>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public static async Task<IResult> HandleAsync(ARMIMMonthlyAuditReq request, IRepository<BusinessRiskRating> busnessRiskRating, IRepository<AnualAuditUniverseRiskRating> annualaudit,
//            IRepository<ARMIMAuditUniverse> armimauditUniverse, IRepository<AuditUniverseARMIMIMUnit> imunit,
//            IRepository<AuditUniverseARMIMOperationControl> operationControl, IRepository<AuditUniverseARMIMFundAdmin> fundAdmin,
//            IRepository<AuditUniverseARMIMRegistrar> registrar, IRepository<AuditUniverseARMIMBDPWMIAMIMRetail> bDPWMIAMIMRetail,
//            IRepository<AuditUniverseARMIMFinancialControl> financialControl, IRepository<AuditUniverseARMIMCompliance> compliance,
//            IRepository<AuditUniverseARMIMOperationSettlement> operationSettlement, IRepository<AuditUniverseARMIMTreasuryInvestment> treasuryInvestment,
//            IRepository<AuditUniverseARMIMRetailOperation> retailOperation, IRepository<AuditUniverseARMIMFundAccount> fundAccount,
//            ClaimsPrincipal user)
//        {
//            try
//            {
//                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
//                var year = DateTime.Now.Year;               
//                var getbusnessRiskRating = busnessRiskRating.GetContextByConditon(x => x.Id == request.BusinessRiskRatingId && x.CreatedOnUtc.Year == year).FirstOrDefault();
//                if (getbusnessRiskRating == null)
//                {
//                    return TypedResults.NotFound($"The Business Risk Rating Id '{request.BusinessRiskRatingId}' was not found");

//                }
//                var getaudit = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == request.BusinessRiskRatingId && x.CreatedOnUtc.Year == year).FirstOrDefault();
//                var checkIfItHasBeenRated = armimauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id && x.RequesterName == requesterName).FirstOrDefault();

//                if (checkIfItHasBeenRated != null)
//                {
//                    return TypedResults.Ok($"The user has performed Monthly rating for the ARMHoldingCompany with id '{getaudit.Id}' for the year {year}");
//                }               
//                getaudit.Update(requesterName);

//                checkIfItHasBeenRated.Update(requesterName);               
//                var updateimunit = imunit.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateimunit.UpdateMonth(request.IMUnit.January, request.IMUnit.February, request.IMUnit.March, request.IMUnit.April, request.IMUnit.May, request.IMUnit.June, request.IMUnit.July, request.IMUnit.August, request.IMUnit.September, request.IMUnit.October, request.IMUnit.November, request.IMUnit.December);

//                var updateoperationControl = operationControl.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateoperationControl.UpdateMonth(request.OperationControl.January, request.OperationControl.February, request.OperationControl.March, request.OperationControl.April, request.OperationControl.May, request.OperationControl.June, request.OperationControl.July, request.OperationControl.August, request.OperationControl.September, request.OperationControl.October, request.OperationControl.November, request.OperationControl.December);

//                var updatefundAdmin = fundAdmin.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefundAdmin.UpdateMonth(request.FundAdmin.January, request.FundAdmin.February, request.FundAdmin.March, request.FundAdmin.April, request.FundAdmin.May, request.FundAdmin.June, request.FundAdmin.July, request.FundAdmin.August, request.FundAdmin.September, request.FundAdmin.October, request.FundAdmin.November, request.FundAdmin.December);

//                var updateFinancialControl = financialControl.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateFinancialControl.UpdateMonth(request.FinancialControl.January, request.FinancialControl.February, request.FinancialControl.March, request.FinancialControl.April, request.FinancialControl.May, request.FinancialControl.June, request.FinancialControl.July, request.FinancialControl.August, request.FinancialControl.September, request.FinancialControl.October, request.FinancialControl.November, request.FinancialControl.December);
                
//               var updateregistrar = registrar.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateregistrar.UpdateMonth(request.Registrar.January, request.Registrar.February, request.Registrar.March, request.Registrar.April, request.Registrar.May, request.Registrar.June, request.Registrar.July, request.Registrar.August, request.Registrar.September, request.Registrar.October, request.Registrar.November, request.Registrar.December);

//                var updateCompliance = compliance.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateCompliance.UpdateMonth(request.Compliance.January, request.Compliance.February, request.Compliance.March, request.Compliance.April, request.Compliance.May, request.Compliance.June, request.Compliance.July, request.Compliance.August, request.Compliance.September, request.Compliance.October, request.Compliance.November, request.Compliance.December);

//                var updatebDPWMIAMIMRetail = bDPWMIAMIMRetail.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatebDPWMIAMIMRetail.UpdateMonth(request.BDPWMIAMIMRetail.January, request.BDPWMIAMIMRetail.February, request.BDPWMIAMIMRetail.March, request.BDPWMIAMIMRetail.April, request.BDPWMIAMIMRetail.May, request.BDPWMIAMIMRetail.June, request.BDPWMIAMIMRetail.July, request.BDPWMIAMIMRetail.August, request.BDPWMIAMIMRetail.September, request.BDPWMIAMIMRetail.October, request.BDPWMIAMIMRetail.November, request.BDPWMIAMIMRetail.December);

//                var updateoperationSettlement = operationSettlement.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateoperationSettlement.UpdateMonth(request.OperationSettlement.January, request.OperationSettlement.February, request.OperationSettlement.March, request.OperationSettlement.April, request.OperationSettlement.May, request.OperationSettlement.June, request.OperationSettlement.July, request.OperationSettlement.August, request.OperationSettlement.September, request.OperationSettlement.October, request.OperationSettlement.November, request.OperationSettlement.December);

//                var updatetreasuryInvestment = treasuryInvestment.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatetreasuryInvestment.UpdateMonth(request.TreasuryInvestment.January, request.TreasuryInvestment.February, request.TreasuryInvestment.March, request.TreasuryInvestment.April, request.TreasuryInvestment.May, request.TreasuryInvestment.June, request.TreasuryInvestment.July, request.TreasuryInvestment.August, request.TreasuryInvestment.September, request.TreasuryInvestment.October, request.TreasuryInvestment.November, request.TreasuryInvestment.December);

//                var updateretailOperation = retailOperation.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateretailOperation.UpdateMonth(request.RetailOperation.January, request.RetailOperation.February, request.RetailOperation.March, request.RetailOperation.April, request.RetailOperation.May, request.RetailOperation.June, request.RetailOperation.July, request.RetailOperation.August, request.RetailOperation.September, request.RetailOperation.October, request.RetailOperation.November, request.RetailOperation.December);

//                var updatefundAccount = fundAccount.GetContextByConditon(x => x.ARMIMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefundAccount.UpdateMonth(request.FundAccount.January, request.FundAccount.February, request.FundAccount.March, request.FundAccount.April, request.FundAccount.May, request.FundAccount.June, request.FundAccount.July, request.FundAccount.August, request.FundAccount.September, request.FundAccount.October, request.FundAccount.November, request.FundAccount.December);
//                fundAccount.SaveChanges();
//                AnualAuditUniverseResp response = new AnualAuditUniverseResp
//                {
//                    AnualAuditUniverseId = getaudit.Id
//                };

//                return TypedResults.Created($"apra/{response}", response);

//            }
//            catch (Exception ex)
//            {
//                return TypedResults.Problem(ex.Message, null, 500);
//            }

//        }
//    }

//}
