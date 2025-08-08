using Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Bibliography;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 10/11/2024
      * Development Group: GRCTools
      * Internal Control Officer Approval.     
      */
    public class ApproveInternalControlEndpoint
    {
        /// <summary>
        /// Internal Control Officer Approval
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
            ApproveInternalControlRequest approve, IRepository<InternalControlActionOwner> repo, 
             IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            string requesterName = currentUserService.CurrentUserFullName;
            var getById = repo.GetContextByConditon(c => c.Id == approve.ActionOwnerId && c.ActionOwnerStatus != InternalControlStatus.Approved && c.Response != null)
                              .Include(c => c.InternalControlAction)
                              .ThenInclude(c => c.InternalControl)
                              .FirstOrDefault();

            if (getById is null)
                return TypedResults.NotFound("You can only approve after action owner has responsed");

            if (getById.InternalControlAction.InternalControl.Status == InternalControlStatus.Closed)
                return TypedResults.BadRequest("The current investigation is closed, you can no longer approve");

            getById.ApproveInternalControl(requesterName);
            getById.SetModifiedBy(requesterName);
            getById.SetModifiedOnUtc(DateTime.Now);
            repo.SaveChanges();

            // Send email to action owner, line mgr and internal control
            #region Log email request
            string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
            string subject = $"Internal Control Officer Approval - {dateOfOccurrence}";
            var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolICApprovedActionOwnerrequest"], getById.Id, getById.InternalControlActionlId);
            string emailTo = getById.ActionOwnerEmail;
            string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
            string body = $"Hello All, <br><br> {requesterName} has approved the internal control requested by {getById.CreatedBy}.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, getById.Id, emailTo, toCC);

            #endregion


            return TypedResults.Ok("Approved successfully");
        }
    }
}
