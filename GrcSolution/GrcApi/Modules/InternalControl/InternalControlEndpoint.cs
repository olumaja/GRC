using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 17/10/2024
      * Development Group: GRCTools
      * View all initiated internal control for action owner     
      */
    public class InternalControlEndpoint
    {
        /// <summary>
        /// View all initiated internal control for action owner.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? actionOwnerStatus, DateTime? startDate, DateTime? endDate, IRepository<InternalControlActionOwner> repository, 
            ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {
            if (startDate > endDate)
            {
                return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
            }
            var query = repository.GetContextByConditon(q => q.ActionOwnerEmail.ToLower() == currentUserService.CurrentUserEmail.ToLower())
                                  .Include(q => q.InternalControlAction)
                                  .ThenInclude(b => b.InternalControl)
                                  .OrderByDescending(r => r.CreatedOnUtc);
           
            if (startDate != null || endDate != null)
            {
                query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                              .OrderByDescending(r => r.CreatedOnUtc);
            }

           
            if (!string.IsNullOrEmpty(actionOwnerStatus))
            {
                var status = actionOwnerStatus.ToLower();
                var statusRecommended = new Dictionary<string, InternalControlStatus>
                {
                    {"pending", InternalControlStatus.Pending}, {"rejected", InternalControlStatus.Rejected},
                    {"approved", InternalControlStatus.Approved},{"submitted",  InternalControlStatus.Submitted},
                };

                if (!statusRecommended.ContainsKey(status))
                    return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                query = query.Where(d => d.ActionOwnerStatus == statusRecommended[status])
                            .OrderByDescending(r => r.CreatedOnUtc);
            }

            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;
            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedTasks = Pagination<InternalControlActionOwner>.Create(query, pageNumber, pageSize);

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

            var response = new PaginatedInternalControlForActionOwner(
                paginationMeta, 
                paginatedTasks.Select(q => new GetAllInternalControlForActionOwner
                {
                    ActionOwnerId = q.Id,
                    Title = q.InternalControlAction.InternalControl.Title,
                    DateCreated = q.InternalControlAction.InternalControl.CreatedOnUtc,
                    Status = q.ActionOwnerStatus.ToString()
                }).ToList());

            return TypedResults.Ok(response);
        }
    }
}
