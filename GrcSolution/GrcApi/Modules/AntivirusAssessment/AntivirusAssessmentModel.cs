using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using System.ComponentModel;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public enum AntivirusStatus
    {
        [Description("PENDING APPROVAL")] Pending = 1,
        [Description("RESOLVED")] Resolved,
        [Description("UNRESOLVED")] UnResolved,
        [Description("AWAITING APPROVAL")] Awaiting_Approval,
        [Description("COMPLETED")] Completed,
        [Description("APPROVED")] Approve,
        [Description("REJECTED")] Rejected,
        [Description("AWAITING VALIDATION")] Awaiting_Validation
    }
    public class AntivirusAssessmentModel : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string? AssessmentType { get; private set; }
        public string? TitleOfAssessment { get; private set; }
        public string? ActionOwner { get; private set; }
        public string? ActionOwnerEmail { get; private set; }
        public string? ActionOwnerUnit { get; private set; }
        public DateTime? ProposeEndDate { get; private set; }
        public string? ReasonForRejection { get; private set; }
        public string? ApprovedBy { get; private set; }
        public DateTime? DateApproved { get; private set; }
        public string? RequesterEmailAddress { get; private set; }
        public AntivirusStatus AntivirusStatus { get; private set; } = AntivirusStatus.Pending;
        public AntivirusStatus InfosecFeedbackStatus { get; private set; } = AntivirusStatus.Pending;
        public AntivirusStatus InactiveSensorsStatus { get; private set; } = AntivirusStatus.Pending;
        public AntivirusStatus ReducedFunctionalityModeStatus { get; private set; } = AntivirusStatus.Pending;
        public List<InactiveSensors> InactiveSensors { get; private set; }
        public List<ReducedFunctionalityMode> ReducedFunctionalityMode { get; private set; }

        public static AntivirusAssessmentModel Create(string assessmentType, string titleOfAssessment, string requesterEmailAddress)
        {
            return new AntivirusAssessmentModel
            {
                AssessmentType = assessmentType,
                TitleOfAssessment = titleOfAssessment,
                RequesterEmailAddress = requesterEmailAddress
            };
        }

        public void InfoSecAssignActionOwner(string actionOwner, string actionOwnerEmail, string actionOwnerUnit, DateTime proposeEndDate)
        {
            ActionOwner = actionOwner;
            ActionOwnerEmail = actionOwnerEmail;
            ActionOwnerUnit = actionOwnerUnit;
            ProposeEndDate = proposeEndDate;
        }
        public void SetInactiveSensorsInfosecFeedbackStatus(AntivirusStatus newStatus, string reason)
        {
            InactiveSensorsStatus = newStatus;
            InfosecFeedbackStatus = newStatus;
            AntivirusStatus = newStatus;
            ReasonForRejection = reason;
        }
       
        public void ReduceFunctionalityStatusAfterActionOwnerResponse()
        {
            ReducedFunctionalityModeStatus = AntivirusStatus.Awaiting_Validation;
            AntivirusStatus = AntivirusStatus.Awaiting_Validation;
        }
        public void InactiveSensorsStatusAfterActionOwnerResponse()
        {
            InactiveSensorsStatus = AntivirusStatus.Awaiting_Validation;
            AntivirusStatus = AntivirusStatus.Awaiting_Validation;
        }
        public void UpdateApproval(string name)
        {
            ApprovedBy = name;
            DateApproved = DateTime.Now;
        }

    }
}
