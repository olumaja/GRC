using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System.Security.Claims;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 28/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint get all business and management concern risk rating
*/
    public class ViewARMHoldingCompanyAnualAuditPlanEndpoint
    {

        /// <summary>
        /// View ARMHolding Company Anual Audit Universe
        /// </summary>
        /// <param name="HoldcoRating"></param>
        /// <param name="annualAudit"></param>
        /// <param name="holdcoAnnualAudit"></param>
        /// <param name="annualAuditHoldCo"></param>
        /// <param name="annualAuditTreasurySale"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ARMHoldingCompanyBusinessRating> HoldcoRating,
            IRepository<AnualAuditUniverseRiskRating> annualAudit, IRepository<ARMHoldingCompanyAnnualAuditUniverse> holdcoAnnualAudit,
            IRepository<AuditUniverseARMHoldingCompany> annualAuditHoldCo, IRepository<AuditUniverseARMHoldCoTreasurySale> annualAuditTreasurySale,
            ClaimsPrincipal user, ICurrentUserService currentUserService

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
                var getarmholdcoRating = HoldcoRating.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var getAnnualAudit = await annualAudit.GetAllAsync();
                if (getarmholdcoRating == null) { return TypedResults.NotFound("ARMHoldingCompany is yet to be approved"); }
                foreach (var item in getarmholdcoRating)
                {
                    var getAnnualAuditResp = getAnnualAudit.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                    var getholdcoAnnualAudit = holdcoAnnualAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getAnnualAuditResp.Id).FirstOrDefault();

                    var getannualAuditHoldCo = annualAuditHoldCo.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getholdcoAnnualAudit.Id).FirstOrDefault();
                    var getannualAuditTreasurySale = annualAuditTreasurySale.GetContextByConditon(x => x.ARMHoldingCompanyAnnualAuditUniverseId == getholdcoAnnualAudit.Id).FirstOrDefault();

                    var auditUniverse = new ARMHoldingCompanyAuditUniverseResp
                    {
                        BusinessName = "ARMHoldingCompany",
                        busnessRiskRatingId = item.BusinessRiskRatingId,
                        ARMHoldingCompany = new AuditUniverseResp
                        {
                            BusinessManagerConcern = getannualAuditHoldCo.BusinessManagerConcern,
                            DirectorConcern = getannualAuditHoldCo.DirectorConcern,
                            RiskScore = getannualAuditHoldCo.RiskScore,
                            OldRiskScore = getannualAuditHoldCo.OldRiskScore,
                            RiskRating = getannualAuditHoldCo.RiskRating,
                            Recommentation = getannualAuditHoldCo.Recommentation
                        },
                        TreasurySale = new AuditUniverseResp
                        {
                            BusinessManagerConcern = getannualAuditTreasurySale.BusinessManagerConcern,
                            DirectorConcern = getannualAuditTreasurySale.DirectorConcern,
                            RiskScore = getannualAuditTreasurySale.RiskScore,
                            OldRiskScore = getannualAuditTreasurySale.OldRiskScore,
                            RiskRating = getannualAuditTreasurySale.RiskRating,
                            Recommentation = getannualAuditTreasurySale.Recommentation
                        },
                    };

                    return TypedResults.Ok(auditUniverse);


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
