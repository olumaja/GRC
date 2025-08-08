using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
        * Original Author: Olusegun Adaramaja
        * Date Created: 23/11/2024
        * Development Group: GRCTools
        * This endpoint update internal control status to either open or close
        */
    public class UpdateInternalControlStatusEndpoint
    {
        /// <summary>
        /// This endpoint update internal control status to either open or close
        /// </summary>
        /// <param name="request"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(UpdateInternalControlStatus request, IRepository<InternalControlModel> repository, IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService)
        {
            var control = await repository.GetByIdAsync(request.Id);

            if (control == null)
                return TypedResults.NotFound("Record not found");

            if(request.Status.Equals(InternalControlStatus.Closed.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                control.UpdateStatus(InternalControlStatus.Closed);
                repository.SaveChanges();
                // Send email to action owner, line mgr and internal control
                #region Log email request
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"Internal Control Supervisor Update the Internal Control StatRequest Status - {dateOfOccurrence})";
                var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolUpdateInvestigationUpdateStatus"], control.Id);
                string emailTo = control.CollaboratorEmail; // config["EmailConfiguration:InternalControlEmailTo"];
                string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
                string body = $"Hello All, <br><br> {currentUserService.CurrentUserFullName} has updated the Internal Control status initiated by {control.CreatedBy} to Closed.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, control.Id, emailTo, toCC);

                if (logEmailRequest == false)
                {
                    return TypedResults.Problem($"Internal Control Officer updated the exception tracker successfully, but email message was not logged");
                }
                #endregion
                return TypedResults.Ok("Status update successful, investigation is now Closed");
            }
            else if(request.Status.Equals(InternalControlStatus.Open.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                control.UpdateStatus(InternalControlStatus.Open);
                repository.SaveChanges();
                // Send email to action owner, line mgr and internal control
                #region Log email request
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"Internal Control Supervisor Update the Internal Control StatRequest Status - {dateOfOccurrence})";
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = control.CollaboratorEmail;
                string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
                string body = $"Hello All, <br><br> {currentUserService.CurrentUserFullName} has updated the  Internal Control status initiated by {control.CreatedBy} to Open.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, control.Id, emailTo, toCC);

                //if (logEmailRequest == false)
                //{
                //    return TypedResults.Problem($"Internal Control Supervisor updated the status successfully, but email message was not logged");
                //}
                #endregion
                return TypedResults.Ok("Status update successful, investigation is now Open");
            }

            return TypedResults.BadRequest("Investigating status can either be Open or Closed");
        }
    }
}
