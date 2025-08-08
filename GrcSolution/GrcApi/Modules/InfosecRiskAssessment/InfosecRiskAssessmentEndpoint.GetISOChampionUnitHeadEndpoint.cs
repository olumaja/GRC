using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.ServiceModel.Channels;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/11/2025
    * Development Group: GRCTools
    * Get ISO Champion Unit Head Endpoint
    */
    public class GetISOChampionUnitHeadEndpoint
    {
        /// <summary>
        /// Get ISO Champion Unit Head Endpoint
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="search"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? status, DateTime? startDate, DateTime? endDate, string? search,
            IRepository<InfosecRiskAssessmentModel> repo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {
            try
            {
                var riskassessment = repo.GetContextByConditon(x => x.ActionOwnerEmail.ToLower() == currentUserService.CurrentUserEmail.ToLower());

                if (startDate != null && endDate != null)
                {
                    if (startDate > endDate)
                        return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");

                    riskassessment = riskassessment.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date);
                }

                if (!string.IsNullOrEmpty(status))
                {
                    var getStatus = status.ToLower();
                    var statusRecommended = new Dictionary<string, RiskAssessmentStatus>
                    {
                        {"pending approval", RiskAssessmentStatus.Pending_Approval}, {"rejected", RiskAssessmentStatus.Rejected}, {"approved",  RiskAssessmentStatus.Approved}                        
                    };

                    if (!statusRecommended.ContainsKey(getStatus))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                    riskassessment = riskassessment.Where(d => d.Status == statusRecommended[getStatus]);
                }
               
                if (!string.IsNullOrEmpty(search))
                {
                    riskassessment = riskassessment.Where(d => d.CreatedBy.Contains(search) || d.ReasonForRejection.Contains(search) ||
                        d.CreatedBy.Contains(search) || d.ModifiedBy.Contains(search) || d.ActionOwner.Contains(search) ||
                        d.Asset.Contains(search) || d.AssetDescription.Contains(search) || d.ApprovedBy.Contains(search)
                    );
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<InfosecRiskAssessmentModel>.Create(riskassessment.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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
                var response = new PaginatedGetISOChampionUnitHeadResp(
                 paginationMeta,
                   paginatedTasks.Select(e => new GetISOChampionUnitHeadResponse
                   {
                       NotifyISOId = e.Id,
                       DateIdentified = e.CreatedOnUtc,
                       Asset = e.Asset,
                       Category = e.Category,
                       DescriptionOfAsset = e.AssetDescription,
                       Status = e.Status.ToString(),
                   }).ToList());

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Exception: ISO Champion Unit Head record was not found");
            }
        }
    }
}
