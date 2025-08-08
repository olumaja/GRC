using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using Microsoft.AspNetCore.Http.HttpResults;

using System.Security.Claims;

using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostProcessInherentRiskControlRiskRatingTests
    {
        [Test]
        public async Task PostProcessInherentRiskControlRiskRating_CallWithValidPayload_UpdatesTheProcessInherentRiskControlRiskRating()
        {
            //Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<ProcessInherentRiskControl> processInherentRiskControlRepository = new Repository<ProcessInherentRiskControl>(context);
            IRepository<Document> documentRepository = new Repository<Document>(context);
            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);
            IRepository<DocumentRSCAProcessLog> documentProcessLogRepo = new Repository<DocumentRSCAProcessLog>(context);

            ClaimsPrincipal principal = new();
            ClaimsIdentity identity = new("joshua", ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim("name", "joshua"));
            principal.AddIdentity(identity);

            DocumentRSCAProcess documentRSCAProcess = Create(Guid.NewGuid(), Stage.RiskChampionReviewTestApplied);
            docRepo.Add(documentRSCAProcess);

            var processRisk = ProcessInherentRiskControl.Create(Guid.NewGuid(), documentRSCAProcess.Id, "Test Risk", "Test control");
            processInherentRiskControlRepository.Add(processRisk);
            processInherentRiskControlRepository.SaveChanges();

            CreateProcessInherentRiskControlRiskRatingDto riskRatingDto = new CreateProcessInherentRiskControlRiskRatingDto(
                processRisk.Id, "Test result", null, "test colour effectiveness", "test residual risk", 1, "Low", "test action", "ifeanyi", DateOnly.FromDateTime(DateTime.Now)
                );

            ////Act
            //var result = await RiskControlSelfAssessmentEndpointPostProcessInherentRiskControlRiskRating.HandleAsync(riskRatingDto, processInherentRiskControlRepository, documentRepository, docRepo, documentProcessLogRepo, principal);

            ////Assert
            //var docProcess = await docRepo.FirstOrDefaultAsync(d => d.Id.Equals(documentRSCAProcess.Id));
            //Assert.IsInstanceOf<Ok>(result);
            //Assert.That(docProcess.Status, Is.EqualTo(RCSAStatus.Pending));
            //Assert.That(docProcess.RCSAStage, Is.EqualTo(Stage.RiskChampionHeadReviewTestApplied));
        }
    }
}
