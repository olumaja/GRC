using Arm.GrcApi.Models;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class UpdateISORiskAssessmentEndpoint
    {
        public static async Task<IResult> HandleAsync(
            UpdateInfosecRiskAssessmentDto payload, IRepository<InfosecRiskAssessmentModel> riskRepo, IRepository<PlannedControl> plannedRepo,
            IRepository<ExistingPrimaryControl> existControlRepo, IRepository<Document> docRepo, ICurrentUserService currentUserService
        )
        {
            try
            {
                var riskAssesment = riskRepo.GetContextByConditon(r => r.Id == payload.RiskId)
                                        .Include(r => r.PlannedControls)
                                        .Include(r => r.ExistingPrimaryControls)
                                        .FirstOrDefault();

                if (riskAssesment is null)
                    return TypedResults.NotFound("Record not found");

                if (riskAssesment.Unit.ToLower() != currentUserService.CurrentUserUnitName.ToLower())
                    return TypedResults.Forbid();

                if (riskAssesment.Status == RiskAssessmentStatus.Approved)
                    return TypedResults.BadRequest("This request has been approved, you can no longer update it");

                var ratingTypes = new Dictionary<string, ISORating>
                {
                    {"LOW", ISORating.Low}, {"MEDIUM", ISORating.Medium},
                    {"HIGH", ISORating.High}, {"VERY HIGH", ISORating.VeryHigh},
                };
                var impactRatingTypes = new Dictionary<string, ISOImpactRating>
                {
                    {"INSIGNIFICANT", ISOImpactRating.Insignificant}, {"MINOR", ISOImpactRating.Minor},
                    {"MODERATE", ISOImpactRating.Moderate}, {"MAJOR", ISOImpactRating.Major},
                    {"CRITICAL", ISOImpactRating.Critical }
                };
                var threatOccurTypes = new Dictionary<string, ISOThreatOccuring>
                {
                    {"RARE", ISOThreatOccuring.Rare }, {"UNLIKELY", ISOThreatOccuring.Unlikely},
                    {"PROBABLE", ISOThreatOccuring.Probable }, {"LIKEKY", ISOThreatOccuring.Likely},
                    {"ALMOST CERTAIN", ISOThreatOccuring.AlmostCertain }
                };
                var remediationTypes = new Dictionary<string, ISORemediation>
                {
                    {"WORK IN PROGRESS", ISORemediation.Workinprogress }, {"CLOSED", ISORemediation.Closed},
                    {"OPEN", ISORemediation.Open }
                };
                var confidenceRating = payload.ConfidentialityRating.ToUpper();
                var integrityRating = payload.IntegrityRating.ToUpper();
                var availablityRating = payload.AvailabilityRating.ToUpper();
                var assetScore = payload.AssetScore.ToUpper();
                var vulnerabilityRating = payload.VulnerabilityRating.ToUpper();
                var impactRating = payload.ImpactRating.ToUpper();
                var threatOccur = payload.LikelihoodofThreatOccurring.ToUpper();
                var remediationStatus = payload.RemediationStatus.ToUpper();

                if (!IsValidKey(confidenceRating, ratingTypes))
                    return TypedResults.BadRequest($"Confidentiality rating allowed are {string.Join(", ", ratingTypes.Keys)}");

                if (!IsValidKey(integrityRating, ratingTypes))
                    return TypedResults.BadRequest($"Integrity rating allowed are {string.Join(", ", ratingTypes.Keys)}");

                if (!IsValidKey(availablityRating, ratingTypes))
                    return TypedResults.BadRequest($"Availablity rating allowed are {string.Join(", ", ratingTypes.Keys)}");

                if (!IsValidKey(assetScore, ratingTypes))
                    return TypedResults.BadRequest($"Asset score allowed are {string.Join(", ", ratingTypes.Keys)}");

                if (!IsValidKey(vulnerabilityRating, ratingTypes))
                    return TypedResults.BadRequest($"Vulnerability rating allowed are {string.Join(", ", ratingTypes.Keys)}");

                if (!IsValidKey(impactRating, impactRatingTypes))
                    return TypedResults.BadRequest($"Impact rating allowed are {string.Join(", ", impactRatingTypes.Keys)}");

                if (!IsValidKey(threatOccur, threatOccurTypes))
                    return TypedResults.BadRequest($"Likelihood of threat occurring allowed are {string.Join(", ", threatOccurTypes.Keys)}");

                if (!IsValidKey(remediationStatus, remediationTypes))
                    return TypedResults.BadRequest($"Remediation status allowed are {string.Join(", ", remediationTypes.Keys)}");

                riskAssesment.UpdateCommenceRisk(new InfosecRiskAssessment(
                    Asset: payload.Asset, AssetDescription: payload.AssetDescription,
                    RiskAssessmentDate: payload.RiskAssessmentDate, Category: payload.Category,
                    ConfidentialityRating: ratingTypes[confidenceRating], IntegrityRating: ratingTypes[integrityRating],
                    AvailabilityRating: ratingTypes[availablityRating], AssetValue: payload.AssetValue, AssetScore: ratingTypes[assetScore],
                    Vulnerability: payload.Vulnerability, VulnerabilityRating: ratingTypes[vulnerabilityRating], Threats: payload.Threats,
                    ImpactRating: impactRatingTypes[impactRating], LikelihoodofThreatOccurring: threatOccurTypes[threatOccur],
                    RiskScore: payload.RiskScore, RiskValue: payload.RiskValue, RiskOptions: payload.RiskOptions,
                    ControlEffectiveness: payload.ControlEffectiveness,
                    ResidualRisk: payload.ResidualRisk, RiskOwner: payload.RiskOwner, ActionOwner: string.Join(',', payload.ActionOwners.Select(n => n.Name)),
                    ActionOwnerEmail: string.Join(',', payload.ActionOwners.Select(n => n.Email)), AdditionalInformation: payload.AdditionalInformation,
                    ProposedClosureDate: payload.ProposedClosureDate, RemediationStatus: remediationTypes[remediationStatus], Unit: riskAssesment.Unit
                ));
                riskAssesment.UpdateStatus(RiskAssessmentStatus.Pending_Approval);
                riskAssesment.SetModifiedBy(currentUserService.CurrentUserFullName);
                riskAssesment.SetModifiedOnUtc(DateTime.Now);

                //Remove previous planned control if exist
                plannedRepo.BulkDelete(p => p.InfosecRiskAssessmentId == riskAssesment.Id);
                //Update Planned Control
                var plans = payload.PlannedControls.Select(p => PlannedControl.Create(riskAssesment.Id, p.PlannedControl));
                plannedRepo.AddRange(plans);

                //Remove previous Exist primary control if exist
                existControlRepo.BulkDelete(e => e.InfosecRiskAssessmentId == riskAssesment.Id);
                // Update Existing Primary Controls
                var existingControls = payload.ExistingPrimaryControls.Select(e => ExistingPrimaryControl.Create(riskAssesment.Id, e.ExistingPrimaryControl));
                existControlRepo.AddRange(existingControls);

                //Remove previous attachment if exist
                docRepo.BulkDelete(x => x.ModuleItemId == payload.RiskId && x.ModuleItemType == ModuleType.InfoSecISORiskChampionAssessment);
                // Add attachment if available
                if (payload.Attachment != null)
                {
                    var attachment = DocumentExtensions.ConvertFormFileToDocument(payload.Attachment, ModuleType.InfoSecISORiskChampionAssessment, payload.RiskId);
                    docRepo.Add(attachment);
                }

                existControlRepo.SaveChanges();

                return TypedResults.Ok("Risk assessment update successful");
            }
            catch (Exception ex) {
                return TypedResults.Problem("Service not available, try agin later");
            }
            
        }

        private static bool IsValidKey<T>(string key, Dictionary<string, T> data)
        {
            return data.ContainsKey(key) ? true : false;
        }
    }
}
