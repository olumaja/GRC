using Arm.GrcApi.Modules.Shared;

using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcTool.Domain.BusinessImpactAnalysis
{
    public class BIAUnitProcessDetailsBusinessUnitToRunProcess : AuditEntity
    {
        public Guid Id { get; private set; }

        public Guid BIAUnitProcessDetailsId { get; private set; }

        [JsonIgnore]
        public virtual BIAUnitProcessDetails BIAUnitProcessDetails { get; private set; } = null!;

        [ForeignKey(nameof(Unit))]
        public Guid UnitId { get; private set; }

        [JsonIgnore]
        public virtual Unit Unit { get; private set; } = null!;

        public static BIAUnitProcessDetailsBusinessUnitToRunProcess Create(Guid biaUnitProcessDetailsId, Guid unitId)
        {
            return new BIAUnitProcessDetailsBusinessUnitToRunProcess
            {
                BIAUnitProcessDetailsId = biaUnitProcessDetailsId,
                UnitId = unitId
            };
        }

        public static BIAUnitProcessDetailsBusinessUnitToRunProcess Create(Guid unitId)
        {
            return new BIAUnitProcessDetailsBusinessUnitToRunProcess
            {
                UnitId = unitId
            };
        }
    }
}
