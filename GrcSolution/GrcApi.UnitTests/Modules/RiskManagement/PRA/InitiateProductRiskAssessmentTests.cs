using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.UnitTests;

namespace Arm.GrcApi.UnitTests.Modules.RiskManagement.PRA
{
    public class InitiateProductRiskAssessmentTests
    {
        [Test]
        public async Task PostInitiatePRA_CallMethodWithValidParameter_ReturnsCreatedSuccessfully()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<ProductRiskAssessment> piaRepo = new Repository<ProductRiskAssessment>(context);
            IRepository<Document> docRepo = new Repository<Document>(context);

            // Initiate PRA

        }

    }
}
