using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("01a7076c-b7cc-4c4e-8b1c-9a929337ed4a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0823fc35-2de3-4068-98c1-a8f6d0184be7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0d398961-8971-466d-8489-3652ed84d4d5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0d9a123d-d041-4886-93d5-754c679609e8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0f2d6bc3-54a0-4920-b3c2-02dd5c509d5b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("109c37ac-b508-4403-bfa8-8e5fb54a70f1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10e38755-bf42-4b15-912f-0d09a06e991d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1149ee47-57ff-44ea-a4d5-ad7e1f702d9e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13599a6a-93bd-406e-b81b-112e3be626ca"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1c457bc2-0740-4699-a15c-b21554e05ead"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1c4bd8f7-9bb2-43e9-89e8-dbfe8819d9a1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1ce02542-4152-40cf-90f9-8be2bc02fb96"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("21cc65e9-3739-4eda-b096-726f6f3ebb6d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("25972c92-f5c7-4f6b-9526-0bd6650933b2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2cc7cee6-37b9-4ca2-b0e3-aab334129e1a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2e8a2190-2243-462b-903b-986ce3182cad"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2f595130-3a6e-4551-900a-f558b5a91ba1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3485ea69-1bcc-4ba8-9f38-f3fb0b4fcdd1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("372c45a8-e7e2-418f-a8c9-207f09cd1161"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("38c28af1-1428-46a6-96af-31636e86f06f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3c8f4fd3-ac45-4b64-8346-2f12a3081e18"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3ff6d552-9933-45c3-a3ad-0f82dae42695"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("436e0f9e-a459-458e-a39b-92a4043b1d48"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("440a72d9-df35-4af5-97a4-7934a124eb71"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("49eddb26-9714-44d3-aed7-6d35493eabc3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4c9c2b13-0993-4ce0-a42e-858b84d634d4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4cf55e1b-7072-4e20-9050-198b301f7367"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("513c47d7-8325-4c48-b558-8be1580b9a3e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("54271b3f-02f2-4f02-a584-7c0d0673dd01"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("55c555e4-b7a1-48aa-b79c-792e6072ac68"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("560be7c4-f597-4107-b0d9-43f6b6307d7a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58915699-1038-4f42-9e0e-3796cbb0d398"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58cb4076-0472-4513-8641-ab2a9afe475c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58d8805c-7080-40dd-94a9-186cb1c15349"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5ad9a543-3920-46b1-8829-7c786f6e2410"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("63ba6a4b-37dd-4d78-a76c-064a1a9a6e9b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("69341120-467e-44ff-b0bc-6b0528658ec3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("72aae660-16bd-4baf-b5af-6823d59bcf1e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("74c29ab0-d228-4c60-974a-937525f99cb4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75213f8b-5c95-4058-a99a-04b7b9a6d8b4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("776d5b43-5c1c-4d8b-82bd-cd08b19ee65e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("78a45928-2479-497b-b464-ba8200c0b79f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7b743dde-efc3-44d1-8e23-4efe18ce5902"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7ba537fc-4901-45f7-9949-4e5455968eb1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7c7c5bf2-f35e-4f4e-8197-7bf1c90513c3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7e305198-2f0e-44c2-8b49-a43f54c4a69a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("809a99cd-5ed3-4f9d-9b83-75e523511176"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8120ab53-21fd-4fe3-8a8a-7d02d5f7a08b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("82680ebb-6dc0-4b47-8ace-f862423500fb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("83f375c4-71ef-4202-888c-2be5e047f258"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("873de00f-3bc7-4588-923b-2a745b78ce12"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8f48ab4d-83b3-46f9-aba4-3e6122e63f3e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("92174a6c-c484-48ad-bade-0f5a552c0f48"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("97601f31-81e5-4292-a706-c49d7511fecf"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("97785247-d2ba-4da7-863e-7e426605e1dd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9919e073-56da-4565-8448-142dfafe1778"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9b77fc7c-8e5c-48ec-8759-8f053ff5ffbb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9cf25244-915d-41fe-a9e7-d4c7d66d7bd1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9ef3ee3f-3be5-4589-9fba-7de6bed53b07"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a510cf36-2722-41de-88f2-ba94a2a7b690"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a6e2f856-eff4-4668-9965-abc8dc3511e9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("aad263b0-60a4-454f-928e-7479592f00ba"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ab3197b4-795e-4095-aca5-98d33cb1b215"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ae2f806d-9f3a-4e5b-b015-af79531cd436"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("aff48248-6803-43df-b7f4-526badfdb28f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b2e782c2-a01f-496a-8b7a-52286eb60280"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b2e91786-48ec-4bf6-af79-880feaf02ccc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b3d3e7cc-1ab2-4831-8a33-fd8827402bcd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b5e97b9f-65b0-4b83-86d4-f94d5bda6f66"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b78d486a-b35b-4848-b2fb-fa7f24a506d7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b9cf3a50-1385-402b-becb-405c01e6903d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ba231dc2-0a5f-4058-8776-cec2f13fd4fe"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c00507b3-7e06-441c-ad88-13d9bb4fa351"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c050340c-65bd-44a5-8575-bf9517f4831d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c160021d-1301-486f-997d-176944db9921"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3682106-1c49-4714-bf31-977b6a9b10cd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c89a7ba3-3862-4a06-a252-874283671aa2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cc46e6c5-40f8-48a8-8e5a-86c8bd81c15c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cc7c9577-414e-494c-b505-ad963d33b1f3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d2fe7644-373e-4186-a452-4b3cc38406e0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d686961a-fdd3-4fc1-930f-1d1adb1d8825"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d68d39a1-cede-42a1-8940-3282c8c60abe"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d9a1aac8-a0e1-4259-9674-c5133d77a3e7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("dafbf93a-f2aa-4c81-8607-5ea5ae433c57"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e0e94926-7633-45a1-b35a-0ce3f8bd9c44"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e1ae66f0-9468-41cc-b6b2-c9094b3164ee"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e66aef98-fa19-4a7b-968e-10ba5ea347ff"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e6eece0a-be86-4ec4-8ba6-2b5ad16c612f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eaeca829-d6de-4670-a7ab-5ea14a2cf061"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ecd8d4c4-997a-4dda-aa5e-4947b8111e83"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ecdf2829-42f5-4be4-a390-d5348c2b5b49"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f1d95d98-06ab-44d4-aac4-8e7b420421ca"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f2e74168-3da5-4e4a-85a7-20290e5d7612"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f375b872-bf3a-4d74-b65a-f1cb35b24511"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f792624d-f54c-40e2-830b-c4e05e6eb6f0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7f35bfd-2201-4f32-b81d-b6d14ebee335"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f926356f-abb9-4830-b658-7a9ccfd11a5f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ff5979d6-f48c-42d2-8561-2b0c4675c93e"));

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                table: "ComplianceRegulatoryPayment",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ComplianceRegulatoryPayment",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("0174147d-01c3-4d55-af32-1366761125b1"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5239), null, "Ibukun.Ajose@arm.com.ng", false, null, null, "Ibukun Ajose", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("01d6abaf-882d-4dcc-9c5b-529cf7ee720a"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5397), null, "olabisi.adesina@arm.com.ng", false, null, null, "Olabisi Adesina", "Legal,Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("03e0220e-1eea-4fcb-81a0-466b3fbef54d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5209), null, "Stephen.Igwenwanne@arm.com.ng", false, null, null, "Stephen Igwenwanne", "WRM (PortHarcourt)", new Guid("80245081-74bc-4124-87f5-d6008b28706b"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("03f99534-49e8-4298-b1e9-803395ea8695"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5273), null, "Jacqueline.Adefeso@arm.com.ng", false, null, null, "Jacqueline Adefeso", "Procurement and Administration", new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("050f9d8f-005a-4f40-b518-bf9ee88fdce0"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5254), null, "oritsegbemi.agbajor@arm.com.ng", false, null, null, "Oritsegbemi Agbajor", "ARM Commercial Trust", new Guid("05652a26-461c-4c78-be42-f212fc5fd083"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("070d5e2a-3fb7-4ed7-9b31-7afb62658f32"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5264), null, "Ezekiel.solomon@arm.com.ng", false, null, null, "Ezekiel Solomon", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("0929a098-ea1c-443b-b929-9ffd0ce3df3b"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5382), null, "olugbenga.ajigbotafe@arm.com.ng", false, null, null, "Olugbenga Ajigbotafe", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("0bb4b6e9-ebf5-40d4-94ce-64d1d72cc51b"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5345), null, "opeyemi.babasola@arm.com.ng", false, null, null, "Opeyemi Babasola", "Securities Operations,Financial Control", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("110b99af-6f0f-4784-860c-9bdde455058e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5368), null, "valerie.okosun@arm.com.ng", false, null, null, "Valerie Okosun", "Securities Operations,Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("160a6e4b-dff6-4bc2-9661-f91fa8602c3b"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5226), null, "Igbagbo.Ilori@arm.com.ng", false, null, null, "Igbagbo Ilori", "ARM Academy", new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("1682522a-a70a-477f-95d4-bd0af174afae"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5394), null, "faith.sani@arm.com.ng", false, null, null, "Faith Sani", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("1733710e-6e1b-49b8-8f35-47cffe15f95e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5247), null, "raymond.akorah@arm.com.ng", false, null, null, "Raymond Akorah", "ARM Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("1b09bdea-2825-4329-86e0-231bd1589673"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5343), null, "james.agu@arm.com.ng", false, null, null, "James Agu", "Operations Control", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("1efc9305-b8c9-4c4f-bfc7-fc7fd534ce89"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5197), null, "phoebe.ohiembor@arm.com.ng", false, null, null, "Phoebe Ohiembor", "Information Technology", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("21c3853a-41d1-40b1-b259-d44a4a2442c8"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5275), null, "moradeke.odugbesan@arm.com.ng", false, null, null, "Moradeke Odugbesan", "Procurement and Administration", new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("2451e4fc-da2d-4513-a44c-39f3be2a0eef"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5374), null, "oluwatosin.afolayan@arm.com.ng", false, null, null, "Oluwatosin Afolayan", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("27576f79-02c6-42a6-9ae1-a4653fb8cd86"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5188), null, "olabisi.adesina@arm.com.ng", false, null, null, "Olabisi Adesina", "Legal", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("28dbb258-c63a-41e0-9e53-67ef5cf9de57"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5191), null, "Ediagbonya.Osayomwanbo@arm.com.ng", false, null, null, "Ediagbonya Osayomwanbo", "WRM (Abuja)", new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("29f4cdf2-0ec8-4729-abac-655b861d26f4"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5285), null, "doyinsola.ola@arm.com.ng", false, null, null, "Doyinsola Ola", "WRM (Lagos)", new Guid("500fc670-2f14-4786-9092-f7f82b8ae507"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("2a291aa2-4435-47bc-a9b0-334a9167e2c7"), "ARM Digital Financial Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5251), null, "Ina.Alogwu@arm.com.ng", false, null, null, "Ina Alogwu", "Digital Financial Services", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("2ae26ba0-78e5-4241-b6c6-7987ca359569"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5211), null, "ndubuisi.anya@arm.com.ng", false, null, null, "Ndubuisi Anya", "WRM (PortHarcourt)", new Guid("80245081-74bc-4124-87f5-d6008b28706b"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("2b1e0984-936e-4ade-8c3f-430070d05c68"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5282), null, "rotimi.olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("2ea42ded-e826-4f4e-a2ad-93d0a51c3d6d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5184), null, "iwasam.elemi@arm.com.ng", false, null, null, "Iwasam Elemi", "Risk management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("2fb82534-8037-42bb-9594-2dd907db3a62"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5333), null, "anuoluwapo.sebanjo@arm.com.ng", false, null, null, "Anuoluwapo Sebanjo", "Corporate Strategy", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("378f17f6-128e-49f9-8f58-a4ce81c69b7c"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5186), null, "Nehizena.Ibhawoh@arm.com.ng", false, null, null, "Nehizena Ibhawoh", "Legal", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("3989733b-de80-45ca-9bfa-52c697fa4e4a"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5350), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("3a82043c-8cd8-40c1-a0a1-c4b2dc478ea7"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5258), null, "olugbenga.ajigbotafe@arm.com.ng", false, null, null, "Olugbenga Ajigbotafe", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("3df73eab-91f1-4812-a7ac-d19a6af5241d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5385), null, "abayomi.apoeso@arm.com.ng", false, null, null, "Abayomi Apoeso", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("409fddba-f019-44a7-882e-0a9784c71e8b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5364), null, "bimbo.moses@arm.com.ng", false, null, null, "Bimbo Moses", "Securities Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("45735445-dadb-4140-bebd-f3bdb43f6c54"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5287), null, "rasheed.adebola@arm.com.ng", false, null, null, "Rasheed Adebola", "WRM (Lagos)", new Guid("500fc670-2f14-4786-9092-f7f82b8ae507"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("476f24be-beae-4944-973c-2d898d3f8cf9"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5339), null, "gbeminiyi.onipede@arm.com.ng", false, null, null, "Gbeminiyi Onipede", "HoldCo Sales", new Guid("772f854e-c9f6-4428-bad1-53db881e28bb"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("4e6df287-2429-4686-93af-29800266170e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5315), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("4f01fe75-1825-4714-a380-c6a97fee449d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5193), null, "james.ewah@arm.com.ng", false, null, null, "James Ewah", "WRM (Abuja)", new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("50f56ccc-af52-44be-99ff-19a48c339f73"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5237), null, "nnamdi.okeke@arm.com.ng", false, null, null, "Nnamdi Okeke", "ARM Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("514740d9-9739-4171-894c-02e5f698133e"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5323), null, "faith.sani@arm.com.ng", false, null, null, "Faith Sani", "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("522f8cdb-94f0-4e56-97a9-2547929b7758"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5369), null, "kingsley.ottah@arm.com.ng", false, null, null, "Kingsley Ottah", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("5514332d-d6e3-4deb-8d80-87dc77cde805"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5377), null, "olawale.bakir@arm.com.ng", false, null, null, "Olawale Bakir", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("5663b6dd-a898-4073-861d-f3dfe90d6dda"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5395), null, "augustine.chukwu@arm.com.ng", false, null, null, "Augustine Chukwu", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("58c08dd6-f708-4774-be71-224b4f512616"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5295), null, "moyosore.taiwo@arm.com.ng", false, null, null, "Moyosore Taiwo", "Research", new Guid("a6409616-e559-4ff8-a877-0925be18ff3d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("6009fb6d-5552-44f7-a1a9-42c7d08951f6"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5320), null, "tosin.adesope@arm.com.ng", false, null, null, "Tosin Adesope", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("60a78977-7f9a-4c31-9bbf-d07c646c76dd"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5337), null, "gbeminiyi.onipede@arm.com.ng", false, null, null, "Gbeminiyi Onipede", "HoldCo Sales", new Guid("772f854e-c9f6-4428-bad1-53db881e28bb"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("65e561a7-c7c3-4277-b1a5-2064e618f760"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5280), null, "moshood.hassan@arm.com.ng", false, null, null, "Moshood Hassan", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("66a8ac50-19f1-4e64-8543-ee8aa84cbaeb"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5361), null, "temitope.akinola@arm.com.ng", false, null, null, "Temitope Akinola", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("66c69eea-ab72-416d-9e1e-4246ca8a02b3"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5372), null, "ramond.akorah@arm.com.ng", false, null, null, "Ramond Akorah", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("674ea36d-7cb9-4158-a275-c0207da50de9"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5235), null, "Oluwaferanmi.Olorunleke@arm.com.ng", false, null, null, "Seun idowu", "ARM Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("6999cf64-b2f2-4306-9c32-3b0824748f8f"), "ARM Digital Financial Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5252), null, "folaranmi.adefila@arm.com.ng", false, null, null, "Folaranmi Adefila", "Digital Financial Services", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("6bd0166b-0c7b-4296-8181-ab1392bc445b"), "ARM Agricbusiness Fund Manager Ltd", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5216), null, "david.akinboade@arm.com.ng", false, null, null, "David Akinboade", "RFL", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("6f6f1f1b-adbf-4a0c-b4e0-ac36197b85ca"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5325), null, "mounir.bouba@arm.com.ng", false, null, null, "Mounir Bouba", "Investment Managment", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("71ebe072-b049-4d5e-895a-8148671c7d78"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5399), null, "kiadum.nwakoh@arm.com.ng", false, null, null, "Kiadum Nwakoh", "Legal,Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("7a700475-c0aa-4870-99b8-3a2a4d5c9986"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5179), null, "chukwuebuka.obieri@arm.com.ng", false, null, null, "Chukwuebuka Obieri", "Risk management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("883a6c36-0aff-4a1d-8df1-c14e772fa765"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5224), null, "Adeleye.Adewusi@arm.com.ng", false, null, null, "Adeleye Adewusi", "ARM Academy", new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("8b03207b-92be-4244-a9d6-8860ca7895f1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5330), null, "hamed.omotayo@arm.com.ng", false, null, null, "Hamed Omotayo", "Retail Sales", new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("8e462146-af08-48a4-b8cc-c1e8fa7ee517"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5380), null, "babatunde.osho@arm.com.ng", false, null, null, "Babatunde Osho", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("91a62b23-94c5-4395-a654-106c11fc458a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5271), null, "Olaoluwa.Omolayole@arm.com.ng", false, null, null, "Olaoluwa Omolayole", "Corporate Transformation", new Guid("850b308d-bef3-41ad-b812-413b868e7621"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("93a9359e-aaf6-4b9b-883c-f4c7bbe8ca00"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5284), null, "opeyemi.babasola@arm.com.ng", false, null, null, "Opeyemi Babasola", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("95f37d2f-b93f-44b1-8c08-a92dce8b3a2c"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5386), null, "joy.oyekan@arm.com.ng", false, null, null, "Joy Oyekan", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("986dd45f-ecc7-4b0d-bff9-6e629a8b5783"), "ARM Harith Infracstrure Investement Limited", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5302), null, "tariye.gbadegesin@arm.com.ng", false, null, null, "Tariye Gbadegesin", "ARM Harith Infrastructure Investment Ltd", new Guid("44fe054d-83dd-41da-b90a-a53631af453d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("a18269d0-c9fd-4e01-bba4-ba15b41b2833"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5245), null, "Isaac.Elakhe@arm.com.ng", false, null, null, "Isaac Elakhe", "ARM Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("a7b5c945-a616-488c-8dbc-45ff800614ba"), "ARM Harith Infracstrure Investement Limited", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5304), null, "oyedele.oyinbojuni@armharith.com", false, null, null, "Oyedele Oyinbojuni", "ARM Harith Infrastructure Investment Ltd", new Guid("44fe054d-83dd-41da-b90a-a53631af453d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("a824d429-8d9d-4fa6-b49d-5d6520791acb"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5401), null, "nehizena.ibhawoh@arm.com.ng", false, null, null, "Nehizena Ibhawoh", "Legal,Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("a865af36-c8dd-4ecf-a57a-4a2c926bc8ea"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5351), null, "kareem.bashir@arm.com.ng", false, null, null, "Kareem Bashir", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("a9656c22-d9f4-4aa2-a031-ff5447ee0294"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5356), null, "oluwatosin.adeboyejo@arm.com.ng", false, null, null, "Oluwatosin Adeboyejo", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("a9fd718f-2218-48a9-98e6-29a7d335d905"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5256), null, "oritsegbemi.agbajor@arm.com.ng", false, null, null, "Oritsegbemi Agbajor", "ARM Commercial Trust", new Guid("05652a26-461c-4c78-be42-f212fc5fd083"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("ab1c3a9b-42a5-47db-83b2-9d2fe9f528e1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5231), null, "Aminat.Ashafa@arm.com.ng", false, null, null, "Aminat Ashafa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("abf14514-ccc6-4223-8ffb-59293252e8d9"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5263), null, "Oluwabunmi.Abiodun-Wright@arm.com.ng", false, null, null, "Oluwabunmi Abiodun-Wright", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("ac32615e-fb99-4ee9-a16c-e2ffc5d1e120"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5260), null, "joy.oyekan@arm.com.ng", false, null, null, "Joy Oyekan", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("b24cb0f6-78ee-41f9-8f1e-629e69c05196"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5207), null, "ubi.torsam@arm.com.ng", false, null, null, "Ubi Torsam", "Marketing and Corporate Communications", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("b4fbad80-9b8b-4972-809e-7fb46412cbed"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5318), null, "itunu.olatunde-folaji@arm.com.ng", false, null, null, "Itunu Olatunde-Folaji", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("b6824858-253b-41b7-83d7-759b84954272"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5335), null, "philip.aikinomiora @arm.com.ng", false, null, null, "Philip Aikinomiora", "Corporate Strategy", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("bb7c1d62-a452-4a52-88de-640c91a4df41"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5371), null, "lincoln.ogigai@arm.com.ng", false, null, null, "Lincoln Ogigai", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("bfddcb29-046e-4b4f-a05a-7bf0c8f6852e"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5218), null, "Eddy.Ayikimi@arm.com.ng", false, null, null, "Eddy Ayikimi", "Customer Experience", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("c1f46793-77c2-4b0b-8ae0-139390a54bcf"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5358), null, "elizabeth.alloy@arm.com.ng", false, null, null, "Elizabeth Alloy", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("c224560d-a657-4389-ad28-70cd4b8a89e3"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5270), null, "Carol.Ariyibi@arm.com.ng", false, null, null, "Carol Ariyibi", "Corporate Transformation", new Guid("850b308d-bef3-41ad-b812-413b868e7621"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("c5f0ec74-627c-4e1c-a006-ec97490a10e6"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5329), null, "raphael.emenyonu@arm.com.ng", false, null, null, "Raphael Emenyonu", "Retail Sales", new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("c6d6f05e-cfe8-4680-96d3-8223b5d2e9c6"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5195), null, "Olayemi.Toye@arm.com.ng", false, null, null, "Olayemi Toye", "Information Technology", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("c887f581-bad6-4562-b230-9f60440a163c"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5290), null, "lincoln.ogigai@arm.com.ng", false, null, null, "Lincoln Ogigai", "Compliance", new Guid("a470f202-ca90-4fc9-8617-358311885a1c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("cc9ac1a1-433a-4f66-ab98-ebf5103908d0"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5314), null, "adetayo.adebiyi@arm.com.ng", false, null, null, "Adetayo Adebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("d0fb492a-c61a-4686-a52b-a44199fcff2f"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5376), null, "evelyn.nwogu@arm.com.ng", false, null, null, "Evelyn Nwogu", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("d11a9d2c-6cfa-4204-920a-b00938e08a31"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5267), null, "Rotimi.Olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("d940cda6-8901-46db-b659-111b60803221"), "ARM Agricbusiness Fund Manager Ltd", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5214), null, "Hassan.AdeObafemi@arm.com.ng", false, null, null, "Hassan AdeObafemi", "RFL", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("db5e9d1b-2b3e-4a26-8a69-5573a99437a9"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5268), null, "vwede.edah@arm.com.ng", false, null, null, "Vwede Edah", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("dbb1ae4a-fc7d-4a7c-9392-a2f657bded65"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5241), null, "Kevian.Kevin@arm.com.ng", false, null, null, "Kevian Kevin", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("df8a6076-83e4-4b63-8a31-1001d451b421"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5321), null, "abayomi.apoeso@arm.com.ng", false, null, null, "Abayomi Apoeso", "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("e245380d-ded9-43e6-b53d-b76c1e3f5b71"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5347), null, "gbenga.sonubi@arm.com.ng", false, null, null, "Gbenga Sonubi", "Securities Operations,Financial Control", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("e24e4865-2d68-45b1-9c26-de0c418c8b1e"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5206), null, "Ethan.Okwara@arm.com.ng", false, null, null, "Ethan Okwara", "Marketing and Corporate Communications", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("e3cb26f2-9043-4fe7-8cd6-ad1b4dddca4a"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5229), null, "bimbo.moses@arm.com.ng", false, null, null, "Bimbo Moses", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("ec472f24-0335-419c-b293-dba9d8d62c2d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5306), null, "isaac.elakhe@arm.com.ng", false, null, null, "Isaac Elakhe", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("ee91829d-3368-4602-86ca-faeee18b76dd"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5294), null, "rotimi.olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Research", new Guid("a6409616-e559-4ff8-a877-0925be18ff3d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("eefd3228-ff3b-46e7-b596-366cab4cd71c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5341), null, "opeyemi.oshinyemi@arm.com.ng", false, null, null, "Opeyemi Oshinyemi", "Operations Control", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("f38bd3b0-fadf-498a-9b57-edeb29c826e8"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5326), null, "chukwufumnanya.chizea@arm.com.ng", false, null, null, "Chukwufumnanya Chizea", "Investment Managment", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("f3ba2800-b428-4719-b228-75ec7155977b"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5359), null, "stephanie.gber@arm.com.ng", false, null, null, "Stephanie Gber", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("f5251959-ce5a-436e-9f66-e5e89152f6e4"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5278), null, "Dare.Shobajo@arm.com.ng", false, null, null, "Dare Shobajo", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("f861056d-0144-42d6-a2bf-53d30680e52b"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5220), null, "akpesiri.kodu@arm.com.ng", false, null, null, "Akpesiri Kodu", "Customer Experience", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("f8ba6155-226c-4468-aa2f-fc6efe5eccec"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5308), null, "oladupe.oshinuga@arm.com.ng", false, null, null, "Oladupe Oshinuga", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("f9276a8b-fffb-402f-91c8-f8a014785163"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5354), null, "oluyemi.omodayo@arm.com.ng", false, null, null, "Oluyemi Omodayo", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("fa96e824-19cd-49d8-8ce6-f06c39930b70"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5288), null, "oluyemi.omodayo@arm.com.ng", false, null, null, "Oluyemi Omodayo", "Compliance", new Guid("a470f202-ca90-4fc9-8617-358311885a1c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("fdcf5a8f-c8aa-4b72-933e-6da558cc09e8"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5353), null, "patrick.ayele@arm.com.ng", false, null, null, "Patrick Ayele", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("ffae07a0-e3bd-446d-8e5b-ebf41d8ff70a"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 17, 34, 59, 876, DateTimeKind.Utc).AddTicks(5383), null, "vwede.edah@arm.com.ng", false, null, null, "Vwede Edah", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0174147d-01c3-4d55-af32-1366761125b1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("01d6abaf-882d-4dcc-9c5b-529cf7ee720a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("03e0220e-1eea-4fcb-81a0-466b3fbef54d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("03f99534-49e8-4298-b1e9-803395ea8695"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("050f9d8f-005a-4f40-b518-bf9ee88fdce0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("070d5e2a-3fb7-4ed7-9b31-7afb62658f32"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0929a098-ea1c-443b-b929-9ffd0ce3df3b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0bb4b6e9-ebf5-40d4-94ce-64d1d72cc51b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("110b99af-6f0f-4784-860c-9bdde455058e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("160a6e4b-dff6-4bc2-9661-f91fa8602c3b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1682522a-a70a-477f-95d4-bd0af174afae"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1733710e-6e1b-49b8-8f35-47cffe15f95e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1b09bdea-2825-4329-86e0-231bd1589673"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1efc9305-b8c9-4c4f-bfc7-fc7fd534ce89"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("21c3853a-41d1-40b1-b259-d44a4a2442c8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2451e4fc-da2d-4513-a44c-39f3be2a0eef"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("27576f79-02c6-42a6-9ae1-a4653fb8cd86"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28dbb258-c63a-41e0-9e53-67ef5cf9de57"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("29f4cdf2-0ec8-4729-abac-655b861d26f4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2a291aa2-4435-47bc-a9b0-334a9167e2c7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2ae26ba0-78e5-4241-b6c6-7987ca359569"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2b1e0984-936e-4ade-8c3f-430070d05c68"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2ea42ded-e826-4f4e-a2ad-93d0a51c3d6d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2fb82534-8037-42bb-9594-2dd907db3a62"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("378f17f6-128e-49f9-8f58-a4ce81c69b7c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3989733b-de80-45ca-9bfa-52c697fa4e4a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3a82043c-8cd8-40c1-a0a1-c4b2dc478ea7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3df73eab-91f1-4812-a7ac-d19a6af5241d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("409fddba-f019-44a7-882e-0a9784c71e8b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("45735445-dadb-4140-bebd-f3bdb43f6c54"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("476f24be-beae-4944-973c-2d898d3f8cf9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4e6df287-2429-4686-93af-29800266170e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4f01fe75-1825-4714-a380-c6a97fee449d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50f56ccc-af52-44be-99ff-19a48c339f73"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("514740d9-9739-4171-894c-02e5f698133e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("522f8cdb-94f0-4e56-97a9-2547929b7758"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5514332d-d6e3-4deb-8d80-87dc77cde805"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5663b6dd-a898-4073-861d-f3dfe90d6dda"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58c08dd6-f708-4774-be71-224b4f512616"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6009fb6d-5552-44f7-a1a9-42c7d08951f6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("60a78977-7f9a-4c31-9bbf-d07c646c76dd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("65e561a7-c7c3-4277-b1a5-2064e618f760"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("66a8ac50-19f1-4e64-8543-ee8aa84cbaeb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("66c69eea-ab72-416d-9e1e-4246ca8a02b3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("674ea36d-7cb9-4158-a275-c0207da50de9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6999cf64-b2f2-4306-9c32-3b0824748f8f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6bd0166b-0c7b-4296-8181-ab1392bc445b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6f6f1f1b-adbf-4a0c-b4e0-ac36197b85ca"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71ebe072-b049-4d5e-895a-8148671c7d78"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7a700475-c0aa-4870-99b8-3a2a4d5c9986"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("883a6c36-0aff-4a1d-8df1-c14e772fa765"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8b03207b-92be-4244-a9d6-8860ca7895f1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8e462146-af08-48a4-b8cc-c1e8fa7ee517"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("91a62b23-94c5-4395-a654-106c11fc458a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("93a9359e-aaf6-4b9b-883c-f4c7bbe8ca00"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("95f37d2f-b93f-44b1-8c08-a92dce8b3a2c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("986dd45f-ecc7-4b0d-bff9-6e629a8b5783"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a18269d0-c9fd-4e01-bba4-ba15b41b2833"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a7b5c945-a616-488c-8dbc-45ff800614ba"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a824d429-8d9d-4fa6-b49d-5d6520791acb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a865af36-c8dd-4ecf-a57a-4a2c926bc8ea"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a9656c22-d9f4-4aa2-a031-ff5447ee0294"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a9fd718f-2218-48a9-98e6-29a7d335d905"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ab1c3a9b-42a5-47db-83b2-9d2fe9f528e1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("abf14514-ccc6-4223-8ffb-59293252e8d9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ac32615e-fb99-4ee9-a16c-e2ffc5d1e120"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b24cb0f6-78ee-41f9-8f1e-629e69c05196"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b4fbad80-9b8b-4972-809e-7fb46412cbed"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b6824858-253b-41b7-83d7-759b84954272"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bb7c1d62-a452-4a52-88de-640c91a4df41"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bfddcb29-046e-4b4f-a05a-7bf0c8f6852e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c1f46793-77c2-4b0b-8ae0-139390a54bcf"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c224560d-a657-4389-ad28-70cd4b8a89e3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c5f0ec74-627c-4e1c-a006-ec97490a10e6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c6d6f05e-cfe8-4680-96d3-8223b5d2e9c6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c887f581-bad6-4562-b230-9f60440a163c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cc9ac1a1-433a-4f66-ab98-ebf5103908d0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d0fb492a-c61a-4686-a52b-a44199fcff2f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d11a9d2c-6cfa-4204-920a-b00938e08a31"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d940cda6-8901-46db-b659-111b60803221"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("db5e9d1b-2b3e-4a26-8a69-5573a99437a9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("dbb1ae4a-fc7d-4a7c-9392-a2f657bded65"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("df8a6076-83e4-4b63-8a31-1001d451b421"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e245380d-ded9-43e6-b53d-b76c1e3f5b71"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e24e4865-2d68-45b1-9c26-de0c418c8b1e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e3cb26f2-9043-4fe7-8cd6-ad1b4dddca4a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ec472f24-0335-419c-b293-dba9d8d62c2d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ee91829d-3368-4602-86ca-faeee18b76dd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eefd3228-ff3b-46e7-b596-366cab4cd71c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f38bd3b0-fadf-498a-9b57-edeb29c826e8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f3ba2800-b428-4719-b228-75ec7155977b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f5251959-ce5a-436e-9f66-e5e89152f6e4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f861056d-0144-42d6-a2bf-53d30680e52b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f8ba6155-226c-4468-aa2f-fc6efe5eccec"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f9276a8b-fffb-402f-91c8-f8a014785163"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fa96e824-19cd-49d8-8ce6-f06c39930b70"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fdcf5a8f-c8aa-4b72-933e-6da558cc09e8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ffae07a0-e3bd-446d-8e5b-ebf41d8ff70a"));

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountPaid",
                table: "ComplianceRegulatoryPayment",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ComplianceRegulatoryPayment",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("01a7076c-b7cc-4c4e-8b1c-9a929337ed4a"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3825), null, "bimbo.moses@arm.com.ng", false, null, null, "Bimbo Moses", "Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("0823fc35-2de3-4068-98c1-a8f6d0184be7"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3813), null, "oluwatosin.adeboyejo@arm.com.ng", false, null, null, "Oluwatosin Adeboyejo", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("0d398961-8971-466d-8489-3652ed84d4d5"), "ARM Digital Financial Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3706), null, "folaranmi.adefila@arm.com.ng", false, null, null, "Folaranmi Adefila", "Digital Financial Services", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("0d9a123d-d041-4886-93d5-754c679609e8"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3803), null, "opeyemi.babasola@arm.com.ng", false, null, null, "Opeyemi Babasola", "Operations,Financial Control", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("0f2d6bc3-54a0-4920-b3c2-02dd5c509d5b"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3846), null, "joy.oyekan@arm.com.ng", false, null, null, "Joy Oyekan", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("109c37ac-b508-4403-bfa8-8e5fb54a70f1"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3822), null, "stephanie.gber@arm.com.ng", false, null, null, "Stephanie Gber", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("10e38755-bf42-4b15-912f-0d09a06e991d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3789), null, "anuoluwapo.sebanjo@arm.com.ng", false, null, null, "Anuoluwapo Sebanjo", "Corporate Strategy", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("1149ee47-57ff-44ea-a4d5-ad7e1f702d9e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3764), null, "isaac.elakhe@arm.com.ng", false, null, null, "Isaac Elakhe", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("13599a6a-93bd-406e-b81b-112e3be626ca"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3685), null, "bimbo.moses@arm.com.ng", false, null, null, "Bimbo Moses", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("1c457bc2-0740-4699-a15c-b21554e05ead"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3829), null, "kingsley.ottah@arm.com.ng", false, null, null, "Kingsley Ottah", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("1c4bd8f7-9bb2-43e9-89e8-dbfe8819d9a1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3782), null, "chukwufumnanya.chizea@arm.com.ng", false, null, null, "Chukwufumnanya Chizea", "Investment Managment", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("1ce02542-4152-40cf-90f9-8be2bc02fb96"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3709), null, "oritsegbemi.agbajor@arm.com.ng", false, null, null, "Oritsegbemi Agbajor", "ARM Commercial Trust", new Guid("05652a26-461c-4c78-be42-f212fc5fd083"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("21cc65e9-3739-4eda-b096-726f6f3ebb6d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3697), null, "Kevian.Kevin@arm.com.ng", false, null, null, "Kevian Kevin", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("25972c92-f5c7-4f6b-9526-0bd6650933b2"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3656), null, "Olayemi.Toye@arm.com.ng", false, null, null, "Olayemi Toye", "Information Technology", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("2cc7cee6-37b9-4ca2-b0e3-aab334129e1a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3681), null, "Igbagbo.Ilori@arm.com.ng", false, null, null, "Igbagbo Ilori", "ARM Academy", new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("2e8a2190-2243-462b-903b-986ce3182cad"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3838), null, "olawale.bakir@arm.com.ng", false, null, null, "Olawale Bakir", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("2f595130-3a6e-4551-900a-f558b5a91ba1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3811), null, "oluyemi.omodayo@arm.com.ng", false, null, null, "Oluyemi Omodayo", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("3485ea69-1bcc-4ba8-9f38-f3fb0b4fcdd1"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3844), null, "abayomi.apoeso@arm.com.ng", false, null, null, "Abayomi Apoeso", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("372c45a8-e7e2-418f-a8c9-207f09cd1161"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3736), null, "Jacqueline.Adefeso@arm.com.ng", false, null, null, "Jacqueline Adefeso", "Procurement and Administration", new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("38c28af1-1428-46a6-96af-31636e86f06f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3827), null, "valerie.okosun@arm.com.ng", false, null, null, "Valerie Okosun", "Operations,Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("3c8f4fd3-ac45-4b64-8346-2f12a3081e18"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3852), null, "olabisi.adesina@arm.com.ng", false, null, null, "Olabisi Adesina", "Legal and Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("3ff6d552-9933-45c3-a3ad-0f82dae42695"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3843), null, "vwede.edah@arm.com.ng", false, null, null, "Vwede Edah", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("436e0f9e-a459-458e-a39b-92a4043b1d48"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3719), null, "Ezekiel.solomon@arm.com.ng", false, null, null, "Ezekiel Solomon", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("440a72d9-df35-4af5-97a4-7934a124eb71"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3799), null, "james.agu@arm.com.ng", false, null, null, "James Agu", "Operations Control", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("49eddb26-9714-44d3-aed7-6d35493eabc3"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3657), null, "phoebe.ohiembor@arm.com.ng", false, null, null, "Phoebe Ohiembor", "Information Technology", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("4c9c2b13-0993-4ce0-a42e-858b84d634d4"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3676), null, "akpesiri.kodu@arm.com.ng", false, null, null, "Akpesiri Kodu", "Customer Experience", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("4cf55e1b-7072-4e20-9050-198b301f7367"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3662), null, "Stephen.Igwenwanne@arm.com.ng", false, null, null, "Stephen Igwenwanne", "WRM (PortHarcourt)", new Guid("80245081-74bc-4124-87f5-d6008b28706b"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("513c47d7-8325-4c48-b558-8be1580b9a3e"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3710), null, "oritsegbemi.agbajor@arm.com.ng", false, null, null, "Oritsegbemi Agbajor", "ARM Commercial Trust", new Guid("05652a26-461c-4c78-be42-f212fc5fd083"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("54271b3f-02f2-4f02-a584-7c0d0673dd01"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3823), null, "temitope.akinola@arm.com.ng", false, null, null, "Temitope Akinola", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("55c555e4-b7a1-48aa-b79c-792e6072ac68"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3795), null, "gbeminiyi.onipede@arm.com.ng", false, null, null, "Gbeminiyi Onipede", "HoldCo Sales", new Guid("772f854e-c9f6-4428-bad1-53db881e28bb"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("560be7c4-f597-4107-b0d9-43f6b6307d7a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3776), null, "abayomi.apoeso@arm.com.ng", false, null, null, "Abayomi Apoeso", "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("58915699-1038-4f42-9e0e-3796cbb0d398"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3695), null, "Ibukun.Ajose@arm.com.ng", false, null, null, "Ibukun Ajose", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("58cb4076-0472-4513-8641-ab2a9afe475c"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3746), null, "opeyemi.babasola@arm.com.ng", false, null, null, "Opeyemi Babasola", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("58d8805c-7080-40dd-94a9-186cb1c15349"), "ARM Digital Financial Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3704), null, "Ina.Alogwu@arm.com.ng", false, null, null, "Ina Alogwu", "Digital Financial Services", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("5ad9a543-3920-46b1-8829-7c786f6e2410"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3808), null, "kareem.bashir@arm.com.ng", false, null, null, "Kareem Bashir", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("63ba6a4b-37dd-4d78-a76c-064a1a9a6e9b"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3773), null, "itunu.olatunde-folaji@arm.com.ng", false, null, null, "Itunu Olatunde-Folaji", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("69341120-467e-44ff-b0bc-6b0528658ec3"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3758), null, "moyosore.taiwo@arm.com.ng", false, null, null, "Moyosore Taiwo", "Research", new Guid("a6409616-e559-4ff8-a877-0925be18ff3d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("72aae660-16bd-4baf-b5af-6823d59bcf1e"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3805), null, "gbenga.sonubi@arm.com.ng", false, null, null, "Gbenga Sonubi", "Operations,Financial Control", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("74c29ab0-d228-4c60-974a-937525f99cb4"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3747), null, "doyinsola.ola@arm.com.ng", false, null, null, "Doyinsola Ola", "WRM (Lagos)", new Guid("500fc670-2f14-4786-9092-f7f82b8ae507"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("75213f8b-5c95-4058-a99a-04b7b9a6d8b4"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3749), null, "rasheed.adebola@arm.com.ng", false, null, null, "Rasheed Adebola", "WRM (Lagos)", new Guid("500fc670-2f14-4786-9092-f7f82b8ae507"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("776d5b43-5c1c-4d8b-82bd-cd08b19ee65e"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3659), null, "Ethan.Okwara@arm.com.ng", false, null, null, "Ethan Okwara", "Marketing and Corporate Communications", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("78a45928-2479-497b-b464-ba8200c0b79f"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3841), null, "olugbenga.ajigbotafe@arm.com.ng", false, null, null, "Olugbenga Ajigbotafe", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("7b743dde-efc3-44d1-8e23-4efe18ce5902"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3809), null, "patrick.ayele@arm.com.ng", false, null, null, "Patrick Ayele", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("7ba537fc-4901-45f7-9949-4e5455968eb1"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3714), null, "olugbenga.ajigbotafe@arm.com.ng", false, null, null, "Olugbenga Ajigbotafe", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("7c7c5bf2-f35e-4f4e-8197-7bf1c90513c3"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3674), null, "Eddy.Ayikimi@arm.com.ng", false, null, null, "Eddy Ayikimi", "Customer Experience", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("7e305198-2f0e-44c2-8b49-a43f54c4a69a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3642), null, "Nehizena.Ibhawoh@arm.com.ng", false, null, null, "Nehizena Ibhawoh", "Legal", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("809a99cd-5ed3-4f9d-9b83-75e523511176"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3648), null, "james.ewah@arm.com.ng", false, null, null, "James Ewah", "WRM (Abuja)", new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("8120ab53-21fd-4fe3-8a8a-7d02d5f7a08b"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3661), null, "ubi.torsam@arm.com.ng", false, null, null, "Ubi Torsam", "Marketing and Corporate Communications", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("82680ebb-6dc0-4b47-8ace-f862423500fb"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3851), null, "augustine.chukwu@arm.com.ng", false, null, null, "Augustine Chukwu", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("83f375c4-71ef-4202-888c-2be5e047f258"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3837), null, "evelyn.nwogu@arm.com.ng", false, null, null, "Evelyn Nwogu", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("873de00f-3bc7-4588-923b-2a745b78ce12"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3766), null, "oladupe.oshinuga@arm.com.ng", false, null, null, "Oladupe Oshinuga", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("8f48ab4d-83b3-46f9-aba4-3e6122e63f3e"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3727), null, "Rotimi.Olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("92174a6c-c484-48ad-bade-0f5a552c0f48"), "ARM Harith Infracstrure Investement Limited", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3760), null, "tariye.gbadegesin@arm.com.ng", false, null, null, "Tariye Gbadegesin", "ARM Harith Infrastructure Investment Ltd", new Guid("44fe054d-83dd-41da-b90a-a53631af453d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("97601f31-81e5-4292-a706-c49d7511fecf"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3647), null, "Ediagbonya.Osayomwanbo@arm.com.ng", false, null, null, "Ediagbonya Osayomwanbo", "WRM (Abuja)", new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("97785247-d2ba-4da7-863e-7e426605e1dd"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3778), null, "faith.sani@arm.com.ng", false, null, null, "Faith Sani", "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("9919e073-56da-4565-8448-142dfafe1778"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3791), null, "philip.aikinomiora @arm.com.ng", false, null, null, "Philip Aikinomiora", "Corporate Strategy", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("9b77fc7c-8e5c-48ec-8759-8f053ff5ffbb"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3664), null, "ndubuisi.anya@arm.com.ng", false, null, null, "Ndubuisi Anya", "WRM (PortHarcourt)", new Guid("80245081-74bc-4124-87f5-d6008b28706b"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("9cf25244-915d-41fe-a9e7-d4c7d66d7bd1"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3739), null, "Dare.Shobajo@arm.com.ng", false, null, null, "Dare Shobajo", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("9ef3ee3f-3be5-4589-9fba-7de6bed53b07"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3793), null, "gbeminiyi.onipede@arm.com.ng", false, null, null, "Gbeminiyi Onipede", "HoldCo Sales", new Guid("772f854e-c9f6-4428-bad1-53db881e28bb"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("a510cf36-2722-41de-88f2-ba94a2a7b690"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3848), null, "faith.sani@arm.com.ng", false, null, null, "Faith Sani", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("a6e2f856-eff4-4668-9965-abc8dc3511e9"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3744), null, "rotimi.olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("aad263b0-60a4-454f-928e-7479592f00ba"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3680), null, "Adeleye.Adewusi@arm.com.ng", false, null, null, "Adeleye Adewusi", "ARM Academy", new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("ab3197b4-795e-4095-aca5-98d33cb1b215"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3771), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("ae2f806d-9f3a-4e5b-b015-af79531cd436"), "ARM Agricbusiness Fund Manager Ltd", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3669), null, "david.akinboade@arm.com.ng", false, null, null, "David Akinboade", "RFL", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("aff48248-6803-43df-b7f4-526badfdb28f"), "ARM Agricbusiness Fund Manager Ltd", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3667), null, "Hassan.AdeObafemi@arm.com.ng", false, null, null, "Hassan AdeObafemi", "RFL", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("b2e782c2-a01f-496a-8b7a-52286eb60280"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3702), null, "raymond.akorah@arm.com.ng", false, null, null, "Raymond Akorah", "ARM Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("b2e91786-48ec-4bf6-af79-880feaf02ccc"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3798), null, "opeyemi.oshinyemi@arm.com.ng", false, null, null, "Opeyemi Oshinyemi", "Operations Control", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("b3d3e7cc-1ab2-4831-8a33-fd8827402bcd"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3840), null, "babatunde.osho@arm.com.ng", false, null, null, "Babatunde Osho", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("b5e97b9f-65b0-4b83-86d4-f94d5bda6f66"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3634), null, "chukwuebuka.obieri@arm.com.ng", false, null, null, "Chukwuebuka Obieri", "Risk management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("b78d486a-b35b-4848-b2fb-fa7f24a506d7"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3786), null, "raphael.emenyonu@arm.com.ng", false, null, null, "Raphael Emenyonu", "Retail Sales", new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("b9cf3a50-1385-402b-becb-405c01e6903d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3754), null, "lincoln.ogigai@arm.com.ng", false, null, null, "Lincoln Ogigai", "Compliance", new Guid("a470f202-ca90-4fc9-8617-358311885a1c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("ba231dc2-0a5f-4058-8776-cec2f13fd4fe"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3732), null, "Olaoluwa.Omolayole@arm.com.ng", false, null, null, "Olaoluwa Omolayole", "Corporate Transformation", new Guid("850b308d-bef3-41ad-b812-413b868e7621"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("c00507b3-7e06-441c-ad88-13d9bb4fa351"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3806), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("c050340c-65bd-44a5-8575-bf9517f4831d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3854), null, "kiadum.nwakoh@arm.com.ng", false, null, null, "Kiadum Nwakoh", "Legal and Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("c160021d-1301-486f-997d-176944db9921"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3700), null, "Isaac.Elakhe@arm.com.ng", false, null, null, "Isaac Elakhe", "ARM Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("c3682106-1c49-4714-bf31-977b6a9b10cd"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3752), null, "oluyemi.omodayo@arm.com.ng", false, null, null, "Oluyemi Omodayo", "Compliance", new Guid("a470f202-ca90-4fc9-8617-358311885a1c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("c89a7ba3-3862-4a06-a252-874283671aa2"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3717), null, "Oluwabunmi.Abiodun-Wright@arm.com.ng", false, null, null, "Oluwabunmi Abiodun-Wright", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("cc46e6c5-40f8-48a8-8e5a-86c8bd81c15c"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3756), null, "rotimi.olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Research", new Guid("a6409616-e559-4ff8-a877-0925be18ff3d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("cc7c9577-414e-494c-b505-ad963d33b1f3"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3832), null, "ramond.akorah@arm.com.ng", false, null, null, "Ramond Akorah", "Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("d2fe7644-373e-4186-a452-4b3cc38406e0"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3639), null, "iwasam.elemi@arm.com.ng", false, null, null, "Iwasam Elemi", "Risk management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("d686961a-fdd3-4fc1-930f-1d1adb1d8825"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3731), null, "Carol.Ariyibi@arm.com.ng", false, null, null, "Carol Ariyibi", "Corporate Transformation", new Guid("850b308d-bef3-41ad-b812-413b868e7621"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("d68d39a1-cede-42a1-8940-3282c8c60abe"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3830), null, "lincoln.ogigai@arm.com.ng", false, null, null, "Lincoln Ogigai", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("d9a1aac8-a0e1-4259-9674-c5133d77a3e7"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3729), null, "vwede.edah@arm.com.ng", false, null, null, "Vwede Edah", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("dafbf93a-f2aa-4c81-8607-5ea5ae433c57"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3737), null, "moradeke.odugbesan@arm.com.ng", false, null, null, "Moradeke Odugbesan", "Procurement and Administration", new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("e0e94926-7633-45a1-b35a-0ce3f8bd9c44"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3788), null, "hamed.omotayo@arm.com.ng", false, null, null, "Hamed Omotayo", "Retail Sales", new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("e1ae66f0-9468-41cc-b6b2-c9094b3164ee"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3691), null, "nnamdi.okeke@arm.com.ng", false, null, null, "Nnamdi Okeke", "ARM Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("e66aef98-fa19-4a7b-968e-10ba5ea347ff"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3716), null, "joy.oyekan@arm.com.ng", false, null, null, "Joy Oyekan", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("e6eece0a-be86-4ec4-8ba6-2b5ad16c612f"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3819), null, "elizabeth.alloy@arm.com.ng", false, null, null, "Elizabeth Alloy", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("eaeca829-d6de-4670-a7ab-5ea14a2cf061"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3775), null, "tosin.adesope@arm.com.ng", false, null, null, "Tosin Adesope", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("ecd8d4c4-997a-4dda-aa5e-4947b8111e83"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3834), null, "oluwatosin.afolayan@arm.com.ng", false, null, null, "Oluwatosin Afolayan", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("ecdf2829-42f5-4be4-a390-d5348c2b5b49"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3741), null, "moshood.hassan@arm.com.ng", false, null, null, "Moshood Hassan", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("f1d95d98-06ab-44d4-aac4-8e7b420421ca"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3643), null, "olabisi.adesina@arm.com.ng", false, null, null, "Olabisi Adesina", "Legal", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("f2e74168-3da5-4e4a-85a7-20290e5d7612"), "ARM Harith Infracstrure Investement Limited", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3762), null, "oyedele.oyinbojuni@armharith.com", false, null, null, "Oyedele Oyinbojuni", "ARM Harith Infrastructure Investment Ltd", new Guid("44fe054d-83dd-41da-b90a-a53631af453d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("f375b872-bf3a-4d74-b65a-f1cb35b24511"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3689), null, "Oluwaferanmi.Olorunleke@arm.com.ng", false, null, null, "Seun idowu", "ARM Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("f792624d-f54c-40e2-830b-c4e05e6eb6f0"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3770), null, "adetayo.adebiyi@arm.com.ng", false, null, null, "Adetayo Adebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("f7f35bfd-2201-4f32-b81d-b6d14ebee335"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3781), null, "mounir.bouba@arm.com.ng", false, null, null, "Mounir Bouba", "Investment Managment", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("f926356f-abb9-4830-b658-7a9ccfd11a5f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3686), null, "Aminat.Ashafa@arm.com.ng", false, null, null, "Aminat Ashafa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("ff5979d6-f48c-42d2-8561-2b0c4675c93e"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 979, DateTimeKind.Utc).AddTicks(3855), null, "nehizena.ibhawoh@arm.com.ng", false, null, null, "Nehizena Ibhawoh", "Legal and Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") }
                });
        }
    }
}
