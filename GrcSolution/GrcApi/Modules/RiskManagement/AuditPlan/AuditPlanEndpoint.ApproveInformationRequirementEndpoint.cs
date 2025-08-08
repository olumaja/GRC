using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 09/05/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * Endpoint to approve Information Requirement
  */
    public class ApproveInformationRequirementEndpoint
    {

        /// <summary>
        /// Endpoint to approve Information Requirement
        /// </summary>
        /// <param name="commenceEngagementId"></param>
        /// <param name="auditmemo"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ApproveInformationRequirementRequest payload, IRepository<InformationRequirementAuditExecution> informationReq, 
            IRepository<CommenceEngagementAuditexecution> commenceEng, IRepository<AuditAnnouncementMemoAuditExecution> auditmemo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
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
                var getInformationRequirement = informationReq.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == payload.Team).FirstOrDefault();
                if (getInformationRequirement == null)
                {
                    return TypedResults.NotFound($"Information Requirement has not been fully performed");
                }
                if (getInformationRequirement != null)
                {
                    getInformationRequirement.ApproveInformationRequirementStatus();
                    informationReq.SaveChanges();

                    #region Send email to the supervisor 
                   
                    string subject = $"Information Requirement - {getAuditAnnouncementMemo.Unit}";
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string emailToOfficer = getAuditAnnouncementMemo.RequesterEmailAddress;
                    string bodyOfficer = $"Dear {getAuditAnnouncementMemo.RequesterName},<br> {requesterName} has approved the Information Requirement for {getAuditAnnouncementMemo.Unit} {getAuditAnnouncementMemo.Recommendation}, for your review and approval.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.<br><br>Thank you";
                    var logEmailRequestOfficer = await EmailService.LogEmailRequestAssync(subject: subject, message: bodyOfficer, ModuleType.InternalAudit, getAuditAnnouncementMemo.Id, emailTo: emailToOfficer, toCC: toCC);

                    #endregion

                    return TypedResults.Ok("Approved successfully");
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
                return TypedResults.Problem(ex.Message);
            }
        }
    }

    public record ApproveInformationRequirementRequest(Guid CommenceEngagementId, string Team);

    public class ApproveInformationRequirementRequestValidation : AbstractValidator<ApproveInformationRequirementRequest>
    {
        public ApproveInformationRequirementRequestValidation()
        {
            RuleFor(x => x.CommenceEngagementId).NotEmpty();
            RuleFor(x => x.Team).NotEmpty()
             .Must(CharacterValidation.IsInvalidCharacter)
             .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
