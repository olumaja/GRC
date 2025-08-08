using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditTraitToComplianceStatutoryPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "ComplianceStatutoryPayment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "ComplianceStatutoryPayment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Initiator",
                table: "ComplianceStatutoryPayment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                table: "ComplianceStatutoryPayment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessOfficer",
                table: "ComplianceStatutoryPayment",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessedDate",
                table: "ComplianceStatutoryPayment",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "ComplianceStatutoryPayment");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "ComplianceStatutoryPayment");

            migrationBuilder.DropColumn(
                name: "Initiator",
                table: "ComplianceStatutoryPayment");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "ComplianceStatutoryPayment");

            migrationBuilder.DropColumn(
                name: "ProcessOfficer",
                table: "ComplianceStatutoryPayment");

            migrationBuilder.DropColumn(
                name: "ProcessedDate",
                table: "ComplianceStatutoryPayment");
        }
    }
}
