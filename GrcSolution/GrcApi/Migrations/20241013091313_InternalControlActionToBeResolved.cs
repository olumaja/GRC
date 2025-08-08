using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class InternalControlActionToBeResolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionToBeResolved",
                table: "InternalControlModel");

            migrationBuilder.AddColumn<string>(
                name: "ActionToBeResolved",
                table: "InternalControlActionOwner",
                type: "nvarchar(MAX)",
                maxLength: 50,
                nullable: true);
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.DropColumn(
                name: "ActionToBeResolved",
                table: "InternalControlActionOwner");

            migrationBuilder.AddColumn<string>(
                name: "ActionToBeResolved",
                table: "InternalControlModel",
                type: "nvarchar(MAX)",
                maxLength: 50,
                nullable: true);

        }
    }
}
