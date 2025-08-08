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
//    public class ArmHillMonthlyAuditUniverseEndpoint
//    {
//        /// <summary>
//        /// ARMHill Monthly audit universe       
//        /// </summary>
//        /// <param name="request"></param>
//        /// <param name="annualaudit"></param>
//        /// <param name="req"></param>
//        /// <param name="armhill"></param>
//        /// <param name="investmentPortfolio"></param>
//        /// <param name="financialControl"></param>
//        /// <param name="compliance"></param>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public static async Task<IResult> HandleAsync(ARMHillMonthlyAuditReq request, IRepository<AnualAuditUniverseRiskRating> annualaudit,           
//            IRepository<ARMHillAuditUniverse> req, IRepository<AuditUniverseARMHill> armhill, IRepository<AuditUniverseARMHillInvestmentPortfolio> investmentPortfolio,
//            IRepository<AuditUniverseARMHillFinancialControl> financialControl, IRepository<AuditUniverseARMHillCompliance> compliance,
//            ClaimsPrincipal user)
//        {
//            try
//            {
//                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
//                var year = DateTime.Now.Year;
//                var getaudit = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == request.BusinessRiskRatingId && x.CreatedOnUtc.Year == year).FirstOrDefault();
//                var checkIfItHasBeenRated = req.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getaudit.Id && x.RequesterName == requesterName).FirstOrDefault();

//                if (checkIfItHasBeenRated != null)
//                {
//                    return TypedResults.Ok($"The user has performed Monthly rating for the ARMHill with id '{getaudit.Id}' for the year {year}");
//                }

//                getaudit.Update(requesterName);

//                checkIfItHasBeenRated.Update(requesterName);

//                var updatearmhill = armhill.GetContextByConditon(x => x.ARMHillAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatearmhill.UpdateMonth(request.ARMHill.January, request.ARMHill.February, request.ARMHill.March, request.ARMHill.April, request.ARMHill.May, request.ARMHill.June, request.ARMHill.July, request.ARMHill.August, request.ARMHill.September, request.ARMHill.October, request.ARMHill.November, request.ARMHill.December);

//                var updatefinancialControl = financialControl.GetContextByConditon(x => x.ARMHillAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefinancialControl.UpdateMonth(request.FinancialControl.January, request.FinancialControl.February, request.FinancialControl.March, request.FinancialControl.April, request.FinancialControl.May, request.FinancialControl.June, request.FinancialControl.July, request.FinancialControl.August, request.FinancialControl.September, request.FinancialControl.October, request.FinancialControl.November, request.FinancialControl.December);

//                var updateinvestmentPortfolio = investmentPortfolio.GetContextByConditon(x => x.ARMHillAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateinvestmentPortfolio.UpdateMonth(request.InvestmentPortfolio.January, request.InvestmentPortfolio.February, request.InvestmentPortfolio.March, request.InvestmentPortfolio.April, request.InvestmentPortfolio.May, request.InvestmentPortfolio.June, request.InvestmentPortfolio.July, request.InvestmentPortfolio.August, request.InvestmentPortfolio.September, request.InvestmentPortfolio.October, request.InvestmentPortfolio.November, request.InvestmentPortfolio.December);

//                var updatecompliance = compliance.GetContextByConditon(x => x.ARMHillAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatecompliance.UpdateMonth(request.Compliance.January, request.Compliance.February, request.Compliance.March, request.Compliance.April, request.Compliance.May, request.Compliance.June, request.Compliance.July, request.Compliance.August, request.Compliance.September, request.Compliance.October, request.Compliance.November, request.Compliance.December);
//                compliance.SaveChanges();
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
