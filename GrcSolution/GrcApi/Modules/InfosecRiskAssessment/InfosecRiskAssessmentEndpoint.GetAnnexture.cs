using Arm.GrcTool.Infrastructure;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class GetAnnextureEndpoint
    {
        public static async Task<IResult> HandleAsync(IRepository<Annexture> repository)
        {
            var annextures = repository.GetAll().Select(a => new AnnextureResponse { Id = a.Id, Annexture = a.Name}).ToList();

            return TypedResults.Ok(annextures);
        }
    }
}
