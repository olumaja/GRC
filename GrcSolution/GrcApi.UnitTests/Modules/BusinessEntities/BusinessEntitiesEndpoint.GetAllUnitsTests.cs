using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.BusinessEntities;
using GrcApi.Modules.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Arm.GrcApi.Modules.BusinessEntities;

namespace GrcApi.UnitTests.Modules.BusinessEntities
{
    public class BusinessEntitiesEndpointGetAllUnitsTests
    {
        [Test]
        public async Task BusinessEntitiesEndpointGetAllUnits_OnMethodCallWithBusinessEntityId_ReturnsRightListOfUnits()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<BusinessEntity> businessRepository = new Repository<BusinessEntity>(context);
            IRepository<Department> departmentRepository = new Repository<Department>(context);
            IRepository<Unit> unitRepository = new Repository<Unit>(context);

            BusinessEntity businessEntity = BusinessEntity.Create("Test Entity1");
            BusinessEntity businessEntity2 = BusinessEntity.Create("Test Entity2");
            Department department = Department.Create(businessEntity.Id, "Test Department");
            Department department2 = Department.Create(businessEntity2.Id, "Test Department2");
            IList<Unit> units = new List<Unit>
            {
                Unit.Create(department.Id, "Test Unit1"),
                Unit.Create(department.Id, "Test Unit2"),
                Unit.Create(department2.Id, "Test Unit3"),
            };

            businessRepository.Add(businessEntity);
            businessRepository.Add(businessEntity2);
            departmentRepository.Add(department);
            unitRepository.AddRange(units);
            businessRepository.SaveChanges();

            Guid? testBusinessEntityId = businessEntity.Id;
            IList<Unit> unitsDto = await unitRepository
                .GetContextByConditon(d => d.Department.BusinessEntityId == testBusinessEntityId)
                .ToListAsync();

            IList<UnitDto> expectedResult = unitsDto
                .Select(b => new UnitDto(b.Name, b.Id))
                .ToList();

            //Act
            var response = await BusinessEntitiesEndpointGetAllUnits.HandleAsync(unitRepository, testBusinessEntityId);
            var responseValue = ((response as IValueHttpResult).Value) as IList<UnitDto>;

            //Assert
            Assert.That(response, Is.InstanceOf<Ok<IList<UnitDto>>>());
            Assert.That(expectedResult, Is.EquivalentTo(responseValue));
        }

        [Test]
        public async Task BusinessEntitiesEndpointGetAllUnits_OnMethodCallWithNoParameters_ReturnsRightListOfUnits()
        {
            // Arrange
            await using var context = new MockDb().CreateDbContext();
            IRepository<BusinessEntity> businessRepository = new Repository<BusinessEntity>(context);
            IRepository<Department> departmentRepository = new Repository<Department>(context);
            IRepository<Unit> unitRepository = new Repository<Unit>(context);

            BusinessEntity businessEntity = BusinessEntity.Create("Test Entity1");
            BusinessEntity businessEntity2 = BusinessEntity.Create("Test Entity2");
            Department department = Department.Create(businessEntity.Id, "Test Department");
            Department department2 = Department.Create(businessEntity2.Id, "Test Department2");
            IList<Unit> units = new List<Unit>
            {
                Unit.Create(department.Id, "Test Unit1"),
                Unit.Create(department.Id, "Test Unit2"),
                Unit.Create(department2.Id, "Test Unit3"),
            };

            businessRepository.Add(businessEntity);
            businessRepository.Add(businessEntity2);
            departmentRepository.Add(department);
            unitRepository.AddRange(units);
            businessRepository.SaveChanges();

            Guid? testBusinessEntityId = businessEntity.Id;
            IList<Unit> unitsDto = await unitRepository
                .GetAllAsync();

            IList<UnitDto> expectedResult = unitsDto
                .Select(b => new UnitDto(b.Name, b.Id))
                .ToList();

            //Act
            var response = await BusinessEntitiesEndpointGetAllUnits.HandleAsync(unitRepository);
            var responseValue = ((response as IValueHttpResult).Value) as IList<UnitDto>;

            //Assert
            Assert.That(response, Is.InstanceOf<Ok<IList<UnitDto>>>());
            Assert.That(expectedResult, Is.EquivalentTo(responseValue));
        }
    }
}
