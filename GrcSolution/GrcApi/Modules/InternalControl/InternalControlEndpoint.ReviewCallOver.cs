using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using Azure;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 14/12/2024
      * Development Group: GRCTools
      * The endpoint return a list of call over     
      */
    public class ReviewCallOverEndpoint
    {
        /// <summary>
        /// The endpoint return a list of call over
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="unit"></param>
        /// <param name="repository"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, DateOnly? startDate, DateOnly? endDate, string? status, string? unit, IRepository<InternalControlCallOver> repository, 
            IHttpContextAccessor httpContext
        )
        {
            bool isOverDue = false;

            var query = repository.GetContextByConditon(q => q.Status == CallOverStatus.Submitted || q.Status == CallOverStatus.Saved);

            if (startDate != null || endDate != null)
            {
                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }

                query = query.Where(d => d.ReportDate >= startDate && d.ReportDate <= endDate);
            }

            if (!string.IsNullOrEmpty(unit))
                query = query.Where(q => q.Unit.ToLower() == unit.ToLower());

            if (!string.IsNullOrWhiteSpace(status))
            {
                var getstatus = status.ToLower();
                var statusRecommended = new Dictionary<string, CallOverStatus>
                {
                    {"submitted", CallOverStatus.Submitted}, {"saved", CallOverStatus.Saved }
                };

                if (!statusRecommended.ContainsKey(getstatus))
                    return TypedResults.BadRequest($"Enter one of the following recommended status {string.Join(",", statusRecommended.Keys)}");

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
            var reportCallOver = new List<ReviewCallOver>();

            foreach (var call in paginatedCalls)
            {
                if (call.TimeUploaded.HasValue && DateOnly.FromDateTime(call.TimeUploaded.Value) > call.DueDate)
                {
                    isOverDue = true;
                }

                if (call.TimeUploaded.HasValue && DateOnly.FromDateTime(call.TimeUploaded.Value) == call.DueDate && TimeOnly.FromDateTime(call.TimeUploaded.Value) > call.ExpectedUploadTime)
                {
                    isOverDue = true;
                }

                reportCallOver.Add(new ReviewCallOver(
                    CallOverId: call.Id,
                    ReportDate: call.ReportDate,
                    Unit: call.Unit,
                    DueDate: call.DueDate,
                    ExpectedUploadTime: call.ExpectedUploadTime,
                    TimeUpload: call.TimeUploaded,
                    Score: call.Status == CallOverStatus.Saved ? call.Score : 0,
                    Status: call.Status.ToString(),
                    Comment: call.Comment,
                    CreatedBy: call.CreatedBy ?? null,
                    IsOverDue: isOverDue
                ));
            }

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

            var response = new ReviewCallOverResponse(
                PaginationMeta: paginationMeta,
                Response: reportCallOver
            );

            return TypedResults.Ok(response);
        }
    }
}
