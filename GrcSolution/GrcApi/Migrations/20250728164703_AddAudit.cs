using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PlannedControlAnnexture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "PlannedControlAnnexture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "PlannedControlAnnexture",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "PlannedControlAnnexture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlannedControlAnnexture",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PlannedControlAnnexture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "PlannedControlAnnexture",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExistingPrimaryControlAnnexture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "ExistingPrimaryControlAnnexture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ExistingPrimaryControlAnnexture",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "ExistingPrimaryControlAnnexture",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExistingPrimaryControlAnnexture",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ExistingPrimaryControlAnnexture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOnUtc",
                table: "ExistingPrimaryControlAnnexture",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PlannedControlAnnexture");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "PlannedControlAnnexture");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "PlannedControlAnnexture");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PlannedControlAnnexture");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlannedControlAnnexture");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PlannedControlAnnexture");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "PlannedControlAnnexture");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExistingPrimaryControlAnnexture");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "ExistingPrimaryControlAnnexture");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ExistingPrimaryControlAnnexture");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ExistingPrimaryControlAnnexture");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExistingPrimaryControlAnnexture");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ExistingPrimaryControlAnnexture");

            migrationBuilder.DropColumn(
                name: "ModifiedOnUtc",
                table: "ExistingPrimaryControlAnnexture");
        }
    }
}
