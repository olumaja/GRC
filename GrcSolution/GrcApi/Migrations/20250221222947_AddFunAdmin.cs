using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFunAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("0668f587-33a8-4449-be39-7aea057c175c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 21, 22, 29, 44, 365, DateTimeKind.Utc).AddTicks(1940), null, "oluseyi.omoleye@arm.com.ng", false, null, null, "Oluseyi Omoleye", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("33926534-f378-41a7-bedd-286406f103ac"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 21, 22, 29, 44, 365, DateTimeKind.Utc).AddTicks(1481), null, "isaac.elakhe@arm.com.ng", false, null, null, "Isaac Elakhe", "ARM Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("5AF3368C-48C9-4AEA-BA95-0F361AC82CC6") },               
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0668f587-33a8-4449-be39-7aea057c175c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("33926534-f378-41a7-bedd-286406f103ac"));
        }
    }
}
