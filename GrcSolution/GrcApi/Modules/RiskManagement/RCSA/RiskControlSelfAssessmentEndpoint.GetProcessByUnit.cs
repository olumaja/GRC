using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class GetProcessByUnitEndpoint
    {
        public static async Task<IResult> HandleAsync(string unitName, IRepository<RSCAProcess> repoProcess, IRepository<Unit> repoUnit)
        {
            var unit = repoUnit.GetContextByConditon(u => u.Name.ToLower() == unitName.ToLower())
                                .Include(u => u.RSCAProcess)
                                .FirstOrDefault();

            if (unit is null)
                return TypedResults.NotFound($"Unit {unitName} does not exist");

            return TypedResults.Ok(unit.RSCAProcess.Where(p => !p.IsDeleted).OrderBy(p => p.Name).Select(p => new GetRCSAProcessResponse(Id: p.Id, ProcessName: p.Name)));
        }
    }
}
