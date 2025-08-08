using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AuditPlanningMemoPlanningTimeline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "AuditPlanningMemoPlanningTimeline",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditPlanningMemoAuditExecutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tasks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Responsibility = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditPlanningMemoPlanningTimeline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditPlanningMemoPlanningTimeline_AuditPlanningMemoAuditExecution_AuditPlanningMemoAuditExecutionId",
                        column: x => x.AuditPlanningMemoAuditExecutionId,
                        principalTable: "AuditPlanningMemoAuditExecution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });         

            migrationBuilder.CreateIndex(
                name: "IX_AuditPlanningMemoPlanningTimeline_AuditPlanningMemoAuditExecutionId",
                table: "AuditPlanningMemoPlanningTimeline",
                column: "AuditPlanningMemoAuditExecutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            
        }
    }
}
