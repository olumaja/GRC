//using Arm.GrcApi.Modules.RiskManagement.BIA;
//using Arm.GrcTool.Domain;
//using Arm.GrcTool.Domain.BusinessImpactAnalysis;
//using Arm.GrcTool.Infrastructure;

//using Microsoft.AspNetCore.Http.HttpResults;

//using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BIAUnitProcessDetails;
//using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

//namespace GrcApi.UnitTests.Modules.RiskManagement.BIA
//{
//    public class InitiateBusinessImpactAnalysisTests
//    {
//        [Test]
//        public async Task PostInitiateBIA_CallMethodWithValidParameter_ReturnsCreatedSuccessfully()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<BusinessImpactAnalysisUnit> biaUnitRepo = new Repository<BusinessImpactAnalysisUnit>(context);
//            IRepository<BIAUnitProcessDetails> biaProcessDetailRepo = new Repository<BIAUnitProcessDetails>(context);
//            //IRepository<BIAUnitProcessDetailsResponsibleBusinessUnit> responsibleBusinessUnitsRepo = new Repository<BIAUnitProcessDetailsResponsibleBusinessUnit>(context);
//            IRepository<BIAUnitProcessDetailsBusinessUnitToRunProcess> businessUnitsToRunProcessRepo = new Repository<BIAUnitProcessDetailsBusinessUnitToRunProcess>(context);
//            IRepository<Unit> unitRepo = new Repository<Unit>(context);
//            IRepository<BusinessImpactAnalysisUnitLog> businessImpactAnalysisUnitLogRepo = new Repository<BusinessImpactAnalysisUnitLog>(context);

//            Unit sampleUnit = Unit.Create(Guid.NewGuid(), "Sample unit");
//            unitRepo.Add(sampleUnit);
//            List<Guid> responsibleBusinessUnits = new() { sampleUnit.Id };
//            List<Guid> businessUnitsToRunProcess = new() { sampleUnit.Id };
//            BusinessImpactAnalysisUnit BIAUnit = Create(Guid.NewGuid());

//            biaUnitRepo.Add(BIAUnit);
//            biaUnitRepo.SaveChanges();

//            // Initiate BIA
//            List<InitiateBIAProcessDetailsDto> initiateBIAProcesses = new()
//            {
//                new InitiateBIAProcessDetailsDto(
//                    "Business Process Description Summary", Guid.NewGuid(), "Test Financial impact", "Customer experience", "Other process People",
//                    "Regular or legal", "Reputation", "Third party impact", "Minimum business continuty objective", "Maximiun allowable outage", "Recovery time objective",
//                    "Recovery point objective", BIAPriority.Critical, "Apllication used to run process", "Key vendor", "Any non-electronic vital record",
//                    "Alternative work around", "Primary recover stragy and solution", BIAPeakPeriod.Daily, "Remote work", //responsibleBusinessUnits, 
//                    businessUnitsToRunProcess
//                )
//            };

//            InitiateBIADto initiateBIA = new(BIAUnit.Id, initiateBIAProcesses);

//            // Act
//            var result = await InitiateBusinessImpactAnalysisEndpoint.HandleAsync(
//                initiateBIA, biaUnitRepo, biaProcessDetailRepo, businessImpactAnalysisUnitLogRepo
//            );

//            // Assert
//            var expectedBia = (await biaUnitRepo.GetByIdAsync(BIAUnit.Id));

//            //Assert
//            Assert.IsInstanceOf<Created<InitiateBIAResponseDto>>(result);
//            Assert.That(expectedBia.BIAUnitProcessDetails, Has.Count.EqualTo(initiateBIAProcesses.Count));
//            Assert.That(expectedBia.BIAUnitProcessDetails[0].BusinessUnitsToRunProcess, Has.Count.EqualTo(initiateBIAProcesses[0].BusinessUnitsToRunProcess.Count));
//            //Assert.That(expectedBia.BIAUnitProcessDetails[0].ResponsibleBusinessUnits, Has.Count.EqualTo(initiateBIAProcesses[0].ResponsibleBusinessUnits.Count));
//            Assert.That(expectedBia.Stage, Is.EqualTo(BIAStage.RiskChampionHeadInitiateBIA));
//            Assert.That(expectedBia.BusinessImpactAnalysisUnitLogs, Has.Count.EqualTo(BIAUnit.BusinessImpactAnalysisUnitLogs.Count));
//        }

