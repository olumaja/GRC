using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class InternalAuditReport : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();        
        [ForeignKey(nameof(CommenceEngagementAuditexecution))]
        public Guid CommenceEngagementAuditexecutionId { get; set; }
        [ForeignKey(nameof(CommenceEngagementAuditexecutionId))]
        public CommenceEngagementAuditexecution CommenceEngagementAuditexecution { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Unit { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Team { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Summary { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Scope { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ScopeLimitation { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ExecutiveSummary { get; set; }
        public List<AuditFindingAuditReport> AuditFinding { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? GoodPractiseInclude { get; set; }
        public List<InternalAuditRatingReport> InternalAuditRating { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AdditionalDescription { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? OverAllManagementComment { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? SignedBy { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DescriptionOfIssue { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? IssueRating { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Observation { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? PotentialMaterialisedImpact { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string RootCause { get; set; } = null;
        [Column(TypeName = "nvarchar(MAX)")]
        public string Impact { get; set; } = null;
        [Column(TypeName = "nvarchar(MAX)")]
        public string Recommendation { get; set; } = null;
        public string? DetailedFinding { get; set; } = null;
        public Guid DocumentAttachId { get; private set; }
        public List<ManagementResponseAuditReport> ManagementResponse { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AssessmentOfDigitalInitiative { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? OtherImprovementArea { get; set; }
        public List<ObservationListAuditReport> ObservationList { get; set; }
        public List<CitationAuditReport>? Citation { get; set; }
        public List<ReportDistributionList>? DistributionList { get; set; }       
        public string? ReasonForRejection { get; set; } = null;
        public List<ReportDetailfindings>? ReportDetailfindings { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReportComment { get; set; } = null;
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;       
        public static InternalAuditReport Create(Guid commenceEngagementAuditexecutionId, string requesterName, InternalAuditReportRequest request)
        {
            return new InternalAuditReport
            {
                CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId,
                RequesterName = requesterName,
                Unit = request.Unit,
                Team = request.Team,
                Summary = request.Summary,
                Scope = request.Scope,
                ScopeLimitation = request.ScopeLimitation,
                SignedBy = request.SignedBy,
                ExecutiveSummary = request.ExecutiveSummary,
                AssessmentOfDigitalInitiative = request.AssessmentOfDigitalInitiative,
                OtherImprovementArea = request.OtherImprovementArea,
                OverAllManagementComment = request.OverAllManagementComment,
                GoodPractiseInclude = request.GoodPractiseInclude,
                AdditionalDescription = request.AdditionalDescription,
                DetailedFinding = request.DetailedFinding,
                Status = BusinessRiskRatingStatus.Completed,
                RootCause = "Work paper",
                Impact = "Work paper",
                Recommendation = "Work paper",
                ReportComment = request.Comment

            };
        }

        public void UpdateInternalAuditReport(Guid id, Guid commenceEngagementAuditexecutionId, string requesterName, UpdateInternalAuditReportRequest request)
        {
            Id = Id;
            CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId;
            RequesterName = requesterName;            
            Summary = request.Summary;
            Scope = request.Scope;
            ScopeLimitation = request.ScopeLimitation;
            SignedBy = request.SignedBy;
            ExecutiveSummary = request.ExecutiveSummary;
            AssessmentOfDigitalInitiative = request.AssessmentOfDigitalInitiative;
            OtherImprovementArea = request.OtherImprovementArea;
            OverAllManagementComment = request.OverAllManagementComment;
            GoodPractiseInclude = request.GoodPractiseInclude;
            AdditionalDescription = request.AdditionalDescription;
            DetailedFinding = request.DetailedFinding;
            Status = BusinessRiskRatingStatus.Completed;           
            ReportComment = request.Comment;            
            Status = BusinessRiskRatingStatus.Completed;            
        }

        public void UpdateDocumentAttachId(Guid documentAttachId)
        {
            DocumentAttachId = documentAttachId;
        }
        public void UpdateRootCauseImpactRecommendation(string rootCause, string impact, string recommendation)
        {
            RootCause = rootCause;
            Impact = impact;
            Recommendation = recommendation;
        }
        public void ApproveReportStatus()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }

        public void RejectReportStatus(string reason)
        {
            ReasonForRejection = reason;
            Status = BusinessRiskRatingStatus.Rejected;
        }

    }

    public class ReportDetailfindings : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }     
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DescriptionOfIssue { get; set; }
        public string? IssueRating { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Observation { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? PotentialMaterialisedImpact { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Recommendation { get; set; }

        public static ReportDetailfindings Create(Guid internalAuditReportId, string? descriptionOfIssue, string? issueRating, string? observation, string? potentialMaterialisedImpact, string? recommendation)
        {
            return new ReportDetailfindings
            {
                InternalAuditReportId = internalAuditReportId,
                DescriptionOfIssue = descriptionOfIssue,
                IssueRating = issueRating,
                Observation = observation,
                PotentialMaterialisedImpact = potentialMaterialisedImpact,
                Recommendation = recommendation
            };
        }
        public void UpdateReportDetailfindings(Guid id, Guid internalAuditReportId, string descriptionOfIssue, string issueRating, string observation, string potentialMaterialisedImpact)
        {
            Id = id;
            InternalAuditReportId = internalAuditReportId;
            DescriptionOfIssue = descriptionOfIssue;
            IssueRating = issueRating;
            Observation = observation;
            PotentialMaterialisedImpact = potentialMaterialisedImpact;
        }
    }

    public class ReportDistributionList : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }
        public string? Designation { get; set; }
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ForAction { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ForDistribution { get; set; }
        public static ReportDistributionList Create(Guid internalAuditReportId, string designation, string name, string forAction, string forDistribution)
        {
            return new ReportDistributionList
            {
                InternalAuditReportId = internalAuditReportId,
                Designation = designation,
                Name = name,
                ForAction = forAction,
                ForDistribution = forDistribution

            };
        }
        public void UpdateReportDistributionList(Guid id, Guid internalAuditReportId, string designation, string name, string forAction, string forDistribution)
        {
            Id = id;
            InternalAuditReportId = internalAuditReportId;
            Designation = designation;
            Name = name;
            ForAction = forAction;
            ForDistribution = forDistribution;
        }
    }


    public class CitationAuditReport : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Placement { get; set; }
        public static CitationAuditReport Create(Guid internalAuditReportId, string description, string placement)
        {
            return new CitationAuditReport
            {
                InternalAuditReportId = internalAuditReportId,
                Description = description,
                Placement = placement
            };
        }
        public void UpdateCitationAuditReport(Guid id, Guid internalAuditReportId, string description, string placement)
        {
            Id = id;
            InternalAuditReportId = internalAuditReportId;
            Description = description;
            Placement = placement;
        }
    }
    public class AssessmentOfDigitalInitiativeList : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Observation { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Recommendation { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ActionOwner { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ManagementResponse { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Destination { get; set; }
        public DateTime DueDate { get; set; }
        public static AssessmentOfDigitalInitiativeList Create(Guid internalAuditReportId, string observation, string recommendation, string managementResponse, string actionOwner, string destination, DateTime dueDate)
        {
            return new AssessmentOfDigitalInitiativeList
            {
                InternalAuditReportId = internalAuditReportId,
                Observation = observation,
                Recommendation = recommendation,
                ManagementResponse = managementResponse,
                ActionOwner = actionOwner,
                Destination = destination,
                DueDate = dueDate
            };
        }

        public void UpdateAssessmentOfDigitalInitiativeList(Guid id, Guid internalAuditReportId, string observation, string recommendation, string managementResponse, string actionOwner, string destination, DateTime dueDate)
        {
            Id = id;
            InternalAuditReportId = internalAuditReportId;
            Observation = observation;
            Recommendation = recommendation;
            ManagementResponse = managementResponse;
            ActionOwner = actionOwner;
            Destination = destination;
            DueDate = dueDate;
        }
    }

    public class ObservationListAuditReport : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Observation { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Recommendation { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ActionOwner { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ManagementResponse { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Destination { get; set; }
        public DateTime DueDate { get; set; }
        public static ObservationListAuditReport Create(Guid internalAuditReportId, string observation, string recommendation, string managementResponse, string actionOwner, string destination, DateTime dueDate)
        {
            return new ObservationListAuditReport
            {
                InternalAuditReportId = internalAuditReportId,
                Observation = observation,
                Recommendation = recommendation,
                ManagementResponse = managementResponse,
                ActionOwner = actionOwner,
                Destination = destination,
                DueDate = dueDate
            };
        }

        public void UpdateObservationListAuditReport(Guid id, Guid internalAuditReportId, string observation, string recommendation, string managementResponse, string actionOwner, string destination, DateTime dueDate)
        {
            Id = id; 
            InternalAuditReportId = internalAuditReportId;
            Observation = observation;
            Recommendation = recommendation;
            ManagementResponse = managementResponse;
            ActionOwner = actionOwner;
            Destination = destination;
            DueDate = dueDate;
        }




    }

    public class ManagementResponseAuditReport : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ActionPointToResolve { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ActionOwner { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Unit { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Designation { get; set; }
        public DateTime DueDate { get; set; }
        public static ManagementResponseAuditReport Create(Guid internalAuditReportId, string? actionPointToResolve, string? actionOwner, string? unit, string? designation, DateTime dueDate)
        {
            return new ManagementResponseAuditReport
            {
                InternalAuditReportId = internalAuditReportId,
                ActionPointToResolve = actionPointToResolve,
                ActionOwner = actionOwner,
                Unit = unit,
                Designation = designation,
                DueDate = dueDate
            };
        }
        public void UpdateManagementResponseAuditReport(Guid id, Guid internalAuditReportId, string? actionPointToResolve, string? actionOwner, string? unit, string? designation, DateTime dueDate)
        {
            Id = id;
            InternalAuditReportId = internalAuditReportId;
            ActionPointToResolve = actionPointToResolve;
            ActionOwner = actionOwner;
            Unit = unit;
            Designation = designation;
            DueDate = dueDate;
        }
    }

    public class InternalAuditRatingReport : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AuditArea { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? CurrentRating { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? PreviousRating { get; set; }
        public static InternalAuditRatingReport Create(Guid internalAuditReportId, string? auditArea, string? currentRating, string? previousRating)
        {
            return new InternalAuditRatingReport
            {
                InternalAuditReportId = internalAuditReportId,
                AuditArea = auditArea,
                CurrentRating = currentRating,
                PreviousRating = previousRating
            };
        }

        public void UpdateInternalAuditRatingReport(Guid id, Guid internalAuditReportId, string? auditArea, string? currentRating, string? previousRating)
        {
            Id = id;
            InternalAuditReportId = internalAuditReportId;
            AuditArea = auditArea;
            CurrentRating = currentRating;
            PreviousRating = previousRating;
        }
    }

    public class AuditFindingAuditReport : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(InternalAuditReport))]
        public Guid InternalAuditReportId { get; set; }
        [ForeignKey(nameof(InternalAuditReportId))]
        public InternalAuditReport InternalAuditReport { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AuditFinding { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? NameOrRecurring { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ControlType { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ControlDesignOrEffectively { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Rating { get; set; }
        public static AuditFindingAuditReport Create(Guid internalAuditReportId, string? auditFinding, string? nameOrRecurring,
            string? controlType, string? controlDesignOrEffectively, string? rating)
        {
            return new AuditFindingAuditReport
            {
                InternalAuditReportId = internalAuditReportId,
                AuditFinding = auditFinding,
                NameOrRecurring = nameOrRecurring,
                ControlType = controlType,
                ControlDesignOrEffectively = controlDesignOrEffectively,
                Rating = rating
            };
        }

        public void UpdateAuditFindingAuditReport(Guid id, Guid internalAuditReportId, string? auditFinding, string? nameOrRecurring,
             string? controlType, string? controlDesignOrEffectively, string? rating)
        {
            Id = id;
            InternalAuditReportId = internalAuditReportId;
            AuditFinding = auditFinding;
            NameOrRecurring = nameOrRecurring;
            ControlType = controlType;
            ControlDesignOrEffectively = controlDesignOrEffectively;
            Rating = rating;
        }

    }
}
