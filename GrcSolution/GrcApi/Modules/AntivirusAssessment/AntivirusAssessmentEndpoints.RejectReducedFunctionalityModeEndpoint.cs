using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 05/31/2025
        * Development Group: GRCTools
        * Reject Reduced Functionality Mode endpoint
        */
    public class RejectReducedFunctionalityModeEndpoint
    {
        /// <summary>
        /// Reject Reduced Functionality Mode endpoint
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
           RejectAntivirusAssessmentReq payload, IRepository<ReducedFunctionalityMode> repo, ICurrentUserService currentUserService
        )
        {
            try
            {
                string requesterName = currentUserService.CurrentUserFullName;
                var update = repo.GetContextByConditon(r => r.Id == payload.antivirusId && r.Status == AntivirusStatus.Resolved).FirstOrDefault();
                if (update is null) return TypedResults.NotFound("Antivirus Assessment was not found or it has not been resolved");
                if (update.Action == AntivirusStatus.Approve)
                {
                    return TypedResults.BadRequest("Antivirus Assessment has been previously approved");
                }
                update.RejectReducedFunctionalityMode(payload.Comment);
                update.SetModifiedBy(requesterName);
                update.SetModifiedOnUtc(DateTime.Now);
                repo.SaveChanges();

                return TypedResults.Ok("Rejected Successfully");
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest("Exception: Unable to rejected the Antivirus Assessment");
            }
        }
    }
}
