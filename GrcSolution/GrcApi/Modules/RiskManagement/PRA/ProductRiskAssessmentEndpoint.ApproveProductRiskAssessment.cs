using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.RiskManagement.PRA;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    /*
     * Author: Olusegun Adaramaja
     * Date created: 28/11/2023
     * Development Group: GRCTools
     * The endpoint approve the product risk assessment and update product owner's response
     */
    public class ApproveProductRiskAssessmentEndpoint
    {
        /// <summary>
        /// The approve the product risk assessment and update product owner's response
        /// </summary>
        /// <param name="approveProductRiskAssessment"></param>
        /// <param name="productRiskRepo"></param>
        /// <param name="user"></param>
        /// <param name="config"></param>
        /// <param name="EmailService"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ApproveProductRiskAssessment approveProductRiskAssessment, IRepository<ProductRiskAssessment> productRiskRepo, ClaimsPrincipal user,
            IConfiguration config, IEmailService EmailService, Serilog.ILogger logger, ICurrentUserService currentUserService
        )
        {
            try
            {
                //var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));

                var email = currentUserService.CurrentUserEmail;

                if (string.IsNullOrWhiteSpace(email))
                {
                    return TypedResults.Unauthorized();
                }

                List<string> errorResponse = new();

                var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

                if (unitIdValue is null)
                {
                    return TypedResults.Ok(errorResponse);
                }

                Guid unitId = new Guid(unitIdValue.Value);

                var productRiskAssessment = productRiskRepo.GetContextByConditon(a => a.Id.Equals(approveProductRiskAssessment.ProductRiskAssessementId))
                                                          .Include(a => a.ProductAssessRisks).FirstOrDefault();

                if (productRiskAssessment.ProductAssessRisks is null || productRiskAssessment.ProductAssessRisks.Count == 0)
                {
                    errorResponse.Add($"Product risk assesment {approveProductRiskAssessment.ProductRiskAssessementId} does not have existing assess risk");
                    return TypedResults.BadRequest(errorResponse);
                }

                var availableAssessRiskId = productRiskAssessment.ProductAssessRisks.Select(a => a.Id).ToList();

                var inputedAssessRiskId = approveProductRiskAssessment.AssessRiskForApprovals.Select(a => a.ProductAssessRiskId).ToList();

                var notFound = inputedAssessRiskId.Where(p => !availableAssessRiskId.Contains(p)).Select(p => p).ToList();

                if (notFound.Count > 0)
                {
                    notFound.ForEach(n => errorResponse.Add($"Invalid assess risk id {n}"));
                    return TypedResults.BadRequest(errorResponse);
                }

                foreach (var product in approveProductRiskAssessment.AssessRiskForApprovals)
                {
                    productRiskAssessment.ProductAssessRisks.Find(p => p.Id.Equals(product.ProductAssessRiskId)).UpdateProductOwnerResponse(product.ProductOwnerResponse);
                }

                productRiskAssessment.AddApproval(currentUserService.CurrentUserFullName);
                productRiskAssessment.UpdatePRAStageStatusReason(PRAStage.Final, PRAStatus.Approved);
                productRiskAssessment.UpdateOwnerResponseToRecommendation(approveProductRiskAssessment.OwnerResponseToRecommendation);
                await productRiskRepo.SaveChangesAsync();
                #region Send email when a product owner completes a request for Product Risk Assessment to RiskMgtUnit
                string subject = $"New Product Risk Assessment Request";
                string emailTo = config["EmailConfiguration:RiskMgtUnit"];
                string toCC = config["EmailConfiguration:toCC"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Hello all, <br> The Risk Management team have concluded the Risk Assessment on your product. <br> <br>Kindly click on the link provided for further information:<br> <a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, productRiskAssessment.Id, emailTo, toCC);
                if (logEmailRequest == false)
                {
                    return TypedResults.Ok($"Request created successfully but email message was not logged");
                }
                #endregion

                return TypedResults.Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return TypedResults.BadRequest("Unable to submit the request");
            }


          
        }
    }
}
