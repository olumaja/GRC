using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
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
         * This endpoint delete internal control exception tracker by ID 
         */
    public class DeleteExceptionTrackerEndpoint
    {
        /// <summary>
        /// This endpoint delete internal control exception tracker by ID 
        /// </summary>
        /// <param name="exceptionTrackerId"></param>
        /// <param name="repository"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(DeleteExceptionTrackerControlStatus del, IRepository<InternalControlExceptionTracker> repository,
          IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService)
        {
            try
            {
                var exception = await repository.GetByIdAsync(del.Id);

                if (exception == null)
                    return TypedResults.NotFound("Exception Tracker Record was not found");

                exception.DeleteRequest();
                var currentUser = currentUserService.CurrentUserFullName;
                exception.SetModifiedBy(currentUser);
                exception.SetModifiedOnUtc(DateTime.Now);
                repository.Update(exception);
                await repository.SaveChangesAsync();
                // Send email to action owner, line mgr and internal control
                #region Log email request
                string dateOfOccurrence = DateTime.Now.ToString("dd MMMM yyyy"); 
                string subject = $"Internal Control Officer Deleted Request - {dateOfOccurrence}";
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = exception.ResponsibleOfficerEmail; 
                string toCC = config["EmailConfiguration:InternalControlEmailTo"];
                string body = $"Hello All, <br><br> {currentUser} has deleted an internal control exception request created by {exception.CreatedBy} containing these:<br> >> Unit => {exception.Unit},<br> >>  Exception => {exception.Exception},<br> >> Activity Impacted => {exception.ActivityImpacted},<br> >> Date Created => {exception.CreatedOnUtc}. <br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";

                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, exception.Id, emailTo, toCC);

                #endregion
                return TypedResults.NoContent();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
