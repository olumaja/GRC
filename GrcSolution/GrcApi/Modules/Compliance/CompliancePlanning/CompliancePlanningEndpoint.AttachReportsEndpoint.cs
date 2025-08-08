using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 2/07/2024
      * Development Group: GRCTools
      * Compliance Planning: Attach report Endpoint.     
      */
    public class AttachReportsEndpoint
    {
        /// <summary>
        /// The endpoint enable user to attach reports for compliance
        /// </summary>
        /// <param name="attachReport"></param>
        /// <param name="currentUserService"></param>
        /// <param name="complianceRepo"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            AttachReportDto attachReport, ICurrentUserService currentUserService, IRepository<ComplianceCalendar> complianceRepo, IRepository<Document> docRepo
        )
        {
            bool isDeadline = false;
            var report = await complianceRepo.GetByIdAsync(attachReport.ComplianceReportId);

            if (report is null)
                return TypedResults.NotFound("Report not found");

            if (attachReport.Attachments is null || attachReport.Attachments.Count == 0)
                return TypedResults.BadRequest("Please attach report");

            var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "csv", "docx" }; 

            foreach (var attachment in attachReport.Attachments)
            {
                var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                if (!fileTypeAllow.Contains(fileExtension))
                    return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");
            }

            //Remove previously attached reports --- This serve as edit endpoint 
            var oldReports = docRepo.GetContextByConditon(r => r.ModuleItemId == report.Id && r.ModuleItemType == ModuleType.Compliance);
            docRepo.RemoveRange(oldReports);

            //handle attachments
            List<Document> attachedFiles = new();
            foreach (var attachment in attachReport.Attachments)
            {
                attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.Compliance, report.Id));
            }
            //Parallel.ForEach(attachReport.Attachments, a => attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(a, ModuleType.Compliance, report.Id)));
            await docRepo.AddRangeAsync(attachedFiles);
            
            if (report.DeadLine >= DateTime.Now)
                isDeadline = true;

            report.AddProcessOfficer(currentUserService.CurrentUserFullName);
            report.SetModifiedOnUtc(DateTime.Now);
            report.ResponseStatusAfterUploadingReport(isDeadline);
            report.UpdateAttachmentCount(attachReport.Attachments.Count);
            complianceRepo.SaveChanges();
            return TypedResults.Ok("Attached report successfully");
        }
    }
}
