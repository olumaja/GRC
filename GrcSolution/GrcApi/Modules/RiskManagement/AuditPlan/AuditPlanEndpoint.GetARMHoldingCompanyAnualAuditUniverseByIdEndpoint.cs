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
    public class GetARMHoldingCompanyAnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get ARMHoldingCompany Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="armholdcoauditUniverse"></param>
        /// <param name="armholdco"></param>
        /// <param name="armHoldCoTreasurySale"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMHoldingCompanyAnnualAuditUniverse> armholdcoauditUniverse,
            IRepository<AuditUniverseARMHoldingCompany> armholdco, IRepository<AuditUniverseARMHoldCoTreasurySale> armHoldCoTreasurySale,
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
                var getArmHoldco = armholdcoauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getArmHoldco == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMHoldingCompany");
                }
                var getarmholdco = armholdco.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getArmHoldco.Id).FirstOrDefault();
                var getarmHoldCoTreasurySale = armHoldCoTreasurySale.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getArmHoldco.Id).FirstOrDefault();

                GetARMHoldngCompanyAuditUniverseSummary resp = new GetARMHoldngCompanyAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,
                    ArmHoldingCompany = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getarmholdco.BusinessManagerConcern,
                        DirectorConcern = getarmholdco.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getarmholdco.Recommentation,
                        RiskScore2 = getarmholdco.RiskScore,
                        RiskRating = getarmholdco.RiskRating,
                        Recommentation = getarmholdco.Recommentation,
                        January = getarmholdco.January,
                        February = getarmholdco.February,
                        March = getarmholdco.March,
                        April = getarmholdco.April,
                        May = getarmholdco.May,
                        June = getarmholdco.June,
                        July = getarmholdco.July,
                        August = getarmholdco.August,
                        September = getarmholdco.September,
                        October = getarmholdco.October,
                        November = getarmholdco.November,
                        December = getarmholdco.December

                    },
                    TreasurySale = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getarmHoldCoTreasurySale.BusinessManagerConcern,
                        DirectorConcern = getarmHoldCoTreasurySale.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getarmHoldCoTreasurySale.Recommentation,
                        RiskScore2 = getarmHoldCoTreasurySale.RiskScore,
                        RiskRating = getarmHoldCoTreasurySale.RiskRating,
                        Recommentation = getarmHoldCoTreasurySale.Recommentation,
                        January = getarmHoldCoTreasurySale.January,
                        February = getarmHoldCoTreasurySale.February,
                        March = getarmHoldCoTreasurySale.March,
                        April = getarmHoldCoTreasurySale.April,
                        May = getarmHoldCoTreasurySale.May,
                        June = getarmHoldCoTreasurySale.June,
                        July = getarmHoldCoTreasurySale.July,
                        August = getarmHoldCoTreasurySale.August,
                        September = getarmHoldCoTreasurySale.September,
                        October = getarmHoldCoTreasurySale.October,
                        November = getarmHoldCoTreasurySale.November,
                        December = getarmHoldCoTreasurySale.December
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
