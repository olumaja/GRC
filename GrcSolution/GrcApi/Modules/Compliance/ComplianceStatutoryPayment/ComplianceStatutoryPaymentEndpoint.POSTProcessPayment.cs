using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 17/10/2024
      * Development Group: GRCTools
      * Compliance Statutory Payment: This endpoint enable fincon to attached processed document     
      */
    public class POSTProcessPaymentEndpoint
    {
        /// <summary>
        /// This endpoint enable fincon to attached processed document
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <param name="repo"></param>
        /// <param name="docRepo"></param>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        /// <param name="EmailService"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(ProcessPayment paymentRequest, IRepository<ComplianceStatutoryPayment> repo, IRepository<Document> docRepo,
             IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "csv", "docx", "jpg", "jpeg", "png", "gif"};

            foreach (var attachment in paymentRequest.ProcessedPaymentAttachments)
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

            if (paymentRequest.ProcessedPaymentAttachments.Count == 0)
                return TypedResults.BadRequest("Please provide attachments that have been processed");

            payment.SetModifiedOnUtc(DateTime.Now);
            payment.UpdateStatus(StatutoryStatus.Processed);

            //Remove previous attachments if exist, this endpoint also serve as update for process statutory payment by FINCO
            docRepo.BulkDelete(x => x.ModuleItemId == payment.Id && x.ModuleItemType == ModuleType.ComplianceStatutoryPaymentFINCON);


            //Add attachments
            List<Document> attachedFiles = new();
            Parallel.ForEach(paymentRequest.ProcessedPaymentAttachments, a => attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(a, ModuleType.ComplianceStatutoryPaymentFINCON, payment.Id)));
            await docRepo.AddRangeAsync(attachedFiles);
            repo.SaveChanges();

            #region Log email request
            string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
            string subject = $"PAYE REMITTANCES - {dateOfOccurrence}";
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = config["EmailConfiguration:PayingUnitEmailTo"];
            string toCC = config["EmailConfiguration:PayingUnitEmailToCC"];
            string body = $"Dear all, <br> HCM has initiated the payment request on the {dateOfOccurrence}.<br> Click here for more detail:<a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.ComplianceStatutoryPaymentPayingUnit, payment.Id, emailTo, toCC);
            
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"Processed attachment was added successfully, but email message was not logged");
            }
            #endregion

            return TypedResults.Ok("Submitted successfully");
        }
    }
}
