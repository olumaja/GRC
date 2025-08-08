using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Crypto;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ConsolidatedAuditFinding : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReviewType { get; set; }
        public DateTime? DateFindingRaised { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Business { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Level1 { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Level2 { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReportingQuater { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? WorkStream { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AuditArea { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ImpactRating { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Recommendation { get; set; }
        public DateTime? RevisedDueDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public DateTime? ActionDueDate { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Evidence { get; set; } = null;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DetailedFindings { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? UpdatedComment { get; set; } = null;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ManagmentResponseAsAtTimeOfEngagement { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DescriptionOfFinding { get; set; }
        public List<ConsolidatedAuditFindingActionDetail> ActionDetail { get; set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus StatusLevel { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus OPRStatus { get; set; } = BusinessRiskRatingStatus.Not_Yet_Due;
        public string? EngagementName { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; } = null;
        public string? Entity { get; set; } = null;
        public static ConsolidatedAuditFinding Create(Guid internalAuditReportId, string requesterName, string? reviewType, DateTime? dateFindingRaised, string? detailedFindings,
            string? auditArea, string business, string? level1, string? level2, DateTime? revisedDueDate, string? recommendation,
            string? impactRating, string? workStream, string? reportingQuater, DateTime? actionDueDate, string? updatedComment,
            string? managmentResponseAsAtTimeOfEngagement, string? descriptionOfIssue, string? actionOwner, string? engagementName, string? unit, string? entity,
            BusinessRiskRatingStatus oPRStatus, BusinessRiskRatingStatus statusLevel
            )
        {
            return new ConsolidatedAuditFinding
            {
                InternalAuditReportId = internalAuditReportId,
                RequesterName = requesterName,
                ReviewType = reviewType,
                DateFindingRaised = dateFindingRaised,
                DetailedFindings = detailedFindings,
                AuditArea = auditArea,
                Business = business,
                Level1 = level1,
                Level2 = level2,
                RevisedDueDate = revisedDueDate,
                Recommendation = recommendation,
                ImpactRating = impactRating,
                WorkStream = workStream,
                ReportingQuater = reportingQuater,
                ActionDueDate = actionDueDate,
                UpdatedComment = updatedComment,
                ManagmentResponseAsAtTimeOfEngagement = managmentResponseAsAtTimeOfEngagement,
                DescriptionOfFinding = descriptionOfIssue,
                ActionOwner = actionOwner,
                EngagementName = engagementName,
                Unit = unit,
                Entity = entity,
                OPRStatus = oPRStatus,
                StatusLevel = statusLevel
            };
        }

        public void UpdateConsolidatedAuditFinding(Guid id, Guid internalAuditReportId, string? reviewType, DateTime? dateFindingRaised, string? detailedFindings,
           string? auditArea, string business, string? level1, string? level2, DateTime? revisedDueDate, string? recommendation,
           string? impactRating, string? workStream, string? reportingQuater, DateTime? actionDueDate, string? updatedComment,
           string? managmentResponseAsAtTimeOfEngagement, string? descriptionOfIssue, string? actionOwner, string? engagementName, string? unit, string? entity, DateTime? resolutionDate

           )
        {
            Id = id;
            InternalAuditReportId = internalAuditReportId;
            ReviewType = reviewType;
            DateFindingRaised = dateFindingRaised;
            DetailedFindings = detailedFindings;
            AuditArea = auditArea;
            Business = business;
            Level1 = level1;
            Level2 = level2;
            RevisedDueDate = revisedDueDate;
            Recommendation = recommendation;
            ImpactRating = impactRating;
            WorkStream = workStream;
            ReportingQuater = reportingQuater;
            ActionDueDate = actionDueDate;
            UpdatedComment = updatedComment;
            ManagmentResponseAsAtTimeOfEngagement = managmentResponseAsAtTimeOfEngagement;
            DescriptionOfFinding = descriptionOfIssue;
            ActionOwner = actionOwner;
            EngagementName = engagementName;
            Unit = unit;
            Entity = entity;
            Status = BusinessRiskRatingStatus.Pending;
            ResolutionDate = resolutionDate;
        }

        public static ConsolidatedAuditFinding ExcelUploadCreate(Guid internalAuditReportId, string requesterName, ConsolidatedAuditFindingUploadReq request) //  ConsolidatedAuditFindingRequest
        {
            return new ConsolidatedAuditFinding
            {
                InternalAuditReportId = internalAuditReportId,
                RequesterName = requesterName,
                ReviewType = request.ReviewType,
                DateFindingRaised = DateTime.Parse(request.DateFindingRaised),
                DetailedFindings = request.DetailedFindings,
                AuditArea = request.AuditArea,
                Business = request.Business,
                Level1 = request.Level1,
                Level2 = request.Level2,
                RevisedDueDate = DateTime.Parse(request.RevisedDueDate),
                EngagementName = request.EngagementName,
                Recommendation = request.Recommendation,
                ImpactRating = request.ImpactRating,
                WorkStream = request.WorkStream,
                ReportingQuater = request.ReportingQuater,
                ActionDueDate = DateTime.Parse(request.ActionDueDate),
                UpdatedComment = request.UpdatedComment,
                ManagmentResponseAsAtTimeOfEngagement = request.ManagmentResponseAsAtTimeOfEngagement,
                DescriptionOfFinding = request.DescriptionOfFinding,
                ResolutionDate = DateTime.Parse(request.ResolutionDate),
                ActionOwner = request.ActionOwner,
                Unit = request.Unit,
                Entity = request.Entity,
                Status = BusinessRiskRatingStatus.Pending,
                StatusLevel = BusinessRiskRatingStatus.Pending,
                OPRStatus = BusinessRiskRatingStatus.Not_Yet_Due
            };
        }

        public void UpdateRevisedDueDate(DateTime revisedDueDate)
        {
            RevisedDueDate = revisedDueDate;
        }
        public void UpdateOPRStatus(BusinessRiskRatingStatus oPRStatus, BusinessRiskRatingStatus statusLevel)
        {
            OPRStatus = oPRStatus;
            StatusLevel = statusLevel;
        }
        public void UpdateStatus()
        {
            Status = BusinessRiskRatingStatus.Resolved;
            StatusLevel = BusinessRiskRatingStatus.Implemented;
            OPRStatus = BusinessRiskRatingStatus.Implemented;
            ResolutionDate = DateTime.Now;
        }

    }

    public class ConsolidatedAuditFindingActionDetail : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ConsolidatedAuditFinding))]
        public Guid ConsolidatedAuditFindingId { get; set; }
        [ForeignKey(nameof(ConsolidatedAuditFindingId))]
        public ConsolidatedAuditFinding ConsolidatedAuditFinding { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Recommendation { get; set; } = null;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ActionOwner { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Unit { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? EntityToAction { get; set; }
        public DateTime ActionDueDate { get; set; }

        public static ConsolidatedAuditFindingActionDetail Create(Guid consolidatedAuditFindingId, string recommendation, string actionOwner, string unit, string entityToAction, DateTime actionDueDate)
        {
            return new ConsolidatedAuditFindingActionDetail
            {
                ConsolidatedAuditFindingId = consolidatedAuditFindingId,
                Recommendation = recommendation,
                ActionOwner = actionOwner,
                Unit = unit,
                EntityToAction = entityToAction,
                ActionDueDate = actionDueDate
            };
        }
        public void UpdateConsolidatedAuditFindingActionDetail (Guid id, Guid consolidatedAuditFindingId, string recommendation, string actionOwner, string unit, string entityToAction, DateTime actionDueDate)
        {
            Id = id;
            ConsolidatedAuditFindingId = consolidatedAuditFindingId;
            Recommendation = recommendation;
            ActionOwner = actionOwner;
            Unit = unit;
            EntityToAction = entityToAction;
            ActionDueDate = actionDueDate;
        }

    }


}
