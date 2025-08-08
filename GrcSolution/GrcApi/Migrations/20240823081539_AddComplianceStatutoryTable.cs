using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddComplianceStatutoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplianceStatutoryPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessEntity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PayingUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Regulator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatutoryPayment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentFrequency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CashRemittanceStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SubmissionToStatutoryBody = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceStatutoryPayment", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplianceStatutoryPayment");
        }
    }
}
