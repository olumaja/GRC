using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class InternalControlExceptionTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalControlExceptionTracker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControlImpact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImpactRating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NatureOfException = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TransactionCount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActivityImpacted = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManagementResponse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExceptionTrackerStatus = table.Column<int>(type: "int", nullable: false),
                    ResponsibleOfficer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalControlExceptionTracker", x => x.Id);
                });
                       
        } 
        
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalControlExceptionTracker");          
            
        }
    }
}
