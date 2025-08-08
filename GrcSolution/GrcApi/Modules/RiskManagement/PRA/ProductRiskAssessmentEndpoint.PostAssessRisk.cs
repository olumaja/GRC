using Arm.GrcApi.Modules.Shared.EmailNotification;
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
     * Original Author: Olusegun Adaramaja
     * Date Created: 24/11/2023
     * Development Group: GRCTools
     * The endpoint enable risk management to create product assess risk
     * Send email notification to the RiskMgtUnit upon successful request.
     */
    public class PostAssessRiskEndpoint
    {

        /// <summary>
        /// Create product assess risk
        /// </summary>
        /// <param name="initiateAssessRisk"></param>
        /// <param name="productRiskRepo"></param>
        /// <param name="assessRiskRepo"></param>
        /// <param name="user"></param>
        /// <param name="config"></param>
        /// <param name="EmailService"></param>
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(
            InitiateAssessRiskDto initiateAssessRisk, IRepository<ProductRiskAssessment> productRiskRepo, IRepository<ProductAssessRisk> assessRiskRepo,
            ClaimsPrincipal user, IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService
        )
        {
            try
            {
                var email = currentUserService.CurrentUserEmail; //user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));

                var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

                if (unitIdValue is null)
                {
                    return TypedResults.Ok("Unit was not found");
                }

                Guid unitId = new Guid(unitIdValue.Value);

                var product = productRiskRepo.GetContextByConditon(p => p.Id.Equals(initiateAssessRisk.ProductRiskAssessmentId))
                                             .Include(p => p.ProductAssessRisks).FirstOrDefault();

                if (product is null)
                {
                    return TypedResults.BadRequest($"Product risk assesment with Id {initiateAssessRisk.ProductRiskAssessmentId} doesn't exist");
                }

                if (product.ProductAssessRisks.Count > 0)
                {
                    assessRiskRepo.RemoveRange(product.ProductAssessRisks);
                }

                var assesRisks = initiateAssessRisk.AssessRisks.Select(a => ProductAssessRisk.Create(
                    initiateAssessRisk.ProductRiskAssessmentId,
                    a.ProductRiskCategory,
                    a.Description,
                    a.Rating
                )).ToList();

                assessRiskRepo.AddRange(assesRisks);

                product.UpdatePRAStageStatusReason(PRAStage.RiskChampionReviewPRA, PRAStatus.Responded);
                product.UpdateQuestionRecommendation(initiateAssessRisk.QuestionOrRecomendation);
                productRiskRepo.SaveChanges();
                #region Send email When Risk Management concludes assessment
                string subject = $"New Product Risk Assessment";
                string emailTo = config["EmailConfiguration:emailTo"];
                string toCC = config["EmailConfiguration:RiskChampionsUnitHeads"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Hello all, <br>The Risk Management team have concluded the Risk Assessment on your product. <br> <br>Kindly click on the link provided to respond:<br> <a href={linkToGRCTool}>GRC link</a>.";

                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, product.Id, emailTo, toCC);
                if (logEmailRequest == false)
                {
                    return TypedResults.Ok($"Request created successfully but email message was not logged");
                }
                #endregion

                return TypedResults.Ok();

            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
