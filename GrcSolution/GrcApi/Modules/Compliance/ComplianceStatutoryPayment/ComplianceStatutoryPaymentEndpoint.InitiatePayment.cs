using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using Azure;
using DocumentFormat.OpenXml.Drawing.Charts;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 23/08/2024
      * Development Group: GRCTools
      * Compliance Statutory Payment: Initiate statutory Payment Endpoint.     
      */
    public class InitiatePaymentEndpoint
    {
        /// <summary>
        /// Initiate statutory payment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="repo"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ComplianceStatutoryPaymentDto request, IRepository<ComplianceStatutoryPayment> repo, IRepository<Document> docRepo, ICurrentUserService currentUserService,
            IConfiguration config, IEmailService EmailService)
        {
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

            var payment = ComplianceStatutoryPayment.Create(
                new CreateStatutoryPayment
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
                )
            );
            payment.SetModifiedOnUtc(DateTime.Now);
            repo.Add(payment);

            //Add attachments
            List<Document> attachedFiles = new();
            Parallel.ForEach(request.Attachments, a => attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(a, ModuleType.ComplianceStatutoryPaymentHCM, payment.Id)));
            await docRepo.AddRangeAsync(attachedFiles);
            docRepo.SaveChanges();

            // Send email notification to paying unit
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
                return TypedResults.Ok($"Paying unit makes payment successfully, but email message was not logged");
            }
            #endregion

            var response = new InitiateStatutoryPaymentResponse(Id: payment.Id);
            return TypedResults.Created($"ar/{response}", response);
        }
    }
}
