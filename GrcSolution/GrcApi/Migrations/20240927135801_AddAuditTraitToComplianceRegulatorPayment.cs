using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditTraitToComplianceRegulatorPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "ComplianceRegulatoryPayment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "ComplianceRegulatoryPayment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Initiator",
                table: "ComplianceRegulatoryPayment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "ComplianceRegulatoryPayment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "ComplianceRegulatoryPayment");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "ComplianceRegulatoryPayment");

            migrationBuilder.DropColumn(
                name: "Initiator",
                table: "ComplianceRegulatoryPayment");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "ComplianceRegulatoryPayment");
        }
    }
}
