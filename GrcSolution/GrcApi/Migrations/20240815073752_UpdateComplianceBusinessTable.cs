using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComplianceBusinessTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComplianceBusines",
                keyColumn: "Id",
                keyValue: new Guid("70c25108-c4c7-4221-b444-2a98bddbba7b"),
                columns: new[] { "BusinessName", "CreatedOnUtc", "DateUpdated" },
                values: new object[] { "ARM Trustees", new DateTime(2024, 8, 15, 7, 37, 50, 513, DateTimeKind.Utc).AddTicks(8948), new DateTime(2024, 8, 15, 8, 37, 50, 513, DateTimeKind.Local).AddTicks(8947) });

            migrationBuilder.UpdateData(
                table: "ComplianceBusines",
                keyColumn: "Id",
                keyValue: new Guid("803dcb0e-6a10-4e3b-9c73-35f1c7c4a265"),
                columns: new[] { "BusinessName", "CreatedOnUtc", "DateUpdated" },
                values: new object[] { "ARM Capital Partner", new DateTime(2024, 8, 15, 7, 37, 50, 513, DateTimeKind.Utc).AddTicks(8949), new DateTime(2024, 8, 15, 8, 37, 50, 513, DateTimeKind.Local).AddTicks(8949) });

            migrationBuilder.UpdateData(
                table: "ComplianceBusines",
                keyColumn: "Id",
                keyValue: new Guid("b8fda6fb-0e8a-4621-bae1-16f26d40f345"),
                columns: new[] { "BusinessName", "CreatedOnUtc", "DateUpdated" },
                values: new object[] { "ARM Securities", new DateTime(2024, 8, 15, 7, 37, 50, 513, DateTimeKind.Utc).AddTicks(8937), new DateTime(2024, 8, 15, 8, 37, 50, 513, DateTimeKind.Local).AddTicks(8926) });

            migrationBuilder.UpdateData(
                table: "ComplianceBusines",
                keyColumn: "Id",
                keyValue: new Guid("c767a782-a495-4b96-988c-22e8e16c33d9"),
                columns: new[] { "BusinessName", "CreatedOnUtc", "DateUpdated" },
                values: new object[] { "ARM IM", new DateTime(2024, 8, 15, 7, 37, 50, 513, DateTimeKind.Utc).AddTicks(8941), new DateTime(2024, 8, 15, 8, 37, 50, 513, DateTimeKind.Local).AddTicks(8941) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComplianceBusines",
                keyColumn: "Id",
                keyValue: new Guid("70c25108-c4c7-4221-b444-2a98bddbba7b"),
                columns: new[] { "BusinessName", "CreatedOnUtc", "DateUpdated" },
                values: new object[] { "ARMTrustee", new DateTime(2024, 8, 14, 17, 34, 59, 871, DateTimeKind.Utc).AddTicks(2589), new DateTime(2024, 8, 14, 18, 34, 59, 871, DateTimeKind.Local).AddTicks(2589) });

            migrationBuilder.UpdateData(
                table: "ComplianceBusines",
                keyColumn: "Id",
                keyValue: new Guid("803dcb0e-6a10-4e3b-9c73-35f1c7c4a265"),
                columns: new[] { "BusinessName", "CreatedOnUtc", "DateUpdated" },
                values: new object[] { "ARMCapitalPartner", new DateTime(2024, 8, 14, 17, 34, 59, 871, DateTimeKind.Utc).AddTicks(2591), new DateTime(2024, 8, 14, 18, 34, 59, 871, DateTimeKind.Local).AddTicks(2591) });

            migrationBuilder.UpdateData(
                table: "ComplianceBusines",
                keyColumn: "Id",
                keyValue: new Guid("b8fda6fb-0e8a-4621-bae1-16f26d40f345"),
                columns: new[] { "BusinessName", "CreatedOnUtc", "DateUpdated" },
                values: new object[] { "ARMSecurity", new DateTime(2024, 8, 14, 17, 34, 59, 871, DateTimeKind.Utc).AddTicks(2584), new DateTime(2024, 8, 14, 18, 34, 59, 871, DateTimeKind.Local).AddTicks(2573) });

            migrationBuilder.UpdateData(
                table: "ComplianceBusines",
                keyColumn: "Id",
                keyValue: new Guid("c767a782-a495-4b96-988c-22e8e16c33d9"),
                columns: new[] { "BusinessName", "CreatedOnUtc", "DateUpdated" },
                values: new object[] { "ARMIM", new DateTime(2024, 8, 14, 17, 34, 59, 871, DateTimeKind.Utc).AddTicks(2588), new DateTime(2024, 8, 14, 18, 34, 59, 871, DateTimeKind.Local).AddTicks(2587) });
        }
    }
}
