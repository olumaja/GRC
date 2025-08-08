using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.DocumentManagement;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public class RiskEventEndpointGetRiskEventDetails
    {
        /// <summary>
        /// Get the risk event details for the riskEventId
        /// </summary>
        /// <param name="riskEventId"></param>
        /// <param name="riskEventRepository"></param>
        /// <param name="documentRepository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid riskEventId, IRepository<RiskEvent> riskEventRepository, IRepository<Document> documentRepository, ICurrentUserService currentUserService,
            IRepository<BusinessEntity> businessRepo, IRepository<Department> deptRepo, IRepository<Unit> unitRepo, ClaimsPrincipal user
        )
        {
            try
            {
                RiskEvent riskEvent = await riskEventRepository.GetByIdAsync(riskEventId);
                IList<DocumentDto> documents = documentRepository.GetContextByConditon(d => d.ModuleItemId == riskEvent.Id && d.ModuleItemType == ModuleType.RiskManagement)
                    .Select(d => new DocumentDto(d.Id, d.Name, d.ModuleItemId))
                    .ToList();

                BusinessEntity business = await businessRepo.GetByIdAsync(riskEvent.BusinessEntityId);
                Department department = await deptRepo.GetByIdAsync(riskEvent.DepartmentId);
                Unit unit = await unitRepo.GetByIdAsync(riskEvent.UnitId);

                RiskEventDto riskEventDto = new(
                            riskEvent.DateOfIdentification,
                            riskEvent.DateOfOccurence,
                            riskEvent.Description,
                            riskEvent.EstimatedLoss,
                            riskEvent.BusinessEntityId,
                            business.Name,
                            riskEvent.DepartmentId,
                            department.Name,
                            riskEvent.UnitId,
                            unit.Name,
                            documents,
                            riskEvent.ReportedByUsername,
                            riskEvent.RiskEventDescription,
                            riskEvent.Id,
                            riskEvent.CreatedOnUtc,
                            riskEvent.AssesmentStatus,
                            riskEvent.Requester
                            );

                return TypedResults.Ok(riskEventDto);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
