using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;
using System.Security.Claims;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 28/03/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * This endpoint get all business and management concern risk rating
  */
    public class ViewARMSecurityAnualAuditPlanEndpoint
    {
        ///<summary>
        /// View ARMSecurity Anual Audit Universe
        /// </summary>
        /// <param name="securityRating"></param>
        /// <param name="auditUniverse"></param>
        /// <param name="aRMSecurityAnnualAudit"></param>
        /// <param name="stockBroking"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ARMSecurityRating> securityRating,
            IRepository<AnualAuditUniverseRiskRating> auditUniverse, IRepository<ARMSecurityAnnualAuditUniverse> aRMSecurityAnnualAudit,
           IRepository<AuditUniverseARMSecurityStockBroking> stockBroking,          
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
                var getRating = securityRating.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var getanualAuditUniverse = await auditUniverse.GetAllAsync();
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                        var getanualAuditUniverseResp = getanualAuditUniverse.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                        var getaRMSecurityAnnualAudit = aRMSecurityAnnualAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getanualAuditUniverseResp.Id).FirstOrDefault();

                        var getstockBroking = stockBroking.GetContextByConditon(x => x.ARMSecurityAnnualAuditUniverseId == getaRMSecurityAnnualAudit.Id).FirstOrDefault();

                        var result = new ARMSecurityAuditUniverseResp
                        {
                            BusinessName = "ARMSecurity",
                            busnessRiskRatingId = item.BusinessRiskRatingId,                         
                            StockBroking = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getstockBroking.BusinessManagerConcern,
                                DirectorConcern = getstockBroking.DirectorConcern,
                                RiskScore = getstockBroking.RiskScore,
                                OldRiskScore = getstockBroking.OldRiskScore,
                                RiskRating = getstockBroking.RiskRating,
                                Recommentation = getstockBroking.Recommentation
                            }                          
                        };
                        return TypedResults.Ok(result);
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
