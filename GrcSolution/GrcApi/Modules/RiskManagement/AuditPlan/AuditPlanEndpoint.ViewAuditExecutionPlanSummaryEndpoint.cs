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
 * Endpoint to View Audit Execution Plan summary for the year
 */
    public class ViewAuditExecutionPlanSummaryEndpoint
    {
        /// <summary>
        /// Endpoint to View Audit Execution Plan summary for the year
        /// </summary>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<CommenceEngagementAuditexecution> commenceEng,
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
                List<ViewAuditExecutionPlanSummaryResp> viewResp = new List<ViewAuditExecutionPlanSummaryResp>();
                var getRating = commenceEng.GetContextByConditon(x => x.Id != null).OrderByDescending(x => x.CreatedOnUtc).ToList();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed");
                }
                
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                        
                        viewResp.Add(new ViewAuditExecutionPlanSummaryResp
                        {
                            CommenceEngagementId = item.Id,
                            Team = item.Team,
                            EngagementPlanStatus = item.EngagementPlan.ToString(),
                            WorkPaperStatus = item.WorkPaper.ToString(),
                            Findingstatus = item.Findingstatus.ToString()                         
                           
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
