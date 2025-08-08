using Arm.GrcTool.Domain.DocumentManagement;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using Microsoft.EntityFrameworkCore;
using GrcApi.Modules.Shared;
using System.Security.Claims;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public class RiskEventEndpointGetRiskEventStatistics
    {
        public static async Task<IResult> HandleAsync(
            IRepository<RiskEvent> repository, IRepository<Document> documentRepository, IRepository<BusinessEntity> businessRepo,
            IRepository<Department> deptRepo, ClaimsPrincipal user, IRepository<Unit> unitRepo, ICurrentUserService currentUserService, Status status = Status.Pending
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                IList<RiskEvent> riskEvents = null;
                riskEvents = await repository.GetContextByConditon(r => r.AssesmentStatus == status).ToListAsync();


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

                return TypedResults.Ok(riskEventDtos);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
