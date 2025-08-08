using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.ActionTracker;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
     * Author: Olusegun Adaramaja
     * Date created: 06/12/2023
     * Development Group: GRCTools
     * The endpoint update action progress and action status
     */
    public class ActionTrackerEndpointUpdateActionManagment
    {
        /// <summary>
        /// The endpoint update action progress and action status
        /// </summary>
        /// <param name="updateActionAndStatus"></param>
        /// <param name="actionRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            UpdateActionProgressAndStatusDto updateActionAndStatus, IRepository<ActionManagement> actionRepo,
            ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            var rolesAllowed = new[] { "UnitHead", "RiskChampion" };

            if (currentUserService.CurrentUserRoles.Count == 0 || !currentUserService.CurrentUserRoles.Any(role => rolesAllowed.Contains(role)))
            {
                return TypedResults.Forbid();
            }

            var actonManagment = await actionRepo.GetByIdAsync(updateActionAndStatus.ActionManagementId);            
            
            if (actonManagment is null)
            {
                return TypedResults.NotFound();
            }            
            actonManagment.UpdateActionProgressAndActionState(updateActionAndStatus.ActionProgress, updateActionAndStatus.ActionStatus);
            actionRepo.SaveChanges();

            return TypedResults.Ok("Update successful");
        }
    }
}
