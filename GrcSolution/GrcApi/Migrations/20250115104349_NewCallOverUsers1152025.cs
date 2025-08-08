using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class NewCallOverUsers1152025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("4aacbee5-ed0a-4369-8298-4fda8b0dd92b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 10, 43, 45, 451, DateTimeKind.Utc).AddTicks(7838), null, "ifeoluwa.obigbemi@arm.com.ng", false, null, null, "Ifeoluwani Obigbemi", "IMUnit", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("0ace6d4d-e74c-417d-aad2-22f526780138"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 10, 43, 45, 451, DateTimeKind.Utc).AddTicks(7844), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("7fb9880e-9d89-4ffa-abfe-63f5c17c8c09"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 10, 43, 45, 451, DateTimeKind.Utc).AddTicks(7840), null, "aminat.ashafa@arm.com.ng", false, null, null, "Aminat Ashafa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("ae3ef0b3-6f41-4a08-b024-1b8ee10a4e6c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 10, 43, 45, 451, DateTimeKind.Utc).AddTicks(7848), null, "gift.aizebeoje@arm.com.ng", false, null, null, "Gift Aizebeoje", "IMUnit", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("bd787296-c021-4f4a-8019-43185ab9a809"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 10, 43, 45, 451, DateTimeKind.Utc).AddTicks(7842), null, "thompson.shedara@arm.com.ng", false, null, null, "Thompson Shedara", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("d07b176f-805d-4a23-a245-4c0d227bd304"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 10, 43, 45, 451, DateTimeKind.Utc).AddTicks(7845), null, "kevian.kevin@arm.com.ng", false, null, null, "Kevian Kevin", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") }
                });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
