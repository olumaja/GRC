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
    public class GetARMTrusteeAnnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to get ARMTrustee Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="req"></param>
        /// <param name="privateTrust"></param>
        /// <param name="commercialTrust"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMTrusteeAuditUniverse> req, IRepository<AuditUniverseARMTrusteePrivateTrust> privateTrust,
            IRepository<AuditUniverseARMTrusteeCommercialTrust> commercialTrust, ICurrentUserService currentUserService,
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
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMTrustee");
                }
                var getprivateTrust = privateTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getcommercialTrust = commercialTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                GetARMTrusteeAuditUniverseSummary resp = new GetARMTrusteeAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,

                    PrivateTrust = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getprivateTrust.BusinessManagerConcern,
                        DirectorConcern = getprivateTrust.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getprivateTrust.Recommentation,
                        RiskScore2 = getprivateTrust.RiskScore,
                        RiskRating = getprivateTrust.RiskRating,
                        Recommentation = getprivateTrust.Recommentation,
                        January = getprivateTrust.January,
                        February = getprivateTrust.February,
                        March = getprivateTrust.March,
                        April = getprivateTrust.April,
                        May = getprivateTrust.May,
                        June = getprivateTrust.June,
                        July = getprivateTrust.July,
                        August = getprivateTrust.August,
                        September = getprivateTrust.September,
                        October = getprivateTrust.October,
                        November = getprivateTrust.November,
                        December = getprivateTrust.December
                    },
                    CommercialTrust = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getcommercialTrust.BusinessManagerConcern,
                        DirectorConcern = getcommercialTrust.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getcommercialTrust.Recommentation,
                        RiskScore2 = getcommercialTrust.RiskScore,
                        RiskRating = getcommercialTrust.RiskRating,
                        Recommentation = getcommercialTrust.Recommentation,
                        January = getcommercialTrust.January,
                        February = getcommercialTrust.February,
                        March = getcommercialTrust.March,
                        April = getcommercialTrust.April,
                        May = getcommercialTrust.May,
                        June = getcommercialTrust.June,
                        July = getcommercialTrust.July,
                        August = getcommercialTrust.August,
                        September = getcommercialTrust.September,
                        October = getcommercialTrust.October,
                        November = getcommercialTrust.November,
                        December = getcommercialTrust.December
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
