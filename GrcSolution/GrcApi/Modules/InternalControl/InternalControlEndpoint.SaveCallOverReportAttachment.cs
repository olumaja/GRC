using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.InternalControl;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
       * Original Author: Olusegun Adaramaja
       * Date Created: 9/12/2024
       * Development Group: GRCTools
       * Save call over report.     
       */
    public class SaveCallOverReportAttachmentEndpoint
    {
        /// <summary>
        /// Save call over report
        /// </summary>
        /// <param name="request"></param>
        /// <param name="reportRepo"></param>
        /// <param name="docRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            SaveCallOverAttachmentDto request, IRepository<InternalControlCallOverReport> reportRepo, IRepository<Document> docRepo,
            ICurrentUserService currentUserService, IConfiguration config
        )
        {
            List<Document> attachedFiles = new();
            var maxFileSize = Convert.ToInt32(config["MaximumFileSize"]);

            foreach (var attachment in request.Attachments)
            {
                var fileLength = attachment.Length;
                var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                if (fileLength > maxFileSize)
                    return TypedResults.BadRequest($"File size for {attachment.Name} is larger than 4MB");

                if (fileExtension != "pdf")
                    return TypedResults.BadRequest("The only file type allowed is pdf");

                attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.InternalControlCallOver, request.CallOverReportId));
            }

            var callOverReport = reportRepo.GetContextByConditon(r => r.Id == request.CallOverReportId)
                                            .Include(r => r.CallOver)
                                            .FirstOrDefault();

            if (callOverReport is null)
                return TypedResults.NotFound("Record not found");

            if (callOverReport.CallOver.Unit != currentUserService.CurrentUserUnitName)
                return TypedResults.Forbid();

            callOverReport.UpdateNumberOfAttachment(attachedFiles.Count);
            callOverReport.SetCreatedBy(currentUserService.CurrentUserFullName);
            callOverReport.SetModifiedBy(currentUserService.CurrentUserUnitName);
            callOverReport.SetModifiedOnUtc(DateTime.Now);

            //Remove previous attachments if exist, this endpoint also serve as update
            docRepo.BulkDelete(x => x.ModuleItemId == callOverReport.Id && x.ModuleItemType == ModuleType.InternalControlCallOver);

            //Add attachments
            await docRepo.AddRangeAsync(attachedFiles);
            await docRepo.SaveChangesAsync();

            return TypedResults.Ok("Attachments saved successfully");
        }
    }
}
