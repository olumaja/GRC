//using Arm.GrcApi.Modules.RiskManagement.PRA;
//using Arm.GrcTool.Infrastructure;
//using GrcApi.Modules.RiskManagement.PRA;
//using Microsoft.AspNetCore.Http.HttpResults;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace GrcApi.UnitTests.Modules.RiskManagement.PRA
//{
//    /*
//     * Author: Olusegun Adaramaja
//     * Date created: 28/11/2023
//     * Development Group: GRCTools
//     * This test the approve endpoint
//     */
//    public class ProductRiskAssessmentEndpoint
//    {
//        [Test]
//        public async Task PostAssessRiskEndpoint_CallWithValidPayload_CreateAssessRisk()
//        {
//            //Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<ProductRiskAssessment> productRiskRepo = new Repository<ProductRiskAssessment>(context);
//            IRepository<ProductAssessRisk> assessRiskRepo = new Repository<ProductAssessRisk>(context);

//            ClaimsPrincipal principal = new();
//            ClaimsIdentity identity = new("joshua", ClaimTypes.Name, ClaimTypes.Role);
//            identity.AddClaim(new Claim("name", "joshua"));
//            principal.AddIdentity(identity);

//            // Create product risk assessment
//            ProductRiskAssessment productRisk = ProductRiskAssessment.Create("Agric Business", Guid.NewGuid(), Guid.NewGuid(), "Agric business", Guid.NewGuid(), PRAStage.RiskManagement);
//            productRiskRepo.Add(productRisk);

//            ProductAssessRisk assessRisk = ProductAssessRisk.Create(productRisk.Id, "Category", "Description", PARRating.Medium);
//            assessRiskRepo.Add(assessRisk);
//            await context.SaveChangesAsync();

//            ApproveProductRiskAssessment approveProductrisk = new ApproveProductRiskAssessment(productRisk.Id, new List<ProductAssessRiskForApproval>{
//                new ProductAssessRiskForApproval(assessRisk.Id, "Owner response")
//            });

//            // Act
//            var result = await ApproveProductRiskAssessmentEndpoint.HandleAsync(approveProductrisk, productRiskRepo, principal);
//            var productRiskAssessment = await productRiskRepo.GetByIdAsync(productRisk.Id);

//            // Assert
//            Assert.IsInstanceOf<Ok>(result);
//            Assert.That(productRiskAssessment.Status, Is.EqualTo(PRAStatus.Approved));
//            Assert.That(productRiskAssessment.Stage, Is.EqualTo(PRAStage.Final));
//        }
//    }
//}
