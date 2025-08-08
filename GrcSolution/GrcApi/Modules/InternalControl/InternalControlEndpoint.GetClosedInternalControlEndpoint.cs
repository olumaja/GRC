using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 22/10/2024
      * Development Group: GRCTools
      * Get all closed investigations    
      */
    public class GetClosedInternalControlEndpoint
    {
        /// <summary>
        /// Get all closed investigations
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, DateTime? startDate, DateTime? endDate, IRepository<InternalControlModel> repository, IHttpContextAccessor httpContext)
        {

            if (startDate > endDate)
            {
                return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
            }

            var query = repository.GetContextByConditon(q => q.Status == InternalControlStatus.Closed)
                                  .OrderByDescending(r => r.CreatedOnUtc);
            if (startDate != null || endDate != null)
            {
                query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                              .OrderByDescending(r => r.CreatedOnUtc);
            }

            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;
            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedTasks = Pagination<InternalControlModel>.Create(query, pageNumber, pageSize);

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

            var response = new PaginatedClosedInternalControl(
                paginationMeta,
                paginatedTasks.Select(q => new GetClosedInternalControlResponse
                {
                    InternalControlId = q.Id,
                    Title = q.Title,
                    DateCreated = q.CreatedOnUtc,
                    DateModified = q.ModifiedOnUtc,
                    InitiatingOfficer = q.CreatedBy,
                    Collaborators = q.Collaborators
                }).ToList());

            return TypedResults.Ok(response);
           
        }
    }
}
