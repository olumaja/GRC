using Arm.GrcApi.Modules.Shared;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentValidation;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.InternalControl;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Arm.GrcApi.Modules.InternalControl
{
    public record InternalControlDto(
        string Title,
        string IssueSummary,
        List<Collaborators> Collaborator,
        List<Action> Actions
    );

    public class InternalControlDtoValidator : AbstractValidator<InternalControlDto>
    {
        public InternalControlDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.IssueSummary).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Collaborator).NotEmpty();
            RuleForEach(x => x.Collaborator).SetValidator(new CollaboratorsValidation());
            RuleFor(x => x.Actions).NotEmpty();
            RuleForEach(x => x.Actions).SetValidator(new ActionDtoValidator());
        }
    }

    public record UpdateInternalControlDto(
        Guid Id,
        string Title,
        string IssueSummary,
        List<Collaborators> Collaborator,
        List<Action> Actions
    );

    public class UpdateInternalControlDtoValidator : AbstractValidator<UpdateInternalControlDto>
    {
        public UpdateInternalControlDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.IssueSummary).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Collaborator).NotEmpty();
            RuleForEach(x => x.Collaborator).SetValidator(new CollaboratorsValidation());
            RuleFor(x => x.Actions).NotEmpty();
            RuleForEach(x => x.Actions).SetValidator(new ActionDtoValidator());
        }
    }

    public record Action(
        string ActionToBeResolved,
        List<Owner> Owners
    );

    public class ActionDtoValidator : AbstractValidator<Action>
    {
        public ActionDtoValidator()
        {
            RuleFor(x => x.ActionToBeResolved).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Owners).NotEmpty();
            RuleForEach(x => x.Owners).SetValidator(new OwnerValidator());
        }
    }

    public record Owner(
        string ActionOwnerName,
        string ActionOwnerEmail,
        string Business,
        DateTime Deadline
    );

    public class OwnerValidator : AbstractValidator<Owner>
    {
        public OwnerValidator()
        {
            RuleFor(x => x.ActionOwnerName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwnerEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.Business).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Deadline).NotEmpty().GreaterThanOrEqualTo(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))).WithMessage("Deadline date cannot be earlier than today's date");
        }
    }

    public record InternalControlAttachmentDto(Guid InternalControlId, List<IFormFile> Attachments)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a InternalControlAttachmentDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<InternalControlAttachmentDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["InternalControlId"], out var InternalControlId);

            return ValueTask.FromResult(
                new InternalControlAttachmentDto(
                    InternalControlId,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class InternalControlAttachmenValidation : AbstractValidator<InternalControlAttachmentDto> {
        public InternalControlAttachmenValidation()
        {
            RuleFor(x => x.InternalControlId).NotEmpty();
            RuleFor(x => x.Attachments).NotEmpty();
        }
    }

    public record CreateInternalControl(
        string Title,
        string IssueSummary,
        string Collaborators,
        string ContributorEmail,
        int NoOfActionOwners,
        int NoOfCollaboration
    );

    public record CreateInternalControlAction(
        //Guid InternalControlActionId,
        string ActionOwner,
        string ActionOwnerEmail,
        string Business,
        DateTime Deadline
    );

    public record Collaborators(string Name, string Email);

    public class CollaboratorsValidation : AbstractValidator<Collaborators>
    {
        public CollaboratorsValidation()
        {
            RuleFor(x => x.Name).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }

    public record InternalControlResponse(Guid Id);

    public record InternalControlActionOwnerResponse(Guid ActionOwnerId, string Response, List<IFormFile> Attachments)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a InternalControlActionOwnerResponse object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<InternalControlActionOwnerResponse> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["ActionOwnerId"], out var ActionOwnerId);

            return ValueTask.FromResult(
                new InternalControlActionOwnerResponse(
                    ActionOwnerId,
                    httpContext.Request.Form["Response"],
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class InternalControlActionOwnerResponseValidator : AbstractValidator<InternalControlActionOwnerResponse>
    {
        public InternalControlActionOwnerResponseValidator()
        {
            RuleFor(x => x.ActionOwnerId).NotEmpty();
            RuleFor(x => x.Response).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Attachments).NotEmpty();
        }
    }

    public record DeleteExceptionTrackerControlStatus(Guid Id);
    public class DeleteExceptionTrackerControlStatusValidator : AbstractValidator<DeleteExceptionTrackerControlStatus>
    {
        public DeleteExceptionTrackerControlStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
    public record UpdateExceptionTrackerControlStatus(Guid Id, string? ManagementResponse, string? Status);
   
    public class UpdateExceptionTrackerControlStatusValidator : AbstractValidator<UpdateExceptionTrackerControlStatus>
    {
        public UpdateExceptionTrackerControlStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ManagementResponse).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record UpdateInternalControlStatus(Guid Id, string Status);

    public class UpdateInternalControlStatusValidator : AbstractValidator<UpdateInternalControlStatus>
    {
        public UpdateInternalControlStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }


    public record UpdateInternalControlExceptionTracker(
        Guid ExceptionTrackerId,
        string Exception,
        string Unit,
        string ControlImpact,
        string ImpactRating,
        string NatureOfException,
        int TransactionCount,
        string ActivityImpacted,
        string Recommendation,
        string Status,
        string ResponsibleOfficer,
        string ProposedDeadline
    );
    public record LogUpdatedInternalControlExceptionTracker(
      string Exception,
      string Unit,
      string ControlImpact,
      string ImpactRating,
      string NatureOfException,
      int TransactionCount,
      string ActivityImpacted,
      string Recommendation,
      ExceptionTrackerStatus Status,
      string ResponsibleOfficer,
      DateTime ProposedDeadline
    );

    public record UpdatedExceptionTrackerStatus(
     string ManagementResponse,
     ExceptionTrackerStatus Status
    );


    public class UpdateInternalControlExceptionTrackerValidator : AbstractValidator<UpdateInternalControlExceptionTracker>
    {
        public UpdateInternalControlExceptionTrackerValidator()
        {
            RuleFor(x => x.ExceptionTrackerId).NotEmpty();
            RuleFor(x => x.Exception).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Unit).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ControlImpact).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ImpactRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.NatureOfException).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.TransactionCount).NotEmpty();
            RuleFor(x => x.ActivityImpacted).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Recommendation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ResponsibleOfficer).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ProposedDeadline).NotEmpty();
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class GetExceptionTrackerByIdResp
    {
        public Guid ExceptionTrackerId { get; set; }
        public string? Exception { get; set; }
        public string? Unit { get; set; }
        public string? ControlImpact { get; set; }
        public string? ImpactRating { get; set; }
        public string? NatureOfException { get; set; }
        public int TransactionCount { get; set; }
        public string? ActivityImpacted { get; set; }
        public string? Recommendation { get; set; }
        public string? ManagementResponse { get; set; }
        public string? Status { get; set; }
        public string? ResponsibleOfficer { get; set; }
        public DateTime? ProposedDeadline { get; set; }
        public string? ApprovedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ReasonForReject { get; set; }
        public DateTime? DateCreated { get; set; }
    }
    public class GetControlDashboardByIdResp 
    {
        public Guid InternalControlDashboardId { get; set; }
        public string ActivityIntervals { get; set; }
        public string Activity { get; set; }
        public string Comment { get; set; }
        public DateTime DateInitiated { get; set; }
        public DateTime CompletionDate { get; set; }
        public string ActionOwner { get; set; }
        public string ActionOwnerEmail { get; set; }
        public string? Remarks { get; set; }
        public int? NumberOfTransactionsReviewed { get; set; }
        public string Status { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }

    }

    public record PaginatedControlDashboardListResp(PaginationMeta PaginationMeta, List<GetControlDashboardListResp> Response);
    public record GetControlDashboardListResp
    (
        Guid InternalControlDashboardId,
        string ActivityIntervals,
        string Activity,
        string Comment,
        DateTime DateInitiated,
        DateTime CompletionDate,
        string ActionOwner,
        string ActionOwnerEmail,
        string? Remarks,
        int? NumberOfTransactionsReviewed,
        string Status,
        string? CreatedBy,
        string? ModifiedBy
    );

    public record UpdateControlDashboardStatusReq(
        InternalControlDashboardStatus Status,
        string Remark,
        int NumberOfTransaction
    );

    public record UpdateControlDashboardStatus(Guid Id, string Status, string Remark, int NumberOfTransaction);

    public class UpdateControlDashboardStatusValidator : AbstractValidator<UpdateControlDashboardStatus>
    {
        public UpdateControlDashboardStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.NumberOfTransaction).NotNull();
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Remark).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
    public record UpdateInternalControlDashBoardDto
    (
      InternalControlDashboardActivityInterval ActivityIntervals,
      string Activity,
      DateTime CompletionDate,
      string ActionOwner,
      string ActionOwnerEmail,
      string Comment
     );

    //public class UpdateInternalControlDashBoardTaskDto
    //{
    //    [Required(ErrorMessage = "Internal Control Dashboard ID is required.")]
    //    public Guid InternalControlDashboardId { get; set; }

    //    [Required(ErrorMessage = "Activity Interval is required.")]
    //    public string ActivityInterval { get; set; }

    //    [Required(ErrorMessage = "Activity is required.")]
    //    public string Activity { get; set; }

    //    [Required(ErrorMessage = "Completion Date is required.")]
    //    public string CompletionDate { get; set; }

    //    [Required(ErrorMessage = "Action Owner is required.")]
    //    public string ActionOwner { get; set; }

    //    [Required(ErrorMessage = "Comment is required.")]
    //    public string Comment { get; set; }
    //}


    public record UpdateInternalControlDashBoardTaskDto
    (
      Guid InternalControlDashboardId,
      string ActivityInterval,
      string Activity,
      DateTime CompletionDate,
      string ActionOwner,
      string ActionOwnerEmail,
      string Comment
     );

    public class UpdateInternalControlDashBoardTaskDtoValidator : AbstractValidator<UpdateInternalControlDashBoardTaskDto>
    {
        public UpdateInternalControlDashBoardTaskDtoValidator()
        {
            RuleFor(x => x.InternalControlDashboardId).NotEmpty();
            RuleFor(x => x.ActivityInterval).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Activity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Comment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwner).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwnerEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.CompletionDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Today).WithMessage("Completion date cannot be earlier than today's date");          
        }
    }


    public record UpdateInternalControlDashBoard
    (
      InternalControlDashboardActivityInterval ActivityInterval,
      string Activity,
      DateTime CompletionDate,
      string ActionOwner,
      string ActionOwnerEmail,
      string Comment,
      DateTime? NotificationDate
     );

}
