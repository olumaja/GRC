using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
    * Original Author: Olusegun Adaramaja
    * Date Created: 22/10/2024
    * Development Group: GRCTools
    * This endpoint enable action owner response to investigation 
    */
    public class ActionOwnerResponseEndpoint
    {
        /// <summary>
        /// This endpoint enable action owner response to investigation
        /// </summary>
        /// <param name="ownerResponse"></param>
        /// <param name="actionRepo"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            InternalControlActionOwnerResponse ownerResponse, ICurrentUserService currentUserService,
            IRepository<InternalControlActionOwner> actionRepo, IRepository<Document> docRepo)
        {
           var actionOwner = actionRepo.GetContextByConditon(a => a.Id == ownerResponse.ActionOwnerId && a.ActionOwnerEmail.ToLower() == currentUserService.CurrentUserEmail.ToLower())
                                        .Include(a => a.InternalControlAction)
                                        .FirstOrDefault();

            if (actionOwner is null)
                return TypedResults.NotFound("Action owner doesnot exist");

            var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "csv", "docx" };

            foreach (var attachment in ownerResponse.Attachments)
            {
                var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                if (!fileTypeAllow.Contains(fileExtension))
                    return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");
            }

            actionOwner.ActionOwnerResponse(ownerResponse.Response);
            actionOwner.SetModifiedBy(currentUserService.CurrentUserFullName);
            actionOwner.SetModifiedOnUtc(DateTime.Now);
            actionRepo.Update(actionOwner);

            //Remove previous attachments if exist, this endpoint also serve as update
            docRepo.BulkDelete(x => x.ModuleItemId == actionOwner.Id && x.ModuleItemType == ModuleType.InternalControlActionOwner);

            //Add attachments
            List<Document> attachedFiles = new();
            foreach (var attachment in ownerResponse.Attachments)
            {
                attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.InternalControlActionOwner, actionOwner.Id));
            }

            await docRepo.AddRangeAsync(attachedFiles);
            await docRepo.SaveChangesAsync();

            return TypedResults.Ok("Response saved successfully");
        }
    }
}
