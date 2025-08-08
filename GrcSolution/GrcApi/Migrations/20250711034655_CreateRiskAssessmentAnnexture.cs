using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateRiskAssessmentAnnexture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annexture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annexture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfosecRiskAssessmentModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Objective = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AssetDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    RiskAssessmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfidentialityRating = table.Column<int>(type: "int", nullable: true),
                    IntegrityRating = table.Column<int>(type: "int", nullable: true),
                    AvailabilityRating = table.Column<int>(type: "int", nullable: true),
                    AssetValue = table.Column<int>(type: "int", nullable: false),
                    AssetScore = table.Column<int>(type: "int", nullable: true),
                    Vulnerability = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    VulnerabilityRating = table.Column<int>(type: "int", nullable: true),
                    Threat = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ImpactRating = table.Column<int>(type: "int", nullable: true),
                    LikehoodOfthreatOccuring = table.Column<int>(type: "int", nullable: true),
                    RiskScore = table.Column<int>(type: "int", nullable: false),
                    RiskValue = table.Column<int>(type: "int", nullable: false),
                    RiskOption = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControlEffectiveness = table.Column<int>(type: "int", maxLength: 2147483647, nullable: false),
                    ResidualRisk = table.Column<int>(type: "int", nullable: false),
                    Riskowner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReasonForRejection = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateApproved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ProposeClosureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemediationStatus = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfosecRiskAssessmentModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExistingPrimaryControl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InfosecRiskAssessmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistingPrimaryControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExistingPrimaryControl_InfosecRiskAssessmentModel_InfosecRiskAssessmentId",
                        column: x => x.InfosecRiskAssessmentId,
                        principalTable: "InfosecRiskAssessmentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedControl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InfosecRiskAssessmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedControl_InfosecRiskAssessmentModel_InfosecRiskAssessmentId",
                        column: x => x.InfosecRiskAssessmentId,
                        principalTable: "InfosecRiskAssessmentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExistingPrimaryControlAnnexture",
                columns: table => new
                {
                    ExistingPrimaryControlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnextureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistingPrimaryControlAnnexture", x => new { x.AnnextureId, x.ExistingPrimaryControlId });
                    table.ForeignKey(
                        name: "FK_ExistingPrimaryControlAnnexture_Annexture_AnnextureId",
                        column: x => x.AnnextureId,
                        principalTable: "Annexture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExistingPrimaryControlAnnexture_ExistingPrimaryControl_ExistingPrimaryControlId",
                        column: x => x.ExistingPrimaryControlId,
                        principalTable: "ExistingPrimaryControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedControlAnnexture",
                columns: table => new
                {
                    PlannedControlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnextureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedControlAnnexture", x => new { x.AnnextureId, x.PlannedControlId });
                    table.ForeignKey(
                        name: "FK_PlannedControlAnnexture_Annexture_AnnextureId",
                        column: x => x.AnnextureId,
                        principalTable: "Annexture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlannedControlAnnexture_PlannedControl_PlannedControlId",
                        column: x => x.PlannedControlId,
                        principalTable: "PlannedControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Annexture",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DateDeleted", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("031f02f1-12c7-4a3c-b778-f3e80e0a6168"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(175), null, null, false, null, null, "A.6.1 Screening" },
                    { new Guid("0365fade-3c4d-4e5e-85bf-a4e23cc249d1"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(92), null, null, false, null, null, "A.5.21 Managing Information Security in the ICT Supply Chain" },
                    { new Guid("0b9a3afb-c070-49aa-a0bd-59cf4cf7f5af"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(576), null, null, false, null, null, "A.8.28 Secure Coding" },
                    { new Guid("0c26b54f-b650-428f-b6c6-d6f62d82ae80"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(17), null, null, false, null, null, "A.5.2 Information Security Roles and Responsibilities" },
                    { new Guid("0efb757a-d37e-46e2-a1e3-e995500b0255"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(30), null, null, false, null, null, "A.5.6 Contact with Special Interest Groups" },
                    { new Guid("11e035b2-088e-4602-beb8-84cbd50a5142"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(595), null, null, false, null, null, "A.8.34 Protection of Information Systems during Audit Testing" },
                    { new Guid("13beb7a5-0a04-4320-b13c-814153c43060"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(326), null, null, false, null, null, "A.6.5 Responsibilities after Termination or Change of Employment" },
                    { new Guid("152d511d-f82e-4ae6-bc05-2fab7e568856"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(574), null, null, false, null, null, "A.8.27 Secure System Architecture and Engineering Principles" },
                    { new Guid("18a961fc-826e-435f-97e7-642f6975a317"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(158), null, null, false, null, null, "A.5.32 Intellectual Property Rights" },
                    { new Guid("197185f0-3071-4a92-bbe8-eb7efb69fdde"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(378), null, null, false, null, null, "A.7.14 Secure Disposal or Re-use of Equipment" },
                    { new Guid("1a22f98d-725d-44a3-a728-5c42a8c387df"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(108), null, null, false, null, null, "A.5.27 Learning from Information Security Incidents" },
                    { new Guid("22445818-ef3b-4ae6-aa17-42b39703502b"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(407), null, null, false, null, null, "A.8.11 Data Masking" },
                    { new Guid("23594615-35e3-44ce-8f15-a6d7e5354a87"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(101), null, null, false, null, null, "A.5.26 Response to Information Security Incidents" },
                    { new Guid("24de8a04-cb07-419b-b455-f3e3be4990b1"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(351), null, null, false, null, null, "A.7.5 Protecting Against Physical and Environmental Threats" },
                    { new Guid("2d1208b2-edfd-4742-87b3-6aa9de11531d"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(163), null, null, false, null, null, "A.5.34 Privacy and Protection of PII" },
                    { new Guid("2fd07e01-912d-4f6d-9a0e-60d529db65d6"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(586), null, null, false, null, null, "A.8.32 Change Management" },
                    { new Guid("30cfc72f-7377-400b-96e8-2494597e30ab"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(371), null, null, false, null, null, "A.7.12 Cabling Security" },
                    { new Guid("342f41af-3ac2-48d8-8981-cd1fb8426085"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(55), null, null, false, null, null, "A.5.15 Access Control" },
                    { new Guid("34b0e48a-d2bb-4521-841c-a888b5eead61"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(385), null, null, false, null, null, "A.8.3 Information Access Restriction" },
                    { new Guid("3bfa46d2-256a-4089-a0da-92836626653a"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(334), null, null, false, null, null, "A.6.7 Remote Working" },
                    { new Guid("3eb9f678-02df-4230-b57e-3bed61c6d4c2"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(571), null, null, false, null, null, "A.8.26 Application Security Requirements" },
                    { new Guid("3f2ec051-1aaf-45de-807f-e1fcb9a521cf"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(387), null, null, false, null, null, "A.8.4 Access to Source Code" },
                    { new Guid("3fbd8208-357a-406e-b06b-eb5e167c1c11"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(113), null, null, false, null, null, "A.5.29 Information Security during Disruption" },
                    { new Guid("440f05b0-7c7f-4e55-ad1a-3d5afb85be0f"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(324), null, null, false, null, null, "A.6.4 Disciplinary Process" },
                    { new Guid("5518d071-3f94-45aa-b5fe-b873fa145835"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(45), null, null, false, null, null, "A.5.11 Return of Assets" },
                    { new Guid("5586f93b-ab8c-4af8-aa08-2ab7e578a6a5"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(96), null, null, false, null, null, "A.5.24 Information Security Incident Management Planning and Preparation" },
                    { new Guid("5651fd80-618b-4707-9a31-25dbe2700e22"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(115), null, null, false, null, null, "A.5.30 ICT Readiness for Business Continuity" },
                    { new Guid("592aec8e-070c-4646-8974-33866e4e0221"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(443), null, null, false, null, null, "A.8.25 Secure Development Life Cycle" },
                    { new Guid("5c34e4cb-19a7-4a6e-9d37-f1ee65f5a710"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(21), null, null, false, null, null, "A.5.3 Segregation of Duties" },
                    { new Guid("5d71e6f1-cb9f-40d5-97b6-9a4ba0a7c255"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(37), null, null, false, null, null, "A.5.9 Inventory of Information and Other Associated Assets" },
                    { new Guid("5df02208-099c-4916-b0c4-adc8870725ca"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(438), null, null, false, null, null, "A.8.23 Web Filtering" },
                    { new Guid("5e6a0550-8440-4a8e-af9d-8ebaeef7befe"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(427), null, null, false, null, null, "A.8.18 Use of Privileged Utility Programs" },
                    { new Guid("60e73b34-b4e5-4c40-bd19-a9d70fb86bc2"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(409), null, null, false, null, null, "A.8.12 Data Leakage Prevention" },
                    { new Guid("62f637bf-01be-4b55-b6de-447d6579b16b"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(332), null, null, false, null, null, "A.6.6 Confidentiality or Non-disclosure Agreements" },
                    { new Guid("631c7930-0f74-41a9-b609-6c23acdc5e18"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(422), null, null, false, null, null, "A.8.16 Monitoring Activities" },
                    { new Guid("647fff81-e207-49b4-b2a3-a577803af7e6"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(368), null, null, false, null, null, "A.7.11 Supporting Utilities" },
                    { new Guid("67c69b44-7ef6-46c4-990a-716a479441a3"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(35), null, null, false, null, null, "A.5.8 Information Security in Project Management" },
                    { new Guid("72765e26-2f71-401d-b459-95a5d4c0011c"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(170), null, null, false, null, null, "A.5.36 Compliance with Policies, Rules, and Standards for Information Security" },
                    { new Guid("74d88139-6018-45dc-902c-abab66797e14"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(61), null, null, false, null, null, "A.5.17 Authentication Information" },
                    { new Guid("7ba55426-ab74-42b8-bbd9-7af8d76bb55f"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(405), null, null, false, null, null, "A.8.10 Information Deletion" },
                    { new Guid("7d243537-ff5e-4eed-99b4-1e510bb9a17b"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(110), null, null, false, null, null, "A.5.28 Collection of Evidence" },
                    { new Guid("8062c03b-d329-48fa-910f-0c89823e4aac"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(58), null, null, false, null, null, "A.5.16 Identity Management" },
                    { new Guid("8078b936-021d-4a76-b706-8e1cd46dd4e1"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(394), null, null, false, null, null, "A.8.7 Protection Against Malware" },
                    { new Guid("81d5ccc7-3b5e-4e6f-8233-47a6e89f933b"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(27), null, null, false, null, null, "A.5.5 Contact with Authorities" },
                    { new Guid("87fa2237-ef81-4ebc-9eea-4bb9b780e059"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(584), null, null, false, null, null, "A.8.31 Separation of Development, Test, and Production Environments" },
                    { new Guid("8e56bdd4-20c9-4fce-bfb0-6e4f5ea5e438"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(344), null, null, false, null, null, "A.7.2 Physical Entry" },
                    { new Guid("8fd5eec3-a904-42ab-adac-a6b8f51d9f05"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(380), null, null, false, null, null, "A.8.1 User Endpoint Devices" },
                    { new Guid("9130c0b2-5654-49b5-86b1-e1c9c635e53f"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(173), null, null, false, null, null, "A.5.37 Documented Operating Procedures" },
                    { new Guid("91af5609-eeac-44b8-97d9-c9c169c2ccfa"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(348), null, null, false, null, null, "A.7.4 Physical Security Monitoring" },
                    { new Guid("9fa14c05-dc41-477b-afca-84520caaf2a9"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(339), null, null, false, null, null, "A.7.1 Physical Security Perimeters" },
                    { new Guid("a0398302-909b-4f2e-86d9-a87fab47c232"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(32), null, null, false, null, null, "A.5.7 Threat Intelligence" },
                    { new Guid("a1225816-8d4c-423d-b09e-837d471086e4"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(593), null, null, false, null, null, "A.8.33 Test Information" },
                    { new Guid("a21b993c-546a-40ea-a6fe-27fb722d5446"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(389), null, null, false, null, null, "A.8.5 Secure Authentication" },
                    { new Guid("a2f90c6e-e710-4740-adae-4e2f980a308a"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(399), null, null, false, null, null, "A.8.8 Management of Technical Vulnerabilities" },
                    { new Guid("a3d07ed3-2622-4310-9685-a6dae9755759"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(99), null, null, false, null, null, "A.5.25 Assessment and Decision on Information Security Events" },
                    { new Guid("a4086ebc-44e7-48ce-83c3-c8633fe84346"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(373), null, null, false, null, null, "A.7.13 Equipment Maintenance" },
                    { new Guid("aa9aa89a-0f17-43c6-a841-ffa783ce58c8"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(383), null, null, false, null, null, "A.8.2 Privileged Access Rights" },
                    { new Guid("ab878cdc-0a61-4815-90f9-dc7844d1935a"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(424), null, null, false, null, null, "A.8.17 Clock Synchronization" },
                    { new Guid("abdba944-bc56-4bb3-b780-5f0be5ab50bf"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(433), null, null, false, null, null, "A.8.21 Security of Network Services" },
                    { new Guid("ac45486e-8579-468f-9fbb-24daa710db3c"), null, new DateTime(2025, 7, 11, 4, 46, 50, 826, DateTimeKind.Local).AddTicks(9977), null, null, false, null, null, "A.5.1 Policies for Information Security" },
                    { new Guid("ad82bbee-2e64-4e90-833e-0c19cedc0528"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(148), null, null, false, null, null, "A.5.31 Legal, Statutory, Regulatory, and Contractual Requirements" },
                    { new Guid("aee25f20-2267-4eb1-bcac-4d9ebc3764e0"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(436), null, null, false, null, null, "A.8.22 Segregation of Networks" },
                    { new Guid("b02c6548-62f9-4c4e-a80c-e5b14c2950cd"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(73), null, null, false, null, null, "A.5.18 Access Rights" },
                    { new Guid("b0b58706-b882-4afd-90a6-4e50050ce6ac"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(414), null, null, false, null, null, "A.8.14 Redundancy of Information Processing Facilities" },
                    { new Guid("b0b76105-a212-4fe3-8a17-8bf9f6ce54ea"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(48), null, null, false, null, null, "A.5.12 Classification of Information" },
                    { new Guid("b68a412e-0f52-4fb9-b6b0-52a34471cba8"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(346), null, null, false, null, null, "A.7.3 Securing Offices, Rooms, and Facilities" },
                    { new Guid("b71927b2-e397-4cd0-a5eb-7e95036e152f"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(24), null, null, false, null, null, "A.5.4 Management Responsibilities" },
                    { new Guid("bafef079-1a53-46af-b955-3e8b77a0569f"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(89), null, null, false, null, null, "A.5.20 Addressing Information Security within Supplier Agreements" },
                    { new Guid("c12f9698-cdde-40ad-a114-df0c70fc39b9"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(53), null, null, false, null, null, "A.5.14 Information Transfer" },
                    { new Guid("c30eec80-8844-4364-bcb8-57065459ccd5"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(318), null, null, false, null, null, "A.6.2 Terms and Conditions of Employment" },
                    { new Guid("c38f4b0d-8f41-4e92-aa98-6a84dd1d2251"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(363), null, null, false, null, null, "A.7.9 Security of Assets Off-Premises" },
                    { new Guid("c3a6c745-bec9-4b52-8c37-6c1c2196d9fb"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(429), null, null, false, null, null, "A.8.19 Installation of Software on Operational Systems" },
                    { new Guid("c442387d-36a6-4227-b17b-e229912c2a79"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(86), null, null, false, null, null, "A.5.19 Information Security in Supplier Relationships" },
                    { new Guid("c487c724-041e-4c8a-92b0-7fae9b744afc"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(579), null, null, false, null, null, "A.8.29 Security Testing in Development and Acceptance" },
                    { new Guid("c62df7de-cc2d-4c1a-a61c-d9964d0ce9f4"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(161), null, null, false, null, null, "A.5.33 Protection of Records" },
                    { new Guid("cb4e42a6-c4fc-4c37-a6f8-959c47034d2b"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(50), null, null, false, null, null, "A.5.13 Labelling of Information" },
                    { new Guid("cc1092d4-8f57-468d-89f7-7179216cad94"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(392), null, null, false, null, null, "A.8.6 Capacity Management" },
                    { new Guid("d0d0b293-09a2-4ccf-bcbf-9bde376b8067"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(94), null, null, false, null, null, "A.5.22 Monitoring, Review, and Change Management of Supplier Services" },
                    { new Guid("d56c6d2a-22d9-4d67-b343-1eb067aa0efc"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(401), null, null, false, null, null, "A.8.9 Configuration Management" },
                    { new Guid("d5750f4c-ad57-49ab-8c2f-0d66e597f831"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(168), null, null, false, null, null, "A.5.35 Independent Review of Information Security" },
                    { new Guid("d77e0731-e007-4c62-a3ed-a748b06b328e"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(361), null, null, false, null, null, "A.7.8 Equipment Siting and Protection" },
                    { new Guid("d9eecaeb-879b-4bef-8a97-87a54573a2cf"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(581), null, null, false, null, null, "A.8.30 Outsourced Development" },
                    { new Guid("e02e3770-8207-48d5-afeb-81fcee41f8ee"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(412), null, null, false, null, null, "A.8.13 Information Backup" },
                    { new Guid("e11dfe71-1b18-41ec-95b2-ffe1258b369b"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(359), null, null, false, null, null, "A.7.7 Clear Desk and Clear Screen" },
                    { new Guid("e53917d5-f5a2-4623-aff2-79828197d43c"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(356), null, null, false, null, null, "A.7.6 Working in Secure Areas" },
                    { new Guid("e53ca697-dba5-4c5d-913f-fe5a987d57f3"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(366), null, null, false, null, null, "A.7.10 Storage Media" },
                    { new Guid("eccea2eb-cfd2-4486-b045-5d0ed5069b4c"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(417), null, null, false, null, null, "A.8.15 Logging" },
                    { new Guid("edb9018b-b2ec-4d1f-aafd-178ff76a19e9"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(43), null, null, false, null, null, "A.5.10 Acceptable Use of Information and Other Associated Assets" },
                    { new Guid("f5b9d0d2-39f3-4009-9228-db2f674a1c55"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(337), null, null, false, null, null, "A.6.8 Information Security Event Reporting" },
                    { new Guid("f8a2ce43-ec8e-4f30-a732-b313ae441940"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(431), null, null, false, null, null, "A.8.20 Network Security" },
                    { new Guid("fa79fc03-3f54-4686-b8cd-e352f9eb0391"), null, new DateTime(2025, 7, 11, 4, 46, 50, 827, DateTimeKind.Local).AddTicks(321), null, null, false, null, null, "A.6.3 Information Security Awareness, Education, and Training" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annexture_Name",
                table: "Annexture",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExistingPrimaryControl_InfosecRiskAssessmentId",
                table: "ExistingPrimaryControl",
                column: "InfosecRiskAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistingPrimaryControlAnnexture_ExistingPrimaryControlId",
                table: "ExistingPrimaryControlAnnexture",
                column: "ExistingPrimaryControlId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedControl_InfosecRiskAssessmentId",
                table: "PlannedControl",
                column: "InfosecRiskAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedControlAnnexture_PlannedControlId",
                table: "PlannedControlAnnexture",
                column: "PlannedControlId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistingPrimaryControlAnnexture");

            migrationBuilder.DropTable(
                name: "PlannedControlAnnexture");

            migrationBuilder.DropTable(
                name: "ExistingPrimaryControl");

            migrationBuilder.DropTable(
                name: "Annexture");

            migrationBuilder.DropTable(
                name: "PlannedControl");

            migrationBuilder.DropTable(
                name: "InfosecRiskAssessmentModel");
        }
    }
}
