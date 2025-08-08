using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class InactiveSensorsReq
    {
        public string? ComputerName { get; set; } = null;
        public string? LastSeenOnCrowdStrike { get; set; } = null;
        public string? MACAddress { get; set; } = null;
        public string? SystemProductName { get; set; } = null;
        public string? SystemVersion { get; set; } = null;
        public string? LoggedOnUser { get; set; } = null;
        public string? LastSeenOnManageEngine { get; set; } = null;
    }

    public record ApproveAntivirusAssessmentRequest(Guid antivirusId);

    public class ApproveAntivirusAssessmentRequestValidator : AbstractValidator<ApproveAntivirusAssessmentRequest>
    {
        public ApproveAntivirusAssessmentRequestValidator()
        {
            RuleFor(x => x.antivirusId).NotEmpty();
        }
    }

    public record RejectAntivirusAssessmentReq(Guid antivirusId, string Comment);

    public class RejectAntivirusAssessmentReqValidator : AbstractValidator<RejectAntivirusAssessmentReq>
    {
        public RejectAntivirusAssessmentReqValidator()
        {
            RuleFor(x => x.antivirusId).NotEmpty();
            RuleFor(x => x.Comment).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);

        }
    }
}
