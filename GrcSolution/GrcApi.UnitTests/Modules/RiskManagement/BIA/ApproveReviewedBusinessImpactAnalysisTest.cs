//using Arm.GrcApi.Modules.RiskManagement.BIA;
//using Arm.GrcTool.Domain.BusinessImpactAnalysis;
//using Arm.GrcTool.Infrastructure;

//using GrcApi.Modules.RiskManagement.BIA;

//using Microsoft.AspNetCore.Http.HttpResults;

//namespace GrcApi.UnitTests.Modules.RiskManagement.BIA
//{
//    public class ApproveReviewedBusinessImpactAnalysisTest
//    {
//        [Test]
//        public async Task PostApproveReviewed_CallWithValidPayload_ReturnSuccess()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<BusinessImpactAnalysisUnit> biaUnitRepo = new Repository<BusinessImpactAnalysisUnit>(context);
//            var biaUnit = BusinessImpactAnalysisUnit.Create(Guid.NewGuid());
//            biaUnitRepo.Add(biaUnit);
//            biaUnitRepo.SaveChanges();
//            ApproveInitiateBIADto approveInitiateBIA = new ApproveInitiateBIADto(biaUnit.Id);

//            // Act
//            var result = await ApproveInitiateBusinessImpactAnalysisEndpoint.HandleAsync(approveInitiateBIA, biaUnitRepo);

//            // Assert
//            Assert.IsInstanceOf<Ok>(result);
//        }
//    }
//}
