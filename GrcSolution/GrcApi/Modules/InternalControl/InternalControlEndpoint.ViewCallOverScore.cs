using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 17/12/2024
      * Development Group: GRCTools
      * The endpoint displace score and attachment for callover report     
      */
    public class ViewCallOverScoreEndpoint
    {
        /// <summary>
        /// The endpoint displace score and attachment for callover report
        /// </summary>
        /// <param name="calloverId"></param>
        /// <param name="repoCallover"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid calloverId, IRepository<InternalControlCallOver> repoCallover, IRepository<Document> docRepo)
        {
            var callover = repoCallover.GetContextByConditon(c => c.Id == calloverId)
                                        .Include(c => c.Reports)
                                        .FirstOrDefault();

            if (callover is null)
                return TypedResults.NotFound("Record not found");

            var attachments = new List<CallOverAttachedReport>();

            foreach (var report in callover.Reports)
            {
                var doc = (await docRepo.GetContextByConditon(d => d.ModuleItemId == report.Id && d.ModuleItemType == ModuleType.InternalControlCallOver)
                                .ToListAsync())
                                .Select(d => new CallOverAttachedReport(DocumentId: d.Id, Name: d.Name, DateCreated: d.CreatedOnUtc));

                if (doc.Count() > 0)
                    attachments.AddRange(doc);
            }

            int callOverDoneScore = 0, calloverAsWhenDue = 0;
            bool errorFreeReport = true;

            /*
             * Total score allow is 100
             * callOverDoneScore can only be 25
             * calloverAsWhenDue can be 25 if done on or before due date
             */
            if (callover.Status == CallOverStatus.Submitted || callover.Status == CallOverStatus.Saved)
            {
                callOverDoneScore = 25;

                if (callover.Score == 50 || callover.Score == 100)
                    calloverAsWhenDue = 25;

                if (callover.Score >= 75)
                    errorFreeReport = false;
            }

            var response = new ViewCallOverScoreResponse(
                CalloverId: callover.Id,
                Attachments: attachments,
                CallOverDoneScore: callOverDoneScore,
                CalloverAsWhenDue: calloverAsWhenDue,
                TotalScore: callover.Score,
                ErrorSpotted: errorFreeReport,
                ReasonForRejection: callover.ReasonForRejection,
                Status: callover.Status.ToString(),
                Comment: callover.Comment,
                CreatedBy: callover.CreatedBy ?? null
            );

            return TypedResults.Ok(response);
        }
    }
}
