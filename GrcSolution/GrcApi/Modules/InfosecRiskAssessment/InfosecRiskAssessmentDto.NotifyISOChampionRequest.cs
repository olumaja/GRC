using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.Reflection;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public record NotifyISOChampionRequest(List<string> Units, string Objective);

    public class NotifyISOChampionRequestValidator : AbstractValidator<NotifyISOChampionRequest>
    {
        public NotifyISOChampionRequestValidator()
        {
            RuleFor(r => r.Objective).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Units).NotEmpty();
        }
    }

    public record NotifyISOChampionResp(Guid NotifyISOId);
    public record CommenceAssessmentResp(Guid RiskAssessmentId);




}
