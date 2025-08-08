using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 05/31/2025
        * Development Group: GRCTools
        * Approval for the Inactive Sensors endpoint
        */
    public class ApproveInactiveSensorsAntivirusEndpoint
    {
        /// <summary>
        /// Approval for the Inactive Sensors endpoint
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="inactiveSensor"></param>
        /// <param name="antiVir"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
           ApproveAntivirusAssessmentRequest payload, IRepository<InactiveSensors> inactiveSensor, IRepository<AntivirusAssessmentModel> antiVir, ICurrentUserService currentUserService
        )
        {
            try
            {
                var update = inactiveSensor.GetContextByConditon(v => v.Id == payload.antivirusId && v.Status == AntivirusStatus.Resolved).FirstOrDefault();
                if (update is null) return TypedResults.NotFound("Antivirus Assessment was not found or it has not been resolved");
                if (update.Action == AntivirusStatus.Approve)
                {
                    return TypedResults.BadRequest("Antivirus Assessment has been previously approved");
                }
                var updateantiVir = antiVir.GetContextByConditon(v => v.Id == update.AntivirusAssessmentModelId).FirstOrDefault();

                updateantiVir.UpdateApproval(currentUserService.CurrentUserFullName);
                update.ApproveAntivirusAssessment();
                update.SetModifiedBy(currentUserService.CurrentUserFullName);
                update.SetModifiedOnUtc(DateTime.Now);
                inactiveSensor.SaveChanges();

                return TypedResults.Ok("Approved successfully");
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest("Approval was not successfully");
            }
        }
    }
}
