using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedStatusAntivirusAssessmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            


            migrationBuilder.AddColumn<int>(
                name: "InactiveSensorsStatus",
                table: "AntivirusAssessmentModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReducedFunctionalityModeStatus",
                table: "AntivirusAssessmentModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "InactiveSensorsStatus",
                table: "AntivirusAssessmentModel");

            migrationBuilder.DropColumn(
                name: "ReducedFunctionalityModeStatus",
                table: "AntivirusAssessmentModel");

        }
    }
}
