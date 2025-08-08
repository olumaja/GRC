using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class Annexture : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; private set; }
        public List<PlannedControlAnnexture> PlannedControlAnnextures { get; private set; }
        public List<ExistingPrimaryControlAnnexture> ExistingPrimaryControlAnnextures { get; private set; }

        public static Annexture Create(Guid id, string name)
        {
            return new Annexture { Id = id, Name = name };
        }
    }
}
