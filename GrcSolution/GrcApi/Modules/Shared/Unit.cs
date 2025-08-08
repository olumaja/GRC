

using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;

namespace Arm.GrcTool.Domain
{
    public class Unit:BaseEntity
    {
        public Guid DepartmentId { get; private set; }

        public Department Department { get; private set; } = null!;
        public List<RSCAProcess> RSCAProcess { get; set; } = new List<RSCAProcess>();

        public static Unit Create(Guid departmentId, string name, Guid id)
        {
            return new Unit
            {
                DepartmentId = departmentId,
                Name = name,
                Id = id
            };
        }

        public static Unit Create(Guid departmentId, string name)
        {
            return new Unit 
            { 
                DepartmentId = departmentId,
                Name = name 
            };
        }
    }
}
