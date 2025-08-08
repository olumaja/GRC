using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using FluentValidation;

using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostApproveInitiatedRCSA
    {
        public static async Task<IResult> HandleAsync(
            ApproveDto approveDto, IRepository<DocumentRSCAProcess> docRepo, IRepository<DocumentRSCAProcessLog> documentProcessLogRepo,
            IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo, ICurrentUserService currentUserService
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            var documentRCSAProcess = await docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnit.Id.Equals(approveDto.riskControlSelfAssessmentUnitId)).FirstAsync();

            if (documentRCSAProcess == null)
            {
                return TypedResults.BadRequest($"Risk control selfassessment with id {approveDto.riskControlSelfAssessmentUnitId} has not been initiated");
            }

            var rcsaUnit = await rcsaUnitRepo.GetByIdAsync(approveDto.riskControlSelfAssessmentUnitId);
            rcsaUnit.AddApproval(currentUserService.CurrentUserFullName);
            documentRCSAProcess.UpdateStage(Stage.RiskManagementEnterTestToBeApplied);
            documentRCSAProcess.UpdateApprovalStatus(RCSAStatus.Approved);
            documentProcessLogRepo.Add(documentRCSAProcess.ConvertToDocumentRSCAProcessLog());
            docRepo.Update(documentRCSAProcess);

            docRepo.SaveChanges();

            return TypedResults.Ok();
        }
    }

    public record ApproveDto(Guid riskControlSelfAssessmentUnitId);

    public class ApprovedDtoValidator : AbstractValidator<ApproveDto>
    {
        public ApprovedDtoValidator()
        {
            RuleFor(model => model.riskControlSelfAssessmentUnitId).NotEmpty();
        }
    }
}
