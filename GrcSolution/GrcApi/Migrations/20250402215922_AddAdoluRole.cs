using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAdoluRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "UserRoleMap",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc" },
                values: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("4b510482-51c3-43ed-98d9-bc58cdd53cd3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 2, 21, 59, 19, 642, DateTimeKind.Utc).AddTicks(2769), null, false, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("4b510482-51c3-43ed-98d9-bc58cdd53cd3") });
        }
    }
}
