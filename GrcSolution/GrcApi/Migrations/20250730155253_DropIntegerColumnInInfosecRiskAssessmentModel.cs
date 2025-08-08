using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class DropIntegerColumnInInfosecRiskAssessmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetValue",
                table: "InfosecRiskAssessmentModel");

            migrationBuilder.DropColumn(
                name: "ResidualRisk",
                table: "InfosecRiskAssessmentModel");

            migrationBuilder.DropColumn(
                name: "RiskScore",
                table: "InfosecRiskAssessmentModel");

            migrationBuilder.DropColumn(
                name: "RiskValue",
                table: "InfosecRiskAssessmentModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssetValue",
                table: "InfosecRiskAssessmentModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResidualRisk",
                table: "InfosecRiskAssessmentModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskScore",
                table: "InfosecRiskAssessmentModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskValue",
                table: "InfosecRiskAssessmentModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
