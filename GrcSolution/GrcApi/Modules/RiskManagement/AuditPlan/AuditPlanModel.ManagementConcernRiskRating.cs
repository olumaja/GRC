using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ManagementConcernRiskRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? BusinessRateRequesterName { get; set; }
        public string? ManagementConcernRequesterName { get; set; }
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public ManagementConcernARMIM ARMIM { get; set; }

        public ManagementConcernARMTrustee ARMTrustee { get; set; }

        public ManagementConcernARMSecurity ARMSecurity { get; set; }

        public ManagementConcernARMHill ARMHill { get; set; }
        public ManagementConcernDFS DigitalFinancialService { get; set; }

        public ManagementConcernARMAgribusiness ARMAgribusiness { get; set; }
        public static ManagementConcernRiskRating CreateManagementConcernRiskRating(string businessRateRequesterName, string managementConcernRequesterName, Guid businessRiskRatingId)
        {
            return new ManagementConcernRiskRating
            {
                BusinessRateRequesterName = businessRateRequesterName,
                ManagementConcernRequesterName = managementConcernRequesterName,
                BusinessRiskRatingId = businessRiskRatingId,
            };
        }

    }
    #region ARM IM
    public class ManagementConcernARMIM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(ManagementConcernRiskRating))]
        public Guid ManagementConcernRiskRatingId { get; set; }

        [ForeignKey(nameof(ManagementConcernRiskRatingId))]
        public ManagementConcernRiskRating ManagementConcernRiskRating { get; set; }
        public ManagementConcernBusinessUnitARMIMRating BusinessAndBusinessUnit { get; set; }
        public ManagementConcernSharedServiceARMIMRating SharedService { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Comment { get; set; }
        public static ManagementConcernARMIM Create(Guid riskRatingId, string requesterName, string comment)
        {
            return new ManagementConcernARMIM
            {
                ManagementConcernRiskRatingId = riskRatingId,
                RequesterName = requesterName,
                Comment = comment
            };
        }

    }
    public class ManagementConcernBusinessUnitARMIMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(ManagementConcernARMIM))]
        public Guid ManagementConcernARMIMId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMIM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal IMUnit { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BDOrIMRetail { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FundAccount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FundAdmin { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RetailOperation { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMRegistrar { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OperationSettlement { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OperationControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Research { get; set; }
        public static ManagementConcernBusinessUnitARMIMRating Create(Guid riskRatingId, ManagementConcernARMIMReq req)
        {
            return new ManagementConcernBusinessUnitARMIMRating
            {
                ManagementConcernARMIMId = riskRatingId,
                ARMIM = req.BusinessAndBusinessUnit.ARMIM,
                IMUnit = req.BusinessAndBusinessUnit.IMUnit,
                BDOrIMRetail = req.BusinessAndBusinessUnit.BDOrIMRetail,
                ARMRegistrar = req.BusinessAndBusinessUnit.ARMRegistrar,
                RetailOperation = req.BusinessAndBusinessUnit.RetailOperation,
                FundAccount = req.BusinessAndBusinessUnit.FundAccount,
                FundAdmin = req.BusinessAndBusinessUnit.FundAdmin,
                OperationControl = req.BusinessAndBusinessUnit.OperationControl,
                OperationSettlement = req.BusinessAndBusinessUnit.OperationSettlement,
                Research = req.BusinessAndBusinessUnit.Research
            };
        }

    }
    public class ManagementConcernSharedServiceARMIMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(ManagementConcernARMIM))]
        public Guid ManagementConcernARMIMId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal HCM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProcurementAndAdmin { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal IT { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RiskManagement { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Academy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Legal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MCC { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CTO { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CustomerExperience { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InformationSecurity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CorporateStrategy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Treasury { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DataAnalytic { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinancialControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Compliance { get; set; }

        public static ManagementConcernSharedServiceARMIMRating Create(Guid riskRatingId, ManagementConcernARMIMReq req)
        {
            return new ManagementConcernSharedServiceARMIMRating
            {
                ManagementConcernARMIMId = riskRatingId,
                HCM = req.SharedService.HCM,
                CorporateStrategy = req.SharedService.CorporateStrategy,
                CTO = req.SharedService.CTO,
                Academy = req.SharedService.Academy,
                IT = req.SharedService.IT,
                InformationSecurity = req.SharedService.InformationSecurity,
                FinancialControl = req.SharedService.FinancialControl,
                DataAnalytic = req.SharedService.DataAnalytic,
                Compliance = req.SharedService.Compliance,
                CustomerExperience = req.SharedService.CustomerExperience,
                ProcurementAndAdmin = req.SharedService.ProcurementAndAdmin,
                InternalControl = req.SharedService.InternalControl,
                Legal = req.SharedService.Legal,
                MCC = req.SharedService.MCC,
                RiskManagement = req.SharedService.RiskManagement,
                Treasury = req.SharedService.Treasury
            };
        }

    }

    #endregion

    #region ARM Trustee 
    public class ManagementConcernARMTrustee : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernRiskRating))]
        public Guid ManagementConcernRiskRatingId { get; set; }
        [ForeignKey(nameof(ManagementConcernRiskRatingId))]
        public ManagementConcernRiskRating ManagementConcernRiskRating { get; set; }
        public ManagementConcernBusinessUnitARMTrusteeRating BusinessAndBusinessUnit { get; set; }
        public ManagementConcernSharedServiceARTrusteeRating SharedService { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static ManagementConcernARMTrustee Create(Guid managementConcernRiskRatingId, string requesterName, string comment)
        {
            return new ManagementConcernARMTrustee
            {
                ManagementConcernRiskRatingId = managementConcernRiskRatingId,
                RequesterName = requesterName,
                Comment = comment
            };
        }
    }
    public class ManagementConcernBusinessUnitARMTrusteeRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMTrustee))]
        public Guid ManagementConcernARMTrusteeId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrivateTrust { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CommercialTrust { get; set; }

        public static ManagementConcernBusinessUnitARMTrusteeRating Create(ManagementConcernARMTrusteeReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernBusinessUnitARMTrusteeRating
            {
                ManagementConcernARMTrusteeId = managementConcernRiskRatingId,
                CommercialTrust = req.BusinessAndBusinessUnit.CommercialTrust,
                PrivateTrust = req.BusinessAndBusinessUnit.PrivateTrust
            };
        }

    }
    public class ManagementConcernSharedServiceARTrusteeRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMTrustee))]
        public Guid ManagementConcernARMTrusteeId { get; set; }
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
        public decimal InformationSecurity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CorporateStrategy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Treasury { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Academy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinancialControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Compliance { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DataAnalytic { get; set; }

        public static ManagementConcernSharedServiceARTrusteeRating Create(ManagementConcernARMTrusteeReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernSharedServiceARTrusteeRating
            {
                ManagementConcernARMTrusteeId = managementConcernRiskRatingId,
                HCM = req.SharedService.HCM,
                CorporateStrategy = req.SharedService.CorporateStrategy,
                CTO = req.SharedService.CTO,
                IT = req.SharedService.IT,
                InformationSecurity = req.SharedService.InformationSecurity,
                FinancialControl = req.SharedService.FinancialControl,
                DataAnalytic = req.SharedService.DataAnalytic,
                Compliance = req.SharedService.FinancialControl,
                CustomerExperience = req.SharedService.Compliance,
                ProcurementAndAdmin = req.SharedService.ProcurementAndAdmin,
                InternalControl = req.SharedService.InternalControl,
                Legal = req.SharedService.Legal,
                MCC = req.SharedService.MCC,
                RiskManagement = req.SharedService.RiskManagement,
                Academy = req.SharedService.Academy,
                Treasury = req.SharedService.Treasury
            };
        }

    }

    #endregion

    #region ARM Security 
    public class ManagementConcernARMSecurity : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernRiskRating))]
        public Guid ManagementConcernRiskRatingId { get; set; }
        [ForeignKey(nameof(ManagementConcernRiskRatingId))]
        public ManagementConcernRiskRating ManagementConcernRiskRating { get; set; }
        public ManagementConcernBusinessUnitARMSecurityRating BusinessAndBusinessUnit { get; set; }
        public ManagementConcernSharedServiceARMSecurityRating SharedService { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static ManagementConcernARMSecurity Create(Guid managementConcernRiskRatingId, string requesterName, string comment)
        {
            return new ManagementConcernARMSecurity
            {
                ManagementConcernRiskRatingId = managementConcernRiskRatingId,
                RequesterName = requesterName,
                Comment = comment
            };
        }

    }
    public class ManagementConcernBusinessUnitARMSecurityRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMSecurity))]
        public Guid ManagementConcernARMSecurityId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InvestmentBanking { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal StockBroking { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Research { get; set; }

        public static ManagementConcernBusinessUnitARMSecurityRating Create(ManagementConcernARMSecurityReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernBusinessUnitARMSecurityRating
            {
                ManagementConcernARMSecurityId = managementConcernRiskRatingId,
                InvestmentBanking = 0,
                StockBroking = req.BusinessAndBusinessUnit.StockBroking,
                Research = 0
            };
        }

    }

    public class ManagementConcernSharedServiceARMSecurityRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMSecurity))]
        public Guid ManagementConcernARMSecurityId { get; set; }
        public ManagementConcernARMSecurity ManagementConcernARMSecurity { get; set; }
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
        public decimal InformationSecurity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CorporateStrategy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Academy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Treasury { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Compliance { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DataAnalytic { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinancialControl { get; set; }

        public static ManagementConcernSharedServiceARMSecurityRating Create(ManagementConcernARMSecurityReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernSharedServiceARMSecurityRating
            {
                ManagementConcernARMSecurityId = managementConcernRiskRatingId,
                HCM = req.SharedService.HCM,
                CorporateStrategy = req.SharedService.CorporateStrategy,
                CTO = req.SharedService.CTO,
                IT = req.SharedService.IT,
                InformationSecurity = req.SharedService.InformationSecurity,
                Compliance = req.SharedService.Compliance,
                FinancialControl = req.SharedService.FinancialControl,
                DataAnalytic = req.SharedService.DataAnalytic,
                CustomerExperience = req.SharedService.CustomerExperience,
                ProcurementAndAdmin = req.SharedService.ProcurementAndAdmin,
                InternalControl = req.SharedService.InternalControl,
                Legal = req.SharedService.Legal,
                MCC = req.SharedService.MCC,
                RiskManagement = req.SharedService.RiskManagement,
                Academy = req.SharedService.Academy,
                Treasury = req.SharedService.Treasury
            };
        }

    }

    #endregion

    #region ARM Hill
    public class ManagementConcernARMHill : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ManagementConcernRiskRatingId { get; set; }
        [ForeignKey(nameof(ManagementConcernRiskRatingId))]
        public ManagementConcernRiskRating ManagementConcernRiskRating { get; set; }
        public ManagementConcernBusinessUnitARMHillRating BusinessAndBusinessUnit { get; set; }
        public ManagementConcernSharedServiceARMHillRating SharedService { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static ManagementConcernARMHill Create(Guid managementConcernRiskRatingId, string requesterName, string comment)
        {
            return new ManagementConcernARMHill
            {
                ManagementConcernRiskRatingId = managementConcernRiskRatingId,
                RequesterName = requesterName,
                Comment = comment
            };
        }
    }
    public class ManagementConcernBusinessUnitARMHillRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMHill))]
        public Guid ManagementConcernARMHillId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMHill { get; set; }

        public static ManagementConcernBusinessUnitARMHillRating Create(ManagementConcernARMHillReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernBusinessUnitARMHillRating
            {
                ManagementConcernARMHillId = managementConcernRiskRatingId,
                ARMHill = req.BusinessAndBusinessUnit.ARMHill
            };
        }

    }

    public class ManagementConcernSharedServiceARMHillRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMHill))]
        public Guid ManagementConcernARMHillId { get; set; }
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
        public decimal Academy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CTO { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CustomerExperience { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InformationSecurity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CorporateStrategy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Treasury { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Compliance { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinancialControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DataAnalytic { get; set; }

        public static ManagementConcernSharedServiceARMHillRating Create(ManagementConcernARMHillReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernSharedServiceARMHillRating
            {
                ManagementConcernARMHillId = managementConcernRiskRatingId,
                HCM = req.SharedService.HCM,
                CorporateStrategy = req.SharedService.CorporateStrategy,
                CTO = req.SharedService.CTO,
                IT = req.SharedService.IT,
                InformationSecurity = req.SharedService.InformationSecurity,
                DataAnalytic = req.SharedService.DataAnalytic,
                Compliance = req.SharedService.Compliance,
                FinancialControl = req.SharedService.FinancialControl,
                CustomerExperience = req.SharedService.CustomerExperience,
                ProcurementAndAdmin = req.SharedService.ProcurementAndAdmin,
                InternalControl = req.SharedService.InternalControl,
                Legal = req.SharedService.Legal,
                MCC = req.SharedService.MCC,
                Academy = req.SharedService.Academy,
                RiskManagement = req.SharedService.RiskManagement,
                Treasury = req.SharedService.Treasury
            };
        }

    }

    #endregion 

    #region ARM Agribusiness
    public class ManagementConcernARMAgribusiness : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ManagementConcernRiskRatingId { get; set; }
        [ForeignKey(nameof(ManagementConcernRiskRatingId))]
        public ManagementConcernRiskRating ManagementConcernRiskRating { get; set; }
        public ManagementConcernBusinessUnitARMAgribusinessRating BusinessAndBusinessUnit { get; set; }
        public ManagementConcernSharedServiceARMAgribusinessRating SharedService { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }
        public static ManagementConcernARMAgribusiness Create(Guid managementConcernRiskRatingId, string requesterName, string comment)
        {
            return new ManagementConcernARMAgribusiness
            {
                ManagementConcernRiskRatingId = managementConcernRiskRatingId,
                RequesterName = requesterName,
                Comment = comment
            };

        }
    }
    public class ManagementConcernBusinessUnitARMAgribusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMAgribusiness))]
        public Guid ManagementConcernARMAgribusinessId { get; set; }
        public ManagementConcernARMAgribusiness ManagementConcernARMAgribusiness { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RFL { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AAFML { get; set; }
        public static ManagementConcernBusinessUnitARMAgribusinessRating Create(ManagementConcernARMAgribusinessReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernBusinessUnitARMAgribusinessRating
            {
                ManagementConcernARMAgribusinessId = managementConcernRiskRatingId,
                RFL = req.BusinessAndBusinessUnit.RFL,
                AAFML = req.BusinessAndBusinessUnit.AAFML,
            };
        }

    }

    public class ManagementConcernSharedServiceARMAgribusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMAgribusiness))]
        public Guid ManagementConcernARMAgribusinessId { get; set; }
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
        public decimal InformationSecurity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CorporateStrategy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Treasury { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Academy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DataAnalytic { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinancialControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Compliance { get; set; }
        public static ManagementConcernSharedServiceARMAgribusinessRating Create(ManagementConcernARMAgribusinessReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernSharedServiceARMAgribusinessRating
            {
                ManagementConcernARMAgribusinessId = managementConcernRiskRatingId,
                HCM = req.SharedService.HCM,
                CorporateStrategy = req.SharedService.CorporateStrategy,
                CTO = req.SharedService.CTO,
                IT = req.SharedService.IT,
                InformationSecurity = req.SharedService.InformationSecurity,
                FinancialControl = req.SharedService.FinancialControl,
                Compliance = req.SharedService.Compliance,
                DataAnalytic = req.SharedService.DataAnalytic,
                CustomerExperience = req.SharedService.CustomerExperience,
                ProcurementAndAdmin = req.SharedService.ProcurementAndAdmin,
                InternalControl = req.SharedService.InternalControl,
                Legal = req.SharedService.Legal,
                MCC = req.SharedService.MCC,
                RiskManagement = req.SharedService.RiskManagement,
                Academy = req.SharedService.Academy,
                Treasury = req.SharedService.Treasury
            };

        }

    }

    #endregion

    #region DFS
    public class ManagementConcernDFS : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ManagementConcernRiskRatingId { get; set; }
        [ForeignKey(nameof(ManagementConcernRiskRatingId))]
        public ManagementConcernRiskRating ManagementConcernRiskRating { get; set; }
        public ManagementConcernBusinessUnitDFSRating BusinessAndBusinessUnit { get; set; }
        public ManagementConcernSharedServiceDFSRating SharedService { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static ManagementConcernDFS Create(Guid managementConcernRiskRatingId, string requesterName, string comment)
        {
            return new ManagementConcernDFS
            {
                ManagementConcernRiskRatingId = managementConcernRiskRatingId,
                RequesterName = requesterName,
                Comment = comment
            };
        }
    }
    public class ManagementConcernBusinessUnitDFSRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernDFS))]
        public Guid ManagementConcernDFSId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DigitalFinancialService { get; set; }

        public static ManagementConcernBusinessUnitDFSRating Create(ManagementConcernDFSReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernBusinessUnitDFSRating
            {
                ManagementConcernDFSId = managementConcernRiskRatingId,
                DigitalFinancialService = req.BusinessAndBusinessUnit.DigitalFinancialService
            };
        }

    }

    public class ManagementConcernSharedServiceDFSRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernDFS))]
        public Guid ManagementConcernDFSId { get; set; }
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
        public decimal Academy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CTO { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CustomerExperience { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InformationSecurity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CorporateStrategy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Treasury { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Compliance { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinancialControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DataAnalytic { get; set; }

        public static ManagementConcernSharedServiceDFSRating Create(ManagementConcernDFSReq req, Guid managementConcernRiskRatingId)
        {
            return new ManagementConcernSharedServiceDFSRating
            {
                ManagementConcernDFSId = managementConcernRiskRatingId,
                HCM = req.SharedService.HCM,
                CorporateStrategy = req.SharedService.CorporateStrategy,
                CTO = req.SharedService.CTO,
                IT = req.SharedService.IT,
                InformationSecurity = req.SharedService.InformationSecurity,
                DataAnalytic = req.SharedService.DataAnalytic,
                Compliance = req.SharedService.Compliance,
                FinancialControl = req.SharedService.FinancialControl,
                CustomerExperience = req.SharedService.CustomerExperience,
                ProcurementAndAdmin = req.SharedService.ProcurementAndAdmin,
                InternalControl = req.SharedService.InternalControl,
                Legal = req.SharedService.Legal,
                MCC = req.SharedService.MCC,
                Academy = req.SharedService.Academy,
                RiskManagement = req.SharedService.RiskManagement,
                Treasury = req.SharedService.Treasury
            };
        }

    }

    #endregion

    #region ARM Capital
    public class ManagementConcernARMCapital : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ManagementConcernRiskRatingId { get; set; }
        [ForeignKey(nameof(ManagementConcernRiskRatingId))]
        public ManagementConcernRiskRating ManagementConcernRiskRating { get; set; }
        public ManagementConcernBusinessUnitARMCapitalRating BusinessAndBusinessUnit { get; set; }
        public ManagementConcernSharedServiceARMCapitalRating SharedService { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Comment { get; set; }

        public static ManagementConcernARMCapital Create(Guid managementConcernRiskRatingId, string requesterName, string comment)
        {
            return new ManagementConcernARMCapital
            {
                ManagementConcernRiskRatingId = managementConcernRiskRatingId,
                RequesterName = requesterName,
                Comment = comment
            };
        }
    }
    public class ManagementConcernBusinessUnitARMCapitalRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMCapital))]
        public Guid ManagementConcernARMCapitalId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ARMCapital { get; set; }

        public static ManagementConcernBusinessUnitARMCapitalRating Create(ManagementConcernARMCapitalReq req, Guid managementConcernARMCapitalId)
        {
            return new ManagementConcernBusinessUnitARMCapitalRating
            {
                ManagementConcernARMCapitalId = managementConcernARMCapitalId,
                ARMCapital = req.BusinessAndBusinessUnit.ARMCapital
            };
        }

    }

    public class ManagementConcernSharedServiceARMCapitalRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ManagementConcernARMCapital))]
        public Guid ManagementConcernARMCapitalId { get; set; }
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
        public decimal Academy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CTO { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CustomerExperience { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InformationSecurity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InternalControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CorporateStrategy { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Treasury { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Compliance { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinancialControl { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DataAnalytic { get; set; }

        public static ManagementConcernSharedServiceARMCapitalRating Create(ManagementConcernARMCapitalReq req, Guid managementConcernARMCapitalId)
        {
            return new ManagementConcernSharedServiceARMCapitalRating
            {
                ManagementConcernARMCapitalId = managementConcernARMCapitalId,
                HCM = req.SharedService.HCM,
                CorporateStrategy = req.SharedService.CorporateStrategy,
                CTO = req.SharedService.CTO,
                IT = req.SharedService.IT,
                InformationSecurity = req.SharedService.InformationSecurity,
                DataAnalytic = req.SharedService.DataAnalytic,
                Compliance = req.SharedService.Compliance,
                FinancialControl = req.SharedService.FinancialControl,
                CustomerExperience = req.SharedService.CustomerExperience,
                ProcurementAndAdmin = req.SharedService.ProcurementAndAdmin,
                InternalControl = req.SharedService.InternalControl,
                Legal = req.SharedService.Legal,
                MCC = req.SharedService.MCC,
                Academy = req.SharedService.Academy,
                RiskManagement = req.SharedService.RiskManagement,
                Treasury = req.SharedService.Treasury
            };
        }

    }

    #endregion 
}
