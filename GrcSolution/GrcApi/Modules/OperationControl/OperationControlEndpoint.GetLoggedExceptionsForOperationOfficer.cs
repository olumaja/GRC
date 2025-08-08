using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.OperationControl
{
    public class GetLoggedExceptionsForOperationOfficerEndpoint
    {
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? status, DateTime? startDate, DateTime? endDate, IRepository<OperationControl> repoControl,
            IHttpContextAccessor httpContext
        )
        {
            var query = repoControl.GetAll();

            if (startDate is not null && endDate is not null)
            {
                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("EndDate cannot be earlier than StartDate");
                }

                query = query.Where(q => q.CreatedOnUtc.Date >= startDate.Value.Date && q.CreatedOnUtc.Date <= endDate.Value.Date);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                var getstatus = status.ToLower();

                var statusRecommended = new Dictionary<string, ExceptionStatus> {
                    { "open", ExceptionStatus.Open }, { "closed", ExceptionStatus.Closed },
                    { "submitted", ExceptionStatus.Submitted }, { "rejected", ExceptionStatus.Rejected },
                    { "approved", ExceptionStatus.Approved }
                };

                if (!statusRecommended.ContainsKey(getstatus))
                    return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                query = query.Where(q => q.Status == statusRecommended[getstatus]);
            }

            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;

            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedExceptions = Pagination<OperationControl>.Create(query.OrderByDescending(q => q.CreatedOnUtc), pageNumber, pageSize);

            var paginationMeta = new PaginationMeta
                (
                    paginatedExceptions.HasNextPage,
                    paginatedExceptions.HasPreviousPage,
                    paginatedExceptions.CurrentPage,
                    paginatedExceptions.PageSize,
                    paginatedExceptions.TotalPages,
                    paginatedExceptions.TotalCount
            );

            httpContext.HttpContext.Response.AddPagination(paginationMeta);

            var response = new PaginatedOperationControl(
                PaginationMeta: paginationMeta,
                paginatedExceptions.Select(e => new OperationControlResp {
                    LoggedBy = e.CreatedBy,
                    OperationalActivity = e.OperationActivity,
                    TransactionCallOverType = e.TransactionCallOverType,
                    ExceptionSummary = e.ExceptionDescription,
                    ActionPoint = e.ActionPoint,
                    ActionOwner = e.ActionOwner,
                    Unit = e.Unit,
                    ExceptionCategory = e.ExceptionCategory.ToString(),
                    ProposedDeadline = e.CompletionDate,
                    DateResolved = e.DateResolved,
                    Status = e.Status.ToString()
                }).ToList()
            );

            return TypedResults.Ok(response);
        }
    }
}
 