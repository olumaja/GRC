using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcTool.Domain
{
    public class Document: BaseEntity
    {
        public ModuleType ModuleItemType { get; private set; }

        public Guid ModuleItemId { get; private set; }

        public string FileType { get; private set; } = null!;

        public int Size { get; private set; }

        public byte[] Blob { get; private set; } = null!;

        public static Document Create(
            string name,
            ModuleType moduleItemType,
            Guid moduleItemId,
            string fileType,
            int size,
            byte[] blob
            )
        {
            return new Document
            {
                Name = name,
                ModuleItemType = moduleItemType,
                ModuleItemId = moduleItemId,
                FileType = fileType,
                Size = size,
                Blob = blob
            };
        }
    }
}
