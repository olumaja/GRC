using Arm.GrcApi.Modules.InfosecRiskAssessment;
using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Shared.Helpers;
using System;
using System.Linq;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 07/18/2025
   * Development Group: GRCTools
   * Get unit title Endpoint
   */
    public class GetUnitTitleEndpoint
    {
        /// <summary>
        /// Get unit title Endpoint
        /// </summary>
        /// <param name="riskRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(string unit, DateTime? startDate, DateTime? endDate, string? search, 
            IRepository<InfosecRiskAssessmentModel> repo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext, int pageSize = 10, int pageNumber = 1, bool isDownload = false)
        {
            try
            {
                if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecISORiskChampion) && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecISOUnitHead))
                    return TypedResults.Forbid();

                var riskAssessment = repo.GetContextByConditon(r => r.Unit == unit && r.Status == RiskAssessmentStatus.Approved);

                if (startDate != null && endDate != null)
                {
                    if (startDate > endDate)
                        return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");

                    riskAssessment = riskAssessment.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date).OrderByDescending(x => x.CreatedOnUtc);
                }
                if (!string.IsNullOrEmpty(search))
                {
                    riskAssessment = riskAssessment.Where(d => d.CreatedBy.Contains(search) || d.ReasonForRejection.Contains(search) || d.Objective.Contains(search) ||
                        d.CreatedBy.Contains(search) || d.ModifiedBy.Contains(search) || d.ActionOwner.Contains(search) ||
                        d.Vulnerability.Contains(search) || d.Threat.Contains(search) || d.Category.Contains(search) ||
                        d.Asset.Contains(search) || d.AssetDescription.Contains(search) || d.ApprovedBy.Contains(search)
                    );
                }

                if (isDownload)
                {
                    var records = riskAssessment.OrderByDescending(x => x.CreatedOnUtc).ToList().Select(t => new GetUnitTitleReports(
                         Unit: t.Unit,
                         Objective: t.Objective,
                         Asset: t.Asset,
                         AssetDescription: t.AssetDescription,
                         RiskAssessmentDate: t.RiskAssessmentDate,
                         Category: t.Category,
                         ConfidentialityRating: t.ConfidentialityRating.ToString(),
                         IntegrityRating: t.IntegrityRating.ToString(),
                         AvailabilityRating: t.AvailabilityRating.ToString(),
                         AssetValue: t.AssetValue,
                         AssetScore: t.AssetScore.ToString(),
                         Vulnerability: t.Vulnerability,
                         VulnerabilityRating: t.VulnerabilityRating.ToString(),
                         Threat: t.Threat,
                         ImpactRating: t.ImpactRating.ToString(),
                         LikehoodOfThreatOccuring: t.LikehoodOfthreatOccuring.ToString(),
                         RiskScore: t.RiskScore,
                         RiskValue: t.RiskValue,
                         RiskOption: t.RiskOption,
                         ControlEffective: t.ControlEffective,
                         ResidualRisk: t.ResidualRisk,
                         RiskOwner: t.Riskowner,
                         ActionOwner: t.ActionOwner,
                         ReasonForRejection: t.ReasonForRejection,
                         ApprovedBy: t.ApprovedBy,
                         DateApproved: t.DateApproved,
                         AdditionalInformation: t.AdditionalInformation,
                         ProposedClosureDate: t.ProposeClosureDate,
                         RemediationStatus: t.RemediationStatus.ToString(),
                         Status: t.Status.ToString(),
                         DateLogged: t.CreatedOnUtc
                    )).ToList();
                    var excelSheetName = "RiskAssessmentUnitReport";
                    var columnHeaders = new List<string>
                    {
                        "Unit", "Objective", "Asset" , "Asset Description", "Risk Assessment Date", "Category", "ConfidentialityRating",
                        "Integrity Rating", "Availability Rating", "Asset Value" , "Asset Score", "Vulnerability", "Vulnerability Rating", "Threat",
                        "Impact Rating", "Likehood Of Threat Occuring", "Risk Score" , "Risk Value", "Risk Option", "Control Effective", "Residual Risk",
                        "Risk Owner", "Action Owner","Reason For Rejection", "Approved By", "Date Approved", "Additional Information",
                        "Proposed Closure Date", "Remediation Status","Status", "Date Logged"
                    };

                    var report = ReportDocument.GenerateExcelDocument(excelSheetName, columnHeaders, records);

                    return TypedResults.File(report, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{excelSheetName}{DateTime.Now:yyyyMMddhhmmss}.xlsx");
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<InfosecRiskAssessmentModel>.Create(riskAssessment, pageNumber, pageSize);

                var paginationMeta = new PaginationMeta
                    (
                        paginatedTasks.HasNextPage,
                        paginatedTasks.HasPreviousPage,
                        paginatedTasks.CurrentPage,
                        paginatedTasks.PageSize,
                        paginatedTasks.TotalPages,
                        paginatedTasks.TotalCount
                    );

                httpContext.HttpContext.Response.AddPagination(paginationMeta);

                var response = new PaginatedGetUnitTitleResponse(
                    paginationMeta,
                    paginatedTasks.OrderByDescending(x => x.CreatedOnUtc).Select(p => new GetUnitTitleResponse
                    {
                        Id = p.Id,
                        DateIdentify = p.CreatedOnUtc,
                        Unit = p.Unit,
                        Category = p.Category,
                        Asset = p.Asset,
                        DescriptionOfAsset = p.AssetDescription,
                        Status = p.Status.GetEnumDestription(),
                    }).ToList()
                );

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Exception: Unit title record was not found");
            }
        }
    }
}
