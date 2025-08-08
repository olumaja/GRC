//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcTool.Domain.RiskEvent;
//using Arm.GrcTool.Domain;
//using Arm.GrcTool.Infrastructure;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Http;
//using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    internal class RiskEventEndpointGetRiskEventStatisticsTests
//    {
//        [Test]
//        [TestCase(Status.Pending)]
//        [TestCase(Status.Treated)]
//        public async Task CallMethod_ReturnsMatchingRiskEvents(Status status)
//        {

//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskEvent> riskEventRepository = new Repository<RiskEvent>(context);
//            IRepository<Document> documentRepository = new Repository<Document>(context);
//            IRepository<BusinessEntity> businessRepo = new Repository<BusinessEntity>(context);
//            IRepository<Department> deptRepo = new Repository<Department>(context);
//            IRepository<Unit> unitRepo = new Repository<Unit>(context);
//            IUnitOfWork unitOfWork = new UnitOfWork(context);

//            List<RiskEvent> riskEvents = new();
//            for (int i = 0; i < 20; i++)
//            {
//                // create instance of risk event dto
//                CreateRiskEventDto riskEventDto = new(
//                    DateOfIdentification: DateOnly.FromDateTime(DateTime.UtcNow),
//                    DateOfOcurrence: DateOnly.FromDateTime(DateTime.UtcNow),
//                    Description: "None for now",
//                    EstimatedLoss: 10000 * (i+1),
//                    LocationId: Guid.NewGuid(),
//                    DepartmentId: Guid.NewGuid(),
//                    UnitId: Guid.NewGuid(),
//                    Attachments: null,
//                    ReportedByUsername: "joshua",
//                    RiskEventDescription: "None for now"
//                    );

//                RiskEvent riskEvent = RiskEvent.Create(
//                    riskEventDto.DateOfIdentification,
//                    riskEventDto.DateOfOcurrence,
//                    riskEventDto.Description,
//                    riskEventDto.EstimatedLoss,
//                    riskEventDto.LocationId,
//                    riskEventDto.DepartmentId,
//                    riskEventDto.UnitId,
//                    riskEventDto.ReportedByUsername
//                    );
//                riskEvent.SetRiskEventStatus(i % 2 > 0 ? Status.Pending : Status.Treated);
//                riskEvents.Add( riskEvent );
//            }

//            // persist to db
//            await riskEventRepository.AddRangeAsync(riskEvents);
//            await unitOfWork.SaveChangesAsync();

//            // Act
//            var result = await RiskEventEndpointGetRiskEventStatistics.HandleAsync(riskEventRepository, documentRepository, businessRepo, deptRepo, unitRepo, status);
//            var responseValue = ((result as IValueHttpResult).Value) as List<RiskEventDto>;

//            //Assert
//            Assert.IsInstanceOf<Ok<IList<RiskEventDto>>>(result);
//            Assert.IsFalse(responseValue.Any(r => r.Status != status));
//        }
//    }
//}
