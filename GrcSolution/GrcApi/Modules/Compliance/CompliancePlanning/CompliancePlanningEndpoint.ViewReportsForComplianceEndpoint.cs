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
    public class ViewReportsForComplianceEndpoint
    {
        /// <summary>
        /// Get all reports for compliance
        /// </summary>
        /// <param name="currentUserService"></param>
        /// <param name="calendarRepo"></param>
        /// <returns>List<GetCompliancePlaningReportForComplianceDto></returns>
        public static async Task<IResult> HandleAsync(
            string? businessName, ICurrentUserService currentUserService, IRepository<ComplianceCalendar> calendarRepo
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var response = new List<GetCompliancePlaningReportForComplianceDto>();
            IQueryable<ComplianceCalendar> reports = calendarRepo.GetAll(); ;

            if(!string.IsNullOrWhiteSpace(businessName))
                reports = calendarRepo.GetContextByConditon(r => r.FirmToSubmit == businessName);
            
            response = reports.OrderByDescending(x => x.CreatedOnUtc)
                            .Select(x => new GetCompliancePlaningReportForComplianceDto
            {
                ReportId = x.Id,
                ReportStatus = x.ReportStatus.ToString(),
                ResponseStatus = x.ResponseStatus.ToString(),
                ReportName = x.Name,
                Frequency = x.Frequency,
                Deadline = x.DeadLine,
                UnitOfInterest = x.FirmToSubmit,
                ReasonForRejection = x.ReasonForRejection,
                DateCreated = x.CreatedOnUtc,
                ProcessOfficer = x.ProcessOfficer,
                ApprovedBy = x.ApprovedBy,
                ApprovalDate = x.ApprovalDate
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
