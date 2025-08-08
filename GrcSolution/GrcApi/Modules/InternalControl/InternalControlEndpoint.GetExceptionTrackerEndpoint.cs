using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using DocumentFormat.OpenXml.Wordprocessing;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using System.Linq;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 16/10/2024
     * Development Group: GRCTools
     * Get all exception for internal control officer
     */
    public class GetExceptionTrackerEndpoint
    {
        /// <summary>
        /// Get all exception for internal control officer
        /// </summary>
        /// <param name="exRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, DateTime? startDate, DateTime? endDate, IRepository<InternalControlExceptionTracker> exRepo, IHttpContextAccessor httpContext
        )
        {            

            var exceptions = exRepo.GetContextByConditon(x => x.ExceptionTrackerStatus != ExceptionTrackerStatus.Deleted)
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
