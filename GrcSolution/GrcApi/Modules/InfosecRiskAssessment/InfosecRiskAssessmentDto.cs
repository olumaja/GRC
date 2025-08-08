using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using Newtonsoft.Json;
using System.Reflection;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public record InfosecRiskAssessmentDto(
        string Asset, string AssetDescription, DateTime RiskAssessmentDate, string Category,
        string ConfidentialityRating, string IntegrityRating, string AvailabilityRating,
        string AssetValue, string AssetScore, string Vulnerability, string VulnerabilityRating,
        string Threats, string ImpactRating, string LikelihoodofThreatOccurring, string RiskScore,
        string RiskValue, string RiskOptions, List<ExistingPrimaryControlDto> ExistingPrimaryControls,
        string ControlEffectiveness, string ResidualRisk, string RiskOwner, List<ActionOwnerDetails> ActionOwners,
        string AdditionalInformation, DateTime ProposedClosureDate, string RemediationStatus,
        List<PlannedControlDto> PlannedControls, IFormFile Attachment
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a InfosecRiskAssessmentDto object and returns object
        /// </summary>     
        public static ValueTask<InfosecRiskAssessmentDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            var RiskAssessmentDate = Convert.ToDateTime(httpContext.Request.Form["RiskAssessmentDate"]);
            var ProposedClosureDate = Convert.ToDateTime(httpContext.Request.Form["ProposedClosureDate"]);
            var serilizePlan = httpContext.Request.Form["PlannedControls"].ToString().Replace("\n", "").Replace("\r", "");
            var PlannedControls = FormInput.ConvertToObject<PlannedControlDto>(serilizePlan);
            var serilizeExist = httpContext.Request.Form["ExistingPrimaryControls"].ToString().Replace("\n", "").Replace("\r", "");
            var ExistingPrimaryControls = FormInput.ConvertToObject<ExistingPrimaryControlDto>(serilizeExist);
            var serilizeActionOwner = httpContext.Request.Form["ActionOwners"].ToString().Replace("\n", "").Replace("\r", "");
            var ActionOwners = FormInput.ConvertToObject<ActionOwnerDetails>(serilizeActionOwner);

            return ValueTask.FromResult(new InfosecRiskAssessmentDto(
                   httpContext.Request.Form["Asset"],
                   httpContext.Request.Form["AssetDescription"],
                   RiskAssessmentDate,
                   httpContext.Request.Form["Category"],
                   httpContext.Request.Form["ConfidentialityRating"],
                   httpContext.Request.Form["IntegrityRating"],
                   httpContext.Request.Form["AvailabilityRating"],
                   httpContext.Request.Form["AssetValue"],
                   httpContext.Request.Form["AssetScore"],
                   httpContext.Request.Form["Vulnerability"],
                   httpContext.Request.Form["VulnerabilityRating"],
                   httpContext.Request.Form["Threats"],
                   httpContext.Request.Form["ImpactRating"],
                   httpContext.Request.Form["LikelihoodofThreatOccurring"],
                   httpContext.Request.Form["RiskScore"],
                   httpContext.Request.Form["RiskValue"],
                   httpContext.Request.Form["RiskOptions"],
                   ExistingPrimaryControls,
                   httpContext.Request.Form["ControlEffectiveness"],
                   httpContext.Request.Form["ResidualRisk"],
                   httpContext.Request.Form["RiskOwner"],
                   ActionOwners,
                   httpContext.Request.Form["AdditionalInformation"],
                   ProposedClosureDate,
                   httpContext.Request.Form["RemediationStatus"],
                   PlannedControls,
                   httpContext.Request.Form.Files.GetFile("Attachment")
                ));
        }
    }

    public class InfosecRiskAssessmentDtoValidator : AbstractValidator<InfosecRiskAssessmentDto>
    {
        public InfosecRiskAssessmentDtoValidator()
        {
            RuleFor(r => r.Asset).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.AssetDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.AssetValue).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.RiskScore).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.RiskValue).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ResidualRisk).NotEmpty().Matches(@"^\d+(\.\d+)?$").WithMessage("Only numbers and decimal points are allowed."); // Validate only numbers and decimal point
            //RuleFor(r => r.ResidualRisk).NotEmpty().Matches("^[0-9]+$").WithMessage("'{PropertyName}' must contain only string of numbers."); //Validates that the string contains only digits;
            RuleFor(r => r.RiskAssessmentDate).NotEmpty();
            RuleFor(r => r.Category).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ConfidentialityRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.IntegrityRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.AvailabilityRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.AssetScore).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Vulnerability).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.VulnerabilityRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Threats).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ImpactRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.LikelihoodofThreatOccurring).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.RiskOptions).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ControlEffectiveness).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.RiskOwner).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ActionOwners).NotEmpty();
            RuleForEach(x => x.ActionOwners).SetValidator(new ActionOwnerDetailsValidator());
            RuleFor(r => r.AdditionalInformation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ProposedClosureDate).NotEmpty();
            RuleFor(r => r.RemediationStatus).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Attachment).NotEmpty();
            RuleFor(r => r.ExistingPrimaryControls).NotEmpty();
            RuleForEach(x => x.ExistingPrimaryControls).SetValidator(new ExistingPrimaryControlDtoValidator());
            RuleFor(r => r.PlannedControls).NotEmpty();
            RuleForEach(x => x.PlannedControls).SetValidator(new PlannedControlDtoValidator());
        }
    }

    public record UpdateInfosecRiskAssessmentDto(
        Guid RiskId, string Asset, string AssetDescription, DateTime RiskAssessmentDate, string Category,
        string ConfidentialityRating, string IntegrityRating, string AvailabilityRating,
        string AssetValue, string AssetScore, string Vulnerability, string VulnerabilityRating,
        string Threats, string ImpactRating, string LikelihoodofThreatOccurring, string RiskScore,
        string RiskValue, string RiskOptions, List<ExistingPrimaryControlDto> ExistingPrimaryControls,
        string ControlEffectiveness, string ResidualRisk, string RiskOwner, List<ActionOwnerDetails> ActionOwners,
        string AdditionalInformation, DateTime ProposedClosureDate, string RemediationStatus,
        List<PlannedControlDto> PlannedControls, IFormFile Attachment
    )
    {
        /// <summary>
        /// Binds the values from the multipart form in the http request to a InfosecRiskAssessmentDto object and returns object
        /// </summary>     
        public static ValueTask<UpdateInfosecRiskAssessmentDto> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            var RiskId = Guid.Parse(httpContext.Request.Form["RiskId"]);
            var RiskAssessmentDate = Convert.ToDateTime(httpContext.Request.Form["RiskAssessmentDate"]);
            //var RiskScore = Convert.ToInt32(httpContext.Request.Form["RiskScore"]);
            //var RiskValue = Convert.ToInt32(httpContext.Request.Form["RiskValue"]);
            //var ResidualRisk = Convert.ToInt32(httpContext.Request.Form["ResidualRisk"]);
            //var AssetValue = Convert.ToInt32(httpContext.Request.Form["AssetValue"]);
            var ProposedClosureDate = Convert.ToDateTime(httpContext.Request.Form["ProposedClosureDate"]);
            var serilizePlan = httpContext.Request.Form["PlannedControls"].ToString().Replace("\n", "").Replace("\r", "");
            var PlannedControls = FormInput.ConvertToObject<PlannedControlDto>(serilizePlan);
            var serilizeExist = httpContext.Request.Form["ExistingPrimaryControls"].ToString().Replace("\n", "").Replace("\r", "");
            var ExistingPrimaryControls = FormInput.ConvertToObject<ExistingPrimaryControlDto>(serilizeExist);
            var serilizeActionOwner = httpContext.Request.Form["ActionOwners"].ToString().Replace("\n", "").Replace("\r", "");
            var ActionOwners = FormInput.ConvertToObject<ActionOwnerDetails>(serilizeActionOwner);

            return ValueTask.FromResult(new UpdateInfosecRiskAssessmentDto(
                   RiskId,
                   httpContext.Request.Form["Asset"],
                   httpContext.Request.Form["AssetDescription"],
                   RiskAssessmentDate,
                   httpContext.Request.Form["Category"],
                   httpContext.Request.Form["ConfidentialityRating"],
                   httpContext.Request.Form["IntegrityRating"],
                   httpContext.Request.Form["AvailabilityRating"],
                   httpContext.Request.Form["AssetValue"],
                   httpContext.Request.Form["AssetScore"],
                   httpContext.Request.Form["Vulnerability"],
                   httpContext.Request.Form["VulnerabilityRating"],
                   httpContext.Request.Form["Threats"],
                   httpContext.Request.Form["ImpactRating"],
                   httpContext.Request.Form["LikelihoodofThreatOccurring"],
                   httpContext.Request.Form["RiskScore"],
                   httpContext.Request.Form["RiskValue"],
                   httpContext.Request.Form["RiskOptions"],
                   ExistingPrimaryControls,
                   httpContext.Request.Form["ControlEffectiveness"],
                   httpContext.Request.Form["ResidualRisk"],
                   httpContext.Request.Form["RiskOwner"],
                   ActionOwners,
                   httpContext.Request.Form["AdditionalInformation"],
                   ProposedClosureDate,
                   httpContext.Request.Form["RemediationStatus"],
                   PlannedControls,
                   httpContext.Request.Form.Files.GetFile("Attachment")
                ));
        }
    }

    public class UpdateInfosecRiskAssessmentDtoValidator : AbstractValidator<UpdateInfosecRiskAssessmentDto>
    {
        public UpdateInfosecRiskAssessmentDtoValidator()
        {
            RuleFor(r => r.RiskId).NotEmpty();
            RuleFor(r => r.Asset).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.AssetDescription).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.AssetValue).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.RiskScore).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.RiskValue).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ResidualRisk).NotEmpty().Matches(@"^\d+(\.\d+)?$").WithMessage("Only numbers and decimal points are allowed."); // Validate only numbers and decimal point
            //RuleFor(r => r.ResidualRisk).NotEmpty().Matches("^[0-9]+$").WithMessage("'{PropertyName}' must contain only string of numbers."); //Validates that the string contains only digits;
            RuleFor(r => r.RiskAssessmentDate).NotEmpty();
            RuleFor(r => r.Category).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ConfidentialityRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.IntegrityRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.AvailabilityRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.AssetScore).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Vulnerability).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.VulnerabilityRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Threats).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ImpactRating).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.LikelihoodofThreatOccurring).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.RiskOptions).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ControlEffectiveness).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.RiskOwner).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ActionOwners).NotEmpty();
            RuleForEach(x => x.ActionOwners).SetValidator(new ActionOwnerDetailsValidator());
            RuleFor(r => r.AdditionalInformation).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.ProposedClosureDate).NotEmpty();
            RuleFor(r => r.RemediationStatus).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(r => r.Attachment).NotEmpty();
            RuleFor(r => r.ExistingPrimaryControls).NotEmpty();
            RuleForEach(x => x.ExistingPrimaryControls).SetValidator(new ExistingPrimaryControlDtoValidator());
            RuleFor(r => r.PlannedControls).NotEmpty();
            RuleForEach(x => x.PlannedControls).SetValidator(new PlannedControlDtoValidator());
        }
    }

    public record ExistingPrimaryControlDto(string ExistingPrimaryControl);

    public class ExistingPrimaryControlDtoValidator : AbstractValidator<ExistingPrimaryControlDto>
    {
        public ExistingPrimaryControlDtoValidator()
        {
            RuleFor(e => e.ExistingPrimaryControl).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record PlannedControlDto(string PlannedControl);
    public class PlannedControlDtoValidator : AbstractValidator<PlannedControlDto>
    {
        public PlannedControlDtoValidator()
        {
            RuleFor(e => e.PlannedControl).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record ActionOwnerDetails(string Name, string Email);
    public class ActionOwnerDetailsValidator : AbstractValidator<ActionOwnerDetails>
    {
        public ActionOwnerDetailsValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(e => e.Email).NotEmpty().EmailAddress();
        }
    }

    public record InfosecRiskAssessment(
        string Asset, string AssetDescription, DateTime RiskAssessmentDate, string Category,
        ISORating ConfidentialityRating, ISORating IntegrityRating, ISORating AvailabilityRating,
        string AssetValue, ISORating AssetScore, string Vulnerability, ISORating VulnerabilityRating,
        string Threats, ISOImpactRating ImpactRating, ISOThreatOccuring LikelihoodofThreatOccurring, string RiskScore,
        string RiskValue, string RiskOptions, string ControlEffectiveness, string ResidualRisk, 
        string RiskOwner, string ActionOwner, string ActionOwnerEmail, string AdditionalInformation, 
        DateTime ProposedClosureDate, ISORemediation RemediationStatus, string? Unit
    );

    public record ApprovalDto(Guid RiskId, string Status, string? ReasonForRejection);

    public class ApprovalDtoValidator : AbstractValidator<ApprovalDto>
    {
        public ApprovalDtoValidator() { 
            RuleFor(r => r.RiskId).NotEmpty();
            RuleFor(r => r.Status).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public record InfosecRiskAssessmentByIdResponse(
        Guid RiskId, string Asset, string AssetDescription, DateTime? RiskAssessmentDate, string Category,
        string? ConfidentialityRating, string IntegrityRating, string AvailabilityRating,
        string AssetValue, string AssetScore, string Vulnerability, string VulnerabilityRating,
        string Threats, string ImpactRating, string LikelihoodofThreatOccurring, string RiskScore,
        string RiskValue, string RiskOptions, string Status,
        string ControlEffectiveness, string ResidualRisk, string RiskOwner, List<ActionOwnerDetails> ActionOwners,
        string AdditionalInformation, DateTime? ProposedClosureDate, string RemediationStatus,
        List<PlannedControlResponse> PlannedControls, List<ExistingPrimaryControlResponse> ExistingPrimaryControls, DocumentResponse Attachment
    );

    public record PlannedControlResponse(Guid PlannedControlId, string PlannedControlName, List<AnextureDto> Anextures);
    public record ExistingPrimaryControlResponse(Guid ExistingPrimaryControlId, string ExistingPrimaryControlName, List<AnextureDto> Anextures);

    public record AnextureDto(Guid AnextureId, string AnextureName);
    public record DocumentResponse(Guid? DocumentId, string? DocumentName);


    public record AddAnexture(Guid RiskId, List<AddPlannedControlAnexture> PlannedControlAnextures, List<AddPExistingPrimaryControlAnexture> ExistingPrimaryControlAnextures);
    public class AddAnextureValidator : AbstractValidator<AddAnexture>
    {
        public AddAnextureValidator() { 
            RuleFor(r => r.RiskId).NotEmpty();
            RuleFor(p => p.PlannedControlAnextures).NotEmpty();
            RuleForEach(x => x.PlannedControlAnextures).SetValidator(new AddPlannedControlAnextureValidator());
            RuleFor(p => p.ExistingPrimaryControlAnextures).NotEmpty();
            RuleForEach(x => x.ExistingPrimaryControlAnextures).SetValidator(new AddPExistingPrimaryControlAnextureValidator());
        }
    }

    public record AddPlannedControlAnexture(Guid PlannedControlId, List<AnextureRequest> Anextures);
    public class AddPlannedControlAnextureValidator : AbstractValidator<AddPlannedControlAnexture>
    {
        public AddPlannedControlAnextureValidator()
        {
            RuleFor(p => p.PlannedControlId).NotEmpty();
            RuleFor(p => p.Anextures).NotEmpty();
            RuleForEach(p => p.Anextures).SetValidator(new AnextureRequestValidator());
        }
    }

    public record AddPExistingPrimaryControlAnexture(Guid ExistingPrimaryControlId, List<AnextureRequest> Anextures);
    public class AddPExistingPrimaryControlAnextureValidator : AbstractValidator<AddPExistingPrimaryControlAnexture>
    {
        public AddPExistingPrimaryControlAnextureValidator()
        {
            RuleFor(p => p.ExistingPrimaryControlId).NotEmpty();
            RuleFor(p => p.Anextures).NotEmpty();
            RuleForEach(p => p.Anextures).SetValidator(new AnextureRequestValidator());
        }
    }
    public record AnextureRequest(Guid AnnextureId, string AnextureName);
    public class AnextureRequestValidator : AbstractValidator<AnextureRequest>
    {
        public AnextureRequestValidator()
        {
            RuleFor(p => p.AnnextureId).NotEmpty();
            RuleFor(p =>p.AnextureName).NotEmpty().Must(CharacterValidation.IsInvalidCharacter).WithMessage(GRCToolsMessages.InvalidCharacters);
        }
    }

    public class AnnextureResponse
    {
        public Guid Id { get; set; }
        public string Annexture { get; set; }
    }
        
}
