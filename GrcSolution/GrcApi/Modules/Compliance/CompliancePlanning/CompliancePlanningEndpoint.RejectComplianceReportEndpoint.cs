using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 09/05/2024
   * Development Group: Audit plan Risk Assessment - GRCTools
   * Endpoint to Reject Compliance Report 
   */
    public class RejectComplianceReportEndpoint
    {
        /// <summary>
        /// Endpoint to Reject Compliance Report 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="comp"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(RejectComplianceReportRequest payload, IRepository<ComplianceCalendar> comp,
             ClaimsPrincipal user, ICurrentUserService currentUserService, Serilog.ILogger logger
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var year = DateTime.Now.Year;
                var getComp = comp.GetContextByConditon(x => x.Id == payload.complianceReportId && x.ReportStatus != ComplianceStatus.Approved && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getComp == null)
                {
                    return TypedResults.NotFound($"Compliance report not found");
                }

                getComp.RejectReportStatus(payload.Reason, currentUserService.CurrentUserFullName);
                comp.SaveChanges();
                return TypedResults.Ok("Rejected successfully");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return TypedResults.Problem(ex.Message);
            }
        }
    }

    public record RejectComplianceReportRequest(Guid complianceReportId, string Reason);

    public class RejectComplianceReportRequestValidation : AbstractValidator<RejectComplianceReportRequest>
    {
        public RejectComplianceReportRequestValidation()
        {
            RuleFor(x => x.complianceReportId).NotEmpty();
            RuleFor(x => x.Reason).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
