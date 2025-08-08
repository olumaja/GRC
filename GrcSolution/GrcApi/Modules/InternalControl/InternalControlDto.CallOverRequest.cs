using Arm.GrcApi.Modules.InternalControl;
using FluentValidation;
using System.Reflection;

namespace Arm.GrcApi.Modules.InternalControl
{
    public record SaveCallOverAttachmentDto(Guid CallOverReportId,List<IFormFile> Attachments)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a InternalControlAttachmentDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>MakePaymentDto</returns>
        public static ValueTask<SaveCallOverAttachmentDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["CallOverReportId"], out var CallOverReportId);

            return ValueTask.FromResult(
                new SaveCallOverAttachmentDto(
                    CallOverReportId,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
            ));
        }
    }

    public class SaveCallOverAttachmentValidator : AbstractValidator<SaveCallOverAttachmentDto>
    {
        public SaveCallOverAttachmentValidator()
        {
            RuleFor(x => x.CallOverReportId).NotEmpty();
            RuleFor(x => x.Attachments).NotEmpty();
        }
    }

    public record SubmitCallOverDto(Guid CallOverId);

    public class SubmitCallOverValidator : AbstractValidator<SubmitCallOverDto>
    {
        public SubmitCallOverValidator()
        {
            RuleFor(x => x.CallOverId).NotEmpty();
        }
    }

    public record ScoreCallOverDto(Guid CalloverId, int CallOverDoneScore, int CalloverAsWhenDue, bool IsErrorSpotted, string Comment);

    public class ScoreCallOverDtoValidator : AbstractValidator<ScoreCallOverDto>
    {
        public ScoreCallOverDtoValidator()
        {
            RuleFor(x => x.CalloverId).NotEmpty();
            RuleFor(x => x.CallOverDoneScore).NotNull();
            RuleFor(x => x.CalloverAsWhenDue).NotNull();
            RuleFor(x => x.IsErrorSpotted).NotNull();
        }
    }
}
