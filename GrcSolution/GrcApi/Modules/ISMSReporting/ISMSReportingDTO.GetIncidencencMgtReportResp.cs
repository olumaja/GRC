using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.ISMSReporting
{
    public record GetIncidencencMgtReportResp(
        string? SecurityIncident,
        string? SecurityArea,
        string? Severity,
        string? DescriptionOfIncident,
        string? TypeOfAsset,
        string? AssetDescription,
        string? ReportingStaff,
        DateTime? DateOfReporting,
        string? DescriptionOfActionTaken,
        string? RootCause,
        string? Impact,
        string? RecommendationToPreventFutureReoccurence,
        string? LessonLearnt,
        string? ReportingStaffComment,
        string? ReportingUnit,
        string? Status,
        DateTime? DateOfClosure,
        string? ActionOwner,
        string? ActionOwnerComment,
        string? IncidentTag,
        string? InfoSecStaffName,
        string? InfoSecRecommendation,
        DateTime? ReportingStaffCommentDate,
        DateTime? InfoSecStaffCommentDate,
        DateTime? ActionOwnerCommentDate
    );
    
}
