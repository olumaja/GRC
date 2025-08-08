//using Arm.GrcTool.Domain.Risk;
//using Arm.GrcTool.Infrastructure;
//using GrcApi.Modules.RiskManagement;
//using Microsoft.AspNetCore.Http.HttpResults;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    public class RiskEventTypeEndpointGetAllRiskEventTypeTest
//    {
//        [Test]
//        public async Task CreateRiskEventTypeWithValidParameters()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskEventType> repository = new Repository<RiskEventType>(context);

//            // Return empty list when there is no existing data
//            var result = RiskEventTypeEndpointGetAllRiskEventType.HandleAsync(repository);

//            Assert.NotNull(result);

//            // Create risk event type
//            RiskEventType riskEventType = RiskEventType.Create("Internal Fraud");

//            // persist to db
//            await repository.AddAsync(riskEventType);
//            await repository.SaveChangesAsync();

//            result = RiskEventTypeEndpointGetAllRiskEventType.HandleAsync(repository);

//            //Assert
//            Assert.IsInstanceOf<Ok<IList<RiskEventTypeDto>>>(result.Result);
//        }
//    }
//}
