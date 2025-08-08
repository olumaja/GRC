using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 23/08/2024
      * Development Group: GRCTools
      * Compliance Statutory Payment: Update initiated statutory Payment Endpoint.     
      */
    public class InitiatePaymentUpdateEndpoint
    {
        /// <summary>
        /// Update initiated statutory Payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="repo"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            UpdateComplianceStatutoryPaymentDto request, IRepository<ComplianceStatutoryPayment> repo, IRepository<Document> docRepo, ICurrentUserService currentUserService,
            IConfiguration config
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }
            var payment = await repo.GetByIdAsync(request.PaymentId);

            if (payment is null)
                return TypedResults.NotFound("Statutory payment not found");

            if(payment.Status == StatutoryStatus.Approved)
                return TypedResults.BadRequest("This request has been approved, you can no longer edit it");

            if (request.Attachments is null || request.Attachments.Count == 0)
                return TypedResults.BadRequest("Please attach document");

            if (request.PeriodFrom > request.PeriodTo) return TypedResults.BadRequest("PeriodFrom date cannot be greater than PeriodTo dte");

            var fileType = "pdf";
            var maxFileSize = Convert.ToInt32(config["MaximumFileSize"]);

            foreach (var attachment in request.Attachments)
            {
                var fileLength = attachment.Length;
                var fileExtension = Path.GetExtension(attachment.FileName).Trim('.');

                if (fileLength > maxFileSize)
                    return TypedResults.BadRequest($"File size for {attachment.Name} is larger than 4MB");

                if (!fileExtension.Equals(fileType, StringComparison.CurrentCultureIgnoreCase))
                    return TypedResults.BadRequest($"File type must be {fileType}");
            }

            payment.UpdateComplianceStatutoryPayment(new CreateStatutoryPayment
                (
                    BusinessEntity: request.BusinessEntity,
                    PayingUnit: request.PayingUnit,
                    Regulator: request.Regulator,
                    StatutoryPayment: request.StatutoryPayment,
                    PaymentFrequency: request.PaymentFrequency,
                    Purpose: request.Purpose,
                    PeriodFrom: request.PeriodFrom,
                    PeriodTo: request.PeriodTo,
                    Initiator: currentUserService.CurrentUserFullName,
                    ModifiedBy: currentUserService.CurrentUserFullName
                ));
            payment.SetModifiedOnUtc(DateTime.Now);
            repo.Update(payment);

            //Remove previous attachments if exist, this endpoint is update for statutory payment by HCM
            docRepo.BulkDelete(x => x.ModuleItemId == payment.Id && x.ModuleItemType == ModuleType.ComplianceStatutoryPaymentHCM);

            //Add attachments
            List<Document> attachedFiles = new();
            Parallel.ForEach(request.Attachments, a => attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(a, ModuleType.ComplianceStatutoryPaymentHCM, payment.Id)));
            await docRepo.AddRangeAsync(attachedFiles);
            docRepo.SaveChanges();

            return TypedResults.Ok("Updated succcessfully");
        }
    }
}
