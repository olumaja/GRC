using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class RejectWorkpaperEndpoint
    {
        public static async Task<IResult> HandleAsync(
            RejectWorkpaperDto payload, IRepository<CommenceEngagementAuditexecution> commenceRepo, IRepository<AuditProgramAuditExecution> programRepo,
            IRepository<AuditAnnouncementMemoAuditExecution> auditmemo, IRepository<WorkPaper> workpaperRepo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                var getprogramRepo = programRepo.GetContextByConditon(x => x.Id == payload.AuditProgramId && x.Team == payload.Team).FirstOrDefault();
                if (getprogramRepo is null)
                {
                    return TypedResults.BadRequest("Audit program does not exist");
                }
                var commenceEngagement = commenceRepo.GetContextByConditon(x => x.Id == getprogramRepo.CommenceEngagementAuditexecutionId && x.Team == payload.Team).FirstOrDefault();

                if (commenceEngagement is null)
                {
                    return TypedResults.BadRequest("Commence engagement does not exist");
                }
                var getAuditAnnouncementMemo = auditmemo.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == commenceEngagement.Id && x.Team == payload.Team).FirstOrDefault();
                if (getAuditAnnouncementMemo == null)
                {
                    return TypedResults.NotFound($"Audit Announcement Memo has not been fully performed");
                }
                var getworkpaperRepo = await workpaperRepo.FirstOrDefaultAsync(x => x.AuditProgramId == payload.AuditProgramId && x.Team == payload.Team && x.Status != BusinessRiskRatingStatus.Approved);
                if (getworkpaperRepo is null)
                {
                    return TypedResults.BadRequest("Work paper was not found");
                }

                getprogramRepo.RejectWorkpaperStatus(payload.ReasonForRejection);
                commenceEngagement.RejectWorkPaperStatus(payload.Team, payload.ReasonForRejection);
                getworkpaperRepo.RejectWorkPaperStatus(payload.Team, payload.ReasonForRejection);
                commenceRepo.SaveChanges();
                #region Send email to the supervisor 

                string subject = $"{getAuditAnnouncementMemo.Unit} - Work Paper.";
                string emailTo = getAuditAnnouncementMemo.RequesterEmailAddress;
                string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Dear {getAuditAnnouncementMemo.RequesterName},<br> {requesterName} has rejected the work paper for {getAuditAnnouncementMemo.Unit} {getAuditAnnouncementMemo.Recommendation}, for your review and approval.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.<br><br>Thank you";
                var logEmailRequest1 = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, getprogramRepo.Id, emailTo: emailTo, toCC: toCC);

                #endregion
                return TypedResults.Ok("Work paper rejected");
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }

    public record RejectWorkpaperDto(Guid AuditProgramId, string Team, string ReasonForRejection);

    public class RejectWorkpaperDtoValidation : AbstractValidator<RejectWorkpaperDto>
    {
        public RejectWorkpaperDtoValidation()
        {
            RuleFor(x => x.AuditProgramId).NotEmpty();
            RuleFor(x => x.Team).NotEmpty()
              .Must(CharacterValidation.IsInvalidCharacter)
              .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.ReasonForRejection).NotEmpty()
              .Must(CharacterValidation.IsInvalidCharacter)
              .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
