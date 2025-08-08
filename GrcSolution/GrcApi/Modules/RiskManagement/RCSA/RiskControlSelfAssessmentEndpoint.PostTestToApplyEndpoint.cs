using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostTestToApplyEndpoint
    {
        public static async Task<IResult> HandleAsync(
            ApplyTestProcessInherentRiskControlDto testToApply, IRepository<DocumentRSCAProcess> docRepo, IRepository<ProcessInherentRiskControl> inherentRiskRepo, 
            IRepository<DocumentRSCAProcessLog> documentProcessLogRepo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }

            DocumentRSCAProcess documentRSCAProcess = docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnit.Id.Equals(testToApply.RiskControlSelfAssessmentUnitId))
                                                             .FirstOrDefault();

            if (documentRSCAProcess == null)
            {
                return TypedResults.BadRequest($"Risk assessment with id {testToApply.RiskControlSelfAssessmentUnitId} doesn't have documented process");
            }

            documentRSCAProcess.UpdateStage(DocumentRSCAProcess.Stage.RiskChampionReviewTestApplied);

            var processInherentriskControls = inherentRiskRepo.GetContextByConditon(p => p.DocumentRCSAProcessId.Equals(documentRSCAProcess.Id)).ToList();
            List<ProcessInherentRiskControl> testApplied = new();

            foreach (var item in testToApply.applyTests)
            {
                var processinherent = processInherentriskControls.FirstOrDefault(x => x.Id.Equals(item.ProcessInherentRiskControlId));

                if (processinherent != null)
                {
                    processinherent.ApplyTest(item.testToApply);
                    testApplied.Add(processinherent);
                }
            }
            inherentRiskRepo.UpdateRange(testApplied);
            documentProcessLogRepo.Add(documentRSCAProcess.ConvertToDocumentRSCAProcessLog());
            docRepo.Update(documentRSCAProcess);
            await inherentRiskRepo.SaveChangesAsync();
           
            #region Log email request
            string subject = $"New RCSA Exercise";
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = config["EmailConfiguration:RiskMgtUnit"];
            string toCC = config["EmailConfiguration:toCC"];
            string body = $"Hello all, <br>The initiated RCSA performed by the Risk Champion and Unit Head have been submitted and approved successfully. <br>Kindly login to input the test to be applied for the Risk Champion:<br> <a href={linkToGRCTool} >GRC link</a>.";

            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, testToApply.RiskControlSelfAssessmentUnitId, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"New RCSA Exercise was created successfully, but email message was not logged");
            }
            #endregion
            return TypedResults.Ok();
        }
    }
}
