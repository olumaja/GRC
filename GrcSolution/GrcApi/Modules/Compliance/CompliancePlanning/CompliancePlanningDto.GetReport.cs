using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public class GetCompliancePlaningReportDto {
        public Guid ReportId { get; set; }
        public string ReportStatus { get; set; }
        public string ResponseStatus { get; set; }
        public string ReportName { get; set; }
        public string Frequency { get; set; }
        public string UnitOfInterest { get; set; }
        public string? ReasonForRejection { get; set; }
        public string LeveLStatus { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ProcessOfficer { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }

        public int AttachmentCount { get; set; }
    };

    public class OverdueComplianceRegulatoryPaymentRes
    {
        public Guid ComplianceRegulatoryPaymentId { get; set; } 
        public string? Regulator { get; set; }
        public string? BusinessEntity { get; set; }
        public string? MeansOfPaymentAmount { get; set; }
        public decimal Amount { get; set; }
        public string? ProcessOfficer { get; set; }
        public string? ContactPerson { get; set; } = null;
        public string? PaymentDetail { get; set; }
        public DateTime? DeadLine { get; set; }
        public string Status { get; set; } 
        public DateTime? DateOfPayment { get; set; } 
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    };

    public class GetCompliancePlaningReportForComplianceDto
    {
        public Guid ReportId { get; set; }
        public string ReportStatus { get; set; }
        public string ResponseStatus { get; set; }
        public string ReportName { get; set; }
        public string Frequency { get; set; }
        public DateTime Deadline { get; set; }
        public string UnitOfInterest { get; set; }
        public string? ReasonForRejection { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ProcessOfficer { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
    };

    public record GetCompliancePlaningReportByIdResponse(
        string ReportName,
        string Frequency,
        string UnitOfInterest,
        DateTime DeadLine,
        string ResponseStatus,
        string ReportStatus,
        string? ReasonForRejection,
        DateTime DateCreated,
        string? ProcessOfficer,
        string? ApprovedBy,
        DateTime? ApprovalDate,
        List<GetAttachedReportResponse>? Attachments
    );

    public class GetAttachedReportResponse {
        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public record AttachReportDto(
        Guid ComplianceReportId,
        IList<IFormFile> Attachments
    )
    { 
        /// <summary>
        /// Binds the values from the multipart form in the http request to a AttachReportsDto object and returns object
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="parameter"></param>
        /// <returns>AttachReportsDto</returns>
        public static ValueTask<AttachReportDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            Guid.TryParse(httpContext.Request.Form["ComplianceReportId"], out var ComplianceReportId);

            return ValueTask.FromResult(
                new AttachReportDto(
                    ComplianceReportId,
                    httpContext.Request.Form.Files.GetFiles("Attachments").ToList()
                ));
        }
    }

    public class AttachReportValidator : AbstractValidator<AttachReportDto>
    {
        public AttachReportValidator()
        {
            RuleFor(x => x.ComplianceReportId).NotEmpty();
            RuleFor(x => x.Attachments).NotEmpty();
        }
    }
}
