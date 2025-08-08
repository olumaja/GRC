//using Arm.GrcApi.Modules.RiskManagement.RCSA;
//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcTool.Domain.RiskControlSelfAssessment;
//using Arm.GrcTool.Infrastructure;
//using Microsoft.AspNetCore.Http.HttpResults;
//using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;
//using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

//namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
//{
//    internal class RiskControlSelfAssessmentEndpointPostRejectReviewedTestAppliedTests
//    {
//        [Test]
//        public async Task CallWithValidPayload_RejectAndMoveRCSAToRiskManagementToApplyTest()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);
//            IRepository<RiskControlSelfAssessment> riskControlrepo = new Repository<RiskControlSelfAssessment>(context);
//            IRepository<DocumentRSCAProcessLog> documentProcessLogRepo = new Repository<DocumentRSCAProcessLog>(context);

//            List<RiskControlSelfAssessmentUnit> units = new()
//            {
//                Create(Guid.NewGuid())
//            };

//            RiskControlSelfAssessment rcsa = RiskControlSelfAssessment.Create(
//                    DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now).AddMonths(3), DateOnly.FromDateTime(DateTime.Now),
//                    DateOnly.FromDateTime(DateTime.Now).AddMonths(3), units
//                );

//            riskControlrepo.Add(rcsa);
//            riskControlrepo.SaveChanges();
//            RiskControlSelfAssessmentRejectDto rejectDto = new(units[0].Id, "Rejected");

//            // Act
//            var result = await RiskControlSelfAssessmentEndpointPostRejectReviewedTestApplied.HandleAsync(rejectDto, docRepo, documentProcessLogRepo);

//            // Assert
//            var docProcess = await docRepo.FirstOrDefaultAsync(d => d.RiskControlSelfAssessmentUnit.Id.Equals(rejectDto.RiskControlSelfAssessmentUnitId));
//            Assert.IsInstanceOf<Ok>(result);
//            Assert.That(docProcess.Status, Is.EqualTo(RCSAStatus.Rejected));
//            Assert.That(docProcess.RCSAStage, Is.EqualTo(Stage.RiskChampionReviewTestApplied));
//        }
//    }
//}
