using Arm.GrcApi.Modules.Shared.EmailNotification;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 16/10/2024
     * Development Group: GRCTools
     * Create Exception and send notification
     */
    public class CreateExceptionTrackerEndpoint
    {
        /// <summary>
        /// Create Exception and send notification
        /// </summary>
        /// <param name="requests"></param>
        /// <param name="excepRepo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="config"></param>
        /// <param name="EmailService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            CreateExceptionDto requests, IRepository<InternalControlExceptionTracker> excepRepo,
            ICurrentUserService currentUserService, IConfiguration config, IEmailService EmailService
        )
        {
            try
            {
                var requesterName = currentUserService.CurrentUserFullName;
                var exceptions = requests.CreateExceptions.Select(x => InternalControlExceptionTracker.Create(
                    new CreateException(
                        Exception: x.Exception,
                        Unit: x.BusinessUnit,
                        NatureOfException: x.NatureOfException,
                        ControlImpact: x.ControlImpact,
                        ImpactRating: x.ImpactRating,
                        TransactionCount: x.TransactionCount,
                        ActivityImpacted: x.ActivityImpacted,
                        ReponsibleOfficer: x.ReponsibleOfficer,
                        ReponsibleOfficerEmail: x.ReponsibleOfficerEmail.ToLower(),
                        DeadLine: x.DeadLine,
                        Recommendation: x.Recommendation,
                        RequesterEmail: currentUserService.CurrentUserEmail
                    ))).ToList();

                Parallel.ForEach(exceptions, e => e.SetCreatedBy(requesterName));
                Parallel.ForEach(exceptions, e => e.SetModifiedBy(requesterName));
                Parallel.ForEach(exceptions, e => e.SetModifiedOnUtc(DateTime.Now));
                excepRepo.AddRange(exceptions);
                excepRepo.SaveChanges();

                // Send email to action owner, line mgr and internal control
                #region Log email request
                string recipientEmails = string.Join(",", requests.CreateExceptions.Select(e => e.ReponsibleOfficerEmail));
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"Internal Control Officer Submitted Request - {dateOfOccurrence}";
                var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolCreateException"], exceptions[0].Id);
                string emailTo = config["EmailConfiguration:InternalControlExceptionEmailTo"]; 
                string toCC = config["EmailConfiguration:InternalControlEmailTo"]; 
                string body = $"Hello All, <br><br> {requesterName} has submitted an internal control exception request.<br><br> Click here for more detail:<a href={linkToGRCTool}>GRC link</a>.";

                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, exceptions[0].Id, emailTo, toCC);

                #endregion

                var response = exceptions.Select(e => new InternalControlResponse(Id: e.Id)).ToList();
                return TypedResults.Created($"ice/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Unable to submit the request");
            }
        }
    }
}
