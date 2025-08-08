using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Domain;
using Azure;
using System.Linq;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 04/04/2025
      * Development Group: GRCTools
      * The endpoint log new PAM    
      */
    public class LogNewPAMEndpoint
    {
        /// <summary>
        /// The endpoint log new PAM 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repoControl"></param>
        /// <param name="pamLogType"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            NewPAMRequest payload, IRepository<LogManagement> repoControl, IRepository<PAMLog> pamLogType,
            IRepository<Document> docRepo, IEmailService EmailService, IConfiguration config, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(payload.Status) && payload.Status.ToLower() != LogMgtStatus.Closed.GetEnumDestription().ToLower() && payload.Status.ToLower() != LogMgtStatus.Work_In_Progress.GetEnumDestription().ToLower())
                    return TypedResults.BadRequest("Status allowed are Work In Progress or Closed");

                var status = string.IsNullOrWhiteSpace(payload.Status) ? LogMgtStatus.Open : payload.Status.ToLower() == LogMgtStatus.Work_In_Progress.GetEnumDestription().ToLower() ? LogMgtStatus.Work_In_Progress : LogMgtStatus.Closed;
                if (payload.Status.ToLower() == LogMgtStatus.Work_In_Progress.GetEnumDestription().ToLower() && string.IsNullOrWhiteSpace(payload.ActionOwner))
                {
                    return TypedResults.BadRequest("For the 'Work In Progress' status, an action owner must be selected");
                }

                var logMgtRequest = LogManagement.CreateLogMgt(LogType.PAM, payload.EventName, DateTime.Now, payload.ProposeEndDate, status, null,
                   currentUserService.CurrentUserEmail, payload.ActionOwner, payload.ActionOwnerEmailAddress, payload.ActionOwnerUnit);

                logMgtRequest.SetCreatedBy(currentUserService.CurrentUserFullName);
                logMgtRequest.SetModifiedBy(currentUserService.CurrentUserFullName);
                logMgtRequest.SetModifiedOnUtc(DateTime.Now);
                repoControl.Add(logMgtRequest);
                if (!string.IsNullOrWhiteSpace(payload.ActionOwner))
                {
                    //Attachement 
                    if (payload.Attachments.Count < 0)
                        return TypedResults.BadRequest("Once an action owner is selected, document must be attached");

                    var fileType = new List<string> { "pdf", "xlsx", "xls", "docx", "jpeg", "png" };
                    //Add attachments
                    List<Document> attachedFiles = new();

                    foreach (var attachment in payload.Attachments)
                    {
                        var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                        if (!fileType.Contains(fileExtension))
                            return TypedResults.BadRequest($"The file types allowed are {string.Join(",", fileType)}");

                        //Add attachments
                        attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.InformationSecurity, logMgtRequest.Id));

                    }

                    await docRepo.AddRangeAsync(attachedFiles);
                }
                var logPAMRequest = PAMLog.Create(
                   new NewPAMReq(
                       LogManagementModelId: logMgtRequest.Id,
                       EventName: payload.EventName,
                       EventDescription: payload.IncidentDescription,
                       CorrectiveActionCarriedOut: payload.CorrectiveActionCarriedOut,
                       DateCarriedOut: payload.DateCarriedOut
                   )
               );

                logPAMRequest.SetCreatedBy(currentUserService.CurrentUserFullName);
                logPAMRequest.SetModifiedBy(currentUserService.CurrentUserFullName);
                logPAMRequest.SetModifiedOnUtc(DateTime.Now);
                pamLogType.Add(logPAMRequest);
                pamLogType.SaveChanges();

                //Send Email notification
                #region Send email notification 
                var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string subject = $"PAM New Log Assigned - Action Required";
                string emailTo = config["EmailConfiguration:CISOEmailAddress"];
                string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                string body = $"Dear {config["EmailConfiguration:CISOName"]}, <br><br>This is to notify you that a new event has been logged into the GRC Tool as of {DateTime.Now}.<br><br>Details of the Log:<br><br> <strong>Event Name</strong>:- {payload.EventName}.<br><br><strong>Submitted By</strong>:- {currentUserService.CurrentUserFullName}.<br><br><strong>Description</strong>:- {payload.IncidentDescription}.<br><br>Click here <a href={linkToGRCTool}>GRC link</a> to view full log report.<br><br>Best regards.";

                if (payload.ActionOwner != null)
                {
                    emailTo = $"{payload.ActionOwnerEmailAddress}";
                    toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                    body = $"Dear {payload.ActionOwner}, <br><br>A new security log has been assigned to you in the GRC Tool. Please review and work on the recommendation stated. Please see below the summary of the log:<br> <strong>Event Name</strong>:- {payload.EventName}.<br><br><strong>Source</strong>:- PAM.<br><br><strong>Description</strong>:- {payload.IncidentDescription}.<br><br><strong>Due Date</strong>:- {payload.ProposeEndDate}.<br><br> Please log into the GRC tool, review the details, and share remark of the status of this log as you progress.<br><br>Please click here <a href={linkToGRCTool}>GRC link</a> to access the tool.<br><br>If you believe this was assigned to you in error or need further clarification, please reach out to the Information Security Team.<br><br>Best regards.";
                }

                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InformationSecurity, logMgtRequest.Id, emailTo, toCC);

                #endregion
                var response = new LogMgtResponse(logMgtId: logMgtRequest.Id);
                return TypedResults.Created($"lm/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("An error occurred while processing your request");
            }
        }
    }
}
