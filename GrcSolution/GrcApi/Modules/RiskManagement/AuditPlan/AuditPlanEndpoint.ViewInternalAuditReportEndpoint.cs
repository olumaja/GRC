using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 16/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint View Internal Audit Report 
*/
    public class ViewInternalAuditReportEndpoint
    {
        /// <summary>
        /// View Internal Audit Report 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<BusinessRiskRating> repo, IRepository<InternalAuditReport> internalAuditReport,
            IRepository<AnualAuditUniverseRiskRating> annualAudit,  IRepository<CommenceEngagementAuditexecution> commenceengagemnt, ClaimsPrincipal user, ICurrentUserService currentUserService 
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
                var year = DateTime.Now.Year;
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.Id != null).ToList();
                var getBusiness = await repo.GetAllAsync();
                var getannualAudit = await annualAudit.GetAllAsync();
                var getAuditRating = await internalAuditReport.GetAllAsync();
                var getcommenceengagemnt = await commenceengagemnt.GetAllAsync();
                var commenceengagements = commenceengagemnt.GetContextByConditon(c => c.Team != null && c.CreatedOnUtc.Year == year && c.WorkPaper == BusinessRiskRatingStatus.Approved && c.EngagementPlan == BusinessRiskRatingStatus.Approved && c.Findingstatus == BusinessRiskRatingStatus.Approved).ToList(); 
                List<ViewInternalAuditReportResp> resp = new List<ViewInternalAuditReportResp>();
                int availableReportDFS = 1;
                int availableReporttam = 1;
                int availableReportarmim = 9;
                int availableReporttrustee = 2;
                int availableReporthill = 1;
                int availableReportsecurty = 1;
                int availableReportagri = 2;
                int availableReportARMCapital = 1;
                int availableReportshared = 16;
                int totalavailableReport = availableReportDFS + availableReportARMCapital + availableReporttam + availableReportarmim + availableReporttrustee + availableReporthill + availableReportsecurty + availableReportagri + availableReportshared;
                //no of teams in a unit
                //int totalholdco = 2;
                int totaltam = 1;
                int totalarmim = 9;
                int totaltrustee = 2;
                int totalhill = 1;
                int totalsecurty = 1;
                int totalagri = 2;
                int totalshared = 16;
                int totalDFS = 1;
                int totalARMCapital = 1;
                int totalTeam = totalDFS + totaltam + totalarmim + totaltrustee + totalhill + totalsecurty + totalagri + totalshared + totalARMCapital;
                if (getBusinessRiskRating is not null)
                {
                   foreach (var item in commenceengagements)  
                    {
                        var getannualAuditResp = annualAudit.GetContextByConditon(c => c.Id == item.AnualAuditUniverseRiskRatingId).FirstOrDefault();
                        Guid annualAuditUniverseId = Guid.Empty;
                        if (getannualAuditResp != null)
                        {
                            annualAuditUniverseId = getannualAuditResp.Id;
                        }
                        var getAuditRatingResp = internalAuditReport.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == item.Id).FirstOrDefault(); 
                       
                        Guid auditReportId = Guid.Empty;
                        if (getAuditRatingResp != null)
                        {
                            auditReportId = getAuditRatingResp.Id;
                        }
                        var getauditReportTeam = internalAuditReport.GetContextByConditon(a => a.Team != null);
                        Guid reportId = Guid.Empty;
                        string? unit = null;
                        string? team = null;
                        if (getauditReportTeam == null)
                        {
                            reportId = Guid.Empty;
                            unit = null;
                            team = null;
                        }
                        var getauditReportTeamList = getauditReportTeam.Select(p => new GetAuditReportTeam
                        {
                            AuditReportId = p.Id,
                            BusinesUnit = p.Unit,
                            Team = p.Team,
                           
                        }).ToList();
                        resp.Add(new ViewInternalAuditReportResp
                        {
                            DateCreated = item.CreatedOnUtc,
                            AuditYear = DateTime.Now.Year,
                            Units = 9,
                            TotalTeam = totalTeam,
                            AvailableReports = totalavailableReport,
                            AnnualAuditUniverseId = annualAuditUniverseId,
                            CommenceEngagementId = item.Id,
                            AuditReportTeam = getauditReportTeamList,
                            Unit = new BusinessUnit
                            {
                                ARMIM = new UnitDetails
                                {
                                    Unit = "ARMIM",
                                    TotalTeam = totalarmim,
                                    AvailableReports = availableReportarmim,                                   
                                    Team = "IMUnit, BDPWMIAMIMRetail, Research, Fund Account, Fund Admin, Retail Operation, ARM Register, Operation Control, Operation Settlement"
                                                                       
                                },
                                ARMTAM = new UnitDetails
                                {
                                    Unit = "ARMTAM",
                                    TotalTeam = totaltam,
                                    AvailableReports = availableReporttam,
                                    Team = "ARMTAM"
                                },
                                ARMSecurity = new UnitDetails
                                {
                                    Unit = "ARMSecurity",
                                    TotalTeam = totalsecurty,
                                    AvailableReports = availableReportsecurty,
                                    Team = "Stock Broking"
                                },
                                ARMHill = new UnitDetails
                                {
                                    Unit = "ARMHill",
                                    TotalTeam = totalhill,
                                    AvailableReports = availableReporthill,
                                    Team = "ARMHill"
                                },
                                ARMTrustee = new UnitDetails
                                {
                                    Unit = "ARMTrustee",
                                    TotalTeam = totaltrustee,
                                    AvailableReports = availableReporttrustee,
                                    Team = "Private Trust, Commercial Trust"
                                },
                                ARMAgribusiness = new UnitDetails
                                {
                                    Unit = "ARMAgribusiness",
                                    TotalTeam = totalagri,
                                    AvailableReports = availableReportagri,
                                    Team = "RFL, AAFML"
                                },
                                DigitalFinancialService = new UnitDetails
                                {
                                    Unit = "Digital Financial Service",
                                    TotalTeam = totalDFS,
                                    AvailableReports = availableReportDFS,
                                    Team = "Digital Financial Service"
                                },
                                ARMCapital = new UnitDetails
                                {
                                    Unit = "ARMCapital",
                                    TotalTeam = totalDFS,
                                    AvailableReports = availableReportDFS,
                                    Team = "ARMCapital"
                                },
                                ARMShareService = new UnitDetails
                                {
                                    Unit = "ARMShareService",
                                    TotalTeam = totalshared,
                                    AvailableReports = availableReportshared,
                                    Team = "HCM, Procurement Advisory, IT, Risk Management, Academy, Legal, MCC, CTO, Customer Experience, Information Security, internal Control, Corporate strategy, Treasury, Data Analytic, Financial Control, Compliance"
                                }
                            }
                        });
                    }
                    return TypedResults.Ok(resp.Take(1));

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
