using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AssessmentOfDigitalInitiativeList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {                    
            
            migrationBuilder.AddColumn<DateTime>(
                name: "CommenceDate",
                table: "AuditAnnouncementMemoAuditExecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodFrom",
                table: "AuditAnnouncementMemoAuditExecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodTo",
                table: "AuditAnnouncementMemoAuditExecution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssessmentOfDigitalInitiativeList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternalAuditReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    ActionOwner = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    ManagementResponse = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentOfDigitalInitiativeList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentOfDigitalInitiativeList_InternalAuditReport_InternalAuditReportId",
                        column: x => x.InternalAuditReportId,
                        principalTable: "InternalAuditReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_AssessmentOfDigitalInitiativeList_InternalAuditReportId",
                table: "AssessmentOfDigitalInitiativeList",
                column: "InternalAuditReportId");
        }
               
        
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
