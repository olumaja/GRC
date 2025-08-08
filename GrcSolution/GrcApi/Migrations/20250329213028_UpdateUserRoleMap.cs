using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRoleMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoleMap",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("006f672b-6535-473b-b93c-11b3d9844a83"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2751), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("00830805-4cff-4380-94c2-2498b00dba7d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2708), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("00830805-4cff-4380-94c2-2498b00dba7d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2707), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("02734701-28d5-4166-ac88-065780672f10"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2794), null, false, null, null },
                    { new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("0326c783-2eb2-4723-8e92-f3d755df6c82"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2688), null, false, null, null },
                    { new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"), new Guid("09bafc7d-145b-4508-bdbe-4ab9550edaad"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2716), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("0a2aaf20-ad6f-499a-821b-88e8c4e80850"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2646), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("0a2aaf20-ad6f-499a-821b-88e8c4e80850"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2648), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("0a2aaf20-ad6f-499a-821b-88e8c4e80850"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2645), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("0ba0ccae-e71c-433e-8de4-30285f854bc8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2694), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("0ba0ccae-e71c-433e-8de4-30285f854bc8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2692), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("0daa9fb1-8858-4fa3-94c1-d26a3375679b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2666), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("0daa9fb1-8858-4fa3-94c1-d26a3375679b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2667), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("0daa9fb1-8858-4fa3-94c1-d26a3375679b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2664), null, false, null, null },
                    { new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("0f293e73-db67-4151-95a3-c37f9a578640"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2686), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("1788341d-ab99-4ac4-9c6a-aff9ebba37e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2727), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("17ec9f3f-2de4-4730-929e-0d3aaba63256"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2760), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("1ab43f1a-d3c4-4cbd-a1eb-c38a75a812f3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2732), null, false, null, null },
                    { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("1b0346b0-5186-4af1-8f80-8605f368296d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2720), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("1bac4e41-033e-49ce-8e4e-9e7632d4189b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2626), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("1c2a2eb3-c584-4185-acbb-5bbb06c10cf5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2741), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("1f409f31-01da-45c4-b08c-4d75362fe0f0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2691), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("1f409f31-01da-45c4-b08c-4d75362fe0f0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2690), null, false, null, null },
                    { new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("24158b3a-a2ab-468c-b4ee-a0361d0bd679"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2684), null, false, null, null },
                    { new Guid("8d667eed-04db-481c-9ae0-1c7e614e4507"), new Guid("24158b3a-a2ab-468c-b4ee-a0361d0bd679"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2685), null, false, null, null },
                    { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("27ac990e-7445-4be9-9206-ee36533fdabb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2721), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("27b6e67c-92a4-4166-ab21-fdf40f8c9a08"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2752), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("328cae33-88ef-4b8c-b928-a761024d2e54"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2705), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("328cae33-88ef-4b8c-b928-a761024d2e54"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2703), null, false, null, null },
                    { new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("3756232d-c562-47a7-bc5f-81d82a85964f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2676), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("3983d79c-3c87-4fd9-b05b-c7c2db777f18"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2770), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("3ce35779-1df8-48fa-818d-605c69fda68e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2784), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("3dd0786d-f3c4-4662-83ac-2420fcbfa5f3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2625), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("44aaf905-d100-4b66-ae1a-42ff22b5985c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2783), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("46759c7a-860b-48c1-972f-aeddc13fe604"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2775), null, false, null, null },
                    { new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("4736e129-0473-4b12-8305-62011ee8ba52"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2649), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("4b9592a9-c7b0-4231-9170-8f68d4b672b1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2765), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("4c116457-5a05-4e31-bec4-4e3e74d1584f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2776), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("50e7d53a-168a-474e-a981-0c21cf63ad3d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2793), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5245052a-9d22-4cbc-8552-32e40c0d1c57"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2722), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("52f6bb20-fbfe-45cd-a767-bca8c272ff4a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2696), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("52f6bb20-fbfe-45cd-a767-bca8c272ff4a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2695), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("54fba425-4415-4149-bdbf-e031c0dd5a8b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2791), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("59a2eae1-ded9-4f5d-b6e9-c8572e77f764"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2740), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5a1a94b8-f9ae-4485-af3f-cbdb507c9f5e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2723), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5bff9668-4850-4351-b37b-e6ca0048fa4c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2729), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("5d9e18df-0a3c-495b-8de4-65bf8be65a87"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2787), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5df5bba8-fa4a-40a8-b88f-ce342d1fcb4e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2780), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("62310863-e5a5-4f6c-ba97-2141acaf1e62"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2654), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("62c5e7f4-dc13-4b17-9a74-ab301cee30ee"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2761), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("63684ef0-a6ed-4d5a-9b47-568358a84670"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2640), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("63684ef0-a6ed-4d5a-9b47-568358a84670"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2641), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("63684ef0-a6ed-4d5a-9b47-568358a84670"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2639), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("66cf02d7-748e-4b59-9f3d-24ae3134a25b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2706), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("672316f2-ddd1-48f6-bc95-710d27836a3d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2746), null, false, null, null },
                    { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("69f91acc-e65c-4b4c-a43f-ef2216d220cf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2719), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("6a30b54c-54bc-41d2-ae42-4cb418bfb3a5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2730), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("6d4b51f7-929b-4894-a1f1-82b84d971880"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2764), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("72b05306-1d04-4310-8344-16e8ca7c3372"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2796), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("75d0157a-c79c-4402-9212-fd9feaf6bb3b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2749), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("75e2dc83-eb5e-4c43-9eb4-1b9c2ba3e588"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2660), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("75e2dc83-eb5e-4c43-9eb4-1b9c2ba3e588"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2659), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("7cf72076-44ad-428d-8073-d6cfb172806d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2683), null, false, null, null },
                    { new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"), new Guid("7cf72076-44ad-428d-8073-d6cfb172806d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2682), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("7eb3989a-9707-4a1e-9182-60ff86b6d44d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2774), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("7ee32b4c-07a4-4459-9ac0-577df0458611"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2679), null, false, null, null },
                    { new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"), new Guid("7ee32b4c-07a4-4459-9ac0-577df0458611"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2678), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("7f7d39f1-e068-4c3a-b6fc-02f0bc76e351"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2733), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("82eaa8ad-7483-40ca-b584-1f0546720a79"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2698), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("82eaa8ad-7483-40ca-b584-1f0546720a79"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2697), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("846503d5-9b92-4148-83a3-682b99fa1ed7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2782), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("86ef8958-9c81-4ce8-9fc6-2df53ab20599"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2759), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("87497a34-3059-4b2e-9afd-65ad4ccf9cdc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2756), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("89ec5cac-5c61-4ac5-b19a-966195dba85c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2632), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("8f71c6e3-b327-4046-ad43-783141f8b01b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2742), null, false, null, null },
                    { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("8fda951d-36fa-4263-8c66-1fba037d3765"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2717), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("95212a97-96c7-434c-a795-bb692ee58021"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2634), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("9627518a-07ee-4da8-bf71-9503615994f6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2781), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("a3b8254e-d8c1-49ae-99b3-30fe33bd5806"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2710), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("a3b8254e-d8c1-49ae-99b3-30fe33bd5806"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2709), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("a48b5840-94d2-445e-8a5f-1eeb5beb45f8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2713), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("a48b5840-94d2-445e-8a5f-1eeb5beb45f8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2711), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("a4d57608-7b78-4e09-ba49-79444f23da6c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2777), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("adcc99a7-dc88-46bb-8398-62e9ec322d5f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2771), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("af39e2a5-a893-4e07-90af-5d11d9fc0bf4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2757), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b292c77c-ec56-4e3e-bd59-4fa6de45e998"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2738), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b49fc47a-6b5d-4ec5-bb83-468b3fc04602"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2788), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b4cf0cf4-69d6-4610-b8ba-b3a39193b8e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2750), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b61100af-0f06-4ac6-85ef-80da244e4fa7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2792), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b70e5969-5638-4492-95ef-405713ee599c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2755), null, false, null, null },
                    { new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"), new Guid("b9e76d0e-46fd-48b8-8ecb-c4e1527f67eb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2715), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("bbb05cc6-492d-405d-883d-e2779bf0ab1e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2652), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("bd8f67ea-a3d0-48d3-99bd-e75f5008f974"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2672), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("bd8f67ea-a3d0-48d3-99bd-e75f5008f974"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2674), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("bd8f67ea-a3d0-48d3-99bd-e75f5008f974"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2671), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("c052329e-ff47-42e0-919d-6e6a701a96b3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2795), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("c0c800df-ac58-4fd9-88b1-63a3dbf4451c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2637), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("c0c800df-ac58-4fd9-88b1-63a3dbf4451c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2638), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("c0c800df-ac58-4fd9-88b1-63a3dbf4451c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2636), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("c15dc281-64a8-4dfe-999b-a59084327aa9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2670), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("c15dc281-64a8-4dfe-999b-a59084327aa9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2669), null, false, null, null },
                    { new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("c4a91ea0-ae99-4dc5-913f-043f14836a30"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2677), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ca9690f7-2871-4bb1-9072-cfa10bb14a0b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2762), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("cab92ccc-ca73-4e7a-acab-cd7fd0a7db3a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2644), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("cab92ccc-ca73-4e7a-acab-cd7fd0a7db3a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2643), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("cd86c3bb-c3ce-4e32-a18d-864c7be053b7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2747), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("cebab131-6b5b-4648-88a8-4f6524cb71e3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2754), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("cf9c48f2-20da-4989-b929-b2a250154126"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2736), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("d06f7e39-f81b-4062-b841-b5de4b7d98cf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2724), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("d587a654-52e1-472e-895e-15690c026b3d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2663), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("d69810b1-d0c7-4c25-9e82-29677990fe6e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2739), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("db50d28f-5f88-47fc-a160-da10003c1fc1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2734), null, false, null, null },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("ddc6903f-0a16-448a-ac10-279a5f169b13"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2656), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("ddc6903f-0a16-448a-ac10-279a5f169b13"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2657), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("ddc6903f-0a16-448a-ac10-279a5f169b13"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2655), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("de135872-a718-452f-9975-c152411c5f3d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2744), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("e143ed84-322a-4f9c-993a-12598abe894d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2789), null, false, null, null },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("e21c004e-9246-47b6-8547-6b462643ae59"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2662), null, false, null, null },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("e21c004e-9246-47b6-8547-6b462643ae59"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2661), null, false, null, null },
                    { new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"), new Guid("e2809297-1779-4454-85cc-c7c105a6a709"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2680), null, false, null, null },
                    { new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"), new Guid("e3c6a104-e732-4865-afe3-58f3e973af90"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2714), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("e4e321fa-c082-4b73-90d1-2ee8d1df57b1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2743), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("e705cfd6-c806-4a73-ad96-b831e203b7f9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2728), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ec75a36c-663d-4405-926a-8addacc6dc0f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2773), null, false, null, null },
                    { new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("ed7fa8c7-7bbb-4a7c-94b2-c25aaace3fb1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2675), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ed8fd2d3-536b-477a-b27d-aa52171de2f7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2758), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ee3838b7-b264-41ce-96df-5fb233b7fc83"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2779), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ee8dd936-36b8-4492-aa97-9eb78a88d051"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2745), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("eefdd975-bbe9-44dd-a654-2992ddd303dd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2786), null, false, null, null },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("ef7040f3-cff3-40ab-871f-d7da70c41581"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2726), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("f0790dc3-bb5b-4086-9ea1-7967b337fc5f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2735), null, false, null, null },
                    { new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("fd37f00f-06f2-400b-a883-05ded0522c6b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2651), null, false, null, null },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("fe525ead-e18a-4e3f-852d-ca1854139dc0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 29, 21, 30, 26, 387, DateTimeKind.Utc).AddTicks(2689), null, false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("006f672b-6535-473b-b93c-11b3d9844a83") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("00830805-4cff-4380-94c2-2498b00dba7d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("00830805-4cff-4380-94c2-2498b00dba7d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("02734701-28d5-4166-ac88-065780672f10") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("0326c783-2eb2-4723-8e92-f3d755df6c82") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"), new Guid("09bafc7d-145b-4508-bdbe-4ab9550edaad") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("0a2aaf20-ad6f-499a-821b-88e8c4e80850") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("0a2aaf20-ad6f-499a-821b-88e8c4e80850") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("0a2aaf20-ad6f-499a-821b-88e8c4e80850") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("0ba0ccae-e71c-433e-8de4-30285f854bc8") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("0ba0ccae-e71c-433e-8de4-30285f854bc8") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("0daa9fb1-8858-4fa3-94c1-d26a3375679b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("0daa9fb1-8858-4fa3-94c1-d26a3375679b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("0daa9fb1-8858-4fa3-94c1-d26a3375679b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("0f293e73-db67-4151-95a3-c37f9a578640") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("1788341d-ab99-4ac4-9c6a-aff9ebba37e6") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("17ec9f3f-2de4-4730-929e-0d3aaba63256") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("1ab43f1a-d3c4-4cbd-a1eb-c38a75a812f3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("1b0346b0-5186-4af1-8f80-8605f368296d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("1bac4e41-033e-49ce-8e4e-9e7632d4189b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("1c2a2eb3-c584-4185-acbb-5bbb06c10cf5") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("1f409f31-01da-45c4-b08c-4d75362fe0f0") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("1f409f31-01da-45c4-b08c-4d75362fe0f0") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("24158b3a-a2ab-468c-b4ee-a0361d0bd679") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d667eed-04db-481c-9ae0-1c7e614e4507"), new Guid("24158b3a-a2ab-468c-b4ee-a0361d0bd679") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("27ac990e-7445-4be9-9206-ee36533fdabb") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("27b6e67c-92a4-4166-ab21-fdf40f8c9a08") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("328cae33-88ef-4b8c-b928-a761024d2e54") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("328cae33-88ef-4b8c-b928-a761024d2e54") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("3756232d-c562-47a7-bc5f-81d82a85964f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("3983d79c-3c87-4fd9-b05b-c7c2db777f18") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("3ce35779-1df8-48fa-818d-605c69fda68e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("3dd0786d-f3c4-4662-83ac-2420fcbfa5f3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("44aaf905-d100-4b66-ae1a-42ff22b5985c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("46759c7a-860b-48c1-972f-aeddc13fe604") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("4736e129-0473-4b12-8305-62011ee8ba52") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("4b9592a9-c7b0-4231-9170-8f68d4b672b1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("4c116457-5a05-4e31-bec4-4e3e74d1584f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("50e7d53a-168a-474e-a981-0c21cf63ad3d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5245052a-9d22-4cbc-8552-32e40c0d1c57") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("52f6bb20-fbfe-45cd-a767-bca8c272ff4a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("52f6bb20-fbfe-45cd-a767-bca8c272ff4a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("54fba425-4415-4149-bdbf-e031c0dd5a8b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("59a2eae1-ded9-4f5d-b6e9-c8572e77f764") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5a1a94b8-f9ae-4485-af3f-cbdb507c9f5e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5bff9668-4850-4351-b37b-e6ca0048fa4c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("5d9e18df-0a3c-495b-8de4-65bf8be65a87") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5df5bba8-fa4a-40a8-b88f-ce342d1fcb4e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("62310863-e5a5-4f6c-ba97-2141acaf1e62") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("62c5e7f4-dc13-4b17-9a74-ab301cee30ee") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("63684ef0-a6ed-4d5a-9b47-568358a84670") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("63684ef0-a6ed-4d5a-9b47-568358a84670") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("63684ef0-a6ed-4d5a-9b47-568358a84670") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("66cf02d7-748e-4b59-9f3d-24ae3134a25b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("672316f2-ddd1-48f6-bc95-710d27836a3d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("69f91acc-e65c-4b4c-a43f-ef2216d220cf") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("6a30b54c-54bc-41d2-ae42-4cb418bfb3a5") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("6d4b51f7-929b-4894-a1f1-82b84d971880") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("72b05306-1d04-4310-8344-16e8ca7c3372") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("75d0157a-c79c-4402-9212-fd9feaf6bb3b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("75e2dc83-eb5e-4c43-9eb4-1b9c2ba3e588") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("75e2dc83-eb5e-4c43-9eb4-1b9c2ba3e588") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("7cf72076-44ad-428d-8073-d6cfb172806d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"), new Guid("7cf72076-44ad-428d-8073-d6cfb172806d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("7eb3989a-9707-4a1e-9182-60ff86b6d44d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("7ee32b4c-07a4-4459-9ac0-577df0458611") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"), new Guid("7ee32b4c-07a4-4459-9ac0-577df0458611") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("7f7d39f1-e068-4c3a-b6fc-02f0bc76e351") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("82eaa8ad-7483-40ca-b584-1f0546720a79") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("82eaa8ad-7483-40ca-b584-1f0546720a79") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("846503d5-9b92-4148-83a3-682b99fa1ed7") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("86ef8958-9c81-4ce8-9fc6-2df53ab20599") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("87497a34-3059-4b2e-9afd-65ad4ccf9cdc") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("89ec5cac-5c61-4ac5-b19a-966195dba85c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("8f71c6e3-b327-4046-ad43-783141f8b01b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("8fda951d-36fa-4263-8c66-1fba037d3765") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("95212a97-96c7-434c-a795-bb692ee58021") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("9627518a-07ee-4da8-bf71-9503615994f6") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("a3b8254e-d8c1-49ae-99b3-30fe33bd5806") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("a3b8254e-d8c1-49ae-99b3-30fe33bd5806") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("a48b5840-94d2-445e-8a5f-1eeb5beb45f8") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("a48b5840-94d2-445e-8a5f-1eeb5beb45f8") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("a4d57608-7b78-4e09-ba49-79444f23da6c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("adcc99a7-dc88-46bb-8398-62e9ec322d5f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("af39e2a5-a893-4e07-90af-5d11d9fc0bf4") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b292c77c-ec56-4e3e-bd59-4fa6de45e998") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b49fc47a-6b5d-4ec5-bb83-468b3fc04602") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b4cf0cf4-69d6-4610-b8ba-b3a39193b8e6") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b61100af-0f06-4ac6-85ef-80da244e4fa7") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("b70e5969-5638-4492-95ef-405713ee599c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"), new Guid("b9e76d0e-46fd-48b8-8ecb-c4e1527f67eb") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("bbb05cc6-492d-405d-883d-e2779bf0ab1e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("bd8f67ea-a3d0-48d3-99bd-e75f5008f974") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("bd8f67ea-a3d0-48d3-99bd-e75f5008f974") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("bd8f67ea-a3d0-48d3-99bd-e75f5008f974") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("c052329e-ff47-42e0-919d-6e6a701a96b3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("c0c800df-ac58-4fd9-88b1-63a3dbf4451c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("c0c800df-ac58-4fd9-88b1-63a3dbf4451c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("c0c800df-ac58-4fd9-88b1-63a3dbf4451c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("c15dc281-64a8-4dfe-999b-a59084327aa9") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("c15dc281-64a8-4dfe-999b-a59084327aa9") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("c4a91ea0-ae99-4dc5-913f-043f14836a30") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ca9690f7-2871-4bb1-9072-cfa10bb14a0b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("cab92ccc-ca73-4e7a-acab-cd7fd0a7db3a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("cab92ccc-ca73-4e7a-acab-cd7fd0a7db3a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("cd86c3bb-c3ce-4e32-a18d-864c7be053b7") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("cebab131-6b5b-4648-88a8-4f6524cb71e3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("cf9c48f2-20da-4989-b929-b2a250154126") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("d06f7e39-f81b-4062-b841-b5de4b7d98cf") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("d587a654-52e1-472e-895e-15690c026b3d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("d69810b1-d0c7-4c25-9e82-29677990fe6e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("db50d28f-5f88-47fc-a160-da10003c1fc1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("ddc6903f-0a16-448a-ac10-279a5f169b13") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("ddc6903f-0a16-448a-ac10-279a5f169b13") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("ddc6903f-0a16-448a-ac10-279a5f169b13") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("de135872-a718-452f-9975-c152411c5f3d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("e143ed84-322a-4f9c-993a-12598abe894d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("e21c004e-9246-47b6-8547-6b462643ae59") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("e21c004e-9246-47b6-8547-6b462643ae59") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"), new Guid("e2809297-1779-4454-85cc-c7c105a6a709") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"), new Guid("e3c6a104-e732-4865-afe3-58f3e973af90") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("e4e321fa-c082-4b73-90d1-2ee8d1df57b1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("e705cfd6-c806-4a73-ad96-b831e203b7f9") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ec75a36c-663d-4405-926a-8addacc6dc0f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("ed7fa8c7-7bbb-4a7c-94b2-c25aaace3fb1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ed8fd2d3-536b-477a-b27d-aa52171de2f7") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ee3838b7-b264-41ce-96df-5fb233b7fc83") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ee8dd936-36b8-4492-aa97-9eb78a88d051") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("eefdd975-bbe9-44dd-a654-2992ddd303dd") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("ef7040f3-cff3-40ab-871f-d7da70c41581") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("f0790dc3-bb5b-4086-9ea1-7967b337fc5f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("fd37f00f-06f2-400b-a883-05ded0522c6b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("fe525ead-e18a-4e3f-852d-ca1854139dc0") });
        }
    }
}
