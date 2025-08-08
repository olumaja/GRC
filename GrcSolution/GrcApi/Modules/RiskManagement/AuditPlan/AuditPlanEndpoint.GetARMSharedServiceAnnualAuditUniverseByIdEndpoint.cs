using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 02/04/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint get Annual Audit Universe By anualAuditUniverseId
*/
    public class GetARMSharedServiceAnnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to get ARMSharedService Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="sharedServiceAuditUniverse"></param>
        /// <param name="sharedServicecorporateStrategy"></param>
        /// <param name="sharedServicehcm"></param>
        /// <param name="sharedServiceprocurementandAdmin"></param>
        /// <param name="sharedServiceinternalControl"></param>
        /// <param name="sharedServiceacademy"></param>
        /// <param name="sharedServicelegal"></param>
        /// <param name="dataAna"></param>
        /// <param name="sharedServiceriskManagement"></param>
        /// <param name="sharedServicemcc"></param>
        /// <param name="sharedServiceit"></param>
        /// <param name="sharedServicetreasure"></param>
        /// <param name="sharedServiceCTO"></param>
        /// <param name="sharedServicecustomerExperience"></param>
        /// <param name="informationSecurity"></param>
        /// <param name="currentUserService"></param>
        /// <param name="finCtrl"></param>
        /// <param name="comp"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMSharedAuditUniverse> sharedServiceAuditUniverse, IRepository<ARMSharedAuditUniverseCorporatestrategy> sharedServicecorporateStrategy,
            IRepository<ARMSharedAuditUniverseHCM> sharedServicehcm, IRepository<ARMSharedAuditUniverseProcurementAndAdmin> sharedServiceprocurementandAdmin, IRepository<ARMSharedAuditUniverseInternalControl> sharedServiceinternalControl,
            IRepository<ARMSharedAuditUniverseAcademy> sharedServiceacademy, IRepository<ARMSharedAuditUniverseLegal> sharedServicelegal, IRepository<ARMSharedAuditUniverseDataAnalytic> dataAna,
            IRepository<ARMSharedAuditUniverseRiskManagement> sharedServiceriskManagement, IRepository<ARMSharedAuditUniverseMCC> sharedServicemcc, IRepository<ARMSharedAuditUniverseIT> sharedServiceit,
            IRepository<ARMSharedAuditUniverseTreasury> sharedServicetreasure, IRepository<ARMSharedAuditUniverseCTO> sharedServiceCTO, IRepository<ARMSharedAuditUniverseCustomerExperience> sharedServicecustomerExperience,
            IRepository<ARMSharedAuditUniverseInformationSecurity> informationSecurity, ICurrentUserService currentUserService,
            IRepository<ARMSharedAuditUniverseFinancialControl> finCtrl, IRepository<ARMSharedAuditUniverseCompliance> comp,
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
                var getRating = annualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = sharedServiceAuditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMSharedService");
                }
                var getcomp = comp.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getfinCtrl = finCtrl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getcorporateStrategy = sharedServicecorporateStrategy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var gethcm = sharedServicehcm.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var gettreasure = sharedServicetreasure.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getriskManagement = sharedServiceriskManagement.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getacademy = sharedServiceacademy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getCTO = sharedServiceCTO.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getIT = sharedServiceit.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getMCC = sharedServicemcc.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getlegal = sharedServicelegal.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getinternalControl = sharedServiceinternalControl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getprocurementandAdmin = sharedServiceprocurementandAdmin.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getdataAna = dataAna.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getcustomerExperience = sharedServicecustomerExperience.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getinformationSecurity = informationSecurity.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                GetARMSharedServiceAuditUniverseSummary resp = new GetARMSharedServiceAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,
                    HCM = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = gethcm.BusinessManagerConcern,
                        DirectorConcern = gethcm.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = gethcm.Recommentation,
                        RiskScore2 = gethcm.RiskScore,
                        RiskRating = gethcm.RiskRating,
                        Recommentation = gethcm.Recommentation,
                        January = gethcm.January,
                        February = gethcm.February,
                        March = gethcm.March,
                        April = gethcm.April,
                        May = gethcm.May,
                        June = gethcm.June,
                        July = gethcm.July,
                        August = gethcm.August,
                        September = gethcm.September,
                        October = gethcm.October,
                        November = gethcm.November,
                        December = gethcm.December
                    },
                    DataAnalytic = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getdataAna.BusinessManagerConcern,
                        DirectorConcern = getdataAna.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getdataAna.Recommentation,
                        RiskScore2 = getdataAna.RiskScore,
                        RiskRating = getdataAna.RiskRating,
                        Recommentation = getdataAna.Recommentation,
                        January = getdataAna.January,
                        February = getdataAna.February,
                        March = getdataAna.March,
                        April = getdataAna.April,
                        May = getdataAna.May,
                        June = getdataAna.June,
                        July = getdataAna.July,
                        August = getdataAna.August,
                        September = getdataAna.September,
                        October = getdataAna.October,
                        November = getdataAna.November,
                        December = getdataAna.December
                    },
                    FinancialControl = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getfinCtrl.BusinessManagerConcern,
                        DirectorConcern = getfinCtrl.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getfinCtrl.Recommentation,
                        RiskScore2 = getfinCtrl.RiskScore,
                        RiskRating = getfinCtrl.RiskRating,
                        Recommentation = getfinCtrl.Recommentation,
                        January = getfinCtrl.January,
                        February = getfinCtrl.February,
                        March = getfinCtrl.March,
                        April = getfinCtrl.April,
                        May = getfinCtrl.May,
                        June = getfinCtrl.June,
                        July = getfinCtrl.July,
                        August = getfinCtrl.August,
                        September = getfinCtrl.September,
                        October = getfinCtrl.October,
                        November = getfinCtrl.November,
                        December = getfinCtrl.December
                    },
                    Legal = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getlegal.BusinessManagerConcern,
                        DirectorConcern = getlegal.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getlegal.Recommentation,
                        RiskScore2 = getlegal.RiskScore,
                        RiskRating = getlegal.RiskRating,
                        Recommentation = getlegal.Recommentation,
                        January = getlegal.January,
                        February = getlegal.February,
                        March = getlegal.March,
                        April = getlegal.April,
                        May = getlegal.May,
                        June = getlegal.June,
                        July = getlegal.July,
                        August = getlegal.August,
                        September = getlegal.September,
                        October = getlegal.October,
                        November = getlegal.November,
                        December = getlegal.December
                    },
                    IT = new AuditUniverseSummary
                    {

                        BusinessManagerConcern = getIT.BusinessManagerConcern,
                        DirectorConcern = getIT.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getIT.Recommentation,
                        RiskScore2 = getIT.RiskScore,
                        RiskRating = getIT.RiskRating,
                        Recommentation = getIT.Recommentation,
                        January = getIT.January,
                        February = getIT.February,
                        March = getIT.March,
                        April = getIT.April,
                        May = getIT.May,
                        June = getIT.June,
                        July = getIT.July,
                        August = getIT.August,
                        September = getIT.September,
                        October = getIT.October,
                        November = getIT.November,
                        December = getIT.December
                    },
                    InternalControl = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getinternalControl.BusinessManagerConcern,
                        DirectorConcern = getinternalControl.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getinternalControl.Recommentation,
                        RiskScore2 = getinternalControl.RiskScore,
                        RiskRating = getinternalControl.RiskRating,
                        Recommentation = getinternalControl.Recommentation,
                        January = getinternalControl.January,
                        February = getinternalControl.February,
                        March = getinternalControl.March,
                        April = getinternalControl.April,
                        May = getinternalControl.May,
                        June = getinternalControl.June,
                        July = getinternalControl.July,
                        August = getinternalControl.August,
                        September = getinternalControl.September,
                        October = getinternalControl.October,
                        November = getinternalControl.November,
                        December = getinternalControl.December
                    },
                    CTO = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getCTO.BusinessManagerConcern,
                        DirectorConcern = getCTO.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getCTO.Recommentation,
                        RiskScore2 = getCTO.RiskScore,
                        RiskRating = getCTO.RiskRating,
                        Recommentation = getCTO.Recommentation,
                        January = getCTO.January,
                        February = getCTO.February,
                        March = getCTO.March,
                        April = getCTO.April,
                        May = getCTO.May,
                        June = getCTO.June,
                        July = getCTO.July,
                        August = getCTO.August,
                        September = getCTO.September,
                        October = getCTO.October,
                        November = getCTO.November,
                        December = getCTO.December
                    },
                    RiskManagement = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getriskManagement.BusinessManagerConcern,
                        DirectorConcern = getriskManagement.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getriskManagement.Recommentation,
                        RiskScore2 = getriskManagement.RiskScore,
                        RiskRating = getriskManagement.RiskRating,
                        Recommentation = getriskManagement.Recommentation,
                        January = getriskManagement.January,
                        February = getriskManagement.February,
                        March = getriskManagement.March,
                        April = getriskManagement.April,
                        May = getriskManagement.May,
                        June = getriskManagement.June,
                        July = getriskManagement.July,
                        August = getriskManagement.August,
                        September = getriskManagement.September,
                        October = getriskManagement.October,
                        November = getriskManagement.November,
                        December = getriskManagement.December
                    },
                    CorporateStrategy = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getcorporateStrategy.BusinessManagerConcern,
                        DirectorConcern = getcorporateStrategy.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getcorporateStrategy.Recommentation,
                        RiskScore2 = getcorporateStrategy.RiskScore,
                        RiskRating = getcorporateStrategy.RiskRating,
                        Recommentation = getcorporateStrategy.Recommentation,
                        January = getcorporateStrategy.January,
                        February = getcorporateStrategy.February,
                        March = getcorporateStrategy.March,
                        April = getcorporateStrategy.April,
                        May = getcorporateStrategy.May,
                        June = getcorporateStrategy.June,
                        July = getcorporateStrategy.July,
                        August = getcorporateStrategy.August,
                        September = getcorporateStrategy.September,
                        October = getcorporateStrategy.October,
                        November = getcorporateStrategy.November,
                        December = getcorporateStrategy.December
                    },
                    Academy = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getacademy.BusinessManagerConcern,
                        DirectorConcern = getacademy.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getacademy.Recommentation,
                        RiskScore2 = getacademy.RiskScore,
                        RiskRating = getacademy.RiskRating,
                        Recommentation = getacademy.Recommentation,
                        January = getacademy.January,
                        February = getacademy.February,
                        March = getacademy.March,
                        April = getacademy.April,
                        May = getacademy.May,
                        June = getacademy.June,
                        July = getacademy.July,
                        August = getacademy.August,
                        September = getacademy.September,
                        October = getacademy.October,
                        November = getacademy.November,
                        December = getacademy.December
                    },
                    Compliance = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getcomp.BusinessManagerConcern,
                        DirectorConcern = getcomp.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getcomp.Recommentation,
                        RiskScore2 = getcomp.RiskScore,
                        RiskRating = getcomp.RiskRating,
                        Recommentation = getcomp.Recommentation,
                        January = getcomp.January,
                        February = getcomp.February,
                        March = getcomp.March,
                        April = getcomp.April,
                        May = getcomp.May,
                        June = getcomp.June,
                        July = getcomp.July,
                        August = getcomp.August,
                        September = getcomp.September,
                        October = getcomp.October,
                        November = getcomp.November,
                        December = getcomp.December
                    },
                    ProcurementandAdmin = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getprocurementandAdmin.BusinessManagerConcern,
                        DirectorConcern = getprocurementandAdmin.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getprocurementandAdmin.Recommentation,
                        RiskScore2 = getprocurementandAdmin.RiskScore,
                        RiskRating = getprocurementandAdmin.RiskRating,
                        Recommentation = getprocurementandAdmin.Recommentation,
                        January = getprocurementandAdmin.January,
                        February = getprocurementandAdmin.February,
                        March = getprocurementandAdmin.March,
                        April = getprocurementandAdmin.April,
                        May = getprocurementandAdmin.May,
                        June = getprocurementandAdmin.June,
                        July = getprocurementandAdmin.July,
                        August = getprocurementandAdmin.August,
                        September = getprocurementandAdmin.September,
                        October = getprocurementandAdmin.October,
                        November = getprocurementandAdmin.November,
                        December = getprocurementandAdmin.December
                    },
                    CustomerExperience = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getcustomerExperience.BusinessManagerConcern,
                        DirectorConcern = getcustomerExperience.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getcustomerExperience.Recommentation,
                        RiskScore2 = getcustomerExperience.RiskScore,
                        RiskRating = getcustomerExperience.RiskRating,
                        Recommentation = getcustomerExperience.Recommentation,
                        January = getcustomerExperience.January,
                        February = getcustomerExperience.February,
                        March = getcustomerExperience.March,
                        April = getcustomerExperience.April,
                        May = getcustomerExperience.May,
                        June = getcustomerExperience.June,
                        July = getcustomerExperience.July,
                        August = getcustomerExperience.August,
                        September = getcustomerExperience.September,
                        October = getcustomerExperience.October,
                        November = getcustomerExperience.November,
                        December = getcustomerExperience.December
                    },
                    MCC = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getMCC.BusinessManagerConcern,
                        DirectorConcern = getMCC.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getMCC.Recommentation,
                        RiskScore2 = getMCC.RiskScore,
                        RiskRating = getMCC.RiskRating,
                        Recommentation = getMCC.Recommentation,
                        January = getMCC.January,
                        February = getMCC.February,
                        March = getMCC.March,
                        April = getMCC.April,
                        May = getMCC.May,
                        June = getMCC.June,
                        July = getMCC.July,
                        August = getMCC.August,
                        September = getMCC.September,
                        October = getMCC.October,
                        November = getMCC.November,
                        December = getMCC.December
                    },
                    InformationSecurity = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getinformationSecurity.BusinessManagerConcern,
                        DirectorConcern = getinformationSecurity.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getinformationSecurity.Recommentation,
                        RiskScore2 = getinformationSecurity.RiskScore,
                        RiskRating = getinformationSecurity.RiskRating,
                        Recommentation = getinformationSecurity.Recommentation,
                        January = getinformationSecurity.January,
                        February = getinformationSecurity.February,
                        March = getinformationSecurity.March,
                        April = getinformationSecurity.April,
                        May = getinformationSecurity.May,
                        June = getinformationSecurity.June,
                        July = getinformationSecurity.July,
                        August = getinformationSecurity.August,
                        September = getinformationSecurity.September,
                        October = getinformationSecurity.October,
                        November = getinformationSecurity.November,
                        December = getinformationSecurity.December
                    },
                    Treasury = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = gettreasure.BusinessManagerConcern,
                        DirectorConcern = gettreasure.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = gettreasure.Recommentation,
                        RiskScore2 = gettreasure.RiskScore,
                        RiskRating = gettreasure.RiskRating,
                        Recommentation = gettreasure.Recommentation,
                        January = gettreasure.January,
                        February = gettreasure.February,
                        March = gettreasure.March,
                        April = gettreasure.April,
                        May = gettreasure.May,
                        June = gettreasure.June,
                        July = gettreasure.July,
                        August = gettreasure.August,
                        September = gettreasure.September,
                        October = gettreasure.October,
                        November = gettreasure.November,
                        December = gettreasure.December
                    }
                };
                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
