using Arm.GrcApi.Modules.InternalControl;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using Org.BouncyCastle.Ocsp;
using System.Threading;

namespace Arm.GrcApi.Modules.Shared.Helpers
{
    /*
    * Original Author: Olusegun Adaramaja
    * Date Created: 02/11/2024
    * Development Group: GRCTools
    * This method generate excel document 
    */
    public class ReportDocument
    {
        /// <summary>
        /// This method generate excel document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="excelSheetName"></param>
        /// <param name="headers"></param>
        /// <param name="reports"></param>
        /// <returns></returns>
       
        public static byte[] GenerateExcelDocument<T>(string excelSheetName, List<string> headers, List<T> reports)
        {
            try{
                int headerRow = 1;
                const int maxNameLength = 30;
                //excel sheet name must not be more than 30 characters
                excelSheetName = excelSheetName.Length > maxNameLength ? excelSheetName.Substring(0, maxNameLength) : excelSheetName;

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(excelSheetName);

                    for (int i = 0; i < headers.Count; i++)
                    {
                        worksheet.Cell(headerRow, i + 1).Value = headers[i];
                    }

                    var properties = typeof(T).GetProperties();
                    var row = 2;

                    foreach (var report in reports)
                    {
                        int column = 1;
                        foreach (var property in properties)
                        {
                            worksheet.Cell(row, column).Value = report.GetType().GetProperty(property.Name).GetValue(report, null)?.ToString();
                            column++;
                        }

                        row++;
                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return content;
                    }
                }
            }
            catch(Exception ex) { 
                return null;
            }

            
        }

        public static byte[] GeneratePdfDocument2<T>(string pdfFileName, List<string> headers, List<T> reports)
    {
        try
        {
            // Create a memory stream to save the PDF to
            using (var ms = new MemoryStream())
            {
                // Create a new document
                var document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, ms);
                document.Open();

                // Add a title to the document
                document.Add(new Paragraph($"{pdfFileName}"));
                document.Add(new Paragraph("\n")); // Add a new line

                // Create a table for the headers
                var table = new PdfPTable(headers.Count);
                foreach (var header in headers)
                {
                    table.AddCell(new Phrase(header)); // Add each header as a cell
                }

                // Get the properties of the report objects
                var properties = typeof(T).GetProperties();

                // Add rows for each report
                foreach (var report in reports)
                {
                    foreach (var property in properties)
                    {
                        // Get the value of each property of the report object and add it to the table
                        var value = report.GetType().GetProperty(property.Name).GetValue(report, null)?.ToString();
                        table.AddCell(new Phrase(value)); // Add each property value as a cell
                    }
                }

                // Add the table to the document
                document.Add(table);
                document.Close();

                // Return the PDF as a byte array
                return ms.ToArray();
            }
        }
        catch (Exception ex)
        {
            // Handle exception (log it, rethrow, etc.)
            return null;
        }
    }

        public static List<Dictionary<string, string>> ReadExcelDocument(IFormFile file)
        {
            var result = new List<Dictionary<string, string>>();

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var workbook = new XLWorkbook(stream))
                {
                    var firstWorksheet = 1;
                    var firstRow = 1; //This is where the headers is
                    var worksheet = workbook.Worksheet(firstWorksheet); // Get first worksheet
                    var rows = worksheet.RangeUsed().RowsUsed();

                    var headers = new List<string>();
                    foreach (var cell in rows.First().Cells())
                    {
                        headers.Add(cell.Value.ToString());
                    }

                    foreach (var row in rows.Skip(firstRow))
                    {
                        var rowData = new Dictionary<string, string>();
                        for (int i = 0; i < headers.Count; i++)
                        {
                            rowData[headers[i]] = row.Cell(i + 1).GetValue<string>();
                        }
                        result.Add(rowData);
                    }
                }
            }

            return result;
        }
    }
}
