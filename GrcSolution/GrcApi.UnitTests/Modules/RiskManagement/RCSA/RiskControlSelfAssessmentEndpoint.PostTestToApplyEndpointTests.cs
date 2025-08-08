//using Arm.GrcApi.Modules.RiskManagement.RCSA;
//using Arm.GrcTool.Domain;
//using Arm.GrcTool.Domain.RiskControlSelfAssessment;
//using Arm.GrcTool.Infrastructure;

//using Microsoft.AspNetCore.Http.HttpResults;

//using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

//namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
//{
//    public class RiskControlSelfAssessmentEndpointPostTestToApplyTests
//    {
//        [Test]
//        public async Task PostProcessInherentRiskControlRiskTestToApply_CallWithValidPayload_UpdateProcessInherentRiskControlRiskTestToApply()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);
//            IRepository<ProcessInherentRiskControl> inherentRiskRepo = new Repository<ProcessInherentRiskControl>(context);
//            IRepository<RiskControlSelfAssessment> rcsaRepo = new Repository<RiskControlSelfAssessment>(context);
//            IRepository<Unit> unitRepo = new Repository<Unit>(context);
//            IRepository<DocumentRSCAProcessLog> documentProcessLogRepo = new Repository<DocumentRSCAProcessLog>(context);

//            var units = new List<Unit>
//            {
//                Unit.Create(Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E"), "unit1")
//            };
//            unitRepo.AddRange(units);

//            //create rcsa list
//            List<RiskControlSelfAssessmentUnit> rcsaUnits = new()
//            {
//                RiskControlSelfAssessmentUnit.Create(units[0].Id, documentRSCAProcess: Create(Stage.RiskChampionInitiateRCSA))
//            };

//            List<RiskControlSelfAssessment> rcsaList = new()
//            {
//                RiskControlSelfAssessment.Create(DateOnly.FromDateTime(DateTime.Now),
//                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
//                DateOnly.FromDateTime(DateTime.Now),
//                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
//                rcsaUnits)
//            };

//            rcsaRepo.AddRange(rcsaList);

//            var processRisk = ProcessInherentRiskControl.Create(Guid.NewGuid(), rcsaUnits[0].DocumentRSCAProcess.Id, "Test Risk", "Test control");
//            inherentRiskRepo.Add(processRisk);
//            inherentRiskRepo.SaveChanges();
            
//            ApplyTestProcessInherentRiskControlDto applyTest = new (
//                rcsaUnits[0].Id,
//                new List<TestToApplyDto> { new TestToApplyDto(processRisk.Id, "Test to be applied") }
//            );

//            // Act
//            var result = await RiskControlSelfAssessmentEndpointPostTestToApplyEndpoint.HandleAsync(applyTest, docRepo, inherentRiskRepo, documentProcessLogRepo);

//            // Assert
//            Assert.IsInstanceOf<Ok>(result);
//            Assert.That(processRisk.TestToApply, Is.EqualTo(applyTest.applyTests.First(a => a.ProcessInherentRiskControlId == processRisk.Id).testToApply));
//        }
//    }
//}
