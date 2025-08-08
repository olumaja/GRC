using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 2/07/2024
      * Development Group: GRCTools
      * Compliance Planning: Get report by id Endpoint.     
      */
    public class GetReportById
    {
        /// <summary>
        /// Get report by id Endpoint
        /// </summary>
        /// <param name="ComplianceReportId"></param>
        /// <param name="currentUserService"></param>
        /// <param name="repository"></param>
        /// <param name="docRep"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid ComplianceReportId, ICurrentUserService currentUserService, IRepository<ComplianceCalendar> repository,
            IRepository<Document> docRep
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var report = await repository.GetByIdAsync(ComplianceReportId);
        
            if (report is null)
                return TypedResults.NotFound("Report not found");

            var attachments = new List<GetAttachedReportResponse>();
            var documents = docRep.GetContextByConditon(d => d.ModuleItemId == ComplianceReportId && d.ModuleItemType == ModuleType.Compliance)
                                .ToList();

            if(documents.Count > 0)
            {
                attachments = documents.Select(a => new GetAttachedReportResponse
                {
                    DocumentId = a.Id,
                    DocumentName = a.Name,
                }).ToList();
            }
            
            var response = new GetCompliancePlaningReportByIdResponse(
                ReportName: report.Name,
                Frequency: report.Frequency,
                UnitOfInterest: report.FirmToSubmit,
                DeadLine: report.DeadLine,
                ResponseStatus: report.ResponseStatus.ToString(),
                ReportStatus: report.ReportStatus.ToString(),
                ReasonForRejection:report.ReasonForRejection,
                DateCreated:report.CreatedOnUtc,
                ProcessOfficer: report.ProcessOfficer,
                ApprovedBy: report.ApprovedBy,
                ApprovalDate: report.ApprovalDate,
                Attachments: attachments
            );

            return TypedResults.Ok(response);
        }
    }
}
