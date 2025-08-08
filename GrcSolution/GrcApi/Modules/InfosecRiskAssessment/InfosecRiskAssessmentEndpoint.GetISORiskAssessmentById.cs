using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Extensions;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class GetISORiskAssessmentByIdEndpoint
    {
        public static async Task<IResult> HandleAsync(
            Guid RiskId, IRepository<InfosecRiskAssessmentModel> riskRepo, IRepository<Document> docRepo, ICurrentUserService currentUserService
        )
        {
            var risk = riskRepo.GetContextByConditon(r => r.Id == RiskId)
                                    .Include(r => r.ExistingPrimaryControls)
                                    .ThenInclude(e => e.ExistingPrimaryControlAnnextures)
                                    .ThenInclude(ep => ep.Annexture)
                                    .Include(r => r.PlannedControls)
                                    .ThenInclude(p => p.PlannedControlAnnextures)
                                    .ThenInclude(pa => pa.Annexture)
                                    .FirstOrDefault();

            if (risk is null)
                return TypedResults.NotFound("Record not found");

            if (!currentUserService.CurrentUserRoles.Contains(GRCUserRole.InfoSecOfficer) && risk.Unit != currentUserService.CurrentUserUnitName)
                return TypedResults.Forbid();
            
            var attachement = docRepo.GetContextByConditon(d => d.ModuleItemId == risk.Id && d.ModuleItemType == ModuleType.InfoSecISORiskChampionAssessment)
                                    .FirstOrDefault();

            var actionOwnerName = risk.ActionOwner.Split(",").ToList();
            var actionOwnerEmail = risk.ActionOwnerEmail.Split(",").ToList();
            var actionOwnerDetails = new List<ActionOwnerDetails>();

            for(var i = 0; i < actionOwnerEmail.Count; i++)
            {
                actionOwnerDetails.Add(new ActionOwnerDetails(Name: actionOwnerName[i], Email: actionOwnerEmail[i]));
            }

            var response = new InfosecRiskAssessmentByIdResponse(
                RiskId: risk.Id, Asset: risk.Asset, AssetDescription: risk.AssetDescription,
                RiskAssessmentDate: risk.RiskAssessmentDate, Category: risk.Category, ConfidentialityRating: risk.ConfidentialityRating.GetEnumDestription(),
                IntegrityRating: risk.IntegrityRating.GetEnumDestription(), AvailabilityRating: risk.AvailabilityRating.GetEnumDestription(), AssetValue: risk.AssetValue,
                AssetScore: risk.AssetScore.GetEnumDestription(), Vulnerability: risk.Vulnerability, VulnerabilityRating: risk.VulnerabilityRating.GetEnumDestription(),
                Threats: risk.Threat, ImpactRating: risk.ImpactRating.GetEnumDestription(), LikelihoodofThreatOccurring: risk.LikehoodOfthreatOccuring.GetEnumDestription(),
                RiskScore: risk.RiskScore, RiskValue: risk.RiskValue, RiskOptions: risk.RiskOption, Status: risk.Status.GetEnumDestription(),
                ControlEffectiveness: risk.ControlEffective, ResidualRisk: risk.ResidualRisk, RiskOwner: risk.Riskowner,
                ActionOwners: actionOwnerDetails, AdditionalInformation: risk.AdditionalInformation, ProposedClosureDate: risk.ProposeClosureDate,
                RemediationStatus: risk.RemediationStatus.GetEnumDestription(), 
                PlannedControls: risk.PlannedControls
                .Select(p => new PlannedControlResponse(PlannedControlId: p.Id, PlannedControlName: p.Name, Anextures: p.PlannedControlAnnextures
                .Select(a => new AnextureDto(AnextureId: a.Annexture.Id, AnextureName: a.Annexture.Name)).ToList()
                )).ToList(), ExistingPrimaryControls: risk.ExistingPrimaryControls
                .Select(e => new ExistingPrimaryControlResponse(ExistingPrimaryControlId: e.Id, ExistingPrimaryControlName: e.Name, e.ExistingPrimaryControlAnnextures
                .Select(a => new AnextureDto(AnextureId: a.Annexture.Id, a.Annexture.Name)).ToList()
                )).ToList(), Attachment: new DocumentResponse(DocumentId: attachement?.Id, DocumentName: attachement?.Name)
            );
            return TypedResults.Ok(response);
        }
    }
}
