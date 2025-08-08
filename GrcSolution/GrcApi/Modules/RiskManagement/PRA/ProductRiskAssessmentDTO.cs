using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Net.Mail;
using System.Reflection;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{

    public record ProductRiskAssessmentDTO(Guid BusinessId, Guid DepartmentId, Guid UnitId, string ProductName, string ProductDescription, IFormFile AttachDocument)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a ProductRiskAssessmentDTO object and returns object
        /// </summary>     
        public static ValueTask<ProductRiskAssessmentDTO> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            //Guid.TryParse(httpContext.Request.Form["TestResultAttachmentId"], out var TestResultAttachmentId);
            Guid.TryParse(httpContext.Request.Form["BusinessId"], out var BusinessId);
            Guid.TryParse(httpContext.Request.Form["DepartmentId"], out var DepartmentId);
            Guid.TryParse(httpContext.Request.Form["UnitId"], out var UnitId);

            // return the CreateRiskEventDto
            return ValueTask.FromResult(new ProductRiskAssessmentDTO(
                   BusinessId,
                   DepartmentId,
                   UnitId,
                   httpContext.Request.Form["ProductName"],
                   httpContext.Request.Form["ProductDescription"],
                   httpContext.Request.Form.Files.GetFile("AttachDocument")

                ));
        }

    }
    public class ProductRiskAssessmentDTOValidator : AbstractValidator<ProductRiskAssessmentDTO>
    {
        public ProductRiskAssessmentDTOValidator()
        {
            RuleFor(model => model.ProductName).NotEmpty();
            RuleFor(model => model.BusinessId).NotEmpty();
            RuleFor(model => model.AttachDocument).NotEmpty();
            RuleFor(model => model.DepartmentId).NotEmpty();
            RuleFor(model => model.UnitId).NotEmpty();
            RuleFor(model => model.ProductDescription).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);

        }
    }

    public record ProductRiskAssessmentResponse
    {
        public Guid ProductRiskAssessmentId { get; init; }
        public string ProductName { get; init; }
        public Guid BusinessId { get; init; }
        public Guid DepartmentId { get; init; }
        public Guid UnitId { get; init; }
        public string ProductDescription { get; init; }
        public Guid DocumentAttachId { get; init; }
        public PRAStatus Status { get; init; }
        public PRAStage Stage { get; init; }
        //public string EmailAddress { get; init; }
    }


}
