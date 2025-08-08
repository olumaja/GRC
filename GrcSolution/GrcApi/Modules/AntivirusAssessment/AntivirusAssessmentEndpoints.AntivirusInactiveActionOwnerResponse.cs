using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.VulnerabilityManagement;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class AntivirusInactiveActionOwnerResponseEndpoint
    {
        public static async Task<IResult> HandleAsync(
            HttpRequest payload, IRepository<AntivirusAssessmentModel> antiVirusRepo, IRepository<InactiveSensors> inactiveRepo,
            IRepository<Document> docRepo, IEmailService EmailService, IConfiguration config, ICurrentUserService currentUserService
        )
        {
            var forms = await payload.ReadFormAsync();
            int count = 0;
            var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "docx", "jpeg", "png" };
            var statusAllow = new Dictionary<string, AntivirusStatus> {
                { "RESOLVED", AntivirusStatus.Resolved }, { "PENDING", AntivirusStatus.Pending}
            };
            var evidences = new List<AntivirusAssessmentDTO>();

            while (true)
            {
                var antiVirusModelIdKey = $"AntivirusModelId{count}";
                var inactiveSensorIdKey = $"InactiveSensorId{count}";
                var statusKey = $"Status{count}";
                var actionOwnerCommentKey = $"ActionOwnerComment{count}";
                var evidenceFileKey = $"EvidenceFile{count}";

                if (!forms.ContainsKey(antiVirusModelIdKey) || !forms.ContainsKey(inactiveSensorIdKey) || !forms.ContainsKey(statusKey))
                    break;

                Guid antiVirusModelId;
                Guid inactiveSensorId;

                if (!Guid.TryParse(forms[antiVirusModelIdKey], out antiVirusModelId))
                    return TypedResults.BadRequest($"The anti-virus model id {forms[antiVirusModelIdKey]} is not valid");

                if (!Guid.TryParse(forms[inactiveSensorIdKey], out inactiveSensorId))
                    return TypedResults.BadRequest($"The inactive sensor id {forms[inactiveSensorIdKey]} is not valid");

                var status = forms[statusKey].ToString();
                status = status.ToUpper();

                if (string.IsNullOrWhiteSpace(status) || !statusAllow.ContainsKey(status))
                    return TypedResults.BadRequest("Status can only be Resolved or Pending");

                var file = forms.Files.GetFile(evidenceFileKey);

                if (file != null)
                {
                    var fileExtension = Path.GetExtension(file.FileName).Trim('.').ToLower();

                    if (!fileTypeAllow.Contains(fileExtension))
                        return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");
                }
                var actionOwnerComment = forms[actionOwnerCommentKey].ToString();

                evidences.Add(new AntivirusAssessmentDTO(
                    AntiVirusModelId: antiVirusModelId,
                    InactiveSensorId: inactiveSensorId,
                    Status: statusAllow[status],
                    ActionOwnerComment: actionOwnerComment,
                    Attachment: file
                ));

                count++;
            }

            if (count == 0)
                return TypedResults.BadRequest("No response submitted");

            var antivirus = antiVirusRepo.GetContextByConditon(v => v.Id == evidences[0].AntiVirusModelId)
                                                .Include(v => v.InactiveSensors)
                                                .FirstOrDefault();

            if (antivirus is null)
                return TypedResults.NotFound("Record doesnot exist");

            if (antivirus.ActionOwnerEmail.ToLower() != currentUserService.CurrentUserEmail.ToLower())
                return TypedResults.Forbid();

            antivirus.InactiveSensorsStatusAfterActionOwnerResponse();
            antivirus.SetModifiedBy(currentUserService.CurrentUserFullName);
            antivirus.SetModifiedOnUtc(DateTime.Now);

            var inactiveSensors = antivirus.InactiveSensors;

            //Add attachments
            List<Document> attachedFiles = new();

            foreach (var evidence in evidences)
            {
                var index = inactiveSensors.FindIndex(v => v.Id == evidence.InactiveSensorId);

                if (index >= 0)
                {
                    inactiveSensors[index].UpdateAfterActionOwnerResponse(evidence.Status, evidence.ActionOwnerComment);

                    if (evidence.Attachment != null)
                        attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(evidence.Attachment, ModuleType.InfoSecAntivirusInactiveSensor, evidence.InactiveSensorId));
                }
                    
            }

            if (attachedFiles.Count > 0)
                await docRepo.AddRangeAsync(attachedFiles);

            await docRepo.SaveChangesAsync();

            #region Send email to the infosec staff      
            DateTime currentMonth = antivirus.CreatedOnUtc;
            string currentMonthFormatted = currentMonth.ToString("MMMM yyyy");
            string subject = $"Antivirus Assessment for {currentMonthFormatted}";
            var linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = antivirus.RequesterEmailAddress;
            string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
            string body = $"Dear {antivirus.CreatedBy}, <br><br>This is to notify you that the remediation has been completed for the {currentMonthFormatted} Antivirus Assessment. <br><br> The necessary changes have been implemented. Kindly log on here and verify <br><br><a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InfoSecAntivirusInactiveSensor, antivirus.Id, emailTo, toCC);

            #endregion

            return TypedResults.Ok("Response submitted successfully");
        }
    }
}
