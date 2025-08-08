//using Arm.GrcTool.Domain.Risk;
//using Arm.GrcTool.Infrastructure;
//using GrcApi.Modules.RiskManagement;
//using Microsoft.AspNetCore.Http.HttpResults;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    public class RiskEventTypeEndpoint
//    {
//        [Test]
//        public async Task CreateRiskEventTypeCategoryWithValidParameters()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskEventTypeCategory> repository = new Repository<RiskEventTypeCategory>(context);
//            var riskEventTypeId = Guid.NewGuid();

//            //Return null when there is no existing category with the id
//            var result = RiskEventTypeEndpointGetEventCategory.HandleAsync(riskEventTypeId, repository);

//            Assert.NotNull(result);

//            //Persist to db
//            RiskEventTypeCategory riskEventTypeCategory = RiskEventTypeCategory.Create(riskEventTypeId, "System Security");
//            await repository.AddAsync(riskEventTypeCategory);
//            await context.SaveChangesAsync();

//            //Act
//            result = RiskEventTypeEndpointGetEventCategory.HandleAsync(riskEventTypeId, repository);

//            Assert.IsInstanceOf<Ok<IList<RiskEventTypeCategoryDto>>>(result);
//        }
//    }
//}
