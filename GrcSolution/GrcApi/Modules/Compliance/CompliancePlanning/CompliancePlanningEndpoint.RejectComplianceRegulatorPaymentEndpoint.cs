using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 09/05/2024
     * Development Group: Audit plan Risk Assessment - GRCTools
     * Endpoint to Reject Compliance regulatory payment 
     */
    public class RejectComplianceRegulatorPaymentEndpoint
    {
        /// <summary>
        /// Endpoint to Reject Compliance regulatory payment  
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="comp"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(RejectComplianceRegulatoryPaymentRequest payload, IRepository<ComplianceRegulatoryPayment> comp,
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
                var getComp = comp.GetContextByConditon(x => x.Id == payload.complianceRegulatoryPaymentId && x.Status != ComplianceStatus.Approved && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getComp == null)
                {
                    return TypedResults.NotFound($"Compliance regulatory payment was not found");
                }

                getComp.RejectPaymentStatus(payload.Reason, currentUserService.CurrentUserFullName);
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

    public record RejectComplianceRegulatoryPaymentRequest(Guid complianceRegulatoryPaymentId, string Reason);

    public class RejectComplianceRegulatoryPaymentRequestValidation : AbstractValidator<RejectComplianceRegulatoryPaymentRequest>
    {
        public RejectComplianceRegulatoryPaymentRequestValidation()
        {
            RuleFor(x => x.complianceRegulatoryPaymentId).NotEmpty();
            RuleFor(x => x.Reason).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage("{PropertyName} contains one or more special characters that are not allow");
        }
    }
}
