using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    public record CallOverResponse
    (
        PaginationMeta PaginationMeta,
        List<CallOver> Response
    );

    public record CallOver(
        Guid CallOverId,
        DateOnly ReportDate,
        int NumberOfReport,
        DateOnly DueDate,
        TimeOnly ExpectedUploadTime,
        DateOnly? DateUploaded,
        string Status,
        string? Comment
    );

    public record ReviewCallOverResponse(
        PaginationMeta PaginationMeta,
        List<ReviewCallOver> Response
    );

    public record ReviewCallOver(
        Guid CallOverId,
        DateOnly ReportDate,
        string Unit,
        DateOnly DueDate,
        TimeOnly ExpectedUploadTime,
        DateTime? TimeUpload,
        int Score,
        string Status,
        string? Comment,
        string? CreatedBy,
        bool IsOverDue
    );

    public record ReportCallOverResponse(
        PaginationMeta PaginationMeta,
        List<ReportCallOver> Response
    );

    public record ReportCallOverResponseV2(
       List<ReportCallOver> Response
   );

    public record ReportCallOver(
        Guid CallOverId,
        DateOnly ReportDate,
        string Unit,
        DateOnly DueDate,
        TimeOnly? TimeUpload,
        int Score,
        string? Comment,
        string? CreatedBy,
        bool IsOverDue
    );
    public class ReportCallOverV2
    {
        public Guid CallOverId { get; set; }
        public DateOnly ReportDate { get; set; }
        public string Unit { get; set; }
        public DateOnly DueDate { get; set; }
        public TimeOnly? TimeUpload { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsOverDue { get; set; }
    }

    public record CallOverReportResponse(Guid CallOverId, string Status, string? ReasonForRjection, string? Comment, string? CreatedBy, List<CallOverReport> Reports);

    public record CallOverReport(Guid CallOverReportId, string ReportTitle, int NumberOfAttachment);

    public record CallOverAttachedReportResponse(Guid CallOverReportId, string Name, List<CallOverAttachedReport> Attachments);

    public record CallOverAttachedReport(Guid DocumentId, string Name, DateTime DateCreated);

    public record ViewCallOverScoreResponse(
        Guid CalloverId, List<CallOverAttachedReport> Attachments, int CallOverDoneScore, int CalloverAsWhenDue, int TotalScore, 
        bool ErrorSpotted, string? ReasonForRejection, string Status, string? Comment, string? CreatedBy
    );
}
