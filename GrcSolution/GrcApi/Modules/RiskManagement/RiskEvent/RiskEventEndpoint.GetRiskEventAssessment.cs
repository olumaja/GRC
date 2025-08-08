using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement
{
    public class RiskEventEndpointGetRiskEventAssessment
    {
        public static async Task<IResult> HandleAsync(Guid riskEventId, IRepository<RiskEffectManagement> riskEffectRepo,ClaimsPrincipal user, IRepository<RiskEventManagement> riskEventRepo,
            IRepository<ActionManagement> actionRepo, IRepository<LossManagement> lossRepo, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                // Get risk effect management
                var riskEffectsManagement = riskEffectRepo.GetContextByConditon(r => r.RiskEventId.Equals(riskEventId)).ToList();
                IList<EffectManagementDto> effectsManagement = riskEffectsManagement.Select(r => new EffectManagementDto(
                    r.RiskEventId, r.EffectType, r.EffectCategoryId, r.LossValue, r.RationaleForGrossLossValue, r.EffectDescription
                )).ToList();

                // Get event management
                var riskEventsManagement = riskEventRepo.GetContextByConditon(r => r.RiskEventId.Equals(riskEventId));
                IList<EventManagementDto> eventsManagement = riskEventsManagement.Select(e => new EventManagementDto(
                    e.RiskEventId, e.EventTypeId, e.EventCategoryId, e.EventSubCategoryId, e.BoundaryEventId, e.RiskDriverId, e.RiskDriverCategoryId,
                    e.RiskDriverSubCategoryId, e.RiskDriverDescription
                )).ToList();

                // Get action management
                var actionsManagement = actionRepo.GetContextByConditon(r => r.RiskEventId.Equals(riskEventId));
                IList<ActionManagementDto> actions = actionsManagement.Select(a => new ActionManagementDto(
                    a.RiskEventId, a.Action, a.ActionOwner, a.ActionResolutionDate, a.ActionProgress, a.ActionStatus
                )).ToList();

                // Get loss management
                var lossesManagement = lossRepo.GetContextByConditon(r => r.RiskEventId.Equals(riskEventId));
                IList<LossManagementDto> losses = lossesManagement.Select(l => new LossManagementDto(
                    l.RiskEventId, l.GrossLossValue, l.TotalRecoveredAmount, l.RecoveryDate, l.RecoveredAmount, l.RecoveryTypeId, l.RecoveryDescription,
                    l.NetLoss, l.AccountImpacted
                )).ToList();

                RiskAssessmentResponseDto riskAssessment = new(riskEventId, eventsManagement, effectsManagement, actions, losses);
                return TypedResults.Ok(riskAssessment);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }

        public record RiskAssessmentResponseDto(
             Guid RiskEventId
            , IList<EventManagementDto> EventsManagement
            , IList<EffectManagementDto> EffectsManagement
            , IList<ActionManagementDto> ActionsManagement
            , IList<LossManagementDto> LossesManagement
        );
    }
}
