using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace Arm.GrcApi.Modules.IncidentManagement
{
   public record NewPAMRequest(
   string EventName,
   string IncidentDescription,
   string CorrectiveActionCarriedOut,
   string Status,
   DateTime ProposeEndDate,
   DateTime DateCarriedOut,   
   string? ActionOwner,
   string? ActionOwnerEmailAddress,
   string? ActionOwnerUnit,
   IList<IFormFile> Attachments
 )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a NewPAMRequest object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<NewPAMRequest> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateTime.TryParse(httpContext.Request.Form["ProposeEndDate"], out var ProposeEndDate);
            DateTime.TryParse(httpContext.Request.Form["DateCarriedOut"], out var DateCarriedOut);

            return ValueTask.FromResult(
                new NewPAMRequest(
                    httpContext.Request.Form["EventName"],
                    httpContext.Request.Form["IncidentDescription"],
                    httpContext.Request.Form["CorrectiveActionCarriedOut"],
                    httpContext.Request.Form["Status"],
                    ProposeEndDate,
                    DateCarriedOut,
                    httpContext.Request.Form["ActionOwner"],
                    httpContext.Request.Form["ActionOwnerEmailAddress"],
                    httpContext.Request.Form["ActionOwnerUnit"],
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class NewPAMRequestValidator : AbstractValidator<NewPAMRequest>
    {
        public NewPAMRequestValidator()
        {
            RuleFor(x => x.EventName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.CorrectiveActionCarriedOut).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.IncidentDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.DateCarriedOut).NotEmpty();
            RuleFor(x => x.ProposeEndDate).NotEmpty();
            RuleFor(x => x.ActionOwner).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(x => x.ActionOwnerEmailAddress).EmailAddress();
            RuleFor(x => x.ActionOwnerUnit).Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);

        }
    }

    public record NewPAMReq(
     Guid LogManagementModelId,
     string EventName,
     string EventDescription,
     string CorrectiveActionCarriedOut,
     DateTime DateCarriedOut
     );
}
