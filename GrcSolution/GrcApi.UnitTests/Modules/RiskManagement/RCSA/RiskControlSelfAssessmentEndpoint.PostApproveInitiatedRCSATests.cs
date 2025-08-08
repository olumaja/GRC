//using Arm.GrcApi.Modules.RiskManagement.RCSA;
//using Arm.GrcTool.Domain.RiskControlSelfAssessment;
//using Arm.GrcTool.Infrastructure;

//using Microsoft.AspNetCore.Http.HttpResults;

//using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;
//using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

//namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
//{
//    public class RiskControlSelfAssessmentEndpointPostApproveInitiatedRCSATests
//    {
//        [Test]
//        public async Task PostRiskControlSelfAssessmentApproved_CallWithValidPayload_UpdateRiskControlSelfAssessmentStatus()
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

//            ApproveDto approveDto = new(units[0].Id);

//            // Act
//            var result = await RiskControlSelfAssessmentEndpointPostApproveInitiatedRCSA.HandleAsync(approveDto, docRepo, documentProcessLogRepo);

//            // Assert
//            var docProcess = await docRepo.FirstOrDefaultAsync(d => d.RiskControlSelfAssessmentUnit.Id.Equals(approveDto.riskControlSelfAssessmentUnitId));
//            Assert.IsInstanceOf<Ok>(result);
//            Assert.That(docProcess.Status, Is.EqualTo(RCSAStatus.Approved));
//            Assert.That(docProcess.RCSAStage, Is.EqualTo(Stage.RiskManagementEnterTestToBeApplied));
//        }
//    }
//}
