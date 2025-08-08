using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class ExistingPrimaryControlAnnexture : AuditEntity2
    {
        public Guid ExistingPrimaryControlId { get; private set; }
        public Guid AnnextureId { get; private set; }
        public ExistingPrimaryControl ExistingPrimaryControl { get; private set; }
        public Annexture Annexture { get; private set; }

        public static ExistingPrimaryControlAnnexture Create(Guid existingId, Guid anextureId)
        {
            return new ExistingPrimaryControlAnnexture
            {
                ExistingPrimaryControlId = existingId,
                AnnextureId = anextureId
            };
        }
    }
}
