using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIfeoluwaniOkunoye : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumns: new[] { "Id" },
                keyValues: new object[] { new Guid("CF9C48F2-20DA-4989-B929-B2A250154126") },
                column: "Email",
                value: "ifeoluwani.okunoye@arm.com.ng");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumns: new[] { "Id" },
                keyValues: new object[] { new Guid("CF9C48F2-20DA-4989-B929-B2A250154126") },
                column: "Email",
                value: "ifeoluwa.okunoye@arm.com.ng");
        }
    }
}
