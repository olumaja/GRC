using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class DropApproveBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "InternalControlModel");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "InternalControlModel");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                table: "InternalControlModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "InternalControlActionOwner",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "InternalControlActionOwner",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                table: "InternalControlActionOwner",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "InternalControlActionOwner");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "InternalControlActionOwner");

            migrationBuilder.DropColumn(
                name: "ReasonForRejection",
                table: "InternalControlActionOwner");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "InternalControlModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "InternalControlModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForRejection",
                table: "InternalControlModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
