using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{ /*
 * Original Author: Sodiq Quadre
 * Date Created: 03/06/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 */
    public class GetBusinessRiskRatingForCAFEndpoint
    {

        /// <summary>
        /// Get rated business risk rating
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<BusinessRiskRating> repo, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                List<ViewCAFBusinessRiskRatingResp> resp = new List<ViewCAFBusinessRiskRatingResp>();
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.IsEMCRated == true && c.IsManagementRated == true).ToList();
               
                if (getBusinessRiskRating != null)
                {
                    foreach (var item in getBusinessRiskRating)
                    {                        
                        resp.Add(new ViewCAFBusinessRiskRatingResp
                        {
                            BusinessRiskRatingId = item.Id,
                            DateCreated = item.CreatedOnUtc,
                            RequesterName = item.RequesterName,
                            Business = new BusinessCAF
                            {
                                ARMIM = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,                                   
                                    BusinessName = "ARMIM",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMHoldingCompany = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,                                   
                                    BusinessName = "ARMHoldingCompany",
                                    DateCreated = item.CreatedOnUtc

                                },
                                ARMHill = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,                                  
                                    BusinessName = "ARMHill",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMSecurity = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,                                   
                                    BusinessName = "ARMSecurity",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMTAM = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,                                   
                                    BusinessName = "ARMTAM",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMTrustee = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,                                   
                                    BusinessName = "ARMTrustee",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMSharedService = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,                                   
                                    BusinessName = "ARMSharedService",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMAgribusiness = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,                                  
                                    BusinessName = "ARMAgribusiness",
                                    DateCreated = item.CreatedOnUtc
                                },
                                ARMCapital = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,
                                    BusinessName = "ARMCapital",
                                    DateCreated = item.CreatedOnUtc
                                },
                                DigitalFinancialService = new CAFBusinessDetail
                                {
                                    BusinessRiskRatingId = item.Id,
                                    BusinessName = "Digital Financial Service",
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
