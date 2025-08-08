using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 10/11/2024
        * Development Group: GRCTools
        * Get internal control by Id Endpoint.     
        */
    public class GetInternalControlByIdEndpoint
    {
        /// <summary>
        /// Get compliance statutory Payment by id Endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserService"></param>
        /// <param name="repository"></param>
        /// <param name="docRep"></param>
        /// <param name="actionOwner"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid id, IRepository<InternalControlModel> repository, IRepository<Document> docRep, ICurrentUserService currentUserService)
        {
            var getById = repository.GetContextByConditon(x => x.Id == id)
                                    .Include(x => x.Actions)
                                    .ThenInclude(a => a.InternalControlActionOwners)
                                    .FirstOrDefault();

            if (getById is null) return TypedResults.NotFound($"Internal Control was not found");
                      
            var attachments = docRep.GetContextByConditon(d => d.ModuleItemId == id && d.ModuleItemType == ModuleType.InternalControl)
                .Select(a => new GetAttachedReportResponse
                {
                    DocumentId = a.Id,
                    DocumentName = a.Name,
                    DateCreated = a.CreatedOnUtc,
                }).ToList();

            var collaboratorsName = getById.Collaborators.Split(",");
            var collaboratorsEmail = getById.CollaboratorEmail.Split(",");
            var collaborators = new List<Collaborator>();

            foreach (var email in collaboratorsEmail)
            {
                var extractName = email.Replace("@arm.com.ng", "").Replace(".", " ").ToLower();
                var name = Array.Find(collaboratorsName, n => n.ToLower() == extractName);
                collaborators.Add(new Collaborator ( Name: name, Email: email ));
            }

            var response = new GetInternalControlByIdResponse
            {
                InternalControlId = getById.Id,
                Title = getById.Title,
                IssueSummary = getById.IssueSummary,
                Collaborators = collaborators,
                Status = getById.Status.ToString(),
                ActionToResolve = getById.Actions.Select(p => new InternalControlActionInputted
                {
                    ActionToBeResolved = p.ActionToBeResolved,
                    ActionOwners = p.InternalControlActionOwners.Select(d => new GetInternalControlActionOwnerResp
                    {
                        ActionOwner = d.ActionOwner,
                        ActionOwnerEmail = d.ActionOwnerEmail,
                        Unit = d.Unit,
                        Deadline = d.Deadline,
                        ActionOwnerStatus = d.ActionOwnerStatus.ToString()
                    }).ToList()
                }).ToList(),
                Response = getById.Actions.Select(r => new ActionOwnerResponse
                {
                    ActionToResolve = r.ActionToBeResolved, 
                    Details = r.InternalControlActionOwners.Select(b => new ActionOwnerDetail
                    {
                        ActionOwerId = b.Id,
                        ActionOwner = b.ActionOwner,
                        ActionOwnerStatus = b.ActionOwnerStatus.ToString(),
                        Unit = b.Unit,
                        ResponseTime = b.ResponseTime,
                        ResponseSummary = b.Response,
                        ActionOwnerAttachments = docRep.GetContextByConditon(d => d.ModuleItemId == b.Id && d.ModuleItemType == ModuleType.InternalControlActionOwner)
                                                        .Select(a => new GetAttachedReportResponse
                                                        {
                                                            DocumentId = a.Id,
                                                            DocumentName = a.Name,
                                                            DateCreated = a.CreatedOnUtc,
                                                        }).ToList()
                    }).ToList()
                }).ToList(),
                Attachments = attachments,
            };

            return TypedResults.Ok(response);
        }
    }
}
