using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class NotifyISORiskAssessmentModel : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string? Unit { get; private set; }
        public string? Objective { get; private set; }
        public string? RequesterName { get; private set; }
        public string? RequesterEmail { get; private set; }
        public bool? IsMessageSent { get; private set; } = true;
        public static NotifyISORiskAssessmentModel Create(string unit, string objective, string? requesterName, string? requesterEmail)
        {
            return new NotifyISORiskAssessmentModel
            {
                Unit = unit,
                Objective = objective,
                RequesterName = requesterName,
                RequesterEmail = requesterEmail
            };
        }
       
    }
}
