using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddmorefieldsOperationControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "OperationControl",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateResolved",
                table: "OperationControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResolutionStatus",
                table: "OperationControl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionAmount",
                table: "OperationControl",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "OperationControl",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "OperationControl");

            migrationBuilder.DropColumn(
                name: "DateResolved",
                table: "OperationControl");

            migrationBuilder.DropColumn(
                name: "ResolutionStatus",
                table: "OperationControl");

            migrationBuilder.DropColumn(
                name: "TransactionAmount",
                table: "OperationControl");

            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "OperationControl");
        }
    }
}
