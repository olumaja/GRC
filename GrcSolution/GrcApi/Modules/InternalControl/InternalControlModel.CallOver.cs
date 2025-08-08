using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.InternalControl
{
    public enum CallOverStatus
    {
        Pending = 1,
        Awaiting_Approval,        
        Rejected,
        Submitted,
        Saved
    }

    public class InternalControlCallOver : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Unit { get; private set; }
        public DateOnly ReportDate { get; private set; } = DateOnly.FromDateTime(DateTime.Today);
        public int NumberOfReport { get; private set; }
        public int Score { get; private set; } = 0;
        public DateOnly DueDate { get; private set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        public TimeOnly ExpectedUploadTime { get; private set; }
        public DateTime? TimeUploaded { get; private set; }
        public CallOverStatus Status { get; private set; } = CallOverStatus.Pending;
        public string? ApprovedBy { get; private set; }
        public DateTime? ApprovalDate { get; private set; }
        public string? ReasonForRejection { get; private set; }
        public string? Comment { get; private set; }
        public List<InternalControlCallOverReport> Reports { get; set; }
              
        public static InternalControlCallOver LogEmail(string unit, int numberOfReports, TimeOnly expectedUploadTime)
        {
            return new InternalControlCallOver
            {
                Unit = unit,
                NumberOfReport = numberOfReports,
                ExpectedUploadTime = expectedUploadTime,
                Status = CallOverStatus.Pending,
                TimeUploaded = DateTime.Now
            };
        }
              
        public void UpdateStatus(CallOverStatus status)
        {
            Status = status;
        }

        public void ApprovedCallOver(string approvedBy)
        {
            ApprovedBy = approvedBy;
            ApprovalDate = DateTime.Now;
            TimeUploaded = DateTime.Now;
        }

        public void Rejected(string reasonForRejection, string rejectedBy)
        {
            ReasonForRejection = reasonForRejection;
            ApprovedBy = rejectedBy;
            ApprovalDate = DateTime.Now;
        }

        public void UpdateScore(int score, string? comment = null)
        {
            Score = score;
            Comment = comment;
        }
    }

    public class InternalControlCallOverReport : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid CallOverId { get; private set; }
        public string ReportTitle { get; private set; }
        public int NumberOfAttachments { get; private set; } = 0;
        public bool IsReportDone { get; private set; } = false;
        public InternalControlCallOver CallOver { get; private set; }

        public static InternalControlCallOverReport Create(Guid callOverId, string reportTitle)
        {
            return new InternalControlCallOverReport {
                CallOverId = callOverId,
                ReportTitle = reportTitle
            };
        }

        public void UpdateNumberOfAttachment(int numberOfAttachments)
        {
            NumberOfAttachments = numberOfAttachments;
            IsReportDone = true;
        }
    }
}
