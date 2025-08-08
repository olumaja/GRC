using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.OperationControl
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 10/11/2024
      * Development Group: GRCTools
      * Operation exception Officer Approval.     
      */
    public class ApproveOperationExceptionEndpoint
    {
        /// <summary>
        /// Approve operation Exception
        /// </summary>
        /// <param name="approve"></param>
        /// <param name="repo"></param>
        /// <param name="config"></param>
        /// <param name="EmailService"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ApproveExceptionRequest approve, IRepository<OperationControl> repo,
             IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (!currentUserService.CurrentUserRoles.Contains("OperationControlOfficer") && !currentUserService.CurrentUserRoles.Contains("OperationControlSupervisor"))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = currentUserService.CurrentUserFullName;
              
                if (approve.ApprovalProcess != "Observation" && approve.ApprovalProcess != "Exception")
                { return TypedResults.BadRequest("Approval Process can only 'Observation' or as an 'Exception'"); }

                var getException = repo.GetContextByConditon(c => c.Id == approve.OperationExceptionId).FirstOrDefault();
                if (string.IsNullOrEmpty(getException.ReAssignedOfficer) && getException.RequestedEmailAddress.ToLower() == currentUserService.CurrentUserEmail.ToLower())
                {
                    if (approve.ApprovalProcess == "Observation")
                    {
                        var getById = repo.GetContextByConditon(c => c.Id == approve.OperationExceptionId && c.ActionOwnerComment != null && c.Status != ExceptionStatus.Approved).FirstOrDefault();

                        if (getById is null)
                            return TypedResults.NotFound("Approval as an Observation was not completed");

                        getById.ApproveAsObservation(requesterName, approve.ApprovalProcess);
                        getById.SetModifiedBy(requesterName);
                        getById.SetModifiedOnUtc(DateTime.Now);
                        repo.SaveChanges();

                        return TypedResults.Ok("Approved successfully");
                    }
                    if (approve.ApprovalProcess == "Exception")
                    {
                        var getById = repo.GetContextByConditon(c => c.Id == approve.OperationExceptionId && c.ActionOwnerComment != null && c.Status != ExceptionStatus.Approved).FirstOrDefault();

                        if (getById is null)
                            return TypedResults.NotFound("Approval as an Exception was not completed");

                        getById.ApproveAsException(requesterName, approve.ApprovalProcess);
                        getById.SetModifiedBy(requesterName);
                        getById.SetModifiedOnUtc(DateTime.Now);
                        repo.SaveChanges();

                        return TypedResults.Ok("Approved successfully");
                    }

                }
                if (!string.IsNullOrEmpty(getException.ReAssignedOfficer) && getException.ReassignOfficerEmailAddress.ToLower() == currentUserService.CurrentUserEmail.ToLower())
                {
                    if (approve.ApprovalProcess == "Observation")
                    {
                        var getById = repo.GetContextByConditon(c => c.Id == approve.OperationExceptionId && c.ActionOwnerComment != null && c.Status != ExceptionStatus.Approved).FirstOrDefault();

                        if (getById is null)
                            return TypedResults.NotFound("Reassigned officer approval as an observation was not completed");

                        getById.ApproveAsObservation(requesterName, approve.ApprovalProcess);
                        getById.SetModifiedBy(requesterName);
                        getById.SetModifiedOnUtc(DateTime.Now);
                        repo.SaveChanges();

                        return TypedResults.Ok("Approved successfully");
                    }
                    if (approve.ApprovalProcess == "Exception")
                    {
                        var getById = repo.GetContextByConditon(c => c.Id == approve.OperationExceptionId && c.ActionOwnerComment != null && c.Status != ExceptionStatus.Approved).FirstOrDefault();

                        if (getById is null)
                            return TypedResults.NotFound("Reassigned officer approval as an exception was not completed");

                        getById.ApproveAsException(requesterName, approve.ApprovalProcess);
                        getById.SetModifiedBy(requesterName);
                        getById.SetModifiedOnUtc(DateTime.Now);
                        repo.SaveChanges();

                        return TypedResults.Ok("Approved successfully");
                    }

                }
                if (currentUserService.CurrentUserRoles.Contains("OperationControlSupervisor"))
                {
                    if (approve.ApprovalProcess == "Observation")
                    {
                        var getById = repo.GetContextByConditon(c => c.Id == approve.OperationExceptionId && c.ActionOwnerComment != null && c.Status != ExceptionStatus.Approved).FirstOrDefault();

                        if (getById is null)
                            return TypedResults.NotFound("Supervisor approval as an observation was not completed");

                        getById.ApproveAsObservation(requesterName, approve.ApprovalProcess);
                        getById.SetModifiedBy(requesterName);
                        getById.SetModifiedOnUtc(DateTime.Now);
                        repo.SaveChanges();

                        return TypedResults.Ok("Approved successfully");
                    }
                    if (approve.ApprovalProcess == "Exception")
                    {
                        var getById = repo.GetContextByConditon(c => c.Id == approve.OperationExceptionId && c.ActionOwnerComment != null && c.Status != ExceptionStatus.Approved).FirstOrDefault();

                        if (getById is null)
                            return TypedResults.NotFound("Supervisor approval as an exception was not completed");

                        getById.ApproveAsException(requesterName, approve.ApprovalProcess);
                        getById.SetModifiedBy(requesterName);
                        getById.SetModifiedOnUtc(DateTime.Now);
                        repo.SaveChanges();

                        return TypedResults.Ok("Approved successfully");
                    }

                }

                 return TypedResults.BadRequest("You can only be an initiator or the reassigned officer before you can approve");

            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record was not found");
            }
        }
    }

    public record ApproveExceptionRequest(Guid OperationExceptionId, string? ApprovalProcess);

    public class ApproveExceptionRequestValidation : AbstractValidator<ApproveExceptionRequest>
    {
        public ApproveExceptionRequestValidation()
        {
            RuleFor(x => x.OperationExceptionId).NotEmpty();           
            RuleFor(x => x.ApprovalProcess).NotEmpty();           
        }
    }
}
