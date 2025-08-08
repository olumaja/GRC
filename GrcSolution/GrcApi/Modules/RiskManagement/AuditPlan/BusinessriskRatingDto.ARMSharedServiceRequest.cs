using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ARMSharedServiceRequest
    {
        public ARMSharedServiceRatingReq ARMSharedService { get; set; }
    }
    public class ARMSharedServiceRatingReq
    {
        public StrategySharedServiceReq Strategy { get; set; }
        public OperationSharedServiceReq Operations { get; set; }
        public ComplianceSharedServiceReq Compliance { get; set; }
        public TimeSinceLastSharedServiceAuditReq LastReportOverallRating { get; set; }
        public BusinessRiskRatingStatus Status { get; set; }
    }

    public class StrategySharedServiceReq
    {
        public StrategySharedServiceRatingReq HCM { get; set; }
        public StrategySharedServiceRatingReq ProcurementAndAdmin { get; set; }
        public StrategySharedServiceRatingReq IT { get; set; }
        public StrategySharedServiceRatingReq RiskManagement { get; set; }
        public StrategySharedServiceRatingReq Academy { get; set; }
        public StrategySharedServiceRatingReq Legal { get; set; }
        public StrategySharedServiceRatingReq MCC { get; set; }
        public StrategySharedServiceRatingReq CTO { get; set; }
        public StrategySharedServiceRatingReq CustomerExperience { get; set; }
        public StrategySharedServiceRatingReq InformationSecurity { get; set; }
        public StrategySharedServiceRatingReq InternalControl { get; set; }
        public StrategySharedServiceRatingReq Corporatestrategy { get; set; }
        public StrategySharedServiceRatingReq Treasury { get; set; }
        public StrategySharedServiceRatingReq FinancialControl { get; set; }
        public StrategySharedServiceRatingReq Compliance { get; set; }
        public StrategySharedServiceRatingReq DataAnalytic { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }
    public class StrategySharedServiceRatingReq
    {
        public int ReputationalRisk { get; set; }
        public int PeopleRetentionRisk { get; set; }
        public int TechnologicalRisk { get; set; }
        public int InformationSecurityRisk { get; set; }
        public int FluidityofTechnologicalSolutions { get; set; }
        public int ProjectManagementRisk { get; set; }
        public int HealthandSafetyRisks { get; set; }
        public int EmergingRisks { get; set; }
        public int ProductivityRisk { get; set; }
        public int Total { get; set; }
    }

    public class OperationSharedServiceReq
    {
        public OperationSharedServiceRatingReq HCM { get; set; }
        public OperationSharedServiceRatingReq ProcurementAndAdmin { get; set; }
        public OperationSharedServiceRatingReq IT { get; set; }
        public OperationSharedServiceRatingReq RiskManagement { get; set; }
        public OperationSharedServiceRatingReq Academy { get; set; }
        public OperationSharedServiceRatingReq Legal { get; set; }
        public OperationSharedServiceRatingReq MCC { get; set; }
        public OperationSharedServiceRatingReq CTO { get; set; }
        public OperationSharedServiceRatingReq CustomerExperience { get; set; }
        public OperationSharedServiceRatingReq InformationSecurity { get; set; }
        public OperationSharedServiceRatingReq InternalControl { get; set; }
        public OperationSharedServiceRatingReq Corporatestrategy { get; set; }
        public OperationSharedServiceRatingReq Treasury { get; set; }
        public OperationSharedServiceRatingReq DataAnalytic { get; set; }
        public OperationSharedServiceRatingReq Financialcontrol { get; set; }
        public OperationSharedServiceRatingReq Compliance { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class OperationSharedServiceRatingReq
    {
        public int AdoptionandImplementationofPolicies { get; set; }
        public int TheftorFraudRisk { get; set; }
        public int PoorCustomerService { get; set; }
        public int ObsoleteTechnology { get; set; }
        public int VendorManagement { get; set; }
        public int QualityManagament { get; set; }
        public int AssentMaintenance { get; set; }
        public int DisclosureCorruptionOfSensitiveData { get; set; }
        public int ChangeNoticeManagement { get; set; }
        public int BCPandDRP { get; set; }
        public int ITInfrastruCTOreDowntime { get; set; }
        public int ThirdpartyRisk { get; set; }
        public int TAT { get; set; }
        public int TheftLeakageorMisuseofIntelleCTOalProperty { get; set; }
        public int OverorUnderpaymentofClient { get; set; }
        public int RecruitmentRisk { get; set; }
        public int UnauthorizedAccess { get; set; }
        public int MalwareorVirusorWebsiteAttacks { get; set; }
        public int ErroneousDataEntry { get; set; }
        public int Miscommunication { get; set; }
        public int ErrorDetectionRisk { get; set; }
        public int StrategyMonitoringRisk { get; set; }
        public int RelevanceandRecencyofModelToolsandTechniques { get; set; }
        public int BudgetOverruns { get; set; }
        public int Total { get; set; }
    }

    public class FinancialSharedServiceReportingReq
    {
        public FinacialSharedServiceRatingReq ARMSharedService { get; set; }
        public FinacialSharedServiceRatingReq HCM { get; set; }
        public FinacialSharedServiceRatingReq ProcurementAndAdmin { get; set; }
        public FinacialSharedServiceRatingReq IT { get; set; }
        public FinacialSharedServiceRatingReq RiskManagement { get; set; }
        public FinacialSharedServiceRatingReq Academy { get; set; }
        public FinacialSharedServiceRatingReq Legal { get; set; }
        public FinacialSharedServiceRatingReq MCC { get; set; }
        public FinacialSharedServiceRatingReq CTO { get; set; }
        public FinacialSharedServiceRatingReq Customerexperience { get; set; }
        public FinacialSharedServiceRatingReq InformationSecurity { get; set; }
        public FinacialSharedServiceRatingReq InternalControl { get; set; }
        public FinacialSharedServiceRatingReq Corporatestrategy { get; set; }
        public FinacialSharedServiceRatingReq Treasury { get; set; }
        public FinacialSharedServiceRatingReq DigitalFinanceService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

    public class FinacialSharedServiceRatingReq
    {
        public int IncomeAssuranceRisk { get; set; }

        public int StatutoryDeductionsandTaxes { get; set; }

        public int AdherencetoFinancialStandards { get; set; }

        public int AdoptionandImplementationofPoliciesAdherence { get; set; }

        public int TAT { get; set; }

        public int ErrororControlRisk { get; set; }

        public int TheftorFraudRisk { get; set; }

        public int Total { get; set; }

    }

    public class ComplianceSharedServiceReq
    {
        public ComplianceSharedServiceRatingReq HCM { get; set; }
        public ComplianceSharedServiceRatingReq ProcurementAndAdmin { get; set; }
        public ComplianceSharedServiceRatingReq IT { get; set; }
        public ComplianceSharedServiceRatingReq RiskManagement { get; set; }
        public ComplianceSharedServiceRatingReq Academy { get; set; }
        public ComplianceSharedServiceRatingReq Legal { get; set; }
        public ComplianceSharedServiceRatingReq MCC { get; set; }
        public ComplianceSharedServiceRatingReq CTO { get; set; }
        public ComplianceSharedServiceRatingReq Customerexperience { get; set; }
        public ComplianceSharedServiceRatingReq InformationSecurity { get; set; }
        public ComplianceSharedServiceRatingReq InternalControl { get; set; }
        public ComplianceSharedServiceRatingReq Corporatestrategy { get; set; }
        public ComplianceSharedServiceRatingReq Treasury { get; set; }
        public ComplianceSharedServiceRatingReq Compliance { get; set; }
        public ComplianceSharedServiceRatingReq FinancialControl { get; set; }
        public ComplianceSharedServiceRatingReq DataAnalytic { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }

    }

    public class ComplianceSharedServiceRatingReq
    {
        public int AMLCFT { get; set; }
        public int LitigationRisk { get; set; }
        public int ChangingRegulations { get; set; }
        public int InaccurateComputationofRegulatoryRemittancesDelayedFilings { get; set; }
        public int NonComplianceWithContracts { get; set; }
        public int KYCChecks { get; set; }
        public int GDPROrNDPR { get; set; }
        public int DisclosureRisk { get; set; }
        public int Total { get; set; }
    }

    public class TimeSinceLastSharedServiceAuditReq
    {
        public int HCM { get; set; }
        public int ProcurementAndAdmind { get; set; }
        public int IT { get; set; }
        public int RiskManagement { get; set; }
        public int Academy { get; set; }
        public int Legal { get; set; }
        public int MCC { get; set; }
        public int CTO { get; set; }
        public int Customerexperience { get; set; }
        public int InformationSecurity { get; set; }
        public int InternalControl { get; set; }
        public int Corporatestrategy { get; set; }
        public int Treasury { get; set; }
        public int FinancialControl { get; set; }
        public int DataAnalytic { get; set; }
        public int Compliance { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
    }

}
