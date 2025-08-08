//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcTool.Domain;
//using Arm.GrcTool.Domain.RiskEvent;
//using Arm.GrcTool.Infrastructure;
//using Microsoft.AspNetCore.Http.HttpResults;
//using System.Security.Claims;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    public class RiskEventEndpointPostRiskEventTest
//    {
//        [Test]
//        public async Task CreateRiskEventWithValidParameters()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskEvent> riskEventRepository = new Repository<RiskEvent>(context);
//            IRepository<Document> documentRepository = new Repository<Document>(context);
//            IUnitOfWork unitOfWork = new UnitOfWork(context);

//            ClaimsPrincipal principal = new();
//            ClaimsIdentity identity = new("joshua", ClaimTypes.Name, ClaimTypes.Role);
//            identity.AddClaim(new Claim("name", "joshua"));
//            principal.AddIdentity(identity);

//            // create instance of risk event dto
//            CreateRiskEventDto riskEventDto = new CreateRiskEventDto(
//                DateOfIdentification: DateOnly.FromDateTime(DateTime.UtcNow),
//                DateOfOcurrence: DateOnly.FromDateTime(DateTime.UtcNow),
//                Description: "None for now",
//                EstimatedLoss: 100000,
//                LocationId: Guid.NewGuid(),
//                DepartmentId: Guid.NewGuid(),
//                UnitId: Guid.NewGuid(),
//                Attachments: null,
//                ReportedByUsername: "joshua",
//                RiskEventDescription: "None for now"
//                );

//            // Act
//            var result = await RiskEventEndpointPostRiskEvent.HandleAsync(riskEventDto, riskEventRepository, documentRepository, unitOfWork, principal);

//            //Assert
//            Assert.IsInstanceOf<Created<CreateRiskEventResponseDto>>(result);

//        }
//    }
//}
