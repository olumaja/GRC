using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class InformationRequirementUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "InformationRequirementAuditExecution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommenceEngagementAuditexecutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InformationRequest = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    ResponsibleOfficer = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateProvided = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InformationRequirementCompleted = table.Column<bool>(type: "bit", nullable: true),
                    EngagementLetterCompleted = table.Column<bool>(type: "bit", nullable: true),
                    ReasonForRejection = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationRequirementAuditExecution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformationRequirementAuditExecution_CommenceEngagementAuditexecution_CommenceEngagementAuditexecutionId",
                        column: x => x.CommenceEngagementAuditexecutionId,
                        principalTable: "CommenceEngagementAuditexecution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationRequirementAuditExecution_CommenceEngagementAuditexecutionId",
                table: "InformationRequirementAuditExecution",
                column: "CommenceEngagementAuditexecutionId");
        }

       
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        
        }
    }
}
