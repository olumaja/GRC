using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.ActionTracker;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
* Original Author: McCarthy Nwosu
* Date Created: 09/12/2023
* Development Group: GRCTools
* View the reports on all modules in Risk management. 
*/

    public class ViewActionSummaryByIDEndpoint
    {
        /// <summary>
        /// View the reports on all modules in Risk management
        /// </summary> 
        /// <param name="actionManagementRepo"></param>
        /// <param name="Id"></param>
        /// <returns></returns>   

        public static async Task<IResult> HandleAsync(IRepository<ProcessInherentRiskControl> actionManagementRepo, IRepository<RSCAProcess> processName, 
            Guid Id, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string status = "";
                var viewActionSummary = await actionManagementRepo.GetByIdAsync(Id);

                if(viewActionSummary is null)
                    return TypedResults.NotFound("Record not found");

                var getProcessName = processName.GetContextByConditon(x => x.Id == viewActionSummary.ProcessId).Select(x => x.Name).FirstOrDefault();

                if (viewActionSummary.ActionStatus == PIRCActionState.Open)
                {
                    status = "Open";
                }
                if (viewActionSummary.ActionStatus == PIRCActionState.Pending)
                {
                    status = "Pending";
                }
                if (viewActionSummary.ActionStatus == PIRCActionState.Complete)
                {
                    status = "Completed";
                }
                if (viewActionSummary is null)
                {
                    return TypedResults.NotFound();

                }
                int noOfDays = 0;
                var toDate = DateOnly.FromDateTime(DateTime.Now);
                var res = viewActionSummary.TimeLine.Value.Day - toDate.Day;
                if (res > 0)
                {
                    noOfDays = res;
                }
                var varResp = new ViewActionItemSummaryDTO
                {
                    
                    ProcessInherentRiskId= viewActionSummary.Id,   
                    Process= getProcessName,
                    Control= viewActionSummary.Control,
                    InherentRisk= viewActionSummary.InherentRisk,
                    ResidualRisk= viewActionSummary.ResidualRisks,
                    ActionProgress = viewActionSummary.ActionProgress,
                    Status = status,
                    NoOfDaysLeft = noOfDays,
                    CorrectiveAction = viewActionSummary.CorrectiveActions,
                };

                return TypedResults.Ok(varResp);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Record not found", null, 500);
            }
        }
    }
}
