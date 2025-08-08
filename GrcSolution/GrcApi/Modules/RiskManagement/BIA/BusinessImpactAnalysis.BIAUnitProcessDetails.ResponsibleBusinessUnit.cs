//using Arm.GrcApi.Modules.Shared;

//using Newtonsoft.Json;

//using System.ComponentModel.DataAnnotations.Schema;

//namespace Arm.GrcTool.Domain.BusinessImpactAnalysis
//{
//    public class BIAUnitProcessDetailsResponsibleBusinessUnit : AuditEntity
//    {
//        public Guid Id { get; private set; } = Guid.NewGuid();

//        public Guid BIAUnitProcessDetailsId { get; private set; }

//        [JsonIgnore]
//        public virtual BIAUnitProcessDetails BIAUnitProcessDetails { get; private set; } = null!;

//        [ForeignKey(nameof(Unit))]
//        public Guid UnitId { get; private set; }

//        [JsonIgnore]
//        public virtual Unit Unit { get; private set; } = null!;

//        public static BIAUnitProcessDetailsResponsibleBusinessUnit Create(Guid biaUnitProcessDetailsId, Guid unitId)
//        {
//            return new BIAUnitProcessDetailsResponsibleBusinessUnit
//            {
//                BIAUnitProcessDetailsId = biaUnitProcessDetailsId,
//                UnitId = unitId
//            };
//        }

//        public static BIAUnitProcessDetailsResponsibleBusinessUnit Create(Guid unitId)
//        {
//            return new BIAUnitProcessDetailsResponsibleBusinessUnit
//            {
//                UnitId = unitId
//            };
//        }
//    }

//}
