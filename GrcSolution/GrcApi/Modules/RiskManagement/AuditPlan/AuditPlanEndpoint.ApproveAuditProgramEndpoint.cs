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
    * Endpoint to Approve Audit Program
    */
    public class ApproveAuditProgramEndpoint
    {

        /// <summary>
        /// Endpoint to Approve Audit Program
        /// </summary>
        /// <param name="commenceEngagementId"></param>
        /// <param name="auditmemo"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ApproveAuditProgramRequest payload, IRepository<AuditProgramAuditExecution> auditProgram, IRepository<AuditAnnouncementMemoAuditExecution> auditmemo,
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
                var getAuditPlanningMemo = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == payload.Team).FirstOrDefault();
                if (getAuditPlanningMemo == null)
                {
                    return TypedResults.NotFound($"Audit Program has not been fully performed");
                }
                if (getAuditPlanningMemo != null)
                {
                    getCommenceEng.ApproveEngagementPlanStatus(payload.Team);                    
                    getAuditPlanningMemo.ApproveAuditProgramStatus();
                    auditProgram.SaveChanges();
                    #region Send email to the supervisor 
                    
                    string subject = $"Audit Program - {getAuditAnnouncementMemo.Unit}";
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"]; 

                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string emailToOfficer = getAuditAnnouncementMemo.RequesterEmailAddress;
                    string bodyOfficer = $"Dear {getAuditAnnouncementMemo.RequesterName},<br> {requesterName} has approved the Audit Program for {getAuditAnnouncementMemo.Unit} {getAuditAnnouncementMemo.Recommendation}, for your review and approval.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.<br><br>Thank you";
                    var logEmailRequestOfficer = await EmailService.LogEmailRequestAssync(subject: subject, message: bodyOfficer, ModuleType.InternalAudit, getAuditAnnouncementMemo.Id, emailTo: emailToOfficer, toCC: toCC);


                    // Recipient 
                    var AuditEngagementLetterLink = string.Format(config["EmailConfiguration:AuditEngagementLetterLink"], payload.CommenceEngagementId, payload.Team);
                    var InformationRequirementLink = string.Format(config["EmailConfiguration:InformationRequirementLink"], payload.CommenceEngagementId, payload.Team);

                    //email
                    string salutation = $"Trust you are doing well.<br> This is to formally notify you that a {getAuditAnnouncementMemo.Recommendation} Audit of {getAuditAnnouncementMemo.Unit} unit will commence on {getAuditAnnouncementMemo.CommenceDate}.<br> During the audit, we will review the existence, adequacy and effectiveness of controls and processes in place for the unit’s operations, to determine if they are properly designed and operating as intended. We will also review compliance with policies and procedures as they relate to the unit. This will enable us to provide reasonable assurance to the business and key stakeholders on the effectiveness of these controls in addressing key risks within the {getAuditAnnouncementMemo.Unit}. <br>";
                    string auditScoped = $"Audit Scope. <br> The audit is for the period {getAuditAnnouncementMemo.PeriodFrom} to {getAuditAnnouncementMemo.PeriodTo}, and it will cover the areas listed in the attached Audit Engagement Letter <a href={AuditEngagementLetterLink}>link</a>.";
                    string workApproach = $"Work Approach. <br> The Audit review will be carried out using the following work approach:<br>» One-on-one interviews and walkthroughs with some process owners <br>» Review of policies and procedures <br>» Evaluation of the effectiveness of key controls and sample testing. <br>» Documentation of draft audit findings and recommendations; discussions with Management prior to the finalization of the report. <br>» Incorporation of Management’s comments and finalization of the report.<br>Where control weaknesses and audit exceptions are identified, these will be communicated on an on-going basis during the audit. Upon conclusion of the testing phase, Internal Audit will prepare a draft report summarizing key findings and recommendations on how the control issues can be remediated. We will solicit feedback regarding our findings, including your management action plans, and follow up on the implementation of our recommendations.";
                    string role = $"Your Role.<br>Please note that you are required to notify relevant staff about the commencement of this audit and kindly communicate to us the liaison for this review.<br>Also use this <a href={InformationRequirementLink}>link</a>. to view our initial list of information requirements. The list of requirements is not exhaustive, and additional requests may be made during the audit. Please assist in ensuring that all requirements are provided promptly for our review. Evidence should be uploaded in the Information Requirements folder, which will be shared shortly.<br>We expect to issue a final report in {getAuditAnnouncementMemo.CommenceDate.Value.Date.ToString("MMMM yyyy")}.<br> We look forward to working with you and other members of the team on this audit. Kindly contact {requesterName}, or any member of the Internal Audit team, should you require any additional information.";
                    string emailTo = getAuditAnnouncementMemo.Recipient;
                    string body = $"Dear {getAuditAnnouncementMemo.SalutationName},<br> {salutation} <br> {auditScoped} <br> {workApproach} <br>{role} <br><br>Thank you";
                    var logEmailRequest1 = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, getAuditAnnouncementMemo.Id, emailTo: emailTo, toCC: toCC);

                    #endregion
                    return TypedResults.Ok("Approved successfully");
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }

    public record ApproveAuditProgramRequest(Guid CommenceEngagementId, string Team);

    public class ApproveAuditProgramRequestValidation : AbstractValidator<ApproveAuditProgramRequest>
    {
        public ApproveAuditProgramRequestValidation()
        {
            RuleFor(x => x.CommenceEngagementId).NotEmpty();
            RuleFor(x => x.Team).NotEmpty()
             .Must(CharacterValidation.IsInvalidCharacter)
             .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
