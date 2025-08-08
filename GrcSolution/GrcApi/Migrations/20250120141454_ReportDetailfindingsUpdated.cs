using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class ReportDetailfindingsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                table: "InternalAuditReport",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReportDetailfindings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternalAuditReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DescriptionOfIssue = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    IssueRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    PotentialMaterialisedImpact = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetailfindings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportDetailfindings_InternalAuditReport_InternalAuditReportId",
                        column: x => x.InternalAuditReportId,
                        principalTable: "InternalAuditReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_ReportDetailfindings_InternalAuditReportId",
                table: "ReportDetailfindings",
                column: "InternalAuditReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
           
        }
    }
}
