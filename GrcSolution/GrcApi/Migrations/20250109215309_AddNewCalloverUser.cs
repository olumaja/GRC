using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCalloverUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("53dd0f5d-1f6d-4136-9d59-1b6a19c860ac"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 9, 21, 53, 7, 508, DateTimeKind.Utc).AddTicks(1275), null, "victor.arowolo@arm.com.ng", false, null, null, "Victor Arowolo", "Operations Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("6d79105d-7c20-46c3-bee7-a92fc1d45491"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 9, 21, 53, 7, 508, DateTimeKind.Utc).AddTicks(1280), null, "babatunde.osho@arm.com.ng", false, null, null, "Babatunde Osho", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("eda70617-a843-4a8c-a0a6-55870a24d9ed"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 9, 21, 53, 7, 508, DateTimeKind.Utc).AddTicks(1277), null, "gift.aizebeoje@arm.com.ng", false, null, null, "Gift Aizebeoje", "Operations Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("ab4f1183-a4bd-4c14-9f92-ae2520bd311e"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 9, 21, 53, 7, 508, DateTimeKind.Utc).AddTicks(1280), null, "stephanie.gber@arm.com.ng", false, null, null, "Stephanie Gber", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("53dd0f5d-1f6d-4136-9d59-1b6a19c860ac"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6d79105d-7c20-46c3-bee7-a92fc1d45491"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eda70617-a843-4a8c-a0a6-55870a24d9ed"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ab4f1183-a4bd-4c14-9f92-ae2520bd311e"));
        }
    }
}
