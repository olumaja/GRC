using FluentValidation;
using System.Reflection;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public record NewFindingExcelUpload(Guid internalAuditReportId, IFormFile findings)
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a RuleExcelUpload object and returns object
        /// </summary>     
        public static ValueTask<NewFindingExcelUpload> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["internalAuditReportId"], out var internalAuditReportId);

            return ValueTask.FromResult(new NewFindingExcelUpload(internalAuditReportId, httpContext.Request.Form.Files.GetFile("findings")));
        }
    }
    public class NewFindingExcelUploadValidator : AbstractValidator<NewFindingExcelUpload>
    {
        public NewFindingExcelUploadValidator()
        {
            RuleFor(model => model.internalAuditReportId).NotEmpty();
            RuleFor(model => model.findings).NotEmpty();

        }
    }

}
