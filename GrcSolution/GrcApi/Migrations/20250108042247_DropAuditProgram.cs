using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class DropAuditProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditFindings");

            migrationBuilder.DropTable(
                name: "WorkPaper");

            migrationBuilder.DropTable(
                name: "AuditProgramAuditExecution");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditProgramAuditExecution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommenceEngagementAuditexecutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditProgramCompleted = table.Column<bool>(type: "bit", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    ControlDescription = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    ControlObjective = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FindingStatus = table.Column<int>(type: "int", nullable: false),
                    InformationRequired = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    IsAuditFindingInitiated = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsWorkPaperInitiated = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonForRejection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReviewProcedure = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    RiskDescription = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubProcess = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    WorkpaperStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditProgramAuditExecution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditProgramAuditExecution_CommenceEngagementAuditexecution_CommenceEngagementAuditexecutionId",
                        column: x => x.CommenceEngagementAuditexecutionId,
                        principalTable: "CommenceEngagementAuditexecution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkPaper",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditProgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExceptionsNoted = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    Impact = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    IsAuditFindingInitiated = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IssueRating = table.Column<int>(type: "int", nullable: false),
                    IssueSummary = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    Reoccurrence = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    ReviewResult = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    RootCause = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPaper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPaper_AuditProgramAuditExecution_AuditProgramId",
                        column: x => x.AuditProgramId,
                        principalTable: "AuditProgramAuditExecution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditFindings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkerPaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionOwner = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    ActionOwnerUnit = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    ActionToPreventReoccurrence = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    ActionToResolve = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditFindings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditFindings_WorkPaper_WorkerPaperId",
                        column: x => x.WorkerPaperId,
                        principalTable: "WorkPaper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditFindings_WorkerPaperId",
                table: "AuditFindings",
                column: "WorkerPaperId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditProgramAuditExecution_CommenceEngagementAuditexecutionId",
                table: "AuditProgramAuditExecution",
                column: "CommenceEngagementAuditexecutionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkPaper_AuditProgramId",
                table: "WorkPaper",
                column: "AuditProgramId",
                unique: true);
        }
    }
}
