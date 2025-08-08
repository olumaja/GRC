using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Wordprocessing;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;

namespace Arm.GrcApi.Modules.OperationControl
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 16/10/2024
    * Development Group: GRCTools
    * Get all operation exception for the action owner
    */
    public class GetActionOwnerOperationExceptionEndpoint
    {
        /// <summary>
        /// Get all operation exception for the action owner
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="dateCreated"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? resolutionStatus, string? exceptionCategory, DateTime? startDate, DateTime? endDate, string? search,
            IRepository<OperationControl> repo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {

            try
            {
                if(startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }

                var myExceptions = repo.GetContextByConditon(x => x.ActionOwnerEmail.ToLower() == currentUserService.CurrentUserEmail.ToLower());

              
                if(startDate != null || endDate != null)
                {
                    myExceptions = myExceptions.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date);
                }

                if(!string.IsNullOrWhiteSpace(resolutionStatus))
                {
                    var getStatus = resolutionStatus.ToLower();
                    var statusRecommended = new Dictionary<string, ExceptionStatus>
                    {
                        {"approved", ExceptionStatus.Approved}, {"resolved", ExceptionStatus.Resolved}, {"approved as exception",  ExceptionStatus.Approved_As_Exception},
                        {"open", ExceptionStatus.Open}, {"rejected", ExceptionStatus.Rejected},
                        {"not resolved", ExceptionStatus.Not_Resolved},{"submitted",  ExceptionStatus.Submitted},
                        {"closed",  ExceptionStatus.Closed}, {"approved as observation",  ExceptionStatus.Approved_As_Observation}
                    };

                    if (!statusRecommended.ContainsKey(getStatus))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                    myExceptions = myExceptions.Where(d => d.Status == statusRecommended[getStatus]);
                }
                              
                if (!string.IsNullOrWhiteSpace(exceptionCategory))
                {
                    var getexceptionCategory = exceptionCategory.ToLower();
                    var exceptionCategoryRecommended = new Dictionary<string, ExceptionCategory>
                    {
                        {"major", ExceptionCategory.Major}, {"minor", ExceptionCategory.Minor},
                        {"medium", ExceptionCategory.Medium}
                   
                    };

                    if (!exceptionCategoryRecommended.ContainsKey(getexceptionCategory))
                        return TypedResults.BadRequest($"Enter one of the following recommended Exception Category {string.Join(",", exceptionCategoryRecommended.Keys)}");

                    myExceptions = myExceptions.Where(d => d.ExceptionCategory == exceptionCategoryRecommended[getexceptionCategory]);
                }

                if(!string.IsNullOrWhiteSpace(search)) {
                    myExceptions = myExceptions.Where(d => d.ExceptionDescription.Contains(search) || d.ActionPoint.Contains(search) ||
                        d.CreatedBy.Contains(search) || d.OperationActivity.Contains(search)
                    );
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<OperationControl>.Create(myExceptions.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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
                                
              var response = new PaginatedGetExceptionsResp(
               paginationMeta,
                 paginatedTasks.Select(e => new GetOperationExceptionsResp
               {
                   OpearationExceptionId = e.Id,
                   DateRaised = e.CreatedOnUtc,
                   ExceptionDescription = e.ExceptionDescription,
                   ActionPoint = e.ActionPoint,
                   Loggedby = e.CreatedBy,
                   OperationActivity = e.OperationActivity,
                   ExceptionCategory = e.ExceptionCategory.ToString(),
                   ProposedCompletionDate = e.CompletionDate,
                   ResolutionStatus = e.Status.ToString(),
                   TransactionCallOverType = e.TransactionCallOverType,
                   ActionOwner = e.ActionOwner,
                   Unit = e.Unit,
                   DateResolved = e.DateResolved,
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
