using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 10/11/2024
       * Development Group: GRCTools
       * Reject Exception Endpoint.     
       */
    public class SupervisorRejectExceptionEndpoint
    {
        /// <summary>
        /// Reject Exception Endpoint. 
        /// </summary>
        /// <param name="approve"></param>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        /// <param name="EmailService"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            SupervisorRejectExceptionRequest reject, IRepository<InternalControlExceptionTracker> repo,
            ClaimsPrincipal user, IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            string requesterName = currentUserService.CurrentUserFullName;
            var getById = repo.GetContextByConditon(c => c.Id == reject.exceptionTrackerId && c.SupervisorStatus == ExceptionTrackerStatus.Pending_Approval).FirstOrDefault();

            if (getById is null)
                return TypedResults.NotFound("You can only reject new exception");
                      
            getById.RejectException(reject.ReasonForRejection);
            getById.SetModifiedBy(requesterName);
            getById.SetModifiedOnUtc(DateTime.Now);
            repo.SaveChanges();

            // Send email to action owner, 
            #region Log email request
           
            string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
            string subject = $"Logged Exception Rejected - {dateOfOccurrence}";
            var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolLoggedException"], getById.Id);
            string emailTo = getById.RequesterEmail;
            string toCC = $"{currentUserService.CurrentUserEmail},{config["EmailConfiguration:InternalControlEmailToCC"]}";
            string body = $"Hello All, <br><br> {requesterName} has rejected the logged exception created by {getById.CreatedBy}.<br><br> Reason =>{reject.ReasonForRejection} <br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, getById.Id, emailTo, toCC);

            #endregion

            return TypedResults.Ok("Rejected successfully");
        }
    }
}
