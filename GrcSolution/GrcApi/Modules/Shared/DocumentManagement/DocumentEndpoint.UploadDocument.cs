using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GrcApi.Modules.DocumentManagement
{
    public class DocumentEndpointUploadDocument
    {
        public static async Task<IResult> HandleAsync([FromForm] IFormFile upload, IRepository<Document> repository)
        {
            // Fetch document bytes from your data store
            Document document = DocumentExtensions.ConvertFormFileToDocument(upload, ModuleType.RiskManagement, Guid.NewGuid());

            await repository.AddAsync(document);
            await repository.SaveChangesAsync();

            // Return the document as a file
            return TypedResults.Ok(document.Id);
        }
    }
}