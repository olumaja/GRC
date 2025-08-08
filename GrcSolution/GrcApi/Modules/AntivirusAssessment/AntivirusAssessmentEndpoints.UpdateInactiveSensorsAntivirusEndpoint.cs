using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class UpdateInactiveSensorsAntivirusEndpoint
    {
        /// <summary>
        /// Update inactive sensor
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="docRepo"></param>
        /// <param name="inactiveRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            UpdateInactivesensorsDto payload, IRepository<Document> docRepo, IRepository<AntivirusAssessmentModel> antiVirusRepo, IRepository<InactiveSensors> inactiveRepo, IConfiguration config, IEmailService EmailService, ICurrentUserService currentUserService
        )
        { 
            try
            {
                var inactiveSensor = inactiveRepo.GetContextByConditon(a => a.Id == payload.InactiveSensorsId && a.Action == AntivirusStatus.Rejected)
                                               .Include(a => a.AntivirusAssessmentModel)
                                               .FirstOrDefault();

                if (inactiveSensor is null)
                    return TypedResults.NotFound("Record not found");

                if (inactiveSensor.AntivirusAssessmentModel.ActionOwnerEmail.ToLower() != currentUserService.CurrentUserEmail.ToLower())
                    return TypedResults.Forbid();

                var statusAllow = new Dictionary<string, AntivirusStatus> {
                { "RESOLVED", AntivirusStatus.Resolved }, { "PENDING", AntivirusStatus.Pending}
            };

                var antivirus = antiVirusRepo.GetContextByConditon(v => v.Id == inactiveSensor.AntivirusAssessmentModelId)
                                                   .Include(v => v.InactiveSensors)
                                                   .FirstOrDefault();
                if (antivirus is null)
                    return TypedResults.NotFound("Record doesnot exist");

                var status = payload.Status.ToUpper();
                if (!statusAllow.ContainsKey(status))
                    return TypedResults.BadRequest("Status can only be Resolved or Pending");

                inactiveSensor.EditInactiveSensor(new UpdateInactivesensor
                (
                    ActionownerComment: payload.ActionownerComment,
                    Status: statusAllow[status]
                ));

                inactiveSensor.ResetAction();
                inactiveSensor.AntivirusAssessmentModel.InactiveSensorsStatusAfterActionOwnerResponse();
                inactiveSensor.AntivirusAssessmentModel.SetModifiedBy(currentUserService.CurrentUserFullName);
                inactiveSensor.AntivirusAssessmentModel.SetModifiedOnUtc(DateTime.Now);

                //Remove previous attachment if exist
                docRepo.BulkDelete(x => x.ModuleItemId == payload.InactiveSensorsId && x.ModuleItemType == ModuleType.InfoSecAntivirusInactiveSensor);
                // Add attachment if available
                if (payload.Attachment != null)
                {
                    var evidence = DocumentExtensions.ConvertFormFileToDocument(payload.Attachment, ModuleType.InfoSecAntivirusInactiveSensor, payload.InactiveSensorsId);
                    docRepo.Add(evidence);
                }

                inactiveRepo.SaveChanges();

                #region Send email to the infosec staff      
                DateTime currentMonth = antivirus.CreatedOnUtc;
                string currentMonthFormatted = currentMonth.ToString("MMMM yyyy");
                string subject = $"Antivirus Assessment for {currentMonthFormatted} Updated";
                var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = antivirus.RequesterEmailAddress;
                string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                string body = $"Dear {antivirus.CreatedBy}, <br><br>This is to notify you that the remediation has been updated for the {currentMonthFormatted} Antivirus Assessment. <br><br> The necessary changes have been implemented. Kindly log on here and verify <br><br><a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InfoSecAntivirusInactiveSensor, antivirus.Id, emailTo, toCC);

                #endregion
                return TypedResults.Ok("Update successful");
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Exception: Antivirus Assessment record was not found");
            }
        }
    }
}
