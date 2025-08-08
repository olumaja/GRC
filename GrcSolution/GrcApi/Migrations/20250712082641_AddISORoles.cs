using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddISORoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionOwnerUnit",
                table: "InfosecRiskAssessmentModel");

            migrationBuilder.DropColumn(
                name: "ControlEffectiveness",
                table: "InfosecRiskAssessmentModel");

            migrationBuilder.AddColumn<string>(
                name: "ControlEffective",
                table: "InfosecRiskAssessmentModel",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Annexture",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2147483647)",
                oldMaxLength: 2147483647);

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DateDeleted", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "ModuleItemType", "Name" },
                values: new object[,]
                {
                    { new Guid("d67f889d-7635-40ae-bb90-340b57032ad5"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 12, 9, 26, 29, 99, DateTimeKind.Local).AddTicks(923), null, null, false, null, null, 13, "InfoSec ISO Unit Head" },
                    { new Guid("dfdb754d-c7c7-4070-be8a-c86ea420f4c1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 7, 12, 9, 26, 29, 99, DateTimeKind.Local).AddTicks(880), null, null, false, null, null, 13, "InfoSec ISO Risk Champion" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("dfdb754d-c7c7-4070-be8a-c86ea420f4c1"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("d67f889d-7635-40ae-bb90-340b57032ad5"));

            migrationBuilder.DropColumn(
                name: "ControlEffective",
                table: "InfosecRiskAssessmentModel");

            migrationBuilder.AddColumn<string>(
                name: "ActionOwnerUnit",
                table: "InfosecRiskAssessmentModel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ControlEffectiveness",
                table: "InfosecRiskAssessmentModel",
                type: "int",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Annexture",
                type: "nvarchar(2147483647)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000); 
        }
    }
}
