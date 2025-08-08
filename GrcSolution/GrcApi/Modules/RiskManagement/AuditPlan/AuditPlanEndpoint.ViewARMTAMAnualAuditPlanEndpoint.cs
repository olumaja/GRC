using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Shared.Helpers;
using System;
using System.Security.Claims;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 28/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint get all business and management concern risk rating
 */
    public class ViewARMTAMAnualAuditPlanEndpoint
    {

        /// <summary>
        /// View ARMTAM Anual Audit Universe
        ///  </summary>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armTAM"></param>
        /// <param name="strategy"></param>
        /// <param name="straTreasuryOperation"></param>
        /// <param name="straFinancialControl"></param>
        /// <param name="strategyTAM"></param>
        /// <param name="operation"></param>
        /// <param name="operTreasuryOpe"></param>
        /// <param name="operFinancialControl"></param>
        /// <param name="operTAM"></param>
        /// <param name="finance"></param>
        /// <param name="financeTreasOp"></param>
        /// <param name="financeControl"></param>
        /// <param name="financeTAM"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceTreasOp"></param>
        /// <param name="complianceFinaControl"></param>
        /// <param name="complianceTAM"></param>
        /// <param name="timeSinceLastARMTAMAudit"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ARMTAMBusinessRiskRating> tam,
             IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMTAMAuditUniverse> armtamauditUniverse,
            IRepository<AuditUniverseARMTAM> logTamaudit, ClaimsPrincipal user, ICurrentUserService currentUserService

            )
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
                var getRating = tam.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var getAnnualAudit = await annualaudit.GetAllAsync();
                if (getRating == null) { return TypedResults.NotFound("ARMHoldingCompany is yet to be approved"); }

                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                        var getAnnualAuditResp = getAnnualAudit.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                        var getarmtamauditUniverse = armtamauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAnnualAuditResp.Id).FirstOrDefault();

                        var getTamaudit = logTamaudit.GetContextByConditon(x => x.ARMTAMAuditUniverseId == getarmtamauditUniverse.Id).FirstOrDefault();

                        var auditUniverse = new ARMTAMAuditUniverseResp
                        {
                            BusinessName = "ARMTAM",
                            busnessRiskRatingId = item.BusinessRiskRatingId,
                            ARMTAM = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getTamaudit.BusinessManagerConcern,
                                DirectorConcern = getTamaudit.DirectorConcern,
                                RiskScore = getTamaudit.RiskScore,
                                OldRiskScore = getTamaudit.OldRiskScore,
                                RiskRating = getTamaudit.RiskRating,
                                Recommentation = getTamaudit.Recommentation
                            }

                        };

                        return TypedResults.Ok(auditUniverse);

                    }

                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }

        }
    }

}
