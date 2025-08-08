using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;
using System.Security.Claims;
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
    public class ViewARMAgribusinessAnualAuditPlanEndpoint
    {
        /// <summary>
        /// View ARMAgribusiness Anual Audit Universe
        /// </summary>
        /// <param name="agriRating"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="aRMAgribusinessAudit"></param>
        /// <param name="rfl"></param>
        /// <param name="aafml"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ARMAgribusinessRating> agriRating,
            IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse, IRepository<ARMAgribusinessAuditUniverse> aRMAgribusinessAudit,
            IRepository<AuditUniverseARMAgribusinessRFL> rfl, IRepository<AuditUniverseARMAgribusinessAAFML> aafml,
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
                var getRating = agriRating.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var businesses = await anualAuditUniverse.GetAllAsync();
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                        var getanualAuditUniverseResp = businesses.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                        var getaRMAgribusinessAudit = aRMAgribusinessAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getanualAuditUniverseResp.Id).FirstOrDefault();

                        var getrfl = rfl.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == getaRMAgribusinessAudit.Id).FirstOrDefault();
                        var getaafml = aafml.GetContextByConditon(x => x.ARMAgribusinessAuditUniverseId == getaRMAgribusinessAudit.Id).FirstOrDefault();

                        var auditUniverse = new ARMAgribusinessAuditUniverseResp
                        {
                            BusinessName = "ARMAgribusiness",
                            busnessRiskRatingId = item.BusinessRiskRatingId,
                            RFL = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getrfl.BusinessManagerConcern,
                                DirectorConcern = getrfl.DirectorConcern,
                                RiskScore = getrfl.RiskScore,
                                OldRiskScore = getrfl.OldRiskScore,
                                RiskRating = getrfl.RiskRating,
                                Recommentation = getrfl.Recommentation
                            },
                            AAFML = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaafml.BusinessManagerConcern,
                                DirectorConcern = getaafml.DirectorConcern,
                                RiskScore = getaafml.RiskScore,
                                OldRiskScore = getaafml.OldRiskScore,
                                RiskRating = getaafml.RiskRating,
                                Recommentation = getaafml.Recommentation
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
