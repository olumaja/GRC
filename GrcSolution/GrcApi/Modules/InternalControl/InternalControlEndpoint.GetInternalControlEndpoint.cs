using Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;
using System;
using System.Linq;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 10/11/2024
      * Development Group: GRCTools
      * View all initiated internal control.     
      */
    public class GetInternalControlEndpoint
    {
        /// <summary>
        /// View all initiated internal control.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? actionOwnerStatus, DateTime? startDate, DateTime? endDate, IConfiguration config, IRepository<InternalControlModel> repository, IHttpContextAccessor httpContext
        )
        {            
            if (startDate > endDate)
            {
                return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
            }

           var query = repository.GetContextByConditon(x => x.Status == InternalControlStatus.Open)
                                  .OrderByDescending(r => r.CreatedOnUtc);
           
            if (startDate != null || endDate != null)
            {
                query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                             .OrderByDescending(r => r.CreatedOnUtc);
            }
            if (!string.IsNullOrWhiteSpace(actionOwnerStatus))
            {
                var status = actionOwnerStatus.ToLower();
                var statusRecommended = new Dictionary<string, InternalControlStatus>
                {                    
                    {"open", InternalControlStatus.Open}, {"closed", InternalControlStatus.Closed},
                    {"pending", InternalControlStatus.Pending}, {"rejected", InternalControlStatus.Rejected},
                    {"approved", InternalControlStatus.Approved},{"submitted",  InternalControlStatus.Submitted},
                };

                if (!statusRecommended.ContainsKey(status))
                    return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                query = query.Where(d => d.Status == statusRecommended[status])
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

            var response = new PaginatedAllInternalControl(
                paginationMeta, 
                paginatedTasks.Select(q => new GetAllInternalControlResp
                {
                    InternalControlId = q.Id,
                    Title = q.Title,
                    DateCreated = q.CreatedOnUtc,
                    Collaborators = q.NoOfCollaboration,
                    ActionOwners = q.NoOfActionOwners,
                    Status = q.Status.ToString()
                }).ToList());

            return TypedResults.Ok(response);
        }
    }
}
