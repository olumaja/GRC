using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class seedingUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "DepartmentId", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("003ed424-1724-44b1-bcb1-924abb94e338"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4471), null, new Guid("8d7eedf4-3714-4ab6-bd81-c6d87058407b"), false, null, null, "Risk Management" },
                    { new Guid("01ac6f97-9040-439b-abd4-77c79f873d79"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4204), null, new Guid("cee03620-24b8-4293-bf43-03d8d0e570d5"), false, null, null, "Fund Account" },
                    { new Guid("037019bf-ce11-4307-a984-170b02ca17a9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4304), null, new Guid("fa7d1d89-8a78-49ec-86fd-7ec5310a2545"), false, null, null, "Information Technology" },
                    { new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4422), null, new Guid("62645a9d-45d7-4470-95d3-30e12c649e5d"), false, null, null, "Risk Management" },
                    { new Guid("05652a26-461c-4c78-be42-f212fc5fd083"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4193), null, new Guid("3b4b6872-94ef-45c4-93de-39a35fbce365"), false, null, null, "Commercial Trust" },
                    { new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4145), null, new Guid("8c9b5665-1e3b-45c5-8f08-1d4836487b12"), false, null, null, "Registrars" },
                    { new Guid("07d965be-1bd6-40df-bfe9-9679b6a4a3c1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4140), null, new Guid("428fa69d-36cf-4fd3-9bba-d4a45dff366b"), false, null, null, "Proprietary and Principal Transactions" },
                    { new Guid("0845fb19-2120-461d-b291-74e1aafa9adb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4084), null, new Guid("f5bbaf6f-6593-4b31-87fa-8704088ecff3"), false, null, null, "Port Harcourt" },
                    { new Guid("085af12a-41d1-4516-adc4-7e6aba212354"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4002), null, new Guid("76b853d0-f625-4e48-bdcd-5cfb930ff181"), false, null, null, "ARM Financial Advisers" },
                    { new Guid("087015b4-acdb-4487-a687-0f084390f387"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4275), null, new Guid("7f042f8c-2e1c-410b-9892-525d3cdc7bcc"), false, null, null, "ARM Academy" },
                    { new Guid("0aacc5ae-ea42-41e1-98c9-9b28d3628d08"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4074), null, new Guid("c5cc333f-018a-4f43-9a77-1b3d2a8b565e"), false, null, null, "Wealth & Relationship Management -Lagos" },
                    { new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4475), null, new Guid("01b5cda8-819c-49d6-ac53-d6d38fde3b99"), false, null, null, "Internal Control" },
                    { new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4117), null, new Guid("74ea2a08-c9e4-4d76-853c-fea704def351"), false, null, null, "Internal Control" },
                    { new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4206), null, new Guid("0d7ec4b9-58ff-4dd1-b29c-9bf526cae665"), false, null, null, "Call Centre" },
                    { new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4320), null, new Guid("203a95e8-1dbb-4957-ad3d-e2199facd3df"), false, null, null, "Corporate Strategy" },
                    { new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4309), null, new Guid("e31ff356-9785-4e9f-ab1c-018b4bc65483"), false, null, null, "Internal Control" },
                    { new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4488), null, new Guid("6f4bde6b-21ac-4631-b7da-0d3bd0ce2a95"), false, null, null, "Legal" },
                    { new Guid("12fc7195-2c3f-4bca-88b4-beef3f234d01"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4403), null, new Guid("51850e25-0a19-4bfa-9cee-b3ea1cd09ec1"), false, null, null, "Lakowe Lakes Golf Club Ltd" },
                    { new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4321), null, new Guid("2cd5e5f8-67c2-4216-9684-2550888f86d1"), false, null, null, "Legal" },
                    { new Guid("156818e3-1ea6-42b0-a785-7dfaac6f5371"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4174), null, new Guid("0529a58d-3fec-47d9-baf0-5f588014ab1d"), false, null, null, "ARM Academy" },
                    { new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4156), null, new Guid("b425cf7c-40b2-4419-89df-8bc891b2e15e"), false, null, null, "Call Centre" },
                    { new Guid("16bedab4-1eb0-484a-9845-e1581085f146"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4202), null, new Guid("cee03620-24b8-4293-bf43-03d8d0e570d5"), false, null, null, "Retail Operations" },
                    { new Guid("185e0a8b-5aa5-43e5-8828-edeae97cd121"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4375), null, new Guid("16201b11-7d0d-4d2c-a632-4408439672da"), false, null, null, "Enclave" },
                    { new Guid("19331c05-77f0-4f49-bb90-2af3a78a7793"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4177), null, new Guid("3bcf36b7-e55e-4f3e-8edc-4c537f74d9d1"), false, null, null, "Administration" },
                    { new Guid("19704b51-99bb-439f-a4db-6603c6089a58"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4443), null, new Guid("27446c0d-a9af-471f-8a83-7e9a31ade74d"), false, null, null, "Human Capital Management" },
                    { new Guid("1df86816-2842-4941-8710-36822d6240e8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4292), null, new Guid("8de5a8ea-0f58-494f-b022-8a403e34d840"), false, null, null, "Call Centre" },
                    { new Guid("1e382c5d-6b22-43a6-9ce9-521244c1f555"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4398), null, new Guid("d05f8a34-201b-458e-af3f-d546aa51ba93"), false, null, null, "Greater Port Harcour Golf Club" },
                    { new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4245), null, new Guid("54fe23d5-e9fc-4ec2-82d6-f294ae6aba1f"), false, null, null, "Legal" },
                    { new Guid("201b2b9b-55a4-49eb-82b7-05afb9110eae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4136), null, new Guid("7ad4c706-19c0-4e01-a9b5-1686059e0180"), false, null, null, "Co.Sec" },
                    { new Guid("209cfd77-d2b6-4264-963c-bd02558837e4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4138), null, new Guid("5c23a138-65a5-4c07-9dc1-1fc581abeba1"), false, null, null, "Human Capital Management" },
                    { new Guid("2108a385-5b39-4953-97e7-216523683078"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4066), null, new Guid("ea5061d7-5ff1-419b-aa65-3f6e820d215b"), false, null, null, "Human Capital Management" },
                    { new Guid("2289ecd3-d422-42e9-95d1-aa91425d1c0d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4277), null, new Guid("00805aae-25cb-4540-83a4-5f8891e6687a"), false, null, null, "Coporate Transformation" },
                    { new Guid("2324ca19-a743-485a-b49a-d04b5a1ec0a0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4354), null, new Guid("8948b589-f3d6-4166-9c85-083eccf50ef0"), false, null, null, "Internal Audit" },
                    { new Guid("23f36ca8-a0ce-49bf-be0c-66366eff3c51"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4367), null, new Guid("7252a7d7-b535-4461-82c8-10ce3cda075f"), false, null, null, "Compliance" },
                    { new Guid("2470d7cf-0bea-49c7-a2c7-04c9fa36ade6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4379), null, new Guid("16201b11-7d0d-4d2c-a632-4408439672da"), false, null, null, "Village" },
                    { new Guid("2570f9e3-7c71-41de-9a32-0981e29c14b3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4355), null, new Guid("2b4a09bb-d50b-4af2-b635-b7df21581795"), false, null, null, "ARM Academy" },
                    { new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4094), null, new Guid("2bcee133-d95c-4662-b71a-40197ae725a0"), false, null, null, "Operation Controls" },
                    { new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4305), null, new Guid("95fa75c8-5e83-4696-a739-bec98c3bd9ea"), false, null, null, "Risk Management" },
                    { new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4088), null, new Guid("2bcee133-d95c-4662-b71a-40197ae725a0"), false, null, null, "Fund Admin" },
                    { new Guid("2abce038-72a5-4fd5-9cfc-deef8348f4d0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4342), null, new Guid("098ddce3-8aea-42d3-a3aa-e2c7b3a40bbe"), false, null, null, "Financial Control" },
                    { new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4458), null, new Guid("8bcaabe1-68e8-48d9-993c-037bb38b1a0c"), false, null, null, "Customer Service" },
                    { new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4200), null, new Guid("cee03620-24b8-4293-bf43-03d8d0e570d5"), false, null, null, "Registrars" },
                    { new Guid("2d544b75-9bda-4aff-a212-a2998fc28cfa"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4378), null, new Guid("16201b11-7d0d-4d2c-a632-4408439672da"), false, null, null, "Platform 30" },
                    { new Guid("2e1919c1-fdae-4023-b602-6c3584f2b95b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4061), null, new Guid("e0649b38-ae55-4664-9b1e-07c93d4d0c47"), false, null, null, "Compliance" },
                    { new Guid("2f7f4b7b-25de-490c-9db4-5ecbb9265268"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4432), null, new Guid("efcc9848-f2b7-43f3-a5a5-880ff82af57f"), false, null, null, "Administration" },
                    { new Guid("30306755-5207-4d72-9c62-359afa8a5f0e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4325), null, new Guid("2cd5e5f8-67c2-4216-9684-2550888f86d1"), false, null, null, "Co.Sec" },
                    { new Guid("30c9c38f-23b7-4694-acd9-bac0da70eb4e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4381), null, new Guid("16201b11-7d0d-4d2c-a632-4408439672da"), false, null, null, "RDP" },
                    { new Guid("329d8cac-d18b-4a9b-bd38-8535e19d2b60"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4459), null, new Guid("9e8c92bb-3e4b-4dc7-a5e6-bb3a8562b3d3"), false, null, null, "Financial Control" },
                    { new Guid("32a964ce-a439-4c80-9a36-f7774706ee32"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4264), null, new Guid("203d9306-73ee-4f90-b4b5-84da8c23d7f4"), false, null, null, "Information Technology" },
                    { new Guid("33cdd2bc-364b-4975-a2ba-3f40cecca022"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4359), null, new Guid("1ef96ef9-a51f-4632-8aa1-eb844abce381"), false, null, null, "Administration" },
                    { new Guid("35a7256f-7c2a-45ea-8cbb-2e7509b1cd21"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4416), null, new Guid("5f813a8d-b1f6-4271-a8f1-1fe8da637b31"), false, null, null, "Business Planning" },
                    { new Guid("36998696-f319-43d4-bcbf-61b52d0556bd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4483), null, new Guid("500cd5ee-7fac-4285-80d3-9e3a86869ba2"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("36e6ae73-2270-40ea-ae16-64d610c1e5b8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4270), null, new Guid("e082844a-52c9-4719-a2da-a10cf49f82e6"), false, null, null, "Real Estate" },
                    { new Guid("389e0846-2dfd-4e66-91c7-b7c37a565c70"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4119), null, new Guid("74ea2a08-c9e4-4d76-853c-fea704def351"), false, null, null, "Internal Audit" },
                    { new Guid("38bf0e6d-58f3-47f8-8324-4938c42ac62b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4344), null, new Guid("098ddce3-8aea-42d3-a3aa-e2c7b3a40bbe"), false, null, null, "Treasury" },
                    { new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4197), null, new Guid("cee03620-24b8-4293-bf43-03d8d0e570d5"), false, null, null, "Fund Admin" },
                    { new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4310), null, new Guid("e31ff356-9785-4e9f-ab1c-018b4bc65483"), false, null, null, "Internal Audit" },
                    { new Guid("3bc7f31c-9502-492b-8a0d-4204be7a5614"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4262), null, new Guid("02eb6692-18d6-49cd-9404-1225dfe8bcc1"), false, null, null, "Treasury" },
                    { new Guid("3d1ba0a1-ce2d-4806-b60e-4002c054f341"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4417), null, new Guid("32bc8c7e-cb36-42f0-88f3-96da17bc5b80"), false, null, null, "Financial Control" },
                    { new Guid("3f4ee577-f743-4614-adda-5bd4e641c85c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4044), null, new Guid("b36eff41-501d-463f-b764-b7998a4d039e"), false, null, null, "Coporate Transformation" },
                    { new Guid("3ff75ac7-8e21-4e8a-8895-a77a4dfb5dee"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4336), null, new Guid("1ac6a090-f8d8-4c57-b604-036f61257463"), false, null, null, "ARM Agric Fund" },
                    { new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4068), null, new Guid("81b3631c-84bd-4357-8919-ce9a18c42720"), false, null, null, "Investment Management" },
                    { new Guid("4221d035-01ed-4439-8829-d9b73f9e5a4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4439), null, new Guid("2dbd67f5-a20d-4ce7-a147-707e1e8bc31d"), false, null, null, "Compliance" },
                    { new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4445), null, new Guid("86bfe07d-57d0-4c7e-b778-6c4b3967ba49"), false, null, null, "Digital Financial Services" },
                    { new Guid("42c3cab6-ccbd-452e-8f84-45993337f2b3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4051), null, new Guid("0dbc7eba-bc38-4b8d-af59-92769cd22afc"), false, null, null, "Corporate Strategy" },
                    { new Guid("444a03bb-a3d4-4cec-a76c-eeabda66003a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4238), null, new Guid("013f1c1f-994f-4178-a82a-98293abf3fd9"), false, null, null, "Corporate Strategy" },
                    { new Guid("44fe054d-83dd-41da-b90a-a53631af453d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4253), null, new Guid("cc56bbaa-4c91-45a8-bd01-276b89a49028"), false, null, null, "ARM Harith Infrastructure Investment Ltd" },
                    { new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4025), null, new Guid("db8cd93a-2aee-465c-aee1-ebc408ad3501"), false, null, null, "Financial Control" },
                    { new Guid("456575f1-a8db-4fd9-885f-8e84e096c860"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4129), null, new Guid("aadf66e4-2e68-42dc-9fee-dfc99e037236"), false, null, null, "Corporate Strategy" },
                    { new Guid("4771bfd1-bcba-463a-84ed-f6e8a53f207a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4395), null, new Guid("97966912-7879-4358-b802-c71cfd610871"), false, null, null, "Adiva" },
                    { new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4092), null, new Guid("2bcee133-d95c-4662-b71a-40197ae725a0"), false, null, null, "Registrars" },
                    { new Guid("4914b69b-1b5e-499a-8350-9fcf5b2e4dca"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4373), null, new Guid("16201b11-7d0d-4d2c-a632-4408439672da"), false, null, null, "Summerville / Lakowe" },
                    { new Guid("491cdc51-64aa-4f6b-b5ba-b036b0174852"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4405), null, new Guid("a8e98921-579a-4824-9bb8-ec5f4254b32c"), false, null, null, "Townsville" },
                    { new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4023), null, new Guid("d2f7a060-2f44-4714-98bb-f03741d918d2"), false, null, null, "Customer Service" },
                    { new Guid("500fc670-2f14-4786-9092-f7f82b8ae507"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4108), null, new Guid("f6c2a424-bf74-4f64-a6ea-eb1466730bf1"), false, null, null, "Lagos" },
                    { new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4053), null, new Guid("e0649b38-ae55-4664-9b1e-07c93d4d0c47"), false, null, null, "Legal" },
                    { new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4451), null, new Guid("f3506495-7e1a-41b1-ae2a-4bedd308c2b1"), false, null, null, "Registrars" },
                    { new Guid("52ae7cc8-1382-4c45-833a-84e78a2de191"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4172), null, new Guid("2a650f64-bb8c-4529-a02c-d9e6ded8dd77"), false, null, null, "Internal Audit" },
                    { new Guid("53d0cdd2-2aca-417f-ad11-92364253defd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4272), null, new Guid("4ee4f005-2ab1-43a9-a714-78649319e467"), false, null, null, "Internal Control" },
                    { new Guid("54578f13-6ee3-418d-aede-e77041ef4878"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4195), null, new Guid("6dcf8606-8ba4-4310-8acc-2a6ad3e7ff57"), false, null, null, "Investment Management" },
                    { new Guid("556d5367-6794-4355-974f-e2ebb6447695"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4029), null, new Guid("be805504-2141-44dd-b6f3-0718142df7ae"), false, null, null, "Information Technology" },
                    { new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4424), null, new Guid("d9955013-91b9-4200-897e-cb3cc9ec45aa"), false, null, null, "Internal Control" },
                    { new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4086), null, new Guid("2bcee133-d95c-4662-b71a-40197ae725a0"), false, null, null, "Fund Account" },
                    { new Guid("575a8a92-112f-4752-a875-24999b3f69ca"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4070), null, new Guid("c5cc333f-018a-4f43-9a77-1b3d2a8b565e"), false, null, null, "Institutional" },
                    { new Guid("598f6cac-69ce-47bb-8be4-f0697c1eb47e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4190), null, new Guid("1bc03880-d977-40df-b4f7-02b031cf7a13"), false, null, null, "Human Capital Management" },
                    { new Guid("5a64f00c-b288-46b3-aa77-ecc4d35b212d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4472), null, new Guid("7e9ed9b4-f4cc-4ae3-800f-dc2e0b614f8f"), false, null, null, "Project Management Office" },
                    { new Guid("5a96a0a8-8d71-45dc-9736-befceefbecb4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4446), null, new Guid("e29ab0a4-f3d8-4ee6-a03e-acba120fd7cc"), false, null, null, "Investment Management" },
                    { new Guid("5b77ef60-1c4a-474a-a320-30b120509229"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4419), null, new Guid("32bc8c7e-cb36-42f0-88f3-96da17bc5b80"), false, null, null, "Treasury" },
                    { new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4105), null, new Guid("f6c2a424-bf74-4f64-a6ea-eb1466730bf1"), false, null, null, "Abuja" },
                    { new Guid("5cf04c21-a4c1-45f2-a80c-9ccd03aec033"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4486), null, new Guid("f56e3da6-b318-4ade-89e4-f6d03aec0973"), false, null, null, "Corporate Strategy" },
                    { new Guid("5d296ac9-f9f9-4f69-bb40-0f8b616a6d0c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4414), null, new Guid("15c808a9-658c-4a88-885a-59654f6d376f"), false, null, null, "Crosstown Iju" },
                    { new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4331), null, new Guid("dfe3332e-0098-412b-bcd6-9599bef354ea"), false, null, null, "Human Capital Management" },
                    { new Guid("5e3f8a3a-4451-4153-8871-eaf7f24aa0e2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4338), null, new Guid("1ac6a090-f8d8-4c57-b604-036f61257463"), false, null, null, "ODA" },
                    { new Guid("5ec15a12-324e-429a-87d7-af5b945a4859"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4348), null, new Guid("c7db68c2-9dd0-429d-bdad-dbd5af1a1978"), false, null, null, "Risk Management" },
                    { new Guid("5efbbf5f-3081-4492-9ec4-b8880b3eb06e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4360), null, new Guid("2c04365f-3fd6-491d-9ef1-13751fbe8b32"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("64e5f632-d1a0-4ed0-b133-629f6c5d05c5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4393), null, new Guid("7be57b73-24b7-4e03-8c75-ba06181ac887"), false, null, null, "Design" },
                    { new Guid("65757b71-e2fb-490d-ba49-20e94ee3623d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4273), null, new Guid("4ee4f005-2ab1-43a9-a714-78649319e467"), false, null, null, "Internal Audit" },
                    { new Guid("659a83bc-cee9-4939-8669-d2c5617b7845"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4397), null, new Guid("bb950e8a-57d5-4795-b027-7ef594142df2"), false, null, null, "Beechwood" },
                    { new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4150), null, new Guid("8c9b5665-1e3b-45c5-8f08-1d4836487b12"), false, null, null, "Fund Account" },
                    { new Guid("67552124-7cee-4f19-8e6c-4b9598f1510f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4127), null, new Guid("f1baaf91-b927-4ed0-ae14-9446760caf96"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4312), null, new Guid("0b6029b0-97b5-4dcb-af24-ea214143b795"), false, null, null, "ARM Academy" },
                    { new Guid("6944d275-92d3-400f-bf70-00f6d9a271ba"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4125), null, new Guid("f5bdf107-f9c6-4c13-b41f-b1ba55568906"), false, null, null, "Administration" },
                    { new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4165), null, new Guid("4ef41c3b-77f4-41e8-89ce-05869eb3fac8"), false, null, null, "Risk Management" },
                    { new Guid("6b2c5f66-56fe-4a29-9393-5a8b7623d880"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4034), null, new Guid("657ba2bd-1ca7-47f9-9518-b09103df8000"), false, null, null, "Project Management Office" },
                    { new Guid("6c300c5e-fba6-467e-952f-4bb3d1d15ea4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4480), null, new Guid("1bab317b-253a-4b3d-b5c6-21f1ea4e95b5"), false, null, null, "Coporate Transformation" },
                    { new Guid("6cfdabd5-52e6-465b-8cca-5b23aead61be"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4435), null, new Guid("8c756839-450f-4ba7-bb42-aa26399d452f"), false, null, null, "Corporate Strategy" },
                    { new Guid("6d33101c-f8c2-44f0-8774-5eda11b05df3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4255), null, new Guid("cc56bbaa-4c91-45a8-bd01-276b89a49028"), false, null, null, "ARM Harith Investment Ltd" },
                    { new Guid("6e7c4307-421c-4f26-9216-a740663cdebd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4072), null, new Guid("c5cc333f-018a-4f43-9a77-1b3d2a8b565e"), false, null, null, "Wealth & Relationship Management -Abuja" },
                    { new Guid("7116856a-f88c-4bdf-b7d4-92e8e241c8ea"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4489), null, new Guid("6f4bde6b-21ac-4631-b7da-0d3bd0ce2a95"), false, null, null, "Compliance" },
                    { new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4266), null, new Guid("7eee5e9e-f47d-4f90-bc9c-b8502f55298f"), false, null, null, "Risk Management" },
                    { new Guid("757ecc97-7a10-420e-b919-2ac7aa557b3e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4441), null, new Guid("2dbd67f5-a20d-4ce7-a147-707e1e8bc31d"), false, null, null, "Co.Sec" },
                    { new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4184), null, new Guid("9f6edbba-294b-4526-9175-e8ec4950a564"), false, null, null, "Legal" },
                    { new Guid("772f854e-c9f6-4428-bad1-53db881e28bb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4141), null, new Guid("a39a7edb-e4d2-4bd1-959c-9a82b03ded14"), false, null, null, "HoldCo Sales" },
                    { new Guid("77635858-f888-45c8-9a6f-df2f5ac50670"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4219), null, new Guid("45cdfa60-9130-49ed-9fdf-845f34eca48b"), false, null, null, "Information Technology" },
                    { new Guid("789c6900-e5a3-44d4-9e6e-f165c0f94650"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4339), null, new Guid("1ac6a090-f8d8-4c57-b604-036f61257463"), false, null, null, "Advisory" },
                    { new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4191), null, new Guid("7222488c-5f14-4d9f-9d53-d1cf0ee621f4"), false, null, null, "Private Trust" },
                    { new Guid("7979d030-e342-426c-b1e6-6ce2ba29cb20"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4280), null, new Guid("92708b32-f123-452e-9589-8d191e51f524"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("79f64fe8-0a3e-4f2a-b499-8f48e6ea37e8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4430), null, new Guid("67f97d9b-6a96-431f-a6ee-080e58220b8d"), false, null, null, "Coporate Transformation" },
                    { new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4456), null, new Guid("8bcaabe1-68e8-48d9-993c-037bb38b1a0c"), false, null, null, "Call Centre" },
                    { new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4294), null, new Guid("8de5a8ea-0f58-494f-b022-8a403e34d840"), false, null, null, "Customer Service" },
                    { new Guid("7c0261cb-0d3e-496d-aa86-9cf5f37da1ae"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4434), null, new Guid("74ed3363-3053-4e12-afda-8aa3a9ba5394"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("7d22672e-a552-4944-a418-d7678717c193"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4346), null, new Guid("53c3f01b-9c1d-435a-8f98-59a2f16f91c6"), false, null, null, "Information Technology" },
                    { new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4207), null, new Guid("0d7ec4b9-58ff-4dd1-b29c-9bf526cae665"), false, null, null, "Customer Service" },
                    { new Guid("7fc65d4a-e0ad-4274-b1ba-c447f49cd208"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4234), null, new Guid("c76cf258-40da-497b-b3ca-5035438c23c5"), false, null, null, "Administration" },
                    { new Guid("80245081-74bc-4124-87f5-d6008b28706b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4107), null, new Guid("f6c2a424-bf74-4f64-a6ea-eb1466730bf1"), false, null, null, "Port Harcourt" },
                    { new Guid("83d63b3c-f20b-4e30-8384-6d603fd67bd4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4462), null, new Guid("44d0991b-952e-4c8f-ba3e-3290fe2606be"), false, null, null, "Abuja" },
                    { new Guid("840c5c87-0155-4c39-85f4-f3736f04e540"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4042), null, new Guid("43074297-ed5e-465c-be08-3a681e4404bf"), false, null, null, "ARM Academy" },
                    { new Guid("850b308d-bef3-41ad-b812-413b868e7621"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4315), null, new Guid("c19e5f07-3325-447e-a0b8-ab67aaba1390"), false, null, null, "Coporate Transformation" },
                    { new Guid("8581332b-8d77-4f1c-8a3b-79a996ff575f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4307), null, new Guid("8c800862-9634-44b8-b597-5273d8f025d5"), false, null, null, "Project Management Office" },
                    { new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4032), null, new Guid("5ba71bd0-7831-44f4-be2b-b4894ecd17df"), false, null, null, "Risk Management" },
                    { new Guid("8618dc34-8edc-471a-8bab-e7d8b0670462"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4384), null, new Guid("36b7af25-5670-422b-a961-d19591210791"), false, null, null, "Mixta Nigeria Operations" },
                    { new Guid("8a454ad0-80d6-4ded-a89e-c5e9023357ed"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4402), null, new Guid("44dc2e6a-def4-4fa1-a130-5e755ff04522"), false, null, null, "Oakland Limited" },
                    { new Guid("8eb2aa8b-3cd7-41b1-9628-436aaace8df5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4428), null, new Guid("9790b206-c748-48d8-8e3d-92e1848d181b"), false, null, null, "ARM Academy" },
                    { new Guid("8f3b081b-f835-4577-aa13-9aefd6559760"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4211), null, new Guid("b56de526-2e34-41c7-9cd3-3e38408404d2"), false, null, null, "Treasury" },
                    { new Guid("9085fd66-97e2-4f6f-91c1-84fa719168c7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4134), null, new Guid("7ad4c706-19c0-4e01-a9b5-1686059e0180"), false, null, null, "Compliance" },
                    { new Guid("90cd9708-b7b4-4203-ba98-6ce8c66e623e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4209), null, new Guid("b56de526-2e34-41c7-9cd3-3e38408404d2"), false, null, null, "Financial Control" },
                    { new Guid("941c57d3-66c5-4083-85b9-20bf746b0def"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4103), null, new Guid("52353d55-0c2c-48b8-b8fe-67c4c76380c0"), false, null, null, "Treasury" },
                    { new Guid("957f6bf9-1d02-4600-b676-6200eb6c4de3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4186), null, new Guid("9f6edbba-294b-4526-9175-e8ec4950a564"), false, null, null, "Compliance" },
                    { new Guid("985b91e0-b7c5-4521-8c9a-d312a250d497"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4246), null, new Guid("54fe23d5-e9fc-4ec2-82d6-f294ae6aba1f"), false, null, null, "Compliance" },
                    { new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4285), null, new Guid("0eb79555-2e7e-4e98-95a3-8b09e35c8f65"), false, null, null, "Legal" },
                    { new Guid("9a3f56c3-6249-46eb-880d-01b01cbe7078"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4279), null, new Guid("07a11106-3e41-417e-bc54-7f29a335c51e"), false, null, null, "Administration" },
                    { new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4112), null, new Guid("40a08501-139d-4f64-9ceb-d4746af51fb1"), false, null, null, "Risk Management" },
                    { new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4453), null, new Guid("f3506495-7e1a-41b1-ae2a-4bedd308c2b1"), false, null, null, "Fund Admin" },
                    { new Guid("9e089a8d-603a-4c72-a278-0aeb843f9015"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4371), null, new Guid("fd320c62-42b4-430d-bab5-accbb1f501c5"), false, null, null, "Mixta Nigeria Sales" },
                    { new Guid("9ec38d97-5e77-4410-90fd-30c179766021"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4143), null, new Guid("8c9b5665-1e3b-45c5-8f08-1d4836487b12"), false, null, null, "Fund Admin" },
                    { new Guid("9f4432a0-9002-4553-997d-633869423d79"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4282), null, new Guid("f28ded07-03e1-4706-a28f-fad22856265c"), false, null, null, "Corporate Strategy" },
                    { new Guid("9fb66e98-951d-462e-a559-4f19a955bd5b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4179), null, new Guid("d035fddb-c8b1-46ac-bad0-0c6433c32a96"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("a0d8712a-f6dd-4f64-a9b0-dcc204e52287"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4027), null, new Guid("db8cd93a-2aee-465c-aee1-ebc408ad3501"), false, null, null, "Treasury" },
                    { new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4450), null, new Guid("f3506495-7e1a-41b1-ae2a-4bedd308c2b1"), false, null, null, "Retail Operations" },
                    { new Guid("a16649cf-8b89-4027-9628-8af108db66fc"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4110), null, new Guid("08679d84-cd66-4415-85ea-c4ceb9fdc008"), false, null, null, "Information Technology" },
                    { new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4352), null, new Guid("8948b589-f3d6-4166-9c85-083eccf50ef0"), false, null, null, "Internal Control" },
                    { new Guid("a39f7dfe-55bb-433d-aabd-70476e81a9f1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4478), null, new Guid("a307d88a-0271-4630-a127-e15b01d4fb0d"), false, null, null, "ARM Academy" },
                    { new Guid("a470f202-ca90-4fc9-8617-358311885a1c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4323), null, new Guid("2cd5e5f8-67c2-4216-9684-2550888f86d1"), false, null, null, "Compliance" },
                    { new Guid("a5ab3b91-07f8-47d7-8ad7-3dfdbf005f8e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4468), null, new Guid("3495caee-2674-4590-a0b1-05ed02f7c5d3"), false, null, null, "Information Technology" },
                    { new Guid("a6409616-e559-4ff8-a877-0925be18ff3d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(3996), null, new Guid("d02e7cc9-5cae-4590-9ada-7e01e2eb0721"), false, null, null, "Research" },
                    { new Guid("a6dc58d2-3ca3-442c-a2f2-74a3e2f861e5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4123), null, new Guid("4b242a25-387f-4193-9d1f-04e715479802"), false, null, null, "Coporate Transformation" },
                    { new Guid("a77067b1-9217-4a5b-b16d-70e211f22c25"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4427), null, new Guid("d9955013-91b9-4200-897e-cb3cc9ec45aa"), false, null, null, "Internal Audit" },
                    { new Guid("a7f38bb3-596e-486d-b7ef-3e30b893a622"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4046), null, new Guid("3da5a658-20b1-4c7d-9817-669807b26cb3"), false, null, null, "Administration" },
                    { new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4295), null, new Guid("f27e8e75-fbbc-49e0-b7a5-48d3772c170c"), false, null, null, "Financial Control" },
                    { new Guid("a9e024ce-d1e7-42c6-b833-73bb43471c8e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4388), null, new Guid("c55dd501-c81a-40d6-a087-c0db735c280c"), false, null, null, "Facility Management" },
                    { new Guid("aa0a3489-560d-4e02-b270-ca08a45d2fcf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4421), null, new Guid("c08d35a4-8107-4d76-8c7a-cc588b5ff552"), false, null, null, "Information Technology" },
                    { new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4090), null, new Guid("2bcee133-d95c-4662-b71a-40197ae725a0"), false, null, null, "Retail Operations" },
                    { new Guid("ac2f5e03-e11a-4f64-8439-6dee0012376b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4181), null, new Guid("5d470b46-3059-4868-b413-f84c6b73f38d"), false, null, null, "Corporate Strategy" },
                    { new Guid("ad196f3c-1065-439f-a8d4-4a88a6933949"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4350), null, new Guid("769375cb-e998-4055-a75f-58a9039a8229"), false, null, null, "Real Estate" },
                    { new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4318), null, new Guid("bb58cf62-0d7a-4738-be3f-5bb05bb2d54d"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("ad6a7903-fb1b-4bf2-a55c-2d06f83e7707"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4400), null, new Guid("9c2b6429-7224-4b41-9078-24ec7f29619d"), false, null, null, "TSD Ltd" },
                    { new Guid("ad83f6ba-ea3b-4d12-a50a-5f00899e3f0c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4260), null, new Guid("02eb6692-18d6-49cd-9404-1225dfe8bcc1"), false, null, null, "Financial Control" },
                    { new Guid("ada4d1eb-bcaf-40b1-9790-82c54a225fc3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4216), null, new Guid("ebb477e8-093d-47f2-baf0-cd77f2884705"), false, null, null, "Port Harcourt" },
                    { new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4096), null, new Guid("e7ca403b-763d-4bc2-9ba9-ddf0c07db0f0"), false, null, null, "Call Centre" },
                    { new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4221), null, new Guid("fbe396d7-8f37-4344-8767-6a1e343c73ad"), false, null, null, "Risk Management" },
                    { new Guid("b0c9d7c8-a875-4f67-b386-d3475c0b2585"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4491), null, new Guid("83f8177c-f3a4-4766-85ee-415608202a64"), false, null, null, "Human Capital Management" },
                    { new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4257), null, new Guid("d6f89132-a0c8-4ffe-9d31-438a62821397"), false, null, null, "Call Centre" },
                    { new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4008), null, new Guid("e2ed9446-64f8-4150-abf0-2e170136c6aa"), false, null, null, "Trading / Bokerage" },
                    { new Guid("b84c6b8d-5fe4-4e4a-9143-16e25509bfb5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4476), null, new Guid("01b5cda8-819c-49d6-ac53-d6d38fde3b99"), false, null, null, "Internal Audit" },
                    { new Guid("b88ebfeb-5f91-4718-aa00-ec6ef714f50e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4465), null, new Guid("44d0991b-952e-4c8f-ba3e-3290fe2606be"), false, null, null, "Lagos" },
                    { new Guid("b8bc161a-36be-433c-b9b2-2502b40786de"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4481), null, new Guid("c5fdcbd4-7c92-4838-90e4-1d22f52d596e"), false, null, null, "Administration" },
                    { new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4334), null, new Guid("694ecc27-72e5-4aba-bf1b-d169e3c82eeb"), false, null, null, "Information Security" },
                    { new Guid("bae03f16-d1e7-410b-ad67-46bfe376c873"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4121), null, new Guid("1b733991-ba99-460e-96eb-f2e669afb4e2"), false, null, null, "ARM Academy" },
                    { new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4316), null, new Guid("d6601e9a-645c-4b34-86fd-96379b4cda73"), false, null, null, "Procurement and Administration" },
                    { new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4448), null, new Guid("f3506495-7e1a-41b1-ae2a-4bedd308c2b1"), false, null, null, "Fund Account" },
                    { new Guid("bb28a222-8895-4def-a8a2-1320ad8eb17b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4213), null, new Guid("ebb477e8-093d-47f2-baf0-cd77f2884705"), false, null, null, "Abuja" },
                    { new Guid("bba02c89-3bf2-4596-857c-54c4f86e9a27"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4363), null, new Guid("29f35a84-0491-415e-9583-0acc53696230"), false, null, null, "Corporate Strategy" },
                    { new Guid("bddcf236-c134-41a2-9946-02a335f9b53d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4171), null, new Guid("2a650f64-bb8c-4529-a02c-d9e6ded8dd77"), false, null, null, "Internal Control" },
                    { new Guid("be3396b5-e02e-48ac-ae55-d64dad1cbd76"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4302), null, new Guid("464713f9-0a6a-4da1-b5b9-ccd01200fa13"), false, null, null, "Lagos" },
                    { new Guid("bec6c783-ba3c-4180-9d8a-052ce433f695"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4357), null, new Guid("6b930a61-222f-445a-b3dc-b38c7b9465a8"), false, null, null, "Coporate Transformation" },
                    { new Guid("bedd46ce-899c-4c9d-a098-bb49c3633b35"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4370), null, new Guid("57bdc355-223c-471e-b5d1-a9381721e815"), false, null, null, "Human Capital Management" },
                    { new Guid("bfe9d961-8677-4fe2-9727-65f633759353"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4076), null, new Guid("c5cc333f-018a-4f43-9a77-1b3d2a8b565e"), false, null, null, "Wealth & Relationship Management -Port Harcourt" },
                    { new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4005), null, new Guid("322bd236-2e60-409a-86e6-835c2689015f"), false, null, null, "Securities Operations" },
                    { new Guid("c1beeff0-0f52-40a7-8bd0-9f031ef1110a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4040), null, new Guid("fcf19754-f07e-41c0-8a3f-bd135f93c40f"), false, null, null, "Internal Audit" },
                    { new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4158), null, new Guid("b425cf7c-40b2-4419-89df-8bc891b2e15e"), false, null, null, "Customer Service" },
                    { new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4341), null, new Guid("1ac6a090-f8d8-4c57-b604-036f61257463"), false, null, null, "RFL" },
                    { new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4099), null, new Guid("e7ca403b-763d-4bc2-9ba9-ddf0c07db0f0"), false, null, null, "Customer Service" },
                    { new Guid("c8ba310f-753d-4317-bce6-1559fb079142"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4036), null, new Guid("fcf19754-f07e-41c0-8a3f-bd135f93c40f"), false, null, null, "Internal Control" },
                    { new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4437), null, new Guid("2dbd67f5-a20d-4ce7-a147-707e1e8bc31d"), false, null, null, "Legal" },
                    { new Guid("cb66fa72-3399-4483-9766-bf35f2033862"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4250), null, new Guid("f3a518ad-7fd9-4b61-8329-d5202365376a"), false, null, null, "Human Capital Management" },
                    { new Guid("cc9fd72b-9a83-43f9-b28f-f8376af33ac0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4383), null, new Guid("4efd2543-e778-4610-b003-c7dd46c91920"), false, null, null, "Hospitality and Retail Management" },
                    { new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4225), null, new Guid("26f0bc25-7466-46ba-b420-215d49d37ccf"), false, null, null, "Internal Control" },
                    { new Guid("d09befe1-8e69-4e76-9735-88597aeb09a4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4248), null, new Guid("54fe23d5-e9fc-4ec2-82d6-f294ae6aba1f"), false, null, null, "Co.Sec" },
                    { new Guid("d0b29a0f-69c0-42df-8af9-490ebc733c64"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4227), null, new Guid("26f0bc25-7466-46ba-b420-215d49d37ccf"), false, null, null, "Internal Audit" },
                    { new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4020), null, new Guid("d2f7a060-2f44-4714-98bb-f03741d918d2"), false, null, null, "Call Centre" },
                    { new Guid("d6194902-48f8-4bed-bb0d-0aae5b24df4d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4368), null, new Guid("7252a7d7-b535-4461-82c8-10ce3cda075f"), false, null, null, "Co.Sec" },
                    { new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4162), null, new Guid("374cc2c3-1692-4211-a438-9c84f096c998"), false, null, null, "Treasury" },
                    { new Guid("d6733360-b4e1-4b88-9cbb-364cf2c3fd9c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4408), null, new Guid("c005c30e-ebc3-4ec1-a1b3-0d23f4d06b60"), false, null, null, "Farapark" },
                    { new Guid("d79f8f8d-8fe1-4ff4-94f0-2550f51d8186"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4289), null, new Guid("0eb79555-2e7e-4e98-95a3-8b09e35c8f65"), false, null, null, "Co.Sec" },
                    { new Guid("db1294f5-ada3-42c3-bc59-cd554818e099"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4389), null, new Guid("7be57b73-24b7-4e03-8c75-ba06181ac887"), false, null, null, "Procurement and Contracting" },
                    { new Guid("db3aeece-97b4-42b0-bf58-0f02b87ae4cd"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4223), null, new Guid("6a5cdada-9119-496c-92b1-051ad5794c7e"), false, null, null, "Project Management Office" },
                    { new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4101), null, new Guid("52353d55-0c2c-48b8-b8fe-67c4c76380c0"), false, null, null, "Financial Control" },
                    { new Guid("dcea9d1b-56d2-47b3-901e-1e6b8a6365d7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4232), null, new Guid("7503c8dc-27d2-4364-92f4-086444244e47"), false, null, null, "Coporate Transformation" },
                    { new Guid("dda976b6-ac1f-42ed-a9cf-860ab77826ac"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4048), null, new Guid("1107ea36-29cd-48ec-9e71-0867a3248d45"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("e0df9434-41f4-454a-a02b-45d644b4d08d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4461), null, new Guid("9e8c92bb-3e4b-4dc7-a5e6-bb3a8562b3d3"), false, null, null, "Treasury" },
                    { new Guid("e1671ffd-98d2-4063-b883-310378ac972a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4164), null, new Guid("b3dd1e0b-7fb0-41e7-ac57-a7dc6fd35190"), false, null, null, "Information Technology" },
                    { new Guid("e35aaace-aeba-48df-867c-750aef56d05f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4218), null, new Guid("ebb477e8-093d-47f2-baf0-cd77f2884705"), false, null, null, "Lagos" },
                    { new Guid("e3ccc14e-8d7b-4817-a4c2-8d7eca698d72"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4236), null, new Guid("d9b9f300-6378-4d18-b511-36b88d40cdb2"), false, null, null, "Marketing and Corporate Communications" },
                    { new Guid("e3eaede4-d14c-4c91-b986-f19350038ab4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4116), null, new Guid("db791aa9-d9b5-435c-aa4f-efd668a6fe62"), false, null, null, "Project Management Office" },
                    { new Guid("e4789074-ab43-463f-b18f-42606e28db63"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4287), null, new Guid("0eb79555-2e7e-4e98-95a3-8b09e35c8f65"), false, null, null, "Compliance" },
                    { new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4149), null, new Guid("8c9b5665-1e3b-45c5-8f08-1d4836487b12"), false, null, null, "Retail Operations" },
                    { new Guid("e60519ac-2af8-40be-94ed-2218e244d1d5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4176), null, new Guid("778caba2-5bc9-44e7-ab17-74fcf528d9e7"), false, null, null, "Coporate Transformation" },
                    { new Guid("ea600662-5dbb-4ad6-8200-cc3b2cf39a10"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4290), null, new Guid("d6718e8a-104b-4fbc-a48d-1e5d6f9d12d1"), false, null, null, "Human Capital Management" },
                    { new Guid("eaa2f32a-bd71-4b87-a692-6b7eae9f560f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4078), null, new Guid("f5bbaf6f-6593-4b31-87fa-8704088ecff3"), false, null, null, "Abuja" },
                    { new Guid("eaaafeef-5b77-4370-bd8f-21fd1b9e1b94"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4169), null, new Guid("332e2c96-7873-4e7e-a417-855c6cf61512"), false, null, null, "Project Management Office" },
                    { new Guid("eb862f6f-9693-4a7a-b2b8-df539e26a8c0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4300), null, new Guid("464713f9-0a6a-4da1-b5b9-ccd01200fa13"), false, null, null, "Port Harcourt" },
                    { new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4132), null, new Guid("7ad4c706-19c0-4e01-a9b5-1686059e0180"), false, null, null, "Legal" },
                    { new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4259), null, new Guid("d6f89132-a0c8-4ffe-9d31-438a62821397"), false, null, null, "Customer Service" },
                    { new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4365), null, new Guid("7252a7d7-b535-4461-82c8-10ce3cda075f"), false, null, null, "Legal" },
                    { new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4297), null, new Guid("f27e8e75-fbbc-49e0-b7a5-48d3772c170c"), false, null, null, "Treasury" },
                    { new Guid("f4c145fb-e830-4fa2-ba1d-77963b39eccf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4188), null, new Guid("9f6edbba-294b-4526-9175-e8ec4950a564"), false, null, null, "Co.Sec" },
                    { new Guid("f60b1ae5-e26f-41bc-a5f3-814f19bdaf0e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4229), null, new Guid("52e9802f-2408-435f-9f5f-5d4a10de82bf"), false, null, null, "ARM Academy" },
                    { new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4081), null, new Guid("f5bbaf6f-6593-4b31-87fa-8704088ecff3"), false, null, null, "Lagos" },
                    { new Guid("f6f9b36b-1d78-475e-b7e0-ffdd9f6e45e1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4464), null, new Guid("44d0991b-952e-4c8f-ba3e-3290fe2606be"), false, null, null, "Port Harcourt" },
                    { new Guid("f849e3eb-bc9e-46f7-9d8e-45912925298d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4064), null, new Guid("e0649b38-ae55-4664-9b1e-07c93d4d0c47"), false, null, null, "Co.Sec" },
                    { new Guid("fa110f66-701d-43b3-9cea-35ca0aaeece1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4386), null, new Guid("a30367f4-d362-4f4d-b8f9-0ddf8446d02e"), false, null, null, "Technical / Projects" },
                    { new Guid("fb274136-84fe-430d-bab9-6647909a1a48"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 8, 4, 3, 15, 46, 771, DateTimeKind.Utc).AddTicks(4160), null, new Guid("374cc2c3-1692-4211-a438-9c84f096c998"), false, null, null, "Financial Control" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("003ed424-1724-44b1-bcb1-924abb94e338"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("01ac6f97-9040-439b-abd4-77c79f873d79"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("037019bf-ce11-4307-a984-170b02ca17a9"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("04bd1a1c-a506-4ce7-b0ce-5f3c1e812c22"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("05652a26-461c-4c78-be42-f212fc5fd083"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("07d965be-1bd6-40df-bfe9-9679b6a4a3c1"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("0845fb19-2120-461d-b291-74e1aafa9adb"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("085af12a-41d1-4516-adc4-7e6aba212354"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("087015b4-acdb-4487-a687-0f084390f387"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("0aacc5ae-ea42-41e1-98c9-9b28d3628d08"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("0ad594c4-73bb-4ee8-a533-c9ba80814d21"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("0af7e7ae-8a58-44b4-97eb-b018f46f9aa0"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("0be0c18a-7705-4468-a2b4-38b5c61592d8"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("1152377f-b194-4f27-8c7e-fb8b3b733a75"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("128a206a-4da3-4e49-9b73-8b817eea61d2"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("129ff73a-c11c-4ac7-bd7c-0029d80ef739"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("12fc7195-2c3f-4bca-88b4-beef3f234d01"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("14bc990b-65e8-468a-ad31-338bb36b07e1"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("156818e3-1ea6-42b0-a785-7dfaac6f5371"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("167b697a-f58e-42cb-8eeb-8bf0180696e6"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("16bedab4-1eb0-484a-9845-e1581085f146"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("185e0a8b-5aa5-43e5-8828-edeae97cd121"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("19331c05-77f0-4f49-bb90-2af3a78a7793"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("19704b51-99bb-439f-a4db-6603c6089a58"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("1df86816-2842-4941-8710-36822d6240e8"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("1e382c5d-6b22-43a6-9ce9-521244c1f555"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("1f04d0c7-a755-4a59-8b72-7711bbc53d11"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("201b2b9b-55a4-49eb-82b7-05afb9110eae"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("209cfd77-d2b6-4264-963c-bd02558837e4"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2108a385-5b39-4953-97e7-216523683078"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2289ecd3-d422-42e9-95d1-aa91425d1c0d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2324ca19-a743-485a-b49a-d04b5a1ec0a0"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("23f36ca8-a0ce-49bf-be0c-66366eff3c51"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2470d7cf-0bea-49c7-a2c7-04c9fa36ade6"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2570f9e3-7c71-41de-9a32-0981e29c14b3"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2abce038-72a5-4fd5-9cfc-deef8348f4d0"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2d49e611-2b7f-4515-86cc-6e67723405b2"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2d541dca-d8d3-43e1-9ac1-d215cf89c085"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2d544b75-9bda-4aff-a212-a2998fc28cfa"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2e1919c1-fdae-4023-b602-6c3584f2b95b"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("2f7f4b7b-25de-490c-9db4-5ecbb9265268"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("30306755-5207-4d72-9c62-359afa8a5f0e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("30c9c38f-23b7-4694-acd9-bac0da70eb4e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("329d8cac-d18b-4a9b-bd38-8535e19d2b60"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("32a964ce-a439-4c80-9a36-f7774706ee32"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("33cdd2bc-364b-4975-a2ba-3f40cecca022"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("35a7256f-7c2a-45ea-8cbb-2e7509b1cd21"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("36998696-f319-43d4-bcbf-61b52d0556bd"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("36e6ae73-2270-40ea-ae16-64d610c1e5b8"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("389e0846-2dfd-4e66-91c7-b7c37a565c70"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("38bf0e6d-58f3-47f8-8324-4938c42ac62b"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("3b4fb588-4847-4f9b-9f6b-5a8364ff86fc"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("3bc7f31c-9502-492b-8a0d-4204be7a5614"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("3d1ba0a1-ce2d-4806-b60e-4002c054f341"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("3f4ee577-f743-4614-adda-5bd4e641c85c"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("3ff75ac7-8e21-4e8a-8895-a77a4dfb5dee"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("4082fe29-5966-476e-951f-c44e306ca50f"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("4221d035-01ed-4439-8829-d9b73f9e5a4b"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("42bb02b3-075d-4414-9d51-4592aa1b18a8"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("42c3cab6-ccbd-452e-8f84-45993337f2b3"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("444a03bb-a3d4-4cec-a76c-eeabda66003a"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("44fe054d-83dd-41da-b90a-a53631af453d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("456575f1-a8db-4fd9-885f-8e84e096c860"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("4771bfd1-bcba-463a-84ed-f6e8a53f207a"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("4914b69b-1b5e-499a-8350-9fcf5b2e4dca"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("491cdc51-64aa-4f6b-b5ba-b036b0174852"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("500fc670-2f14-4786-9092-f7f82b8ae507"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("518a9fb8-50d8-48a3-824f-3f836305c3bb"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("51e640b2-bee2-4b4c-8aa0-4286737b8ec9"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("52ae7cc8-1382-4c45-833a-84e78a2de191"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("53d0cdd2-2aca-417f-ad11-92364253defd"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("54578f13-6ee3-418d-aede-e77041ef4878"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("556d5367-6794-4355-974f-e2ebb6447695"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("55937fd0-e454-4dfb-a652-cf4ff41078d7"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("575a8a92-112f-4752-a875-24999b3f69ca"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("598f6cac-69ce-47bb-8be4-f0697c1eb47e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5a64f00c-b288-46b3-aa77-ecc4d35b212d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5a96a0a8-8d71-45dc-9736-befceefbecb4"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5b77ef60-1c4a-474a-a320-30b120509229"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5b7bf6bf-cd9b-44bd-b88e-57bfb256f784"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5cf04c21-a4c1-45f2-a80c-9ccd03aec033"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5d296ac9-f9f9-4f69-bb40-0f8b616a6d0c"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5d423f0c-ace3-4f86-8c10-1b6155bd748a"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5e3f8a3a-4451-4153-8871-eaf7f24aa0e2"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5ec15a12-324e-429a-87d7-af5b945a4859"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("5efbbf5f-3081-4492-9ec4-b8880b3eb06e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("64e5f632-d1a0-4ed0-b133-629f6c5d05c5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("65757b71-e2fb-490d-ba49-20e94ee3623d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("659a83bc-cee9-4939-8669-d2c5617b7845"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("659d183c-6ea8-4d2d-bee2-5e3374903ff6"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("67552124-7cee-4f19-8e6c-4b9598f1510f"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("68f11193-1923-40d1-87d3-5a7b4de0b96e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("6944d275-92d3-400f-bf70-00f6d9a271ba"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("6a60b06e-8252-4478-b5ca-ed38e56c56bc"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("6b2c5f66-56fe-4a29-9393-5a8b7623d880"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("6c300c5e-fba6-467e-952f-4bb3d1d15ea4"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("6cfdabd5-52e6-465b-8cca-5b23aead61be"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("6d33101c-f8c2-44f0-8774-5eda11b05df3"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("6e7c4307-421c-4f26-9216-a740663cdebd"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7116856a-f88c-4bdf-b7d4-92e8e241c8ea"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("73b718ca-eecf-45eb-bf74-283ff17073b5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("757ecc97-7a10-420e-b919-2ac7aa557b3e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7597c6ec-e19f-4ad2-add8-e32b1df75663"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("772f854e-c9f6-4428-bad1-53db881e28bb"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("77635858-f888-45c8-9a6f-df2f5ac50670"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("789c6900-e5a3-44d4-9e6e-f165c0f94650"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7979d030-e342-426c-b1e6-6ce2ba29cb20"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("79f64fe8-0a3e-4f2a-b499-8f48e6ea37e8"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7b36de44-d363-4d42-b02e-bafeb0c905d5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7b5d5f83-12ea-44ab-aa57-354c23f25819"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7c0261cb-0d3e-496d-aa86-9cf5f37da1ae"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7d22672e-a552-4944-a418-d7678717c193"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7e6554fc-5a0b-4bb0-bc61-2f8dff033a13"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("7fc65d4a-e0ad-4274-b1ba-c447f49cd208"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("80245081-74bc-4124-87f5-d6008b28706b"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("83d63b3c-f20b-4e30-8384-6d603fd67bd4"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("840c5c87-0155-4c39-85f4-f3736f04e540"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("850b308d-bef3-41ad-b812-413b868e7621"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("8581332b-8d77-4f1c-8a3b-79a996ff575f"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("85e7d3b3-b00d-4ffe-897a-17af4b7677b7"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("8618dc34-8edc-471a-8bab-e7d8b0670462"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("8a454ad0-80d6-4ded-a89e-c5e9023357ed"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("8eb2aa8b-3cd7-41b1-9628-436aaace8df5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("8f3b081b-f835-4577-aa13-9aefd6559760"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("9085fd66-97e2-4f6f-91c1-84fa719168c7"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("90cd9708-b7b4-4203-ba98-6ce8c66e623e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("941c57d3-66c5-4083-85b9-20bf746b0def"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("957f6bf9-1d02-4600-b676-6200eb6c4de3"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("985b91e0-b7c5-4521-8c9a-d312a250d497"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("99e13568-607e-4a0f-bf1a-734ebe4310fe"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("9a3f56c3-6249-46eb-880d-01b01cbe7078"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("9b8a0856-7a3f-4276-8c5f-4491aba5ea32"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("9c4c1904-45e3-4068-bdc4-0edaad048df1"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("9e089a8d-603a-4c72-a278-0aeb843f9015"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("9ec38d97-5e77-4410-90fd-30c179766021"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("9f4432a0-9002-4553-997d-633869423d79"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("9fb66e98-951d-462e-a559-4f19a955bd5b"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a0d8712a-f6dd-4f64-a9b0-dcc204e52287"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a12793d5-baa7-4c20-8555-06c46c0c08c5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a16649cf-8b89-4027-9628-8af108db66fc"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a2449964-8bd7-4773-8b33-449dfcb9a538"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a39f7dfe-55bb-433d-aabd-70476e81a9f1"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a470f202-ca90-4fc9-8617-358311885a1c"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a5ab3b91-07f8-47d7-8ad7-3dfdbf005f8e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a6409616-e559-4ff8-a877-0925be18ff3d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a6dc58d2-3ca3-442c-a2f2-74a3e2f861e5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a77067b1-9217-4a5b-b16d-70e211f22c25"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a7f38bb3-596e-486d-b7ef-3e30b893a622"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("a9e024ce-d1e7-42c6-b833-73bb43471c8e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("aa0a3489-560d-4e02-b270-ca08a45d2fcf"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ac2f5e03-e11a-4f64-8439-6dee0012376b"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ad196f3c-1065-439f-a8d4-4a88a6933949"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ad291e41-ea05-4e3d-ba6a-e970c8d6ec8c"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ad6a7903-fb1b-4bf2-a55c-2d06f83e7707"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ad83f6ba-ea3b-4d12-a50a-5f00899e3f0c"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ada4d1eb-bcaf-40b1-9790-82c54a225fc3"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("af33d7c8-cf9b-4753-b6bb-7839adaaefd1"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("afaf7dd5-e4f9-4fb3-af99-ce7d5409d9e0"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("b0c9d7c8-a875-4f67-b386-d3475c0b2585"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("b1ea8e93-9858-4d81-82c0-7c320e34fb2d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("b84c6b8d-5fe4-4e4a-9143-16e25509bfb5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("b88ebfeb-5f91-4718-aa00-ec6ef714f50e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("b8bc161a-36be-433c-b9b2-2502b40786de"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("b8e4ea11-e826-4eb9-8a10-d46a6830bbcb"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bae03f16-d1e7-410b-ad67-46bfe376c873"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bae8a609-e0f7-4e17-8671-5f599cf213f9"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("baef19b2-cb1a-4a73-86d0-f187cbd9502a"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bb28a222-8895-4def-a8a2-1320ad8eb17b"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bba02c89-3bf2-4596-857c-54c4f86e9a27"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bddcf236-c134-41a2-9946-02a335f9b53d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("be3396b5-e02e-48ac-ae55-d64dad1cbd76"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bec6c783-ba3c-4180-9d8a-052ce433f695"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bedd46ce-899c-4c9d-a098-bb49c3633b35"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("bfe9d961-8677-4fe2-9727-65f633759353"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("c1569f0f-9643-43d6-bdca-e7296d044604"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("c1beeff0-0f52-40a7-8bd0-9f031ef1110a"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("c4ced74d-0564-4a17-80c6-48677d2a3f38"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("c6583d8f-0c97-480f-9030-3853a8ce9e72"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("c8ba310f-753d-4317-bce6-1559fb079142"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("cb0e55cc-f82b-4e63-ada3-e067be4df970"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("cb66fa72-3399-4483-9766-bf35f2033862"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("cc9fd72b-9a83-43f9-b28f-f8376af33ac0"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("cd5cf9e3-20cf-4c82-b030-5a705320b6e2"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("d09befe1-8e69-4e76-9735-88597aeb09a4"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("d0b29a0f-69c0-42df-8af9-490ebc733c64"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("d37b8f43-c24c-4ed7-a195-c34d16a04836"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("d6194902-48f8-4bed-bb0d-0aae5b24df4d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("d638462f-bde3-4555-889b-2af892201b07"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("d6733360-b4e1-4b88-9cbb-364cf2c3fd9c"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("d79f8f8d-8fe1-4ff4-94f0-2550f51d8186"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("db1294f5-ada3-42c3-bc59-cd554818e099"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("db3aeece-97b4-42b0-bf58-0f02b87ae4cd"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("dcea9d1b-56d2-47b3-901e-1e6b8a6365d7"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("dda976b6-ac1f-42ed-a9cf-860ab77826ac"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("e0df9434-41f4-454a-a02b-45d644b4d08d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("e1671ffd-98d2-4063-b883-310378ac972a"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("e35aaace-aeba-48df-867c-750aef56d05f"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("e3ccc14e-8d7b-4817-a4c2-8d7eca698d72"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("e3eaede4-d14c-4c91-b986-f19350038ab4"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("e4789074-ab43-463f-b18f-42606e28db63"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("e5c86213-9222-4efd-9b33-253c2c3a3719"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("e60519ac-2af8-40be-94ed-2218e244d1d5"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ea600662-5dbb-4ad6-8200-cc3b2cf39a10"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("eaa2f32a-bd71-4b87-a692-6b7eae9f560f"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("eaaafeef-5b77-4370-bd8f-21fd1b9e1b94"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("eb862f6f-9693-4a7a-b2b8-df539e26a8c0"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("ef9e9e15-3901-4d43-bb4f-fd7145b9dc31"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("f1e70d82-133f-491d-9cd9-a2b0a698689e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("f24666d4-a288-47ac-99d2-e2b11c62c879"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("f4c145fb-e830-4fa2-ba1d-77963b39eccf"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("f60b1ae5-e26f-41bc-a5f3-814f19bdaf0e"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("f6c8474e-084e-474a-9164-f912b62cdbd3"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("f6f9b36b-1d78-475e-b7e0-ffdd9f6e45e1"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("f849e3eb-bc9e-46f7-9d8e-45912925298d"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("fa110f66-701d-43b3-9cea-35ca0aaeece1"));

            migrationBuilder.DeleteData(
                table: "Unit",
                keyColumn: "Id",
                keyValue: new Guid("fb274136-84fe-430d-bab9-6647909a1a48"));
        }
    }
}
