using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class RejectAuditReportEndpoint
    {
        public static async Task<IResult> HandleAsync(RejectAuditReportDto payload, IRepository<InternalAuditReport> auditReport,
           ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var getAuditReport = await auditReport.FirstOrDefaultAsync(x => x.Id == payload.AuditReportId && x.Team == payload.Team && x.Status != BusinessRiskRatingStatus.Approved);
                if (getAuditReport is null)
                {
                    return TypedResults.BadRequest("Audit Report has been previously rejected or does not exist");
                }
                getAuditReport.RejectReportStatus(payload.ReasonForRejection);
                auditReport.SaveChanges();

                return TypedResults.Ok("Audit Report Rejected Successfully");
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }

    public record RejectAuditReportDto(Guid AuditReportId, string Team, string ReasonForRejection);

    public class RejectAuditReportDtoValidation : AbstractValidator<RejectAuditReportDto>
    {
        public RejectAuditReportDtoValidation()
        {
            RuleFor(x => x.AuditReportId).NotEmpty();
            RuleFor(x => x.Team).NotEmpty()
              .Must(CharacterValidation.IsInvalidCharacter)
              .WithMessage("{PropertyName} contains one or more special characters that are not allow");
            RuleFor(x => x.ReasonForRejection).NotEmpty()
              .Must(CharacterValidation.IsInvalidCharacter)
              .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
