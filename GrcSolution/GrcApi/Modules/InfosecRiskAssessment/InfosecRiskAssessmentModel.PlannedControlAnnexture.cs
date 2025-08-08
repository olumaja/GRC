
using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class PlannedControlAnnexture : AuditEntity2
    {
        public Guid PlannedControlId { get; private set; }
        public Guid AnnextureId { get; private set; }
        public PlannedControl PlannedControl { get; private set; }
        public Annexture Annexture { get; private set; }

        public static PlannedControlAnnexture Create(Guid plannedId, Guid AnextureId)
        {
            return new PlannedControlAnnexture
            {
                PlannedControlId = plannedId,
                AnnextureId = AnextureId
            };
        }
    }
}
