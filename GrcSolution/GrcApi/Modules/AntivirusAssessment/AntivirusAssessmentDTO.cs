using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using FluentValidation;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public record AntivirusAssessmentDTO(
        Guid AntiVirusModelId, 
        Guid InactiveSensorId, 
        AntivirusStatus Status,
        string? ActionOwnerComment,
        IFormFile? Attachment
    );

    public record SubmitAntivirusAssessmentDt0(Guid antivirusAssessmentFileId);

    public class SubmitAntivirusAssessmentDt0Validator : AbstractValidator<SubmitAntivirusAssessmentDt0>
    {
        public SubmitAntivirusAssessmentDt0Validator()
        {
            RuleFor(x => x.antivirusAssessmentFileId).NotEmpty();

        }
    }

}
