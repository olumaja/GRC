//using Arm.GrcTool.Domain;
//using Arm.GrcTool.Infrastructure;
//using DocumentFormat.OpenXml.Wordprocessing;
using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 04/04/2025
     * Development Group: GRCTools
     * Get GetNotify ISO Champion Endpoint
     */
    public class GetNotifyISOChampionEndpoint
    {
        /// <summary>
        /// Get GetNotify ISO Champion Endpoint
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="unit"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="search"></param>
        /// <param name="repo"></param>
        /// <param name="docRepo"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>      
        public static async Task<IResult> HandleAsync(int pageSize, int pageNumber, string? unit, DateTime? startDate, DateTime? endDate, string? search,
            IRepository<NotifyISORiskAssessmentModel> repo, IRepository<Document> docRepo, IHttpContextAccessor httpContext)
        {
            try
            {
                var query = repo.GetAll();

                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }
                if (startDate != null || endDate != null)
                {
                    query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date);
                }

                if (!string.IsNullOrEmpty(unit))
                {
                    query = query.Where(d => d.Unit == unit);
                }
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(d => d.Unit.Contains(search) || d.Objective.Contains(search) || d.CreatedBy.Contains(search));
                }
                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<NotifyISORiskAssessmentModel>.Create(query.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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
                var response = new PaginatedGetNotifyISOChampionResp(
                 paginationMeta,
                   paginatedTasks.Select(e => new GetNotifyISOChampionResponse
                   {
                       NotifyISOId = e.Id,
                       Unit = e.Unit,
                       Objective = e.Objective,
                       DateIdentify = e.CreatedOnUtc
                   }).ToList());

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Exception: Record was not found");
            }
        }

    }
}
