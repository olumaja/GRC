//using Arm.GrcApi.Modules.RiskManagement;
//using Arm.GrcTool.Domain.RiskControlSelfAssessment;
//using Arm.GrcTool.Infrastructure;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Http;
//using GrcApi.Modules.BusinessEntities;
//using Microsoft.EntityFrameworkCore;
//using Arm.GrcApi.Modules.RiskManagement.RCSA;

//namespace GrcApi.UnitTests.Modules.RiskManagement.RCSA
//{
//    public class RiskControlSelfAssessmentEndpointGetRCSATests
//    {
//        [Test]
//        public async Task RiskControlSelfAssessmentEndpointGetRCSA_CallMethodWithValidRCSAId_ReturnsDetailOfCreatedRCSA()
//        {
//            // Arrange
//            await using var context = new MockDb().CreateDbContext();
//            IRepository<RiskControlSelfAssessment> repository = new Repository<RiskControlSelfAssessment>(context);

//            //create rcsa list
//            List<RiskControlSelfAssessmentUnit> units = new()
//                {
//                    RiskControlSelfAssessmentUnit.Create(Guid.Parse("ED35D0D5-8FB0-4A05-AB80-E28620A3D69E")),
//                    RiskControlSelfAssessmentUnit.Create(Guid.Parse("D96247A0-749A-4CBF-AA79-0BB30C687E7F"))
//                };

//            RiskControlSelfAssessment rcsa = RiskControlSelfAssessment.Create(DateOnly.FromDateTime(DateTime.Now),
//            DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
//            DateOnly.FromDateTime(DateTime.Now),
//            DateOnly.FromDateTime(DateTime.Now.AddMonths(7)),
//            units);

//            repository.Add(rcsa);
//            repository.SaveChanges();

//            RiskControlSelfAssessmentDto? expectedResult = await repository.GetContextByConditon(r => r.Id.Equals(rcsa.Id))
//            .Include(e => e.RiskControlSelfAssessmentUnits).Select(r => new RiskControlSelfAssessmentDto
//            {
//                CreatedDate = r.CreatedOnUtc,
//                PeriodFrom = r.PeriodFrom,
//                PeriodTo = r.PeriodTo,
//                StartDate = r.StartDate,
//                EndDate = r.EndDate,
//                Id = r.Id,
//                //Status = r.Status.ToString(),
//                RiskControlSelfAssessmentUnits = r.RiskControlSelfAssessmentUnits.Select(u => new UnitDto(u.Unit.Name, u.Unit.Id)).ToList(),
//                NumberOfRiskControlSelfAssessmentUnits = r.RiskControlSelfAssessmentUnits.Count
//            }).FirstOrDefaultAsync();

//            //Act
//            var response = await RiskControlSelfAssessmentEndpointGetRCSA.HandleAsync(repository, rcsa.Id);
//            var responseValue = ((response as IValueHttpResult).Value) as RiskControlSelfAssessmentDto;

//            //Assert
//            Assert.IsInstanceOf<Ok<RiskControlSelfAssessmentDto>>(response);
//            Assert.That(expectedResult.RiskControlSelfAssessmentUnits, Is.EquivalentTo(responseValue.RiskControlSelfAssessmentUnits));
//            Assert.That(expectedResult.Id, Is.EqualTo(responseValue.Id));
//        }
//    }
//}
