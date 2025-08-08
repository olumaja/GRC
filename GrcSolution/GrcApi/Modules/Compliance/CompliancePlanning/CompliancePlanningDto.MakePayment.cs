using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public record MakePaymentDto(
        Guid ComplianceRegulatoryPaymentId,
        decimal AmountPaid,
        string TransactionReference,
        DateTime DateOfPayment,
        IList<IFormFile> Attachments
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a MakePaymentDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<MakePaymentDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["ComplianceRegulatoryPaymentId"], out var ComplianceRegulatoryPaymentId);
            decimal.TryParse(httpContext.Request.Form["AmountPaid"], out var AmountPaid);
            DateTime.TryParse(httpContext.Request.Form["DateOfPayment"], out var DateOfPayment);

            return ValueTask.FromResult(
                new MakePaymentDto(
                    ComplianceRegulatoryPaymentId,
                    AmountPaid,
                    httpContext.Request.Form["TransactionReference"],
                    DateOfPayment,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class MakePaymentDtoValidator : AbstractValidator<MakePaymentDto>
    {
        public MakePaymentDtoValidator()
        {
            RuleFor(x => x.ComplianceRegulatoryPaymentId).NotEmpty();
            RuleFor(x => x.TransactionReference).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.Attachments).NotEmpty();
            RuleFor(x => x.DateOfPayment).NotEmpty();
            //RuleFor(x => x.DateOfPayment).GreaterThanOrEqualTo(DateTime.Now).NotEmpty();
        }
    }
}
