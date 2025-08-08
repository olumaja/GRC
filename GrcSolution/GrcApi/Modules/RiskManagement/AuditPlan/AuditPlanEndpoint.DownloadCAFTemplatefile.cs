using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using ClosedXML.Excel;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 07/06/2024
     * Development Group: GRCTools
     * Compliance Planning: Download Compliance Rule file     
     */
    public class DownloadCAFTemplatefile
    {
        /// <summary>
        /// Download CAF template Endpoint   
        /// </summary>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("ConsolidatedAuditFindingFile");
                    var currentRow = 1;

                    worksheet.Cell(currentRow, 1).Value = "Review Type";
                    worksheet.Cell(currentRow, 2).Value = "Date Finding Raised";
                    worksheet.Cell(currentRow, 3).Value = "Business";
                    worksheet.Cell(currentRow, 4).Value = "Level1";
                    worksheet.Cell(currentRow, 5).Value = "Level2";
                    worksheet.Cell(currentRow, 6).Value = "Reporting Quater";
                    worksheet.Cell(currentRow, 7).Value = "Work Stream";
                    worksheet.Cell(currentRow, 8).Value = "Audit Area";
                    worksheet.Cell(currentRow, 9).Value = "Impact Rating";
                    worksheet.Cell(currentRow, 10).Value = "Recommendation";
                    worksheet.Cell(currentRow, 11).Value = "Revised Due Date";
                    worksheet.Cell(currentRow, 12).Value = "EngagementName";
                    worksheet.Cell(currentRow, 13).Value = "Detailed Findings";
                    worksheet.Cell(currentRow, 14).Value = "Description Of Finding";
                    worksheet.Cell(currentRow, 15).Value = "Action Du eDate";
                    worksheet.Cell(currentRow, 16).Value = "Managment Response As At Time Of Engagement";
                    worksheet.Cell(currentRow, 17).Value = "Updated Comment";
                    worksheet.Cell(currentRow, 18).Value = "ResolutionDate";
                    worksheet.Cell(currentRow, 19).Value = "DescriptionOfIssue";
                    worksheet.Cell(currentRow, 20).Value = "ActionOwner";
                    worksheet.Cell(currentRow, 21).Value = "Unit";
                    worksheet.Cell(currentRow, 22).Value = "Entity";
                   
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return TypedResults.File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ConsolidatedAuditFindingFile.xlsx");
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
