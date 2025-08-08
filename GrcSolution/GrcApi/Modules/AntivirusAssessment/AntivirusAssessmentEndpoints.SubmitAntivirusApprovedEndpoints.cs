using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcTool.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class SubmitAntivirusApprovedEndpoints
    {
        public static async Task<IResult> HandleAsync(SubmitAntivirusAssessmentDt0 payload, IRepository<AntivirusAssessmentModel> antiVirus)
        {
            var getantiVirus = antiVirus.GetContextByConditon(v => v.Id == payload.antivirusAssessmentFileId)
                                                .Include(v => v.InactiveSensors)
                                                .Include(x => x.ReducedFunctionalityMode)
                                                .FirstOrDefault();
            if (getantiVirus is null)
                return TypedResults.NotFound("Record not found");

            if (getantiVirus.InactiveSensors.Any(v => v.Action != AntivirusStatus.Approve))
                return TypedResults.BadRequest("Some records are yet to be approve for the Inactive Sensors");

            if (getantiVirus.ReducedFunctionalityMode.Any(v => v.Action != AntivirusStatus.Approve))
                return TypedResults.BadRequest("Some records are yet to be approve for the Reduced Functionality Mode");

            getantiVirus.SetInactiveSensorsInfosecFeedbackStatus(AntivirusStatus.Completed, string.Empty);
            getantiVirus.SetModifiedOnUtc(DateTime.Now);
            antiVirus.SaveChanges();
            return TypedResults.Ok("Submit successful");
        }
    }
}

