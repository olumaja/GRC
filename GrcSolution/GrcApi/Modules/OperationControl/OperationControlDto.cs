using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Arm.GrcApi.Modules.OperationControl
{
    public record UpdateOperationControlDto(
        Guid OperationId,
        string OperationActivity,
        string TransactionCallOverType,
        string ExceptionDescription,
        string ActionPoint,
        string ActionOwner,
        string ActionOwnerEmail,
        string Unit,
        string ExceptionCategory,
        DateTime CompletionDate,
        List<IFormFile> Attachments
    )
    {
        public static ValueTask<UpdateOperationControlDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["CompletionDate"], out var Completion);
            Guid.TryParse(httpContext.Request.Form["OperationId"], out var OperationId);

            return ValueTask.FromResult(
                new UpdateOperationControlDto(
                    OperationId,
                    httpContext.Request.Form["OperationActivity"],
                    httpContext.Request.Form["TransactionCallOverType"],
                    httpContext.Request.Form["ExceptionDescription"],
                    httpContext.Request.Form["ActionPoint"],
                    httpContext.Request.Form["ActionOwner"],
                    httpContext.Request.Form["ActionOwnerEmail"],
                    httpContext.Request.Form["Unit"],
                    httpContext.Request.Form["ExceptionCategory"],
                    Completion,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class UpdateOperationControlDtoValidator : AbstractValidator<UpdateOperationControlDto>
    {
        public UpdateOperationControlDtoValidator()
        {
            RuleFor(x => x.OperationId).NotEmpty();
            RuleFor(x => x.OperationActivity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.TransactionCallOverType).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ExceptionDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionPoint).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwner).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwnerEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.Unit).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ExceptionCategory).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.CompletionDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
        }
    }

    public record OperationControlDto(
        string OperationActivity,
        string TransactionCallOverType,
        string ExceptionDescription,
        string ActionPoint,
        string ActionOwner,
        string ActionOwnerEmail,
        string Unit,
        string ExceptionCategory,
        DateTime CompletionDate,
        List<IFormFile> Attachments
    )
    {
        public static ValueTask<OperationControlDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["CompletionDate"], out var Completion);

            return ValueTask.FromResult(
                new OperationControlDto(
                    httpContext.Request.Form["OperationActivity"],
                    httpContext.Request.Form["TransactionCallOverType"],
                    httpContext.Request.Form["ExceptionDescription"],
                    httpContext.Request.Form["ActionPoint"],
                    httpContext.Request.Form["ActionOwner"],
                    httpContext.Request.Form["ActionOwnerEmail"],
                    httpContext.Request.Form["Unit"],
                    httpContext.Request.Form["ExceptionCategory"],
                    Completion,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class OperationControlDtoValidator : AbstractValidator<OperationControlDto>
    {
        public OperationControlDtoValidator()
        {
            RuleFor(x => x.OperationActivity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.TransactionCallOverType).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ExceptionDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionPoint).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwner).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwnerEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.Unit).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ExceptionCategory).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.CompletionDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
        }
    }
    public record UpdateActionOwnerResponse(
        DateTime? TransactionDate,
        decimal? TransactionAmount,
        DateTime? DateResolved,
        string? Comment,
        string? ActionOwnerResponse,
        ExceptionStatus ResolutionStatus,
        DateTime? ActionOwnerResponseDate,
        ExceptionStatus Status
    );


    public record CreateOperationControl(
        string OperationActivity,
        string TransactionCallOverType,
        string ExceptionDescription,
        string ActionPoint,
        string ActionOwner,
        string ActionOwnerEmail,
        string Unit,
        ExceptionCategory ExceptionCategory,
        DateTime CompletionDate,
        string RequestedEmailAddress
    );

    public record EditCreateOperationControl(
        string OperationActivity,
        string TransactionCallOverType,
        string ExceptionDescription,
        string ActionPoint,
        string ActionOwner,
        string ActionOwnerEmail,
        string Unit,
        ExceptionStatus ExceptionStatus,
        ExceptionCategory ExceptionCategory,
        DateTime CompletionDate        
    );


    public record OperationControlResponse(Guid Id);

    public record PaginatedGetExceptionsResp(PaginationMeta PaginationMeta, List<GetOperationExceptionsResp> Response);
    public class GetOperationExceptionsResp
    {
        public Guid OpearationExceptionId { get; set; }
        public DateTime? DateRaised { get; set; }
        public string? Unit { get; set; }
        public string? ExceptionDescription { get; set; }
        public string? ActionPoint { get; set; }
        public string? Loggedby { get; set; }
        public string? ActionOwner { get; set; }
        public string? OperationActivity { get; set; }
        public string ExceptionCategory { get; set; }
        public string TransactionCallOverType { get; set; }
        public string ResolutionStatus { get; set; }
        public DateTime ProposedCompletionDate { get; set; }
        public DateTime? DateResolved { get; set; }
        public string? ReassignedTo { get; set; }
    }
   
    public record GetOperationExceptionsByIdResp
    (
        Guid OpearationExceptionId,
        DateTime? DateRaised,
        string? OperationActivity,
        string? Unit,
        string? Actionowner,
        string? ActionOwnerEmail,
        string? ExceptionDescription,
        string? ActionPoint,
        string? Loggedby,
        string? LoggedbyEmailAddress,
        string? TransactionCallOverType,
        string? ExceptionCategory,
        DateTime? ProposedCompletionDate,
        DateTime? DateResolved,
        string? ActionOwnerResponse,
        DateTime? ActionOwnerResponseDate,
        string? ReAssignedOfficer,
        string? ApprovalProcess,
        DateTime? ReAssignedDate,
        string? ApprovalName,
        string? SupervisorName,
        string? ReasonForRejection,
        decimal? TransactionAmount,
        DateTime? TransactionDate,
        string? ResolutionStatusForActionOwner,
        string? ResolutionStatus,
        string? Comment,
        List<GetAttachedReportResponse> Attachments,
        List<GetAttachedReportResponse> ActionOwnerAttachments
    );

    public record UpdateActionownerReq(
        Guid OperationExceptionId,
        DateTime? TransactionDate,
        decimal? TransactionAmount,
        DateTime? DateResolved,
        string Comment,
        List<IFormFile> Attachments
    )
    
    {
        public static ValueTask<UpdateActionownerReq> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["TransactionDate"], out var TransactionDate);
            DateTime.TryParse(httpContext.Request.Form["DateResolved"], out var DateResolved);
            decimal.TryParse(httpContext.Request.Form["TransactionAmount"], out var TransactionAmount);
            Guid.TryParse(httpContext.Request.Form["OperationExceptionId"], out var OperationExceptionId);

            return ValueTask.FromResult(
                new UpdateActionownerReq(
                    OperationExceptionId,
                    TransactionDate,
                    TransactionAmount,
                    DateResolved,
                   httpContext.Request.Form["Comment"],                 
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class UpdateActionownerReqValidator : AbstractValidator<UpdateActionownerReq>
    {
        public UpdateActionownerReqValidator()
        {
            RuleFor(x => x.OperationExceptionId).NotEmpty();
            RuleFor(x => x.TransactionDate).NotEmpty();
            RuleFor(x => x.TransactionAmount).NotEmpty();
            RuleFor(x => x.DateResolved).NotEmpty();                    
            RuleFor(x => x.Comment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);            
        }
    }

    public record ExceptionRecordResponse(PaginationMeta PaginationMeta, List<ExceptionReport> reports);
    public record ExceptionReport(Guid OperationControlId,
        string BusinessUnit, string OperationalActivity, string ActionOwner, string ExceptionDescription, string ExceptionCategory,
        DateOnly DateRaised, DateOnly? DateClosed, DateOnly DueDate, int DaysOverDue,
        string LoggedBy, string ReassignedTo, string Status
    );
    public record ExceptionReportDownload(
       string ExceptionCategory, DateOnly DateRaised, DateOnly? DateClosed, DateOnly DueDate, int DaysOverDue, string LoggedBy, string Status,
       string ActionOwner, string ActionOwnerResponse
   );
    public record ExceptionReportExcelDownload(
      string ExceptionDescription, string ExceptionCategory, DateOnly DateRaised, DateOnly? DateClosed, DateOnly DueDate, int DaysOverDue, string LoggedBy, string ReassignedTo, string ActionOwner, string ActionOwnerResponse, string Status
      
  );

    public record ConsolidatedAuditFindingDownload(
      string? ReviewType, DateTime? DateFindingRaised, string? DetailedFindings, string? AuditArea, string? Business, string? Level1, string? Level2,
      DateTime? RevisedDueDate, string? Recommendation, string? ImpactRating, string? WorkStream, string? ReportingQuater, DateTime? ActionDueDate, string? UpdatedComment,
      string? ManagmentResponseAsAtTimeOfEngagement, string? DescriptionOfFinding, string? ActionOwner, string? EngagementName, string? Unit, string? Entity, string? OPRStatus,
      string? StatusLevel, string? Status, string? DueDay, string PriorYearFinding, int CurrentYearFinding, bool FindingExpectedToBeClose, int FindingRaisedYear

  );

    
}
