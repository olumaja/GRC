using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.DocumentManagement;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetProcessInherentRiskControlRiskRating
    {
        /// <summary>
        /// Get the risk rating for the process inherent risk control for risk champion head to review
        /// </summary>
        /// <param name="riskControlSelfAssessmentUnitId"></param>
        /// <param name="rcsaUnitRepo"></param>
        /// <param name="processRepo"></param>
        /// <param name="documentRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid riskControlSelfAssessmentUnitId, IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo, IRepository<RSCAProcess> processRepo,
            IRepository<Document> documentRepo, IRepository<User> userRepo, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var rcsaUnit = await rcsaUnitRepo.GetContextByConditon(r => r.Id.Equals(riskControlSelfAssessmentUnitId))
                    .Include(r => r.RiskControlSelfAssessment)
                    .Include(r => r.DocumentRSCAProcess).ThenInclude(d => d.ProcessInherentRiskControls).FirstOrDefaultAsync();

                if (rcsaUnit == null)
                {
                    return TypedResults.NotFound();
                }

                var users = await userRepo.GetAllAsync();
                var processes = await processRepo.GetAllAsync();

                List<ProcessInherentRiskControlRiskRating> processInherentRiskControlsRatings = new();

                foreach (var item in rcsaUnit.DocumentRSCAProcess.ProcessInherentRiskControls)
                {
                    var actionOwner = users.Find(u => u.Email == item.ActionOwnerUserName)?.Name ?? "";
                    var document = documentRepo.GetContextByConditon(d => d.ModuleItemId.Equals(item.Id) && d.ModuleItemType == ModuleType.RiskManagement)
                                                .Select(d => new DocumentDto(d.Id, d.Name, d.ModuleItemId))
                                               .FirstOrDefault();
                    var processName = "";
                    var process = processes.Find(f => f.Id.Equals(item.ProcessId));
                    if (process is not null) { processName = process.Name; }

                    processInherentRiskControlsRatings.Add(new ProcessInherentRiskControlRiskRating
                    (
                        item.Id, item.ProcessId, processName, item.InherentRisk, item.Control, item.TestToApply,
                        item.TestResult, item.ColourEffectiveness, item.ResidualRisks, item.ResidualRiskRating, item.ResidualRiskLevel,
                        item.CorrectiveActions, actionOwner, item.TimeLine, document
                    ));
                }

                return TypedResults.Ok(new GetProcessInherentRiskControlRiskRatingDto(
                        rcsaUnit.Id, rcsaUnit.Requester, rcsaUnit.Approval, rcsaUnit.ApprovalDate,
                        rcsaUnit.RiskControlSelfAssessment.PeriodFrom, rcsaUnit.RiskControlSelfAssessment.PeriodTo, rcsaUnit.RiskControlSelfAssessment.StartDate,
                        rcsaUnit.RiskControlSelfAssessment.EndDate, rcsaUnit.DocumentRSCAProcess.Status, processInherentRiskControlsRatings
                    ));
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest("Unable to submit the request");
            }
        }
    }
}
