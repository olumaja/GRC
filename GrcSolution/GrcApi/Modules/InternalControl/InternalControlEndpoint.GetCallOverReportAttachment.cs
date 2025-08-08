using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class GetCallOverReportAttachmentEndpoint
    {
        public static async Task<IResult> HandleAsync(
            Guid callOverReportId, IRepository<InternalControlCallOverReport> callOverRepo, ICurrentUserService currentUserService, 
            IRepository<Document> docRepo
        )
        {
            var attachedReport = callOverRepo.GetContextByConditon(c => c.Id == callOverReportId)
                                            .Include(c => c.CallOver)
                                            .FirstOrDefault();

            if (attachedReport is null)
                return TypedResults.NotFound("Record not found");

            if (attachedReport.CallOver.Unit != currentUserService.CurrentUserUnitName)
                return TypedResults.Forbid();

            var documents = docRepo.GetContextByConditon(d => d.ModuleItemId == callOverReportId && d.ModuleItemType == ModuleType.InternalControlCallOver)
                                    .ToList();

            var response = new CallOverAttachedReportResponse(
                CallOverReportId: callOverReportId,
                Name: attachedReport.ReportTitle,
                Attachments: documents.Select(d => new CallOverAttachedReport(
                    DocumentId: d.Id,
                    Name: d.Name,
                    DateCreated: d.CreatedOnUtc
                )).ToList()
            );

            return TypedResults.Ok(response);
        }
    }
}
