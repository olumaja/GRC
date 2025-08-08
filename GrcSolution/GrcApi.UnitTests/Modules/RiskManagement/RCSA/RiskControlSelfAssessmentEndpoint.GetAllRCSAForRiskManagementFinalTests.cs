using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.RCSA;
using GrcApi.Modules.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
{
    internal class RiskControlSelfAssessmentEndpointGetAllRCSAForRiskManagementFinalTests
    {
        [Test]
        public async Task CallMethod_ReturnsListOfRCSAForRiskManagementToFinalize()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<RiskControlSelfAssessment> repository = new Repository<RiskControlSelfAssessment>(context);
            IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo = new Repository<RiskControlSelfAssessmentUnit>(context);
            IRepository<Unit> unitRepo = new Repository<Unit>(context);

            var units = new List<Unit>
            {
                Unit.Create(Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E"), "unit1"),
                Unit.Create(Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E"), "unit2"),
                Unit.Create(Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E"), "unit3")
            };
            unitRepo.AddRange(units);

            //create rcsa list
            List<RiskControlSelfAssessmentUnit> rcsaUnits = new()
            {
                RiskControlSelfAssessmentUnit.Create(units[0].Id, documentRSCAProcess: Create(Stage.RiskManagementFinal)),
                RiskControlSelfAssessmentUnit.Create(units[1].Id, documentRSCAProcess: Create(Stage.RiskManagementFinal)),
                RiskControlSelfAssessmentUnit.Create(units[2].Id, documentRSCAProcess: Create(Stage.RiskManagementFinal))
            };

            List<RiskControlSelfAssessment> rcsaList = new()
            {
                RiskControlSelfAssessment.Create(DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
                DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
                rcsaUnits)
            };

            repository.AddRange(rcsaList);
            repository.SaveChanges();

            PagedResult<GetAllRCSAForRiskChampionDto> expectedRCSAUnitResult = rcsaUnitRepo
                .GetAllPaged(0, 0, t => t
                .Where(r => r.DocumentRSCAProcess.RCSAStage == Stage.RiskManagementFinal)
                .Select(r => new GetAllRCSAForRiskChampionDto
                {
                    CreatedDate = r.RiskControlSelfAssessment.CreatedOnUtc,
                    PeriodFrom = r.RiskControlSelfAssessment.PeriodFrom,
                    PeriodTo = r.RiskControlSelfAssessment.PeriodTo,
                    StartDate = r.RiskControlSelfAssessment.StartDate,
                    EndDate = r.RiskControlSelfAssessment.EndDate,
                    RiskControlSelfAssessmentUnitId = r.Id,
                    Status = r.DocumentRSCAProcess.Status.ToString(),
                    UnitName = r.Unit.Name,
                    RCSAId = r.RiskControlSelfAssessment.Id
                }).ToList());

            //Act
           // var response = await RiskControlSelfAssessmentEndpointGetAllRCSAForRiskManagementFinal.HandleAsync(rcsaUnitRepo);
            //var responseValue = ((response as IValueHttpResult).Value) as PagedResult<GetAllRCSAForRiskChampionDto>;

            //Assert
           // Assert.IsInstanceOf<Ok<PagedResult<GetAllRCSAForRiskChampionDto>>>(response);
            //Assert.That(expectedRCSAUnitResult.Results[0].RCSAId, Is.EqualTo(responseValue.Results[0].RCSAId));
            //Assert.That(expectedRCSAUnitResult.Results.Count, Is.EqualTo(responseValue.Results.Count));
        }
    }
}
