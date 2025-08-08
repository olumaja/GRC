using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class IncidentManagementLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.CreateTable(
                name: "IncidentManagementLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecurityIncident = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    SecurityArea = table.Column<int>(type: "int", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfIncident = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    TypeOfAsset = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    ReportingStaff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReportingStaffEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfReporting = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DescriptionOfActionTaken = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    RootCause = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    Impact = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    RecommendationToPreventFutureReoccurence = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    LessonLearnt = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfClosure = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportingStaffComment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    ActionOwnerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerComment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    IncidentTag = table.Column<int>(type: "int", nullable: false),
                    InfoSecStaffName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InfoSecStaffEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InfoSecRecommendation = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentManagementLog", x => x.Id);
                });           

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentManagementLog");            
        }
    }
}
