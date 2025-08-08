using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 01/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint get management concern risk rating by bussiness name or get all management concern risk rating
 */
    public class ViewBusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Get management concern risk rating by bussiness name or get all management concern risk rating
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<BusinessRiskRating> repo, IRepository<EMCConcernRiskRating> getEmcConcern,
          IRepository<ManagementConcernRiskRating> managementConcernRating, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                List<ViewBusinessRiskRatingResp> resp = new List<ViewBusinessRiskRatingResp>();
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.IsEMCRated == true && c.IsManagementRated == true && c.Status != BusinessRiskRatingStatus.Approved).ToList();
                if (getBusinessRiskRating == null)
                {
                    return TypedResults.NotFound();
                }
                var emcbusinesses = await getEmcConcern.GetAllAsync();
                var mcbusinesse = await managementConcernRating.GetAllAsync();
                if (getBusinessRiskRating != null)
                {
                    foreach (var item in getBusinessRiskRating)
                    {
                        var geaEMCRating = emcbusinesses.Find(x => x.BusinessRiskRatingId.Equals(item.Id));
                        var geaMCRating = mcbusinesse.Find(x => x.BusinessRiskRatingId.Equals(item.Id));
                        resp.Add(new ViewBusinessRiskRatingResp
                        {
                            Id = item.Id,
                            DateCreated = item.CreatedOnUtc,
                            RequesterName = item.RequesterName,
                            EMCId = geaEMCRating.Id,
                            Business = new Business
                            {
                                ARMIM = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    MgtConcernId = geaMCRating.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "ARMIM",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMHoldingCompany = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "ARMHoldingCompany",
                                    DateCreated = item.CreatedOnUtc

                                },
                                ARMHill = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    MgtConcernId = geaMCRating.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "ARMHill",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMSecurity = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    MgtConcernId = geaMCRating.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "ARMSecurity",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMTAM = new BusinessDetail
                                {
                                    Id = item.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "ARMTAM",
                                    EMCId = geaEMCRating.Id,
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMTrustee = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    MgtConcernId = geaMCRating.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "ARMTrustee",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMSharedService = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "ARMSharedService",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMAgribusiness = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    MgtConcernId = geaMCRating.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "ARMAgribusiness",
                                    DateCreated = item.CreatedOnUtc
                                },
                                DigitalFinancialService = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    MgtConcernId = geaMCRating.Id,
                                    Status = item.Status.ToString(),
                                    BusinessName = "Digital Financial Service",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMCapital = new BusinessDetail
                                {
                                    Id = item.Id,
                                    EMCId = geaEMCRating.Id,
                                    MgtConcernId = geaMCRating.Id,
                                    Status = item.Status.ToString(),
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
