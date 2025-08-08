using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.VulnerabilityManagement;
using OfficeOpenXml;
using Org.BouncyCastle.Ocsp;
using System.IO;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    /*
   * Original Author: Sodiq Quadre
   * Date Created: 06/28/2025
   * Development Group: GRCTools
   * Antivirus Assessment File Upload Endpoint    
   */
    public class AntivirusAssessmentFileUploadEndpoint
    {

        /// <summary>
        /// Excel Upload For the New Antivirus Assessment
        /// </summary>
        /// <param name="req"></param>
        /// <param name="repo"></param>
        /// <param name="inactiveSensor"></param>
        /// <param name="reduceFunct"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="config"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            AntivirusAssessmentFileUploadReq req,
            IRepository<AntivirusAssessmentModel> repo,
            IRepository<InactiveSensors> inactiveSensorRepo,
            IRepository<ReducedFunctionalityMode> reducedFuncRepo,
            CancellationToken cancellationToken,
            IConfiguration config,
            ICurrentUserService currentUserService)
        {
            try
            {
                var now = DateTime.UtcNow;

                var existingRecord = repo.GetContextByConditon(c =>
                    c.TitleOfAssessment == req.TitleOfAssessment)
                    .FirstOrDefault();

                if (existingRecord != null &&
                    existingRecord.CreatedOnUtc.Year == now.Year &&
                    existingRecord.CreatedOnUtc.Month == now.Month)
                {
                    return TypedResults.BadRequest(
                        $"Antivirus Assessment file upload has been done for this month for the assessment title '{req.TitleOfAssessment}'");
                }

                if ((req.inactiveSensorsfile == null || req.inactiveSensorsfile.Length == 0) &&
                    (req.reducedFunctionalityModefile == null || req.reducedFunctionalityModefile.Length == 0))
                {
                    return TypedResults.BadRequest("Invalid file selected.");
                }

                var logRequest = AntivirusAssessmentModel.Create("Antivirus Assessment", req.TitleOfAssessment, currentUserService.CurrentUserEmail);
                logRequest.SetCreatedBy(currentUserService.CurrentUserFullName);
                logRequest.SetModifiedBy(currentUserService.CurrentUserFullName);
                logRequest.SetModifiedOnUtc(now);
                repo.Add(logRequest);

                var inactiveSensorList = new List<InactiveSensorsReq>();
                var reducedFuncList = new List<ReducedFunctionalityModeReq>();

                if (req.inactiveSensorsfile != null && IsExcelFile(req.inactiveSensorsfile.FileName))
                {
                    inactiveSensorList = await ParseInactiveSensorsExcelAsync(req.inactiveSensorsfile, cancellationToken);
                }

                if (req.reducedFunctionalityModefile != null && IsExcelFile(req.reducedFunctionalityModefile.FileName))
                {
                    reducedFuncList = await ParseReducedFunctionalityModeExcelAsync(req.reducedFunctionalityModefile, cancellationToken);
                }

                var inactiveEntities = inactiveSensorList
                    .Select(item => InactiveSensors.ExcelUploadCreate(logRequest.Id, item))
                    .ToList();

                var reducedFuncEntities = reducedFuncList
                    .Select(item => ReducedFunctionalityMode.ExcelUploadCreate(logRequest.Id, item))
                    .ToList();

                await reducedFuncRepo.AddRangeAsync(reducedFuncEntities);
                await inactiveSensorRepo.AddRangeAsync(inactiveEntities);
                await inactiveSensorRepo.SaveChangesAsync();

                var response = new AntivirusAssessmentFileUploadResp(
                    AntivirusAssessmentFileId: logRequest.Id,
                    InactiveSensors: $"{inactiveSensorList.Count} Records uploaded successfully",
                    ReducedFunctionalityMode: $"{reducedFuncList.Count} Records uploaded successfully"
                );

                return TypedResults.Created($"AM/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Exception: Unable to save the request");
            }
        }

        private static bool IsExcelFile(string fileName)
        {
            var ext = Path.GetExtension(fileName)?.ToLower();
            return ext == ".xlsx" || ext == ".xls";
        }

        private static async Task<List<InactiveSensorsReq>> ParseInactiveSensorsExcelAsync(IFormFile file, CancellationToken cancellationToken)
        {
            var result = new List<InactiveSensorsReq>();
            
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream, cancellationToken);
                ExcelPackage.License.SetNonCommercialOrganization("arm");
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
                {
                    var workSheet = excelPackage.Workbook.Worksheets[0];
                    int totalRows = workSheet.Dimension.Rows;

                    for (int i = 2; i <= totalRows; i++)
                    {
                                               
                        result.Add(new InactiveSensorsReq
                        {
                            ComputerName = workSheet.Cells[i, 1].Value?.ToString() ?? null,
                            LastSeenOnCrowdStrike = workSheet.Cells[i, 2].Value?.ToString() ?? null,
                            MACAddress = workSheet.Cells[i, 3].Value?.ToString() ?? null,
                            SystemProductName = workSheet.Cells[i, 4].Value?.ToString() ?? null,
                            SystemVersion = workSheet.Cells[i, 5].Value?.ToString() ?? null,
                            LoggedOnUser = workSheet.Cells[i, 6].Value?.ToString() ?? null,
                            LastSeenOnManageEngine = workSheet.Cells[i, 7].Value?.ToString() ?? null
                        });
                    }
                }

                return result;
            }
        }

        private static async Task<List<ReducedFunctionalityModeReq>> ParseReducedFunctionalityModeExcelAsync(IFormFile file, CancellationToken cancellationToken)
        {
            var result = new List<ReducedFunctionalityModeReq>();           

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream, cancellationToken);
                ExcelPackage.License.SetNonCommercialOrganization("arm");
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
                {
                    var workSheet = excelPackage.Workbook.Worksheets[0];
                    int totalRows = workSheet.Dimension.Rows;

                    for (int i = 2; i <= totalRows; i++)
                    {
                           
                        result.Add(new ReducedFunctionalityModeReq
                        {
                            ComputerName = workSheet.Cells[i, 1].Value?.ToString() ?? null,
                            LastSeenOnCrowdStrike = workSheet.Cells[i, 2].Value?.ToString() ?? null,
                            MACAddress = workSheet.Cells[i, 3].Value?.ToString() ?? null,
                            SystemVersion = workSheet.Cells[i, 4].Value?.ToString() ?? null,
                            LoggedOnUser = workSheet.Cells[i, 5].Value?.ToString() ?? null,
                            LastSeenOnManageEngine = workSheet.Cells[i, 6].Value?.ToString() ?? null
                        });
                    }
                }
                return result;
            }

        }
                
    }
}
