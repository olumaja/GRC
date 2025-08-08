using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;
using System.Security.Claims;
using FluentValidation;
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
    public class ViewARMTrusteeAnualAuditPlanEndpoint
    {

        /// <summary>
        /// View ARMTrustee Anual Audit Universe
        /// </summary>
        /// <param name="trustee"></param>
        /// <param name="getanualAuditUniverse"></param>
        /// <param name="privateTrust"></param>
        /// <param name="commercialTrust"></param>
        /// <param name="aRMTrusteeAuditUni"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ARMTrusteeRating> trustee,

            IRepository<AnualAuditUniverseRiskRating> getanualAuditUniverse, IRepository<AuditUniverseARMTrusteePrivateTrust> privateTrust,
            IRepository<AuditUniverseARMTrusteeCommercialTrust> commercialTrust,

           IRepository<ARMTrusteeAuditUniverse> aRMTrusteeAuditUni, ClaimsPrincipal user, ICurrentUserService currentUserService
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
                var getRating = trustee.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var businesses = await getanualAuditUniverse.GetAllAsync();
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {

                        var getanualAuditUniverseResp = businesses.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                        var getaRMTrusteeAuditUni = aRMTrusteeAuditUni.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getanualAuditUniverseResp.Id).FirstOrDefault();

                        var getcommercialTrust = commercialTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == getaRMTrusteeAuditUni.Id).FirstOrDefault();
                        var getprivateTrust = privateTrust.GetContextByConditon(x => x.ARMTrusteeAuditUniverseId == getaRMTrusteeAuditUni.Id).FirstOrDefault();

                        var auditUniverse = new ARMTrusteeAuditUniverseResp
                        {
                            BusinessName = "ARMTrustee",
                            busnessRiskRatingId = item.BusinessRiskRatingId,
                            PrivateTrust = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getprivateTrust.BusinessManagerConcern,
                                DirectorConcern = getprivateTrust.DirectorConcern,
                                RiskScore = getprivateTrust.RiskScore,
                                OldRiskScore = getprivateTrust.OldRiskScore,
                                RiskRating = getprivateTrust.RiskRating,
                                Recommentation = getprivateTrust.Recommentation
                            },
                            CommercialTrust = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getcommercialTrust.BusinessManagerConcern,
                                DirectorConcern = getcommercialTrust.DirectorConcern,
                                RiskScore = getcommercialTrust.RiskScore,
                                OldRiskScore = getcommercialTrust.OldRiskScore,
                                RiskRating = getcommercialTrust.RiskRating,
                                Recommentation = getcommercialTrust.Recommentation
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
