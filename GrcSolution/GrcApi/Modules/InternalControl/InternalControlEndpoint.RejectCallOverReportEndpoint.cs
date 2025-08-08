using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 12/09/2024
      * Development Group: GRCTools
      * Internal Control Supervisor reject call over report    
      */
    public class RejectCallOverReportEndpoint
    {
        /// <summary>
        /// Internal Control Supervisor reject call over report
        /// </summary>
        /// <param name="reject"></param>
        /// <param name="repo"></param>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        /// <param name="EmailService"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            RejectCallOverReportRequest reject, IRepository<InternalControlCallOver> repo, IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            var callOver = await repo.GetByIdAsync(reject.CallOverId);

            if (callOver is null)
                return TypedResults.NotFound("Record not found");

            if (callOver.Unit != currentUserService.CurrentUserUnitName)
                return TypedResults.Forbid();

            if (callOver.Status != CallOverStatus.Awaiting_Approval)
                return TypedResults.BadRequest("You can only reject callover that is awaiting approval");

            var requester = currentUserService.CurrentUserFullName;
            callOver.Rejected(reject.ReasonForRejection, requester);
            callOver.UpdateStatus(CallOverStatus.Rejected);
            callOver.SetModifiedBy(requester);
            callOver.SetModifiedOnUtc(DateTime.Now);
            repo.SaveChanges();
            // Send email to action owner, line mgr and internal control
            #region Log email request
            string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
            string subject = $"Internal Control Supervisor Rejected Request - {dateOfOccurrence}";
            var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReject"], callOver.Id);
            string emailTo = config["EmailConfiguration:InternalControlEmailTo"];
            string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
            string body = $"Hello All,<br><br> {requester} has rejected the internal control requested by {callOver.CreatedBy}.<br><br> Reason => {reject.ReasonForRejection}.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, callOver.Id, emailTo, toCC);

            #endregion

            return TypedResults.Ok("Rejected successfully");
        }
    }
}
