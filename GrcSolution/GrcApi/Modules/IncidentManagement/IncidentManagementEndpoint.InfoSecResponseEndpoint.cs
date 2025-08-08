using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 04/24/2025
       * Development Group: GRCTools
       * The endpoint for the infosec staff response
       */
    public class InfoSecResponseEndpoint
    {
        /// <summary>
        /// The endpoint for the infosec staff response
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repo"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
           InfoSecResponseReq payload, IRepository<LogManagement> repo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                string requesterName = currentUserService.CurrentUserFullName;
                var logMgt = repo.GetContextByConditon(r => r.Id == payload.LogMgtId && r.Status != LogMgtStatus.Closed && !string.IsNullOrWhiteSpace(r.ActionOwnerRemarks)).FirstOrDefault();
                if (logMgt is null) return TypedResults.NotFound("Log Management was not found or it has been closed");

                if (payload.Status.ToLower() == "rejected" && string.IsNullOrEmpty(payload.Remarks))
                {
                    return TypedResults.BadRequest("There must be a reason for the rejection");
                }
                var logMgtStatus = payload.Status.ToLower();
                var status = new Dictionary<string, LogMgtStatus> { { "closed", LogMgtStatus.Closed }, { "rejected", LogMgtStatus.Rejected } };
                if (!status.ContainsKey(logMgtStatus))
                    return TypedResults.BadRequest("Status allowed are Rejected or Closed");
                logMgt.InfoSecRespnse(status[logMgtStatus], payload.Remarks);
                logMgt.SetModifiedBy(requesterName);
                logMgt.SetModifiedOnUtc(DateTime.Now);
                repo.SaveChanges();

                //Send Email notification
                #region Send email to the Action Owner             
                string subject = $"{logMgt.LogType.ToString()} Log Management Updated";
                var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = logMgt.ActionownerEmailAddress;
                string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                string body = $"Hello {logMgt.ActionownerName}, <br><br>InfoSec Staff updated the log Management request.<br><br><strong>Status</strong>:- {payload.Status}.<br><br><strong>Remarks</strong>:- {payload.Remarks}.<br><br> Click <a href={linkToGRCTool}>GRC link</a> to review the update.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InformationSecurity, logMgt.Id, emailTo, toCC);

                #endregion
                return TypedResults.Ok("Logged Management updated successfully");
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest("Unable to Logged Management updated successfully");
            }
        }
    }
}
