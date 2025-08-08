using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class NewCallOverUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                     { new Guid("8a07f189-3354-40a6-889f-d0deb29fc922"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 0, 23, 22, 984, DateTimeKind.Utc).AddTicks(9884), null, "aminat.ashafa@arm.com.ng", false, null, null, "Aminat Ashafa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                     { new Guid("9ed3c8d2-6fe5-4d9e-9ca4-7c0afed00019"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 0, 23, 22, 984, DateTimeKind.Utc).AddTicks(9886), null, "oluwaferanmi.adedokun@arm.com.ng", false, null, null, "Oluwaferanmi Adedokun", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                     { new Guid("8c33c88f-bbbe-40fc-ae88-bf5dc4ac0ccb"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 0, 23, 22, 984, DateTimeKind.Utc).AddTicks(9891), null, "oluseyi.omoleye@arm.com.ng", false, null, null, "Oluseyi Omoleye", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                     { new Guid("9f1c6e38-398f-4429-8f13-9643a70acf8d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 0, 23, 22, 984, DateTimeKind.Utc).AddTicks(9893), null, "thompson.shedara@arm.com.ng", false, null, null, "Thompson Shedara", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("5AF3368C-48C9-4AEA-BA95-0F361AC82CC6") },
                     { new Guid("a173965b-312f-4cbc-b0b8-82d32d6c86b6"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 0, 23, 22, 984, DateTimeKind.Utc).AddTicks(9895), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                     { new Guid("b3abded1-dca1-441a-898e-d22ac9cf4d88"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 0, 23, 22, 984, DateTimeKind.Utc).AddTicks(9897), null, "hassan.balogun@arm.com.ng", false, null, null, "Hassan Balogun", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                     { new Guid("7692a489-7235-4d66-adf5-d5126b668c61"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 0, 23, 22, 984, DateTimeKind.Utc).AddTicks(9900), null, "kevian.kevin@arm.com.ng", false, null, null, "Kevian Kevin", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                     { new Guid("981cca46-f966-4491-8c29-1560ec3cf7ac"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 1, 15, 0, 23, 22, 984, DateTimeKind.Utc).AddTicks(9902), null, "ibrahim.owolabi@arm.com.ng", false, null, null, "Ibrahim Owolabi", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },

               });

            
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
           

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {

                 });

           
        }
    }
}
