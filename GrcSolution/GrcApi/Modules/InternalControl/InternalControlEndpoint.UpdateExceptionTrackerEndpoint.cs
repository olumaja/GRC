using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Globalization;
using System.Web.Http;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/06/2024
    * Development Group: GRCTools
    * internal control: Update Created exception tracker by Id Endpoint     
    */
    public class UpdateExceptionTrackerEndpoint
    {
        /// <summary>
        /// Update Created exception tracker by Id Endpoint   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateInternalControlExceptionTracker request, IRepository<InternalControlExceptionTracker> repo,
          IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            try
            {
                var deadline = new DateTime(1994, 1, 1);
                var todayDate = DateTime.Now;
                if (!DateTime.TryParseExact(request.ProposedDeadline.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out deadline))
                {
                    return TypedResults.BadRequest("Invalid date format. Proposed Deadline must be in the format yyyy-MM-dd");
                }
               if (deadline.AddDays(1) < DateTime.Now) return TypedResults.BadRequest("Proposed deadline date cannot be earlier than today's date");

                var getException = repo.GetContextByConditon(c => c.Id == request.ExceptionTrackerId && c.SupervisorStatus != ExceptionTrackerStatus.Approved).FirstOrDefault();

                if (getException is null)
                {
                    return TypedResults.NotFound($"Exception was not found");
                }
                ExceptionTrackerStatus status = ExceptionTrackerStatus.Not_Resolved;
                if (request.Status.Equals(ExceptionTrackerStatus.Resolved.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    status = ExceptionTrackerStatus.Resolved;                   
                }                
                if (request.Status.Equals(ExceptionTrackerStatus.Deleted.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    status = ExceptionTrackerStatus.Deleted;
                }
                getException.UpdateExceptionTracker(
                   new LogUpdatedInternalControlExceptionTracker
                   (
                       Exception: request.Exception,
                       Unit: request.Unit,
                       ControlImpact: request.ControlImpact,
                       ImpactRating: request.ImpactRating,
                       NatureOfException: request.NatureOfException,
                       TransactionCount: request.TransactionCount,
                       ActivityImpacted: request.ActivityImpacted,
                       Recommendation: request.Recommendation,
                       Status: status,
                       ResponsibleOfficer: request.ResponsibleOfficer,
                       ProposedDeadline: deadline
                   )
               );

                var currentUser = currentUserService.CurrentUserFullName;
                getException.SetModifiedBy(currentUser);
                getException.SetModifiedOnUtc(DateTime.Now);
                repo.Update(getException);
                await repo.SaveChangesAsync();
                // Send email to action owner, line mgr and internal control
                #region Log email request
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"Internal Control Officer Update the Exception Tracker - {dateOfOccurrence}";
                var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolExceptionUpdate"], getException.Id);
                string emailTo = getException.ResponsibleOfficerEmail; // config["EmailConfiguration:InternalControlEmailTo"];
                string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
                string body = $"Hello All, <br><br> {currentUserService.CurrentUserFullName} has updated the exception tracker requested by {getException.CreatedBy}.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, getException.Id, emailTo, toCC);

                #endregion

                return TypedResults.Ok("updated succcessfully");
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
