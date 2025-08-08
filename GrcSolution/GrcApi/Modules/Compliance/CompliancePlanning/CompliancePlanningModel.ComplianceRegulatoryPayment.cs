using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    public class ComplianceRegulatoryPayment : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string? Regulator { get; private set; }
        public string? BusinessEntity { get; private set; }
        public string? MeansOfPaymentAmount { get; private set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountPaid { get; set; } = 0;
        public string? ProcessOfficer { get; private set; }
        public string? ContactPerson { get; private set; } = null;
        public string? PaymentDetail { get; private set; }
        public string? TransactionReference { get; private set; } = null;
        public string? ReasonForRejection { get; private set; } = null;
        public int? PaymentAttachmentCount { get; private set; } = 0;
        public DateTime? DateOfPayment { get; private set; }
        public DateTime? DeadLine { get; private set; }
        public ComplianceStatus Status { get; private set; } = ComplianceStatus.Non_Compliant;
        public ComplianceStatus ComplianceLevel { get; private set; } = ComplianceStatus.Non_Compliant;
        public string? Initiator { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public static ComplianceRegulatoryPayment InitiatePayment(InitiateRegulatorPaymentDto req, string? initiator = null)
        {
            return new ComplianceRegulatoryPayment
            {
                Regulator = req.Regulator,
                DeadLine = req.DeadLine,
                MeansOfPaymentAmount = req.MeansOfPaymentAmount,
                Amount = req.Amount,
                ProcessOfficer = req.ProcessOfficer,
                ContactPerson = req.ProcessOfficer,
                PaymentDetail = req.PaymentDetail,
                BusinessEntity = req.BusinessEntity,
                Status = ComplianceStatus.Not_Paid,
                Initiator = initiator,
                LastUpdatedBy = initiator
            };
        }

        public void UpdateComplianceRegulatorPayment(UpdatePaymentReq request, string? updatedBy)
        {
            Regulator = request.Regulator;
            DeadLine = request.DeadLine;
            MeansOfPaymentAmount = request.MeansOfPaymentAmount;
            Amount = request.Amount;
            ProcessOfficer = request.ProcessOfficer;
            ContactPerson = request.ProcessOfficer;
            PaymentDetail = request.PaymentDetail;
            BusinessEntity = request.BusinessEntity;
            LastUpdatedBy = updatedBy;
        }

        public void UpdateAttachmentCount(int attachmentCount)
        {
            PaymentAttachmentCount = attachmentCount;
        }

        public void UpdateComplianceStatusAfterSubmit(bool isWithinDealine)
        {
            Status = ComplianceStatus.Awaiting;

            if (isWithinDealine)
                ComplianceLevel = ComplianceStatus.Partially_Compliant;
        }

        public void PaymentTransactionDetails(decimal amountPaid, string transactionReference, DateTime dateOfPayment, string? processOfficer)
        {
            AmountPaid = amountPaid;
            TransactionReference = transactionReference;
            DateOfPayment = dateOfPayment;
            ProcessOfficer = processOfficer;
            LastUpdatedBy = processOfficer;
        }

        public void ApproveReportStatus(bool isWithinDeadline, string? approvedBy)
        {
            Status = ComplianceStatus.Approved;
            ApprovedBy = approvedBy;
            ApprovalDate = DateTime.Now;

            if (isWithinDeadline)
                ComplianceLevel = ComplianceStatus.Fully_Compliant;
        }
        public void RejectPaymentStatus(string reason, string? approvedBy)
        {
            ApprovedBy = approvedBy;
            ApprovalDate = DateTime.Now;
            ReasonForRejection = reason;
            Status = ComplianceStatus.Rejected;
        }
    }

    public record UpdatePaymentReq(
        string Regulator,
        string BusinessEntity,
        DateTime? DeadLine,
        string PaymentDetail,
        string MeansOfPaymentAmount,
        decimal Amount,
        string ProcessOfficer
    );
}
