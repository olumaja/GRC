using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    public record PaginatedInternalControlExceptionResponse(
        PaginationMeta PaginationMeta,
        List<InternalControlExceptionResponse> Response
    );

    public record InternalControlExceptionResponse(
        Guid ExceptionTrackerId,
        string Exception,
        string Unit,
        string NatureOfException,
        string ControlImpact,
        string ImpactRating,
        int TransactionCount,
        string ActivityImpacted,
        string Recommendation,
        string ResponsibleOfficer,
        DateTime? Deadline,
        string ManagementResponse,
        string Status,
        string SupervisorStatus,
        DateTime DateCreated,
        DateTime? ModifiedDate
    );

    public record InternalControlExceptionReport(
        string Exception,
        string Unit,
        string NatureOfException,
        string ControlImpact,
        string ImpactRating,
        int TransactionCount,
        string ActivityImpacted,
        string Recommendation,
        string ResponsibleOfficer,
        DateTime? Deadline,
        string ManagementResponse,
        string Status,
        DateTime DateCreated,
        DateTime? ModifiedDate
    );

    public record InternalControlTaskReportReponse
    (
        PaginationMeta PaginationMeta,
         int TotalTask,
         int CompletedTask,
         int TaskInProgress,
         int TaskOnHold,
         List<InternalControlTaskReport> Reports
    );

    public record InternalControlTaskReport(
        string Activity,
        string ActivityInterval,
        DateTime DateInitiated,
        DateTime ProposeCompletionDate,
        DateTime? DateModified,
        DateTime? DateCompleted,
        string ActionOwner,
        int? NumberOfTransaction,
        string? Remark,
        string Comment,
        string Status
    );
    public record InternalControlTaskReportPDF(
       string Activity,
       string ActionOwner,
       string Status,
       DateTime ProposeCompletionDate,
       DateTime? DateCompleted
    );
}
