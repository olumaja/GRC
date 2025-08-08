using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class OluwatosinARMPrivateTrust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.UpdateData(
                table: "User",
                keyColumns: new[] { "Id" },
                keyValues: new object[] { new Guid("6de1a7fc-b57e-4283-8e46-edea9631ce32") },
                column: "Unit",
                value: "ARM Private Trust");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.UpdateData(
                table: "User",
                keyColumns: new[] { "Id"},
                keyValues: new object[] { new Guid("6de1a7fc-b57e-4283-8e46-edea9631ce32") },
                column: "Unit",
                value: "ARM Private Trust");

        }
    }
}
