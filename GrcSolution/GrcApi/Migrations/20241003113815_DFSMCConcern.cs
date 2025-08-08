using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class DFSMCConcern : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                       
            migrationBuilder.CreateTable(
                name: "ManagementConcernDFS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagementConcernRiskRatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(MAX)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementConcernDFS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementConcernDFS_ManagementConcernRiskRating_ManagementConcernRiskRatingId",
                        column: x => x.ManagementConcernRiskRatingId,
                        principalTable: "ManagementConcernRiskRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementConcernBusinessUnitDFSRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagementConcernDFSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DigitalFinancialService = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementConcernBusinessUnitDFSRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementConcernBusinessUnitDFSRating_ManagementConcernDFS_ManagementConcernDFSId",
                        column: x => x.ManagementConcernDFSId,
                        principalTable: "ManagementConcernDFS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementConcernSharedServiceDFSRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagementConcernDFSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HCM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcurementAndAdmin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RiskManagement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Legal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MCC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Academy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CTO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerExperience = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InformationSecurity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InternalControl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CorporateStrategy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Treasury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Compliance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinancialControl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAnalytic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementConcernSharedServiceDFSRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementConcernSharedServiceDFSRating_ManagementConcernDFS_ManagementConcernDFSId",
                        column: x => x.ManagementConcernDFSId,
                        principalTable: "ManagementConcernDFS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


        }
    }
}
