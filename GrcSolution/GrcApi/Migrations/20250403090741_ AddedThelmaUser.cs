using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedThelmaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Department", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "ModuleItemType", "Name", "Status", "Unit", "UnitId" },
                values: new object[,]
                {                 
                    
                    { new Guid("d3fcfd86-22fb-4255-8255-a45704e47378"), "Shared Services", null, new DateTime(2025, 4, 3, 9, 7, 39, 288, DateTimeKind.Utc).AddTicks(6542), null, null, "thelma.uwandu@arm.com.ng", false, null, null, null, "Thelma.Uwandu", 0, "Risk Management", new Guid("2a2e8cc2-24bc-4adf-acf7-57e73ac28756") },

                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d3fcfd86-22fb-4255-8255-a45704e47378"));

        }
    }
}
