using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.Risk;
using Arm.GrcTool.Domain.RiskEvent;
using GrcApi.Modules.Shared.SessionManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;

namespace Arm.GrcApi.Models
{
    public class GrcToolDbContext : DbContext
    {
        public DbSet<LogManagement> LogManagement { get; set; }

        public DbSet<IncidentManagementLog> IncidentManagementLog { get; set; }
        public DbSet<AuditPlanningMemoPlanningTimeline> AuditPlanningMemoPlanningTimeline { get; set; }
        public DbSet<ReportDetailfindings> ReportDetailfindings { get; set; }
        public DbSet<ReportDistributionList> ReportDistributionList { get; set; }
        public DbSet<AssessmentOfDigitalInitiativeList> AssessmentOfDigitalInitiativeList { get; set; }
        public DbSet<AuditUniverseARMCapitalRating> AuditUniverseARMCapitalRating { get; set; }
        public DbSet<ManagementConcernSharedServiceARMCapitalRating> ManagementConcernSharedServiceARMCapitalRating { get; set; }
        public DbSet<ManagementConcernBusinessUnitARMCapitalRating> ManagementConcernBusinessUnitARMCapitalRating { get; set; }
        public DbSet<OperationARMCapitalRating> OperationARMCapitalRating { get; set; }
        public DbSet<FinancialARMCapital> FinancialARMCapital { get; set; }
        public DbSet<StrategyARMCapitalRating> StrategyARMCapitalRating { get; set; }
        public DbSet<ComplianceARMCapital> ComplianceARMCapital { get; set; }
        public DbSet<ComplianceBusinessARMCapitalRating> ComplianceBusinessARMCapitalRating { get; set; }
        public DbSet<TimeSinceLastAuditARMCapital> TimeSinceLastAuditARMCapital { get; set; }
        public DbSet<ARMCapitalEMCRating> ARMCapitalEMCRating { get; set; }
        public DbSet<ManagementConcernBusinessUnitARMIMRating> ManagementConcernBusinessUnitARMIMRating { get; set; }
        public DbSet<AuditUniverseARMIMResearch> AuditUniverseARMIMResearch { get; set; }
        public DbSet<FinacialIMRatingResearch> FinacialIMRatingResearch { get; set; }
        public DbSet<StrategyIMRatingResearch> StrategyIMRatingResearch { get; set; }
        public DbSet<OperationIMRatingResearch> OperationIMRatingResearch { get; set; }
        public DbSet<OperationARMCapital> OperationARMCapital { get; set; }
        public DbSet<ManagementConcernARMCapital> ManagementConcernARMCapital { get; set; }
        public DbSet<FinacialBusinessARMCapitalRating> FinacialBusinessARMCapitalRating { get; set; }
        public DbSet<ARMCapitalAuditUniverse> ARMCapitalAuditUniverse { get; set; }        
        public DbSet<InternalControlExceptionTracker> InternalControlExceptionTracker { get; set; }
        public DbSet<InternalControlModel> InternalControlModel { get; set; }
        public DbSet<InternalControlActionOwner> InternalControlActionOwner { get; set; }
        public DbSet<ComplianceRegulatoryPayment> ComplianceRegulatoryPayment { get; set; }
        public DbSet<ComplianceRules> ComplianceRules { get; set; }
        public DbSet<ComplianceRegulator> ComplianceRegulator { get; set; }
        public DbSet<ComplianceBusines> ComplianceBusines { get; set; }
        public DbSet<RatedBusinessRiskRating> RatedBusinessRiskRating { get; set; }
        public DbSet<ARMHoldingCompanyEMCRating> ARMHoldingCompanyEMCRating { get; set; }
        public DbSet<ARMIMEMCRating> ARMIMEMCRating { get; set; }
        public DbSet<ARMSecurityEMCRating> ARMSecurityEMCRating { get; set; }
        public DbSet<ARMTrusteeEMCRating> ARMTrusteeEMCRating { get; set; }
        public DbSet<ARMHILLEMCRating> ARMHILLEMCRating { get; set; }
        public DbSet<ARMAgribusinessEMCRating> ARMAgribusinessEMCRating { get; set; }
        public DbSet<ARMSharedServiceEMCRating> ARMSharedServiceEMCRating { get; set; }
        public DbSet<EMCConcernRiskRating> EMCConcernRiskRating { get; set; }
        public DbSet<ManagementConcernRiskRating> ManagementConcernRiskRating { get; set; }
        public DbSet<ManagementConcernARMIM> ManagementConcernARMIM { get; set; }
        public DbSet<ManagementConcernSharedServiceARMIMRating> ManagementConcernSharedServiceARMIMRating { get; set; }
        public DbSet<ManagementConcernSharedServiceARMSecurityRating> ManagementConcernSharedServiceARMSecurityRating { get; set; }
        public DbSet<ManagementConcernBusinessUnitARMSecurityRating> ManagementConcernBusinessUnitARMSecurityRating { get; set; }
        public DbSet<ManagementConcernARMSecurity> ManagementConcernARMSecurity { get; set; }
        public DbSet<ManagementConcernSharedServiceARTrusteeRating> ManagementConcernSharedServiceARTrusteeRating { get; set; }
        public DbSet<ManagementConcernBusinessUnitARMTrusteeRating> ManagementConcernBusinessUnitARMTrusteeRating { get; set; }
        public DbSet<ManagementConcernARMTrustee> ManagementConcernARMTrustee { get; set; }
        public DbSet<ManagementConcernSharedServiceARMHillRating> ManagementConcernSharedServiceARMHillRating { get; set; }
        public DbSet<ManagementConcernBusinessUnitARMHillRating> ManagementConcernBusinessUnitARMHillRating { get; set; }
        public DbSet<ManagementConcernARMHill> ManagementConcernARMHill { get; set; }
        public DbSet<ManagementConcernBusinessUnitARMAgribusinessRating> ManagementConcernBusinessUnitARMAgribusinessRating { get; set; }
        public DbSet<ManagementConcernSharedServiceARMAgribusinessRating> ManagementConcernSharedServiceARMAgribusinessRating { get; set; }
        public DbSet<ManagementConcernARMAgribusiness> ManagementConcernARMAgribusiness { get; set; }

