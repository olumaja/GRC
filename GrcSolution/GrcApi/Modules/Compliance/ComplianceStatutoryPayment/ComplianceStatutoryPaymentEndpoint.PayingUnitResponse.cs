using Arm.GrcApi.Modules.RiskManagement.BIA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.RestHelper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
  * Original Author: Olusegun Adaramaja
  * Date Created: 03/09/2024
  * Development Group: GRCTools
  * Endpoint to attach prove payment 
  */
    public class PayingUnitResponseEndpoint
    {
        /// <summary>
        /// Paying unit attached prove of payment
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="repo"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(MakePaymentRequest paymentRequest, IRepository<ComplianceStatutoryPayment> repo, IRepository<Document> docRepo,
             IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "csv", "docx", "jpg", "jpeg", "png", "gif" };

            foreach (var attachment in paymentRequest.PaymentAttachments)
            {
                var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                if (!fileTypeAllow.Contains(fileExtension))
                    return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");
            }

            var payment = await repo.GetByIdAsync(paymentRequest.StatutoryPaymentId);

            if (payment is null)
                return TypedResults.BadRequest("Statutory payment does not exist");

            if (payment.Status == StatutoryStatus.Approved)
                return TypedResults.BadRequest("You can no longer edit statutory payment once it has been approved by HCM");

            if (payment.Status != StatutoryStatus.Awaiting && payment.Status != StatutoryStatus.Processed)
                return TypedResults.BadRequest("FINCON must process payment before you can continue");

            if (paymentRequest.PaymentAttachments.Count == 0)
                return TypedResults.BadRequest("Please attach prove of payment");

            //Remove previous attachments if exist, this endpoint also serve as update for statutory payment by Treasury
            docRepo.BulkDelete(x => x.ModuleItemId == payment.Id && x.ModuleItemType == ModuleType.ComplianceStatutoryPaymentPayingUnit);

            bool isWithInDeadline = false;
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var deadLine = new DateOnly(currentYear, currentMonth, 28);

            if (DateOnly.FromDateTime(DateTime.Now) < deadLine)
                isWithInDeadline = true;

            var submitPayment = new SubmitPayment(
                CashRemittanceStatus: paymentRequest.CashRemittanceStatus,
                SubmissionToStatutoryBody: paymentRequest.SubmissionToStatutoryBody,
                Comment: paymentRequest.Comment,
                DateOfPayment: paymentRequest.DateOfPayment,
                ProcessOfficer: currentUserService.CurrentUserFullName
            );
            payment.UpdateSubmitToStatutoryBody(submitPayment, isWithInDeadline);
            payment.SetModifiedOnUtc(DateTime.Now);
            payment.UpdateStatus(StatutoryStatus.Awaiting);

            //Add attachments
            List<Document> attachedFiles = new();
            Parallel.ForEach(paymentRequest.PaymentAttachments, a => attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(a, ModuleType.ComplianceStatutoryPaymentPayingUnit, payment.Id)));
            await docRepo.AddRangeAsync(attachedFiles);
            repo.SaveChanges();

            #region Log email request
            string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
            string subject = $"PAYE REMITTANCES - {dateOfOccurrence}";
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = config["EmailConfiguration:HCMToReviewPaymentFromPayingUnitEmailTo"];
            string toCC = config["EmailConfiguration:HCMToReviewPaymentFromPayingUnitEmailToCC"];
            string body = $"Dear all, <br> Paying Unit (FINCON/TREASURY) has make payment on the {dateOfOccurrence}<br> Click here for more detail:<a href={linkToGRCTool}>GRC link</a>.";
            //string body = $"Dear all, <br> The BIA exercise has begun, and you have been mandated to initiate all BIA activities as your unit’s Risk Champion. <br><ul><li>BIA Period Covered: {StartBIADto.PeriodFrom} - {StartBIADto.PeriodTo}</li><li>BIA Exercise Timeline: {StartBIADto.StartDate} - {StartBIADto.EndDate}</li></ul> <br>. Kindly login to the GRC Tool to initiate the BIA exercise: <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.ComplianceStatutoryPaymentPayingUnit, payment.Id, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"Paying unit makes payment successfully, but email message was not logged");
            }
            #endregion

            return TypedResults.Ok("Submitted successfully");
        }
    }
}
