using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCalloverRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 12, 15, 13, 59, 38, 434, DateTimeKind.Utc).AddTicks(8271), null, false, null, null, "InternalControlCallOverOfficer" },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 12, 15, 13, 59, 38, 434, DateTimeKind.Utc).AddTicks(8273), null, false, null, null, "InternalControlCallOverSupervisor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"));
        }
    }
}
