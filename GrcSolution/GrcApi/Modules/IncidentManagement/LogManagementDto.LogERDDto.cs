using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.IncidentManagement;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public record LogERDDto(
        string EventName,
        string EventDescription,
        string EventID,
        string SourceIPAddress,
        string DestinationIPAddress,
        string DestinationHostName,
        string DestinationUserName,
        string SecurityTools,
        DateTime DateAlertGenerated,
        DateTime ProposeEndDate,
        string ActionTakenByCS,
        string Technique,
        string FileHash,
        string Recommendation,
        string Observation,
        string? ActionOwner,
        string? ActionOwnerEmail,
        string? ActionOwnerUnit,
        string Severity,
        string DestinationFQDN,
        string SourceOrFileName,
        string Status,
        IList<IFormFile> Attachments
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a LogDAMDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<LogERDDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["DateAlertGenerated"], out var DateAlertGenerated);
            DateTime.TryParse(httpContext.Request.Form["ProposeEndDate"], out var ProposeEndDate);

            return ValueTask.FromResult(
                new LogERDDto(
                    httpContext.Request.Form["EventName"],
                    httpContext.Request.Form["EventDescription"],
                    httpContext.Request.Form["EventID"],
                    httpContext.Request.Form["SourceIPAddress"],
                    httpContext.Request.Form["DestinationIPAddress"],
                    httpContext.Request.Form["DestinationHostName"],
                    httpContext.Request.Form["DestinationUserName"],
                    httpContext.Request.Form["SecurityTools"],
                    DateAlertGenerated,
                    ProposeEndDate,
                    httpContext.Request.Form["ActionTakenByCS"],
                    httpContext.Request.Form["Technique"],
                    httpContext.Request.Form["FileHash"],
                    httpContext.Request.Form["Recommendation"],
                    httpContext.Request.Form["Observation"],
                    httpContext.Request.Form["ActionOwner"],
                    httpContext.Request.Form["ActionOwnerEmail"],
                    httpContext.Request.Form["ActionOwnerUnit"],
                    httpContext.Request.Form["Severity"],
                    httpContext.Request.Form["DestinationFQDN"],
                    httpContext.Request.Form["SourceOrFileName"],
                    httpContext.Request.Form["Status"],
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class LogERDDtoValidator : AbstractValidator<LogERDDto>
    {
        public LogERDDtoValidator()
        {
            RuleFor(e => e.EventName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.EventDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.EventID).NotEmpty();
            RuleFor(e => e.SourceIPAddress).NotEmpty();
            RuleFor(e => e.ActionTakenByCS).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Technique).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DestinationIPAddress).NotEmpty();
            RuleFor(e => e.FileHash).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DestinationHostName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DestinationUserName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SecurityTools).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DateAlertGenerated).NotEmpty();
            RuleFor(e => e.ProposeEndDate).NotEmpty();
            RuleFor(e => e.Recommendation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Observation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ActionOwner).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(e => e.ActionOwnerEmail).EmailAddress();
            RuleFor(e => e.ActionOwnerUnit).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Severity).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DestinationFQDN).NotEmpty();
            RuleFor(e => e.SourceOrFileName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
    public record LogEDRRequest(
        Guid LogManagementId,
        string EventName,
        string EventDescription,
        string EventID,
        string ConfigurationDetails,
        string SourceIPAddress,
        string Severity,
        string DestinationFQDN,
        string SourceOrFileName,
        string DestinationIPAddress,
        string DestinationHostName,
        string DestinationUserName,
        string SecurityTools,
        string Observation,
        string ActionTakenByCS,
        string Technique,
        string FileHash
    );
}
