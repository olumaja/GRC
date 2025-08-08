using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;
using System.Security.Claims;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 28/03/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  */
    public class ViewDigitalFinancialServiceAnualAuditPlanEndpoint
    {
        /// <summary>
        /// View Digital Financial Service Anual Audit Universe
        /// </summary>
        /// <param name="dfsRating"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="dfsAudit"></param>
        /// <param name="dfs"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<DigitalFinancialServiceBusinessRiskRating> dfsRating,
            IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse, IRepository<DigitalFinancialServiceAuditUniverse> dfsAudit, IRepository<AuditUniverseDigitalFinancialServiceRating> dfs,

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
                var getRating = dfsRating.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var businesses = await anualAuditUniverse.GetAllAsync();
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                        var getanualAuditUniverseResp = businesses.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                        var getdfsAuditAudit = dfsAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getanualAuditUniverseResp.Id).FirstOrDefault();

                        var getdfs = dfs.GetContextByConditon(x => x.DigitalFinancialServiceAuditUniverseId == getdfsAuditAudit.Id).FirstOrDefault();

                        var auditUniverse = new DigitalFinancialServiceAuditUniverseResp
                        {
                            BusinessName = "Digital Financial Service",
                            busnessRiskRatingId = item.BusinessRiskRatingId,
                            DigitalFinancialService = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getdfs.BusinessManagerConcern,
                                DirectorConcern = getdfs.DirectorConcern,
                                RiskScore = getdfs.RiskScore,
                                OldRiskScore = getdfs.OldRiskScore,
                                RiskRating = getdfs.RiskRating,
                                Recommentation = getdfs.Recommentation
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
