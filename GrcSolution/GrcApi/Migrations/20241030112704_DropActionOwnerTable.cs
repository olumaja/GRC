using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class DropActionOwnerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalControlActionOwner");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalControlActionOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternalControlModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionOwner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionOwnerStatus = table.Column<int>(type: "int", nullable: false),
                    ActionToBeResolved = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonForRejection = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Response = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ResponseTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalControlActionOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalControlActionOwner_InternalControlModel_InternalControlModelId",
                        column: x => x.InternalControlModelId,
                        principalTable: "InternalControlModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalControlActionOwner_InternalControlModelId",
                table: "InternalControlActionOwner",
                column: "InternalControlModelId");
        }
    }
}
