using Arm.GrcApi.Modules.RiskManagement.BIA;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.BIA;
using GrcApi.Modules.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace GrcApi.UnitTests.Modules.RiskManagement.BIA
{
    public class GetAllBusinessImpactAnalysisForRiskChampionEndpointTest
    {
        [Test]
        public async Task CallMethod_ReturnsListOfBIAForRiskChampionHead()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<BusinessImpactAnalysisUnit> biaUnitRepo = new Repository<BusinessImpactAnalysisUnit>(context);
            IRepository<Unit> unitRepo = new Repository<Unit>(context);
            IRepository<BusinessImpactAnalysis> biaRepo = new Repository<BusinessImpactAnalysis>(context);

            // Create list of unit
            var units = new List<Unit>
            {
                Unit.Create(Guid.NewGuid(), "Sample unit1"),
                Unit.Create(Guid.NewGuid(), "Sample unit2"),
                Unit.Create(Guid.NewGuid(), "Sample unit2")
            };
            unitRepo.AddRange(units);

            // Create list business impact analysis unit
            var biaUnits = new List<BusinessImpactAnalysisUnit>
            {
                BusinessImpactAnalysisUnit.Create(units[0].Id),
                BusinessImpactAnalysisUnit.Create(units[1].Id),
                BusinessImpactAnalysisUnit.Create(units[2].Id)
            };
            biaUnitRepo.AddRange(biaUnits);
            // Update BIA unit stage
            biaUnits[0].UpdateStage(BIAStage.RiskChampionInitiateBIA);

            // Create business impact analysis
            var biaList = new List<BusinessImpactAnalysis>
            {
                BusinessImpactAnalysis.Create(
                DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
                DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
                biaUnits
                )
            };
            biaRepo.AddRange(biaList);
            biaRepo.SaveChanges();

            var expected = await biaUnitRepo.GetAllPagedAsync(0, 0, b => b
            .Where(r => r.Stage.Equals(BIAStage.RiskChampionInitiateBIA))
            .Select(r => new GetAllBIAForRiskChampionDto(
                r.Id,
                r.BusinessImpactAnalysis.Id,
                r.Unit.Name, r.UnitId, r.Status,
                r.BusinessImpactAnalysis.CreatedOnUtc,
                r.BusinessImpactAnalysis.PeriodFrom,
                r.BusinessImpactAnalysis.PeriodTo,
                r.BusinessImpactAnalysis.StartDate,
                r.BusinessImpactAnalysis.EndDate)
            ));

            //// Act
            //var result = await GetAllBusinessImpactAnalysisForRiskChampionEndpoint.HandleAsync(biaUnitRepo);
            //var resultValue = (result as IValueHttpResult).Value as PagedResult<GetAllBIAForRiskChampionDto>;

            //// Assert
            //Assert.IsInstanceOf<Ok<PagedResult<GetAllBIAForRiskChampionDto>>>(result);
            //Assert.That(expected.Results[0].BusinessImpactAnalysisUnitId, Is.EqualTo(resultValue.Results[0].BusinessImpactAnalysisUnitId));
            //Assert.That(expected.Results.Count, Is.EqualTo(resultValue.Results.Count));
        }
    }
}
