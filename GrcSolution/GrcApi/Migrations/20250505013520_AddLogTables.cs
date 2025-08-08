using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLogTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    DateAlertGenerated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActionownerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionownerEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RequesterEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProposeEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActionOwnerUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BusinessJustification = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    UserApprovalObtained = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InfoSecRemarks = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ActionOwnerRemarks = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ReasonForRejection = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    IsReminderSent1WkToProposedEndDate = table.Column<bool>(type: "bit", nullable: false),
                    IsReminderSent3DaysToProposedEndDate = table.Column<bool>(type: "bit", nullable: false),
                    IsReminderSent1DayToProposedEndDate = table.Column<bool>(type: "bit", nullable: false),
                    IsReminderSentOnTheProposedEndDate = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogManagement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CASPLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogManagementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ResponsibleStaff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceFileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceDevice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationEmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ObjectIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Application = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_CASPLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CASPLog_LogManagement_LogManagementId",
                        column: x => x.LogManagementId,
                        principalTable: "LogManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DAMLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogManagementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ConfigurationObject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationDetail = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
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
                    Observation = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
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
                    table.PrimaryKey("PK_DAMLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DAMLog_LogManagement_LogManagementId",
                        column: x => x.LogManagementId,
                        principalTable: "LogManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DLPLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogManagementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DLPPolicy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DLPRuleMatch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DLPRuleAction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionTaken = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ResponsibleStaff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLPLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DLPLog_LogManagement_LogManagementId",
                        column: x => x.LogManagementId,
                        principalTable: "LogManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EDRLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogManagementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ConfigurationDetail = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    SourceIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceFileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationFQDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationIPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DestinationHostName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SecurityTool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActionTakenByUs = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Technique = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FileHash = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDRLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDRLog_LogManagement_LogManagementId",
                        column: x => x.LogManagementId,
                        principalTable: "LogManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FIMLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogManagementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ConfigurationObject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationDetail = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
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
                    SecurityTool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIMLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FIMLog_LogManagement_LogManagementId",
                        column: x => x.LogManagementId,
                        principalTable: "LogManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAMLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogManagementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IncidentDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CorrectiveActionCarriedOut = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
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
                    table.PrimaryKey("PK_PAMLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PAMLog_LogManagement_LogManagementId",
                        column: x => x.LogManagementId,
                        principalTable: "LogManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SIEMLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogManagementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ConfigurationObject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConfigurationDetail = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
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
                    Observation = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
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
                    table.PrimaryKey("PK_SIEMLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SIEMLog_LogManagement_LogManagementId",
                        column: x => x.LogManagementId,
                        principalTable: "LogManagement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CASPLog_LogManagementId",
                table: "CASPLog",
                column: "LogManagementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DAMLog_LogManagementId",
                table: "DAMLog",
                column: "LogManagementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DLPLog_LogManagementId",
                table: "DLPLog",
                column: "LogManagementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EDRLog_LogManagementId",
                table: "EDRLog",
                column: "LogManagementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FIMLog_LogManagementId",
                table: "FIMLog",
                column: "LogManagementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAMLog_LogManagementId",
                table: "PAMLog",
                column: "LogManagementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SIEMLog_LogManagementId",
                table: "SIEMLog",
                column: "LogManagementId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CASPLog");

            migrationBuilder.DropTable(
                name: "DAMLog");

            migrationBuilder.DropTable(
                name: "DLPLog");

            migrationBuilder.DropTable(
                name: "EDRLog");

            migrationBuilder.DropTable(
                name: "FIMLog");

            migrationBuilder.DropTable(
                name: "PAMLog");

            migrationBuilder.DropTable(
                name: "SIEMLog");

            migrationBuilder.DropTable(
                name: "LogManagement");
        }
    }
}
