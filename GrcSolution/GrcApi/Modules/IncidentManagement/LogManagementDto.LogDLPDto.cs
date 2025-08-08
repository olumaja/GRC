using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace GrcApi.Modules.IncidentManagement
{
    public record LogDLPDto
    (
        string DLPPolicy,
        string DLPRuleMatched,
        string DLPRuleAction,
        string ActionTaken,
        string ResponsibleStaff,
        string? ActionOwner,
        string? ActionOwnerEmail,
        string? ActionOwnerUnit,
        string Status,
        DateTime DateAlertWasGenerated,
        DateTime ProposedEndDate,
        IList<IFormFile> Attachments
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a LogDLPDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<LogDLPDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["DateAlertWasGenerated"], out var DateAlertWasGenerated);
            DateTime.TryParse(httpContext.Request.Form["ProposedEndDate"], out var ProposedEndDate);

            return ValueTask.FromResult(
                new LogDLPDto(
                    httpContext.Request.Form["DLPPolicy"],
                    httpContext.Request.Form["DLPRuleMatched"],
                    httpContext.Request.Form["DLPRuleAction"],
                    httpContext.Request.Form["ActionTaken"],
                    httpContext.Request.Form["ResponsibleStaff"],
                    httpContext.Request.Form["ActionOwner"],
                    httpContext.Request.Form["ActionOwnerEmail"],
                    httpContext.Request.Form["ActionOwnerUnit"],
                    httpContext.Request.Form["Status"],
                    DateAlertWasGenerated,
                    ProposedEndDate,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class LogDLPDtoValidator : AbstractValidator<LogDLPDto>
    {
        public LogDLPDtoValidator()
        {
            RuleFor(l => l.DLPPolicy).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(l => l.DLPRuleMatched).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(l => l.DLPRuleMatched).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(l => l.ActionTaken).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(l => l.ResponsibleStaff).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(l => l.ActionOwner).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
           // RuleFor(l => l.ActionOwnerEmail).EmailAddress();
            RuleFor(l => l.ActionOwnerUnit).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(l => l.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(l => l.ProposedEndDate).NotEmpty();
            RuleFor(l => l.DateAlertWasGenerated).NotEmpty();
        }
    }

    public record LogDLPRequest
    (
        Guid LogManagementId,
        string DLPPolicy,
        string DLPRuleMatched,
        string DLPRuleAction,
        string ActionTaken,
        string ResponsibleStaff
    );
}
