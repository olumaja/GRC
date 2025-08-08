using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public record AntivirusAssessmentFileUploadReq(string TitleOfAssessment, IFormFile inactiveSensorsfile, IFormFile reducedFunctionalityModefile)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a AntivirusAssessmentFileUploadReq object and returns object
        /// </summary>     
        public static ValueTask<AntivirusAssessmentFileUploadReq> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            return ValueTask.FromResult(new AntivirusAssessmentFileUploadReq(
                   httpContext.Request.Form["TitleOfAssessment"],
                   httpContext.Request.Form.Files.GetFile("inactiveSensorsfile"),
                   httpContext.Request.Form.Files.GetFile("reducedFunctionalityModefile")
                ));
        }

    }

    public class AntivirusAssessmentFileUploadReqValidator : AbstractValidator<AntivirusAssessmentFileUploadReq>
    {
        public AntivirusAssessmentFileUploadReqValidator()
        {
            RuleFor(e => e.TitleOfAssessment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.inactiveSensorsfile).NotEmpty();
            RuleFor(model => model.reducedFunctionalityModefile).NotEmpty();

        }
    }

    public record UpdateInactivesensorsDto(
        Guid InactiveSensorsId, string? ActionownerComment, string? Status, IFormFile Attachment
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a UpdateInactivesensorsDto object and returns object
        /// </summary>     
        public static ValueTask<UpdateInactivesensorsDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            var inactiveSensorsId = Guid.Parse(httpContext.Request.Form["InactiveSensorsId"]);

            return ValueTask.FromResult(new UpdateInactivesensorsDto(
                   inactiveSensorsId,
                   httpContext.Request.Form["ActionownerComment"],
                   httpContext.Request.Form["Status"],
                   httpContext.Request.Form.Files.GetFile("Attachment")
            ));
        }
    }

    public class UpdateInactivesensorsDtoValidator : AbstractValidator<UpdateInactivesensorsDto>
    {
        public UpdateInactivesensorsDtoValidator()
        {
            RuleFor(r => r.InactiveSensorsId).NotEmpty();
            RuleFor(r => r.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record UpdateInactivesensor(string ActionownerComment, AntivirusStatus Status);
    
    public record UpdateReduceFunctionalityDto(
        Guid ReducedFunctionalityModeId, string ActionownerComment, string Status, IFormFile Attachment
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a UpdateReduceFunctionalityDto object and returns object
        /// </summary>     
        public static ValueTask<UpdateReduceFunctionalityDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            var reducedFunctionalityModeId = Guid.Parse(httpContext.Request.Form["ReducedFunctionalityModeId"]);

            return ValueTask.FromResult(new UpdateReduceFunctionalityDto(
                   reducedFunctionalityModeId,
                   httpContext.Request.Form["ActionownerComment"],
                   httpContext.Request.Form["Status"],
                   httpContext.Request.Form.Files.GetFile("Attachment")
            ));
        }
    }

    public class UpdateUpdateReduceFunctionalityDtoValidator : AbstractValidator<UpdateReduceFunctionalityDto>
    {
        public UpdateUpdateReduceFunctionalityDtoValidator()
        {
            RuleFor(r => r.ReducedFunctionalityModeId).NotEmpty();
            RuleFor(r => r.ActionownerComment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record UpdateReduceFunctionality(string ActionownerComment, AntivirusStatus Status);
}
