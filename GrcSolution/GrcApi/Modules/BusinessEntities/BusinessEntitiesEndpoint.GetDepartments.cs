using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GrcApi.Modules.BusinessEntities
{
    public class BusinessEntitiesEndpointGetDepartments
    {
        public static async Task<IResult> HandleAsync(Guid businessEntityId ,IRepository<Department> repository)
        {
            IList<Department> departments = await repository
                .GetContextByConditon( d=> d.BusinessEntityId == businessEntityId )
                .ToListAsync();
            IList<DepartmentDto> departmentDtos = departments
                .Select(b => new DepartmentDto(b.Name, b.Id))
                .ToList();
            return TypedResults.Ok(departmentDtos);
        }
    }

    public record DepartmentDto(String Name, Guid id);
}
