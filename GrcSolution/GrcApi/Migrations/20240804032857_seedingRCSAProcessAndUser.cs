using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class seedingRCSAProcessAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RSCAProcess",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "UnitId" },
                values: new object[,]
                {
                    { new Guid("00744227-3e11-47a8-83fa-57f00c7d1d66"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8118), null, false, null, null, "Memo for Transfer of fund across Bank", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("0099098a-ffbc-49fd-9e6c-7ead1552b3d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7974), null, false, null, null, "Investigation", new Guid("389e0846-2dfd-4e66-91c7-b7c37a565c70") },
                    { new Guid("00c6ea1a-2a34-41e2-966a-cbd4e71a023f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8513), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("a470f202-ca90-4fc9-8617-358311885a1c") },
                    { new Guid("00ea314c-41ce-4eee-887b-2ec3bff15ffc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7883), null, false, null, null, "Sanction Sceening on clients", new Guid("9085fd66-97e2-4f6f-91c1-84fa719168c7") },
                    { new Guid("02051c12-e364-49c1-adfb-6d7ac9761f6b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8366), null, false, null, null, "Business Continuity Management Tests", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("024336e2-fb7f-4502-9cc2-08eaa63b752d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7845), null, false, null, null, "Business strategy articulataion", new Guid("456575f1-a8db-4fd9-885f-8e84e096c860") },
                    { new Guid("0254e8ae-753f-4cf4-8adc-0783e177f310"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7870), null, false, null, null, "Drafting Embassy letters ", new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31") },
                    { new Guid("02b1096f-d321-43fc-990b-27005579ef3f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7982), null, false, null, null, "Mutual Fund Pricing Review", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("037124f1-5f7a-49f3-9eff-889f1004d6b6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8185), null, false, null, null, "Embassy Letter", new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13") },
                    { new Guid("039ab0f0-d67f-456f-985b-7bc8413e5443"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8108), null, false, null, null, "AMS automatch transactions with membership ID and integrates to NAV", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("03a6064c-ae46-4eee-bb40-25f303da025d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8598), null, false, null, null, "Trade call-over", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("03bfc427-71eb-4129-acc1-484a7d4fd851"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7878), null, false, null, null, "Account Opening", new Guid("9085fd66-97e2-4f6f-91c1-84fa719168c7") },
                    { new Guid("03c9fb2a-67b0-4698-a7f9-067d1a7662e2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8299), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("77635858-f888-45c8-9a6f-df2f5ac50670") },
                    { new Guid("03e2df38-86e7-4cee-bff7-5cf55bbd5e1a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8858), null, false, null, null, "Post Go Live Support", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8") },
                    { new Guid("04c45f33-0475-4aca-bcae-ccfd0d758d36"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8009), null, false, null, null, "Pledge Review and Approval", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("04d3d59d-60e8-4df9-9823-4facd7ab7faa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7938), null, false, null, null, "Sanction Screening", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("050b41b5-1620-4801-b758-80547018f6b7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7849), null, false, null, null, "Quarterly performance review session", new Guid("456575f1-a8db-4fd9-885f-8e84e096c860") },
                    { new Guid("053d7fd3-8062-461e-ab2b-f2fe1e346109"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8437), null, false, null, null, "Embassy Letter", new Guid("1df86816-2842-4941-8710-36822d6240e8") },
                    { new Guid("0554f57d-9286-4df6-804b-80e93cc364c0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7880), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("9085fd66-97e2-4f6f-91c1-84fa719168c7") },
                    { new Guid("055fb17f-4622-42cf-87c2-d398d3704220"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7767), null, false, null, null, "Root Cause Analysis", new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836") },
                    { new Guid("064f2e45-76d4-4a83-9023-b59b910e314c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8217), null, false, null, null, "Regulatory filings", new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11") },
                    { new Guid("075949cb-71e2-45bd-884f-9b3dc9801318"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8830), null, false, null, null, "Data Recovery Steps", new Guid("a5ab3b91-07f8-47d7-8ad7-3dfdbf005f8e") },
                    { new Guid("07932f05-03f0-4f5c-9c7a-15a22f43c9f7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8099), null, false, null, null, "Deactivation of Mobile Number Re-assigned to a Third Party", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("07dadc8a-a57c-4014-8058-568a9fe8b9d9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8799), null, false, null, null, "Standard Embassy Letter", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("080dd1e9-166b-453f-aaf5-f303fafc485f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8843), null, false, null, null, "Institutional Fund Pricing Review", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("08170cf7-b57e-48a1-94e8-e4314b2e7865"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8782), null, false, null, null, "Transfer of portfolio to another party (broker)/Portfolio stock withdrawal", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("0827cd66-de5f-46cb-993a-6f54ff9b21af"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7727), null, false, null, null, "BARC Reporting", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("082bfc03-0e70-4d2f-8faa-579999d253e4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8340), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d") },
                    { new Guid("084aaf3d-ae50-436f-bbdc-a5672ea53906"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8760), null, false, null, null, "Portfolio CSCS creation", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("08519af6-f5ed-42ee-9c6b-7d0ec9f11562"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8326), null, false, null, null, "Data Update", new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e") },
                    { new Guid("08569e24-6d6b-4efd-9b90-effe9184a120"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8842), null, false, null, null, "Mutual Fund Pricing Review", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("085b82ef-63d4-42db-882a-3fc6b8bfba16"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8469), null, false, null, null, "Corporate strategy development", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75") },
                    { new Guid("08eb6b13-84b2-4e7b-bb63-b0b296259b3e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8188), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13") },
                    { new Guid("08ffa2a5-1dc0-45ae-a66a-983eaf67438c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8415), null, false, null, null, "User Rights Access Mgt", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("09a55de7-5da8-4225-9d65-0cc2ee8f4360"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8810), null, false, null, null, "AMS automatch transactions with membership ID and integrates to NAV", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("09bd0017-3d32-44ac-b8f4-72b725ebfba8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8827), null, false, null, null, "Applications Development/Enhancement", new Guid("a5ab3b91-07f8-47d7-8ad7-3dfdbf005f8e") },
                    { new Guid("0a7a77d1-0118-4805-96a1-78748b6d95b3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8390), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe") },
                    { new Guid("0a85f5af-7786-41c5-b43e-ff9ee12cf0f2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8389), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe") },
                    { new Guid("0ad00baf-7502-4537-932d-ae08d9cabfcd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7868), null, false, null, null, "Root Cause Analysis", new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1") },
                    { new Guid("0ad923cb-881f-491d-80b6-3c6a4a2cee82"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8018), null, false, null, null, "Business strategy monitoring", new Guid("ac2f5e03-e11a-4f64-8439-6dee0012376b") },
                    { new Guid("0b8412ac-528e-46b4-abd5-fdcf68e5e96f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8324), null, false, null, null, "CSCS Reconciliation", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("0bcf1908-f9c2-4156-a63f-5791577c8614"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8121), null, false, null, null, "Daily Movement of posted subscriptions at Bank(Cash Sweep)", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("0c13213f-67b5-4a04-9eb1-1c4c1cc6fa0b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8203), null, false, null, null, "Strategy revision", new Guid("444a03bb-a3d4-4cec-a76c-eeabda66003a") },
                    { new Guid("0c460955-b9cc-48c0-8158-3e01b7c4f6f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8180), null, false, null, null, "Counterparty Review and Assessment", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("0c462248-5dd9-46a9-a638-67273ff2f86c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8692), null, false, null, null, "Filing of Regulatory Returns", new Guid("4221d035-01ed-4439-8829-d9b73f9e5a4b") },
                    { new Guid("0c56d458-78f9-42fd-9bbb-75e3a102c675"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8256), null, false, null, null, "Update of Instrument Information", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("0d0b5c02-74c5-4494-aec9-98fa9f0ee863"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7942), null, false, null, null, "Manual matching of inflow into clients account", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("0d0ce324-d68d-4a85-b650-4ec127bb5e2e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8213), null, false, null, null, "Report preparation", new Guid("444a03bb-a3d4-4cec-a76c-eeabda66003a") },
                    { new Guid("0d977394-a158-44ee-bfed-6b4dfcfff5af"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8537), null, false, null, null, "TALENT ACQUISITION AND ORGANIZATIONAL DEVELOPMENT", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("0d98e9d3-bbd4-45b9-8f1a-de82f2198153"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8793), null, false, null, null, "Redemption Processing - Verification (Mutual Fund)", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("0dd12c08-cce8-443d-aae1-4b444017a76f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8156), null, false, null, null, "Statutory Remittance Review", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("0e6865b8-4489-4c5e-88fb-4de3de79711f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8680), null, false, null, null, "Daily Teams Call Over", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("0ebcf81a-e994-4dcd-8c0a-9acebea05ae2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8391), null, false, null, null, "General secretarial activities", new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe") },
                    { new Guid("0f6ca9a2-b90d-474f-bcae-2548f9fbbfa2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8320), null, false, null, null, "User Rights Access Mgt", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("0f94f24e-7205-4a5d-b502-ec4a1e489163"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8089), null, false, null, null, "MMF Quarterly Dividend Reinvestment", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("1009e0b1-91ba-48f7-a7f0-0386c45fb227"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8305), null, false, null, null, "Audit Review", new Guid("d0b29a0f-69c0-42df-8af9-490ebc733c64") },
                    { new Guid("1099766a-6f11-46c9-8647-0932d2824b3b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8668), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("a77067b1-9217-4a5b-b16d-70e211f22c25") },
                    { new Guid("10d3f333-5951-4c39-ba20-e5ef35031574"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8493), null, false, null, null, "Daily Teams Call Over", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("10db66bf-ba9e-4e47-b75d-d96dcf873e37"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8696), null, false, null, null, "Sanction Sceening on clients", new Guid("4221d035-01ed-4439-8829-d9b73f9e5a4b") },
                    { new Guid("10e79d72-a078-4c5e-a192-2bad4d6b1051"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8015), null, false, null, null, "Business strategy articulataion", new Guid("ac2f5e03-e11a-4f64-8439-6dee0012376b") },
                    { new Guid("111a62fa-be84-4f5b-a1b7-1bf3d83b9813"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8659), null, false, null, null, "Business strategy monitoring", new Guid("6cfdabd5-52e6-465b-8cca-5b23aead61be") },
                    { new Guid("11bfd1b6-5037-4f6b-bfaf-70bb2e324baf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8325), null, false, null, null, "Mutual Funds Account Creation", new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e") },
                    { new Guid("11d510fc-b48d-4fa3-bc15-fc59164e2870"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8617), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879") },
                    { new Guid("11e7fca9-55df-4e95-b9e5-0b37a2c8a369"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8514), null, false, null, null, "Sanction Sceening on clients", new Guid("a470f202-ca90-4fc9-8617-358311885a1c") },
                    { new Guid("12385aed-bc67-414d-a64f-6e3df644cecf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8459), null, false, null, null, "Business Continuity Management Tests", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("12ba4ccb-a16b-4882-823c-6e1305889ac2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7928), null, false, null, null, "Standard Embassy Letter", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("133e4802-b36e-48f3-9900-a5e7db7a3ca3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8818), null, false, null, null, "Direct debit set up and Termination", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("140c2437-0e92-4661-bcf1-507c28033546"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8073), null, false, null, null, "Client creation and client mapping", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("14a07000-9f09-45cb-8650-6b7d167c1347"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8260), null, false, null, null, "Redemption Processing - Verification (Mutual Fund)", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("150a1b62-9604-4be0-9df5-fcee63e140bf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8247), null, false, null, null, "Unverified returned share certificates", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("1592ca9d-d57f-42ab-b180-825ad594797d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8829), null, false, null, null, "Data Backup", new Guid("a5ab3b91-07f8-47d7-8ad7-3dfdbf005f8e") },
                    { new Guid("15b801c9-2ce3-4751-8f8a-d86323cdbc8d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8270), null, false, null, null, "EOQ/Dividend Payment", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("15bf2886-94ff-442f-968f-08e6dea1b3da"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8137), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("52ae7cc8-1382-4c45-833a-84e78a2de191") },
                    { new Guid("15c558b7-a460-4932-b64c-93430333233c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8347), null, false, null, null, "MRC Reporting", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("15eb0e70-fbab-4685-a4a6-51fb2875efe7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8024), null, false, null, null, "Data Update", new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38") },
                    { new Guid("15ef9cb6-b6e4-43b1-9a8c-41d36f327327"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8853), null, false, null, null, "Agile Delivery Process", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8") },
                    { new Guid("16a14670-cbe1-474e-a539-9123dbc672ea"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8844), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("16b51a4c-6f35-4816-87fb-20ebd797c80d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8500), null, false, null, null, "Regulatory filings", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("178a2b24-5430-47ed-b361-7538f58865f3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8785), null, false, null, null, "Update of Instrument Information", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("17a7b1a5-6832-4f81-b3a3-b777e97870a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8478), null, false, null, null, "Investigation", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("17aaf7f2-4e39-49e4-8d6c-50028543c086"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7747), null, false, null, null, "Data Update", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("17b4b299-7b40-437a-9200-c6c5ec49c0bd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8393), null, false, null, null, "Filing of Regulatory Returns", new Guid("e4789074-ab43-463f-b18f-42606e28db63") },
                    { new Guid("185e9af2-1ddb-4d17-b1b6-f79f4c6bf991"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7914), null, false, null, null, "Portfolio stock reconciliation", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("1966fd76-d6a3-4af9-8038-780d645db22b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8600), null, false, null, null, "Institutional Fund Pricing Review", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("199353cb-44db-470a-8453-d6632e08cd43"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8364), null, false, null, null, "New Product Assessment", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("1a4178c9-a168-46c7-bba0-0bc69453229f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8473), null, false, null, null, "Quarterly performance review session", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75") },
                    { new Guid("1a67d798-91d6-4ad7-b2b3-084f7127af94"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8519), null, false, null, null, "CSR Evaluation & Sponsorshp Selection Process", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c") },
                    { new Guid("1a9b8afd-ceb8-40f5-b69b-91d4be7c159f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8711), null, false, null, null, "Counterparty Review and Assessment", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("1ab5a766-70aa-4b37-9818-6232723fc88e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8292), null, false, null, null, "Goal-related Transactions", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("1ac41df5-d575-4d59-8794-45e9aa0f4eb4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8159), null, false, null, null, "Trust Client Acquisition", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c") },
                    { new Guid("1b19a001-b2ab-44b5-817c-295aee769005"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7881), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("9085fd66-97e2-4f6f-91c1-84fa719168c7") },
                    { new Guid("1b39df01-48f3-456e-bef5-4a42f31c8016"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8419), null, false, null, null, "CSCS Reconciliation", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("1b6102a2-94c6-4b31-8ff4-fe8d8c850fe1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8608), null, false, null, null, "Daily Teams Call Over", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("1b954b49-70b9-4658-a9d1-299491b12be9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8802), null, false, null, null, "Unclaimed Dividend Payment", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("1bc338d5-79cf-4202-9d38-7b74c69ddaf2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8819), null, false, null, null, "Posting of Buybacks", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("1c49a64e-8056-4e5e-91cd-482bcb750c28"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8585), null, false, null, null, "Business strategy articulataion", new Guid("bba02c89-3bf2-4596-857c-54c4f86e9a27") },
                    { new Guid("1e1e783c-6e13-4a85-87e0-79984b7e3202"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8512), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("a470f202-ca90-4fc9-8617-358311885a1c") },
                    { new Guid("1e2f4cb4-4ecc-4ef8-b4e5-d13555e107ae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8420), null, false, null, null, "Mutual Funds Account Creation", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("1e606b87-bb2d-41bd-b926-9aca5304e217"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7813), null, false, null, null, "Daily Teams Call Over", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("1ee3c63c-8907-4500-81f2-67b244d23b14"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7788), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("556d5367-6794-4355-974f-e2ebb6447695") },
                    { new Guid("1f251946-b46c-4ea8-9636-94463839cefd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7865), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1") },
                    { new Guid("1fb8b8a6-bb59-4d59-b097-6c2922e96408"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8691), null, false, null, null, "Account Opening", new Guid("4221d035-01ed-4439-8829-d9b73f9e5a4b") },
                    { new Guid("20a630a0-1673-4009-8480-8e1692b9b0be"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8664), null, false, null, null, "Investigation", new Guid("a77067b1-9217-4a5b-b16d-70e211f22c25") },
                    { new Guid("20eea21c-8ff6-4a02-b285-7e66671f7cbb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8290), null, false, null, null, "Posting of Buybacks", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("210094fc-d396-4071-a84c-b3f11827e9ca"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8707), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("2121d93b-8c79-481b-8b8a-86b0aa15fcfe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8002), null, false, null, null, "RCSA Process", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("216582a9-35a0-43ba-84f9-844abe57fc33"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8179), null, false, null, null, "New Product Assessment", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("218da0c2-42f2-49a3-8940-9f897cdcc53f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7995), null, false, null, null, "Daily Teams Call Over", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("21eb1e57-1922-41f1-9f96-11cc2a64a769"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8763), null, false, null, null, "Foreign exchnage upload. Price and rates upload (Bloomberg prices, FMDQ, NGX, FMAN, NASD)", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("21edfbdf-b9b3-4ff8-a6b0-025ae663d340"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7966), null, false, null, null, "Applications Development/Enhancement", new Guid("a16649cf-8b89-4027-9628-8af108db66fc") },
                    { new Guid("240f3771-e3b7-437e-932d-fff02e0c5c88"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8821), null, false, null, null, "Goal-related Transactions", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("249d4e65-1eb7-4775-bbfa-f4f7388a59ae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8227), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("985b91e0-b7c5-4521-8c9a-d312a250d497") },
                    { new Guid("2500ea4c-bc68-4197-8582-1de31d292297"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8541), null, false, null, null, "Staff Sign-in/attendance management", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("250a51f5-31a2-4b28-8093-f2fbdbc658c2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7991), null, false, null, null, "Fixed Income Trade Review", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("25cabd8b-280b-4812-a65b-3f79d1420ccb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8794), null, false, null, null, "Withdrawal Processing (Portfolio Fund)", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("25ddce19-a77c-4e32-8b79-4dc40879f029"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7719), null, false, null, null, "MRC Reporting", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("2632c80f-ac43-49f0-be37-80b1177f4dee"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7779), null, false, null, null, "Filing of Regulatory Returns", new Guid("2e1919c1-fdae-4023-b602-6c3584f2b95b") },
                    { new Guid("267302f8-6228-4854-b424-ed2ca3557e03"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7729), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("26d66b69-6b35-4022-a02c-5a0ba5c23979"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8142), null, false, null, null, "Operational Performance Rating", new Guid("52ae7cc8-1382-4c45-833a-84e78a2de191") },
                    { new Guid("27527cbb-ffd5-4e59-a3ba-0c1ee478ec03"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8725), null, false, null, null, "Report preparation", new Guid("5cf04c21-a4c1-45f2-a80c-9ccd03aec033") },
                    { new Guid("278cd6c6-e49f-433c-afca-ddc94f1e773a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8563), null, false, null, null, "BARC Reporting", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("285fbcc2-addd-4b3b-b179-f1ba9846922a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8258), null, false, null, null, "Account Onboarding", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("28916de9-079b-4b58-ac27-44abbefa7953"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8792), null, false, null, null, "Account Onboarding", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("293f22da-7fc2-413d-bda8-3acc5157c6d2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8727), null, false, null, null, "Data Update", new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2") },
                    { new Guid("2a05c7ec-1437-4fb7-9f0e-9e5d955ac29c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8063), null, false, null, null, "Foreign exchnage upload. Price and rates upload (Bloomberg prices, FMDQ, NGX, FMAN, NASD)", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("2a83a16e-df77-4e20-b8d6-3b7052fefc21"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8739), null, false, null, null, "Unit Transfer", new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5") },
                    { new Guid("2a8ca117-5453-4251-a539-c46e07060a5a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8747), null, false, null, null, "Legal Advisory", new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739") },
                    { new Guid("2a98c36b-00c4-4889-b84a-15c2e73abdbb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7720), null, false, null, null, "RCSA Process", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("2ac85722-8a13-4bed-bd69-4b39f734df63"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8396), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("e4789074-ab43-463f-b18f-42606e28db63") },
                    { new Guid("2acaac92-b57f-4dea-a7e0-72252f961f11"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8604), null, false, null, null, "Fixed Income Trade Review", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("2acc00e6-443a-479c-8bf5-4cece206dd22"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8029), null, false, null, null, "Root Cause Analysis", new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38") },
                    { new Guid("2ad3884b-5baa-4e98-9dcd-072834b2f269"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8412), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("2b12ebf2-4f0d-408a-ad9b-44d79359fa49"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7715), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("2b55b1e8-96fd-4ae7-8aa5-eede00d22e06"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8566), null, false, null, null, "Pledge Review and Approval", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("2c8624dc-bfb7-4ba2-94ca-23a9aa284c0f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8758), null, false, null, null, "Sanction Sceening on clients", new Guid("7116856a-f88c-4bdf-b7d4-92e8e241c8ea") },
                    { new Guid("2cbdb10a-7e96-4771-a2a3-30d8c96412f9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8062), null, false, null, null, "Bank statement upload on AMS and  Fund injection processing on Deluxe", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("2cf84f08-86cd-44df-924f-a16acbf44445"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8653), null, false, null, null, "Corporate strategy development", new Guid("6cfdabd5-52e6-465b-8cca-5b23aead61be") },
                    { new Guid("2d35ebac-ef7e-4db1-b1da-a111ec590802"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8406), null, false, null, null, "Cash call-over", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("2dacb482-b385-4d9b-a084-8e01ee70a4de"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8445), null, false, null, null, "Loss Data Collection", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("2e2b852f-5337-47df-90bb-e2951064a23d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8348), null, false, null, null, "RCSA Process", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("2e525e10-bf64-460c-a800-10a601d3136e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8429), null, false, null, null, "Mutual Funds Account Creation", new Guid("1df86816-2842-4941-8710-36822d6240e8") },
                    { new Guid("2ed54b12-c3d5-432d-a74a-a17f2660f4de"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8307), null, false, null, null, "Follow Up", new Guid("d0b29a0f-69c0-42df-8af9-490ebc733c64") },
                    { new Guid("305c1d6a-0ad8-494d-adc3-a4fa944d1717"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8479), null, false, null, null, "Follow Up", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("308159c2-564a-4010-95a1-21e9cccc8a7f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8857), null, false, null, null, "Functional Testing – User Acceptance Test", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8") },
                    { new Guid("30ad8842-c611-42ef-8e34-9a4f84ec0aa2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8314), null, false, null, null, "Mutual Fund Pricing Review", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("30b31373-faa8-4cdd-8852-6c5492a84f46"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8246), null, false, null, null, "Inter-Member transfer request", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("30c54586-83fd-4800-b425-dfc88af6d3c0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8302), null, false, null, null, "Simulating Disaster and Recovery", new Guid("77635858-f888-45c8-9a6f-df2f5ac50670") },
                    { new Guid("311ac23a-3841-415f-8dca-effaa7602f4f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7808), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("3171b194-00ff-470d-9793-e85dadce357d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8452), null, false, null, null, "MFIC Reporting", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("31eadde3-d4c7-4d9b-a55f-415c68178121"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7902), null, false, null, null, "Receipt of share certificates and verification documents", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("31ec4aa6-b744-4d0b-82e1-3507cc996460"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8851), null, false, null, null, "Daily Teams Call Over", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("31f6c5bd-ca78-4d64-8b87-b562a7460720"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8093), null, false, null, null, "Record Update", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("322b080d-3c28-4d15-80c7-3243256f0004"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8508), null, false, null, null, "General secretarial activities", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("325a6c9d-6c36-4dc1-a9f9-167c19fd2ecc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8082), null, false, null, null, "Portfolio stock reconciliation", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("32813e2f-6610-487f-86b6-656b5b0128d3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8071), null, false, null, null, "Fee set up and fee mapping", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("328bbae0-0387-4531-bc91-70fad3d32bd5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8386), null, false, null, null, "Regulatory filings", new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe") },
                    { new Guid("34281ee9-4452-4e7b-b423-14ef148ac307"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8362), null, false, null, null, "Pledge Review and Approval", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("344b7a64-2ef9-461d-8c7c-40bb395ed0ad"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8564), null, false, null, null, "MFIC Reporting", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("345a417b-f306-432e-9ea4-f8204e47654f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8055), null, false, null, null, "Sanction Sceening on clients", new Guid("957f6bf9-1d02-4600-b676-6200eb6c4de3") },
                    { new Guid("3473e4ec-3976-4bf1-a9cb-7b5cfcb2efd8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8220), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11") },
                    { new Guid("347c5efb-1a9f-42b0-b938-77441880946f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8286), null, false, null, null, "Initiation of Intra-fund unit transfers", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("3504678c-67b4-4664-b65b-492a6e4c82a5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8301), null, false, null, null, "Data Recovery Steps", new Guid("77635858-f888-45c8-9a6f-df2f5ac50670") },
                    { new Guid("3546f3b1-a0c1-47ff-9313-7ba21ca154fa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8385), null, false, null, null, "Legal Advisory", new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe") },
                    { new Guid("35b57aec-ae66-4e29-94b9-ad30ee68c275"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8530), null, false, null, null, "Investor Notes Reconciliation", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("35eac49b-4873-4ff9-af41-0daae87e11d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7905), null, false, null, null, "Unverified returned share certificates", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("36818b33-3806-4eef-967d-7c71341c010e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8628), null, false, null, null, "RCSA Process", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("36c00334-4827-49fd-9bc3-caf86bd25a98"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8300), null, false, null, null, "Data Backup", new Guid("77635858-f888-45c8-9a6f-df2f5ac50670") },
                    { new Guid("37675f92-b2c8-475c-a3cd-52f3e01eba15"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8626), null, false, null, null, "Loss Data Collection", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("377a1a93-7a85-49ab-9949-8204aa8e88b6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8110), null, false, null, null, "Manual Collation of inflows and uploads into core application- NAV", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("37e68311-1fed-4e00-a849-6e191f644a5b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8523), null, false, null, null, "Create Asset Master Data", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("389ab5b4-5816-4363-8b64-80f517199684"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8828), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("a5ab3b91-07f8-47d7-8ad7-3dfdbf005f8e") },
                    { new Guid("39508b77-2989-4564-8327-a5c81f7b18bf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8552), null, false, null, null, "Requisition Invoice", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("39fc0305-0fe3-4796-95b4-18b4f58446a4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8056), null, false, null, null, "Stock & Institution creation, Issuer Creation, Mutual fund Creation", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("3a3fb3fa-0c8f-4908-b33b-54a863cfa9a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8658), null, false, null, null, "Strategy revision", new Guid("6cfdabd5-52e6-465b-8cca-5b23aead61be") },
                    { new Guid("3a5c69c0-f256-468b-b320-4ef84d65be6d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8192), null, false, null, null, "Mutual Funds Account Creation", new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8") },
                    { new Guid("3a5ccdc1-981f-4a37-b3a6-57a7c34c622d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8619), null, false, null, null, "Filing of Regulatory Returns", new Guid("23f36ca8-a0ce-49bf-be0c-66366eff3c51") },
                    { new Guid("3a68d996-c7a6-4e1c-87f4-f66748483550"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8309), null, false, null, null, "Operational Performance Rating", new Guid("d0b29a0f-69c0-42df-8af9-490ebc733c64") },
                    { new Guid("3b2b3d88-628e-433f-82d9-7ec1b4d79a0d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7855), null, false, null, null, "Unit Transfer", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("3b92a6f4-f6d0-4a47-8cf1-384c6d1147d7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8536), null, false, null, null, "HMO MANAGEMENT", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("3ba96d05-de87-4367-9063-03772d73d7c3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8625), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("3bec24d7-7ed1-41bf-a989-3257558d8dc1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7838), null, false, null, null, "Pledge Review and Approval", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("3c09a654-d457-487e-ab54-09b74c63861a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7918), null, false, null, null, "Update of Instrument Information", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("3c8ff071-29b8-4ec8-9676-c01a3b2505a4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7939), null, false, null, null, "AMS pulls transactions from the Bank API", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("3c94a5bf-144d-4622-aa29-f1424029b0bb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8612), null, false, null, null, "Drafting Embassy letters ", new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879") },
                    { new Guid("3c96100b-1b3b-41c9-8c48-9ff7dda27bf1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8103), null, false, null, null, "NFIU Reporting", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("3cb93705-ee66-4f14-bb5b-ceb400b4e647"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7854), null, false, null, null, "Embassy Letter", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("3cc4eb0e-9000-422c-a8cd-2a3192858b5d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8148), null, false, null, null, "Mutual Fund Pricing Review", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("3cfeeda8-0d99-4fc8-ba3e-ca6e3440b333"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8756), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("7116856a-f88c-4bdf-b7d4-92e8e241c8ea") },
                    { new Guid("3d3fbfa2-1749-42ac-b057-fb542f5d4c61"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8784), null, false, null, null, "Custodian reconciliation", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("3dd2be7d-a6b6-43b1-a174-fc6877303b40"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8048), null, false, null, null, "General secretarial activities", new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663") },
                    { new Guid("3edb74ac-cbbb-43bd-a55a-e69cd1cf4c0b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8618), null, false, null, null, "General secretarial activities", new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879") },
                    { new Guid("3f1e70b7-d50b-4c78-9b30-a23406e01cb2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8615), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879") },
                    { new Guid("3ff4e226-b678-4f6b-af06-592548735e44"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8774), null, false, null, null, "Receipt of share certificates and verification documents", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("41077438-11d7-458b-ac13-cd252924b1e4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8361), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("420439e4-72f5-4db6-a80f-34c412426632"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8776), null, false, null, null, "Unverified returned share certificates", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("430a4089-763d-4e62-a696-d9a5d52643fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8572), null, false, null, null, "Applications Development/Enhancement", new Guid("7d22672e-a552-4944-a418-d7678717c193") },
                    { new Guid("43151a08-1f8c-48eb-8d24-2260c9ebf142"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7784), null, false, null, null, "Sanction Sceening on clients", new Guid("2e1919c1-fdae-4023-b602-6c3584f2b95b") },
                    { new Guid("437ed55c-e0a5-41aa-9a2d-dca2928b2095"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8296), null, false, null, null, "Applications Development/Enhancement", new Guid("77635858-f888-45c8-9a6f-df2f5ac50670") },
                    { new Guid("44155f81-6b27-4ffb-863d-e17a6aaf2f92"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7790), null, false, null, null, "Data Recovery Steps", new Guid("556d5367-6794-4355-974f-e2ebb6447695") },
                    { new Guid("44d86950-e193-45a3-ae1e-102a5360f5e1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8370), null, false, null, null, "Applications Development/Enhancement", new Guid("32a964ce-a439-4c80-9a36-f7774706ee32") },
                    { new Guid("45629430-24be-4934-9c85-8926002d491e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8805), null, false, null, null, "Change of Dividend Mandate", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("4582c1bd-8443-4518-87df-d6686b1b2689"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8507), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("45e5be39-e7aa-414f-a48d-fde49935780a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8700), null, false, null, null, "MRC Reporting", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("46602c75-6c7e-4333-b7f5-7e9a96a94793"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8276), null, false, null, null, "AMS pulls transactions from the Bank API", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("4680cefd-a546-4384-9e8d-b0723f054b7f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7817), null, false, null, null, "Redemption/Withdrawals/Other Payments", new Guid("6e7c4307-421c-4f26-9216-a740663cdebd") },
                    { new Guid("46a6cf8e-3c4d-4ebc-adee-fbc0b2520dfd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8624), null, false, null, null, "Sanction Sceening on clients", new Guid("23f36ca8-a0ce-49bf-be0c-66366eff3c51") },
                    { new Guid("4784817e-7a97-4f6f-b544-4f564bf537e7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8427), null, false, null, null, "Root Cause Analysis", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("47f95908-b29b-458a-a326-aa6d6d43f811"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7844), null, false, null, null, "Corporate strategy development", new Guid("456575f1-a8db-4fd9-885f-8e84e096c860") },
                    { new Guid("48105385-6882-4ab1-8c8d-13e9f710d3a5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8807), null, false, null, null, "NFIU Reporting", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("48c8ffdb-f58a-44fe-b3b3-a44fc0070801"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7774), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb") },
                    { new Guid("48d182ac-2d60-493b-be12-1ef9e68ceb77"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8484), null, false, null, null, "Trade call-over", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("48e1ed78-ec40-4aa5-b18e-b11a5de5faf8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8043), null, false, null, null, "Drafting Embassy letters ", new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663") },
                    { new Guid("4905e60d-b0f7-47e3-bf11-b9e2a4a37b22"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7830), null, false, null, null, "BARC Reporting", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("492c69c8-97e1-45cf-afa3-68b4bdc20a0a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8800), null, false, null, null, "Estate Transmission - Letter of Administration / Probate", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("497ccb36-51db-442e-ac20-c358b645587c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8544), null, false, null, null, "Cold Room Management", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("49c74058-1375-4f2f-98d5-3e7ea1b61c56"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8402), null, false, null, null, "Follow Up", new Guid("65757b71-e2fb-490d-ba49-20e94ee3623d") },
                    { new Guid("49d27176-d7e4-40d5-8264-fd200b61028c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8088), null, false, null, null, "Update of Instrument Information", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("49f815f0-249e-4928-86f2-74cf4b220fce"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8823), null, false, null, null, "Daily Reconciliation of all Web transactions", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("4a7459a0-7dd8-48c6-9ddc-5ecc76a34f4c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8455), null, false, null, null, "Pledge Review and Approval", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("4aa8374f-b4d9-4455-b6d3-50acd799100e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8711), null, false, null, null, "Business Continuity Management Tests", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("4ad2ac52-5b7e-4635-8666-33ef7f3ef92b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8195), null, false, null, null, "Unit Transfer", new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8") },
                    { new Guid("4afb4879-9f58-47ca-b632-20c67fbbb307"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8497), null, false, null, null, "Contract drafting and reviews", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("4b3e2a5e-aac2-472f-bcb2-4300cf05d0b1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7778), null, false, null, null, "Account Opening", new Guid("2e1919c1-fdae-4023-b602-6c3584f2b95b") },
                    { new Guid("4bbc6fbf-ada5-4c09-b610-a98ad9d98051"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8400), null, false, null, null, "Audit Review", new Guid("65757b71-e2fb-490d-ba49-20e94ee3623d") },
                    { new Guid("4c0607db-3e42-4932-87ff-cdb0d85fae02"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8046), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663") },
                    { new Guid("4cabd5a5-bff8-44f1-8391-3c79ec656279"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7993), null, false, null, null, "User Rights Access Mgt", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("4d033d3c-6ba8-4fca-90fd-8df283135f7d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8054), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("957f6bf9-1d02-4600-b676-6200eb6c4de3") },
                    { new Guid("4d634fd9-47e9-49bb-9bce-dda9e600f3e4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7818), null, false, null, null, "Subscriptions", new Guid("6e7c4307-421c-4f26-9216-a740663cdebd") },
                    { new Guid("4dc55a0b-ecc3-4876-a225-84f40827d90d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8100), null, false, null, null, "Unclaimed Dividend Payment", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("4ee84890-6ff1-432b-8ae0-93d65ab5c090"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8464), null, false, null, null, "Data Backup", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("4fd0422e-86ce-4305-8248-8c427d73b3f3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8204), null, false, null, null, "Business strategy monitoring", new Guid("444a03bb-a3d4-4cec-a76c-eeabda66003a") },
                    { new Guid("50102f42-6b23-4825-9c72-075e3f8e00fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8742), null, false, null, null, "Client Communications", new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5") },
                    { new Guid("5053e912-6e1a-49a2-b44a-f9d93657e82f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8515), null, false, null, null, "Develop Marketing and Corporate Communication (external and internal)", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c") },
                    { new Guid("5082f73b-1540-4fba-b970-2266c8e41abb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7837), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("50ff0c2a-5b09-4305-92b8-3ebcb6c48c07"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8706), null, false, null, null, "MFIC Reporting", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("516ac2b8-2f5e-40b2-a7db-63b429159453"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8820), null, false, null, null, "Memo for Transfer of fund across Bank", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("5295837f-700f-42cb-b0e7-fcf59b238fde"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8268), null, false, null, null, "Deactivation of Mobile Number Re-assigned to a Third Party", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("5297682e-4844-42ba-a09f-f1638709d543"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7903), null, false, null, null, "Inter-Member transfer request", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("5322f073-7d8b-4c3c-be3d-cefae8770713"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8708), null, false, null, null, "Pledge Review and Approval", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("535cb97f-a234-44e7-9e2c-e48a6c58a01e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8596), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("2324ca19-a743-485a-b49a-d04b5a1ec0a0") },
                    { new Guid("53687b10-754c-4868-80b3-83b60e8bd8f5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7763), null, false, null, null, "Embassy Letter", new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836") },
                    { new Guid("54413748-222f-4a8c-92c7-7273a8ea339e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8489), null, false, null, null, "Fixed Income Trade Review", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("557d7e4f-d5f5-40a6-b6bf-5f5b891e4bac"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8194), null, false, null, null, "Embassy Letter", new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8") },
                    { new Guid("559b5192-86a1-485b-a4d5-a16c8ce2a22d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7866), null, false, null, null, "Client Communications", new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1") },
                    { new Guid("561d795f-8e52-4150-a79b-b2c5bee1a647"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7859), null, false, null, null, "Root Cause Analysis", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("56cbaabe-ac1b-4828-810c-15d3b1f139dd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8149), null, false, null, null, "Institutional Fund Pricing Review", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("56f26683-55cb-4bc7-870c-21670ae4acd7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8425), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("5705a147-8e71-418c-a8fd-f9a97cd15bbf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7920), null, false, null, null, "MMF Quarterly Dividend Reinvestment", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("5775c7b5-4b85-4f60-bc4f-0978d71e7ecd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8542), null, false, null, null, "Keys Management", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("57f2b2a1-0e64-4eb2-b0c0-51bfe1d658a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8487), null, false, null, null, "Institutional Fund Pricing Review", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("58926708-5546-4a86-8d51-632f19991802"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8417), null, false, null, null, "Daily Teams Call Over", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("58cfeb2d-4172-4d3e-86cc-b5ffa359df7c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8775), null, false, null, null, "Inter-Member transfer request", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("592155be-5b34-441c-a7e9-d8896fa64cb3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7856), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("595f2743-aa31-4851-9340-5229a6747a4a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8384), null, false, null, null, "Drafting Embassy letters ", new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe") },
                    { new Guid("597f1016-6ecf-45e7-9f60-e654b2ffbcda"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8684), null, false, null, null, "Legal Advisory", new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970") },
                    { new Guid("598e1bf0-e6a9-4564-b4bd-d7ec779fd6ec"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8593), null, false, null, null, "Investigation", new Guid("2324ca19-a743-485a-b49a-d04b5a1ec0a0") },
                    { new Guid("59b44cbd-71c3-4f42-b71d-86f6f051e656"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8158), null, false, null, null, "CSCS Reconciliation", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("5a0a5c1b-9035-47bf-9fe7-f421054732ee"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8392), null, false, null, null, "Account Opening", new Guid("e4789074-ab43-463f-b18f-42606e28db63") },
                    { new Guid("5a3e7b2a-b7b5-46dc-af57-4238957e89bd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8483), null, false, null, null, "Cash call-over", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("5a4534c5-21b8-4eef-9121-139372059984"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8797), null, false, null, null, "Record Update", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("5a45cdd0-5033-4364-bffa-e0f49ff00506"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8080), null, false, null, null, "Corporate Action", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("5a671de9-1b26-4136-9839-7167e047ee1c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8225), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("985b91e0-b7c5-4521-8c9a-d312a250d497") },
                    { new Guid("5ae649e8-a278-493b-995e-ba4e43c6e25c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8285), null, false, null, null, "Posting of all verified redemptions and pass for payment", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("5b5a1808-45f3-4a19-a81c-43fa9c819b39"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8269), null, false, null, null, "Unclaimed Dividend Payment", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("5bc2bf97-8632-4df9-80a6-10d743a1c021"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8783), null, false, null, null, "Transfer of stocks between same client’s portfolios", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("5bf3919e-5f5c-4626-9534-702b14163fbf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7728), null, false, null, null, "MFIC Reporting", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("5c50c1dd-36b1-4006-9fb8-0f7bb883b2da"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7789), null, false, null, null, "Data Backup", new Guid("556d5367-6794-4355-974f-e2ebb6447695") },
                    { new Guid("5c5f70c8-6835-4af0-bf36-628741ac5ba0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7961), null, false, null, null, "GL reconciliation and review", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                    { new Guid("5cd9e705-6e7f-4acf-b172-1e035c666b03"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7896), null, false, null, null, "Fee set up and fee mapping", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("5cff91b4-9ac9-4caf-8d28-d82071492a64"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8005), null, false, null, null, "BARC Reporting", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("5d9d51a8-c24e-43f8-b378-5739da797d9b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8599), null, false, null, null, "Mutual Fund Pricing Review", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("5e2785d6-dcbd-4c7a-b87a-9b97e03e71cd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8762), null, false, null, null, "Bank statement upload on AMS and  Fund injection processing on Deluxe", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("5e38ebf7-7917-4dcc-84f3-82e0fe2dea3f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8317), null, false, null, null, "Fixed Income Trade Review", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("5e3bd166-b49f-42fb-b34a-fa52d7099e0d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8811), null, false, null, null, "Manual matching of inflow into clients account", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("5e9da993-b3e6-47b7-94b1-87ff5e7a69e5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8565), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("5eb0509a-163a-476f-8c37-7f97d208bc69"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8735), null, false, null, null, "Mutual Funds Account Creation", new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5") },
                    { new Guid("5ebc8d92-ce24-4b80-8844-347b36f5ddf8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7926), null, false, null, null, "Record Update", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("5f08d383-8f4d-4d21-8db3-77b274e950c7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7877), null, false, null, null, "General secretarial activities", new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31") },
                    { new Guid("5f109704-b582-4c04-b9ae-e9a1b7a165e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8767), null, false, null, null, "Portfolio creation, System bank account creation, Bank account mapping", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("5facbea3-9ec2-49f9-87a1-5082e489c7df"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8837), null, false, null, null, "Follow Up", new Guid("b84c6b8d-5fe4-4e4a-9143-16e25509bfb5") },
                    { new Guid("5faf9001-3749-496e-8c4e-5555a3a7ab51"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8511), null, false, null, null, "Filing of Regulatory Returns", new Guid("a470f202-ca90-4fc9-8617-358311885a1c") },
                    { new Guid("5fb9169a-8006-4243-95c6-43e4713d336a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8228), null, false, null, null, "Sanction Sceening on clients", new Guid("985b91e0-b7c5-4521-8c9a-d312a250d497") },
                    { new Guid("5fccbb52-58bf-4cf2-9a93-f50512d6cab7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7745), null, false, null, null, "Mutual Funds Account Creation", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("5ff0687a-cfcd-42a5-aa72-c700deb47125"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8441), null, false, null, null, "Client Communications", new Guid("1df86816-2842-4941-8710-36822d6240e8") },
                    { new Guid("6074f8a8-e88d-485c-b403-f2b85eb34be1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8634), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("607e5c78-0494-41e9-a733-969e26501ffb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7809), null, false, null, null, "Fixed Income Trade Review", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("60aa5dc9-ae6a-4098-84da-d9ee60e28dba"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8690), null, false, null, null, "General secretarial activities", new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970") },
                    { new Guid("60e6f303-181c-4416-9f74-7f8a486c4ef3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8215), null, false, null, null, "Drafting Embassy letters ", new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11") },
                    { new Guid("61273a13-d444-4199-a329-40ae9989baf2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8588), null, false, null, null, "Quarterly performance review session", new Guid("bba02c89-3bf2-4596-857c-54c4f86e9a27") },
                    { new Guid("612bdd13-5c59-43be-bf5b-2745e2470a3e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8773), null, false, null, null, "Receipt of client instruction", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("61668619-34b5-4ce5-9e42-f1aa65a78508"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8693), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("4221d035-01ed-4439-8829-d9b73f9e5a4b") },
                    { new Guid("6194c0bc-5396-4009-9bdf-56317e8b43a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7952), null, false, null, null, "Goal-related Transactions", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("619779b9-5311-449f-83d2-60ce1b0662e0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8293), null, false, null, null, "Daily Movement of posted subscriptions at Bank(Cash Sweep)", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("619e8533-81b7-434d-9160-c70ecf197c7f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8257), null, false, null, null, "MMF Quarterly Dividend Reinvestment", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("61b82d19-7978-43b2-8975-791e83eabfc4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8587), null, false, null, null, "Business strategy monitoring", new Guid("bba02c89-3bf2-4596-857c-54c4f86e9a27") },
                    { new Guid("62045406-a992-4e55-8abb-5ea54a9846e5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8838), null, false, null, null, "Operational Performance Rating", new Guid("b84c6b8d-5fe4-4e4a-9143-16e25509bfb5") },
                    { new Guid("624d6658-1dce-4a9b-8ade-bf531daaf12f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8740), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5") },
                    { new Guid("62911f41-ec91-462b-9ac2-3a37553ddd54"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7829), null, false, null, null, "Risk Management Disclosures", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("62b26d63-509e-401f-b6f5-f2d2eecd870d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8047), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663") },
                    { new Guid("62f1e19d-f1ad-4b43-a5f3-d9dc0ade72d0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8852), null, false, null, null, "CSCS Reconciliation", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("62fb208e-023d-4775-9c40-cc967f22162b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8238), null, false, null, null, "Portfolio creation, System bank account creation, Bank account mapping", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("634f6e94-c3e7-4425-a6d6-1317fb8febdf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7884), null, false, null, null, "Stock & Institution creation, Issuer Creation, Mutual fund Creation", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("63bc281a-80b5-4368-ba7a-28153724f7f5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8284), null, false, null, null, "Posting of all matched subscription on NAV", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("641f16f9-7aea-44b8-9937-f00e976304de"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7733), null, false, null, null, "Counterparty Review and Assessment", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("643afc97-be56-40e6-a89b-651252b43078"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7960), null, false, null, null, "Fee accrual validation", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                    { new Guid("64980b73-2fe3-410d-863e-eebf5186d850"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8331), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e") },
                    { new Guid("64c2c315-6c29-40a5-9529-2f157b61e222"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8255), null, false, null, null, "Custodian reconciliation", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("64e1b71c-0d7b-4821-ba4e-e7b1d7a32524"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8786), null, false, null, null, "MMF Quarterly Dividend Reinvestment", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("64f9052d-e769-47d4-a45b-8c46f5fffb3d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8803), null, false, null, null, "EOQ/Dividend Payment", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("653d152c-5ec0-4dc5-8c65-cb3326b891a6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8614), null, false, null, null, "Regulatory filings", new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879") },
                    { new Guid("654d7b28-4118-4b12-bd4a-95bbce3960ae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8446), null, false, null, null, "MRC Reporting", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("6561a66a-3ac6-4baa-8ea6-f95c91bf651f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8752), null, false, null, null, "General secretarial activities", new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739") },
                    { new Guid("6684b8f8-44a4-4181-a578-3cebbc43a5ef"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8383), null, false, null, null, "Contract drafting and reviews", new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe") },
                    { new Guid("66bd4173-6527-4b4d-b6ae-810e2973b2f3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7951), null, false, null, null, "Memo for Transfer of fund across Bank", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("6740fb3d-4b4f-4af1-8e52-0ecfa3ea56ec"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8423), null, false, null, null, "Embassy Letter", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("67a72c00-444a-4d31-bdae-a1acb5fa451b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8311), null, false, null, null, "Cash call-over", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("67bf2284-a290-41e3-b019-8694cb3c8329"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7947), null, false, null, null, "Initiation of Intra-fund unit transfers", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("67c18e0f-cae4-4b06-a83e-4654a99f692c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8839), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("b84c6b8d-5fe4-4e4a-9143-16e25509bfb5") },
                    { new Guid("67e0398a-6eff-4716-88ae-1168ae42b600"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8492), null, false, null, null, "Statutory Remittance Review", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("68354475-f0a3-4716-9fc6-553bbfa9b347"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7935), null, false, null, null, "Change of Dividend Mandate", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("68bd03f8-4375-4b21-b3fe-6c02a6b9d0d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7773), null, false, null, null, "Regulatory filings", new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb") },
                    { new Guid("68be6519-80cc-4c02-ab6a-9951544133e7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7945), null, false, null, null, "Posting of all matched subscription on NAV", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("68d29364-05cd-45f8-b6a2-c129c8704d5d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7759), null, false, null, null, "Mutual Funds Account Creation", new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836") },
                    { new Guid("68de03de-6ff6-46f4-85ba-c332a7a0883a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8083), null, false, null, null, "Transfer of portfolio to another party (broker)/Portfolio stock withdrawal", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("68e164c4-9382-42ab-9cb1-dc3a38e18c36"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8254), null, false, null, null, "Transfer of stocks between same client’s portfolios", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("68ed7d07-36b6-46c8-9953-9a49e4f5ab2e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7858), null, false, null, null, "Client Communications", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("69390cff-ea07-4af4-9009-45c09db74c5d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8214), null, false, null, null, "Contract drafting and reviews", new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11") },
                    { new Guid("693bcc1b-a6e7-4b44-b16a-9f4d10063fad"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8754), null, false, null, null, "Filing of Regulatory Returns", new Guid("7116856a-f88c-4bdf-b7d4-92e8e241c8ea") },
                    { new Guid("69416810-2b4d-4d66-a45a-dc386f3b02c6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8026), null, false, null, null, "Unit Transfer", new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38") },
                    { new Guid("69489613-9629-41d0-837e-f1f45c9ae84b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8841), null, false, null, null, "Trade call-over", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("697fcb2e-601c-44b7-9377-0f6211b8e373"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8724), null, false, null, null, "Quarterly performance review session", new Guid("5cf04c21-a4c1-45f2-a80c-9ccd03aec033") },
                    { new Guid("698227cd-ca40-4c41-ad87-f2cc3e4dfb9b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8161), null, false, null, null, "Client Investment Monitoring", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c") },
                    { new Guid("69d55fc0-65d9-4c86-9276-c6f805cc869f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7724), null, false, null, null, "ALCO Reporting", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("6a233cef-1a58-4bf0-a67d-fb06e0e5a256"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8157), null, false, null, null, "Daily Teams Call Over", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("6ae041af-5e51-44a4-92f5-df7f54ceeb2c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8267), null, false, null, null, "Estate Transmission - Letter of Administration / Probate", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("6af1fb13-1f80-4c8c-aefe-42e65379eade"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7775), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb") },
                    { new Guid("6b6a28b7-9e96-4b0b-bcbc-ab7799bcef15"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8329), null, false, null, null, "Unit Transfer", new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e") },
                    { new Guid("6b703f18-8d35-4987-ade1-37144650060e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8310), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("d0b29a0f-69c0-42df-8af9-490ebc733c64") },
                    { new Guid("6b7ac93e-c646-40ab-8025-c646712248cb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8034), null, false, null, null, "Embassy Letter", new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6") },
                    { new Guid("6bdb3139-31c1-4850-b2c1-bae2f63406f3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8342), null, false, null, null, "Root Cause Analysis", new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d") },
                    { new Guid("6beda882-5b10-46df-aea6-f89bd17a68fd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8759), null, false, null, null, "Stock & Institution creation, Issuer Creation, Mutual fund Creation", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("6c6eae4d-81a1-4203-adb9-91eba4a4a25d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7740), null, false, null, null, "Business strategy monitoring", new Guid("42c3cab6-ccbd-452e-8f84-45993337f2b3") },
                    { new Guid("6ca0ff48-7312-4b0d-a020-75acdd75ac17"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8241), null, false, null, null, "Client creation and client mapping", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("6cebdf8a-f6cf-48e3-be40-e6c4e581aaef"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7804), null, false, null, null, "Mutual Fund Pricing Review", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("6d72ef47-5681-4e55-9613-cc449c5fc50c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8597), null, false, null, null, "Cash call-over", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("6d85d177-8f6e-4d03-bc56-a14a7fa5eda7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8223), null, false, null, null, "Account Opening", new Guid("985b91e0-b7c5-4521-8c9a-d312a250d497") },
                    { new Guid("6db463ec-7d4c-4c02-a7c3-401ef79b80f4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8210), null, false, null, null, "Quarterly performance review session", new Guid("444a03bb-a3d4-4cec-a76c-eeabda66003a") },
                    { new Guid("6e3ca098-cb92-41a5-8f8e-fe2d4791fca6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8008), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("6e90bb25-a302-4f62-8aea-7637b7fd7c23"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7994), null, false, null, null, "Statutory Remittance Review", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("6f0d24ed-2893-4ae4-b8b3-0035551d85e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8744), null, false, null, null, "Contract drafting and reviews", new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739") },
                    { new Guid("6f17edaf-06f8-4df3-964f-8ef949e3821e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8840), null, false, null, null, "Cash call-over", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("6f4e7481-c74d-4d43-8962-f62c1cd17c6f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8527), null, false, null, null, "Cash Advance and Cash Advance Retirement", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("6f81738f-0419-4a89-bde2-1f1d9a26b6e0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8061), null, false, null, null, "Portfolio CSCS creation", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("70114e8e-5c57-4f48-8a79-d14c3f4192b7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7819), null, false, null, null, "Reference Letters", new Guid("6e7c4307-421c-4f26-9216-a740663cdebd") },
                    { new Guid("7077c9c3-6ad2-4dbc-88af-b54e48223c6c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8584), null, false, null, null, "Corporate strategy development", new Guid("bba02c89-3bf2-4596-857c-54c4f86e9a27") },
                    { new Guid("707dd21c-676f-49fa-8564-ebef1bb8f200"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7725), null, false, null, null, "Risk Management Disclosures", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("7152af96-5050-45ea-a06c-955455b503d9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8112), null, false, null, null, "Posting of all matched subscription on NAV", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("715f8f85-4770-4524-9b5a-0d7442b8c9e3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8036), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6") },
                    { new Guid("71850ef0-7822-45f4-a231-e166632c45f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8355), null, false, null, null, "MFIC Reporting", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("718f2c9c-7894-4989-b7e4-35162309a7fa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8651), null, false, null, null, "Simulating Disaster and Recovery", new Guid("aa0a3489-560d-4e02-b270-ca08a45d2fcf") },
                    { new Guid("7196e521-e563-4473-a3f4-9e1521301df3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8678), null, false, null, null, "User Rights Access Mgt", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("721e6f15-2ed7-4b32-b3d2-90bb0a549282"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8567), null, false, null, null, "New Product Assessment", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("723b72bd-fce8-4401-b901-a29211ceb154"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7840), null, false, null, null, "New Product Assessment", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("72da65c4-c78d-4a3e-aa61-840993f08c5c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8065), null, false, null, null, "Portfolio, Transactional client, Scheme  withdrwals", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("7305405b-4264-4a35-be6f-90c7449a4648"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8808), null, false, null, null, "Sanction Screening", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("7327655a-759e-4c33-8059-b36f3fdf9e78"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7971), null, false, null, null, "Simulating Disaster and Recovery", new Guid("a16649cf-8b89-4027-9628-8af108db66fc") },
                    { new Guid("73464d5a-6666-4463-85d6-92b419a785d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8007), null, false, null, null, "MFIC Reporting", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("738851c4-b543-4510-b996-5293190c60cd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8832), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("b84c6b8d-5fe4-4e4a-9143-16e25509bfb5") },
                    { new Guid("73a3945b-ea2c-4594-884b-3446f2f66fe7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8143), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("52ae7cc8-1382-4c45-833a-84e78a2de191") },
                    { new Guid("74481bb2-dc22-449c-bddc-da534a4fd6af"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7873), null, false, null, null, "Regulatory filings", new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31") },
                    { new Guid("748a245f-05db-490d-bfdf-61d414a91b20"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8084), null, false, null, null, "Transfer of stocks between same client’s portfolios", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("748d6613-faaa-4fe2-9fb5-079bf27cf3c6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7730), null, false, null, null, "Pledge Review and Approval", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("74fc36fe-4f1e-4912-a271-b91b8c72e05c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8095), null, false, null, null, "Standard Embassy Letter", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("7510f720-b58d-455b-9ba3-7ae1000f8162"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8472), null, false, null, null, "Business strategy monitoring", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75") },
                    { new Guid("756c8af0-acfc-45b8-a43d-ebf7ddd112a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8476), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("756e2b32-6368-4482-83b9-b044a380ce2e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8556), null, false, null, null, "Loss Data Collection", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("76166896-dcff-4fe7-86cc-c6389772590c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7969), null, false, null, null, "Data Recovery Steps", new Guid("a16649cf-8b89-4027-9628-8af108db66fc") },
                    { new Guid("767694aa-96db-4aea-a008-ec87ca9a82ad"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8147), null, false, null, null, "Trade call-over", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("768a8e1b-d86c-4e6e-b185-e184d78dd408"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8699), null, false, null, null, "Loss Data Collection", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("775f0c0e-53b2-4ec6-b0fe-39ab686454a1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8070), null, false, null, null, "RM creation and mapping ", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("7775fd11-d7a7-4764-8eb4-e5614025bcf6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8422), null, false, null, null, "Data Update", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("787e5323-e23a-42a5-92c2-aa32e5730947"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8627), null, false, null, null, "MRC Reporting", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("78b74dc9-07bf-4919-9afc-5b5cc063350f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8251), null, false, null, null, "Transfer of portfolio to another party (broker)/Portfolio stock withdrawal", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("78bee780-5161-42f6-b406-136ae7d05b3b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8003), null, false, null, null, "ALCO Reporting", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("79ba7e0e-8ab9-4c98-ac67-2c09e38ce5a1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8140), null, false, null, null, "Investigation", new Guid("52ae7cc8-1382-4c45-833a-84e78a2de191") },
                    { new Guid("79e5a3fc-4b1e-44b9-8e81-66754b4b0f48"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8336), null, false, null, null, "Embassy Letter", new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d") },
                    { new Guid("7a48cadb-bf9a-4c6a-a1fa-9b40d6244afb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8815), null, false, null, null, "Posting of all verified redemptions and pass for payment", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("7a4a27e1-bab4-41f1-be03-873110bf23a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7737), null, false, null, null, "Corporate strategy development", new Guid("42c3cab6-ccbd-452e-8f84-45993337f2b3") },
                    { new Guid("7a4ba8eb-94e1-4429-b9df-355f7b5614d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8278), null, false, null, null, "Manual matching of inflow into clients account", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("7a834d11-68f0-44b3-aaa0-487faa102ef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8153), null, false, null, null, "User Rights Access Mgt", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("7a845d44-bfe0-48c3-a782-befa70610d81"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8533), null, false, null, null, "STAFF FILE", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("7afab922-cb07-4399-8c74-34a10afc6f1a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8039), null, false, null, null, "Contract drafting and reviews", new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663") },
                    { new Guid("7b41bbd0-51be-46f2-84be-5a8c44013a74"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8824), null, false, null, null, "Systems Maintenance", new Guid("a5ab3b91-07f8-47d7-8ad7-3dfdbf005f8e") },
                    { new Guid("7b8a05ec-5cc0-4705-ac4f-3aac40c9822b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7765), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836") },
                    { new Guid("7c4fa8c7-6f12-41d2-8562-080f1f2829ec"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8490), null, false, null, null, "BRD and UAT review", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("7d374f00-cdc9-460e-ad1c-d06705652581"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8594), null, false, null, null, "Follow Up", new Guid("2324ca19-a743-485a-b49a-d04b5a1ec0a0") },
                    { new Guid("7d3d2b80-e14e-458e-b9fd-2f89e7cb7703"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8426), null, false, null, null, "Client Communications", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("7d50431e-7155-4e2a-bcde-d945e5a15d13"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8606), null, false, null, null, "User Rights Access Mgt", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("7d5d24c2-6899-4de1-9ee9-be5dbebb69b3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8164), null, false, null, null, "Business Development", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c") },
                    { new Guid("7d6c8e36-7d43-4fc4-8104-443d21646c9b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8710), null, false, null, null, "New Product Assessment", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("7dc20bbd-badb-4f36-9a25-a6069c69b1cd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8146), null, false, null, null, "Cash call-over", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("7dd407ae-1ccd-4dd3-9f97-bc2157d703d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7776), null, false, null, null, "General secretarial activities", new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb") },
                    { new Guid("7e451f1b-8084-4132-87c7-2b8c39d67b47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7967), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("a16649cf-8b89-4027-9628-8af108db66fc") },
                    { new Guid("7e51ef96-f804-4362-adbf-074ad5bf1986"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8474), null, false, null, null, "Report preparation", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75") },
                    { new Guid("7eae9f64-27c1-47e4-9c98-811d9cea5908"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8650), null, false, null, null, "Data Recovery Steps", new Guid("aa0a3489-560d-4e02-b270-ca08a45d2fcf") },
                    { new Guid("7eb15434-f0a2-44f6-a537-e3501837a0b9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7933), null, false, null, null, "Unclaimed Dividend Payment", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("7ebe9cb1-fb1d-4ce5-9e5c-f3c3627ef262"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7766), null, false, null, null, "Client Communications", new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836") },
                    { new Guid("7f34d972-6963-413d-9025-beaf6833a75e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8152), null, false, null, null, "BRD and UAT review", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("7f39aa4d-7ac9-4a20-bace-7875c6728143"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8517), null, false, null, null, "Web Development /Update (this is the process of developing or updating web pages)", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c") },
                    { new Guid("7f8c01a1-516c-49b3-b73d-a3156b7c3e28"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8382), null, false, null, null, "Report preparation", new Guid("9f4432a0-9002-4553-997d-633869423d79") },
                    { new Guid("7fb77bf4-a33a-4afe-9f08-f5113f228c6d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8501), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("7fca4064-7bf3-4bd7-9716-0f2ec7610d48"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8457), null, false, null, null, "New Product Assessment", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("80c10e92-05d3-4a8b-af7a-303161d9f938"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8704), null, false, null, null, "BARC Reporting", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("80eb566d-b70b-428c-8a25-568d36b0c420"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8178), null, false, null, null, "Pledge Review and Approval", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("8123249c-e4ca-49a6-a15c-7039857d1001"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8463), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("81250c47-b677-49f4-bb8e-62541cc29436"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8401), null, false, null, null, "Investigation", new Guid("65757b71-e2fb-490d-ba49-20e94ee3623d") },
                    { new Guid("81634fdc-7285-4136-9510-7ecd31fc4331"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8126), null, false, null, null, "Data Backup", new Guid("e1671ffd-98d2-4063-b883-310378ac972a") },
                    { new Guid("819e0826-2fcd-4ceb-8aa6-6881e6708deb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8581), null, false, null, null, "Simulating Disaster and Recovery", new Guid("7d22672e-a552-4944-a418-d7678717c193") },
                    { new Guid("81ed1560-5bf5-49a6-943f-2717aebcad40"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7997), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("82121006-cf72-4681-9219-86188cfdfd9f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7949), null, false, null, null, "Direct debit set up and Termination", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("823b3208-cad8-49e2-b3b2-75387df690d6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8442), null, false, null, null, "Root Cause Analysis", new Guid("1df86816-2842-4941-8710-36822d6240e8") },
                    { new Guid("8271585b-42f5-40c5-baac-015ffb777b0c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8353), null, false, null, null, "BARC Reporting", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("82e9d158-33f6-480d-ace5-5dae139d61ef"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8557), null, false, null, null, "MRC Reporting", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("83197450-c85b-42a5-9d1d-59485c3146d2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7989), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("83ba966b-c6cc-49e8-bb74-ac06a2e61010"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8579), null, false, null, null, "Data Backup", new Guid("7d22672e-a552-4944-a418-d7678717c193") },
                    { new Guid("84d8ebaa-5a4f-429b-bf64-b3321536b3ea"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8289), null, false, null, null, "Direct debit set up and Termination", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("8544e8a2-2a0a-4304-9eba-519d84b809f7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8160), null, false, null, null, "Client Request Processing ", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c") },
                    { new Guid("8551d032-bf96-4847-b740-d6ab984da8a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8498), null, false, null, null, "Drafting Embassy letters ", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("85733995-8ec9-439d-b44e-92e8461fb908"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8466), null, false, null, null, "Data Recovery Steps", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("85c211ae-6440-4c6b-a83a-124768db86a3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7979), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("389e0846-2dfd-4e66-91c7-b7c37a565c70") },
                    { new Guid("861b083a-0901-49f4-81b5-1e92301695f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8450), null, false, null, null, "Risk Management Disclosures", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("8637f710-6282-469b-b80b-9c11289d3ec6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8236), null, false, null, null, "Accounting unit postings / adjsutements", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("86512a6f-bcfc-400b-8214-7c4263cfda2e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8332), null, false, null, null, "Client Communications", new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e") },
                    { new Guid("86ad87d8-1634-40e6-a214-4826839bd050"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8109), null, false, null, null, "Manual matching of inflow into clients account", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("86d24c51-a624-42cc-bffa-87069e7b129f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7825), null, false, null, null, "MRC Reporting", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("872f61c1-90bf-4018-97f3-ab0292b8b5f5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8623), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("23f36ca8-a0ce-49bf-be0c-66366eff3c51") },
                    { new Guid("8750507b-deec-49ed-a650-012426fce453"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8854), null, false, null, null, "DEVOPs Operations (Deployment to Production)", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8") },
                    { new Guid("87846b97-f496-41d3-8cd4-606e6610f219"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7803), null, false, null, null, "Trade call-over", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("87fe618e-7e8c-4532-a35c-30ac4cb7cb75"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8613), null, false, null, null, "Legal Advisory", new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879") },
                    { new Guid("882d1a26-1a16-42ce-8fb3-9a346c892bb3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7864), null, false, null, null, "Unit Transfer", new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1") },
                    { new Guid("889a11ef-6906-4093-8030-d024f090ca10"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8053), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("957f6bf9-1d02-4600-b676-6200eb6c4de3") },
                    { new Guid("89c01b6f-6cbd-4424-8478-442fdf23f985"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8772), null, false, null, null, "Client creation and client mapping", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("89c55abf-279d-4159-8083-c01b98ccde96"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8122), null, false, null, null, "Daily Reconciliation of all Web transactions", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("89cb66c6-0f35-4eaa-909c-3539b0b9a0eb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7944), null, false, null, null, "Manual Collation of inflows and uploads into core application- NAV", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("89fdfe5a-97e1-482d-a740-408e45bf3ac8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8424), null, false, null, null, "Unit Transfer", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819") },
                    { new Guid("8a20843e-3767-4fa2-b4e5-37033a322ba7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8649), null, false, null, null, "Data Backup", new Guid("aa0a3489-560d-4e02-b270-ca08a45d2fcf") },
                    { new Guid("8a69ad50-9357-4ba8-954e-ec57112564e7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8661), null, false, null, null, "Report preparation", new Guid("6cfdabd5-52e6-465b-8cca-5b23aead61be") },
                    { new Guid("8a952ad4-4166-48aa-b312-5a59cbd1a323"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8168), null, false, null, null, "MRC Reporting", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("8ad49b8c-37a9-44ad-b590-0bc7fb40b1d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7886), null, false, null, null, "Portfolio CSCS creation", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("8b034454-0bef-4a9d-a8e3-063dde0bce5e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8150), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("8b5a8cc8-5da6-44e1-b81e-b5f1780692d3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8365), null, false, null, null, "Counterparty Review and Assessment", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("8ba97c3d-58aa-4b6e-a52e-9fb370809a67"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8092), null, false, null, null, "Withdrawal Processing (Portfolio Fund)", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("8bb2a3a3-fbf6-4220-8ff6-0b2fa5440ff0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8570), null, false, null, null, "Business Continuity Management Tests", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("8d002900-6e44-437f-8f95-db0a5afa71ee"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8231), null, false, null, null, "Bank statement upload on AMS and  Fund injection processing on Deluxe", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("8d87d698-53b9-4af9-ade1-858d71bcb6bd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8580), null, false, null, null, "Data Recovery Steps", new Guid("7d22672e-a552-4944-a418-d7678717c193") },
                    { new Guid("8d8f361f-9dd2-4569-95af-e4c63672e933"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7851), null, false, null, null, "Mutual Funds Account Creation", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("8da67f87-fb41-48d6-b6b4-0fac66644a1a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8022), null, false, null, null, "Mutual Funds Account Creation", new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38") },
                    { new Guid("8df8d964-1d5c-4bb9-b46b-3d8d5adfd403"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8607), null, false, null, null, "Statutory Remittance Review", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("8e087d23-7504-49ae-bff2-2dca912f2b88"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8343), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("8e2111db-f481-4f1e-8b51-3119ee7cb42e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7863), null, false, null, null, "Embassy Letter", new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1") },
                    { new Guid("8edcf34c-dcec-47fb-99e8-28c2b3cde2cf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8167), null, false, null, null, "Loss Data Collection", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("8f5d4dd1-df75-4389-a8f9-778614076e2f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8451), null, false, null, null, "BARC Reporting", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("8fd3e59e-0481-4187-8e63-5c6b3e223239"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8482), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("8fe827e9-a0e0-43c8-9172-99cb066853e0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7717), null, false, null, null, "Loss Data Collection", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("90a2a7b5-8eca-4775-ac41-969536f880b5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8510), null, false, null, null, "Account Opening", new Guid("a470f202-ca90-4fc9-8617-358311885a1c") },
                    { new Guid("90d7f561-e34f-47e5-adb1-c8c09aac9aed"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8458), null, false, null, null, "Counterparty Review and Assessment", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("90d95292-7dd9-4505-b7d6-b971ca5ca24a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8560), null, false, null, null, "ALCO Reporting", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("91288523-ae8b-4daf-8245-b9bae19757c0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7841), null, false, null, null, "Counterparty Review and Assessment", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("918bfd3a-7bcd-427e-ac65-b1ca7d002d06"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7913), null, false, null, null, "Dividend Settlement", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("91982f64-e658-41d3-ade5-63b7cc708750"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8831), null, false, null, null, "Simulating Disaster and Recovery", new Guid("a5ab3b91-07f8-47d7-8ad7-3dfdbf005f8e") },
                    { new Guid("92119bb1-9601-4e6a-975e-b5249712db43"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8248), null, false, null, null, "Corporate Action", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("923ad703-4c4a-43d1-9c88-32090ca7718e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7738), null, false, null, null, "Business strategy articulataion", new Guid("42c3cab6-ccbd-452e-8f84-45993337f2b3") },
                    { new Guid("92feb139-f56e-4ef3-b863-6636aa2fbf9a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8850), null, false, null, null, "Statutory Remittance Review", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("93116525-93e5-46a1-b1f0-c1ce6b6f1149"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8555), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("9327b3ac-1785-4f89-95da-a198879512ce"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8812), null, false, null, null, "Manual Collation of inflows and uploads into core application- NAV", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("93334406-6abe-4d69-9b76-d0ccde4db70d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8539), null, false, null, null, "STATUTORY DEDUCTIONS", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("940a0c0b-b2a8-45af-82f7-29b4b2865566"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8395), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("e4789074-ab43-463f-b18f-42606e28db63") },
                    { new Guid("941a5033-b854-4f7a-adfb-811acb27ddcb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8777), null, false, null, null, "Corporate Action", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("944de849-c4e3-41d9-a745-cf6217ccdac5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8372), null, false, null, null, "Data Backup", new Guid("32a964ce-a439-4c80-9a36-f7774706ee32") },
                    { new Guid("948a93a5-999e-4e33-a0a1-877eefdc2c7b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8605), null, false, null, null, "BRD and UAT review", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("94f0925b-553f-4009-b9d9-2288c0935de9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7846), null, false, null, null, "Strategy revision", new Guid("456575f1-a8db-4fd9-885f-8e84e096c860") },
                    { new Guid("9538f5c5-2226-4e3a-aa5f-1ba1a00668f9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8411), null, false, null, null, "Institutional Fund Pricing Review", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("954c81a3-5dc7-423a-9683-64934c211a07"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7901), null, false, null, null, "Receipt of client instruction", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("95c88fef-ce5b-42c7-84c7-79d444cd5ea9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7973), null, false, null, null, "Audit Review", new Guid("389e0846-2dfd-4e66-91c7-b7c37a565c70") },
                    { new Guid("95deac6f-21a3-4570-8c8c-8ff2c4979ba5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8075), null, false, null, null, "Receipt of share certificates and verification documents", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("962a0222-41d4-4994-8c9e-9eb47629d4cc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8629), null, false, null, null, "ALCO Reporting", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("9649ce34-245d-4894-a2f2-86f0e7a07a95"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8641), null, false, null, null, "Systems Maintenance", new Guid("aa0a3489-560d-4e02-b270-ca08a45d2fcf") },
                    { new Guid("967f5403-691a-4051-81f5-9c6f08fe0d72"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7976), null, false, null, null, "Follow Up", new Guid("389e0846-2dfd-4e66-91c7-b7c37a565c70") },
                    { new Guid("96963b90-bdb0-4ca2-8281-f4004669a53d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7820), null, false, null, null, "Statement/Valuation Requests & Quarterly Portfolio Reviews", new Guid("6e7c4307-421c-4f26-9216-a740663cdebd") },
                    { new Guid("96f6dce9-7ca6-41ec-bfd6-b4567d1f997b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8240), null, false, null, null, "Fee set up and fee mapping", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("970f490b-3931-4a4d-9bf7-90f07b8e0812"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8770), null, false, null, null, "Fee set up and fee mapping", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("97e2641e-2a44-4969-ae95-795c6868ec6f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8033), null, false, null, null, "Data Update", new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6") },
                    { new Guid("980067d9-4e45-48b9-8964-edb2f71e65a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7760), null, false, null, null, "Data Update", new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836") },
                    { new Guid("983834af-1157-4976-9108-61ca61b9b592"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8379), null, false, null, null, "Strategy revision", new Guid("9f4432a0-9002-4553-997d-633869423d79") },
                    { new Guid("987d9da2-4bc2-4af6-a9c1-321faa6ebcb3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8037), null, false, null, null, "Client Communications", new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6") },
                    { new Guid("98c36fc0-b52f-4b19-bd78-7a2b35fb7de6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7931), null, false, null, null, "Deactivation of Mobile Number Re-assigned to a Third Party", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("990ab609-a732-479d-a539-5284fa4c0185"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8271), null, false, null, null, "Change of Dividend Mandate", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("990d7ccd-0332-41ad-9f06-bc3bbac0d0d6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8249), null, false, null, null, "Dividend Settlement", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("9a33fe31-5a19-4ead-8c25-3529f3231ed1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8177), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("9a78eab2-2f79-49dc-be0b-930f62ba391d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7793), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("c1beeff0-0f52-40a7-8bd0-9f031ef1110a") },
                    { new Guid("9ab6d779-7cd5-4603-a842-a632436d81eb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8453), null, false, null, null, "Fianacial Risk Review and Reporting", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("9ac34b93-77e3-4b7a-8d34-7b581f4e8039"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8689), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970") },
                    { new Guid("9b67149b-36a8-40f5-8c04-989b1cc7ad6f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7958), null, false, null, null, "Call over", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                    { new Guid("9b7598e2-172f-4f82-a49f-3628292ba698"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8414), null, false, null, null, "BRD and UAT review", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("9c015330-3d50-483b-b378-f0a422cb8560"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8025), null, false, null, null, "Embassy Letter", new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38") },
                    { new Guid("9c608b3b-ef1d-4cf2-b9d9-5d8dc75dacd7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8068), null, false, null, null, "Bank account mapping", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("9c95670d-8d5c-4e70-aaa8-7f7df226bcb4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8524), null, false, null, null, "Asset Disposal", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("9ca8c2f9-954f-4fba-984b-0bf01e8b9cc1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8738), null, false, null, null, "Embassy Letter", new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5") },
                    { new Guid("9d5bafe3-b983-4a00-b631-d335633d03d1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8545), null, false, null, null, "Dispensed goods Invoice", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("9dccb8b3-24c7-4aa5-b0cc-14e3c2efcaa5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8636), null, false, null, null, "New Product Assessment", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("9dd574e1-433b-418d-9cf3-dcaf7a40479a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8250), null, false, null, null, "Portfolio stock reconciliation", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("9e75b303-bef8-4ca9-890e-d8d82fbe9e24"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7749), null, false, null, null, "Unit Transfer", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("9f406662-1e6f-400e-a1e4-f6322c4679d7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8403), null, false, null, null, "Operational Performance Rating", new Guid("65757b71-e2fb-490d-ba49-20e94ee3623d") },
                    { new Guid("9fb27092-ffe8-4127-9457-b40e813cbaaa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7743), null, false, null, null, "Report preparation", new Guid("42c3cab6-ccbd-452e-8f84-45993337f2b3") },
                    { new Guid("9ff7cb3c-1ad0-4e1d-be9e-4c40cb9ab278"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8559), null, false, null, null, "RCSA Process", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("a003b4f6-344c-40b2-8fdc-de09bc234567"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7757), null, false, null, null, "Root Cause Analysis", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("a00e87bc-9ba8-4da1-a8e7-eab2b37530f3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8435), null, false, null, null, "Data Update", new Guid("1df86816-2842-4941-8710-36822d6240e8") },
                    { new Guid("a0159313-8652-48d2-b6ae-6cba897b4956"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8101), null, false, null, null, "EOQ/Dividend Payment", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("a0639e74-b99d-4cba-a812-cf13efa1c7b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8294), null, false, null, null, "Daily Reconciliation of all Web transactions", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("a0756725-5748-4a24-ae96-6af04227cc15"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8045), null, false, null, null, "Regulatory filings", new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663") },
                    { new Guid("a09b9c22-73d1-4bfc-a9fe-78a4fd28716e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8670), null, false, null, null, "Trade call-over", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("a0ceb1e8-84fa-45be-a07b-5cc41bddc0c0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7889), null, false, null, null, "Portfolio, Transactional client, Scheme  withdrwals", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("a1740567-f136-42f5-a760-f596385c0b27"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8697), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("a17fdeb7-1f85-42a1-b3e5-89daf473dace"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8341), null, false, null, null, "Client Communications", new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d") },
                    { new Guid("a18f0434-c770-4942-b37a-7eb735e44a17"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8085), null, false, null, null, "Custodian reconciliation", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("a19c70a3-4f8d-4d71-a50d-7c1edc51dd93"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8529), null, false, null, null, "Reimbursements", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("a1e531fc-d751-4724-a452-aabf2fdc8864"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7795), null, false, null, null, "Audit Review", new Guid("c1beeff0-0f52-40a7-8bd0-9f031ef1110a") },
                    { new Guid("a216df49-3063-41db-8590-9e690425f696"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7843), null, false, null, null, "Business Continuity Management Tests", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("a237535a-9af4-453b-9c15-3459df7df57c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8124), null, false, null, null, "Applications Development/Enhancement", new Guid("e1671ffd-98d2-4063-b883-310378ac972a") },
                    { new Guid("a26d697e-1037-495d-b06a-4555346e043e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7812), null, false, null, null, "Statutory Remittance Review", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("a33fee1e-90c3-4802-83d6-716385a261fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8531), null, false, null, null, "STAFF DISCIPLINARY ISSUES", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("a34c40b3-3647-4d7b-bdc3-5d90339eb4c6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8765), null, false, null, null, "Accounting unit postings / adjsutements", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("a3ad5a17-1d85-4fbe-8bbc-9eeb6e59d4c5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7798), null, false, null, null, "Follow Up", new Guid("c1beeff0-0f52-40a7-8bd0-9f031ef1110a") },
                    { new Guid("a3cf5aa0-60cd-4cea-ad4d-fd5581a90cd0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8162), null, false, null, null, "Real estate asset management", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c") },
                    { new Guid("a45b5e92-701c-435e-8729-07828d8281dc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7847), null, false, null, null, "Business strategy monitoring", new Guid("456575f1-a8db-4fd9-885f-8e84e096c860") },
                    { new Guid("a4a1eb36-d962-4e21-805d-abe27ee38f8f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8654), null, false, null, null, "Business strategy articulataion", new Guid("6cfdabd5-52e6-465b-8cca-5b23aead61be") },
                    { new Guid("a4bc10be-1dff-4a4f-90ea-fb4f9da407e2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8115), null, false, null, null, "Direct debit set up and Termination", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("a4c15601-3574-43f4-ac7e-7f5c6de9b6de"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8333), null, false, null, null, "Root Cause Analysis", new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e") },
                    { new Guid("a5e4d201-a80c-44c5-a5f6-1fbe818f9961"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7954), null, false, null, null, "Daily Movement of posted subscriptions at Bank(Cash Sweep)", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("a6ad7073-eacd-44d8-b017-17f14ddf8117"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8590), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("2324ca19-a743-485a-b49a-d04b5a1ec0a0") },
                    { new Guid("a6d5d437-9e5a-4ff9-8262-c2c0e90a84f6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7752), null, false, null, null, "Client Communications", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("a6d7eebe-265c-42ea-980a-60c19b777fa2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7950), null, false, null, null, "Posting of Buybacks", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("a732fdd6-0d6c-4914-98e1-461481f6b8fb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7968), null, false, null, null, "Data Backup", new Guid("a16649cf-8b89-4027-9628-8af108db66fc") },
                    { new Guid("a73f194d-efa8-44d5-b358-f518445f4106"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8753), null, false, null, null, "Account Opening", new Guid("7116856a-f88c-4bdf-b7d4-92e8e241c8ea") },
                    { new Guid("a7578958-6633-4237-9e5a-11f95c0c6a23"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7764), null, false, null, null, "Unit Transfer", new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836") },
                    { new Guid("a767bf45-31e3-421a-873d-4c5aa613e53e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8077), null, false, null, null, "Inter-Member transfer request", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("a7991138-e3a7-44e1-ad3c-ca15282655a2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8633), null, false, null, null, "MFIC Reporting", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("a839353b-f872-4610-a6cb-50fb09d22c8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8648), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("aa0a3489-560d-4e02-b270-ca08a45d2fcf") },
                    { new Guid("a8eac4d9-e1b7-4cc2-b5db-b15266143ddf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8768), null, false, null, null, "RM creation and mapping ", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("a9a8ca2b-6931-4051-a6a8-17ff7bef6d49"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7963), null, false, null, null, "Systems Maintenance", new Guid("a16649cf-8b89-4027-9628-8af108db66fc") },
                    { new Guid("a9e5f612-4b15-4ce6-bbb6-e210546d94c1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7972), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("389e0846-2dfd-4e66-91c7-b7c37a565c70") },
                    { new Guid("aa3aad3a-d54a-421c-b8a4-b5ee63fffb96"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7787), null, false, null, null, "Applications Development/Enhancement", new Guid("556d5367-6794-4355-974f-e2ebb6447695") },
                    { new Guid("aa94ae4a-450d-4e89-af12-1bba104e6ae8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8235), null, false, null, null, "Portfolio, Transactional client, Scheme  withdrwals", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("ab29dc32-a9ce-4011-b167-fbe5f3c13fe8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8731), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2") },
                    { new Guid("ab384f09-28fc-4b78-8f19-a3bc9feac3c0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7810), null, false, null, null, "BRD and UAT review", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("ab8fe4ac-21df-41a3-b968-b5f83daa936e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7769), null, false, null, null, "Drafting Embassy letters ", new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb") },
                    { new Guid("abd83dd2-107e-4e14-af00-814160c7a175"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8448), null, false, null, null, "ALCO Reporting", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("aca41565-cb6b-4f43-aa36-3d5473248c0d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7916), null, false, null, null, "Transfer of stocks between same client’s portfolios", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("adf6a310-2e73-4db8-9a46-9a3a0b06dbfa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8679), null, false, null, null, "Statutory Remittance Review", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("ae4556d7-79d3-4e0e-8f63-63c4a1863bfd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8749), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739") },
                    { new Guid("ae9e4556-fef2-4979-95cf-8396750adfa5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8130), null, false, null, null, "Simulating Disaster and Recovery", new Guid("e1671ffd-98d2-4063-b883-310378ac972a") },
                    { new Guid("aea8b1fc-dc51-4104-98bf-be9b8cb50734"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8849), null, false, null, null, "User Rights Access Mgt", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("aed801be-58bb-4fa9-b03f-b3cd14d516af"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8078), null, false, null, null, "Unverified returned share certificates", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("aee17616-712e-4184-ad2c-966f0531d093"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8562), null, false, null, null, "Risk Management Disclosures", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("aeeb3e41-c5c5-4a6b-8c86-065bcfb342be"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8817), null, false, null, null, "Initiation of Intra-fund unit transfers", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("af5478af-1386-4e7c-94d6-f6219e76456b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8114), null, false, null, null, "Initiation of Intra-fund unit transfers", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("af5c9f5a-2628-4509-b307-da8fa38bfbc6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8337), null, false, null, null, "Unit Transfer", new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d") },
                    { new Guid("afbbd777-8d41-44db-9657-fc230b4a76d6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8139), null, false, null, null, "Audit Review", new Guid("52ae7cc8-1382-4c45-833a-84e78a2de191") },
                    { new Guid("b0300f47-70ce-4d01-a97e-46125c3a6a88"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7887), null, false, null, null, "Bank statement upload on AMS and  Fund injection processing on Deluxe", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("b0d7ef3b-0dec-4002-a500-5d2ec05ab5a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8729), null, false, null, null, "Unit Transfer", new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2") },
                    { new Guid("b12699a2-de6a-4780-b317-c3760cf982d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8733), null, false, null, null, "Client Communications", new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2") },
                    { new Guid("b1592cc6-d00f-4f2d-8089-dd4d325abc84"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8350), null, false, null, null, "ALCO Reporting", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("b1d1eff5-fef4-4612-8a93-4997c4c68eed"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8750), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739") },
                    { new Guid("b1e10a20-4ddb-4d96-9449-a13a6f28c51d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8734), null, false, null, null, "Root Cause Analysis", new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2") },
                    { new Guid("b1e69e29-a929-4db9-907a-ec2fa1924310"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7927), null, false, null, null, "Unit Transfer", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("b208ed8e-1779-40df-9ed6-349840338fd4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8069), null, false, null, null, "Portfolio creation, System bank account creation, Bank account mapping", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("b20afece-c28f-478a-96d7-fd451181d3ca"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8237), null, false, null, null, "Bank account mapping", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("b2184144-ad2b-42cd-be03-50c558c22628"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8376), null, false, null, null, "Business strategy articulataion", new Guid("9f4432a0-9002-4553-997d-633869423d79") },
                    { new Guid("b21c82dc-0ff7-4238-a615-623cbecebf23"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8049), null, false, null, null, "Account Opening", new Guid("957f6bf9-1d02-4600-b676-6200eb6c4de3") },
                    { new Guid("b2269672-1635-4ab2-98ca-28734fb2175e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7981), null, false, null, null, "Trade call-over", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("b254881b-02ec-4616-bbd9-65c5935a7ef5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8809), null, false, null, null, "AMS pulls transactions from the Bank API", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("b26ba350-276b-40d0-8259-ce6a862f8e11"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8004), null, false, null, null, "Risk Management Disclosures", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("b2a8e5ca-79e4-4a22-9ff2-7ebe528c8ec4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8113), null, false, null, null, "Posting of all verified redemptions and pass for payment", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("b2ec1b67-bc5d-4689-81f0-9c553c74ccc5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8090), null, false, null, null, "Account Onboarding", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("b3a2754c-e47b-482a-9716-da169f84d622"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8526), null, false, null, null, "Process Payments", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("b3c8aa19-08e7-4972-b503-4c755fbce3c3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8766), null, false, null, null, "Bank account mapping", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("b3ce21b8-fe7c-4ba8-a2a0-8968331f6bcc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8713), null, false, null, null, "Corporate strategy development", new Guid("5cf04c21-a4c1-45f2-a80c-9ccd03aec033") },
                    { new Guid("b3e407f8-042b-4a7c-a38a-1e5976de9b77"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8035), null, false, null, null, "Unit Transfer", new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6") },
                    { new Guid("b4a8ed20-2ca3-49dc-9200-1b1b09b875ed"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8335), null, false, null, null, "Data Update", new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d") },
                    { new Guid("b5027f61-e9c8-4ed4-8a31-21a725d5c9ca"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8200), null, false, null, null, "Root Cause Analysis", new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8") },
                    { new Guid("b5e943ae-449a-4d05-8c60-ccabf4b2456c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8553), null, false, null, null, "Store key management", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("b647e6f4-7bd1-418b-9986-eb890e7d74f4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8813), null, false, null, null, "Posting of all matched subscription on NAV", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("b6673b87-6c2e-400a-a057-c102eede6c9b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8516), null, false, null, null, "Production of Branded Materials", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c") },
                    { new Guid("b66f8fec-3397-40b9-889d-3b8e1afaa8bc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8798), null, false, null, null, "Unit Transfer", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("b729edcc-b098-4125-83c5-53d59839ec4c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8847), null, false, null, null, "Fixed Income Trade Review", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") },
                    { new Guid("b7581275-f268-48e0-bf2d-f4d35aca8d95"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8665), null, false, null, null, "Follow Up", new Guid("a77067b1-9217-4a5b-b16d-70e211f22c25") },
                    { new Guid("b7797b6f-65c0-4a3c-bc77-6976da59b6ea"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7853), null, false, null, null, "Data Update", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") },
                    { new Guid("b79f8b72-80ea-48db-ad6d-d3bfdf70bbed"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8027), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38") },
                    { new Guid("b8139e83-7f0a-48ed-9994-3173a2271530"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8012), null, false, null, null, "Counterparty Review and Assessment", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("b824874d-dbaa-4f79-b4fc-46078a8dafc2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8352), null, false, null, null, "Risk Management Disclosures", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("b831f039-eb88-4f9c-a13f-6890e3c62ce7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8272), null, false, null, null, "NFIU Reporting", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("b897efe3-5fd5-44fa-876e-bd0567c5d5b4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8637), null, false, null, null, "Counterparty Review and Assessment", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("b8e74338-21e0-4893-b4cb-0f733427962c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8757), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("7116856a-f88c-4bdf-b7d4-92e8e241c8ea") },
                    { new Guid("b911425e-ba76-4b3e-8648-020d021fef6d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8315), null, false, null, null, "Institutional Fund Pricing Review", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("b9963f45-68a3-4ac5-a672-66aa94c93312"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8081), null, false, null, null, "Dividend Settlement", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("b9e08824-4d41-44cf-875f-b561509b0590"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8346), null, false, null, null, "Loss Data Collection", new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5") },
                    { new Guid("b9f059b5-be85-4cd3-8848-a89c92f6bb9c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8032), null, false, null, null, "Mutual Funds Account Creation", new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6") },
                    { new Guid("ba2671b3-ff2c-4505-9494-60fb140c129e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7800), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("c1beeff0-0f52-40a7-8bd0-9f031ef1110a") },
                    { new Guid("ba4407a8-29df-460b-970f-f46405f3837b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8303), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("d0b29a0f-69c0-42df-8af9-490ebc733c64") },
                    { new Guid("bab16885-c840-4dd0-92be-26d6bcae0386"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8525), null, false, null, null, "Invoicing", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("badd67c6-90c0-4d9b-adda-942104226649"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8313), null, false, null, null, "Trade call-over", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("bae0f64d-5efb-4e17-8ce5-c2c9bf775dbc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8550), null, false, null, null, "Procurement of Supplies and Inventory Update", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("baf7267f-c271-4f3c-b43d-1d29cbc3e32a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8674), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("bba04301-c185-431b-ba20-985d19460f47"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8703), null, false, null, null, "Risk Management Disclosures", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("bc7d9af0-9789-47dc-81c9-c3adfc5e68f8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7735), null, false, null, null, "Business Continuity Management Tests", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("bca53d0b-7b6a-4205-bc9d-567a6897939a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7799), null, false, null, null, "Operational Performance Rating", new Guid("c1beeff0-0f52-40a7-8bd0-9f031ef1110a") },
                    { new Guid("bcf71ac3-b9bf-4165-ad08-c96935f61f57"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8129), null, false, null, null, "Data Recovery Steps", new Guid("e1671ffd-98d2-4063-b883-310378ac972a") },
                    { new Guid("bd89dcde-57eb-4457-814c-8aecbd38f584"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7992), null, false, null, null, "BRD and UAT review", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("bdfa341b-e0b2-477f-b3ab-1e22449e73fd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7742), null, false, null, null, "Quarterly performance review session", new Guid("42c3cab6-ccbd-452e-8f84-45993337f2b3") },
                    { new Guid("be7e474c-2bc6-4b2e-917e-341b45f8ba4a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8219), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11") },
                    { new Guid("c001636c-7d73-490b-b479-98c0a840d8f0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8174), null, false, null, null, "MFIC Reporting", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("c00f98db-9802-46e1-881e-9e4365dbf1d3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7860), null, false, null, null, "Mutual Funds Account Creation", new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1") },
                    { new Guid("c07b15a6-a075-4da4-b78a-8c349fd62b0b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8546), null, false, null, null, "Goods received register", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("c09c5278-844a-471a-842e-f818dfe8a064"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8663), null, false, null, null, "Audit Review", new Guid("a77067b1-9217-4a5b-b16d-70e211f22c25") },
                    { new Guid("c0db589a-b730-4dbe-9394-cce864444577"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8677), null, false, null, null, "BRD and UAT review", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("c1ad9e93-f792-4227-be91-f9c0eda7ce42"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8603), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("c1c4d2fd-491c-404f-a437-9060a34e584d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7957), null, false, null, null, "Reconciliation", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                    { new Guid("c230db9f-1c85-4c18-bc88-8f7310ef0a30"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8687), null, false, null, null, "Regulatory filings", new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970") },
                    { new Guid("c2614c9b-fc93-4d31-b087-25f9cd6c08e7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8578), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("7d22672e-a552-4944-a418-d7678717c193") },
                    { new Guid("c352d61e-1e17-4948-a23d-8e8fea7dea10"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7897), null, false, null, null, "Client creation and client mapping", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("c3b1e2ef-5a09-49c9-a74d-d5e323cad2f4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8171), null, false, null, null, "ALCO Reporting", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("c3fdc550-f817-4542-bc73-4316fc5a8e53"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8166), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("c42581fa-c125-400e-adaa-175311a89b3c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8635), null, false, null, null, "Pledge Review and Approval", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("c477f961-6313-4ad3-b57d-85cce9ab7141"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8736), null, false, null, null, "Data Update", new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5") },
                    { new Guid("c478145c-640a-4225-a3b3-e127fc336f7b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8571), null, false, null, null, "Systems Maintenance", new Guid("7d22672e-a552-4944-a418-d7678717c193") },
                    { new Guid("c48fc700-c609-47c2-acf7-87221e8f9c4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8261), null, false, null, null, "Withdrawal Processing (Portfolio Fund)", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("c4c9cb0c-5f73-431c-9bc6-5ba068403929"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8322), null, false, null, null, "Statutory Remittance Review", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("c5a4e05e-8936-46bc-978e-7c7ffab5e235"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7915), null, false, null, null, "Transfer of portfolio to another party (broker)/Portfolio stock withdrawal", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("c5b9e871-f8e6-46da-ba89-ca3e00347fa9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8682), null, false, null, null, "Contract drafting and reviews", new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970") },
                    { new Guid("c5e64cc2-be3f-4d33-8c3a-aa4bec30a1d3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7956), null, false, null, null, "Daily Reconciliation of all Web transactions", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("c6528414-a321-4813-a382-101310c5d189"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8102), null, false, null, null, "Change of Dividend Mandate", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("c6d08278-b36e-4e60-a2d1-a4124ecbb426"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7822), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("c70c64ee-faaf-4d59-b735-5f927a1adce4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8591), null, false, null, null, "Audit Review", new Guid("2324ca19-a743-485a-b49a-d04b5a1ec0a0") },
                    { new Guid("c79a8647-91d6-46d2-ae3d-c0b38af6d054"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7912), null, false, null, null, "Corporate Action", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("c8cf273a-479f-400f-911b-9f9acd1383cc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8551), null, false, null, null, "Store inventory management", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("c8d07d5e-d60e-47dd-aa7c-98e6e51ed83b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7836), null, false, null, null, "MFIC Reporting", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("c934a091-ee21-4aa5-8a65-d16678253710"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8595), null, false, null, null, "Operational Performance Rating", new Guid("2324ca19-a743-485a-b49a-d04b5a1ec0a0") },
                    { new Guid("c9535bb0-5c0b-47db-8687-06d17ef6329f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8183), null, false, null, null, "Data Update", new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13") },
                    { new Guid("c9602445-a66d-4959-8433-43d10471c02a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8660), null, false, null, null, "Quarterly performance review session", new Guid("6cfdabd5-52e6-465b-8cca-5b23aead61be") },
                    { new Guid("c99269c7-5da5-4cb1-a742-93d501c0e26b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8181), null, false, null, null, "Business Continuity Management Tests", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("ca036b0c-7668-496a-9861-7e590f93e49f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8371), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("32a964ce-a439-4c80-9a36-f7774706ee32") },
                    { new Guid("ca4330ec-5d55-4bdd-8b83-2a7086ad30c8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8291), null, false, null, null, "Memo for Transfer of fund across Bank", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("cab07303-0a19-4dcd-b33c-a9dcb62421d7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7811), null, false, null, null, "User Rights Access Mgt", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("cb5affe1-1af8-46db-a843-7d621583187c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8610), null, false, null, null, "Contract drafting and reviews", new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879") },
                    { new Guid("cb6c9ea1-2bae-422e-b681-474ddbef5cef"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7861), null, false, null, null, "Data Update", new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1") },
                    { new Guid("cba64586-c49f-46c8-ad1f-b16352fed48a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8028), null, false, null, null, "Client Communications", new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38") },
                    { new Guid("cbabf26a-1ac5-4037-aee5-fae4ad8edf50"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8589), null, false, null, null, "Report preparation", new Guid("bba02c89-3bf2-4596-857c-54c4f86e9a27") },
                    { new Guid("cc8819e7-6fc6-439c-8a16-9e96a5565e68"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8667), null, false, null, null, "Operational Performance Rating", new Guid("a77067b1-9217-4a5b-b16d-70e211f22c25") },
                    { new Guid("cca5f9b0-04f9-4774-a1e1-0b481a4fa6c4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8074), null, false, null, null, "Receipt of client instruction", new Guid("9ec38d97-5e77-4410-90fd-30c179766021") },
                    { new Guid("cdfc11c8-804a-4745-8205-437667b581bc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8586), null, false, null, null, "Strategy revision", new Guid("bba02c89-3bf2-4596-857c-54c4f86e9a27") },
                    { new Guid("ce1d0278-4ec3-42e4-86a2-acd0e8447ce0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7874), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31") },
                    { new Guid("ce4361ec-e0a0-479d-a74b-1aaf7f714374"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8011), null, false, null, null, "New Product Assessment", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("ce5888e9-0c1d-42b0-8849-1634b4ba13e2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8098), null, false, null, null, "Estate Transmission - Letter of Administration / Probate", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("ce6e8918-a082-4a77-9c6b-c0f8ec67074c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8549), null, false, null, null, "Community Relationships and Development", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("cf07c4dd-0750-47b8-b20f-951f4ed4d5b4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8265), null, false, null, null, "Standard Embassy Letter", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("cf269fab-2dc9-48ae-b999-b32e562c2c27"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8327), null, false, null, null, "Embassy Letter", new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e") },
                    { new Guid("cff60635-35f7-4c88-9c81-b973d7ea4eb3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8141), null, false, null, null, "Follow Up", new Guid("52ae7cc8-1382-4c45-833a-84e78a2de191") },
                    { new Guid("d0c5ebd2-5a7b-4d4a-9838-f35c6e41612a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8462), null, false, null, null, "Applications Development/Enhancement", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("d21d9b6c-369c-4909-838b-6e3dca700461"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7731), null, false, null, null, "New Product Assessment", new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7") },
                    { new Guid("d22147bb-bf5f-4dad-a469-931f4bfffeae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7770), null, false, null, null, "Legal Advisory", new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb") },
                    { new Guid("d2230972-adb6-4539-aa12-6b55b2bd76dd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7739), null, false, null, null, "Strategy revision", new Guid("42c3cab6-ccbd-452e-8f84-45993337f2b3") },
                    { new Guid("d2460b98-8b09-45f0-87a7-4423a246f1ae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8019), null, false, null, null, "Quarterly performance review session", new Guid("ac2f5e03-e11a-4f64-8439-6dee0012376b") },
                    { new Guid("d4150e24-eb99-4c59-9df8-e521f62cff0e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8316), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("d4abd1cb-f03d-4b2a-b4a9-5e61f14b2361"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8720), null, false, null, null, "Strategy revision", new Guid("5cf04c21-a4c1-45f2-a80c-9ccd03aec033") },
                    { new Guid("d4ae25bc-7f08-48bb-a677-c7cf96c23203"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7917), null, false, null, null, "Custodian reconciliation", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04") },
                    { new Guid("d4dce986-9459-43fe-aeff-fa2fd931d205"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7828), null, false, null, null, "ALCO Reporting", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("d4f6888e-7c3c-47a6-bdd4-01a0636ec073"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7826), null, false, null, null, "RCSA Process", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("d5565dd1-1bf8-4eb5-ac5b-ac7985808207"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8216), null, false, null, null, "Legal Advisory", new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11") },
                    { new Guid("d58fbd72-b83d-4f37-9490-bb06cdd5cc65"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8187), null, false, null, null, "Unit Transfer", new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13") },
                    { new Guid("d6539243-2786-49f4-8483-c66fd0b4a2cd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8172), null, false, null, null, "Risk Management Disclosures", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("d669a6e8-3abd-4b12-a699-5a5caba00805"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7929), null, false, null, null, "Estate Transmission - Letter of Administration / Probate", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("d6c8bbb4-53f9-4241-8587-ed7034bad47e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7988), null, false, null, null, "Institutional Fund Pricing Review", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("d762f21d-ed92-42c0-984a-ef298d7104ee"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8295), null, false, null, null, "Systems Maintenance", new Guid("77635858-f888-45c8-9a6f-df2f5ac50670") },
                    { new Guid("d7782077-9a73-490d-8b25-3e6108592541"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7894), null, false, null, null, "Portfolio creation, System bank account creation, Bank account mapping", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("d79bc59a-33f8-470b-bc21-455534071a7a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8778), null, false, null, null, "Dividend Settlement", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("d7adc19a-70f1-4138-97ad-3d3e270dbb01"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8397), null, false, null, null, "Sanction Sceening on clients", new Guid("e4789074-ab43-463f-b18f-42606e28db63") },
                    { new Guid("d7f4aca9-f7c1-4480-946f-3a50bcca6586"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7797), null, false, null, null, "Investigation", new Guid("c1beeff0-0f52-40a7-8bd0-9f031ef1110a") },
                    { new Guid("d8090422-e3ee-421d-b2f0-04f140dd3123"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7977), null, false, null, null, "Operational Performance Rating", new Guid("389e0846-2dfd-4e66-91c7-b7c37a565c70") },
                    { new Guid("d8942f3f-2506-4fc6-9832-0a04d22e90b9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7814), null, false, null, null, "CSCS Reconciliation", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("d92e5f9f-5f60-4f6a-a8f4-bd598f34619f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7869), null, false, null, null, "Contract drafting and reviews", new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31") },
                    { new Guid("dad06f3c-5e66-4140-8cda-114cfb789684"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8477), null, false, null, null, "Audit Review", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("dae17fa2-bf6b-464d-a7ab-e01aaed4b617"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7888), null, false, null, null, "Foreign exchnage upload. Price and rates upload (Bloomberg prices, FMDQ, NGX, FMAN, NASD)", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("daf080de-f040-47d5-bd0c-f59c00554551"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8471), null, false, null, null, "Strategy revision", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75") },
                    { new Guid("db7ee808-5d5e-430c-8bcd-b0b6fd2e923f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8671), null, false, null, null, "Mutual Fund Pricing Review", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("dbcda5aa-0651-4a63-8257-b2b2ea8d1be8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8375), null, false, null, null, "Corporate strategy development", new Guid("9f4432a0-9002-4553-997d-633869423d79") },
                    { new Guid("dbd5d7a4-6cd1-466a-8682-6e41909bd9e7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8438), null, false, null, null, "Unit Transfer", new Guid("1df86816-2842-4941-8710-36822d6240e8") },
                    { new Guid("dbebf7e5-c84b-43b4-ba9c-b461d06226ce"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7999), null, false, null, null, "Loss Data Collection", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("dc39c6d4-5247-49b2-a581-9941f04896f7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7871), null, false, null, null, "Legal Advisory", new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31") },
                    { new Guid("dc504257-bcd3-4733-9feb-83cfd4088d28"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8373), null, false, null, null, "Data Recovery Steps", new Guid("32a964ce-a439-4c80-9a36-f7774706ee32") },
                    { new Guid("dca066aa-0c5c-4742-9880-c46af12fbfd4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8230), null, false, null, null, "Portfolio CSCS creation", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("dcde2d3c-5d42-426f-80e9-352affba2f26"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7875), null, false, null, null, "Drafting of Minutes and other post meeting documents/Correspondence", new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31") },
                    { new Guid("dd32ab96-1ab8-4c00-87d5-90fea082c13b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8638), null, false, null, null, "Business Continuity Management Tests", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("dd6062cb-cfd1-4cd4-a404-08f11511b7a6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8722), null, false, null, null, "Business strategy monitoring", new Guid("5cf04c21-a4c1-45f2-a80c-9ccd03aec033") },
                    { new Guid("dd6a690a-2866-4503-b89b-f74861a21e29"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8182), null, false, null, null, "Mutual Funds Account Creation", new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13") },
                    { new Guid("dd744fbf-faec-40ec-9a3e-a98af77a7a27"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8229), null, false, null, null, "Stock & Institution creation, Issuer Creation, Mutual fund Creation", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("ddd67f9e-6308-4e61-ad36-9fe998a41b8c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8532), null, false, null, null, "TOTAL REWARDS", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("de613895-b32e-4d00-8852-dac974d2d70d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7895), null, false, null, null, "RM creation and mapping ", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("de7d3611-3d63-4e08-bca2-d011149bf7a0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7946), null, false, null, null, "Posting of all verified redemptions and pass for payment", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("de8a29f4-65db-46fd-91cc-34899401b92e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8038), null, false, null, null, "Root Cause Analysis", new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6") },
                    { new Guid("de927edd-8485-4d8d-b7c1-d5104dcd2fea"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8779), null, false, null, null, "Portfolio stock reconciliation", new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1") },
                    { new Guid("dedc9df9-a631-4599-84d7-d687cd81aad8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8050), null, false, null, null, "Filing of Regulatory Returns", new Guid("957f6bf9-1d02-4600-b676-6200eb6c4de3") },
                    { new Guid("df10b201-3e41-45a4-98b6-1b5827ddbda8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8399), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("65757b71-e2fb-490d-ba49-20e94ee3623d") },
                    { new Guid("df245373-3b54-43de-8ecd-593e4e92c112"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8173), null, false, null, null, "BARC Reporting", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("e000aa59-d4d9-41b4-b743-41edace821a0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8440), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("1df86816-2842-4941-8710-36822d6240e8") },
                    { new Guid("e038f73d-c33b-49eb-9b93-5eb18a1de448"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8491), null, false, null, null, "User Rights Access Mgt", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("e0bf9baa-7fbd-4341-bf8b-9a0e1d3e9e50"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7823), null, false, null, null, "Loss Data Collection", new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32") },
                    { new Guid("e0cff931-4b61-4de3-a72e-6bf5ed2b91e0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7780), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("2e1919c1-fdae-4023-b602-6c3584f2b95b") },
                    { new Guid("e0d7dbed-a941-4dc4-ba0e-66c579ba7523"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8688), null, false, null, null, "Coordination of Boarding and Committee Meetings", new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970") },
                    { new Guid("e123c8f0-a041-4e17-b95c-f87a74104f15"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8221), null, false, null, null, "General secretarial activities", new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11") },
                    { new Guid("e1f6e867-d02c-4f60-a2c5-459208454175"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8714), null, false, null, null, "Business strategy articulataion", new Guid("5cf04c21-a4c1-45f2-a80c-9ccd03aec033") },
                    { new Guid("e207788e-f82a-4d60-b49e-c68e859331ab"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7786), null, false, null, null, "Systems Maintenance", new Guid("556d5367-6794-4355-974f-e2ebb6447695") },
                    { new Guid("e29b3d10-dc10-486d-b471-79d74c3fb10c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7802), null, false, null, null, "Cash call-over", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("e2cf929f-47bc-4585-bf4f-35d1c8629892"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7879), null, false, null, null, "Filing of Regulatory Returns", new Guid("9085fd66-97e2-4f6f-91c1-84fa719168c7") },
                    { new Guid("e335dbca-d275-4869-9139-8565cff84fd8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8632), null, false, null, null, "BARC Reporting", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("e34781a6-3bf6-472d-b0dc-769148a884b5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8198), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8") },
                    { new Guid("e3995255-8641-425a-8127-d61c18548de6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8191), null, false, null, null, "Root Cause Analysis", new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13") },
                    { new Guid("e41fa383-ec10-4875-ad08-a261a1140abd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8245), null, false, null, null, "Receipt of share certificates and verification documents", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("e429b85e-2c39-4702-a6fe-bb85a8598feb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8413), null, false, null, null, "Fixed Income Trade Review", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("e45b21f7-4d05-4adc-8df8-a821a4aeedfd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8486), null, false, null, null, "Mutual Fund Pricing Review", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("e4663342-b59a-444c-b479-26195176ce74"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7936), null, false, null, null, "NFIU Reporting", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("e54e7fcc-9e8f-429f-9087-e7fded0f5eaf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8496), null, false, null, null, "CSCS Reconciliation", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("e55d92da-38d1-492e-989f-dbff12b49f6c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7781), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("2e1919c1-fdae-4023-b602-6c3584f2b95b") },
                    { new Guid("e55f2812-8d2f-43ad-b18b-a9d638d9e602"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8569), null, false, null, null, "Counterparty Review and Assessment", new Guid("5ec15a12-324e-429a-87d7-af5b945a4859") },
                    { new Guid("e5706c6d-d2da-461f-aa9e-156642fdefab"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8224), null, false, null, null, "Filing of Regulatory Returns", new Guid("985b91e0-b7c5-4521-8c9a-d312a250d497") },
                    { new Guid("e5d571cb-1b35-4c54-9f98-aa1221ed474c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7996), null, false, null, null, "CSCS Reconciliation", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("e6082136-d018-4849-9904-a4b139a9d367"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8323), null, false, null, null, "Daily Teams Call Over", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("e611d18e-66fa-4caf-a955-a4511db3583b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7891), null, false, null, null, "Bank account mapping", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("e64cf708-ed94-4ba7-bc41-76a607758db6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8409), null, false, null, null, "Mutual Fund Pricing Review", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("e6c5ae09-c182-4bd6-8ae1-f819d3bbf03e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8622), null, false, null, null, "Due Diligence on Clients and Vendors", new Guid("23f36ca8-a0ce-49bf-be0c-66366eff3c51") },
                    { new Guid("e6cb1506-7f77-4de6-abb7-6963f3e28ce1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8151), null, false, null, null, "Fixed Income Trade Review", new Guid("bddcf236-c134-41a2-9946-02a335f9b53d") },
                    { new Guid("e7191f13-46e9-4f68-b831-a3ea4467773c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8443), null, false, null, null, "Risk event reporting on the oprisk manager", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("e739617c-24d3-4064-86b8-bcbcf43a059d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8662), null, false, null, null, "Development of Annual Audit Plan (IA Plan)", new Guid("a77067b1-9217-4a5b-b16d-70e211f22c25") },
                    { new Guid("e84729d2-c9fb-4b0d-aa35-851773785881"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8368), null, false, null, null, "Systems Maintenance", new Guid("32a964ce-a439-4c80-9a36-f7774706ee32") },
                    { new Guid("e8852133-a81a-4d81-bc10-22897c577e6c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7924), null, false, null, null, "Redemption Processing - Verification (Mutual Fund)", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("e8a39224-546c-4ec7-8cc7-b46a676a3ad0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7850), null, false, null, null, "Report preparation", new Guid("456575f1-a8db-4fd9-885f-8e84e096c860") },
                    { new Guid("e8fc94bf-f078-4cf1-a7b0-09a2d72cc9e0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8193), null, false, null, null, "Data Update", new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8") },
                    { new Guid("e909b713-fbdf-4bff-84a1-0e6aa0a4df74"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8642), null, false, null, null, "Applications Development/Enhancement", new Guid("aa0a3489-560d-4e02-b270-ca08a45d2fcf") },
                    { new Guid("e9458afa-7652-4971-80f7-cb216b79a0c8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8488), null, false, null, null, "Portfolio Stock Account Reconciliation", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2") },
                    { new Guid("e9bcb9b4-ddaa-40eb-a0cf-ec17989192ec"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8275), null, false, null, null, "Sanction Screening", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("ea4e5d9b-bc59-45fc-ba75-2d163041fd46"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8239), null, false, null, null, "RM creation and mapping ", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("eae5a262-3628-4d06-a3a2-cc92a8614c2f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8277), null, false, null, null, "AMS automatch transactions with membership ID and integrates to NAV", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("eb0f3b05-6b63-40c6-a441-448f0272210a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8683), null, false, null, null, "Drafting Embassy letters ", new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970") },
                    { new Guid("eb5bd3f6-de76-428d-9eeb-dd6ac6b59c0a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8834), null, false, null, null, "Investigation", new Guid("b84c6b8d-5fe4-4e4a-9143-16e25509bfb5") },
                    { new Guid("eba13e0c-0770-42e7-ab80-587a4c2c5341"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7791), null, false, null, null, "Simulating Disaster and Recovery", new Guid("556d5367-6794-4355-974f-e2ebb6447695") },
                    { new Guid("ebba0282-966a-4b3e-9abb-2c8ff8079a8e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8460), null, false, null, null, "Systems Maintenance", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("ebd02a7e-baf7-4203-9d32-a2ebff87424e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8521), null, false, null, null, "Budget and Planning", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("ebdeff1f-04db-4eaa-ac24-7cf232e2cf8e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7941), null, false, null, null, "AMS automatch transactions with membership ID and integrates to NAV", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a") },
                    { new Guid("ec5b7426-ad3e-4c34-8788-2c6c5729859e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8013), null, false, null, null, "Business Continuity Management Tests", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("ec5f11c5-469b-4cba-a61f-6f13713ecb09"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8764), null, false, null, null, "Portfolio, Transactional client, Scheme  withdrwals", new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a") },
                    { new Guid("ec9194bd-d2ce-4b08-9904-f92f2e2b63b9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8673), null, false, null, null, "Institutional Fund Pricing Review", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("ed0e9daf-cb2b-4705-aa2a-a5ec35047803"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8675), null, false, null, null, "Fixed Income Trade Review", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("ed64dd0e-6403-4507-9dad-b3cc359e454d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7980), null, false, null, null, "Cash call-over", new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0") },
                    { new Guid("edc334b7-9856-4a2c-beb2-4ab3fe708bd3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7748), null, false, null, null, "Embassy Letter", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("edc831e9-3ffc-44ed-ba91-cb71bada183c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8726), null, false, null, null, "Mutual Funds Account Creation", new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2") },
                    { new Guid("edc8bb7e-a7a7-426b-8208-3b1279524d87"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8170), null, false, null, null, "RCSA Process", new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0") },
                    { new Guid("ee019e5a-f668-4408-ad38-bbaf11600efa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8381), null, false, null, null, "Quarterly performance review session", new Guid("9f4432a0-9002-4553-997d-633869423d79") },
                    { new Guid("ee277731-31f3-410f-ac70-fa487aec8539"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8833), null, false, null, null, "Audit Review", new Guid("b84c6b8d-5fe4-4e4a-9143-16e25509bfb5") },
                    { new Guid("ee81471c-a708-421f-81af-24851932457f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8748), null, false, null, null, "Regulatory filings", new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739") },
                    { new Guid("eeb16967-8f98-493d-a34d-236a1b07f38d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8405), null, false, null, null, "Board Audit and Risk Management Committee (BARC) Reporting", new Guid("65757b71-e2fb-490d-ba49-20e94ee3623d") },
                    { new Guid("eec44653-40c8-4a1e-9a05-ea647c4bc845"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7890), null, false, null, null, "Accounting unit postings / adjsutements", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111") },
                    { new Guid("eed4d211-0559-4da3-98d1-8e748e362fd3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8091), null, false, null, null, "Redemption Processing - Verification (Mutual Fund)", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("ef5f291b-29c7-4488-8fbe-b1ad8f4f4691"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8262), null, false, null, null, "Record Update", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("ef8f482d-9c13-4995-a4c5-c49d32a5fe8a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8540), null, false, null, null, "Staff and Visitors Identification", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("efbc66e9-df95-4905-b80a-b5ea5b15b900"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8416), null, false, null, null, "Statutory Remittance Review", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("f0091e03-0266-419c-b174-074f7ed3dbc9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8123), null, false, null, null, "Systems Maintenance", new Guid("e1671ffd-98d2-4063-b883-310378ac972a") },
                    { new Guid("f012b950-604d-4ab5-8bf9-9aa76d3c40be"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8094), null, false, null, null, "Unit Transfer", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("f1347f80-385d-4b7f-b899-da1addd6acd0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8694), null, false, null, null, "SEC Registration of Sponsored individuals/Transfers and Applications", new Guid("4221d035-01ed-4439-8829-d9b73f9e5a4b") },
                    { new Guid("f13bd93d-29d7-4bdd-94b1-7001afd7fb0b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8499), null, false, null, null, "Legal Advisory", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1") },
                    { new Guid("f149edd4-1139-4dea-b65a-4af14c8021f8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8244), null, false, null, null, "Receipt of client instruction", new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc") },
                    { new Guid("f1a4f65d-d2fc-4628-966b-814f02600bcc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7934), null, false, null, null, "EOQ/Dividend Payment", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("f20771e2-1f26-41fd-a876-952226ae776d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8618), null, false, null, null, "Account Opening", new Guid("23f36ca8-a0ce-49bf-be0c-66366eff3c51") },
                    { new Guid("f265dce4-dc72-4734-b3f1-75c53bd51e9a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8470), null, false, null, null, "Business strategy articulataion", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75") },
                    { new Guid("f2cb6d2a-b9eb-4c1e-9772-38425cfac2e3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8543), null, false, null, null, "Scrutiny of all entrants", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72") },
                    { new Guid("f2d149de-48e9-4111-9cde-e2e17bca6900"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8334), null, false, null, null, "Mutual Funds Account Creation", new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d") },
                    { new Guid("f335638e-4df4-4fb0-b765-f61e393b589b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8017), null, false, null, null, "Strategy revision", new Guid("ac2f5e03-e11a-4f64-8439-6dee0012376b") },
                    { new Guid("f33e565a-c05f-42b4-808c-785033828b81"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8021), null, false, null, null, "Report preparation", new Guid("ac2f5e03-e11a-4f64-8439-6dee0012376b") },
                    { new Guid("f3633a7c-6294-4a2b-9f2b-57560c8b7ee2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8120), null, false, null, null, "Goal-related Transactions", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("f383e749-84f7-4fe4-98dd-bcfcfd939391"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8522), null, false, null, null, "Bank Reconciliation", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec") },
                    { new Guid("f3ab802d-2c23-40b2-8856-eda6eacae739"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8306), null, false, null, null, "Investigation", new Guid("d0b29a0f-69c0-42df-8af9-490ebc733c64") },
                    { new Guid("f3b6d572-fac9-4d68-baac-580b8459ac12"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8105), null, false, null, null, "AMS pulls transactions from the Bank API", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("f3bc25e6-fd45-40df-bb9f-9c56159e29a7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7925), null, false, null, null, "Withdrawal Processing (Portfolio Fund)", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("f3c24571-d518-429f-8c8f-244ebe978a2a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7750), null, false, null, null, "Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5") },
                    { new Guid("f41ba8ea-3e94-45a5-9081-e24876a906ae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8407), null, false, null, null, "Trade call-over", new Guid("53d0cdd2-2aca-417f-ad11-92364253defd") },
                    { new Guid("f4daabb0-8945-4219-8dcd-c1f26339581e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8202), null, false, null, null, "Business strategy articulataion", new Guid("444a03bb-a3d4-4cec-a76c-eeabda66003a") },
                    { new Guid("f4f3b798-53fd-42de-8fe8-91b74333294a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7806), null, false, null, null, "Institutional Fund Pricing Review", new Guid("c8ba310f-753d-4317-bce6-1559fb079142") },
                    { new Guid("f5947b64-dd0c-4799-b966-1921f3e004b4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8067), null, false, null, null, "Accounting unit postings / adjsutements", new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6") },
                    { new Guid("f5bf9265-8268-454e-9e4b-e64fff8d5f13"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8264), null, false, null, null, "Unit Transfer", new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085") },
                    { new Guid("f5e7472a-43fb-4df7-9046-ce6d79ee57f9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7962), null, false, null, null, "Valuation and pricing review, EOD activities review", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                    { new Guid("f658b23e-dfa5-41c8-a954-f9d2d2523d87"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8014), null, false, null, null, "Corporate strategy development", new Guid("ac2f5e03-e11a-4f64-8439-6dee0012376b") },
                    { new Guid("f72981c2-8da1-4503-a902-de0e9a3f8655"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8044), null, false, null, null, "Legal Advisory", new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663") },
                    { new Guid("f777e591-641c-4d59-a0d8-42ae6fa8d719"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8125), null, false, null, null, "Planning, Implementing and Closing IT Projects", new Guid("e1671ffd-98d2-4063-b883-310378ac972a") },
                    { new Guid("f7937455-47ab-4747-81aa-f59bcf6cf62d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8801), null, false, null, null, "Deactivation of Mobile Number Re-assigned to a Third Party", new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9") },
                    { new Guid("f7b6e141-0b61-4b8b-adfa-358529d56a3c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8201), null, false, null, null, "Corporate strategy development", new Guid("444a03bb-a3d4-4cec-a76c-eeabda66003a") },
                    { new Guid("f7d86282-7de2-47b6-9705-0bac5a3547b5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8631), null, false, null, null, "Risk Management Disclosures", new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22") },
                    { new Guid("f82816fd-7099-4ecd-8235-2c3762b63777"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8001), null, false, null, null, "MRC Reporting", new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc") },
                    { new Guid("f86db9bc-5cf9-4749-97a8-2d1101b1e148"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8746), null, false, null, null, "Drafting Embassy letters ", new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739") },
                    { new Guid("f8d33c9e-1efc-45b1-975e-5bc4382a3220"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8279), null, false, null, null, "Manual Collation of inflows and uploads into core application- NAV", new Guid("16bedab4-1eb0-484a-9845-e1581085f146") },
                    { new Guid("f8f64547-4c5e-4be0-8472-52f0413f0c61"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8701), null, false, null, null, "RCSA Process", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("f8fb887d-bac4-4ea5-91c9-ded4b1090223"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8199), null, false, null, null, "Client Communications", new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8") },
                    { new Guid("f9bf2296-ecd8-4164-9427-4d53f4deb110"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8116), null, false, null, null, "Posting of Buybacks", new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719") },
                    { new Guid("fa7d677a-777f-4ac2-aa3c-a876088d733a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8374), null, false, null, null, "Simulating Disaster and Recovery", new Guid("32a964ce-a439-4c80-9a36-f7774706ee32") },
                    { new Guid("fa7da3bc-8afc-4b7b-9ca8-4036716892ae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8669), null, false, null, null, "Cash call-over", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("fac5618e-69a5-4ddb-8cab-2141aea0c2bd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8467), null, false, null, null, "Simulating Disaster and Recovery", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                    { new Guid("faee37d1-964a-45be-a1af-c34473953224"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8609), null, false, null, null, "CSCS Reconciliation", new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538") },
                    { new Guid("fb006463-95bc-4963-a976-38447abfb093"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8189), null, false, null, null, "Client Communications", new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13") },
                    { new Guid("fb7a6076-71db-4d7f-bfe0-cee7ecec9058"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8234), null, false, null, null, "Foreign exchnage upload. Price and rates upload (Bloomberg prices, FMDQ, NGX, FMAN, NASD)", new Guid("01ac6f97-9040-439b-abd4-77c79f873d79") },
                    { new Guid("fbae5c2a-d3d2-47ce-8bf7-3776c6832fb3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8743), null, false, null, null, "Root Cause Analysis", new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5") },
                    { new Guid("fbbfe4ec-452d-4fb2-a2e9-b6a5dc31f77a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8380), null, false, null, null, "Business strategy monitoring", new Guid("9f4432a0-9002-4553-997d-633869423d79") },
                    { new Guid("fbc466a9-75ed-41b1-ac2a-fc032026fbb5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7923), null, false, null, null, "Account Onboarding", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12") },
                    { new Guid("fc497b1d-8574-4bd1-bf63-1b9e1ea374e2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8447), null, false, null, null, "RCSA Process", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },
                    { new Guid("fcad4f0e-49f1-4564-ad74-49fbe66d285a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8822), null, false, null, null, "Daily Movement of posted subscriptions at Bank(Cash Sweep)", new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5") },
                    { new Guid("fce4a99d-4070-4b09-9519-6439deb364cd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8319), null, false, null, null, "BRD and UAT review", new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2") },
                    { new Guid("fd681dc5-3a55-4964-aa9a-4c2b18694b56"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8702), null, false, null, null, "ALCO Reporting", new Guid("003ed424-1724-44b1-bcb1-924abb94e338") },
                    { new Guid("fe3fc777-80be-4cac-b4fc-eee247a13221"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8104), null, false, null, null, "Sanction Screening", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf") },
                    { new Guid("fe3fe6c0-515d-4ef4-a62e-c45c48e2bc01"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8534), null, false, null, null, "PERFORMANCE APPRAISAL", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a") },
                    { new Guid("fe68db50-5da8-444d-8060-249c525db3e2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(7768), null, false, null, null, "Contract drafting and reviews", new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb") },
                    { new Guid("febedf95-2e84-4c89-8647-d41a94cfb566"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8480), null, false, null, null, "Operational Performance Rating", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a") },
                    { new Guid("ff23b2cd-2787-4d84-87cf-d09407406a7b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8681), null, false, null, null, "CSCS Reconciliation", new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7") },
                    { new Guid("ff36878d-9473-499f-b367-512ed45bf09b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8728), null, false, null, null, "Embassy Letter", new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2") },
                    { new Guid("ff600d52-7435-4009-9d2e-7b1a8fc45646"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 439, DateTimeKind.Utc).AddTicks(8848), null, false, null, null, "BRD and UAT review", new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21") }
                });

            

            

            

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("007e1744-112d-4126-90a3-68767d716c23"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8866), null, "phoebe.ohiembor@arm.com.ng", false, null, null, "Phoebe Ohiembor", "Information Technology", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("01a681f7-e570-41e9-953f-b55649caa3fb"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8973), null, "adetayo.adebiyi@arm.com.ng", false, null, null, "Adetayo Adebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("046a520e-daef-41b6-97bd-be8b29f34211"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9018), null, "temitope.akinola@arm.com.ng", false, null, null, "Temitope Akinola", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("10dbd193-eeb4-4423-b696-5468dabc40d9"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8907), null, "raymond.akorah@arm.com.ng", false, null, null, "Raymond Akorah", "ARM Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("10f181a3-91be-41fd-bd45-b93cddcad914"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9042), null, "olawale.bakir@arm.com.ng", false, null, null, "Olawale Bakir", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("18586789-113d-4d94-8054-fd09c237f238"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9025), null, "lincoln.ogigai@arm.com.ng", false, null, null, "Lincoln Ogigai", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("1cec6e8b-56e2-4e5b-ab45-c337b2173141"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8983), null, "mounir.bouba@arm.com.ng", false, null, null, "Mounir Bouba", "Investment Managment", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("1e922e6f-fcde-4cb9-aa79-dfc44efc32ef"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9024), null, "kingsley.ottah@arm.com.ng", false, null, null, "Kingsley Ottah", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("1eaeec8c-d596-4173-9c45-dd9dc2a1abf5"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9057), null, "olabisi.adesina@arm.com.ng", false, null, null, "Olabisi Adesina", "Legal and Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("1fd61362-e3be-4644-9382-70b4b9529de6"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8991), null, "anuoluwapo.sebanjo@arm.com.ng", false, null, null, "Anuoluwapo Sebanjo", "Corporate Strategy", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("210fb09d-6bf1-4d99-8bab-d6f4263f5799"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8898), null, "nnamdi.okeke@arm.com.ng", false, null, null, "Nnamdi Okeke", "ARM Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("2520bef2-ed4c-4eef-ae1b-d87ca8e0a409"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8882), null, "akpesiri.kodu@arm.com.ng", false, null, null, "Akpesiri Kodu", "Customer Experience", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("26180984-e4e6-4d30-9c70-80d2861698b2"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8927), null, "vwede.edah@arm.com.ng", false, null, null, "Vwede Edah", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("28ce6fc4-2f2c-4579-975d-6e4c2acd7167"), "ARM Agricbusiness Fund Manager Ltd", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8876), null, "david.akinboade@arm.com.ng", false, null, null, "David Akinboade", "RFL", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("2a608c13-2919-4f72-94a5-626573e5e26f"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8926), null, "Rotimi.Olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("2aacffa1-aa73-4b41-a29a-46d489bbf1b5"), "ARM Harith Infracstrure Investement Limited", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8961), null, "tariye.gbadegesin@arm.com.ng", false, null, null, "Tariye Gbadegesin", "ARM Harith Infrastructure Investment Ltd", new Guid("44fe054d-83dd-41da-b90a-a53631af453d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("300a9d0f-6f69-4fae-9ef5-d5f1592ea4f0"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8844), null, "chukwuebuka.obieri@arm.com.ng", false, null, null, "Chukwuebuka Obieri", "Risk management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("306f67cb-70ac-4177-9fcb-f007d94a94db"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9005), null, "gbenga.sonubi@arm.com.ng", false, null, null, "Gbenga Sonubi", "Operations,Financial Control", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("31f55a02-b900-462d-a7f0-4ac283e514d9"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9016), null, "stephanie.gber@arm.com.ng", false, null, null, "Stephanie Gber", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("322d1bd5-6482-4c95-ac14-182ad3d5b6fc"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9000), null, "james.agu@arm.com.ng", false, null, null, "James Agu", "Operations Control", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("35b9869f-172e-46c6-98a4-7dc7880f74da"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8869), null, "ubi.torsam@arm.com.ng", false, null, null, "Ubi Torsam", "Marketing and Corporate Communications", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("36e3e1bb-501a-44f3-b9b5-b2c90b5b48db"), "ARM Agricbusiness Fund Manager Ltd", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8875), null, "Hassan.AdeObafemi@arm.com.ng", false, null, null, "Hassan AdeObafemi", "RFL", new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("383edb3e-8ba1-4f19-8c74-0dd2d453e0ed"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8956), null, "lincoln.ogigai@arm.com.ng", false, null, null, "Lincoln Ogigai", "Compliance", new Guid("a470f202-ca90-4fc9-8617-358311885a1c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("3b0c3dfe-cd9d-4455-9773-caadf4065395"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8951), null, "rasheed.adebola@arm.com.ng", false, null, null, "Rasheed Adebola", "WRM (Lagos)", new Guid("500fc670-2f14-4786-9092-f7f82b8ae507"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("3c96b599-f537-4c27-a109-4f136bda37f1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8872), null, "ndubuisi.anya@arm.com.ng", false, null, null, "Ndubuisi Anya", "WRM (PortHarcourt)", new Guid("80245081-74bc-4124-87f5-d6008b28706b"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("41c5eac9-bc9c-433f-8d2d-47e6ea279fc0"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8976), null, "itunu.olatunde-folaji@arm.com.ng", false, null, null, "Itunu Olatunde-Folaji", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("450e9818-ee59-46c5-8914-30a1803ba34b"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8923), null, "Ezekiel.solomon@arm.com.ng", false, null, null, "Ezekiel Solomon", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("4b50b8d1-7e5f-4683-9caf-e0b9e481ea25"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8867), null, "Ethan.Okwara@arm.com.ng", false, null, null, "Ethan Okwara", "Marketing and Corporate Communications", new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("518b58b2-01e4-4619-a456-1706ad28f43e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9011), null, "oluyemi.omodayo@arm.com.ng", false, null, null, "Oluyemi Omodayo", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("51dbd356-3fdd-44c2-8c59-df75c12463af"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8919), null, "olugbenga.ajigbotafe@arm.com.ng", false, null, null, "Olugbenga Ajigbotafe", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("54a0260a-19d4-4236-b3bc-9e537dc41195"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8975), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("557e514f-2a23-4867-b91e-85a020db43fe"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9058), null, "kiadum.nwakoh@arm.com.ng", false, null, null, "Kiadum Nwakoh", "Legal and Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("56c5025f-2b5f-423b-9f3d-97c79c0eda8a"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9044), null, "babatunde.osho@arm.com.ng", false, null, null, "Babatunde Osho", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("5afba47c-4381-4be1-b082-dfe887e53da1"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8985), null, "chukwufumnanya.chizea@arm.com.ng", false, null, null, "Chukwufumnanya Chizea", "Investment Managment", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("5b852c8e-d62f-45fd-9ec1-d708d8030b7d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9037), null, "evelyn.nwogu@arm.com.ng", false, null, null, "Evelyn Nwogu", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("5deb0b02-51f7-49a1-8435-8f99be1c5b1f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8988), null, "raphael.emenyonu@arm.com.ng", false, null, null, "Raphael Emenyonu", "Retail Sales", new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("5e54f2ae-a4b8-4fe4-86c5-c0174bcfa169"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9027), null, "ramond.akorah@arm.com.ng", false, null, null, "Ramond Akorah", "Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("627a08eb-a2d4-4de3-bc88-65ec07bdefe8"), "ARM Harith Infracstrure Investement Limited", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8963), null, "oyedele.oyinbojuni@armharith.com", false, null, null, "Oyedele Oyinbojuni", "ARM Harith Infrastructure Investment Ltd", new Guid("44fe054d-83dd-41da-b90a-a53631af453d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("62fa4f97-1fb8-4630-a06c-08e002a00e87"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8958), null, "rotimi.olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Research", new Guid("a6409616-e559-4ff8-a877-0925be18ff3d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("6309d084-3788-46e6-b752-40600cc1a48d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8848), null, "iwasam.elemi@arm.com.ng", false, null, null, "Iwasam Elemi", "Risk management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("64b41e75-ae89-48ed-82e3-b82854e65427"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8901), null, "Ibukun.Ajose@arm.com.ng", false, null, null, "Ibukun Ajose", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("653b7bf8-b903-4608-9b1d-c81ea64fb712"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8892), null, "bimbo.moses@arm.com.ng", false, null, null, "Bimbo Moses", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("65b78319-1a78-415f-95c6-04441ea485b0"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8864), null, "Olayemi.Toye@arm.com.ng", false, null, null, "Olayemi Toye", "Information Technology", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("670b56b4-0a26-4d0a-ae76-cffd591b6f35"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8990), null, "hamed.omotayo@arm.com.ng", false, null, null, "Hamed Omotayo", "Retail Sales", new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("69b4b5b8-aa26-48b7-ab80-011824fa244c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8968), null, "isaac.elakhe@arm.com.ng", false, null, null, "Isaac Elakhe", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("69d6d740-1075-434f-b917-ee6b0cec8247"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8858), null, "james.ewah@arm.com.ng", false, null, null, "James Ewah", "WRM (Abuja)", new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("70acee64-944d-43d2-a606-5fc1960a4208"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8930), null, "Olaoluwa.Omolayole@arm.com.ng", false, null, null, "Olaoluwa Omolayole", "Corporate Transformation", new Guid("850b308d-bef3-41ad-b812-413b868e7621"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("722ee4c9-e518-4cd1-b7c1-790a840bd4a9"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9051), null, "joy.oyekan@arm.com.ng", false, null, null, "Joy Oyekan", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("747b515e-9bd9-4387-a587-74e8125265f6"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8996), null, "gbeminiyi.onipede@arm.com.ng", false, null, null, "Gbeminiyi Onipede", "HoldCo Sales", new Guid("772f854e-c9f6-4428-bad1-53db881e28bb"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("76a4e14f-4e11-4d91-a723-dcdf735558aa"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8856), null, "Ediagbonya.Osayomwanbo@arm.com.ng", false, null, null, "Ediagbonya Osayomwanbo", "WRM (Abuja)", new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("7bc62aba-3145-41df-ab1f-ef74a06574af"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8950), null, "doyinsola.ola@arm.com.ng", false, null, null, "Doyinsola Ola", "WRM (Lagos)", new Guid("500fc670-2f14-4786-9092-f7f82b8ae507"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("7c8e0222-f16e-460a-98ad-43021384c483"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9047), null, "vwede.edah@arm.com.ng", false, null, null, "Vwede Edah", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("8086f715-74cc-40c8-a37d-3e634c68e976"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8937), null, "Dare.Shobajo@arm.com.ng", false, null, null, "Dare Shobajo", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("8294a2b4-f95f-4a88-944c-0a326d3894fd"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8993), null, "philip.aikinomiora @arm.com.ng", false, null, null, "Philip Aikinomiora", "Corporate Strategy", new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("835f7505-c911-4700-95dd-ef08049c47d2"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8948), null, "opeyemi.babasola@arm.com.ng", false, null, null, "Opeyemi Babasola", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("85978752-05e8-420e-b865-5e9c328b7406"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8941), null, "rotimi.olubi@arm.com.ng", false, null, null, "Rotimi Olubi", "Securities Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("8c7e6d76-2cdf-428d-93ac-16c3d4147a2d"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8915), null, "oritsegbemi.agbajor@arm.com.ng", false, null, null, "Oritsegbemi Agbajor", "ARM Commercial Trust", new Guid("05652a26-461c-4c78-be42-f212fc5fd083"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("925336b2-62a5-46a2-b919-00dbf803f33d"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9034), null, "oluwatosin.afolayan@arm.com.ng", false, null, null, "Oluwatosin Afolayan", "Operations", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("9446edf4-2f71-411e-b303-65f8ba5caba0"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8870), null, "Stephen.Igwenwanne@arm.com.ng", false, null, null, "Stephen Igwenwanne", "WRM (PortHarcourt)", new Guid("80245081-74bc-4124-87f5-d6008b28706b"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("99c28aa4-8328-4175-8f05-fb33ff93f3dd"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8978), null, "tosin.adesope@arm.com.ng", false, null, null, "Tosin Adesope", "Internal Control", new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("9a3bb15c-8df7-4663-96a1-e321c031c09f"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8959), null, "moyosore.taiwo@arm.com.ng", false, null, null, "Moyosore Taiwo", "Research", new Guid("a6409616-e559-4ff8-a877-0925be18ff3d"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("9b0e60ad-68af-4d97-87d3-d66d0f2df385"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8922), null, "Oluwabunmi.Abiodun-Wright@arm.com.ng", false, null, null, "Oluwabunmi Abiodun-Wright", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("9c1943e7-0a46-4f9e-bae3-8cd808156fa4"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8906), null, "Isaac.Elakhe@arm.com.ng", false, null, null, "Isaac Elakhe", "ARM Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("9da9489e-4371-40c7-837a-0cc655f63b97"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8954), null, "oluyemi.omodayo@arm.com.ng", false, null, null, "Oluyemi Omodayo", "Compliance", new Guid("a470f202-ca90-4fc9-8617-358311885a1c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("a04365ba-be36-46f1-900f-aae2f97d683a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8920), null, "joy.oyekan@arm.com.ng", false, null, null, "Joy Oyekan", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("a21c2d44-05d2-4790-8113-69dfb56f7d47"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9049), null, "abayomi.apoeso@arm.com.ng", false, null, null, "Abayomi Apoeso", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("a4b17ed6-2902-4b37-81e3-bd2fe78b099b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9008), null, "kareem.bashir@arm.com.ng", false, null, null, "Kareem Bashir", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("ab2aef8c-0c42-4408-99e1-5b9431e5c689"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9055), null, "augustine.chukwu@arm.com.ng", false, null, null, "Augustine Chukwu", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("ad4a20b3-7ed7-4896-8a37-a22201c6a55c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9019), null, "bimbo.moses@arm.com.ng", false, null, null, "Bimbo Moses", "Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("ad89b05e-82b1-4cda-b87b-f91400b01175"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8981), null, "faith.sani@arm.com.ng", false, null, null, "Faith Sani", "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("b07c2110-5418-4291-98bc-7a79c65411f1"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8896), null, "Oluwaferanmi.Olorunleke@arm.com.ng", false, null, null, "Seun idowu", "ARM Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("b207e71c-5092-4788-9c8e-fc40f0c09e37"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8995), null, "gbeminiyi.onipede@arm.com.ng", false, null, null, "Gbeminiyi Onipede", "HoldCo Sales", new Guid("772f854e-c9f6-4428-bad1-53db881e28bb"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("b5276249-69db-4ed5-ba5a-14ed293f69a3"), "ARM Digital Financial Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8911), null, "folaranmi.adefila@arm.com.ng", false, null, null, "Folaranmi Adefila", "Digital Financial Services", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("bc7ffb50-2b9c-459c-97d9-4347bbd112e3"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8893), null, "Aminat.Ashafa@arm.com.ng", false, null, null, "Aminat Ashafa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("c113e852-5d57-4246-a4e5-ac01247d6783"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9003), null, "opeyemi.babasola@arm.com.ng", false, null, null, "Opeyemi Babasola", "Operations,Financial Control", new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("c746ddfc-77a3-4e96-92f3-5cbdd5060dd1"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9014), null, "elizabeth.alloy@arm.com.ng", false, null, null, "Elizabeth Alloy", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("cbb03c33-6cc0-4737-90da-f0d4538252ba"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8885), null, "Adeleye.Adewusi@arm.com.ng", false, null, null, "Adeleye Adewusi", "ARM Academy", new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("d204727a-1068-47cf-b57c-c045448efef1"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8933), null, "Jacqueline.Adefeso@arm.com.ng", false, null, null, "Jacqueline Adefeso", "Procurement and Administration", new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("d2bc70a9-33c4-4d61-b36b-1fc8764ff668"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8934), null, "moradeke.odugbesan@arm.com.ng", false, null, null, "Moradeke Odugbesan", "Procurement and Administration", new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("d8b1309a-2144-4805-aaa6-ab6af8870ab3"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9012), null, "oluwatosin.adeboyejo@arm.com.ng", false, null, null, "Oluwatosin Adeboyejo", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("df0f4ab9-33d7-4616-acfe-196b4f3df2ea"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8929), null, "Carol.Ariyibi@arm.com.ng", false, null, null, "Carol Ariyibi", "Corporate Transformation", new Guid("850b308d-bef3-41ad-b812-413b868e7621"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("e1011d4f-56d6-4a70-a8eb-c77b54255e1e"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8851), null, "Nehizena.Ibhawoh@arm.com.ng", false, null, null, "Nehizena Ibhawoh", "Legal", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("e136923e-00f0-4054-bcfe-fcb27f9879d3"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8914), null, "oritsegbemi.agbajor@arm.com.ng", false, null, null, "Oritsegbemi Agbajor", "ARM Commercial Trust", new Guid("05652a26-461c-4c78-be42-f212fc5fd083"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("e323055f-a6a4-4341-b152-f704c87bd32e"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9060), null, "nehizena.ibhawoh@arm.com.ng", false, null, null, "Nehizena Ibhawoh", "Legal and Compliance", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("e3ecc43b-4256-4736-b689-8b2aea0a0a48"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8903), null, "Kevian.Kevin@arm.com.ng", false, null, null, "Kevian Kevin", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("e55c08db-9d76-4179-91c5-3b69b3e2e2bb"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8880), null, "Eddy.Ayikimi@arm.com.ng", false, null, null, "Eddy Ayikimi", "Customer Experience", new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("e78f9fa2-a17f-4454-89fa-bbd2af61629a"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8938), null, "moshood.hassan@arm.com.ng", false, null, null, "Moshood Hassan", "Human Capital Management", new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("e93baf37-ba2e-403d-aa6e-9daf5dac4afa"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8998), null, "opeyemi.oshinyemi@arm.com.ng", false, null, null, "Opeyemi Oshinyemi", "Operations Control", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("e9a379ec-d1b8-4446-b3c0-7f3c793fa711"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9022), null, "valerie.okosun@arm.com.ng", false, null, null, "Valerie Okosun", "Operations,Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") },
                    { new Guid("ea019e87-a9d6-4174-9a18-a04d87a9a84d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8979), null, "abayomi.apoeso@arm.com.ng", false, null, null, "Abayomi Apoeso", "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("eaade002-13e4-414b-9a60-c96beaea76ba"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8886), null, "Igbagbo.Ilori@arm.com.ng", false, null, null, "Igbagbo Ilori", "ARM Academy", new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("eb6cd3cb-f022-4552-99e8-b519f48dbc76"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9052), null, "faith.sani@arm.com.ng", false, null, null, "Faith Sani", "Information Security", new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("ed9bccf4-f56c-41d3-a2ed-801b89cf04cc"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8970), null, "oladupe.oshinuga@arm.com.ng", false, null, null, "Oladupe Oshinuga", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("efb16929-afaa-44ac-b2ac-a6d47151a3e5"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9009), null, "patrick.ayele@arm.com.ng", false, null, null, "Patrick Ayele", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("f5d1a48f-a523-4d1b-9ca7-0a4b2e8fa45d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9006), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("f7355541-8c38-4db0-bc1a-2627fd8259d4"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(9045), null, "olugbenga.ajigbotafe@arm.com.ng", false, null, null, "Olugbenga Ajigbotafe", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") },
                    { new Guid("fc0b698e-deb5-4b91-9341-dcc1648f5f33"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8853), null, "olabisi.adesina@arm.com.ng", false, null, null, "Olabisi Adesina", "Legal", new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("fe01f322-eb7a-416b-9678-7ccdd9b637c2"), "ARM Digital Financial Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 28, 55, 444, DateTimeKind.Utc).AddTicks(8910), null, "Ina.Alogwu@arm.com.ng", false, null, null, "Ina Alogwu", "Digital Financial Services", new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("00744227-3e11-47a8-83fa-57f00c7d1d66"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0099098a-ffbc-49fd-9e6c-7ead1552b3d5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("00c6ea1a-2a34-41e2-966a-cbd4e71a023f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("00ea314c-41ce-4eee-887b-2ec3bff15ffc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("02051c12-e364-49c1-adfb-6d7ac9761f6b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("024336e2-fb7f-4502-9cc2-08eaa63b752d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0254e8ae-753f-4cf4-8adc-0783e177f310"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("02b1096f-d321-43fc-990b-27005579ef3f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("037124f1-5f7a-49f3-9eff-889f1004d6b6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("039ab0f0-d67f-456f-985b-7bc8413e5443"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("03a6064c-ae46-4eee-bb40-25f303da025d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("03bfc427-71eb-4129-acc1-484a7d4fd851"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("03c9fb2a-67b0-4698-a7f9-067d1a7662e2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("03e2df38-86e7-4cee-bff7-5cf55bbd5e1a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("04c45f33-0475-4aca-bcae-ccfd0d758d36"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("04d3d59d-60e8-4df9-9823-4facd7ab7faa"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("050b41b5-1620-4801-b758-80547018f6b7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("053d7fd3-8062-461e-ab2b-f2fe1e346109"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0554f57d-9286-4df6-804b-80e93cc364c0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("055fb17f-4622-42cf-87c2-d398d3704220"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("064f2e45-76d4-4a83-9023-b59b910e314c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("075949cb-71e2-45bd-884f-9b3dc9801318"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("07932f05-03f0-4f5c-9c7a-15a22f43c9f7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("07dadc8a-a57c-4014-8058-568a9fe8b9d9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("080dd1e9-166b-453f-aaf5-f303fafc485f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("08170cf7-b57e-48a1-94e8-e4314b2e7865"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0827cd66-de5f-46cb-993a-6f54ff9b21af"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("082bfc03-0e70-4d2f-8faa-579999d253e4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("084aaf3d-ae50-436f-bbdc-a5672ea53906"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("08519af6-f5ed-42ee-9c6b-7d0ec9f11562"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("08569e24-6d6b-4efd-9b90-effe9184a120"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("085b82ef-63d4-42db-882a-3fc6b8bfba16"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("08eb6b13-84b2-4e7b-bb63-b0b296259b3e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("08ffa2a5-1dc0-45ae-a66a-983eaf67438c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("09a55de7-5da8-4225-9d65-0cc2ee8f4360"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("09bd0017-3d32-44ac-b8f4-72b725ebfba8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0a7a77d1-0118-4805-96a1-78748b6d95b3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0a85f5af-7786-41c5-b43e-ff9ee12cf0f2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0ad00baf-7502-4537-932d-ae08d9cabfcd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0ad923cb-881f-491d-80b6-3c6a4a2cee82"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0b8412ac-528e-46b4-abd5-fdcf68e5e96f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0bcf1908-f9c2-4156-a63f-5791577c8614"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0c13213f-67b5-4a04-9eb1-1c4c1cc6fa0b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0c460955-b9cc-48c0-8158-3e01b7c4f6f1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0c462248-5dd9-46a9-a638-67273ff2f86c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0c56d458-78f9-42fd-9bbb-75e3a102c675"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0d0b5c02-74c5-4494-aec9-98fa9f0ee863"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0d0ce324-d68d-4a85-b650-4ec127bb5e2e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0d977394-a158-44ee-bfed-6b4dfcfff5af"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0d98e9d3-bbd4-45b9-8f1a-de82f2198153"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0dd12c08-cce8-443d-aae1-4b444017a76f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0e6865b8-4489-4c5e-88fb-4de3de79711f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0ebcf81a-e994-4dcd-8c0a-9acebea05ae2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0f6ca9a2-b90d-474f-bcae-2548f9fbbfa2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("0f94f24e-7205-4a5d-b502-ec4a1e489163"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1009e0b1-91ba-48f7-a7f0-0386c45fb227"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1099766a-6f11-46c9-8647-0932d2824b3b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("10d3f333-5951-4c39-ba20-e5ef35031574"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("10db66bf-ba9e-4e47-b75d-d96dcf873e37"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("10e79d72-a078-4c5e-a192-2bad4d6b1051"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("111a62fa-be84-4f5b-a1b7-1bf3d83b9813"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("11bfd1b6-5037-4f6b-bfaf-70bb2e324baf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("11d510fc-b48d-4fa3-bc15-fc59164e2870"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("11e7fca9-55df-4e95-b9e5-0b37a2c8a369"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("12385aed-bc67-414d-a64f-6e3df644cecf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("12ba4ccb-a16b-4882-823c-6e1305889ac2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("133e4802-b36e-48f3-9900-a5e7db7a3ca3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("140c2437-0e92-4661-bcf1-507c28033546"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("14a07000-9f09-45cb-8650-6b7d167c1347"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("150a1b62-9604-4be0-9df5-fcee63e140bf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1592ca9d-d57f-42ab-b180-825ad594797d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("15b801c9-2ce3-4751-8f8a-d86323cdbc8d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("15bf2886-94ff-442f-968f-08e6dea1b3da"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("15c558b7-a460-4932-b64c-93430333233c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("15eb0e70-fbab-4685-a4a6-51fb2875efe7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("15ef9cb6-b6e4-43b1-9a8c-41d36f327327"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("16a14670-cbe1-474e-a539-9123dbc672ea"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("16b51a4c-6f35-4816-87fb-20ebd797c80d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("178a2b24-5430-47ed-b361-7538f58865f3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("17a7b1a5-6832-4f81-b3a3-b777e97870a9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("17aaf7f2-4e39-49e4-8d6c-50028543c086"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("17b4b299-7b40-437a-9200-c6c5ec49c0bd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("185e9af2-1ddb-4d17-b1b6-f79f4c6bf991"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1966fd76-d6a3-4af9-8038-780d645db22b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("199353cb-44db-470a-8453-d6632e08cd43"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1a4178c9-a168-46c7-bba0-0bc69453229f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1a67d798-91d6-4ad7-b2b3-084f7127af94"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1a9b8afd-ceb8-40f5-b69b-91d4be7c159f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1ab5a766-70aa-4b37-9818-6232723fc88e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1ac41df5-d575-4d59-8794-45e9aa0f4eb4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1b19a001-b2ab-44b5-817c-295aee769005"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1b39df01-48f3-456e-bef5-4a42f31c8016"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1b6102a2-94c6-4b31-8ff4-fe8d8c850fe1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1b954b49-70b9-4658-a9d1-299491b12be9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1bc338d5-79cf-4202-9d38-7b74c69ddaf2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1c49a64e-8056-4e5e-91cd-482bcb750c28"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1e1e783c-6e13-4a85-87e0-79984b7e3202"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1e2f4cb4-4ecc-4ef8-b4e5-d13555e107ae"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1e606b87-bb2d-41bd-b926-9aca5304e217"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1ee3c63c-8907-4500-81f2-67b244d23b14"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1f251946-b46c-4ea8-9636-94463839cefd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("1fb8b8a6-bb59-4d59-b097-6c2922e96408"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("20a630a0-1673-4009-8480-8e1692b9b0be"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("20eea21c-8ff6-4a02-b285-7e66671f7cbb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("210094fc-d396-4071-a84c-b3f11827e9ca"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2121d93b-8c79-481b-8b8a-86b0aa15fcfe"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("216582a9-35a0-43ba-84f9-844abe57fc33"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("218da0c2-42f2-49a3-8940-9f897cdcc53f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("21eb1e57-1922-41f1-9f96-11cc2a64a769"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("21edfbdf-b9b3-4ff8-a6b0-025ae663d340"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("240f3771-e3b7-437e-932d-fff02e0c5c88"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("249d4e65-1eb7-4775-bbfa-f4f7388a59ae"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2500ea4c-bc68-4197-8582-1de31d292297"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("250a51f5-31a2-4b28-8093-f2fbdbc658c2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("25cabd8b-280b-4812-a65b-3f79d1420ccb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("25ddce19-a77c-4e32-8b79-4dc40879f029"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2632c80f-ac43-49f0-be37-80b1177f4dee"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("267302f8-6228-4854-b424-ed2ca3557e03"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("26d66b69-6b35-4022-a02c-5a0ba5c23979"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("27527cbb-ffd5-4e59-a3ba-0c1ee478ec03"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("278cd6c6-e49f-433c-afca-ddc94f1e773a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("285fbcc2-addd-4b3b-b179-f1ba9846922a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("28916de9-079b-4b58-ac27-44abbefa7953"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("293f22da-7fc2-413d-bda8-3acc5157c6d2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2a05c7ec-1437-4fb7-9f0e-9e5d955ac29c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2a83a16e-df77-4e20-b8d6-3b7052fefc21"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2a8ca117-5453-4251-a539-c46e07060a5a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2a98c36b-00c4-4889-b84a-15c2e73abdbb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2ac85722-8a13-4bed-bd69-4b39f734df63"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2acaac92-b57f-4dea-a7e0-72252f961f11"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2acc00e6-443a-479c-8bf5-4cece206dd22"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2ad3884b-5baa-4e98-9dcd-072834b2f269"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2b12ebf2-4f0d-408a-ad9b-44d79359fa49"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2b55b1e8-96fd-4ae7-8aa5-eede00d22e06"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2c8624dc-bfb7-4ba2-94ca-23a9aa284c0f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2cbdb10a-7e96-4771-a2a3-30d8c96412f9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2cf84f08-86cd-44df-924f-a16acbf44445"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2d35ebac-ef7e-4db1-b1da-a111ec590802"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2dacb482-b385-4d9b-a084-8e01ee70a4de"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2e2b852f-5337-47df-90bb-e2951064a23d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2e525e10-bf64-460c-a800-10a601d3136e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("2ed54b12-c3d5-432d-a74a-a17f2660f4de"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("305c1d6a-0ad8-494d-adc3-a4fa944d1717"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("308159c2-564a-4010-95a1-21e9cccc8a7f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("30ad8842-c611-42ef-8e34-9a4f84ec0aa2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("30b31373-faa8-4cdd-8852-6c5492a84f46"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("30c54586-83fd-4800-b425-dfc88af6d3c0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("311ac23a-3841-415f-8dca-effaa7602f4f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3171b194-00ff-470d-9793-e85dadce357d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("31eadde3-d4c7-4d9b-a55f-415c68178121"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("31ec4aa6-b744-4d0b-82e1-3507cc996460"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("31f6c5bd-ca78-4d64-8b87-b562a7460720"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("322b080d-3c28-4d15-80c7-3243256f0004"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("325a6c9d-6c36-4dc1-a9f9-167c19fd2ecc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("32813e2f-6610-487f-86b6-656b5b0128d3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("328bbae0-0387-4531-bc91-70fad3d32bd5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("34281ee9-4452-4e7b-b423-14ef148ac307"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("344b7a64-2ef9-461d-8c7c-40bb395ed0ad"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("345a417b-f306-432e-9ea4-f8204e47654f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3473e4ec-3976-4bf1-a9cb-7b5cfcb2efd8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("347c5efb-1a9f-42b0-b938-77441880946f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3504678c-67b4-4664-b65b-492a6e4c82a5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3546f3b1-a0c1-47ff-9313-7ba21ca154fa"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("35b57aec-ae66-4e29-94b9-ad30ee68c275"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("35eac49b-4873-4ff9-af41-0daae87e11d5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("36818b33-3806-4eef-967d-7c71341c010e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("36c00334-4827-49fd-9bc3-caf86bd25a98"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("37675f92-b2c8-475c-a3cd-52f3e01eba15"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("377a1a93-7a85-49ab-9949-8204aa8e88b6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("37e68311-1fed-4e00-a849-6e191f644a5b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("389ab5b4-5816-4363-8b64-80f517199684"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("39508b77-2989-4564-8327-a5c81f7b18bf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("39fc0305-0fe3-4796-95b4-18b4f58446a4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3a3fb3fa-0c8f-4908-b33b-54a863cfa9a9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3a5c69c0-f256-468b-b320-4ef84d65be6d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3a5ccdc1-981f-4a37-b3a6-57a7c34c622d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3a68d996-c7a6-4e1c-87f4-f66748483550"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3b2b3d88-628e-433f-82d9-7ec1b4d79a0d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3b92a6f4-f6d0-4a47-8cf1-384c6d1147d7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3ba96d05-de87-4367-9063-03772d73d7c3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3bec24d7-7ed1-41bf-a989-3257558d8dc1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3c09a654-d457-487e-ab54-09b74c63861a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3c8ff071-29b8-4ec8-9676-c01a3b2505a4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3c94a5bf-144d-4622-aa29-f1424029b0bb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3c96100b-1b3b-41c9-8c48-9ff7dda27bf1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3cb93705-ee66-4f14-bb5b-ceb400b4e647"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3cc4eb0e-9000-422c-a8cd-2a3192858b5d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3cfeeda8-0d99-4fc8-ba3e-ca6e3440b333"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3d3fbfa2-1749-42ac-b057-fb542f5d4c61"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3dd2be7d-a6b6-43b1-a174-fc6877303b40"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3edb74ac-cbbb-43bd-a55a-e69cd1cf4c0b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3f1e70b7-d50b-4c78-9b30-a23406e01cb2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("3ff4e226-b678-4f6b-af06-592548735e44"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("41077438-11d7-458b-ac13-cd252924b1e4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("420439e4-72f5-4db6-a80f-34c412426632"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("430a4089-763d-4e62-a696-d9a5d52643fc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("43151a08-1f8c-48eb-8d24-2260c9ebf142"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("437ed55c-e0a5-41aa-9a2d-dca2928b2095"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("44155f81-6b27-4ffb-863d-e17a6aaf2f92"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("44d86950-e193-45a3-ae1e-102a5360f5e1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("45629430-24be-4934-9c85-8926002d491e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4582c1bd-8443-4518-87df-d6686b1b2689"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("45e5be39-e7aa-414f-a48d-fde49935780a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("46602c75-6c7e-4333-b7f5-7e9a96a94793"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4680cefd-a546-4384-9e8d-b0723f054b7f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("46a6cf8e-3c4d-4ebc-adee-fbc0b2520dfd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4784817e-7a97-4f6f-b544-4f564bf537e7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("47f95908-b29b-458a-a326-aa6d6d43f811"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("48105385-6882-4ab1-8c8d-13e9f710d3a5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("48c8ffdb-f58a-44fe-b3b3-a44fc0070801"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("48d182ac-2d60-493b-be12-1ef9e68ceb77"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("48e1ed78-ec40-4aa5-b18e-b11a5de5faf8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4905e60d-b0f7-47e3-bf11-b9e2a4a37b22"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("492c69c8-97e1-45cf-afa3-68b4bdc20a0a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("497ccb36-51db-442e-ac20-c358b645587c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("49c74058-1375-4f2f-98d5-3e7ea1b61c56"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("49d27176-d7e4-40d5-8264-fd200b61028c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("49f815f0-249e-4928-86f2-74cf4b220fce"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4a7459a0-7dd8-48c6-9ddc-5ecc76a34f4c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4aa8374f-b4d9-4455-b6d3-50acd799100e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4ad2ac52-5b7e-4635-8666-33ef7f3ef92b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4afb4879-9f58-47ca-b632-20c67fbbb307"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4b3e2a5e-aac2-472f-bcb2-4300cf05d0b1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4bbc6fbf-ada5-4c09-b610-a98ad9d98051"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4c0607db-3e42-4932-87ff-cdb0d85fae02"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4cabd5a5-bff8-44f1-8391-3c79ec656279"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4d033d3c-6ba8-4fca-90fd-8df283135f7d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4d634fd9-47e9-49bb-9bce-dda9e600f3e4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4dc55a0b-ecc3-4876-a225-84f40827d90d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4ee84890-6ff1-432b-8ae0-93d65ab5c090"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("4fd0422e-86ce-4305-8248-8c427d73b3f3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("50102f42-6b23-4825-9c72-075e3f8e00fe"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5053e912-6e1a-49a2-b44a-f9d93657e82f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5082f73b-1540-4fba-b970-2266c8e41abb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("50ff0c2a-5b09-4305-92b8-3ebcb6c48c07"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("516ac2b8-2f5e-40b2-a7db-63b429159453"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5295837f-700f-42cb-b0e7-fcf59b238fde"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5297682e-4844-42ba-a09f-f1638709d543"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5322f073-7d8b-4c3c-be3d-cefae8770713"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("535cb97f-a234-44e7-9e2c-e48a6c58a01e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("53687b10-754c-4868-80b3-83b60e8bd8f5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("54413748-222f-4a8c-92c7-7273a8ea339e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("557d7e4f-d5f5-40a6-b6bf-5f5b891e4bac"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("559b5192-86a1-485b-a4d5-a16c8ce2a22d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("561d795f-8e52-4150-a79b-b2c5bee1a647"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("56cbaabe-ac1b-4828-810c-15d3b1f139dd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("56f26683-55cb-4bc7-870c-21670ae4acd7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5705a147-8e71-418c-a8fd-f9a97cd15bbf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5775c7b5-4b85-4f60-bc4f-0978d71e7ecd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("57f2b2a1-0e64-4eb2-b0c0-51bfe1d658a8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("58926708-5546-4a86-8d51-632f19991802"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("58cfeb2d-4172-4d3e-86cc-b5ffa359df7c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("592155be-5b34-441c-a7e9-d8896fa64cb3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("595f2743-aa31-4851-9340-5229a6747a4a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("597f1016-6ecf-45e7-9f60-e654b2ffbcda"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("598e1bf0-e6a9-4564-b4bd-d7ec779fd6ec"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("59b44cbd-71c3-4f42-b71d-86f6f051e656"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5a0a5c1b-9035-47bf-9fe7-f421054732ee"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5a3e7b2a-b7b5-46dc-af57-4238957e89bd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5a4534c5-21b8-4eef-9121-139372059984"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5a45cdd0-5033-4364-bffa-e0f49ff00506"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5a671de9-1b26-4136-9839-7167e047ee1c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5ae649e8-a278-493b-995e-ba4e43c6e25c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5b5a1808-45f3-4a19-a81c-43fa9c819b39"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5bc2bf97-8632-4df9-80a6-10d743a1c021"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5bf3919e-5f5c-4626-9534-702b14163fbf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5c50c1dd-36b1-4006-9fb8-0f7bb883b2da"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5c5f70c8-6835-4af0-bf36-628741ac5ba0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5cd9e705-6e7f-4acf-b172-1e035c666b03"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5cff91b4-9ac9-4caf-8d28-d82071492a64"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5d9d51a8-c24e-43f8-b378-5739da797d9b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5e2785d6-dcbd-4c7a-b87a-9b97e03e71cd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5e38ebf7-7917-4dcc-84f3-82e0fe2dea3f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5e3bd166-b49f-42fb-b34a-fa52d7099e0d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5e9da993-b3e6-47b7-94b1-87ff5e7a69e5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5eb0509a-163a-476f-8c37-7f97d208bc69"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5ebc8d92-ce24-4b80-8844-347b36f5ddf8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5f08d383-8f4d-4d21-8db3-77b274e950c7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5f109704-b582-4c04-b9ae-e9a1b7a165e6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5facbea3-9ec2-49f9-87a1-5082e489c7df"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5faf9001-3749-496e-8c4e-5555a3a7ab51"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5fb9169a-8006-4243-95c6-43e4713d336a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5fccbb52-58bf-4cf2-9a93-f50512d6cab7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("5ff0687a-cfcd-42a5-aa72-c700deb47125"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6074f8a8-e88d-485c-b403-f2b85eb34be1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("607e5c78-0494-41e9-a733-969e26501ffb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("60aa5dc9-ae6a-4098-84da-d9ee60e28dba"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("60e6f303-181c-4416-9f74-7f8a486c4ef3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("61273a13-d444-4199-a329-40ae9989baf2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("612bdd13-5c59-43be-bf5b-2745e2470a3e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("61668619-34b5-4ce5-9e42-f1aa65a78508"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6194c0bc-5396-4009-9bdf-56317e8b43a8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("619779b9-5311-449f-83d2-60ce1b0662e0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("619e8533-81b7-434d-9160-c70ecf197c7f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("61b82d19-7978-43b2-8975-791e83eabfc4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("62045406-a992-4e55-8abb-5ea54a9846e5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("624d6658-1dce-4a9b-8ade-bf531daaf12f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("62911f41-ec91-462b-9ac2-3a37553ddd54"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("62b26d63-509e-401f-b6f5-f2d2eecd870d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("62f1e19d-f1ad-4b43-a5f3-d9dc0ade72d0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("62fb208e-023d-4775-9c40-cc967f22162b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("634f6e94-c3e7-4425-a6d6-1317fb8febdf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("63bc281a-80b5-4368-ba7a-28153724f7f5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("641f16f9-7aea-44b8-9937-f00e976304de"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("643afc97-be56-40e6-a89b-651252b43078"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("64980b73-2fe3-410d-863e-eebf5186d850"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("64c2c315-6c29-40a5-9529-2f157b61e222"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("64e1b71c-0d7b-4821-ba4e-e7b1d7a32524"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("64f9052d-e769-47d4-a45b-8c46f5fffb3d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("653d152c-5ec0-4dc5-8c65-cb3326b891a6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("654d7b28-4118-4b12-bd4a-95bbce3960ae"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6561a66a-3ac6-4baa-8ea6-f95c91bf651f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6684b8f8-44a4-4181-a578-3cebbc43a5ef"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("66bd4173-6527-4b4d-b6ae-810e2973b2f3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6740fb3d-4b4f-4af1-8e52-0ecfa3ea56ec"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("67a72c00-444a-4d31-bdae-a1acb5fa451b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("67bf2284-a290-41e3-b019-8694cb3c8329"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("67c18e0f-cae4-4b06-a83e-4654a99f692c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("67e0398a-6eff-4716-88ae-1168ae42b600"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("68354475-f0a3-4716-9fc6-553bbfa9b347"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("68bd03f8-4375-4b21-b3fe-6c02a6b9d0d8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("68be6519-80cc-4c02-ab6a-9951544133e7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("68d29364-05cd-45f8-b6a2-c129c8704d5d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("68de03de-6ff6-46f4-85ba-c332a7a0883a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("68e164c4-9382-42ab-9cb1-dc3a38e18c36"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("68ed7d07-36b6-46c8-9953-9a49e4f5ab2e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("69390cff-ea07-4af4-9009-45c09db74c5d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("693bcc1b-a6e7-4b44-b16a-9f4d10063fad"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("69416810-2b4d-4d66-a45a-dc386f3b02c6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("69489613-9629-41d0-837e-f1f45c9ae84b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("697fcb2e-601c-44b7-9377-0f6211b8e373"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("698227cd-ca40-4c41-ad87-f2cc3e4dfb9b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("69d55fc0-65d9-4c86-9276-c6f805cc869f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6a233cef-1a58-4bf0-a67d-fb06e0e5a256"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6ae041af-5e51-44a4-92f5-df7f54ceeb2c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6af1fb13-1f80-4c8c-aefe-42e65379eade"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6b6a28b7-9e96-4b0b-bcbc-ab7799bcef15"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6b703f18-8d35-4987-ade1-37144650060e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6b7ac93e-c646-40ab-8025-c646712248cb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6bdb3139-31c1-4850-b2c1-bae2f63406f3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6beda882-5b10-46df-aea6-f89bd17a68fd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6c6eae4d-81a1-4203-adb9-91eba4a4a25d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6ca0ff48-7312-4b0d-a020-75acdd75ac17"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6cebdf8a-f6cf-48e3-be40-e6c4e581aaef"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6d72ef47-5681-4e55-9613-cc449c5fc50c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6d85d177-8f6e-4d03-bc56-a14a7fa5eda7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6db463ec-7d4c-4c02-a7c3-401ef79b80f4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6e3ca098-cb92-41a5-8f8e-fe2d4791fca6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6e90bb25-a302-4f62-8aea-7637b7fd7c23"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6f0d24ed-2893-4ae4-b8b3-0035551d85e6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6f17edaf-06f8-4df3-964f-8ef949e3821e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6f4e7481-c74d-4d43-8962-f62c1cd17c6f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("6f81738f-0419-4a89-bde2-1f1d9a26b6e0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("70114e8e-5c57-4f48-8a79-d14c3f4192b7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7077c9c3-6ad2-4dbc-88af-b54e48223c6c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("707dd21c-676f-49fa-8564-ebef1bb8f200"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7152af96-5050-45ea-a06c-955455b503d9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("715f8f85-4770-4524-9b5a-0d7442b8c9e3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("71850ef0-7822-45f4-a231-e166632c45f1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("718f2c9c-7894-4989-b7e4-35162309a7fa"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7196e521-e563-4473-a3f4-9e1521301df3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("721e6f15-2ed7-4b32-b3d2-90bb0a549282"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("723b72bd-fce8-4401-b901-a29211ceb154"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("72da65c4-c78d-4a3e-aa61-840993f08c5c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7305405b-4264-4a35-be6f-90c7449a4648"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7327655a-759e-4c33-8059-b36f3fdf9e78"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("73464d5a-6666-4463-85d6-92b419a785d8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("738851c4-b543-4510-b996-5293190c60cd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("73a3945b-ea2c-4594-884b-3446f2f66fe7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("74481bb2-dc22-449c-bddc-da534a4fd6af"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("748a245f-05db-490d-bfdf-61d414a91b20"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("748d6613-faaa-4fe2-9fb5-079bf27cf3c6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("74fc36fe-4f1e-4912-a271-b91b8c72e05c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7510f720-b58d-455b-9ba3-7ae1000f8162"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("756c8af0-acfc-45b8-a43d-ebf7ddd112a9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("756e2b32-6368-4482-83b9-b044a380ce2e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("76166896-dcff-4fe7-86cc-c6389772590c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("767694aa-96db-4aea-a008-ec87ca9a82ad"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("768a8e1b-d86c-4e6e-b185-e184d78dd408"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("775f0c0e-53b2-4ec6-b0fe-39ab686454a1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7775fd11-d7a7-4764-8eb4-e5614025bcf6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("787e5323-e23a-42a5-92c2-aa32e5730947"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("78b74dc9-07bf-4919-9afc-5b5cc063350f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("78bee780-5161-42f6-b406-136ae7d05b3b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("79ba7e0e-8ab9-4c98-ac67-2c09e38ce5a1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("79e5a3fc-4b1e-44b9-8e81-66754b4b0f48"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7a48cadb-bf9a-4c6a-a1fa-9b40d6244afb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7a4a27e1-bab4-41f1-be03-873110bf23a7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7a4ba8eb-94e1-4429-b9df-355f7b5614d8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7a834d11-68f0-44b3-aaa0-487faa102ef5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7a845d44-bfe0-48c3-a782-befa70610d81"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7afab922-cb07-4399-8c74-34a10afc6f1a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7b41bbd0-51be-46f2-84be-5a8c44013a74"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7b8a05ec-5cc0-4705-ac4f-3aac40c9822b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7c4fa8c7-6f12-41d2-8562-080f1f2829ec"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7d374f00-cdc9-460e-ad1c-d06705652581"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7d3d2b80-e14e-458e-b9fd-2f89e7cb7703"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7d50431e-7155-4e2a-bcde-d945e5a15d13"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7d5d24c2-6899-4de1-9ee9-be5dbebb69b3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7d6c8e36-7d43-4fc4-8104-443d21646c9b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7dc20bbd-badb-4f36-9a25-a6069c69b1cd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7dd407ae-1ccd-4dd3-9f97-bc2157d703d5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7e451f1b-8084-4132-87c7-2b8c39d67b47"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7e51ef96-f804-4362-adbf-074ad5bf1986"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7eae9f64-27c1-47e4-9c98-811d9cea5908"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7eb15434-f0a2-44f6-a537-e3501837a0b9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7ebe9cb1-fb1d-4ce5-9e5c-f3c3627ef262"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7f34d972-6963-413d-9025-beaf6833a75e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7f39aa4d-7ac9-4a20-bace-7875c6728143"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7f8c01a1-516c-49b3-b73d-a3156b7c3e28"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7fb77bf4-a33a-4afe-9f08-f5113f228c6d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("7fca4064-7bf3-4bd7-9716-0f2ec7610d48"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("80c10e92-05d3-4a8b-af7a-303161d9f938"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("80eb566d-b70b-428c-8a25-568d36b0c420"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8123249c-e4ca-49a6-a15c-7039857d1001"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("81250c47-b677-49f4-bb8e-62541cc29436"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("81634fdc-7285-4136-9510-7ecd31fc4331"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("819e0826-2fcd-4ceb-8aa6-6881e6708deb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("81ed1560-5bf5-49a6-943f-2717aebcad40"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("82121006-cf72-4681-9219-86188cfdfd9f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("823b3208-cad8-49e2-b3b2-75387df690d6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8271585b-42f5-40c5-baac-015ffb777b0c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("82e9d158-33f6-480d-ace5-5dae139d61ef"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("83197450-c85b-42a5-9d1d-59485c3146d2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("83ba966b-c6cc-49e8-bb74-ac06a2e61010"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("84d8ebaa-5a4f-429b-bf64-b3321536b3ea"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8544e8a2-2a0a-4304-9eba-519d84b809f7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8551d032-bf96-4847-b740-d6ab984da8a9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("85733995-8ec9-439d-b44e-92e8461fb908"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("85c211ae-6440-4c6b-a83a-124768db86a3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("861b083a-0901-49f4-81b5-1e92301695f1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8637f710-6282-469b-b80b-9c11289d3ec6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("86512a6f-bcfc-400b-8214-7c4263cfda2e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("86ad87d8-1634-40e6-a214-4826839bd050"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("86d24c51-a624-42cc-bffa-87069e7b129f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("872f61c1-90bf-4018-97f3-ab0292b8b5f5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8750507b-deec-49ed-a650-012426fce453"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("87846b97-f496-41d3-8cd4-606e6610f219"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("87fe618e-7e8c-4532-a35c-30ac4cb7cb75"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("882d1a26-1a16-42ce-8fb3-9a346c892bb3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("889a11ef-6906-4093-8030-d024f090ca10"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("89c01b6f-6cbd-4424-8478-442fdf23f985"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("89c55abf-279d-4159-8083-c01b98ccde96"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("89cb66c6-0f35-4eaa-909c-3539b0b9a0eb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("89fdfe5a-97e1-482d-a740-408e45bf3ac8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8a20843e-3767-4fa2-b4e5-37033a322ba7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8a69ad50-9357-4ba8-954e-ec57112564e7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8a952ad4-4166-48aa-b312-5a59cbd1a323"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8ad49b8c-37a9-44ad-b590-0bc7fb40b1d8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8b034454-0bef-4a9d-a8e3-063dde0bce5e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8b5a8cc8-5da6-44e1-b81e-b5f1780692d3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8ba97c3d-58aa-4b6e-a52e-9fb370809a67"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8bb2a3a3-fbf6-4220-8ff6-0b2fa5440ff0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8d002900-6e44-437f-8f95-db0a5afa71ee"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8d87d698-53b9-4af9-ade1-858d71bcb6bd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8d8f361f-9dd2-4569-95af-e4c63672e933"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8da67f87-fb41-48d6-b6b4-0fac66644a1a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8df8d964-1d5c-4bb9-b46b-3d8d5adfd403"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8e087d23-7504-49ae-bff2-2dca912f2b88"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8e2111db-f481-4f1e-8b51-3119ee7cb42e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8edcf34c-dcec-47fb-99e8-28c2b3cde2cf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8f5d4dd1-df75-4389-a8f9-778614076e2f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8fd3e59e-0481-4187-8e63-5c6b3e223239"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("8fe827e9-a0e0-43c8-9172-99cb066853e0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("90a2a7b5-8eca-4775-ac41-969536f880b5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("90d7f561-e34f-47e5-adb1-c8c09aac9aed"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("90d95292-7dd9-4505-b7d6-b971ca5ca24a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("91288523-ae8b-4daf-8245-b9bae19757c0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("918bfd3a-7bcd-427e-ac65-b1ca7d002d06"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("91982f64-e658-41d3-ade5-63b7cc708750"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("92119bb1-9601-4e6a-975e-b5249712db43"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("923ad703-4c4a-43d1-9c88-32090ca7718e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("92feb139-f56e-4ef3-b863-6636aa2fbf9a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("93116525-93e5-46a1-b1f0-c1ce6b6f1149"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9327b3ac-1785-4f89-95da-a198879512ce"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("93334406-6abe-4d69-9b76-d0ccde4db70d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("940a0c0b-b2a8-45af-82f7-29b4b2865566"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("941a5033-b854-4f7a-adfb-811acb27ddcb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("944de849-c4e3-41d9-a745-cf6217ccdac5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("948a93a5-999e-4e33-a0a1-877eefdc2c7b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("94f0925b-553f-4009-b9d9-2288c0935de9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9538f5c5-2226-4e3a-aa5f-1ba1a00668f9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("954c81a3-5dc7-423a-9683-64934c211a07"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("95c88fef-ce5b-42c7-84c7-79d444cd5ea9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("95deac6f-21a3-4570-8c8c-8ff2c4979ba5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("962a0222-41d4-4994-8c9e-9eb47629d4cc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9649ce34-245d-4894-a2f2-86f0e7a07a95"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("967f5403-691a-4051-81f5-9c6f08fe0d72"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("96963b90-bdb0-4ca2-8281-f4004669a53d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("96f6dce9-7ca6-41ec-bfd6-b4567d1f997b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("970f490b-3931-4a4d-9bf7-90f07b8e0812"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("97e2641e-2a44-4969-ae95-795c6868ec6f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("980067d9-4e45-48b9-8964-edb2f71e65a8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("983834af-1157-4976-9108-61ca61b9b592"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("987d9da2-4bc2-4af6-a9c1-321faa6ebcb3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("98c36fc0-b52f-4b19-bd78-7a2b35fb7de6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("990ab609-a732-479d-a539-5284fa4c0185"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("990d7ccd-0332-41ad-9f06-bc3bbac0d0d6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9a33fe31-5a19-4ead-8c25-3529f3231ed1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9a78eab2-2f79-49dc-be0b-930f62ba391d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9ab6d779-7cd5-4603-a842-a632436d81eb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9ac34b93-77e3-4b7a-8d34-7b581f4e8039"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9b67149b-36a8-40f5-8c04-989b1cc7ad6f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9b7598e2-172f-4f82-a49f-3628292ba698"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9c015330-3d50-483b-b378-f0a422cb8560"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9c608b3b-ef1d-4cf2-b9d9-5d8dc75dacd7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9c95670d-8d5c-4e70-aaa8-7f7df226bcb4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9ca8c2f9-954f-4fba-984b-0bf01e8b9cc1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9d5bafe3-b983-4a00-b631-d335633d03d1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9dccb8b3-24c7-4aa5-b0cc-14e3c2efcaa5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9dd574e1-433b-418d-9cf3-dcaf7a40479a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9e75b303-bef8-4ca9-890e-d8d82fbe9e24"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9f406662-1e6f-400e-a1e4-f6322c4679d7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9fb27092-ffe8-4127-9457-b40e813cbaaa"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("9ff7cb3c-1ad0-4e1d-be9e-4c40cb9ab278"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a003b4f6-344c-40b2-8fdc-de09bc234567"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a00e87bc-9ba8-4da1-a8e7-eab2b37530f3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a0159313-8652-48d2-b6ae-6cba897b4956"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a0639e74-b99d-4cba-a812-cf13efa1c7b2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a0756725-5748-4a24-ae96-6af04227cc15"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a09b9c22-73d1-4bfc-a9fe-78a4fd28716e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a0ceb1e8-84fa-45be-a07b-5cc41bddc0c0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a1740567-f136-42f5-a760-f596385c0b27"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a17fdeb7-1f85-42a1-b3e5-89daf473dace"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a18f0434-c770-4942-b37a-7eb735e44a17"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a19c70a3-4f8d-4d71-a50d-7c1edc51dd93"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a1e531fc-d751-4724-a452-aabf2fdc8864"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a216df49-3063-41db-8590-9e690425f696"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a237535a-9af4-453b-9c15-3459df7df57c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a26d697e-1037-495d-b06a-4555346e043e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a33fee1e-90c3-4802-83d6-716385a261fc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a34c40b3-3647-4d7b-bdc3-5d90339eb4c6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a3ad5a17-1d85-4fbe-8bbc-9eeb6e59d4c5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a3cf5aa0-60cd-4cea-ad4d-fd5581a90cd0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a45b5e92-701c-435e-8729-07828d8281dc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a4a1eb36-d962-4e21-805d-abe27ee38f8f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a4bc10be-1dff-4a4f-90ea-fb4f9da407e2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a4c15601-3574-43f4-ac7e-7f5c6de9b6de"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a5e4d201-a80c-44c5-a5f6-1fbe818f9961"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a6ad7073-eacd-44d8-b017-17f14ddf8117"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a6d5d437-9e5a-4ff9-8262-c2c0e90a84f6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a6d7eebe-265c-42ea-980a-60c19b777fa2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a732fdd6-0d6c-4914-98e1-461481f6b8fb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a73f194d-efa8-44d5-b358-f518445f4106"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a7578958-6633-4237-9e5a-11f95c0c6a23"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a767bf45-31e3-421a-873d-4c5aa613e53e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a7991138-e3a7-44e1-ad3c-ca15282655a2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a839353b-f872-4610-a6cb-50fb09d22c8a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a8eac4d9-e1b7-4cc2-b5db-b15266143ddf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a9a8ca2b-6931-4051-a6a8-17ff7bef6d49"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("a9e5f612-4b15-4ce6-bbb6-e210546d94c1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("aa3aad3a-d54a-421c-b8a4-b5ee63fffb96"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("aa94ae4a-450d-4e89-af12-1bba104e6ae8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ab29dc32-a9ce-4011-b167-fbe5f3c13fe8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ab384f09-28fc-4b78-8f19-a3bc9feac3c0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ab8fe4ac-21df-41a3-b968-b5f83daa936e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("abd83dd2-107e-4e14-af00-814160c7a175"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("aca41565-cb6b-4f43-aa36-3d5473248c0d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("adf6a310-2e73-4db8-9a46-9a3a0b06dbfa"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ae4556d7-79d3-4e0e-8f63-63c4a1863bfd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ae9e4556-fef2-4979-95cf-8396750adfa5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("aea8b1fc-dc51-4104-98bf-be9b8cb50734"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("aed801be-58bb-4fa9-b03f-b3cd14d516af"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("aee17616-712e-4184-ad2c-966f0531d093"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("aeeb3e41-c5c5-4a6b-8c86-065bcfb342be"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("af5478af-1386-4e7c-94d6-f6219e76456b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("af5c9f5a-2628-4509-b307-da8fa38bfbc6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("afbbd777-8d41-44db-9657-fc230b4a76d6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b0300f47-70ce-4d01-a97e-46125c3a6a88"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b0d7ef3b-0dec-4002-a500-5d2ec05ab5a9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b12699a2-de6a-4780-b317-c3760cf982d5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b1592cc6-d00f-4f2d-8089-dd4d325abc84"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b1d1eff5-fef4-4612-8a93-4997c4c68eed"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b1e10a20-4ddb-4d96-9449-a13a6f28c51d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b1e69e29-a929-4db9-907a-ec2fa1924310"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b208ed8e-1779-40df-9ed6-349840338fd4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b20afece-c28f-478a-96d7-fd451181d3ca"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b2184144-ad2b-42cd-be03-50c558c22628"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b21c82dc-0ff7-4238-a615-623cbecebf23"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b2269672-1635-4ab2-98ca-28734fb2175e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b254881b-02ec-4616-bbd9-65c5935a7ef5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b26ba350-276b-40d0-8259-ce6a862f8e11"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b2a8e5ca-79e4-4a22-9ff2-7ebe528c8ec4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b2ec1b67-bc5d-4689-81f0-9c553c74ccc5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b3a2754c-e47b-482a-9716-da169f84d622"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b3c8aa19-08e7-4972-b503-4c755fbce3c3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b3ce21b8-fe7c-4ba8-a2a0-8968331f6bcc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b3e407f8-042b-4a7c-a38a-1e5976de9b77"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b4a8ed20-2ca3-49dc-9200-1b1b09b875ed"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b5027f61-e9c8-4ed4-8a31-21a725d5c9ca"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b5e943ae-449a-4d05-8c60-ccabf4b2456c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b647e6f4-7bd1-418b-9986-eb890e7d74f4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b6673b87-6c2e-400a-a057-c102eede6c9b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b66f8fec-3397-40b9-889d-3b8e1afaa8bc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b729edcc-b098-4125-83c5-53d59839ec4c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b7581275-f268-48e0-bf2d-f4d35aca8d95"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b7797b6f-65c0-4a3c-bc77-6976da59b6ea"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b79f8b72-80ea-48db-ad6d-d3bfdf70bbed"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b8139e83-7f0a-48ed-9994-3173a2271530"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b824874d-dbaa-4f79-b4fc-46078a8dafc2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b831f039-eb88-4f9c-a13f-6890e3c62ce7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b897efe3-5fd5-44fa-876e-bd0567c5d5b4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b8e74338-21e0-4893-b4cb-0f733427962c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b911425e-ba76-4b3e-8648-020d021fef6d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b9963f45-68a3-4ac5-a672-66aa94c93312"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b9e08824-4d41-44cf-875f-b561509b0590"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("b9f059b5-be85-4cd3-8848-a89c92f6bb9c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ba2671b3-ff2c-4505-9494-60fb140c129e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ba4407a8-29df-460b-970f-f46405f3837b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("bab16885-c840-4dd0-92be-26d6bcae0386"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("badd67c6-90c0-4d9b-adda-942104226649"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("bae0f64d-5efb-4e17-8ce5-c2c9bf775dbc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("baf7267f-c271-4f3c-b43d-1d29cbc3e32a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("bba04301-c185-431b-ba20-985d19460f47"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("bc7d9af0-9789-47dc-81c9-c3adfc5e68f8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("bca53d0b-7b6a-4205-bc9d-567a6897939a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("bcf71ac3-b9bf-4165-ad08-c96935f61f57"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("bd89dcde-57eb-4457-814c-8aecbd38f584"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("bdfa341b-e0b2-477f-b3ab-1e22449e73fd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("be7e474c-2bc6-4b2e-917e-341b45f8ba4a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c001636c-7d73-490b-b479-98c0a840d8f0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c00f98db-9802-46e1-881e-9e4365dbf1d3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c07b15a6-a075-4da4-b78a-8c349fd62b0b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c09c5278-844a-471a-842e-f818dfe8a064"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c0db589a-b730-4dbe-9394-cce864444577"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c1ad9e93-f792-4227-be91-f9c0eda7ce42"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c1c4d2fd-491c-404f-a437-9060a34e584d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c230db9f-1c85-4c18-bc88-8f7310ef0a30"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c2614c9b-fc93-4d31-b087-25f9cd6c08e7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c352d61e-1e17-4948-a23d-8e8fea7dea10"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c3b1e2ef-5a09-49c9-a74d-d5e323cad2f4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c3fdc550-f817-4542-bc73-4316fc5a8e53"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c42581fa-c125-400e-adaa-175311a89b3c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c477f961-6313-4ad3-b57d-85cce9ab7141"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c478145c-640a-4225-a3b3-e127fc336f7b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c48fc700-c609-47c2-acf7-87221e8f9c4b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c4c9cb0c-5f73-431c-9bc6-5ba068403929"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c5a4e05e-8936-46bc-978e-7c7ffab5e235"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c5b9e871-f8e6-46da-ba89-ca3e00347fa9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c5e64cc2-be3f-4d33-8c3a-aa4bec30a1d3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c6528414-a321-4813-a382-101310c5d189"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c6d08278-b36e-4e60-a2d1-a4124ecbb426"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c70c64ee-faaf-4d59-b735-5f927a1adce4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c79a8647-91d6-46d2-ae3d-c0b38af6d054"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c8cf273a-479f-400f-911b-9f9acd1383cc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c8d07d5e-d60e-47dd-aa7c-98e6e51ed83b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c934a091-ee21-4aa5-8a65-d16678253710"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c9535bb0-5c0b-47db-8687-06d17ef6329f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c9602445-a66d-4959-8433-43d10471c02a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("c99269c7-5da5-4cb1-a742-93d501c0e26b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ca036b0c-7668-496a-9861-7e590f93e49f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ca4330ec-5d55-4bdd-8b83-2a7086ad30c8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cab07303-0a19-4dcd-b33c-a9dcb62421d7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cb5affe1-1af8-46db-a843-7d621583187c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cb6c9ea1-2bae-422e-b681-474ddbef5cef"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cba64586-c49f-46c8-ad1f-b16352fed48a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cbabf26a-1ac5-4037-aee5-fae4ad8edf50"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cc8819e7-6fc6-439c-8a16-9e96a5565e68"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cca5f9b0-04f9-4774-a1e1-0b481a4fa6c4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cdfc11c8-804a-4745-8205-437667b581bc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ce1d0278-4ec3-42e4-86a2-acd0e8447ce0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ce4361ec-e0a0-479d-a74b-1aaf7f714374"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ce5888e9-0c1d-42b0-8849-1634b4ba13e2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ce6e8918-a082-4a77-9c6b-c0f8ec67074c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cf07c4dd-0750-47b8-b20f-951f4ed4d5b4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cf269fab-2dc9-48ae-b999-b32e562c2c27"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("cff60635-35f7-4c88-9c81-b973d7ea4eb3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d0c5ebd2-5a7b-4d4a-9838-f35c6e41612a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d21d9b6c-369c-4909-838b-6e3dca700461"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d22147bb-bf5f-4dad-a469-931f4bfffeae"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d2230972-adb6-4539-aa12-6b55b2bd76dd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d2460b98-8b09-45f0-87a7-4423a246f1ae"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d4150e24-eb99-4c59-9df8-e521f62cff0e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d4abd1cb-f03d-4b2a-b4a9-5e61f14b2361"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d4ae25bc-7f08-48bb-a677-c7cf96c23203"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d4dce986-9459-43fe-aeff-fa2fd931d205"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d4f6888e-7c3c-47a6-bdd4-01a0636ec073"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d5565dd1-1bf8-4eb5-ac5b-ac7985808207"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d58fbd72-b83d-4f37-9490-bb06cdd5cc65"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d6539243-2786-49f4-8483-c66fd0b4a2cd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d669a6e8-3abd-4b12-a699-5a5caba00805"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d6c8bbb4-53f9-4241-8587-ed7034bad47e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d762f21d-ed92-42c0-984a-ef298d7104ee"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d7782077-9a73-490d-8b25-3e6108592541"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d79bc59a-33f8-470b-bc21-455534071a7a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d7adc19a-70f1-4138-97ad-3d3e270dbb01"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d7f4aca9-f7c1-4480-946f-3a50bcca6586"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d8090422-e3ee-421d-b2f0-04f140dd3123"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d8942f3f-2506-4fc6-9832-0a04d22e90b9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("d92e5f9f-5f60-4f6a-a8f4-bd598f34619f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dad06f3c-5e66-4140-8cda-114cfb789684"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dae17fa2-bf6b-464d-a7ab-e01aaed4b617"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("daf080de-f040-47d5-bd0c-f59c00554551"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("db7ee808-5d5e-430c-8bcd-b0b6fd2e923f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dbcda5aa-0651-4a63-8257-b2b2ea8d1be8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dbd5d7a4-6cd1-466a-8682-6e41909bd9e7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dbebf7e5-c84b-43b4-ba9c-b461d06226ce"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dc39c6d4-5247-49b2-a581-9941f04896f7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dc504257-bcd3-4733-9feb-83cfd4088d28"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dca066aa-0c5c-4742-9880-c46af12fbfd4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dcde2d3c-5d42-426f-80e9-352affba2f26"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dd32ab96-1ab8-4c00-87d5-90fea082c13b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dd6062cb-cfd1-4cd4-a404-08f11511b7a6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dd6a690a-2866-4503-b89b-f74861a21e29"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dd744fbf-faec-40ec-9a3e-a98af77a7a27"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ddd67f9e-6308-4e61-ad36-9fe998a41b8c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("de613895-b32e-4d00-8852-dac974d2d70d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("de7d3611-3d63-4e08-bca2-d011149bf7a0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("de8a29f4-65db-46fd-91cc-34899401b92e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("de927edd-8485-4d8d-b7c1-d5104dcd2fea"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("dedc9df9-a631-4599-84d7-d687cd81aad8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("df10b201-3e41-45a4-98b6-1b5827ddbda8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("df245373-3b54-43de-8ecd-593e4e92c112"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e000aa59-d4d9-41b4-b743-41edace821a0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e038f73d-c33b-49eb-9b93-5eb18a1de448"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e0bf9baa-7fbd-4341-bf8b-9a0e1d3e9e50"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e0cff931-4b61-4de3-a72e-6bf5ed2b91e0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e0d7dbed-a941-4dc4-ba0e-66c579ba7523"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e123c8f0-a041-4e17-b95c-f87a74104f15"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e1f6e867-d02c-4f60-a2c5-459208454175"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e207788e-f82a-4d60-b49e-c68e859331ab"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e29b3d10-dc10-486d-b471-79d74c3fb10c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e2cf929f-47bc-4585-bf4f-35d1c8629892"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e335dbca-d275-4869-9139-8565cff84fd8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e34781a6-3bf6-472d-b0dc-769148a884b5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e3995255-8641-425a-8127-d61c18548de6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e41fa383-ec10-4875-ad08-a261a1140abd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e429b85e-2c39-4702-a6fe-bb85a8598feb"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e45b21f7-4d05-4adc-8df8-a821a4aeedfd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e4663342-b59a-444c-b479-26195176ce74"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e54e7fcc-9e8f-429f-9087-e7fded0f5eaf"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e55d92da-38d1-492e-989f-dbff12b49f6c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e55f2812-8d2f-43ad-b18b-a9d638d9e602"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e5706c6d-d2da-461f-aa9e-156642fdefab"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e5d571cb-1b35-4c54-9f98-aa1221ed474c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e6082136-d018-4849-9904-a4b139a9d367"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e611d18e-66fa-4caf-a955-a4511db3583b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e64cf708-ed94-4ba7-bc41-76a607758db6"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e6c5ae09-c182-4bd6-8ae1-f819d3bbf03e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e6cb1506-7f77-4de6-abb7-6963f3e28ce1"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e7191f13-46e9-4f68-b831-a3ea4467773c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e739617c-24d3-4064-86b8-bcbcf43a059d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e84729d2-c9fb-4b0d-aa35-851773785881"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e8852133-a81a-4d81-bc10-22897c577e6c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e8a39224-546c-4ec7-8cc7-b46a676a3ad0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e8fc94bf-f078-4cf1-a7b0-09a2d72cc9e0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e909b713-fbdf-4bff-84a1-0e6aa0a4df74"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e9458afa-7652-4971-80f7-cb216b79a0c8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("e9bcb9b4-ddaa-40eb-a0cf-ec17989192ec"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ea4e5d9b-bc59-45fc-ba75-2d163041fd46"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("eae5a262-3628-4d06-a3a2-cc92a8614c2f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("eb0f3b05-6b63-40c6-a441-448f0272210a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("eb5bd3f6-de76-428d-9eeb-dd6ac6b59c0a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("eba13e0c-0770-42e7-ab80-587a4c2c5341"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ebba0282-966a-4b3e-9abb-2c8ff8079a8e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ebd02a7e-baf7-4203-9d32-a2ebff87424e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ebdeff1f-04db-4eaa-ac24-7cf232e2cf8e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ec5b7426-ad3e-4c34-8788-2c6c5729859e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ec5f11c5-469b-4cba-a61f-6f13713ecb09"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ec9194bd-d2ce-4b08-9904-f92f2e2b63b9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ed0e9daf-cb2b-4705-aa2a-a5ec35047803"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ed64dd0e-6403-4507-9dad-b3cc359e454d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("edc334b7-9856-4a2c-beb2-4ab3fe708bd3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("edc831e9-3ffc-44ed-ba91-cb71bada183c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("edc8bb7e-a7a7-426b-8208-3b1279524d87"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ee019e5a-f668-4408-ad38-bbaf11600efa"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ee277731-31f3-410f-ac70-fa487aec8539"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ee81471c-a708-421f-81af-24851932457f"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("eeb16967-8f98-493d-a34d-236a1b07f38d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("eec44653-40c8-4a1e-9a05-ea647c4bc845"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("eed4d211-0559-4da3-98d1-8e748e362fd3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ef5f291b-29c7-4488-8fbe-b1ad8f4f4691"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ef8f482d-9c13-4995-a4c5-c49d32a5fe8a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("efbc66e9-df95-4905-b80a-b5ea5b15b900"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f0091e03-0266-419c-b174-074f7ed3dbc9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f012b950-604d-4ab5-8bf9-9aa76d3c40be"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f1347f80-385d-4b7f-b899-da1addd6acd0"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f13bd93d-29d7-4bdd-94b1-7001afd7fb0b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f149edd4-1139-4dea-b65a-4af14c8021f8"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f1a4f65d-d2fc-4628-966b-814f02600bcc"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f20771e2-1f26-41fd-a876-952226ae776d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f265dce4-dc72-4734-b3f1-75c53bd51e9a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f2cb6d2a-b9eb-4c1e-9772-38425cfac2e3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f2d149de-48e9-4111-9cde-e2e17bca6900"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f335638e-4df4-4fb0-b765-f61e393b589b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f33e565a-c05f-42b4-808c-785033828b81"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f3633a7c-6294-4a2b-9f2b-57560c8b7ee2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f383e749-84f7-4fe4-98dd-bcfcfd939391"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f3ab802d-2c23-40b2-8856-eda6eacae739"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f3b6d572-fac9-4d68-baac-580b8459ac12"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f3bc25e6-fd45-40df-bb9f-9c56159e29a7"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f3c24571-d518-429f-8c8f-244ebe978a2a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f41ba8ea-3e94-45a5-9081-e24876a906ae"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f4daabb0-8945-4219-8dcd-c1f26339581e"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f4f3b798-53fd-42de-8fe8-91b74333294a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f5947b64-dd0c-4799-b966-1921f3e004b4"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f5bf9265-8268-454e-9e4b-e64fff8d5f13"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f5e7472a-43fb-4df7-9046-ce6d79ee57f9"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f658b23e-dfa5-41c8-a954-f9d2d2523d87"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f72981c2-8da1-4503-a902-de0e9a3f8655"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f777e591-641c-4d59-a0d8-42ae6fa8d719"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f7937455-47ab-4747-81aa-f59bcf6cf62d"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f7b6e141-0b61-4b8b-adfa-358529d56a3c"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f7d86282-7de2-47b6-9705-0bac5a3547b5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f82816fd-7099-4ecd-8235-2c3762b63777"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f86db9bc-5cf9-4749-97a8-2d1101b1e148"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f8d33c9e-1efc-45b1-975e-5bc4382a3220"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f8f64547-4c5e-4be0-8472-52f0413f0c61"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f8fb887d-bac4-4ea5-91c9-ded4b1090223"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("f9bf2296-ecd8-4164-9427-4d53f4deb110"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fa7d677a-777f-4ac2-aa3c-a876088d733a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fa7da3bc-8afc-4b7b-9ca8-4036716892ae"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fac5618e-69a5-4ddb-8cab-2141aea0c2bd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("faee37d1-964a-45be-a1af-c34473953224"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fb006463-95bc-4963-a976-38447abfb093"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fb7a6076-71db-4d7f-bfe0-cee7ecec9058"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fbae5c2a-d3d2-47ce-8bf7-3776c6832fb3"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fbbfe4ec-452d-4fb2-a2e9-b6a5dc31f77a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fbc466a9-75ed-41b1-ac2a-fc032026fbb5"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fc497b1d-8574-4bd1-bf63-1b9e1ea374e2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fcad4f0e-49f1-4564-ad74-49fbe66d285a"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fce4a99d-4070-4b09-9519-6439deb364cd"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fd681dc5-3a55-4964-aa9a-4c2b18694b56"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fe3fc777-80be-4cac-b4fc-eee247a13221"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fe3fe6c0-515d-4ef4-a62e-c45c48e2bc01"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("fe68db50-5da8-444d-8060-249c525db3e2"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("febedf95-2e84-4c89-8647-d41a94cfb566"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ff23b2cd-2787-4d84-87cf-d09407406a7b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ff36878d-9473-499f-b367-512ed45bf09b"));

            migrationBuilder.DeleteData(
                table: "RSCAProcess",
                keyColumn: "Id",
                keyValue: new Guid("ff600d52-7435-4009-9d2e-7b1a8fc45646"));

            

            

            

            

            

            

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("007e1744-112d-4126-90a3-68767d716c23"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("01a681f7-e570-41e9-953f-b55649caa3fb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("046a520e-daef-41b6-97bd-be8b29f34211"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10dbd193-eeb4-4423-b696-5468dabc40d9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10f181a3-91be-41fd-bd45-b93cddcad914"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18586789-113d-4d94-8054-fd09c237f238"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1cec6e8b-56e2-4e5b-ab45-c337b2173141"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1e922e6f-fcde-4cb9-aa79-dfc44efc32ef"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1eaeec8c-d596-4173-9c45-dd9dc2a1abf5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1fd61362-e3be-4644-9382-70b4b9529de6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("210fb09d-6bf1-4d99-8bab-d6f4263f5799"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2520bef2-ed4c-4eef-ae1b-d87ca8e0a409"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26180984-e4e6-4d30-9c70-80d2861698b2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28ce6fc4-2f2c-4579-975d-6e4c2acd7167"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2a608c13-2919-4f72-94a5-626573e5e26f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2aacffa1-aa73-4b41-a29a-46d489bbf1b5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("300a9d0f-6f69-4fae-9ef5-d5f1592ea4f0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("306f67cb-70ac-4177-9fcb-f007d94a94db"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31f55a02-b900-462d-a7f0-4ac283e514d9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("322d1bd5-6482-4c95-ac14-182ad3d5b6fc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("35b9869f-172e-46c6-98a4-7dc7880f74da"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("36e3e1bb-501a-44f3-b9b5-b2c90b5b48db"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("383edb3e-8ba1-4f19-8c74-0dd2d453e0ed"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3b0c3dfe-cd9d-4455-9773-caadf4065395"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3c96b599-f537-4c27-a109-4f136bda37f1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("41c5eac9-bc9c-433f-8d2d-47e6ea279fc0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("450e9818-ee59-46c5-8914-30a1803ba34b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4b50b8d1-7e5f-4683-9caf-e0b9e481ea25"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("518b58b2-01e4-4619-a456-1706ad28f43e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("51dbd356-3fdd-44c2-8c59-df75c12463af"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("54a0260a-19d4-4236-b3bc-9e537dc41195"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("557e514f-2a23-4867-b91e-85a020db43fe"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("56c5025f-2b5f-423b-9f3d-97c79c0eda8a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5afba47c-4381-4be1-b082-dfe887e53da1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5b852c8e-d62f-45fd-9ec1-d708d8030b7d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5deb0b02-51f7-49a1-8435-8f99be1c5b1f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5e54f2ae-a4b8-4fe4-86c5-c0174bcfa169"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("627a08eb-a2d4-4de3-bc88-65ec07bdefe8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("62fa4f97-1fb8-4630-a06c-08e002a00e87"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6309d084-3788-46e6-b752-40600cc1a48d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("64b41e75-ae89-48ed-82e3-b82854e65427"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("653b7bf8-b903-4608-9b1d-c81ea64fb712"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("65b78319-1a78-415f-95c6-04441ea485b0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("670b56b4-0a26-4d0a-ae76-cffd591b6f35"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("69b4b5b8-aa26-48b7-ab80-011824fa244c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("69d6d740-1075-434f-b917-ee6b0cec8247"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("70acee64-944d-43d2-a606-5fc1960a4208"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("722ee4c9-e518-4cd1-b7c1-790a840bd4a9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("747b515e-9bd9-4387-a587-74e8125265f6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("76a4e14f-4e11-4d91-a723-dcdf735558aa"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7bc62aba-3145-41df-ab1f-ef74a06574af"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7c8e0222-f16e-460a-98ad-43021384c483"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8086f715-74cc-40c8-a37d-3e634c68e976"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8294a2b4-f95f-4a88-944c-0a326d3894fd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("835f7505-c911-4700-95dd-ef08049c47d2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("85978752-05e8-420e-b865-5e9c328b7406"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8c7e6d76-2cdf-428d-93ac-16c3d4147a2d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("925336b2-62a5-46a2-b919-00dbf803f33d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9446edf4-2f71-411e-b303-65f8ba5caba0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("99c28aa4-8328-4175-8f05-fb33ff93f3dd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a3bb15c-8df7-4663-96a1-e321c031c09f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9b0e60ad-68af-4d97-87d3-d66d0f2df385"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9c1943e7-0a46-4f9e-bae3-8cd808156fa4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9da9489e-4371-40c7-837a-0cc655f63b97"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a04365ba-be36-46f1-900f-aae2f97d683a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a21c2d44-05d2-4790-8113-69dfb56f7d47"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a4b17ed6-2902-4b37-81e3-bd2fe78b099b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ab2aef8c-0c42-4408-99e1-5b9431e5c689"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ad4a20b3-7ed7-4896-8a37-a22201c6a55c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ad89b05e-82b1-4cda-b87b-f91400b01175"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b07c2110-5418-4291-98bc-7a79c65411f1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b207e71c-5092-4788-9c8e-fc40f0c09e37"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b5276249-69db-4ed5-ba5a-14ed293f69a3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bc7ffb50-2b9c-459c-97d9-4347bbd112e3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c113e852-5d57-4246-a4e5-ac01247d6783"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c746ddfc-77a3-4e96-92f3-5cbdd5060dd1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cbb03c33-6cc0-4737-90da-f0d4538252ba"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d204727a-1068-47cf-b57c-c045448efef1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d2bc70a9-33c4-4d61-b36b-1fc8764ff668"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d8b1309a-2144-4805-aaa6-ab6af8870ab3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("df0f4ab9-33d7-4616-acfe-196b4f3df2ea"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e1011d4f-56d6-4a70-a8eb-c77b54255e1e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e136923e-00f0-4054-bcfe-fcb27f9879d3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e323055f-a6a4-4341-b152-f704c87bd32e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e3ecc43b-4256-4736-b689-8b2aea0a0a48"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e55c08db-9d76-4179-91c5-3b69b3e2e2bb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e78f9fa2-a17f-4454-89fa-bbd2af61629a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e93baf37-ba2e-403d-aa6e-9daf5dac4afa"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e9a379ec-d1b8-4446-b3c0-7f3c793fa711"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ea019e87-a9d6-4174-9a18-a04d87a9a84d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eaade002-13e4-414b-9a60-c96beaea76ba"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eb6cd3cb-f022-4552-99e8-b519f48dbc76"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ed9bccf4-f56c-41d3-a2ed-801b89cf04cc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("efb16929-afaa-44ac-b2ac-a6d47151a3e5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f5d1a48f-a523-4d1b-9ca7-0a4b2e8fa45d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7355541-8c38-4db0-bc1a-2627fd8259d4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fc0b698e-deb5-4b91-9341-dcc1648f5f33"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fe01f322-eb7a-416b-9678-7ccdd9b637c2"));
        }
    }
}
