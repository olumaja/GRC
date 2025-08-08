using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 10/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* The endpoint Update audit findings
*/
    public class UpdateInitiateAuditFindsEndpoint
    {
        /// <summary>
        /// This endpoint update audit findings
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="workpaperRepo"></param>
        /// <param name="findingsRepo"></param>
        /// <param name="auditProgramRepo"></param>
        /// <param name="repoComenceRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            UpdatePostAuditFindingsRequest payload, IRepository<AuditFindings> findingsRepo, ICurrentUserService currentUserService, ClaimsPrincipal user)
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
                var getFinding = findingsRepo.GetContextByConditon(a => a.Id == payload.AuditFindingId).FirstOrDefault();
                if (getFinding is null)
                {
                    return TypedResults.NotFound($"Record was not found or it has been previously approved");
                }               
               
                //update request               
                getFinding.UpdateAuditFindings(getFinding.Id, getFinding.WorkerPaperId, payload.ActionToResolve, payload.ActionToPreventReoccurence, payload.ActionDueDate, payload.ActionOwner,
                    payload.ActionOwnerUnit);
                getFinding.SetModifiedBy(getFinding.Id);
                getFinding.SetModifiedOnUtc(DateTime.Now);
                findingsRepo.SaveChanges();

                return TypedResults.Ok($"Record update successfully");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }
        }
    }
}
