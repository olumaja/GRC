using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.RestHelper;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 24/05/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 */
    public class GetRatedBusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Get rated business risk rating
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<BusinessRiskRating> repo, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating,
            ClaimsPrincipal user, ICurrentUserService currentUserService
            )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                //string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                //if (requesterUnit != "Internal Audit")
                //{ return TypedResults.Forbid(); }

                var getBusinessRiskRating = await repo.GetAllAsync();
                var getRating = await ratedBusinessRiskRating.GetAllAsync();
                List<GetRatedBusinessRiskRating> result = new List<GetRatedBusinessRiskRating>();
                if (getBusinessRiskRating == null)
                {
                    return TypedResults.NotFound();
                }
                if (getBusinessRiskRating != null)
                {
                    foreach (var item in getBusinessRiskRating)
                    {
                        var getRatingResp = getRating.Find(x => x.BusinessRiskRatingId == item.Id);
                        if (getRatingResp != null)
                        {
                            var ratedBusinessRiskRatingResp = ratedBusinessRiskRating.GetContextByConditon(x => x.BusinessRiskRatingId == getRatingResp.BusinessRiskRatingId);
                            var getRatedBusiness = ratedBusinessRiskRatingResp.Select(p => new GetRatedBusinessRiskRatingResp
                            {
                                BusinessRiskRatingId = p.BusinessRiskRatingId,
                                Business = p.Business,
                                Status = p.Status.ToString(),
                                RequesterName = p.RequesterName,
                                DateCreated = p.CreatedOnUtc
                            }).ToList();
                            GetRatedBusinessRiskRating resp = new GetRatedBusinessRiskRating
                            {
                                Business = getRatedBusiness
                            };
                            result.Add(resp);
                        }

                    }
                    return TypedResults.Ok(result);
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
