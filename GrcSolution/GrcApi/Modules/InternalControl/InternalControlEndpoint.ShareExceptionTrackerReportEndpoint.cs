using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcTool.Domain;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;
using Arm.GrcTool.Infrastructure;
using Arm.GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.RestHelper;
using GrcApi.Modules.Shared.EmailNotification.Response;
using GrcApi.Modules.Shared.Enums;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
    * Original Author: Olusegun Adaramaja
    * Date Created: 02/11/2024
    * Development Group: GRCTools
    * Internal Control: Share exception report to others via email    
    */
    public class ShareExceptionTrackerReportEndpoint
    {
        /// <summary>
        /// Share exception report to others via email
        /// </summary>
        /// <param name="request"></param>
        /// <param name="exceptRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ShareExceptionReport request, IRepository<InternalControlExceptionTracker> exceptRepo, IRestHelper restHelper,
            IConfiguration config
        )
        {
            try
            {
                if (request.DateFrom == default || request.DateTo == default)
                    return TypedResults.BadRequest("Enter valid date for Date From and Date To");

                if (request.DateFrom > request.DateTo)
                    return TypedResults.BadRequest($"Date From {request.DateFrom} cannot be greater than Date To {request.DateTo}");

                var exceptions = exceptRepo.GetContextByConditon(t => t.CreatedOnUtc >= request.DateFrom.Date && t.CreatedOnUtc.Date <= request.DateTo);

                if (!string.IsNullOrWhiteSpace(request.Status))
                {
                    var allowedStatus = new Dictionary<string, ExceptionTrackerStatus> { { "resolved", ExceptionTrackerStatus.Resolved }, { "not resolved", ExceptionTrackerStatus.Not_Resolved } };
                    var trackerStatus = request.Status.ToLower();

                    if (!allowedStatus.ContainsKey(trackerStatus))
                    {
                        Dictionary<string, ExceptionTrackerStatus>.ValueCollection values = allowedStatus.Values;
                        return TypedResults.BadRequest($"The allowed status are {string.Join(", ", values).Replace('_', ' ')}");
                    }

                    exceptions = exceptions.Where(t => t.ExceptionTrackerStatus == allowedStatus[trackerStatus]);
                }

                if (!string.IsNullOrWhiteSpace(request.ImpactRating))
                {
                    var ratings = new List<string> { "very low", "low", "medium", "high", "very high" };
                    var rating = request.ImpactRating.ToLower();

                    if (!ratings.Contains(rating))
                        return TypedResults.BadRequest($"The allowed ratings are {string.Join(", ", ratings)}");

                    exceptions = exceptions.Where(t => t.ImpactRating.ToLower().Equals(rating));
                }

                if (!string.IsNullOrWhiteSpace(request.Unit))
                    exceptions = exceptions.Where(t => t.Unit.ToLower().Equals(request.Unit.ToLower()));

                //exceptions = exceptions.Where(t => t.CreatedOnUtc >= request.DateFrom.Date && t.CreatedOnUtc.Date <= request.DateTo);

                // Generate report as excel sheet
                var records = exceptions.ToList().Select(t => new InternalControlExceptionReport(
                    Exception: t.Exception,
                    Unit: t.Unit,
                    NatureOfException: t.NatureOfException,
                    ControlImpact: t.ControlImpact,
                    ImpactRating: t.ImpactRating,
                    TransactionCount: t.TransactionCount,
                    ActivityImpacted: t.ActivityImpacted,
                    Recommendation: t.Recommendation,
                    ResponsibleOfficer: t.ResponsibleOfficer,
                    Deadline: t.Deadline,
                    ManagementResponse: t.ManagementResponse,
                    Status: t.ExceptionTrackerStatus.ToString(),
                    DateCreated: t.CreatedOnUtc,
                    ModifiedDate: t.ModifiedOnUtc
                )).ToList();

                var excelSheetName = "InternalControlExceptionReport";
                var columnHeaders = new List<string>
                {
                    "Exception", "Unit", "Nature Of Exception", "Control Impact", "Impact Rating", "Transaction Count",
                    "Activity Impacted", "Recommendation", "Responsible Officer", "Proposed Deadline", "Management Response",
                    "Status", "Date Created", "Last Modified"
                };

                var report = ReportDocument.GenerateExcelDocument(excelSheetName, columnHeaders, records);

                // Send email to users
                var emails = request.Emails.Select(e => e.Email);
                var recipientEmail = string.Join(",", emails);
                var reportAttachment = Convert.ToBase64String(report);
                var toCC = config["EmailConfiguration:toCC"];
                excelSheetName = excelSheetName + ".xlsx";
                var message = $"Dear all, <br><br>Kindly find attached internal control exception report.<br>";
                var attachments = new List<EmailAttachment>
                 {
                new EmailAttachment(excelSheetName, reportAttachment)
                 };
                var payload = new EmailWithAttachmentRequest
                {
                    attachments = attachments,
                    isBodyHtml = true,
                    toCc = toCC,
                    toEmail = recipientEmail,
                    message = message,
                    subject = "Internal Control - Exception Report"
                };
                var emailUrl = config["EmailConfiguration:urlWithAttachment"];
                var response = await restHelper.ConsumeApi<EmailWithAttachmentResponse>("emailMessageClient", emailUrl, payload, HttpVerb.Post);

                if (response.Content is not null && response.Content.Status)
                {
                    return TypedResults.Ok("Report shared successfully");
                }

                return TypedResults.Ok("Report not sent, service is unavailable at the moment.");
            }
            catch(Exception ex)
            {
                return TypedResults.Ok("Report not sent, service is unavailable at the moment.");
            }
            
        }
    }
}
