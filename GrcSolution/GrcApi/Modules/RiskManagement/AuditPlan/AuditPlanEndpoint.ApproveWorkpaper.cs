using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ApproveWorkpaperEndpoint
    {
        public static async Task<IResult> HandleAsync(
            ApproveWorkpaperDto payload, IRepository<CommenceEngagementAuditexecution> commenceRepo, IRepository<AuditProgramAuditExecution> programRepo,
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
                var getprogramRepo = await programRepo.FirstOrDefaultAsync(x => x.Id == payload.AuditProgramId && x.Team == payload.Team);
                if (getprogramRepo is null)
                {
                    return TypedResults.BadRequest("Audit program does not exist or record has been previosly approved");
                }
                var commenceEngagement = await commenceRepo.FirstOrDefaultAsync(x => x.Id == getprogramRepo.CommenceEngagementAuditexecutionId && x.Team == payload.Team);
                
                if (commenceEngagement is null)
                {
                    return TypedResults.BadRequest("Commence engagement does not exist");
                }
                var getAuditAnnouncementMemo = auditmemo.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == commenceEngagement.Id && x.Team == payload.Team).FirstOrDefault();
                if (getAuditAnnouncementMemo == null)
                {
                    return TypedResults.NotFound($"Audit Announcement Memo has not been fully performed");
                }
                var getworkpaperRepo = workpaperRepo.GetContextByConditon(x => x.AuditProgramId == payload.AuditProgramId && x.Team == payload.Team && x.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getworkpaperRepo is null)
                {
                    return TypedResults.BadRequest("Work paper was not found");
                }
                getprogramRepo.UpdateWorkpaperStatus(payload.Team);
                commenceEngagement.ApproveWorkPaperStatus(payload.Team);
                getworkpaperRepo.ApproveWorkPaperStatus(payload.Team);
                commenceRepo.SaveChanges();
                #region Send email to the supervisor 

                string subject = $"{getAuditAnnouncementMemo.Unit} - Work Paper.";
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = getAuditAnnouncementMemo.RequesterEmailAddress;
                string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                string body = $"Dear {getAuditAnnouncementMemo.RequesterName},<br> {requesterName} has approved the work paper for {getAuditAnnouncementMemo.Unit} {getAuditAnnouncementMemo.Recommendation}, for your review and approval.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.<br><br>Thank you";
                var logEmailRequest1 = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, commenceEngagement.Id, emailTo: emailTo, toCC: toCC);

                #endregion
                return TypedResults.Ok("Work paper approved");
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }

    public record ApproveWorkpaperDto(Guid AuditProgramId, string Team);

    public class ApproveWorkpaperDtoValidation : AbstractValidator<ApproveWorkpaperDto>
    {
        public ApproveWorkpaperDtoValidation()
        {
            RuleFor(x => x.AuditProgramId).NotEmpty();
            RuleFor(x => x.Team).NotEmpty()
              .Must(CharacterValidation.IsInvalidCharacter)
              .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
