using Arm.GrcApi.Modules.InfosecRiskAssessment;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcApi.Modules.ISMSReporting
{
    public class GetRiskAssessmentReportingEndpoint
    {
        public static async Task<IResult> HandleAsync(IRepository<InfosecRiskAssessmentModel> riskRepo)
        {
            var riskAssessments = riskRepo.GetAll()
                                          .ToList();

            var distinctUnits = riskAssessments.DistinctBy(r => r.Unit).Select(r => r.Unit).ToList();
            var response = new List<RiskAssessmentReportResponse>();

            foreach (var unit in distinctUnits) { 
                int count = riskAssessments.Where(r => r.Unit == unit).Count();
                response.Add(new RiskAssessmentReportResponse(Unit: unit, RiskCount: count));
            }

            return TypedResults.Ok(response);
        }
    }
}
