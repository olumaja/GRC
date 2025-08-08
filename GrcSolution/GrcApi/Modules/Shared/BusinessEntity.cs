using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain
{
    public class BusinessEntity:BaseEntity
    {
        public static BusinessEntity Create(
            string name,
            Guid id
            )
        {
            return new BusinessEntity
            {
                Name = name,
                Id = id
            };
        }

        public static BusinessEntity Create(
            string name
            )
        {
            return new BusinessEntity
            {
                Name = name
            };
        }

        public virtual List<Department> Departments { get; set; } = new List<Department>();
    }
}
