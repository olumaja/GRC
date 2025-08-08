using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 24/05/2024
 * Development Group: Get Audit Reports
 */
    public class GetAuditReportEndpoint
    {

        /// <summary>
        /// Get Audit Reports
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<InternalAuditReport> repo, ClaimsPrincipal user, ICurrentUserService currentUserService
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

                List<GetInternalAuditReport> resp = new List<GetInternalAuditReport>();
                var getAuditReport = repo.GetContextByConditon(c => c.Id != null).ToList();
                if (getAuditReport == null)
                {
                    return TypedResults.NotFound("No record found");
                }
                if (getAuditReport != null)
                {
                    foreach (var item in getAuditReport)
                    {
                        resp.Add(new GetInternalAuditReport
                        {
                            AuditReportId = item.Id,
                            RequesterName = item.RequesterName,
                            Unit = item.Unit,
                            Team = item.Team,
                            Summary = item.Summary,
                            Scope = item.Scope,
                            ScopeLimitation = item.ScopeLimitation,
                            ExecutiveSummary = item.ExecutiveSummary

                        });

                    }
                    return TypedResults.Ok(resp);
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
