using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleMapUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.InsertData(
                table: "UserRoleMap",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"), new Guid("1b0346b0-5186-4af1-8f80-8605f368296d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 25, 15, 17, 44, 630, DateTimeKind.Local).AddTicks(8215), null, false, null, null },
                    { new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"), new Guid("744e925b-6aa7-45fa-824c-0b505a04e20a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 25, 15, 17, 44, 630, DateTimeKind.Local).AddTicks(8212), null, false, null, null },
                    { new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"), new Guid("b241d596-f089-434b-a94c-16114c0a4b4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 6, 25, 15, 17, 44, 630, DateTimeKind.Local).AddTicks(8208), null, false, null, null }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"), new Guid("1b0346b0-5186-4af1-8f80-8605f368296d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"), new Guid("744e925b-6aa7-45fa-824c-0b505a04e20a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e4495bcf-454a-4f04-92e2-9cb02605db3c"), new Guid("b241d596-f089-434b-a94c-16114c0a4b4b") });

        }
    }
}
