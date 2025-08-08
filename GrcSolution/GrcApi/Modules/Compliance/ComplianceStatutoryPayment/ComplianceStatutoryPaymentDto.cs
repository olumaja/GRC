using Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    public record ComplianceStatutoryPaymentDto(
        string BusinessEntity,
        string PayingUnit,
        string Regulator,
        string StatutoryPayment,
        string PaymentFrequency,
        string Purpose,
        DateTime PeriodFrom,
        DateTime PeriodTo,
        IList<IFormFile> Attachments
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a ComplianceStatutoryPaymentDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<ComplianceStatutoryPaymentDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["PeriodFrom"], out var PeriodFrom);
            DateTime.TryParse(httpContext.Request.Form["PeriodTo"], out var PeriodTo);

            return ValueTask.FromResult(
                new ComplianceStatutoryPaymentDto(
                    httpContext.Request.Form["BusinessEntity"],
                    httpContext.Request.Form["PayingUnit"],
                    httpContext.Request.Form["Regulator"],
                    httpContext.Request.Form["StatutoryPayment"],
                    httpContext.Request.Form["PaymentFrequency"],
                    httpContext.Request.Form["Purpose"],
                    PeriodFrom,
                    PeriodTo,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }
    
    public class ComplianceStatutoryPaymentDtoValidator : AbstractValidator<ComplianceStatutoryPaymentDto>
    {
        public ComplianceStatutoryPaymentDtoValidator()
        {
            RuleFor(r => r.BusinessEntity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.PayingUnit).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Regulator).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.StatutoryPayment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.PaymentFrequency).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Purpose).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.PeriodFrom).NotEmpty();
            RuleFor(r => r.PeriodTo).NotEmpty().GreaterThanOrEqualTo(r => r.PeriodFrom);
            RuleFor(r => r.Attachments).NotEmpty();
        }
    }

    public record UpdateComplianceStatutoryPaymentDto(
        Guid PaymentId,
        string BusinessEntity,
        string PayingUnit,
        string Regulator,
        string StatutoryPayment,
        string PaymentFrequency,
        string Purpose,
        DateTime PeriodFrom,
        DateTime PeriodTo,
        IList<IFormFile> Attachments
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a UpdateComplianceStatutoryPaymentDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<UpdateComplianceStatutoryPaymentDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["PaymentId"], out var PaymentId);
            DateTime.TryParse(httpContext.Request.Form["PeriodFrom"], out var PeriodFrom);
            DateTime.TryParse(httpContext.Request.Form["PeriodTo"], out var PeriodTo);

            return ValueTask.FromResult(
                new UpdateComplianceStatutoryPaymentDto(
                    PaymentId,
                    httpContext.Request.Form["BusinessEntity"],
                    httpContext.Request.Form["PayingUnit"],
                    httpContext.Request.Form["Regulator"],
                    httpContext.Request.Form["StatutoryPayment"],
                    httpContext.Request.Form["PaymentFrequency"],
                    httpContext.Request.Form["Purpose"],
                    PeriodFrom,
                    PeriodTo,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class UpdateComplianceStatutoryPaymentDtoValidator : AbstractValidator<UpdateComplianceStatutoryPaymentDto>
    {
        public UpdateComplianceStatutoryPaymentDtoValidator()
        {
            RuleFor(r => r.PaymentId).NotEmpty();
            RuleFor(r => r.BusinessEntity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.PayingUnit).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Regulator).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.StatutoryPayment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.PaymentFrequency).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Purpose).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.PeriodFrom).NotEmpty();
            RuleFor(r => r.PeriodTo).NotEmpty().GreaterThanOrEqualTo(r => r.PeriodFrom);
            RuleFor(r => r.Attachments).NotEmpty();
        }
    }

    public record MakePaymentRequest(
        Guid StatutoryPaymentId,
        string CashRemittanceStatus,
        string SubmissionToStatutoryBody,
        string Comment,
        DateTime DateOfPayment,
        List<IFormFile> PaymentAttachments
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a MakePaymentRequest object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<MakePaymentRequest> BindAsync(HttpContext httpContext, ParameterInfo parameter)
    {
        Guid.TryParse(httpContext.Request.Form["StatutoryPaymentId"], out var StatutoryPaymentId);
            
        DateTime.TryParse(httpContext.Request.Form["DateOfPayment"], out var DateOfPayment);

        return ValueTask.FromResult(
            new MakePaymentRequest(
                StatutoryPaymentId,
                httpContext.Request.Form["CashRemittanceStatus"],
                httpContext.Request.Form["SubmissionToStatutoryBody"],
                httpContext.Request.Form["Comment"],
                DateOfPayment,
                httpContext.Request.Form.Files.GetFiles("PaymentAttachments").ToList()
        ));
    }
}

    public class MakePaymentRequestValidator : AbstractValidator<MakePaymentRequest>
    {
        public MakePaymentRequestValidator()
        {
            RuleFor(r => r.StatutoryPaymentId).NotEmpty();
            RuleFor(r => r.CashRemittanceStatus).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.SubmissionToStatutoryBody).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Comment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.PaymentAttachments).NotEmpty();
            //RuleFor(r => r.DateOfPayment).NotEmpty().LessThanOrEqualTo(DateTime.Now);
            //RuleFor(r => r.ProveOfPayments).NotEmpty();
        }
    }

    public record ProcessPayment(Guid StatutoryPaymentId, List<IFormFile> ProcessedPaymentAttachments)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a ProcessPayment object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<ProcessPayment> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["StatutoryPaymentId"], out var StatutoryPaymentId);

            return ValueTask.FromResult(
                new ProcessPayment(
                    StatutoryPaymentId,
                    httpContext.Request.Form.Files.GetFiles("ProcessedPaymentAttachments").ToList()
            ));
        }
    }

    public class ProcessPaymentValidator : AbstractValidator<ProcessPayment>
    {
        public ProcessPaymentValidator()
        {
            RuleFor(r => r.StatutoryPaymentId).NotEmpty();
            RuleFor(r => r.ProcessedPaymentAttachments).NotEmpty();
        }
    }

    public record ProveOfPayment(
        IFormFile PaymentAttachment, DateTime DateOfPayment
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a MakePaymentRequest object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<ProveOfPayment> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["DateOfPayment"], out var DateOfPayment);

            return ValueTask.FromResult(
                new ProveOfPayment(
                    httpContext.Request.Form.Files.GetFiles("PaymentAttachment").FirstOrDefault(),
                    DateOfPayment
                )
            );
        }
    }

    public record SubmitPayment(
        string CashRemittanceStatus,
        string SubmissionToStatutoryBody,
        string Comment,
        DateTime DateOfPayment,
        string? ProcessOfficer
    );

    public record CreateStatutoryPayment(
        string BusinessEntity,
        string PayingUnit,
        string Regulator,
        string StatutoryPayment,
        string PaymentFrequency,
        string Purpose,
        DateTime PeriodFrom,
        DateTime PeriodTo,
        string? Initiator,
        string? ModifiedBy
    );

    public class ComplianceStatutoryPaymentResponse {
        public Guid Id { get; set; }
        public string BusinessEntity { get; set; }
        public string PayingUnit { get; set; }
        public string StatutoryPayment { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ProcessOfficer { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }

    public class ComplianceLevelResponse
    {
        public Guid Id { get; set; }
        public string BusinessEntity { get; set; }
        public string PayingUnit { get; set; }
        public string StatutoryPayment { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public string ComplianceLevel { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ProcessOfficer { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }

    public record InitiateStatutoryPaymentResponse(Guid Id);

    public record ApproveStatutoryPaymentRequest(Guid Id);

    public record RejectStatutoryPaymentRequest(Guid Id, string ReasonForRejection);

    public class RejectStatutoryPaymentRequestValidation : AbstractValidator<RejectStatutoryPaymentRequest>
    {
        public RejectStatutoryPaymentRequestValidation()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.ReasonForRejection).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
}
