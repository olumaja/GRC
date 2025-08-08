using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 13/05/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * Endpoint to View Audit Execution Plan for the year
  */
    public class ViewOfficerAuditExecutionPlanEndpoint
    {
        /// <summary>
        /// Endpoint to View Audit Execution Plan for the year
        /// </summary>
        /// <param name="annualaudit"></param>
        /// <param name="holdco"></param>
        /// <param name="armIM"></param>
        /// <param name="security"></param>
        /// <param name="trustee"></param>
        /// <param name="armHill"></param>
        /// <param name="agriBus"></param>
        /// <param name="sharedservice"></param>
        /// <param name="armTam"></param>
        /// <param name="dfs"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMHoldingCompanyAnnualAuditUniverse> holdco,            
            IRepository<ARMIMAuditUniverse> armIM, IRepository<ARMSecurityAnnualAuditUniverse> security, IRepository<ARMTrusteeAuditUniverse> trustee,
            IRepository<ARMHillAuditUniverse> armHill, IRepository<ARMAgribusinessAuditUniverse> agriBus, IRepository<ARMSharedAuditUniverse> sharedservice,
            IRepository<ARMTAMAuditUniverse> armTam, IRepository<DigitalFinancialServiceAuditUniverse> dfs, IRepository<ARMCapitalAuditUniverse> armCapitaaaal, IRepository<CommenceEngagementAuditexecution> commenceEng,
            ClaimsPrincipal user, ICurrentUserService currentUserService
        )
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
                List<ViewAuditExecutionPlan> viewResp = new List<ViewAuditExecutionPlan>();
                var getRating = annualaudit.GetContextByConditon(x => x.Id != null).ToList();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed");
                }
                var commenceEngRep = await commenceEng.GetAllAsync();
                var holdcoResp = await holdco.GetAllAsync();
                var armIMResp = await armIM.GetAllAsync();
                var securityResp = await security.GetAllAsync();
                var trusteeResp = await trustee.GetAllAsync();
                var armHillResp = await armHill.GetAllAsync();
                var agriBusResp = await agriBus.GetAllAsync();
                var sharedserviceResp = await sharedservice.GetAllAsync();
                var dfsResp = await dfs.GetAllAsync();
                var armCapitalResp = await armCapitaaaal.GetAllAsync();
                var armTamResp = await armTam.GetAllAsync();
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                        var getcommenceEngRep = commenceEngRep.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));                                              
                        var getholdco = holdcoResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));

                        string holdcoRequester = "null";
                        string holdcostatus = "Pending";
                        if (getholdco != null)
                        {
                            holdcoRequester = getholdco.RequesterName;
                            holdcostatus = getholdco.AnualAuditUniverseStatus.ToString();
                        }
                        var getarmIM = armIMResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string armIMRequester = "null";
                        string armIMstatus = "Pending";
                        if (getarmIM != null)
                        {
                            armIMRequester = getarmIM.RequesterName;
                            armIMstatus = getarmIM.AnualAuditUniverseStatus.ToString();
                        }
                        var getsecurity = securityResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string secRequester = "null";
                        string secStatus = "Pending";
                        if (getsecurity != null)
                        {
                            secRequester = getsecurity.RequesterName;
                            secStatus = getsecurity.AnualAuditUniverseStatus.ToString();
                        }
                        var gettrustee = trusteeResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string trustRequester = "null";
                        string trustStatus = "Pending";
                        if (gettrustee != null)
                        {
                            trustRequester = gettrustee.RequesterName;
                            trustStatus = gettrustee.AnualAuditUniverseStatus.ToString();
                        }
                        var getarmHill = armHillResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string hillRequester = "null";
                        string hillStatus = "Pending";
                        if (getarmHill != null)
                        {
                            hillRequester = getarmHill.RequesterName;
                            hillStatus = getarmHill.AnualAuditUniverseStatus.ToString();
                        }
                        var getagriBus = agriBusResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string agriRequester = "null";
                        string agriStatus = "Pending";
                        if (getagriBus != null)
                        {
                            agriRequester = getagriBus.RequesterName;
                            agriStatus = getagriBus.AnualAuditUniverseStatus.ToString();
                        }
                        var getsharedservice = sharedserviceResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string shareRequester = "null";
                        string shareStatus = "Pending";
                        if (getsharedservice != null)
                        {
                            shareRequester = getsharedservice.RequesterName;
                            shareStatus = getsharedservice.AnualAuditUniverseStatus.ToString();
                        }
                        var getdfsResp = dfsResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string dfsRequester = "null";
                        string dfsStatus = "Pending";
                        if (getdfsResp != null)
                        {
                            dfsRequester = getdfsResp.RequesterName;
                            dfsStatus = getdfsResp.AnualAuditUniverseStatus.ToString();
                        }
                        var getARMCapitalResp = armCapitalResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string armCapitalRequester = "null";
                        string armCapitalStatus = "Pending";
                        if (getdfsResp != null)
                        {
                            armCapitalRequester = getARMCapitalResp.RequesterName;
                            armCapitalStatus = getARMCapitalResp.AnualAuditUniverseStatus.ToString();
                        }

                        var getarmTamResp = armTamResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.Id));
                        string tamRequester = "null";
                        string tamStatus = "Pending";
                        if (getarmTamResp != null)
                        {
                            tamRequester = getarmTamResp.RequesterName;
                            tamStatus = getarmTamResp.AnualAuditUniverseStatus.ToString();
                        }
                        Guid getCommenceEngId = Guid.Empty;
                        if (getcommenceEngRep != null)
                        {
                            getCommenceEngId = getcommenceEngRep.Id;
                        }
                        //get rated engagement for the unit
                        Guid getCommenceEngIdHoldco = Guid.Empty;
                        Guid getIMUnit = Guid.Empty;
                        Guid getCommenceEngIdTreasurySale = Guid.Empty;
                        Guid getRegistrar = Guid.Empty;
                        Guid getOperationSettlement = Guid.Empty;
                        Guid getBDPWMIAMIMRetail = Guid.Empty;
                        Guid getFundAccount = Guid.Empty;
                        Guid getFundAdmin = Guid.Empty;
                        Guid getOperationControl = Guid.Empty;
                        Guid getResearch = Guid.Empty;
                        Guid getRetailOperation = Guid.Empty;                        
                        Guid getStockBroking = Guid.Empty;
                        Guid getPrivateTrust = Guid.Empty;
                        Guid getCommercialTrust = Guid.Empty;
                        Guid getARMHill = Guid.Empty;
                        Guid getRFL = Guid.Empty;
                        Guid getAAFML = Guid.Empty;
                        Guid getDigitalFinancialService = Guid.Empty;
                        Guid getARMCapital = Guid.Empty;
                        Guid getARMTAM = Guid.Empty;
                        Guid getLegal = Guid.Empty;
                        Guid getIT = Guid.Empty;
                        Guid getCompliance = Guid.Empty;
                        Guid getHCM = Guid.Empty;
                        Guid getFinancialControl = Guid.Empty;
                        Guid getInternalControl = Guid.Empty;
                        Guid getMCC = Guid.Empty;
                        Guid getCTO = Guid.Empty;
                        Guid getAcademy = Guid.Empty;
                        Guid getDataAnalytic = Guid.Empty;
                        Guid getRiskManagement = Guid.Empty;
                        Guid getCorporateStrategy = Guid.Empty;
                        Guid getTreasury = Guid.Empty;                       
                        Guid getCustomerExperience = Guid.Empty;
                        Guid getProcurementandAdmin = Guid.Empty;
                        Guid getInformationSecurity = Guid.Empty;                       
                        
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "ARM Holding Company")
                        {
                            getCommenceEngIdHoldco = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Treasury Sale")
                        {
                            getCommenceEngIdTreasurySale = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "IMUnit")
                        {
                            getIMUnit = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Registrar")
                        {
                            getRegistrar = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Operation Settlement")
                        {
                            getOperationSettlement = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "BDPWMIAMIMRetail")
                        {
                            getBDPWMIAMIMRetail = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Fund Account")
                        {
                            getFundAccount = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Fund Admin")
                        {
                            getFundAdmin = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Operation Control")
                        {
                            getOperationControl = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Stock Broking")
                        {
                            getStockBroking = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Private Trust")
                        {
                            getPrivateTrust = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Commercial Trust")
                        {
                            getCommercialTrust = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "ARMHill")
                        {
                            getARMHill = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "RFL")
                        {
                            getRFL = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "AAFML")
                        {
                            getAAFML = getcommenceEngRep.Id;
                        }                        
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Digital Financial Service")
                        {
                            getDigitalFinancialService = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "ARMCapital")
                        {
                            getARMCapital = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "ARMTAM")
                        {
                            getARMTAM = getcommenceEngRep.Id;

                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Legal")
                        {
                            getLegal = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "IT")
                        {
                            getIT = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Compliance")
                        {
                            getCompliance = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "HCM")
                        {
                            getHCM = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Financial Control")
                        {
                            getFinancialControl = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Internal Control")
                        {
                            getInternalControl = getcommenceEngRep.Id;
                        }                     
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Corporate Strategy")
                        {
                            getCorporateStrategy = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Treasury")
                        {
                            getTreasury = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "MCC")
                        {
                            getMCC = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Academy")
                        {
                            getAcademy = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "CTO")
                        {
                            getCTO = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Data Analytic")
                        {
                            getDataAnalytic = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Risk Management")
                        {
                            getRiskManagement = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Customer Experience")
                        {
                            getCustomerExperience = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Procurement and Admin")
                        {
                            getProcurementandAdmin = getcommenceEngRep.Id;
                        }
                        if (getcommenceEngRep != null && getcommenceEngRep.Team == "Information Security")
                        {
                            getInformationSecurity = getcommenceEngRep.Id;
                        }                     

                        viewResp.Add(new ViewAuditExecutionPlan
                        {
                            DateCreated = item.CreatedOnUtc,
                            AuditYear = item.CreatedOnUtc.Year,
                            AuditOfficer = item.RequesterName,
                            Status = item.AnualAuditUniverseStatus.ToString(),
                            ARMHoldingCompany = new ViewAuditExecutionARMHoldCoResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMHoldingCompany",
                                AuditOfficer = holdcoRequester, 
                                Status = holdcostatus, 
                                AnualAuditUniverseRiskRatingId = item.Id,
                                ARMHoldingCompany = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getCommenceEngIdHoldco,
                                },
                                 Treasurysale = new ViewAuditExecutionDetail
                                 {
                                     AnualAuditUniverseRiskRatingId = item.Id,
                                     CommenceengagementId = getCommenceEngIdTreasurySale,
                                 }

                            },
                            ARMIM = new ViewAuditExecutionARMIMResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMIM",
                                AuditOfficer = armIMRequester,
                                Status = armIMstatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                IMUnit = new ViewAuditExecutionDetail
                                {
                                    
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getIMUnit,
                                },
                                Registrar = new ViewAuditExecutionDetail
                                 {

                                     AnualAuditUniverseRiskRatingId = item.Id,
                                     CommenceengagementId = getRegistrar,
                                 },
                                OperationSettlement = new ViewAuditExecutionDetail
                                  {

                                      AnualAuditUniverseRiskRatingId = item.Id,
                                      CommenceengagementId = getOperationSettlement,
                                  },
                                BDPWMIAMIMRetail = new ViewAuditExecutionDetail
                                   {

                                       AnualAuditUniverseRiskRatingId = item.Id,
                                       CommenceengagementId = getBDPWMIAMIMRetail,
                                   },
                                FundAccount = new ViewAuditExecutionDetail
                                  {

                                        AnualAuditUniverseRiskRatingId = item.Id,
                                        CommenceengagementId = getFundAccount,
                                  },
                                FundAdmin = new ViewAuditExecutionDetail
                                {

                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getFundAdmin,
                                },
                                OperationControl = new ViewAuditExecutionDetail
                                {

                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getOperationControl,
                                },
                                Research = new ViewAuditExecutionDetail
                                {

                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getResearch
                                },
                                RetailOperation = new ViewAuditExecutionDetail
                                {

                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getRetailOperation
                                }
                            },
                            ARMSecurity = new ViewAuditExecutionARMSecurityResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMSecurity",
                                AuditOfficer = secRequester,
                                Status = secStatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                StockBroking = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getStockBroking
                                }
                            },
                            ARMTrustee = new ViewAuditExecutionARMTrusteeResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMTrustee",
                                AuditOfficer = trustRequester,
                                Status = trustStatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                PrivateTrust = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getPrivateTrust
                                },
                                CommercialTrust = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getCommercialTrust
                                }
                            },
                            ARMHill = new ViewAuditExecutionARMHillResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMHill",
                                AuditOfficer = hillRequester,
                                Status = hillStatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                ARMHill = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getARMHill
                                }
                            },
                            ARMAgribusiness = new ViewAuditExecutionARMAgribusnessResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMAgribusiness",
                                AuditOfficer = agriRequester,
                                Status = agriStatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                RFL = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getRFL
                                },
                                AAFML = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getAAFML
                                }
                            },
                            DigitalFinancialService = new ViewAuditExecutionDFSResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "DigitalFinancialService",
                                AuditOfficer = dfsRequester,
                                Status = dfsStatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                DigitalFinancialService = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getDigitalFinancialService
                                }
                            },
                            ARMCapital = new ViewAuditExecutionARMCapitalResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMCapital",
                                AuditOfficer = armCapitalRequester,
                                Status = armCapitalStatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                ARMCapital = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getARMCapital
                                }
                            },
                            ARMTAM = new ViewAuditExecutionARMTAMResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMTAM",
                                AuditOfficer = tamRequester,
                                Status = tamStatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                ARMTAM = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getARMTAM
                                }
                            },
                            ARMSharedService = new ViewAuditExecutionARMSharedServiceResp
                            {
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                Business = "ARMSharedService",
                                AuditOfficer = shareRequester,
                                Status = shareStatus,
                                AnualAuditUniverseRiskRatingId = item.Id,
                                HCM = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getHCM
                                },
                                Compliance = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getCompliance
                                },
                                FinancialControl = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getFinancialControl
                                },
                                InternalControl = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getInternalControl
                                },
                                Legal = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getLegal
                                },
                                IT = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getIT
                                },
                                CTO = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getCTO
                                },
                                MCC = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getMCC
                                },
                                Academy = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getAcademy
                                },
                                DataAnalytic = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getDataAnalytic
                                },
                                RiskManagement = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getRiskManagement
                                },
                                Treasury = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getTreasury
                                },
                                CorporateStrategy = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getCorporateStrategy
                                },
                                CustomerExperience = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getCustomerExperience
                                },
                                ProcurementandAdmin = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getProcurementandAdmin
                                },
                                InformationSecurity = new ViewAuditExecutionDetail
                                {
                                    AnualAuditUniverseRiskRatingId = item.Id,
                                    CommenceengagementId = getInformationSecurity
                                }                               
                            },
                        }); 
                    }
                    return TypedResults.Ok(viewResp);
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }

        }
    }
}
