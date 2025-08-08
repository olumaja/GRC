using Arm.GrcApi.Modules.RiskManagement.BIA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.BIA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BIAUnitProcessDetails;

namespace GrcApi.UnitTests.Modules.RiskManagement.BIA
{
    public class GetBusinessImpactAnalysisTest
    {
        [Test]
        public async Task GetBusinessImpactAnalysis_CallMethodWithValidBIAUnitId_ReturnsDetailOfCreatedBIAUnitProcessDetails()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<BusinessImpactAnalysisUnit> biaUnitRepo = new Repository<BusinessImpactAnalysisUnit>(context);
            IRepository<BIAUnitProcessDetails> biaProcessDetailsRepo = new Repository<BIAUnitProcessDetails>(context);
            IRepository<RSCAProcess> processRepo = new Repository<RSCAProcess>(context);
            IRepository<Unit> unitRepo = new Repository<Unit>(context);
            //IRepository<BIAUnitProcessDetailsBusinessUnitToRunProcess> BusinessUnitToRunProcessRepo = new Repository<BIAUnitProcessDetailsBusinessUnitToRunProcess>(context);

            var units = new List<Unit>
            {
                Unit.Create(Guid.NewGuid(), "Sample unit1"),
                Unit.Create(Guid.NewGuid(), "Sample unit2"),
                Unit.Create(Guid.NewGuid(), "Sample unit2")
            };
            unitRepo.AddRange(units);

            // Create Process
            var process = RSCAProcess.Create("Sample unit1", units[0].Id);
            processRepo.Add(process);

            // Create BIA unit
            BusinessImpactAnalysisUnit BIAUnit = BusinessImpactAnalysisUnit.Create(units[0].Id);
            biaUnitRepo.Add(BIAUnit);

            // Initiate BIA
            BIAUnitProcessDetails bIAUnitProcessDetail = Create(
                BIAUnit.Id, process.Id, "BPDS", "Financial", "Customer", "OtherProcess", "Regulatory", "Reputable", "Third", "MinimumBusiness", "Maximum", "Recovery",
                "RecoveryPoint", BIAPriority.NonCritical, "Application", "KeyVendor", "NonElectronic", "Alternative", "Primary", BIAPeakPeriod.Daily, "Remote",
                //new List<BIAUnitProcessDetailsResponsibleBusinessUnit> { BIAUnitProcessDetailsResponsibleBusinessUnit.Create(units[1].Id) },
                new List<BIAUnitProcessDetailsBusinessUnitToRunProcess> { BIAUnitProcessDetailsBusinessUnitToRunProcess.Create(units[2].Id) }
            );
            biaProcessDetailsRepo.Add(bIAUnitProcessDetail);

            biaProcessDetailsRepo.SaveChanges();

            var expectedResult = biaProcessDetailsRepo.GetContextByConditon(b => b.BusinessImpactAnalysisUnitId.Equals(BIAUnit.Id))
                //.Include(b => b.ResponsibleBusinessUnits).ThenInclude(r => r.Unit)
                .Include(b => b.BusinessUnitsToRunProcess).ThenInclude(r => r.Unit).ToList();

            //// Acts
            //var result = await GetBusinessImpactAnalysisEndpoint.HandleAsync(BIAUnit.Id, biaUnitRepo, biaProcessDetailsRepo, processRepo);
            //var resultValue = (result as IValueHttpResult).Value as GetBIAUnitDto;

            //// Assert
            //Assert.IsInstanceOf<Ok<GetBIAUnitDto>>(result);
            //Assert.That(expectedResult.Count, Is.EqualTo(resultValue.ProcessDetials.Count));
            //Assert.That(expectedResult[0].BusinessImpactAnalysisUnitId, Is.EqualTo(resultValue.BIAUnitId));
        }
    }
}
