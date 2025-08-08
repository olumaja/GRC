using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class UpdateReduceFunctionalityAntivirusEndpoint
    {
        public static async Task<IResult> HandleAsync(
            UpdateReduceFunctionalityDto payload, IRepository<Document> docRepo, IRepository<AntivirusAssessmentModel> antiVirusRepo, IRepository<ReducedFunctionalityMode> reduceRepo, IEmailService EmailService, IConfiguration config, ICurrentUserService currentUserService
        )
        { 
            try
            {
                var reduceFunctionality = reduceRepo.GetContextByConditon(a => a.Id == payload.ReducedFunctionalityModeId && a.Action == AntivirusStatus.Rejected)
                                               .Include(a => a.AntivirusAssessmentModel)
                                               .FirstOrDefault();

                if (reduceFunctionality is null)
                    return TypedResults.NotFound("Record not found");

                if (reduceFunctionality.AntivirusAssessmentModel.ActionOwnerEmail.ToLower() != currentUserService.CurrentUserEmail.ToLower())
                    return TypedResults.Forbid();

                var antivirus = antiVirusRepo.GetContextByConditon(v => v.Id == reduceFunctionality.AntivirusAssessmentModelId)
                                                    .Include(v => v.ReducedFunctionalityMode)
                                                    .FirstOrDefault();

                if (antivirus is null)
                    return TypedResults.NotFound("Record doesnot exist");
                var statusAllow = new Dictionary<string, AntivirusStatus> {
                { "RESOLVED", AntivirusStatus.Resolved }, { "PENDING", AntivirusStatus.Pending}
            };

                var status = payload.Status.ToUpper();
                if (!statusAllow.ContainsKey(status))
                    return TypedResults.BadRequest("Status can only be Resolved or Pending");

                reduceFunctionality.EditReduceFunctionality(new UpdateReduceFunctionality
                (
                    ActionownerComment: payload.ActionownerComment,
                    Status: statusAllow[status]
                ));

                reduceFunctionality.ResetAction();
                reduceFunctionality.AntivirusAssessmentModel.InactiveSensorsStatusAfterActionOwnerResponse();
                reduceFunctionality.AntivirusAssessmentModel.SetModifiedBy(currentUserService.CurrentUserFullName);
                reduceFunctionality.AntivirusAssessmentModel.SetModifiedOnUtc(DateTime.Now);

                //Remove previous attachment if exist
                docRepo.BulkDelete(x => x.ModuleItemId == payload.ReducedFunctionalityModeId && x.ModuleItemType == ModuleType.InfoSecAntivirusReduceFunctionality);
                // Add attachment if available
                if (payload.Attachment != null)
                {
                    var evidence = DocumentExtensions.ConvertFormFileToDocument(payload.Attachment, ModuleType.InfoSecAntivirusReduceFunctionality, payload.ReducedFunctionalityModeId);
                    docRepo.Add(evidence);
                }
                reduceRepo.SaveChanges();
                #region Send email to the infosec staff      
                DateTime currentMonth = antivirus.CreatedOnUtc;
                string currentMonthFormatted = currentMonth.ToString("MMMM yyyy");
                string subject = $"Antivirus Assessment for {currentMonthFormatted} Updated";
                var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = antivirus.RequesterEmailAddress;
                string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                string body = $"Dear {antivirus.CreatedBy}, <br><br>This is to notify you that the remediation has been updated for the {currentMonthFormatted} Antivirus Assessment. <br><br> The necessary changes have been implemented. Kindly log on here and verify <br><br><a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InfoSecAntivirusReduceFunctionality, antivirus.Id, emailTo, toCC);

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
