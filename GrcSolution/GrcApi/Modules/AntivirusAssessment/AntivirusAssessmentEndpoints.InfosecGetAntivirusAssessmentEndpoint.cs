using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 06/28/2025
    * Development Group: GRCTools
    * Infosec Get Antivirus Assessment Endpoint
    */
    public class InfosecGetAntivirusAssessmentEndpoint
    {
        /// <summary>
        /// Infosec Get IAntivirus Assessment for Action Owner Endpoint
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="status"></param>
        /// <param name="requester"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="search"></param>
        /// <param name="repo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? status, string? requester, DateTime? startDate, DateTime? endDate, string? search,
            IRepository<AntivirusAssessmentModel> repo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {
            try
            {
                var antiVirus = repo.GetAll();

                if (startDate != null && endDate != null)
                {
                    if (startDate > endDate)
                        return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");

                    antiVirus = antiVirus.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date);
                }

                if (!string.IsNullOrEmpty(status))
                {
                    var getStatus = status.ToLower();
                    var statusRecommended = new Dictionary<string, AntivirusStatus>
                    {
                        {"resolved", AntivirusStatus.Resolved}, {"unresolved", AntivirusStatus.UnResolved}, {"completed",  AntivirusStatus.Completed},
                        {"pending", AntivirusStatus.Pending},  {"awaiting validation", AntivirusStatus.Awaiting_Validation}
                    };

                    if (!statusRecommended.ContainsKey(getStatus))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                    antiVirus = antiVirus.Where(d => d.AntivirusStatus == statusRecommended[getStatus]);
                }

                if (!string.IsNullOrEmpty(requester))
                {
                    antiVirus = antiVirus.Where(d => d.CreatedBy.ToLower() == requester.ToLower());
                }

                if (!string.IsNullOrEmpty(search))
                {
                    antiVirus = antiVirus.Where(d => d.CreatedBy.Contains(search) || d.ReasonForRejection.Contains(search) ||
                        d.CreatedBy.Contains(search) || d.ModifiedBy.Contains(search) || d.ActionOwnerUnit.Contains(search) ||
                        d.AssessmentType.Contains(search) || d.TitleOfAssessment.Contains(search) || d.ApprovedBy.Contains(search)
                    );
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<AntivirusAssessmentModel>.Create(antiVirus.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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
                var response = new PaginatedGetAntivirusAssessmentResp(
                 paginationMeta,
                   paginatedTasks.Select(e => new GetAntivirusAssessmentResponse
                   {
                       AntivirusAssessmentFileId = e.Id,
                       Date = e.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),
                       AssessmentType = e.AssessmentType,
                       AssessmentTitle = e.TitleOfAssessment,
                       Initiator = e.CreatedBy,
                       ActionOwner = e.ActionOwner,
                       Status = e.AntivirusStatus.ToString()

                   }).ToList());

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Exception: Antivirus Assessment record was not found");
            }
        }


    }
}
