using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /* Original Author: Sodiq Quadre
      * Date Created: 16/10/2024
      * Development Group: GRCTools
      * Get all resolved exception for internal control officer
      */
    public class GetAllRejectedExceptionTrackerEndpoint
    {
        /// <summary>
        /// Get all resolved exception for internal control officer
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="exRepo"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, DateTime? startDate, DateTime? endDate, IRepository<InternalControlExceptionTracker> exRepo, IHttpContextAccessor httpContext
        )
        {
            try
            {
                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }

                var exceptions = exRepo.GetContextByConditon(x => x.ExceptionTrackerStatus == ExceptionTrackerStatus.Rejected)
                                        .OrderByDescending(r => r.CreatedOnUtc);

                if (startDate != null || endDate != null)
                {
                    exceptions = exceptions.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                                  .OrderByDescending(r => r.CreatedOnUtc);
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
            catch (Exception ex)
            {

                return TypedResults.NotFound("Exception: Rejected exceptions was not found");
            }
        }
    }
}
