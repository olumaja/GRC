using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostApproveReviewedTestApplied
    {
        public static async Task<IResult> HandleAsync(
            ApproveDto approveDto, IRepository<DocumentRSCAProcess> docRepo, IRepository<DocumentRSCAProcessLog> documentProcessLogRepo, IEmailService EmailService, 
            IConfiguration config, IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo, ICurrentUserService currentUserService
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            var documentRCSAProcess = await docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnit.Id.Equals(approveDto.riskControlSelfAssessmentUnitId)).FirstAsync();

            if (documentRCSAProcess == null)
            {
                return TypedResults.BadRequest($"Risk control selfassessment with id {approveDto.riskControlSelfAssessmentUnitId} has not been initiated!");
            }

            var rcsaUnit = await rcsaUnitRepo.GetByIdAsync(approveDto.riskControlSelfAssessmentUnitId);
            rcsaUnit.AddApproval(currentUserService.CurrentUserFullName);
            documentRCSAProcess.UpdateStage(Stage.RiskManagementFinal);
            documentRCSAProcess.UpdateApprovalStatus(RCSAStatus.Approved);
            documentProcessLogRepo.Add(documentRCSAProcess.ConvertToDocumentRSCAProcessLog());
            docRepo.Update(documentRCSAProcess);

            docRepo.SaveChanges();
            #region Log email request
            string subject = $"New RCSA Exercise";
            string emailTo = config["EmailConfiguration:RiskChampionsUnitHeads"];
            string toCC = config["EmailConfiguration:toCC"];
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string body = $"Hello all, <br>Please log in to review and approve the exercise and RCSA form completed by your risk champion.<br>See link to the GRC Tool (Link): <a href={linkToGRCTool} >GRC link</a>.";

            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, documentRCSAProcess.RiskControlSelfAssessmentUnitId, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Problem($"New RCSA Exercise was created successfully, but email message was not logged");
            }
            #endregion
            return TypedResults.Ok();
        }
    }
}
