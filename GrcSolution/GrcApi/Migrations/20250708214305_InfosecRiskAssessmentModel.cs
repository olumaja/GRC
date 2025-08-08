using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class InfosecRiskAssessmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.CreateTable(
                name: "InfosecRiskAssessmentModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Objective = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    RiskAssessmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfidentialityRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IntegrityRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AvailabilityRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssetValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssetScore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Vulnerability = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    VulnerabilityRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Threat = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ImpactRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LikehoodOfthreatOccuring = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RiskScore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RiskValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RiskOption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControlEffectiveness = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ResidualRisk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Riskowner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReasonForRejection = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateApproved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ProposeClosureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemediationStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequesterEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfosecRiskAssessmentModel", x => x.Id);
                });
                        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfosecRiskAssessmentModel");
                       
        }
    }
}
