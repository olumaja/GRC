using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 09/05/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * Endpoint to Approve Compliance Regulator Payment 
  */
    public class ApproveComplianceRegulatorPaymentEndpoint
    {
        /// <summary>
        /// Endpoint to Approve Compliance Regulator Payment 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="comp"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ApproveCompliancePaymentRequest payload, IRepository<ComplianceRegulatoryPayment> comp,
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
                var getComp = comp.GetContextByConditon(x => x.Id == payload.complianceRegulatoryPaymentId && x.Status != ComplianceStatus.Approved && x.PaymentAttachmentCount > 0).FirstOrDefault();
                             
                if (getComp is null)
                {
                    return TypedResults.NotFound($"Compliance Regulatory Payment has not been confirm or not found");
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

    public record ApproveCompliancePaymentRequest(Guid complianceRegulatoryPaymentId);

    public class ApproveCompliancePaymentRequestValidation : AbstractValidator<ApproveCompliancePaymentRequest>
    {
        public ApproveCompliancePaymentRequestValidation()
        {
            RuleFor(x => x.complianceRegulatoryPaymentId).NotEmpty();
        }
    }
}
