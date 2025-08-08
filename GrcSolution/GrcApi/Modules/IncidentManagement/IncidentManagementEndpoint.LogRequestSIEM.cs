using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class LogRequestSIEMEndpoint
    {
        public static async Task<IResult> HandleAsync(LogManagementDto payload, IRepository<SIEMLog> SIEMRepo, IRepository<LogManagement> logMgtRepo, 
            ICurrentUserService currentUserService, IConfiguration config, IEmailService EmailService, IRepository<Document> docRepo
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
                var logMgtRequest = LogManagement.CreateLogMgt(LogType.SIEM, payload.EventName, payload.DateAlertGenerated, payload.ProposeEndDate, status, payload.Recommendation,
                    currentUserService.CurrentUserEmail, payload.ActionOwner, payload.ActionOwnerEmail, payload.ActionOwnerUnit
                );

                logMgtRequest.SetCreatedBy(currentUserService.CurrentUserFullName);
                logMgtRequest.SetModifiedBy(currentUserService.CurrentUserFullName);
                logMgtRequest.SetModifiedOnUtc(DateTime.Now);
                logMgtRepo.Add(logMgtRequest);

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

                var siemlog = SIEMLog.Create(
                    new SIEMLogRequest(
                        LogMgtId: logMgtRequest.Id,
                        EventName: payload.EventName,
                        EventDescription: payload.EventDescription,
                        ConfigurationObject: payload.ConfigurationObject,
                        ConfigurationDetail: payload.ConfigurationDetails,
                        SourceIPAddress: payload.SourceIPAddress,
                        SourcePort: payload.SourcePort,
                        SourceFQDN: payload.SourceFQDN,
                        SourceHostName: payload.SourceHostName,
                        SourceUserName: payload.SourceUserName,
                        DestinationIpAddress: payload.DestinationIPAddress,
                        DestinationPort: payload.DestinationPort,
                        DestinationHostName: payload.DestinationHostName,
                        DestinationFQDN: payload.DestinationFQDN,
                        DestinationUserName: payload.DestinationUserName,
                        NATIPAddress: payload.NATIPAddress,
                        NATPort: payload.NATPort,
                        MaliciousReputation: payload.MaliciousRepution,
                        EventId: payload.EventID,
                        Observation: payload.Observation,
                        SecurityTool: payload.SecurityTools
                    ));

                siemlog.SetCreatedBy(currentUserService.CurrentUserFullName);
                siemlog.SetModifiedBy(currentUserService.CurrentUserFullName);
                siemlog.SetModifiedOnUtc(DateTime.Now);
                SIEMRepo.Add(siemlog);
                SIEMRepo.SaveChanges();

                //Send Email notification
                #region Send email notification 
                var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string subject = $"SIEM New Log Assigned - Action Required";
                string emailTo = config["EmailConfiguration:CISOEmailAddress"];
                string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                string body = $"Dear {config["EmailConfiguration:CISOName"]}, <br><br>This is to notify you that a new event has been logged into the GRC Tool as of {DateTime.Now}.<br><br>Details of the Log:<br><br> <strong>Event Name</strong>:- {payload.EventName}.<br><br><strong>Submitted By</strong>:- {currentUserService.CurrentUserFullName}.<br><br><strong>Description</strong>:- {payload.EventDescription}.<br><br>Click here <a href={linkToGRCTool}>GRC link</a> to view full log report.<br><br>Best regards.";

                if (!string.IsNullOrWhiteSpace(payload.ActionOwner))
                {
                    emailTo = $"{payload.ActionOwnerEmail}";
                    toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                    body = $"Dear {payload.ActionOwner}, <br><br>A new security log has been assigned to you in the GRC Tool. Please review and work on the recommendation stated. Please see below the summary of the log:<br> <strong>Event Name</strong>:- {payload.EventName}.<br><br><strong>Source</strong>:- SIEM.<br><br><strong>Description</strong>:- {payload.EventDescription}.<br><br><strong>Due Date</strong>:- {payload.ProposeEndDate}.<br><br> Please log into the GRC tool, review the details, and share remark of the status of this log as you progress.<br><br>Please click here <a href={linkToGRCTool}>GRC link</a> to access the tool.<br><br>If you believe this was assigned to you in error or need further clarification, please reach out to the Information Security Team.<br><br>Best regards.";
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
