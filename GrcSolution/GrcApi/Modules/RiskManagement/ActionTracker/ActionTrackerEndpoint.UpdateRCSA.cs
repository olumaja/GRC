using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.ActionTracker;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
     * Author: Olusegun Adaramaja
     * Date created: 06/12/2023
     * Development Group: GRCTools
     * The endpoint update action progress and action status
     */
    public class ActionTrackerEndpointUpdateRCSA
    {
        /// <summary>
        /// The endpoint update action progress and action status
        /// </summary>
        /// <param name="updateActionAndStatus"></param>
        /// <param name="processInherentRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            UpdateActionAndStatusForRCSADto updateActionAndStatus, IRepository<ProcessInherentRiskControl> processInherentRepo, 
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

            var processInherentRisk = await processInherentRepo.GetByIdAsync(updateActionAndStatus.ProcessInhereRiskControlId);

            if (processInherentRisk is null)
            {
                return TypedResults.NotFound();
            }

            processInherentRisk.UpdateActionProgressAndActionState(updateActionAndStatus.ActionProgress, updateActionAndStatus.ActionStatus);
            processInherentRepo.SaveChanges(); 

            return TypedResults.Ok("Update successful");
        }
    }
}
