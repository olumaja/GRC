using Arm.GrcTool.Infrastructure;
using ClosedXML.Excel;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/06/2024
    * Development Group: GRCTools
    * Compliance Planning: Download Compliance Rule file     
    */
    public class DownloadComplianceRulefile
    {
        /// <summary>
        /// Download Compliance Rule file  Endpoint   
        /// </summary>
        /// <param name="regulator"></param>
        /// <param name="rule"></param>
        /// <param name="user"></param>
        /// <returns></returns>


        public static async Task<IResult> HandleAsync(IRepository<ComplianceRules> rules, IRepository<ComplianceRegulator> regu, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("RegulatorRuleFile");
                    var currentRow = 1;

                    worksheet.Cell(currentRow, 1).Value = "Section";
                    worksheet.Cell(currentRow, 2).Value = "Heading";
                    worksheet.Cell(currentRow, 3).Value = "IssuesOrFillingOrReturns";
                    worksheet.Cell(currentRow, 4).Value = "DeadlineOrPeriodForFillingReturns";
                    worksheet.Cell(currentRow, 5).Value = "Responsibilities";
                    worksheet.Cell(currentRow, 6).Value = "PenaltForNonComplianceIfAny";

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return TypedResults.File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RegulatorRuleFile.xlsx");
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
