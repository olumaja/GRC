using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using GrcApi.Modules.Shared.Helpers;

namespace GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
    * Original Author: McCarthy Nwosu
    * Date Created: 09/12/2023
    * Development Group: GRCTools
    * View the reports on all modules in Risk management. 
    */
    public class ViewEventDescriptionByIDEndpoint
    {
        /// <summary>
        /// View the reports on all modules in Risk management
        /// </summary> 
        /// <param name="actionManagementRepo"></param>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(
            IRepository<ActionManagement> actionManagementRepo, IRepository<Arm.GrcTool.Domain.RiskEvent.RiskEvent> repo, 
            Guid id, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string status = "";                
                
                var getStatus = await actionManagementRepo.GetContextByConditon(x => x.Id == id).FirstOrDefaultAsync();

                if (getStatus is null) 
                    return TypedResults.NotFound("Record not found");

                if(getStatus.ActionStatus == ActionState.Open)
                {
                    status = "Open";
                }
                if (getStatus.ActionStatus == ActionState.Pending)
                {
                    status = "Pending";
                }
                if (getStatus.ActionStatus == ActionState.Closed)
                {
                    status = "Closed";
                }
                int noOfDays = 0;
                var toDate = DateOnly.FromDateTime(DateTime.Now);
                var res = toDate.Day - getStatus.ActionResolutionDate.Day;
                if (res > 0)
                {
                    noOfDays = res;
                }

                var getEventDescription = repo.GetContextByConditon(x => x.Id == getStatus.RiskEventId).Select(x => x.RiskEventDescription).FirstOrDefault();

                var viewEventSummary = await actionManagementRepo.GetContextByConditon(x => x.Id == id)
                     .Select(y => new ViewEventDescriptionDTO
                     {
                         ActionManagementId = y.Id,
                         ActionOwner = y.ActionOwner,
                         CorrectiveActions = y.Action,
                         DueDate = y.ActionResolutionDate,
                         ActionProgress = y.ActionProgress,
                         Status = status,
                         NoOfDaysLeft = noOfDays,
                         EventDescription = getEventDescription
                     }).FirstOrDefaultAsync();

                if (viewEventSummary is null)
                {
                    return TypedResults.NotFound("No record");
                }

                return TypedResults.Ok(viewEventSummary);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Record not found", null, 500);
            }
        }
    }
}

