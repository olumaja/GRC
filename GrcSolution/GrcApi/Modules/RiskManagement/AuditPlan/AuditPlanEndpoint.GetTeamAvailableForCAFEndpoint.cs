using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 03/06/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  */
    public class GetTeamAvailableForCAFEndpoint
    {
        /// <summary>
        /// Get rated business risk rating
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<InternalAuditReport> repo, IRepository<AuditProgramAuditExecution> auditProgram, IRepository<WorkPaper> workPaper,
            IRepository<AuditFindingAuditReport> ctrltype, IRepository<ManagementResponseAuditReport> action, IRepository<ReportDetailfindings> reportDetailfindings,
            IRepository<ObservationListAuditReport> observationList, IRepository<AssessmentOfDigitalInitiativeList> assessment, ClaimsPrincipal user, ICurrentUserService currentUserService) 
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
                List<ViewTeamAvailableForCAFResp> resp = new List<ViewTeamAvailableForCAFResp>();
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.Team != null && c.Status == BusinessRiskRatingStatus.Approved).ToList();

                if (getBusinessRiskRating != null)
                {
                    foreach (var item in getBusinessRiskRating)
                    {
                        var getWorkpaperRatings = workPaper.GetContextByConditon(a => a.CreatedOnUtc.Year == year && a.Team == item.Team && a.ExceptionsNoted.ToLower() == "yes").OrderBy(x => x.CreatedOnUtc);
                        var getWorkpaperRatingsResp = getWorkpaperRatings.Select(p => new CAFDetailFindingList
                        {
                            Recommendation = p.Recommendation
                           
                        }).ToList();
                        var getrecommendation = assessment.GetContextByConditon(c => c.InternalAuditReportId == item.Id).OrderBy(x => x.CreatedOnUtc);                        
                        var getrecommendationList = getrecommendation.Select(p => new GetRecommendation
                        {
                            Observation = p.Observation,
                            ActionOwner = p.ActionOwner,
                            ManagementResponse = p.ManagementResponse,
                            Destination = p.Destination,
                            DueDate = p.DueDate
                        }).ToList();                                               
                        var getreportDetailfindings = reportDetailfindings.GetContextByConditon(c => c.InternalAuditReportId == item.Id).OrderBy(x => x.CreatedOnUtc);
                        var getreportDetailfindingsList = getreportDetailfindings.Select(p => new GetReportDetailfindingList
                        {
                            DescriptionOfFinding = p.DescriptionOfIssue,
                            ImpactRating = p.IssueRating,
                            DetailedFindings = p.Observation,
                            PotentialMaterialisedImpact = p.PotentialMaterialisedImpact,
                            Recommendation = p.Recommendation
                            
                        }).ToList();
                        var getAction = action.GetContextByConditon(c => c.InternalAuditReportId == item.Id).FirstOrDefault();
                        string managementResponse = null;
                        string actionOwner = null;
                        string MgtrespontUnit = null;
                        DateTime dueDate = item.CreatedOnUtc;
                        if (getAction != null)
                        {
                            managementResponse = getAction.ActionPointToResolve;
                            actionOwner = getAction.ActionOwner;
                            MgtrespontUnit = getAction.Unit;
                            dueDate = getAction.DueDate;
                        }

                        var getManagResp = action.GetContextByConditon(c => c.InternalAuditReportId == item.Id).OrderBy(x => x.CreatedOnUtc);
                        var getManagRespList = getManagResp.Select(p => new GetManagemetRespList
                        {
                            ActionPointToResolve = p.ActionPointToResolve,
                            ActionOwner = p.ActionOwner,
                            Unit = p.Unit,
                            DueDate = p.DueDate,
                            Designation = p.Designation
                        }).ToList();
                        var getctrltype = ctrltype.GetContextByConditon(c => c.InternalAuditReportId == item.Id).FirstOrDefault();
                        string level1 = null;                       
                        if (getctrltype != null)
                        {
                            level1 = getctrltype.ControlType;                           
                        }
                        string unit = "ARMShareService";
                        if (item.Team == "ARMTAM") { unit = "ARMTAM"; }
                        if (item.Team == "Digital Financial Service") { unit = "Digital Financial Service"; }
                        if (item.Team == "ARMHill") { unit = "ARMHill"; }
                        if (item.Team == "ARMCapital") { unit = "ARMCapital"; }
                        if (item.Team == "Stock Broking") { unit = "ARMSecurity"; }
                        if (item.Team == "Private Trust" || item.Team == "Commercial Trust") { unit = "ARMTrustee"; }
                        if (item.Team == "RFL" || item.Team == "AAFML") { unit = "ARMAgribusiness"; }
                        if (item.Team == "IMUnit" || item.Team == "Research" || item.Team == "BDPWMIAMIMRetail" || item.Team == "Fund Account" || item.Team == "Fund Admin" || item.Team == "Retail Operation" || item.Team == "ARM Register" || item.Team == "Operation Settlement" || item.Team == "Operation Control") { unit = "ARMIM"; }

                        resp.Add(new ViewTeamAvailableForCAFResp
                        {
                            TeamDetail = new ViewTeamAvailableForCAF
                            {
                                InternalAuditReportId = item.Id,
                                Year = year,
                                Business = unit,
                                Team = item.Team,
                                AuditArea = item.Team,
                                DetailedFindings = getreportDetailfindingsList, 
                                Recommendations = getWorkpaperRatingsResp,
                                Observation = getrecommendationList,
                                ActionOwner = actionOwner,
                                Unit = MgtrespontUnit,
                                ActionDueDate = dueDate,  
                                DateFindingRaised = item.CreatedOnUtc, 
                                Level1 = level1,
                                ManagementResponseAsAtTimeOfReport = getManagRespList, 
                                Status = item.Status.ToString()
                            }                        
                        });

                    }
                    return TypedResults.Ok(resp);
                }
                return TypedResults.NotFound("Record was not found");

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound();
            }

        }
    }

}
