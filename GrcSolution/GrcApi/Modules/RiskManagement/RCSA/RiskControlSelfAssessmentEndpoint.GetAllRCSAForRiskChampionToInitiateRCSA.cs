using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.RiskManagement.RCSA;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionToInitiateRCSA
    {
        public static async Task<IResult> HandleAsync(IRepository<RiskControlSelfAssessmentUnit> repository, IRepository<Unit> unitRepo, ICurrentUserService currentUserService)
        {
			try
			{
                var email = currentUserService.CurrentUserEmail;

                if (string.IsNullOrWhiteSpace(email))
                {
                    return TypedResults.Unauthorized();
                }

                var rcsaList = new List<GetAllRCSAForRiskChampionDto>();
                var unitId = currentUserService.CurrentUserUnitId;

                if (unitId is null)
                {
                    return TypedResults.Ok(rcsaList);
                }

                var unit = await unitRepo.GetByIdAsync(unitId.Value);

                rcsaList = repository
                    .GetContextByConditon(u => u.Unit.Name == unit.Name).Include(e => e.RiskControlSelfAssessment)
                    .Include(e => e.DocumentRSCAProcess).Where(r => r.DocumentRSCAProcess.RCSAStage == DocumentRSCAProcess.Stage.RiskChampionInitiateRCSA)
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
