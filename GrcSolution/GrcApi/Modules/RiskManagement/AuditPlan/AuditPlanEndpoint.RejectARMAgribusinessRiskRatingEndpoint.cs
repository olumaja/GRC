using Arm.GrcTool.Infrastructure;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 20/03/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * Endpoint to reject business risk rating
  */
    public class RejectARMAgribusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Endpoint to reject armagribusiness risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="repo"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, IRepository<ARMAgribusinessRating> repo,
             ClaimsPrincipal user)
        {
            try
            {
                if (user == null)
                {
                    return TypedResults.BadRequest("User must be logged in");
                }
                //string email = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                var year = DateTime.Now.Year;
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.BusinessRiskRatingId == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved && c.CreatedOnUtc.Year == year).FirstOrDefault();
                if (getBusinessRiskRating != null)
                {
                    getBusinessRiskRating.RejectBusinessRating();
                    repo.SaveChanges();

                    return TypedResults.Ok("Rejected successfully");
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
