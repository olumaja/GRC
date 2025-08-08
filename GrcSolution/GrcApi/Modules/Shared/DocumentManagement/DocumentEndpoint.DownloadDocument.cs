using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;

namespace GrcApi.Modules.DocumentManagement
{
    public class DocumentEndpointDownloadDocument
    {
        public static async Task<IResult> HandleAsync(Guid documentId, IRepository<Document> repository)
        {
            // Fetch document bytes from your data store
            Document document = await repository.GetByIdAsync(documentId);

            if (document == null)
            {
                return TypedResults.NotFound();
            }

            // Determine the content type based on document type (e.g., "application/pdf")
            string contentType = string.IsNullOrWhiteSpace(document.FileType) ? document.FileType : "application/octet-stream";

            // Return the document as a file
            return TypedResults.File(document.Blob, contentType, document.Name);
        }
    }
}
