using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AinternalAuditUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name" },
                values: new object[,]
                {
                    { new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 20, 14, 48, 13, 600, DateTimeKind.Utc).AddTicks(2908), null, false, null, null, "InternalAuditOfficer" },
                    { new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 20, 14, 48, 13, 600, DateTimeKind.Utc).AddTicks(2910), null, false, null, null, "InternalAuditSupervisor" }
                });       
               
        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"));
       
        }
    }
}
