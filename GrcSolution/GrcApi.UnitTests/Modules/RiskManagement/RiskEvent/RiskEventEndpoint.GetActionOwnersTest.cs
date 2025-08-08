//using GrcApi.Modules.RiskManagement.RiskEvent;
//using GrcApi.Modules.Shared.RestHelper;

//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    public class RiskEventEndpointGetActionOwnersTest
//    {
//        private readonly IServiceScopeFactory factoryScope;

//        public RiskEventEndpointGetActionOwnersTest(IServiceScopeFactory factoryScope)
//        {
//            this.factoryScope = factoryScope;
//        }

//        [Test]
//        public async Task GetActionOwners_CallMethod_ReturnListOfStaff()
//        {
//            using (IServiceScope scope = factoryScope.CreateScope())
//            {
//                // Arrange
//                var restHelper = scope.ServiceProvider.GetRequiredService<IRestHelper>();
//                var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

//                // Act
//                var result = await RiskEventEndpointGetActionOwners.HandleAsync(restHelper, config);

//                // Assert
//                Assert.IsInstanceOf<Ok<IList<StaffNameEmail>>>(result);
//            }
//        }
//    }
//}
