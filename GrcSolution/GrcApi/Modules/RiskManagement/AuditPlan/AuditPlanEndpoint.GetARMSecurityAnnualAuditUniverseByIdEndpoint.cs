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
    public class GetARMSecurityAnnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to get ARMSecurity Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="req"></param>
        /// <param name="stockBroking"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMSecurityAnnualAuditUniverse> req, IRepository<AuditUniverseARMSecurityStockBroking> stockBroking,
            ICurrentUserService currentUserService,
            ClaimsPrincipal user)
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
                var getRating = annualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = req.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMSecurity");
                }
                var getstockBroking = stockBroking.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                GetARMSecurityAuditUniverseSummary resp = new GetARMSecurityAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,                 
                    StockBroking = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getstockBroking.BusinessManagerConcern,
                        DirectorConcern = getstockBroking.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getstockBroking.Recommentation,
                        RiskScore2 = getstockBroking.RiskScore,
                        RiskRating = getstockBroking.RiskRating,
                        Recommentation = getstockBroking.Recommentation,
                        January = getstockBroking.January,
                        February = getstockBroking.February,
                        March = getstockBroking.March,
                        April = getstockBroking.April,
                        May = getstockBroking.May,
                        June = getstockBroking.June,
                        July = getstockBroking.July,
                        August = getstockBroking.August,
                        September = getstockBroking.September,
                        October = getstockBroking.October,
                        November = getstockBroking.November,
                        December = getstockBroking.December
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
