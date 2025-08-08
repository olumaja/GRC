using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BusinessEntity",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
            { new Guid("f93b6763-93d7-41d2-9a4c-4929d359b69c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 412, DateTimeKind.Utc).AddTicks(501), null, false, null, null, "ARM HIIL" },
            { new Guid("fee31ed7-4adf-4d03-8fd0-b3144b42865a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 412, DateTimeKind.Utc).AddTicks(507), null, false, null, null, "ARM Capital" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "BusinessEntityId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                { new Guid("059d49f4-3cdc-4c20-8a1c-d5ed7f8d2791"), new Guid("0ca1b490-11d5-4e58-9289-e3eecefbdb9a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9367), null, false, null, null, "Operations Settlement" },
                { new Guid("1777e6a2-05bc-4322-81f0-10a205779214"), new Guid("7e222ca0-5e9b-4a55-8c17-2e9b0de78641"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9550), null, false, null, null, "ARM HoldCo" },
                { new Guid("2214335d-9ca8-4ac9-8fe1-352deda923bf"), new Guid("0ca1b490-11d5-4e58-9289-e3eecefbdb9a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9355), null, false, null, null, "Research" },
                { new Guid("252cf529-9e73-4257-a718-d9cf51251ae0"), new Guid("8497da34-5cac-46dd-bad0-efcc4bcb3656"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9948), null, false, null, null, "Environmental, Social and Governance" },
                { new Guid("2b4752e0-89e3-45ab-b4d6-f3809bd9c015"), new Guid("50987439-cf5a-4356-8dec-55a845974076"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9218), null, false, null, null, "ARM Security" },
                { new Guid("37d376e3-5e1f-42a7-9d77-e63f07ca4475"), new Guid("8497da34-5cac-46dd-bad0-efcc4bcb3656"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9955), null, false, null, null, "Data and Insights" },
                { new Guid("427b8268-2d8b-4686-b677-69de2a46a459"), new Guid("7e222ca0-5e9b-4a55-8c17-2e9b0de78641"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9556), null, false, null, null, "Treasury Operations" },
                { new Guid("865be81a-ebe9-4c50-b5b9-9c07c28b1d9f"), new Guid("8497da34-5cac-46dd-bad0-efcc4bcb3656"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9941), null, false, null, null, "Company Secretariat" },
                { new Guid("f663d307-7d4d-4261-9f7e-e8fe6645ba18"), new Guid("7e222ca0-5e9b-4a55-8c17-2e9b0de78641"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 431, DateTimeKind.Utc).AddTicks(9563), null, false, null, null, "Treasury Sales" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "DepartmentId", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                { new Guid("55b730f9-4550-4829-a479-9fc651b7946f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(7402), null, new Guid("374cc2c3-1692-4211-a438-9c84f096c998"), false, null, null, "Treasury Operations" },
                { new Guid("a3f65993-988f-49aa-9268-ae88d2472739"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(7409), null, new Guid("374cc2c3-1692-4211-a438-9c84f096c998"), false, null, null, "Treasury Sales" },
                { new Guid("d1904219-86a4-44a5-85a0-754ff2dcadc0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(7182), null, new Guid("f5bbaf6f-6593-4b31-87fa-8704088ecff3"), false, null, null, "Retail Sales" },
                { new Guid("d421d758-faec-4fc4-bab7-9f022d03698d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(7169), null, new Guid("c5cc333f-018a-4f43-9a77-1b3d2a8b565e"), false, null, null, "Business Development" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "BusinessEntityId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                { new Guid("840c2b0e-4146-41fb-a771-ede34bd0d915"), new Guid("f93b6763-93d7-41d2-9a4c-4929d359b69c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 432, DateTimeKind.Utc).AddTicks(457), null, false, null, null, "ARM HIIL" },
                 { new Guid("b0b881eb-8beb-412e-8b63-ebfb5fbe0c0a"), new Guid("fee31ed7-4adf-4d03-8fd0-b3144b42865a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 432, DateTimeKind.Utc).AddTicks(464), null, false, null, null, "ARM Capital" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "DepartmentId", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                { new Guid("0c3dc3f2-d704-4d25-9177-46bde182bf5a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(8017), null, new Guid("865be81a-ebe9-4c50-b5b9-9c07c28b1d9f"), false, null, null, "Company Secretariat" },
                { new Guid("393f2a41-0ae5-487d-9b67-224cd145f5fb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(6861), null, new Guid("2b4752e0-89e3-45ab-b4d6-f3809bd9c015"), false, null, null, "ARM Securities" },
                { new Guid("856f2fcf-81ba-4ff8-84e5-f61b0acb9128"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(8024), null, new Guid("37d376e3-5e1f-42a7-9d77-e63f07ca4475"), false, null, null, "Data and Insights" },
                { new Guid("b625ff03-0916-4369-882d-0ffcd322660d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(8031), null, new Guid("252cf529-9e73-4257-a718-d9cf51251ae0"), false, null, null, "Environmental, Social and Governance" },
                { new Guid("b79352c2-c526-46ce-91fc-c94915ea6ce3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(7396), null, new Guid("1777e6a2-05bc-4322-81f0-10a205779214"), false, null, null, "ARM HoldCo" },
                { new Guid("eb42b40b-bfd0-443b-b03f-956ab9d03db3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(7176), null, new Guid("2214335d-9ca8-4ac9-8fe1-352deda923bf"), false, null, null, "Research" },
                { new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(7189), null, new Guid("059d49f4-3cdc-4c20-8a1c-d5ed7f8d2791"), false, null, null, "Operations Settlement" },
                { new Guid("10f06e8a-0531-458a-9131-3d1820112a49"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(8723), null, new Guid("840c2b0e-4146-41fb-a771-ede34bd0d915"), false, null, null, "ARMHIIL" },
                { new Guid("1fe23b5b-08a7-450f-9f19-19c41aff6037"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 2, 8, 46, 51, 500, DateTimeKind.Utc).AddTicks(8730), null, new Guid("b0b881eb-8beb-412e-8b63-ebfb5fbe0c0a"), false, null, null, "ARM Capital" }
                });

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
           
        }
    }
}
