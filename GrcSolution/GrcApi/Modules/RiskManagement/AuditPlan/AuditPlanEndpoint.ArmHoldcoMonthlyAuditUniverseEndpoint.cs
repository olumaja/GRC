//using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
//using Arm.GrcTool.Infrastructure;
//using GrcApi.Modules.RiskManagement.AuditPlan;
//using System.Security.Claims;

//namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
//{
//    /*
// * Original Author: Sodiq Quadre
// * Date Created: 27/02/2024
// * Development Group: Audit plan Risk Assessment - GRCTools
// * This endpoint allow Monthly Audit Universe on the subsidiary
// */
//    public class ArmHoldcoMonthlyAuditUniverseEndpoint
//    {

//        /// <summary>
//        /// ARMHoldco Monthly audit universe       
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
//        public static async Task<IResult> HandleAsync(ARMHoldCoMonthlyAuditReq request, IRepository<AnualAuditUniverseRiskRating> annualaudit, 
//            IRepository<ARMHoldingCompanyAnnualAuditUniverse> armholdcoauditUniverse, IRepository<AuditUniverseARMHoldingCompany> armholdco, 
//            IRepository<AuditUniverseARMHoldCoTreasurySale> armHoldCoTreasurySale, IRepository<AuditUniverseARMHoldCoTreasuryOperation> armholdcoTreasuryOperation, 
//            IRepository<AuditUniverseARMHoldCoFinancialControl> armHoldCoFinancialControl, IRepository<AuditUniverseARMHoldCoCompliance> armholdcoCompliance,
//            IRepository<BusinessRiskRating> busnessRiskRating, ClaimsPrincipal user)
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
//                var checkIfItHasBeenRated = armholdcoauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id && x.RequesterName == requesterName).FirstOrDefault();
                               
//                if(checkIfItHasBeenRated != null)
//                {
//                    return TypedResults.Ok($"The user has performed Monthly rating for the ARMHoldingCompany with id '{getaudit.Id}' for the year {year}");
//                }               
//                getaudit.Update(requesterName);

//                checkIfItHasBeenRated.Update(requesterName);

//                var updatearmholdco = armholdco.GetContextByConditon(x => x.ARMHoldingCompanyAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatearmholdco.UpdateMonth(request.ArmHoldingcompany.January, request.ArmHoldingcompany.February, request.ArmHoldingcompany.March, request.ArmHoldingcompany.April, request.ArmHoldingcompany.May, request.ArmHoldingcompany.June, request.ArmHoldingcompany.July, request.ArmHoldingcompany.August, request.ArmHoldingcompany.September, request.ArmHoldingcompany.October, request.ArmHoldingcompany.November, request.ArmHoldingcompany.December);

//                var updateTreasurySale = armHoldCoTreasurySale.GetContextByConditon(x => x.ARMHoldingCompanyAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateTreasurySale.UpdateMonth(request.TreasurySale.January, request.TreasurySale.February, request.TreasurySale.March, request.TreasurySale.April, request.TreasurySale.May, request.TreasurySale.June, request.TreasurySale.July, request.TreasurySale.August, request.TreasurySale.September, request.TreasurySale.October, request.TreasurySale.November, request.TreasurySale.December);
              
//                var updateTreasuryOperation = armholdcoTreasuryOperation.GetContextByConditon(x => x.ARMHoldingCompanyAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateTreasuryOperation.UpdateMonth(request.TreasuryOperation.January, request.TreasuryOperation.February, request.TreasuryOperation.March, request.TreasuryOperation.April, request.TreasuryOperation.May, request.TreasuryOperation.June, request.TreasuryOperation.July, request.TreasuryOperation.August, request.TreasuryOperation.September, request.TreasuryOperation.October, request.TreasuryOperation.November, request.TreasuryOperation.December);

//                var updateFinancialControl = armHoldCoFinancialControl.GetContextByConditon(x => x.ARMHoldingCompanyAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateFinancialControl.UpdateMonth(request.FinancialControl.January, request.FinancialControl.February, request.FinancialControl.March, request.FinancialControl.April, request.FinancialControl.May, request.FinancialControl.June, request.FinancialControl.July, request.FinancialControl.August, request.FinancialControl.September, request.FinancialControl.October, request.FinancialControl.November, request.FinancialControl.December);

//                var updateCompliance = armholdcoCompliance.GetContextByConditon(x => x.ARMHoldingCompanyAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateCompliance.UpdateMonth(request.Compliance.January, request.Compliance.February, request.Compliance.March, request.Compliance.April, request.Compliance.May, request.Compliance.June, request.Compliance.July, request.Compliance.August, request.Compliance.September, request.Compliance.October, request.Compliance.November, request.Compliance.December);
//                armholdcoCompliance.SaveChanges();
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
