using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
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

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 07/06/2024
      * Development Group: GRCTools
      * Compliance Planning: Excel Upload For the New Rule Endpoint     
      */
    public class ExcelUploadForNewFindingEndpoint
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
            NewFindingExcelUpload req, CancellationToken cancellationToken, IRepository<InternalAuditReport> auditReport, IRepository<ConsolidatedAuditFinding> findingRepo,
            IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
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

                var checkIfAuditReportExist = auditReport.GetContextByConditon(c => c.Id == req.internalAuditReportId).FirstOrDefault();
                if (checkIfAuditReportExist == null)
                    return TypedResults.NotFound($"Internal Audit report has not been created");

                ConsolidatedAuditFindingUploadReq rules = new ConsolidatedAuditFindingUploadReq(); 
                List<ConsolidatedAuditFinding> newFindingReq = new List<ConsolidatedAuditFinding>();

                if (req.findings == null || req.findings.Length == 0) { return TypedResults.BadRequest("Invalid file selected"); }

                string fileExtenstion = Path.GetExtension(req.findings.FileName);

                if (fileExtenstion == ".xlsx" || fileExtenstion == ".xls")
                {
                    using var stream = new MemoryStream();
                    await req.findings.CopyToAsync(stream, cancellationToken);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using ExcelPackage excelPackage = new ExcelPackage(stream);
                    var workSheet = excelPackage.Workbook.Worksheets[0];
                    int totalRows = workSheet.Dimension.Rows;
                    var findingList = new List<ConsolidatedAuditFindingUploadReq>();
                    for (int i = 2; i <= totalRows; i++)
                    {
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 1]?.Value?.ToString() ?? null))
                        {
                            // Console.WriteLine("Section is null");
                            return TypedResults.BadRequest("ReviewType cannot be null");
                            //continue;
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 2]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("DateFindingRaised cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 3]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("Business cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 4]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("Level1 cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 5]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("Level2 cannot be null");
                        }                                            
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 6]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("ReportingQuater cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 7]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("WorkStream cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 9]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("AuditArea cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 9]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("ImpactRating cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 10]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("Recommendation cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 11]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("RevisedDueDate cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 12]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("EngagementName cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 13]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("DetailedFindings cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 14]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("DescriptionOfFinding cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 15]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("ActionDueDate cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 16]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("ManagmentResponseAsAtTimeOfEngagement cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 17]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("UpdatedComment cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 18]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("ResolutionDate cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 19]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("DescriptionOfIssue cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 20]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("ActionOwner cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 21]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("Unit cannot be null");
                        }
                        if (string.IsNullOrEmpty(workSheet.Cells[i, 22]?.Value?.ToString() ?? null))
                        {
                            return TypedResults.BadRequest("Entity cannot be null");
                        }
                        findingList.Add(new ConsolidatedAuditFindingUploadReq
                        {
                            ReviewType = workSheet.Cells[i, 1].Value.ToString(),
                            DateFindingRaised = workSheet.Cells[i, 2].Value.ToString(),
                            Business = workSheet.Cells[i, 3].Value.ToString(),
                            Level1 = workSheet.Cells[i, 4].Value.ToString(),
                            Level2 = workSheet.Cells[i, 5].Value.ToString(),
                            ReportingQuater = workSheet.Cells[i, 6].Value.ToString(),
                            WorkStream = workSheet.Cells[i, 7].Value.ToString(),
                            AuditArea = workSheet.Cells[i, 8].Value.ToString(),
                            ImpactRating = workSheet.Cells[i, 9].Value.ToString(),
                            Recommendation = workSheet.Cells[i, 10].Value.ToString(),
                            RevisedDueDate = workSheet.Cells[i, 11].Value.ToString(),
                            EngagementName = workSheet.Cells[i, 12].Value.ToString(),
                            DetailedFindings = workSheet.Cells[i, 13].Value.ToString(),
                            DescriptionOfFinding = workSheet.Cells[i, 14].Value.ToString(),
                            ActionDueDate = workSheet.Cells[i, 15].Value.ToString(),
                            ManagmentResponseAsAtTimeOfEngagement = workSheet.Cells[i, 16].Value.ToString(),
                            UpdatedComment = workSheet.Cells[i, 17].Value.ToString(),
                            ResolutionDate = workSheet.Cells[i, 18].Value.ToString(),
                            DescriptionOfIssue = workSheet.Cells[i, 19].Value.ToString(),
                            ActionOwner = workSheet.Cells[i, 20].Value.ToString(),
                            Unit = workSheet.Cells[i, 21].Value.ToString(),
                            Entity = workSheet.Cells[i, 22].Value.ToString()
                           
                        });
                    }
                    foreach (var item in findingList)
                    {
                       newFindingReq.Add(ConsolidatedAuditFinding.ExcelUploadCreate(req.internalAuditReportId, currentUserService.CurrentUserFullName, item));
                    }
                    await findingRepo.AddRangeAsync(newFindingReq);
                    await findingRepo.SaveChangesAsync();

                    return TypedResults.Ok($"{findingList.Count} Records uploaded successfully");
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
