using Arm.GrcApi.Modules.InfosecRiskAssessment;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/11/2025
    * Development Group: GRCTools
    * Get Approved Risk Endpoint
    */
    public class GetApprovedRiskEndpoint
    {
        /// <summary>
        /// Get Approved Risk Endpoint
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="search"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>       
        public static async Task<IResult> HandleAsync(
        int pageSize, int pageNumber, DateTime? startDate, DateTime? endDate, string? search,
        IRepository<InfosecRiskAssessmentModel> repo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext)
        {
            try
            {
                if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecISORiskChampion) && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecISOUnitHead))
                    return TypedResults.Forbid();
                var query = repo.GetContextByConditon(x => x.Status == RiskAssessmentStatus.Approved);

                if (startDate != null && endDate != null)
                {
                    if (startDate > endDate)
                        return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");

                    query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date);
                }

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(d => d.CreatedBy.Contains(search) || d.ReasonForRejection.Contains(search) || d.Objective.Contains(search) ||
                        d.CreatedBy.Contains(search) || d.ModifiedBy.Contains(search) || d.ActionOwner.Contains(search) ||
                        d.Vulnerability.Contains(search) || d.Threat.Contains(search) || d.Category.Contains(search) ||
                        d.Asset.Contains(search) || d.AssetDescription.Contains(search) || d.ApprovedBy.Contains(search)
                    );
                }
                               
                // Pagination rules
                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;
                pageSize = Math.Clamp(pageSize, 1, MaxPageSize);
                pageNumber = Math.Max(pageNumber, DefaultPageNumber);

                // Grouping by Unit
                var grouped = query.GroupBy(x => x.Unit)
                    .Select(g => new GetApprovedRiskResponse
                    {
                        Unit = g.Key,
                        Count = g.Count()
                    });
                               
                // Pagination on grouped results
                var totalCount = await grouped.CountAsync();
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
                var items = await grouped.OrderByDescending(x => x.Count).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                // Add pagination headers
                var paginationMeta = new PaginationMeta(
                    HasNextPage: pageNumber < totalPages,
                    HasPreviousPage: pageNumber > 1,
                    CurrentPage: pageNumber,
                    PageSize: pageSize,
                    TotalPages: totalPages,
                    TotalCount: totalCount
                );

                httpContext.HttpContext?.Response?.AddPagination(paginationMeta);

                var response = new PaginatedGetApprovedRiskResponse(paginationMeta, items);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Exception: Approved Risk record was not found");
            }
        }


    }
}
