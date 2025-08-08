using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.PRA;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 20/11/2023
     * Development Group: GRCTools
     * Initiate Product Risk Assessment with document Upload. 
     * The request is persisted into ProductRiskAssessment table.
     * Send email notification to the RiskMgtUnit upon successful request.
     */
    public class ProductRiskAssessmentEndpoint
    {
        /// <summary>
        /// Initiate Product Risk Assessment with document Upload. 
        /// The request is persisted into ProductRiskAssessment table.
        /// Send email notification to the RiskMgtUnit upon successful request.
        /// </summary> 
        /// <param name="productRiskAssessmentDTO"></param>
        /// <param name="productRiskAssessmentRepo"></param>
        /// <param name="documentRepository"></param>
        /// <param name="user"></param>
        /// <param name="config"></param>
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(
            ProductRiskAssessmentDTO productRiskAssessmentDTO,
            IRepository<ProductRiskAssessment> productRiskAssessmentRepo,
            IRepository<Document> documentRepository,
            ClaimsPrincipal user, ICurrentUserService currentUserService,
            IConfiguration config, IEmailService EmailService) 
        {
            try
            {
                var email = currentUserService.CurrentUserEmail;
                var rolesAllowed = new[] { "UnitHead", "RiskChampion" };

                if (currentUserService.CurrentUserRoles.Count == 0 || !currentUserService.CurrentUserRoles.Any(role => rolesAllowed.Contains(role)))
                {
                    return TypedResults.Forbid();
                }

                var createPRA = ProductRiskAssessment.Create(
                        productName: productRiskAssessmentDTO.ProductName, businessId: productRiskAssessmentDTO.BusinessId,
                       departmentId: productRiskAssessmentDTO.DepartmentId, productDescription: productRiskAssessmentDTO.ProductDescription, 
                       unitId: productRiskAssessmentDTO.UnitId, stage: PRAStage.RiskManagement, email, currentUserService.CurrentUserFullName
                   );
                productRiskAssessmentRepo.Add(createPRA);

                if (productRiskAssessmentDTO.AttachDocument != null)
                {
                    var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "csv", "docx" };
                    var fileExtension = Path.GetExtension(productRiskAssessmentDTO.AttachDocument.FileName).Trim('.').ToLower();

                    if (!fileTypeAllow.Contains(fileExtension))
                        return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");

                    var testResultAttachment = DocumentExtensions.ConvertFormFileToDocument(
                        productRiskAssessmentDTO.AttachDocument,
                        ModuleType.RiskManagement,
                        createPRA.Id
                    );
                    documentRepository.Add(testResultAttachment);
                    await productRiskAssessmentRepo.SaveChangesAsync();

                    //update DocumentAttachId on the productRiskAssessment table
                    createPRA.UpdatePRADocumentAttachId(testResultAttachment.Id);
                }

                await productRiskAssessmentRepo.SaveChangesAsync();

                ProductRiskAssessmentResponse response = new ProductRiskAssessmentResponse()
                {
                    ProductRiskAssessmentId = createPRA.Id,
                    DepartmentId = productRiskAssessmentDTO.DepartmentId,
                    BusinessId = productRiskAssessmentDTO.BusinessId,
                    ProductName = productRiskAssessmentDTO.ProductName,
                    UnitId = productRiskAssessmentDTO.UnitId,
                    ProductDescription = productRiskAssessmentDTO.ProductDescription,
                    DocumentAttachId = createPRA.DocumentAttachId,
                    Status = createPRA.Status,
                    Stage = createPRA.Stage
                    //EmailAddress = email.ToString()
                };
                #region Send email when a product owner completes a request for Product Risk Assessment to RiskMgtUnit
                string subject = $"New Product Risk Assessment Request";
                string emailTo = config["EmailConfiguration:RiskMgtUnit"];
                string toCC = config["EmailConfiguration:toCC"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Hello all, <br> A Product Risk Assessment request has been submitted on the GRC Tool. <br> <br>Kindly click on the link provided for further information:<br> <a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, createPRA.Id, emailTo, toCC);
                if (logEmailRequest == false)
                {
                    return TypedResults.Ok($"Request created successfully {response} but email message was not logged");
                }
                #endregion
                
                return TypedResults.Created($"pra/{response}", response);

            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message, null, 500);
            }

        }
    }
}
