using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSupervisorRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[] { new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 18, 23, 14, 46, 263, DateTimeKind.Utc).AddTicks(6006), null, false, null, null, "InternalControlSupervisor" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("086af934-3e2c-417d-baf5-00bb8bb5ed57"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 18, 23, 14, 46, 262, DateTimeKind.Utc).AddTicks(9918), null, "itunu.olatunde-folaji@arm.com.ng", false, null, null, "Itunu Olatunde-Folaji", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e") },
                    { new Guid("ab4a0e44-e2f3-4dae-9fac-558b893c3100"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 18, 23, 14, 46, 262, DateTimeKind.Utc).AddTicks(9916), null, "roselina.ajah@arm.com.ng", false, null, null, "Roselina Ajah", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("086af934-3e2c-417d-baf5-00bb8bb5ed57"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ab4a0e44-e2f3-4dae-9fac-558b893c3100"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"));
        }
    }
}
