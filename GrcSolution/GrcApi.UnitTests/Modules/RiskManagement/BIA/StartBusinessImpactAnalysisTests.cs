//using Arm.GrcTool.Infrastructure;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Http;
//using Arm.GrcApi.Modules.RiskManagement.BIA;
//using Arm.GrcTool.Domain;
//using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;
//using Arm.GrcTool.Domain.BusinessImpactAnalysis;

//namespace GrcApi.UnitTests.Modules.RiskManagement.BIA
//{
//    public class StartBusinessImpactAnalysisTests
//    {
//        [Test]
//        public async Task CallMethodWithValidParameter_ReturnsCreatedSuccessfully()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<BusinessImpactAnalysis> repository = new Repository<BusinessImpactAnalysis>(context);
//            IRepository<Unit> unitRepo = new Repository<Unit>(context);
//            Unit testUnit = Unit.Create(Guid.NewGuid(), "Test unit");
//            unitRepo.Add(testUnit);
//            unitRepo.SaveChanges();

//            //create bia
//            List<CreateBusinessImpactAnalysisUnitDto> units = new() { new(testUnit.Id) };
//            StartBIADto bia = new(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
//                                    DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
//                                    units);

//            //Act
//            var res = await StartBusinessImpactAnalysisEndpoint.HandleAsync(bia, repository, unitRepo);
//            var value = ((res as IValueHttpResult).Value) as StartBIAResponseDto;

//            //
//            var expectedBia = (await repository.GetByIdAsync(value.BusinessImpactAnalysisId));

//            //Assert
//            Assert.IsInstanceOf<Created<StartBIAResponseDto>>(res);
//            Assert.That(expectedBia.BusinessImpactAnalysisUnits.Count, Is.EqualTo(value.BusinessImpactAnalysisUnits.Count));
//            Assert.That(expectedBia.BusinessImpactAnalysisUnits[0].Stage, Is.EqualTo(BIAStage.RiskChampionInitiateBIA));
//        }

//        [Test]
//        public async Task CallMethodWithInValidUnit_ReturnsError()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<BusinessImpactAnalysis> repository = new Repository<BusinessImpactAnalysis>(context);
//            IRepository<Unit> unitRepo = new Repository<Unit>(context);
//            Unit testUnit = Unit.Create(Guid.NewGuid(), "Test unit");
//            unitRepo.Add(testUnit);

//            //create bia
//            Guid unitId = Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E");
//            List<CreateBusinessImpactAnalysisUnitDto> units = new() { new(unitId) };
//            StartBIADto bia = new(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
//                                    DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
//                                    units);

//            //Act
//            var res = await StartBusinessImpactAnalysisEndpoint.HandleAsync(bia, repository, unitRepo);
//            var value = ((res as IValueHttpResult).Value) as List<string>;

//            //Assert
//            Assert.That(value[0], Is.EqualTo($"Invalid unitId, {unitId}"));
//        }
//    }
//}
