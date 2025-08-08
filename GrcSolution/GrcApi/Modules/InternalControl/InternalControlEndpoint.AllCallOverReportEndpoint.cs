using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Wordprocessing;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 17/12/2024
     * Development Group: GRCTools
     * The endpoint displace all callover reports 
     */
    public class AllCallOverReportEndpoint
    {
        /// <summary>
        /// The endpoint displace all callover reports
        /// </summary>
        /// <param name="score"></param>
        /// <param name="unit"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="timeUploaded"></param>
        /// <param name="repository"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            int? score, string? unit, DateTime? startDate, DateTime? endDate, TimeOnly? timeUploaded, IRepository<InternalControlCallOver> repository, IHttpContextAccessor httpContext
        )
        {
            if (startDate > endDate)
            {
                return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
            }
            List<ReportCallOverV2> viewResp = new List<ReportCallOverV2>();
            var query = repository.GetAll();

            if (startDate != null || endDate != null)
            {
                query = query.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                              .OrderByDescending(r => r.CreatedOnUtc);
            }

            if (!string.IsNullOrEmpty(unit))
                query = query.Where(q => q.Unit.ToLower() == unit.ToLower());

            if (score != null)
                query = query.Where(q => q.Score == score).OrderByDescending(q => q.CreatedOnUtc);

            if (timeUploaded != null)
            {
                query = query.Where(q => q.TimeUploaded.Value.Hour == timeUploaded.Value.Hour);
            }           
            var resp = query.OrderByDescending(q => q.CreatedOnUtc);

            if (resp != null)
            {
                foreach (var item in resp)
                {                   
                    viewResp.Add(new ReportCallOverV2
                    {
                        CallOverId = item.Id,
                        ReportDate = item.ReportDate,
                        Unit = item.Unit,
                        DueDate = item.DueDate,
                        TimeUpload = item.TimeUploaded is null ? null : TimeOnly.FromDateTime(item.TimeUploaded.Value),
                        Score = item.Score,
                        Comment = item.Comment,
                        CreatedBy = item.CreatedBy ?? null,
                        IsOverDue = item.TimeUploaded is null ? false : item.DueDate >= DateOnly.FromDateTime(item.TimeUploaded.Value) && item.ExpectedUploadTime >= TimeOnly.FromDateTime(item.TimeUploaded.Value) ? true : false

                    });

                }
                return TypedResults.Ok(viewResp);
            }
            return TypedResults.NotFound("Record was not found");
        }
    }
}
