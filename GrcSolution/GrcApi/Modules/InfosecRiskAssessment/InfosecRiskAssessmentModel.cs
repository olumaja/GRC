using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using GrcApi.Modules.Shared.Helpers;
using System.ComponentModel;
using System.Security.AccessControl;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public enum RiskAssessmentStatus
    {
        [Description("PENDING")] Pending = 1,
        [Description("PENDING APPROVAL")] Pending_Approval,
        [Description("APPROVED")] Approved,
        [Description("REJECTED")] Rejected
    }

    public enum ISORating
    {
        [Description("LOW")] Low = 1,
        [Description("MEDIUM")] Medium,
        [Description("HIGH")] High,
        [Description("VERY HIGH")] VeryHigh
    }

    public enum ISOImpactRating
    {
        [Description("INSIGNIFICANT")] Insignificant = 1,
        [Description("MINOR")] Minor,
        [Description("MODERATE")] Moderate,
        [Description("MAJOR")] Major,
        [Description("CRITICAL")] Critical
    }

    public enum ISOThreatOccuring
    {
        [Description("RARE")] Rare = 1,
        [Description("UNLIKELY")] Unlikely,
        [Description("PROBABLE")] Probable,
        [Description("LIKEKY")] Likely,
        [Description("ALMOST CERTAIN")] AlmostCertain
    }

    public enum ISORemediation
    {
        [Description("OPEN")] Open = 1,
        [Description("WORK IN PROGRESS")] Workinprogress,
        [Description("CLOSED")] Closed
    }

    public class InfosecRiskAssessmentModel : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string? Unit { get; private set; }
        public string? Objective { get; private set; }
        public string? Asset { get; private set; }
        public string? AssetDescription { get; private set; }
        public DateTime? RiskAssessmentDate { get; private set; }
        public string? Category { get; private set; }
        public ISORating? ConfidentialityRating { get; private set; }
        public ISORating? IntegrityRating { get; private set; }
        public ISORating? AvailabilityRating { get; private set; }
        public string? AssetValue { get; private set; }
        public ISORating? AssetScore { get; private set; }
        public string? Vulnerability { get; private set; }
        public ISORating? VulnerabilityRating { get; private set; }
        public string? Threat { get; private set; }
        public ISOImpactRating? ImpactRating { get; private set; }
        public ISOThreatOccuring? LikehoodOfthreatOccuring { get; private set; }
        public string? RiskScore { get; private set; }
        public string? RiskValue { get; private set; }
        public string? RiskOption { get; private set; }
        public string? ControlEffective { get; set; }
        public string? ResidualRisk { get; private set; }
        public string? Riskowner { get; private set; }
        public string? ActionOwner { get; private set; }
        public string? ActionOwnerEmail { get; private set; }
        public string? ReasonForRejection { get; private set; }
        public string? ApprovedBy { get; private set; }
        public DateTime? DateApproved { get; private set; }
        public string? AdditionalInformation { get; private set; }
        public DateTime? ProposeClosureDate { get; private set; }
        public ISORemediation? RemediationStatus { get; private set; }
        public RiskAssessmentStatus Status { get; private set; } = RiskAssessmentStatus.Pending;
        public List<PlannedControl> PlannedControls { get; private set; }
        public List<ExistingPrimaryControl> ExistingPrimaryControls { get; private set; }

        public static InfosecRiskAssessmentModel CommenceRisk(InfosecRiskAssessment payload)
        {
            return new InfosecRiskAssessmentModel
            {
                Asset = payload.Asset,
                AssetDescription = payload.AssetDescription,
                RiskAssessmentDate = payload.RiskAssessmentDate,
                Category = payload.Category,
                ConfidentialityRating = payload.ConfidentialityRating,
                IntegrityRating = payload.IntegrityRating,
                AvailabilityRating = payload.AvailabilityRating,
                AssetValue = payload.AssetValue,
                AssetScore = payload.AssetScore,
                Vulnerability = payload.Vulnerability,
                VulnerabilityRating = payload.VulnerabilityRating,
                Threat = payload.Threats,
                ImpactRating = payload.ImpactRating,
                LikehoodOfthreatOccuring = payload.LikelihoodofThreatOccurring,
                RiskScore = payload.RiskScore,
                RiskValue = payload.RiskValue,
                RiskOption = payload.RiskOptions,
                ControlEffective = payload.ControlEffectiveness,
                ResidualRisk = payload.ResidualRisk,
                Riskowner = payload.RiskOwner,
                ActionOwner = payload.ActionOwner,
                ActionOwnerEmail = payload.ActionOwnerEmail,
                AdditionalInformation = payload.AdditionalInformation,
                ProposeClosureDate = payload.ProposedClosureDate,
                RemediationStatus = payload.RemediationStatus,
                Unit = payload.Unit,
            };
        }

        public void UpdateCommenceRisk(InfosecRiskAssessment payload)
        {
            Asset = payload.Asset;
            AssetDescription = payload.AssetDescription;
            RiskAssessmentDate = payload.RiskAssessmentDate;
            Category = payload.Category;
            ConfidentialityRating = payload.ConfidentialityRating;
            IntegrityRating = payload.IntegrityRating;
            AvailabilityRating = payload.AvailabilityRating;
            AssetValue = payload.AssetValue;
            AssetScore = payload.AssetScore;
            Vulnerability = payload.Vulnerability;
            VulnerabilityRating = payload.VulnerabilityRating;
            Threat = payload.Threats;
            ImpactRating = payload.ImpactRating;
            LikehoodOfthreatOccuring = payload.LikelihoodofThreatOccurring;
            RiskScore = payload.RiskScore;
            RiskValue = payload.RiskValue;
            RiskOption = payload.RiskOptions;
            ControlEffective = payload.ControlEffectiveness;
            ResidualRisk = payload.ResidualRisk;
            Riskowner = payload.RiskOwner;
            ActionOwner = payload.ActionOwner;
            ActionOwnerEmail = payload.ActionOwnerEmail;
            AdditionalInformation = payload.AdditionalInformation;
            ProposeClosureDate = payload.ProposedClosureDate;
            RemediationStatus = payload.RemediationStatus;
            Unit = payload.Unit;
        }

        public void UpdateStatus(RiskAssessmentStatus status, string? reasonForRejection = null)
        {
            Status = status;
            ReasonForRejection = reasonForRejection;
        }

        public void SetApprovedBy(string name)
        {
            ApprovedBy = name;
            DateApproved = DateTime.Now;
        }
    }
}
