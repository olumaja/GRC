//using Arm.GrcApi.Modules.RiskManagement.BIA;
//using Arm.GrcTool.Domain.BusinessImpactAnalysis;
//using Arm.GrcTool.Infrastructure;

//using GrcApi.Modules.RiskManagement.BIA;

//using Microsoft.AspNetCore.Http.HttpResults;

//namespace GrcApi.UnitTests.Modules.RiskManagement.BIA
//{
//    public class RejectReviewedBusinessImpactAnalysisTest
//    {
//        [Test]
//        public async Task PostRejectReviewed_CallWithValidPayload_ReturnSuccess()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<BusinessImpactAnalysisUnit> biaUnitRepo = new Repository<BusinessImpactAnalysisUnit>(context);
//            var biaUnit = BusinessImpactAnalysisUnit.Create(Guid.NewGuid());
//            biaUnitRepo.Add(biaUnit);
//            biaUnitRepo.SaveChanges();
//            RejectInitiateBIADto rejectInitiateBIA = new RejectInitiateBIADto(biaUnit.Id, "Say something");

//            // Act
//            var result = await RejectInitiateBusinessImpactAnalysisEndpoint.HandleAsync(rejectInitiateBIA, biaUnitRepo);

//            // Assert
//            Assert.IsInstanceOf<Ok>(result);
//        }
//    }
//}
