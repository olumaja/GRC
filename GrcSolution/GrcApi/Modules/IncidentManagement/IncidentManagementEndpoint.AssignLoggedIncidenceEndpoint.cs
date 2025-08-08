using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcApi.Modules.Shared.EmailNotification;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 04/04/2025
      * Development Group: GRCTools
      * The endpoint for the Infosec to assign incidence to an action owner
      */
    public class AssignLoggedIncidenceEndpoint
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
           InfosecAssignLogIncidenceReq payload, IRepository<IncidentManagementLog> repo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            string requesterName = currentUserService.CurrentUserFullName;            
            var incidence = repo.GetContextByConditon(r => r.Id == payload.IncidenceId && r.Status != ActionStatus.Closed).FirstOrDefault();
            if (incidence is null) return TypedResults.NotFound("Record was not found");
            string actionOwner = incidence.ReportingStaff;
            string actionOwnerEmail = incidence.ReportingStaffEmailAddress;
            if (payload.ActionOwnerName != null && payload.ActionOwnerEmailAddress != null)
            {
                actionOwner = payload.ActionOwnerName;
                actionOwnerEmail = payload.ActionOwnerEmailAddress;
            }
            var incidentTagCategory = payload.IncidentTag.ToLower();
            var incidentTag = new Dictionary<string, IncidentTagCategory> { { "false positive", IncidentTagCategory.False_Positive }, { "true positive", IncidentTagCategory.True_Positive } };
            if (!incidentTag.ContainsKey(incidentTagCategory))
                return TypedResults.BadRequest("Incident Tag allowed are False Positive or True Positive");

            var statusCategory = payload.Status.ToLower();
            var status = new Dictionary<string, ActionStatus> { { "work in progress", ActionStatus.Work_In_Progress }, { "closed", ActionStatus.Closed } };
            if (!status.ContainsKey(statusCategory))
                return TypedResults.BadRequest("Status allowed are Open or Work In Progress or Closed");

            incidence.AssignIncidenceToActionOwner(incidentTag[incidentTagCategory], status[statusCategory], payload.Recommendation, actionOwner, actionOwnerEmail, requesterName, currentUserService.CurrentUserEmail, payload.ActionOwnerUnit);
            incidence.SetModifiedBy(requesterName);
            incidence.SetModifiedOnUtc(DateTime.Now);
            repo.SaveChanges();

            //Send Email notification
            #region Send email to the Information Security Team 
           
            string subject = "Security Incident - Action Required";
            var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = actionOwnerEmail;
            string toCC = $"{incidence.ReportingStaffEmailAddress}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
            string body = $"Hello {actionOwner}, <br><br>You have been assigned as the action owner for a security incident requiring your attention.<br><br><strong>Date & Time</strong>:- {DateTime.Now}.<br><br><strong>Incident Topic</strong>:- {incidence.SecurityIncident}.<br><br><strong>Description</strong>:- {incidence.DescriptionOfIncident}.<br><br> <strong>Recommended Action</strong>:- {payload.Recommendation}.<br><br>Please review and take the necessary action as soon as possible.<br><br> Click <a href={linkToGRCTool}>GRC link</a> to access the full incident details.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InformationSecurity, incidence.Id, emailTo, toCC);

            #endregion
            return TypedResults.Ok("Incidence assigned successfully");
        }
    }
}
