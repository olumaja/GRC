using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRoleToUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"),
                columns: new[] { "CreatedOnUtc", "Name" },
                values: new object[] { new DateTime(2024, 10, 11, 14, 27, 11, 143, DateTimeKind.Utc).AddTicks(5858), "FINCON" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[] { new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 10, 11, 14, 27, 11, 143, DateTimeKind.Utc).AddTicks(5861), null, false, null, null, "Treasury" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("920CD077-FDE0-42CD-8682-5EDF3334599E"),
                columns: new[] { "CreatedOnUtc", "UserRoleId" },
                values: new object[] { new DateTime(2024, 10, 11, 14, 27, 11, 143, DateTimeKind.Utc).AddTicks(5858), new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("FE45E8EE-27F3-4973-B0E9-7287CC369C47"),
                columns: new[] { "CreatedOnUtc", "UserRoleId" },
                values: new object[] { new DateTime(2024, 10, 11, 14, 27, 11, 143, DateTimeKind.Utc).AddTicks(5858), new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"),
                columns: new[] { "CreatedOnUtc", "Name" },
                values: new object[] { new DateTime(2024, 9, 28, 8, 20, 7, 769, DateTimeKind.Utc).AddTicks(1100), "FINCONTreasury" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("920CD077-FDE0-42CD-8682-5EDF3334599E"),
                columns: new[] { "CreatedOnUtc", "UserRoleId" },
                values: new object[] { new DateTime(2024, 10, 11, 14, 27, 11, 143, DateTimeKind.Utc).AddTicks(5858), new Guid("2D15AB00-F3BA-4B7F-AB78-6B0DBCFAE65C") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("FE45E8EE-27F3-4973-B0E9-7287CC369C47"),
                columns: new[] { "CreatedOnUtc", "UserRoleId" },
                values: new object[] { new DateTime(2024, 10, 11, 14, 27, 11, 143, DateTimeKind.Utc).AddTicks(5858), new Guid("2D15AB00-F3BA-4B7F-AB78-6B0DBCFAE65C") });
        }
    }
}
