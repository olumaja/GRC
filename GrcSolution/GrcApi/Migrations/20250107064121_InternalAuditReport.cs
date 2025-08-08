using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class InternalAuditReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalAuditReport_BusinessRiskRating_BusinessRiskRatingId",
                table: "InternalAuditReport");

            migrationBuilder.RenameColumn(
                name: "BusinessRiskRatingId",
                table: "InternalAuditReport",
                newName: "CommenceEngagementAuditexecutionId");

            migrationBuilder.RenameIndex(
                name: "IX_InternalAuditReport_BusinessRiskRatingId",
                table: "InternalAuditReport",
                newName: "IX_InternalAuditReport_CommenceEngagementAuditexecutionId");


            migrationBuilder.AddForeignKey(
                name: "FK_InternalAuditReport_CommenceEngagementAuditexecution_CommenceEngagementAuditexecutionId",
                table: "InternalAuditReport",
                column: "CommenceEngagementAuditexecutionId",
                principalTable: "CommenceEngagementAuditexecution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalAuditReport_CommenceEngagementAuditexecution_CommenceEngagementAuditexecutionId",
                table: "InternalAuditReport");

            migrationBuilder.AddForeignKey(
                name: "FK_InternalAuditReport_BusinessRiskRating_BusinessRiskRatingId",
                table: "InternalAuditReport",
                column: "BusinessRiskRatingId",
                principalTable: "BusinessRiskRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
