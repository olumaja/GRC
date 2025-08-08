using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 06/28/2025
        * Development Group: GRCTools
        * The endpoint for the infosec staff to assign an action owner
        */
    public class InfoSecAssignedAntivirusToActionOwnerEndpoint
    {
        /// <summary>
        /// The endpoint for the infosec staff to assign an action owner
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repo"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
           InfoSecAssignAntivirusToActionOwnerReq payload, IRepository<AntivirusAssessmentModel> repo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                string requesterName = currentUserService.CurrentUserFullName;
                var update = repo.GetContextByConditon(r => r.Id == payload.AntivirusAssessmentFileId && r.AntivirusStatus != AntivirusStatus.Resolved).FirstOrDefault();
                if (update is null) return TypedResults.NotFound("Antivirus Assessment was not found or has been resolved");

                update.InfoSecAssignActionOwner(payload.ActionOwner, payload.ActionOwnerEmail, payload.ActionOwnerUnit, payload.ProposeEndDate);
                update.SetModifiedBy(requesterName);
                update.SetModifiedOnUtc(DateTime.Now);
                repo.SaveChanges();

                //Send Email notification
                #region Send email to the Action Owner      
                DateTime currentMonth = DateTime.Now;
                DateTime pastMonth = currentMonth.AddMonths(-1);
                string currentMonthFormatted = currentMonth.ToString("MMMM yyyy");
                string pastMonthFormatted = pastMonth.ToString("MMMM yyyy");

                string subject = $"Antivirus Assessment for {currentMonthFormatted}";
                var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = payload.ActionOwnerEmail;
                string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                string body = $"Dear {payload.ActionOwner}, <br><br>Thank you for the {pastMonthFormatted} updates. <br><br>Kindly click here to access the {currentMonthFormatted} Antivirus Assessment we just carried out. <br><br>Please remediate the issues identified as we would be following up with you and providing remediation status to the management at the end of the month. <br><br> Kindly see below the summary of issues raised this month {currentMonthFormatted} on the GRC Tool Link <br><br> <a href={linkToGRCTool}>GRC link</a> to review the details.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InfoSecInternalVulnerability, payload.AntivirusAssessmentFileId, emailTo, toCC);

                #endregion
                return TypedResults.Ok("Infosec update action owner successfully");
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest("Unable to update action owner successfully");
            }
        }
    }
}