        public DbSet<ARMHoldingCompanyBusinessRating> ARMHoldingCompanyBusinessRating { get; set; }
        public DbSet<StrategyBusinessRatingARMHoldCo> StrategyBusinessRatingARMHoldCo { get; set; }
        public DbSet<StrategyBusinessArmHoldCo> StrategyBusinessArmHoldCo { get; set; }
        public DbSet<StrategyBusinessTreasurySale> StrategyBusinessTreasurySale { get; set; }
        public DbSet<OperationBusinessRatingARMHoldCo> OperationBusinessRatingARMHoldCo { get; set; }
        public DbSet<OperationBusinessTreasurySale> OperationBusinessTreasurySale { get; set; }
        public DbSet<OperationBusinessArmHolco> OperationBusinessArmHolco { get; set; }
        public DbSet<FinacialRatingBusinessratingTreasurySale> FinacialRatingBusinessratingTreasurySale { get; set; }
        public DbSet<FinancialReportingBusinessratingARMHoldCo> FinancialReportingBusinessratingARMHoldCo { get; set; }
        public DbSet<FinacialRatingBusinessratingARMHoldCo> FinacialRatingBusinessratingARMHoldCo { get; set; }
        public DbSet<ComplianceBusinessRatingARMHoldCo> ComplianceBusinessRatingARMHoldCo { get; set; }
        public DbSet<CompliancesBusinessRiskRatingARMHoldCo> CompliancesBusinessRiskRatingARMHoldCo { get; set; }
        public DbSet<CompliancesBusinessTreasurySale> CompliancesBusinessTreasurySale { get; set; }
        public DbSet<TimeSinceLastAuditBusinessRatingARMHoldCo> TimeSinceLastAuditBusinessRatingARMHoldCo { get; set; }
        public DbSet<TimeSinceLastBusinessARMTAMAudit> TimeSinceLastBusinessARMTAMAudit { get; set; }
        public DbSet<ComplianceBusinessTAMRating> ComplianceBusinessTAMRating { get; set; }
        public DbSet<FinacialBusinessTAMRating> FinacialBusinessTAMRating { get; set; }
        public DbSet<ComplianceBusinessARMTAM> ComplianceBusinessARMTAM { get; set; }
        public DbSet<FinancialBusinessARMTAM> FinancialBusinessARMTAM { get; set; }
        public DbSet<OperationBusinessARMTAM> OperationBusinessARMTAM { get; set; }
        public DbSet<StrategyBusinessTAMRating> StrategyBusinessTAMRating { get; set; }
        public DbSet<StrategyBusinessARMTAM> StrategyBusinessARMTAM { get; set; }
        public DbSet<ARMTAMBusinessRiskRating> ARMTAMBusinessRiskRating { get; set; }
        public DbSet<OperationBusinessTAMRating> OperationBusinessTAMRating { get; set; }
        public DbSet<FinacialIMRatingARMRegistrar> FinacialIMRatingARMRegistrar { get; set; }
        public DbSet<FinancialIMBusinessRating> FinancialIMBusinessRating { get; set; }
        public DbSet<ComplianceIMBusinessRating> ComplianceIMBusinessRating { get; set; }
        public DbSet<ComplianceIMRatingFundAccount> ComplianceIMRatingFundAccount { get; set; }
        public DbSet<FinacialIMRatingOperationSettlement> FinacialIMRatingOperationSettlement { get; set; }
        public DbSet<ComplianceIMRatingOperationControl> ComplianceIMRatingOperationControl { get; set; }
        public DbSet<TimeSinceLastAuditIMBusinessRating> TimeSinceLastAuditIMBusinessRating { get; set; }
        public DbSet<ComplianceIMRatingFundAdmin> ComplianceIMRatingFundAdmin { get; set; }
        public DbSet<ComplianceIMRating> ComplianceIMRating { get; set; }
        public DbSet<ComplianceIMRatingBDPWMIAMIMRetail> ComplianceIMRatingBDPWMIAMIMRetail { get; set; }
        public DbSet<FinacialIMRatingOperationControl> FinacialIMRatingOperationControl { get; set; }
        public DbSet<ComplianceIMRatingARMRegistrar> ComplianceIMRatingARMRegistrar { get; set; }
        public DbSet<ComplianceIMRatingOperationSettlement> ComplianceIMRatingOperationSettlement { get; set; }
        public DbSet<FinacialIMRatingFundAccount> FinacialIMRatingFundAccount { get; set; }
        public DbSet<ComplianceIMRatingRetailOperation> ComplianceIMRatingRetailOperation { get; set; }
        public DbSet<FinacialIMRatingBDPWMIAMIMRetail> FinacialIMRatingBDPWMIAMIMRetail { get; set; }
        public DbSet<FinacialIMBusinessRating> FinacialIMBusinessRating { get; set; }
        public DbSet<FinacialIMRatingFundAdmin> FinacialIMRatingFundAdmin { get; set; }
        public DbSet<FinacialIMRatingRetailOperation> FinacialIMRatingRetailOperation { get; set; }
        public DbSet<StrategyIMRatingARMRegistrar> StrategyIMRatingARMRegistrar { get; set; }
        public DbSet<StrategyIMRatingBDPWMIAMIMRetail> StrategyIMRatingBDPWMIAMIMRetail { get; set; }
        public DbSet<StrategyIMRating> StrategyIMRating { get; set; }
        public DbSet<StrategyIMRatingFundAccount> StrategyIMRatingFundAccount { get; set; }
        public DbSet<StrategyIMRatingFundAdmin> StrategyIMRatingFundAdmin { get; set; }
        public DbSet<StrategyIMRatingRetailOperation> StrategyIMRatingRetailOperation { get; set; }
        public DbSet<StrategyIMRatingOperationSettlement> StrategyIMRatingOperationSettlement { get; set; }
        public DbSet<StrategyIMRatingOperationControl> StrategyIMRatingOperationControl { get; set; }
        public DbSet<StrategyImBusinessRating> StrategyImBusinessRating { get; set; }
        public DbSet<ARMIMBusinessRiskRating> ARMIMBusinessRiskRating { get; set; }
        public DbSet<OperationIMRatingARMRegistrar> OperationIMRatingARMRegistrar { get; set; }
        public DbSet<OperationIMRatingRetailOperation> OperationIMRatingRetailOperation { get; set; }
        public DbSet<OperationIMRatingFundAdmin> OperationIMRatingFundAdmin { get; set; }
        public DbSet<OperationIMRatingFundAccount> OperationIMRatingFundAccount { get; set; }
        public DbSet<OperationIMRatingBDPWMIAMIMRetail> OperationIMRatingBDPWMIAMIMRetail { get; set; }
        public DbSet<OperationIMBusinessRating> OperationIMBusinessRating { get; set; }
        public DbSet<OperationIMRatingOperationSettlement> OperationIMRatingOperationSettlement { get; set; }
        public DbSet<OperationIMUnitRating> OperationIMUnitRating { get; set; }
        public DbSet<OperationIMRatingOperationControl> OperationIMRatingOperationControl { get; set; }
        public DbSet<TimeSinceLastSecurityAudit> TimeSinceLastSecurityAudit { get; set; }
        public DbSet<ComplianceSecurity> ComplianceSecurity { get; set; }
        public DbSet<ARMSecurityRating> ARMSecurityRating { get; set; }
        public DbSet<StrategySecurityRatingStockBroking> StrategySecurityRatingStockBroking { get; set; }
        public DbSet<FinacialSecurityRatingStockBroking> FinacialSecurityRatingStockBroking { get; set; }
        public DbSet<ComplianceSecurityRatingStockBroking> ComplianceSecurityRatingStockBroking { get; set; }
        public DbSet<OperationSecurityBusinessRating> OperationSecurityBusinessRating { get; set; }
        public DbSet<StrategySecurityBusinessRating> StrategySecurityBusinessRating { get; set; }
        public DbSet<FinancialSecurityReporting> FinancialSecurityReporting { get; set; }
        public DbSet<OperationSecurityRatingStockBroking> OperationSecurityRatingStockBroking { get; set; }
        public DbSet<ComplianceBusinessRatingTrustee> ComplianceBusinessRatingTrustee { get; set; }
        public DbSet<FinacialTrusteeRatingCommercialTrust> FinacialTrusteeRatingCommercialTrust { get; set; }
        public DbSet<ComplianceTrusteeRatingPrivateTrust> ComplianceTrusteeRatingPrivateTrust { get; set; }
        public DbSet<TimeSinceLastTrusteeAudit> TimeSinceLastTrusteeAudit { get; set; }
        public DbSet<FinacialTrusteeRatingPrivateTrust> FinacialTrusteeRatingPrivateTrust { get; set; }
        public DbSet<ComplianceTrusteeRatingCommercialTrust> ComplianceTrusteeRatingCommercialTrust { get; set; }
        public DbSet<FinancialTrusteeReporting> FinancialTrusteeReporting { get; set; }
        public DbSet<OperationTrustee> OperationTrustee { get; set; }
        public DbSet<OperationTrusteeRatingCommercialTrust> OperationTrusteeRatingCommercialTrust { get; set; }
        public DbSet<OperationTrusteeRatingPrivateTrust> OperationTrusteeRatingPrivateTrust { get; set; }
        public DbSet<StrategyTrusteeRatingPrivateTrust> StrategyTrusteeRatingPrivateTrust { get; set; }
        public DbSet<StrategyTrusteeRatingCommercialTrust> StrategyTrusteeRatingCommercialTrust { get; set; }
        public DbSet<ARMTrusteeRating> ARMTrusteeRating { get; set; }
        public DbSet<StrategyBusinessRatingTrustee> StrategyBusinessRatingTrustee { get; set; }
        public DbSet<ComplianceHillRating> ComplianceHillRating { get; set; }
        public DbSet<TimeSinceLastHillAudit> TimeSinceLastHillAudit { get; set; }
        public DbSet<ComplianceBusinessRatingHill> ComplianceBusinessRatingHill { get; set; }
        public DbSet<StrategyHillRating> StrategyHillRating { get; set; }
        public DbSet<FinancialHillReporting> FinancialHillReporting { get; set; }
        public DbSet<OperationBusinessRatingHill> OperationBusinessRatingHill { get; set; }
        public DbSet<FinacialHillRating> FinacialHillRating { get; set; }
        public DbSet<OperationHillRating> OperationHillRating { get; set; }
        public DbSet<StrategyBusinessRatingARMHill> StrategyBusinessRatingARMHill { get; set; }
        public DbSet<ARMHillRating> ARMHillRating { get; set; }
        public DbSet<ComplianceAgribusiness> ComplianceAgribusiness { get; set; }
        public DbSet<FinacialAgribusinessRatingAAFML> FinacialAgribusinessRatingAAFML { get; set; }
        public DbSet<ComplianceAgribusinessRatingAAFML> ComplianceAgribusinessRatingAAFML { get; set; }
        public DbSet<ComplianceAgribusinessRatingRFl> ComplianceAgribusinessRatingRFl { get; set; }
        public DbSet<FinacialAgribusinessRatingRFl> FinacialAgribusinessRatingRFl { get; set; }
        public DbSet<TimeSinceLastAgribusinessAudit> TimeSinceLastAgribusinessAudit { get; set; }
        public DbSet<FinancialAgribusinessReporting> FinancialAgribusinessReporting { get; set; }
        public DbSet<OperationAgribusiness> OperationAgribusiness { get; set; }
        public DbSet<StrategyAgribusinessRatingAAFML> StrategyAgribusinessRatingAAFML { get; set; }
        public DbSet<OperationAgribusinessRatingRFl> OperationAgribusinessRatingRFl { get; set; }
        public DbSet<StrategyAgribusinessRatingRFl> StrategyAgribusinessRatingRFl { get; set; }
        public DbSet<OperationAgribusinessRatingAAFML> OperationAgribusinessRatingAAFML { get; set; }
        public DbSet<StrategyAgribusiness> StrategyAgribusiness { get; set; }
        public DbSet<ARMAgribusinessRating> ARMAgribusinessRating { get; set; }
        public DbSet<ComplianceSharedService> ComplianceSharedService { get; set; }
        public DbSet<ComplianceSharedServiceRatingMCC> ComplianceSharedServiceRatingMCC { get; set; }
        public DbSet<ComplianceSharedServiceRatingHCM> ComplianceSharedServiceRatingHCM { get; set; }
        public DbSet<ComplianceSharedServiceRatingProcurementAndAdmin> ComplianceSharedServiceRatingProcurementAndAdmin { get; set; }
        public DbSet<ComplianceSharedServiceRatingCTO> ComplianceSharedServiceRatingCTO { get; set; }
        public DbSet<ComplianceSharedServiceRatingInformationSecurity> ComplianceSharedServiceRatingInformationSecurity { get; set; }
        public DbSet<ComplianceSharedServiceRatingLegal> ComplianceSharedServiceRatingLegal { get; set; }
        public DbSet<TimeSinceLastSharedServiceAudit> TimeSinceLastSharedServiceAudit { get; set; }
        public DbSet<ComplianceSharedServiceRatingCustomerexperience> ComplianceSharedServiceRatingCustomerexperience { get; set; }
        public DbSet<ComplianceSharedServiceRatingIT> ComplianceSharedServiceRatingIT { get; set; }
        public DbSet<ComplianceSharedServiceRatingRiskManagement> ComplianceSharedServiceRatingRiskManagement { get; set; }
        public DbSet<ComplianceSharedServiceRatingAcademy> ComplianceSharedServiceRatingAcademy { get; set; }
        public DbSet<ComplianceSharedServiceRatingCorporatestrategy> ComplianceSharedServiceRatingCorporatestrategy { get; set; }
        public DbSet<ComplianceSharedServiceRatingTreasury> ComplianceSharedServiceRatingTreasury { get; set; }
        public DbSet<ComplianceSharedServiceRatingInternalControl> ComplianceSharedServiceRatingInternalControl { get; set; }
        public DbSet<OperationSharedServiceRatingLegal> OperationSharedServiceRatingLegal { get; set; }
        public DbSet<OperationSharedServiceRatingHCM> OperationSharedServiceRatingHCM { get; set; }
        public DbSet<OperationSharedServiceRatingCustomerexperience> OperationSharedServiceRatingCustomerexperience { get; set; }
        public DbSet<OperationSharedServiceRatingCorporatestrategy> OperationSharedServiceRatingCorporatestrategy { get; set; }
        public DbSet<OperationSharedServiceRatingCTO> OperationSharedServiceRatingCTO { get; set; }
        public DbSet<OperationSharedServiceRatingTreasury> OperationSharedServiceRatingTreasury { get; set; }
        public DbSet<OperationSharedServiceRatingInternalControl> OperationSharedServiceRatingInternalControl { get; set; }
        public DbSet<OperationSharedServiceRatingRiskManagement> OperationSharedServiceRatingRiskManagement { get; set; }
        public DbSet<OperationSharedServiceRatingMCC> OperationSharedServiceRatingMCC { get; set; }
        public DbSet<OperationSharedServiceRatingIT> OperationSharedServiceRatingIT { get; set; }
        public DbSet<OperationSharedServiceRatingInformationSecurity> OperationSharedServiceRatingInformationSecurity { get; set; }
        public DbSet<OperationSharedServiceRatingAcademy> OperationSharedServiceRatingAcademy { get; set; }
        public DbSet<OperationSharedServiceRatingProcurementAndAdmin> OperationSharedServiceRatingProcurementAndAdmin { get; set; }
        public DbSet<OperationSharedService> OperationSharedService { get; set; }
        public DbSet<StrategySharedService> StrategySharedService { get; set; }
        public DbSet<StrategySharedServiceRatingAcademy> StrategySharedServiceRatingAcademy { get; set; }
        public DbSet<StrategySharedServiceRatingCorporatestrategy> StrategySharedServiceRatingCorporatestrategy { get; set; }
        public DbSet<StrategySharedServiceRatingCustomerexperience> StrategySharedServiceRatingCustomerexperience { get; set; }
        public DbSet<StrategySharedServiceRatingTreasury> StrategySharedServiceRatingTreasury { get; set; }
        public DbSet<StrategySharedServiceRatingIT> StrategySharedServiceRatingIT { get; set; }
        public DbSet<StrategySharedServiceRatingProcurementAndAdmin> StrategySharedServiceRatingProcurementAndAdmin { get; set; }
        public DbSet<StrategySharedServiceRatingCTO> StrategySharedServiceRatingCTO { get; set; }
        public DbSet<StrategySharedServiceRatingInternalControl> StrategySharedServiceRatingInternalControl { get; set; }
        public DbSet<StrategySharedServiceRatingHCM> StrategySharedServiceRatingHCM { get; set; }
        public DbSet<StrategySharedServiceRatingMCC> StrategySharedServiceRatingMCC { get; set; }
        public DbSet<StrategySharedServiceRatingInformationSecurity> StrategySharedServiceRatingInformationSecurity { get; set; }
        public DbSet<StrategySharedServiceRatingLegal> StrategySharedServiceRatingLegal { get; set; }
        public DbSet<StrategySharedServiceRatingRiskManagement> StrategySharedServiceRatingRiskManagement { get; set; }
        public DbSet<ARMSharedServiceRating> ARMSharedServiceRating { get; set; }
        public DbSet<ARMTAMAuditUniverse> ARMTAMAuditUniverse { get; set; }
        public DbSet<AuditUniverseARMTAM> AuditUniverseARMTAM { get; set; }
        public DbSet<AuditUniverseARMHoldCoTreasurySale> AuditUniverseARMHoldCoTreasurySale { get; set; }
        public DbSet<AuditUniverseARMHoldingCompany> AuditUniverseARMHoldingCompany { get; set; }
        public DbSet<ARMHoldingCompanyAnnualAuditUniverse> ARMHoldingCompanyAnnualAuditUniverse { get; set; }
        public DbSet<AuditUniverseARMIMIMUnit> AuditUniverseARMIMIMUnit { get; set; }
        public DbSet<AuditUniverseARMIMBDPWMIAMIMRetail> AuditUniverseARMIMBDPWMIAMIMRetail { get; set; }
        public DbSet<AuditUniverseARMIMFundAccount> AuditUniverseARMIMFundAccount { get; set; }
        public DbSet<AuditUniverseARMIMFundAdmin> AuditUniverseARMIMFundAdmin { get; set; }
        public DbSet<AuditUniverseARMIMRetailOperation> AuditUniverseARMIMRetailOperation { get; set; }
        public DbSet<AuditUniverseARMIMRegistrar> AuditUniverseARMIMRegistrar { get; set; }
        public DbSet<AnualAuditUniverseRiskRating> AnualAuditUniverseRiskRating { get; set; }
        public DbSet<ARMIMAuditUniverse> ARMIMAuditUniverse { get; set; }
        public DbSet<AuditUniverseARMIMOperationControl> AuditUniverseARMIMOperationControl { get; set; }
        public DbSet<AuditUniverseARMIMOperationSettlement> AuditUniverseARMIMOperationSettlement { get; set; }
        public DbSet<AuditUniverseARMSecurityStockBroking> AuditUniverseARMSecurityStockBroking { get; set; }
        public DbSet<AuditUniverseARMSecurityInvestmentBanking> AuditUniverseARMSecurityInvestmentBanking { get; set; }
        public DbSet<AuditUniverseARMSecurityResearch> AuditUniverseARMSecurityResearch { get; set; }
        public DbSet<ARMSecurityAnnualAuditUniverse> ARMSecurityAnnualAuditUniverse { get; set; }
        public DbSet<AuditUniverseARMTrusteeCommercialTrust> AuditUniverseARMTrusteeCommercialTrust { get; set; }
        public DbSet<AuditUniverseARMHill> AuditUniverseARMHill { get; set; }
        public DbSet<AuditUniverseARMTrusteePrivateTrust> AuditUniverseARMTrusteePrivateTrust { get; set; }
        public DbSet<ARMHillAuditUniverse> ARMHillAuditUniverse { get; set; }
        public DbSet<ARMTrusteeAuditUniverse> ARMTrusteeAuditUniverse { get; set; }
        public DbSet<ARMAgribusinessAuditUniverse> ARMAgribusinessAuditUniverse { get; set; }
        public DbSet<AuditUniverseARMAgribusinessRFL> AuditUniverseARMAgribusinessRFL { get; set; }
        public DbSet<AuditUniverseARMAgribusinessAAFML> AuditUniverseARMAgribusinessAAFML { get; set; }
        public DbSet<ARMSharedAuditUniverseCustomerExperience> ARMSharedAuditUniverseCustomerExperience { get; set; }
        public DbSet<ARMSharedAuditUniverseInformationSecurity> ARMSharedAuditUniverseInformationSecurity { get; set; }
        public DbSet<ARMSharedAuditUniverseLegal> ARMSharedAuditUniverseLegal { get; set; }
        public DbSet<ARMSharedAuditUniverseProcurementAndAdmin> ARMSharedAuditUniverseProcurementAndAdmin { get; set; }
        public DbSet<ARMSharedAuditUniverseCorporatestrategy> ARMSharedAuditUniverseCorporatestrategy { get; set; }
        public DbSet<ARMSharedAuditUniverseAcademy> ARMSharedAuditUniverseAcademy { get; set; }
        public DbSet<ARMSharedAuditUniverseTreasury> ARMSharedAuditUniverseTreasury { get; set; }
        public DbSet<ARMSharedAuditUniverseMCC> ARMSharedAuditUniverseMCC { get; set; }
        public DbSet<ARMSharedAuditUniverseHCM> ARMSharedAuditUniverseHCM { get; set; }
        public DbSet<ARMSharedAuditUniverseIT> ARMSharedAuditUniverseIT { get; set; }
        public DbSet<ARMSharedAuditUniverseInternalControl> ARMSharedAuditUniverseInternalControl { get; set; }
        public DbSet<ARMSharedAuditUniverseCTO> ARMSharedAuditUniverseCTO { get; set; }
        public DbSet<ARMSharedAuditUniverseRiskManagement> ARMSharedAuditUniverseRiskManagement { get; set; }
        public DbSet<ARMSharedAuditUniverse> ARMSharedAuditUniverse { get; set; }
        public DbSet<MonthlyARMHillRating> MonthlyARMHillRating { get; set; }
        public DbSet<MonthlyARMIMRating> MonthlyARMIMRating { get; set; }
        public DbSet<MonthlyARMTrusteeRating> MonthlyARMTrusteeRating { get; set; }
        public DbSet<MonthlyARMAgribusinessRating> MonthlyARMAgribusinessRating { get; set; }
        public DbSet<MonthlyARMSecurityRating> MonthlyARMSecurityRating { get; set; }
        public DbSet<MonthlyARMHoldingCompanyRating> MonthlyARMHoldingCompanyRating { get; set; }
        public DbSet<MonthlyARMSharedServiceRating> MonthlyARMSharedServiceRating { get; set; }

