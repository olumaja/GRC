using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class InternalAuditUserConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 15, 0, 402, DateTimeKind.Utc).AddTicks(4752), null, false, null, null, "InternalAuditManagerConcern" },
                    { new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 15, 0, 402, DateTimeKind.Utc).AddTicks(4756), null, false, null, null, "InternalAuditExecutiveManagerConcern" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
              table: "UserRole",
              keyColumn: "Id",
              keyValue: new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"));

            migrationBuilder.DeleteData(
               table: "UserRole",
               keyColumn: "Id",
               keyValue: new Guid("e20991e8-6233-4635-8829-4ee12bf7004d"));
                       
        }
    }
}
