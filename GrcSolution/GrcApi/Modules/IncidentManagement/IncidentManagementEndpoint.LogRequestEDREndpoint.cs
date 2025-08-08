using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class LogRequestEDREndpoint
    {
        public static async Task<IResult> HandleAsync(LogERDDto payload, IRepository<EDRLog> ERDRepo, IRepository<LogManagement> logMgtRepo,
                ICurrentUserService currentUserService, IConfiguration config, IEmailService EmailService, IRepository<Document> docRepo
        )
        {
            if (!string.IsNullOrWhiteSpace(payload.Status) && payload.Status.ToLower() != LogMgtStatus.Closed.GetEnumDestription().ToLower() && payload.Status.ToLower() != LogMgtStatus.Work_In_Progress.GetEnumDestription().ToLower())
                return TypedResults.BadRequest("Status allowed are Work In Progress and Closed");

            var status = string.IsNullOrWhiteSpace(payload.Status) ? LogMgtStatus.Open : payload.Status.ToLower() == LogMgtStatus.Work_In_Progress.GetEnumDestription().ToLower() ? LogMgtStatus.Work_In_Progress : LogMgtStatus.Closed;
            if (payload.Status.ToLower() == LogMgtStatus.Work_In_Progress.GetEnumDestription().ToLower() && string.IsNullOrWhiteSpace(payload.ActionOwner))
            {
                return TypedResults.BadRequest("For the 'Work In Progress' status, an action owner must be selected");
            }
            var logMgt = LogManagement.CreateLogMgt(
                LogType.EDR, payload.EventName, dateAlertWasGenerated: payload.DateAlertGenerated, proposeEndDate: payload.ProposeEndDate,
                status, remark: payload.Recommendation, requesterEmail: currentUserService.CurrentUserEmail, actionOwner: payload.ActionOwner, actionOwnerEmailAddress: payload.ActionOwnerEmail,
                actionOwnerUnit: payload.ActionOwnerUnit
            );

            logMgt.SetCreatedBy(currentUserService.CurrentUserFullName);
            logMgt.SetModifiedBy(currentUserService.CurrentUserFullName);
            logMgt.SetModifiedOnUtc(DateTime.Now);
            logMgtRepo.Add(logMgt);
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
                    attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.InformationSecurity, logMgt.Id));

                }

                await docRepo.AddRangeAsync(attachedFiles);
            }
            var edrlog = EDRLog.Create(
                new LogEDRRequest
                (
                    LogManagementId: logMgt.Id,
                    EventName: payload.EventName,
                    EventDescription: payload.EventDescription,
                    EventID: payload.EventID,    
                    ConfigurationDetails: null,
                    SourceIPAddress: payload.SourceIPAddress,
                    Severity: payload.Severity,
                    DestinationFQDN: payload.DestinationFQDN,
                    SourceOrFileName: payload.SourceOrFileName,
                    DestinationIPAddress: payload.DestinationIPAddress,
                    DestinationHostName: payload.DestinationHostName,
                    DestinationUserName: payload.DestinationUserName,
                    SecurityTools: payload.SecurityTools,
                    Observation: payload.Observation,
                    ActionTakenByCS: payload.ActionTakenByCS,
                    Technique: payload.Technique,
                    FileHash: payload.FileHash
            ));

            edrlog.SetCreatedBy(currentUserService.CurrentUserFullName);
            edrlog.SetModifiedBy(currentUserService.CurrentUserFullName);
            edrlog.SetModifiedOnUtc(DateTime.Now);
            ERDRepo.Add(edrlog);
            ERDRepo.SaveChanges();

            //Send Email notification
            #region Send email notification 
            var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string subject = $"EDR Log Assigned - Action Required";
            string emailTo = config["EmailConfiguration:CISOEmailAddress"];
            string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
            string body = $"Dear {config["EmailConfiguration:CISOName"]}, <br><br>This is to notify you that a new event has been logged into the GRC Tool as of {DateTime.Now}.<br><br>Details of the Log:<br><br> <strong>Event Name</strong>:- {payload.EventName}.<br><br><strong>Submitted By</strong>:- {currentUserService.CurrentUserFullName}.<br><br><strong>Description</strong>:- {payload.EventDescription}.<br><br>Click here <a href={linkToGRCTool}>GRC link</a> to view full log report.<br><br>Best regards.";

            if (payload.ActionOwner != null)
            {
                emailTo = $"{payload.ActionOwnerEmail}";
                toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                body = $"Dear {payload.ActionOwner}, <br><br>A new security log has been assigned to you in the GRC Tool. Please review and work on the recommendation stated. Please see below the summary of the log:<br> <strong>Event Name</strong>:- {payload.EventName}.<br><br><strong>Source</strong>:- EDR.<br><br><strong>Description</strong>:- {payload.EventDescription}.<br><br><strong>Due Date</strong>:- {payload.ProposeEndDate}.<br><br> Please log into the GRC tool, review the details, and share remark of the status of this log as you progress.<br><br>Please click here <a href={linkToGRCTool}>GRC link</a> to access the tool.<br><br>If you believe this was assigned to you in error or need further clarification, please reach out to the Information Security Team.<br><br>Best regards.";
            }

            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InformationSecurity, logMgt.Id, emailTo, toCC);

            #endregion

            var response = new LogMgtResponse(logMgtId: logMgt.Id);
            return TypedResults.Created($"lm/{response}", response);
        }
    }
}
