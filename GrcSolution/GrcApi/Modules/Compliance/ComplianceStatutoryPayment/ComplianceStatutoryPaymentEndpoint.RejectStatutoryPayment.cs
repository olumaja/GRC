using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    public class RejectStatutoryPaymentEndpoint
    {
        public static async Task<IResult> HandleAsync(
            RejectStatutoryPaymentRequest rejectStatutory, IRepository<ComplianceStatutoryPayment> repo, IRepository<Document> docRepo,
             IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }
            var payment = await repo.GetByIdAsync(rejectStatutory.Id);

            if (payment is null)
                return TypedResults.NotFound("Statutory payment not found");

            var proveOfPayments = docRepo.GetContextByConditon(d => d.ModuleItemId == payment.Id && d.ModuleItemType == ModuleType.ComplianceStatutoryPaymentPayingUnit);

            if (proveOfPayments.Count() == 0)
                return TypedResults.BadRequest("Prove of payment has not been attached");

            if (payment.Status != StatutoryStatus.Awaiting)
                return TypedResults.BadRequest("This request is not in the awaiting list");

            payment.RejectStatutoryPayment(rejectStatutory.ReasonForRejection, currentUserService.CurrentUserFullName);
            repo.SaveChanges();
            #region Log email request
            string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
            string subject = $"PAYE REMITTANCES REJECTION - {dateOfOccurrence})";
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = config["EmailConfiguration:PayingUnitEmailTo"];
            string toCC = config["EmailConfiguration:PayingUnitEmailToCC"];
            string body = $"Dear all, <br> HCM has rejected the evidence of payment request on the {dateOfOccurrence}.<br> Reason for rejection => {rejectStatutory.ReasonForRejection}<br> Click here for more detail:<a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.ComplianceStatutoryPaymentPayingUnit, payment.Id, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"Paying unit makes payment successfully, but email message was not logged");
            }
            #endregion
            return TypedResults.Ok("Rejected successfully");
        }
    }
}
