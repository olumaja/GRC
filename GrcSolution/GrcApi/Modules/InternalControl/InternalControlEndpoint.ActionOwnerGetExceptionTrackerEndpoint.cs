using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using DocumentFormat.OpenXml.Wordprocessing;
using GrcApi.Modules.Shared.Helpers;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using System.Linq;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
     * Original Author: Sodiq  Quadre
     * Date Created: 16/10/2024
     * Development Group: GRCTools
     * Get all exception for internal control officer
     */
    public class ActionOwnerGetExceptionTrackerEndpoint
    {
        /// <summary>
        /// Get all exception for internal control officer
        /// </summary>
        /// <param name="exRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? status, string? impactRating, DateTime? startDate, DateTime? endDate, IRepository<InternalControlExceptionTracker> exRepo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {
           
           var exceptions = exRepo.GetContextByConditon(x => x.ResponsibleOfficerEmail == currentUserService.CurrentUserEmail && x.SupervisorStatus == ExceptionTrackerStatus.Approved)           
                                    .OrderByDescending(r => r.CreatedOnUtc);
            if (startDate > endDate)
            {
                return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
            }
            if (startDate != null || endDate != null)
            {
                exceptions = exceptions.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                              .OrderByDescending(r => r.CreatedOnUtc);
            }
            if (!string.IsNullOrEmpty(status))
            {
                var getstatus = status.ToLower();
                var statusRecommended = new Dictionary<string, ExceptionTrackerStatus>
                 {
                     {"resolved", ExceptionTrackerStatus.Resolved}, {"not resolved", ExceptionTrackerStatus.Not_Resolved},
                     {"deleted", ExceptionTrackerStatus.Deleted}, {"approved", ExceptionTrackerStatus.Approved}, {"rejected", ExceptionTrackerStatus.Rejected},
                 };

                if (!statusRecommended.ContainsKey(getstatus))
                    return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                exceptions = exceptions.Where(d => d.ExceptionTrackerStatus == statusRecommended[getstatus])
                            .OrderByDescending(r => r.CreatedOnUtc);
            }
           
            if (!string.IsNullOrEmpty(impactRating))
            {
                var ratings = new List<string> { "very low", "low", "medium", "high", "very high" };
                var rating = impactRating.ToLower();

                if (!ratings.Contains(rating))
                    return TypedResults.BadRequest($"The allowed ratings are {string.Join(", ", ratings)}");

                exceptions = exceptions.Where(t => t.ImpactRating.ToLower() == rating).OrderByDescending(r => r.CreatedOnUtc); 
            }

            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;
            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedTasks = Pagination<InternalControlExceptionTracker>.Create(exceptions, pageNumber, pageSize);

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

            var response = new PaginatedInternalControlExceptionResponse(
                paginationMeta, 
                paginatedTasks.Select(e => new InternalControlExceptionResponse(
                ExceptionTrackerId: e.Id,
                Exception: e.Exception,
                Unit: e.Unit,
                NatureOfException: e.NatureOfException,
                ControlImpact: e.ControlImpact,
                ImpactRating: e.ImpactRating,
                TransactionCount: e.TransactionCount,
                ActivityImpacted: e.ActivityImpacted,
                Recommendation: e.Recommendation,
                ResponsibleOfficer: e.ResponsibleOfficer,
                Deadline: e.Deadline,
                ManagementResponse: e.ManagementResponse,
                Status: e.ExceptionTrackerStatus.ToString(),
                SupervisorStatus: e.SupervisorStatus.ToString(),
                DateCreated: e.CreatedOnUtc,
                ModifiedDate: e.ModifiedOnUtc
            )).ToList());

            return TypedResults.Ok(response);
        }
    }
}
