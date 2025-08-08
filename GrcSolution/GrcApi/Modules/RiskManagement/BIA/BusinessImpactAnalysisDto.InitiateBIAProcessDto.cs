using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BIAUnitProcessDetails;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public record InitiateBIAProcessDetailsDto(
         string BusinessProcessDescriptionSummary,
         Guid ProcessId,
         string FinancialImpact,
         string CustomerExperience,
        string OtherProcessesOrPeople,
        string RegulatoryOrLegal,
        string Reputation,
        string ThirdPartyImpact,
        string MinimumBusinessContinuityObjective,
        string MaximumAllowableOutage,
         string RecoveryTimeObjective,
         string RecoveryPointObjective,
         BIAPriority Priority,
         string ApplicationsUsedToRunProcess,
         string KeyVendors,
         string AnyNonElectronicVitalRecords,
         string AlternativeWorkarounds,
         string PrimaryRecoverStrategyAndSolution,
         BIAPeakPeriod PeakPeriod,
         string RemoteWorking,
         //List<Guid> ResponsibleBusinessUnits,
         List<Guid> BusinessUnitsToRunProcess
    );

    public class InitiateBIAProcessDetailsDtoValidator : AbstractValidator<InitiateBIAProcessDetailsDto>
    {
        public InitiateBIAProcessDetailsDtoValidator()
        {
            RuleFor(model => model.BusinessProcessDescriptionSummary).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.ProcessId).NotEmpty();
            RuleFor(model => model.FinancialImpact).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.CustomerExperience).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.OtherProcessesOrPeople).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.RegulatoryOrLegal).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.Reputation).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.ThirdPartyImpact).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.MinimumBusinessContinuityObjective).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.MaximumAllowableOutage).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.RecoveryTimeObjective).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.RecoveryPointObjective).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(model => model.Priority).NotNull();
            RuleFor(model => model.ApplicationsUsedToRunProcess).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.KeyVendors).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.AnyNonElectronicVitalRecords).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.AlternativeWorkarounds).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            RuleFor(model => model.PrimaryRecoverStrategyAndSolution).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(model => model.PeakPeriod).NotNull();
            RuleFor(model => model.RemoteWorking).NotEmpty()
                .Must(CharacterValidation.IsInvalidCharacter)
                .WithMessage(GRCToolsMessages.InvalidCharacters);
            //RuleFor(model => model.ResponsibleBusinessUnits).NotEmpty();
            RuleFor(model => model.BusinessUnitsToRunProcess).NotEmpty();
        }
    }
}
