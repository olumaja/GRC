using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public record LogManagementDto
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
        string MaliciousRepution,
        string SecurityTools,
        DateTime DateAlertGenerated,
        DateTime ProposeEndDate,
        string Observation,
        string Recommendation,
        string? ActionOwner,
        string? ActionOwnerEmail,
        string? ActionOwnerUnit,
        string Status,
        IList<IFormFile> Attachments
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a LogManagementDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<LogManagementDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["DateAlertGenerated"], out var DateAlertGenerated);
            DateTime.TryParse(httpContext.Request.Form["ProposeEndDate"], out var ProposeEndDate);

            return ValueTask.FromResult(
                new LogManagementDto(
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
                    httpContext.Request.Form["MaliciousRepution"],
                    httpContext.Request.Form["SecurityTools"],
                    DateAlertGenerated,
                    ProposeEndDate,
                    httpContext.Request.Form["Observation"],
                    httpContext.Request.Form["Recommendation"],
                    httpContext.Request.Form["ActionOwner"],
                    httpContext.Request.Form["ActionOwnerEmail"],
                    httpContext.Request.Form["ActionOwnerUnit"],
                    httpContext.Request.Form["Status"],
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class LogManagementDtoValidator : AbstractValidator<LogManagementDto>
    {
        public LogManagementDtoValidator()
        {
            RuleFor(e => e.EventName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.EventDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.EventID).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ConfigurationObject).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ConfigurationDetails).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceIPAddress).NotEmpty();
            RuleFor(e => e.SourcePort).NotEmpty();
            RuleFor(e => e.SourceHostName).NotEmpty(); 
            RuleFor(e => e.SourceFQDN).NotEmpty(); 
            RuleFor(e => e.SourceUserName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DestinationIPAddress).NotEmpty(); 
            RuleFor(e => e.DestinationPort).NotEmpty();
            RuleFor(e => e.DestinationHostName).NotEmpty(); 
            RuleFor(e => e.DestinationFQDN).NotEmpty(); 
            RuleFor(e => e.DestinationUserName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.NATIPAddress).NotEmpty();
            RuleFor(e => e.NATPort).NotEmpty();
            RuleFor(e => e.MaliciousRepution).NotEmpty();
            RuleFor(e => e.SecurityTools).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DateAlertGenerated).NotEmpty();
            RuleFor(e => e.ProposeEndDate).NotEmpty();
            RuleFor(e => e.Observation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Recommendation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ActionOwner).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(e => e.ActionOwnerEmail).EmailAddress();
            RuleFor(e => e.ActionOwnerUnit).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
    public record SIEMLogRequest(
        Guid LogMgtId, string EventName, string EventDescription, string ConfigurationObject, string ConfigurationDetail,
        string SourceIPAddress, string SourcePort, string SourceFQDN, string SourceHostName, string SourceUserName, string DestinationIpAddress,
        string DestinationPort, string DestinationHostName, string DestinationFQDN, string DestinationUserName, string NATIPAddress, string NATPort,
        string MaliciousReputation, string EventId, string Observation, string SecurityTool
    );
}
