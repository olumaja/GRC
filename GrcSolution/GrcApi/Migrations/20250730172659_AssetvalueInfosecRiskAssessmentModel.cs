using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AssetvalueInfosecRiskAssessmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssetValue",
                table: "InfosecRiskAssessmentModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidualRisk",
                table: "InfosecRiskAssessmentModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RiskScore",
                table: "InfosecRiskAssessmentModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RiskValue",
                table: "InfosecRiskAssessmentModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
