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
    public class GetARMAgribusinessAnnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMAgribusiness Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="agrreq"></param>
        /// <param name="agraafml"></param>
        /// <param name="agrirfl"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMAgribusinessAuditUniverse> agrreq, IRepository<AuditUniverseARMAgribusinessAAFML> agraafml,
            IRepository<AuditUniverseARMAgribusinessRFL> agrirfl, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                var getAuditRating = agrreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMAgribusiness");
                }
                var getrfl = agrirfl.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getaafml = agraafml.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                GetARMAgribusinessAuditUniverseSummary resp = new GetARMAgribusinessAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,
                    RFL = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getrfl.BusinessManagerConcern,
                        DirectorConcern = getrfl.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getrfl.Recommentation,
                        RiskScore2 = getrfl.RiskScore,
                        RiskRating = getrfl.RiskRating,
                        Recommentation = getrfl.Recommentation,
                        January = getrfl.January,
                        February = getrfl.February,
                        March = getrfl.March,
                        April = getrfl.April,
                        May = getrfl.May,
                        June = getrfl.June,
                        July = getrfl.July,
                        August = getrfl.August,
                        September = getrfl.September,
                        October = getrfl.October,
                        November = getrfl.November,
                        December = getrfl.December
                    },
                    AAFML = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getaafml.BusinessManagerConcern,
                        DirectorConcern = getaafml.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getaafml.Recommentation,
                        RiskScore2 = getaafml.RiskScore,
                        RiskRating = getaafml.RiskRating,
                        Recommentation = getaafml.Recommentation,
                        January = getaafml.January,
                        February = getaafml.February,
                        March = getaafml.March,
                        April = getaafml.April,
                        May = getaafml.May,
                        June = getaafml.June,
                        July = getaafml.July,
                        August = getaafml.August,
                        September = getaafml.September,
                        October = getaafml.October,
                        November = getaafml.November,
                        December = getaafml.December
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
