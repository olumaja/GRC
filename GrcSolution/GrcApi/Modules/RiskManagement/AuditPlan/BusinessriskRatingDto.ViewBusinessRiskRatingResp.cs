using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class GetInternalAuditReport
    {
        public Guid AuditReportId { get; set; } 
        public string? RequesterName { get; set; }
        public string? Unit { get; set; }
        public string? Team { get; set; }
        public string? Summary { get; set; }
        public string? Scope { get; set; }
        public string? ScopeLimitation { get; set; }
        public string? ExecutiveSummary { get; set; }
        public GetAuditFindingAuditReport AuditFinding { get; set; }
        public string? GoodPractiseInclude { get; set; }
        public GetInternalAuditRatingReport InternalAuditRating { get; set; }
        public string? AdditionalDescription { get; set; }
        public string? OverAllManagementComment { get; set; }
        public string? SignedBy { get; set; }
        public string? DescriptionOfIssue { get; set; }
        public string? IssueRating { get; set; }
        public string? Observation { get; set; }
        public string? PotentialMaterialisedImpact { get; set; }
        public string RootCause { get; set; } 
        public string Impact { get; set; } 
        public string Recommendation { get; set; } 
        public GetManagementResponseAuditReport ManagementResponse { get; set; }
        public string? AssessmentOfDigitalInitiative { get; set; }
        public string? OtherImprovementArea { get; set; }
        public GetObservationListAuditReport ObservationList { get; set; }
        public GetCitationAuditReport Citation { get; set; }
        public string Status { get; set; }
    }
    public class GetCitationAuditReport
    {
        public string? Description { get; set; }
        public string? Placement { get; set; }
    }

    public class GetObservationListAuditReport 
    {       
        public string? Observation { get; set; }
        public string? Recommendation { get; set; }
        public string? ActionOwner { get; set; }
        public string? ManagementResponse { get; set; }
        public string? Destination { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class GetManagementResponseAuditReport 
    {
        public string? ActionPointToResolve { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; }
        public string? Designation { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class GetInternalAuditRatingReport 
    {        
        public string? AuditArea { get; set; }
        public string? CurrentRating { get; set; }
        public string? PreviousRating { get; set; }
    }

    public class GetAuditFindingAuditReport 
    {     
        public string? AuditFinding { get; set; }
        public string? NameOrRecurring { get; set; }
        public string? ControlType { get; set; }
        public string? ControlDesignOrEffectively { get; set; }
        public string? Rating { get; set; }
    }




    public class ViewBusinessRiskRatingResp
    {
        public Guid Id { get; set; }
        public string RequesterName { get; set; }
        public Guid EMCId { get; set; }
        public Guid MgtConcernId { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ReasonForRejection { get; set; }
        public Business Business { get; set; }
    }

    public class ViewEMCRatingResp
    {
        public Guid EMCId { get; set; }       
        public Guid BusinessRiskRatingId { get; set; }      
        public string? RequesterName { get; set; }
        public string? Comment { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class TeamAvailableForCAFResp
    {
        public Guid AuditReportId { get; set; }
        public string? ReviewType { get; set; }
        public DateTime DateFindingRaised { get; set; }
        public string? Business { get; set; }
        public string? Level2 { get; set; }
        public string? ReportingQuater { get; set; }
        public string? WorkStream { get; set; }
        public string? AuditArea { get; set; }       
        public string? EngagementName { get; set; }
        public DateTime? RevisedDueDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public List<ReportDetailfindingListResp> Findings { get; set; }
        public List<ManagementResponseAuditDetail> ActionDetail { get; set; }       
        public List<ObservationListAuditResp> Observation { get; set; }
        public List<AuditFindingAuditResp> Level1 { get; set; }
        public string? UpdatedComment { get; set; }
    }

    public class ViewTeamAvailableForCAFResp
    {
        public ViewTeamAvailableForCAF TeamDetail { get; set; }
    }
    public class ViewTeamAvailableForCAF
    {
        public Guid InternalAuditReportId { get; set; }
        public int Year { get; set; }
        public string? Business { get; set; }
        public string? Team { get; set; }
        public string? AuditArea { get; set; }
        public string? Status { get; set; }
        public DateTime DateFindingRaised { get; set; }
        public string? Level1 { get; set; }
        public List<GetReportDetailfindingList> DetailedFindings { get; set; }
        public List<CAFDetailFindingList> Recommendations { get; set; }
        public List<GetRecommendation> Observation { get; set; }
        public string? ActionOwner { get; set; }
        public string? Unit { get; set; }
        public DateTime ActionDueDate { get; set; }
        public List<GetManagemetRespList> ManagementResponseAsAtTimeOfReport { get; set; }
    }
    public class ViewCAFBusinessRiskRatingResp
    {
        public Guid BusinessRiskRatingId { get; set; }
        public string RequesterName { get; set; }
        public DateTime DateCreated { get; set; }
        public BusinessCAF Business { get; set; }
    }

    public class BusinessCAF
    {
        public CAFBusinessDetail ARMIM { get; set; }
        public CAFBusinessDetail ARMHoldingCompany { get; set; }
        public CAFBusinessDetail ARMTAM { get; set; }
        public CAFBusinessDetail ARMSecurity { get; set; }
        public CAFBusinessDetail ARMTrustee { get; set; }
        public CAFBusinessDetail ARMHill { get; set; }
        public CAFBusinessDetail ARMAgribusiness { get; set; }
        public CAFBusinessDetail DigitalFinancialService { get; set; }
        public CAFBusinessDetail ARMSharedService { get; set; }
        public CAFBusinessDetail ARMCapital { get; set; }
    }
    public class CAFBusinessDetail
    {
        public Guid BusinessRiskRatingId { get; set; }
        public string BusinessName { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class ViewAuditUniverseSummaryResp
    {
        public Guid AnualAuditUniverseId { get; set; }
        public Guid BusinessristRatingId { get; set; }
        public string RequesterName { get; set; }
        public DateTime DateCreated { get; set; }
        public AuditUniverse AuditUniverse { get; set; }
    }
    public class AuditUniverse
    {
        public AuditUniverseDetail ARMIM { get; set; }
        public AuditUniverseDetail ARMHoldingCompany { get; set; }
        public AuditUniverseDetail DigitalFinancialService { get; set; }
        public AuditUniverseDetail ARMCapital { get; set; }
        public AuditUniverseDetail ARMSecurity { get; set; }
        public AuditUniverseDetail ARMTrustee { get; set; }
        public AuditUniverseDetail ARMHill { get; set; }
        public AuditUniverseDetail ARMAgribusiness { get; set; }
        public AuditUniverseDetail ARMSharedService { get; set; }
    }
    public class AuditUniverseDetail
    {
        public Guid AnualAuditUniverseId { get; set; }
        public Guid BusinessristRatingId { get; set; }

        public string BusinessName { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class Business
    {
        public BusinessDetail ARMIM { get; set; }
        public BusinessDetail ARMHoldingCompany { get; set; }
        public BusinessDetail ARMTAM { get; set; }
        public BusinessDetail ARMSecurity { get; set; }
        public BusinessDetail ARMTrustee { get; set; }
        public BusinessDetail ARMHill { get; set; }
        public BusinessDetail ARMAgribusiness { get; set; }
        public BusinessDetail DigitalFinancialService { get; set; }
        public BusinessDetail ARMCapital { get; set; }
        public BusinessDetail ARMSharedService { get; set; }
    }
    public class BusinessDetail
    {
        public Guid Id { get; set; }
        public Guid EMCId { get; set; }
        public Guid MgtConcernId { get; set; }
        public string BusinessName { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class BusinessRatingAwaitingManagementConcernRatingResp
    {
        public Guid Id { get; set; }

        public string RequesterName { get; set; }
        public DateTime DateCreated { get; set; }
        public BusinessRatingAwaitingManagementRatingResp Business { get; set; }
    }

    public class BusinessRatingAwaitingManagementRatingResp
    {
        public BusinessRatingAwaitingManagementRating ARMHoldingCompany { get; set; }
        public BusinessRatingAwaitingManagementRating ARMTAM { get; set; }
        public BusinessRatingAwaitingManagementRating ARMIM { get; set; }
        public BusinessRatingAwaitingManagementRating ARMSecurity { get; set; }
        public BusinessRatingAwaitingManagementRating ARMTrustee { get; set; }
        public BusinessRatingAwaitingManagementRating ARMHill { get; set; }
        public BusinessRatingAwaitingManagementRating ARMAgribusiness { get; set; }
        public BusinessRatingAwaitingManagementRating DigitalFinancialService { get; set; }
        public BusinessRatingAwaitingManagementRating ARMCapital { get; set; }
        public BusinessRatingAwaitingManagementRating ARMSharedService { get; set; }
    }
    public class BusinessRatingAwaitingManagementRating
    {
        public Guid Id { get; set; }

        public string RequesterName { get; set; }

        public string BusinessName { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class ViewCommenceEngagementSummaryResp
    {
        public Guid CommenceEngagementId { get; set; }
        //public string RequesterName { get; set; }
        public DateTime DateCreated { get; set; }
        public ViewCommenceEngagement CommenceEngagement { get; set; }
    }
    public class ViewCommenceEngagement
    {
        public ViewCommenceEngagementDetail AuditAnnouncementMemo { get; set; }
        public ViewCommenceEngagementDetail EngagementLetter { get; set; }
        public ViewCommenceEngagementDetail InformationRequirement { get; set; }
        public ViewCommenceEngagementDetail AuditPlanningMemo { get; set; }
        public ViewCommenceEngagementDetail AuditProgram { get; set; }
    }
    public class ViewCommenceEngagementDetail
    {
        public Guid CommenceEngagementId { get; set; }


        public string Month { get; set; }

        public string RequesterName { get; set; }

        public string? Team { get; set; }

        public string? Recommendation { get; set; }
        public string Status { get; set; }
        //public BusinessRiskRatingStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public string EngagementPlan { get; set; }
        public string WorkPaper { get; set; }
        public string Findingstatus { get; set; }
    }

    public class ViewInternalAuditReportResp
    {
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public int Units { get; set; }
        public int TotalTeam { get; set; }
        public int AvailableReports { get; set; }
        public Guid AnnualAuditUniverseId { get; set; }       
        public Guid CommenceEngagementId { get; set; }
        public List<GetAuditReportTeam> AuditReportTeam { get; set; }
        public BusinessUnit Unit { get; set; }
    }
    public class GetAuditReportTeam
    {
        public Guid? AuditReportId { get; set; }
        public string? BusinesUnit { get; set; }
        public string? Team { get; set; }
      
    }

    public class BusinessUnit
    {
        //public UnitDetails ARMHoldingCompany { get; set; }
        public UnitDetails ARMTAM { get; set; }
        public UnitDetails ARMIM { get; set; }
        public UnitDetails ARMSecurity { get; set; }
        public UnitDetails ARMTrustee { get; set; }
        public UnitDetails ARMHill { get; set; }
        public UnitDetails ARMAgribusiness { get; set; }
        public UnitDetails DigitalFinancialService { get; set; }
        public UnitDetails ARMCapital { get; set; }
        public UnitDetails ARMShareService { get; set; }
    }
    public class UnitDetails
    {

        public string Unit { get; set; }        
        public int TotalTeam { get; set; }
        public int AvailableReports { get; set; }
        public string Team { get; set; }
    }


    public class ViewResolvedFindingResp
    {
        public int Count { get; set; }
        public List<FindingDetail> FindingDetail { get; set; }
    }
    
    public class ViewCompliancePlanningReportResp
    {
        public int Count { get; set; }
        public List<CompliancePlanningReport> CompliancePlanning { get; set; }
    }
    
    public class ViewComplianceRegulatoryPaymentReportResp
    {
        public int Count { get; set; }
        public List<ComplianceRegulatoryPaymentReport> ComplianceRegulatoryPayment { get; set; }
    }
    public class ViewComplianceStatutoryPaymentReportReportResp
    {
        public int Count { get; set; }
        public List<ComplianceStatutoryPaymentReport> ComplianceStatutoryPayment { get; set; }
    }
    
    public class FindingDetail
    {
        public Guid ConsolidatedAuditFindingId { get; set; }
        public string RequesterName { get; set; }
        public string ReviewType { get; set; }
        public string DetailFinding { get; set; }
        public string ReportingQuarter { get; set; }
        public string Business { get; set; }
        public string DescriptionOfFinding { get; set; }
        public string? Recommendation { get; set; }
        public DateTime? RevisedDuedate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string Status { get; set; }  
        public string StatusLevel { get; set; }
        public string OPRStatus { get; set; }
    }
    public class CompliancePlanningReport 
    {
        public Guid CompliancePlanningId { get; set; }
        public string Frequency { get; set; }
        public string? ReportName { get; set; }
        public string? BusinessUnit { get; set; }
        public string? ReasonForRejection { get; set; }
        public int? AttachmentCount { get; set; }
        public DateTime DeadLine { get; set; }
        public string ResponseStatus { get; set; }
        public string ReportStatus { get; set; }
        public string ComplianceLevelStatus { get; set; }
        public string? ProcessOfficer { get; set; }
        public string? ApprovalName { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class ComplianceRegulatoryPaymentReport
    {
        public Guid ComplianceRegulatoryPaymentId { get; set; }
        public string? Regulator { get; set; }
        public string? BusinessEntity { get; set; }
        public string? MeansOfPaymentAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; } = 0;
        public string? ProcessOfficer { get; set; }
        public string? ContactPerson { get; set; } 
        public string? PaymentDetail { get; set; }
        public string? TransactionReference { get; set; } 
        public string? ReasonForRejection { get; set; } 
        public int? PaymentAttachmentCount { get; set; } 
        public DateTime? DateOfPayment { get; set; }
        public DateTime? DeadLine { get; set; }
        public DateTime DateCreated { get; set; } 
        public string Status { get; set; } 
        public string ComplianceLevel { get; set; } 
    }

    public class ComplianceStatutoryPaymentReport
    {
        public Guid ComplianceStatutoryPaymentId { get; set; } 
        public string BusinessEntity { get; set; }
        public string PayingUnit { get; set; }
        public string Regulator { get; set; }
        public string StatutoryPayment { get; set; }
        public string PaymentFrequency { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public string Purpose { get; set; }
        public string? Comments { get; set; }
        public string? CashRemittanceStatus { get; set; }
        public string? SubmissionToStatutoryBody { get; set; }
        public string? ReasonForRejection { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public DateTime DateCreated { get; set; }
        public string Status { get; set; } 
        public string ComplianceLevel { get; set; } 
        public string? ProcessOfficer { get; set; } 
    }

    public class GetRatedBusinessRiskRating
    {
        public List<GetRatedBusinessRiskRatingResp> Business { get; set; }

    }

    public class GetRatedBusinessRiskRatingResp
    {
        public Guid BusinessRiskRatingId { get; set; }
        public string RequesterName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Business { get; set; }
        public string Status { get; set; }

    }

    public class AuditUniverseReports
    {
        public ARMIMAuditUniverseReport ARMIM { get; set; }
        public ARMHoldCoAuditUniverseReport ARMHoldingCompany { get; set; }
        public DFSAuditUniverseReport DigitalFinancialService { get; set; }
        public ARMCapitalAuditUniverseReport ARMCapital { get; set; }
        public ARMSecurityAuditUniverseReport ARMSecurity { get; set; }
        public ARMTrusteeAuditUniverseReport ARMTrustee { get; set; }
        public ARMHillAuditUniverseReport ARMHill { get; set; }
        public ARMAgriAuditUniverseReport ARMAgribusiness { get; set; }
        public ARMSharedAuditUniverseReport ARMSharedService { get; set; }
    }
    public class ARMHoldCoAuditUniverseReport
    {
        public AuditUniverseSummaryReport ARMHoldingCompany { get; set; }
        public AuditUniverseSummaryReport TreasurySale { get; set; }
    }
    public class DFSAuditUniverseReport
    {
        public AuditUniverseSummaryReport DigitalFinancialServices { get; set; }
    }

    public class ARMCapitalAuditUniverseReport
    {
        public AuditUniverseSummaryReport ARMCapital { get; set; }
    }


    public class ARMIMAuditUniverseReport
    {
        public AuditUniverseSummaryReport ARMIM { get; set; }
        public AuditUniverseSummaryReport IMUnit { get; set; }
        public AuditUniverseSummaryReport BDPWMIAMIMRetail { get; set; }
        public AuditUniverseSummaryReport FundAccount { get; set; }
        public AuditUniverseSummaryReport FundAdmin { get; set; }
        public AuditUniverseSummaryReport RetailOperation { get; set; }
        public AuditUniverseSummaryReport ARMRegistrar { get; set; }
        public AuditUniverseSummaryReport OperationSettlement { get; set; }
        public AuditUniverseSummaryReport OperationControl { get; set; }
        public AuditUniverseSummaryReport Research { get; set; }
    }

    public class ARMHillAuditUniverseReport
    {
        public AuditUniverseSummaryReport ARMHill { get; set; }
    }

    public class ARMAgriAuditUniverseReport
    {
        public AuditUniverseSummaryReport RFl { get; set; }
        public AuditUniverseSummaryReport AAFML { get; set; }
    }
    public class ARMSecurityAuditUniverseReport
    {
        public AuditUniverseSummaryReport StockBroking { get; set; }       
    }
    public class ARMTrusteeAuditUniverseReport
    {
        public AuditUniverseSummaryReport CommercialTrust { get; set; }
        public AuditUniverseSummaryReport PrivateTrust { get; set; }       
    }

    public class AuditUniverseSummaryReport
    {
        //public string BusinessName { get; set; }
        public decimal? BusinessManagerConcern { get; set; }
        public decimal? DirectorConcern { get; set; }

        public string? OldRiskScore { get; set; }

        public string? RiskScore { get; set; }

        public string? RiskRating { get; set; }

        public string? Recommentation { get; set; }

        public string? January { get; set; }

        public string? February { get; set; }

        public string? March { get; set; }

        public string? April { get; set; }

        public string? May { get; set; }

        public string? June { get; set; }

        public string? July { get; set; }

        public string? August { get; set; }

        public string? September { get; set; }

        public string? October { get; set; }

        public string? November { get; set; }

        public string? December { get; set; }
    }
    public class ARMSharedAuditUniverseReport
    {
        public AuditUniverseSummaryReport HCM { get; set; }
        public AuditUniverseSummaryReport ProcurementAndAdmin { get; set; }
        public AuditUniverseSummaryReport IT { get; set; }
        public AuditUniverseSummaryReport RiskManagement { get; set; }
        public AuditUniverseSummaryReport Academy { get; set; }
        public AuditUniverseSummaryReport Legal { get; set; }
        public AuditUniverseSummaryReport MCC { get; set; }
        public AuditUniverseSummaryReport CTO { get; set; }
        public AuditUniverseSummaryReport CustomerExperience { get; set; }
        public AuditUniverseSummaryReport InformationSecurity { get; set; }
        public AuditUniverseSummaryReport InternalControl { get; set; }
        public AuditUniverseSummaryReport Corporatestrategy { get; set; }
        public AuditUniverseSummaryReport Treasury { get; set; }
        public AuditUniverseSummaryReport FinancialControl { get; set; }
        public AuditUniverseSummaryReport Compliance { get; set; }
        public AuditUniverseSummaryReport DataAnalytic { get; set; }
    }
}
