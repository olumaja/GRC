using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 04/18/2024
* Development Group: Audit Development Plan - GRCTools
* This endpoint get audit universe summary
*/
    public class Monthlyaudituniversesummary
    {

        /// <summary>
        /// Audit universe summary
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<AnualAuditUniverseRiskRating> repo, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                List<ViewAuditUniverseSummaryResp> resp = new List<ViewAuditUniverseSummaryResp>();
                var getAuditUniverse = repo.GetContextByConditon(c => c.Id != null).ToList();
                if (getAuditUniverse == null)
                {
                    return TypedResults.NotFound("No record found");
                }
                if (getAuditUniverse != null)
                {
                    foreach (var item in getAuditUniverse)
                    {
                        resp.Add(new ViewAuditUniverseSummaryResp
                        {
                            AnualAuditUniverseId = item.Id,
                            BusinessristRatingId = item.BusinessRiskRatingId,
                            DateCreated = item.CreatedOnUtc,
                            RequesterName = item.RequesterName,
                            AuditUniverse = new AuditUniverse
                            {
                                ARMIM = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "ARMIM",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMHoldingCompany = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "ARMHoldingCompany",
                                    DateCreated = item.CreatedOnUtc

                                },
                                ARMHill = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "ARMHill",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMSecurity = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "ARMSecurity",
                                    DateCreated = item.CreatedOnUtc
                                },                               
                                ARMTrustee = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "ARMTrustee",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMAgribusiness = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "ARMAgribusiness",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMSharedService = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "ARMSharedService",
                                    DateCreated = item.CreatedOnUtc
                                },
                                DigitalFinancialService = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "Digital Financial Service",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMCapital = new AuditUniverseDetail
                                {
                                    AnualAuditUniverseId = item.Id,
                                    BusinessristRatingId = item.BusinessRiskRatingId,
                                    BusinessName = "ARMCapital",
                                    DateCreated = item.CreatedOnUtc
                                }
                            }

                        });

                    }
                    return TypedResults.Ok(resp);
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
