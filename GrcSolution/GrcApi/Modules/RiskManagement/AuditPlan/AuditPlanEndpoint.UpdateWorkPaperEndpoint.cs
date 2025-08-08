using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 10/05/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * The endpoint Initiate work paper
 */
    public class UpdateWorkPaperEndpoint
    {
        /// <summary>
        /// The endoint update work paper
        /// </summary>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            UpdatePostWorkPaperRequest payload, IRepository<WorkPaper> workpaperRepo, ICurrentUserService currentUserService, ClaimsPrincipal user)
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

                var checkworkPaper = workpaperRepo.GetContextByConditon(a => a.Id == payload.WorkpapperId).FirstOrDefault();
                if (checkworkPaper == null) { return TypedResults.Ok($"Record was not found or it has been previously approved"); }

                //update request               
                checkworkPaper.UpdateWorkPaper(checkworkPaper.Id, checkworkPaper.AuditProgramId, payload.Reference, payload.Reoccurence, payload.ExceptionNoted, payload.IssueSummary, payload.RootCause, payload.Impact, payload.Recommendation, payload.IssueRating, payload.ReviewResult);
                checkworkPaper.SetModifiedBy(checkworkPaper.Id);
                checkworkPaper.SetModifiedOnUtc(DateTime.Now);
                workpaperRepo.SaveChanges();

                return TypedResults.Ok($"Record updated successfully");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }
        }
    }
}
