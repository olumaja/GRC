using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 22/05/2024
     * Development Group: GRCTools
     * Update Consolidated Audit finding status to resolved.    
     */
    public class UpdateStatusToResolvedEndpoint
    {
        /// <summary>
        /// Update Consolidated Audit finding status to resolved. 
        /// </summary> 
        /// <param name="consolidatedauditfindingid"></param>
        /// <param name="finding"></param>
        /// <param name="user"></param>
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(Guid consolidatedauditfindingid, IRepository<ConsolidatedAuditFinding> finding,
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
                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
               
                var checkIfItHasBeenReported = finding.GetContextByConditon(c => c.Id == consolidatedauditfindingid).FirstOrDefault();
                if (checkIfItHasBeenReported == null) { return TypedResults.NotFound("The record was not created by you or no record found"); }
                               
                if (checkIfItHasBeenReported != null)
                {
                    checkIfItHasBeenReported.UpdateStatus();
                    await finding.SaveChangesAsync();
                    return TypedResults.Ok("Successfully updated");
                }

                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
