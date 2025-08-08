using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMapUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoleMap",
                columns: new[] { "RoleId", "UserId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("C48C025D-C9DC-4525-BD5B-8E0898585852"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1488), null, false, null, null },
                    { new Guid("2fc82d56-b5ac-44a6-8f5e-3ea708d722e5"), new Guid("0B0FDCAE-D8AF-4505-88B4-88E42F5E43AB"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1492), null, false, null, null },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5E2A7BE9-A773-4F2E-9B96-3CDFE9B074BE"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1501), null, false, null, null },
                    { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("40D1D858-3446-4BA7-92BB-35DB2DAE6BED"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1482), null, false, null, null },
                    { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("8CD17AAF-7503-4906-B6A0-1A24227520CB"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1485), null, false, null, null },
                    { new Guid("2fc82d56-b5ac-44a6-8f5e-3ea708d722e5"), new Guid("CDDCC87A-8F88-4A4F-B81C-B690496571A8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1491), null, false, null, null },
                    { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("2D0F9EE3-C16D-4097-9DE3-EA7974A2C3B3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1481), null, false, null, null },
                    { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("5B3E427F-8B10-4B20-A217-711CE08B6E48"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1479), null, false, null, null },
                    { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("003DA116-B61E-4D0C-AEE1-FD7055110BAD"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 5, 23, 8, 10, 9, 734, DateTimeKind.Local).AddTicks(1486), null, false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("C48C025D-C9DC-4525-BD5B-8E0898585852") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("40D1D858-3446-4BA7-92BB-35DB2DAE6BED") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("8CD17AAF-7503-4906-B6A0-1A24227520CB") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("2D0F9EE3-C16D-4097-9DE3-EA7974A2C3B3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("5B3E427F-8B10-4B20-A217-711CE08B6E48") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("003DA116-B61E-4D0C-AEE1-FD7055110BAD") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2fc82d56-b5ac-44a6-8f5e-3ea708d722e5"), new Guid("0B0FDCAE-D8AF-4505-88B4-88E42F5E43AB") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2fc82d56-b5ac-44a6-8f5e-3ea708d722e5"), new Guid("CDDCC87A-8F88-4A4F-B81C-B690496571A8") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5E2A7BE9-A773-4F2E-9B96-3CDFE9B074BE") });
        }
    }
}
