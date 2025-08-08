//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcTool.Domain.RiskEvent;
//using Arm.GrcTool.Infrastructure;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    public class GetAllRiskDriversTests
//    {
//        [Test]
//        public async Task RiskEventRiskDriverEndpointGetAllRiskDrivers_CreatedRiskEventRiskDriverWithValidParameters_ReturnsListOfRiskDriversCreated()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskDriver> repository = new Repository<RiskDriver>(context);

//            //Create risk event type
//            RiskDriver riskDriver = RiskDriver.Create("Testing Risk driver creation");
//            IList<RiskDriverDto> expectedResult = new List<RiskDriverDto>() { new RiskDriverDto(riskDriver.Name, riskDriver.Id) };

//            // persist to db
//            await repository.AddAsync(riskDriver);
//            await repository.SaveChangesAsync();

//            //Act
//            var result = await RiskEventRiskDriverEndpointGetAllRiskDrivers.HandleAsync(repository);
//            var value = ((result as IValueHttpResult).Value) as List<RiskDriverDto>;

//            //Assert
//            Assert.IsInstanceOf<Ok<IList<RiskDriverDto>>>(result);
//            Assert.That(value, Is.EquivalentTo(expectedResult));
//        }
//    }
//}
