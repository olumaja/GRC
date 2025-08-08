using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
         * Original Author: Sodiq Quadre
         * Date Created: 23/11/2024
         * Development Group: GRCTools
         * This endpoint update internal control exception tracker status
         */
    public class GetClosedInternalControlByIdEndpoint
    {
        /// <summary>
        /// The endpoint display detail of closed record
        /// </summary>
        /// <param name="internalControlId"></param>
        /// <param name="repository"></param>
        /// <param name="docRep"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid internalControlId, IRepository<InternalControlModel> repository, IRepository<Document> docRep, ICurrentUserService currentUserService
        )
        {
            var control = repository.GetContextByConditon(x => x.Id == internalControlId)
                                    .Include(x => x.Actions)
                                    .ThenInclude(a => a.InternalControlActionOwners)
                                    .FirstOrDefault();

            if (control is null) return TypedResults.NotFound("Report not found");

            var attachments = docRep.GetContextByConditon(d => d.ModuleItemId == internalControlId && d.ModuleItemType == ModuleType.InternalControl)
                                    .Select(a => new GetAttachedReportResponse
                                    {
                                        DocumentId = a.Id,
                                        DocumentName = a.Name,
                                        DateCreated = a.CreatedOnUtc,
                                    }).ToList();

            var response = new GetClosedInternalControlByIdResponse
            {
                InternalControlId = control.Id,
                Title = control.Title,
                IssueSummary = control.IssueSummary,
                Actions = control.Actions.Select(a => new GetClosedInternalControlAction
                {
                    ActionToBeResolved = a.ActionToBeResolved,
                    InitiatingOfficer = control.CreatedBy,
                    DateCreated = a.CreatedOnUtc,
                    DateModified = a.ModifiedOnUtc,
                    Deadline = a.InternalControlActionOwners.Select(d => d.Deadline).FirstOrDefault(),
                    ActionOwners = a.InternalControlActionOwners.Select(o => new ActionOwnerReportResponse
                    {
                        ActionOwner = o.ActionOwner,
                        Unit = o.Unit,
                        ResponseSummary = o.Response,
                        DocumentCount = 2,
                        DateReplied = o.ResponseTime
                    }).ToList()
                }).ToList(),
                DocumentTrail = new DocumentTrail { 
                    OfficerName = control.CreatedBy,
                    Unit = "Internal Control",
                    Attachments = attachments,
                    ActionOwnerDocumentTrails = control.Actions.SelectMany(t => t.InternalControlActionOwners.Select(e => new ActionOwnerDocumentTrail
                    {
                        Name = e.ActionOwner,
                        Unit = e.Unit,
                        Attachments = docRep.GetContextByConditon(d => d.ModuleItemId == internalControlId && d.ModuleItemType == ModuleType.InternalControl)
                                    .Select(a => new GetAttachedReportResponse
                                    {
                                        DocumentId = a.Id,
                                        DocumentName = a.Name,
                                        DateCreated = a.CreatedOnUtc,
                                    }).ToList()
                    }).ToList()
                    ).ToList()
                }
            };

            return TypedResults.Ok(response);
        }
    }
}
