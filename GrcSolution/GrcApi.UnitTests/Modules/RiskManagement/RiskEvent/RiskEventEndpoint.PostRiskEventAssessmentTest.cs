//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcTool.Domain.RiskEvent;
//using Arm.GrcTool.Infrastructure;

//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.EntityFrameworkCore;

//using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

//namespace GrcApi.UnitTests.Modules.RiskManagement
//{
//    public class RiskEventEndpoint
//    {
//        [Test]
//        public async Task CreateRiskEventWithValidParameters()
//        {
//            // Arrange 
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskEvent> riskEventRepo = new Repository<RiskEvent>(context);
//            IRepository<RiskEventManagement> riskEventManageRepo = new Repository<RiskEventManagement>(context);
//            IRepository<RiskEffectManagement> riskEffectRepo = new Repository<RiskEffectManagement>(context);
//            IRepository<ActionManagement> actionRepo = new Repository<ActionManagement>(context);
//            IRepository<LossManagement> lossRepo = new Repository<LossManagement>(context);
//            IUnitOfWork unitOfWork = new UnitOfWork(context);

//            //create risk event
//            RiskEvent riskEvent = RiskEvent.Create(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now),
//                "test riskevent", 0, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "test reporter");
//            riskEventRepo.Add(riskEvent);
//            riskEffectRepo.SaveChanges();
//            Guid riskEventId = riskEvent.Id;
//            context.Entry(riskEvent).State = EntityState.Detached;

//            // Create instance of CreateEventManagementDto list
//            List<CreateEventManagementDto> eventManagementDtos = new List<CreateEventManagementDto>
//            {
//                new CreateEventManagementDto(
//                    RiskEventId: riskEventId,
//                    EventTypeId: Guid.NewGuid(),
//                    EventCategoryId: Guid.NewGuid(),
//                    EventSubCategoryId: Guid.NewGuid(),
//                    BoundaryEventId: Guid.NewGuid(),
//                    RiskDriverId: Guid.NewGuid(),
//                    RiskDriverCategoryId: Guid.NewGuid(),
//                    RiskDriverSubCategoryId: Guid.NewGuid(),
//                    RiskDriverDescription: "This is risk driver test"
//                )
//            };

//            // Create instance of CreateEffectManagementDto list
//            List<CreateEffectManagementDto> effectManagementDtos = new List<CreateEffectManagementDto>
//            {
//                new CreateEffectManagementDto(
//                    RiskEventId: riskEventId,
//                    EffectType: EffectType.None,
//                    EffectCategoryId: Guid.NewGuid(),
//                    LossValue: 2,
//                    RationaleForGrossLossValue: "Maybe it is good",
//                    EffectDescription: "This is effect description"
//                )
//            };

//            // Create instance of CreateActionManagementDto List
//            List<CreateActionManagementDto> actionManagementDtos = new List<CreateActionManagementDto>
//            {
//                new CreateActionManagementDto(
//                    RiskEventId: riskEventId,
//                    Action: "Action carried out by owner",
//                    ActionOwner: "Segun",
//                    ActionResolutionDate: new DateOnly(2023, 8, 8),
//                    ActionProgress: "Pending",
//                    ActionStatus: ActionState.Pending
//                )

//            };

//            // Create instance of CreateLossManagementDto list
//            List<CreateLossManagementDto> lossManagementDtos = new List<CreateLossManagementDto>
//            {
//                new CreateLossManagementDto(
//                    RiskEventId: riskEventId,
//                    GrossLossValue: 2,
//                    TotalRecoveredAmount: 3000,
//                    RecoveryDate: new DateOnly(2023, 8, 9),
//                    RecoveredAmount: 1000,
//                    RecoveryTypeId: Guid.NewGuid(),
//                    RecoveryDescription: "Recovery description",
//                    NetLoss: 1000,
//                    AccountImpacted: "Account number"
//                )
//            };

//            // Create instance of RiskAssessmentDto
//            RiskAssessmentDto riskAssessment = new RiskAssessmentDto(
//                RiskEventId: riskEventId,
//                eventManagementDtos,
//                effectManagementDtos,
//                actionManagementDtos,
//                lossManagementDtos
//            );

//            // Act
//            var result = await RiskEventEndpointPostRiskEventAssessment.HandleAsync(riskEventId,
//                riskAssessment, riskEventRepo, riskEffectRepo, riskEventManageRepo, actionRepo, lossRepo, unitOfWork
//            );

//            // Assert
//            Assert.IsInstanceOf<Ok>(result);

//        }
//    }
//}
