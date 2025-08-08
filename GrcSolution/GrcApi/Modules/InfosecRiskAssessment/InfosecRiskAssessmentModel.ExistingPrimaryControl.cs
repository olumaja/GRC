using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class ExistingPrimaryControl : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; private set; }
        public Guid InfosecRiskAssessmentId { get; private set; }
        public InfosecRiskAssessmentModel InfosecRiskAssessment { get; private set; }
        public List<ExistingPrimaryControlAnnexture> ExistingPrimaryControlAnnextures { get; private set; }

        public static ExistingPrimaryControl Create(Guid infosecRiskAssessmentId, string name)
        {
            return new ExistingPrimaryControl
            {
                InfosecRiskAssessmentId = infosecRiskAssessmentId,
                Name = name
            };
        }

        public void UpdateExistingPrimaryControl(string name)
        {
            Name = name;
        }
    }
}
