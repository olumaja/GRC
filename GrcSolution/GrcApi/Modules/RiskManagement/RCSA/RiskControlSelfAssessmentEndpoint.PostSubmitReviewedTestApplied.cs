using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.Shared;

using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostSubmitReviewedTestApplied
    {
        public static async Task<IResult> HandleAsync(
            ApproveDto approveDto, IRepository<DocumentRSCAProcess> docRepo, IRepository<DocumentRSCAProcessLog> documentProcessLogRepo, ClaimsPrincipal user
        )
        {
            if (user is null)
            {
                return TypedResults.BadRequest("User must be logged in");
            }
            var documentRCSAProcess = await docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnit.Id.Equals(approveDto.riskControlSelfAssessmentUnitId)).FirstAsync();

            if (documentRCSAProcess == null)
            {
                return TypedResults.BadRequest($"Risk control selfassessment with id {approveDto.riskControlSelfAssessmentUnitId} has not been initiated!");
            }

            documentRCSAProcess.UpdateStage(Stage.RiskChampionHeadReviewTestApplied);
            documentRCSAProcess.UpdateApprovalStatus(RCSAStatus.Pending);
            documentProcessLogRepo.Add(documentRCSAProcess.ConvertToDocumentRSCAProcessLog());
            docRepo.Update(documentRCSAProcess);

            docRepo.SaveChanges();

            return TypedResults.Ok();
        }
    }
}
