using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 04/04/2025
      * Development Group: GRCTools
      * The endpoint log new incidence    
      */
    public class LogNewIncidenceEndpoint
    {
        /// <summary>
        /// The endpoint log new incidence 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repoControl"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            LogIncidenceRequest payload, IRepository<IncidentManagementLog> repoControl, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            
            foreach (var item in payload.SecurityArea) 
            {
              if(item.ToLower() != "availability" && item.ToLower() != "integrity" && item.ToLower() != "confidentiality")
                {
                    return TypedResults.BadRequest("Security area allowed are availability, integrity, confidentiality");
                }
            }

            var severityCategory = payload.Severity.ToLower();
            var severity = new Dictionary<string, SeverityCategory> { { "low", SeverityCategory.Low }, { "medium", SeverityCategory.Medium }, { "high", SeverityCategory.High } };
            if (!severity.ContainsKey(severityCategory))
                return TypedResults.BadRequest("Severity allowed are Low or Medium or High");
           
            var actionStatus = payload.Status.ToLower();
            var status = new Dictionary<string, ActionStatus> { { "open", ActionStatus.Open }, { "work in progress", ActionStatus.Work_In_Progress }, { "closed", ActionStatus.Closed } };
            if (!status.ContainsKey(actionStatus))
                return TypedResults.BadRequest("Status allowed are Open or Work In Progress or Closed");
            string savedImpact = string.Join(",", payload.Impact);
            string savesecurityArea = string.Join(",", payload.SecurityArea);
            var logIncident = IncidentManagementLog.Create(
                new LogIncidence(
                    SecurityIncident: payload.SecurityIncident,
                    SecurityArea: savesecurityArea,
                    Severity: severity[severityCategory],
                    DescriptionOfIncident: payload.DescriptionOfIncident,
                    TypeOfAsset: payload.TypeOfAsset,
                    AssetDescription: payload.AssetDescription,
                    DateOfIncidence: payload.DateOfIncidence,
                    DescriptionOfActionTaken: payload.DescriptionOfActionTaken,
                    RootCause: payload.RootCause,
                    Impact: savedImpact,
                    RecommendationToPreventFutureReoccurence: payload.RecommendationToPreventFutureReoccurence,
                    LessonLearnt: payload.LessonLearnt,
                    Status: status[actionStatus],
                    DateOfClosure: payload.DateOfClosure,
                    Comment: payload.Comment,
                    ReportingUnit: payload.ReportingUnit,
                    ReportingStaff: currentUserService.CurrentUserFullName,
                    ReportingStaffEmailAddress: currentUserService.CurrentUserEmail.ToLower()
                )
            );
            logIncident.SetCreatedBy(currentUserService.CurrentUserFullName);
            logIncident.SetModifiedBy(currentUserService.CurrentUserFullName);
            logIncident.SetModifiedOnUtc(DateTime.Now);
            repoControl.Add(logIncident);
            repoControl.SaveChanges();

            var response = new LogIncidenceResponse(IncidenceId: logIncident.Id);

            //Send Email notification
            #region Send email to the Information Security Team 
            
            string subject = "New Security Incident Report Logged";
            var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = config["EmailConfiguration:InformationSecurityGroupEmail"];
            string toCC = currentUserService.CurrentUserEmail; 
            string body = $"Hello InfoSec, <br><br> {currentUserService.CurrentUserFullName} has logged a new security incident in the GRC Tool.<br><br> <strong>Date & Time</strong>:- {DateTime.Now}.<br><br><strong>Incident Topic</strong>:- {payload.SecurityIncident}.<br><br><strong>Description</strong>:- {payload.DescriptionOfIncident}.<br><br> Click here to view full details of the incident: <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InformationSecurity, logIncident.Id, emailTo, toCC);

            #endregion
            return TypedResults.Created($"im/{response}", response);
        }
    }
}
