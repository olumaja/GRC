using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public enum ActionStatus
    {
        Open = 1,
        Work_In_Progress,
        Closed,
       
    }
    public enum SecurityAreaCategory
    {
        Availability = 1,
        Integrity,
        Confidentiality
    }
    public enum SeverityCategory
    {
        Low = 1,
        Medium,
        High
    }
    public enum IncidentTagCategory
    {
        False_Positive = 1,
        True_Positive
                
    }
    public class IncidentManagementLog : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        [Column(TypeName = "nvarchar(MAX)")]
        public string? SecurityIncident { get; private set; }
        public SecurityAreaCategory SecurityArea { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? SecurityAreas { get; private set; }
        public SeverityCategory Severity { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DescriptionOfIncident { get; private set; }
        public string? TypeOfAsset { get; private set; }
        public string? ReportingUnit { get; private set; }
        public string? ActionOwnerUnit { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AssetDescription { get; private set; }
        public string? ReportingStaff { get; private set; }
        public string? ReportingStaffEmailAddress { get; private set; }
        public DateTime? DateOfReporting { get; private set; } = DateTime.Now;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DescriptionOfActionTaken { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? RootCause { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Impact { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? RecommendationToPreventFutureReoccurence { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? LessonLearnt { get; private set; }
        public ActionStatus Status { get; private set; }
        public DateTime? DateOfClosure { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReportingStaffComment { get; private set; }
        public string? ActionOwnerName { get; private set; }
        public string? ActionOwnerEmailAddress { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ActionOwnerComment { get; private set; }
        public IncidentTagCategory IncidentTag { get; private set; } 
        public string? InfoSecStaffName { get; private set; }
        public string? InfoSecStaffEmailAddress { get; private set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? InfoSecRecommendation { get; private set; }
        public DateTime? ReportingStaffCommentDate { get; private set; }
        public DateTime? InfoSecStaffCommentDate { get; private set; }
        public DateTime? ActionOwnerCommentDate { get; private set; }

        public static IncidentManagementLog Create(LogIncidence request)
        {
            return new IncidentManagementLog
            {
                SecurityIncident = request.SecurityIncident,
                SecurityAreas = request.SecurityArea,
                Severity = request.Severity,
                DescriptionOfIncident = request.DescriptionOfIncident,
                TypeOfAsset = request.TypeOfAsset,
                AssetDescription = request.AssetDescription,
                DateOfReporting = request.DateOfIncidence,
                DescriptionOfActionTaken = request.DescriptionOfActionTaken,
                RootCause = request.RootCause,
                Impact = request.Impact,
                RecommendationToPreventFutureReoccurence = request.RecommendationToPreventFutureReoccurence,
                LessonLearnt = request.LessonLearnt,
                Status = request.Status,
                DateOfClosure = request.DateOfClosure,
                ReportingStaffComment = request.Comment,
                ReportingStaff = request.ReportingStaff,
                ReportingUnit = request.ReportingUnit,
                ReportingStaffEmailAddress = request.ReportingStaffEmailAddress,
                ReportingStaffCommentDate = DateTime.Now
            };
        }

        public void ActionOwnerResponse(ActionStatus status, string? comment, string? actionOwner, string? actionOwnerEmailAddress)
        {
            Status = status;
            ActionOwnerComment = comment;
            ActionOwnerName = actionOwner;
            ActionOwnerEmailAddress = actionOwnerEmailAddress;
            ActionOwnerCommentDate = DateTime.Now;
        }
        public void AssignIncidenceToActionOwner(IncidentTagCategory incidentTag, ActionStatus status, string? recommendation, string? actionOwner, string? actionOwnerEmailAddress, string infoSecStaffName, string infoSecStaffEmailAddress, string? actionOwnerUnit)
        {
            IncidentTag = incidentTag;
            Status = status;
            InfoSecRecommendation = recommendation;
            ActionOwnerName = actionOwner;
            ActionOwnerEmailAddress = actionOwnerEmailAddress;
            InfoSecStaffName = infoSecStaffName;
            InfoSecStaffEmailAddress = infoSecStaffEmailAddress;
            InfoSecStaffCommentDate = DateTime.Now;
            ActionOwnerUnit = actionOwnerUnit;
        }
               
    }
}
