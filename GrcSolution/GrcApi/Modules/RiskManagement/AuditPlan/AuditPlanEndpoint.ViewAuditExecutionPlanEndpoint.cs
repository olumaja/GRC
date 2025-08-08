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
    public class ViewAuditExecutionPlanEndpoint
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
        /// <param name="user"></param>    
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMHoldingCompanyAnnualAuditUniverse> holdco,
            IRepository<ARMTAMAuditUniverse> annualauditTAM, IRepository<DigitalFinancialServiceAuditUniverse> annualauditDFS, IRepository<ARMCapitalAuditUniverse> annualauditARMCapital,
            IRepository<ARMIMAuditUniverse> armIM, IRepository<ARMSecurityAnnualAuditUniverse> security, IRepository<ARMTrusteeAuditUniverse> trustee,
            IRepository<ARMHillAuditUniverse> armHill, IRepository<ARMAgribusinessAuditUniverse> agriBus, IRepository<ARMSharedAuditUniverse> sharedservice,
            IRepository<CommenceEngagementAuditexecution> commenceEng, IRepository<WorkPaper> workpaperRepo, IRepository<AuditProgramAuditExecution> auditProgramRepo,
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
                List<ViewAuditExecutionPlanSumary> viewResp = new List<ViewAuditExecutionPlanSumary>();
                //List<ViewAuditExecutionPlan> viewResp = new List<ViewAuditExecutionPlan>();
                var getRating = annualaudit.GetContextByConditon(x => x.Id != null).ToList();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed");
                }
                var commenceEngResp = await commenceEng.GetAllAsync();

                
                var annualauditTAMResp = await annualauditTAM.GetAllAsync();
                var annualauditDFSResp = await annualauditDFS.GetAllAsync();
                var annualauditARMCapitalResp = await annualauditARMCapital.GetAllAsync();
                var holdcoResp = await holdco.GetAllAsync();
                var armIMResp = await armIM.GetAllAsync();
                var securityResp = await security.GetAllAsync();
                var trusteeResp = await trustee.GetAllAsync();
                var armHillResp = await armHill.GetAllAsync();
                var agriBusResp = await agriBus.GetAllAsync();
                var sharedserviceResp = await sharedservice.GetAllAsync();
                var auditProgramRepoResp = await auditProgramRepo.GetAllAsync();
                var workpaperRepoResp = await workpaperRepo.GetAllAsync();

                if (getRating != null)
                {
                    foreach (var item in commenceEngResp)
                    // foreach( var item in getRating )
                    {
                        var getauditProgramRepoResp = auditProgramRepoResp.Find(x => x.CommenceEngagementAuditexecutionId.Equals(item.Id));
                        var getholdco = holdcoResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var getarmIM = armIMResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var getsecurity = securityResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var gettrustee = trusteeResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var getarmHill = armHillResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var getagriBus = agriBusResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var getsharedservice = sharedserviceResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var getannualauditTAMResp = annualauditTAMResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var getannualauditDFSResp = annualauditDFSResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        var getannualauditARMCapitalResp = annualauditARMCapitalResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(item.AnualAuditUniverseRiskRatingId));
                        Guid getAuditProgramId = Guid.Empty;
                        if (getauditProgramRepoResp != null)
                        {
                            getAuditProgramId = getauditProgramRepoResp.Id;
                        }
                        viewResp.Add(new ViewAuditExecutionPlanSumary
                        {
                            DateCreated = getholdco.CreatedOnUtc,
                            AuditYear = getholdco.CreatedOnUtc.Year,
                            AuditOfficer = getholdco.RequesterName,
                            Status = item.Status.ToString(),
                            ARMHoldingCompany = new ViewAuditExecutionResp
                            {
                                DateCreated = getholdco.CreatedOnUtc,
                                AuditYear = getholdco.CreatedOnUtc.Year,
                                Business = "ARMHoldingCompany",
                                AuditOfficer = getholdco.RequesterName,
                                Status = getholdco.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getholdco.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            ARMIM = new ViewAuditExecutionResp
                            {
                                DateCreated = getarmIM.CreatedOnUtc,
                                AuditYear = getarmIM.CreatedOnUtc.Year,
                                Business = "ARMIM",
                                AuditOfficer = getarmIM.RequesterName,
                                Status = getarmIM.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getarmIM.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            ARMSecurity = new ViewAuditExecutionResp
                            {
                                DateCreated = getsecurity.CreatedOnUtc,
                                AuditYear = getsecurity.CreatedOnUtc.Year,
                                Business = "ARMSecurity",
                                AuditOfficer = getsecurity.RequesterName,
                                Status = getsecurity.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getsecurity.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            ARMTrustee = new ViewAuditExecutionResp
                            {
                                DateCreated = gettrustee.CreatedOnUtc,
                                AuditYear = gettrustee.CreatedOnUtc.Year,
                                Business = "ARMTrustee",
                                AuditOfficer = gettrustee.RequesterName,
                                Status = gettrustee.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = gettrustee.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            ARMHill = new ViewAuditExecutionResp
                            {
                                DateCreated = getarmHill.CreatedOnUtc,
                                AuditYear = getarmHill.CreatedOnUtc.Year,
                                Business = "ARMHill",
                                AuditOfficer = getarmHill.RequesterName,
                                Status = getarmHill.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getarmHill.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            DigitalFinancialService = new ViewAuditExecutionResp 
                            {
                                DateCreated = getannualauditDFSResp.CreatedOnUtc,
                                AuditYear = getannualauditDFSResp.CreatedOnUtc.Year,
                                Business = "Digital Financial Service",
                                AuditOfficer = getannualauditDFSResp.RequesterName,
                                Status = getannualauditDFSResp.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getannualauditDFSResp.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            ARMCapital = new ViewAuditExecutionResp
                            {
                                DateCreated = getannualauditARMCapitalResp.CreatedOnUtc,
                                AuditYear = getannualauditARMCapitalResp.CreatedOnUtc.Year,
                                Business = "ARMCapital",
                                AuditOfficer = getannualauditARMCapitalResp.RequesterName,
                                Status = getannualauditARMCapitalResp.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getannualauditARMCapitalResp.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            ARMTAM = new ViewAuditExecutionResp
                            {
                                DateCreated = getannualauditTAMResp.CreatedOnUtc,
                                AuditYear = getannualauditTAMResp.CreatedOnUtc.Year,
                                Business = "ARMTAM",
                                AuditOfficer = getannualauditTAMResp.RequesterName,
                                Status = getannualauditTAMResp.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getannualauditTAMResp.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            ARMAgribusiness = new ViewAuditExecutionResp
                            {
                                DateCreated = getagriBus.CreatedOnUtc,
                                AuditYear = getagriBus.CreatedOnUtc.Year,
                                Business = "ARMAgribusiness",
                                AuditOfficer = getagriBus.RequesterName,
                                Status = getagriBus.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getagriBus.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
                            },
                            ARMSharedService = new ViewAuditExecutionResp
                            {
                                DateCreated = getsharedservice.CreatedOnUtc,
                                AuditYear = getsharedservice.CreatedOnUtc.Year,
                                Business = "ARMSharedService",
                                AuditOfficer = getsharedservice.RequesterName,
                                Status = getsharedservice.AnualAuditUniverseStatus.ToString(),
                                AnualAuditUniverseRiskRatingId = getsharedservice.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = item.Id,
                                AuditProgramId = getAuditProgramId
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
