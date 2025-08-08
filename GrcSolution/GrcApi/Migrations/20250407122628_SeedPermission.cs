using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Module", "Name" },
                values: new object[,]
                {
                    { new Guid("0291715f-c93a-425f-91e3-3f4d64cbe720"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8748), null, false, null, null, "Compliance Planning", "Approve attached report" },
                    { new Guid("05ca74cc-cd70-4965-9ea5-2530e2171774"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8762), null, false, null, null, "Regulatory Payment", "Approve regulatory payment" },
                    { new Guid("078c30e2-702e-4abe-af61-fc86357535d7"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8731), null, false, null, null, "Compliance Planning", "Create rule" },
                    { new Guid("0d542309-09b4-4176-ad55-e7d42e028d14"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8759), null, false, null, null, "Regulatory Payment", "Make Regulatory Payment" },
                    { new Guid("0f4e423f-2a2d-48bb-b8b7-3c1a4d444fa2"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8696), null, false, null, null, "Business Impact Analysis", "Approve initiate business impact analysis" },
                    { new Guid("226501c2-60c7-4254-bb7f-975480eae817"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8649), null, false, null, null, "Risk Control Self Assessment", "Start RCSA" },
                    { new Guid("2e44d6a0-5c92-40be-8d5e-28a586ddeb26"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8660), null, false, null, null, "Risk Control Self Assessment", "Apply test to process inherent risk" },
                    { new Guid("316f9d9a-3f5c-40e9-b5a5-25833587bda3"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8756), null, false, null, null, "Regulatory Payment", "Update regulatory payment" },
                    { new Guid("34e8d57a-e3f3-471e-be17-b8b70988282b"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8742), null, false, null, null, "Compliance Planning", "Create regulator" },
                    { new Guid("3889f9f8-25a5-4904-9d9c-56bf9d506a1d"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8776), null, false, null, null, "Statutory Payment", "Submit statutory payment" },
                    { new Guid("3fa5b006-8d8f-4fec-aff9-249615a896a1"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8745), null, false, null, null, "Compliance Planning", "Upload report" },
                    { new Guid("42a05247-8579-4c6c-96bf-d5cd3a73a89f"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8702), null, false, null, null, "Action Tracker", "Update action progress and status" },
                    { new Guid("438d86f6-f78c-44a8-b0fe-deb55693e80a"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8767), null, false, null, null, "Statutory Payment", "Initiate statutory payment" },
                    { new Guid("4467735e-4043-40a7-b571-654751d1b8d5"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8669), null, false, null, null, "Risk Control Self Assessment", "Approve reviewed test applied" },
                    { new Guid("4ca6b903-3f45-446d-b1ae-6d99b696c845"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8739), null, false, null, null, "Compliance Planning", "Update business" },
                    { new Guid("559c4f59-68ac-4f83-a708-6632b8a080f4"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8657), null, false, null, null, "Risk Control Self Assessment", "Process control risk rating" },
                    { new Guid("5c9bd282-d701-4591-877b-9e36a61cff69"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8781), null, false, null, null, "Statutory Payment", "Reject statutory payment" },
                    { new Guid("6306f9e3-2489-4d8d-9846-fe741faab813"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8654), null, false, null, null, "Risk Control Self Assessment", "Review RCSA" },
                    { new Guid("6ae48c8e-e15c-40aa-a660-3a7556d53f3c"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8666), null, false, null, null, "Risk Control Self Assessment", "Reject initiated RCSA" },
                    { new Guid("7f5e914d-5c48-4659-a46e-9461f64f4c9b"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8699), null, false, null, null, "Business Impact Analysis", "Reject initiate business impact analysis" },
                    { new Guid("80041e2a-9387-4554-ba14-496dfc07358a"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8677), null, false, null, null, "Risk Control Self Assessment", "Finalize RCSA" },
                    { new Guid("836b6390-aa37-4c3c-bdc1-42f9977a16b4"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8652), null, false, null, null, "Risk Control Self Assessment", "Initiate RCSA" },
                    { new Guid("9425e21e-0372-466c-bff1-70b685a75ee8"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8773), null, false, null, null, "Statutory Payment", "Process statutory payment" },
                    { new Guid("9f554761-84a3-4c52-9a3d-3955983c4cc3"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8691), null, false, null, null, "Business Impact Analysis", "Starts the Business Impact Analysis" },
                    { new Guid("9f87d685-92c9-42b4-a58e-20fe028dd3c4"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8637), null, false, null, null, "Risk Identification", "Create risk event" },
                    { new Guid("a17e0b76-5d29-4c79-a8df-bae18da34cb1"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8705), null, false, null, null, "Action Tracker", "Update action progress and status inherent risk" },
                    { new Guid("a9e34482-dd6b-4274-ae9f-0214d6490b3e"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8764), null, false, null, null, "Regulatory Payment", "Reject regulatory payment" },
                    { new Guid("ac289fc1-4149-42e3-9870-3ec94de81bfa"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8734), null, false, null, null, "Compliance Planning", "Update rule" },
                    { new Guid("b5333a97-47ae-4464-82e7-eb552230fd2c"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8680), null, false, null, null, "Product Risk Assessment", "Initiate product risk assessment" },
                    { new Guid("c135ca16-e877-4e16-aed0-9e330456f33f"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8751), null, false, null, null, "Compliance Planning", "Reject attached report" },
                    { new Guid("c42a1ac1-014c-4bfa-a258-7ddb9b257b58"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8694), null, false, null, null, "Business Impact Analysis", "Initiate the Business Impact Analysis" },
                    { new Guid("cf2a9cde-97eb-41e0-b17f-d7ac38ff601b"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8753), null, false, null, null, "Regulatory Payment", "Initiate regulatory payment" },
                    { new Guid("e1f00b8c-9704-4406-9d61-468146fe06dd"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8688), null, false, null, null, "Product Risk Assessment", "Reject product risk assessment" },
                    { new Guid("e36a0878-2621-4749-849c-0cc979ec0b32"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8737), null, false, null, null, "Compliance Planning", "Create business" },
                    { new Guid("e4db911f-91dd-463e-a310-b441708198aa"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8683), null, false, null, null, "Product Risk Assessment", "Create assess risk" },
                    { new Guid("e6ca00e4-7080-4198-b75c-37a2a99d4bc2"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8646), null, false, null, null, "Risk Identification", "Review risk event" },
                    { new Guid("ed334b91-9e47-46f0-92b7-84c9a1e34b9e"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8663), null, false, null, null, "Risk Control Self Assessment", "Approve initiated RCSA" },
                    { new Guid("f0157a4d-de6c-47c7-a4b3-243ebf8076ca"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8778), null, false, null, null, "Statutory Payment", "Approve statutory payment" },
                    { new Guid("f2641950-69d9-499c-8e7b-4b7b2a8a6efb"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8674), null, false, null, null, "Risk Control Self Assessment", "Reject reviewed test applied" },
                    { new Guid("f5b16af9-1c7d-4c03-8c4c-5669819f74cf"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8770), null, false, null, null, "Statutory Payment", "Update statutory payment" },
                    { new Guid("f8684d71-0b28-4f93-bcd7-d1f7c107708f"), null, new DateTime(2025, 4, 7, 12, 26, 16, 383, DateTimeKind.Utc).AddTicks(8685), null, false, null, null, "Product Risk Assessment", "Approve product risk assessment" }
                });

            migrationBuilder.InsertData(
                table: "UserRolePermission",
                columns: new[] { "PermissionId", "UserRoleId", "CreatedBy", "CreatedOnUtc", "DeletedBy", "IsDeleted", "ModifiedBy", "ModifiedOnUtc" },
                values: new object[,]
                {
                    { new Guid("9425e21e-0372-466c-bff1-70b685a75ee8"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3256), null, false, null, null },
                    { new Guid("2e44d6a0-5c92-40be-8d5e-28a586ddeb26"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3145), null, false, null, null },
                    { new Guid("42a05247-8579-4c6c-96bf-d5cd3a73a89f"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3183), null, false, null, null },
                    { new Guid("559c4f59-68ac-4f83-a708-6632b8a080f4"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3140), null, false, null, null },
                    { new Guid("836b6390-aa37-4c3c-bdc1-42f9977a16b4"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3136), null, false, null, null },
                    { new Guid("9f87d685-92c9-42b4-a58e-20fe028dd3c4"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3098), null, false, null, null },
                    { new Guid("a17e0b76-5d29-4c79-a8df-bae18da34cb1"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3191), null, false, null, null },
                    { new Guid("b5333a97-47ae-4464-82e7-eb552230fd2c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3114), null, false, null, null },
                    { new Guid("c42a1ac1-014c-4bfa-a258-7ddb9b257b58"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3167), null, false, null, null },
                    { new Guid("e1f00b8c-9704-4406-9d61-468146fe06dd"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3122), null, false, null, null },
                    { new Guid("f8684d71-0b28-4f93-bcd7-d1f7c107708f"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3118), null, false, null, null },
                    { new Guid("3889f9f8-25a5-4904-9d9c-56bf9d506a1d"), new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3260), null, false, null, null },
                    { new Guid("0f4e423f-2a2d-48bb-b8b7-3c1a4d444fa2"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3171), null, false, null, null },
                    { new Guid("42a05247-8579-4c6c-96bf-d5cd3a73a89f"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3179), null, false, null, null },
                    { new Guid("4467735e-4043-40a7-b571-654751d1b8d5"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3157), null, false, null, null },
                    { new Guid("6ae48c8e-e15c-40aa-a660-3a7556d53f3c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3153), null, false, null, null },
                    { new Guid("7f5e914d-5c48-4659-a46e-9461f64f4c9b"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3175), null, false, null, null },
                    { new Guid("9f87d685-92c9-42b4-a58e-20fe028dd3c4"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3090), null, false, null, null },
                    { new Guid("a17e0b76-5d29-4c79-a8df-bae18da34cb1"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3187), null, false, null, null },
                    { new Guid("b5333a97-47ae-4464-82e7-eb552230fd2c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3110), null, false, null, null },
                    { new Guid("e1f00b8c-9704-4406-9d61-468146fe06dd"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3130), null, false, null, null },
                    { new Guid("ed334b91-9e47-46f0-92b7-84c9a1e34b9e"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3149), null, false, null, null },
                    { new Guid("f2641950-69d9-499c-8e7b-4b7b2a8a6efb"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3163), null, false, null, null },
                    { new Guid("f8684d71-0b28-4f93-bcd7-d1f7c107708f"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3126), null, false, null, null },
                    { new Guid("0d542309-09b4-4176-ad55-e7d42e028d14"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3236), null, false, null, null },
                    { new Guid("3fa5b006-8d8f-4fec-aff9-249615a896a1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3215), null, false, null, null },
                    { new Guid("9f87d685-92c9-42b4-a58e-20fe028dd3c4"), new Guid("a8cac012-b665-481a-8028-90ed1c4226f9"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3104), null, false, null, null },
                    { new Guid("438d86f6-f78c-44a8-b0fe-deb55693e80a"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3248), null, false, null, null },
                    { new Guid("5c9bd282-d701-4591-877b-9e36a61cff69"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3268), null, false, null, null },
                    { new Guid("f0157a4d-de6c-47c7-a4b3-243ebf8076ca"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3264), null, false, null, null },
                    { new Guid("f5b16af9-1c7d-4c03-8c4c-5669819f74cf"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3252), null, false, null, null },
                    { new Guid("0291715f-c93a-425f-91e3-3f4d64cbe720"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3220), null, false, null, null },
                    { new Guid("05ca74cc-cd70-4965-9ea5-2530e2171774"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3240), null, false, null, null },
                    { new Guid("078c30e2-702e-4abe-af61-fc86357535d7"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3195), null, false, null, null },
                    { new Guid("316f9d9a-3f5c-40e9-b5a5-25833587bda3"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3232), null, false, null, null },
                    { new Guid("34e8d57a-e3f3-471e-be17-b8b70988282b"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3211), null, false, null, null },
                    { new Guid("4ca6b903-3f45-446d-b1ae-6d99b696c845"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3207), null, false, null, null },
                    { new Guid("a9e34482-dd6b-4274-ae9f-0214d6490b3e"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3244), null, false, null, null },
                    { new Guid("ac289fc1-4149-42e3-9870-3ec94de81bfa"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3199), null, false, null, null },
                    { new Guid("c135ca16-e877-4e16-aed0-9e330456f33f"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3224), null, false, null, null },
                    { new Guid("cf2a9cde-97eb-41e0-b17f-d7ac38ff601b"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3228), null, false, null, null },
                    { new Guid("e36a0878-2621-4749-849c-0cc979ec0b32"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 4, 7, 12, 26, 16, 390, DateTimeKind.Utc).AddTicks(3203), null, false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("226501c2-60c7-4254-bb7f-975480eae817"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("6306f9e3-2489-4d8d-9846-fe741faab813"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("80041e2a-9387-4554-ba14-496dfc07358a"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("9f554761-84a3-4c52-9a3d-3955983c4cc3"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("e4db911f-91dd-463e-a310-b441708198aa"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("e6ca00e4-7080-4198-b75c-37a2a99d4bc2"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("0291715f-c93a-425f-91e3-3f4d64cbe720"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("05ca74cc-cd70-4965-9ea5-2530e2171774"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("078c30e2-702e-4abe-af61-fc86357535d7"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("0d542309-09b4-4176-ad55-e7d42e028d14"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("0f4e423f-2a2d-48bb-b8b7-3c1a4d444fa2"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("2e44d6a0-5c92-40be-8d5e-28a586ddeb26"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("316f9d9a-3f5c-40e9-b5a5-25833587bda3"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("34e8d57a-e3f3-471e-be17-b8b70988282b"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("3889f9f8-25a5-4904-9d9c-56bf9d506a1d"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("3fa5b006-8d8f-4fec-aff9-249615a896a1"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("42a05247-8579-4c6c-96bf-d5cd3a73a89f"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("438d86f6-f78c-44a8-b0fe-deb55693e80a"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("4467735e-4043-40a7-b571-654751d1b8d5"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("4ca6b903-3f45-446d-b1ae-6d99b696c845"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("559c4f59-68ac-4f83-a708-6632b8a080f4"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("5c9bd282-d701-4591-877b-9e36a61cff69"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("6ae48c8e-e15c-40aa-a660-3a7556d53f3c"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("7f5e914d-5c48-4659-a46e-9461f64f4c9b"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("836b6390-aa37-4c3c-bdc1-42f9977a16b4"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("9425e21e-0372-466c-bff1-70b685a75ee8"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("9f87d685-92c9-42b4-a58e-20fe028dd3c4"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("a17e0b76-5d29-4c79-a8df-bae18da34cb1"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("a9e34482-dd6b-4274-ae9f-0214d6490b3e"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("ac289fc1-4149-42e3-9870-3ec94de81bfa"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("b5333a97-47ae-4464-82e7-eb552230fd2c"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("c135ca16-e877-4e16-aed0-9e330456f33f"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("c42a1ac1-014c-4bfa-a258-7ddb9b257b58"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("cf2a9cde-97eb-41e0-b17f-d7ac38ff601b"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("e1f00b8c-9704-4406-9d61-468146fe06dd"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("e36a0878-2621-4749-849c-0cc979ec0b32"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("ed334b91-9e47-46f0-92b7-84c9a1e34b9e"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("f0157a4d-de6c-47c7-a4b3-243ebf8076ca"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("f2641950-69d9-499c-8e7b-4b7b2a8a6efb"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("f5b16af9-1c7d-4c03-8c4c-5669819f74cf"));

            migrationBuilder.DeleteData(
                table: "Permission",
                keyColumn: "Id",
                keyValue: new Guid("f8684d71-0b28-4f93-bcd7-d1f7c107708f"));

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("9425e21e-0372-466c-bff1-70b685a75ee8"), new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("2e44d6a0-5c92-40be-8d5e-28a586ddeb26"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("42a05247-8579-4c6c-96bf-d5cd3a73a89f"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("559c4f59-68ac-4f83-a708-6632b8a080f4"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("836b6390-aa37-4c3c-bdc1-42f9977a16b4"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("9f87d685-92c9-42b4-a58e-20fe028dd3c4"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("a17e0b76-5d29-4c79-a8df-bae18da34cb1"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("b5333a97-47ae-4464-82e7-eb552230fd2c"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("c42a1ac1-014c-4bfa-a258-7ddb9b257b58"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("e1f00b8c-9704-4406-9d61-468146fe06dd"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("f8684d71-0b28-4f93-bcd7-d1f7c107708f"), new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("3889f9f8-25a5-4904-9d9c-56bf9d506a1d"), new Guid("6a41b1bf-2ead-46f8-9fa6-a2b8c2529f81") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("0f4e423f-2a2d-48bb-b8b7-3c1a4d444fa2"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("42a05247-8579-4c6c-96bf-d5cd3a73a89f"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("4467735e-4043-40a7-b571-654751d1b8d5"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("6ae48c8e-e15c-40aa-a660-3a7556d53f3c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("7f5e914d-5c48-4659-a46e-9461f64f4c9b"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("9f87d685-92c9-42b4-a58e-20fe028dd3c4"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("a17e0b76-5d29-4c79-a8df-bae18da34cb1"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("b5333a97-47ae-4464-82e7-eb552230fd2c"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("e1f00b8c-9704-4406-9d61-468146fe06dd"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("ed334b91-9e47-46f0-92b7-84c9a1e34b9e"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("f2641950-69d9-499c-8e7b-4b7b2a8a6efb"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("f8684d71-0b28-4f93-bcd7-d1f7c107708f"), new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("0d542309-09b4-4176-ad55-e7d42e028d14"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("3fa5b006-8d8f-4fec-aff9-249615a896a1"), new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("9f87d685-92c9-42b4-a58e-20fe028dd3c4"), new Guid("a8cac012-b665-481a-8028-90ed1c4226f9") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("438d86f6-f78c-44a8-b0fe-deb55693e80a"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("5c9bd282-d701-4591-877b-9e36a61cff69"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("f0157a4d-de6c-47c7-a4b3-243ebf8076ca"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("f5b16af9-1c7d-4c03-8c4c-5669819f74cf"), new Guid("b2809835-af4f-4c1c-8d5f-8bddca554f86") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("0291715f-c93a-425f-91e3-3f4d64cbe720"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("05ca74cc-cd70-4965-9ea5-2530e2171774"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("078c30e2-702e-4abe-af61-fc86357535d7"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("316f9d9a-3f5c-40e9-b5a5-25833587bda3"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("34e8d57a-e3f3-471e-be17-b8b70988282b"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("4ca6b903-3f45-446d-b1ae-6d99b696c845"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("a9e34482-dd6b-4274-ae9f-0214d6490b3e"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("ac289fc1-4149-42e3-9870-3ec94de81bfa"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("c135ca16-e877-4e16-aed0-9e330456f33f"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("cf2a9cde-97eb-41e0-b17f-d7ac38ff601b"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });

            migrationBuilder.DeleteData(
                table: "UserRolePermission",
                keyColumns: new[] { "PermissionId", "UserRoleId" },
                keyValues: new object[] { new Guid("e36a0878-2621-4749-849c-0cc979ec0b32"), new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c") });
        }
    }
}
