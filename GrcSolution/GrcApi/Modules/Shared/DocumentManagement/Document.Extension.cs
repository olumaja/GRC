using Arm.GrcTool.Domain;

namespace Arm.GrcTool.Infrastructure
{
    public static class DocumentExtensions
    {
        /// <summary>
        /// Exatrct and convert the IFormfile to document entity format
        /// </summary>
        /// <param name="document"></param>
        /// <param name="file"></param>
        /// <param name="moduleItemType"></param>
        /// <param name="moduleItemId"></param>
        /// <returns></returns>
        public static Document ConvertFormFileToDocument(IFormFile file, ModuleType moduleItemType, Guid moduleItemId)
        {
            // Read the file content into a byte array
            using (var memoryStream = new MemoryStream())
            {
                //extract and convert to document entity
                file.CopyTo(memoryStream);
                var fileContent = memoryStream.ToArray();

                return Document.Create(name: file.FileName, moduleItemType: moduleItemType, moduleItemId: moduleItemId, fileType: file.ContentType, size: (int)file.Length, blob: fileContent);
            }
        }

        /// <summary>
        /// Exatrct and convert the document entity to IFormfile format
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static IFormFile ConvertDocumentToFormFile(this Document document)
        {
            using (MemoryStream memoryStream = new(document.Blob))
            {
                // Create a new FormFile instance using the MemoryStream
                IFormFile formFile = new FormFile(memoryStream, 0, memoryStream.Length, null, $"{document.Name}.{document.FileType}");
                return formFile;
            }
        }
    }
}
