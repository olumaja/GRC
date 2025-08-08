using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AuditAnnouncementMemoAuditExecution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "Policies",
                table: "AuditPlanningMemoAuditExecution",
                type: "nvarchar(MAX)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemOverview",
                table: "AuditPlanningMemoAuditExecution",
                type: "nvarchar(MAX)",
                maxLength: 50,
                nullable: true);

          

         }
    }
}
