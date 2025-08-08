using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using static Arm.GrcTool.Domain.RiskControlSelfAssessment.DocumentRSCAProcess;

namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostDocumentProcessTests
    {
        [Test]
        public async Task CreatesRCSAProcessWithValidParameters_Returns_Successful()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);
            IRepository<ProcessInherentRiskControl> inherentRiskRepo = new Repository<ProcessInherentRiskControl>(context);
            IRepository<RiskControlSelfAssessment> rcsaRepo = new Repository<RiskControlSelfAssessment>(context);
            IRepository<DocumentRSCAProcessLog> documentRSCAProcessLogRepo = new Repository<DocumentRSCAProcessLog>(context);

            //create mock rcsa
            Guid unitId = Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E");
            List<RiskControlSelfAssessmentUnit> units = new() { RiskControlSelfAssessmentUnit.Create(unitId: unitId, documentRSCAProcess: Create(Stage.RiskChampionInitiateRCSA)) };
            RiskControlSelfAssessment rcsa = RiskControlSelfAssessment.Create(
                DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
                DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
                units);

            rcsaRepo.Add(rcsa);

            rcsaRepo.SaveChanges();

            // Create instance of RiskControlSelfAssessmentCreateDocumentProcessDto
            RiskControlSelfAssessmentCreateDocumentProcessDto documentProcessDto = new(
                RiskControlSelfAssessmentUnitId: units[0].Id,
                ProcessInherentRiskControls: new List<CreateProcessInherentRiskControlDto>
                {
                    new CreateProcessInherentRiskControlDto(
                        ProcessId: Guid.NewGuid(),
                        InherentRisk: "Enter inherent risk",
                        Control: "Enter control"
                    )
                }
            );

            //// Act
            //var result = await RiskControlSelfAssessmentEndpointPostDocumentProcess.HandleAsync(documentProcessDto, docRepo, inherentRiskRepo, documentRSCAProcessLogRepo);

            //// Assert
            //var docProcess = docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnitId.Equals(documentProcessDto.RiskControlSelfAssessmentUnitId)).Include(d => d.DocumentRSCAProcessLogs).FirstOrDefault();
            //Assert.IsInstanceOf<Created<CreateDocumentProcessResponseDto>>(result);
            //Assert.That(units[0].DocumentRSCAProcess.ProcessInherentRiskControls[0].ProcessId, Is.EqualTo(documentProcessDto.ProcessInherentRiskControls[0].ProcessId));
            //Assert.That(units[0].DocumentRSCAProcess.RCSAStage, Is.EqualTo(Stage.RiskChampionHeadInitiateRCSA));
            //Assert.That(docProcess.DocumentRSCAProcessLogs.Count, Is.GreaterThan(0));
        }

        [Test]
        public async Task ReinitiatesRCSAProcessWithValidParameters_Returns_Successful()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<DocumentRSCAProcess> docRepo = new Repository<DocumentRSCAProcess>(context);
            IRepository<ProcessInherentRiskControl> inherentRiskRepo = new Repository<ProcessInherentRiskControl>(context);
            IRepository<RiskControlSelfAssessment> rcsaRepo = new Repository<RiskControlSelfAssessment>(context);
            IRepository<DocumentRSCAProcessLog> documentRSCAProcessLogRepo = new Repository<DocumentRSCAProcessLog>(context);

            //create mock rcsa
            Guid unitId = Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E");
            List<RiskControlSelfAssessmentUnit> units = new() { RiskControlSelfAssessmentUnit.Create(unitId: unitId, documentRSCAProcess: Create(Stage.RiskChampionInitiateRCSA)) };
            RiskControlSelfAssessment rcsa = RiskControlSelfAssessment.Create(
                DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
                DateOnly.FromDateTime(DateTime.Now),
                DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
                units);

            rcsaRepo.Add(rcsa);

            #region Mock an existing RCSADocumentProcess
            RiskControlSelfAssessmentCreateDocumentProcessDto createDocProcess = new(
                RiskControlSelfAssessmentUnitId: units[0].Id,
                ProcessInherentRiskControls: new List<CreateProcessInherentRiskControlDto>
                {
                    new CreateProcessInherentRiskControlDto(
                        ProcessId: Guid.NewGuid(),
                        InherentRisk: "Enter inherent risk1",
                        Control: "Enter control1"
                    )
                }
            );

            Guid documentRSCAProcessId = units[0].DocumentRSCAProcess.Id;

            List<ProcessInherentRiskControl> processInherentRisks = new();

            foreach (var item in createDocProcess.ProcessInherentRiskControls)
            {
                ProcessInherentRiskControl inherentRiskControl = ProcessInherentRiskControl.Create(
                    item.ProcessId,
                    documentRSCAProcessId,
                    item.InherentRisk,
                    item.Control
                );

                processInherentRisks.Add(inherentRiskControl);
            }
            inherentRiskRepo.AddRange(processInherentRisks);
            inherentRiskRepo.SaveChanges();
            #endregion

            // Create instance of RiskControlSelfAssessmentCreateDocumentProcessDto
            RiskControlSelfAssessmentCreateDocumentProcessDto documentProcessDto = new(
                RiskControlSelfAssessmentUnitId: units[0].Id,
                ProcessInherentRiskControls: new List<CreateProcessInherentRiskControlDto>
                {
                    new CreateProcessInherentRiskControlDto(
                        ProcessId: Guid.NewGuid(),
                        InherentRisk: "Enter inherent risk2",
                        Control: "Enter control2"
                    )
                }
            );

            //// Act
            //var result = await RiskControlSelfAssessmentEndpointPostDocumentProcess.HandleAsync(documentProcessDto, docRepo, inherentRiskRepo, documentRSCAProcessLogRepo);

            //// Assert
            //var docProcess = docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnitId.Equals(documentProcessDto.RiskControlSelfAssessmentUnitId)).Include(d => d.DocumentRSCAProcessLogs).FirstOrDefault();
            //Assert.IsInstanceOf<Created<CreateDocumentProcessResponseDto>>(result);
            //Assert.That(docProcess.ProcessInherentRiskControls[0].ProcessId, Is.EqualTo(documentProcessDto.ProcessInherentRiskControls[0].ProcessId));
            //Assert.That(docProcess.ProcessInherentRiskControls.Count, Is.EqualTo(1));
        }
    }
}
