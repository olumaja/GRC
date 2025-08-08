using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Bibliography;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using Serilog;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 09/05/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * Endpoint to Approve Compliance Report 
  */
    public class ApproveComplianceReportEndpoint
    {
        /// <summary>
        /// Endpoint to Approve Compliance Report 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="comp"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ApproveComplianceReportRequest payload, IRepository<ComplianceCalendar> comp,
            ICurrentUserService currentUserService, Serilog.ILogger logger
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                bool isDeadline = false;
                var getComp = comp.GetContextByConditon(x => x.Id == payload.complianceReportId && x.ReportStatus != ComplianceStatus.Approved).FirstOrDefault();
                          
                //var getComp = await comp.GetByIdAsync(payload.complianceReportId);

                if (getComp is null)
                {
                    return TypedResults.NotFound($"Compliance report not found");
                }

                if (getComp.DeadLine >= DateTime.Now)
                    isDeadline = true;

                getComp.ApproveReportStatus(isDeadline, currentUserService.CurrentUserFullName);
                comp.SaveChanges();
                return TypedResults.Ok("Approved successfully");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return TypedResults.Problem(ex.Message);
            }
        }
    }

    public record ApproveComplianceReportRequest(Guid complianceReportId);

    public class ApproveComplianceReportRequestValidation : AbstractValidator<ApproveComplianceReportRequest>
    {
        public ApproveComplianceReportRequestValidation()
        {
            RuleFor(x => x.complianceReportId).NotEmpty();
        }
    }
}
