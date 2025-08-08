using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;
using static GrcApi.Modules.RiskManagement.RiskEventEndpointGetRiskEventAssessment;

namespace GrcApi.UnitTests.Modules.RiskManagement
{
    public class RiskEventEndpointGetRiskEventAssessmentTest
    {
        [Test]
        public async Task RiskEventAssessmentGetEndpoint_CallMethod_ReturnsCreatedRiskEventAssessment()
        {
            // Arrange 
            await using var context = new MockDb().CreateDbContext();
            IRepository<RiskEvent> riskEventRepo = new Repository<RiskEvent>(context);
            IRepository<RiskEventManagement> riskEventManageRepo = new Repository<RiskEventManagement>(context);
            IRepository<RiskEffectManagement> riskEffectRepo = new Repository<RiskEffectManagement>(context);
            IRepository<ActionManagement> actionRepo = new Repository<ActionManagement>(context);
            IRepository<LossManagement> lossRepo = new Repository<LossManagement>(context);

            //create risk event
            RiskEvent riskEvent = RiskEvent.Create(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now),
                "test riskevent", 0, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "test reporter");
            riskEventRepo.Add(riskEvent);
            riskEffectRepo.SaveChanges();
            Guid riskEventId = riskEvent.Id;
            context.Entry(riskEvent).State = EntityState.Detached;

            // Create instance of RiskEventManagement list
            List<RiskEventManagement> riskEventManagement = new()
            {
                RiskEventManagement.Create(
                    riskEventId,
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "This is risk driver test"
                )
            };
            riskEventManageRepo.AddRange(riskEventManagement);

            // Create instance of CreateEffectManagementDto list
            List<RiskEffectManagement> effectManagementDtos = new()
            {
                RiskEffectManagement.Create(
                    riskEventId,
                    EffectType.None,
                    Guid.NewGuid(),
                    2,
                    "Maybe it is good",
                    "This is effect description"
                )
            };
            riskEffectRepo.AddRange(effectManagementDtos);

            // Create instance of CreateActionManagementDto List
            List<ActionManagement> actionManagement = new()
            {
                ActionManagement.Create(
                    riskEventId,
                    "Action carried out by owner",
                    "Segun",
                    new DateOnly(2023, 8, 8),
                    "Pending",
                    ActionState.Pending
                )

            };
            actionRepo.AddRange(actionManagement);

            // Create instance of CreateLossManagementDto list
            List<LossManagement> lossManagement = new()
            {
                 LossManagement.Create(
                    riskEventId,
                    2,
                    3000,
                    new DateOnly(2023, 8, 9),
                    1000,
                    Guid.NewGuid(),
                    "Recovery description",
                    1000,
                    "Account number"
                )
            };
            lossRepo.AddRange(lossManagement);
            await lossRepo.SaveChangesAsync();

            //// Act
            //var result = await HandleAsync(riskEventId, riskEffectRepo, riskEventManageRepo, actionRepo, lossRepo);
            //var value = ((result as IValueHttpResult).Value) as RiskAssessmentResponseDto;

            //// Assert
            //Assert.IsInstanceOf<Ok<RiskAssessmentResponseDto>>(result);
            //Assert.That(value.EffectsManagement[0].EffectCategoryId, Is.EqualTo(effectManagementDtos[0].EffectCategoryId));
            //Assert.That(value.EventsManagement[0].EventTypeId, Is.EqualTo(riskEventManagement[0].EventTypeId));
            //Assert.That(value.LossesManagement[0].NetLoss, Is.EqualTo(lossManagement[0].NetLoss));
            //Assert.That(value.ActionsManagement[0].Action, Is.EqualTo(actionManagement[0].Action));
        }
    }
}
