using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 17/12/2024
      * Development Group: GRCTools
      * The endpoint displace all callover reports 
      */
    public class CallOverReportEndpoint
    {
        /// <summary>
        /// The endpoint displace all callover reports
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="score"></param>
        /// <param name="unit"></param>
        /// <param name="timeUploaded"></param>
        /// <param name="repository"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int pageSize, int pageNumber, int? score, string? unit, DateTime? startDate, DateTime? endDate, TimeOnly? timeUploaded, 
            IRepository<InternalControlCallOver> repository, IHttpContextAccessor httpContext
        )
        {
            bool isOverDue = false;

            var query = repository.GetAll();          

            if (startDate != null && endDate != null)
            {
                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, End Date cannot be earlier than Start Date");
                }

                query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                              .OrderByDescending(r => r.CreatedOnUtc);
            }

            if (!string.IsNullOrEmpty(unit))
                query = query.Where(q => q.Unit.ToLower() == unit.ToLower());
            
            if(score != null)
                query = query.Where(q => q.Score == score).OrderByDescending(q => q.CreatedOnUtc);
            
            if (timeUploaded != null)
            {
                query = query.Where(q => q.TimeUploaded.Value.Hour == timeUploaded.Value.Hour);
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
            var reportCallOver = new List<ReportCallOver>();

            foreach(var call in paginatedCalls)
            {
                if(call.TimeUploaded.HasValue && DateOnly.FromDateTime(call.TimeUploaded.Value) > call.DueDate)
                {
                    isOverDue = true;
                }

                if(call.TimeUploaded.HasValue && DateOnly.FromDateTime(call.TimeUploaded.Value) == call.DueDate && TimeOnly.FromDateTime(call.TimeUploaded.Value) > call.ExpectedUploadTime)
                {
                    isOverDue = true;
                }

                reportCallOver.Add(new ReportCallOver(
                    CallOverId: call.Id,
                    ReportDate: call.ReportDate,
                    Unit: call.Unit,
                    DueDate: call.DueDate,
                    TimeUpload: call.TimeUploaded is null ? null : TimeOnly.FromDateTime(call.TimeUploaded.Value),
                    Score: call.Status == CallOverStatus.Saved ? call.Score : 0,
                    Comment: call.Comment,
                    CreatedBy: call.CreatedBy ?? null,
                    IsOverDue: isOverDue
                ));
            }

            var response = new ReportCallOverResponse(
                PaginationMeta: paginationMeta,
                Response: reportCallOver
            );

            return TypedResults.Ok(response);
        }
    }
}
