using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAuditUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {

                    { new Guid("2a6939f0-3516-44ad-9daf-a9b33d60aed4"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 29, 10, 34, 12, 574, DateTimeKind.Utc).AddTicks(1165), null, "oluwabunmi.wright@arm.com.ng", false, null, null, "Oluwabunmi Abiodun-Wright", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") },
                    { new Guid("8f19c873-eea8-4983-914d-09956b80ed93"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 29, 10, 34, 12, 574, DateTimeKind.Utc).AddTicks(1189), null, "Jobalo.Oshikanlu@arm.com.ng", false, null, null, "Jobalo Oshikanlu", "ARMHIIL", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },

                });
         }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {           
            
          

        }
    }
}
