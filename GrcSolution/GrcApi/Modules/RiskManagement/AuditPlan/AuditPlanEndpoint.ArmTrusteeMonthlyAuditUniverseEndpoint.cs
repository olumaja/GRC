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
//    public class ArmTrusteeMonthlyAuditUniverseEndpoint
//    {
//        /// <summary>
//        /// ARMTrustee Monthly audit universe       
//        /// </summary>
//        /// <param name="request"></param>
//        /// <param name="annualaudit"></param>
//        /// <param name="req"></param>
//        /// <param name="armtrustee"></param>
//        /// <param name="privateTrust"></param>
//        /// <param name="financialControl"></param>
//        /// <param name="commercialTrust"></param>
//        /// <param name="compliance"></param>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public static async Task<IResult> HandleAsync(ARMTrusteeMonthlyAuditReq request, IRepository<AnualAuditUniverseRiskRating> annualaudit,
//            IRepository<ARMTrusteeAuditUniverse> req, IRepository<AuditUniverseARMTrustee> armtrustee, IRepository<AuditUniverseARMTrusteePrivateTrust> privateTrust,
//            IRepository<AuditUniverseARMTrusteeFinancialControl> financialControl, IRepository<AuditUniverseARMTrusteeCommercialTrust> commercialTrust,
//            IRepository<AuditUniverseARMTrusteeCompliance> compliance, IRepository<BusinessRiskRating> busnessRiskRating,
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

//                var updatearmtrustee = armtrustee.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatearmtrustee.UpdateMonth(request.ARMTrustee.January, request.ARMTrustee.February, request.ARMTrustee.March, request.ARMTrustee.April, request.ARMTrustee.May, request.ARMTrustee.June, request.ARMTrustee.July, request.ARMTrustee.August, request.ARMTrustee.September, request.ARMTrustee.October, request.ARMTrustee.November, request.ARMTrustee.December);

//                var updatefinancialControl = financialControl.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatefinancialControl.UpdateMonth(request.FinancialControl.January, request.FinancialControl.February, request.FinancialControl.March, request.FinancialControl.April, request.FinancialControl.May, request.FinancialControl.June, request.FinancialControl.July, request.FinancialControl.August, request.FinancialControl.September, request.FinancialControl.October, request.FinancialControl.November, request.FinancialControl.December);

//                var updateprivateTrust = privateTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateprivateTrust.UpdateMonth(request.PrivateTrust.January, request.PrivateTrust.February, request.PrivateTrust.March, request.PrivateTrust.April, request.PrivateTrust.May, request.PrivateTrust.June, request.PrivateTrust.July, request.PrivateTrust.August, request.PrivateTrust.September, request.PrivateTrust.October, request.PrivateTrust.November, request.PrivateTrust.December);

//                var updatecommercialTrust = commercialTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatecommercialTrust.UpdateMonth(request.CommercialTrust.January, request.CommercialTrust.February, request.CommercialTrust.March, request.CommercialTrust.April, request.CommercialTrust.May, request.CommercialTrust.June, request.CommercialTrust.July, request.CommercialTrust.August, request.CommercialTrust.September, request.CommercialTrust.October, request.CommercialTrust.November, request.CommercialTrust.December);

//                var updatecompliance = compliance.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
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
