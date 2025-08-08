using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using GrcApi.Modules.RiskManagement.AuditPlan;
using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class GetEmcConcernRatingResp
    {
        public Guid Id { get; set; }
        public ARMHoldingCompanyResponse ARMHoldingCompany { get; set; }
        public EMCARMTAMResponse ARMTAM { get; set; }
        public EMCDigitalFinancialServiceResponse DigitalFinancialService { get; set; }
        public EMCARMCapitalResponse ARMCapital { get; set; }
        public ARMIMResponse ARMIM { get; set; }
        public ARMSecurityResponse ARMSecurity { get; set; }
        public ARMTrusteeResponse ARMTrustee { get; set; }
        public ARMHILLResponse ARMHILL { get; set; }
        public ARMAgribusinessResponse ARMAgribusiness { get; set; }
        public ARMSharedServiceResponse ARMSharedService { get; set; }
        public string Comment { get; set; }
    }

    public class GetMCConcernRatingResp
    {      
        public Guid Id { get; set; }
        public MCSummary DigitalFinancialService { get; set; }
        public MCSummary ARMCapital { get; set; }
        public MCSummary ARMIM { get; set; }
        public MCSummary ARMSecurity { get; set; }
        public MCSummary ARMTrustee { get; set; }
        public MCSummary ARMHILL { get; set; }
        public MCSummary ARMAgribusiness { get; set; }
    
    }

    public class MCSummary
    {
        public string? MCRequesterName { get; set; }
        public string? Comment { get; set; }
        public DateTime DateCreated { get; set; }
    }






    public class EMCARMTAMResponse
    {
        public decimal ARMTAM { get; set; }
    }
    public class EMCDigitalFinancialServiceResponse
    {
        public decimal DigitalFinancialService { get; set; }
    }
    public class EMCARMCapitalResponse
    {
        public decimal ARMCapital { get; set; }
    }
    public class ARMHoldingCompanyResponse
    {

        public decimal ARMHoldingCompany { get; set; }
        public decimal TreasurySales { get; set; }
    }

    public class ARMIMResponse
    {

        public decimal ARMIM { get; set; }
        public decimal IMUnit { get; set; }
        public decimal BDOrIMRetail { get; set; }
        public decimal Fundaccount { get; set; }
        public decimal FundAdmin { get; set; }
        public decimal RetailOperations { get; set; }
        public decimal ARMRegisterar { get; set; }
        public decimal OperationSetlement { get; set; }
        public decimal OperationControl { get; set; }
        public decimal Research { get; set; }
    }

    public class ARMSecurityResponse
    {
        public decimal StockBroking { get; set; }

    }

    public class ARMTrusteeResponse
    {
        public decimal PrivateTrust { get; set; }
        public decimal CommercialTrust { get; set; }
    }

    public class ARMHILLResponse
    {
        public decimal ARMHILL { get; set; }
    }
    public class ARMAgribusinessResponse
    {
        public decimal RFL { get; set; }
        public decimal AAFML { get; set; }
    }

    public class ARMSharedServiceResponse
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
        public decimal InfoSecurity { get; set; }
        public decimal InternalControl { get; set; }
        public decimal CorporateStrategy { get; set; }
        public decimal Treasury { get; set; }
        public decimal DataAnalytic { get; set; }
        public decimal FinancialControl { get; set; }
        public decimal Compliance { get; set; }
    }
}
