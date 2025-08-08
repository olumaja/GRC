using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAuditExecution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                        
            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "WorkPaper",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "InformationRequirementAuditExecution",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "EngagementLetterAuditExecution",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "AuditProgramAuditExecution",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "AuditPlanningMemoAuditExecution",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "AuditFindings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "AuditAnnouncementMemoAuditExecution",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "Team",
                table: "WorkPaper");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "InformationRequirementAuditExecution");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "EngagementLetterAuditExecution");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "AuditProgramAuditExecution");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "AuditPlanningMemoAuditExecution");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "AuditFindings");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "AuditAnnouncementMemoAuditExecution");


        }
    }
}
