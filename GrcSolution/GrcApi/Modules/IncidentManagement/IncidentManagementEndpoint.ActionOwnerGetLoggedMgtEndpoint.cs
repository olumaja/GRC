using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 04/24/2025
   * Development Group: GRCTools
   * Action owner get all logged mgt
   */
    public class ActionOwnerGetLoggedMgtEndpoint
    {
        /// <summary>
        /// Get all logged mgt
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="logtype"></param>
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
            int pageSize, int pageNumber, string? logtype, string? status, string? requester, DateTime? startDate, DateTime? endDate, string? search,
            IRepository<LogManagement> repo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {
            try
            {
                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }
                var logMgt = repo.GetContextByConditon(x => x.ActionownerEmailAddress.ToLower() == currentUserService.CurrentUserEmail.ToLower());

                if (startDate != null || endDate != null)
                {
                    logMgt = logMgt.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date);
                }

                if (!string.IsNullOrWhiteSpace(logtype))
                {
                    var getlogtype = logtype.ToLower();
                    var logtypeRecommended = new Dictionary<string, LogType>
                    {
                        {"siem", LogType.SIEM}, {"dam", LogType.DAM}, {"casp",  LogType.CASP},
                        {"fim", LogType.FIM}, {"edr", LogType.EDR}, {"pam",  LogType.PAM}, {"dlp",  LogType.DLP}
                    };

                    if (!logtypeRecommended.ContainsKey(getlogtype))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", logtypeRecommended.Keys)}");

                    logMgt = logMgt.Where(d => d.LogType == logtypeRecommended[getlogtype]);
                }

                if (!string.IsNullOrWhiteSpace(status))
                {
                    var getStatus = status.ToLower();
                    var statusRecommended = new Dictionary<string, LogMgtStatus>
                    {
                        {"rejected", LogMgtStatus.Rejected}, {"work in progress", LogMgtStatus.Work_In_Progress}, {"closed",  LogMgtStatus.Closed}
                    };

                    if (!statusRecommended.ContainsKey(getStatus))
                        return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                    logMgt = logMgt.Where(d => d.Status == statusRecommended[getStatus]);
                }

                if (requester != null)
                {
                    logMgt = logMgt.Where(d => d.CreatedBy == requester);
                }

                if (!string.IsNullOrWhiteSpace(search))
                {
                    logMgt = logMgt.Where(d => d.CreatedBy.Contains(search) || d.ReasonForRejection.Contains(search) ||
                        d.CreatedBy.Contains(search) || d.EventName.Contains(search) || d.InfoSecRemarks.Contains(search) || d.ActionOwnerRemarks.Contains(search) ||
                        d.ModifiedBy.Contains(search) || d.ActionOwnerUnit.Contains(search) || d.ActionownerEmailAddress.Contains(search) ||
                        d.RequesterEmailAddress.Contains(search) || d.BusinessJustification.Contains(search) || d.UserApprovalObtained.Contains(search)
                    );
                }

                const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

                if (pageSize > MaxPageSize)
                    pageSize = MaxPageSize;

                if (pageSize < 1)
                    pageSize = DefaultPageSize;

                if (pageNumber < DefaultPageNumber)
                    pageNumber = DefaultPageNumber;

                var paginatedTasks = Pagination<LogManagement>.Create(logMgt.OrderByDescending(r => r.CreatedOnUtc), pageNumber, pageSize);

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
                var response = new PaginatedGetLogMgtResp(
                 paginationMeta,
                   paginatedTasks.Select(e => new GetLogMgtResponse
                   {
                       LogMgtId = e.Id,
                       LogType = e.LogType.ToString(),
                       Timestamp = e.CreatedOnUtc.ToString("MM/dd/yyyy hh:mm tt"),  
                       //Timestamp = e.CreatedOnUtc.ToString("HH:mm:ss"),  
                       EventName = e.EventName,
                       Requester = e.CreatedBy,
                       Actionowner = e.ActionownerName,
                       Status = e.Status.ToString(),
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
