using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostRejectReviewedTestApplied
    {
        public static async Task<IResult> HandleAsync(
            RiskControlSelfAssessmentRejectDto rejectDto, IRepository<DocumentRSCAProcess> docRepo, IRepository<DocumentRSCAProcessLog> documentProcessLogRepo, 
            IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo, ICurrentUserService currentUserService
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            var documentRCSAProcess = await docRepo.FirstOrDefaultAsync(d => d.RiskControlSelfAssessmentUnit.Id.Equals(rejectDto.RiskControlSelfAssessmentUnitId));

            if (documentRCSAProcess == null)
            {
                return TypedResults.BadRequest($"Risk control selfassessment with id {rejectDto.RiskControlSelfAssessmentUnitId} has not been initiated");
            }

            var rcsaUnit = await rcsaUnitRepo.GetByIdAsync(rejectDto.RiskControlSelfAssessmentUnitId);
            rcsaUnit.AddApproval(currentUserService.CurrentUserFullName);
            documentRCSAProcess.UpdateStage(Stage.RiskChampionReviewTestApplied);
            documentRCSAProcess.UpdateApprovalStatus(RCSAStatus.Rejected, rejectDto.Comment);
            documentProcessLogRepo.Add(documentRCSAProcess.ConvertToDocumentRSCAProcessLog());
            docRepo.Update(documentRCSAProcess);

            docRepo.SaveChanges();

            return TypedResults.Ok();
        }
    }
}
