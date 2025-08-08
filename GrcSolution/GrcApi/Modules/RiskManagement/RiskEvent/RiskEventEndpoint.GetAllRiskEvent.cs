using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.DocumentManagement;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public class RiskEventEndpointGetAllRiskEvent
    {
        public static async Task<IResult> HandleAsync(
            IRepository<RiskEvent> repository, IRepository<Document> documentRepository, IRepository<BusinessEntity> businessRepo,
            IRepository<Department> deptRepo, IRepository<Unit> unitRepo, ICurrentUserService currentUserService,
            ClaimsPrincipal user
        ) 
        {
            try
            {
                string email = currentUserService.CurrentUserEmail;

                string department = currentUserService.CurrentUserDepartment; //user.Claims.FirstOrDefault(c => c.Type=="department").Value; // this should be converted to extension methods
                IList<RiskEvent> riskEvents = null;
                if (department.ToUpper() == "Risk Management".ToUpper())
                {
                    riskEvents = (await repository.GetAllAsync())
                                                .OrderByDescending(r => r.CreatedOnUtc)
                                                .ToList();
                }
                else
                { // fetch only for currently logged in user
                    riskEvents = await repository.GetContextByConditon(r => r.ReportedByUsername == email)
                                                .OrderByDescending(r => r.CreatedOnUtc)
                                                .ToListAsync();
                }

                var totalRiskThisMonth = riskEvents.Where(r => r.CreatedOnUtc.ToString("yyyy-MM") == DateTime.Now.ToString("yyyy-MM")).Count();
                var todaysTotalRisk = riskEvents.Where(r => DateOnly.FromDateTime(r.CreatedOnUtc) == DateOnly.FromDateTime(DateTime.Now)).Count();
                var totalRisk = riskEvents.Count;

                IList<Guid> riskEventIds = riskEvents.Select(r => r.Id).ToList();
                IList<DocumentDto> documents = documentRepository.GetContextByConditon(d => riskEventIds.Contains(d.ModuleItemId) && d.ModuleItemType == ModuleType.RiskManagement)
                    .Select(d => new DocumentDto(d.Id, d.Name, d.ModuleItemId))
                    .ToList();

                IList<Guid> businessIds = riskEvents.Select(r => r.BusinessEntityId).ToList();
                IList<BusinessEntity> business = businessRepo.GetContextByConditon(b => businessIds.Contains(b.Id)).ToList();
                IList<Guid> deptIds = riskEvents.Select(r => r.DepartmentId).ToList();
                IList<Department> departments = deptRepo.GetContextByConditon(d => deptIds.Contains(d.Id)).ToList();
                IList<Guid> unitIds = riskEvents.Select(r => r.UnitId).ToList();
                IList<Unit> units = unitRepo.GetContextByConditon(u => unitIds.Contains(u.Id)).ToList();


                IList<RiskEventDto> riskEventDtos = riskEvents
                        .Select(r =>
                        new RiskEventDto(
                            r.DateOfIdentification,
                            r.DateOfOccurence,
                            r.Description,
                            r.EstimatedLoss,
                            r.BusinessEntityId,
                            business.Where(b => b.Id == r.BusinessEntityId).Select(b => b.Name).FirstOrDefault(),
                            r.DepartmentId,
                            departments.Where(d => d.Id == r.DepartmentId).Select(d => d.Name).FirstOrDefault(),
                            r.UnitId,
                            units.Where(d => d.Id == r.UnitId).Select(d => d.Name).FirstOrDefault(),
                            documents.Where(d => d.ModuleItemId == r.Id).ToList(),
                            r.ReportedByUsername,
                            r.RiskEventDescription,
                            r.Id,
                            r.CreatedOnUtc,
                            r.AssesmentStatus,
                            r.Requester
                            ))
                        .ToList();

                var response = new RiskEventResponse(
                    TodaysTotalRisk: todaysTotalRisk,
                    TotalsRiskThisMonth: totalRiskThisMonth,
                    TotalsRisk: totalRisk,
                    RiskEvents: riskEventDtos
                );

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
