using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 16/10/2024
     * Development Group: GRCTools
     * Get all operation exceptions
     */
    public class GetConsolidatedAuditFindingEndpoint
    {
        /// <summary>
        /// Get all operation exceptions
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="dateCreated"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? status,
            string? search, IRepository<ConsolidatedAuditFinding> repo, ClaimsPrincipal user, ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {

            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var totalFindings = repo.GetAll().Count();
                var findings = repo.GetAll();
                var resolved = repo.GetAll().Where(d => d.Status == BusinessRiskRatingStatus.Closed && d.Status == BusinessRiskRatingStatus.Resolved && d.Status == BusinessRiskRatingStatus.Completed).Count(); 
                var unResolved = repo.GetAll().Where(d => d.OPRStatus == BusinessRiskRatingStatus.Due && d.OPRStatus == BusinessRiskRatingStatus.Past_Due).Count();

                if (!string.IsNullOrWhiteSpace(status))
                {
                    var getStatus = status.ToLower();
                    var statusRecommended = new Dictionary<string, BusinessRiskRatingStatus>
                    {//expectd to be closed
                        {"due", BusinessRiskRatingStatus.Due}, {"open", BusinessRiskRatingStatus.Pending}, {"closed",  BusinessRiskRatingStatus.Closed},
                        {"past due", BusinessRiskRatingStatus.Past_Due}, {"resolved", BusinessRiskRatingStatus.Resolved}, {"completed", BusinessRiskRatingStatus.Completed}
                    };

                    if (!statusRecommended.ContainsKey(getStatus))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");
                    if (status == "Open".ToLower())
                    {
                        findings = findings.Where(d => d.Status == BusinessRiskRatingStatus.Pending);
                    }
                    if (status == "Past Due".ToLower())
                    {
                        findings = findings.Where(d => d.OPRStatus == BusinessRiskRatingStatus.Past_Due);
                    }
                    if (status == "Due".ToLower())
                    {
                        findings = findings.Where(d => d.OPRStatus == BusinessRiskRatingStatus.Due && d.OPRStatus == BusinessRiskRatingStatus.Past_Due);
                    }
                    if (status == "Closed".ToLower())
                    {
                        findings = findings.Where(d => d.Status == BusinessRiskRatingStatus.Closed && d.Status == BusinessRiskRatingStatus.Completed && d.Status == BusinessRiskRatingStatus.Resolved);
                    }
                    if (status == "Completed".ToLower())
                    {
                        findings = findings.Where(d => d.Status == BusinessRiskRatingStatus.Completed);
                    }
                    if (status == "Resolved".ToLower())
                    {
                        findings = findings.Where(d => d.Status == BusinessRiskRatingStatus.Resolved);
                    }
                }

                if (!string.IsNullOrWhiteSpace(search))
                {
                    findings = findings.Where(d => d.Business.Contains(search) || d.Level1.Contains(search) || d.Level2.Contains(search) ||
                        d.ReviewType.Contains(search) || d.UpdatedComment.Contains(search) || d.ManagmentResponseAsAtTimeOfEngagement.Contains(search) || d.DetailedFindings.Contains(search) || d.Recommendation.Contains(search) || d.Unit.Contains(search)
                    );
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<ConsolidatedAuditFinding>.Create(findings.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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
                int count = findings.Count();
                double closureRate = resolved / (double)unResolved;
                if (resolved == 0 && unResolved == 0)
                {
                    closureRate = 0;
                }
                if (resolved > 0 && unResolved == 0)
                {
                    closureRate = resolved;
                }
                var response = new PaginatedGetConsolidatedAuditFindingListResp(
                 paginationMeta,
                 count,
                 closureRate,
                 totalFindings,
                   paginatedTasks.Select(e => new GetConsolidatedAuditFindingListResp
                   {
                       ConsolidatedAuditFindingId = e.Id,
                       Status = e.Status.ToString(),
                       OPRStatus = e.OPRStatus.ToString(),
                       StatusLevel = e.StatusLevel.ToString(),
                       ActionDueDate = e.ActionDueDate,
                       Business = e.Business,
                       DateFindingRaised = e.DateFindingRaised,
                       ReportingQuater = e.ReportingQuater,
                       ResolutionDate = e.ResolutionDate,
                       ReviewType = e.ReviewType,
                       RevisedDueDate = e.RevisedDueDate                      
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
