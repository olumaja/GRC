using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
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
    public class UpdateAuditPlanningMemoEndpoint
    {
        /// <summary>
        /// Commence Engagement- Update Audit Planning Memo   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="planningTime"></param>
        /// <param name="auditPlanning"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateAuditPlanningMemoAuditExecutionReq request, IRepository<AuditPlanningMemoPlanningTimeline> planningTime,
            IRepository<AuditPlanningMemoAuditExecution> auditPlanning, ClaimsPrincipal user, ICurrentUserService currentUserService)
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

                var checkIfItHasBeenrated = auditPlanning.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == request.CommenceEngagementId).FirstOrDefault();
                if (checkIfItHasBeenrated == null) { return TypedResults.Ok($"Record was not found or it has been previously approved"); }
               
                //update request               
                checkIfItHasBeenrated.UpdateAuditPlanningMemoAuditExecution(checkIfItHasBeenrated.Id, checkIfItHasBeenrated.CommenceEngagementAuditexecutionId, request.BusinessDescription, request.StrategicObjective, request.ImplementationPlan,
                    request.RiskIdentified, request.ScopeAndControlTesting, request.PriorAuditObservation, request.SystemOverview, request.Policies, request.RegulatoryConsideration);
                checkIfItHasBeenrated.SetModifiedBy(checkIfItHasBeenrated.Id);
                checkIfItHasBeenrated.SetModifiedOnUtc(DateTime.Now);
                auditPlanning.SaveChanges();


                foreach (var item in request.PlanningTimeline)
                {
                    var getplanningTime = planningTime.GetContextByConditon(c => c.AuditPlanningMemoAuditExecutionId == checkIfItHasBeenrated.Id).FirstOrDefault();
                    if (getplanningTime == null)
                    { return TypedResults.NotFound("Audit Announcement Memo planning time was not found"); }

                    getplanningTime.UpdateAuditPlanningMemoPlanningTimeline(getplanningTime.Id, getplanningTime.AuditPlanningMemoAuditExecutionId, item.Tasks, item.PlannedDate, item.CompletedDate, item.Responsibility);
                    getplanningTime.SetModifiedBy(getplanningTime.Id);
                    getplanningTime.SetModifiedOnUtc(DateTime.Now);
                }
                planningTime.SaveChanges();
                return TypedResults.Ok("Record updated successfully");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
