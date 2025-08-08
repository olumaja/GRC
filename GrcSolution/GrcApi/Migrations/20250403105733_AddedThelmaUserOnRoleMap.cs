using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedThelmaUserOnRoleMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.InsertData(
                table: "UserRoleMap",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc" },
                values: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("d3fcfd86-22fb-4255-8255-a45704e47378"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 3, 10, 57, 31, 59, DateTimeKind.Utc).AddTicks(9418), null, false, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {           
            
            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("d3fcfd86-22fb-4255-8255-a45704e47378") });

        }


    }
}
