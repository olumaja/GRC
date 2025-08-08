//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcApi.Modules.RiskManagement.RCSA;
//using Arm.GrcTool.Domain.RiskControlSelfAssessment;
//using Arm.GrcTool.Infrastructure;

//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;

//using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

//namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
//{
//    public class RiskControlSelfAssessmentEndpointPostRCSATests
//    {
//        [Test]
//        public async Task RiskControlSelfAssessmentEndpointPostRCSA_CallMethodWithValidParameter_ReturnsIdOfRCSACreated()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskControlSelfAssessment> repository = new Repository<RiskControlSelfAssessment>(context);
//            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);

//            //create rcsa
//            Guid unitId = Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E");
//            IList<CreateRiskControlSelfAssessmentUnitDto> units = new List<CreateRiskControlSelfAssessmentUnitDto> { new(unitId) };
//            CreateRiskControlSelfAssessmentDto rcsa = new(DateTime.Now, DateTime.Now.AddMonths(7), DateTime.Now, DateTime.Now.AddMonths(7), units);

//            //Act
//            var res = await RiskControlSelfAssessmentEndpointPostRCSA.HandleAsync(rcsa, repository);
//            var value = (res as IValueHttpResult).Value as CreateRiskControlSelfAssessmentResponseDto;
//            //
//            var expectedRcsa = await repository.GetByIdAsync(value.RiskControlSelfAssessmentId);
//            var expectedDoc = await docRepo.GetByIdAsync(expectedRcsa.RiskControlSelfAssessmentUnits[0].DocumentRSCAProcess.Id);

//            //Assert
//            Assert.IsInstanceOf<Created<CreateRiskControlSelfAssessmentResponseDto>>(res);
//            Assert.That(expectedRcsa.RiskControlSelfAssessmentUnits[0].UnitId, Is.EqualTo(unitId));
//            Assert.That(expectedDoc.RiskControlSelfAssessmentUnit.DocumentRSCAProcess.Id, Is.EqualTo(expectedDoc.Id));
//            Assert.That(expectedDoc.RCSAStage, Is.EqualTo(Stage.RiskChampionInitiateRCSA));
//        }

//        [Test]
//        public async Task RiskControlSelfAssessmentEndpointPostRCSA_CallMethodWithInvalidUnitsParameter_ReturnsValidationErrorListWithStatus400()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskControlSelfAssessment> repository = new Repository<RiskControlSelfAssessment>(context);
//            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);

//            //create rcsa
//            Guid unitId = Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E");
//            IList<CreateRiskControlSelfAssessmentUnitDto> units = new List<CreateRiskControlSelfAssessmentUnitDto> { new(unitId) };
//            CreateRiskControlSelfAssessmentDto rcsa = new(DateTime.Now, DateTime.Now.AddMonths(7), DateTime.Now, DateTime.Now.AddMonths(7), null);

//            //Act
//            var res = await RiskControlSelfAssessmentEndpointPostRCSA.HandleAsync(rcsa, repository);

//            //Assert
//            Assert.IsInstanceOf<BadRequest<List<string>>>(res);
//        }
//    }
//}
