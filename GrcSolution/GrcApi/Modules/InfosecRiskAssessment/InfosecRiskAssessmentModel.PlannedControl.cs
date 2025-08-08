using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class PlannedControl : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; private set; }
        public Guid InfosecRiskAssessmentId { get; private set; }
        public InfosecRiskAssessmentModel InfosecRiskAssessment { get; private set; }
        public List<PlannedControlAnnexture> PlannedControlAnnextures { get; private set; }

        public static PlannedControl Create(Guid infosecRiskAssessmentId, string name)
        {
            return new PlannedControl
            {
                InfosecRiskAssessmentId = infosecRiskAssessmentId,
                Name = name
            };
        }
    }
}
