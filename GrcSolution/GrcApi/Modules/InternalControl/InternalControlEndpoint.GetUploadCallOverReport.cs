using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 6/12/2024
      * Development Group: GRCTools
      * Get all call over reports for user unit     
      */
    public class GetUploadCallOverReportEndpoint
    {
        /// <summary>
        /// Get all call over reports for user unit
        /// </summary>
        /// <param name="callOverId"></param>
        /// <param name="repository"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid callOverId, IRepository<InternalControlCallOver> repository, ICurrentUserService currentUserService)
        {
            var callover = await repository.GetContextByConditon(c => c.Id == callOverId)
                                    .Include(c => c.Reports)
                                    .FirstOrDefaultAsync();

            if (callover is null)
                return TypedResults.NotFound("Record not found");

            if (callover.Unit != currentUserService.CurrentUserUnitName)
                return TypedResults.Forbid();

            var response = new CallOverReportResponse(
                CallOverId: callover.Id,
                Status: callover.Status == CallOverStatus.Saved ? "Submitted" : callover.Status.ToString(),
                ReasonForRjection: callover.ReasonForRejection,
                Comment: callover.Comment ?? null,
                CreatedBy: callover.CreatedBy ?? null,
                Reports: callover.Reports.Select(c => new CallOverReport(
                    CallOverReportId: c.Id,
                    ReportTitle: c.ReportTitle,
                    NumberOfAttachment: c.NumberOfAttachments
                )).ToList()
            );

            return TypedResults.Ok(response);
        }
    }
}
