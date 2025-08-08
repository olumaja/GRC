using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
        * Original Author: Olusegun Adaramaja
        * Date Created: 23/11/2024
        * Development Group: GRCTools
        * Get internal control by Id Endpoint.
        */
    public class GetActionOwnerInternalControlByIdEndpoint
    {
        /// <summary>
        /// Get detail of the internal control
        /// </summary>
        /// <param name="actionOwnerId"></param>
        /// <param name="repository"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid actionOwnerId, IRepository<InternalControlActionOwner> repository, 
            IRepository<Document> docRepo, ICurrentUserService currentUserService
        )
        {
            var action = repository.GetContextByConditon(r => r.Id == actionOwnerId)
                                   .Include(r => r.InternalControlAction)
                                   .ThenInclude(r => r.InternalControl)
                                   .FirstOrDefault();

            if (action is null)
                return TypedResults.NotFound("Record not found");

            var attachments = await docRepo.GetContextByConditon(d => d.ModuleItemId == action.InternalControlAction.InternalControlId && d.ModuleItemType == ModuleType.InternalControl)
                                    .Select(d => new GetAttachedReportResponse
                                    {
                                        DocumentId = d.Id,
                                        DateCreated = d.CreatedOnUtc,
                                        DocumentName = d.Name
                                    }).ToListAsync();

            var actionAttachments = await docRepo.GetContextByConditon(d => d.ModuleItemId == action.Id && d.ModuleItemType == ModuleType.InternalControlActionOwner)
                                    .Select(d => new GetAttachedReportResponse
                                    {
                                        DocumentId = d.Id,
                                        DateCreated = d.CreatedOnUtc,
                                        DocumentName = d.Name
                                    }).ToListAsync();

            return TypedResults.Ok(new GetActionOwnerInternalControlByIdResponse(
                ActionOwnerId: action.Id,
                Title: action.InternalControlAction.InternalControl.Title,
                IssueSummary: action.InternalControlAction.InternalControl.IssueSummary,
                ActionToBeResolved: action.InternalControlAction.ActionToBeResolved,
                ReasonForRejection: action.ReasonForRejection,
                Response: action.Response,
                Deadline: action.Deadline,
                Status: action.InternalControlAction.InternalControl.Status.ToString(),
                ActionOwnerStatus: action.ActionOwnerStatus.ToString(),
                ReasonForReject: action.ReasonForRejection,
                Attactments: attachments,
                ActionOwnerAttachments: actionAttachments
            ));
        }
    }
}