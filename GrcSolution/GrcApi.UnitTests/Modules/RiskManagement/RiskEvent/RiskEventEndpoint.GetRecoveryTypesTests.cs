//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcTool.Domain.RiskEvent;
//using Arm.GrcTool.Infrastructure;

//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    public class GetRecoveryTypesTests
//    {
//        [Test]
//        public async Task Should_return_all_created_RecoveryTypes()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RecoveryType> repository = new Repository<RecoveryType>(context);

//            //Create risk event type
//            List<RecoveryType> recoveryTypes =
//                new()
//                {
//                    RecoveryType.Create(Guid.NewGuid(), "RecoveryType1"),
//                    RecoveryType.Create(Guid.NewGuid(), "RecoveryType2")
//                };

//            IList<RecoveryTypeDto> expectedResult = new List<RecoveryTypeDto>() 
//            { 
//                new RecoveryTypeDto(recoveryTypes[0].Id, recoveryTypes[0].Name),
//                new RecoveryTypeDto(recoveryTypes[1].Id, recoveryTypes[1].Name)
//            };

//            // persist to db
//            await repository.AddRangeAsync(recoveryTypes);
//            await repository.SaveChangesAsync();

//            //Act
//            var result = await RiskEventEndpointGetRecoveryTypes.HandleAsync(repository);
//            var value = ((result as IValueHttpResult).Value) as List<RecoveryTypeDto>;

//            //Assert
//            Assert.IsInstanceOf<Ok<IList<RecoveryTypeDto>>>(result);
//            Assert.That(value, Is.EquivalentTo(expectedResult));
//        }
//    }
//}
