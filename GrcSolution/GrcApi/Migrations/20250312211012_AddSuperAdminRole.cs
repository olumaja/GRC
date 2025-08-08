using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSuperAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[] { new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 12, 21, 10, 9, 741, DateTimeKind.Utc).AddTicks(9927), null, false, null, null, "SuperAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"));
        }
    }
}
