using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.BusinessEntities;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetAllRCSA
    {
        public static async Task<IResult> HandleAsync(IRepository<RiskControlSelfAssessment> repository, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
			try
			{
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var rcsaList = repository
                    .GetAll().Include(e => e.RiskControlSelfAssessmentUnits).Select(r => new RiskControlSelfAssessmentDto
                    {
                        CreatedDate = r.CreatedOnUtc,
                        PeriodFrom = r.PeriodFrom,
                        PeriodTo = r.PeriodTo,
                        StartDate = r.StartDate,
                        EndDate = r.EndDate,
                        Id = r.Id,
                        RiskControlSelfAssessmentUnits = r.RiskControlSelfAssessmentUnits.Select(u => new UnitDto(u.Unit.Name, u.Unit.Id)).ToList(),
                        NumberOfRiskControlSelfAssessmentUnits = r.RiskControlSelfAssessmentUnits.Count
                    }).ToList();

                return TypedResults.Ok(rcsaList);
            }
			catch (Exception ex)
			{

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
