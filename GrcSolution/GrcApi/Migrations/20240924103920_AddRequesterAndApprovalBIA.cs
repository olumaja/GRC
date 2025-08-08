using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRequesterAndApprovalBIA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Approval",
                table: "BusinessImpactAnalysisUnit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "BusinessImpactAnalysisUnit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Requester",
                table: "BusinessImpactAnalysisUnit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approval",
                table: "BusinessImpactAnalysisUnit");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "BusinessImpactAnalysisUnit");

            migrationBuilder.DropColumn(
                name: "Requester",
                table: "BusinessImpactAnalysisUnit");
        }
    }
}
