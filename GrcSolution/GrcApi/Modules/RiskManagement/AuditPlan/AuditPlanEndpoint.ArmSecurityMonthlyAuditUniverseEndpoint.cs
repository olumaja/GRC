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
//    public class ArmSecurityMonthlyAuditUniverseEndpoint
//    {
//        /// <summary>
//        /// ARMSecurity Monthly audit universe       
//        /// </summary>
//        /// <param name="request"></param>
//        /// <param name="busnessRiskRating"></param>
//        /// <param name="annualaudit"></param>
//        /// <param name="req"></param>
//        /// <param name="armsecurity"></param>
//        /// <param name="research"></param>
//        /// <param name="financialControl"></param>
//        /// <param name="securityOperation"></param>
//        /// <param name="stockBroking"></param>
//        /// <param name="financialAdvisory"></param>
//        /// <param name="compliance"></param>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public static async Task<IResult> HandleAsync(ARMSecurityMonthlyAuditReq request, IRepository<BusinessRiskRating> busnessRiskRating,
//            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMSecurityAnnualAuditUniverse> req, IRepository<AuditUniverseARMSecurity> armsecurity, 
//            IRepository<AuditUniverseARMSecurityResearch> research, IRepository<AuditUniverseARMSecurityFinacialControl> financialControl, IRepository<AuditUniverseARMSecuritySecurityOperation> securityOperation,
//            IRepository<AuditUniverseARMSecurityStockBroking> stockBroking, IRepository<AuditUniverseARMSecurityFinancialAdvisory> financialAdvisory,
//            IRepository<AuditUniverseARMSecurityCompliance> compliance,
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
//                var checkIfItHasBeenRated = req.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id && x.RequesterName == requesterName).FirstOrDefault();

//                if (checkIfItHasBeenRated != null)
//                {
//                    return TypedResults.Ok($"The user has performed Monthly rating for the ARMTAM with id '{getaudit.Id}' for the year {year}");
//                }

//                getaudit.Update(requesterName);

//                checkIfItHasBeenRated.Update(requesterName);
               
//                var updatearmsecurity = armsecurity.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatearmsecurity.UpdateMonth(request.ARMSecurity.January, request.ARMSecurity.February, request.ARMSecurity.March, request.ARMSecurity.April, request.ARMSecurity.May, request.ARMSecurity.June, request.ARMSecurity.July, request.ARMSecurity.August, request.ARMSecurity.September, request.ARMSecurity.October, request.ARMSecurity.November, request.ARMSecurity.December);

//                var updatefinancialControl = financialControl.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefinancialControl.UpdateMonth(request.FinancialControl.January, request.FinancialControl.February, request.FinancialControl.March, request.FinancialControl.April, request.FinancialControl.May, request.FinancialControl.June, request.FinancialControl.July, request.FinancialControl.August, request.FinancialControl.September, request.FinancialControl.October, request.FinancialControl.November, request.FinancialControl.December);

//                var updateresearch = research.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateresearch.UpdateMonth(request.Research.January, request.Research.February, request.Research.March, request.Research.April, request.Research.May, request.Research.June, request.Research.July, request.Research.August, request.Research.September, request.Research.October, request.Research.November, request.Research.December);

//                var updatesecurityOperation = securityOperation.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatesecurityOperation.UpdateMonth(request.SecurityOperation.January, request.SecurityOperation.February, request.SecurityOperation.March, request.SecurityOperation.April, request.SecurityOperation.May, request.SecurityOperation.June, request.SecurityOperation.July, request.SecurityOperation.August, request.SecurityOperation.September, request.SecurityOperation.October, request.SecurityOperation.November, request.SecurityOperation.December);

//                var updatecompliance = compliance.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatecompliance.UpdateMonth(request.Compliance.January, request.Compliance.February, request.Compliance.March, request.Compliance.April, request.Compliance.May, request.Compliance.June, request.Compliance.July, request.Compliance.August, request.Compliance.September, request.Compliance.October, request.Compliance.November, request.Compliance.December);

//                var updateStockBroking = stockBroking.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateStockBroking.UpdateMonth(request.StockBroking.January, request.StockBroking.February, request.StockBroking.March, request.StockBroking.April, request.StockBroking.May, request.StockBroking.June, request.StockBroking.July, request.StockBroking.August, request.StockBroking.September, request.StockBroking.October, request.StockBroking.November, request.StockBroking.December);

//                var updatefinancialAdvisory = financialAdvisory.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefinancialAdvisory.UpdateMonth(request.FinancialAdvisory.January, request.FinancialAdvisory.February, request.FinancialAdvisory.March, request.FinancialAdvisory.April, request.FinancialAdvisory.May, request.FinancialAdvisory.June, request.FinancialAdvisory.July, request.FinancialAdvisory.August, request.FinancialAdvisory.September, request.FinancialAdvisory.October, request.FinancialAdvisory.November, request.FinancialAdvisory.December);
//                financialAdvisory.SaveChanges();
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
