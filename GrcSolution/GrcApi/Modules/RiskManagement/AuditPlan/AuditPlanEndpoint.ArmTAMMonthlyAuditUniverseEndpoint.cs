//using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
//using Arm.GrcTool.Infrastructure;
//using GrcApi.Modules.RiskManagement.AuditPlan;
//using System.Security.Claims;

//namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
//{
//    /*
//* Original Author: Sodiq Quadre
//* Date Created: 27/02/2024
//* Development Group: Audit plan Risk Assessment - GRCTools
//* This endpoint allow Monthly Audit Universe on the subsidiary
//*/
//    public class ArmTAMMonthlyAuditUniverseEndpoint
//    {

//        /// <summary>
//        /// ARMTAM Monthly audit universe       
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
//        public static async Task<IResult> HandleAsync(ARMTAMMonthlyAuditReq request, IRepository<AnualAuditUniverseRiskRating> annualaudit,           
//            IRepository<ARMTAMAuditUniverse> armtamReq, IRepository<AuditUniverseARMTAM> armtam, IRepository<BusinessRiskRating> busnessRiskRating,
//            IRepository<AuditUniverseARMTAMFinancialControl> financialControl, IRepository<AuditUniverseARMTAMTreasuryOperation> treasuryOperation,
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
//                var checkIfItHasBeenRated = armtamReq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id && x.RequesterName == requesterName).FirstOrDefault();

//                if (checkIfItHasBeenRated != null)
//                {
//                    return TypedResults.Ok($"The user has performed Monthly rating for the ARMTAM with id '{getaudit.Id}' for the year {year}");
//                }
                
//                getaudit.Update(requesterName);

//                checkIfItHasBeenRated.Update(requesterName);

//                var updatearmtam = armtam.GetContextByConditon(x => x.ARMTAMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatearmtam.UpdateMonth(request.ArmTAM.January, request.ArmTAM.February, request.ArmTAM.March, request.ArmTAM.April, request.ArmTAM.May, request.ArmTAM.June, request.ArmTAM.July, request.ArmTAM.August, request.ArmTAM.September, request.ArmTAM.October, request.ArmTAM.November, request.ArmTAM.December);

//                var updatefinancialControl = financialControl.GetContextByConditon(x => x.ARMTAMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefinancialControl.UpdateMonth(request.FinancialControl.January, request.FinancialControl.February, request.FinancialControl.March, request.FinancialControl.April, request.FinancialControl.May, request.FinancialControl.June, request.FinancialControl.July, request.FinancialControl.August, request.FinancialControl.September, request.FinancialControl.October, request.FinancialControl.November, request.FinancialControl.December);

//                var updateTreasuryOperation = treasuryOperation.GetContextByConditon(x => x.ARMTAMAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateTreasuryOperation.UpdateMonth(request.TreasuryOperation.January, request.TreasuryOperation.February, request.TreasuryOperation.March, request.TreasuryOperation.April, request.TreasuryOperation.May, request.TreasuryOperation.June, request.TreasuryOperation.July, request.TreasuryOperation.August, request.TreasuryOperation.September, request.TreasuryOperation.October, request.TreasuryOperation.November, request.TreasuryOperation.December);
//                treasuryOperation.SaveChanges();
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
