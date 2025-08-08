using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AuditTrailToComplianceBusiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "ComplianceBusines");

            migrationBuilder.AddColumn<string>(
                name: "InitiatedBy",
                table: "ComplianceBusines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ComplianceBusines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitiatedBy",
                table: "ComplianceBusines");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ComplianceBusines");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "ComplianceBusines",
                type: "datetime2",
                nullable: true);
        }
    }
}
