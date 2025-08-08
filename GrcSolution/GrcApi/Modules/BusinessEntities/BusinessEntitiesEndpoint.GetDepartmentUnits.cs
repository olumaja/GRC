using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GrcApi.Modules.BusinessEntities
{
    public class BusinessEntitiesEndpointGetUnits
    {
        public static async Task<IResult> HandleAsync(Guid departmentId, IRepository<Unit> repository)
        {
            IList<Unit> units = await repository
                .GetContextByConditon(d => d.DepartmentId == departmentId)
                .ToListAsync();
            IList<UnitDto> unitDtos = units
                .Select(b => new UnitDto(b.Name, b.Id))
                .ToList();
            return TypedResults.Ok(unitDtos);
        }
    }

    public record UnitDto(String Name, Guid id);
}
