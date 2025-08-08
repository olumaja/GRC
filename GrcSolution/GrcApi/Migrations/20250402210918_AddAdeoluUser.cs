using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAdeoluUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Department", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "ModuleItemType", "Name", "Status", "Unit", "UnitId" },
                values: new object[,]
                {
                    { new Guid("4b510482-51c3-43ed-98d9-bc58cdd53cd3"), "ARM IM", null, new DateTime(2025, 4, 2, 21, 9, 15, 444, DateTimeKind.Utc).AddTicks(5657), null, null, "adeolu.folayira@arm.com.ng", false, null, null, null, "Adeolu Folayira", 0, "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") }                   
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4b510482-51c3-43ed-98d9-bc58cdd53cd3"));
        }
    }
}
