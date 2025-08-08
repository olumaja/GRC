using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRequesterAndApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Approval",
                table: "RiskControlSelfAssessmentUnit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "RiskControlSelfAssessmentUnit",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Requester",
                table: "RiskControlSelfAssessmentUnit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approval",
                table: "RiskControlSelfAssessmentUnit");

            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "RiskControlSelfAssessmentUnit");

            migrationBuilder.DropColumn(
                name: "Requester",
                table: "RiskControlSelfAssessmentUnit");
        }
    }
}
