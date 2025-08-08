using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class DropDepartmentFromRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "ComplianceRules");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("09809373-4bdb-4e41-a794-271730b2563d"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 3, 11, 18, 8, 929, DateTimeKind.Utc).AddTicks(9705), null, "olawale.bakir@arm.com.ng", false, null, null, "Olawale Bakir", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") },
                    { new Guid("3b500d34-3fd9-4fab-978e-30a79c173124"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 3, 11, 18, 8, 929, DateTimeKind.Utc).AddTicks(9708), null, "barakat.olusanya@arm.com.ng", false, null, null, "Barakat Olusanya", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") },
                    { new Guid("e4caa81a-d403-4a4b-a7e2-0b56d2e7cd00"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 9, 3, 11, 18, 8, 929, DateTimeKind.Utc).AddTicks(9566), null, "judith.okeke@arm.com.ng", false, null, null, "Judith Okeke", "Trading & Brokerage", new Guid("b4a85a6e-f9db-4af1-ac85-175574f703f7"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") }
                });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("09809373-4bdb-4e41-a794-271730b2563d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3b500d34-3fd9-4fab-978e-30a79c173124"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e4caa81a-d403-4a4b-a7e2-0b56d2e7cd00"));

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "ComplianceRules",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
