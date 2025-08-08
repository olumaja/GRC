using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain.DocumentManagement;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.RiskControlSelfAssessmentUnit;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record GetProcessInherentRiskControlRiskRatingDto(
        Guid RiskControlSelfAssessmentUnitId, string? Requester, string? Approval, DateTime? ApprovalDate,
        DateOnly PeriodFrom, DateOnly PeriodTo, DateOnly StartDate, DateOnly EndDate,
        RCSAStatus Status, List<ProcessInherentRiskControlRiskRating> ProcessInherentRiskControls
    );

    public record ProcessInherentRiskControlRiskRating(
      Guid ProcessInherentRiskControlId, Guid ProcessId,  string ProcessName,  string InherentRisk,  string Control,  string TestToApply,
         string TestResult,  string ColourEffectiveness,  string ResidualRisks, int? ResidualRiskRating,  string ResidualRiskLevel,
       string CorrectiveActions,  string ActionOwnerUserName, DateOnly? TimeLine, DocumentDto Document
    );

    public class CreateRCSAProcessDto {
        public string Unit { get; set; }
        public string ProcessName { get; set; }
    }

    public class CreateRCSAProcessDtoValidator : AbstractValidator<CreateRCSAProcessDto>
    {
        public CreateRCSAProcessDtoValidator()
        {
            RuleFor( x => x.ProcessName ).NotEmpty().Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor( x => x.Unit ).NotEmpty().Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class DeleteRCSAProcessDto { public string ProcessName { get; set; } };

    public class DeleteRCSAProcessDtoValidator : AbstractValidator<DeleteRCSAProcessDto>
    {
        public DeleteRCSAProcessDtoValidator()
        {
            RuleFor(x => x.ProcessName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record GetRCSAProcessResponse(Guid Id, string ProcessName);
}
