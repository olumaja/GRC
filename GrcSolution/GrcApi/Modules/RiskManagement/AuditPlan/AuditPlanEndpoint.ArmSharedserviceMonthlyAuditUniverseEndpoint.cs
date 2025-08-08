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
//    public class ArmSharedserviceMonthlyAuditUniverseEndpoint
//    {
//        /// <summary>
//        /// ARMSharedService Monthly audit universe       
//        /// </summary>
//        /// <param name="request"></param>
//        /// <param name="busnessRiskRating"></param>
//        /// <param name="annualaudit"></param>
//        /// <param name="req"></param>
//        /// <param name="sharedservice"></param>
//        /// <param name="hcm"></param>
//        /// <param name="procurementandAdmin"></param>
//        /// <param name="corporateStrategy"></param>
//        /// <param name="academy"></param>
//        /// <param name="legal"></param>
//        /// <param name="digitalFinService"></param>
//        /// <param name="riskManagement"></param>
//        /// <param name="mcc"></param>
//        /// <param name="internalControl"></param>
//        /// <param name="treasure"></param>
//        /// <param name="ctu"></param>
//        /// <param name="it"></param>
//        /// <param name="customerExperience"></param>
//        /// <param name="infoSec"></param>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public static async Task<IResult> HandleAsync(ARMSharedServiceMonthlyAuditReq request, IRepository<BusinessRiskRating> busnessRiskRating,
//            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMSharedServiceAuditUniverse> req, IRepository<AuditUniverseARMSharedService> sharedservice,
//            IRepository<AuditUniverseARMSharedServiceHCM> hcm, IRepository<AuditUniverseARMSharedServiceProcurementandAdmin> procurementandAdmin, IRepository<AuditUniverseARMSharedServiceCorporateStrategy> corporateStrategy,
//            IRepository<AuditUniverseARMSharedServiceAcademy> academy, IRepository<AuditUniverseARMSharedServiceLegal> legal, IRepository<AuditUniverseARMSharedServiceDigitalFinService> digitalFinService,
//            IRepository<AuditUniverseARMSharedServiceRiskManagement> riskManagement, IRepository<AuditUniverseARMSharedServiceMCC> mcc, IRepository<AuditUniverseARMSharedServiceInternalControl> internalControl,
//            IRepository<AuditUniverseARMSharedServiceTreasury> treasury, IRepository<AuditUniverseARMSharedServiceCTU> ctu, IRepository<AuditUniverseARMSharedServiceIT> it,
//            IRepository<AuditUniverseARMSharedServiceCustomerExperience> customerExperience, IRepository<AuditUniverseARMSharedServiceInformationSecurity> infoSec,
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
//                    return TypedResults.Ok($"The user has performed Monthly rating for the ARMSharedservice with id '{getaudit.Id}' for the year {year}");
//                }

//                getaudit.Update(requesterName);

//                checkIfItHasBeenRated.Update(requesterName);

//                var updatesharedservice = sharedservice.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatesharedservice.UpdateMonth(request.ArmSharedservice.January, request.ArmSharedservice.February, request.ArmSharedservice.March, request.ArmSharedservice.April, request.ArmSharedservice.May, request.ArmSharedservice.June, request.ArmSharedservice.July, request.ArmSharedservice.August, request.ArmSharedservice.September, request.ArmSharedservice.October, request.ArmSharedservice.November, request.ArmSharedservice.December);

//                var updateresearch = hcm.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateresearch.UpdateMonth(request.HCM.January, request.HCM.February, request.HCM.March, request.HCM.April, request.HCM.May, request.HCM.June, request.HCM.July, request.HCM.August, request.HCM.September, request.HCM.October, request.HCM.November, request.HCM.December);

//                var updatetreasury = treasury.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatetreasury.UpdateMonth(request.Treasury.January, request.Treasury.February, request.Treasury.March, request.Treasury.April, request.Treasury.May, request.Treasury.June, request.Treasury.July, request.Treasury.August, request.Treasury.September, request.Treasury.October, request.Treasury.November, request.Treasury.December);

//                var updateprocurementandAdmin = procurementandAdmin.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateprocurementandAdmin.UpdateMonth(request.ProcurementandAdmin.January, request.ProcurementandAdmin.February, request.ProcurementandAdmin.March, request.ProcurementandAdmin.April, request.ProcurementandAdmin.May, request.ProcurementandAdmin.June, request.ProcurementandAdmin.July, request.ProcurementandAdmin.August, request.ProcurementandAdmin.September, request.ProcurementandAdmin.October, request.ProcurementandAdmin.November, request.ProcurementandAdmin.December);

