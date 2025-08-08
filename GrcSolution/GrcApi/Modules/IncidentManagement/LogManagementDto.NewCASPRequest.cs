using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.IncidentManagement;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace Arm.GrcApi.Modules.IncidentManagement
{
  public record NewCASPRequest(
  string EventName,
  string ResponsibleStaff,
  string SourceIPAddress,
  string SourceHostName,
  string SourceLocation,
  string SourceUserName,
  string DestinationEmailAddress,
  string SourceFileName,
  string SourceDevice,
  string ObjectIdentifier,
  string Application,
  string Observation,
  DateTime DateAlertWasGenerated,
  DateTime ProposeEndDate,
  string SecurityTool,
  string Recommendation, 
  string Status,
  string? ActionOwner,
  string? ActionOwnerEmailAddress,
  string? ActionOwnerUnit,
  IList<IFormFile> Attachments
)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a NewCASPRequest object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<NewCASPRequest> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["DateAlertWasGenerated"], out var DateAlertWasGenerated);
            DateTime.TryParse(httpContext.Request.Form["ProposeEndDate"], out var ProposeEndDate);
            return ValueTask.FromResult(
                new NewCASPRequest(
                    httpContext.Request.Form["EventName"],
                    httpContext.Request.Form["ResponsibleStaff"],
                    httpContext.Request.Form["SourceIPAddress"],
                    httpContext.Request.Form["SourceHostName"],
                    httpContext.Request.Form["SourceLocation"],
                    httpContext.Request.Form["SourceUserName"],
                    httpContext.Request.Form["DestinationEmailAddress"],
                    httpContext.Request.Form["SourceFileName"],
                    httpContext.Request.Form["SourceDevice"],
                    httpContext.Request.Form["ObjectIdentifier"],
                    httpContext.Request.Form["Application"],
                    httpContext.Request.Form["Observation"],
                    DateAlertWasGenerated,
                    ProposeEndDate,
                    httpContext.Request.Form["SecurityTool"],
                    httpContext.Request.Form["Recommendation"],
                    httpContext.Request.Form["Status"],
                    httpContext.Request.Form["ActionOwner"],
                    httpContext.Request.Form["ActionOwnerEmailAddress"],
                    httpContext.Request.Form["ActionOwnerUnit"],
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class NewCASPRequestValidator : AbstractValidator<NewCASPRequest>
    {
        public NewCASPRequestValidator()
        {
            RuleFor(e => e.EventName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ResponsibleStaff).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceLocation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceIPAddress).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceHostName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceUserName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SecurityTool).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Application).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DateAlertWasGenerated).NotEmpty();
            RuleFor(e => e.ProposeEndDate).NotEmpty();
            RuleFor(e => e.ObjectIdentifier).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceFileName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.SourceDevice).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Recommendation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Observation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.ActionOwner).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.DestinationEmailAddress).EmailAddress();
           // RuleFor(e => e.ActionOwnerEmailAddress).EmailAddress();
            RuleFor(e => e.ActionOwnerUnit).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }
    public record NewCASPReq(
      Guid LogManagementModelId,
      string EventName,
      string ResponsibleStaff,
      string SourceIPAddress,
      string SourceHostName,
      string SourceLocation,
      string SourceUserName,
      string DestinationEmailAddress,
      string SourceFileName,
      string SourceDevice,
      string ObjectIdentifier,
      string Application,
      string Observation,
      string SecurityTool     
     );
        
}