        public DbSet<EngagementLetterAuditExecutionDuration> EngagementLetterAuditExecutionDuration { get; set; }
        public DbSet<InformationRequirementAuditExecution> InformationRequirementAuditExecution { get; set; }
        public DbSet<EngagementLetterAuditExecution> EngagementLetterAuditExecution { get; set; }
        public DbSet<EngagementLetterReportDistributionList> EngagementLetterReportDistributionList { get; set; }
        public DbSet<CommenceEngagementAuditexecution> CommenceEngagementAuditexecution { get; set; }
        public DbSet<AuditPlanningMemoAuditExecution> AuditPlanningMemoAuditExecution { get; set; }
        public DbSet<AuditProgramAuditExecution> AuditProgramAuditExecution { get; set; }
        public DbSet<AuditAnnouncementMemoAuditExecution> AuditAnnouncementMemoAuditExecution { get; set; }

        public DbSet<AuditFindingAuditReport> AuditFindingAuditReport { get; set; }
        public DbSet<InternalAuditRatingReport> InternalAuditRatingReport { get; set; }
        public DbSet<ManagementResponseAuditReport> ManagementResponseAuditReport { get; set; }
        public DbSet<ObservationListAuditReport> ObservationListAuditReport { get; set; }
        public DbSet<CitationAuditReport> CitationAuditReport { get; set; }
        public DbSet<InternalAuditReport> InternalAuditReport { get; set; }
        public DbSet<ConsolidatedAuditFinding> ConsolidatedAuditFinding { get; set; }
        public DbSet<ConsolidatedAuditFindingActionDetail> ConsolidatedAuditFindingActionDetail { get; set; }
        public DbSet<SessionTracker> SessionTracker { get; set; }
        public GrcToolDbContext(DbContextOptions<GrcToolDbContext> options)
         : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //runs all our configurations implementing IEntityTypeConfiguration<TEntity>

