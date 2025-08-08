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
    public class RiskControlSelfAssessmentEndpointPostFinaliseRCSA
    {
        public static async Task<IResult> HandleAsync(
            ApproveDto approveDto, IRepository<DocumentRSCAProcess> docRepo, IRepository<DocumentRSCAProcessLog> documentProcessLogRepo, IEmailService EmailService, 
            IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            var documentRCSAProcess = await docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnit.Id.Equals(approveDto.riskControlSelfAssessmentUnitId)).FirstAsync();

            if (documentRCSAProcess == null)
            {
                return TypedResults.BadRequest($"Risk control selfassessment has not been initiated!");
            }

            documentRCSAProcess.UpdateStage(Stage.End);
            documentRCSAProcess.UpdateApprovalStatus(RCSAStatus.Treated);
            documentProcessLogRepo.Add(documentRCSAProcess.ConvertToDocumentRSCAProcessLog());
            docRepo.Update(documentRCSAProcess);

            docRepo.SaveChanges();
            #region Log email request
            string subject = $"New RCSA Exercise";
            string emailTo = config["EmailConfiguration:RiskMgtUnit"];
            string toCC = config["EmailConfiguration:toCC"];
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string body = $"Hello all, <br>Please log in to review and approve the exercise and filled RCSA form completed by the risk champion <br>and approved by the Unit Head. <br>See link to the GRC Tool: <a href={linkToGRCTool} >GRC link</a>.";

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
