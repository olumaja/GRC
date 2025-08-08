using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class GetManagementConcernRatingResponse
    {
        public Guid Id { get; set; }
        public ManagementConcernARMIMResp? ARMIM { get; set; }
        public ManagementConcernARMTrusteeResp? ARMTrustee { get; set; }
        public ManagementConcernARMSecurityResp? ARMSecurity { get; set; }
        public ManagementConcernARMHillResp? ARMHill { get; set; }
        public ManagementConcernDFSResp? DigitalFinancialService { get; set; }
        public ManagementConcernARMCapitalResp? ARMCapital { get; set; }
        public ManagementConcernARMAgribusinessResp? ARMAgribusiness { get; set; }

    }
    
    #region DFS
    public class ManagementConcernDFSResp
    {
        public BusinessAndBusinessUnitDFSResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceDFSResp? SharedService { get; set; }

    }
    public class BusinessAndBusinessUnitDFSResp
    {
        public decimal DigitalFinancialService { get; set; }
    }

    public class SharedServiceDFSResp
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal Compliance { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal Academy { get; set; }

    }

    public class GetDFSManagementConcernRatingById
    {
        public BusinessAndBusinessUnitDFSResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceDFSResp? SharedService { get; set; }

        public string? Comment { get; set; }
    }

    #endregion

    #region ARMCapital
    public class ManagementConcernARMCapitalResp
    {
        public BusinessAndBusinessUnitARMCapitalResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMCapitalResp? SharedService { get; set; }

    }
    public class BusinessAndBusinessUnitARMCapitalResp
    {
        public decimal ARMCapital { get; set; }
    }

    public class SharedServiceARMCapitalResp
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal Compliance { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal Academy { get; set; }

    }

    public class GetARMCapitalManagementConcernRatingById
    {
        public BusinessAndBusinessUnitARMCapitalResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMCapitalResp? SharedService { get; set; }
        public string? Comment { get; set; }
    }

    #endregion


    #region ARM IM
    public class ManagementConcernARMIMResp
    {
        public BusinessAndBusinessUnitARMIMRatingARMIMResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMIMRatingARMIMResp? SharedService { get; set; }

    }
    public class BusinessAndBusinessUnitARMIMRatingARMIMResp
    {
        public decimal ARMIM { get; set; }
        public decimal IMUnit { get; set; }
        public decimal BDOrIMRetail { get; set; }
        public decimal FundAccount { get; set; }
        public decimal FundAdmin { get; set; }
        public decimal RetailOperation { get; set; }
        public decimal ARMRegistrar { get; set; }
        public decimal OperationSettlement { get; set; }
        public decimal OperationControl { get; set; }
        public decimal Research { get; set; }
    }
    public class SharedServiceARMIMRatingARMIMResp
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal Academy { get; set; }

        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal Compliance { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal DataAnalytic { get; set; }
    }

    public class GetARMIMManagementConcernById
    {
        public BusinessAndBusinessUnitARMIMRatingARMIMResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMIMRatingARMIMResp? SharedService { get; set; }

        public string? Comment { get; set; }

    }

    #endregion

    #region ARM Trustee 
    public class ManagementConcernARMTrusteeResp
    {
        public BusinessAndBusinessUnitARMTrusteeRatingARMTrusteeResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARTrusteeRatingARMTrusteeResp? SharedService { get; set; }

    }
    public class BusinessAndBusinessUnitARMTrusteeRatingARMTrusteeResp
    {
        public decimal PrivateTrust { get; set; }
        public decimal CommercialTrust { get; set; }
    }
    public class SharedServiceARTrusteeRatingARMTrusteeResp
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
        public decimal Compliance { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal DataAnalytic { get; set; }
    }
    public class GetARMTrusteeManagementConcernRatingById
    {
        public BusinessAndBusinessUnitARMTrusteeRatingARMTrusteeResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARTrusteeRatingARMTrusteeResp? SharedService { get; set; }

        public string? Comment { get; set; }
    }

    #endregion

    #region ARM Security 
    public class ManagementConcernARMSecurityResp
    {
        public BusinessAndBusinessUnitARMSecurityRatingARMSecurityResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMSecurityRatingARMSecurityResp? SharedService { get; set; }
    }
    public class BusinessAndBusinessUnitARMSecurityRatingARMSecurityResp
    {
        public decimal StockBroking { get; set; }
    }

    public class SharedServiceARMSecurityRatingARMSecurityResp
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal Compliance { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal Academy { get; set; }

    }

    public class GetARMSecurityManagementConcernRatingById
    {
        public BusinessAndBusinessUnitARMSecurityRatingARMSecurityResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMSecurityRatingARMSecurityResp? SharedService { get; set; }

        public string? Comment { get; set; }
    }
    #endregion

    #region ARM Hill
    public class ManagementConcernARMHillResp
    {
        public BusinessAndBusinessUnitARMHillRatingARMHillResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMHillRatingARMHillResp? SharedService { get; set; }

    }
    public class BusinessAndBusinessUnitARMHillRatingARMHillResp
    {
        public decimal ARMHill { get; set; }
    }

    public class SharedServiceARMHillRatingARMHillResp
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal Academy { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal Compliance { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal DataAnalytic { get; set; }
    }

    public class GetARMHillManagementConcernRatingById
    {
        public BusinessAndBusinessUnitARMHillRatingARMHillResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMHillRatingARMHillResp? SharedService { get; set; }

        public string? Comment { get; set; }
    }

    #endregion

    #region ARM Agribusiness
    public class ManagementConcernARMAgribusinessResp
    {
        public BusinessAndBusinessUnitARMAgribusinessRatingARMAgribusinessResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMAgribusinessRatingArmAgribusinessResp? SharedService { get; set; }
    }
    public class BusinessAndBusinessUnitARMAgribusinessRatingARMAgribusinessResp
    {
        public decimal RFL { get; set; }
        public decimal AAFML { get; set; }
    }

    public class SharedServiceARMAgribusinessRatingArmAgribusinessResp
    {
        public decimal HCM { get; set; }
        public decimal ProcurementAndAdmin { get; set; }
        public decimal IT { get; set; }
        public decimal RiskManagement { get; set; }
        public decimal Legal { get; set; }
        public decimal MCC { get; set; }
        public decimal CTO { get; set; }
        public decimal CustomerExperience { get; set; }
        public decimal InformationSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal Compliance { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal Academy { get; set; }
    }

    public class GetArmAgribusinessManagementConcernRatingById
    {
        public BusinessAndBusinessUnitARMAgribusinessRatingARMAgribusinessResp? BusinessAndBusinessUnit { get; set; }
        public SharedServiceARMAgribusinessRatingArmAgribusinessResp? SharedService { get; set; }

        public string? Comment { get; set; }
    }
    #endregion
}