            // configure risk event relationships
            modelBuilder.Entity<BusinessEntity>()
                .HasMany<RiskEvent>()
                .WithOne()
                .HasForeignKey(r => r.BusinessEntityId);

            modelBuilder.Entity<Department>()
                .HasMany<RiskEvent>()
                .WithOne()
                .HasForeignKey(r => r.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<Unit>()
                .HasMany<RiskEvent>()
                .WithOne()
                .HasForeignKey(r => r.UnitId)
                .IsRequired();

            // configure RiskEventManagement
            modelBuilder.Entity<RiskEvent>()
                .HasMany<RiskEventManagement>()
                .WithOne()
                .HasForeignKey(r => r.RiskEventId)
                .IsRequired();

            modelBuilder.Entity<RiskDriver>()
                .HasMany<RiskEventManagement>()
                .WithOne()
                .HasForeignKey(r => r.RiskDriverId)
                .IsRequired();

            modelBuilder.Entity<RiskDriverCategory>()
                .HasMany<RiskEventManagement>()
                .WithOne()
                .HasForeignKey(r => r.RiskDriverCategoryId)
                .IsRequired();

            modelBuilder.Entity<RiskDriverSubCategory>()
                .HasMany<RiskEventManagement>()
                .WithOne()
                .HasForeignKey(r => r.RiskDriverSubCategoryId)
                .IsRequired();

            modelBuilder.Entity<RiskEventType>()
                .HasMany<RiskEventManagement>()
                .WithOne()
                .HasForeignKey(r => r.EventTypeId)
                .IsRequired();

            modelBuilder.Entity<RiskEventTypeCategory>()
                .HasMany<RiskEventManagement>()
                .WithOne()
                .HasForeignKey(r => r.EventCategoryId)
                .IsRequired();

            modelBuilder.Entity<RiskEventTypeSubCategory>()
                .HasMany<RiskEventManagement>()
                .WithOne()
                .HasForeignKey(r => r.EventSubCategoryId)
                .IsRequired();

            // configure RiskEffectManagement
            modelBuilder.Entity<RiskEvent>()
                .HasMany<RiskEffectManagement>()
                .WithOne()
                .HasForeignKey(r => r.RiskEventId)
                .IsRequired();

            modelBuilder.Entity<RiskEffectCategory>()
                .HasMany<RiskEffectManagement>()
                .WithOne()
                .HasForeignKey(r => r.EffectCategoryId)
                .IsRequired();

            // Configure ActionManagement
            modelBuilder.Entity<RiskEvent>()
                .HasMany<ActionManagement>()
                .WithOne()
                .HasForeignKey(k => k.RiskEventId)
                .IsRequired();

            // Configure LossManagement
            modelBuilder.Entity<RiskEvent>()
                .HasMany<LossManagement>()
                .WithOne()
                .HasForeignKey(k => k.RiskEventId)
                .IsRequired();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateOnly>()
                    .HaveConversion<DateOnlyConverter>()
                    .HaveColumnType("date");

            configurationBuilder.Properties<DateOnly?>()
                   .HaveConversion<NullableDateOnlyConverter>()
                   .HaveColumnType("date");

            configurationBuilder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>();

            configurationBuilder.Properties<TimeOnly?>()
                .HaveConversion<NullableTimeOnlyConverter>();

            configurationBuilder.Properties<string>().HaveMaxLength(50);

        }

