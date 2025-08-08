using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public class BIACreateProcessEndpoint
    {
        public static async Task<IResult> HandleAsync(
             CreateRCSAProcessDto payload, IRepository<RSCAProcess> repoProcess, IRepository<Unit> unitRepo, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (currentUserService.CurrentUserDepartment != "Risk Management" && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.RiskChampion))
                    return TypedResults.Forbid();

                var currentUser = currentUserService.CurrentUserFullName;
                var unitIds = unitRepo.GetContextByConditon(u => u.Name.ToLower() == payload.Unit.ToLower())
                                    .Select(u => u.Id)
                                    .ToList();

                if (unitIds.Count == 0)
                    return TypedResults.BadRequest($"Unit {payload.Unit} does not exist");

                var processes = new List<RSCAProcess>();
                foreach (var unitId in unitIds)
                {
                    var process = RSCAProcess.Create(payload.ProcessName, unitId);
                    process.AddInitiator(currentUser);
                    process.SetLastModifiedBy(currentUser);
                    process.SetModifiedOnUtc(DateTime.Now);
                    processes.Add(process);
                }

                repoProcess.AddRange(processes);
                repoProcess.SaveChanges();

                return TypedResults.Ok("Process created successfully");
            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Servic not available");
            }

        }
    }
}
