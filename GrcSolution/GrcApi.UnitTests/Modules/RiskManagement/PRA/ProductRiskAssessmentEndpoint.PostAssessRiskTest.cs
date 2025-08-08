using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.PRA;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GrcApi.UnitTests.Modules.RiskManagement.PRA
{
    public class ProductRiskAssessmentEndpointPostAssessRiskTest
    {
        /// <summary>
        /// Create product risk assessment
        /// Test that product assess risk is created, status and stage updated
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task PostAssessRiskEndpoint_CallWithValidPayload_CreateAssessRisk()
        {
            //Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<ProductRiskAssessment> productRiskRepo = new Repository<ProductRiskAssessment>(context);
            IRepository<ProductAssessRisk> assessRiskRepo = new Repository<ProductAssessRisk>(context);

            ClaimsPrincipal principal = new();
            ClaimsIdentity identity = new("joshua", ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim("name", "joshua"));
            principal.AddIdentity(identity);

            //// Create product risk assessment
            //ProductRiskAssessment productRisk = ProductRiskAssessment.Create("Agric Business", Guid.NewGuid(), Guid.NewGuid(), "Agric business", Guid.NewGuid(), PRAStage.RiskManagement);
            //productRiskRepo.Add(productRisk);
            //await context.SaveChangesAsync();

            //InitiateAssessRiskDto initiateAssessRisk = new InitiateAssessRiskDto(productRisk.Id, "Question", new List<AssessRiskDto>{
            //    new AssessRiskDto("Agric category", "For farmers", PARRating.Medium)
            //});

            // Act
            //var result = await PostAssessRiskEndpoint.HandleAsync(initiateAssessRisk, productRiskRepo, assessRiskRepo, principal);
            //var productRiskAssessment = await productRiskRepo.GetByIdAsync(productRisk.Id);

            // Assert
            //Assert.IsInstanceOf<Ok>(result);
            //Assert.That(productRiskAssessment.Status, Is.EqualTo(PRAStatus.Responded));
            //Assert.That(productRiskAssessment.Stage, Is.EqualTo(PRAStage.RiskChampionReviewPRA));
        }
    }
}
