using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 04/04/2025
   * Development Group: GRCTools
   * Action owner get all logged incidence
   */
    public class ActionOwnerGetLoggedIncidenceEndpoint
    {
        /// <summary>
        /// Get all logged incidence
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="status"></param>
        /// <param name="securityArea"></param>
        /// <param name="severity"></param>
        /// <param name="incidentTag"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="search"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? status, string? securityArea, string? severity, DateTime? startDate, DateTime? endDate, string? search,
            IRepository<IncidentManagementLog> repo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {
            try
            {
                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }
                 var logIncident = repo.GetContextByConditon(x => x.ActionOwnerEmailAddress.ToLower() == currentUserService.CurrentUserEmail.ToLower());

                if (startDate != null || endDate != null)
                {
                    logIncident = logIncident.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date);
                }

                if (!string.IsNullOrWhiteSpace(status))
                {
                    var getStatus = status.ToLower();
                    var statusRecommended = new Dictionary<string, ActionStatus>
                    {
                        {"open", ActionStatus.Open}, {"work in progress", ActionStatus.Work_In_Progress}, {"closed",  ActionStatus.Closed}
                    };

                    if (!statusRecommended.ContainsKey(getStatus))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                    logIncident = logIncident.Where(d => d.Status == statusRecommended[getStatus]);
                }

                if (!string.IsNullOrWhiteSpace(securityArea))
                {
                    var getSecurityAreaategory = securityArea.ToLower();
                    var securityAreaCategoryRecommended = new Dictionary<string, SecurityAreaCategory>
                    {
                        {"availability", SecurityAreaCategory.Availability}, {"integrity", SecurityAreaCategory.Integrity},
                        {"confidentiality", SecurityAreaCategory.Confidentiality}
                    };

                    if (!securityAreaCategoryRecommended.ContainsKey(getSecurityAreaategory))
                        return TypedResults.BadRequest($"Enter one of the following recommended Security Area Category {string.Join(",", securityAreaCategoryRecommended.Keys)}");

                    logIncident = logIncident.Where(d => d.SecurityArea == securityAreaCategoryRecommended[getSecurityAreaategory]);
                }

                if (!string.IsNullOrWhiteSpace(severity))
                {
                    var severityCategory = severity.ToLower();
                    var severityCategoryRecommended = new Dictionary<string, SeverityCategory>
                    {
                        {"low", SeverityCategory.Low}, {"high", SeverityCategory.High},
                        {"medium", SeverityCategory.Medium}

                    };

                    if (!severityCategoryRecommended.ContainsKey(severityCategory))
                        return TypedResults.BadRequest($"Enter one of the following recommended Severity Category {string.Join(",", severityCategoryRecommended.Keys)}");

                    logIncident = logIncident.Where(d => d.Severity == severityCategoryRecommended[severityCategory]);
                }
                               
                if (!string.IsNullOrWhiteSpace(search))
                {
                    logIncident = logIncident.Where(d => d.SecurityIncident.Contains(search) || d.DescriptionOfIncident.Contains(search) ||
                        d.CreatedBy.Contains(search) || d.RootCause.Contains(search) || d.RecommendationToPreventFutureReoccurence.Contains(search) || d.ActionOwnerComment.Contains(search) ||
                        d.InfoSecRecommendation.Contains(search) || d.InfoSecStaffEmailAddress.Contains(search) || d.InfoSecStaffName.Contains(search) || d.TypeOfAsset.Contains(search) ||
                        d.ActionOwnerName.Contains(search) || d.AssetDescription.Contains(search) || d.Impact.Contains(search) || d.ActionOwnerEmailAddress.Contains(search) ||
                        d.DescriptionOfActionTaken.Contains(search) || d.LessonLearnt.Contains(search) || d.ReportingStaffComment.Contains(search)
                    );
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<IncidentManagementLog>.Create(logIncident.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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

                var response = new PaginatedGetLogIncidenceResp(
                 paginationMeta,
                   paginatedTasks.Select(e => new GetLogIncidenceResponse
                   {
                       IncidenceId = e.Id,
                       SecurityIncident = e.SecurityIncident,
                       SecurityAreas = e.SecurityAreas,
                       Severity = e.Severity.ToString(),
                       ReportingStaff = e.ReportingStaff,
                       DateOfClosure = e.DateOfClosure,
                       DateOfReporting = e.CreatedOnUtc,
                       DateOfIncidence = e.DateOfReporting,
                       DescriptionOfIncident = e.DescriptionOfIncident,
                       TypeOfAsset = e.TypeOfAsset,
                       ReportingUnit = e.ReportingUnit,
                       Status = e.Status.ToString(),
                   }).ToList());

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record was not found");
            }
        }
    }
}
