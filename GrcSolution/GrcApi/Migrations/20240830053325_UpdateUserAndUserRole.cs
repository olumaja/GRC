using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAndUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(3187), null, false, null, null, "FINCONTreasury" },
                    { new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(3185), null, false, null, null, "HROfficer" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("10116115-1311-4beb-aa9a-2b5eab9a4a9b"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(74), null, "babatunde.osho@arm.com.ng", false, null, null, "Babatunde Osho", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                    { new Guid("5ffd7f36-4ab5-4c6e-8393-321c86f9b44a"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(70), null, "temitope.akinola@arm.com.ng", false, null, null, "Temitope Akinola", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                    { new Guid("920cd077-fde0-42cd-8682-5edf3334599e"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(76), null, "ifeoma.ofili@arm.com.ng ", false, null, null, "Ifeoma Ofili", "Treasury", new Guid("a0d8712a-f6dd-4f64-a9b0-dcc204e52287"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                    { new Guid("9dc682a9-9607-4ad3-821d-709eafa60b19"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(71), null, "stephanie.gber@arm.com.ng", false, null, null, "Stephanie Gber", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                    { new Guid("d099db0d-bd43-4d36-b0c9-1fe956b6c9b1"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(73), null, "elizabeth.alloy@arm.com.ng", false, null, null, "Elizabeth Alloy", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                    { new Guid("fe45e8ee-27f3-4973-b0e9-7287cc369c47"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(78), null, "ademola.adebisi@arm.com.ng ", false, null, null, "Ademola Adebisi", "Treasury", new Guid("a0d8712a-f6dd-4f64-a9b0-dcc204e52287"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                    { new Guid("feffa1ff-11e9-4063-9c63-e37f3783fef1"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 30, 5, 33, 24, 165, DateTimeKind.Utc).AddTicks(66), null, "ogugua.emamoke@arm.com.ng", false, null, null, "Ogugua Emamoke", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10116115-1311-4beb-aa9a-2b5eab9a4a9b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5ffd7f36-4ab5-4c6e-8393-321c86f9b44a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("920cd077-fde0-42cd-8682-5edf3334599e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9dc682a9-9607-4ad3-821d-709eafa60b19"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d099db0d-bd43-4d36-b0c9-1fe956b6c9b1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fe45e8ee-27f3-4973-b0e9-7287cc369c47"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("feffa1ff-11e9-4063-9c63-e37f3783fef1"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"));
        }
    }
}
