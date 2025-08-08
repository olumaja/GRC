using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.Shared.EmailNotification;
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
       * The endpoint for the Infosec to assign incidence to an action owner
       */
    public class ActionOwnerUpdateEndpoint
    {
        /// <summary>
        /// The endpoint for the Infosec to assign incidence to an action owner
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repo"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
           ActionownerResponseReq payload, IRepository<IncidentManagementLog> repo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            string requesterName = currentUserService.CurrentUserFullName;

            var incidence = repo.GetContextByConditon(r => r.Id == payload.IncidenceId && r.Status != ActionStatus.Closed && r.ActionOwnerEmailAddress == currentUserService.CurrentUserEmail).FirstOrDefault();
            if (incidence is null) return TypedResults.NotFound("Incidence was not assigned to you or it has been closed");
            
            var statusCategory = payload.Status.ToLower();
            var status = new Dictionary<string, ActionStatus> { { "open", ActionStatus.Open }, { "work in progress", ActionStatus.Work_In_Progress }, { "closed", ActionStatus.Closed } };
            if (!status.ContainsKey(statusCategory))
                return TypedResults.BadRequest("Status allowed are Open or Work In Progress or Closed");
            incidence.ActionOwnerResponse(status[statusCategory], payload.Comment, requesterName, currentUserService.CurrentUserEmail);
            incidence.SetModifiedBy(requesterName);
            incidence.SetModifiedOnUtc(DateTime.Now);
            repo.SaveChanges();

            //Send Email notification
            #region Send email to the Information Security Team 
            
            string subject = "Security Incident - Recommendation Implemented";
            var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = incidence.InfoSecStaffEmailAddress; 
            string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
            string body = $"Hello {incidence.InfoSecStaffName}, <br><br>An update has been made to an assigned security incident.<br><br><strong>Date & Time</strong>:- {DateTime.Now}.<br><br><strong>Incident Topic</strong>:- {incidence.SecurityIncident}.<br><br><strong>Recommendation</strong>:- {incidence.InfoSecRecommendation}.<br><br><strong>Status Update</strong>:- {status[statusCategory]}.<br><br> Click <a href={linkToGRCTool}>GRC link</a> to review the updated status of the incident.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InformationSecurity, incidence.Id, emailTo, toCC);

            #endregion
            return TypedResults.Ok("Incidence updated successfully");
        }
    }
}
