using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class infosecrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "ModuleItemType", "Name" },
                values: new object[] { new Guid("2fc82d56-b5ac-44a6-8f5e-3ea708d722e5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 30, 0, 36, 23, 924, DateTimeKind.Utc).AddTicks(2826), null, false, null, null, 13, "InfoSec Officer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2fc82d56-b5ac-44a6-8f5e-3ea708d722e5"));
        }
    }
}
