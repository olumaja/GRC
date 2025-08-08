using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using GrcApi.Modules.RiskManagement.AuditPlan;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class EMCConcernRiskRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? BusinessRateRequesterName { get; set; }
        public string? EmcRequesterName { get; set; }
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public ARMHoldingCompanyEMCRating ARMHoldingCompany { get; set; }
        public ARMTAMEMCRating ARMTAM { get; set; }
        public ARMIMEMCRating ARMIM { get; set; }
        public DigitalFinancialServiceEMCRating DigitalFinancialService { get; set; }
        public ARMSecurityEMCRating ARMSecurity { get; set; }
        public ARMTrusteeEMCRating ARMTrustee { get; set; }
        public ARMHILLEMCRating ARMHILL { get; set; }
        public ARMAgribusinessEMCRating ARMAgribusiness { get; set; }
        public ARMSharedServiceEMCRating ARMSharedService { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static EMCConcernRiskRating Create(string businessRateRequesterName, string emcRequesterName, Guid id, string comment)
        {
            return new EMCConcernRiskRating
            {
                BusinessRateRequesterName = businessRateRequesterName,
                EmcRequesterName = emcRequesterName,
                BusinessRiskRatingId = id,
                Comment = comment
            };

        }
    }
    public class ARMHoldingCompanyEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMHoldingCompany { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TreasurySales { get; set; }
        public static ARMHoldingCompanyEMCRating Create(Guid eMCConcernRiskRating, ARMHoldingCompanyRiskRatingEMC aRMHoldingCompanyReq)
        {
            return new ARMHoldingCompanyEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                ARMHoldingCompany = aRMHoldingCompanyReq.ARMHoldingCompany,
                TreasurySales = aRMHoldingCompanyReq.TreasurySales
            };

        }

    }
    public class ARMTAMEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMTAM { get; set; }
        public static ARMTAMEMCRating Create(Guid eMCConcernRiskRating, ARMTAMRiskRatingEMC tam)
        {
            return new ARMTAMEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                ARMTAM = tam.ARMTAM
            };
        }
    }
    public class ARMIMEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMIM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal IMUnit { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BDOrIMRetail { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Fundaccount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FundAdmin { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RetailOperations { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMRegisterar { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OperationSetlement { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OperationControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Research { get; set; }
        public static ARMIMEMCRating Create(Guid eMCConcernRiskRating, ARMIMRiskRatingEMC aRMIMReq)
        {
            return new ARMIMEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                ARMIM = aRMIMReq.ARMIM,
                IMUnit = aRMIMReq.IMUnit,
                OperationSetlement = aRMIMReq.OperationSetlement,
                ARMRegisterar = aRMIMReq.ARMRegisterar,
                FundAdmin = aRMIMReq.FundAdmin,
                Fundaccount = aRMIMReq.Fundaccount,
                BDOrIMRetail = aRMIMReq.BDOrIMRetail,
                OperationControl = aRMIMReq.OperationControl,
                RetailOperations = aRMIMReq.RetailOperations,
                Research = aRMIMReq.Research
            };
        }

    }

    public class ARMSecurityEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InvestmentBanking { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal StockBroking { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Research { get; set; }
        public static ARMSecurityEMCRating Create(Guid eMCConcernRiskRating, ARMSecurityRiskRatingEMC aRMSecurityReq)
        {
            return new ARMSecurityEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                InvestmentBanking = 0,
                StockBroking = aRMSecurityReq.StockBroking,
                Research = 0
            };
        }
    }

    public class ARMTrusteeEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrivateTrust { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CommercialTrust { get; set; }
        public static ARMTrusteeEMCRating Create(Guid eMCConcernRiskRating, ARMTrusteeRiskRatingEMC aRMTrusteeReq)
        {
            return new ARMTrusteeEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                CommercialTrust = aRMTrusteeReq.CommercialTrust,
                PrivateTrust = aRMTrusteeReq.PrivateTrust
            };
        }
    }

    public class ARMHILLEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMHILL { get; set; }
        public static ARMHILLEMCRating Create(Guid eMCConcernRiskRating, ARMHILLRiskRatingEMC aRMHILLReq)
        {
            return new ARMHILLEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                ARMHILL = aRMHILLReq.ARMHILL
            };
        }
    }
    public class ARMAgribusinessEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RFL { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AAFML { get; set; }
        public static ARMAgribusinessEMCRating Create(Guid eMCConcernRiskRating, ARMAgribusinessRiskRatingEMC aRMAgribusinessReq)
        {
            return new ARMAgribusinessEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                RFL = aRMAgribusinessReq.RFL,
                AAFML = aRMAgribusinessReq.AAFML
            };
        }
    }

    public class DigitalFinancialServiceEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DigitalFinancialService { get; set; }
        public static DigitalFinancialServiceEMCRating Create(Guid eMCConcernRiskRating, DigitalFinancialServiceRating dfs)
        {
            return new DigitalFinancialServiceEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                DigitalFinancialService = dfs.DigitalFinancialService
            };
        }
    }


    public class ARMCapitalEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMCapital { get; set; }
        public static ARMCapitalEMCRating Create(Guid eMCConcernRiskRating, ARMCapitalRating armCapital)
        {
            return new ARMCapitalEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                ARMCapital = armCapital.ARMCapital
            };
        }
    }

    public class ARMSharedServiceEMCRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(EMCConcernRiskRating))]
        public Guid EMCConcernRiskRatingId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Compliance { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinancialControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DataAnalytic { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal HCM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProcurementAndAdmin { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal IT { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RiskManagement { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Legal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MCC { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CTO { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CustomerExperience { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InfoSecurity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CorporateStrategy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Academy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Treasury { get; set; }
        public static ARMSharedServiceEMCRating Create(Guid eMCConcernRiskRating, ARMSharedServiceRiskRating aRMSharedServiceReq)
        {
            return new ARMSharedServiceEMCRating
            {
                EMCConcernRiskRatingId = eMCConcernRiskRating,
                FinancialControl = aRMSharedServiceReq.FinancialControl,
                CorporateStrategy = aRMSharedServiceReq.CorporateStrategy,
                CTO = aRMSharedServiceReq.CTO,
                IT = aRMSharedServiceReq.IT,
                DataAnalytic = aRMSharedServiceReq.DataAnalytic,
                InfoSecurity = aRMSharedServiceReq.InfoSecurity,
                Compliance = aRMSharedServiceReq.Compliance,
                CustomerExperience = aRMSharedServiceReq.CustomerExperience,
                ProcurementAndAdmin = aRMSharedServiceReq.ProcurementAndAdmin,
                HCM = aRMSharedServiceReq.HCM,
                Legal = aRMSharedServiceReq.Legal,
                MCC = aRMSharedServiceReq.MCC,
                RiskManagement = aRMSharedServiceReq.RiskManagement,
                InternalControl = aRMSharedServiceReq.InternalControl,
                Academy = aRMSharedServiceReq.Academy,
                Treasury = aRMSharedServiceReq.Treasury
            };
        }
    }
}
