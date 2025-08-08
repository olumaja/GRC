using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEmailInternalControlActionOwner : Migration
    {

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "IsReminderSent12Hrs",
                table: "InternalControlActionOwner",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReminderSent24Hrs",
                table: "InternalControlActionOwner",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReminderSent36Hrs",
                table: "InternalControlActionOwner",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReminderSent48Hrs",
                table: "InternalControlActionOwner",
                type: "bit",
                nullable: true);

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "IsReminderSent12Hrs",
                table: "InternalControlActionOwner");

            migrationBuilder.DropColumn(
                name: "IsReminderSent24Hrs",
                table: "InternalControlActionOwner");

            migrationBuilder.DropColumn(
                name: "IsReminderSent36Hrs",
                table: "InternalControlActionOwner");

            migrationBuilder.DropColumn(
                name: "IsReminderSent48Hrs",
                table: "InternalControlActionOwner");

          
        }
    }
}
