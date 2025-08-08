using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.Shared;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    public enum ComplianceStatus
    {
        Not_Available = 1,
        Available,
        Pending,
        Rejected,
        Approved,
        Non_Compliant,
        Partially_Compliant,
        Fully_Compliant, 
        Paid,
        Submited,
        Not_Paid,
        Approved_Paid, 
        Rejected_Paid,
        Awaiting
    }
    public class ComplianceCalendar : BaseEntity
    {
        public string Frequency { get; set; }
        public string FirmToSubmit { get; set; }
        public string? ReasonForRejection { get; set; }
        public int? AttachmentCount { get; set; }
        public DateTime DeadLine { get; set; }    
        public ComplianceStatus ResponseStatus { get; set; } = ComplianceStatus.Not_Available;
        public ComplianceStatus ReportStatus { get; set; } = ComplianceStatus.Pending;
        public ComplianceStatus LevelStatus { get; set; } = ComplianceStatus.Non_Compliant;
        public string? ProcessOfficer { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? UpdatedBy { get; set; }

        public static ComplianceCalendar CreateEmail(string nameOfReport, string frequency, string firmToSubmit, DateTime deadLine)
        {
            return new ComplianceCalendar
            {
                Name = nameOfReport,
                Frequency = frequency,
                FirmToSubmit = firmToSubmit,
                DeadLine = deadLine
            };
        }

        public void UpdateAttachmentCount(int attachmentCount)
        {
            AttachmentCount = attachmentCount;
        }
        public void ResponseStatusAfterUploadingReport(bool isWithinDeadline)
        {
            ResponseStatus = ComplianceStatus.Available;
            ReportStatus = ComplianceStatus.Submited;

            if (isWithinDeadline)
                LevelStatus = ComplianceStatus.Partially_Compliant;
        }
        public void ApproveReportStatus(bool isWithinDeadline, string? approvedBy)
        {
            ReportStatus = ComplianceStatus.Approved;
            ApprovedBy = approvedBy;
            ApprovalDate = DateTime.Now;

            if(isWithinDeadline)
                LevelStatus = ComplianceStatus.Fully_Compliant;
        }
        public void RejectReportStatus(string reason, string? approvedBy)
        {
            ReasonForRejection = reason;
            ReportStatus = ComplianceStatus.Rejected;
            ApprovedBy = approvedBy;
            ApprovalDate = DateTime.Now;
        }

        public void AddProcessOfficer(string? processOfficer)
        {
            ProcessOfficer = processOfficer;
            UpdatedBy = processOfficer;
        }
      
    }
}
