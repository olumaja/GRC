using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class ARMCapital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditUniverseARMSecurityInvestmentBanking_ARMSecurityAnnualAuditUniverse_ARMSecurityAnnualAuditUniverseId",
                table: "AuditUniverseARMSecurityInvestmentBanking");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditUniverseARMSecurityResearch_ARMSecurityAnnualAuditUniverse_ARMSecurityAnnualAuditUniverseId",
                table: "AuditUniverseARMSecurityResearch");

            migrationBuilder.DropTable(
                name: "ComplianceSecurityRatingInvestmentBanking");

            migrationBuilder.DropTable(
                name: "ComplianceSecurityRatingResearch");

            migrationBuilder.DropTable(
                name: "FinacialSecurityRatingInvestmentBanking");

            migrationBuilder.DropTable(
                name: "FinacialSecurityRatingResearch");

            migrationBuilder.DropTable(
                name: "OperationSecurityRatingInvestmentBanking");

            migrationBuilder.DropTable(
                name: "OperationSecurityRatingResearch");

            migrationBuilder.DropTable(
                name: "StrategySecurityRatingInvestmentBanking");

            migrationBuilder.DropTable(
                name: "StrategySecurityRatingResearch");

            migrationBuilder.DropIndex(
                name: "IX_AuditUniverseARMSecurityResearch_ARMSecurityAnnualAuditUniverseId",
                table: "AuditUniverseARMSecurityResearch");

            migrationBuilder.DropIndex(
                name: "IX_AuditUniverseARMSecurityInvestmentBanking_ARMSecurityAnnualAuditUniverseId",
                table: "AuditUniverseARMSecurityInvestmentBanking");
                        

            migrationBuilder.DropColumn(
                name: "InvestmentBanking",
                table: "TimeSinceLastSecurityAudit");

            migrationBuilder.DropColumn(
                name: "Research",
                table: "TimeSinceLastSecurityAudit");

            migrationBuilder.AddColumn<int>(
                name: "Research",
                table: "TimeSinceLastAuditIMBusinessRating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Research",
                table: "ManagementConcernBusinessUnitARMIMRating",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Research",
                table: "ARMIMEMCRating",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ARMCapitalAuditUniverse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnualAuditUniverseRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnualAuditUniverseStatus = table.Column<int>(type: "int", nullable: false),
                    EngagementPlan = table.Column<int>(type: "int", nullable: false),
                    WorkPaper = table.Column<int>(type: "int", nullable: false),
                    Findingstatus = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARMCapitalAuditUniverse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ARMCapitalAuditUniverse_AnualAuditUniverseRiskRating_AnualAuditUniverseRiskRatingId",
                        column: x => x.AnualAuditUniverseRiskRatingId,
                        principalTable: "AnualAuditUniverseRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ARMCapitalBusinessRiskRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARMCapitalBusinessRiskRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ARMCapitalBusinessRiskRating_BusinessRiskRating_BusinessRiskRatingId",
                        column: x => x.BusinessRiskRatingId,
                        principalTable: "BusinessRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ARMCapitalEMCRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMCConcernRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARMCapitalEMCRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditUniverseARMIMResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMIMAuditUniverseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BusinessManagerConcern = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OldRiskScore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DirectorConcern = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskScore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RiskRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommentation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    January = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    February = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    March = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    April = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    May = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    June = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    July = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    August = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    September = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    October = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    November = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    December = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditUniverseARMIMResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditUniverseARMIMResearch_ARMIMAuditUniverse_ARMIMAuditUniverseId",
                        column: x => x.ARMIMAuditUniverseId,
                        principalTable: "ARMIMAuditUniverse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceIMRatingResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplianceIMBusinessRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AMLCFT = table.Column<int>(type: "int", nullable: false),
                    LitigationRisk = table.Column<int>(type: "int", nullable: false),
                    ChangingRegulations = table.Column<int>(type: "int", nullable: false),
                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = table.Column<int>(type: "int", nullable: false),
                    NonComplianceWithContracts = table.Column<int>(type: "int", nullable: false),
                    KYCChecks = table.Column<int>(type: "int", nullable: false),
                    GDPROrNDPR = table.Column<int>(type: "int", nullable: false),
                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = table.Column<int>(type: "int", nullable: false),
                    DisclosureRisk = table.Column<int>(type: "int", nullable: false),
                    CorporateGovernance = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceIMRatingResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceIMRatingResearch_ComplianceIMBusinessRating_ComplianceIMBusinessRatingId",
                        column: x => x.ComplianceIMBusinessRatingId,
                        principalTable: "ComplianceIMBusinessRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinacialIMRatingResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialIMBusinessRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomeAssuranceRisk = table.Column<int>(type: "int", nullable: false),
                    StatutoryDeductionsandTaxes = table.Column<int>(type: "int", nullable: false),
                    AdherencetoFinancialStandards = table.Column<int>(type: "int", nullable: false),
                    AdoptionandImplementationofPoliciesAdherence = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    ErrororControlRisk = table.Column<int>(type: "int", nullable: false),
                    TheftorFraudRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinacialIMRatingResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinacialIMRatingResearch_FinancialIMBusinessRating_FinancialIMBusinessRatingId",
                        column: x => x.FinancialIMBusinessRatingId,
                        principalTable: "FinancialIMBusinessRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementConcernARMCapital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagementConcernRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementConcernARMCapital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementConcernARMCapital_ManagementConcernRiskRating_ManagementConcernRiskRatingId",
                        column: x => x.ManagementConcernRiskRatingId,
                        principalTable: "ManagementConcernRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationIMRatingResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationIMBusinessRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdoptionandImplementationofPolicies = table.Column<int>(type: "int", nullable: false),
                    InadequateProfilingOfClientsToEffectivelySellProduct = table.Column<int>(type: "int", nullable: false),
                    TheftorFraudRisk = table.Column<int>(type: "int", nullable: false),
                    PoorCustomerService = table.Column<int>(type: "int", nullable: false),
                    ITInfrastruCTOreDowntime = table.Column<int>(type: "int", nullable: false),
                    ThirdpartyRisk = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    TheftLeakageorMisuseofIntelleCTOalProperty = table.Column<int>(type: "int", nullable: false),
                    OverorUnderpaymentofClient = table.Column<int>(type: "int", nullable: false),
                    RecruitmentRisk = table.Column<int>(type: "int", nullable: false),
                    ConfidentialityIntegrityandAvailabilityofData = table.Column<int>(type: "int", nullable: false),
                    UnauthorizedAccess = table.Column<int>(type: "int", nullable: false),
                    MalwareorVirusorWebsiteAttacks = table.Column<int>(type: "int", nullable: false),
                    ErroneousDataEntry = table.Column<int>(type: "int", nullable: false),
                    Miscommunication = table.Column<int>(type: "int", nullable: false),
                    ErrorDetectionRisk = table.Column<int>(type: "int", nullable: false),
                    StrategyMonitoringRisk = table.Column<int>(type: "int", nullable: false),
                    RelevanceandRecencyofModelToolsandTechniques = table.Column<int>(type: "int", nullable: false),
                    ProductivityRisk = table.Column<int>(type: "int", nullable: false),
                    BudgetOverruns = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationIMRatingResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationIMRatingResearch_OperationIMBusinessRating_OperationIMBusinessRatingId",
                        column: x => x.OperationIMBusinessRatingId,
                        principalTable: "OperationIMBusinessRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrategyIMRatingResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrategyImBusinessRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlunCTOatingInterestRates = table.Column<int>(type: "int", nullable: false),
                    CurrencyDevaluation = table.Column<int>(type: "int", nullable: false),
                    Increasedleverage = table.Column<int>(type: "int", nullable: false),
                    LiquidityPressures = table.Column<int>(type: "int", nullable: false),
                    ReputationalRisk = table.Column<int>(type: "int", nullable: false),
                    PeopleRetentionRisk = table.Column<int>(type: "int", nullable: false),
                    TechnologicalRisk = table.Column<int>(type: "int", nullable: false),
                    InformationSecurityRisk = table.Column<int>(type: "int", nullable: false),
                    CreditRisk = table.Column<int>(type: "int", nullable: false),
                    AllianceandPartnershipRisks = table.Column<int>(type: "int", nullable: false),
                    PortfolioProductandFundPerformanceRisk = table.Column<int>(type: "int", nullable: false),
                    RisktoProfitabilityorPerformance = table.Column<int>(type: "int", nullable: false),
                    RiskofDeclineinMarketShare = table.Column<int>(type: "int", nullable: false),
                    DropinFundandFundManagerRatings = table.Column<int>(type: "int", nullable: false),
                    HarshMacroeconomicConditionsegInflation = table.Column<int>(type: "int", nullable: false),
                    StiffCompetitionandPoorVisibilityOftheBusiness = table.Column<int>(type: "int", nullable: false),
                    ErosionofStatutoryCapital = table.Column<int>(type: "int", nullable: false),
                    FluidityofTechnologicalSolutions = table.Column<int>(type: "int", nullable: false),
                    UnregulatedUnstruCTOredlandscape = table.Column<int>(type: "int", nullable: false),
                    PoliticalRisk = table.Column<int>(type: "int", nullable: false),
                    ProjectManagementRisk = table.Column<int>(type: "int", nullable: false),
                    InvestmentRisk = table.Column<int>(type: "int", nullable: false),
                    FailureofInvestor = table.Column<int>(type: "int", nullable: false),
                    ExitRisk = table.Column<int>(type: "int", nullable: false),
                    SocialRisk = table.Column<int>(type: "int", nullable: false),
                    EnvironmentalRisk = table.Column<int>(type: "int", nullable: false),
                    SustainabilityRisk = table.Column<int>(type: "int", nullable: false),
                    BCPandDRP = table.Column<int>(type: "int", nullable: false),
                    MyLegacyIssuesProperty = table.Column<int>(type: "int", nullable: false),
                    HealthandSafetyRisks = table.Column<int>(type: "int", nullable: false),
                    EmergingRisks = table.Column<int>(type: "int", nullable: false),
                    ProductivityRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyIMRatingResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategyIMRatingResearch_StrategyImBusinessRating_StrategyImBusinessRatingId",
                        column: x => x.StrategyImBusinessRatingId,
                        principalTable: "StrategyImBusinessRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditUniverseARMCapitalRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapitalAuditUniverseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BusinessManagerConcern = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OldRiskScore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DirectorConcern = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskScore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RiskRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommentation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    January = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    February = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    March = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    April = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    May = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    June = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    July = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    August = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    September = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    October = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    November = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    December = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditUniverseARMCapitalRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditUniverseARMCapitalRating_ARMCapitalAuditUniverse_ARMCapitalAuditUniverseId",
                        column: x => x.ARMCapitalAuditUniverseId,
                        principalTable: "ARMCapitalAuditUniverse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceARMCapital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapitalBusinessRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceARMCapital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceARMCapital_ARMCapitalBusinessRiskRating_ARMCapitalBusinessRiskRatingId",
                        column: x => x.ARMCapitalBusinessRiskRatingId,
                        principalTable: "ARMCapitalBusinessRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialARMCapital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapitalBusinessRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialARMCapital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialARMCapital_ARMCapitalBusinessRiskRating_ARMCapitalBusinessRiskRatingId",
                        column: x => x.ARMCapitalBusinessRiskRatingId,
                        principalTable: "ARMCapitalBusinessRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationARMCapital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapitalBusinessRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationARMCapital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationARMCapital_ARMCapitalBusinessRiskRating_ARMCapitalBusinessRiskRatingId",
                        column: x => x.ARMCapitalBusinessRiskRatingId,
                        principalTable: "ARMCapitalBusinessRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrategyARMCapital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapitalBusinessRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyARMCapital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategyARMCapital_ARMCapitalBusinessRiskRating_ARMCapitalBusinessRiskRatingId",
                        column: x => x.ARMCapitalBusinessRiskRatingId,
                        principalTable: "ARMCapitalBusinessRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSinceLastAuditARMCapital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapitalBusinessRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapital = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSinceLastAuditARMCapital", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSinceLastAuditARMCapital_ARMCapitalBusinessRiskRating_ARMCapitalBusinessRiskRatingId",
                        column: x => x.ARMCapitalBusinessRiskRatingId,
                        principalTable: "ARMCapitalBusinessRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementConcernBusinessUnitARMCapitalRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagementConcernARMCapitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ARMCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementConcernBusinessUnitARMCapitalRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementConcernBusinessUnitARMCapitalRating_ManagementConcernARMCapital_ManagementConcernARMCapitalId",
                        column: x => x.ManagementConcernARMCapitalId,
                        principalTable: "ManagementConcernARMCapital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementConcernSharedServiceARMCapitalRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagementConcernARMCapitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HCM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcurementAndAdmin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskManagement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Legal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MCC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Academy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CTO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerExperience = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InformationSecurity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InternalControl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CorporateStrategy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Treasury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Compliance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinancialControl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAnalytic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementConcernSharedServiceARMCapitalRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementConcernSharedServiceARMCapitalRating_ManagementConcernARMCapital_ManagementConcernARMCapitalId",
                        column: x => x.ManagementConcernARMCapitalId,
                        principalTable: "ManagementConcernARMCapital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceBusinessARMCapitalRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplianceARMCapitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AMLCFT = table.Column<int>(type: "int", nullable: false),
                    LitigationRisk = table.Column<int>(type: "int", nullable: false),
                    ChangingRegulations = table.Column<int>(type: "int", nullable: false),
                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = table.Column<int>(type: "int", nullable: false),
                    NonComplianceWithContracts = table.Column<int>(type: "int", nullable: false),
                    KYCChecks = table.Column<int>(type: "int", nullable: false),
                    GDPROrNDPR = table.Column<int>(type: "int", nullable: false),
                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = table.Column<int>(type: "int", nullable: false),
                    DisclosureRisk = table.Column<int>(type: "int", nullable: false),
                    CorporateGovernance = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceBusinessARMCapitalRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceBusinessARMCapitalRating_ComplianceARMCapital_ComplianceARMCapitalId",
                        column: x => x.ComplianceARMCapitalId,
                        principalTable: "ComplianceARMCapital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinacialBusinessARMCapitalRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FinancialARMCapitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomeAssuranceRisk = table.Column<int>(type: "int", nullable: false),
                    StatutoryDeductionsandTaxes = table.Column<int>(type: "int", nullable: false),
                    AdherencetoFinancialStandards = table.Column<int>(type: "int", nullable: false),
                    AdoptionandImplementationofPoliciesAdherence = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    ErrororControlRisk = table.Column<int>(type: "int", nullable: false),
                    TheftorFraudRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinacialBusinessARMCapitalRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinacialBusinessARMCapitalRating_FinancialARMCapital_FinancialARMCapitalId",
                        column: x => x.FinancialARMCapitalId,
                        principalTable: "FinancialARMCapital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationARMCapitalRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationARMCapitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdoptionandImplementationofPolicies = table.Column<int>(type: "int", nullable: false),
                    InadequateProfilingOfClientsToEffectivelySellProduct = table.Column<int>(type: "int", nullable: false),
                    TheftorFraudRisk = table.Column<int>(type: "int", nullable: false),
                    PoorCustomerService = table.Column<int>(type: "int", nullable: false),
                    ITInfrastruCTOreDowntime = table.Column<int>(type: "int", nullable: false),
                    ThirdpartyRisk = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    TheftLeakageorMisuseofIntelleCTOalProperty = table.Column<int>(type: "int", nullable: false),
                    OverorUnderpaymentofClient = table.Column<int>(type: "int", nullable: false),
                    RecruitmentRisk = table.Column<int>(type: "int", nullable: false),
                    ConfidentialityIntegrityandAvailabilityofData = table.Column<int>(type: "int", nullable: false),
                    UnauthorizedAccess = table.Column<int>(type: "int", nullable: false),
                    MalwareorVirusorWebsiteAttacks = table.Column<int>(type: "int", nullable: false),
                    ErroneousDataEntry = table.Column<int>(type: "int", nullable: false),
                    Miscommunication = table.Column<int>(type: "int", nullable: false),
                    ErrorDetectionRisk = table.Column<int>(type: "int", nullable: false),
                    StrategyMonitoringRisk = table.Column<int>(type: "int", nullable: false),
                    RelevanceandRecencyofModelToolsandTechniques = table.Column<int>(type: "int", nullable: false),
                    ProductivityRisk = table.Column<int>(type: "int", nullable: false),
                    BudgetOverruns = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationARMCapitalRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationARMCapitalRating_OperationARMCapital_OperationARMCapitalId",
                        column: x => x.OperationARMCapitalId,
                        principalTable: "OperationARMCapital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrategyARMCapitalRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrategyARMCapitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlunCTOatingInterestRates = table.Column<int>(type: "int", nullable: false),
                    CurrencyDevaluation = table.Column<int>(type: "int", nullable: false),
                    Increasedleverage = table.Column<int>(type: "int", nullable: false),
                    LiquidityPressures = table.Column<int>(type: "int", nullable: false),
                    ReputationalRisk = table.Column<int>(type: "int", nullable: false),
                    PeopleRetentionRisk = table.Column<int>(type: "int", nullable: false),
                    TechnologicalRisk = table.Column<int>(type: "int", nullable: false),
                    InformationSecurityRisk = table.Column<int>(type: "int", nullable: false),
                    CreditRisk = table.Column<int>(type: "int", nullable: false),
                    AllianceandPartnershipRisks = table.Column<int>(type: "int", nullable: false),
                    PortfolioProductandFundPerformanceRisk = table.Column<int>(type: "int", nullable: false),
                    RisktoProfitabilityorPerformance = table.Column<int>(type: "int", nullable: false),
                    RiskofDeclineinMarketShare = table.Column<int>(type: "int", nullable: false),
                    DropinFundandFundManagerRatings = table.Column<int>(type: "int", nullable: false),
                    HarshMacroeconomicConditionsegInflation = table.Column<int>(type: "int", nullable: false),
                    StiffCompetitionandPoorVisibilityOftheBusiness = table.Column<int>(type: "int", nullable: false),
                    ErosionofStatutoryCapital = table.Column<int>(type: "int", nullable: false),
                    FluidityofTechnologicalSolutions = table.Column<int>(type: "int", nullable: false),
                    UnregulatedUnstruCTOredlandscape = table.Column<int>(type: "int", nullable: false),
                    PoliticalRisk = table.Column<int>(type: "int", nullable: false),
                    ProjectManagementRisk = table.Column<int>(type: "int", nullable: false),
                    InvestmentRisk = table.Column<int>(type: "int", nullable: false),
                    FailureofInvestor = table.Column<int>(type: "int", nullable: false),
                    ExitRisk = table.Column<int>(type: "int", nullable: false),
                    SocialRisk = table.Column<int>(type: "int", nullable: false),
                    EnvironmentalRisk = table.Column<int>(type: "int", nullable: false),
                    SustainabilityRisk = table.Column<int>(type: "int", nullable: false),
                    BCPandDRP = table.Column<int>(type: "int", nullable: false),
                    MyLegacyIssuesProperty = table.Column<int>(type: "int", nullable: false),
                    HealthandSafetyRisks = table.Column<int>(type: "int", nullable: false),
                    EmergingRisks = table.Column<int>(type: "int", nullable: false),
                    ProductivityRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategyARMCapitalRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategyARMCapitalRating_StrategyARMCapital_StrategyARMCapitalId",
                        column: x => x.StrategyARMCapitalId,
                        principalTable: "StrategyARMCapital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARMCapitalAuditUniverse_AnualAuditUniverseRiskRatingId",
                table: "ARMCapitalAuditUniverse",
                column: "AnualAuditUniverseRiskRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ARMCapitalBusinessRiskRating_BusinessRiskRatingId",
                table: "ARMCapitalBusinessRiskRating",
                column: "BusinessRiskRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditUniverseARMCapitalRating_ARMCapitalAuditUniverseId",
                table: "AuditUniverseARMCapitalRating",
                column: "ARMCapitalAuditUniverseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditUniverseARMIMResearch_ARMIMAuditUniverseId",
                table: "AuditUniverseARMIMResearch",
                column: "ARMIMAuditUniverseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceARMCapital_ARMCapitalBusinessRiskRatingId",
                table: "ComplianceARMCapital",
                column: "ARMCapitalBusinessRiskRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceBusinessARMCapitalRating_ComplianceARMCapitalId",
                table: "ComplianceBusinessARMCapitalRating",
                column: "ComplianceARMCapitalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceIMRatingResearch_ComplianceIMBusinessRatingId",
                table: "ComplianceIMRatingResearch",
                column: "ComplianceIMBusinessRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinacialBusinessARMCapitalRating_FinancialARMCapitalId",
                table: "FinacialBusinessARMCapitalRating",
                column: "FinancialARMCapitalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinacialIMRatingResearch_FinancialIMBusinessRatingId",
                table: "FinacialIMRatingResearch",
                column: "FinancialIMBusinessRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialARMCapital_ARMCapitalBusinessRiskRatingId",
                table: "FinancialARMCapital",
                column: "ARMCapitalBusinessRiskRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagementConcernARMCapital_ManagementConcernRiskRatingId",
                table: "ManagementConcernARMCapital",
                column: "ManagementConcernRiskRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementConcernBusinessUnitARMCapitalRating_ManagementConcernARMCapitalId",
                table: "ManagementConcernBusinessUnitARMCapitalRating",
                column: "ManagementConcernARMCapitalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManagementConcernSharedServiceARMCapitalRating_ManagementConcernARMCapitalId",
                table: "ManagementConcernSharedServiceARMCapitalRating",
                column: "ManagementConcernARMCapitalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationARMCapital_ARMCapitalBusinessRiskRatingId",
                table: "OperationARMCapital",
                column: "ARMCapitalBusinessRiskRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationARMCapitalRating_OperationARMCapitalId",
                table: "OperationARMCapitalRating",
                column: "OperationARMCapitalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationIMRatingResearch_OperationIMBusinessRatingId",
                table: "OperationIMRatingResearch",
                column: "OperationIMBusinessRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategyARMCapital_ARMCapitalBusinessRiskRatingId",
                table: "StrategyARMCapital",
                column: "ARMCapitalBusinessRiskRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategyARMCapitalRating_StrategyARMCapitalId",
                table: "StrategyARMCapitalRating",
                column: "StrategyARMCapitalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategyIMRatingResearch_StrategyImBusinessRatingId",
                table: "StrategyIMRatingResearch",
                column: "StrategyImBusinessRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSinceLastAuditARMCapital_ARMCapitalBusinessRiskRatingId",
                table: "TimeSinceLastAuditARMCapital",
                column: "ARMCapitalBusinessRiskRatingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARMCapitalEMCRating");

            migrationBuilder.DropTable(
                name: "AuditUniverseARMCapitalRating");

            migrationBuilder.DropTable(
                name: "AuditUniverseARMIMResearch");

            migrationBuilder.DropTable(
                name: "ComplianceBusinessARMCapitalRating");

            migrationBuilder.DropTable(
                name: "ComplianceIMRatingResearch");

            migrationBuilder.DropTable(
                name: "FinacialBusinessARMCapitalRating");

            migrationBuilder.DropTable(
                name: "FinacialIMRatingResearch");

            migrationBuilder.DropTable(
                name: "ManagementConcernBusinessUnitARMCapitalRating");

            migrationBuilder.DropTable(
                name: "ManagementConcernSharedServiceARMCapitalRating");

            migrationBuilder.DropTable(
                name: "OperationARMCapitalRating");

            migrationBuilder.DropTable(
                name: "OperationIMRatingResearch");

            migrationBuilder.DropTable(
                name: "StrategyARMCapitalRating");

            migrationBuilder.DropTable(
                name: "StrategyIMRatingResearch");

            migrationBuilder.DropTable(
                name: "TimeSinceLastAuditARMCapital");

            migrationBuilder.DropTable(
                name: "ARMCapitalAuditUniverse");

            migrationBuilder.DropTable(
                name: "ComplianceARMCapital");

            migrationBuilder.DropTable(
                name: "FinancialARMCapital");

            migrationBuilder.DropTable(
                name: "ManagementConcernARMCapital");

            migrationBuilder.DropTable(
                name: "OperationARMCapital");

            migrationBuilder.DropTable(
                name: "StrategyARMCapital");

            migrationBuilder.DropTable(
                name: "ARMCapitalBusinessRiskRating");


            migrationBuilder.DropColumn(
                name: "Research",
                table: "TimeSinceLastAuditIMBusinessRating");

            migrationBuilder.DropColumn(
                name: "Research",
                table: "ManagementConcernBusinessUnitARMIMRating");

            migrationBuilder.DropColumn(
                name: "Research",
                table: "ARMIMEMCRating");
                      

            migrationBuilder.CreateTable(
                name: "ComplianceSecurityRatingInvestmentBanking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AMLCFT = table.Column<int>(type: "int", nullable: false),
                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = table.Column<int>(type: "int", nullable: false),
                    ChangingRegulations = table.Column<int>(type: "int", nullable: false),
                    ComplianceSecurityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateGovernance = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisclosureRisk = table.Column<int>(type: "int", nullable: false),
                    GDPROrNDPR = table.Column<int>(type: "int", nullable: false),
                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    KYCChecks = table.Column<int>(type: "int", nullable: false),
                    LitigationRisk = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonComplianceWithContracts = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceSecurityRatingInvestmentBanking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceSecurityRatingInvestmentBanking_ComplianceSecurity_ComplianceSecurityId",
                        column: x => x.ComplianceSecurityId,
                        principalTable: "ComplianceSecurity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceSecurityRatingResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AMLCFT = table.Column<int>(type: "int", nullable: false),
                    AdoptionandIimplementationOfPoliciesandAdherenceToProcesses = table.Column<int>(type: "int", nullable: false),
                    ChangingRegulations = table.Column<int>(type: "int", nullable: false),
                    ComplianceSecurityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorporateGovernance = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisclosureRisk = table.Column<int>(type: "int", nullable: false),
                    GDPROrNDPR = table.Column<int>(type: "int", nullable: false),
                    InaccurateComputationofRegulatoryRemittancesDelayedFilings = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    KYCChecks = table.Column<int>(type: "int", nullable: false),
                    LitigationRisk = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NonComplianceWithContracts = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceSecurityRatingResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceSecurityRatingResearch_ComplianceSecurity_ComplianceSecurityId",
                        column: x => x.ComplianceSecurityId,
                        principalTable: "ComplianceSecurity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinacialSecurityRatingInvestmentBanking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdherencetoFinancialStandards = table.Column<int>(type: "int", nullable: false),
                    AdoptionandImplementationofPoliciesAdherence = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ErrororControlRisk = table.Column<int>(type: "int", nullable: false),
                    FinancialSecurityReportingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomeAssuranceRisk = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatutoryDeductionsandTaxes = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    TheftorFraudRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinacialSecurityRatingInvestmentBanking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinacialSecurityRatingInvestmentBanking_FinancialSecurityReporting_FinancialSecurityReportingId",
                        column: x => x.FinancialSecurityReportingId,
                        principalTable: "FinancialSecurityReporting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinacialSecurityRatingResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdherencetoFinancialStandards = table.Column<int>(type: "int", nullable: false),
                    AdoptionandImplementationofPoliciesAdherence = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ErrororControlRisk = table.Column<int>(type: "int", nullable: false),
                    FinancialSecurityReportingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomeAssuranceRisk = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatutoryDeductionsandTaxes = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    TheftorFraudRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinacialSecurityRatingResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinacialSecurityRatingResearch_FinancialSecurityReporting_FinancialSecurityReportingId",
                        column: x => x.FinancialSecurityReportingId,
                        principalTable: "FinancialSecurityReporting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationSecurityRatingInvestmentBanking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdoptionandImplementationofPolicies = table.Column<int>(type: "int", nullable: false),
                    BudgetOverruns = table.Column<int>(type: "int", nullable: false),
                    ConfidentialityIntegrityandAvailabilityofData = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ErroneousDataEntry = table.Column<int>(type: "int", nullable: false),
                    ErrorDetectionRisk = table.Column<int>(type: "int", nullable: false),
                    ITInfrastruCTOreDowntime = table.Column<int>(type: "int", nullable: false),
                    InadequateProfilingOfClientsToEffectivelySellProduct = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MalwareorVirusorWebsiteAttacks = table.Column<int>(type: "int", nullable: false),
                    Miscommunication = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperationSecurityBusinessRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OverorUnderpaymentofClient = table.Column<int>(type: "int", nullable: false),
                    PoorCustomerService = table.Column<int>(type: "int", nullable: false),
                    ProductivityRisk = table.Column<int>(type: "int", nullable: false),
                    RecruitmentRisk = table.Column<int>(type: "int", nullable: false),
                    RelevanceandRecencyofModelToolsandTechniques = table.Column<int>(type: "int", nullable: false),
                    StrategyMonitoringRisk = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    TheftLeakageorMisuseofIntelleCTOalProperty = table.Column<int>(type: "int", nullable: false),
                    TheftorFraudRisk = table.Column<int>(type: "int", nullable: false),
                    ThirdpartyRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    UnauthorizedAccess = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationSecurityRatingInvestmentBanking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationSecurityRatingInvestmentBanking_OperationSecurityBusinessRating_OperationSecurityBusinessRatingId",
                        column: x => x.OperationSecurityBusinessRatingId,
                        principalTable: "OperationSecurityBusinessRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationSecurityRatingResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdoptionandImplementationofPolicies = table.Column<int>(type: "int", nullable: false),
                    BudgetOverruns = table.Column<int>(type: "int", nullable: false),
                    ConfidentialityIntegrityandAvailabilityofData = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ErroneousDataEntry = table.Column<int>(type: "int", nullable: false),
                    ErrorDetectionRisk = table.Column<int>(type: "int", nullable: false),
                    ITInfrastruCTOreDowntime = table.Column<int>(type: "int", nullable: false),
                    InadequateProfilingOfClientsToEffectivelySellProduct = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MalwareorVirusorWebsiteAttacks = table.Column<int>(type: "int", nullable: false),
                    Miscommunication = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperationSecurityBusinessRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OverorUnderpaymentofClient = table.Column<int>(type: "int", nullable: false),
                    PoorCustomerService = table.Column<int>(type: "int", nullable: false),
                    ProductivityRisk = table.Column<int>(type: "int", nullable: false),
                    RecruitmentRisk = table.Column<int>(type: "int", nullable: false),
                    RelevanceandRecencyofModelToolsandTechniques = table.Column<int>(type: "int", nullable: false),
                    StrategyMonitoringRisk = table.Column<int>(type: "int", nullable: false),
                    TAT = table.Column<int>(type: "int", nullable: false),
                    TheftLeakageorMisuseofIntelleCTOalProperty = table.Column<int>(type: "int", nullable: false),
                    TheftorFraudRisk = table.Column<int>(type: "int", nullable: false),
                    ThirdpartyRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    UnauthorizedAccess = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationSecurityRatingResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationSecurityRatingResearch_OperationSecurityBusinessRating_OperationSecurityBusinessRatingId",
                        column: x => x.OperationSecurityBusinessRatingId,
                        principalTable: "OperationSecurityBusinessRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrategySecurityRatingInvestmentBanking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllianceandPartnershipRisks = table.Column<int>(type: "int", nullable: false),
                    BCPandDRP = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditRisk = table.Column<int>(type: "int", nullable: false),
                    CurrencyDevaluation = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DropinFundandFundManagerRatings = table.Column<int>(type: "int", nullable: false),
                    EmergingRisks = table.Column<int>(type: "int", nullable: false),
                    EnvironmentalRisk = table.Column<int>(type: "int", nullable: false),
                    ErosionofStatutoryCapital = table.Column<int>(type: "int", nullable: false),
                    ExitRisk = table.Column<int>(type: "int", nullable: false),
                    FailureofInvestor = table.Column<int>(type: "int", nullable: false),
                    FluidityofTechnologicalSolutions = table.Column<int>(type: "int", nullable: false),
                    FlunCTOatingInterestRates = table.Column<int>(type: "int", nullable: false),
                    HarshMacroeconomicConditionsegInflation = table.Column<int>(type: "int", nullable: false),
                    HealthandSafetyRisks = table.Column<int>(type: "int", nullable: false),
                    Increasedleverage = table.Column<int>(type: "int", nullable: false),
                    InformationSecurityRisk = table.Column<int>(type: "int", nullable: false),
                    InvestmentRisk = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LiquidityPressures = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MyLegacyIssuesProperty = table.Column<int>(type: "int", nullable: false),
                    PeopleRetentionRisk = table.Column<int>(type: "int", nullable: false),
                    PoliticalRisk = table.Column<int>(type: "int", nullable: false),
                    PortfolioProductandFundPerformanceRisk = table.Column<int>(type: "int", nullable: false),
                    ProductivityRisk = table.Column<int>(type: "int", nullable: false),
                    ProjectManagementRisk = table.Column<int>(type: "int", nullable: false),
                    ReputationalRisk = table.Column<int>(type: "int", nullable: false),
                    RiskofDeclineinMarketShare = table.Column<int>(type: "int", nullable: false),
                    RisktoProfitabilityorPerformance = table.Column<int>(type: "int", nullable: false),
                    SocialRisk = table.Column<int>(type: "int", nullable: false),
                    StiffCompetitionandPoorVisibilityOftheBusiness = table.Column<int>(type: "int", nullable: false),
                    StrategySecurityBusinessRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SustainabilityRisk = table.Column<int>(type: "int", nullable: false),
                    TechnologicalRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    UnregulatedUnstruCTOredlandscape = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategySecurityRatingInvestmentBanking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategySecurityRatingInvestmentBanking_StrategySecurityBusinessRating_StrategySecurityBusinessRatingId",
                        column: x => x.StrategySecurityBusinessRatingId,
                        principalTable: "StrategySecurityBusinessRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrategySecurityRatingResearch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllianceandPartnershipRisks = table.Column<int>(type: "int", nullable: false),
                    BCPandDRP = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditRisk = table.Column<int>(type: "int", nullable: false),
                    CurrencyDevaluation = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DropinFundandFundManagerRatings = table.Column<int>(type: "int", nullable: false),
                    EmergingRisks = table.Column<int>(type: "int", nullable: false),
                    EnvironmentalRisk = table.Column<int>(type: "int", nullable: false),
                    ErosionofStatutoryCapital = table.Column<int>(type: "int", nullable: false),
                    ExitRisk = table.Column<int>(type: "int", nullable: false),
                    FailureofInvestor = table.Column<int>(type: "int", nullable: false),
                    FluidityofTechnologicalSolutions = table.Column<int>(type: "int", nullable: false),
                    FlunCTOatingInterestRates = table.Column<int>(type: "int", nullable: false),
                    HarshMacroeconomicConditionsegInflation = table.Column<int>(type: "int", nullable: false),
                    HealthandSafetyRisks = table.Column<int>(type: "int", nullable: false),
                    Increasedleverage = table.Column<int>(type: "int", nullable: false),
                    InformationSecurityRisk = table.Column<int>(type: "int", nullable: false),
                    InvestmentRisk = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LiquidityPressures = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MyLegacyIssuesProperty = table.Column<int>(type: "int", nullable: false),
                    PeopleRetentionRisk = table.Column<int>(type: "int", nullable: false),
                    PoliticalRisk = table.Column<int>(type: "int", nullable: false),
                    PortfolioProductandFundPerformanceRisk = table.Column<int>(type: "int", nullable: false),
                    ProductivityRisk = table.Column<int>(type: "int", nullable: false),
                    ProjectManagementRisk = table.Column<int>(type: "int", nullable: false),
                    ReputationalRisk = table.Column<int>(type: "int", nullable: false),
                    RiskofDeclineinMarketShare = table.Column<int>(type: "int", nullable: false),
                    RisktoProfitabilityorPerformance = table.Column<int>(type: "int", nullable: false),
                    SocialRisk = table.Column<int>(type: "int", nullable: false),
                    StiffCompetitionandPoorVisibilityOftheBusiness = table.Column<int>(type: "int", nullable: false),
                    StrategySecurityBusinessRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SustainabilityRisk = table.Column<int>(type: "int", nullable: false),
                    TechnologicalRisk = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    UnregulatedUnstruCTOredlandscape = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrategySecurityRatingResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrategySecurityRatingResearch_StrategySecurityBusinessRating_StrategySecurityBusinessRatingId",
                        column: x => x.StrategySecurityBusinessRatingId,
                        principalTable: "StrategySecurityBusinessRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          
            migrationBuilder.CreateIndex(
                name: "IX_AuditUniverseARMSecurityResearch_ARMSecurityAnnualAuditUniverseId",
                table: "AuditUniverseARMSecurityResearch",
                column: "ARMSecurityAnnualAuditUniverseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditUniverseARMSecurityInvestmentBanking_ARMSecurityAnnualAuditUniverseId",
                table: "AuditUniverseARMSecurityInvestmentBanking",
                column: "ARMSecurityAnnualAuditUniverseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSecurityRatingInvestmentBanking_ComplianceSecurityId",
                table: "ComplianceSecurityRatingInvestmentBanking",
                column: "ComplianceSecurityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSecurityRatingResearch_ComplianceSecurityId",
                table: "ComplianceSecurityRatingResearch",
                column: "ComplianceSecurityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinacialSecurityRatingInvestmentBanking_FinancialSecurityReportingId",
                table: "FinacialSecurityRatingInvestmentBanking",
                column: "FinancialSecurityReportingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinacialSecurityRatingResearch_FinancialSecurityReportingId",
                table: "FinacialSecurityRatingResearch",
                column: "FinancialSecurityReportingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationSecurityRatingInvestmentBanking_OperationSecurityBusinessRatingId",
                table: "OperationSecurityRatingInvestmentBanking",
                column: "OperationSecurityBusinessRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationSecurityRatingResearch_OperationSecurityBusinessRatingId",
                table: "OperationSecurityRatingResearch",
                column: "OperationSecurityBusinessRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategySecurityRatingInvestmentBanking_StrategySecurityBusinessRatingId",
                table: "StrategySecurityRatingInvestmentBanking",
                column: "StrategySecurityBusinessRatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrategySecurityRatingResearch_StrategySecurityBusinessRatingId",
                table: "StrategySecurityRatingResearch",
                column: "StrategySecurityBusinessRatingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AuditUniverseARMSecurityInvestmentBanking_ARMSecurityAnnualAuditUniverse_ARMSecurityAnnualAuditUniverseId",
                table: "AuditUniverseARMSecurityInvestmentBanking",
                column: "ARMSecurityAnnualAuditUniverseId",
                principalTable: "ARMSecurityAnnualAuditUniverse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuditUniverseARMSecurityResearch_ARMSecurityAnnualAuditUniverse_ARMSecurityAnnualAuditUniverseId",
                table: "AuditUniverseARMSecurityResearch",
                column: "ARMSecurityAnnualAuditUniverseId",
                principalTable: "ARMSecurityAnnualAuditUniverse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
