using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddComplianceUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Department", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "ModuleItemType", "Name", "Status", "Unit", "UnitId" },
                values: new object[,]
                {
                 { new Guid("c48c025d-c9dc-4525-bd5b-8e0898585852"), "ARM IM", null, new DateTime(2025, 5, 23, 7, 1, 5, 737, DateTimeKind.Local).AddTicks(6379), null, null, "hannah.aliu@arm.com.ng", false, null, null, null, "Hannah Aliu", 0, "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                 { new Guid("40d1d858-3446-4ba7-92bb-35db2dae6bed"), "ARM IM", null, new DateTime(2025, 5, 23, 7, 1, 5, 737, DateTimeKind.Local).AddTicks(6383), null, null, "oluwafunke.nasiru@arm.com.ng", false, null, null, null, "Oluwafunke Nasiru", 0, "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                 { new Guid("8cd17aaf-7503-4906-b6a0-1a24227520cb"), "ARM IM", null, new DateTime(2025, 5, 23, 7, 1, 5, 737, DateTimeKind.Local).AddTicks(6388), null, null, "ademola.fatade@arm.com.ng", false, null, null, null, "Ademola Fatade", 0, "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                 { new Guid("2d0f9ee3-c16d-4097-9de3-ea7974a2c3b3"), "ARM IM", null, new DateTime(2025, 5, 23, 7, 1, 5, 737, DateTimeKind.Local).AddTicks(6393), null, null, "faizat.adeboye@arm.com.ng", false, null, null, null, "Faizat Adeboye", 0, "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                 { new Guid("5b3e427f-8b10-4b20-a217-711ce08b6e48"), "ARM IM", null, new DateTime(2025, 5, 23, 7, 1, 5, 737, DateTimeKind.Local).AddTicks(6398), null, null, "taiwo.olusola@arm.com.ng", false, null, null, null, "Taiwo Olusola", 0, "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                 { new Guid("003da116-b61e-4d0c-aee1-fd7055110bad"), "ARM IM", null, new DateTime(2025, 5, 23, 7, 1, 5, 737, DateTimeKind.Local).AddTicks(6403), null, null, "olanrewaju.fatai@arm.com.ng", false, null, null, null, "Olanrewaju Fatai@", 0, "Operation Controls", new Guid("285bdc67-c5b3-4802-9f08-b9fe2557432d") },
                 { new Guid("cddcc87a-8f88-4a4f-b81c-b690496571a8"), "Shared Services", null, new DateTime(2025, 5, 23, 7, 1, 5, 737, DateTimeKind.Local).AddTicks(6407), null, null, "joy.ogunbi@arm.com.ng", false, null, null, null, "Joy Ogunbi", 0, "Information Security", new Guid("037019bf-ce11-4307-a984-170b02ca17a9") },
                 { new Guid("5e2a7be9-a773-4f2e-9b96-3cdfe9b074be"), "ARM IM", null, new DateTime(2025, 5, 23, 7, 1, 5, 737, DateTimeKind.Local).AddTicks(6185), null, null, "chinonso.okocha@arm.com.ng", false, null, null, null, "Chinonso Okocha", 0, "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7") }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("87497A34-3059-4B2E-9AFD-65AD4CCF9CDC"),
                column: "Email",
                value: "dolapo.oyeleke@arm.com.ng");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c48c025d-c9dc-4525-bd5b-8e0898585852"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("40d1d858-3446-4ba7-92bb-35db2dae6bed"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8cd17aaf-7503-4906-b6a0-1a24227520cb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2d0f9ee3-c16d-4097-9de3-ea7974a2c3b3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5b3e427f-8b10-4b20-a217-711ce08b6e48"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("003da116-b61e-4d0c-aee1-fd7055110bad"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cddcc87a-8f88-4a4f-b81c-b690496571a8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5e2a7be9-a773-4f2e-9b96-3cdfe9b074be"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("87497A34-3059-4B2E-9AFD-65AD4CCF9CDC"),
                column: "Email",
                value: "adedolapo.oyeleke@arm.com.ng");
        }
    }
}
