using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostDocumentProcess
    {
        public static async Task<IResult> HandleAsync(
            RiskControlSelfAssessmentCreateDocumentProcessDto createDocProcess, IRepository<DocumentRSCAProcess> docRepo, ICurrentUserService currentUserService,
            IRepository<ProcessInherentRiskControl> inherentRiskRepo, IRepository<DocumentRSCAProcessLog> documentProcessLogRepo,
            IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo, IEmailService EmailService, IConfiguration config
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var rolesAllowed = new[] { "UnitHead", "RiskChampion" };

                if (currentUserService.CurrentUserRoles.Count == 0 || !currentUserService.CurrentUserRoles.Any(role => rolesAllowed.Contains(role)))
                {
                    return TypedResults.Forbid();
                }

                var documentRSCAProcess = await docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnitId == createDocProcess.RiskControlSelfAssessmentUnitId)
                    .Include(d => d.ProcessInherentRiskControls).FirstAsync();

                Guid documentRSCAProcessId = documentRSCAProcess.Id;

                List<ProcessInherentRiskControl> processInherentRisks = new();

                foreach (var item in createDocProcess.ProcessInherentRiskControls)
                {
                    ProcessInherentRiskControl inherentRiskControl = ProcessInherentRiskControl.Create(
                        item.ProcessId,
                        documentRSCAProcessId,
                        item.InherentRisk,
                        item.Control
                    );

                    processInherentRisks.Add(inherentRiskControl);
                }

                if (documentRSCAProcess.ProcessInherentRiskControls.Count > 0)
                {
                    inherentRiskRepo.RemoveRange(documentRSCAProcess.ProcessInherentRiskControls);
                }

                inherentRiskRepo.AddRange(processInherentRisks);

                var rcsaUnit = await rcsaUnitRepo.GetByIdAsync(createDocProcess.RiskControlSelfAssessmentUnitId);
                rcsaUnit.AddRequester(currentUserService.CurrentUserFullName);

                documentRSCAProcess.UpdateStage(DocumentRSCAProcess.Stage.RiskChampionHeadInitiateRCSA);
                documentProcessLogRepo.Add(documentRSCAProcess.ConvertToDocumentRSCAProcessLog());
                docRepo.Update(documentRSCAProcess);
                docRepo.SaveChanges();
                CreateDocumentProcessResponseDto response = new() { DocumentRCSAProcessId = documentRSCAProcessId };

                #region Log email request
                string subject = $"New RCSA Exercise";
                string emailTo = config["EmailConfiguration:RiskChampionsUnitHeads"];
                string toCC = config["EmailConfiguration:toCC"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Hello all, <br>Your Risk Champion has successfully Initiated RCSA by entering the inherent risks and controls for each process in your unit.<br>Kindly login to the GRC Tool for your review and approval:<br> <a href={linkToGRCTool}>GRC link</a>.";

                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, response.DocumentRCSAProcessId, emailTo, toCC);
                if (logEmailRequest == false)
                {
                    return TypedResults.Ok($"New RCSA Exercise was created successfully {response} but email message was not logged");
                }
                #endregion
                return TypedResults.Created($"documentRSCAprocess/{response}", response);
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest("Unable to submit the request");
            }
        }
    }
}
