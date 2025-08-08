using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.BusinessEntities;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace GrcApi.Modules.RiskManagement.PRA
{
    /*
     * Original Author: McCarthy Nwosu
     * Date Created: 20/11/2023
     * Development Group: GRCTools
     * This endpoint get product risk assessment by ID
     */
    public class ProductRiskAssessmentEndpointGetPRA
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="repository"></param>
        /// <param name="docuRepo"></param>
        /// <param name="productRiskAssessmentId"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ProductRiskAssessment> repository, IRepository<Document> docuRepo, Guid productRiskAssessmentId, 
            ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {

            try
            {
               // var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));

                var email = currentUserService.CurrentUserEmail;

                if (string.IsNullOrWhiteSpace(email))
                {
                    return TypedResults.Unauthorized();
                }

                var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));
                if (unitIdValue is null)
                {
                    return TypedResults.Ok("Unit not found");
                }

                Guid unitId = new Guid(unitIdValue.Value);
                var pra = repository.GetContextByConditon(p => p.Id.Equals(productRiskAssessmentId))
                                    .Include(p => p.ProductAssessRisks).FirstOrDefault();

                if(pra is null)
                {
                    return TypedResults.NotFound();
                }

                var document = docuRepo.GetContextByConditon(x => x.ModuleItemId == productRiskAssessmentId && x.ModuleItemType == ModuleType.RiskManagement)
                                        .Select(y => new DocumentDTO
                                        {
                                            DocumentId = y.Id,
                                            DocumentName = y.Name,
                                            ModuleItemId = y.ModuleItemId
                                        }).FirstOrDefault();

                if (pra.ProductAssessRisks.Count() > 0)
                {
                    ProcessRiskAssessmentByIdDTO resultReInitiated = new ProcessRiskAssessmentByIdDTO
                    {
                        ProductRiskAssessmentId = pra.Id,
                        ProductName = pra.ProductName,
                        DateInitiated = pra.CreatedOnUtc.ToString(),
                        ProductDescription = pra.ProductDescription,
                        ReasonForRejection = pra.ReseasonForRejection,
                        QuestionOrRecomendation = pra.QuestionOrRecomendation,
                        Status = pra.Status,
                        Requester = pra.Requester,
                        Approval = pra.Approval,
                        ApprovalDate = pra.ApprovalDate,
                        ProductAssessDtos = pra.ProductAssessRisks
                        .Select(p => new ProductAssessDto {
                            ProductAssessRiskId = p.Id, 
                            ProductRiskCategory = p.ProductRiskCategory, 
                            Description = p.Description,
                            Rating = p.Rating
                        }).ToList(),
                        Document = document
                    };

                    return TypedResults.Ok(resultReInitiated);
                }

                ProcessRiskAssessmentByIdDTO result = new ProcessRiskAssessmentByIdDTO
                {
                    ProductRiskAssessmentId = pra.Id,
                    ProductName = pra.ProductName,
                    DateInitiated = pra.CreatedOnUtc.ToString(),
                    ProductDescription = pra.ProductDescription,
                    ReasonForRejection = pra.ReseasonForRejection,
                    Requester = pra.Requester,
                    Approval = pra.Approval,
                    ApprovalDate = pra.ApprovalDate,
                    Document = document
                };

                return TypedResults.Ok(result);

            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Record not found", null, 500);
            }

        }
    }
}
