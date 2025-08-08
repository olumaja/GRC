using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 16/10/2024
     * Development Group: GRCTools
     * The endpoint create internal control investigation and the action owners
     */
    public class CreateInvestigationEndpoint
    {
        /// <summary>
        /// The endpoint create internal control investigation and the action owners
        /// </summary>
        /// <param name="createInvestigation"></param>
        /// <param name="internalControlRepo"></param>
        /// <param name="actionRepo"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            InternalControlDto createInvestigation, IRepository<InternalControlModel> internalControlRepo,
            IRepository<InternalControlAction> actionRepo, IRepository<Document> docRepo, 
            IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            try
            {
                var currentUser = currentUserService.CurrentUserFullName;
                var collaborators = createInvestigation.Collaborator.Select( x => x.Name ).ToList();
                var collaboratorEmails = createInvestigation.Collaborator.Select(x => x.Email.ToLower()).ToList();
                var control = InternalControlModel.Create(
                    new CreateInternalControl
                    (
                        Title: createInvestigation.Title,
                        IssueSummary: createInvestigation.IssueSummary,
                        Collaborators: string.Join(",", collaborators),
                        ContributorEmail: string.Join(",", collaboratorEmails),
                        NoOfCollaboration: collaborators.Count,
                        NoOfActionOwners: createInvestigation.Actions.Count
                    )
                );

                control.SetCreatedBy(currentUser);
                control.SetModifiedBy(currentUser);
                control.SetModifiedOnUtc(DateTime.Now);

                internalControlRepo.Add(control);

                var actions = createInvestigation.Actions.Select(x => InternalControlAction.Create(
                    control.Id, 
                    x.ActionToBeResolved,
                    x.Owners.Select(o => InternalControlActionOwner.Create(new CreateInternalControlAction(
                        ActionOwner: o.ActionOwnerName,
                        ActionOwnerEmail: o.ActionOwnerEmail.ToLower(),
                        Business: o.Business,
                        Deadline: o.Deadline
                    )
                    )).ToList()
                )).ToList();

                foreach ( var action in actions)
                {
                    action.SetCreatedBy(currentUser);
                    action.SetModifiedBy(currentUser);
                    action.SetModifiedOnUtc(DateTime.Now);
                }
                
                actionRepo.AddRange(actions);
                await actionRepo.SaveChangesAsync();

                var response = new InternalControlResponse(Id: control.Id);
                return TypedResults.Created($"ar/{response}", response);
            }
            catch(Exception ex)
            {
                return TypedResults.Problem("Unable to create investigation at the moment, please try again later");
            }
            
        }
    }
}
