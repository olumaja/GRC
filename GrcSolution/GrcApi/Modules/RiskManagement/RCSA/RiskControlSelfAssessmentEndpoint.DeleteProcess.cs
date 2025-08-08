using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class DeleteProcessEndpoint
    {
        public static async Task<IResult> HandleAsync(
            DeleteRCSAProcessDto payload, IRepository<RSCAProcess> repoProcess, ICurrentUserService currentUserService
        )
        {
            if (currentUserService.CurrentUserDepartment != "Risk Management" && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.RiskChampion))
                return TypedResults.Forbid();

            var processes = repoProcess.GetContextByConditon(p => p.Name.ToLower() == payload.ProcessName.ToLower())
                                        .ToList();

            var currentUser = currentUserService.CurrentUserFullName;

            if(processes.Count == 0)
                return TypedResults.NotFound($"Process {payload.ProcessName} does not exist");

            for(var i = 0; i < processes.Count; i++)
            {
                processes[i].SetLastModifiedBy(currentUser);
                processes[i].SetDeletedBy(currentUser);
                processes[i].SetModifiedOnUtc(DateTime.Now);
                processes[i].SetDelete();
            }

            repoProcess.SaveChanges();
            return TypedResults.Ok("Process deleted successfully");
        }
    }
}
