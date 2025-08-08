using Arm.GrcTool.Domain;
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
    public class RiskControlSelfAssessmentEndpointPostProcessInherentRiskControlRiskRating
    {
        public static async Task<IResult> HandleAsync(
            CreateProcessInherentRiskControlRiskRatingDto createInherentRiskRatingDto,
            IRepository<ProcessInherentRiskControl> processInherentRiskControlRepository,
            IRepository<Document> documentRepository,
            IRepository<DocumentRSCAProcess> docRepo, ICurrentUserService currentUserService,
            IRepository<DocumentRSCAProcessLog> documentProcessLogRepo,
           IEmailService EmailService, IConfiguration config, ClaimsPrincipal user)
        {
            var processInherentRisk = processInherentRiskControlRepository
                .GetContextByConditon(p => p.Id.Equals(createInherentRiskRatingDto.ProcessInherentRiskControlId))
                .Include(p => p.DocumentRCSAProcess).FirstOrDefault();

            if (processInherentRisk == null) 
                return TypedResults.NotFound($"ProcessInherentRiskControl does not exist");

            Guid? testAttachmentId = null;
            if (createInherentRiskRatingDto.TestResultAttachment != null)
            {
                var testResultAttachment = DocumentExtensions.ConvertFormFileToDocument(
                    createInherentRiskRatingDto.TestResultAttachment, processInherentRisk.TestResultAttachmentModuleType, processInherentRisk.Id
                );
                documentRepository.Add(testResultAttachment);
                testAttachmentId = testResultAttachment.Id;
            }

            //update processInherentRisk details
            processInherentRisk.UpdateRiskRatingInformation(
                createInherentRiskRatingDto.TestResult, testAttachmentId, createInherentRiskRatingDto.ColourEffectiveness, 
                createInherentRiskRatingDto.ResidualRisks, createInherentRiskRatingDto.ResidualRiskRating, createInherentRiskRatingDto.ResidualRiskLevel, 
                createInherentRiskRatingDto.CorrectiveActions, createInherentRiskRatingDto.ActionOwnerUserName, createInherentRiskRatingDto.TimeLine
            );

            processInherentRiskControlRepository.Update(processInherentRisk);

            //update RSCAProcess stage
            DocumentRSCAProcess documentRCSAProcess = processInherentRisk.DocumentRCSAProcess;
            documentRCSAProcess.UpdateStage(Stage.RiskChampionHeadReviewTestApplied);
            documentRCSAProcess.UpdateApprovalStatus(RCSAStatus.Pending);
            documentProcessLogRepo.Add(documentRCSAProcess.ConvertToDocumentRSCAProcessLog());
            docRepo.Update(documentRCSAProcess);

            await processInherentRiskControlRepository.SaveChangesAsync();
            #region Log email request
            string subject = $"New RCSA Exercise";
            string emailTo = config["EmailConfiguration:RiskChampionsUnitHeads"];
            string toCC = config["EmailConfiguration:RiskMgtUnit"];
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string body = $"Hello all, <br>Please log in to perform the exercise and fill in the RCSA form on the GRC Tool. <br>See link to the GRC Tool: <a href={linkToGRCTool} >GRC link</a>.";

            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, documentRCSAProcess.RiskControlSelfAssessmentUnitId, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"New RCSA Exercise was created successfully, but email message was not logged");
            }
            #endregion
            return TypedResults.Ok("Successful");
        }
    }
}
