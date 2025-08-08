using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
  * Original Author: Olusegun Adaramaja
  * Date Created: 03/09/2024
  * Development Group: GRCTools
  * This endpoint enable internal control officer to attach documemts 
  */
    public class CreateInvestigationAttachmentEndpoint
    {
        /// <summary>
        /// This endpoint enable internal control officer to attach documemts
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="internalControlRepo"></param>
        /// <param name="actionRepo"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            InternalControlAttachmentDto payload, IRepository<InternalControlModel> internalControlRepo,
            IRepository<Document> docRepo, IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            try
            {
                string requesterName = currentUserService.CurrentUserFullName;

                var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "csv", "docx" };

                foreach (var attachment in payload.Attachments)
                {
                    var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                    if (!fileTypeAllow.Contains(fileExtension))
                        return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");
                }

                var control = internalControlRepo.GetContextByConditon(c => c.Id == payload.InternalControlId)
                                                  .Include(c => c.Actions)
                                                  .ThenInclude(a => a.InternalControlActionOwners)
                                                  .FirstOrDefault();

                if (control is null)
                    return TypedResults.NotFound("Internal control does not exist");

                control.UpdateAttachmentCount(payload.Attachments.Count);

                //Remove previous attachments if exist, this endpoint also serve as update
                docRepo.BulkDelete(x => x.ModuleItemId == control.Id && x.ModuleItemType == ModuleType.InternalControl);

                //Add attachments
                List<Document> attachedFiles = new();

                foreach (var attachment in payload.Attachments)
                {
                    attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.InternalControl, control.Id));
                }

                await docRepo.AddRangeAsync(attachedFiles);
                await docRepo.SaveChangesAsync();

                // Send email to action owner, line mgr and internal control
                #region Log email request
                var actionOwners = control.Actions.SelectMany(a =>
                    a.InternalControlActionOwners
                ).ToList();

                var actionOwnerEmail = string.Join(",", actionOwners.Select(a => a.ActionOwnerEmail));
                var recipientEmails = $"{actionOwnerEmail}";
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"Internal Control Officer Submitted Request - {dateOfOccurrence})";
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = recipientEmails;
                string toCC = $"{actionOwnerEmail},{control.CollaboratorEmail}," + config["EmailConfiguration:InternalControlEmailTo"]; 
                string body = $"Hello All, <br><br> {requesterName} has submitted an internal control request.<br><br> Click here for more detail:<a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, control.Id, emailTo, toCC);
                
                #endregion
                return TypedResults.Ok("Attachment successful");
            }
            catch(Exception ex )
            {
                return TypedResults.Problem("Unable to submit the attachments at the moment, please try again later");
            }
        }
    }
}
