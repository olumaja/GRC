using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreCalloverUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                   { new Guid("6c1523ca-a422-4f1c-931b-36036a6564ed"), "ARM TRUSTEES", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2226), null, "Emmanuella.Anaza@arm.com.ng", false, null, null, "Emmanuella Anaza", "Financial Control", new Guid("90cd9708-b7b4-4203-ba98-6ce8c66e623e"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                   { new Guid("a17ac38a-7843-4f74-8d02-9258339d2bde"), "ARM TRUSTEES", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2212), null, "Emmanuella.Anaza@arm.com.ng", false, null, null, "Emmanuella Anaza", "Financial Control", new Guid("90cd9708-b7b4-4203-ba98-6ce8c66e623e"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                   { new Guid("cae4c13c-5e2c-49f6-b9b2-d9b333cf60e5"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2213), null, "sandra.onwordi@arm.com.ng", false, null, null, "Sandra Onwordi", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                   { new Guid("f4fdd963-e2a9-4ba8-899c-596c2aa53af0"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2227), null, "sandra.onwordi@arm.com.ng", false, null, null, "Sandra Onwordi", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                   { new Guid("aefb3d2e-58f9-4968-9e2e-acb559f36699"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2217), null, "oluwatomilola.oduntan@arm.com.ng", false, null, null, "Oluwatomilola Oduntan", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                   { new Guid("f037ea0a-22e4-4492-b6d1-4b26ca04063f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2215), null, "oluwatomilola.oduntan@arm.com.ng", false, null, null, "Oluwatomilola Oduntan", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                   { new Guid("4d7050c2-9566-4cb5-8fda-13944d6c6ad5"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2219), null, "oluwatosin.adeboyejo@arm.com.ng", false, null, null, "Oluwatosin Adeboyejo", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                   { new Guid("a83c7a73-13e4-40d3-909e-0ddb3d2e855d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2175), null, "oluwatosin.adeboyejo@arm.com.ng", false, null, null, "Oluwatosin Adeboyejo", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                   { new Guid("7bb70e75-53db-4b64-bc5f-3ac3323377e4"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2221), null, "evelyn.nwogu@arm.com.ng", false, null, null, "Evelyn Nwogu", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                   { new Guid("eb26f184-a064-4f36-a8ea-59821720dbb0"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2192), null, "evelyn.nwogu@arm.com.ng", false, null, null, "Evelyn Nwogu", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                   { new Guid("155b8e5e-c4d0-4e83-89c1-3f99dac80088"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2333), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                   { new Guid("722958f4-3ec3-46fb-8655-2aab75e3c489"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2160), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                   { new Guid("75eb9912-324f-496c-a52a-740396fb2302"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2316), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                   { new Guid("0be73c83-9343-44cf-900e-55f3b3a0eb76"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2224), null, "olawale.bakir@arm.com.ng", false, null, null, "Olawale Bakir", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") },
                   { new Guid("ed8bd532-b608-447d-a636-00c9aa851886"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2194), null, "olawale.bakir@arm.com.ng", false, null, null, "Olawale Bakir", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                   { new Guid("6f1c401c-97b6-477a-a994-3358eabca32c"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2230), null, "abiola.itakpe@arm.com.ng", false, null, null, "Abiola Itakpe", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86") },
                   { new Guid("586e01d0-5be7-41a2-a13a-a70f11f14126"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2232), null, "chidinma.akosa@arm.com.ng", false, null, null, "Chidinma Akosa", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86") },
                   { new Guid("b3fa0ec8-b74e-4d69-9eea-4d1bebccc0cc"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2249), null, "victoria.itrechio@arm.com.ng", false, null, null, "Victoria Itrechio", "Treasury", new Guid("a0d8712a-f6dd-4f64-a9b0-dcc204e52287"), new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81") },
                   { new Guid("8242f797-4331-4589-a62a-28c715d2af6b"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2339), null, "ifeoluwa.okunoye@arm.com.ng", false, null, null, "Ifeoluwani Okunoye", "Register", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                   { new Guid("2cf2895f-2fcb-4975-8a0f-8b5ca6af6d6f"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2340), null, "bukunmi.chuka@arm.com.ng", false, null, null, "Bukunmi Chuka", "Register", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                   { new Guid("8044ee70-14d6-4d58-8f33-c7b669142240"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2343), null, "rosemary.francis@arm.com.ng", false, null, null, "Rosemary Francis", "Settlement", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                   { new Guid("c064ce2b-afa5-4e10-bb31-cbe1635b847d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2344), null, "busola.alakija@arm.com.ng", false, null, null, "Busola Alakija", "Settlement", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                   { new Guid("2e1e45de-8f69-4b7a-8a52-924c6c08e9ae"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2347), null, "tawio.odumuyiwa@arm.com.ng", false, null, null, "Tawio Odumuyiwa", "Customer Service", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                   { new Guid("038ec42b-a09a-462f-beb4-35658993d174"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2348), null, "amara.nwafor@arm.com.ng", false, null, null, "Amara Nwafor", "Customer Service", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                   { new Guid("ffd3a51e-3f36-455e-9c22-117e6adae361"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 8, 16, 6, 33, 262, DateTimeKind.Utc).AddTicks(2350), null, "chisom.okeke@arm.com.ng", false, null, null, "Chisom Okeke", "Customer Service", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6c1523ca-a422-4f1c-931b-36036a6564ed"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a17ac38a-7843-4f74-8d02-9258339d2bde"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cae4c13c-5e2c-49f6-b9b2-d9b333cf60e5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f4fdd963-e2a9-4ba8-899c-596c2aa53af0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("aefb3d2e-58f9-4968-9e2e-acb559f36699"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f037ea0a-22e4-4492-b6d1-4b26ca04063f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4d7050c2-9566-4cb5-8fda-13944d6c6ad5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a83c7a73-13e4-40d3-909e-0ddb3d2e855d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7bb70e75-53db-4b64-bc5f-3ac3323377e4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eb26f184-a064-4f36-a8ea-59821720dbb0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("155b8e5e-c4d0-4e83-89c1-3f99dac80088"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("722958f4-3ec3-46fb-8655-2aab75e3c489"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75eb9912-324f-496c-a52a-740396fb2302"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0be73c83-9343-44cf-900e-55f3b3a0eb76"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ed8bd532-b608-447d-a636-00c9aa851886"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6f1c401c-97b6-477a-a994-3358eabca32c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("586e01d0-5be7-41a2-a13a-a70f11f14126"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b3fa0ec8-b74e-4d69-9eea-4d1bebccc0cc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8242f797-4331-4589-a62a-28c715d2af6b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2cf2895f-2fcb-4975-8a0f-8b5ca6af6d6f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8044ee70-14d6-4d58-8f33-c7b669142240"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c064ce2b-afa5-4e10-bb31-cbe1635b847d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2e1e45de-8f69-4b7a-8a52-924c6c08e9ae"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("038ec42b-a09a-462f-beb4-35658993d174"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ffd3a51e-3f36-455e-9c22-117e6adae361"));
        }
    }
}
