using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 22/05/2024
      * Development Group: GRCTools
      * Update Consolidated Audit finding status to resolved.    
      */
    public class UpdateRevisedDueDateEndpoint
    {
        /// <summary>
        /// Update Consolidated Audit finding Revised Due Date. 
        /// </summary> 
        /// <param name="consolidatedauditfindingid"></param>
        /// <param name="finding"></param>
        /// <param name="user"></param>
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(Guid consolidatedauditfindingid, DateTime revisedduedate, IRepository<ConsolidatedAuditFinding> finding,
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
                var checkIfItHasBeenReported = finding.GetContextByConditon(c => c.Id == consolidatedauditfindingid).FirstOrDefault();
                if (checkIfItHasBeenReported == null) { return TypedResults.NotFound("No record found"); }

                if (checkIfItHasBeenReported != null)
                {
                    checkIfItHasBeenReported.UpdateRevisedDueDate(revisedduedate);
                    await finding.SaveChangesAsync();
                    return TypedResults.Ok("Successfully updated");
                }

                return TypedResults.Unauthorized();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
