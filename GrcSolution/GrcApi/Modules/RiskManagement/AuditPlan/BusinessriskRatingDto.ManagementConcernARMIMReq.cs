using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{

    public class ManagementConcernARMIMReq
    {
        public BusinessAndBusinessUnitARMIMRatingARMIMReq BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMIMRatingARMIMReq SharedService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string BusinessRateRequesterName { get; set; }
        public Guid BusinessRiskRatingId { get; set; }
    }
    public class BusinessAndBusinessUnitARMIMRatingARMIMReq
    {
        public decimal ARMIM { get; set; }
        public decimal IMUnit { get; set; }
        public decimal BDOrIMRetail { get; set; }
        public decimal FundAccount { get; set; }
        public decimal FundAdmin { get; set; }
        public decimal RetailOperation { get; set; }
        public decimal ARMRegistrar { get; set; }
        public decimal OperationControl { get; set; }
        public decimal OperationSettlement { get; set; }        
        public decimal Research { get; set; }        
    }
    public class SharedServiceARMIMRatingARMIMReq
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Academy { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal Compliance { get; set; }
    }

    public class ManagementConcernARMTrusteeReq
    {
        public BusinessAndBusinessUnitARMTrusteeRatingARMTrusteeReq BusinessAndBusinessUnit { get; set; }
        public SharedServiceARTrusteeRatingARMTrusteeReq SharedService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
        public string BusinessRateRequesterName { get; set; }
        public Guid BusinessRiskRatingId { get; set; }
    }
    public class BusinessAndBusinessUnitARMTrusteeRatingARMTrusteeReq
    {
        public decimal PrivateTrust { get; set; }
        public decimal CommercialTrust { get; set; }
    }
    public class SharedServiceARTrusteeRatingARMTrusteeReq
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Academy { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal Compliance { get; set; }
    }

    public class ManagementConcernARMSecurityReq
    {
        public BusinessAndBusinessUnitARMSecurityRatingARMSecurityReq BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMSecurityRatingARMSecurityReq SharedService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
        public string BusinessRateRequesterName { get; set; }
        public Guid BusinessRiskRatingId { get; set; }

    }
    public class BusinessAndBusinessUnitARMSecurityRatingARMSecurityReq
    {
        public decimal StockBroking { get; set; }
    }

    public class SharedServiceARMSecurityRatingARMSecurityReq
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Academy { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal Compliance { get; set; }
    }

    public class ManagementConcernARMAgribusinessReq
    {
        public BusinessAndBusinessUnitARMAgribusinessRatingARMAgribusinessReq BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMAgribusinessRatingArmAgribusinessReq SharedService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
        public string BusinessRateRequesterName { get; set; }
        public Guid BusinessRiskRatingId { get; set; }
    }
    public class BusinessAndBusinessUnitARMAgribusinessRatingARMAgribusinessReq
    {
        public decimal RFL { get; set; }
        public decimal AAFML { get; set; }
    }

    public class SharedServiceARMAgribusinessRatingArmAgribusinessReq
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Academy { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal Compliance { get; set; }
    }

    public class ManagementConcernARMHillReq
    {
        public BusinessAndBusinessUnitARMHillRatingARMHillReq BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMHillRatingARMHillReq SharedService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
        public string BusinessRateRequesterName { get; set; }
        public Guid BusinessRiskRatingId { get; set; }

    }
    public class BusinessAndBusinessUnitARMHillRatingARMHillReq
    {
        public decimal ARMHill { get; set; }
    }

    public class SharedServiceARMHillRatingARMHillReq
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Academy { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal Compliance { get; set; }
    }

    public class ManagementConcernDFSReq
    {
        public BusinessAndBusinessUnitDFSReq BusinessAndBusinessUnit { get; set; }
        public SharedServiceDFSReq SharedService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
        public string BusinessRateRequesterName { get; set; }
        public Guid BusinessRiskRatingId { get; set; }
    }
    public class BusinessAndBusinessUnitDFSReq
    {
        public decimal DigitalFinancialService { get; set; }
    }

    public class SharedServiceDFSReq
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Academy { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal Compliance { get; set; }
    }


    public class ManagementConcernARMCapitalReq
    {
        public BusinessAndBusinessUnitARMCapitalReq BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMCapitalReq SharedService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        public string? Comment { get; set; }
        public string BusinessRateRequesterName { get; set; }
        public Guid BusinessRiskRatingId { get; set; }
    }
    public class BusinessAndBusinessUnitARMCapitalReq
    {
        public decimal ARMCapital { get; set; }
    }

    public class SharedServiceARMCapitalReq
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Academy { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal Compliance { get; set; }
    }
}
