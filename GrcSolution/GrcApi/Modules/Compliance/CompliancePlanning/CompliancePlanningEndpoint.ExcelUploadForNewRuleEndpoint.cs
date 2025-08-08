using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Vml.Office;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.WsPolicy;
using OfficeOpenXml;
using System.ComponentModel;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/06/2024
    * Development Group: GRCTools
    * Compliance Planning: Excel Upload For the New Rule Endpoint     
    */
    public class ExcelUploadForNewRuleEndpoint
    {
        /// <summary>
        /// Excel Upload For the New Rule Endpoint
        /// </summary>
        /// <param name="file"></param>
        /// <param name="regulatorTitle"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="regulator"></param>
        /// <param name="newRule"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            RuleExcelUpload req, CancellationToken cancellationToken, IRepository<ComplianceRegulator> regulator,
           IRepository<ComplianceRules> newRule, IConfiguration config, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var checkIfRegulatorExist = regulator.GetContextByConditon(c => c.Id == req.regulatorId).FirstOrDefault();

                if (checkIfRegulatorExist == null)  
                    return TypedResults.NotFound($"Regulator has not been created for this business involved rule");

                ComplianceRulesExcelUploadReq rules = new ComplianceRulesExcelUploadReq();
                List<ComplianceRules> newRuleReq = new List<ComplianceRules>();

                if (req.rules == null || req.rules.Length == 0) { return TypedResults.BadRequest("Invalid file selected"); }

                string fileExtenstion = Path.GetExtension(req.rules.FileName);

                if (fileExtenstion == ".xlsx" || fileExtenstion == ".xls")
                {
                    var ruleList = new List<ComplianceRulesExcelUploadReq>();
                    using (var stream = new MemoryStream())
                    {
                        await req.rules.CopyToAsync(stream, cancellationToken);
                        ExcelPackage.License.SetNonCommercialOrganization("arm");
                        using (ExcelPackage excelPackage = new ExcelPackage(stream))
                        {
                            var workSheet = excelPackage.Workbook.Worksheets[0];
                            int totalRows = workSheet.Dimension.Rows;

                            for (int i = 2; i <= totalRows; i++)
                            {

                                if (string.IsNullOrEmpty(workSheet.Cells[i, 1]?.Value?.ToString() ?? null))
                                {
                                    // Console.WriteLine("Section is null");
                                    return TypedResults.BadRequest("Section cannot be null");
                                    //continue;
                                }
                                if (string.IsNullOrEmpty(workSheet.Cells[i, 2]?.Value?.ToString() ?? null))
                                {
                                    return TypedResults.BadRequest("Heading cannot be null");
                                }
                                if (string.IsNullOrEmpty(workSheet.Cells[i, 3]?.Value?.ToString() ?? null))
                                {
                                    return TypedResults.BadRequest("IssuesOrFillingOrReturns cannot be null");
                                }
                                if (string.IsNullOrEmpty(workSheet.Cells[i, 4]?.Value?.ToString() ?? null))
                                {
                                    return TypedResults.BadRequest("DeadlineOrPeriodForFillingReturns cannot be null");
                                }
                                if (string.IsNullOrEmpty(workSheet.Cells[i, 5]?.Value?.ToString() ?? null))
                                {
                                    return TypedResults.BadRequest("Responsibilities cannot be null");
                                }
                                if (string.IsNullOrEmpty(workSheet.Cells[i, 6]?.Value?.ToString() ?? null))
                                {
                                    return TypedResults.BadRequest("PenaltForNonComplianceIfAny cannot be null");
                                }

                                ruleList.Add(new ComplianceRulesExcelUploadReq
                                {
                                    Section = workSheet.Cells[i, 1].Value.ToString(),
                                    Heading = workSheet.Cells[i, 2].Value.ToString(),
                                    IssuesOrFillingOrReturns = workSheet.Cells[i, 3].Value.ToString(),
                                    DeadlineOrPeriodForFillingReturns = workSheet.Cells[i, 4].Value.ToString(),
                                    Responsibilities = workSheet.Cells[i, 5].Value.ToString(),
                                    PenaltForNonComplianceIfAny = workSheet.Cells[i, 6].Value.ToString()
                                });
                            }
                        }                       

                    }

                    foreach (var item in ruleList)
                    {
                        newRuleReq.Add(ComplianceRules.ExcelUploadCreate(req.regulatorId, item, currentUserService.CurrentUserFullName));
                    }
                    await newRule.AddRangeAsync(newRuleReq);
                    await newRule.SaveChangesAsync();

                    return TypedResults.Ok($"{ruleList.Count} Records uploaded successfully");
                }

                return TypedResults.BadRequest("Unable to save the request");
                
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }

    }
}
