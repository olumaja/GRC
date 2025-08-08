using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
         * Original Author: Sodiq Quadre
         * Date Created: 23/11/2024
         * Development Group: GRCTools
         * This endpoint update internal control exception tracker status
         */
    public class UpdateControlDashboardStatusEndpoint
    {
        /// <summary>
        /// This endpoint update internal control dashboard status
        /// </summary>
        /// <param name="request"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(UpdateControlDashboardStatus request, IRepository<InternalControlDashboard> repository,
           IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService)
        {

            try
            {
                var actionOwner = repository.GetContextByConditon(x => x.Id == request.Id && x.ActionOwnerEmail.ToLower() == currentUserService.CurrentUserEmail.ToLower()).FirstOrDefault();

                if (actionOwner == null)
                    return TypedResults.NotFound("Record not found");

                var allowSatus = new Dictionary<string, InternalControlDashboardStatus>
               {
                    {"work in progress", InternalControlDashboardStatus.Work_In_Progress},
                    {"on hold", InternalControlDashboardStatus.On_Hold},
                    {"completed", InternalControlDashboardStatus.Completed}              
               };

                var status = request.Status.ToLower();

                if (!allowSatus.ContainsKey(status))
                    return TypedResults.BadRequest("Please enter one of the recommended status");

            actionOwner.UpdateStatus(
                  new UpdateControlDashboardStatusReq
                  (
                      Status: allowSatus[status],
                      Remark: request.Remark,
                      NumberOfTransaction: request.NumberOfTransaction
                  )
              );

                var currentUser = currentUserService.CurrentUserFullName;
                actionOwner.SetModifiedBy(currentUser);
                actionOwner.SetModifiedOnUtc(DateTime.Now);
                repository.Update(actionOwner);
                await repository.SaveChangesAsync();

                // Send email to action owner, stakeholder
                #region Log email request
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"Internal Control Officer Update the Requested Status - {dateOfOccurrence}";
                var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolUpdateStatusDashBoardTask"], actionOwner.Id);
                string emailTo = actionOwner.ActionOwnerEmail; 
                string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
                string body = $"Hello All, <br><br> {currentUserService.CurrentUserFullName} has updated the status of the internal control dashboard requested by {actionOwner.CreatedBy}.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, actionOwner.Id, emailTo, toCC);

                #endregion

                return TypedResults.Ok("Status updated succcessfully");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
