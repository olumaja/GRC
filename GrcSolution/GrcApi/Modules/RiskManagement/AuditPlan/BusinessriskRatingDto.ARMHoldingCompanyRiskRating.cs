using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
   
    public class ARMSecurityRiskRatingEMC
    {
        public decimal StockBroking { get; set; }
    }
       
    public class ARMHoldingCompanyRiskRatingEMC
    {
        public decimal ARMHoldingCompany { get; set; }
        public decimal TreasurySales { get; set; }
    }
  
    public class ARMIMRiskRatingEMC
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

  
    public class ARMAgribusinessRiskRatingEMC
    {
        public decimal RFL { get; set; }
        public decimal AAFML { get; set; }
    }
    public class ARMSharedServiceRiskRating
    {       
        public int HCM { get; set; }
        public int ProcurementAndAdmin { get; set; }
        public int IT { get; set; }
        public int RiskManagement { get; set; }
        public int Academy { get; set; }
        public int Legal { get; set; }
        public int MCC { get; set; }
        public int CTO { get; set; }
        public int CustomerExperience { get; set; }
        public int InfoSecurity { get; set; }
        public int InternalControl { get; set; }
        public int CorporateStrategy { get; set; }       
        public int Treasury { get; set; }
        public int DataAnalytic { get; set; }
        public int FinancialControl { get; set; }
        public int Compliance { get; set; }       
    }

     
    public class ARMTrusteeRiskRatingEMC
    {
        public decimal PrivateTrust { get; set; }
        public decimal CommercialTrust { get; set; }
    }

  
    public class ARMHILLRiskRatingEMC
    {
        public decimal ARMHILL { get; set; }
    }
    public class DigitalFinancialServiceRating
    {
        public int DigitalFinancialService { get; set; }
    }
    public class ARMCapitalRating
    {
        public int ARMCapital { get; set; }
    }
    public class ARMTAMRiskRatingEMC
    {
        public decimal ARMTAM { get; set; }
    }
}
