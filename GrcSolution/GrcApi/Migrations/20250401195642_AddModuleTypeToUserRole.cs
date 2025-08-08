using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddModuleTypeToUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModuleItemType",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2056820f-51e8-43c2-80d4-512346cc813c"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4869), 10 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4874), 0 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4842), 2 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4864), 7 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4848), 0 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4857), 0 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4822), 1 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4867), 7 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4845), 2 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4819), 1 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4852), 7 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d667eed-04db-481c-9ae0-1c7e614e4507"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4807), null });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4855), 7 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4827), 2 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("a8cac012-b665-481a-8028-90ed1c4226f9"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4824), 1 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4832), 2 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4850), 0 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4859), 0 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4876), null });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4872), 10 });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"),
                columns: new[] { "CreatedOnUtc", "ModuleItemType" },
                values: new object[] { new DateTime(2025, 4, 1, 19, 56, 39, 237, DateTimeKind.Utc).AddTicks(4829), 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleItemType",
                table: "UserRole");

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2056820f-51e8-43c2-80d4-512346cc813c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2569));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2577));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2596));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2573));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d667eed-04db-481c-9ae0-1c7e614e4507"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2529));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("a8cac012-b665-481a-8028-90ed1c4226f9"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2599));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2623));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 4, 1, 18, 43, 12, 889, DateTimeKind.Utc).AddTicks(2562));
        }
    }
}
