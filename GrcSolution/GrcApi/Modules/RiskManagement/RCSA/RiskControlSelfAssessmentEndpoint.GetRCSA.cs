using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.BusinessEntities;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetRCSA
    {
        public static async Task<IResult> HandleAsync(IRepository<RiskControlSelfAssessment> repository, Guid rcsaId, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
			try
			{
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                RiskControlSelfAssessmentDto? rcsa = await repository.GetContextByConditon(r => r.Id.Equals(rcsaId))
                    .Include(e => e.RiskControlSelfAssessmentUnits).Select(r => new RiskControlSelfAssessmentDto
                    {
                        CreatedDate = r.CreatedOnUtc,
                        PeriodFrom = r.PeriodFrom,
                        PeriodTo = r.PeriodTo,
                        StartDate = r.StartDate,
                        EndDate = r.EndDate,
                        Id = r.Id,
                        //Status = r.Status.ToString(),
                        RiskControlSelfAssessmentUnits = r.RiskControlSelfAssessmentUnits.Select(u => new UnitDto(u.Unit.Name, u.Unit.Id)).ToList(),
                        NumberOfRiskControlSelfAssessmentUnits = r.RiskControlSelfAssessmentUnits.Count
                    }).FirstOrDefaultAsync();

                return TypedResults.Ok(rcsa);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
