using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedAntivirusAssessmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "AntivirusAssessmentModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessmentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TitleOfAssessment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProposeEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonForRejection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateApproved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequesterEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AntivirusStatus = table.Column<int>(type: "int", nullable: false),
                    InfosecFeedbackStatus = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AntivirusAssessmentModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InactiveSensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AntivirusAssessmentModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComputerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastSeenOnCrowdStrike = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MACAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SystemProductName = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    SystemVersion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoggedOnUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastSeenOnManageEngine = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_InactiveSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InactiveSensors_AntivirusAssessmentModel_AntivirusAssessmentModelId",
                        column: x => x.AntivirusAssessmentModelId,
                        principalTable: "AntivirusAssessmentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReducedFunctionalityMode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AntivirusAssessmentModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComputerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastSeenOnCrowdStrike = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MACAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SystemVersion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoggedOnUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastSeenOnManageEngine = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ReducedFunctionalityMode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReducedFunctionalityMode_AntivirusAssessmentModel_AntivirusAssessmentModelId",
                        column: x => x.AntivirusAssessmentModelId,
                        principalTable: "AntivirusAssessmentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
                        
            migrationBuilder.CreateIndex(
                name: "IX_InactiveSensors_AntivirusAssessmentModelId",
                table: "InactiveSensors",
                column: "AntivirusAssessmentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReducedFunctionalityMode_AntivirusAssessmentModelId",
                table: "ReducedFunctionalityMode",
                column: "AntivirusAssessmentModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InactiveSensors");

            migrationBuilder.DropTable(
                name: "ReducedFunctionalityMode");

            migrationBuilder.DropTable(
                name: "AntivirusAssessmentModel");

        }
    }
}
