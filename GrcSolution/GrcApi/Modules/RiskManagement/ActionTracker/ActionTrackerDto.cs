using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain.RiskEvent;
using static Arm.GrcTool.Domain.RiskControlSelfAssessment.ProcessInherentRiskControl;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{

    public class ActionTrackerDtoRiskReport
    {
        public Guid? ActionManagementId { get; set; }
        public DateOnly OccurrenceDate { get; set; }
        public DateOnly DateOfIdentification { get; set; }
        public string? EventDescription { get; set; }
        public string? EventLocation { get; set; }
        public string? EventLocationDepartment { get; set; }
        public string? EventLocationUnit { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? EventIdentifier { get; set; }
        public string? EventType { get; set; }
        public string? EventCategory { get; set; }
        public string? EventSubCategory { get; set; }
        public string? RiskDriver { get; set; }
        public string? RiskDriverCategory { get; set; }
        public string? RiskDriverSubCategory { get; set; }
        public string? RiskDriverDescription { get; set; }
        public string? EffectType { get; set; }
        public string? EffectCategory { get; set; }
        public decimal? LossValue { get; set; }
        public string? RationaleForGrossLosValue { get; set; }
        public string? EffectDescription { get; set; }
        public string? Action { get; set; }
        public string? ActionProgress { get; set; }
        public DateOnly? ActionResolutionDate { get; set; }
        public string? ActionOwner { get; set;}
        public string? ActionStatus { get; set; }
        public decimal? GrossLossValue { get; set; }
        public decimal? RecoveryAmount { get; set; }
        public DateOnly? RecoveryDate { get; set; }
        public string? RecoveryDescription { get; set; }
        public decimal? NetLoss { get; set; }
        public string? AccountImpacted { get; set; }
        public string? Requester { get; set; }
        public string? Approval { get; set; }
        public string Status { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }

    public class GetRiskEventAndRCSAReportTrackers
    {
        public int NumberOfRiskIdentification { get; init; }
        public int NumberOfRiskControlSelfAssessment { get; init; }
        public List<RiskIdentificationList> RiskIdentification { get; init; }
        public List<RiskControlSelfAssessmentList> RiskControlSelfAssessment { get; init; }
    }
    public class GetRiskEventReportTrackers
    {
        public int NumberOfRiskIdentification { get; init; }
        public List<RiskIdentificationList> RiskIdentification { get; init; }
    }
    public class GetRCSAReportTrackers
    {
        public int NumberOfRiskControlSelfAssessment { get; init; }
        public List<RiskControlSelfAssessmentList> RiskControlSelfAssessment { get; init; }
    }
    public class GetRCSAReportByUnitId
    {
        public List<RiskControlSelfAssessmentList> RiskControlSelfAssessment { get; init; }
    }
    public class GetRCSAListReports
    {
        public List<RCSAListReports> RiskControlSelfAssessments { get; init; }
    }
    public class GetPRAListReports
    {
        public List<PRAListReports> ProductRiskAssessment { get; init; }
    }
    public class PRAListReports
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid BusinessId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid UnitId { get; set; }
        public string ProductDescription { get; set; }
        public PRAStatus Status { get; set; }
        public PRAStage Stage { get; set; }
        public string? QuestionOrRecomendation { get; set; }
        public string? ReseasonForRejection { get; set; }
        public string? Requester { get; set; }
        public string? Approval { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }

    public class ActionTrackerRCSAReport
    {
        public string? ActionProgress { get; set; }
        public string? ActionOwner { get; set; }
        public string? BusinessUnit { get; set; }
        public string? Status { get; set; }
        public string? CorrectiveActions { get; set; }
        public DateOnly? TimeLine { get; set; }
        public DateOnly PeriodFrom { get; set; }
        public DateOnly PeriodTo { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string? Processes { get; set; }
        public string? InherentRisk { get; set; }
        public string? Control { get; set; }
        public string? Test { get; set; }
        public string? TestResult { get; set; }
        public string? ControlEffectiveness { get; set; }
        public string? ResidualRisk { get; set; }
        public string? Requester { get; set; }
        public string? Approval { get; set; }
        public int? ResidualRiskRating { get; set; }
        public string? ResidualRiskLevel { get; set; }
        public DateTime DateCreated { get; set; }
    }
   
    public record RCSAListReports(
        DateOnly DateStarted,
        Guid Id,
        int BusinessUnitCount,
        DateOnly PeriodFrom,
        DateOnly PeriodTo,
        DateOnly StartDate,
        DateOnly EndDate,
        string PeriodCovered,
        string BusinessUnit,
        string ActionPlan,
        string ActionOwner,        
        DateOnly DueDate,
        string Status,
        string? CorrectiveActions,
        string? Progress,       
        string? Processes,
        string? InherentRisk,
        string? Control,
        string? Test,
        string? TestResult,
        string? ControlEffectiveness,
        int? ResidualRiskRating,
        string? ResidualRiskLevel

    );

    public record RCSAListReportsResp(

       string CorrectiveActions,
       string ActionOwner,
       DateOnly DueDate,
       string Status,
       string Progress,
       string Processes,
       string InherentRisk,
       string Control,
       string Test,
       string TestResult,
       string ControlEffectiveness,
       int ResidualRiskRating,
       string ResidualRiskLevel









   /*x.CorrectiveActions,
                                      x.ActionOwnerUserName,
                                      x.TimeLine,
                                      x.Status,
                                      x.CorrectiveActions,
                                      x.Progress,
                                      x.PeriodCovered,
                                      x.Processes,
                                      x.InherentRisk,
                                      x.Control,
                                      x.Test,
                                      x.TestResult,
                                      x.ControlEffectiveness,
                                      x.ResidualRiskRating,
                                      x.ResidualRiskLevel
    */

   );

    public class RiskIdentificationList // ongoing
    {
        public Guid ActionManagementId { get; set; }
        public string ActionPlan { get; set; }
        public string ActionOwner { get; set; }
        public string BusinessUnit { get; set; }
        public string ActionProgress { get; set; }
        public DateOnly DueDate { get; set; }
        public string Status { get; init; }
        public string ActionStatus { get; set; }
        public DateOnly OccurrenceDate { get; init; }
        public DateOnly DateOfIdentification { get; init; }
        public string EventDescription { get; init; }
        public string EventLocation { get; init; }
        public string EventLocationDepartment { get; init; }
        public string EventLocationUnit { get; init; }
        public DateTime? LastUpdate { get; init; }
        public DateOnly DateCreated { get; init; }
        public string EventIdentifier { get; init; }
        public Guid EventType { get; init; }
        public string EventCategory { get; init; }
        public string EventSubCategory { get; init; }
        public string RiskSubCategory { get; init; }
        public string RiskDriver { get; init; }
        public string RiskDriverSubCategory { get; init; }
        public EffectType EffectType { get; init; }
        public Guid EffectCategory { get; init; }
        public decimal LossValue { get; init; }
        public string? RationalForGrossLossValue { get; init; }
        public string EffectDescription { get; init; }
        public string Action { get; init; }
        public DateOnly ActionresolutionDate { get; init; }
        public decimal GrossLossValue { get; init; }
        public decimal RecoverdAmount { get; init; }
        public decimal NetLoss { get; init; }
        public DateOnly RecoveryDate { get; init; }
        public DateTime? ApprovalDate { get; init; }
        public string RecoveryDescription { get; init; }
        public string AccountImpacted { get; init; }
        public string? Approval { get; init; }
        public string? Requester { get; init; }

    }

    public class RiskControlSelfAssessmentList
    {
        public Guid ProcessInherentRiskId { get; set; }
        public string ActionPlan { get; set; }
        public string ActionOwner { get; set; }
        public string BusinessUnit { get; set; }
        public DateOnly? DueDate { get; set; }
        public string? Status { get; set; }
        public string? CorrectiveActions { get; set; }
        public string? Progress { get; set; }
        public string? PeriodCovered { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Processes { get; set; }
        public string? InherentRisk { get; set; }
        public string? Control { get; set; }
        public string? Test { get; set; }
        public string? TestResult { get; set; }
        public string? ControlEffectiveness { get; set; }
        public int? ResidualRiskRating { get; set; }
        public string? ResidualRiskLevel { get; set; }
        public string? ResidualRisk { get; set; }
        public string? Requester { get; set; }
        public string? Approval { get; set; }
        public DateTime? ApprovalDate { get; set; }
    }

    public class GetTotalModuleReports
    {
        public int RiskIdentification { get; set; }
        public int RiskControlSelfAssessment { get; set; }
        public int BusinessImpactAnalysis { get; set; }
        public int ProductRiskAssessment { get; set; }
    }

    public class GetTotalModuleRecords
    {
        public int RiskIdentification { get; set; }
        public int RiskControlSelfAssessment { get; set; }
        public int BusinessImpactAnalysis { get; set; }
        public int ProductRiskAssessment { get; set; }
    }
   
    public class RiskIdentificationActionTrackReq
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }

}
