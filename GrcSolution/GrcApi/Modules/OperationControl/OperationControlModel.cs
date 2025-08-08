using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.OperationControl
{
    public enum ExceptionStatus
    {
        Open = 1,
        Closed,
        Submitted,
        Rejected,
        Approved,
        Approved_As_Observation,
        Approved_As_Exception,
        Resolved,
        Not_Resolved
    }
    public enum ExceptionCategory
    {
        Minor = 1,
        Medium,
        Major
    }

    public class OperationControl : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string OperationActivity { get; private set; }
        public string? TransactionCallOverType { get; private set; }
        public string ExceptionDescription { get; private set; }
        public string ActionPoint { get; private set; }
        public string ActionOwner { get; private set; }
        public string ActionOwnerEmail { get; private set; }
        public string Unit { get; private set; }
        public ExceptionStatus Status { get; private set; }
        public ExceptionCategory ExceptionCategory { get; private set; }
        public DateTime CompletionDate { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; private set; }
        public DateTime? TransactionDate { get; private set; }
        public decimal? TransactionAmount { get; private set; }
        public DateTime? DateResolved { get; private set; }
        public ExceptionStatus ResolutionStatus { get; private set; } = ExceptionStatus.Open;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; private set; }
        public string? ApprovalProcess { get; private set; }
        public string? SupervisorName { get; private set; }
        public string? ApprovalName { get; private set; }
        public string? ReAssignedOfficer { get; private set; }
        public string? ActionOwnerResponse { get; private set; } = null;
        public bool? IsExceptionForActionOwner { get; private set; } = true;
        public bool? IsExceptionReAssignBySupervisor { get; private set; } = false;
        public bool? IsApprovedAsObservation { get; private set; } = false;
        public bool? IsApprovedAsException { get; private set; } = false;
        public DateTime? ActionOwnerResponseDate { get; private set; }
        public DateTime? ReAssignedDate { get; private set; }
        public DateTime? DateApproved { get; private set; }
        public string? RequestedEmailAddress { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ActionOwnerComment { get; private set; }
        public string? ReassignOfficerEmailAddress { get; private set; } = null;
        public bool IsReminderSent1 { get; private set; } = false;
        public bool IsReminderSent2 { get; private set; } = false;
        public bool IsReminderSent3 { get; private set; } = false;
        public static OperationControl Create(CreateOperationControl request)
        {
            return new OperationControl
            {
                OperationActivity = request.OperationActivity,
                TransactionCallOverType = request.TransactionCallOverType,
                ExceptionDescription = request.ExceptionDescription,
                ActionPoint = request.ActionPoint,
                ActionOwner = request.ActionOwner,
                ActionOwnerEmail = request.ActionOwnerEmail.ToLower(),
                Unit = request.Unit,
                Status = ExceptionStatus.Open, 
                ExceptionCategory = request.ExceptionCategory,
                CompletionDate = request.CompletionDate,
                RequestedEmailAddress = request.RequestedEmailAddress.ToLower(),
                ResolutionStatus = ExceptionStatus.Open
            };
        }
        public void ApproveAsObservation(string? approvalName, string? approvalProcess)
        {
            Status = ExceptionStatus.Approved;
            DateApproved = DateTime.Now;
            ApprovalName = approvalName;
            ResolutionStatus = ExceptionStatus.Approved_As_Observation;
            ApprovalProcess = approvalProcess;
        }

        public void ApproveAsException(string? approvalName, string? approvalProcess)
        {
            Status = ExceptionStatus.Approved;
            DateApproved = DateTime.Now;
            ApprovalName = approvalName;
            ResolutionStatus = ExceptionStatus.Approved_As_Exception;
            ApprovalProcess = approvalProcess;
        }

        public void RejectOperationException(string reason, string requesterName)
        {
            ReasonForRejection = reason;
            Status = ExceptionStatus.Rejected;
            DateApproved = DateTime.Now;
            ResolutionStatus = ExceptionStatus.Rejected;
            ApprovalName = requesterName;
        }

        public void UpdateException(EditCreateOperationControl request)
        {

        }
        public void UpdateException(string? operationActivity, string? transactionCallOverType, string? exceptionDescription, string? actionPoint, string? actionOwner, string? actionOwnerEmail, string? unit, ExceptionCategory exceptionCategory, DateTime completionDate)
        {
            OperationActivity = operationActivity;
            TransactionCallOverType = transactionCallOverType;
            ExceptionDescription = exceptionDescription;
            ActionPoint = actionPoint;
            ActionOwner = actionOwner;
            ActionOwnerEmail = actionOwnerEmail.ToLower();
            Unit = unit;
            ExceptionCategory = exceptionCategory;
            CompletionDate = completionDate;
        }

        public void UpdateIsReminderSent1(bool status)
        {
            IsReminderSent1 = status;
        }
        public void UpdateIsReminderSent2(bool status)
        {
            IsReminderSent2 = status;
        }
        public void UpdateIsReminderSent3(bool status)
        {
            IsReminderSent3 = status;
        }
        public void UpdateActionownerResponse(string? comment, DateTime? transactionDate, decimal? transactionAmount, DateTime? dateResolved)
        {
            Comment = comment;
            TransactionDate = transactionDate;
            TransactionAmount = transactionAmount;
            DateResolved = dateResolved;
            ResolutionStatus = ExceptionStatus.Submitted;
            ActionOwnerComment = comment;
            ActionOwnerResponseDate = DateTime.Now;
            Status = ExceptionStatus.Submitted;
                      
        }
        public void ExceptionReAssignedOfficer(string? officerName, string? supervisorname, string? reassignOfficerEmailAddress)
        {
            ReAssignedOfficer = officerName;
            SupervisorName = supervisorname;
            ReassignOfficerEmailAddress = reassignOfficerEmailAddress.ToLower();
            ReAssignedDate = DateTime.Now;
        }
    }
}
