using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Migrations;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 06/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class UpdateConsolidatedAuditFindingEndpoint
    {
        /// <summary>
        /// Update Consolidated Audit Finding Endpoint 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="finding"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateConsolidatedAuditFindingRequest request, IRepository<ConsolidatedAuditFinding> finding,
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

                var checkIfItHasBeenrated = finding.GetContextByConditon(c => c.Id == request.ConsolidatedAuditFindingId).FirstOrDefault();
                if (checkIfItHasBeenrated == null) { return TypedResults.Ok($"Record was not found"); }

                checkIfItHasBeenrated.UpdateConsolidatedAuditFinding(checkIfItHasBeenrated.Id, checkIfItHasBeenrated.InternalAuditReportId, request.ReviewType, request.DateFindingRaised, request.DetailedFindings,
                request.AuditArea, request.Business, request.Level1, request.Level2, request.RevisedDueDate, request.Recommendation, request.ImpactRating, request.WorkStream, request.ReportingQuater, request.ActionDueDate, request.UpdatedComment,
                request.ManagmentResponseAsAtTimeOfEngagement, request.DescriptionOfIssue, request.ActionOwner, request.EngagementName, request.Unit, request.Entity, request.ResolutionDate);
                checkIfItHasBeenrated.SetModifiedBy(checkIfItHasBeenrated.Id);
                checkIfItHasBeenrated.SetModifiedOnUtc(DateTime.Now);
                finding.SaveChanges();
                
                return TypedResults.Ok("Record updated successfully");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
