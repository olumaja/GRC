using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 29/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* Endpoint to View work papaer details
*/
    public class ViewWorkPaperDetailsEndpoint
    {
        /// <summary>
        /// Endpoint to View Work Paper Reports
        /// </summary>
        /// <param name="workpaperRepo"></param>
        /// <param name="auditProgramRepo"></param>
        /// <param name="annualaudit"></param>
        /// <param name="holdco"></param>
        /// <param name="armIM"></param>
        /// <param name="security"></param>
        /// <param name="trustee"></param>
        /// <param name="armHill"></param>
        /// <param name="agriBus"></param>
        /// <param name="sharedservice"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<WorkPaper> workpaperRepo, IRepository<AuditProgramAuditExecution> auditProgramRepo, 
            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMHoldingCompanyAnnualAuditUniverse> holdco,
            IRepository<ARMIMAuditUniverse> armIM, IRepository<ARMSecurityAnnualAuditUniverse> security, IRepository<ARMTrusteeAuditUniverse> trustee,
            IRepository<ARMHillAuditUniverse> armHill, IRepository<ARMAgribusinessAuditUniverse> agriBus, IRepository<ARMSharedAuditUniverse> sharedservice,
            IRepository<CommenceEngagementAuditexecution> commenceEng,
            ClaimsPrincipal user)
        {
            try
            {
                if (user == null)
                {
                    return TypedResults.BadRequest("User must be logged in");
                }
                //string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                var year = DateTime.Now.Year;
                List<ViewWorkPaperReport> viewResp = new List<ViewWorkPaperReport>();

                var commenceEngResp = await commenceEng.GetAllAsync();
                var getannualaudit = await annualaudit.GetAllAsync();
                var getworkpaperRepo = await workpaperRepo.GetAllAsync();
                var auditProgramRepoResp = await auditProgramRepo.GetAllAsync();
                var holdcoResp = await holdco.GetAllAsync();
                var armIMResp = await armIM.GetAllAsync();
                var securityResp = await security.GetAllAsync();
                var trusteeResp = await trustee.GetAllAsync();
                var armHillResp = await armHill.GetAllAsync();
                var agriBusResp = await agriBus.GetAllAsync();
                var sharedserviceResp = await sharedservice.GetAllAsync();
                if (getworkpaperRepo == null)
                {
                    return TypedResults.NotFound($"Work paper has not been initiated after audit program");
                }
                if (getworkpaperRepo != null)
                {
                    foreach (var item in getworkpaperRepo)
                    {
                        
                        var getauditProgramRepoResp = auditProgramRepoResp.Find(x => x.Id.Equals(item.AuditProgramId));
                        var commenceEngRespResp = commenceEngResp.Find(x => x.Id.Equals(getauditProgramRepoResp.CommenceEngagementAuditexecutionId));
                        if(commenceEngRespResp == null)
                        {
                            return TypedResults.NotFound($"Commence engagement has not been initiated");
                        }
                                                
                        if (commenceEngRespResp != null)
                        {

                            var getannualauditResp = getannualaudit.Find(x => x.Id.Equals(commenceEngRespResp.AnualAuditUniverseRiskRatingId));
                           
                            var getholdco = holdcoResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(getannualauditResp.Id));
                            var getarmIM = armIMResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(getannualauditResp.Id));
                            var getsecurity = securityResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(getannualauditResp.Id));
                            var gettrustee = trusteeResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(getannualauditResp.Id));
                            var getarmHill = armHillResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(getannualauditResp.Id));
                            var getagriBus = agriBusResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(getannualauditResp.Id));
                            var getsharedservice = sharedserviceResp.Find(x => x.AnualAuditUniverseRiskRatingId.Equals(getannualauditResp.Id));

                            viewResp.Add(new ViewWorkPaperReport
                            {
                                AuditProgramId = item.AuditProgramId,
                                AnualAuditUniverseRiskRatingId = commenceEngRespResp.AnualAuditUniverseRiskRatingId,
                                CommenceengagementId = commenceEngRespResp.Id,
                                DateCreated = item.CreatedOnUtc,
                                AuditYear = item.CreatedOnUtc.Year,
                                AuditOfficer = getauditProgramRepoResp.RequesterName,
                                IssueRating = item.IssueRating,
                                ARMHoldingCompany = new ViewWorkPaperResp
                                {
                                    AuditProgramId = item.AuditProgramId,
                                    DateCreated = item.CreatedOnUtc,
                                    AuditYear = item.CreatedOnUtc.Year,
                                    Business = "ARMHoldingCompany",
                                    AuditOfficer = getauditProgramRepoResp.RequesterName,
                                    IssueRating = item.IssueRating,
                                    AnualAuditUniverseRiskRatingId = commenceEngRespResp.AnualAuditUniverseRiskRatingId,
                                    CommenceengagementId = commenceEngRespResp.Id
                                },
                                ARMIM = new ViewWorkPaperResp
                                {
                                    AuditProgramId = item.AuditProgramId,
                                    DateCreated = item.CreatedOnUtc,
                                    AuditYear = item.CreatedOnUtc.Year,
                                    Business = "ARMIM",
                                    AuditOfficer = getauditProgramRepoResp.RequesterName,
                                    IssueRating = item.IssueRating,
                                    AnualAuditUniverseRiskRatingId = commenceEngRespResp.AnualAuditUniverseRiskRatingId,
                                    CommenceengagementId = commenceEngRespResp.Id
                                },
                                ARMSecurity = new ViewWorkPaperResp
                                {
                                    AuditProgramId = item.AuditProgramId,
                                    DateCreated = item.CreatedOnUtc,
                                    AuditYear = item.CreatedOnUtc.Year,
                                    Business = "ARMSecurity",
                                    AuditOfficer = getauditProgramRepoResp.RequesterName,
                                    IssueRating = item.IssueRating,
                                    AnualAuditUniverseRiskRatingId = commenceEngRespResp.AnualAuditUniverseRiskRatingId,
                                    CommenceengagementId = commenceEngRespResp.Id
                                },
                                ARMTreasury = new ViewWorkPaperResp
                                {
                                    AuditProgramId = item.AuditProgramId,
                                    DateCreated = item.CreatedOnUtc,
                                    AuditYear = item.CreatedOnUtc.Year,
                                    Business = "ARMTreasury",
                                    AuditOfficer = getauditProgramRepoResp.RequesterName,
                                    IssueRating = item.IssueRating,
                                    AnualAuditUniverseRiskRatingId = commenceEngRespResp.AnualAuditUniverseRiskRatingId,
                                    CommenceengagementId = commenceEngRespResp.Id
                                },
                                ARMHill = new ViewWorkPaperResp
                                {
                                    AuditProgramId = item.AuditProgramId,
                                    DateCreated = item.CreatedOnUtc,
                                    AuditYear = item.CreatedOnUtc.Year,
                                    Business = "ARMHill",
                                    AuditOfficer = getauditProgramRepoResp.RequesterName,
                                    IssueRating = item.IssueRating,
                                    AnualAuditUniverseRiskRatingId = commenceEngRespResp.AnualAuditUniverseRiskRatingId,
                                    CommenceengagementId = commenceEngRespResp.Id
                                },
                                ARMAgribusiness = new ViewWorkPaperResp
                                {
                                    AuditProgramId = item.AuditProgramId,
                                    DateCreated = item.CreatedOnUtc,
                                    AuditYear = item.CreatedOnUtc.Year,
                                    Business = "ARMAgribusiness",
                                    AuditOfficer = getauditProgramRepoResp.RequesterName,
                                    IssueRating = item.IssueRating,
                                    AnualAuditUniverseRiskRatingId = commenceEngRespResp.AnualAuditUniverseRiskRatingId,
                                    CommenceengagementId = commenceEngRespResp.Id
                                },
                                ARMSharedService = new ViewWorkPaperResp
                                {
                                    AuditProgramId = item.AuditProgramId,
                                    DateCreated = item.CreatedOnUtc,
                                    AuditYear = item.CreatedOnUtc.Year,
                                    Business = "ARMSharedService",
                                    AuditOfficer = getauditProgramRepoResp.RequesterName,
                                    IssueRating = item.IssueRating,
                                    AnualAuditUniverseRiskRatingId = commenceEngRespResp.AnualAuditUniverseRiskRatingId,
                                    CommenceengagementId = commenceEngRespResp.Id
                                },
                            });
                        }

                    }
                    return TypedResults.Ok(viewResp);
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }


        }
    }
}
