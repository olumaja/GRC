using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 02/04/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * This endpoint get Annual Audit Universe By anualAuditUniverseId
  */
    public class GetDigitalFinancialServiceAnnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get Digital Financial Service Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="dfsannualaudit"></param>
        /// <param name="dfsreq"></param>
        /// <param name="dfsRate"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> dfsannualaudit,
            IRepository<DigitalFinancialServiceAuditUniverse> dfsreq, IRepository<AuditUniverseDigitalFinancialServiceRating> dfsRate,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var getRating = dfsannualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = dfsreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                }
                var getdfsRate = dfsRate.GetContextByConditon(x => x.DigitalFinancialServiceAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                GetDigitalFinancialServiceAuditUniverseSummary resp = new GetDigitalFinancialServiceAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,
                    DigitalFinancialService = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getdfsRate.BusinessManagerConcern,
                        DirectorConcern = getdfsRate.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getdfsRate.Recommentation,
                        RiskScore2 = getdfsRate.RiskScore,
                        RiskRating = getdfsRate.RiskRating,
                        Recommentation = getdfsRate.Recommentation,
                        January = getdfsRate.January,
                        February = getdfsRate.February,
                        March = getdfsRate.March,
                        April = getdfsRate.April,
                        May = getdfsRate.May,
                        June = getdfsRate.June,
                        July = getdfsRate.July,
                        August = getdfsRate.August,
                        September = getdfsRate.September,
                        October = getdfsRate.October,
                        November = getdfsRate.November,
                        December = getdfsRate.December
                    }
                };
                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
