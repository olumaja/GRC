using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 09/05/2024
    * Development Group: Audit plan Risk Assessment - GRCTools
    * Endpoint to Reject Audit Planning Memo
    */
    public class RejectAuditPlanningMemoEndpoint
    {

        /// <summary>
        /// Endpoint to Approve Audit Planning Memo
        /// </summary>
        /// <param name="commenceEngagementId"></param>
        /// <param name="auditmemo"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            [FromBody] RejectAuditPlanningMemoRequest payload, IRepository<AuditPlanningMemoAuditExecution> auditProgram, IRepository<AuditAnnouncementMemoAuditExecution> auditmemo,
            IRepository<CommenceEngagementAuditexecution> commenceEng, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
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
                var getCommenceEng = commenceEng.GetContextByConditon(x => x.Id == payload.CommenceEngagementId).FirstOrDefault();
                if (getCommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement Id '{payload.CommenceEngagementId}' was not found");
                }
                var getAuditAnnouncementMemo = auditmemo.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == payload.Team).FirstOrDefault();
                if (getAuditAnnouncementMemo == null)
                {
                    return TypedResults.NotFound($"Audit Announcement Memo has not been fully performed");
                }
                var getAuditPlanningMemo = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == payload.Team && x.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getAuditPlanningMemo == null)
                {
                    return TypedResults.NotFound($"Audit Planning Memo has not been fully performed");
                }
                if (getAuditPlanningMemo != null)
                {
                    getAuditPlanningMemo.RejectAuditPlanningMemoStatus(payload.Reason);
                    auditProgram.SaveChanges();
                    #region Send email to the supervisor 
                   
                    string subject = $"Audit Planning Memo - {getAuditAnnouncementMemo.Unit}.";
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"];

                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string emailToOfficer = getAuditAnnouncementMemo.RequesterEmailAddress;
                    string bodyOfficer = $"Dear {getAuditAnnouncementMemo.RequesterName},.<br> {requesterName} has rejected the Audit Planning Memo for {getAuditAnnouncementMemo.Unit} {getAuditAnnouncementMemo.Recommendation}, for your review and approval.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.<br><br>Thank you";
                    var logEmailRequestOfficer = await EmailService.LogEmailRequestAssync(subject: subject, message: bodyOfficer, ModuleType.InternalAudit, getAuditAnnouncementMemo.Id, emailTo: emailToOfficer, toCC: toCC);

                    #endregion
                    return TypedResults.Ok("Rejected successfully");
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }

    public record RejectAuditPlanningMemoRequest(Guid CommenceEngagementId, string Reason, string Team);

    public class RejectAuditPlanningMemoRequestValidation : AbstractValidator<RejectAuditPlanningMemoRequest>
    {
        public RejectAuditPlanningMemoRequestValidation()
        {
            RuleFor(x => x.CommenceEngagementId).NotEmpty();
            RuleFor(x => x.Reason).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.Team).NotEmpty()
             .Must(CharacterValidation.IsInvalidCharacter)
             .WithMessage("{PropertyName} contains one or more special characters that are not allow"); 
        }
    }
}
