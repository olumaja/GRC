using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToRCSAProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "WorkPaper",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "VulnerabilityModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "UserRolePermission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "UserRoleMap",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "UserRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Unit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastTrusteeAudit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastSharedServiceAudit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastSecurityAudit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastHillAudit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastBusinessARMTAMAudit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastAuditIMBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastAuditDigitalFinancialService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastAuditBusinessRatingARMHoldCo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastAuditARMCapital",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TimeSinceLastAgribusinessAudit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyTrusteeRatingPrivateTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyTrusteeRatingCommercialTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingTreasury",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingRiskManagement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingProcurementAndAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingMCC",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingLegal",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingIT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingInternalControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingInformationSecurity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingHCM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingCustomerexperience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingCTO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingCorporatestrategy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingAcademy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceFinancialControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceDataAnalytic",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedServiceCompliance",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySharedService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySecurityRatingStockBroking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategySecurityBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingRetailOperation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingResearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingOperationSettlement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingOperationControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingFundAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingFundAccount",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingBDPWMIAMIMRetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingARMRegistrar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRatingARMIM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyIMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyImBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyHillRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyDigitalFinancialServiceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyDigitalFinancialService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyBusinessTreasurySale",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyBusinessTAMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyBusinessRatingTrustee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyBusinessRatingARMHoldCo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyBusinessRatingARMHill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyBusinessARMTAM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyBusinessArmHoldCo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyARMCapitalRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyARMCapital",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyAgribusinessRatingRFl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyAgribusinessRatingAAFML",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "StrategyAgribusiness",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "SIEMLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "SessionTracker",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RSCAProcess",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitiatedBy",
                table: "RSCAProcess",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "RSCAProcess",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoftDeletedBy",
                table: "RSCAProcess",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskEventTypeSubCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskEventTypeCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskEventType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskEventManagement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskEvent",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskEffectManagement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskEffectCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskDriverSubCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskDriverCategory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskDriver",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskControlSelfAssessmentUnit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RiskControlSelfAssessment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ReportDistributionList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ReportDetailfindings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RecoveryType",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "RatedBusinessRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ProductRiskAssessment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ProductAssessRisk",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ProcessInherentRiskControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Permission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "PAMLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationTrusteeRatingPrivateTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationTrusteeRatingCommercialTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationTrustee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingTreasury",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingRiskManagement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingProcurementAndAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingMCC",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingLegal",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingIT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingInternalControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingInformationSecurity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingHCM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingCustomerexperience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingCTO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingCorporatestrategy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingAcademy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceFinancialControlRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceDataAnalyticRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedServiceComplianceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSharedService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSecurityRatingStockBroking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationSecurityBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMUnitRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMRatingRetailOperation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMRatingResearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMRatingOperationSettlement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMRatingOperationControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMRatingFundAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMRatingFundAccount",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMRatingBDPWMIAMIMRetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMRatingARMRegistrar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationIMBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationHillRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationDigitalFinancialServiceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationDigitalFinancialService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationBusinessTreasurySale",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationBusinessTAMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationBusinessRatingHill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationBusinessRatingARMHoldCo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationBusinessARMTAM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationBusinessArmHolco",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationARMIMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationARMCapitalRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationARMCapital",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationAgribusinessRatingRFl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationAgribusinessRatingAAFML",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "OperationAgribusiness",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ObservationListAuditReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "MonthlyARMTrusteeRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "MonthlyARMSharedServiceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "MonthlyARMSecurityRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "MonthlyARMIMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "MonthlyARMHoldingCompanyRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "MonthlyARMHillRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "MonthlyARMAgribusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementResponseAuditReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceDFSRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARTrusteeRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMSecurityRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMIMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMHillRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMCapitalRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMAgribusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernDFS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitDFSRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMTrusteeRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMSecurityRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMIMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMHillRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMCapitalRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMAgribusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernARMTrustee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernARMSecurity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernARMIM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernARMHill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernARMCapital",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ManagementConcernARMAgribusiness",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "LossManagement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "LogManagement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalVulnerability",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalControlModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalControlExceptionTracker",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalControlDashboard",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalControlCallOverReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalControlCallOver",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalControlActionOwner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalControlAction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalAuditReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InternalAuditRatingReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "InformationRequirementAuditExecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "IncidentManagementLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialTrusteeReporting",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialSecurityReporting",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialReportingBusinessratingARMHoldCo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialIMBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialHillReporting",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialDigitalFinancialService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialBusinessARMTAM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialARMCapital",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinancialAgribusinessReporting",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialTrusteeRatingPrivateTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialTrusteeRatingCommercialTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialSecurityRatingStockBroking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialRatingBusinessratingTreasurySale",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialRatingBusinessratingARMHoldCo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMRatingRetailOperation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMRatingResearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMRatingOperationSettlement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMRatingOperationControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMRatingFundAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMRatingFundAccount",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMRatingBDPWMIAMIMRetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMRatingARMRegistrar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialIMBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialHillRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialBusinessTAMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialBusinessDigitalFinancialServiceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialBusinessARMCapitalRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialARMIMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialAgribusinessRatingRFl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FinacialAgribusinessRatingAAFML",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "FIMLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "EngagementLetterReportDistributionList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "EngagementLetterAuditExecutionDuration",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "EngagementLetterAuditExecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "EMCConcernRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Email",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "EDRLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "DocumentRSCAProcessLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "DocumentRSCAProcess",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Document",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "DLPLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "DigitalFinancialServiceEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "DigitalFinancialServiceBusinessRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "DigitalFinancialServiceAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Department",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "DAMLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ConsolidatedAuditFindingActionDetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ConsolidatedAuditFinding",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceTrusteeRatingPrivateTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceTrusteeRatingCommercialTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceStatutoryPayment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingTreasury",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingRiskManagement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingProcurementAndAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingMCC",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingLegal",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingIT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingInternalControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingInformationSecurity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingHCM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingCustomerexperience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingCTO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingCorporatestrategy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingAcademy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceFinancialControlRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceDataAnalyticRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedServiceComplianceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSharedService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSecurityRatingStockBroking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceSecurity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "CompliancesBusinessTreasurySale",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "CompliancesBusinessRiskRatingARMHoldCo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceRulesBusiness",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceRules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceRegulatoryPayment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceRegulator",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingRetailOperation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingResearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingOperationSettlement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingOperationControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingFundAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingFundAccount",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingBDPWMIAMIMRetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingARMRegistrar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRatingARMIM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceIMBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceHillRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceDigitalFinancialService",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceDepartment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceCalendar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusinessTAMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusinessRatingTrustee",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusinessRatingHill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusinessRatingARMHoldCo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusinessDigitalFinancialServiceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusinessDepartment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusinessARMTAM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusinessARMCapitalRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceBusines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceARMCapital",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceAgribusinessRatingRFl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceAgribusinessRatingAAFML",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ComplianceAgribusiness",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "CommenceEngagementAuditexecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "CitationAuditReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "CASPLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "BusinessRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "BusinessImpactAnalysisUnitLog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "BusinessImpactAnalysisUnit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "BusinessImpactAnalysis",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "BusinessEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "BIAUnitProcessDetailsBusinessUnitToRunProcess",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "BIAUnitProcessDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseDigitalFinancialServiceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMTrusteePrivateTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMTrusteeCommercialTrust",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMTAM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMSecurityStockBroking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMSecurityResearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMSecurityInvestmentBanking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMRetailOperation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMResearch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMRegistrar",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMOperationSettlement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMOperationControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMIMUnit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMFundAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMFundAccount",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMIMBDPWMIAMIMRetail",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMHoldingCompany",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMHoldCoTreasurySale",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMHill",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMCapitalRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMAgribusinessRFL",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditUniverseARMAgribusinessAAFML",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditProgramAuditExecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditPlanningMemoPlanningTimeline",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditPlanningMemoAuditExecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditFindings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditFindingAuditReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AuditAnnouncementMemoAuditExecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AssessmentOfDigitalInitiativeList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMTrusteeRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMTrusteeEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMTrusteeAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMTAMEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMTAMBusinessRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMTAMAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedServiceRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedServiceEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseTreasury",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseRiskManagement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseProcurementAndAdmin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseMCC",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseLegal",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseIT",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseInternalControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseInformationSecurity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseHCM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseFinancialControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseDataAnalytic",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseCustomerExperience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseCTO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseCorporatestrategy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseCompliance",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseAcademy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSecurityRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSecurityEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMSecurityAnnualAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMIMEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMIMBusinessRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMIMAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMHoldingCompanyEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMHoldingCompanyBusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMHoldingCompanyAnnualAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMHillRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMHILLEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMHillAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMCapitalEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMCapitalBusinessRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMCapitalAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMAgribusinessRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMAgribusinessEMCRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ARMAgribusinessAuditUniverse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "AnualAuditUniverseRiskRating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ActionManagement",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "WorkPaper");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "VulnerabilityModel");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "UserRolePermission");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "UserRoleMap");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastTrusteeAudit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastSharedServiceAudit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastSecurityAudit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastHillAudit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastBusinessARMTAMAudit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastAuditIMBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastAuditDigitalFinancialService");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastAuditBusinessRatingARMHoldCo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastAuditARMCapital");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TimeSinceLastAgribusinessAudit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyTrusteeRatingPrivateTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyTrusteeRatingCommercialTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingTreasury");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingRiskManagement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingProcurementAndAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingMCC");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingLegal");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingIT");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingInternalControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingInformationSecurity");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingHCM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingCustomerexperience");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingCTO");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingCorporatestrategy");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceRatingAcademy");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceFinancialControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceDataAnalytic");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedServiceCompliance");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySharedService");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySecurityRatingStockBroking");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategySecurityBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingRetailOperation");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingResearch");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingOperationSettlement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingOperationControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingFundAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingFundAccount");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingBDPWMIAMIMRetail");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingARMRegistrar");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRatingARMIM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyIMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyImBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyHillRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyDigitalFinancialServiceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyDigitalFinancialService");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyBusinessTreasurySale");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyBusinessTAMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyBusinessRatingTrustee");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyBusinessRatingARMHoldCo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyBusinessRatingARMHill");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyBusinessARMTAM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyBusinessArmHoldCo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyARMCapitalRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyARMCapital");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyAgribusinessRatingRFl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyAgribusinessRatingAAFML");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "StrategyAgribusiness");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "SIEMLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "SessionTracker");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RSCAProcess");

            migrationBuilder.DropColumn(
                name: "InitiatedBy",
                table: "RSCAProcess");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RSCAProcess");

            migrationBuilder.DropColumn(
                name: "SoftDeletedBy",
                table: "RSCAProcess");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskEventTypeSubCategory");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskEventTypeCategory");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskEventType");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskEventManagement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskEvent");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskEffectManagement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskEffectCategory");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskDriverSubCategory");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskDriverCategory");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskDriver");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskControlSelfAssessmentUnit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RiskControlSelfAssessment");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ReportDistributionList");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ReportDetailfindings");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RecoveryType");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "RatedBusinessRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ProductRiskAssessment");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ProductAssessRisk");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ProcessInherentRiskControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "PAMLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationTrusteeRatingPrivateTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationTrusteeRatingCommercialTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationTrustee");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingTreasury");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingRiskManagement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingProcurementAndAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingMCC");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingLegal");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingIT");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingInternalControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingInformationSecurity");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingHCM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingCustomerexperience");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingCTO");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingCorporatestrategy");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceRatingAcademy");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceFinancialControlRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceDataAnalyticRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedServiceComplianceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSharedService");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSecurityRatingStockBroking");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationSecurityBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMUnitRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMRatingRetailOperation");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMRatingResearch");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMRatingOperationSettlement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMRatingOperationControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMRatingFundAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMRatingFundAccount");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMRatingBDPWMIAMIMRetail");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMRatingARMRegistrar");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationIMBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationHillRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationDigitalFinancialServiceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationDigitalFinancialService");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationBusinessTreasurySale");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationBusinessTAMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationBusinessRatingHill");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationBusinessRatingARMHoldCo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationBusinessARMTAM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationBusinessArmHolco");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationARMIMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationARMCapitalRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationARMCapital");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationAgribusinessRatingRFl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationAgribusinessRatingAAFML");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "OperationAgribusiness");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ObservationListAuditReport");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "MonthlyARMTrusteeRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "MonthlyARMSharedServiceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "MonthlyARMSecurityRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "MonthlyARMIMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "MonthlyARMHoldingCompanyRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "MonthlyARMHillRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "MonthlyARMAgribusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementResponseAuditReport");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceDFSRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARTrusteeRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMSecurityRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMIMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMHillRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMCapitalRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernSharedServiceARMAgribusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernDFS");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitDFSRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMTrusteeRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMSecurityRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMIMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMHillRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMCapitalRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernBusinessUnitARMAgribusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernARMTrustee");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernARMSecurity");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernARMIM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernARMHill");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernARMCapital");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ManagementConcernARMAgribusiness");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "LossManagement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "LogManagement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalVulnerability");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalControlModel");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalControlExceptionTracker");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalControlDashboard");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalControlCallOverReport");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalControlCallOver");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalControlActionOwner");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalControlAction");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalAuditReport");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InternalAuditRatingReport");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "InformationRequirementAuditExecution");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "IncidentManagementLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialTrusteeReporting");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialSecurityReporting");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialReportingBusinessratingARMHoldCo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialIMBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialHillReporting");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialDigitalFinancialService");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialBusinessARMTAM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialARMCapital");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinancialAgribusinessReporting");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialTrusteeRatingPrivateTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialTrusteeRatingCommercialTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialSecurityRatingStockBroking");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialRatingBusinessratingTreasurySale");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialRatingBusinessratingARMHoldCo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMRatingRetailOperation");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMRatingResearch");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMRatingOperationSettlement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMRatingOperationControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMRatingFundAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMRatingFundAccount");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMRatingBDPWMIAMIMRetail");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMRatingARMRegistrar");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialIMBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialHillRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialBusinessTAMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialBusinessDigitalFinancialServiceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialBusinessARMCapitalRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialARMIMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialAgribusinessRatingRFl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FinacialAgribusinessRatingAAFML");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "FIMLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "EngagementLetterReportDistributionList");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "EngagementLetterAuditExecutionDuration");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "EngagementLetterAuditExecution");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "EMCConcernRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Email");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "EDRLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "DocumentRSCAProcessLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "DocumentRSCAProcess");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "DLPLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "DigitalFinancialServiceEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "DigitalFinancialServiceBusinessRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "DigitalFinancialServiceAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "DAMLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ConsolidatedAuditFindingActionDetail");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ConsolidatedAuditFinding");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceTrusteeRatingPrivateTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceTrusteeRatingCommercialTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceStatutoryPayment");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingTreasury");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingRiskManagement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingProcurementAndAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingMCC");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingLegal");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingIT");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingInternalControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingInformationSecurity");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingHCM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingCustomerexperience");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingCTO");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingCorporatestrategy");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceRatingAcademy");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceFinancialControlRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceDataAnalyticRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedServiceComplianceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSharedService");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSecurityRatingStockBroking");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceSecurity");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "CompliancesBusinessTreasurySale");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "CompliancesBusinessRiskRatingARMHoldCo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceRulesBusiness");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceRules");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceRegulatoryPayment");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceRegulator");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingRetailOperation");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingResearch");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingOperationSettlement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingOperationControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingFundAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingFundAccount");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingBDPWMIAMIMRetail");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingARMRegistrar");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRatingARMIM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceIMBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceHillRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceDigitalFinancialService");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceDepartment");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceCalendar");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusinessTAMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusinessRatingTrustee");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusinessRatingHill");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusinessRatingARMHoldCo");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusinessDigitalFinancialServiceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusinessDepartment");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusinessARMTAM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusinessARMCapitalRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceBusines");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceARMCapital");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceAgribusinessRatingRFl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceAgribusinessRatingAAFML");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ComplianceAgribusiness");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "CommenceEngagementAuditexecution");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "CitationAuditReport");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "CASPLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "BusinessRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "BusinessImpactAnalysisUnitLog");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "BusinessImpactAnalysisUnit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "BusinessImpactAnalysis");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "BusinessEntity");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "BIAUnitProcessDetailsBusinessUnitToRunProcess");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "BIAUnitProcessDetails");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseDigitalFinancialServiceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMTrusteePrivateTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMTrusteeCommercialTrust");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMTAM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMSecurityStockBroking");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMSecurityResearch");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMSecurityInvestmentBanking");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMRetailOperation");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMResearch");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMRegistrar");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMOperationSettlement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMOperationControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMIMUnit");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMFundAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMFundAccount");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMIMBDPWMIAMIMRetail");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMHoldingCompany");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMHoldCoTreasurySale");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMHill");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMCapitalRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMAgribusinessRFL");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditUniverseARMAgribusinessAAFML");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditProgramAuditExecution");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditPlanningMemoPlanningTimeline");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditPlanningMemoAuditExecution");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditFindings");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditFindingAuditReport");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AuditAnnouncementMemoAuditExecution");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AssessmentOfDigitalInitiativeList");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMTrusteeRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMTrusteeEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMTrusteeAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMTAMEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMTAMBusinessRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMTAMAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedServiceRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedServiceEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseTreasury");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseRiskManagement");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseProcurementAndAdmin");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseMCC");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseLegal");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseIT");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseInternalControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseInformationSecurity");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseHCM");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseFinancialControl");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseDataAnalytic");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseCustomerExperience");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseCTO");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseCorporatestrategy");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseCompliance");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverseAcademy");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSharedAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSecurityRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSecurityEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMSecurityAnnualAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMIMEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMIMBusinessRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMIMAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMHoldingCompanyEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMHoldingCompanyBusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMHoldingCompanyAnnualAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMHillRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMHILLEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMHillAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMCapitalEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMCapitalBusinessRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMCapitalAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMAgribusinessRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMAgribusinessEMCRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ARMAgribusinessAuditUniverse");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "AnualAuditUniverseRiskRating");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ActionManagement");
        }
    }
}
