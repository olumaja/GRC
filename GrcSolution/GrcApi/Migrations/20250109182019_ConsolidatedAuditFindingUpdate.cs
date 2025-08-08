using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class ConsolidatedAuditFindingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedAuditFinding_BusinessRiskRating_BusinessRiskRatingId",
                table: "ConsolidatedAuditFinding");            

            migrationBuilder.RenameColumn(
                name: "BusinessRiskRatingId",
                table: "ConsolidatedAuditFinding",
                newName: "InternalAuditReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsolidatedAuditFinding_BusinessRiskRatingId",
                table: "ConsolidatedAuditFinding",
                newName: "IX_ConsolidatedAuditFinding_InternalAuditReportId");


          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

        }
    }
}
