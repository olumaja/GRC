using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System;

namespace GrcApi.Modules.InternalControl
{
    /*
  * Original Author: Olusegun Adaramaja
  * Date Created: 03/09/2024
  * Development Group: GRCTools
  * This endpoint enable internal control officer to update 
  */
    public class UpdateCreatedInvestigationEndpoint
    {
        /// <summary>
        /// The endpoint update created internal control investigation and the action owners
        /// </summary>
        /// <param name="createInvestigation"></param>
        /// <param name="internalControlRepo"></param>
        /// <param name="actionRepo"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            UpdateInternalControlDto updateInvestigation, IRepository<InternalControlModel> internalControlRepo,
            IRepository<InternalControlActionOwner> actionOwnerRepo, IRepository<InternalControlAction> actionRepo, IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            try
            {
                var control = await internalControlRepo.GetByIdAsync(updateInvestigation.Id);

                if (control is null)
                    return TypedResults.NotFound("Record not found");

                if (control.Status == InternalControlStatus.Closed)
                    return TypedResults.BadRequest("You cannot edit a closed investigation");

                var collaborators = updateInvestigation.Collaborator.Select(x => x.Name).ToList();
                var collaboratorEmails = updateInvestigation.Collaborator.Select(x => x.Email.ToLower()).ToList();
                control.UpdateInternalConrol(
                    new CreateInternalControl
                    (
                        Title: updateInvestigation.Title,
                        IssueSummary: updateInvestigation.IssueSummary,
                        Collaborators: string.Join(",", collaborators),
                        ContributorEmail: string.Join(",", collaboratorEmails),
                        NoOfCollaboration: collaborators.Count,
                        NoOfActionOwners: updateInvestigation.Actions.Count
                    )
                );

                var currentUser = currentUserService.CurrentUserFullName;
                control.SetModifiedBy(currentUser);
                control.SetModifiedOnUtc(DateTime.Now);

                internalControlRepo.Update(control);

                //Remove all previous actions and action owners associated with the current internal control
                actionRepo.BulkDelete(x => x.InternalControlId == control.Id);

                //Add new actions and action owners
                var actions = updateInvestigation.Actions.Select(x => InternalControlAction.Create(
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

                foreach (var action in actions)
                {
                    action.SetCreatedBy(currentUser);
                    action.SetModifiedBy(currentUser);
                    action.SetModifiedOnUtc(DateTime.Now);
                }

                actionRepo.AddRange(actions);
                await actionRepo.SaveChangesAsync();
                // Send email to action owner, stakeholder
                #region Log email request
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"Internal Control Officer Update the Requested - {dateOfOccurrence})";
                var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolUpdateInvestigation"], control.Id);
                string emailTo = control.CollaboratorEmail; 
                string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
                string body = $"Hello All, <br><br> {currentUserService.CurrentUserFullName} has updated internal control initiated by {control.CreatedBy}.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, control.Id, emailTo, toCC);

                #endregion

                return TypedResults.Ok("Update successful");
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