//                var updateacademy = academy.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateacademy.UpdateMonth(request.Academy.January, request.Academy.February, request.Academy.March, request.Academy.April, request.Academy.May, request.Academy.June, request.Academy.July, request.Academy.August, request.Academy.September, request.Academy.October, request.Academy.November, request.Academy.December);

//                var updatecorporateStrategy = corporateStrategy.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatecorporateStrategy.UpdateMonth(request.CorporateStrategy.January, request.CorporateStrategy.February, request.CorporateStrategy.March, request.CorporateStrategy.April, request.CorporateStrategy.May, request.CorporateStrategy.June, request.CorporateStrategy.July, request.CorporateStrategy.August, request.CorporateStrategy.September, request.CorporateStrategy.October, request.CorporateStrategy.November, request.CorporateStrategy.December);

//                var updatelegal = legal.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatelegal.UpdateMonth(request.Legal.January, request.Legal.February, request.Legal.March, request.Legal.April, request.Legal.May, request.Legal.June, request.Legal.July, request.Legal.August, request.Legal.September, request.Legal.October, request.Legal.November, request.Legal.December);

//                var updatedigitalFinService = digitalFinService.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatedigitalFinService.UpdateMonth(request.DigitalFinService.January, request.DigitalFinService.February, request.DigitalFinService.March, request.DigitalFinService.April, request.DigitalFinService.May, request.DigitalFinService.June, request.DigitalFinService.July, request.DigitalFinService.August, request.DigitalFinService.September, request.DigitalFinService.October, request.DigitalFinService.November, request.DigitalFinService.December);

//                var updatectu = ctu.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatectu.UpdateMonth(request.CTU.January, request.CTU.February, request.CTU.March, request.CTU.April, request.CTU.May, request.CTU.June, request.CTU.July, request.CTU.August, request.CTU.September, request.CTU.October, request.CTU.November, request.CTU.December);

//                var updateMCC = mcc.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateMCC.UpdateMonth(request.MCC.January, request.MCC.February, request.MCC.March, request.MCC.April, request.MCC.May, request.MCC.June, request.MCC.July, request.MCC.August, request.MCC.September, request.MCC.October, request.MCC.November, request.MCC.December);

//                var updateIT = it.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateIT.UpdateMonth(request.IT.January, request.IT.February, request.IT.March, request.IT.April, request.IT.May, request.IT.June, request.IT.July, request.IT.August, request.IT.September, request.IT.October, request.IT.November, request.IT.December);

//                var updateInternalControl = internalControl.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateInternalControl.UpdateMonth(request.InternalControl.January, request.InternalControl.February, request.InternalControl.March, request.InternalControl.April, request.InternalControl.May, request.InternalControl.June, request.InternalControl.July, request.InternalControl.August, request.InternalControl.September, request.InternalControl.October, request.InternalControl.November, request.InternalControl.December);

//                var updatecustomerExperience = customerExperience.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updatecustomerExperience.UpdateMonth(request.CustomerExperience.January, request.CustomerExperience.February, request.CustomerExperience.March, request.CustomerExperience.April, request.CustomerExperience.May, request.CustomerExperience.June, request.CustomerExperience.July, request.CustomerExperience.August, request.CustomerExperience.September, request.CustomerExperience.October, request.CustomerExperience.November, request.CustomerExperience.December);

//                var updateinfoSec = infoSec.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateinfoSec.UpdateMonth(request.InformationSecurity.January, request.InformationSecurity.February, request.InformationSecurity.March, request.InformationSecurity.April, request.InformationSecurity.May, request.InformationSecurity.June, request.InformationSecurity.July, request.InformationSecurity.August, request.InformationSecurity.September, request.InformationSecurity.October, request.InformationSecurity.November, request.InformationSecurity.December);

//                var updateRiskManagement = riskManagement.GetContextByConditon(x => x.ARMSharedServiceAuditUniverseId == checkIfItHasBeenRated.Id).FirstOrDefault();
//                updateRiskManagement.UpdateMonth(request.RiskManagement.January, request.RiskManagement.February, request.RiskManagement.March, request.RiskManagement.April, request.RiskManagement.May, request.RiskManagement.June, request.RiskManagement.July, request.RiskManagement.August, request.RiskManagement.September, request.RiskManagement.October, request.RiskManagement.November, request.RiskManagement.December);
//                riskManagement.SaveChanges();
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
