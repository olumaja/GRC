using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNewUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "DepartmentId", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("268d2016-a662-4c85-a3b2-5d4cfeeb33ee"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 5, 22, 12, 12, 9, DateTimeKind.Utc).AddTicks(1801), null, new Guid("059d49f4-3cdc-4c20-8a1c-d5ed7f8d2791"), false, null, null, "Account Executives" },
                    { new Guid("81c6034f-0951-4de7-a51b-f4471168c94d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 5, 22, 12, 12, 9, DateTimeKind.Utc).AddTicks(1795), null, new Guid("059d49f4-3cdc-4c20-8a1c-d5ed7f8d2791"), false, null, null, "Customer Onboarding & Data Mgt Team" },
                    { new Guid("bb208834-9b69-4f5b-a283-54c0fd69cf45"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 5, 22, 12, 12, 9, DateTimeKind.Utc).AddTicks(1798), null, new Guid("059d49f4-3cdc-4c20-8a1c-d5ed7f8d2791"), false, null, null, "Relationship Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("268d2016-a662-4c85-a3b2-5d4cfeeb33ee"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("81c6034f-0951-4de7-a51b-f4471168c94d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bb208834-9b69-4f5b-a283-54c0fd69cf45"));
        }
    }
}
