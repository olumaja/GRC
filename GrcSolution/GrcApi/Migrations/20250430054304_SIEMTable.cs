using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class SIEMTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CASPModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StaffName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceFileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceDevice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ObjectIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Application = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SecurityTool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASPModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DAMModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAlertGenerated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationObject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationDetail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourcePort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationIpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NATIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NATPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaliciousReputation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserAuthorized = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BusinessJustification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SecurityTool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAMModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLPModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleStaff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DLPPolicy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DLPRuleMatch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionTaken = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateGenerated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLPModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDRModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAlertGenerated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceFileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionTakenByCS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Technique = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FileHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SecurityTool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDRModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FIMModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAlertGenerated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationObject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationDetail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourcePort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationIpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NATIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NATPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaliciousReputation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserAuthorized = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BusinessJustification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SecurityTool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIMModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogManagementModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionownerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionownerEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequesterName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequesterEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProposeEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogManagementModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PAMModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAlertGenerated = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CorperativeActionCarriedOut = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DatecarriedOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAMModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SIEMModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateAlertGenerated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfReport = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationObject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationDetail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationIpAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NATIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NATPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaliciousReputation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SecurityTool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SIEMModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CASPModel");

            migrationBuilder.DropTable(
                name: "DAMModel");

            migrationBuilder.DropTable(
                name: "DLPModel");

            migrationBuilder.DropTable(
                name: "EDRModel");

            migrationBuilder.DropTable(
                name: "FIMModel");

            migrationBuilder.DropTable(
                name: "LogManagementModel");

            migrationBuilder.DropTable(
                name: "PAMModel");

            migrationBuilder.DropTable(
                name: "SIEMModel");
        }
    }
}