        /// <summary>
        /// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
        /// </summary>
        public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public DateOnlyConverter() : base(
                    d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d))
            { }
        }

        /// <summary>
        /// Converts <see cref="DateOnly?" /> to <see cref="DateTime?"/> and vice versa.
        /// </summary>
        public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// </summary>
            public NullableDateOnlyConverter() : base(
                d => d == null
                    ? null
                    : new DateTime?(d.Value.ToDateTime(TimeOnly.MinValue)),
                d => d == null
                    ? null
                    : new DateOnly?(DateOnly.FromDateTime(d.Value)))
            { }
        }

        /// <summary>
        /// Converts <see cref="TimeOnly" /> to <see cref="TimeSpan"/> and vice versa.
        /// </summary>
        public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// Convert TimeOnly to Timespan and vice versa
            /// </summary>
            public TimeOnlyConverter() : base(
                timeOnly => timeOnly.ToTimeSpan(),
                timeSpan => TimeOnly.FromTimeSpan(timeSpan))
            {}
        }

        /// <summary>
        /// Converts <see cref="TimeOnly?" /> to <see cref="TimeSpan?"/> and vice versa.
        /// </summary>
        public class NullableTimeOnlyConverter : ValueConverter<TimeOnly?, TimeSpan?>
        {
            /// <summary>
            /// Creates a new instance of this converter.
            /// Convert TimeOnly to Timespan and vice versa
            /// </summary>
            public NullableTimeOnlyConverter() : base(
                timeOnly => timeOnly == null ? null : new TimeSpan?(timeOnly.Value.ToTimeSpan()),
                timeSpan => timeSpan == null ? null : new TimeOnly?(TimeOnly.FromTimeSpan(timeSpan.Value)))
            {}
        }
    }
}
