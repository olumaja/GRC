using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class InfosecRiskAssessmentEndpoint
    {
        /// <summary>
        /// This endpoint enable ISO risk champion and Unit head to view records
        /// </summary>
        /// <param name="riskRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            string? category, string? asset, string? status, string? search,
            IRepository<InfosecRiskAssessmentModel> riskRepo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext, 
            int pageSize = 10, int pageNumber = 1
        )
        {
            if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecISORiskChampion) && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecISOUnitHead) 
                && !currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecOfficer)
            )
                return TypedResults.Forbid();

            var riskAssessment = riskRepo.GetAll();

            if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecOfficer))
                riskAssessment = riskAssessment.Where(r => r.Unit == currentUserService.CurrentUserUnitName);

            

            if (!string.IsNullOrWhiteSpace(category))
            {
                riskAssessment = riskAssessment.Where(r => r.Category == category);
            }

            if (!string.IsNullOrWhiteSpace(asset)) {
                riskAssessment = riskAssessment.Where(r => r.Asset == asset);
            }

            if (!string.IsNullOrWhiteSpace(status)) {
                status = status.ToUpper();
                var dicSatus = new Dictionary<string, RiskAssessmentStatus> {
                    {"PENDING APPROVAL", RiskAssessmentStatus.Pending_Approval}, {"APPROVED", RiskAssessmentStatus.Approved},
                    {"REJECTED", RiskAssessmentStatus.Rejected}
                };

                if (!dicSatus.ContainsKey(status))
                    return TypedResults.BadRequest($"Status allowed are {string.Join(",", dicSatus.Keys)}");

                riskAssessment = riskAssessment.Where(r => r.Status == dicSatus[status]);
            }

            if (!string.IsNullOrWhiteSpace(search)) {
                riskAssessment = riskAssessment.Where(r => 
                    r.Asset.StartsWith(search) || r.Category.StartsWith(search) || r.AssetDescription.StartsWith(search)
                );
            }
            var tes = riskAssessment.ToList();
            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;

            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedTasks = Pagination<InfosecRiskAssessmentModel>.Create(riskAssessment.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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

            var response = new PaginatedInfosecRiskAssessmentResponse(
                paginationMeta,
                paginatedTasks.Select( p => new InfosecRiskAssessmentResponse
                {
                    Id = p.Id,
                    DateIndentified = p.CreatedOnUtc,
                    Category = p.Category,
                    Asset = p.Asset,
                    DescriptionOfAsset = p.AssetDescription,
                    Status = p.Status.GetEnumDestription(),
                }).ToList()
            );

            return TypedResults.Ok(response);
        }
    }
}
