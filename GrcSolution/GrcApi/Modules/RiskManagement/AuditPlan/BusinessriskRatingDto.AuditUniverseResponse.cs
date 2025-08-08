using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class AuditUniverseResponse
    {

        public class AuditUniverseResp
        {
            public decimal BusinessManagerConcern { get; set; }
            public decimal DirectorConcern { get; set; }

            public string? RiskScore { get; set; }

            public string? OldRiskScore { get; set; }

            public string? RiskRating { get; set; }

            public string? Recommentation { get; set; }
        }


        #region ARMHoldingCompany         
        public class ARMHoldingCompanyAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp ARMHoldingCompany { get; set; }
            public AuditUniverseResp TreasurySale { get; set; }
        }

        #endregion

        #region ARMTAM     
        public class ARMTAMAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp ARMTAM { get; set; }          
        }
        #endregion

        #region ARMIM     
        public class ARMIMAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp ARMIM { get; set; }
            public AuditUniverseResp IMUnit { get; set; }
            public AuditUniverseResp BDPWMIAMIMRetail { get; set; }
            public AuditUniverseResp FundAccount { get; set; }
            public AuditUniverseResp FundAdmin { get; set; }
            public AuditUniverseResp RetailOperation { get; set; }
            public AuditUniverseResp ARMRegistrar { get; set; }
            public AuditUniverseResp OperationSettlement { get; set; }
            public AuditUniverseResp OperationControl { get; set; }
            public AuditUniverseResp Research { get; set; }
        }
        #endregion

        #region ARMSecurity
        public class ARMSecurityAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp StockBroking { get; set; }
        }
        #endregion

        #region ARMTrustee
        public class ARMTrusteeAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp PrivateTrust { get; set; }
            public AuditUniverseResp CommercialTrust { get; set; }
        }
        #endregion

        #region ARMHill
        public class ARMHillAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp ARMHill { get; set; }
        }
        #endregion
        #region DigitalFinancialService
        public class DigitalFinancialServiceAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp DigitalFinancialService { get; set; }
        }
        #endregion

        #region ARMCapital
        public class ARMCapitalAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp ARMCapital { get; set; }
        }
        #endregion

        #region ARMAgribusiness
        public class ARMAgribusinessAuditUniverseResp
        {
            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp RFL { get; set; }
            public AuditUniverseResp AAFML { get; set; }
        }
        #endregion

        #region ARMSharedService
        public class ARMSharedServiceAuditUniverseResp
        {

            public string BusinessName { get; set; }
            public Guid busnessRiskRatingId { get; set; }
            public AuditUniverseResp HCM { get; set; }
            public AuditUniverseResp InformationSecurity { get; set; }
            public AuditUniverseResp Treasury { get; set; }
            public AuditUniverseResp DataAnalytic { get; set; }
            public AuditUniverseResp Corporatestrategy { get; set; }
            public AuditUniverseResp InternalControl { get; set; }
            public AuditUniverseResp Customerexperience { get; set; }
            public AuditUniverseResp Academy { get; set; }
            public AuditUniverseResp CTO { get; set; }
            public AuditUniverseResp MCC { get; set; }
            public AuditUniverseResp Legal { get; set; }
            public AuditUniverseResp ProcurementAndAdmind { get; set; }
            public AuditUniverseResp IT { get; set; }
            public AuditUniverseResp RiskManagement { get; set; }
            public AuditUniverseResp Compliance { get; set; }
            public AuditUniverseResp FinancialControl { get; set; }
        }
        #endregion
    }
}
