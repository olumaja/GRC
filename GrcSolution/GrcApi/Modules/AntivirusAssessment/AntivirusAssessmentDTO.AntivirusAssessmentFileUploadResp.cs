using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public record AntivirusAssessmentFileUploadResp(Guid AntivirusAssessmentFileId, string InactiveSensors, string ReducedFunctionalityMode);

   public record InfoSecAssignAntivirusToActionOwnerReq(
   Guid AntivirusAssessmentFileId,
   string ActionOwner,
   string ActionOwnerEmail,
   string ActionOwnerUnit,
   DateTime ProposeEndDate
   );

    public class InfoSecAssignAntivirusToActionOwnerReqValidator : AbstractValidator<InfoSecAssignAntivirusToActionOwnerReq>
    {
        public InfoSecAssignAntivirusToActionOwnerReqValidator()
        {
            RuleFor(x => x.AntivirusAssessmentFileId).NotEmpty();
            RuleFor(x => x.ActionOwner).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(x => x.ActionOwnerEmail).NotEmpty();
            RuleFor(x => x.ActionOwnerUnit).NotEmpty();
            RuleFor(x => x.ProposeEndDate).NotEmpty();
        }
    }
}
