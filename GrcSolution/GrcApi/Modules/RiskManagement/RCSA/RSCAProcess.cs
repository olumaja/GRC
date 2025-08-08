using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcTool.Domain.RiskControlSelfAssessment
{
    public class RSCAProcess : BaseEntity
    {
        public Guid UnitId { get; private set; }
        public Unit? Unit { get; private set; }
        public string? InitiatedBy { get; private set; }
        public string? LastModifiedBy { get; private set; }
        public string? SoftDeletedBy { get; private set; }

        public static RSCAProcess Create(string name, Guid unitId)
        {
            return new RSCAProcess
            {
                Name = name,
                UnitId = unitId
            };
        }

        public void AddInitiator(string initiatedBy)
        {
            InitiatedBy = initiatedBy;
        }

        public void SetLastModifiedBy(string lastModifiedBy)
        {
            LastModifiedBy = lastModifiedBy;
        }

        public void SetDeletedBy(string deletedBy)
        {
            SoftDeletedBy = deletedBy;
        }
    }
}
