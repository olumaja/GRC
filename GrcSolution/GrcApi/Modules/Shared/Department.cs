using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain
{
    public class Department:BaseEntity
    {
        public Guid BusinessEntityId { get; private set; }

        public BusinessEntity BusinessEntity { get; private set; } = null!;

        public List<Unit> Units { get; private set; } = new List<Unit>();

        public static Department Create(Guid businessEntityId, string name, Guid id)
        {
            return new Department
            {
                BusinessEntityId = businessEntityId,
                Name = name,
                Id = id
            };
        }

        public static Department Create(Guid businessEntityId, string name)
        {
            return new Department
            {
                BusinessEntityId = businessEntityId,
                Name = name
            };
        }
    }
}
