using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoleMapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Business = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleItemType = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleMap",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMap", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoleMap_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleMap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "ModuleItemType", "Name", "Unit", "UnitId" },
                values: new object[,]
                {
                    { new Guid("00670a0d-dbb5-4b9d-b7c1-ec77ced4f63b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3813), null, "raphael.emenyonu@arm.com.ng", true, false, null, null, null, "Raphael Emenyonu", "Retail Sales", new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3") },
                    { new Guid("006f672b-6535-473b-b93c-11b3d9844a83"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3979), null, "oluwabunmi.ayeni@arm.com.ng", true, false, null, null, null, "Oluwabunmi Ayeni", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("00830805-4cff-4380-94c2-2498b00dba7d"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3896), null, "funmilayo.adeyemi@arm.com.ng", true, false, null, null, null, "Funmilayo Adeyemi", "DFS", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("00fecf89-bb70-4e62-a76b-cd1794d6a21f"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3772), null, "moshood.hassan@arm.com.ng", true, false, null, null, null, "Moshood Hassan", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("02734701-28d5-4166-ac88-065780672f10"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4055), null, "olashile.abowaba@arm.com.ng", true, false, null, null, null, "Olashile Abowaba", "Investment Management", new Guid("4082fe29-5966-476e-951f-c44e306ca50f") },
                    { new Guid("0326c783-2eb2-4723-8e92-f3d755df6c82"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3883), null, "babatunde.abimbola@arm.com.ng", true, false, null, null, null, "Babatunde Abimbola", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("04a192db-f039-49c7-bbc9-f7d7b4085ecd"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3753), null, "ezekiel.solomon@arm.com.ng", true, false, null, null, null, "Ezekiel Solomon", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("0668bb60-8c7a-4392-9a92-d1ec04924a48"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3735), null, "raymond.akorah@arm.com.ng", true, false, null, null, null, "Raymond Akorah", "ARM Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("068e132d-97ae-4ebe-88a1-2787c944be70"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3679), null, "olabisi.adesina@arm.com.ng", true, false, null, null, null, "Olabisi Adesina", "Legal", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("09bafc7d-145b-4508-bdbe-4ab9550edaad"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3905), null, "osahon.ogiemudia@arm.com.ng", true, false, null, null, null, "Osahon Ogiemudia", "ARM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("0a2aaf20-ad6f-499a-821b-88e8c4e80850"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3848), null, "temitope.akinola@arm.com.ng", true, false, null, null, null, "Temitope Akinola", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31") },
                    { new Guid("0b0fdcae-d8af-4505-88b4-88e42f5e43ab"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3806), null, "faith.sani@arm.com.ng", true, false, null, null, null, "Faith Sani", "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("0ba0ccae-e71c-433e-8de4-30285f854bc8"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3889), null, "uche.azubuike@arm.com.ng", true, false, null, null, null, "Uche Azubuike", "RFL", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("0c0245d8-95bd-4c59-8518-2e6ec44685fc"), "ARM Harith Infracstrure Investement Limited", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3790), null, "jobalo.oshinkalu@arm.com.ng", true, false, null, null, null, "Jobalo Oshinkalu", "ARM Harith Infrastructure Investment Ltd", new Guid("44fe054d-83dd-41da-b90a-a53631af453d") },
                    { new Guid("0c093023-fb37-4f46-ada0-849afaae7f99"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3809), null, "chukwufumnanya.chizea@arm.com.ng", true, false, null, null, null, "Chukwufumnanya Chizea", "Investment Managment", new Guid("4082fe29-5966-476e-951f-c44e306ca50f") },
                    { new Guid("0daa9fb1-8858-4fa3-94c1-d26a3375679b"), "ARM TRUSTEES", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3865), null, "emmanuella.anaza@arm.com.ng", true, false, null, null, null, "Emmanuella Anaza", "Financial Control", new Guid("90cd9708-b7b4-4203-ba98-6ce8c66e623e") },
                    { new Guid("0f293e73-db67-4151-95a3-c37f9a578640"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3881), null, "maryann.kakulu@arm.com.ng", true, false, null, null, null, "Maryann Kakulu", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("15e02e42-4ad1-4f38-b074-10c9cdac4767"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3808), null, "mounir.bouba@arm.com.ng", true, false, null, null, null, "Mounir Bouba", "Investment Managment", new Guid("4082fe29-5966-476e-951f-c44e306ca50f") },
                    { new Guid("16473b29-42ad-4763-b1ef-11f0e02b3bca"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3787), null, "moyosore.taiwo@arm.com.ng", true, false, null, null, null, "Moyosore Taiwo", "Research", new Guid("a6409616-e559-4ff8-a877-0925be18ff3d") },
                    { new Guid("1788341d-ab99-4ac4-9c6a-aff9ebba37e6"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3942), null, "busola.alakija@arm.com.ng", true, false, null, null, null, "Busola Alakija", "Operations Settlement", new Guid("4082fe29-5966-476e-951f-c44e306ca50f") },
                    { new Guid("17ec9f3f-2de4-4730-929e-0d3aaba63256"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3992), null, "damilola.akinlade@arm.com.ng", true, false, null, null, null, "Damilola Akinlade", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("18d63e3e-1940-4f80-8c69-29bcc9392b80"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3696), null, "phoebe.ohiembor@arm.com.ng", true, false, null, null, null, "Phoebe Ohiembor", "Information Technology", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("1ab43f1a-d3c4-4cbd-a1eb-c38a75a812f3"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3949), null, "oluseyi.omoleye@arm.com.ng", true, false, null, null, null, "Oluseyi Omoleye", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("1b0346b0-5186-4af1-8f80-8605f368296d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3931), null, "olayinka.oyewole@arm.com.ng", true, false, null, null, null, "Olayinka Oyewole", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("1bac4e41-033e-49ce-8e4e-9e7632d4189b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3832), null, "kareem.bashir@arm.com.ng", true, false, null, null, null, "Kareem Bashir", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("1c2a2eb3-c584-4185-acbb-5bbb06c10cf5"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3963), null, "oluwakemi.onipede@arm.com.ng", true, false, null, null, null, "Oluwakemi Onipede", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07") },
                    { new Guid("1f3a321c-a151-400b-a619-dcebde93c73f"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3820), null, "gbeminiyi.onipede@arm.com.ng", true, false, null, null, null, "Gbeminiyi Onipede", "HoldCo Sales", new Guid("772f854e-c9f6-4428-bad1-53db881e28bb") },
                    { new Guid("1f409f31-01da-45c4-b08c-4d75362fe0f0"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3888), null, "moronke.bamgbala@arm.com.ng", true, false, null, null, null, "Moronke Bamgbala", "ARM Trustees", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("219903d2-54d5-42e2-9916-1bd7420e1cc1"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3727), null, "oluwaferanmi.olorunleke@arm.com.ng", true, false, null, null, null, "Oluwaferanmi Olorunleke", "ARM Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c") },
                    { new Guid("24158b3a-a2ab-468c-b4ee-a0361d0bd679"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3879), null, "adebayo.fagbola@arm.com.ng", true, false, null, null, null, "Adebayo Fagbola", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("27ac990e-7445-4be9-9206-ee36533fdabb"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3934), null, "ifeanyi.esogwa@arm.com.ng", true, false, null, null, null, "Ifeanyi Esogwa", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("27b6e67c-92a4-4166-ab21-fdf40f8c9a08"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3980), null, "eno.udoh@arm.com.ng", true, false, null, null, null, "Eno Udoh", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("328cae33-88ef-4b8c-b928-a761024d2e54"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3894), null, "rachel.moreoshodi@arm.com.ng", true, false, null, null, null, "Rachel Moreoshodi", "ARMHIIL", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("3720bdd2-8bf3-4f07-80e1-89e087e7347d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3778), null, "rasheed.adebola@arm.com.ng", true, false, null, null, null, "Rasheed Adebola", "WRM (Lagos)", new Guid("500fc670-2f14-4786-9092-f7f82b8ae507") },
                    { new Guid("3756232d-c562-47a7-bc5f-81d82a85964f"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3871), null, "abiola.itakpe@arm.com.ng", true, false, null, null, null, "Abiola Itakpe", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("3983d79c-3c87-4fd9-b05b-c7c2db777f18"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4004), null, "esther.onumaegbu@arm.com.ng", true, false, null, null, null, "Esther Onumaegbu", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("39eab3e1-ec3c-4e46-b220-72f24a1a9b6a"), "ARM Digital Financial Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3739), null, "ina.alogwu@arm.com.ng", true, false, null, null, null, "Ina Alogwu", "Digital Financial Services", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8") },
                    { new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3800), null, "oluwatobi.oyebiyi@arm.com.ng", true, false, null, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3828), null, "olawale.bakir@arm.com.ng", true, false, null, null, null, "Olawale Bakir", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("3ce35779-1df8-48fa-818d-605c69fda68e"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4041), null, "adaeze.ukah@arm.com.ng", true, false, null, null, null, "Adaeze Ukah", "Customer Experience", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("3d1dd8c9-46df-47d6-bfe5-e6707937301c"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3761), null, "judith.okeke@arm.com.ng", true, false, null, null, null, "Judith Okeke", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7") },
                    { new Guid("3dd0786d-f3c4-4662-83ac-2420fcbfa5f3"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3831), null, "gbenga.sonubi@arm.com.ng", true, false, null, null, null, "Gbenga Sonubi", "Securities Operations,Financial Control", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604") },
                    { new Guid("3fc9a856-df88-4bc8-88b1-cf4b65f3928d"), "ARM Agricbusiness Fund Manager Ltd", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3708), null, "hassan.adeObafemi@arm.com.ng", true, false, null, null, null, "Hassan AdeObafemi", "RFL", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("404f4298-bfca-4709-b9d4-652509d7f604"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3816), null, "anuoluwapo.sebanjo@arm.com.ng", true, false, null, null, null, "Anuoluwapo Sebanjo", "Corporate Strategy", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75") },
                    { new Guid("414dc8d2-233b-443f-b7da-181aa1cadb3f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3825), null, "james.agu@arm.com.ng", true, false, null, null, null, "James Agu", "Operations Control", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                    { new Guid("44aaf905-d100-4b66-ae1a-42ff22b5985c"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4040), null, "evelyn.osindeinde@arm.com.ng", true, false, null, null, null, "Evelyn Osindeinde", "Customer Experience", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("453e760b-1dee-4706-b2ea-f06826f46bac"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3925), null, "tobi.babalola@arm.com.ng", true, false, null, null, null, "Tobi Babalola", "ARM IM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("46759c7a-860b-48c1-972f-aeddc13fe604"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4026), null, "anike.olalere@arm.com.ng", true, false, null, null, null, "Anike Olalere", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("4736e129-0473-4b12-8305-62011ee8ba52"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3851), null, "valerie.okosun@arm.com.ng", true, false, null, null, null, "Valerie Okosun", "Securities Operations,Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76") },
                    { new Guid("4b9592a9-c7b0-4231-9170-8f68d4b672b1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4002), null, "lebechi.ndukwe@arm.com.ng", true, false, null, null, null, "Lebechi Ndukwe", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("4c116457-5a05-4e31-bec4-4e3e74d1584f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4028), null, "chukwuebuka.agbo@arm.com.ng", true, false, null, null, null, "Chukwuebuka Agbo", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("4ed59e86-27c2-4270-bc10-060676cec0a0"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3695), null, "olayemi.toye@arm.com.ng", true, false, null, null, null, "Olayemi Toye", "Information Technology", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("5074d70a-7471-46a7-8064-605b9710ac74"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3677), null, "nehizena.ibhawoh@arm.com.ng", true, false, null, null, null, "Nehizena Ibhawoh", "Legal,Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("50e7d53a-168a-474e-a981-0c21cf63ad3d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4054), null, "ilerioluwa.akinosun@arm.com.ng", true, false, null, null, null, "Ilerioluwa Akinosun", "Securities Operations", new Guid("393f2a41-0ae5-487d-9b67-224cd145f5fb") },
                    { new Guid("517580ef-82c5-43eb-aeb7-2a82eb2e8546"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3915), null, "walter.agbongbohielu@arm.com.ng", true, false, null, null, null, "Walter Agbongbohielu", "ARM IM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("5245052a-9d22-4cbc-8552-32e40c0d1c57"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3936), null, "victor.arowolo@arm.com.ng", true, false, null, null, null, "Victor Arowolo", "Operations Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293") },
                    { new Guid("52f6bb20-fbfe-45cd-a767-bca8c272ff4a"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3891), null, "Wilfird.korsaga@arm.com.ng", true, false, null, null, null, "Wilfird Korsaga", "AAFML", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("53cc8c36-4366-45cc-b329-8d42b48ff515"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3804), null, "abayomi.apoeso@arm.com.ng", true, false, null, null, null, "Abayomi Apoeso", "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("53d973cc-d395-4789-8b8f-f394b2dd0b2f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3693), null, "james.ewah@arm.com.ng", true, false, null, null, null, "James Ewah", "WRM (Abuja)", new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784") },
                    { new Guid("5438428c-8c2b-48bd-b1d1-2382c488ca9a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3732), null, "ibukun.ajose@arm.com.ng", true, false, null, null, null, "Ibukun Ajose", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805") },
                    { new Guid("54fba425-4415-4149-bdbf-e031c0dd5a8b"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4051), null, "ayomide.ojeniyi@arm.com.ng", true, false, null, null, null, "Ayomide Ojeniyi", "Securities Operations", new Guid("393f2a41-0ae5-487d-9b67-224cd145f5fb") },
                    { new Guid("57c976a7-a9e0-4f31-bec1-99d5d290996e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3917), null, "olufisayo.bassey@arm.com.ng", true, false, null, null, null, "Olufisayo Bassey", "Investment Management", new Guid("4082fe29-5966-476e-951f-c44e306ca50f") },
                    { new Guid("57cda194-4fae-482d-a09f-43c397d373d1"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3785), null, "oyinkan.aregbesola@arm.com.ng", true, false, null, null, null, "Oyinkan Aregbesola", "Research", new Guid("a6409616-e559-4ff8-a877-0925be18ff3d") },
                    { new Guid("59a2eae1-ded9-4f5d-b6e9-c8572e77f764"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3961), null, "ibrahim.owolabi@arm.com.ng", true, false, null, null, null, "Ibrahim Owolabi", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07") },
                    { new Guid("59a83afc-7720-4f57-bbea-80d8358f9b0d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3702), null, "stephen.igwenwanne@arm.com.ng", true, false, null, null, null, "Stephen Igwenwanne", "WRM (PortHarcourt)", new Guid("80245081-74bc-4124-87f5-d6008b28706b") },
                    { new Guid("5a1a94b8-f9ae-4485-af3f-cbdb507c9f5e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3938), null, "oluwaferanmi.adedokun@arm.com.ng", true, false, null, null, null, "Oluwaferanmi Adedokun", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("5bff9668-4850-4351-b37b-e6ca0048fa4c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3945), null, "emmanuel.peter@arm.com.ng", true, false, null, null, null, "Emmanuel Peter", "Operations Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293") },
                    { new Guid("5d9e18df-0a3c-495b-8de4-65bf8be65a87"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4044), null, "adepeju-lola.sangotade@arm.com.ng", true, false, null, null, null, "Adepeju-Lola Sangotade", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("5df5bba8-fa4a-40a8-b88f-ce342d1fcb4e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4032), null, "olufunke.sipe@arm.com.ng", true, false, null, null, null, "Olufunke Sipe", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("5e902748-0188-405d-8a9b-cb3e22098d1b"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3771), null, "dare.shobajo@arm.com.ng", true, false, null, null, null, "Dare Shobajo", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("6209fd2d-95d0-4927-9ada-460ecd424e54"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3777), null, "doyinsola.ola@arm.com.ng", true, false, null, null, null, "Doyinsola Ola", "WRM (Lagos)", new Guid("500fc670-2f14-4786-9092-f7f82b8ae507") },
                    { new Guid("62310863-e5a5-4f6c-ba97-2141acaf1e62"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3855), null, "oluwatosin.afolayan@arm.com.ng", true, false, null, null, null, "Oluwatosin Afolayan", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604") },
                    { new Guid("62c5e7f4-dc13-4b17-9a74-ab301cee30ee"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3993), null, "yetunde.adio@arm.com.ng", true, false, null, null, null, "Yetunde Adio", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("62db3f26-b6bd-4a06-9a89-dc93c249c73d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3748), null, "olugbenga.ajigbotafe@arm.com.ng", true, false, null, null, null, "Olugbenga Ajigbotafe", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("63684ef0-a6ed-4d5a-9b47-568358a84670"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3844), null, "elizabeth.alloy@arm.com.ng", true, false, null, null, null, "Elizabeth Alloy", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31") },
                    { new Guid("663cc78c-a538-4ca0-84a3-7d182e8c2292"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3762), null, "carol.ariyibi@arm.com.ng", true, false, null, null, null, "Carol Ariyibi", "Corporate Transformation", new Guid("850b308d-bef3-41ad-b812-413b868e7621") },
                    { new Guid("66cf02d7-748e-4b59-9f3d-24ae3134a25b"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3895), null, "damilare.mesimo@arm.com.ng", true, false, null, null, null, "Damilare Mmesimo", "DFS", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("672316f2-ddd1-48f6-bc95-710d27836a3d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3971), null, "chisom.okeke@arm.com.ng", true, false, null, null, null, "Chisom Okeke", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("68b49eca-2285-46d4-8449-4cf78a8a730d"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3743), null, "oritsegbemi.agbajor@arm.com.ng", true, false, null, null, null, "Oritsegbemi Agbajor", "ARM Commercial Trust", new Guid("05652a26-461c-4c78-be42-f212fc5fd083") },
                    { new Guid("69f91acc-e65c-4b4c-a43f-ef2216d220cf"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3930), null, "tobby.tobby@arm.com.ng", true, false, null, null, null, "Tobby Moses Tobby", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("6a30b54c-54bc-41d2-ae42-4cb418bfb3a5"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3948), null, "toluwalase.ajediti@arm.com.ng", true, false, null, null, null, "Toluwalase Ajediti", "Operations Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293") },
                    { new Guid("6d4b51f7-929b-4894-a1f1-82b84d971880"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4001), null, "bukola.abdulakeem@arm.com.ng", true, false, null, null, null, "Bukola Abdulakeem", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("6de1a7fc-b57e-4283-8e46-edea9631ce32"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3927), null, "oluwatosin.oluyemi@arm.com.ng", true, false, null, null, null, "Oluwatosin Oluyemi", "Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c") },
                    { new Guid("703c42fa-406c-453c-b3cf-a2fb3ad354a1"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3767), null, "jacqueline.adefeso@arm.com.ng", true, false, null, null, null, "Jacqueline Adefeso", "Procurement and Administration", new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9") },
                    { new Guid("72b05306-1d04-4310-8344-16e8ca7c3372"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4058), null, "gift.aizebeoje@arm.com.ng", true, false, null, null, null, "Gift Aizebeoje", "Investment Management", new Guid("4082fe29-5966-476e-951f-c44e306ca50f") },
                    { new Guid("73355329-e14d-4c0f-9836-ebf962a9298f"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3782), null, "gozie.alozieuwa@arm.com.ng", true, false, null, null, null, "Gozie Alozieuwa", "Compliance", new Guid("a470f202-ca90-4fc9-8617-358311885a1c") },
                    { new Guid("744e925b-6aa7-45fa-824c-0b505a04e20a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3662), null, "chukwuebuka.obieri@arm.com.ng", true, false, null, null, null, "Chukwuebuka Obieri", "Risk Management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("75d0157a-c79c-4402-9212-fd9feaf6bb3b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3976), null, "victoria.makama@arm.com.ng", true, false, null, null, null, "Victoria Makama", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("75e2dc83-eb5e-4c43-9eb4-1b9c2ba3e588"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3858), null, "babatunde.osho@arm.com.ng", true, false, null, null, null, "Babatunde Osho", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31") },
                    { new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3776), null, "opeyemi.babasola@arm.com.ng", true, false, null, null, null, "Opeyemi Babasola", "Securities Operations,Financial Control", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604") },
                    { new Guid("7b13db39-3b27-4ddf-822e-c96a0514434e"), "ARM Agricbusiness Fund Manager Ltd", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3709), null, "david.akinboade@arm.com.ng", true, false, null, null, null, "David Akinboade", "RFL", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("7cf72076-44ad-428d-8073-d6cfb172806d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3878), null, "victoria.itrechio@arm.com.ng", true, false, null, null, null, "Victoria Itrechio", "Treasury", new Guid("a0d8712a-f6dd-4f64-a9b0-dcc204e52287") },
                    { new Guid("7e265aed-6c39-4043-92b0-28f64a9c099d"), "ARM Harith Infracstrure Investement Limited", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3791), null, "oyedele.oyinbojuni@armharith.com", true, false, null, null, null, "Oyedele Oyinbojuni", "ARM Harith Infrastructure Investment Ltd", new Guid("44fe054d-83dd-41da-b90a-a53631af453d") },
                    { new Guid("7eb3989a-9707-4a1e-9182-60ff86b6d44d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4023), null, "veronica.oluigbo@arm.com.ng", true, false, null, null, null, "Veronica Oluigbo", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("7ee32b4c-07a4-4459-9ac0-577df0458611"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3875), null, "ifeoma.ofili@arm.com.ng", true, false, null, null, null, "Ifeoma Ofili", "Treasury", new Guid("a0d8712a-f6dd-4f64-a9b0-dcc204e52287") },
                    { new Guid("7f7d39f1-e068-4c3a-b6fc-02f0bc76e351"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3951), null, "thompson.shedara@arm.com.ng", true, false, null, null, null, "Thompson Shedara", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("8024d065-906b-4708-821c-1a2eb3aacae1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3799), null, "adetayo.adebiyi@arm.com.ng", true, false, null, null, null, "Adetayo Adebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("82d94cb6-6e22-476b-b8a2-a6c996636c73"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3700), null, "ubi.torsam@arm.com.ng", true, false, null, null, null, "Ubi Torsam", "Marketing and Corporate Communications", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c") },
                    { new Guid("82eaa8ad-7483-40ca-b584-1f0546720a79"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3892), null, "yusuf.agbolahan@arm.com.ng", true, false, null, null, null, "Yusuf Agbolahan", "Investment Banking", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3801), null, "itunu.olatunde-folaji@arm.com.ng", true, false, null, null, null, "Itunu Olatunde-Folaji", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("846503d5-9b92-4148-83a3-682b99fa1ed7"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4037), null, "victoria.chukwu@arm.com.ng", true, false, null, null, null, "Victoria Chukwu", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("86de4f7d-fe4c-4a54-a0bc-a894883424c5"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3718), null, "olatunde.samuel@arm.com.ng", true, false, null, null, null, "Olatunde Samuel", "ARM Academy", new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e") },
                    { new Guid("86ef8958-9c81-4ce8-9fc6-2df53ab20599"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3990), null, "deborah.dubukumah@arm.com.ng", true, false, null, null, null, "Deborah Dubukumah", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("87497a34-3059-4b2e-9afd-65ad4ccf9cdc"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3984), null, "adedolapo.oyeleke@arm.com.ng", true, false, null, null, null, "Adedolapo Oyeleke", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("89ec5cac-5c61-4ac5-b19a-966195dba85c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3834), null, "patrick.ayele@arm.com.ng", true, false, null, null, null, "Patrick Ayele", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("8c5d8d3e-587b-4ad7-8333-5ff668390cf3"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3717), null, "adeleye.adewusi@arm.com.ng", true, false, null, null, null, "Adeleye Adewusi", "ARM Academy", new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e") },
                    { new Guid("8e4a4569-dbae-4cec-a86b-d43bf743955e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3703), null, "ndubuisi.anya@arm.com.ng", true, false, null, null, null, "Ndubuisi Anya", "WRM (PortHarcourt)", new Guid("80245081-74bc-4124-87f5-d6008b28706b") },
                    { new Guid("8f71c6e3-b327-4046-ad43-783141f8b01b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3964), null, "covenant.ukachi@arm.com.ng", true, false, null, null, null, "Covenant Ukachi", "Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("8fda951d-36fa-4263-8c66-1fba037d3765"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3928), null, "tosin.adesope@arm.com.ng", true, false, null, null, null, "Tosin Adesope", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("9435698f-d64b-413a-b334-f476bd3ed548"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3750), null, "joy.oyekan@arm.com.ng", true, false, null, null, null, "Joy Oyekan", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("95212a97-96c7-434c-a795-bb692ee58021"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3835), null, "oluyemi.omodayo@arm.com.ng", true, false, null, null, null, "Oluyemi Omodayo", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("9627518a-07ee-4da8-bf71-9503615994f6"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4036), null, "moyosore.ibitoye@arm.com.ng", true, false, null, null, null, "Moyosore Ibitoye", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("984b9023-c774-4e90-a16e-3af0aad05a3c"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3783), null, "lincoln.ogigai@arm.com.ng", true, false, null, null, null, "Lincoln Ogigai", "Compliance", new Guid("a470f202-ca90-4fc9-8617-358311885a1c") },
                    { new Guid("98fc4263-5311-4a1b-8889-aaf3541781e3"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3722), null, "aminat.ashafa@arm.com.ng", true, false, null, null, null, "Aminat Ashafa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3721), null, "bimbo.moses@arm.com.ng", true, false, null, null, null, "Bimbo Moses", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("9e27a329-52f7-4004-8a1a-090ddcac29d0"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3752), null, "oluwabunmi.abiodun-wright@arm.com.ng", true, false, null, null, null, "Oluwabunmi Abiodun-Wright", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("a038cd54-b443-4779-8506-bcc586c64a7d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3774), null, "vwede.edah@arm.com.ng", true, false, null, null, null, "Vwede Edah", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604") },
                    { new Guid("a17fba1c-a1c8-47c1-b0fd-577aa740757a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3714), null, "akpesiri.kodu@arm.com.ng", true, false, null, null, null, "Akpesiri Kodu", "Customer Experience", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("a33da7fb-c2d8-43ea-a5af-48df82c586a7"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3829), null, "barakat.olusanya@arm.com.ng", true, false, null, null, null, "Barakat Olusanya", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("a3b8254e-d8c1-49ae-99b3-30fe33bd5806"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3898), null, "jobalo.oshikanlu@arm.com.ng", true, false, null, null, null, "Jobalo Oshikanlu", "ARMHIIL", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("a48b5840-94d2-445e-8a5f-1eeb5beb45f8"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3901), null, "toni.timi-oyefolu@arm.com.ng", true, false, null, null, null, "Toni Timi-Oyefolu", "ARMIM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("a4d57608-7b78-4e09-ba49-79444f23da6c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4029), null, "chinonso.iwuozor@arm.com.ng", true, false, null, null, null, "Chinonso Iwuozor", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("a8292054-64b5-48ee-8269-81c84c18f424"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3821), null, "olukayode.fajuyagbe@arm.com.ng", true, false, null, null, null, "Olukayode Fajuyagbe", "HoldCo Sales", new Guid("772f854e-c9f6-4428-bad1-53db881e28bb") },
                    { new Guid("aa8b94de-4efb-48ed-95f2-3efb1e980555"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3691), null, "ediagbonya.osayomwanbo@arm.com.ng", true, false, null, null, null, "Ediagbonya Osayomwanbo", "WRM (Abuja)", new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784") },
                    { new Guid("ac871e3a-fb51-427a-83a3-54d3ccd726c0"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3911), null, "adepeju.sangotade@arm.com.ng", true, false, null, null, null, "Adepeju Sangotade", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("adcc99a7-dc88-46bb-8398-62e9ec322d5f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4007), null, "godwin.ebie@arm.com.ng", true, false, null, null, null, "Godwin Ebie", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("af39e2a5-a893-4e07-90af-5d11d9fc0bf4"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3986), null, "simisola.famous-cole@arm.com.ng", true, false, null, null, null, "Simisola Famous-Cole", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("b15d21ae-9e86-4380-924d-d06662ce1e0e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3824), null, "opeyemi.oshinyemi@arm.com.ng", true, false, null, null, null, "Opeyemi Oshinyemi", "Operations Control", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                    { new Guid("b241d596-f089-434b-a94c-16114c0a4b4b"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3674), null, "iwasam.elemi@arm.com.ng", true, false, null, null, null, "Iwasam Elemi", "Risk Management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("b292c77c-ec56-4e3e-bd59-4fa6de45e998"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3957), null, "hassan.balogun@arm.com.ng", true, false, null, null, null, "Hassan Balogun", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("b49fc47a-6b5d-4ec5-bb83-468b3fc04602"), "ARM Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4045), null, "enoma.osazee@arm.com.ng", true, false, null, null, null, "Enoma Osazee", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("b4cf0cf4-69d6-4610-b8ba-b3a39193b8e6"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3977), null, "dolapo.fashina@arm.com.ng", true, false, null, null, null, "Dolapo Fashina", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("b57ffb70-5d09-4349-bbad-54eecfa9fbae"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3803), null, "roselina.ajah@arm.com.ng", true, false, null, null, null, "Roselina Ajah", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("b61100af-0f06-4ac6-85ef-80da244e4fa7"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4052), null, "lawrence.olusina@arm.com.ng", true, false, null, null, null, "Lawrence Olusina", "Securities Operations", new Guid("393f2a41-0ae5-487d-9b67-224cd145f5fb") },
                    { new Guid("b64e0d40-6f17-4e47-a0be-6674b9b2ac18"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3768), null, "moradeke.odugbesan@arm.com.ng", true, false, null, null, null, "Moradeke Odugbesan", "Procurement and Administration", new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9") },
                    { new Guid("b70e5969-5638-4492-95ef-405713ee599c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3983), null, "inemesit.anani@arm.com.ng", true, false, null, null, null, "Inemesit Anani", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("b9e76d0e-46fd-48b8-8ecb-c4e1527f67eb"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3904), null, "wale.odutola@arm.com.ng", true, false, null, null, null, "Wale Odutola", "ARM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("bbb05cc6-492d-405d-883d-e2779bf0ab1e"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3854), null, "ramond.akorah@arm.com.ng", true, false, null, null, null, "Ramond Akorah", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604") },
                    { new Guid("bd8f67ea-a3d0-48d3-99bd-e75f5008f974"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3868), null, "oluwatomilola.oduntan@arm.com.ng", true, false, null, null, null, "Oluwatomilola Oduntan", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("be485a1a-1e6b-452d-a797-dd2dfe5a6902"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3746), null, "chidinma.mbakwe@arm.com.ng", true, false, null, null, null, "Chidinma Mbakwe", "ARM Commercial Trust", new Guid("05652a26-461c-4c78-be42-f212fc5fd083") },
                    { new Guid("c052329e-ff47-42e0-919d-6e6a701a96b3"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4057), null, "ifeoluwa.obigbemi@arm.com.ng", true, false, null, null, null, "Ifeoluwa Obigbemi", "Investment Management", new Guid("4082fe29-5966-476e-951f-c44e306ca50f") },
                    { new Guid("c0c800df-ac58-4fd9-88b1-63a3dbf4451c"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3837), null, "oluwatosin.adeboyejo@arm.com.ng", true, false, null, null, null, "Oluwatosin Adeboyejo", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31") },
                    { new Guid("c15dc281-64a8-4dfe-999b-a59084327aa9"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3867), null, "sandra.onwordi@arm.com.ng", true, false, null, null, null, "Sandra Onwordi", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76") },
                    { new Guid("c4a91ea0-ae99-4dc5-913f-043f14836a30"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3872), null, "chidinma.akosa@arm.com.ng", true, false, null, null, null, "Chidinma Akosa", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("c6492702-c4f5-4099-b360-be3d0f37180b"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3699), null, "ethan.okwara@arm.com.ng", true, false, null, null, null, "Ethan Okwara", "Marketing and Corporate Communications", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c") },
                    { new Guid("ca9690f7-2871-4bb1-9072-cfa10bb14a0b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4000), null, "shulammite.wokwereze@arm.com.ng", true, false, null, null, null, "Shulammite Wokwereze", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("cab92ccc-ca73-4e7a-acab-cd7fd0a7db3a"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3847), null, "stephanie.gber@arm.com.ng", true, false, null, null, null, "Stephanie Gber", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31") },
                    { new Guid("cd86c3bb-c3ce-4e32-a18d-864c7be053b7"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3973), null, "ifeyinwa.amadi@arm.com.ng", true, false, null, null, null, "Ifeyinwa Amadi", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("ce6623a1-3821-460e-88c2-e5082838840e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3924), null, "opeyemi.oshiyemi@arm.com.ng", true, false, null, null, null, "Opeyemi Oshiyemi", "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                    { new Guid("cebab131-6b5b-4648-88a8-4f6524cb71e3"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3982), null, "busola.akerele@arm.com.ng", true, false, null, null, null, "Busola Akerele", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("cf9c48f2-20da-4989-b929-b2a250154126"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3955), null, "ifeoluwa.okunoye@arm.com.ng", true, false, null, null, null, "Ifeoluwani Okunoye", "Fund Amin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("d06f7e39-f81b-4062-b841-b5de4b7d98cf"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3939), null, "oyenike.oluwa@arm.com.ng", true, false, null, null, null, "Oyenike Oluwa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("d587a654-52e1-472e-895e-15690c026b3d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3864), null, "kiadum.nwakoh@arm.com.ng", true, false, null, null, null, "Kiadum Nwakoh", "Legal,Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("d69810b1-d0c7-4c25-9e82-29677990fe6e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3958), null, "chioma.opara@arm.com.ng", true, false, null, null, null, "Chioma Opara", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("d700564f-1a2f-4396-8f6f-e769eb6e7af8"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3814), null, "hamed.omotayo@arm.com.ng", true, false, null, null, null, "Hamed Omotayo", "Retail Sales", new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3") },
                    { new Guid("d70df12b-96fd-46b2-ba74-7898b8cf828f"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3817), null, "philip.aikinomiora @arm.com.ng", true, false, null, null, null, "Philip Aikinomiora", "Corporate Strategy", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75") },
                    { new Guid("d74a1b81-b74f-4cda-a602-c6d46c4d61e9"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3907), null, "chijioke.iteghete@arm.com.ng", true, false, null, null, null, "Chijioke Iteghete", "ARM IM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("d8ed93b7-a3da-4745-ba17-486a11fe10df"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3764), null, "olaoluwa.omolayole@arm.com.ng", true, false, null, null, null, "Olaoluwa Omolayole", "Corporate Transformation", new Guid("850b308d-bef3-41ad-b812-413b868e7621") },
                    { new Guid("db50d28f-5f88-47fc-a160-da10003c1fc1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3952), null, "oladupe.dare@arm.com.ng", true, false, null, null, null, "Oladupe Dare", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("dc3c4bd1-3d0a-4275-86a0-54d0a058b6df"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3793), null, "isaac.elakhe@arm.com.ng", true, false, null, null, null, "Isaac Elakhe", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("ddc6903f-0a16-448a-ac10-279a5f169b13"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3856), null, "evelyn.nwogu@arm.com.ng", true, false, null, null, null, "Evelyn Nwogu", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31") },
                    { new Guid("de135872-a718-452f-9975-c152411c5f3d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3968), null, "bridget.odubela@arm.com.ng", true, false, null, null, null, "Bridget Odubela", "Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("e143ed84-322a-4f9c-993a-12598abe894d"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4047), null, "amaka.nnotum@arm.com.ng", true, false, null, null, null, "Amaka Nnotum", "Financial Control", new Guid("fb274136-84fe-430d-bab9-6647909a1a48") },
                    { new Guid("e21c004e-9246-47b6-8547-6b462643ae59"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3862), null, "augustine.chukwu@arm.com.ng", true, false, null, null, null, "Augustine Chukwu", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb") },
                    { new Guid("e2809297-1779-4454-85cc-c7c105a6a709"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3877), null, "ademola.adebisi@arm.com.ng", true, false, null, null, null, "Ademola Adebisi", "Treasury", new Guid("a0d8712a-f6dd-4f64-a9b0-dcc204e52287") },
                    { new Guid("e3c6a104-e732-4865-afe3-58f3e973af90"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3902), null, "jumoke.ogundare@arm.com.ng", true, false, null, null, null, "Jumoke Ogundare", "ARM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("e4e321fa-c082-4b73-90d1-2ee8d1df57b1"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3967), null, "bukunmi.chuka@arm.com.ng", true, false, null, null, null, "Bukunmi Chuka", "Registrars", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("e705cfd6-c806-4a73-ad96-b831e203b7f9"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3943), null, "augustina.osagie@arm.com.ng", true, false, null, null, null, "Augustina Osagie", "Operations Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293") },
                    { new Guid("ea045141-2b65-497c-8b97-6ca1ecd8885e"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3908), null, "ayodele.oluleye@arm.com.ng", true, false, null, null, null, "Ayodele Oluleye", "ARM IM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("eac59325-3b9c-4701-ac63-b4dc55d65872"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3729), null, "folarinde.ayenuwa@arm.com.ng", true, false, null, null, null, "Folarinde Ayenuwa", "ARM Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c") },
                    { new Guid("ebcf8632-14fe-4c88-9684-93f01986a209"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3733), null, "kevian.kevin@arm.com.ng", true, false, null, null, null, "Kevian Kevin", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805") },
                    { new Guid("ec75a36c-663d-4405-926a-8addacc6dc0f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4008), null, "faith.ojo@arm.com.ng", true, false, null, null, null, "Faith Ojo", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("ed7fa8c7-7bbb-4a7c-94b2-c25aaace3fb1"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3869), null, "ogugua.emamoke@arm.com.ng", true, false, null, null, null, "Ogugua Emamoke", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("ed8fd2d3-536b-477a-b27d-aa52171de2f7"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3989), null, "rukayat.adepitan@arm.com.ng", true, false, null, null, null, "Rukayat Adepitan", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("ee3838b7-b264-41ce-96df-5fb233b7fc83"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4031), null, "jane.david-abia@arm.com.ng", true, false, null, null, null, "Jane David-Abia", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("ee8dd936-36b8-4492-aa97-9eb78a88d051"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3970), null, "amara.nwafor@arm.com.ng", true, false, null, null, null, "Amara Nwafor", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("eeb105a0-8b43-4528-95ef-90c4efce1ee7"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3912), null, "anuoluwapo.senbanjo@arm.com.ng", true, false, null, null, null, "Anuoluwapo Senbanjo", "ARM IM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("eefdd975-bbe9-44dd-a654-2992ddd303dd"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(4042), null, "taiwo.odumuyiwa@arm.com.ng", true, false, null, null, null, "Taiwo Odumuyiwa", "Customer Experience", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("ef7040f3-cff3-40ab-871f-d7da70c41581"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3941), null, "rosemary.francis@arm.com.ng", true, false, null, null, null, "Rosemary Francis", "Operations Settlement", new Guid("4082fe29-5966-476e-951f-c44e306ca50f") },
                    { new Guid("f0790dc3-bb5b-4086-9ea1-7967b337fc5f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3954), null, "martins.onemolease@arm.com.ng", true, false, null, null, null, "Martins Onemolease", "Fund Amin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("f0a8aaf4-89ae-4a13-bb10-e6f5104646bd"), "ARM Digital Financial Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3740), null, "folaranmi.adefila@arm.com.ng", true, false, null, null, null, "Folaranmi Adefila", "Digital Financial Services", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8") },
                    { new Guid("f19317cd-ef8b-425d-abcd-ee6f3f9bc2a8"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3795), null, "oladupe.oshinuga@arm.com.ng", true, false, null, null, null, "Oladupe Oshinuga", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("fd313524-5a4f-4667-b2f9-219b64558435"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3712), null, "eddy.ayikimi@arm.com.ng", true, false, null, null, null, "Eddy Ayikimi", "Customer Experience", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("fd37f00f-06f2-400b-a883-05ded0522c6b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3852), null, "kingsley.ottah@arm.com.ng", true, false, null, null, null, "Kingsley Ottah", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76") },
                    { new Guid("fe525ead-e18a-4e3f-852d-ca1854139dc0"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(3885), null, "kai.orga@arm.com.ng", true, false, null, null, null, "Kai Orga", "ARM IM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") }
                });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2056820f-51e8-43c2-80d4-512346cc813c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d667eed-04db-481c-9ae0-1c7e614e4507"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("a8cac012-b665-481a-8028-90ed1c4226f9"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 18, 0, 10, 548, DateTimeKind.Utc).AddTicks(8349));

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMap_RoleId",
                table: "UserRoleMap",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleMap");

            migrationBuilder.DropTable(
                name: "User");
 
            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2056820f-51e8-43c2-80d4-512346cc813c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1899));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8d667eed-04db-481c-9ae0-1c7e614e4507"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1895));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("a8cac012-b665-481a-8028-90ed1c4226f9"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1907));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1925));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"),
                column: "CreatedOnUtc",
                value: new DateTime(2025, 3, 23, 16, 0, 37, 855, DateTimeKind.Utc).AddTicks(1910));
        }
    }
}
