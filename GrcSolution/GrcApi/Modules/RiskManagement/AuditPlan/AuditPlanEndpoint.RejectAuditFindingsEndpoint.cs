using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class RejectAuditFindingsEndpoint
    {
        public static async Task<IResult> HandleAsync(
            RejectWorkpaperDto payload, IRepository<CommenceEngagementAuditexecution> commenceRepo, IRepository<AuditProgramAuditExecution> programRepo,
             IRepository<AuditAnnouncementMemoAuditExecution> auditmemo, IRepository<WorkPaper> workpaperRepo, IRepository<AuditFindings> findingsRepo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
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
                var getworkpaperRepo = workpaperRepo.GetContextByConditon(x => x.AuditProgramId == payload.AuditProgramId && x.Team == payload.Team).FirstOrDefault();
                if (getworkpaperRepo == null)
                {
                    return TypedResults.NotFound($"Work paperwas not found");
                }

                var getfindingsRepo = findingsRepo.GetContextByConditon(x => x.WorkerPaperId == getworkpaperRepo.Id && x.Team == payload.Team && x.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getfindingsRepo == null)
                {
                    return TypedResults.NotFound($"Audit finding was not found");
                }
                getprogramRepo.RejectFindingStatus(payload.ReasonForRejection);
                commenceEngagement.RejectFindingstatusStatus(payload.Team, payload.ReasonForRejection);
                getfindingsRepo.RejectFindingStatus(payload.Team, payload.ReasonForRejection);
                commenceRepo.SaveChanges();
                #region Send email to the supervisor 
               
                string subject = $"{getAuditAnnouncementMemo.Unit} - Audit Finding.";
                string emailTo = getAuditAnnouncementMemo.RequesterEmailAddress;
                string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Dear {getAuditAnnouncementMemo.RequesterName},<br> {requesterName} has rejected the audit finding for {getAuditAnnouncementMemo.Unit} {getAuditAnnouncementMemo.Recommendation}, for your review and approval.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.<br><br>Thank you";

                var logEmailRequest1 = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, getprogramRepo.Id, emailTo: emailTo, toCC: toCC);

                #endregion
                return TypedResults.Ok("Audit findings rejected");
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }

   
}
