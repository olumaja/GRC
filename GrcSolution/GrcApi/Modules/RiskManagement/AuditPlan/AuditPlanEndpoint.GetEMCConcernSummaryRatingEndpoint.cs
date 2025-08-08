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
 * This endpoint to get all management concern risk rating
 */
    public class GetEMCConcernSummaryRatingEndpoint
    {

        /// <summary>
        /// This endpoint to get all management concern risk rating
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<EMCConcernRiskRating> getEmcConcern, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                List<ViewEMCRatingResp> resp = new List<ViewEMCRatingResp>();
                var getEMCRatings = getEmcConcern.GetContextByConditon(c => c.Id != null).ToList();
                if (getEMCRatings == null)
                {
                    return TypedResults.NotFound();
                }
                if (getEMCRatings != null)
                {
                    foreach (var item in getEMCRatings)
                    {
                        resp.Add(new ViewEMCRatingResp
                        {
                            EMCId = item.Id,
                            BusinessRiskRatingId = item.BusinessRiskRatingId,
                            RequesterName = item.EmcRequesterName,
                            Comment = item.Comment,
                            DateCreated = item.CreatedOnUtc                         

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
