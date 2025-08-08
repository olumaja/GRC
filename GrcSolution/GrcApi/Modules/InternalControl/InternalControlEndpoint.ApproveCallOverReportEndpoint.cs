using Arm.GrcApi.Modules.RiskManagement.RCSA;
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
      * Internal Control Supervisor approve call over report    
      */
    public class ApproveCallOverReportEndpoint
    {
        /// <summary>
        /// Internal Control Supervisor approve call over report
        /// </summary>
        /// <param name="approve"></param>
        /// <param name="repo"></param>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        /// <param name="EmailService"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ApproveCallOverReportRequest approve, IRepository<InternalControlCallOver> repo, ICurrentUserService currentUserService,
            IConfiguration config, IEmailService EmailService
        )
        {
            try
            {
                var callOver = await repo.GetByIdAsync(approve.CallOverId);

                if (callOver is null)
                    return TypedResults.NotFound("Record not found");

                if (callOver.Unit != currentUserService.CurrentUserUnitName)
                    return TypedResults.Forbid();

                if (callOver.Status != CallOverStatus.Awaiting_Approval)
                    return TypedResults.BadRequest("You can only approve callover that is awaiting approval");

                var score = callOver.DueDate >= DateOnly.FromDateTime(DateTime.Now) && callOver.ExpectedUploadTime >= TimeOnly.FromDateTime(DateTime.Now) ? 50 : 25;
                var requester = currentUserService.CurrentUserFullName;
                callOver.ApprovedCallOver(requester);
                callOver.UpdateStatus(CallOverStatus.Submitted);
                callOver.UpdateScore(score);
                callOver.SetModifiedBy(requester);
                callOver.SetModifiedOnUtc(DateTime.Now);
                repo.SaveChanges();

                // Send notification to internal control
                #region Log email request
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"{callOver.Unit} Team Lead Submitted Call Over Report - {dateOfOccurrence}";
                var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolCallOverApprove"], callOver.Id);
                string emailTo = config["EmailConfiguration:InternalControlEmailTo"];
                string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
                string body = $"Dear All, <br><br> {callOver.Unit} Team Lead has submitted a call over request.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, callOver.Id, emailTo, toCC);

                #endregion

                return TypedResults.Ok("Approved successfully");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Unable to approved successfully");
            }
        }
    }
}
