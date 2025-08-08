//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcTool.Domain.RiskEvent;
//using Arm.GrcTool.Infrastructure;
//using Microsoft.AspNetCore.Http.HttpResults;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    public class GetRiskDriverCategoriesTests
//    {
//        [Test]
//        public async Task RiskEventRiskDriverEndpointGetRiskDriverCategories_CreatedRiskDriverCategoryWithValidParameters_ReturnsListOfRiskDriverCategoriesCreated()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskDriverCategory> repository = new Repository<RiskDriverCategory>(context);
//            var riskDriverId = Guid.NewGuid();

//            //Persist to db
//            RiskDriverCategory riskDriverCategory = RiskDriverCategory.Create(riskDriverId, "Testing");
//            await repository.AddAsync(riskDriverCategory);
//            await context.SaveChangesAsync();

//            //Act
//            var result = RiskEventRiskDriverEndpointGetRiskDriverCategories.HandleAsync(riskDriverId, repository);

//            Assert.IsInstanceOf<Ok<IList<RiskEventRiskDriverCategoryDto>>>(result);
//        }
//    }
//}
