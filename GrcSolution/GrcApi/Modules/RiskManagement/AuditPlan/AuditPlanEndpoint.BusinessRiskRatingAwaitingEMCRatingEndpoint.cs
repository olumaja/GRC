using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 25/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint get management concern risk rating by bussiness name or get all management concern risk rating
 */
    public class BusinessRiskRatingAwaitingEMCRatingEndpoint
    {

        /// <summary>
        /// Get management concern risk rating by bussiness name or get all management concern risk rating
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<BusinessRiskRating> repo, ICurrentUserService currentUserService,
             ClaimsPrincipal user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                List<BusinessRatingAwaitingManagementConcernRatingResp> resp = new List<BusinessRatingAwaitingManagementConcernRatingResp>();
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.Id != null).ToList();
                if (getBusinessRiskRating == null)
                {
                    return TypedResults.NotFound();
                }
                if (getBusinessRiskRating != null)
                {
                    foreach (var item in getBusinessRiskRating)
                    {
                        resp.Add(new BusinessRatingAwaitingManagementConcernRatingResp
                        {
                            Id = item.Id,
                            DateCreated = item.CreatedOnUtc,
                            RequesterName = item.RequesterName,
                            Business = new BusinessRatingAwaitingManagementRatingResp
                            {
                                ARMHoldingCompany = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "ARMHoldingCompany",
                                    DateCreated = item.CreatedOnUtc

                                },
                                ARMIM = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "ARMIM",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMHill = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "ARMHill",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMSecurity = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "ARMSecurity",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMTAM = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "ARMTAM",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMTrustee = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "ARMTrustee",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMSharedService = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "ARMSharedService",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMAgribusiness = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "ARMAgribusiness",
                                    DateCreated = item.CreatedOnUtc
                                },
                                DigitalFinancialService = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
                                    BusinessName = "Digital Financial Service",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMCapital = new BusinessRatingAwaitingManagementRating
                                {
                                    Id = item.Id,
                                    Status = item.Status,
                                    RequesterName = item.RequesterName,
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
