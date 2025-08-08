using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;
using System.Data;
using GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcTool.Domain;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class CommenceEngagementAuditexecution : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditAnnouncementMemoAuditExecution AuditAnnouncementMemoAuditExecution { get; set; }
        public EngagementLetterAuditExecution EngagementLetterAuditExecution { get; set; }
        public List<InformationRequirementAuditExecution> InformationRequirementAuditExecution { get; set; }
        public AuditPlanningMemoAuditExecution AuditPlanningMemoAuditExecution { get; set; }
        public List<AuditProgramAuditExecution> AuditProgramAuditExecution { get; set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; set; } = null;
        public string? Team { get; set; } = null;
        public static CommenceEngagementAuditexecution Create(Guid anualAuditUniverseRiskRatingId, string team)
        {
            return new CommenceEngagementAuditexecution
            {
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                Team = team,
            };

        }

        public void UpdateEngagementPlan()
        {
            EngagementPlan = BusinessRiskRatingStatus.Completed;
        }

        public void ApproveEngagementPlanStatus(string team)
        {
            Team = team;
            Status = BusinessRiskRatingStatus.Approved;
            EngagementPlan = BusinessRiskRatingStatus.Approved;
        }
        public void ApproveWorkPaperStatus(string? team)
        {
            Team = team;
            WorkPaper = BusinessRiskRatingStatus.Approved;
        }

        public void RejectWorkPaperStatus(string? team, string reason)
        {
            Team = team;
            ReasonForRejection = reason;
            WorkPaper = BusinessRiskRatingStatus.Rejected;
        }
        public void ApproveFindingstatusStatus(string? team)
        {
            Team = team;
            Findingstatus = BusinessRiskRatingStatus.Approved;
        }

        public void RejectFindingstatusStatus(string? team, string reason)
        {
            Team = team;
            ReasonForRejection = reason;
            Findingstatus = BusinessRiskRatingStatus.Rejected;
        }
    }

    public class AuditPlanningMemoAuditExecution : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(CommenceEngagementAuditexecution))]
        public Guid CommenceEngagementAuditexecutionId { get; set; }
        [ForeignKey(nameof(CommenceEngagementAuditexecutionId))]
        public CommenceEngagementAuditexecution CommenceEngagementAuditexecution { get; set; }
        public List<AuditPlanningMemoPlanningTimeline> AuditPlanningMemoPlanningTimeline { get; set; }
        public string? Team { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? BusinessDescription { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? StrategicObjective { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ImplementationPlan { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? RiskIdentified { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ScopeAndControlTesting { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? PriorAuditObservation { get; set; }
        public bool? AuditPlanningMemoCompleted { get; set; } = true;
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; set; } = null;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? SystemOverview { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Policies { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? RegulatoryConsideration { get; set; } = null;
        public static AuditPlanningMemoAuditExecution Create(string team, string requesterName, Guid commenceEngagementAuditexecutionId,
            string businessDescription, string strategicObjective, string implementationPlan, string riskIdentified, string scopeAndControlTesting,
            string priorAuditObservation, string systemOverview, string policies, string? regulatoryConsideration)
        {
            return new AuditPlanningMemoAuditExecution
            {
                Team = team,
                RequesterName = requesterName,
                CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId,
                BusinessDescription = businessDescription,
                StrategicObjective = strategicObjective,
                ImplementationPlan = implementationPlan,
                RiskIdentified = riskIdentified,
                ScopeAndControlTesting = scopeAndControlTesting,
                PriorAuditObservation = priorAuditObservation,
                SystemOverview = systemOverview,
                Policies = policies,
                RegulatoryConsideration = regulatoryConsideration
            };
        }

        public void ApproveAuditPlanningMemoStatus()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectAuditPlanningMemoStatus(string reason)
        {
            Status = BusinessRiskRatingStatus.Rejected;
            ReasonForRejection = reason;
        }

        public void UpdateAuditPlanningMemoAuditExecution(Guid id, Guid commenceEngagementAuditexecutionId,string businessDescription, string strategicObjective, string implementationPlan, string riskIdentified, string scopeAndControlTesting,
           string priorAuditObservation, string systemOverview, string policies, string? regulatoryConsideration)
        {
            Id = id;
            CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId;
            BusinessDescription = businessDescription;
            StrategicObjective = strategicObjective;
            ImplementationPlan = implementationPlan;
            RiskIdentified = riskIdentified;
            ScopeAndControlTesting = scopeAndControlTesting;
            PriorAuditObservation = priorAuditObservation;
            SystemOverview = systemOverview;
            Policies = policies;
            RegulatoryConsideration = regulatoryConsideration;
            Status = BusinessRiskRatingStatus.Completed;
        }
    }

    public class AuditPlanningMemoPlanningTimeline : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(AuditPlanningMemoAuditExecution))]
        public Guid AuditPlanningMemoAuditExecutionId { get; set; }
        [ForeignKey(nameof(AuditPlanningMemoAuditExecutionId))]
        public List<AuditPlanningMemoAuditExecution> AuditPlanningMemoAuditExecution { get; set; }
        public string? Tasks { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? Responsibility { get; set; }
        public static AuditPlanningMemoPlanningTimeline Create(string? task, DateTime? plannedDate, DateTime? completedDate, string? responsibility)
        {
            return new AuditPlanningMemoPlanningTimeline
            {
                Tasks = task,
                PlannedDate = plannedDate,
                CompletedDate = completedDate,
                Responsibility = responsibility               
            };
        }

        public void UpdateAuditPlanningMemoPlanningTimeline(Guid id, Guid auditPlanningMemoAuditExecutionId, string? task, DateTime? plannedDate, DateTime? completedDate, string? responsibility)
        {
            Id = id;
            AuditPlanningMemoAuditExecutionId = auditPlanningMemoAuditExecutionId;
            Tasks = task;
            PlannedDate = plannedDate;
            CompletedDate = completedDate;
            Responsibility = responsibility;
        }

    }

    public class AuditProgramAuditExecution : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(CommenceEngagementAuditexecutions))]
        public Guid CommenceEngagementAuditexecutionId { get; set; }
        public List<CommenceEngagementAuditexecution> CommenceEngagementAuditexecutions { get; set; }
        public string? Team { get; set; }
        public string? RequesterName { get; set; }
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? SubProcess { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? RiskDescription { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ControlDescription { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ControlObjective { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReviewProcedure { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? InformationRequired { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public bool? AuditProgramCompleted { get; set; } = true;
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;
        public BusinessRiskRatingStatus WorkpaperStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus FindingStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public string? ReasonForRejection { get; set; } = null;
        public bool IsWorkPaperInitiated { get; set; } = false;
        public bool IsAuditFindingInitiated { get; set; } = false;
        public WorkPaper workPaper { get; set; }
        public static AuditProgramAuditExecution Create(string team,
            string requesterName, Guid commenceEngagementAuditexecutionId, string title, string subProcess,
            string riskDescription, string controlDescription, string controlObjectives, string reviewProcedure,
            string informationRequired, string comment
        )
        {
            return new AuditProgramAuditExecution
            {
                Team = team,
                RequesterName = requesterName,
                CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId,
                Title = title,
                SubProcess = subProcess,
                RiskDescription = riskDescription,
                ControlDescription = controlDescription,
                ControlObjective = controlObjectives,
                ReviewProcedure = reviewProcedure,
                InformationRequired = informationRequired,
                Comment = comment
            };
        }      
        public void ApproveAuditProgramStatus()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectAuditProgramStatus(string reason)
        {
            Status = BusinessRiskRatingStatus.Rejected;
            ReasonForRejection = reason;
        }       
        public void UpdateWorkpaperStatus(string? team)
        {
            Team = team;
            WorkpaperStatus = BusinessRiskRatingStatus.Approved;
        }
        public void UpdateFindingStatus(string? team)
        {
            Team = team;
            FindingStatus = BusinessRiskRatingStatus.Approved;
        }
        public void RejectWorkpaperStatus(string reason)
        {
            WorkpaperStatus = BusinessRiskRatingStatus.Rejected;
            ReasonForRejection = reason;
        }
        public void RejectFindingStatus(string reason)
        {
            FindingStatus = BusinessRiskRatingStatus.Rejected;
            ReasonForRejection = reason;
        }

        public void UpdateAuditProgramAuditExecution(Guid id, Guid commenceEngagementAuditexecutionId, string process, string subProcess, string riskDescription, string controlDescription, string controlObjectives, string reviewProcedure,
           string informationRequired, string comment)
        {
            Id = id;
            CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId;
            Title = process;
            SubProcess = subProcess;
            RiskDescription = riskDescription;
            ControlDescription = controlDescription;
            ControlObjective = controlObjectives;
            ReviewProcedure = reviewProcedure;
            InformationRequired = informationRequired;
            Comment = comment;
            Status = BusinessRiskRatingStatus.Completed;
        }

    }

    public class InformationRequirementAuditExecution : AuditEntity
    {

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(CommenceEngagementAuditexecution))]
        public Guid CommenceEngagementAuditexecutionId { get; set; }
        public CommenceEngagementAuditexecution CommenceEngagementAuditexecution { get; set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;
        public string? Team { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? InformationRequest { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ResponsibleOfficer { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? DateProvided { get; set; } 
        public bool? InformationRequirementCompleted { get; set; } = true;
        public bool? EngagementLetterCompleted { get; set; } = true;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; set; } = null;
        public static InformationRequirementAuditExecution Create(string team, string requesterName, Guid commenceEngagementAuditexecutionId, string informationRequest,
           string responsibleOfficer, DateTime requestDate, DateTime? dateProvided)
        {
            return new InformationRequirementAuditExecution
            {
                Team = team,
                RequesterName = requesterName,
                CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId,
                InformationRequest = informationRequest,
                ResponsibleOfficer = responsibleOfficer,
                RequestDate = requestDate,
                DateProvided = dateProvided
            };
        }

        public void ApproveInformationRequirementStatus()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectInformationRequirementStatus(string reason)
        {
            Status = BusinessRiskRatingStatus.Rejected;
            ReasonForRejection = reason;
        }

        public void UpdateInformationRequirementAuditExecution(Guid id, Guid commenceEngagementAuditexecutionId, string informationRequest, string responsibleOfficer, DateTime requestDate, DateTime? dateProvided)
        {
            Id = id;
            CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId;
            InformationRequest = informationRequest;
            ResponsibleOfficer = responsibleOfficer;
            RequestDate = requestDate;
            DateProvided = dateProvided;
            Status = BusinessRiskRatingStatus.Completed;
        }
    }


    public class EngagementLetterAuditExecution : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(CommenceEngagementAuditexecution))]
        public Guid CommenceEngagementAuditexecutionId { get; set; }
        [ForeignKey(nameof(CommenceEngagementAuditexecutionId))]
        public CommenceEngagementAuditexecution CommenceEngagementAuditexecution { get; set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;
        public string? Team { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AuditTitle { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AuditType { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? BusinessUnit { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? IssueBy { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ResponsibleExecutive { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? BusinessOwner { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? BriefBackgroundObjective { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? KeyRisk { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Mandate { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ResponsibilityOfInternalAudit { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AuditObjective { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AuditScope { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ScopeLimitation { get; set; }
        public List<EngagementLetterAuditExecutionDuration> EngagementLetterAuditExecutionDuration { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? CommunicationProtocol { get; set; }
        public List<EngagementLetterReportDistributionList> EngagementLetterReportDistributionList { get; set; }
        public bool? EngagementLetterCompleted { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; set; } = null;
        public static EngagementLetterAuditExecution Create(string team, string requesterName, Guid commenceEngagementAuditexecutionId, EngagementLetterAuditExecutionReq request)
        {
            return new EngagementLetterAuditExecution
            {
                Team = team,
                RequesterName = requesterName,
                CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId,
                AuditTitle = request.AuditTitle,
                AuditType = request.AuditType,
                ScopeLimitation = request.ScopeLimitation,
                AuditScope = request.AuditScope,
                AuditObjective = request.AuditObjective,
                ResponsibilityOfInternalAudit = request.ResponsibilityOfInternalAudit,
                Comment = request.Comment,
                CommunicationProtocol = request.CommunicationProtocol,
                BriefBackgroundObjective = request.BriefBackgroundObjective,
                BusinessOwner = request.BusinessOwner,
                BusinessUnit = request.BusinessUnit,
                Date = request.Date,
                EngagementLetterCompleted = true,
                KeyRisk = request.KeyRisk,
                ResponsibleExecutive = request.ResponsibleExecutive,
                IssueBy = request.IssueBy
            };
        }

        public void ApproveEngagementLetterStatus()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectEngagementLetterStatus(string reason)
        {
            Status = BusinessRiskRatingStatus.Rejected;
            ReasonForRejection = reason;
        }

        public void UpdateEngagementLetterAuditExecution(Guid id, Guid commenceEngagementAuditexecutionId, UpdateEngagementLetterAuditExecutionReq request)
        {
            Id = id;
            CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId;
            AuditTitle = request.AuditTitle;
            AuditType = request.AuditType;
            ScopeLimitation = request.ScopeLimitation;
            AuditScope = request.AuditScope;
            AuditObjective = request.AuditObjective;
            ResponsibilityOfInternalAudit = request.ResponsibilityOfInternalAudit;
            Comment = request.Comment;
            CommunicationProtocol = request.CommunicationProtocol;
            BriefBackgroundObjective = request.BriefBackgroundObjective;
            BusinessOwner = request.BusinessOwner;
            BusinessUnit = request.BusinessUnit;
            Date = request.Date;
            EngagementLetterCompleted = true;
            KeyRisk = request.KeyRisk;
            ResponsibleExecutive = request.ResponsibleExecutive;
            IssueBy = request.IssueBy;
            Status = BusinessRiskRatingStatus.Completed;
        }

    }
    public class EngagementLetterReportDistributionList : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(EngagementLetterAuditExecution))]
        public Guid EngagementLetterAuditExecutionId { get; set; }
        public EngagementLetterAuditExecution EngagementLetterAuditExecution { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReportDistributionListName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReportDistributionListTitle { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReportDistributionListBusinessUnit { get; set; }
        public static EngagementLetterReportDistributionList Create(Guid engagementLetterAuditExecutionId, string name, string title, string unit)
        {
            return new EngagementLetterReportDistributionList
            {
                EngagementLetterAuditExecutionId = engagementLetterAuditExecutionId,
                ReportDistributionListName = name,
                ReportDistributionListTitle = title,
                ReportDistributionListBusinessUnit = unit
            };
        }

        public void UpdateEngagementLetterReportDistributionList(Guid id, Guid engagementLetterAuditExecutionId, string name, string title, string unit)
        {
            Id = id;
            EngagementLetterAuditExecutionId = engagementLetterAuditExecutionId;
            ReportDistributionListName = name;
            ReportDistributionListTitle = title;
            ReportDistributionListBusinessUnit = unit;
        }

    }
    public class EngagementLetterAuditExecutionDuration : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(EngagementLetterAuditExecution))]
        public Guid EngagementLetterAuditExecutionId { get; set; }
        public EngagementLetterAuditExecution EngagementLetterAuditExecution { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DurationAction { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DurationTiming { get; set; }
        public static EngagementLetterAuditExecutionDuration Create(Guid engagementLetterAuditExecutionId, string action, string timing)
        {
            return new EngagementLetterAuditExecutionDuration
            {
                EngagementLetterAuditExecutionId = engagementLetterAuditExecutionId,
                DurationAction = action,
                DurationTiming = timing
            };
        }

        public void UpdateEngagementLetterAuditExecutionDuration(Guid id, Guid engagementLetterAuditExecutionId, string action, string timing)
        {
            Id = id;
            EngagementLetterAuditExecutionId = engagementLetterAuditExecutionId;
            DurationAction = action;
            DurationTiming = timing;
        }
               

    }

    public class AuditAnnouncementMemoAuditExecution : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(CommenceEngagementAuditexecution))]
        public Guid CommenceEngagementAuditexecutionId { get; set; }
        [ForeignKey(nameof(CommenceEngagementAuditexecutionId))]
        public CommenceEngagementAuditexecution CommenceEngagementAuditexecution { get; set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;
        public string? Team { get; set; }
        public string? RequesterName { get; set; }
        public string? RequesterEmailAddress { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? AuditScoped { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? WorkApproach { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Role { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Salutation { get; set; }
        public string? SalutationName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Unit { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Recommendation { get; set; }
        public bool? IsAuditAnnouncementMemoCompleted { get; set; } = true;
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ReasonForRejection { get; set; } = null;
        public DateTime? CommenceDate { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public DateTime? PreviousFrom { get; set; }
        public DateTime? PreviousTo { get; set; }
        public string? Recipient { get; set; } = null;
        public string? RecipientUnitEmail { get; set; } = null;
        public static AuditAnnouncementMemoAuditExecution Create(string team, string requesterName, Guid commenceEngagementAuditexecutionId, string salutation, string auditScoped, string workApproach, string role, string unit, string recommendation, DateTime? commenceDate, DateTime? periodFrom, DateTime? periodTo, DateTime? previousFrom, DateTime? previousTo, string? recipientUnitEmail, string? recipientEmail, string? salutationName, string? currentUserEmail)
        {
            return new AuditAnnouncementMemoAuditExecution
            {
                Team = team,
                RequesterName = requesterName,
                CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId,
                Salutation = salutation,
                AuditScoped = auditScoped,
                WorkApproach = workApproach,
                Role = role,
                Unit = unit,
                Recommendation = recommendation,
                CommenceDate = commenceDate,
                PeriodFrom = periodFrom,
                PeriodTo = periodTo,
                PreviousFrom = previousFrom,
                PreviousTo = previousTo,
                RecipientUnitEmail = recipientUnitEmail.ToLower(),
                Recipient = recipientEmail,
                SalutationName = salutationName,
                RequesterEmailAddress = currentUserEmail.ToLower()

            };
        }

        public void UpdateAuditAnnouncementMemoAuditExecutionstring(Guid id, Guid commenceEngagementAuditexecutionId, string salutation, string auditScoped, string workApproach, string role, string unit, string recommendation, DateTime? commenceDate, DateTime? periodFrom, DateTime? periodTo, DateTime? previousFrom, DateTime? previousTo)

        {
            Id = id;
            CommenceEngagementAuditexecutionId = commenceEngagementAuditexecutionId;
            Salutation = salutation;
            AuditScoped = auditScoped;
            WorkApproach = workApproach;
            Role = role;
            Unit = unit;
            Recommendation = recommendation;
            CommenceDate = commenceDate;
            PeriodFrom = periodFrom;
            PeriodTo = periodTo;
            PreviousFrom = previousFrom;
            PreviousTo = previousTo;
            Status = BusinessRiskRatingStatus.Completed;
        }

        public void ApproveAuditAnnouncementMemoStatus()
        {
            Status = BusinessRiskRatingStatus.Approved;
        }
        public void RejectAuditAnnouncementMemoStatus(string reason)
        {
            Status = BusinessRiskRatingStatus.Rejected;
            ReasonForRejection = reason;
        }
       
    }
}
