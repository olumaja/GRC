using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain.DocumentManagement;
using Arm.GrcTool.Domain.RiskEvent;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateRiskEventDto(
        DateOnly DateOfIdentification,
            DateOnly DateOfOcurrence,
            string Description,
            decimal EstimatedLoss,
            Guid LocationId,
            Guid DepartmentId,
            Guid UnitId,
            IList<IFormFile> Attachments,
            string ReportedByUsername
            //string RiskEventDescription
        )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a CreateRiskEventDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>CreateRiskEventDto</returns>
        public static ValueTask<CreateRiskEventDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            DateOnly.TryParse(httpContext.Request.Form["DateOfIdentification"], out var DateOfIdentification);
            DateOnly.TryParse(httpContext.Request.Form["DateOfOcurrence"], out var DateOfOcurrence);
            decimal.TryParse(httpContext.Request.Form["EstimatedLoss"], out var EstimatedLoss);
            Guid.TryParse(httpContext.Request.Form["LocationId"], out var LocationId);
            Guid.TryParse(httpContext.Request.Form["DepartmentId"], out var DepartmentId);
            Guid.TryParse(httpContext.Request.Form["UnitId"], out var UnitId);

            // return the CreateRiskEventDto
            return ValueTask.FromResult(
                new CreateRiskEventDto(
                    DateOfIdentification,
                    DateOfOcurrence,
                    httpContext.Request.Form["Description"],
                    EstimatedLoss,
                    LocationId,
                    DepartmentId,
                    UnitId,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList(),
                    httpContext.Request.Form["ReportedByUsername"]
                    //httpContext.Request.Form["RiskEventDescription"]
                )
            );
        }
    }

        public record RiskEventDto(
            DateOnly DateOfIdentification,
            DateOnly DateOfOcurrence,
            string Description,
            decimal EstimatedLoss,
            Guid LocationId,
            string Location,
            Guid DepartmentId,
            string Department,
            Guid UnitId,
            string Unit,
            IList<DocumentDto> Attachments,
            string ReportedByUsername,
            string RiskEventDescription,
            Guid Id,
            DateTime CreatedDate,
            RiskEvent.Status Status,
            string Requester
        );

    public record RiskEventResponse(
        int TodaysTotalRisk,
        int TotalsRiskThisMonth,
        int TotalsRisk,
        IList<RiskEventDto> RiskEvents
    );

    public class CreateRiskEventDtoValidator : AbstractValidator<CreateRiskEventDto>
    {
        public CreateRiskEventDtoValidator()
        {
            RuleFor(model => model.DateOfIdentification).NotEmpty();
            RuleFor(model => model.DateOfOcurrence).NotEmpty();
            RuleFor(model => model.Description).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(model => model.EstimatedLoss).NotEmpty();
            RuleFor(model => model.LocationId).NotEmpty();
            RuleFor(model => model.DepartmentId).NotEmpty();
            RuleFor(model => model.UnitId).NotEmpty();
            RuleFor(model => model.ReportedByUsername).NotEmpty()
                .Must(CharacterValidation.IsInvalidUserName)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(model => model.RiskEventDescription).NotEmpty()
            //    .Must(CharacterValidation.IsInvalidCharacter)
            //    .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

}
