using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    public class InitiateRegulatorPaymentDto
    {
        [Required]
        public string? Regulator { get; set; }
        [Required]
        public DateTime? DeadLine { get; set; }
        [Required]
        public string? MeansOfPaymentAmount { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string? ProcessOfficer { get; set; }
        [Required]
        public string? PaymentDetail { get; set; }
        [Required]
        public string? BusinessEntity { get; set; }            
    }
    public class InitiateRegulatorPaymentDtoValidator : AbstractValidator<InitiateRegulatorPaymentDto>
    {
        const decimal amount = 0;
        DateTime deadLine = DateTime.Now;
        public InitiateRegulatorPaymentDtoValidator()
        {
            RuleFor(x => x.Regulator).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.DeadLine).GreaterThanOrEqualTo(deadLine).WithMessage("Deadline date cannot be earlier than today's date");
            RuleFor(x => x.MeansOfPaymentAmount).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(amount).WithMessage("invalid amount, minimum amount required is 1000 naira");
            RuleFor(x => x.ProcessOfficer).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.PaymentDetail).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.BusinessEntity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class InitiateRegulatorPaymentResp
    {
        public Guid RegulatorPaymentId { get; set; }
    }

    public class UpdateComplianceRegulatorPaymentReq
    {
        public Guid RegulatorPaymentId { get; set; }
        public string? Regulator { get; set; }
        public DateTime? DeadLine { get; set; }
        public string? MeansOfPaymentAmount { get; set; }
        public decimal Amount { get; set; } = 0;
        public string? ProcessOfficer { get; set; }
        public string? PaymentDetail { get; set; }
        public string? BusinessEntity { get; set; }
    }

    public class UpdateComplianceRegulatorPaymentReqValidator : AbstractValidator<UpdateComplianceRegulatorPaymentReq>
    {
        const decimal amount = 0;
        DateTime deadLine = DateTime.Now;
        public UpdateComplianceRegulatorPaymentReqValidator()
        {
            RuleFor(x => x.Regulator).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.DeadLine).GreaterThanOrEqualTo(deadLine).WithMessage("Deadline date cannot be earlier than today's date");
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(amount).WithMessage("invalid amount, minimum amount required is 0 naira ore more");
            RuleFor(x => x.MeansOfPaymentAmount).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ProcessOfficer).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.PaymentDetail).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.BusinessEntity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class GetComplianceRegulatorPaymentById
    {
        public Guid RegulatorPaymentId { get; set; }
        public string? Regulator { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public string? MeansOfPaymentAmount { get; set; }
        public decimal Amount { get; set; } = 0;
        public decimal AmountPaid { get; set; } = 0;
        public string? ProcessOfficer { get; set; }
        public string? PaymentDetail { get; set; }
        public string? BusinessEntity { get; set; }
        public string? TransactionReference { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ReasonForRejection { get; set; }
        public string? CreatedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public List<GetAttachedReportResponse> Attachments { get; set; }
    }

    public class GetStatutoryPaymentByIdResp
    {
        public Guid StatutoryPaymentId { get; set; }
        public string? BusinessEntity { get; set; }
        public string? PayingUnit { get; set; }
        public string? Regulator { get; set; }
        public string? StatutoryPayment { get; set; }
        public string? PaymentFrequency { get; set; }
        public string? Purpose { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }       
        public string Status { get; set; }
        public string? CashRemittanceStatus { get; set; }
        public string? SubmissionToStatutoryBody { get; set; }
        public string? ReasonForRejection { get; set; }
        public string? Comments { get; set; }
        public string? ComplianceLevel { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? ProcessOfficer { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<GetAttachedReportResponse> Attachments { get; set; }
        public List<GetAttachedReportResponse> ProcessedAttachments { get; set; }
        public List<GetAttachedReportResponse> EvidenceOfPayment { get; set; }
    }

    public class GetComplianceRegulatorPayment {
        public Guid RegulatorPaymentId { get; set; }
        public string Regulator { get; set; }
        public string BusinessEntity { get; set; }
        public DateTime? DeadLine { get; set; }
        public string MeansOfPayment { get; set; }
        public decimal Amount { get; set; }
        public string ProcessOfficer { get; set; }
        public string Status { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public string ComplianceLevel { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }

}
