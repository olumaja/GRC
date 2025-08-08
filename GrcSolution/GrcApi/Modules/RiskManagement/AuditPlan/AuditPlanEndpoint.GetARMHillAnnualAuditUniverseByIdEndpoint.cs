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
    public class GetARMHillAnnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMHill Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="hillannualaudit"></param>
        /// <param name="hillreq"></param>
        /// <param name="hillarmhill"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> hillannualaudit,
            IRepository<ARMHillAuditUniverse> hillreq, IRepository<AuditUniverseARMHill> hillarmhill,
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
                var getRating = hillannualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = hillreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                }
                var getarmhill = hillarmhill.GetContextByConditon(x => x.ARMHillAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                GetARMHillAuditUniverseSummary resp = new GetARMHillAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,
                    ARMHill = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getarmhill.BusinessManagerConcern,
                        DirectorConcern = getarmhill.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getarmhill.Recommentation,
                        RiskScore2 = getarmhill.RiskScore,
                        RiskRating = getarmhill.RiskRating,
                        Recommentation = getarmhill.Recommentation,
                        January = getarmhill.January,
                        February = getarmhill.February,
                        March = getarmhill.March,
                        April = getarmhill.April,
                        May = getarmhill.May,
                        June = getarmhill.June,
                        July = getarmhill.July,
                        August = getarmhill.August,
                        September = getarmhill.September,
                        October = getarmhill.October,
                        November = getarmhill.November,
                        December = getarmhill.December
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
