using Arm.GrcApi.Modules.Shared;
using GrcApi.Modules.RiskManagement.AuditPlan;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{

    public class AnualAuditUniverseRiskRating : AuditEntity
    {
        [Key]       
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public string? RequesterName { get; set; }
        public ARMHoldingCompanyAnnualAuditUniverse ARMHoldingCompany { get; set; }
        public ARMTAMAuditUniverse ARMTAM { get; set; }
        public ARMIMAuditUniverse ARMIM { get; set; }
        public ARMSecurityAnnualAuditUniverse ARMSecurity { get; set; }
        public ARMTrusteeAuditUniverse ARMTrustee { get; set; }
        public ARMHillAuditUniverse ARMHill { get; set; }
        public ARMAgribusinessAuditUniverse ARMAgribusiness { get; set; }
        public DigitalFinancialServiceAuditUniverse DigitalFinancialService { get; set; }
        public ARMCapitalAuditUniverse ARMCapital { get; set; }
        public ARMSharedAuditUniverse ARMSharedService { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;

        public static AnualAuditUniverseRiskRating Create(string requesterName, Guid businessRiskRatingId)
        {
            return new AnualAuditUniverseRiskRating
            {
                RequesterName = requesterName,
                BusinessRiskRatingId = businessRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }
        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }

    }


    #region ARMHoldingCompany         
    public class ARMHoldingCompanyAnnualAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseARMHoldingCompany ARMHoldingCompany { get; set; }
        public AuditUniverseARMHoldCoTreasurySale TreasurySale { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public static ARMHoldingCompanyAnnualAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMHoldingCompanyAnnualAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }
        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }
    }
    public class AuditUniverseARMHoldingCompany : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHoldingCompanyAnnualAuditUniverse))]
        public Guid ARMHoldingCompanyAnnualAuditUniverseId { get; set; }
        public decimal BusinessManagerConcern { get; set; }
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMHoldingCompany Create(Guid id, string oldriskScore,
           decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)// AuditUniverseRequest req)
        {
            return new AuditUniverseARMHoldingCompany
            {
                ARMHoldingCompanyAnnualAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }
    }
    public class AuditUniverseARMHoldCoTreasurySale : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHoldingCompanyAnnualAuditUniverse))]
        public Guid ARMHoldingCompanyAnnualAuditUniverseId { get; set; }
        public decimal BusinessManagerConcern { get; set; }
        public decimal DirectorConcern { get; set; }
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

        public static AuditUniverseARMHoldCoTreasurySale Create(Guid id, string oldriskScore,
           decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMHoldCoTreasurySale
            {
                ARMHoldingCompanyAnnualAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class MonthlyARMHoldingCompanyRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHoldingCompanyAnnualAuditUniverse))]
        public Guid ARMHoldingCompanyAnnualAuditUniverseId { get; set; }
        public string? Business { get; set; }
        public string? Team { get; set; }
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

        public static MonthlyARMHoldingCompanyRating CreateCalendar(Guid aRMHoldingCompanyAnnualAuditUniverseId, string business, string team, string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            return new MonthlyARMHoldingCompanyRating
            {
                ARMHoldingCompanyAnnualAuditUniverseId = aRMHoldingCompanyAnnualAuditUniverseId,
                Business = business,
                Team = team,
                January = jan,
                February = feb,
                March = mar,
                April = apr,
                May = may,
                June = jun,
                July = jul,
                August = aug,
                September = sept,
                October = oct,
                November = nov,
                December = dec,
            };
        }

    }

    #endregion

    #region ARMTAM     
    public class ARMTAMAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseARMTAM ARMTAM { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;

        public static ARMTAMAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMTAMAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }
        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }

    }
    public class AuditUniverseARMTAM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTAMAuditUniverse))]
        public Guid ARMTAMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMTAM Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMTAM
            {
                ARMTAMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    #endregion

    #region ARMIM     
    public class ARMIMAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseARMIMRating ARMIM { get; set; }
        public AuditUniverseARMIMIMUnit IMUnit { get; set; }
        public AuditUniverseARMIMBDPWMIAMIMRetail BDPWMIAMIMRetail { get; set; }
        public AuditUniverseARMIMFundAccount FundAccount { get; set; }
        public AuditUniverseARMIMFundAdmin FundAdmin { get; set; }
        public AuditUniverseARMIMRetailOperation RetailOperation { get; set; }
        public AuditUniverseARMIMRegistrar ARMRegistrar { get; set; }
        public AuditUniverseARMIMOperationSettlement OperationSettlement { get; set; }
        public AuditUniverseARMIMOperationControl OperationControl { get; set; }
        public AuditUniverseARMIMResearch Research { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public static ARMIMAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMIMAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }
        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }
    }
    public class AuditUniverseARMIMResearch : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMResearch Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMResearch
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMOperationControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMOperationControl Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMOperationControl
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMOperationSettlement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMOperationSettlement Create(Guid id, string oldriskScore,
        decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMOperationSettlement
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMRating Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMRating
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMRegistrar : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMRegistrar Create(Guid id, string oldriskScore,
         decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMRegistrar
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMRetailOperation : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMRetailOperation Create(Guid id, string oldriskScore,
         decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMRetailOperation
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMFundAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMFundAdmin Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMFundAdmin
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMFundAccount : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMFundAccount Create(Guid id, string oldriskScore,
       decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMFundAccount
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMBDPWMIAMIMRetail : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMBDPWMIAMIMRetail Create(Guid id, string oldriskScore,
        decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMBDPWMIAMIMRetail
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMIMIMUnit : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMIMIMUnit Create(Guid id, string oldriskScore,
         decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMIMIMUnit
            {
                ARMIMAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class MonthlyARMIMRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMIMAuditUniverse))]
        public Guid ARMIMAuditUniverseId { get; set; }
        public string? Business { get; set; }
        public string? Team { get; set; }
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

        public static MonthlyARMIMRating CreateCalendar(Guid aRMIMAuditUniverseId, string business, string team, string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            return new MonthlyARMIMRating
            {
                ARMIMAuditUniverseId = aRMIMAuditUniverseId,
                Business = business,
                Team = team,
                January = jan,
                February = feb,
                March = mar,
                April = apr,
                May = may,
                June = jun,
                July = jul,
                August = aug,
                September = sept,
                October = oct,
                November = nov,
                December = dec,
            };
        }

    }

    #endregion

    #region ARMSecurity
    public class ARMSecurityAnnualAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseARMSecurityStockBroking StockBroking { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public static ARMSecurityAnnualAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMSecurityAnnualAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }
        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }
    }

    public class AuditUniverseARMSecurityResearch : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityAnnualAuditUniverse))]
        public Guid ARMSecurityAnnualAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMSecurityResearch Create(Guid id, string oldriskScore,
         decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMSecurityResearch
            {
                ARMSecurityAnnualAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMSecurityStockBroking : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityAnnualAuditUniverse))]
        public Guid ARMSecurityAnnualAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMSecurityStockBroking Create(Guid id, string oldriskScore,
        decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMSecurityStockBroking
            {
                ARMSecurityAnnualAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMSecurityInvestmentBanking : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityAnnualAuditUniverse))]
        public Guid ARMSecurityAnnualAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMSecurityInvestmentBanking Create(Guid id, string oldriskScore,
        decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMSecurityInvestmentBanking
            {
                ARMSecurityAnnualAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class MonthlyARMSecurityRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSecurityAnnualAuditUniverse))]
        public Guid ARMSecurityAnnualAuditUniverseId { get; set; }
        public string? Business { get; set; }
        public string? Team { get; set; }
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

        public static MonthlyARMSecurityRating CreateCalendar(Guid aRMSecurityAnnualAuditUniverseId, string business, string team, string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            return new MonthlyARMSecurityRating
            {
                ARMSecurityAnnualAuditUniverseId = aRMSecurityAnnualAuditUniverseId,
                Business = business,
                Team = team,
                January = jan,
                February = feb,
                March = mar,
                April = apr,
                May = may,
                June = jun,
                July = jul,
                August = aug,
                September = sept,
                October = oct,
                November = nov,
                December = dec,
            };
        }

    }

    #endregion

    #region ARMTrustee
    public class ARMTrusteeAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseARMTrusteePrivateTrust PrivateTrust { get; set; }
        public AuditUniverseARMTrusteeCommercialTrust CommercialTrust { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public static ARMTrusteeAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMTrusteeAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }
        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }
    }

    public class AuditUniverseARMTrusteeCommercialTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTrusteeAuditUniverse))]
        public Guid ARMTrusteeAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMTrusteeCommercialTrust Create(Guid id, string oldriskScore,
            decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMTrusteeCommercialTrust
            {
                ARMTrusteeAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMTrusteePrivateTrust : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTrusteeAuditUniverse))]
        public Guid ARMTrusteeAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMTrusteePrivateTrust Create(Guid id, string oldriskScore,
           decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMTrusteePrivateTrust
            {
                ARMTrusteeAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class MonthlyARMTrusteeRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMTrusteeAuditUniverse))]
        public Guid ARMTrusteeAuditUniverseId { get; set; }
        public string? Business { get; set; }
        public string? Team { get; set; }
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

        public static MonthlyARMTrusteeRating CreateCalendar(Guid aRMTrusteeAuditUniverseId, string business, string team, string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            return new MonthlyARMTrusteeRating
            {
                ARMTrusteeAuditUniverseId = aRMTrusteeAuditUniverseId,
                Business = business,
                Team = team,
                January = jan,
                February = feb,
                March = mar,
                April = apr,
                May = may,
                June = jun,
                July = jul,
                August = aug,
                September = sept,
                October = oct,
                November = nov,
                December = dec,
            };
        }

    }

    #endregion

    #region ARMHill
    public class ARMHillAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseARMHill ARMHill { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public static ARMHillAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMHillAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }

        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }
    }

    public class AuditUniverseARMHill : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHillAuditUniverse))]
        public Guid ARMHillAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMHill Create(Guid id, string oldriskScore,
        decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMHill
            {
                ARMHillAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class MonthlyARMHillRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMHillAuditUniverse))]
        public Guid ARMHillAuditUniverseId { get; set; }
        public string? Business { get; set; }
        public string? Team { get; set; }
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

        public static MonthlyARMHillRating CreateCalendar(Guid aRMHillAuditUniverseId, string business, string team, string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            return new MonthlyARMHillRating
            {
                ARMHillAuditUniverseId = aRMHillAuditUniverseId,
                Business = business,
                Team = team,
                January = jan,
                February = feb,
                March = mar,
                April = apr,
                May = may,
                June = jun,
                July = jul,
                August = aug,
                September = sept,
                October = oct,
                November = nov,
                December = dec,
            };
        }

    }

    #endregion

    #region ARMAgribusiness
    public class ARMAgribusinessAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseARMAgribusinessRFL RFL { get; set; }
        public AuditUniverseARMAgribusinessAAFML AAFML { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public static ARMAgribusinessAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMAgribusinessAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }

        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }
    }

    public class AuditUniverseARMAgribusinessAAFML : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMAgribusinessAuditUniverse))]
        public Guid ARMAgribusinessAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMAgribusinessAAFML Create(Guid id, string oldriskScore,
           decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMAgribusinessAAFML
            {
                ARMAgribusinessAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class AuditUniverseARMAgribusinessRFL : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMAgribusinessAuditUniverse))]
        public Guid ARMAgribusinessAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMAgribusinessRFL Create(Guid id, string oldriskScore,
           decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMAgribusinessRFL
            {
                ARMAgribusinessAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class MonthlyARMAgribusinessRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMAgribusinessAuditUniverse))]
        public Guid ARMAgribusinessAuditUniverseId { get; set; }
        public string? Business { get; set; }
        public string? Team { get; set; }
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

        public static MonthlyARMAgribusinessRating CreateCalendar(Guid aRMAgribusinessAuditUniverseId, string business, string team, string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            return new MonthlyARMAgribusinessRating
            {
                ARMAgribusinessAuditUniverseId = aRMAgribusinessAuditUniverseId,
                Business = business,
                Team = team,
                January = jan,
                February = feb,
                March = mar,
                April = apr,
                May = may,
                June = jun,
                July = jul,
                August = aug,
                September = sept,
                October = oct,
                November = nov,
                December = dec,
            };
        }

    }

    #endregion

    #region DigitalFinancialService     
    public class DigitalFinancialServiceAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseDigitalFinancialServiceRating DigitalFinancialService { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;

        public static DigitalFinancialServiceAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new DigitalFinancialServiceAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }
        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }

    }
    public class AuditUniverseDigitalFinancialServiceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(DigitalFinancialServiceAuditUniverse))]
        public Guid DigitalFinancialServiceAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseDigitalFinancialServiceRating Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseDigitalFinancialServiceRating
            {
                DigitalFinancialServiceAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    #endregion

    #region ARMCapital     
    public class ARMCapitalAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public AuditUniverseARMCapitalRating ARMCapital { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;

        public static ARMCapitalAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMCapitalAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }
        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }

    }
    public class AuditUniverseARMCapitalRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMCapitalAuditUniverse))]
        public Guid ARMCapitalAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static AuditUniverseARMCapitalRating Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new AuditUniverseARMCapitalRating
            {
                ARMCapitalAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }
        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    #endregion

    #region Shared
    public class ARMSharedAuditUniverse : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(AnualAuditUniverseRiskRating))]
        public Guid AnualAuditUniverseRiskRatingId { get; set; }
        public string? RequesterName { get; set; }
        [ForeignKey(nameof(AnualAuditUniverseRiskRatingId))]
        public AnualAuditUniverseRiskRating AnualAuditUniverseRiskRating { get; set; }
        public ARMSharedAuditUniverseIT IT { get; set; }
        public ARMSharedAuditUniverseHCM HCM { get; set; }
        public ARMSharedAuditUniverseMCC MCC { get; set; }
        public ARMSharedAuditUniverseAcademy Academy { get; set; }
        public ARMSharedAuditUniverseInformationSecurity InformationSecurity { get; set; }
        public ARMSharedAuditUniverseTreasury Treasury { get; set; }
        public ARMSharedAuditUniverseDataAnalytic DataAnalytic { get; set; }
        public ARMSharedAuditUniverseCompliance Compliance { get; set; }
        public ARMSharedAuditUniverseFinancialControl FinancialControl { get; set; }
        public ARMSharedAuditUniverseLegal Legal { get; set; }
        public ARMSharedAuditUniverseCorporatestrategy Corporatestrategy { get; set; }
        public ARMSharedAuditUniverseCTO CTO { get; set; }
        public ARMSharedAuditUniverseInternalControl InternalControl { get; set; }
        public ARMSharedAuditUniverseCustomerExperience CustomerExperience { get; set; }
        public ARMSharedAuditUniverseProcurementAndAdmin ProcurementAndAdmin { get; set; }
        public ARMSharedAuditUniverseRiskManagement RiskManagement { get; set; }
        public BusinessRiskRatingStatus AnualAuditUniverseStatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus EngagementPlan { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus WorkPaper { get; set; } = BusinessRiskRatingStatus.Pending;
        public BusinessRiskRatingStatus Findingstatus { get; set; } = BusinessRiskRatingStatus.Pending;
        public static ARMSharedAuditUniverse Create(string requesterName, Guid anualAuditUniverseRiskRatingId)
        {
            return new ARMSharedAuditUniverse
            {
                RequesterName = requesterName,
                AnualAuditUniverseRiskRatingId = anualAuditUniverseRiskRatingId,
                AnualAuditUniverseStatus = BusinessRiskRatingStatus.Completed
            };
        }

        public void Update(string requesterName)
        {
            RequesterName = requesterName;
        }
    }

    public class ARMSharedAuditUniverseRiskManagement : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseRiskManagement Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseRiskManagement
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseProcurementAndAdmin : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseProcurementAndAdmin Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseProcurementAndAdmin
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseCustomerExperience : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseCustomerExperience Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseCustomerExperience
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseInternalControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseInternalControl Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseInternalControl
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseCorporatestrategy : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseCorporatestrategy Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseCorporatestrategy
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseCTO : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseCTO Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseCTO
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseLegal : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseLegal Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseLegal
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }
    public class ARMSharedAuditUniverseFinancialControl : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseFinancialControl Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseFinancialControl
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseCompliance : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseCompliance Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseCompliance
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseTreasury : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseTreasury Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseTreasury
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseInformationSecurity : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseInformationSecurity Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseInformationSecurity
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseAcademy : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseAcademy Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseAcademy
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseMCC : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseMCC Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseMCC
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseIT : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseIT Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseIT
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseDataAnalytic : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseDataAnalytic Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseDataAnalytic
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }

    public class ARMSharedAuditUniverseHCM : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? RequesterName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BusinessManagerConcern { get; set; }
        public string? OldRiskScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DirectorConcern { get; set; }
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
        public static ARMSharedAuditUniverseHCM Create(Guid id, string oldriskScore,
          decimal businessManagerConcern, decimal directorConcern, string riskScore, string riskRating, string recommentation)
        {
            return new ARMSharedAuditUniverseHCM
            {
                ARMSharedAuditUniverseId = id,
                OldRiskScore = oldriskScore,
                BusinessManagerConcern = businessManagerConcern,
                DirectorConcern = directorConcern,
                RiskScore = riskScore,
                RiskRating = riskRating,
                Recommentation = recommentation
            };
        }

        public void UpdateMonth(string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            January = jan;
            February = feb;
            March = mar;
            April = apr;
            May = may;
            June = jun;
            July = jul;
            August = aug;
            September = sept;
            October = oct;
            November = nov;
            December = dec;
        }

    }


    public class MonthlyARMSharedServiceRating : AuditEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(ARMSharedAuditUniverse))]
        public Guid ARMSharedAuditUniverseId { get; set; }
        public string? Business { get; set; }
        public string? Team { get; set; }
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

        public static MonthlyARMSharedServiceRating CreateCalendar(Guid aRMSharedAuditUniverseId, string business, string team, string jan, string feb, string mar, string apr, string may, string jun, string jul, string aug, string sept, string oct, string nov, string dec)
        {
            return new MonthlyARMSharedServiceRating
            {
                ARMSharedAuditUniverseId = aRMSharedAuditUniverseId,
                Business = business,
                Team = team,
                January = jan,
                February = feb,
                March = mar,
                April = apr,
                May = may,
                June = jun,
                July = jul,
                August = aug,
                September = sept,
                October = oct,
                November = nov,
                December = dec,
            };
        }

    }

    #endregion

}
