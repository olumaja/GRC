using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using GrcApi.Modules.BusinessEntities;
using GrcApi.Modules.Shared;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetAllRCSATests
    {
        [Test]
        public async Task RiskControlSelfAssessmentEndpointGetAllRCSA_CallMethod_ReturnsListOfCreatedRCSA()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<RiskControlSelfAssessment> repository = new Repository<RiskControlSelfAssessment>(context);
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
                RiskControlSelfAssessmentUnit.Create(units[0].Id, documentRSCAProcess: Create(Stage.RiskChampionInitiateRCSA)),
                RiskControlSelfAssessmentUnit.Create(units[1].Id, documentRSCAProcess: Create(Stage.RiskChampionHeadInitiateRCSA)),
                RiskControlSelfAssessmentUnit.Create(units[2].Id, documentRSCAProcess: Create(Stage.RiskChampionHeadInitiateRCSA))
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

            PagedResult<RiskControlSelfAssessmentDto> expectedResult = await repository
                .GetAllPagedAsync(0, 0, t => t.Select(r => new RiskControlSelfAssessmentDto
                {
                    CreatedDate = r.CreatedOnUtc,
                    PeriodFrom = r.PeriodFrom,
                    PeriodTo = r.PeriodTo,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    Id = r.Id,
                    //Status = r.Status.ToString(),
                    RiskControlSelfAssessmentUnits = r.RiskControlSelfAssessmentUnits.Select(u => new UnitDto(u.Unit.Name, u.Unit.Id)).ToList(),
                    NumberOfRiskControlSelfAssessmentUnits = r.RiskControlSelfAssessmentUnits.Count
                }));

            ////Act
            //var response = await RiskControlSelfAssessmentEndpointGetAllRCSA.HandleAsync(repository);
            //var responseValue = (response as IValueHttpResult).Value as PagedResult<RiskControlSelfAssessmentDto>;

            ////Assert
            //Assert.IsInstanceOf<Ok<PagedResult<RiskControlSelfAssessmentDto>>>(response);
            //Assert.That(expectedResult.Results[0].Id, Is.EqualTo(responseValue.Results[0].Id));
        }
    }
}