//        [Test]
//        public async Task PostReInitiateBIA_CallMethodWithValidParameter_ReturnsCreatedSuccessfully()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<BusinessImpactAnalysisUnit> biaUnitRepo = new Repository<BusinessImpactAnalysisUnit>(context);
//            IRepository<BIAUnitProcessDetails> biaProcessDetailRepo = new Repository<BIAUnitProcessDetails>(context);
//            //IRepository<BIAUnitProcessDetailsResponsibleBusinessUnit> responsibleBusinessUnitsRepo = new Repository<BIAUnitProcessDetailsResponsibleBusinessUnit>(context);
//            IRepository<BIAUnitProcessDetailsBusinessUnitToRunProcess> businessUnitsToRunProcessRepo = new Repository<BIAUnitProcessDetailsBusinessUnitToRunProcess>(context);
//            IRepository<Unit> unitRepo = new Repository<Unit>(context);
//            IRepository<BusinessImpactAnalysisUnitLog> businessImpactAnalysisUnitLogRepo = new Repository<BusinessImpactAnalysisUnitLog>(context);

//            Unit sampleUnit = Unit.Create(Guid.NewGuid(), "Sample unit");
//            unitRepo.Add(sampleUnit);
//            List<Guid> responsibleBusinessUnits = new() { sampleUnit.Id };
//            List<Guid> businessUnitsToRunProcess = new() { sampleUnit.Id };
//            BusinessImpactAnalysisUnit BIAUnit = Create(Guid.NewGuid());


//            var initiateBIAProcessDetails = new List<BIAUnitProcessDetails>
//            {
//                Create(BIAUnit.Id, Guid.NewGuid(),
//                    "Business Process Description Summary", "Test Financial impact", "Customer experience", "Other process People",
//                        "Regular or legal", "Reputation", "Third party impact", "Minimum business continuty objective", "Maximiun allowable outage", "Recovery time objective",
//                        "Recovery point objective", BIAPriority.Critical, "Apllication used to run process", "Key vendor", "Any non-electronic vital record",
//                        "Alternative work around", "Primary recover stragy and solution", BIAPeakPeriod.Daily, "Remote work"
//                    , //responsibleBusinessUnits: responsibleBusinessUnits.Select(u => BIAUnitProcessDetailsResponsibleBusinessUnit.Create(u)).ToList(),
//                    businessUnitsToRunProcess: businessUnitsToRunProcess.Select(u => BIAUnitProcessDetailsBusinessUnitToRunProcess.Create(u)).ToList()
//                )
//            };
//            biaProcessDetailRepo.AddRange(initiateBIAProcessDetails);

//            biaUnitRepo.Add(BIAUnit);
//            biaUnitRepo.SaveChanges();

//            // Initiate BIA
//            List<InitiateBIAProcessDetailsDto> initiateBIAProcesses = new()
//            {
//                new InitiateBIAProcessDetailsDto(
//                    "Business Process Description Summary", Guid.NewGuid(), "Test Financial impact", "Customer experience", "Other process People",
//                    "Regular or legal", "Reputation", "Third party impact", "Minimum business continuty objective", "Maximiun allowable outage", "Recovery time objective",
//                    "Recovery point objective", BIAPriority.Critical, "Apllication used to run process", "Key vendor", "Any non-electronic vital record",
//                    "Alternative work around", "Primary recover stragy and solution", BIAPeakPeriod.Daily, "Remote work", //responsibleBusinessUnits, 
//                    businessUnitsToRunProcess
//                )
//            };

//            InitiateBIADto initiateBIA = new(BIAUnit.Id, initiateBIAProcesses);

//            // Act
//            var result = await InitiateBusinessImpactAnalysisEndpoint.HandleAsync(
//                initiateBIA, biaUnitRepo, biaProcessDetailRepo, businessImpactAnalysisUnitLogRepo
//            );

//            // Assert
//            var expectedBia = (await biaUnitRepo.GetByIdAsync(BIAUnit.Id));

//            //Assert
//            Assert.IsInstanceOf<Created<InitiateBIAResponseDto>>(result);
//            Assert.That(expectedBia.BIAUnitProcessDetails[0].ProcessId, Is.EqualTo(initiateBIAProcesses[0].ProcessId));
//        }
//    }
//}
