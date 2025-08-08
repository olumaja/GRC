using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Bibliography;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 31/07/2024
      * Development Group: GRCTools
      * Compliance Regulator Payment: Make regulator Payment Endpoint.     
      */
    public class MakeRegulatorPaymentEndpoint
    {
        /// <summary>
        /// The endoint enable business unit to attached prove of payment
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="paymemtRepo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            MakePaymentDto payment, IRepository<ComplianceRegulatoryPayment> paymemtRepo, ICurrentUserService currentUserService, IRepository<Document> docRepo
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();
            if (payment.DateOfPayment.AddDays(1) < DateTime.Now) return TypedResults.BadRequest("DateOfPayment date cannot be earlier than today's date");

            var query = await paymemtRepo.GetByIdAsync(payment.ComplianceRegulatoryPaymentId);

            if (query is null)
                return TypedResults.NotFound("Payment is yet to be initiated");

            if(payment.AmountPaid != query.Amount)
                return TypedResults.BadRequest($"Amount paid {payment.AmountPaid} is not equal to amount required to be paid {query.Amount}");

            if (payment.Attachments is null || payment.Attachments.Count == 0)
                return TypedResults.BadRequest("Please attach report");

            var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "csv", "docx" }; 

           foreach (var attachment in payment.Attachments)
           {
                var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                if (!fileTypeAllow.Contains(fileExtension))
                    return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");
            }

            //Remove previous attachments if exist, this endpoint also serve as update for make regulator payment
            docRepo.BulkDelete(x => x.ModuleItemId == payment.ComplianceRegulatoryPaymentId);

            //handle new attachments
            List<Document> attachedFiles = new();
            Parallel.ForEach(payment.Attachments, a => attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(a, ModuleType.ComplianceRegulatoryPayment, query.Id)));
            await docRepo.AddRangeAsync(attachedFiles);

            query.PaymentTransactionDetails(payment.AmountPaid, payment.TransactionReference, payment.DateOfPayment, currentUserService.CurrentUserFullName);
            query.SetModifiedOnUtc(DateTime.Now);
            query.UpdateAttachmentCount(payment.Attachments.Count);
            bool isWithinDeadline = query.DeadLine > DateTime.Now ? true : false;
            query.UpdateComplianceStatusAfterSubmit(isWithinDeadline);
            paymemtRepo.SaveChanges();

            return TypedResults.Ok("Transaction successful");
        }
    }
}
