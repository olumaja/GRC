using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.BusinessEntities;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.BusinessEntities
{
    public class BusinessEntitiesEndpointGetAllUnits
    {
        public static async Task<IResult> HandleAsync(IRepository<Unit> repository, Guid? businessEntityId = null)
        {
            IList<Unit> units = (businessEntityId != null) ? await repository
                .GetContextByConditon(d => d.Department.BusinessEntityId == businessEntityId)
                .ToListAsync() : await repository.GetAllAsync();

            IList<UnitDto> unitDtos = units
                .Select(b => new UnitDto(b.Name, b.Id))
                .ToList();
            return TypedResults.Ok(unitDtos);
        }
    }
}
