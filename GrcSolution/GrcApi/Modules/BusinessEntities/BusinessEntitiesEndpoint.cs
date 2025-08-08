using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.BusinessEntities
{
    public class BusinessEntitiesEndpoint
    {
        public static async Task<IResult> HandleAsync(IRepository<BusinessEntity> repository) {
            IList<BusinessEntity> businessEntities= await repository.GetAllAsync();
            IList<BusinessEntityDto> businessEntityDtos = businessEntities
                .Select(b => new BusinessEntityDto(b.Name, b.Id))
                .ToList();
            return TypedResults.Ok(businessEntityDtos);
        }
    }

    public record BusinessEntityDto( String Name, Guid id);
}
