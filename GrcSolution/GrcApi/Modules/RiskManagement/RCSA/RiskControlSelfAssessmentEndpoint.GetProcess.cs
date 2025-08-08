using Arm.GrcApi.Modules.BusinessEntities;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.RiskManagement;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetProcess
    {
        public static async Task<IResult> HandleAsync(IRepository<RSCAProcess> repoProcess, ICurrentUserService currentUserService)
        {
			try
			{
                var unitIdValue = currentUserService.CurrentUserUnitId;

                if (unitIdValue is null)
                {
                    return TypedResults.Ok("Unit was not found");
                }

                Guid unitId = unitIdValue.Value;
                var processes = repoProcess.GetContextByConditon(r => r.UnitId == unitId && !r.IsDeleted).ToList();
                IList<RiskControlSelfAssessmentGetProcessDto> processesDto = processes.OrderBy(p => p.Name).Select(p => new RiskControlSelfAssessmentGetProcessDto
                (
                    Id: p.Id,
                    Name: p.Name,
                    UnitId: p.UnitId
                )).ToList();

                return TypedResults.Ok(processesDto);
            }
            catch (Exception ex)
			{
                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
