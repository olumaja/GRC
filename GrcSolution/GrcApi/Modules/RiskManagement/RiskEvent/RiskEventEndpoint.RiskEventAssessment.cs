using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Arm.GrcApi.Modules.RiskManagement
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 15/01/2024
     * Development Group: GRCTools
     * Send email when Risk Management concludes the assessment
     */
    public class RiskEventEndpointPostRiskEventAssessment
    {
        /// <summary>
        /// Send email when Risk Management concludes the assessment
        /// </summary>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="riskEventId"></param>
        /// <param name="assessmentDto"></param>
        /// <param name="riskRepo"></param>
        /// <param name="riskEffectRepo"></param>
        /// <param name="riskEventRepo"></param>
        /// <param name="actionRepo"></param>
        /// <param name="lossRepo"></param>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            RiskAssessmentDto assessmentDto, IRepository<RiskEvent> riskRepo, IRepository<RiskEffectManagement> riskEffectRepo, IRepository<RiskEventManagement> riskEventRepo,
            IRepository<ActionManagement> actionRepo, IRepository<LossManagement> lossRepo, IUnitOfWork unitOfWork, ClaimsPrincipal user, ICurrentUserService currentUserService,
            IEmailService EmailService, IConfiguration config
        ) 
        {
            RiskEvent specifiedRiskEvent = await riskRepo.GetByIdAsync(assessmentDto.RiskEventId);

            if (specifiedRiskEvent is null)
                return TypedResults.BadRequest("The specify Risk Event does not exist");

            // Insert into RiskEventManagement
            List<RiskEventManagement> riskEventManagements = new();
            foreach(var eventItem in assessmentDto.eventsManagement)
            {
                RiskEventManagement riskEventManagement = RiskEventManagement.Create(
                    eventItem.RiskEventId,
                    eventItem.EventTypeId,
                    eventItem.EventCategoryId,
                    eventItem.EventSubCategoryId,
                    Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    eventItem.RiskDriverId,
                    eventItem.RiskDriverCategoryId,
                    eventItem.RiskDriverSubCategoryId,
                    eventItem.RiskDriverDescription
                );
                riskEventManagements.Add(riskEventManagement);
            }

            await riskEventRepo.AddRangeAsync(riskEventManagements);

            // Insert into LossManagement
            List<LossManagement> lossManagementList = new();
            foreach(var lossItem in assessmentDto.lossesManagement)
            {
                LossManagement lossManagement = LossManagement.Create(
                    lossItem.RiskEventId,
                    lossItem.GrossLossValue,
                    lossItem.TotalRecoveredAmount,
                    lossItem.RecoveryDate,
                    lossItem.RecoveredAmount,
                    Guid.Parse("00000000-0000-0000-0000-000000000000"),
                    lossItem.RecoveryDescription,
                    lossItem.NetLoss,
                    lossItem.AccountImpacted
                );
                lossManagementList.Add(lossManagement);
            }

            await lossRepo.AddRangeAsync (lossManagementList);

            // Insert into RiskEffect
            List<RiskEffectManagement> effectManagements = new();
            foreach(var effectItem in assessmentDto.effectsManagement)
            {
                RiskEffectManagement riskEffect = RiskEffectManagement.Create(
                    effectItem.RiskEventId,
                    effectItem.EffectType,
                    effectItem.EffectCategoryId,
                    effectItem.LossValue,
                    effectItem.RationaleForGrossLossValue,
                    effectItem.EffectDescription
                );

                effectManagements.Add(riskEffect);
            }
            await riskEffectRepo.AddRangeAsync (effectManagements);

            // Insert into ActionManagement
            List<ActionManagement> actionManagements = new();
            foreach(var actionItem in assessmentDto.actionsManagement)
            {
                ActionManagement actionManag = ActionManagement.Create(
                    actionItem.RiskEventId,
                    actionItem.Action,
                    actionItem.ActionOwner,
                    actionItem.ActionResolutionDate,
                    actionItem.ActionProgress,
                    actionItem.ActionStatus
                );
                actionManagements.Add(actionManag);
            }
            await actionRepo.AddRangeAsync (actionManagements);

            specifiedRiskEvent.SetRiskEventStatus(
                RiskEvent.Status.Treated
            );

            riskRepo.Update(specifiedRiskEvent);
            await unitOfWork.SaveChangesAsync();
           
            #region Log email request
            string subject = $"New Risk Event";
            string emailTo = config["EmailConfiguration:RiskMgtUnit"];
            string toCC = config["EmailConfiguration:toCC"];
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string body = $"Hello all, <br>The Risk Management team have concluded the Risk Assessment on a risk event and assigned an action to you.<br><ul><li>Event Description: {specifiedRiskEvent.RiskEventDescription}</li><li>Event Identifier: {specifiedRiskEvent.ReportedByUsername}</li><li>Action Plan: {specifiedRiskEvent.Description}</li><li>Action Resolution Date: {specifiedRiskEvent.DateOfOccurence}</li></ul> <br>Kindly click on the link to view:<br> <a href={linkToGRCTool}>GRC link</a>.";

            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, assessmentDto.RiskEventId, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"New Risk event Exercise was created successfully, but email message was not logged");
            }
            //LogEmailRequestAssync

            #endregion
            return TypedResults.Ok("Assessment successful");
        }
    }

    public record RiskAssessmentDto(
         Guid RiskEventId 
        ,IList<CreateEventManagementDto> eventsManagement
        ,IList<CreateEffectManagementDto> effectsManagement
        ,IList<CreateActionManagementDto> actionsManagement
        ,IList<CreateLossManagementDto> lossesManagement
    );

    public class RiskAssessmentDtoValidator : AbstractValidator<RiskAssessmentDto>
    {
        public RiskAssessmentDtoValidator()
        {
            RuleFor(x => x.RiskEventId).NotEmpty();
            RuleFor(x => x.eventsManagement).NotEmpty();
            RuleForEach(x => x.eventsManagement).SetValidator(new CreateEventManagementDtoValidator());
            RuleFor(x => x.actionsManagement).NotEmpty();
            RuleForEach(x => x.actionsManagement).SetValidator(new CreateActionManagementDtoValidator());
            RuleFor(x => x.effectsManagement).NotEmpty();
            RuleForEach(x => x.effectsManagement).SetValidator(new CreateEffectManagementDtoValidator());
            RuleFor (x => x.lossesManagement).NotEmpty();
            RuleForEach(x => x.lossesManagement).SetValidator (new CreateLossManagementDtoValidator());
        }
    }
}
