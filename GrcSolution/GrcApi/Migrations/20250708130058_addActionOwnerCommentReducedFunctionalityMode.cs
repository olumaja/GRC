using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class addActionOwnerCommentReducedFunctionalityMode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<string>(
                name: "ActionOwnerComment",
                table: "ReducedFunctionalityMode",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActionOwnerComment",
                table: "InactiveSensors",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "ActionOwnerComment",
                table: "ReducedFunctionalityMode");

            migrationBuilder.DropColumn(
                name: "ActionOwnerComment",
                table: "InactiveSensors");
                        
        }
    }
}
