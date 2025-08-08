using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using ClosedXML.Excel;
using GrcApi.Modules.Shared.Helpers;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;
using System.Security.Claims;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PdfSharp.UniversalAccessibility.Drawing;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Arm.GrcApi.Modules.OperationControl;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
         * Original Author: Sodiq Quadre
         * Date Created: 23/11/2024
         * Development Group: GRCTools        
         */
    public class DownloadInternalControlDashboardReportToPDF
    {
        /// <summary>
        /// Download Internal Control Report to PDF   
        /// </summary>
        /// <param name="report"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            DateTime? startDate, DateTime? endDate, IRepository<InternalControlDashboard> report, Serilog.ILogger logger
        )
        {
            try
            {   
                
                var getreport = report.GetAll().OrderByDescending(r => r.CreatedOnUtc);
                
                if (startDate != null || endDate != null)
                {
                    getreport = getreport.Where(d => d.CreatedOnUtc.Date >= startDate.Value.Date && d.CreatedOnUtc.Date <= endDate.Value.Date)
                                  .OrderByDescending(r => r.CreatedOnUtc);
                }

                using (var document = new PdfDocument())
                {
                    var page = document.AddPage();
                    page.Orientation = PdfSharp.PageOrientation.Landscape;
                    var graphics = XGraphics.FromPdfPage(page);
                    var font = new XFont("Arial", 10);

                    int yPosition = 40; // Start position for the first row
                    int lineHeight = 20;

                    // Add header
                    graphics.DrawString("Internal Control Dashboard Reports", new XFont("Arial", 14), XBrushes.Black, new XPoint(40, yPosition));
                    yPosition += lineHeight + 10;

                    // Add column titles
                    graphics.DrawString("Activity", font, XBrushes.Black, new XPoint(40, yPosition));
                    graphics.DrawString("Action Owner", font, XBrushes.Black, new XPoint(340, yPosition));
                    graphics.DrawString("Status", font, XBrushes.Black, new XPoint(440, yPosition));
                    graphics.DrawString("Proposed Completion Date", font, XBrushes.Black, new XPoint(540, yPosition));
                    graphics.DrawString("Date Completed", font, XBrushes.Black, new XPoint(680, yPosition));
                    yPosition += lineHeight;

                    // Add report data
                    foreach (var item in getreport)
                    {
                        graphics.DrawString(item.Activity, font, XBrushes.Black, new XPoint(40, yPosition));
                        graphics.DrawString(item.ActionOwner, font, XBrushes.Black, new XPoint(340, yPosition));
                        graphics.DrawString(item.Status.ToString(), font, XBrushes.Black, new XPoint(440, yPosition));                                            
                        graphics.DrawString(item.ProposedCompletionDate.ToString("yyyy-MM-dd"), font, XBrushes.Black, new XPoint(540, yPosition));
                        graphics.DrawString(item.DateTaskCompleted.ToString(), font, XBrushes.Black, new XPoint(680, yPosition));
                       
                        yPosition += lineHeight;

                        // Add a new page if the content exceeds the current page height
                        if (yPosition > page.Height - 40)
                        {
                            page = document.AddPage();
                            page.Orientation = PdfSharp.PageOrientation.Landscape;
                            graphics = XGraphics.FromPdfPage(page);
                            yPosition = 40; // Reset yPosition for the new page
                        }
                    }

                    using (var stream = new MemoryStream())
                    {
                        document.Save(stream);
                        var content = stream.ToArray();
                        return TypedResults.File(content, "application/pdf", "InternalControlDashboardReports.pdf");
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error($"Error from {nameof(DownloadInternalControlDashboardReportToPDF)} ==> Message: {ex.Message}; Stack Track: {ex}");
                return TypedResults.Problem($"Error: please try again later", null, 500);
            }

        }
    }
}
