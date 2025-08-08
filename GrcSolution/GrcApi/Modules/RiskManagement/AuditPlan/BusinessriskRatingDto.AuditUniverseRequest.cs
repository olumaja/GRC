using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using GrcApi.Modules.RiskManagement.AuditPlan;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ViewAuditExecutionResp
    {
       
        public Guid AuditProgramId { get; set; }
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public Guid CommenceengagementId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
    }

    public class ViewAuditExecutionPlanSumary
    {
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionResp ARMHoldingCompany { get; set; }
        public ViewAuditExecutionResp ARMTAM { get; set; }
        public ViewAuditExecutionResp ARMIM { get; set; }
        public ViewAuditExecutionResp ARMTrustee { get; set; }
        public ViewAuditExecutionResp ARMSecurity { get; set; }
        public ViewAuditExecutionResp ARMHill { get; set; }
        public ViewAuditExecutionResp ARMAgribusiness { get; set; }
        public ViewAuditExecutionResp ARMSharedService { get; set; }
        public ViewAuditExecutionResp DigitalFinancialService { get; set; }
        public ViewAuditExecutionResp ARMCapital { get; set; }

    }



    public class ViewAuditExecutionARMSharedServiceResp
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail HCM { get; set; }
        public ViewAuditExecutionDetail Compliance { get; set; }
        public ViewAuditExecutionDetail FinancialControl { get; set; }
        public ViewAuditExecutionDetail Legal { get; set; }
        public ViewAuditExecutionDetail IT { get; set; }
        public ViewAuditExecutionDetail InternalControl { get; set; }
        public ViewAuditExecutionDetail CTO { get; set; }
        public ViewAuditExecutionDetail Treasury { get; set; }
        public ViewAuditExecutionDetail RiskManagement { get; set; }
        public ViewAuditExecutionDetail CorporateStrategy { get; set; }
        public ViewAuditExecutionDetail DataAnalytic { get; set; }
        public ViewAuditExecutionDetail Academy { get; set; }
        public ViewAuditExecutionDetail MCC { get; set; }
        public ViewAuditExecutionDetail InformationSecurity { get; set; }
        public ViewAuditExecutionDetail ProcurementandAdmin { get; set; }
        public ViewAuditExecutionDetail CustomerExperience { get; set; }
    }

    public class ViewAuditExecutionARMAgribusnessResp 
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail RFL { get; set; }
        public ViewAuditExecutionDetail AAFML { get; set; }
    }
    public class ViewAuditExecutionARMTAMResp
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail ARMTAM { get; set; }
    }

    public class ViewAuditExecutionARMCapitalResp
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail ARMCapital { get; set; }
    }

    public class ViewAuditExecutionDFSResp
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail DigitalFinancialService { get; set; }
    }
    public class ViewAuditExecutionARMHillResp
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail ARMHill { get; set; }
    }
    public class ViewAuditExecutionARMSecurityResp
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail StockBroking { get; set; }       
    }
    public class ViewAuditExecutionARMTrusteeResp
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail PrivateTrust { get; set; }
        public ViewAuditExecutionDetail CommercialTrust { get; set; }
    }
    
    public class ViewAuditExecutionARMIMResp
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail IMUnit { get; set; }
        public ViewAuditExecutionDetail FundAdmin { get; set; }
        public ViewAuditExecutionDetail RetailOperation { get; set; }
        public ViewAuditExecutionDetail Research { get; set; }
        public ViewAuditExecutionDetail FundAccount { get; set; }
        public ViewAuditExecutionDetail OperationControl { get; set; }
        public ViewAuditExecutionDetail Registrar { get; set; }
        public ViewAuditExecutionDetail BDPWMIAMIMRetail { get; set; }
        public ViewAuditExecutionDetail OperationSettlement { get; set; }
    }

    public class ViewAuditExecutionARMHoldCoResp
    {
        public Guid AuditProgramId { get; set; }
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionDetail ARMHoldingCompany { get; set; }
        public ViewAuditExecutionDetail Treasurysale { get; set; }
    }

    public class ViewAuditExecutionDetail
    {
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public Guid CommenceengagementId { get; set; }
        //public DateTime DateCreated { get; set; }
        //public int AuditYear { get; set; }
        //public string Status { get; set; }
    }

    public class ViewWorkPaperResp
    {
        public Guid AuditProgramId { get; set; }
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public Guid CommenceengagementId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string Business { get; set; }
        public string AuditOfficer { get; set; }
        public IssueRating IssueRating { get; set; }
    }

    public class ViewAuditExecutionPlan
    {
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string AuditOfficer { get; set; }
        public string Status { get; set; }
        public ViewAuditExecutionARMHoldCoResp ARMHoldingCompany { get; set; }
        public ViewAuditExecutionARMTAMResp ARMTAM { get; set; }
        public ViewAuditExecutionARMIMResp ARMIM { get; set; }
        public ViewAuditExecutionARMTrusteeResp ARMTrustee { get; set; }
        public ViewAuditExecutionARMSecurityResp ARMSecurity { get; set; }
        public ViewAuditExecutionARMHillResp ARMHill { get; set; }
        public ViewAuditExecutionARMAgribusnessResp ARMAgribusiness { get; set; }
        public ViewAuditExecutionARMSharedServiceResp ARMSharedService { get; set; }
        public ViewAuditExecutionDFSResp DigitalFinancialService { get; set; }
        public ViewAuditExecutionARMCapitalResp ARMCapital { get; set; }

    }

    public class ViewWorkPaperReport
    {
        public Guid AuditProgramId { get; set; }
        public Guid CommenceengagementId { get; set; }
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuditYear { get; set; }
        public string AuditOfficer { get; set; }
        public IssueRating IssueRating { get; set; }
        public ViewWorkPaperResp ARMHoldingCompany { get; set; }
        public ViewWorkPaperResp ARMIM { get; set; }
        public ViewWorkPaperResp ARMTreasury { get; set; }
        public ViewWorkPaperResp ARMSecurity { get; set; }
        public ViewWorkPaperResp ARMHill { get; set; }
        public ViewWorkPaperResp ARMAgribusiness { get; set; }
        public ViewWorkPaperResp ARMSharedService { get; set; }

    }

    public class MonthltAudit
    {

        public string January { get; set; }

        public string February { get; set; }

        public string March { get; set; }
        public string April { get; set; }

        public string May { get; set; }

        public string June { get; set; }

        public string July { get; set; }

        public string August { get; set; }

        public string September { get; set; }

        public string October { get; set; }

        public string November { get; set; }

        public string December { get; set; }
    }

    public class AuditUniverseSummary
    {
        public decimal BusinessManagerConcern { get; set; }
        public decimal DirectorConcern { get; set; }

        public string? OldRiskScore { get; set; }

        public string? RiskScore { get; set; }
        public string? RiskScore2 { get; set; }

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
    public class ViewAuditExecutionPlanSummaryResp
    {
        public Guid CommenceEngagementId { get; set; }
        public string Team { get; set; }
        public string EngagementPlanStatus { get; set; } 
        public string WorkPaperStatus { get; set; }
        public string Findingstatus { get; set; } 
        public string ReasonForRejection { get; set; } 
    }

    public class ViewAudiPlanExecutionResponse
    {

        public string Month { get; set; }

        public string Team { get; set; }
        public string? Recommendation { get; set; }
        public string EngagementPlan { get; set; } 
        public string WorkPaper { get; set; }
        public string FindingStatus { get; set; }
        public Guid CommenceEngagementId { get; set; }
    }

    public class MonthlyAuditUniverseReq
    {
        public Guid BusinessRiskRatingId { get; set; }
        public ARMHoldCoMonthlyAuditReq ARMHoldingCompany { get; set; }
        public ARMIMMonthlyAuditReq ARMIM { get; set; }
        public ARMSecurityMonthlyAuditReq ARMSecurity { get; set; }
        public ARMAgribusinessMonthlyAuditReq ARMAgribusiness { get; set; }
        public ARMHillMonthlyAuditReq ARMHill { get; set; }
        public ARMTrusteeMonthlyAuditReq ARMTrustee { get; set; }
        public DigitalFinancialServiceMonthlyAuditReq DigitalFinancialService { get; set; }
        public ARMCapitalMonthlyAuditReq ARMCapital { get; set; }
        public ARMSharedServiceMonthlyAuditReq ARMSharedService { get; set; }
    }

    #region ARMHoldCo
    public class ARMHoldCoMonthlyAuditReq
    {
        public MonthltAudit ArmHoldingcompany { get; set; }
        public MonthltAudit TreasurySale { get; set; }
    }
    public class GetARMHoldngCompanyAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary ArmHoldingCompany { get; set; }
        public AuditUniverseSummary TreasurySale { get; set; }
    }

    public class ViewARMHoldCoAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse ArmHoldingCompany { get; set; }
        public ViewAudiPlanExecutionResponse TreasurySale { get; set; }
    }

    #endregion

    #region ARMSecurity
    public class GetARMSecurityAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary StockBroking { get; set; }
    }
    public class ARMSecurityMonthlyAuditReq
    {
        public MonthltAudit StockBroking { get; set; }
    }

    public class ViewARMSecurityAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse StockBroking { get; set; }
    }

    #endregion

    #region ARMHill
    public class GetARMHillAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary ARMHill { get; set; }
    }
    public class ARMHillMonthlyAuditReq
    {
        public MonthltAudit ARMHill { get; set; }
    }
    public class ViewARMHillAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse ARMHill { get; set; }
    }

    #endregion

    #region ARMSharedService
    public class GetARMSharedServiceAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary HCM { get; set; }
        public AuditUniverseSummary IT { get; set; }
        public AuditUniverseSummary MCC { get; set; }
        public AuditUniverseSummary CTO { get; set; }
        public AuditUniverseSummary Legal { get; set; }
        public AuditUniverseSummary Treasury { get; set; }
        public AuditUniverseSummary InternalControl { get; set; }
        public AuditUniverseSummary ProcurementandAdmin { get; set; }
        public AuditUniverseSummary CustomerExperience { get; set; }
        public AuditUniverseSummary Academy { get; set; }
        public AuditUniverseSummary Compliance { get; set; }
        public AuditUniverseSummary DataAnalytic { get; set; }
        public AuditUniverseSummary FinancialControl { get; set; }
        public AuditUniverseSummary CorporateStrategy { get; set; }
        public AuditUniverseSummary RiskManagement { get; set; }
        public AuditUniverseSummary InformationSecurity { get; set; }
    }

    public class ARMSharedServiceMonthlyAuditReq
    {
        public MonthltAudit HCM { get; set; }
        public MonthltAudit IT { get; set; }
        public MonthltAudit MCC { get; set; }
        public MonthltAudit CTO { get; set; }
        public MonthltAudit Legal { get; set; }
        public MonthltAudit Treasury { get; set; }
        public MonthltAudit InternalControl { get; set; }
        public MonthltAudit ProcurementandAdmin { get; set; }
        public MonthltAudit CustomerExperience { get; set; }
        public MonthltAudit InformationSecurity { get; set; }
        public MonthltAudit Academy { get; set; }
        public MonthltAudit Compliance { get; set; }
        public MonthltAudit FinancialControl { get; set; }
        public MonthltAudit DataAnalytic { get; set; }
        public MonthltAudit CorporateStrategy { get; set; }
        public MonthltAudit RiskManagement { get; set; }
    }

    public class ViewARMSharedServiceAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse HCM { get; set; }
        public ViewAudiPlanExecutionResponse IT { get; set; }
        public ViewAudiPlanExecutionResponse MCC { get; set; }
        public ViewAudiPlanExecutionResponse CTO { get; set; }
        public ViewAudiPlanExecutionResponse Legal { get; set; }
        public ViewAudiPlanExecutionResponse Treasury { get; set; }
        public ViewAudiPlanExecutionResponse InternalControl { get; set; }
        public ViewAudiPlanExecutionResponse ProcurementandAdmin { get; set; }
        public ViewAudiPlanExecutionResponse CustomerExperience { get; set; }
        public ViewAudiPlanExecutionResponse InformationSecurity { get; set; }
        public ViewAudiPlanExecutionResponse Academy { get; set; }
        public ViewAudiPlanExecutionResponse DataAnalytic { get; set; }
        public ViewAudiPlanExecutionResponse Compliance { get; set; }
        public ViewAudiPlanExecutionResponse FinancialControl { get; set; }
        public ViewAudiPlanExecutionResponse CorporateStrategy { get; set; }
        public ViewAudiPlanExecutionResponse RiskManagement { get; set; }
    }


    #endregion

    #region ARMAgribusiness
    public class GetARMAgribusinessAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary RFL { get; set; }
        public AuditUniverseSummary AAFML { get; set; }
    }
    public class ARMAgribusinessMonthlyAuditReq
    {
        public MonthltAudit RFL { get; set; }
        public MonthltAudit AAFML { get; set; }
    }

    public class ViewARMAgribusinessAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse RFL { get; set; }
        public ViewAudiPlanExecutionResponse AAFML { get; set; }
    }

    #endregion

    #region ARMTrustee
    public class GetARMTrusteeAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary CommercialTrust { get; set; }
        public AuditUniverseSummary PrivateTrust { get; set; }
    }
    public class ARMTrusteeMonthlyAuditReq
    {     
        public MonthltAudit CommercialTrust { get; set; }
        public MonthltAudit PrivateTrust { get; set; }
    }

    public class ViewARMTrusteeAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse CommercialTrust { get; set; }
        public ViewAudiPlanExecutionResponse PrivateTrust { get; set; }
    }

    #endregion

    #region ARMTAM
    public class GetARMTAMAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary ArmTAM { get; set; }
    }
    public class ARMTAMMonthlyAuditReq
    {
        public MonthltAudit ArmTAM { get; set; }
    }

    public class ViewARMTAMAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse ArmTAM { get; set; }
    }

    #endregion

    #region DigitalFinancialService
    public class GetDigitalFinancialServiceAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary DigitalFinancialService { get; set; }
    }
    public class DigitalFinancialServiceMonthlyAuditReq
    {
        public MonthltAudit DigitalFinancialService { get; set; }
    }

    public class ViewDigitalFinancialServiceAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse DigitalFinancialService { get; set; }
    }

    #endregion

    #region ARMIM
    public class ARMIMMonthlyAuditReq
    {
        public MonthltAudit IMUnit { get; set; }
        public MonthltAudit OperationControl { get; set; }
        public MonthltAudit FundAdmin { get; set; }
        public MonthltAudit Registrar { get; set; }
        public MonthltAudit BDPWMIAMIMRetail { get; set; }
        public MonthltAudit RetailOperation { get; set; }
        public MonthltAudit OperationSettlement { get; set; }
        public MonthltAudit FundAccount { get; set; }
        public MonthltAudit Research { get; set; }
    }

    public class GetARMIMAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary IMUnit { get; set; }
        public AuditUniverseSummary OperationControl { get; set; }
        public AuditUniverseSummary FundAdmin { get; set; }
        public AuditUniverseSummary Registrar { get; set; }
        public AuditUniverseSummary BDPWMIAMIMRetail { get; set; }
        public AuditUniverseSummary RetailOperation { get; set; }
        public AuditUniverseSummary OperationSettlement { get; set; }
        public AuditUniverseSummary FundAccount { get; set; }
        public AuditUniverseSummary Research { get; set; }
    }

    public class ViewARMIMAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse IMUnit { get; set; }
        public ViewAudiPlanExecutionResponse OperationControl { get; set; }
        public ViewAudiPlanExecutionResponse FundAdmin { get; set; }
        public ViewAudiPlanExecutionResponse Registrar { get; set; }
        public ViewAudiPlanExecutionResponse BDPWMIAMIMRetail { get; set; }
        public ViewAudiPlanExecutionResponse RetailOperation { get; set; }
        public ViewAudiPlanExecutionResponse OperationSettlement { get; set; }
        public ViewAudiPlanExecutionResponse FundAccount { get; set; }
        public ViewAudiPlanExecutionResponse Research { get; set; }
    }

    #endregion

    #region ARMCapital
    public class GetARMCapitalAuditUniverseSummary
    {
        public Guid AnualAuditUniverseId { get; set; }
        public AuditUniverseSummary ARMCapital { get; set; }
    }
    public class ARMCapitalMonthlyAuditReq
    {
        public MonthltAudit ARMCapital { get; set; }
    }

    public class ViewARMCapitalAudiPlanExecutionByIdResp
    {
        public ViewAudiPlanExecutionResponse ARMCapital { get; set; }
    }

    #endregion
}
