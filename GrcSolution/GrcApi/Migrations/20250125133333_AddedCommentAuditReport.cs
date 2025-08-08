using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentAuditReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           





           

            migrationBuilder.AddColumn<string>(
                name: "ReportComment",
                table: "InternalAuditReport",
                type: "nvarchar(MAX)",
                maxLength: 50,
                nullable: true);


            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

        }
    }
}
