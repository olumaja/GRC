using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInternalAuditNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {

                    { new Guid("cbf420da-ed53-49c0-81e7-c982e2bf88d7"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 12, 2, 8, 58, 17, 283, DateTimeKind.Utc).AddTicks(3741), null, "Osahon.Ogiemudia@arm.com.ng", false, null, null, "Osahon Ogiemudia", "ARM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("e20991e8-6233-4635-8829-4ee12bf7004d") },
                    { new Guid("2ea96ab9-bb41-4d1f-a047-27b6508cae5a"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 12, 2, 8, 58, 17, 283, DateTimeKind.Utc).AddTicks(3713), null, "oluwabunmi.abiodun-wright@arm.com.ng", false, null, null, "Oluwabunmi Abiodun-Wright", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") },
                    { new Guid("5c12203a-13ab-4107-a27e-2c7c38b77963"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 12, 2, 8, 58, 17, 283, DateTimeKind.Utc).AddTicks(3734), null, "Toni.Timi-Oyefolu@arm.com.ng", false, null, null, "Toni Timi-Oyefolu", "ARMIM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },

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

                    { new Guid("70cff510-41f0-41b6-90f8-e43e13d7797c"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 29, 10, 34, 12, 574, DateTimeKind.Utc).AddTicks(962), null, "oluwabunmi.abiodun-wright@arm.com.ng", false, null, null, "Oluwabunmi Abiodun-Wright", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },

                 });           
        }
    }
}
