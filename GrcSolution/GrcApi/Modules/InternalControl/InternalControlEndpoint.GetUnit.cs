using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;

namespace GrcApi.Modules.InternalControl
{
    public class InternalControlUnitEndpoint
    {
        public static async Task<IResult> HandleAsync(IRepository<Unit> repository)
        {
            var units = repository.GetAll();

            return TypedResults.Ok(units.Select(u => new UnitResponse(u.Name)).ToHashSet());
        }
    }

    public record UnitResponse(string Name);
}
