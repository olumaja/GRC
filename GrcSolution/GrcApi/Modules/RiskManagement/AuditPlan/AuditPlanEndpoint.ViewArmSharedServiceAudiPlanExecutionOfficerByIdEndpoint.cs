using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 26/04/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * This endpoint get Annual Audit Universe By anualAuditUniverseId
  */
    public class ViewArmSharedServiceAudiPlanExecutionOfficerByIdEndpoint
    {
        /// <summary>
        /// Endpoint to get ARMSharedService Audit Execution Plan By Id
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
        /// <param name="commenceEng"></param>
        /// <param name="finCtrl"></param>
        /// <param name="compl"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMSharedAuditUniverse> sharedServiceAuditUniverse, IRepository<ARMSharedAuditUniverseCorporatestrategy> sharedServicecorporateStrategy,
            IRepository<ARMSharedAuditUniverseHCM> sharedServicehcm, IRepository<ARMSharedAuditUniverseProcurementAndAdmin> sharedServiceprocurementandAdmin, IRepository<ARMSharedAuditUniverseInternalControl> sharedServiceinternalControl,
            IRepository<ARMSharedAuditUniverseAcademy> sharedServiceacademy, IRepository<ARMSharedAuditUniverseLegal> sharedServicelegal, IRepository<ARMSharedAuditUniverseDataAnalytic> dataAna,
            IRepository<ARMSharedAuditUniverseRiskManagement> sharedServiceriskManagement, IRepository<ARMSharedAuditUniverseMCC> sharedServicemcc, IRepository<ARMSharedAuditUniverseIT> sharedServiceit,
            IRepository<ARMSharedAuditUniverseTreasury> sharedServicetreasure, IRepository<ARMSharedAuditUniverseCTO> sharedServiceCTO, IRepository<ARMSharedAuditUniverseCustomerExperience> sharedServicecustomerExperience,
            IRepository<ARMSharedAuditUniverseInformationSecurity> informationSecurity, IRepository<CommenceEngagementAuditexecution> commenceEng,
            IRepository<ARMSharedAuditUniverseFinancialControl> finCtrl, IRepository<ARMSharedAuditUniverseCompliance> compl,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                Guid getcommenceEngId = Guid.Empty;
                var engagementPlan = BusinessRiskRatingStatus.Pending.ToString();
                var workPaper = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatus = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEng = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "HCM").FirstOrDefault();
                if (getCommenceEng != null)
                {
                    engagementPlan = getCommenceEng.EngagementPlan.ToString();
                    workPaper = getCommenceEng.WorkPaper.ToString();
                    findingStatus = getCommenceEng.Findingstatus.ToString();
                    getcommenceEngId = getCommenceEng.Id;
                }

                Guid getcommenceEngIdFtrl = Guid.Empty;
                var engagementPlanFtrl = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperFtrl = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusFtrl = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngFtrl = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Financial Control").FirstOrDefault();
                if (getCommenceEngFtrl != null)
                {
                    engagementPlanFtrl = getCommenceEngFtrl.EngagementPlan.ToString();
                    workPaperFtrl = getCommenceEngFtrl.WorkPaper.ToString();
                    findingStatusFtrl = getCommenceEngFtrl.Findingstatus.ToString();
                    getcommenceEngIdFtrl = getCommenceEngFtrl.Id;
                }

                Guid getcommenceEngIdComp = Guid.Empty;
                var engagementPlanComp = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperComp = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusComp = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngComp = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Compliance").FirstOrDefault();
                if (getCommenceEngComp != null)
                {
                    engagementPlanComp = getCommenceEngComp.EngagementPlan.ToString();
                    workPaperComp = getCommenceEngComp.WorkPaper.ToString();
                    findingStatusComp = getCommenceEngComp.Findingstatus.ToString();
                    getcommenceEngIdComp = getCommenceEngComp.Id;
                }

                Guid getcommenceEngIdLegal = Guid.Empty;
                var engagementPlanLegal = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperLegal = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusLegal = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngLegal = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Legal").FirstOrDefault();
                if (getCommenceEngLegal != null)
                {
                    engagementPlanLegal = getCommenceEngLegal.EngagementPlan.ToString();
                    workPaperLegal = getCommenceEngLegal.WorkPaper.ToString();
                    findingStatusLegal = getCommenceEngLegal.Findingstatus.ToString();
                    getcommenceEngIdLegal = getCommenceEngLegal.Id;
                }

                Guid getcommenceEngIdIT = Guid.Empty;
                var engagementPlanIT = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperIT = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusIT = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngIT = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "IT").FirstOrDefault();
                if (getCommenceEngIT != null)
                {
                    engagementPlanIT = getCommenceEngIT.EngagementPlan.ToString();
                    workPaperIT = getCommenceEngIT.WorkPaper.ToString();
                    findingStatusIT = getCommenceEngIT.Findingstatus.ToString();
                    getcommenceEngIdIT = getCommenceEngIT.Id;
                }
                
                Guid getcommenceEngIdMCC = Guid.Empty;
                var engagementPlanMCC = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperMCC = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusMCC = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngMCC = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "MCC").FirstOrDefault();
                if (getCommenceEngMCC != null)
                {
                    engagementPlanMCC = getCommenceEngMCC.EngagementPlan.ToString();
                    workPaperMCC = getCommenceEngMCC.WorkPaper.ToString();
                    findingStatusMCC = getCommenceEngMCC.Findingstatus.ToString();
                    getcommenceEngIdMCC = getCommenceEngMCC.Id;
                }

                Guid getcommenceEngIdIntCtrl = Guid.Empty;
                var engagementPlanIntCtrl = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperIntCtrl = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusIntCtrl = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngIntCtrl = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Internal Control").FirstOrDefault();
                if (getCommenceEngIntCtrl != null)
                {
                    engagementPlanIntCtrl = getCommenceEngIntCtrl.EngagementPlan.ToString();
                    workPaperIntCtrl = getCommenceEngIntCtrl.WorkPaper.ToString();
                    findingStatusIntCtrl = getCommenceEngIntCtrl.Findingstatus.ToString();
                    getcommenceEngIdIntCtrl = getCommenceEngIntCtrl.Id;
                }

                Guid getcommenceEngIdCTO = Guid.Empty;
                var engagementPlanCTO = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperCTO = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusCTO = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngCTO = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "CTO").FirstOrDefault();
                if (getCommenceEngCTO != null)
                {
                    engagementPlanCTO = getCommenceEngCTO.EngagementPlan.ToString();
                    workPaperCTO = getCommenceEngCTO.WorkPaper.ToString();
                    findingStatusCTO = getCommenceEngCTO.Findingstatus.ToString();
                    getcommenceEngIdCTO = getCommenceEngCTO.Id;
                }

                Guid getcommenceEngIdRisk = Guid.Empty;
                var engagementPlanRisk = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperRisk = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusRisk = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngRisk = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Risk Management").FirstOrDefault();
                if (getCommenceEngRisk != null)
                {
                    engagementPlanRisk = getCommenceEngRisk.EngagementPlan.ToString();
                    workPaperRisk = getCommenceEngRisk.WorkPaper.ToString();
                    findingStatusRisk = getCommenceEngRisk.Findingstatus.ToString();
                    getcommenceEngIdRisk = getCommenceEngRisk.Id;
                }

                Guid getcommenceEngIdCorp = Guid.Empty;
                var engagementPlanCorp = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperCorp = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusCorp = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngCorp = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Corporate Strategy").FirstOrDefault();
                if (getCommenceEngCorp != null)
                {
                    engagementPlanCorp = getCommenceEngCorp.EngagementPlan.ToString();
                    workPaperCorp = getCommenceEngCorp.WorkPaper.ToString();
                    findingStatusCorp = getCommenceEngCorp.Findingstatus.ToString();
                    getcommenceEngIdCorp = getCommenceEngCorp.Id;
                }

                Guid getcommenceEngIdAca = Guid.Empty;
                var engagementPlanAca = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperAca = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusAca = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngAca = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Academy").FirstOrDefault();
                if (getCommenceEngAca != null)
                {
                    engagementPlanAca = getCommenceEngAca.EngagementPlan.ToString();
                    workPaperAca = getCommenceEngAca.WorkPaper.ToString();
                    findingStatusAca = getCommenceEngAca.Findingstatus.ToString();
                    getcommenceEngIdAca = getCommenceEngAca.Id;
                }

                Guid getcommenceEngIdData = Guid.Empty;
                var engagementPlanData = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperData = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusData = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngData = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Data Analytic").FirstOrDefault();
                if (getCommenceEngData != null)
                {
                    engagementPlanData = getCommenceEngData.EngagementPlan.ToString();
                    workPaperData = getCommenceEngData.WorkPaper.ToString();
                    findingStatusData = getCommenceEngData.Findingstatus.ToString();
                    getcommenceEngIdData = getCommenceEngData.Id;
                }

                Guid getcommenceEngIdPro = Guid.Empty;
                var engagementPlanPro = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperPro = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusPro = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngPro = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Procurement and Admin").FirstOrDefault();
                if (getCommenceEngPro != null)
                {
                    engagementPlanPro = getCommenceEngPro.EngagementPlan.ToString();
                    workPaperPro = getCommenceEngPro.WorkPaper.ToString();
                    findingStatusPro = getCommenceEngPro.Findingstatus.ToString();
                    getcommenceEngIdPro = getCommenceEngPro.Id;
                }

                Guid getcommenceEngIdCus = Guid.Empty;
                var engagementPlanCus = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperCus = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusCus = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngCus = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Customer Experience").FirstOrDefault();
                if (getCommenceEngCus != null)
                {
                    engagementPlanCus = getCommenceEngCus.EngagementPlan.ToString();
                    workPaperCus = getCommenceEngCus.WorkPaper.ToString();
                    findingStatusCus = getCommenceEngCus.Findingstatus.ToString();
                    getcommenceEngIdCus = getCommenceEngCus.Id;
                }

                Guid getcommenceEngIdInfo = Guid.Empty;
                var engagementPlanInfo = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperInfo = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusInfo = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngInfo = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Information Security").FirstOrDefault();
                if (getCommenceEngInfo != null)
                {
                    engagementPlanInfo = getCommenceEngInfo.EngagementPlan.ToString();
                    workPaperInfo = getCommenceEngInfo.WorkPaper.ToString();
                    findingStatusInfo = getCommenceEngInfo.Findingstatus.ToString();
                    getcommenceEngIdInfo = getCommenceEngInfo.Id;
                }

                Guid getcommenceEngIdTre = Guid.Empty;
                var engagementPlanTre = BusinessRiskRatingStatus.Pending.ToString();
                var workPaperTre = BusinessRiskRatingStatus.Pending.ToString();
                var findingStatusTre = BusinessRiskRatingStatus.Pending.ToString();
                var getCommenceEngTre = commenceEng.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAuditRating.AnualAuditUniverseRiskRatingId && x.Team == "Treasury").FirstOrDefault();
                if (getCommenceEngTre != null)
                {
                    engagementPlanTre = getCommenceEngTre.EngagementPlan.ToString();
                    workPaperTre = getCommenceEngTre.WorkPaper.ToString();
                    findingStatusTre = getCommenceEngTre.Findingstatus.ToString();
                    getcommenceEngIdTre = getCommenceEngTre.Id;
                }
               
                var getcorporateStrategy = sharedServicecorporateStrategy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthRes = "January";
                string recommendationRes = "Full Scope";
                if (!string.IsNullOrEmpty(getcorporateStrategy.January))
                {
                    monthRes = "January";
                    recommendationRes = getcorporateStrategy.January;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.February))
                {
                    monthRes = "February";
                    recommendationRes = getcorporateStrategy.February;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.March))
                {
                    monthRes = "March";
                    recommendationRes = getcorporateStrategy.March;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.April))
                {
                    monthRes = "April";
                    recommendationRes = getcorporateStrategy.April;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.May))
                {
                    monthRes = "May";
                    recommendationRes = getcorporateStrategy.May;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.June))
                {
                    monthRes = "June";
                    recommendationRes = getcorporateStrategy.June;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.July))
                {
                    monthRes = "July";
                    recommendationRes = getcorporateStrategy.July;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.August))
                {
                    monthRes = "August";
                    recommendationRes = getcorporateStrategy.August;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.September))
                {
                    monthRes = "September";
                    recommendationRes = getcorporateStrategy.September;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.October))
                {
                    monthRes = "October";
                    recommendationRes = getcorporateStrategy.October;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.November))
                {
                    monthRes = "November";
                    recommendationRes = getcorporateStrategy.November;
                }
                if (!string.IsNullOrEmpty(getcorporateStrategy.December))
                {
                    monthRes = "December";
                    recommendationRes = getcorporateStrategy.December;
                }

                var gethcm = sharedServicehcm.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthHcm = "January";
                string recommendationHcm = "Full Scope";
                if (!string.IsNullOrEmpty(gethcm.January))
                {
                    monthHcm = "January";
                    recommendationHcm = gethcm.January;
                }
                if (!string.IsNullOrEmpty(gethcm.February))
                {
                    monthHcm = "February";
                    recommendationHcm = gethcm.February;
                }
                if (!string.IsNullOrEmpty(gethcm.March))
                {
                    monthHcm = "March";
                    recommendationHcm = gethcm.March;
                }
                if (!string.IsNullOrEmpty(gethcm.April))
                {
                    monthHcm = "April";
                    recommendationHcm = gethcm.April;
                }
                if (!string.IsNullOrEmpty(gethcm.May))
                {
                    monthHcm = "May";
                    recommendationHcm = gethcm.May;
                }
                if (!string.IsNullOrEmpty(gethcm.June))
                {
                    monthHcm = "June";
                    recommendationHcm = gethcm.June;
                }
                if (!string.IsNullOrEmpty(gethcm.July))
                {
                    monthHcm = "July";
                    recommendationHcm = gethcm.July;
                }
                if (!string.IsNullOrEmpty(gethcm.August))
                {
                    monthHcm = "August";
                    recommendationHcm = gethcm.August;
                }
                if (!string.IsNullOrEmpty(gethcm.September))
                {
                    monthHcm = "September";
                    recommendationHcm = gethcm.September;
                }
                if (!string.IsNullOrEmpty(gethcm.October))
                {
                    monthHcm = "October";
                    recommendationHcm = gethcm.October;
                }
                if (!string.IsNullOrEmpty(gethcm.November))
                {
                    monthHcm = "November";
                    recommendationHcm = gethcm.November;
                }
                if (!string.IsNullOrEmpty(gethcm.December))
                {
                    monthHcm = "December";
                    recommendationHcm = gethcm.December;
                }

                var gettreasure = sharedServicetreasure.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthTre = "January";
                string recommendationTre = "Full Scope";
                if (!string.IsNullOrEmpty(gettreasure.January))
                {
                    monthTre = "January";
                    recommendationTre = gettreasure.January;
                }
                if (!string.IsNullOrEmpty(gettreasure.February))
                {
                    monthTre = "February";
                    recommendationTre = gettreasure.February;
                }
                if (!string.IsNullOrEmpty(gettreasure.March))
                {
                    monthTre = "March";
                    recommendationTre = gettreasure.March;
                }
                if (!string.IsNullOrEmpty(gettreasure.April))
                {
                    monthTre = "April";
                    recommendationTre = gettreasure.April;
                }
                if (!string.IsNullOrEmpty(gettreasure.May))
                {
                    monthTre = "May";
                    recommendationTre = gettreasure.May;
                }
                if (!string.IsNullOrEmpty(gettreasure.June))
                {
                    monthTre = "June";
                    recommendationTre = gettreasure.June;
                }
                if (!string.IsNullOrEmpty(gettreasure.July))
                {
                    monthTre = "July";
                    recommendationTre = gettreasure.July;
                }
                if (!string.IsNullOrEmpty(gettreasure.August))
                {
                    monthTre = "August";
                    recommendationTre = gettreasure.August;
                }
                if (!string.IsNullOrEmpty(gettreasure.September))
                {
                    monthTre = "September";
                    recommendationTre = gettreasure.September;
                }
                if (!string.IsNullOrEmpty(gettreasure.October))
                {
                    monthTre = "October";
                    recommendationTre = gettreasure.October;
                }
                if (!string.IsNullOrEmpty(gettreasure.November))
                {
                    monthTre = "November";
                    recommendationTre = gettreasure.November;
                }
                if (!string.IsNullOrEmpty(gettreasure.December))
                {
                    monthTre = "December";
                    recommendationTre = gettreasure.December;
                }

                var getriskManagement = sharedServiceriskManagement.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthRisk = "January";
                string recommendationRisk = "Full Scope";
                if (!string.IsNullOrEmpty(getriskManagement.January))
                {
                    monthRisk = "January";
                    recommendationRisk = getriskManagement.January;
                }
                if (!string.IsNullOrEmpty(getriskManagement.February))
                {
                    monthRisk = "February";
                    recommendationRisk = getriskManagement.February;
                }
                if (!string.IsNullOrEmpty(getriskManagement.March))
                {
                    monthRisk = "March";
                    recommendationRisk = getriskManagement.March;
                }
                if (!string.IsNullOrEmpty(getriskManagement.April))
                {
                    monthRisk = "April";
                    recommendationRisk = getriskManagement.April;
                }
                if (!string.IsNullOrEmpty(getriskManagement.May))
                {
                    monthRisk = "May";
                    recommendationRisk = getriskManagement.May;
                }
                if (!string.IsNullOrEmpty(getriskManagement.June))
                {
                    monthRisk = "June";
                    recommendationRisk = getriskManagement.June;
                }
                if (!string.IsNullOrEmpty(getriskManagement.July))
                {
                    monthRisk = "July";
                    recommendationRisk = getriskManagement.July;
                }
                if (!string.IsNullOrEmpty(getriskManagement.August))
                {
                    monthRisk = "August";
                    recommendationRisk = getriskManagement.August;
                }
                if (!string.IsNullOrEmpty(getriskManagement.September))
                {
                    monthRisk = "September";
                    recommendationRisk = getriskManagement.September;
                }
                if (!string.IsNullOrEmpty(getriskManagement.October))
                {
                    monthRisk = "October";
                    recommendationRisk = getriskManagement.October;
                }
                if (!string.IsNullOrEmpty(getriskManagement.November))
                {
                    monthRisk = "November";
                    recommendationRisk = getriskManagement.November;
                }
                if (!string.IsNullOrEmpty(getriskManagement.December))
                {
                    monthRisk = "December";
                    recommendationRisk = getriskManagement.December;
                }

                var getacademy = sharedServiceacademy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthAca = "January";
                string recommendationAca = "Full Scope";
                if (!string.IsNullOrEmpty(getacademy.January))
                {
                    monthAca = "January";
                    recommendationAca = getacademy.January;
                }
                if (!string.IsNullOrEmpty(getacademy.February))
                {
                    monthAca = "February";
                    recommendationAca = getacademy.February;
                }
                if (!string.IsNullOrEmpty(getacademy.March))
                {
                    monthAca = "March";
                    recommendationAca = getacademy.March;
                }
                if (!string.IsNullOrEmpty(getacademy.April))
                {
                    monthAca = "April";
                    recommendationAca = getacademy.April;
                }
                if (!string.IsNullOrEmpty(getacademy.May))
                {
                    monthAca = "May";
                    recommendationAca = getacademy.May;
                }
                if (!string.IsNullOrEmpty(getacademy.June))
                {
                    monthAca = "June";
                    recommendationAca = getacademy.June;
                }
                if (!string.IsNullOrEmpty(getacademy.July))
                {
                    monthAca = "July";
                    recommendationAca = getacademy.July;
                }
                if (!string.IsNullOrEmpty(getacademy.August))
                {
                    monthAca = "August";
                    recommendationAca = getacademy.August;
                }
                if (!string.IsNullOrEmpty(getacademy.September))
                {
                    monthAca = "September";
                    recommendationAca = getacademy.September;
                }
                if (!string.IsNullOrEmpty(getacademy.October))
                {
                    monthAca = "October";
                    recommendationAca = getacademy.October;
                }
                if (!string.IsNullOrEmpty(getacademy.November))
                {
                    monthAca = "November";
                    recommendationAca = getacademy.November;
                }
                if (!string.IsNullOrEmpty(getacademy.December))
                {
                    monthAca = "December";
                    recommendationAca = getacademy.December;
                }

                var getCTO = sharedServiceCTO.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthCTO = "January";
                string recommendationCTO = "Full Scope";
                if (!string.IsNullOrEmpty(getCTO.January))
                {
                    monthCTO = "January";
                    recommendationCTO = getCTO.January;
                }
                if (!string.IsNullOrEmpty(getCTO.February))
                {
                    monthCTO = "February";
                    recommendationCTO = getCTO.February;
                }
                if (!string.IsNullOrEmpty(getCTO.March))
                {
                    monthCTO = "March";
                    recommendationCTO = getCTO.March;
                }
                if (!string.IsNullOrEmpty(getCTO.April))
                {
                    monthCTO = "April";
                    recommendationCTO = getCTO.April;
                }
                if (!string.IsNullOrEmpty(getCTO.May))
                {
                    monthCTO = "May";
                    recommendationCTO = getCTO.May;
                }
                if (!string.IsNullOrEmpty(getCTO.June))
                {
                    monthCTO = "June";
                    recommendationCTO = getCTO.June;
                }
                if (!string.IsNullOrEmpty(getCTO.July))
                {
                    monthCTO = "July";
                    recommendationCTO = getCTO.July;
                }
                if (!string.IsNullOrEmpty(getCTO.August))
                {
                    monthCTO = "August";
                    recommendationCTO = getCTO.August;
                }
                if (!string.IsNullOrEmpty(getCTO.September))
                {
                    monthCTO = "September";
                    recommendationCTO = getCTO.September;
                }
                if (!string.IsNullOrEmpty(getCTO.October))
                {
                    monthCTO = "October";
                    recommendationCTO = getCTO.October;
                }
                if (!string.IsNullOrEmpty(getCTO.November))
                {
                    monthCTO = "November";
                    recommendationCTO = getCTO.November;
                }
                if (!string.IsNullOrEmpty(getCTO.December))
                {
                    monthCTO = "December";
                    recommendationCTO = getCTO.December;
                }

                var getIT = sharedServiceit.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthIt = "January";
                string recommendationIt = "Full Scope";
                if (!string.IsNullOrEmpty(getIT.January))
                {
                    monthIt = "January";
                    recommendationIt = getIT.January;
                }
                if (!string.IsNullOrEmpty(getIT.February))
                {
                    monthIt = "February";
                    recommendationIt = getIT.February;
                }
                if (!string.IsNullOrEmpty(getIT.March))
                {
                    monthIt = "March";
                    recommendationIt = getIT.March;
                }
                if (!string.IsNullOrEmpty(getIT.April))
                {
                    monthIt = "April";
                    recommendationIt = getIT.April;
                }
                if (!string.IsNullOrEmpty(getIT.May))
                {
                    monthIt = "May";
                    recommendationIt = getIT.May;
                }
                if (!string.IsNullOrEmpty(getIT.June))
                {
                    monthIt = "June";
                    recommendationIt = getIT.June;
                }
                if (!string.IsNullOrEmpty(getIT.July))
                {
                    monthIt = "July";
                    recommendationIt = getIT.July;
                }
                if (!string.IsNullOrEmpty(getIT.August))
                {
                    monthIt = "August";
                    recommendationIt = getIT.August;
                }
                if (!string.IsNullOrEmpty(getIT.September))
                {
                    monthIt = "September";
                    recommendationIt = getIT.September;
                }
                if (!string.IsNullOrEmpty(getIT.October))
                {
                    monthIt = "October";
                    recommendationIt = getIT.October;
                }
                if (!string.IsNullOrEmpty(getIT.November))
                {
                    monthIt = "November";
                    recommendationIt = getIT.November;
                }
                if (!string.IsNullOrEmpty(getIT.December))
                {
                    monthIt = "December";
                    recommendationIt = getIT.December;
                }

                var getMCC = sharedServicemcc.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthMCC = "January";
                string recommendationMCC = "Full Scope";
                if (!string.IsNullOrEmpty(getMCC.January))
                {
                    monthMCC = "January";
                    recommendationMCC = getMCC.January;
                }
                if (!string.IsNullOrEmpty(getMCC.February))
                {
                    monthMCC = "February";
                    recommendationMCC = getMCC.February;
                }
                if (!string.IsNullOrEmpty(getMCC.March))
                {
                    monthMCC = "March";
                    recommendationMCC = getMCC.March;
                }
                if (!string.IsNullOrEmpty(getMCC.April))
                {
                    monthMCC = "April";
                    recommendationMCC = getMCC.April;
                }
                if (!string.IsNullOrEmpty(getMCC.May))
                {
                    monthMCC = "May";
                    recommendationMCC = getMCC.May;
                }
                if (!string.IsNullOrEmpty(getMCC.June))
                {
                    monthMCC = "June";
                    recommendationMCC = getMCC.June;
                }
                if (!string.IsNullOrEmpty(getMCC.July))
                {
                    monthMCC = "July";
                    recommendationMCC = getMCC.July;
                }
                if (!string.IsNullOrEmpty(getMCC.August))
                {
                    monthMCC = "August";
                    recommendationMCC = getMCC.August;
                }
                if (!string.IsNullOrEmpty(getMCC.September))
                {
                    monthMCC = "September";
                    recommendationMCC = getMCC.September;
                }
                if (!string.IsNullOrEmpty(getMCC.October))
                {
                    monthMCC = "October";
                    recommendationMCC = getMCC.October;
                }
                if (!string.IsNullOrEmpty(getMCC.November))
                {
                    monthMCC = "November";
                    recommendationMCC = getMCC.November;
                }
                if (!string.IsNullOrEmpty(getMCC.December))
                {
                    monthMCC = "December";
                    recommendationMCC = getMCC.December;
                }

                var getlegal = sharedServicelegal.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthLeg = "January";
                string recommendationLeg = "Full Scope";
                if (!string.IsNullOrEmpty(getlegal.January))
                {
                    monthLeg = "January";
                    recommendationLeg = getlegal.January;
                }
                if (!string.IsNullOrEmpty(getlegal.February))
                {
                    monthLeg = "February";
                    recommendationLeg = getlegal.February;
                }
                if (!string.IsNullOrEmpty(getlegal.March))
                {
                    monthLeg = "March";
                    recommendationLeg = getlegal.March;
                }
                if (!string.IsNullOrEmpty(getlegal.April))
                {
                    monthLeg = "April";
                    recommendationLeg = getlegal.April;
                }
                if (!string.IsNullOrEmpty(getlegal.May))
                {
                    monthLeg = "May";
                    recommendationLeg = getlegal.May;
                }
                if (!string.IsNullOrEmpty(getlegal.June))
                {
                    monthLeg = "June";
                    recommendationLeg = getlegal.June;
                }
                if (!string.IsNullOrEmpty(getlegal.July))
                {
                    monthLeg = "July";
                    recommendationLeg = getlegal.July;
                }
                if (!string.IsNullOrEmpty(getlegal.August))
                {
                    monthLeg = "August";
                    recommendationLeg = getlegal.August;
                }
                if (!string.IsNullOrEmpty(getlegal.September))
                {
                    monthLeg = "September";
                    recommendationLeg = getlegal.September;
                }
                if (!string.IsNullOrEmpty(getlegal.October))
                {
                    monthLeg = "October";
                    recommendationLeg = getlegal.October;
                }
                if (!string.IsNullOrEmpty(getlegal.November))
                {
                    monthLeg = "November";
                    recommendationLeg = getlegal.November;
                }
                if (!string.IsNullOrEmpty(getlegal.December))
                {
                    monthLeg = "December";
                    recommendationLeg = getlegal.December;
                }

                var getinternalControl = sharedServiceinternalControl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthInC = "January";
                string recommendationInC = "Full Scope";
                if (!string.IsNullOrEmpty(getinternalControl.January))
                {
                    monthInC = "January";
                    recommendationInC = getinternalControl.January;
                }
                if (!string.IsNullOrEmpty(getinternalControl.February))
                {
                    monthInC = "February";
                    recommendationInC = getinternalControl.February;
                }
                if (!string.IsNullOrEmpty(getinternalControl.March))
                {
                    monthInC = "March";
                    recommendationInC = getinternalControl.March;
                }
                if (!string.IsNullOrEmpty(getinternalControl.April))
                {
                    monthInC = "April";
                    recommendationInC = getinternalControl.April;
                }
                if (!string.IsNullOrEmpty(getinternalControl.May))
                {
                    monthInC = "May";
                    recommendationInC = getinternalControl.May;
                }
                if (!string.IsNullOrEmpty(getinternalControl.June))
                {
                    monthInC = "June";
                    recommendationInC = getinternalControl.June;
                }
                if (!string.IsNullOrEmpty(getinternalControl.July))
                {
                    monthInC = "July";
                    recommendationInC = getinternalControl.July;
                }
                if (!string.IsNullOrEmpty(getinternalControl.August))
                {
                    monthInC = "August";
                    recommendationInC = getinternalControl.August;
                }
                if (!string.IsNullOrEmpty(getinternalControl.September))
                {
                    monthInC = "September";
                    recommendationInC = getinternalControl.September;
                }
                if (!string.IsNullOrEmpty(getinternalControl.October))
                {
                    monthInC = "October";
                    recommendationInC = getinternalControl.October;
                }
                if (!string.IsNullOrEmpty(getinternalControl.November))
                {
                    monthInC = "November";
                    recommendationInC = getinternalControl.November;
                }
                if (!string.IsNullOrEmpty(getinternalControl.December))
                {
                    monthInC = "December";
                    recommendationInC = getinternalControl.December;
                }

                var getprocurementandAdmin = sharedServiceprocurementandAdmin.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthPro = "January";
                string recommendationPro = "Full Scope";
                if (!string.IsNullOrEmpty(getprocurementandAdmin.January))
                {
                    monthPro = "January";
                    recommendationPro = getprocurementandAdmin.January;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.February))
                {
                    monthPro = "February";
                    recommendationPro = getprocurementandAdmin.February;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.March))
                {
                    monthPro = "March";
                    recommendationPro = getprocurementandAdmin.March;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.April))
                {
                    monthPro = "April";
                    recommendationPro = getprocurementandAdmin.April;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.May))
                {
                    monthPro = "May";
                    recommendationPro = getprocurementandAdmin.May;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.June))
                {
                    monthPro = "June";
                    recommendationPro = getprocurementandAdmin.June;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.July))
                {
                    monthPro = "July";
                    recommendationPro = getprocurementandAdmin.July;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.August))
                {
                    monthPro = "August";
                    recommendationPro = getprocurementandAdmin.August;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.September))
                {
                    monthPro = "September";
                    recommendationPro = getprocurementandAdmin.September;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.October))
                {
                    monthPro = "October";
                    recommendationPro = getprocurementandAdmin.October;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.November))
                {
                    monthPro = "November";
                    recommendationPro = getprocurementandAdmin.November;
                }
                if (!string.IsNullOrEmpty(getprocurementandAdmin.December))
                {
                    monthPro = "December";
                    recommendationPro = getprocurementandAdmin.December;
                }

                var getdataAna = dataAna.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthDat = "January";
                string recommendationDat = "Full Scope";
                if (!string.IsNullOrEmpty(getdataAna.January))
                {
                    monthDat = "January";
                    recommendationDat = getdataAna.January;
                }
                if (!string.IsNullOrEmpty(getdataAna.February))
                {
                    monthDat = "February";
                    recommendationDat = getdataAna.February;
                }
                if (!string.IsNullOrEmpty(getdataAna.March))
                {
                    monthDat = "March";
                    recommendationDat = getdataAna.March;
                }
                if (!string.IsNullOrEmpty(getdataAna.April))
                {
                    monthDat = "April";
                    recommendationDat = getdataAna.April;
                }
                if (!string.IsNullOrEmpty(getdataAna.May))
                {
                    monthDat = "May";
                    recommendationDat = getdataAna.May;
                }
                if (!string.IsNullOrEmpty(getdataAna.June))
                {
                    monthDat = "June";
                    recommendationDat = getdataAna.June;
                }
                if (!string.IsNullOrEmpty(getdataAna.July))
                {
                    monthDat = "July";
                    recommendationDat = getdataAna.July;
                }
                if (!string.IsNullOrEmpty(getdataAna.August))
                {
                    monthDat = "August";
                    recommendationDat = getdataAna.August;
                }
                if (!string.IsNullOrEmpty(getdataAna.September))
                {
                    monthDat = "September";
                    recommendationDat = getdataAna.September;
                }
                if (!string.IsNullOrEmpty(getdataAna.October))
                {
                    monthDat = "October";
                    recommendationDat = getdataAna.October;
                }
                if (!string.IsNullOrEmpty(getdataAna.November))
                {
                    monthDat = "November";
                    recommendationDat = getdataAna.November;
                }
                if (!string.IsNullOrEmpty(getdataAna.December))
                {
                    monthDat = "December";
                    recommendationDat = getdataAna.December;
                }

                var getfinCtrl = finCtrl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthFinc = "January";
                string recommendationFnc = "Full Scope";
                if (!string.IsNullOrEmpty(getfinCtrl.January))
                {
                    monthFinc = "January";
                    recommendationFnc = getfinCtrl.January;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.February))
                {
                    monthFinc = "February";
                    recommendationFnc = getfinCtrl.February;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.March))
                {
                    monthFinc = "March";
                    recommendationFnc = getfinCtrl.March;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.April))
                {
                    monthFinc = "April";
                    recommendationFnc = getfinCtrl.April;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.May))
                {
                    monthFinc = "May";
                    recommendationFnc = getfinCtrl.May;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.June))
                {
                    monthFinc = "June";
                    recommendationFnc = getfinCtrl.June;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.July))
                {
                    monthFinc = "July";
                    recommendationFnc = getfinCtrl.July;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.August))
                {
                    monthFinc = "August";
                    recommendationFnc = getfinCtrl.August;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.September))
                {
                    monthFinc = "September";
                    recommendationFnc = getfinCtrl.September;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.October))
                {
                    monthFinc = "October";
                    recommendationFnc = getfinCtrl.October;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.November))
                {
                    monthFinc = "November";
                    recommendationFnc = getfinCtrl.November;
                }
                if (!string.IsNullOrEmpty(getfinCtrl.December))
                {
                    monthFinc = "December";
                    recommendationFnc = getfinCtrl.December;
                }

                var getcompl = compl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthComp = "January";
                string recommendationComp = "Full Scope";
                if (!string.IsNullOrEmpty(getcompl.January))
                {
                    monthComp = "January";
                    recommendationComp = getcompl.January;
                }
                if (!string.IsNullOrEmpty(getcompl.February))
                {
                    monthComp = "February";
                    recommendationComp = getcompl.February;
                }
                if (!string.IsNullOrEmpty(getcompl.March))
                {
                    monthComp = "March";
                    recommendationComp = getcompl.March;
                }
                if (!string.IsNullOrEmpty(getcompl.April))
                {
                    monthComp = "April";
                    recommendationComp = getcompl.April;
                }
                if (!string.IsNullOrEmpty(getcompl.May))
                {
                    monthComp = "May";
                    recommendationComp = getcompl.May;
                }
                if (!string.IsNullOrEmpty(getcompl.June))
                {
                    monthComp = "June";
                    recommendationComp = getcompl.June;
                }
                if (!string.IsNullOrEmpty(getcompl.July))
                {
                    monthComp = "July";
                    recommendationComp = getcompl.July;
                }
                if (!string.IsNullOrEmpty(getcompl.August))
                {
                    monthComp = "August";
                    recommendationComp = getcompl.August;
                }
                if (!string.IsNullOrEmpty(getcompl.September))
                {
                    monthComp = "September";
                    recommendationComp = getcompl.September;
                }
                if (!string.IsNullOrEmpty(getcompl.October))
                {
                    monthComp = "October";
                    recommendationComp = getcompl.October;
                }
                if (!string.IsNullOrEmpty(getcompl.November))
                {
                    monthComp = "November";
                    recommendationComp = getcompl.November;
                }
                if (!string.IsNullOrEmpty(getcompl.December))
                {
                    monthComp = "December";
                    recommendationComp = getcompl.December;
                }

                var getcustomerExperience = sharedServicecustomerExperience.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthCus = "January";
                string recommendationCus = "Full Scope";
                if (!string.IsNullOrEmpty(getcustomerExperience.January))
                {
                    monthCus = "January";
                    recommendationCus = getcustomerExperience.January;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.February))
                {
                    monthCus = "February";
                    recommendationCus = getcustomerExperience.February;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.March))
                {
                    monthCus = "March";
                    recommendationCus = getcustomerExperience.March;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.April))
                {
                    monthCus = "April";
                    recommendationCus = getcustomerExperience.April;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.May))
                {
                    monthCus = "May";
                    recommendationCus = getcustomerExperience.May;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.June))
                {
                    monthCus = "June";
                    recommendationCus = getcustomerExperience.June;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.July))
                {
                    monthCus = "July";
                    recommendationCus = getcustomerExperience.July;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.August))
                {
                    monthCus = "August";
                    recommendationCus = getcustomerExperience.August;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.September))
                {
                    monthCus = "September";
                    recommendationCus = getcustomerExperience.September;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.October))
                {
                    monthCus = "October";
                    recommendationCus = getcustomerExperience.October;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.November))
                {
                    monthCus = "November";
                    recommendationCus = getcustomerExperience.November;
                }
                if (!string.IsNullOrEmpty(getcustomerExperience.December))
                {
                    monthCus = "December";
                    recommendationCus = getcustomerExperience.December;
                }

                var getinformationSecurity = informationSecurity.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                string monthInfo = "January";
                string recommendationInfo = "Full Scope";
                if (!string.IsNullOrEmpty(getinformationSecurity.January))
                {
                    monthInfo = "January";
                    recommendationInfo = getinformationSecurity.January;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.February))
                {
                    monthInfo = "February";
                    recommendationInfo = getinformationSecurity.February;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.March))
                {
                    monthInfo = "March";
                    recommendationInfo = getinformationSecurity.March;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.April))
                {
                    monthInfo = "April";
                    recommendationInfo = getinformationSecurity.April;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.May))
                {
                    monthInfo = "May";
                    recommendationInfo = getinformationSecurity.May;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.June))
                {
                    monthInfo = "June";
                    recommendationInfo = getinformationSecurity.June;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.July))
                {
                    monthInfo = "July";
                    recommendationInfo = getinformationSecurity.July;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.August))
                {
                    monthInfo = "August";
                    recommendationInfo = getinformationSecurity.August;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.September))
                {
                    monthInfo = "September";
                    recommendationInfo = getinformationSecurity.September;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.October))
                {
                    monthInfo = "October";
                    recommendationInfo = getinformationSecurity.October;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.November))
                {
                    monthInfo = "November";
                    recommendationInfo = getinformationSecurity.November;
                }
                if (!string.IsNullOrEmpty(getinformationSecurity.December))
                {
                    monthInfo = "December";
                    recommendationInfo = getinformationSecurity.December;
                }

                ViewARMSharedServiceAudiPlanExecutionByIdResp resp = new ViewARMSharedServiceAudiPlanExecutionByIdResp
                {
                    HCM = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthHcm,
                        Team = "HCM",
                        Recommendation = recommendationHcm,
                        EngagementPlan = engagementPlan,
                        WorkPaper = workPaper,
                        FindingStatus = findingStatus,
                        CommenceEngagementId = getcommenceEngId
                    },
                    FinancialControl = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthFinc,
                        Team = "Financial Control",
                        Recommendation = recommendationFnc,
                        EngagementPlan = engagementPlanFtrl,
                        WorkPaper = workPaperFtrl,
                        FindingStatus = findingStatusFtrl,
                        CommenceEngagementId = getcommenceEngIdFtrl
                    },
                    Compliance = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthComp,
                        Team = "Compliance",
                        Recommendation = recommendationComp,
                        EngagementPlan = engagementPlanComp,
                        WorkPaper = workPaperComp,
                        FindingStatus = findingStatusComp,
                        CommenceEngagementId = getcommenceEngIdComp
                    },
                    Legal = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthLeg,
                        Team = "Legal",
                        Recommendation = recommendationLeg,
                        EngagementPlan = engagementPlanLegal,
                        WorkPaper = workPaperLegal,
                        FindingStatus = findingStatusLegal,
                        CommenceEngagementId = getcommenceEngIdLegal
                    },
                    IT = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthIt,
                        Team = "IT",
                        Recommendation = recommendationIt,
                        EngagementPlan = engagementPlanIT,
                        WorkPaper = workPaperIT,
                        FindingStatus = findingStatusIT,
                        CommenceEngagementId = getcommenceEngIdIT
                    },
                    InternalControl = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthInC,
                        Team = "Internal Control",
                        Recommendation = recommendationInC,
                        EngagementPlan = engagementPlanIntCtrl,
                        WorkPaper = workPaperIntCtrl,
                        FindingStatus = findingStatusIntCtrl,
                        CommenceEngagementId = getcommenceEngIdIntCtrl
                    },
                    CTO = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthCTO,
                        Team = "CTO",
                        Recommendation = recommendationCTO,
                        EngagementPlan = engagementPlanCTO,
                        WorkPaper = workPaperCTO,
                        FindingStatus = findingStatusCTO,
                        CommenceEngagementId = getcommenceEngIdCTO
                    },
                    RiskManagement = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthRisk,
                        Team = "Risk Management",
                        Recommendation = recommendationRisk,
                        EngagementPlan = engagementPlanRisk,
                        WorkPaper = workPaperRisk,
                        FindingStatus = findingStatusRisk,
                        CommenceEngagementId = getcommenceEngIdRisk
                    },
                    CorporateStrategy = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthRes,
                        Team = "Corporate Strategy",
                        Recommendation = recommendationRes,
                        EngagementPlan = engagementPlanCorp,
                        WorkPaper = workPaperCorp,
                        FindingStatus = findingStatusCorp,
                        CommenceEngagementId = getcommenceEngIdCorp
                    },
                    Academy = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthAca,
                        Team = "Academy",
                        Recommendation = recommendationAca,
                        EngagementPlan = engagementPlanAca,
                        WorkPaper = workPaperAca,
                        FindingStatus = findingStatusAca,
                        CommenceEngagementId = getcommenceEngIdAca
                    },
                    DataAnalytic = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthDat,
                        Team = "Data Analytic",
                        Recommendation = recommendationDat,
                        EngagementPlan = engagementPlanData,
                        WorkPaper = workPaperData,
                        FindingStatus = findingStatusData,
                        CommenceEngagementId = getcommenceEngIdData
                    },
                    ProcurementandAdmin = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthPro,
                        Team = "Procurement and Admin",
                        Recommendation = recommendationPro,
                        EngagementPlan = engagementPlanPro,
                        WorkPaper = workPaperPro,
                        FindingStatus = findingStatusPro,
                        CommenceEngagementId = getcommenceEngIdPro
                    },
                    CustomerExperience = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthCus,
                        Team = "Customer Experience",
                        Recommendation = recommendationCus,
                        EngagementPlan = engagementPlanCus,
                        WorkPaper = workPaperCus,
                        FindingStatus = findingStatusCus,
                        CommenceEngagementId = getcommenceEngIdCus
                    },
                    MCC = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthMCC,
                        Team = "MCC",
                        Recommendation = recommendationMCC,
                        EngagementPlan = engagementPlanMCC,
                        WorkPaper = workPaperMCC,
                        FindingStatus = findingStatusMCC,
                        CommenceEngagementId = getcommenceEngIdMCC
                    },
                    InformationSecurity = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthInfo,
                        Team = "Information Security",
                        Recommendation = recommendationInfo,
                        EngagementPlan = engagementPlanInfo,
                        WorkPaper = workPaperInfo,
                        FindingStatus = findingStatusInfo,
                        CommenceEngagementId = getcommenceEngIdInfo
                    },
                    Treasury = new ViewAudiPlanExecutionResponse
                    {
                        Month = monthTre,
                        Team = "Treasury",
                        Recommendation = recommendationTre,
                        EngagementPlan = engagementPlanTre,
                        WorkPaper = workPaperTre,
                        FindingStatus = findingStatusTre,
                        CommenceEngagementId = getcommenceEngIdTre
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
