using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNewRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 836, DateTimeKind.Utc).AddTicks(2564), null, false, null, null, "OperationControlOfficer" },
                    { new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 836, DateTimeKind.Utc).AddTicks(2567), null, false, null, null, "OperationControlSupervisor" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("07c15ed0-5e2b-4b25-b512-72dc3660f78e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6302), null, "james.agu@arm.com.ng", false, null, null, "James Agu", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") },
                    { new Guid("1562d33d-6360-4553-841f-82a7e43a3c6c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6285), null, "adeolu.folayira@arm.com.ng", false, null, null, "Adeolu Folayira", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") },
                    { new Guid("3c9bb058-61d1-4a4a-8910-86924e97db97"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6295), null, "olanrewaju.fatai@arm.com.ng", false, null, null, "Olanrewaju Fatai", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") },
                    { new Guid("5f502469-e4dd-4a9e-b01e-97971462ffef"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6298), null, "oluwafunke.nasiru@arm.com.ng", false, null, null, "Oluwafunke Nasiru", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") },
                    { new Guid("63bcd68e-757a-45b1-a374-059a34b61264"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6292), null, "faizat.adeboye@arm.com.ng", false, null, null, "Faizat Adeboye", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") },
                    { new Guid("85c9f1d7-e34e-47ec-9462-51bb9d636cfe"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6288), null, "ademola.fatade@arm.com.ng", false, null, null, "Ademola Fatade", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") },
                    { new Guid("883e1b2b-7ce9-42bd-8fcb-a543e9742ca0"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6306), null, "hannah.aliu@arm.com.ng", false, null, null, "Hannah Aliu", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") },
                    { new Guid("c20c128c-79d2-4885-be1d-4b4488715c3a"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6279), null, "opeyemi.oshiyemi@arm.com.ng", false, null, null, "Opeyemi Oshiyemi", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1") },
                    { new Guid("e6c720b2-251c-4b91-9d21-d83d261262bc"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 27, 23, 45, 29, 835, DateTimeKind.Utc).AddTicks(6309), null, "taiwo.olusola@arm.com.ng", false, null, null, "Taiwo Olusola", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e6c720b2-251c-4b91-9d21-d83d261262bc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c20c128c-79d2-4885-be1d-4b4488715c3a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("883e1b2b-7ce9-42bd-8fcb-a543e9742ca0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("85c9f1d7-e34e-47ec-9462-51bb9d636cfe"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("63bcd68e-757a-45b1-a374-059a34b61264"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5f502469-e4dd-4a9e-b01e-97971462ffef"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3c9bb058-61d1-4a4a-8910-86924e97db97"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1562d33d-6360-4553-841f-82a7e43a3c6c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("07c15ed0-5e2b-4b25-b512-72dc3660f78e"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2056820f-51e8-43c2-80d4-512346cc813c"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"));
        }
    }
}
