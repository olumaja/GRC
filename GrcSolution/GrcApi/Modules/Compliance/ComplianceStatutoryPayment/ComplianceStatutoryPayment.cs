using Arm.GrcApi.Modules.Shared;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using System.ComponentModel;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    public enum StatutoryStatus
    {
        Not_Paid = 1,
        Processed,
        Awaiting,
        Rejected,
        Approved,
        Non_Compliance,
        Partially_Compliance,
        Fully_Compliance
    }

    public class ComplianceStatutoryPayment : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string BusinessEntity { get; private set; }
        public string PayingUnit { get; private set; }
        public string Regulator { get; private set; }
        public string StatutoryPayment { get; private set; }
        public string PaymentFrequency { get; private set; }
        public DateTime PeriodFrom { get; private set; }
        public DateTime PeriodTo { get; private set; }
        public string Purpose { get; private set; }
        public string? Comments { get; private set; }
        public string? CashRemittanceStatus { get; private set; }
        public string? SubmissionToStatutoryBody { get; private set; }
        public string? ReasonForRejection { get; set; }
        public DateTime? DateOfPayment { get; private set; }
        public StatutoryStatus Status { get; private set; } = StatutoryStatus.Not_Paid;
        public StatutoryStatus ComplianceLevel { get; private set; } = StatutoryStatus.Non_Compliance;
        public string? Initiator { get; set; }
        public string? ProcessOfficer { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public static ComplianceStatutoryPayment Create(CreateStatutoryPayment request)
        {
            return new ComplianceStatutoryPayment
            {
                BusinessEntity = request.BusinessEntity,
                PayingUnit = request.PayingUnit,
                Regulator = request.Regulator,
                StatutoryPayment = request.StatutoryPayment,
                PaymentFrequency = request.PaymentFrequency,
                PeriodFrom = request.PeriodFrom,
                PeriodTo = request.PeriodTo,
                Purpose = request.Purpose,
                Initiator = request.Initiator,
                LastUpdatedBy = request.ModifiedBy
            };
        }

        public void UpdateComplianceStatutoryPayment(CreateStatutoryPayment request)
        {
            BusinessEntity = request.BusinessEntity;
            PayingUnit = request.PayingUnit;
            Regulator = request.Regulator;
            StatutoryPayment = request.StatutoryPayment;
            PaymentFrequency = request.PaymentFrequency;
            PeriodFrom = request.PeriodFrom;
            PeriodTo = request.PeriodTo;
            Purpose = request.Purpose;
            Initiator = request.Initiator;
            LastUpdatedBy = request.ModifiedBy;
        }

        public void UpdateSubmitToStatutoryBody(SubmitPayment paymentRequest, bool isWithinDeadline)
        {
            CashRemittanceStatus = paymentRequest.CashRemittanceStatus;
            SubmissionToStatutoryBody = paymentRequest.SubmissionToStatutoryBody;
            Comments = paymentRequest.Comment;
            DateOfPayment = paymentRequest.DateOfPayment;
            ProcessOfficer = paymentRequest.ProcessOfficer;
            ProcessedDate = DateTime.Now;
            LastUpdatedBy = paymentRequest.ProcessOfficer;

            if (isWithinDeadline)
                ComplianceLevel = StatutoryStatus.Partially_Compliance;
        }

        public void UpdateStatus(StatutoryStatus status)
        {
            Status = status;
        }

        public void ApproveStatutoryPayment(bool isWithDeadline, string? approvedBy)
        {
            Status = StatutoryStatus.Approved;
            ApprovedBy = approvedBy;
            ApprovalDate = DateTime.Now;

            if (isWithDeadline)
                ComplianceLevel = StatutoryStatus.Fully_Compliance;
        }

        public void RejectStatutoryPayment(string reason, string? approvedBy)
        {
            ApprovedBy = approvedBy;
            ApprovalDate = DateTime.Now;
            Status = StatutoryStatus.Rejected;
            ReasonForRejection = reason;
        }
    }
}
