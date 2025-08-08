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
    public class GetARMTAMAnnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMTAM Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="armTAMannualaudit"></param>
        /// <param name="tamreq"></param>
        /// <param name="armTam"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> armTAMannualaudit,
            IRepository<ARMTAMAuditUniverse> tamreq, IRepository<AuditUniverseARMTAM> armTam,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                var year = DateTime.Now.Year;
                var getRating = armTAMannualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = tamreq.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id && x.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHill");
                }
                var getarmTaml = armTam.GetContextByConditon(x => x.ARMTAMAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                GetARMTAMAuditUniverseSummary resp = new GetARMTAMAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,
                    ArmTAM = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getarmTaml.BusinessManagerConcern,
                        DirectorConcern = getarmTaml.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getarmTaml.Recommentation,
                        RiskScore2 = getarmTaml.RiskScore,
                        RiskRating = getarmTaml.RiskRating,
                        Recommentation = getarmTaml.Recommentation,
                        January = getarmTaml.January,
                        February = getarmTaml.February,
                        March = getarmTaml.March,
                        April = getarmTaml.April,
                        May = getarmTaml.May,
                        June = getarmTaml.June,
                        July = getarmTaml.July,
                        August = getarmTaml.August,
                        September = getarmTaml.September,
                        October = getarmTaml.October,
                        November = getarmTaml.November,
                        December = getarmTaml.December
                    }
                };
                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }


        }
    }
}
