using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using Azure;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using DocumentFormat.OpenXml.Wordprocessing;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 16/10/2024
     * Development Group: GRCTools
     * Get all control dashboard for internal control officer
     */
    public class GetInternalControlDashboardEndpoint
    {
        /// <summary>
        /// Get all control dashboard for internal control officer
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(int pageSize, int pageNumber, string? status, DateTime? startDate, DateTime? endDate, IRepository<InternalControlDashboard> repo, IHttpContextAccessor httpContext)
        {

            try
            {
                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }
                var tasks = repo.GetContextByConditon(x => x.Id != null)
                                     .OrderByDescending(r => r.CreatedOnUtc);

                if (startDate != null || endDate != null)
                {
                    tasks = tasks.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                                  .OrderByDescending(r => r.CreatedOnUtc);
                }

                if (!string.IsNullOrEmpty(status))
                {
                    var getstatus = status.ToLower();
                    var statusRecommended = new Dictionary<string, InternalControlDashboardStatus>
                {
                    {"on hold", InternalControlDashboardStatus.On_Hold}, {"work in progress", InternalControlDashboardStatus.Work_In_Progress},
                    {"completed", InternalControlDashboardStatus.Completed}
                };

                    if (!statusRecommended.ContainsKey(getstatus))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                    tasks = tasks.Where(d => d.Status == statusRecommended[getstatus])
                                .OrderByDescending(r => r.CreatedOnUtc);
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;
                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<InternalControlDashboard>.Create(tasks, pageNumber, pageSize);

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

            var response = new PaginatedControlDashboardListResp(
                PaginationMeta: paginationMeta, 
                paginatedTasks.Select(e => new GetControlDashboardListResp(
                    InternalControlDashboardId: e.Id,
                    ActivityIntervals: e.ActivityIntervals.ToString(),
                    Activity: e.Activity,
                    Comment: e.Comment,
                    DateInitiated: e.CreatedOnUtc,
                    CompletionDate: e.ProposedCompletionDate,
                    ActionOwner: e.ActionOwner,
                    ActionOwnerEmail: e.ActionOwnerEmail,
                    Remarks: e.Remarks,
                    NumberOfTransactionsReviewed: e.NumberOfTransactionsReviewed,
                    Status: e.Status.ToString(),
                    CreatedBy: e.CreatedBy,
                    ModifiedBy: e.ModifiedBy
            )).ToList());

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound(ex.Message);
            }
        }
    }
}
