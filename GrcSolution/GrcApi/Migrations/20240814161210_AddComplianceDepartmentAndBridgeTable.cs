using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddComplianceDepartmentAndBridgeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComplianceDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceBusinessDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplianceBusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplianceDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceBusinessDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceBusinessDepartment_ComplianceBusines_ComplianceBusinessId",
                        column: x => x.ComplianceBusinessId,
                        principalTable: "ComplianceBusines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplianceBusinessDepartment_ComplianceDepartment_ComplianceDepartmentId",
                        column: x => x.ComplianceDepartmentId,
                        principalTable: "ComplianceDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComplianceDepartment",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("022aa7d5-7c0a-4fb3-9c8d-ff2278b289fa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3112), null, false, null, null, "Port Harcourt" },
                    { new Guid("037b9ff2-504e-404f-b329-8dffcc2c5e94"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3075), null, false, null, null, "Compliance" },
                    { new Guid("040acaf6-ccdc-4302-bae9-95bbe7175fa7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3121), null, false, null, null, "RFL" },
                    { new Guid("0b760d1e-9eb3-4758-93d8-beade293f5d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3083), null, false, null, null, "Facility Management" },
                    { new Guid("113da9be-b174-48a0-98cf-7573f8f344f7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3076), null, false, null, null, "Coporate Transformation" },
                    { new Guid("193306a0-16ce-4c4b-99a1-8765a8032cac"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3130), null, false, null, null, "Wealth & Relationship Management -Abuja" },
                    { new Guid("199f9de0-d08b-47eb-a96a-5b2526eb31ee"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3111), null, false, null, null, "Platform 30" },
                    { new Guid("1ac36092-da7b-4b32-bdac-a97fc23164cf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3100), null, false, null, null, "Mixta Nigeria Sales" },
                    { new Guid("1b5cbd9d-3a11-4ae2-8350-f208d37bcbb5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3095), null, false, null, null, "Investment Management" },
                    { new Guid("1c2370db-3244-4bf2-9b56-57d98bb3b5e7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3094), null, false, null, null, "Internal Control" },
                    { new Guid("1e534470-a920-457d-b5d3-ca8882de81ff"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3093), null, false, null, null, "Internal Audit" },
                    { new Guid("2f10b305-b9da-4801-9188-133c042b276a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3067), null, false, null, null, "ARM Agric Fund" },
                    { new Guid("2fd39529-b005-4293-8b8f-12ed3ff87807"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3116), null, false, null, null, "Proprietary and Principal Transactions" },
                    { new Guid("30c73a8b-1b74-4732-802d-e97b7ea2a404"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3074), null, false, null, null, "Commercial Trust" },
                    { new Guid("3d7857e6-8875-477f-a962-247326e2c92d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3090), null, false, null, null, "Human Capital Management" },
                    { new Guid("3ddc0333-f27a-4ced-9599-6ef1ee92c3c0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3113), null, false, null, null, "Private Trust" },
                    { new Guid("4108d577-9409-498b-9822-bbdd9f9b1e6c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3079), null, false, null, null, "Customer Service" },
                    { new Guid("413c704d-af7b-4b17-bd98-9eea7b16ff03"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3096), null, false, null, null, "Lagos" },
                    { new Guid("469e97db-72af-49ed-84dd-c11d425263cb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3072), null, false, null, null, "Call Centre" },
                    { new Guid("48cc7b70-9efa-4125-b448-6a957d2041f5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3084), null, false, null, null, "Farapark" },
                    { new Guid("4c9b0a56-52dc-4b33-af2b-5c999308a0ae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3063), null, false, null, null, "Adiva" },
                    { new Guid("4e7f8112-d6bf-4619-b41e-236fba1eb541"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3101), null, false, null, null, "Oakland Limited" },
                    { new Guid("4f52f84c-20cf-459e-8c9c-48d7072f30c5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3064), null, false, null, null, "Administration" },
                    { new Guid("4fae7da7-6ddd-48d0-9400-1126815fb4d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3092), null, false, null, null, "Institutional" },
                    { new Guid("51c62493-240a-4122-8ac8-ee1fe16e3ee2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3084), null, false, null, null, "Financial Control" },
                    { new Guid("5203f4dc-ab02-4dc8-85b1-b293ff9ffcbf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3125), null, false, null, null, "Technical / Projects" },
                    { new Guid("55772580-4c93-435d-8c31-685b80b9bd3f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3119), null, false, null, null, "Registrars" },
                    { new Guid("581ed77e-2e05-42fd-8b92-d001a96909a5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3080), null, false, null, null, "Design" },
                    { new Guid("58662c2e-5a9c-43f8-8d42-fc2e93a50eb4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3120), null, false, null, null, "Retail Operations" },
                    { new Guid("5e885e75-f8b3-4b3a-9017-b2e7a1122d83"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3115), null, false, null, null, "Project Management Office" },
                    { new Guid("6d071e04-9a34-4c6b-aaa0-ef9f11470990"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3097), null, false, null, null, "Legal" },
                    { new Guid("7165d5c6-dc08-4471-99b9-4c60dd76ec8d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3117), null, false, null, null, "RDP" },
                    { new Guid("732911ea-38e8-4104-a9c9-8101c7ec2748"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3081), null, false, null, null, "Digital Financial Services" },
                    { new Guid("766dfecd-8db0-4cc4-981e-43ae1f9f9265"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3071), null, false, null, null, "Beechwood" },
                    { new Guid("7cc52d32-76d1-4537-b418-7418d09f28f9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3082), null, false, null, null, "Enclave" },
                    { new Guid("80921fb2-5762-4149-98a1-7a990efb2428"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3126), null, false, null, null, "Trading / Bokerage" },
                    { new Guid("82355662-28d3-45c9-bbf4-51be40c368d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3126), null, false, null, null, "Townsville" },
                    { new Guid("86b47b0a-c3e1-45b6-97ef-5dead8955745"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3078), null, false, null, null, "Crosstown Iju" },
                    { new Guid("8acebf76-21e6-4e74-9f8c-b0d1db9f3753"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3085), null, false, null, null, "Fund Account" },
                    { new Guid("8ef60bcb-a795-4141-bab6-38e5863e14a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3098), null, false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("8f9dfe1b-0ca1-4722-b2a1-09609ee3bb0a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3066), null, false, null, null, "ARM Academy" },
                    { new Guid("93427ce2-6640-44ed-a078-320ac73e4dc2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3109), null, false, null, null, "ODA" },
                    { new Guid("9443293c-a893-41de-8317-264444c8bbc2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3060), null, false, null, null, "Abuja" },
                    { new Guid("9686c1aa-690e-4efb-a6f0-e48c838ec238"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3070), null, false, null, null, "ARM Harith Investment Ltd" },
                    { new Guid("97c9b380-ad8f-4f41-944b-dc37b82fe85f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3114), null, false, null, null, "Procurement and Contracting" },
                    { new Guid("9ae1d479-e587-4d46-95ba-b8e72851fc75"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3110), null, false, null, null, "Operation Controls" },
                    { new Guid("9cb7a2c2-4d91-47c1-9c6f-17540afa0c44"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3132), null, false, null, null, "Wealth & Relationship Management -Port Harcourt" },
                    { new Guid("9d10fb74-ed81-42ec-a109-072ca0ddfde3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3123), null, false, null, null, "Securities Operations " },
                    { new Guid("9e94023e-ce76-490c-8f1f-e46f4117b1a3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3096), null, false, null, null, "Lakowe Lakes Golf Club Ltd" },
                    { new Guid("a50412b5-65ff-4002-8da4-a45c5bf4bf2a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3089), null, false, null, null, "Hospitality and Retail Management" },
                    { new Guid("a66bea4e-f461-476f-9af7-61a91c69af99"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3118), null, false, null, null, "Real Estate" },
                    { new Guid("a8e77619-5129-4a88-b234-386f64840215"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3073), null, false, null, null, "Co.Sec" },
                    { new Guid("aa8efd00-7cc1-4fa6-b9e0-b24e06e8a0a5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3086), null, false, null, null, "Fund Admin" },
                    { new Guid("affceba9-38dc-4e5f-afb0-8b2d9edf5efa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3114), null, false, null, null, "Procurement and Administration" },
                    { new Guid("c08f04f7-5e1c-42f9-8247-cb902cd62f49"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3072), null, false, null, null, "Business Planning" },
                    { new Guid("c3de97f2-ef7c-40ad-94ef-f88738c71c07"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3099), null, false, null, null, "Mixta Nigeria Operations" },
                    { new Guid("ca9277c7-59d1-4f5f-adbf-bd036440e602"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3128), null, false, null, null, "TSD Ltd" },
                    { new Guid("d969cbf1-7f32-40bf-9e68-74f71a2d23d6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3068), null, false, null, null, "ARM Financial Advisers" },
                    { new Guid("da0bcbe0-9dad-4f4a-822f-3c0f9005cae8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3065), null, false, null, null, "Advisory" },
                    { new Guid("da9c707e-ff33-455b-973e-ff2928d41aca"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3127), null, false, null, null, "Treasury" },
                    { new Guid("dc1ab4ae-db59-420b-aade-49c9c0225b21"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3077), null, false, null, null, "Corporate Strategy" },
                    { new Guid("dd059d83-0706-425f-aa33-c8d32294f7b7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3120), null, false, null, null, "Research" },
                    { new Guid("dfc65214-67c8-47eb-aeeb-3146ae489e60"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3090), null, false, null, null, "Information Security" },
                    { new Guid("e98b0111-935c-41ba-bfed-00ae9ce3814f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3129), null, false, null, null, "Village" },
                    { new Guid("ebde322f-5df1-4af1-aeb8-870df4c58b3c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3069), null, false, null, null, "ARM Harith Infrastructure Investment Ltd" },
                    { new Guid("eefa7c57-98b1-44f8-aba7-549399321114"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3091), null, false, null, null, "Information Technology" },
                    { new Guid("f0748176-df02-49af-8565-520f9c59c9a0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3124), null, false, null, null, "Summerville / Lakowe" },
                    { new Guid("f155216a-9fc1-4d29-ac25-060c116d0e1e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3122), null, false, null, null, "Risk Management" },
                    { new Guid("f2b1a942-b22c-4c66-9929-513ba1867053"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3087), null, false, null, null, "Greater Port Harcour Golf Club" },
                    { new Guid("f8360ffe-e1be-4d14-99a8-db3a2e840f41"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3131), null, false, null, null, "Wealth & Relationship Management -Lagos" },
                    { new Guid("fad581c6-2f33-46de-b1c4-25d3873f23f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 14, 16, 12, 8, 973, DateTimeKind.Utc).AddTicks(3088), null, false, null, null, "HoldCo Sales" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceBusinessDepartment_ComplianceBusinessId",
                table: "ComplianceBusinessDepartment",
                column: "ComplianceBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceBusinessDepartment_ComplianceDepartmentId",
                table: "ComplianceBusinessDepartment",
                column: "ComplianceDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplianceBusinessDepartment");

            migrationBuilder.DropTable(
                name: "ComplianceDepartment");
        }
    }
}
