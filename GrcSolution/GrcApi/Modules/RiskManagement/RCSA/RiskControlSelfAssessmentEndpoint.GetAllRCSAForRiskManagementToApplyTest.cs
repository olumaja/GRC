using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.RiskManagement.RCSA;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetAllRCSAForRiskManagementToApplyTest
    {
        public static async Task<IResult> HandleAsync(IRepository<RiskControlSelfAssessmentUnit> repository, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
			try
			{
                //var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));
                var email = currentUserService.CurrentUserEmail;

                if (string.IsNullOrWhiteSpace(email))
                {
                    return TypedResults.Unauthorized();
                }

                var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

                if (unitIdValue is null)
                {
                    return TypedResults.Ok("Unit was not found");
                }

                Guid unitId = new Guid(unitIdValue.Value);
                var rcsaList = repository
                    .GetAll().Include(e => e.RiskControlSelfAssessment)
                    .Where(r => r.DocumentRSCAProcess.RCSAStage == DocumentRSCAProcess.Stage.RiskManagementEnterTestToBeApplied)
                    .Select(r => new GetAllRCSAForRiskChampionDto
                    {
                        CreatedDate = r.RiskControlSelfAssessment.CreatedOnUtc,
                        PeriodFrom = r.RiskControlSelfAssessment.PeriodFrom,
                        PeriodTo = r.RiskControlSelfAssessment.PeriodTo,
                        StartDate = r.RiskControlSelfAssessment.StartDate,
                        EndDate = r.RiskControlSelfAssessment.EndDate,
                        RiskControlSelfAssessmentUnitId = r.Id,
                        Status = r.DocumentRSCAProcess.Status.ToString(),
                        UnitName = r.Unit.Name,
                        RCSAId = r.RiskControlSelfAssessment.Id
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
