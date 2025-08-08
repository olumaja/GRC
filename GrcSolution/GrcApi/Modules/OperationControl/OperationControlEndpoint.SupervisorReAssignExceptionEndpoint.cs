using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.OperationControl
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 10/11/2024
      * Development Group: GRCTools
      * Supervisor Re-assign Exception.     
      */
    public class SupervisorReAssignExceptionEndpoint
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
            ReAssignExceptionReq req, IRepository<OperationControl> repo,
             IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            try
            {
                string requesterName = currentUserService.CurrentUserFullName;
                var getById = repo.GetContextByConditon(c => c.Id == req.OperationExceptionId && c.Status != ExceptionStatus.Approved).FirstOrDefault();

                if (getById is null)
                    return TypedResults.NotFound("Record was not found");

                getById.ExceptionReAssignedOfficer(req.OfficerName, requesterName, req.OfficeremailAddress);
                getById.SetModifiedBy(requesterName);
                getById.SetModifiedOnUtc(DateTime.Now);
                repo.SaveChanges();
                //Send Email notification
                #region Send email to the InternalAudit-HQ 

                string subject = $"Operation Control Exception Action Owner Response";
                string emailTo = req.OfficeremailAddress; 
                string toCC = config["EmailConfiguration:OperationControlReAssignExceptionEmailToCC"];
                var linkToGRCTool = string.Format(config["EmailConfiguration:LogExceptionLink"], getById.Id);
                string body = $"Dear {req.OfficerName}, <br><br> {currentUserService.CurrentUserFullName} has reassigned an exception to you. <br><br>Please access the request with the following link <a href={linkToGRCTool}>GRC link</a><br><br> Thank you.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.OperationControl, getById.Id, emailTo, toCC);

                #endregion

                return TypedResults.Ok("Exception Re-assigned successfully");
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest("Exception Re-assigned failed");
            }
        }
    }

    public record ReAssignExceptionReq(Guid OperationExceptionId, string? OfficerName, string? OfficeremailAddress);

    public class ReAssignExceptionReqValidation : AbstractValidator<ReAssignExceptionReq>
    {
        public ReAssignExceptionReqValidation()
        {
            RuleFor(x => x.OperationExceptionId).NotEmpty();
            RuleFor(x => x.OfficeremailAddress).NotEmpty().EmailAddress();
            RuleFor(x => x.OfficerName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);

        }
    }
}
