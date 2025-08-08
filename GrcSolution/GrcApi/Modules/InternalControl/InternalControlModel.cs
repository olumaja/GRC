using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.InternalControl
{
    
    public enum InternalControlStatus
    {
        Open = 1,
        Approved,
        Rejected,
        Closed,
        Pending,
        Submitted

    }

    public enum ExceptionTrackerStatus
    {       
        Not_Resolved = 1,
        Resolved,
        Deleted,
        Approved,
        Rejected,
        Pending_Approval
    }

    public class InternalControlModel : AuditEntity2
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string? Title { get; private set; }
        public int? NoOfCollaboration { get; private set; } = 0;
        public int? NoOfActionOwners { get; private set; } = 0;
        public string? IssueSummary { get; private set; }
        public int? AttachmentCount { get; private set; } = 0;
        public InternalControlStatus Status { get; private set; } = InternalControlStatus.Open;
        public string? Collaborators { get; private set; }
        public string? CollaboratorEmail { get; set; }
        public List<InternalControlAction> Actions { get; private set; }

        public static InternalControlModel Create(CreateInternalControl internalControl)
        {
            return new InternalControlModel
            {
                Title = internalControl.Title,
                IssueSummary = internalControl.IssueSummary,
                Collaborators = internalControl.Collaborators,
                CollaboratorEmail = internalControl.ContributorEmail,
                NoOfActionOwners = internalControl.NoOfActionOwners,
                NoOfCollaboration = internalControl.NoOfCollaboration
            };
        }

        public void UpdateInternalConrol(CreateInternalControl internalControl)
        {
            Title = internalControl.Title;
            IssueSummary = internalControl.IssueSummary;
            Collaborators = internalControl.Collaborators;
            CollaboratorEmail= internalControl.ContributorEmail;
            NoOfActionOwners = internalControl.NoOfActionOwners;
            NoOfCollaboration = internalControl.NoOfCollaboration;
        }

        public void UpdateAttachmentCount(int count)
        {
            AttachmentCount = count;
        }

        public void UpdateStatus(InternalControlStatus status)
        {
            Status = status;
        }
    }

    public class InternalControlAction : AuditEntity2
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid InternalControlId { get; private set; }
        public InternalControlModel InternalControl{ get; private set; }
        public string? ActionToBeResolved { get; private set; }
        public List<InternalControlActionOwner> InternalControlActionOwners { get; private set; }

        public static InternalControlAction Create(
            Guid internalControlId, string actionToBeResolved,
            List<InternalControlActionOwner> actionOwners
        )
        {
            return new InternalControlAction
            {
                InternalControlId = internalControlId,
                ActionToBeResolved = actionToBeResolved,
                InternalControlActionOwners = actionOwners
            };
        }
    }

    public class InternalControlActionOwner : AuditEntity2
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid InternalControlActionlId { get; private set; }
        public string? ActionOwner { get; private set; }
        public string? ActionOwnerEmail { get; private set; }
        public string? Unit { get; private set; }
        public InternalControlStatus ActionOwnerStatus { get; private set; } = InternalControlStatus.Pending;
        public DateTime Deadline { get; private set; }
        public string? Response { get; private set; }
        public DateTime? ResponseTime { get; private set; }
        public string? ApprovedBy { get; private set; }
        public DateTime? ApprovalDate { get; private set; }
        public string? ReasonForRejection { get; private set; } = null;
        public bool? IsReminderSent12Hrs { get; private set; } = false;
        public bool? IsReminderSent24Hrs { get; private set; } = false;
        public bool? IsReminderSent36Hrs { get; private set; } = false;
        public bool? IsReminderSent48Hrs { get; private set; } = false;
        public InternalControlAction InternalControlAction { get; private set; }

        public static InternalControlActionOwner Create(CreateInternalControlAction action)
        {
            return new InternalControlActionOwner
            {
                ActionOwner = action.ActionOwner,
                ActionOwnerEmail = action.ActionOwnerEmail,
                Unit = action.Business,
                Deadline = action.Deadline
            };
        }

        public void UpdateInternalControlActionOwner(CreateInternalControlAction action)
        {
            ActionOwner = action.ActionOwner;
            ActionOwnerEmail = action.ActionOwnerEmail;
            Unit = action.Business;
            Deadline = action.Deadline;
        }

        public void ActionOwnerResponse(string response)
        {
            Response = response;
            ResponseTime = DateTime.Now;
            ActionOwnerStatus = InternalControlStatus.Submitted;
        }

        public void ApproveInternalControl(string? approveBy)
        {
            ActionOwnerStatus = InternalControlStatus.Approved;
            ApprovedBy = approveBy;
            ApprovalDate = DateTime.Now;
        }
        public void RejectInternalControl(string reason)
        {
            ActionOwnerStatus = InternalControlStatus.Rejected;
            ReasonForRejection = reason;
        }

        public void UpdateException12HoursReminder(bool status)
        {
            IsReminderSent12Hrs = status;
        }
        public void UpdateException24HoursReminder(bool status)
        {
            IsReminderSent24Hrs = status;
        }
        public void UpdateException36HoursReminder(bool status)
        {
            IsReminderSent36Hrs = status;
        }
        public void UpdateException48HoursReminder(bool status)
        {
            IsReminderSent48Hrs = status;
        }

    }

    public class InternalControlExceptionTracker : AuditEntity2
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Exception { get; private set; }
        public string? Unit { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ControlImpact { get; private set; }
        public string? ImpactRating { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? NatureOfException { get; private set; }
        public int TransactionCount { get; private set; }
        public string? ActivityImpacted { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Recommendation { get; private set; }
        public string? ManagementResponse { get; private set; }
        public ExceptionTrackerStatus ExceptionTrackerStatus { get; private set; } = ExceptionTrackerStatus.Not_Resolved;
        public ExceptionTrackerStatus SupervisorStatus { get; private set; } = ExceptionTrackerStatus.Pending_Approval;
        public string? ResponsibleOfficer { get; private set; }
        public string? ResponsibleOfficerEmail { get; private set; }
        public string? RequesterEmail { get; private set; }
        public DateTime? Deadline { get; private set; }
        public string? ApprovedBy { get; private set; }            
        public string? ReasonForReject { get; private set; }            
        public DateTime? ApprovalDate { get; private set; }
        public bool? IsReminderSent12Hrs { get; private set; } = false;
        public bool? IsReminderSent24Hrs { get; private set; } = false;
        public bool? IsReminderSent36Hrs { get; private set; } = false;
        public bool? IsReminderSent48Hrs { get; private set; } = false;
      
        public static InternalControlExceptionTracker Create(CreateException exception)
        {
            return new InternalControlExceptionTracker
            {
                Exception = exception.Exception,
                Unit = exception.Unit, 
                ControlImpact = exception.ControlImpact, 
                ImpactRating = exception.ImpactRating,
                NatureOfException = exception.NatureOfException,
                TransactionCount = exception.TransactionCount,
                ActivityImpacted = exception.ActivityImpacted,
                ResponsibleOfficer = exception.ReponsibleOfficer,
                ResponsibleOfficerEmail = exception.ReponsibleOfficerEmail,
                Recommendation = exception.Recommendation,
                Deadline = exception.DeadLine,
                RequesterEmail = exception.RequesterEmail
            };
        }

        public void UpdateExceptionTracker(LogUpdatedInternalControlExceptionTracker exption)
        {
            Exception = exption.Exception;
            Unit = exption.Unit;
            ControlImpact = exption.ControlImpact;
            ImpactRating = exption.ImpactRating;
            NatureOfException = exption.NatureOfException;
            TransactionCount = exption.TransactionCount;
            ActivityImpacted = exption.ActivityImpacted;
            Recommendation = exption.Recommendation;
            ExceptionTrackerStatus = exption.Status;
            ResponsibleOfficer = exption.ResponsibleOfficer;
            Deadline = exption.ProposedDeadline;
        }
        public void ApproveException(string? name)
        {
            SupervisorStatus = ExceptionTrackerStatus.Approved;
            ApprovedBy = name;
            ApprovalDate = DateTime.Now;   
        }
        public void RejectException(string? comment)
        {
            SupervisorStatus = ExceptionTrackerStatus.Rejected;
            ExceptionTrackerStatus = ExceptionTrackerStatus.Rejected;
            ReasonForReject = comment;
        }
        public void UpdateStatus(UpdatedExceptionTrackerStatus update)
        {
            ManagementResponse = update.ManagementResponse;
            ExceptionTrackerStatus = update.Status;           
        }
        public void DeleteRequest()
        {
            ExceptionTrackerStatus = ExceptionTrackerStatus.Deleted;
        }

        public void UpdateException12HoursReminder(bool status)
        {
            IsReminderSent12Hrs = status;
        }
        public void UpdateException24HoursReminder(bool status)
        {
            IsReminderSent24Hrs = status;
        }
        public void UpdateException36HoursReminder(bool status)
        {
            IsReminderSent36Hrs = status;
        }
        public void UpdateException48HoursReminder(bool status)
        {
            IsReminderSent48Hrs = status;
        }
    }
}
