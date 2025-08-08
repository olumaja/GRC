using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;
using System.Security.Claims;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 28/03/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * This endpoint get all business and management concern risk rating
  */
    public class ViewARMHillAnualAuditPlanEndpoint
    {
        /// <summary>
        /// View ARMHill Anual Audit Universe
        /// </summary>
        /// <param name="hillRating"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="aRMHillAudit"></param>
        /// <param name="hill"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ARMHillRating> hillRating,
            IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse, IRepository<ARMHillAuditUniverse> aRMHillAudit, IRepository<AuditUniverseARMHill> hill,


           ICurrentUserService currentUserService, ClaimsPrincipal user
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
                var getRating = hillRating.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var businesses = await anualAuditUniverse.GetAllAsync();
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                        var getanualAuditUniverseResp = businesses.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                        var getaRMHillAudit = aRMHillAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getanualAuditUniverseResp.Id).FirstOrDefault();

                        var gethill = hill.GetContextByConditon(x => x.ARMHillAuditUniverseId == getaRMHillAudit.Id).FirstOrDefault();

                        var auditUniverse = new ARMHillAuditUniverseResp
                        {
                            BusinessName = "ARMHill",
                            busnessRiskRatingId = item.BusinessRiskRatingId,
                            ARMHill = new AuditUniverseResp
                            {
                                BusinessManagerConcern = gethill.BusinessManagerConcern,
                                DirectorConcern = gethill.DirectorConcern,
                                RiskScore = gethill.RiskScore,
                                OldRiskScore = gethill.OldRiskScore,
                                RiskRating = gethill.RiskRating,
                                Recommentation = gethill.Recommentation
                            },

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
