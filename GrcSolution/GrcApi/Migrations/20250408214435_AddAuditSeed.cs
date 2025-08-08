using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Module", "Name" },
                values: new object[,]
                {
                    { new Guid("1178eaab-7eac-4a3c-9a98-3d8c4b88a5f1"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2492), null, false, null, null, "Audit Execution", "Initiate work paper" },
                    { new Guid("1700f355-1943-49cb-bb43-09d91ae939d9"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2472), null, false, null, null, "Audit Execution", "Audit program" },
                    { new Guid("183358b1-ecb3-4280-bcd1-50d6cbb31e1d"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2467), null, false, null, null, "Audit Execution", "Audit engagement letter plan" },
                    { new Guid("1c10cda1-cd2a-42a4-b295-53404768dc35"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2459), null, false, null, null, "Operation Control", "Create operation control exception" },
                    { new Guid("218b0863-5156-4488-ab9a-b71c8ae9d2b4"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2449), null, false, null, null, "Internal Control - Dashboard", "Create Task" },
                    { new Guid("26a31c04-6b1d-43d5-a0d0-ea73756fa20f"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2490), null, false, null, null, "Audit Execution", "Reject Audit Planning Memo" },
                    { new Guid("26aecbd2-eb44-42b2-b83d-4b6778a9a6b8"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2453), null, false, null, null, "Internal Control - Call Over", "Reject created Call Over Report" },
                    { new Guid("39bca629-6bef-4af2-94e2-920d9ff9bc31"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2500), null, false, null, null, "Audit Execution", "Update Audit Announcement Memo" },
                    { new Guid("3cb6772e-8370-41e2-a4ff-9adfa83e038c"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2434), null, false, null, null, "Internal Control", "Approve created Internal Control" },
                    { new Guid("4ba7de16-cc9b-4f2e-9ca6-4133cd025310"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2464), null, false, null, null, "Operation Control", "Update operation control exception" },
                    { new Guid("51e387a4-bca5-48bd-b919-5c5e466f49b9"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2508), null, false, null, null, "Audit Execution", "Update audit findings" },
                    { new Guid("55b7f825-39a1-4437-a42e-2a333ae6658d"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2451), null, false, null, null, "Internal Control - Call Over", "Approve created Call Over Report" },
                    { new Guid("57afe880-14b9-4fcb-b627-afe5f63b3029"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2438), null, false, null, null, "Internal Control", "Update Created Internal Control" },
                    { new Guid("5d027a16-4660-445c-850e-63c81242f5ea"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2504), null, false, null, null, "Audit Execution", "Update Audit Planning Memo" },
                    { new Guid("5ed6a1a1-55a1-4f6f-a9bb-f61f3ca03df1"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2448), null, false, null, null, "Internal Control - Exception", "Share Exception report" },
                    { new Guid("5f870a71-0928-4655-a95d-ff677c4a31ff"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2506), null, false, null, null, "Audit Execution", "Update Audit Program" },
                    { new Guid("607259d7-edb7-4a94-a794-72f90ce076a0"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2507), null, false, null, null, "Audit Execution", "Update work paper" },
                    { new Guid("67805da5-8bd6-441d-9b6b-9c370673c435"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2486), null, false, null, null, "Audit Execution", "Reject Audit Announcement Memo" },
                    { new Guid("689e70cd-0249-49ef-8518-04a0e344484d"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2503), null, false, null, null, "Audit Execution", "Update Information Requirement" },
                    { new Guid("69a2e6e4-0837-47fa-8da9-958f632aff10"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2443), null, false, null, null, "Internal Control - Exception", "Update Created Exception Tracker" },
                    { new Guid("706a5ced-92e3-46f1-8379-bf78129c1f68"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2491), null, false, null, null, "Audit Execution", "Reject Audit Program" },
                    { new Guid("87fb2cbd-b5da-48bd-8966-a6bc109e7e9d"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2475), null, false, null, null, "Audit Execution", "Approve Engagement Letter" },
                    { new Guid("8aea0f36-ab57-4f65-b9f2-5945eb3e9436"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2445), null, false, null, null, "Internal Control - Exception", "Create Exception Tracker" },
                    { new Guid("91dc6d3f-dd35-451e-b04a-fa455816c09c"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2440), null, false, null, null, "Internal Control", "Upload attachment for created investigation" },
                    { new Guid("98bd95cd-1c4a-4427-bd76-957624b0ca75"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2463), null, false, null, null, "Operation Control", "Reject operation exception" },
                    { new Guid("9da49c2d-b60c-43dc-9850-04e8e8fcd945"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2488), null, false, null, null, "Audit Execution", "Reject Information Requirement" },
                    { new Guid("9f95e4c7-2d36-495c-b30f-44b3c136fa40"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2462), null, false, null, null, "Operation Control", "Approve operation exception" },
                    { new Guid("a5df59df-b003-42fc-802d-830bd167cb7e"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2502), null, false, null, null, "Audit Execution", "Update audit engagement letter" },
                    { new Guid("a777e12a-f2d2-40e4-a6a3-1673fea21290"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2476), null, false, null, null, "Audit Execution", "Approve Information Requirement" },
                    { new Guid("a78e57af-08fc-4eae-9dcc-0bbc0b973ad7"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2468), null, false, null, null, "Audit Execution", "Information requirement execution plan" },
                    { new Guid("b2a7429b-74b8-419f-b3ec-a5cab34abfc9"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2450), null, false, null, null, "Internal Control - Dashboard", "Supervisor to Update task" },
                    { new Guid("b67903bd-6435-412d-947c-46a0d2db14ae"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2436), null, false, null, null, "Internal Control", "Create Internal Control" },
                    { new Guid("c54a7d72-d291-49a0-a6ae-ba94f662ee8e"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2455), null, false, null, null, "Internal Control - Call Over", "Save call over report attachment" },
                    { new Guid("c56be2cd-feb9-4186-aadb-5c631b12ca35"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2494), null, false, null, null, "Audit Execution", "Initiate audit findings" },
                    { new Guid("d1ada3b1-3e74-4d43-8b65-0da982aff7e5"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2435), null, false, null, null, "Internal Control", "Reject created Internal Control" },
                    { new Guid("d20f5128-ef29-4b73-bac2-28f115906938"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2458), null, false, null, null, "Internal Control - Call Over", "Save call over score" },
                    { new Guid("d35ab363-6ba9-4812-b0e1-c4685725d688"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2460), null, false, null, null, "Operation Control", "Re-assigned exception" },
                    { new Guid("d4c9affa-992a-48b5-8e17-97e44aa3e232"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2456), null, false, null, null, "Internal Control - Call Over", "Submit call over reports" },
                    { new Guid("d8417df3-e5b7-4ac5-98ef-8f7e0431d9bb"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2495), null, false, null, null, "Audit Execution", "Approve work paper" },
                    { new Guid("d9d45947-d2e5-480e-95cf-379efd384766"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2487), null, false, null, null, "Audit Execution", "Reject Engagement Letter" },
                    { new Guid("d9e92885-ddd4-4a6e-b779-3216e1bb2b4d"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2477), null, false, null, null, "Audit Execution", "Approve Audit Planning Memo" },
                    { new Guid("dc200a69-bb01-4d07-94a8-79844de5170d"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2479), null, false, null, null, "Audit Execution", "Approve Audit Program" },
                    { new Guid("de6f0445-9768-4cdf-b4a6-48c5afbf666e"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2473), null, false, null, null, "Audit Execution", "Approve audit announcement memo" },
                    { new Guid("df5b084e-654d-4e82-84b2-45132d8379b7"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2466), null, false, null, null, "Audit Execution", "Audit announcement memo execution plan" },
                    { new Guid("e40ce5f0-19e6-49b9-a0cb-795c3ec26b67"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2496), null, false, null, null, "Audit Execution", "Reject work paper" },
                    { new Guid("eae56b73-b087-4fd8-81dd-f35f54485718"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2499), null, false, null, null, "Audit Execution", "Reject audit findings" },
                    { new Guid("f6f0bfe0-8f31-484c-9d92-45803b717168"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2471), null, false, null, null, "Audit Execution", "Audit planning memo execution plan" },
                    { new Guid("f6f8e3f6-d1cc-48d9-987a-bbc42eebf7f3"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2498), null, false, null, null, "Audit Execution", "Approve audit findings" },
                    { new Guid("fc74be96-ce8e-469e-8a1a-83a98aaddd08"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2446), null, false, null, null, "Internal Control - Exception", "Delete Created Exception Tracker" },
                    { new Guid("ffe65ef0-6506-47e6-b8ca-a9290f13c7c5"), null, new DateTime(2025, 4, 8, 21, 44, 31, 327, DateTimeKind.Utc).AddTicks(2442), null, false, null, null, "Internal Control", "Update investigation status" }
                });

            migrationBuilder.InsertData(
                table: "UserRolePermission",
                columns: new[] { "PermissionId", "UserRoleId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("1c10cda1-cd2a-42a4-b295-53404768dc35"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3910), null, false, null, null },
                    { new Guid("4ba7de16-cc9b-4f2e-9ca6-4133cd025310"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3922), null, false, null, null },
                    { new Guid("98bd95cd-1c4a-4427-bd76-957624b0ca75"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3918), null, false, null, null },
                    { new Guid("9f95e4c7-2d36-495c-b30f-44b3c136fa40"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3915), null, false, null, null },
                    { new Guid("c54a7d72-d291-49a0-a6ae-ba94f662ee8e"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3903), null, false, null, null },
                    { new Guid("d4c9affa-992a-48b5-8e17-97e44aa3e232"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3906), null, false, null, null },
                    { new Guid("1178eaab-7eac-4a3c-9a98-3d8c4b88a5f1"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3959), null, false, null, null },
                    { new Guid("1700f355-1943-49cb-bb43-09d91ae939d9"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3933), null, false, null, null },
                    { new Guid("183358b1-ecb3-4280-bcd1-50d6cbb31e1d"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3928), null, false, null, null },
                    { new Guid("39bca629-6bef-4af2-94e2-920d9ff9bc31"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3969), null, false, null, null },
                    { new Guid("51e387a4-bca5-48bd-b919-5c5e466f49b9"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3980), null, false, null, null },
                    { new Guid("5d027a16-4660-445c-850e-63c81242f5ea"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3975), null, false, null, null },
                    { new Guid("5f870a71-0928-4655-a95d-ff677c4a31ff"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3977), null, false, null, null },
                    { new Guid("607259d7-edb7-4a94-a794-72f90ce076a0"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3979), null, false, null, null },
                    { new Guid("689e70cd-0249-49ef-8518-04a0e344484d"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3973), null, false, null, null },
                    { new Guid("a5df59df-b003-42fc-802d-830bd167cb7e"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3971), null, false, null, null },
                    { new Guid("a78e57af-08fc-4eae-9dcc-0bbc0b973ad7"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3929), null, false, null, null },
                    { new Guid("c56be2cd-feb9-4186-aadb-5c631b12ca35"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3960), null, false, null, null },
                    { new Guid("df5b084e-654d-4e82-84b2-45132d8379b7"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3926), null, false, null, null },
                    { new Guid("f6f0bfe0-8f31-484c-9d92-45803b717168"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3932), null, false, null, null },
                    { new Guid("26aecbd2-eb44-42b2-b83d-4b6778a9a6b8"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3902), null, false, null, null },
                    { new Guid("55b7f825-39a1-4437-a42e-2a333ae6658d"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3900), null, false, null, null },
                    { new Guid("218b0863-5156-4488-ab9a-b71c8ae9d2b4"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3897), null, false, null, null },
                    { new Guid("3cb6772e-8370-41e2-a4ff-9adfa83e038c"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3878), null, false, null, null },
                    { new Guid("57afe880-14b9-4fcb-b627-afe5f63b3029"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3884), null, false, null, null },
                    { new Guid("5ed6a1a1-55a1-4f6f-a9bb-f61f3ca03df1"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3895), null, false, null, null },
                    { new Guid("69a2e6e4-0837-47fa-8da9-958f632aff10"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3889), null, false, null, null },
                    { new Guid("8aea0f36-ab57-4f65-b9f2-5945eb3e9436"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3891), null, false, null, null },
                    { new Guid("91dc6d3f-dd35-451e-b04a-fa455816c09c"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3886), null, false, null, null },
                    { new Guid("b67903bd-6435-412d-947c-46a0d2db14ae"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3881), null, false, null, null },
                    { new Guid("d1ada3b1-3e74-4d43-8b65-0da982aff7e5"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3879), null, false, null, null },
                    { new Guid("d20f5128-ef29-4b73-bac2-28f115906938"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3908), null, false, null, null },
                    { new Guid("fc74be96-ce8e-469e-8a1a-83a98aaddd08"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3893), null, false, null, null },
                    { new Guid("ffe65ef0-6506-47e6-b8ca-a9290f13c7c5"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3888), null, false, null, null },
                    { new Guid("b2a7429b-74b8-419f-b3ec-a5cab34abfc9"), new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3898), null, false, null, null },
                    { new Guid("26a31c04-6b1d-43d5-a0d0-ea73756fa20f"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3949), null, false, null, null },
                    { new Guid("67805da5-8bd6-441d-9b6b-9c370673c435"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3944), null, false, null, null },
                    { new Guid("706a5ced-92e3-46f1-8379-bf78129c1f68"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3951), null, false, null, null },
                    { new Guid("87fb2cbd-b5da-48bd-8966-a6bc109e7e9d"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3937), null, false, null, null },
                    { new Guid("9da49c2d-b60c-43dc-9850-04e8e8fcd945"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3947), null, false, null, null },
                    { new Guid("a777e12a-f2d2-40e4-a6a3-1673fea21290"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3939), null, false, null, null },
                    { new Guid("d8417df3-e5b7-4ac5-98ef-8f7e0431d9bb"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3962), null, false, null, null },
                    { new Guid("d9d45947-d2e5-480e-95cf-379efd384766"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3946), null, false, null, null },
                    { new Guid("d9e92885-ddd4-4a6e-b779-3216e1bb2b4d"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3941), null, false, null, null },
                    { new Guid("dc200a69-bb01-4d07-94a8-79844de5170d"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3942), null, false, null, null },
                    { new Guid("de6f0445-9768-4cdf-b4a6-48c5afbf666e"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3935), null, false, null, null },
                    { new Guid("e40ce5f0-19e6-49b9-a0cb-795c3ec26b67"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3964), null, false, null, null },
                    { new Guid("eae56b73-b087-4fd8-81dd-f35f54485718"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3968), null, false, null, null },
                    { new Guid("f6f8e3f6-d1cc-48d9-987a-bbc42eebf7f3"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3966), null, false, null, null },
                    { new Guid("1c10cda1-cd2a-42a4-b295-53404768dc35"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3911), null, false, null, null },
                    { new Guid("4ba7de16-cc9b-4f2e-9ca6-4133cd025310"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3924), null, false, null, null },
                    { new Guid("98bd95cd-1c4a-4427-bd76-957624b0ca75"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3920), null, false, null, null },
                    { new Guid("9f95e4c7-2d36-495c-b30f-44b3c136fa40"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3917), null, false, null, null },
                    { new Guid("d35ab363-6ba9-4812-b0e1-c4685725d688"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 8, 21, 44, 31, 329, DateTimeKind.Utc).AddTicks(3913), null, false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("1c10cda1-cd2a-42a4-b295-53404768dc35"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("4ba7de16-cc9b-4f2e-9ca6-4133cd025310"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("98bd95cd-1c4a-4427-bd76-957624b0ca75"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("9f95e4c7-2d36-495c-b30f-44b3c136fa40"), new Guid("2056820f-51e8-43c2-80d4-512346cc813c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("c54a7d72-d291-49a0-a6ae-ba94f662ee8e"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("d4c9affa-992a-48b5-8e17-97e44aa3e232"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("1178eaab-7eac-4a3c-9a98-3d8c4b88a5f1"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("1700f355-1943-49cb-bb43-09d91ae939d9"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("183358b1-ecb3-4280-bcd1-50d6cbb31e1d"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("39bca629-6bef-4af2-94e2-920d9ff9bc31"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("51e387a4-bca5-48bd-b919-5c5e466f49b9"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("5d027a16-4660-445c-850e-63c81242f5ea"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("5f870a71-0928-4655-a95d-ff677c4a31ff"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("607259d7-edb7-4a94-a794-72f90ce076a0"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("689e70cd-0249-49ef-8518-04a0e344484d"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("a5df59df-b003-42fc-802d-830bd167cb7e"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("a78e57af-08fc-4eae-9dcc-0bbc0b973ad7"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("c56be2cd-feb9-4186-aadb-5c631b12ca35"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("df5b084e-654d-4e82-84b2-45132d8379b7"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("f6f0bfe0-8f31-484c-9d92-45803b717168"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("26aecbd2-eb44-42b2-b83d-4b6778a9a6b8"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("55b7f825-39a1-4437-a42e-2a333ae6658d"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("218b0863-5156-4488-ab9a-b71c8ae9d2b4"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("3cb6772e-8370-41e2-a4ff-9adfa83e038c"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("57afe880-14b9-4fcb-b627-afe5f63b3029"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("5ed6a1a1-55a1-4f6f-a9bb-f61f3ca03df1"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("69a2e6e4-0837-47fa-8da9-958f632aff10"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("8aea0f36-ab57-4f65-b9f2-5945eb3e9436"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("91dc6d3f-dd35-451e-b04a-fa455816c09c"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("b67903bd-6435-412d-947c-46a0d2db14ae"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("d1ada3b1-3e74-4d43-8b65-0da982aff7e5"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("d20f5128-ef29-4b73-bac2-28f115906938"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("fc74be96-ce8e-469e-8a1a-83a98aaddd08"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("ffe65ef0-6506-47e6-b8ca-a9290f13c7c5"), new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("b2a7429b-74b8-419f-b3ec-a5cab34abfc9"), new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("26a31c04-6b1d-43d5-a0d0-ea73756fa20f"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("67805da5-8bd6-441d-9b6b-9c370673c435"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("706a5ced-92e3-46f1-8379-bf78129c1f68"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("87fb2cbd-b5da-48bd-8966-a6bc109e7e9d"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("9da49c2d-b60c-43dc-9850-04e8e8fcd945"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("a777e12a-f2d2-40e4-a6a3-1673fea21290"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("d8417df3-e5b7-4ac5-98ef-8f7e0431d9bb"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("d9d45947-d2e5-480e-95cf-379efd384766"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("d9e92885-ddd4-4a6e-b779-3216e1bb2b4d"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("dc200a69-bb01-4d07-94a8-79844de5170d"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("de6f0445-9768-4cdf-b4a6-48c5afbf666e"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("e40ce5f0-19e6-49b9-a0cb-795c3ec26b67"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("eae56b73-b087-4fd8-81dd-f35f54485718"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("f6f8e3f6-d1cc-48d9-987a-bbc42eebf7f3"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("1c10cda1-cd2a-42a4-b295-53404768dc35"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("4ba7de16-cc9b-4f2e-9ca6-4133cd025310"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("98bd95cd-1c4a-4427-bd76-957624b0ca75"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("9f95e4c7-2d36-495c-b30f-44b3c136fa40"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("d35ab363-6ba9-4812-b0e1-c4685725d688"), new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1") });

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("1178eaab-7eac-4a3c-9a98-3d8c4b88a5f1"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("1700f355-1943-49cb-bb43-09d91ae939d9"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("183358b1-ecb3-4280-bcd1-50d6cbb31e1d"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("1c10cda1-cd2a-42a4-b295-53404768dc35"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("218b0863-5156-4488-ab9a-b71c8ae9d2b4"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("26a31c04-6b1d-43d5-a0d0-ea73756fa20f"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("26aecbd2-eb44-42b2-b83d-4b6778a9a6b8"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("39bca629-6bef-4af2-94e2-920d9ff9bc31"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("3cb6772e-8370-41e2-a4ff-9adfa83e038c"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("4ba7de16-cc9b-4f2e-9ca6-4133cd025310"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("51e387a4-bca5-48bd-b919-5c5e466f49b9"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("55b7f825-39a1-4437-a42e-2a333ae6658d"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("57afe880-14b9-4fcb-b627-afe5f63b3029"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("5d027a16-4660-445c-850e-63c81242f5ea"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("5ed6a1a1-55a1-4f6f-a9bb-f61f3ca03df1"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("5f870a71-0928-4655-a95d-ff677c4a31ff"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("607259d7-edb7-4a94-a794-72f90ce076a0"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("67805da5-8bd6-441d-9b6b-9c370673c435"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("689e70cd-0249-49ef-8518-04a0e344484d"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("69a2e6e4-0837-47fa-8da9-958f632aff10"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("706a5ced-92e3-46f1-8379-bf78129c1f68"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("87fb2cbd-b5da-48bd-8966-a6bc109e7e9d"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("8aea0f36-ab57-4f65-b9f2-5945eb3e9436"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("91dc6d3f-dd35-451e-b04a-fa455816c09c"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("98bd95cd-1c4a-4427-bd76-957624b0ca75"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("9da49c2d-b60c-43dc-9850-04e8e8fcd945"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("9f95e4c7-2d36-495c-b30f-44b3c136fa40"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("a5df59df-b003-42fc-802d-830bd167cb7e"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("a777e12a-f2d2-40e4-a6a3-1673fea21290"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("a78e57af-08fc-4eae-9dcc-0bbc0b973ad7"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("b2a7429b-74b8-419f-b3ec-a5cab34abfc9"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("b67903bd-6435-412d-947c-46a0d2db14ae"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("c54a7d72-d291-49a0-a6ae-ba94f662ee8e"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("c56be2cd-feb9-4186-aadb-5c631b12ca35"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d1ada3b1-3e74-4d43-8b65-0da982aff7e5"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d20f5128-ef29-4b73-bac2-28f115906938"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d35ab363-6ba9-4812-b0e1-c4685725d688"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d4c9affa-992a-48b5-8e17-97e44aa3e232"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d8417df3-e5b7-4ac5-98ef-8f7e0431d9bb"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d9d45947-d2e5-480e-95cf-379efd384766"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("d9e92885-ddd4-4a6e-b779-3216e1bb2b4d"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("dc200a69-bb01-4d07-94a8-79844de5170d"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("de6f0445-9768-4cdf-b4a6-48c5afbf666e"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("df5b084e-654d-4e82-84b2-45132d8379b7"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("e40ce5f0-19e6-49b9-a0cb-795c3ec26b67"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("eae56b73-b087-4fd8-81dd-f35f54485718"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("f6f0bfe0-8f31-484c-9d92-45803b717168"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("f6f8e3f6-d1cc-48d9-987a-bbc42eebf7f3"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("fc74be96-ce8e-469e-8a1a-83a98aaddd08"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("ffe65ef0-6506-47e6-b8ca-a9290f13c7c5"));


















            

            
































            

            
        }
    }
}
