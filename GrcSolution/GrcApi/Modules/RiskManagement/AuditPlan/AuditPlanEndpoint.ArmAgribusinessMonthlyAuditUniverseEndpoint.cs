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
//    public class ArmAgribusinessMonthlyAuditUniverseEndpoint
//    {

//        /// <summary>
//        /// ARMAgribusiness Monthly audit universe       
//        /// </summary>
//        /// <param name="request"></param>
//        /// <param name="busnessRiskRating"></param>
//        /// <param name="annualaudit"></param>
//        /// <param name="req"></param>
//        /// <param name="armagri"></param>
//        /// <param name="aafml"></param>
//        /// <param name="financialControlAAFML"></param>
//        /// <param name="rfl"></param>
//        /// <param name="financialControlRF"></param>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public static async Task<IResult> HandleAsync(ARMAgribusinessMonthlyAuditReq request, IRepository<BusinessRiskRating> busnessRiskRating, IRepository<AnualAuditUniverseRiskRating> annualaudit,
//            IRepository<ARMAgribusinessAuditUniverse> req, IRepository<AuditUniverseARMAgribusiness> armagri, IRepository<AuditUniverseARMAgribusinessAAFML> aafml,
//            IRepository<AuditUniverseARMAgriFinancialControlAAFML> financialControlAAFML, IRepository<AuditUniverseARMAgribusinessRFL> rfl, IRepository<AuditUniverseARMAgriFinancialControlRFL> financialControlRF,
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
//                    return TypedResults.Ok($"The user has performed Monthly rating for the ARMAgribusiness with id '{getaudit.Id}' for the year {year}");
//                }

//                getaudit.Update(requesterName);

//                checkIfItHasBeenRated.Update(requesterName);

//                var updatearmagri = armagri.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatearmagri.UpdateMonth(request.ARMAgribusiness.January, request.ARMAgribusiness.February, request.ARMAgribusiness.March, request.ARMAgribusiness.April, request.ARMAgribusiness.May, request.ARMAgribusiness.June, request.ARMAgribusiness.July, request.ARMAgribusiness.August, request.ARMAgribusiness.September, request.ARMAgribusiness.October, request.ARMAgribusiness.November, request.ARMAgribusiness.December);

//                var updateaafml = aafml.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateaafml.UpdateMonth(request.AAFML.January, request.AAFML.February, request.AAFML.March, request.AAFML.April, request.AAFML.May, request.AAFML.June, request.AAFML.July, request.AAFML.August, request.AAFML.September, request.AAFML.October, request.AAFML.November, request.AAFML.December);

//                var updaterfl = rfl.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updaterfl.UpdateMonth(request.RFL.January, request.RFL.February, request.RFL.March, request.RFL.April, request.RFL.May, request.RFL.June, request.RFL.July, request.RFL.August, request.RFL.September, request.RFL.October, request.RFL.November, request.RFL.December);

//                var updatefinancialControlAAFML = financialControlAAFML.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefinancialControlAAFML.UpdateMonth(request.FinancialControlAAFML.January, request.FinancialControlAAFML.February, request.FinancialControlAAFML.March, request.FinancialControlAAFML.April, request.FinancialControlAAFML.May, request.FinancialControlAAFML.June, request.FinancialControlAAFML.July, request.FinancialControlAAFML.August, request.FinancialControlAAFML.September, request.FinancialControlAAFML.October, request.FinancialControlAAFML.November, request.FinancialControlAAFML.December);

//                var updatefinancialControlRF = financialControlRF.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefinancialControlRF.UpdateMonth(request.FinancialControlRFL.January, request.FinancialControlRFL.February, request.FinancialControlRFL.March, request.FinancialControlRFL.April, request.FinancialControlRFL.May, request.FinancialControlRFL.June, request.FinancialControlRFL.July, request.FinancialControlRFL.August, request.FinancialControlRFL.September, request.FinancialControlRFL.October, request.FinancialControlRFL.November, request.FinancialControlRFL.December);
//                financialControlRF.SaveChanges();
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
