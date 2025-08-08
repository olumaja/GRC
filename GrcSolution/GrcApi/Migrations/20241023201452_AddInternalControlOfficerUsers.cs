using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddInternalControlOfficerUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[] { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 10, 23, 20, 14, 50, 823, DateTimeKind.Utc).AddTicks(5216), null, false, null, null, "InternalControlOfficer" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("14483cd0-effa-4ba6-951a-6db29dc4be06"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 10, 23, 20, 14, 50, 823, DateTimeKind.Utc).AddTicks(2311), null, "ifeanyi.esogwa@arm.com.ng", false, null, null, "Ifeanyi Esogwa", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") },
                    { new Guid("1cd9e316-d5b7-4db3-8b64-066f9b6b4690"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 10, 23, 20, 14, 50, 823, DateTimeKind.Utc).AddTicks(2308), null, "olayinka.oyewole@arm.com.ng", false, null, null, "Olayinka Oyewole", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") },
                    { new Guid("ae283c8f-59eb-4570-88e5-879e1bd5ddb2"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 10, 23, 20, 14, 50, 823, DateTimeKind.Utc).AddTicks(2306), null, "tobby.tobby@arm.com.ng", false, null, null, "Tobby Moses Tobby", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") },
                    { new Guid("d8e5abcf-8a9d-42a6-8e6f-29d38bc3d468"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 10, 23, 20, 14, 50, 823, DateTimeKind.Utc).AddTicks(2302), null, "roselina.ajah@arm.com.ng", false, null, null, "Roselina Ajah", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") },
                    { new Guid("e5017930-5cd9-4f5b-8ec3-f2df2957a747"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 10, 23, 20, 14, 50, 823, DateTimeKind.Utc).AddTicks(2303), null, "tosin.adesope@arm.com.ng", false, null, null, "Tosin Adesope", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") },
                    { new Guid("fd9b458e-a379-4bfb-8766-e533ce16f2ee"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 10, 23, 20, 14, 50, 823, DateTimeKind.Utc).AddTicks(2305), null, "itunu.olatunde-folaji@arm.com.ng", false, null, null, "Itunu Olatunde-Folaji", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fd9b458e-a379-4bfb-8766-e533ce16f2ee"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e5017930-5cd9-4f5b-8ec3-f2df2957a747"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d8e5abcf-8a9d-42a6-8e6f-29d38bc3d468"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ae283c8f-59eb-4570-88e5-879e1bd5ddb2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1cd9e316-d5b7-4db3-8b64-066f9b6b4690"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14483cd0-effa-4ba6-951a-6db29dc4be06"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"));
        }
    }
}
