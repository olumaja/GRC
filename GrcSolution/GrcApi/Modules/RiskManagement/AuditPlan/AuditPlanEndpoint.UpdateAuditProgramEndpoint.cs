using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Olusegun Adaramaja
* Date Created: 10/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* The endpoint update Audit program
*/
    public class UpdateAuditProgramEndpoint
    {
        /// <summary>
        /// This endpoint update audit program by commence engagement audit execution id
        /// </summary>
        /// <param name="updateAuditPrograms"></param>
        /// <param name="repoAuditProgram"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            [FromBody] UpdateAuditProgramRequest updateAuditPrograms, IRepository<AuditProgramAuditExecution> repoAuditProgram, IRepository<CommenceEngagementAuditexecution> engagement, ICurrentUserService currentUserService, ClaimsPrincipal user
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

                var getEngagementId = engagement.GetContextByConditon(c => c.Id == updateAuditPrograms.CommenceEngagementId).FirstOrDefault();
                if (getEngagementId == null) { return TypedResults.NotFound("Commence engagement was not found"); }

                foreach (var item in updateAuditPrograms.AuditProgrammes)
                {
                    var auditPrograms = repoAuditProgram.GetContextByConditon(c => c.Id == item.AuditProgramId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                    if (auditPrograms == null)
                    { return TypedResults.NotFound("Audit program was not found");  }
                                     
                    //update request               
                    auditPrograms.UpdateAuditProgramAuditExecution(auditPrograms.Id, auditPrograms.CommenceEngagementAuditexecutionId, item.Process, item.SubProcess, item.RiskDescription, item.ControlDescription, item.ControlObjectives, item.ReviewProcedure, item.InformationRequired, item.Comment);
                    auditPrograms.SetModifiedBy(auditPrograms.Id);
                    auditPrograms.SetModifiedOnUtc(DateTime.Now);
                    repoAuditProgram.SaveChanges();
                }
                repoAuditProgram.SaveChanges();
                return TypedResults.Ok("Record updated successfully");

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }
        }
    }
}
