//using Arm.GrcApi.Modules.RiskManagement.RCSA;
//using Arm.GrcTool.Domain;
//using Arm.GrcTool.Domain.RiskControlSelfAssessment;
//using Arm.GrcTool.Infrastructure;

//using Microsoft.AspNetCore.Http.HttpResults;

//using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

//namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
//{
//    public class RiskControlSelfAssessmentEndpointGetDocumentProcessTests
//    {
//        [Test]
//        public async Task CreateProcessWithValidParameters()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);
//            IRepository<ProcessInherentRiskControl> inherentRiskRepo = new Repository<ProcessInherentRiskControl>(context);
//            IRepository<RSCAProcess> processRepo = new Repository<RSCAProcess>(context);
//            Guid rcsaId = Guid.NewGuid();

//            // Return empty when there is no existing rcsaId in the table
//            var result = await RiskControlSelfAssessmentEndpointGetDocumentedProcess.HandleAsync(rcsaId, docRepo, processRepo);
//            Assert.IsInstanceOf<NotFound>(result);
//            Assert.IsTrue(result is NotFound);
//            //Assert.NotNull(result);

//            // Persist to DocumentRSCAProcess table
//            DocumentRSCAProcess documentRSCA = Create(rcsaId, Stage.RiskChampionInitiateRCSA);
//            await docRepo.AddAsync(documentRSCA);
//            await context.SaveChangesAsync();

//            // persist to ProcessInherentRiskControl table
//            List<ProcessInherentRiskControl> docRisks = new List<ProcessInherentRiskControl>
//            {
//                ProcessInherentRiskControl.Create(Guid.NewGuid(), documentRSCA.Id, "Enter inherent risk", "Enter control")
//            };
//            await inherentRiskRepo.AddRangeAsync(docRisks);
//            await context.SaveChangesAsync();

//            // Act
//            result = await RiskControlSelfAssessmentEndpointGetDocumentedProcess.HandleAsync(rcsaId, docRepo, processRepo);

//            // Assert
//            Assert.IsInstanceOf<Ok<GetDocumentedProcessDto>>(result);
//        }
//    }
//}
