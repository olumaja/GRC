using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using ClosedXML;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GrcApi.Modules.InternalControl
{
    /*
       * Original Author: Olusegun Adaramaja
       * Date Created: 9/12/2024
       * Development Group: GRCTools
       * Submit call over report.     
       */
    public class SubmitCallOverReportsEndpoint
    {
        /// <summary>
        /// Submit call over report
        /// </summary>
        /// <param name="request"></param>
        /// <param name="calloverRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            SubmitCallOverDto request, IRepository<InternalControlCallOver> calloverRepo, IConfiguration config, Serilog.ILogger logger, 
            IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            var callOver = calloverRepo.GetContextByConditon(c => c.Id == request.CallOverId)
                                       .Include(c => c.Reports)
                                       .FirstOrDefault();

            if (callOver is null)
                return TypedResults.BadRequest("Record not found");

            if (callOver.Unit != currentUserService.CurrentUserUnitName)
                return TypedResults.Forbid();

            var numberOfPendingReport = callOver.Reports.Where(r => !r.IsReportDone)
                                                .Count();

            if(numberOfPendingReport > 0)
                return TypedResults.BadRequest($"You have {numberOfPendingReport} reports pending, kindly attached all reports before submission");

            callOver.UpdateStatus(CallOverStatus.Awaiting_Approval);
            callOver.SetCreatedBy(currentUserService.CurrentUserFullName);
            callOver.SetModifiedBy(currentUserService.CurrentUserFullName);
            callOver.SetModifiedOnUtc(DateTime.Now);
            calloverRepo.SaveChanges();
            // Send email to action owner, line mgr and internal control
            #region Log email request
            /* "
    
    "": "Bimbo.Moses@arm.com.ng, Aminat.Ashafa@arm.com.ng, Rosemary.Francis@arm.com.ng",
    "": "Kevian.Kevin@arm.com.ng",
    "": "Oluwatosin.Oluyemi@arm.com.ng"
             */

            string? emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];  
            if (callOver.Unit == "Securities Operations")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToSecuritiesSup"];
            }
            if (callOver.Unit == "Customer Experience")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToCustomerExpSup"];
            }
            if (callOver.Unit == "Financial Control")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToFINCONSup"];
            }
            if (callOver.Unit == "Fund Account")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToFundAccountSup"];
            }
            if (callOver.Unit == "Investment Management")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToARMIMSup"];
            }
            if (callOver.Unit == "Fund Admin")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToFundAdminSup"];
            }
            if (callOver.Unit == "ARM Private Trust")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrustSup"];
            }
            if (callOver.Unit == "ARM Registrars")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToRegistrarsSup"];
            }
            if (callOver.Unit == "Retail Operations")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToRetailsOpSup"];
            }
            if (callOver.Unit == "Treasury")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToTreasurySup"];
            }

            //string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
            string subject = $"Internal Control Supervisor Call Over For Your Review";
            var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = emailTo2;
            string toCC = currentUserService.CurrentUserEmail;
            string body = $"Hello All,<br><br> {currentUserService.CurrentUserFullName} has uploaded a call over for today.<br><br> Click here to review: <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, callOver.Id, emailTo, toCC);

            #endregion
            return TypedResults.Ok("Report submitted successfully");
        }
    }
}
