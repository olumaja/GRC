using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 23/11/2024
        * Development Group: GRCTools
        * This endpoint update internal control exception tracker status to Delete, or Resolved or Cancel 
        */
    public class UpdateExceptionTrackerStatusEndpoint
    {
        /// <summary>
        /// This endpoint update internal control exception tracker status to Delete, or Resolved or Cancel
        /// </summary>
        /// <param name="request"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(UpdateExceptionTrackerControlStatus request, IRepository<InternalControlExceptionTracker> repository,
          IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService)
        {
            var exception = repository.GetContextByConditon(x => x.Id == request.Id && x.ResponsibleOfficerEmail.ToLower() == currentUserService.CurrentUserEmail.ToLower()).FirstOrDefault();

            if (exception == null)
                return TypedResults.NotFound("Record not found");

            ExceptionTrackerStatus status = ExceptionTrackerStatus.Not_Resolved;
            if (request.Status.Equals(ExceptionTrackerStatus.Resolved.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                status = ExceptionTrackerStatus.Resolved;
            }           
            if (request.Status.Equals(ExceptionTrackerStatus.Deleted.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                status = ExceptionTrackerStatus.Deleted;
            }

            exception.UpdateStatus(
                  new UpdatedExceptionTrackerStatus
                  (
                      ManagementResponse: request.ManagementResponse,
                      Status: status
                  )
              );

            var currentUser = currentUserService.CurrentUserFullName;
            exception.SetModifiedBy(currentUser);
            exception.SetModifiedOnUtc(DateTime.Now);
            repository.Update(exception);
            await repository.SaveChangesAsync();
            // Send email to action owner, stakeholder
            #region Log email request
            string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
            string subject = $"Internal Control Officer Update the Requested Satus - {dateOfOccurrence}";
            var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolExceptionUpdatestatus"], exception.Id);
            string emailTo = exception.ResponsibleOfficerEmail; // config["EmailConfiguration:InternalControlEmailTo"];
            string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
            string body = $"Hello All, <br><br> {currentUserService.CurrentUserFullName} has updated the status of the internal control dashboard requested by {exception.CreatedBy}.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, exception.Id, emailTo, toCC);

            //if (logEmailRequest == false)
            //{
            //    return TypedResults.Problem($"Internal Control Officer updated the status successfully, but email message was not logged");
            //}
            #endregion

            return TypedResults.Ok("Status updated successful");

        }
    }
}
