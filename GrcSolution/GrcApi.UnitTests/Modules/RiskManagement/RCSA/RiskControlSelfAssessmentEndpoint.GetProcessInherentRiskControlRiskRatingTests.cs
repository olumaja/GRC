using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetProcessInherentRiskControlRiskRatingTests
    {
        /// <summary>
        /// This test the GetProcessInherentRiskControlRiskRatingTests endpoint
        /// The following are the steps taken to test
        /// Create a claim
        /// Create Risk control self assessment and Create Risk control self assessment unit
        /// Create process, documented rcsa-process and attached document
        /// Create process inherent risk control
        /// Then call GetProcessInherentRiskControlRiskRatingTests and assert that process inherent risk control and document created were return
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetProcessInherentRiskControlRiskRating_CallWithValidPayload_ReturnProcessInherentRiskControlRiskRating()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<RiskControlSelfAssessment> rcsaRepo = new Repository<RiskControlSelfAssessment>(context);
            IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo = new Repository<RiskControlSelfAssessmentUnit>(context);
            IRepository<ProcessInherentRiskControl> processInherentRiskControlRepository = new Repository<ProcessInherentRiskControl>(context);
            IRepository<Document> documentRepository = new Repository<Document>(context);
            IRepository<RSCAProcess> processRepo = new Repository<RSCAProcess>(context);
            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);
            IRepository<Unit> unitRepo = new Repository<Unit>(context);
            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            ICurrentUserService currentUserService = new CurrentUserService(httpContextAccessor);

            ClaimsPrincipal principal = new();
            ClaimsIdentity identity = new("joshua", ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim("name", "joshua"));
            principal.AddIdentity(identity);

            // Create Unit
            var units = new List<Unit>
            {
                Unit.Create(Guid.NewGuid(), "Sample unit1"),
                Unit.Create(Guid.NewGuid(), "Sample unit2"),
                Unit.Create(Guid.NewGuid(), "Sample unit2")
            };
            unitRepo.AddRange(units);

            // Create Risk control self assessment
            List<RiskControlSelfAssessmentUnit> rCSAunits = new()
            {
                RiskControlSelfAssessmentUnit.Create(units[0].Id)
            };
            RiskControlSelfAssessment rcsa = RiskControlSelfAssessment.Create(
                    DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now).AddMonths(3), DateOnly.FromDateTime(DateTime.Now),
                    DateOnly.FromDateTime(DateTime.Now).AddMonths(3), rCSAunits
            );
            rcsaRepo.Add(rcsa);

            var rcsaUnitId = rcsa.RiskControlSelfAssessmentUnits[0].Id;

            // Create Process
            var process = RSCAProcess.Create("Sample unit1", units[1].Id);
            processRepo.Add(process);

            // Create document rcsa process
            var documentRCSAProcess = DocumentRSCAProcess.Create(rcsaUnitId, DocumentRSCAProcess.Stage.RiskChampionHeadReviewTestApplied);
            docRepo.Add(documentRCSAProcess);

            // Create Process inherent risk control
            var processInherentRisk = ProcessInherentRiskControl.Create(process.Id, documentRCSAProcess.Id, "Inherent risk", "Control");
            processInherentRiskControlRepository.Add(processInherentRisk);
            processInherentRiskControlRepository.SaveChanges();

            // Create document
            var blob = "Mytestfile";
            byte[] bytes = Encoding.ASCII.GetBytes(blob);
            var document = Document.Create("Test document", ModuleType.RiskManagement, processInherentRisk.Id, "text/plain", 300, bytes);
            documentRepository.Add(document);
            documentRepository.SaveChanges();

            var expectedResult = docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnitId.Equals(rcsaUnitId))
                                        .Include(d => d.ProcessInherentRiskControls).FirstOrDefault();

            var expectedDocument = documentRepository.GetContextByConditon(d => d.ModuleItemId.Equals(processInherentRisk.Id) && d.ModuleItemType.Equals(ModuleType.RiskManagement))
                                                     .FirstOrDefault();

            // Act
            var result = await RiskControlSelfAssessmentEndpointGetProcessInherentRiskControlRiskRating.HandleAsync(
                    rcsaUnitId, rcsaUnitRepo, processRepo, documentRepository, principal, currentUserService
            );
            var resultValue = (result as IValueHttpResult).Value as GetProcessInherentRiskControlRiskRatingDto;

            // Assert
            Assert.IsInstanceOf<Ok<GetProcessInherentRiskControlRiskRatingDto>>(result);
            Assert.That(expectedResult.ProcessInherentRiskControls.Count, Is.EqualTo(resultValue.ProcessInherentRiskControls.Count));
            Assert.That(expectedResult.ProcessInherentRiskControls[0].Id, Is.EqualTo(resultValue.ProcessInherentRiskControls[0].ProcessInherentRiskControlId));
            Assert.That(expectedDocument.Id, Is.EqualTo(resultValue.ProcessInherentRiskControls[0].Document.DocumentId));
        }
    }
}
