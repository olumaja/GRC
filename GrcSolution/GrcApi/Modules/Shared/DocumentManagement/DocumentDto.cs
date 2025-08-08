namespace Arm.GrcTool.Domain.DocumentManagement
{
    public record DocumentDto(
        Guid DocumentId,
        string Name,
        Guid ModuleItemId
        );

    public record UploadDocumentDto(
        string Name,
        IFormFile File
        );
}
