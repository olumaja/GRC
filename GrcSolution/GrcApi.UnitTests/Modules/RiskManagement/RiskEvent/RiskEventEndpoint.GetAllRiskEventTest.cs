using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;

namespace GrcApi.UnitTests.Modules.RiskManagement
{
    public class RiskEventEndpointGetAllRiskEventTest
    {
        [Test]
        public async Task CreateRiskEventWithValidParameters()
        {

            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            ICurrentUserService currentUserService = new CurrentUserService(httpContextAccessor);
            IRepository<RiskEvent> riskEventRepository = new Repository<RiskEvent>(context);
            IRepository<Document> documentRepository = new Repository<Document>(context);
            IRepository<BusinessEntity> businessRepo = new Repository<BusinessEntity>(context);
            IRepository<Department> deptRepo = new Repository<Department>(context);
            IRepository<Unit> unitRepo = new Repository<Unit>(context);
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            ClaimsPrincipal principal = new();
            ClaimsIdentity identity = new("joshua", ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim("name", "joshua"));
            identity.AddClaim(new Claim("department", "Risk Department"));
            principal.AddIdentity(identity);

            // should return empty list when there is no data
            var result = await RiskEventEndpointGetAllRiskEvent.HandleAsync(riskEventRepository, documentRepository, businessRepo, deptRepo, unitRepo, currentUserService, principal);
            Assert.NotNull(result);


            // create instance of risk event dto
            CreateRiskEventDto riskEventDto = new CreateRiskEventDto(
                DateOfIdentification: DateOnly.FromDateTime(DateTime.UtcNow),
                DateOfOcurrence: DateOnly.FromDateTime(DateTime.UtcNow),
                Description: "None for now",
                EstimatedLoss: 100000,
                LocationId: Guid.NewGuid(),
                DepartmentId: Guid.NewGuid(),
                UnitId: Guid.NewGuid(),
                Attachments: null,
                ReportedByUsername: "joshua"
                //RiskEventDescription: "None for now"
                );

            RiskEvent riskEvent = RiskEvent.Create(
                riskEventDto.DateOfIdentification,
                riskEventDto.DateOfOcurrence,
                riskEventDto.Description,
                riskEventDto.EstimatedLoss,
                riskEventDto.LocationId,
                riskEventDto.DepartmentId,
                riskEventDto.UnitId,
                riskEventDto.ReportedByUsername
                );

            // persist to db
            await riskEventRepository.AddAsync(riskEvent);
            await unitOfWork.SaveChangesAsync();

            // Act
            result = await RiskEventEndpointGetAllRiskEvent.HandleAsync(riskEventRepository, documentRepository, businessRepo, deptRepo, unitRepo, currentUserService, principal);

            //Assert
            Assert.IsInstanceOf<Ok<IList<RiskEventDto>>>(result);

        }
    }
}
