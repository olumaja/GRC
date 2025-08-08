using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 6/12/2024
      * Development Group: GRCTools
      * View all initiated internal control call over for the unit.     
      */
    public class InternalControlUnitCallOverEndpoint
    {
        /// <summary>
        /// The endpoint get all call over of the user unit
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="status"></param>
        /// <param name="reportStartDate"></param>
        /// <param name="reportEndDate"></param>
        /// <param name="repository"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, string? status, DateOnly? reportStartDate, DateOnly? reportEndDate, IRepository<InternalControlCallOver> repository, 
            ICurrentUserService currentUserService, IHttpContextAccessor httpContext
        )
        {
            if (!currentUserService.CurrentUserRoles.Contains("InternalControlCallOverSupervisor") && !currentUserService.CurrentUserRoles.Contains("InternalControlCallOverOfficer"))
                return TypedResults.Unauthorized();

            var query = repository.GetAll();
            if (!string.IsNullOrWhiteSpace(currentUserService.CurrentUserDepartment) && currentUserService.CurrentUserDepartment.ToLower() == "customer experience")
                query = query.Where(q => q.Unit.ToLower() == currentUserService.CurrentUserDepartment.ToLower());
            else
                query = query.Where(q => q.Unit.ToLower() == currentUserService.CurrentUserUnitName.ToLower());

            if (reportStartDate != null || reportEndDate != null)
            {
                if (reportStartDate > reportEndDate)
                    return TypedResults.BadRequest("Oops, Report EndDate cannot be earlier than Report StartDate");

                query = query.Where(d => d.ReportDate >= reportStartDate && d.ReportDate <= reportEndDate);
            }

            if (!string.IsNullOrEmpty(status))
            {
                var getstatus = status.ToLower();
                var statusRecommended = new Dictionary<string, CallOverStatus>
                 {
                     {"rejected", CallOverStatus.Rejected}, {"pending", CallOverStatus.Pending},
                     {"submitted", CallOverStatus.Submitted}, {"awaiting approval", CallOverStatus.Awaiting_Approval}
                 };

                if (!statusRecommended.ContainsKey(getstatus))
                    return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

                if (getstatus == "submitted")
                    query = query.Where(d => d.Status == CallOverStatus.Submitted || d.Status == CallOverStatus.Saved);
                else
                    query = query.Where(d => d.Status == statusRecommended[getstatus]);
            }
           
            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;

            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedCalls = Pagination<InternalControlCallOver>.Create(query.OrderByDescending(q => q.CreatedOnUtc), pageNumber, pageSize);

            var paginationMeta = new PaginationMeta
            (
                paginatedCalls.HasNextPage,
                paginatedCalls.HasPreviousPage,
                paginatedCalls.CurrentPage,
                paginatedCalls.PageSize,
                paginatedCalls.TotalPages,
                paginatedCalls.TotalCount
            );

            httpContext.HttpContext.Response.AddPagination(paginationMeta);

            var response = new CallOverResponse(
                PaginationMeta: paginationMeta,
                Response: paginatedCalls.Select(p => new CallOver(
                    CallOverId: p.Id,
                    ReportDate: p.ReportDate,
                    NumberOfReport: p.NumberOfReport,
                    DueDate: p.DueDate,
                    ExpectedUploadTime: p.ExpectedUploadTime,
                    DateUploaded: p.TimeUploaded.HasValue ? DateOnly.FromDateTime(p.TimeUploaded.Value) : null,
                    Status: p.Status == CallOverStatus.Saved ? "Submitted" : p.Status.ToString(),
                    Comment : p.Comment ?? null
                    )).ToList()
                );

            return TypedResults.Ok(response);
        }
    }
}
