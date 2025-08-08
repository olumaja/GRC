using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.PRA;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    /*
     * Author: Olusegun Adaramaja
     * Date created: 29/11/2023
     * Development Group: GRCTools
     * The endpoint enable risk champion to reject the product risk assessment and add reason for the rejection
     */
    public class RejectProductRiskAssessmentEndpoint
    {
        /// <summary>
        /// The endpoint enable risk champion to reject product risk assessment
        /// </summary>
        /// <param name="user"></param>
        /// <param name="config"></param>
        /// <param name="EmailService"></param>
        /// <param name="rejectProductRiskAssessment"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(RejectProductRiskAssessmentDto rejectProductRiskAssessment, IRepository<ProductRiskAssessment> repository, 
            ClaimsPrincipal user, IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService)
        {

            var email = currentUserService.CurrentUserEmail;

            if (string.IsNullOrWhiteSpace(email))
            {
                return TypedResults.Unauthorized();
            }

            var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

            if (unitIdValue is null)
            {
                return TypedResults.Ok("Unit was not found");
            }

            Guid unitId = new Guid(unitIdValue.Value);
            var product = await repository.GetByIdAsync(rejectProductRiskAssessment.ProductRiskAssessementId);

            if (product is null)
            {
                return TypedResults.NotFound();
            }

            product.AddApproval(currentUserService.CurrentUserFullName);
            product.UpdatePRAStageStatusReason(PRAStage.RiskManagement, PRAStatus.Rejected, rejectProductRiskAssessment.ReasonForRejection);
            repository.SaveChanges();
            #region Send email when a product owner completes a request for Product Risk Assessment to RiskMgtUnit
            string subject = $"New Product Risk Assessment Request";
            string emailTo = config["EmailConfiguration:RiskMgtUnit"];
            string toCC = config["EmailConfiguration:toCC"];
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string body = $"Hello all, <br> The Risk Management team have concluded the Risk Assessment on your product. <br> <br>Kindly click on the link provided for further information:<br> <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, product.Id, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"Request created successfully but email message was not logged");
            }
            #endregion

            return TypedResults.Ok();
        }
    }
}
