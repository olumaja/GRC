using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedInternalControlExceptionTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "ReasonForReject",
                table: "InternalControlExceptionTracker",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequesterEmail",
                table: "InternalControlExceptionTracker",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorStatus",
                table: "InternalControlExceptionTracker",
                type: "int",
                nullable: false,
                defaultValue: 0);
                        
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {                      
            
            migrationBuilder.DropColumn(
                name: "ReasonForReject",
                table: "InternalControlExceptionTracker");

            migrationBuilder.DropColumn(
                name: "RequesterEmail",
                table: "InternalControlExceptionTracker");

            migrationBuilder.DropColumn(
                name: "SupervisorStatus",
                table: "InternalControlExceptionTracker");

        }

    }
}
