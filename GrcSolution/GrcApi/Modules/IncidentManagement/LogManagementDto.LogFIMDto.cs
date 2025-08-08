using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace GrcApi.Modules.IncidentManagement
{
    public record LogFIMDto
    (
        string EventName,
        string EventDescription,
        string EventID,
        string ConfigurationObject,
        string ConfigurationDetails,
        string SourceIPAddress,
        string SourcePort,
        string SourceHostName,
        string SourceFQDN,
        string SourceUserName,
        string DestinationIPAddress,
        string DestinationPort,
        string DestinationHostName,
        string DestinationFQDN,
        string DestinationUserName,
        string NATIPAddress,
        string NATPort,
        string SecurityTools,
        DateTime DateAlertGenerated,
        DateTime ProposeEndDate,
        string Recommendation,
        string Observation,
        string? ActionOwner,
        string? ActionOwnerEmail,
        string? ActionOwnerUnit,
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
        public static ValueTask<LogFIMDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["DateAlertGenerated"], out var DateAlertGenerated);
            DateTime.TryParse(httpContext.Request.Form["ProposeEndDate"], out var ProposeEndDate);

            return ValueTask.FromResult(
                new LogFIMDto(
                    httpContext.Request.Form["EventName"],
                    httpContext.Request.Form["EventDescription"],
                    httpContext.Request.Form["EventID"],
                    httpContext.Request.Form["ConfigurationObject"],
                    httpContext.Request.Form["ConfigurationDetails"],
                    httpContext.Request.Form["SourceIPAddress"],
                    httpContext.Request.Form["SourcePort"],
                    httpContext.Request.Form["SourceHostName"],
                    httpContext.Request.Form["SourceFQDN"],
                    httpContext.Request.Form["SourceUserName"],
                    httpContext.Request.Form["DestinationIPAddress"],
                    httpContext.Request.Form["DestinationPort"],
                    httpContext.Request.Form["DestinationHostName"],
                    httpContext.Request.Form["DestinationFQDN"],
                    httpContext.Request.Form["DestinationUserName"],
                    httpContext.Request.Form["NATIPAddress"],
                    httpContext.Request.Form["NATPort"],
                    httpContext.Request.Form["SecurityTools"],
                    DateAlertGenerated,
                    ProposeEndDate,
                    httpContext.Request.Form["Recommendation"],
                    httpContext.Request.Form["Observation"],
                    httpContext.Request.Form["ActionOwner"],
                    httpContext.Request.Form["ActionOwnerEmail"],
                    httpContext.Request.Form["ActionOwnerUnit"],
                    httpContext.Request.Form["Status"],
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class LogFIMDtoValidator : AbstractValidator<LogFIMDto>
    {
        public LogFIMDtoValidator()
        {
            RuleFor(e => e.EventName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.EventDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.EventID).NotEmpty();
            RuleFor(e => e.ConfigurationObject).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ConfigurationDetails).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceIPAddress).NotEmpty();
            RuleFor(e => e.SourcePort).NotEmpty();
            RuleFor(e => e.SourceHostName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceFQDN).NotEmpty();
            RuleFor(e => e.SourceUserName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DestinationIPAddress).NotEmpty();
            RuleFor(e => e.DestinationPort).NotEmpty();
            RuleFor(e => e.DestinationHostName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DestinationFQDN).NotEmpty();
            RuleFor(e => e.DestinationUserName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.NATIPAddress).NotEmpty();
            RuleFor(e => e.NATPort).NotEmpty();
            RuleFor(e => e.SecurityTools).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DateAlertGenerated).NotEmpty();
            RuleFor(e => e.ProposeEndDate).NotEmpty();
            RuleFor(e => e.Recommendation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Observation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ActionOwner).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ActionOwnerUnit).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
    public record LogFIMRequest(
        Guid LogManagementId,
        string EventName,
        string EventDescription,
        string EventID,
        string ConfigurationObject,
        string ConfigurationDetails,
        string SourceIPAddress,
        string SourcePort,
        string SourceHostName,
        string SourceFQDN,
        string SourceUserName,
        string DestinationIPAddress,
        string DestinationPort,
        string DestinationHostName,
        string DestinationFQDN,
        string DestinationUserName,
        string NATIPAddress,
        string NATPort,
        string MaliciousRepution,
        string SecurityTools,
        string Observation
    );
}
