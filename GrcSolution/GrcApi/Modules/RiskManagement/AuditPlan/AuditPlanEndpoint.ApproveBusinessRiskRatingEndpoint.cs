using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 04/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * Endpoint to approve business risk rating
 */
    public class ApproveBusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Endpoint to approve business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, IRepository<BusinessRiskRating> repo,

             ClaimsPrincipal user)
        {
            try
            {
                if (user == null)
                {
                    return TypedResults.BadRequest("User must be logged in");
                }
                // string email = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                var year = DateTime.Now.Year;
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.Id == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved && c.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getBusinessRiskRating != null)
                {
                    getBusinessRiskRating.ApproveBusinessRiskRatingStatus();
                    repo.SaveChanges();                                     

                    return TypedResults.Ok("Approved successfully");
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
                return TypedResults.Problem(ex.Message);
            }

        }


    }
}
