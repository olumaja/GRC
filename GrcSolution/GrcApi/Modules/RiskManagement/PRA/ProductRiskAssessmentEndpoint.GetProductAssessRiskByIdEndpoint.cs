using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/11/2023
    * Development Group: GRCTools
    * Get details of the ProductRiskAssessment by productRiskAssessmentId. 
   */
    public class GetProductAssessRiskByIdEndpoint
    {
        /// <summary>
        /// Get details of the ProductRiskAssessment by productRiskAssessmentId
        /// </summary> 
        /// <param name="user"></param>
        /// <param name="repository"></param>
        /// <param name="getDocumentRepo"></param>
        /// <param name="productRiskAssessmentId"></param>
        /// <returns></returns>       
        public static async Task<IResult> HandleAsync(IRepository<ProductRiskAssessment> repository, IRepository<Document> getDocumentRepo, Guid productRiskAssessmentId, 
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getDocument = await getDocumentRepo.GetContextByConditon(x => x.ModuleItemId == productRiskAssessmentId && x.ModuleItemType == ModuleType.RiskManagement)
                .Select(y => new DocumentDTO
                {
                    DocumentId = y.Id,
                    DocumentName = y.Name,
                    ModuleItemId = y.ModuleItemId
                }).FirstOrDefaultAsync();

                if (getDocument == null)
                {
                    return TypedResults.NotFound();
                }

                ProductAssessRiskDTOList par = await repository.GetContextByConditon(r => r.Id == productRiskAssessmentId)
                    .Include(e => e.ProductAssessRisks).Select(r => new ProductAssessRiskDTOList
                    {
                        ProductRiskassessmentId = r.Id,
                        ProductDescription = r.ProductDescription,
                        Datecreated = r.CreatedOnUtc,
                        ProductName = r.ProductName,
                        Status = r.Status,
                        QuestionOrRecomendation = r.QuestionOrRecomendation,
                        OwnerResponseToRecommendation = r.OwnerResponse,
                        Requester = r.Requester,
                        Approval = r.Approval,
                        ApprovalDate = r.ApprovalDate,
                        AttachDocument = getDocument,
                        ProductAssessRiskDTO = r.ProductAssessRisks.Select(u => new ProductAssessRiskDTO
                        {
                            ProductAssessRiskId = u.Id,
                            ProductRiskCategory = u.ProductRiskCategory,
                            Description = u.Description,
                            ProductOwnerResponse = u.ProductOwnerResponse,
                            Rating = u.Rating
                        }).ToList()

                    }).FirstOrDefaultAsync();

                return TypedResults.Ok(par);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Record no found", null, 500);
            }
        }
    }
}
