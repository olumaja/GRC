using Arm.GrcTool.Infrastructure;
using ClosedXML.Excel;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/06/2024
    * Development Group: GRCTools
    * Compliance Planning: Download Compliance Report file     
    */
    public class DownloadComplianceReport
    {
        /// <summary>
        /// Download Compliance Report file  Endpoint   
        /// </summary>
        /// <param name="report"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceCalendar> report, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                if (user == null)
                {
                    return TypedResults.BadRequest("User must be logged in");
                }
                var getreport = (await report.GetAllAsync()).OrderByDescending(r => r.CreatedOnUtc);
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("ComplianceAttachedReports");
                    //title
                    //worksheet.Cell(1, 1).Value = "ComplianceAttachedReports";
                    var currentRow = 1;

                    worksheet.Cell(currentRow, 1).Value = "ReportName";
                    worksheet.Cell(currentRow, 2).Value = "Frequesncy";
                    worksheet.Cell(currentRow, 3).Value = "Deadline";
                    worksheet.Cell(currentRow, 4).Value = "ResponseStatus";
                    worksheet.Cell(currentRow, 5).Value = "Attachment";
                    worksheet.Cell(currentRow, 6).Value = "ReportStatus";

                    foreach (var item in getreport)
                    {
                        currentRow++;

                        worksheet.Cell(currentRow, 1).Value = item.Name;
                        worksheet.Cell(currentRow, 2).Value = item.Frequency;
                        worksheet.Cell(currentRow, 3).Value = item.DeadLine;
                        worksheet.Cell(currentRow, 4).Value = item.ResponseStatus.ToString();
                        worksheet.Cell(currentRow, 5).Value = item.AttachmentCount;
                        worksheet.Cell(currentRow, 6).Value = item.ReportStatus.ToString();
                    }
                      
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return TypedResults.File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ComplianceAttachedReports.xlsx");
                    }
                }

            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
