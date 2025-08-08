using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateProcessInherentRiskControlRiskRatingDto(
        Guid ProcessInherentRiskControlId,
         string TestResult,
            IFormFile TestResultAttachment,
             string ColourEffectiveness,
             string ResidualRisks,
            int ResidualRiskRating,
             string ResidualRiskLevel,
             string CorrectiveActions,
             string ActionOwnerUserName,
            DateOnly TimeLine
        )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a CreateRiskEventDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>CreateRiskEventDto</returns>
        public static ValueTask<CreateProcessInherentRiskControlRiskRatingDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["ProcessInherentRiskControlId"], out var ProcessInherentRiskControlId);
            //decimal.TryParse(httpContext.Request.Form["EstimatedLossInNaira"], out var EstimatedLossInNaira);
            Guid.TryParse(httpContext.Request.Form["TestResultAttachmentId"], out var TestResultAttachmentId);
            int.TryParse(httpContext.Request.Form["ResidualRiskRating"], out var ResidualRiskRating);
            DateOnly.TryParse(httpContext.Request.Form["TimeLine"], out var TimeLine);

            // return the CreateRiskEventDto
            return ValueTask.FromResult(
                new CreateProcessInherentRiskControlRiskRatingDto(
                    ProcessInherentRiskControlId,
                    //EstimatedLossInNaira,
                    httpContext.Request.Form["TestResult"],
                    httpContext.Request.Form.Files.GetFile("TestResultAttachment"),
                    httpContext.Request.Form["ColourEffectiveness"],
                    httpContext.Request.Form["ResidualRisks"],
                    ResidualRiskRating,
                    httpContext.Request.Form["ResidualRiskLevel"],
                    httpContext.Request.Form["CorrectiveActions"],
                    httpContext.Request.Form["ActionOwnerUserName"],
                    TimeLine
                )
            );
        }

        public class CreateProcessInherentRiskControlRiskRatingDtoValidator : AbstractValidator<CreateProcessInherentRiskControlRiskRatingDto>
        {
            public CreateProcessInherentRiskControlRiskRatingDtoValidator()
            {
                RuleFor(model => model.ProcessInherentRiskControlId).NotEmpty();
                RuleFor(model => model.TestResult).NotEmpty();
                RuleFor(model => model.TestResultAttachment).NotEmpty();
                RuleFor(model => model.ColourEffectiveness).NotEmpty();
                RuleFor(model => model.ResidualRisks).NotEmpty();
                //RuleFor(model => model.ResidualRiskRating).NotEmpty();
                RuleFor(model => model.ResidualRiskLevel).NotEmpty();
                RuleFor(model => model.CorrectiveActions).NotEmpty();
                RuleFor(model => model.ActionOwnerUserName).NotEmpty().EmailAddress();
                RuleFor(model => model.TimeLine).NotEmpty();
            }
        }
    }
}
