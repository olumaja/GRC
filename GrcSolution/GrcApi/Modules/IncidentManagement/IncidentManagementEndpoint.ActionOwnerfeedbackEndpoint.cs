using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 04/04/2025
      * Development Group: GRCTools
      * The endpoint for the action owner to response to the logged management
      */
    public class ActionOwnerfeedbackEndpoint
    {
        /// <summary>
        /// The endpoint for the action owner to response to the logged management
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repo"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
           ActionownerFeedbackReq payload, IRepository<LogManagement> repo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            string requesterName = currentUserService.CurrentUserFullName;
            var logMgt = repo.GetContextByConditon(r => r.Id == payload.LogMgtId && r.Status != LogMgtStatus.Closed && r.ActionownerEmailAddress == currentUserService.CurrentUserEmail).FirstOrDefault();
            
            if (logMgt is null) 
                return TypedResults.NotFound("Log mgt was not assigned to you or it has been closed");

            logMgt.ActionOwnerFeedback(payload.BusinessJustification, payload.UserApprovalObtained, payload.Remarks);
            logMgt.SetModifiedBy(requesterName);
            logMgt.SetModifiedOnUtc(DateTime.Now);
            repo.SaveChanges();

            //Send Email notification
            #region Send email to the Information Security Team 

            string subject = $"{logMgt.LogType.ToString()} Log Assigned - Action Required";
            var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = logMgt.RequesterEmailAddress;
            string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
            string body = $"Hello {logMgt.CreatedBy}, <br><br>Action owner updated has requested.<br><br><strong>Business Justification</strong>:- {logMgt.BusinessJustification}.<br><br><strong>Remarks</strong>:- {logMgt.ActionOwnerRemarks}.<br><br> Click <a href={linkToGRCTool}>GRC link</a> to review the update.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InformationSecurity, logMgt.Id, emailTo, toCC);

            #endregion
            return TypedResults.Ok("Logged Mgt updated successfully");
        }
    }
}
