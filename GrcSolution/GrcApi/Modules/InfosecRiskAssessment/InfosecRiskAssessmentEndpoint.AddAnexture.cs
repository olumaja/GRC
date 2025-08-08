using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class AddAnextureEndpoint
    {
        public static async Task<IResult> HandleAsync(
            AddAnexture payload, IRepository<InfosecRiskAssessmentModel> riskRepo, IRepository<PlannedControl> planRepo, IRepository<ExistingPrimaryControl> existRepo,
            IRepository<ExistingPrimaryControlAnnexture> existAnextureRepo, IRepository<PlannedControlAnnexture> plannedAnextureRepo,
            ICurrentUserService currentUserService
        )
        {
            var anextures = new List<Annexture>();
            var planAnextures = new List<PlannedControlAnnexture>();
            var existAnextures = new List<ExistingPrimaryControlAnnexture>();

            var riskAssessment = riskRepo.GetContextByConditon(r => r.Id == payload.RiskId)
                                         .Include(r => r.PlannedControls)
                                         .Include(r => r.ExistingPrimaryControls)
                                         .FirstOrDefault();

            if (riskAssessment is null)
                return TypedResults.NotFound("Record not found");

            var previousPlanControlIds = riskAssessment.PlannedControls.Select(p => p.Id).ToHashSet();
            var previousExistControlIds = riskAssessment.ExistingPrimaryControls.Select(e => e.Id).ToHashSet();
            var requestPlanControlIds = payload.PlannedControlAnextures.Select(p => p.PlannedControlId).ToHashSet();
            var requestExistControlId = payload.ExistingPrimaryControlAnextures.Select(e => e.ExistingPrimaryControlId).ToHashSet();

            if (!previousPlanControlIds.SetEquals(requestPlanControlIds))
                return TypedResults.BadRequest("One or more planned control have invalid Id");

            if(!previousExistControlIds.SetEquals(requestExistControlId))
                return TypedResults.BadRequest("One or more exist primary control have invalid Id");

            foreach (var planAnexture in payload.PlannedControlAnextures) {
                foreach (var annex in planAnexture.Anextures)
                {
                    planAnextures.Add(PlannedControlAnnexture.Create(planAnexture.PlannedControlId, annex.AnnextureId));
                }
            }

            foreach (var existAnexture in payload.ExistingPrimaryControlAnextures)
            {
                foreach (var annex in existAnexture.Anextures)
                {
                    existAnextures.Add(ExistingPrimaryControlAnnexture.Create(existAnexture.ExistingPrimaryControlId, annex.AnnextureId));
                }
            }

            plannedAnextureRepo.AddRange(planAnextures);
            existAnextureRepo.AddRange(existAnextures);
            existAnextureRepo.SaveChanges();

            return TypedResults.Ok("Anextures added successfully");
        }
    }
}
