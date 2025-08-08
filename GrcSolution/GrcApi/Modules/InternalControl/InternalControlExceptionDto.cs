using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arm.GrcApi.Modules.InternalControl
{
    public record CreateExceptionDto(
        List<InternalControlExceptionDto> CreateExceptions
    );

    public class CreateExceptionDtoValidator : AbstractValidator<CreateExceptionDto>
    {
        public CreateExceptionDtoValidator()
        {
            RuleFor(x => x.CreateExceptions).NotEmpty();
            RuleForEach(x => x.CreateExceptions).SetValidator(new InternalControlExceptionDtoValidator());
        }
    }

    public record InternalControlExceptionDto(
        string Exception,
        string BusinessUnit,
        string NatureOfException,
        string ControlImpact,
        string ImpactRating,
        int TransactionCount,
        string ActivityImpacted,
        string ReponsibleOfficer,
        string ReponsibleOfficerEmail,
        DateTime DeadLine,
        string Recommendation
    );

    public class InternalControlExceptionDtoValidator : AbstractValidator<InternalControlExceptionDto>
    {
        public InternalControlExceptionDtoValidator()
        {
            RuleFor(e => e.Exception).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.BusinessUnit).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.NatureOfException).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ControlImpact).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ImpactRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ActivityImpacted).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ReponsibleOfficer).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ReponsibleOfficerEmail).NotEmpty().EmailAddress();
            RuleFor(e => e.DeadLine).NotEmpty().GreaterThanOrEqualTo(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))).WithMessage("Deadline date cannot be earlier than today's date");
            RuleFor(e => e.Recommendation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record CreateException(
        string Exception,
        string Unit,
        string NatureOfException,
        string ControlImpact,
        string ImpactRating,
        int TransactionCount,
        string ActivityImpacted,
        string ReponsibleOfficer,
        string ReponsibleOfficerEmail,
        DateTime DeadLine,
        string Recommendation,
        string? RequesterEmail
    );

    public record ShareExceptionReport(
        DateTime DateFrom,
        DateTime DateTo,
        string? Status,
        string? ImpactRating,
        string? Unit,
        List<RecipientEmail> Emails
    );

    public class ShareExceptionReportValidator : AbstractValidator<ShareExceptionReport>
    {
        public ShareExceptionReportValidator()
        {
            RuleFor(e => e.DateTo).NotEmpty();
            RuleFor(e => e.DateFrom).NotEmpty().LessThanOrEqualTo(e => e.DateTo);
            RuleFor(e => e.Emails).NotEmpty();
            RuleForEach(e => e.Emails).SetValidator(new RecipientEmailValidator());
        }
    }

    public record RecipientEmail(string Email);

    public class RecipientEmailValidator : AbstractValidator<RecipientEmail> {
        public RecipientEmailValidator()
        {
            RuleFor(e => e.Email).NotEmpty().EmailAddress().WithMessage("Kindly enter valid email address");
        }
    }
}
