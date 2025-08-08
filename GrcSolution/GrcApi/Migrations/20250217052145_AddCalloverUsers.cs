using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCalloverUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                 table: "User",
                 keyColumn: "Id",
                 keyValue: new Guid("2e1e45de-8f69-4b7a-8a52-924c6c08e9ae"),
                 column: "Unit",
                 value: "Customer Experience");

            migrationBuilder.UpdateData(
                 table: "User",
                 keyColumn: "Id",
                 keyValue: new Guid("038ec42b-a09a-462f-beb4-35658993d174"),
                 column: "Unit",
                 value: "Customer Experience");

            migrationBuilder.UpdateData(
                 table: "User",
                 keyColumn: "Id",
                 keyValue: new Guid("ffd3a51e-3f36-455e-9c22-117e6adae361"),
                 column: "Unit",
                 value: "Customer Experience");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("014923ac-7916-463e-b6e9-07722a160768"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6291), null, "yetunde.adio@arm.com.ng", false, null, null, "Yetunde Adio", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("0ad59504-1fab-43b8-91f3-877c354925de"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6296), null, "lebechi.ndukwe@arm.com.ng", false, null, null, "Lebechi Ndukwe", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("0d05d981-e9f3-41ea-a637-6b84e36fb8dd"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6334), null, "emmanuella.anaza@arm.com.ng", false, null, null, "Emmanuella Anaza", "Financial Control", new Guid("fb274136-84fe-430d-bab9-6647909a1a48"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("0e8f7bbe-cab2-4328-9ccf-7d5547c0adac"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6274), null, "dolapo.fashina@arm.com.ng", false, null, null, "Dolapo Fashina", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("0ff49eb5-c520-4d2d-932d-476b17132120"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6365), null, "emmanuel.peter@arm.com.ng", false, null, null, "Emmanuel Peter", "Operation Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("0fffd1c8-7478-41df-87aa-a706106f19a3"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6294), null, "bukola.abdulakeem@arm.com.ng", false, null, null, "Bukola Abdulakeem", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("10e17a75-073a-4134-af55-05e2434f37be"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6355), null, "oluwatomilola.oduntan@arm.com.ng", false, null, null, "Oluwatomilola Oduntan", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("1758e6e0-c9cd-439f-b52a-a2d87126deee"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6311), null, "chinonso.iwuozor@arm.com.ng", false, null, null, "Chinonso Iwuozor", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("184af40f-9cd0-4588-99cf-a443a4d4c999"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6271), null, "ifeyinwa.amadi@arm.com.ng", false, null, null, "Ifeyinwa Amadi", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("1c5bcc5a-cb39-4edc-9052-5aa2496bdeba"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6258), null, "gift.aizebeoje@arm.com.ng", false, null, null, "Gift Aizebeoje", "IMUnit", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("1cc35f37-d44e-45e2-8f3b-3819d939ee20"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6282), null, "adedolapo.oyeleke@arm.com.ng", false, null, null, "Adedolapo Oyeleke", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("20a16490-de03-4496-9d42-421acd49511e"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6371), null, "ibukun.ajose@arm.com.ng", false, null, null, "Ibukun Ajose", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("20e58a50-51f6-4118-adc9-1c190a00f7da"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6313), null, "jane.david-abia@arm.com.ng", false, null, null, "Jane David-Abia", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("27766613-22c5-4edf-89f5-2f0bfc8a792e"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6336), null, "stephanie.gber@arm.com.ng", false, null, null, "Stephanie Gber", "Financial Control", new Guid("90cd9708-b7b4-4203-ba98-6ce8c66e623e"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("29525504-1c12-4583-93c3-f22f42a3afa5"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6285), null, "rukayat.adepitan@arm.com.ng", false, null, null, "Rukayat Adepitan", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("2e1ffd11-5fc2-4759-82bc-9ed8f1252772"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6322), null, "evelyn.osindeinde@arm.com.ng", false, null, null, "Evelyn Osindeinde", "Customer Experience", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("308de6f9-48bf-4299-887e-930fe9cfee5f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6227), null, "victor.arowolo@arm.com.ng", false, null, null, "Victor Arowolo", "Operations Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("31af6308-577e-4d93-92e1-f9bc74951497"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6359), null, "adetayo.adebiyi@arm.com.ng", false, null, null, "Adetayo Adebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("343e0e59-fe30-4058-acdc-350c6a690c8c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6305), null, "chukwuebuka.agbo@arm.com.ng", false, null, null, "Chukwuebuka Agbo", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("3668a48f-aca4-4fe5-a72a-83bab65df3df"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6304), null, "anike.olalere@arm.com.ng", false, null, null, "Anike Olalere", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("3ee99914-23ea-4ee8-a144-ea542d336f81"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6287), null, "deborah.dubukumah@arm.com.ng", false, null, null, "Deborah Dubukumah", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("409dbc12-05fd-4ebd-8fac-6fb4f505af35"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6317), null, "adepeju.sangotade@arm.com.ng", false, null, null, "Adepeju Sangotade", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("4f523578-1326-42c7-8952-73d05c558b9f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6351), null, "isaac.elakhe@arm.com.ng", false, null, null, "Isaac Elakhe", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("56a098f1-7b4c-4c96-8869-4fb2cf8196e8"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6356), null, "martins.onemolease@arm.com.ng", false, null, null, "Martins Onemolease", "Fund Amin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("596617ed-f589-4b49-b618-ef9f89ab4641"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6363), null, "covenant.ukachi@arm.com.ng", false, null, null, "Covenant Ukachi", "Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("5eb3c14c-92ef-410a-9eb3-8bbc2f06bea0"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6288), null, "damilola.akinlade@arm.com.ng", false, null, null, "Damilola Akinlade", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("61a8478f-2f1a-4260-8463-043a9c0173d2"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6240), null, "oluwaferanmi.adedokun@arm.com.ng", false, null, null, "Oluwaferanmi Adedokun", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("65a331f3-831b-474a-a391-ebabe3120bb2"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6299), null, "godwin.ebie@arm.com.ng", false, null, null, "Godwin Ebie", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("66b3b8c8-8d83-48e5-af42-924ad635b87c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6231), null, "aminat.ashafa@arm.com.ng", false, null, null, "Aminat Ashafa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("66c0b98a-7b5e-4e22-986e-d7f38ab06773"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6314), null, "olufunke.sipe@arm.com.ng", false, null, null, "Olufunke Sipe", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("6737a5e0-8209-4ab9-b9f4-bd92a55761c7"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6346), null, "ifeoluwa.obigbemi@arm.com.ng", false, null, null, "Ifeoluwa Obigbemi", "Investment Management", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("6745d244-2822-4321-acd3-2ebbeeb230ef"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6325), null, "taiwo.odumuyiwa@arm.com.ng", false, null, null, "Taiwo Odumuyiwa", "Customer Service", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("6785d163-396a-4634-be69-f0f54bcbe24d"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6284), null, "simisola.famous-cole@arm.com.ng", false, null, null, "Simisola Famous-Cole", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("67c6b1c8-9ca4-469d-97bd-a4059218cc52"), "Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6369), null, "ifeoma.ofili@arm.com.ng", false, null, null, "Ifeoma Ofili", "Treasury", new Guid("f39cf3fc-5069-4d4c-88e6-981b622dd805"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("6875d876-78af-4cff-8629-ad89258bc389"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6276), null, "oluwabunmi.ayeni@arm.com.ng", false, null, null, "Oluwabunmi Ayeni", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("68de245b-11ea-4ad6-913d-0d25401f0748"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6265), null, "busola.alakija@arm.com.ng", false, null, null, "Busola Alakija", "Settlement", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("696e75fd-cf5a-4a84-9456-fc3b98e616fa"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6327), null, "evelyn.nwogu@arm.com.ng", false, null, null, "Evelyn Nwogu", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("6c988864-7f3d-4e91-af3b-d2cb43412ea7"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6250), null, "ifeoluwa.obigbemi@arm.com.ng", false, null, null, "Ifeoluwani Obigbemi", "IMUnit", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("6d3dceb9-dca7-4c8d-8759-8c03fb1a3915"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6316), null, "moyosore.ibitoye@arm.com.ng", false, null, null, "Moyosore Ibitoye", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("6ed6769a-79a6-483c-bd50-c76ed0fcf1e8"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6348), null, "bimbo.moses@arm.com.ng", false, null, null, "Bimbo Moses", "Operation Settlements", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("703ed29c-57a6-4460-ae2a-b30245024080"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6230), null, "babatunde.osho@arm.com.ng", false, null, null, "Babatunde Osho", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("740520b4-866c-4fc7-bf94-5cd9404d2086"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6241), null, "oluseyi.omoleye@arm.com.ng", false, null, null, "Oluseyi Omoleye", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("761d0be5-44af-4ab5-a85d-638d9aa95de8"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6279), null, "busola.akerele@arm.com.ng", false, null, null, "Busola Akerele", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("76752354-3b3e-4c7d-8847-96e4a458d2a9"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6260), null, "ifeoluwa.okunoye@arm.com.ng", false, null, null, "Ifeoluwani Okunoye", "Register", new Guid("07455948-f63a-4d6b-b88f-9b1038b89ccf"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("78b472be-2740-4c99-998a-589e15b70ce7"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6352), null, "oyenike.oluwa@arm.com.ng", false, null, null, "Oyenike Oluwa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("810a8799-9b5a-4aad-bda1-632f9efd13e0"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6340), null, "opeyemi.babasola@arm.com.ng", false, null, null, "Opeyemi Babasola", "Securities", new Guid("393f2a41-0ae5-487d-9b67-224cd145f5fb"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("82659b85-188d-4a01-b301-a404fb25f002"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6247), null, "kevian.kevin@arm.com.ng", false, null, null, "Kevian Kevin", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("85d28667-0232-4f6b-a1d1-7aa7ffb4c741"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6362), null, "chioma.opara@arm.com.ng", false, null, null, "Chioma Opara", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("882145f3-9688-4fc5-b821-8062381ba2e3"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6281), null, "inemesit.anani@arm.com.ng", false, null, null, "Inemesit Anani", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("89f7ecb8-071a-459a-848c-1babb1a3da74"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6273), null, "victoria.makama@arm.com.ng", false, null, null, "Victoria Makama", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("8a0c4869-0a6c-4af2-b7b7-ee9496e3f558"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6344), null, "olufisayo.bassey@arm.com.ng", false, null, null, "Olufisayo Bassey", "Investment Management", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("8fda017a-4586-41db-a70a-54ae089bcfa5"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6244), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("8ff52401-4911-4778-b4fd-605491e4cc39"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6366), null, "oluwatosin.oluyemi@arm.com.ng", false, null, null, "Oluwatosin Oluyemi", "Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("917b5b8a-5585-495b-bf2c-d6ecb1a15be0"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6248), null, "ibrahim.owolabi@arm.com.ng", false, null, null, "Ibrahim Owolabi", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("96463152-4ac1-4533-8017-61cc74bb8de4"), "ARM Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6329), null, "enoma.osazee@arm.com.ng", false, null, null, "Enoma Osazee", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("97721067-61cd-4dcf-90cc-6e67dd840ce2"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6339), null, "ayomide.ojeniyi@arm.com.ng", false, null, null, "Ayomide Ojeniyi", "Securities", new Guid("393f2a41-0ae5-487d-9b67-224cd145f5fb"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("9ad0b155-209e-450e-89ac-91dad70a61a0"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6337), null, "elizabeth.alloy@arm.com.ng", false, null, null, "Elizabeth Alloy", "Financial Control", new Guid("451c2ef5-4298-4697-af78-5e328e18ef31"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("9daa8f01-8756-42fb-a264-3bc1c00cd503"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6318), null, "victoria.chukwu@arm.com.ng", false, null, null, "Victoria Chukwu", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("a4694977-da72-4c91-9407-b0140625d24e"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6360), null, "augustina.osagie@arm.com.ng", false, null, null, "Augustina Osagie", "Operation Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("a4f9f04a-105a-4d96-af70-8c4a7b641a19"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6297), null, "esther.onumaegbu@arm.com.ng", false, null, null, "Esther Onumaegbu", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("a576f03a-15bb-4268-b5b8-dc9d947cb15e"), "ARM Trustees", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6367), null, "folarinde.ayenuwa@arm.com.ng", false, null, null, "Folarinde Ayenuwa", "Private Trust", new Guid("78c8f28f-f245-4e6c-bd59-dddd06ce248c"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("a8171906-f4e2-4256-af4b-1e6c47e8b418"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6293), null, "shulammite.wokwereze@arm.com.ng", false, null, null, "Shulammite Wokwereze", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("aad09014-acef-45bd-9153-08f7b9b5ba74"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6300), null, "faith.ojo@arm.com.ng", false, null, null, "Faith Ojo", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("b1969a2e-39c0-4104-a78b-c54304c28b49"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6254), null, "thompson.shedara@arm.com.ng", false, null, null, "Thompson Shedara", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("b31ae1d7-3f51-4c90-ae29-7a47c8bea919"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6252), null, "aminat.ashafa@arm.com.ng", false, null, null, "Aminat Ashafa", "Retail Operations", new Guid("ab0802de-a04a-4e10-90d4-3ec2cfdf2b0a"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("b8be23c0-f571-4aba-b84d-c9fb001ed78c"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6228), null, "gift.aizebeoje@arm.com.ng", false, null, null, "Gift Aizebeoje", "Operations Settlement", new Guid("edbd535a-f4b9-4867-99ba-4d49ee6f8293"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("bd2ba5c5-36a1-4092-aed7-9fac93b993e4"), "ARM Shared Services", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6330), null, "oluwatosin.adeboyejo@arm.com.ng", false, null, null, "Oluwatosin Adeboyejo", "Financial Control", new Guid("a89fca23-939c-45d4-adcd-540e94a47eec"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("bf01e0c6-3693-4614-b168-f05a3452d80a"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6373), null, "oluwakemi.onipede@arm.com.ng", false, null, null, "Oluwakemi Onipede", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("c0291438-ad32-45c8-ae33-c4c019f0ae74"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6343), null, "ilerioluwa.akinosun@arm.com.ng", false, null, null, "Ilerioluwa Akinosun", "Securities", new Guid("393f2a41-0ae5-487d-9b67-224cd145f5fb"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("c322ae53-52b9-45d0-9b02-6015f1d21022"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6278), null, "eno.udoh@arm.com.ng", false, null, null, "Eno Udoh", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("c43fe27e-eb2d-41a1-81d1-cf47949ee517"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6374), null, "victoria.itrechio@arm.com.ng", false, null, null, "Victoria Itrechio", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("c6e9c970-23b1-4159-a8f4-db45b2bfa82f"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6354), null, "oladupe.dare@arm.com.ng", false, null, null, "Oladupe Dare", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("d3f969d2-6354-4b65-b72b-2bd773215a21"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6332), null, "amaka.nnotum@arm.com.ng", false, null, null, "Amaka Nnotum", "Financial Control", new Guid("fb274136-84fe-430d-bab9-6647909a1a48"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("dfe566dd-869c-45bb-ac34-ec7eb6035689"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6323), null, "adaeze.ukah@arm.com.ng", false, null, null, "Adaeze Ukah", "Customer Experience", new Guid("4e79a246-e60a-47eb-92af-ace48b36b5c5"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("e0055c55-2e1a-40f7-b06a-a4774889ffd5"), "ARM HoldCo", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6257), null, "kevian.kevin@arm.com.ng", false, null, null, "Kevian Kevin", "Treasury", new Guid("d638462f-bde3-4555-889b-2af892201b07"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("e39cbf62-0c3d-4cca-b644-d4fa03df451b"), "ARM Securities", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6341), null, "lawrence.olusina@arm.com.ng", false, null, null, "Lawrence Olusina", "Securities", new Guid("393f2a41-0ae5-487d-9b67-224cd145f5fb"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("e4d96c48-29bf-42c3-83b5-23a525061e01"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6326), null, "temitope.akinola@arm.com.ng", false, null, null, "Temitope Akinola", "Financial Control", new Guid("dc1638be-a2ea-4eec-9616-0a8feee5ae76"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("e785e91f-f676-4bc0-900b-3ba6afae109b"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6245), null, "hassan.balogun@arm.com.ng", false, null, null, "Hassan Balogun", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("e9dd2a9b-55c5-498a-82f0-23a0f5e3c5e6"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6243), null, "thompson.shedara@arm.com.ng", false, null, null, "Thompson Shedara", "Fund Admin", new Guid("2a9a1019-aaf4-493e-bb1e-16324b8b0e04"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("eb067139-0777-49db-adc4-dff4c8f4b584"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6301), null, "veronica.oluigbo@arm.com.ng", false, null, null, "Veronica Oluigbo", "Customer Experience", new Guid("c8153bcc-3c1c-4a28-98a5-0230194396d7"), new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4") },
                    { new Guid("eeb16d3e-c885-4c62-8a65-238474cc2402"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6349), null, "bridget.odubela@arm.com.ng", false, null, null, "Bridget Odubela", "Registrars", new Guid("482b69b1-3bb8-4caa-969f-ca8c74986b12"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("f3d33ce3-9f73-40f0-a71d-34c7151f8512"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6262), null, "rosemary.francis@arm.com.ng", false, null, null, "Rosemary Francis", "Settlement", new Guid("4082fe29-5966-476e-951f-c44e306ca50f"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                    { new Guid("f6d4a646-e60f-4106-b690-53a2630284c7"), "ARM IM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2025, 2, 17, 5, 21, 44, 183, DateTimeKind.Utc).AddTicks(6255), null, "oluwatobi.oyebiyi@arm.com.ng", false, null, null, "Oluwatobi Oyebiyi", "Fund Account", new Guid("57019e9f-390a-47a5-b7ec-1c9da2fd8111"), new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6") },
                });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("014923ac-7916-463e-b6e9-07722a160768"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0ad59504-1fab-43b8-91f3-877c354925de"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0d05d981-e9f3-41ea-a637-6b84e36fb8dd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0e8f7bbe-cab2-4328-9ccf-7d5547c0adac"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0ff49eb5-c520-4d2d-932d-476b17132120"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0fffd1c8-7478-41df-87aa-a706106f19a3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10e17a75-073a-4134-af55-05e2434f37be"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1758e6e0-c9cd-439f-b52a-a2d87126deee"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("01266a7a-a9f7-4cbd-99af-33c85133891a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("016e3278-8494-4660-8072-56a086f6868b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("02eebe72-b966-438a-a05e-db130b447a43"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("03e719e7-5d1f-45d8-8f84-254b89e5bc7f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("044e8fd1-d188-4b2d-b9c7-7d8ebee1a57c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("04b5ba4d-48b0-4140-9338-2110e2e2251b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("05ad879c-3a66-44bd-9f85-0b6bb8fbf3a3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("05f6cfb5-af3f-4d26-a8f5-598499a62a49"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0790c217-80ab-453b-a56a-bb30ed4ef07e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("07db3a82-a5f0-4ec7-9573-6c655a90f721"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0a03a137-1c29-4049-a7c5-0e5d6c9f5f38"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11750ebc-8133-41ff-9669-130c447728e9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13682527-e3e8-4c98-b60f-87fb4234e9c9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13fda755-e773-4a90-a91e-33baa70a5773"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("145b5be4-bd9a-47bd-8a0e-e96f18e8047b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15c91090-fd32-4e46-a5ae-9821da25bc79"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("176d1de4-3e41-4087-8f9c-c17a3da51408"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("184af40f-9cd0-4588-99cf-a443a4d4c999"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19c42c62-6cca-434c-88c3-7b7c00b67a29"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1c5bcc5a-cb39-4edc-9052-5aa2496bdeba"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1cc35f37-d44e-45e2-8f3b-3819d939ee20"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1d471741-2c67-4f5f-921d-e4a2f22422fe"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1d7bde8b-4590-45af-bae7-b3ee37e7348a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1de0e499-b926-4daa-b968-42e2a1827e03"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1e5d2a31-d2a4-4bec-8a29-9be7f402b8fa"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1f7f21fc-2f3a-4d0c-b2fc-67881a8a537f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("20a16490-de03-4496-9d42-421acd49511e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("20e58a50-51f6-4118-adc9-1c190a00f7da"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("21c91b5e-b97f-4cce-8656-3fd0df949250"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("22079bf9-4b12-4b14-a1ea-73bc539a1fce"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("248b5990-2842-4f5c-94a2-4663be63585a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("27766613-22c5-4edf-89f5-2f0bfc8a792e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28675456-8399-4e70-8e89-1147af6ce037"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("29525504-1c12-4583-93c3-f22f42a3afa5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2c759766-ed42-4a26-8603-0b28605964a6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2e1ffd11-5fc2-4759-82bc-9ed8f1252772"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2e22cbfb-4875-4a3d-b66a-aca4b837d753"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2e89bea8-56b5-44cc-90c2-1f7c8dc0db0a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2e9fd6d4-0eff-4361-abaf-e49835a66a27"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2f7ac717-3c28-45be-9a92-e8b7506c3f02"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2f9e8d29-ef17-4649-bdee-82ec1190a86e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("303dba43-7341-4ff5-af88-1231b7d3c3e2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("308de6f9-48bf-4299-887e-930fe9cfee5f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("30bc4056-8d3b-49e5-b5c9-6e32fc33a661"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31af6308-577e-4d93-92e1-f9bc74951497"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("343e0e59-fe30-4058-acdc-350c6a690c8c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("344d1d95-b0a8-4512-99e3-260bc6636cef"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("36532745-082c-473c-807b-6cb2848616fc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3668a48f-aca4-4fe5-a72a-83bab65df3df"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3a786022-7ab6-43a5-8fbb-d4048784f917"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3c3e8e4b-77d8-47d1-a720-1f129df0be53"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3c6b3320-5cb4-492a-bebf-2efa46384ad8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3c82e81b-678d-452f-a1f6-7ca5e1098fda"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3ee99914-23ea-4ee8-a144-ea542d336f81"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3fbe6ace-9fea-4e00-a8c5-ef5835ee7d19"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("409dbc12-05fd-4ebd-8fac-6fb4f505af35"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("40c4a121-ba4a-4a72-a2a5-2ec0bef26f0c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("417a5f65-5462-4201-a48c-ecb9aa5eb146"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("42022a8e-e086-43c7-9341-9638dc7d2bbd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("461e9897-efbb-4117-9685-3b890c2875c1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4a231a4e-ff2d-4d54-93d9-758cbcf48eed"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4c49cec5-a728-46d6-b7af-3780b3863930"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4c4bb868-3b14-4d0e-a7cd-02a7212367a6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4f523578-1326-42c7-8952-73d05c558b9f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("50035636-56c9-43d9-bda3-bcac96ad007f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("518ecdee-625d-4f9a-9e9e-bb757e16c471"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("54724c35-372f-483b-8a22-c6b4a3a54bd7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("54cdd0d7-845d-46d3-9eb7-faa47a0c08ea"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("56a098f1-7b4c-4c96-8869-4fb2cf8196e8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("596617ed-f589-4b49-b618-ef9f89ab4641"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("59f32602-f995-4b38-9424-d78b61021789"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5de49b9c-b76b-4195-8e6d-28dd61d00510"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5e81191e-b2a0-4ab0-92b3-18396d2df737"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5ea73b40-65b3-4616-afa8-369f6f163d48"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5eb3c14c-92ef-410a-9eb3-8bbc2f06bea0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("60222896-36a9-46e6-b599-381ebae6c62c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("61a8478f-2f1a-4260-8463-043a9c0173d2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("61e85c67-d555-462c-8697-3297f1dc695c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("653630d4-4062-4787-afb2-c3fc12199c7c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("65370b4a-0e96-448d-b2f6-afe0012d669c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("65a331f3-831b-474a-a391-ebabe3120bb2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("66b3b8c8-8d83-48e5-af42-924ad635b87c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("66c0b98a-7b5e-4e22-986e-d7f38ab06773"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6737a5e0-8209-4ab9-b9f4-bd92a55761c7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6745d244-2822-4321-acd3-2ebbeeb230ef"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6785d163-396a-4634-be69-f0f54bcbe24d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("67c6b1c8-9ca4-469d-97bd-a4059218cc52"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6837d98f-f283-4014-801e-40dec51135f7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6875d876-78af-4cff-8629-ad89258bc389"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68de245b-11ea-4ad6-913d-0d25401f0748"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("696e75fd-cf5a-4a84-9456-fc3b98e616fa"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6c988864-7f3d-4e91-af3b-d2cb43412ea7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6cbe5431-b16f-4d1e-b97e-e8e5f6530682"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6ce2c183-d7c7-45fe-99bf-bb81723acdd2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6d3dceb9-dca7-4c8d-8759-8c03fb1a3915"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6dff7dfb-b289-4931-9075-ce79257525ef"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6ed6769a-79a6-483c-bd50-c76ed0fcf1e8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6ffceef6-00fb-45d7-bf71-3c558f455108"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("703ed29c-57a6-4460-ae2a-b30245024080"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("70621c35-f6ac-48ed-82ab-f5324aa238e9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71436f0a-e20d-47bd-8663-ba52d39491cb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("72092a63-da0a-4393-8031-82c74550f14c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("72da5a8c-2e9f-41d5-b84e-dbd8ba37f685"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("740520b4-866c-4fc7-bf94-5cd9404d2086"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("74eb3b7f-5b17-42ac-85d3-16f4563c5b96"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("761d0be5-44af-4ab5-a85d-638d9aa95de8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("76752354-3b3e-4c7d-8847-96e4a458d2a9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("76aa4df5-4d15-48b9-aa81-7c59d852c217"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("774f9160-6468-4161-9975-792985246082"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7868d1a1-5b22-4318-b940-0b2489f928ea"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("78b472be-2740-4c99-998a-589e15b70ce7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7e6a7c90-e395-4a67-9102-7c8f1668bdfb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7ff2b41f-dfc8-4cac-83c1-29e725ae144f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8006e4e9-fdc4-4ec1-acc4-128ca6861251"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("801a3f9a-178b-4b27-9315-303541a9f7df"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8042a5e1-ec4f-4840-a6b8-b19174db0f7a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("810a8799-9b5a-4aad-bda1-632f9efd13e0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("82659b85-188d-4a01-b301-a404fb25f002"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8300232b-2288-4b5a-aaba-3500050a4e96"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("85d28667-0232-4f6b-a1d1-7aa7ffb4c741"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("882145f3-9688-4fc5-b821-8062381ba2e3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("89f7ecb8-071a-459a-848c-1babb1a3da74"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a0c4869-0a6c-4af2-b7b7-ee9496e3f558"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a67330b-ce4c-462c-84b7-4e51200a8436"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8df1dc56-131e-4abf-9315-371242969d5e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8e7f10ca-2dfe-463a-8167-016fcac4e528"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8fda017a-4586-41db-a70a-54ae089bcfa5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8ff52401-4911-4778-b4fd-605491e4cc39"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("917b5b8a-5585-495b-bf2c-d6ecb1a15be0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9395b72d-b195-40e3-8aff-f83eceb369d0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9485c069-8c6f-4500-820e-7b2b19c8d4c4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("948e65f9-a0b5-47af-a788-357024cbd2d7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9492fcdd-02fa-4dae-964d-91b98fc13fea"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("96463152-4ac1-4533-8017-61cc74bb8de4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("97721067-61cd-4dcf-90cc-6e67dd840ce2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("99f9f29f-933f-45df-9ebc-7a622eb45a2b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a04986b-43eb-4538-a465-f899fd85ef03"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a491804-cf23-4517-bf9e-866cee3b5d1f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9ad0b155-209e-450e-89ac-91dad70a61a0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9b724de8-f04f-4ec9-ba45-c93da0929fa3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9cf7a8bc-902f-4d7b-a1e2-ad411a11a8ac"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9d792a23-2ba1-4009-ac32-2651740cf599"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9daa8f01-8756-42fb-a264-3bc1c00cd503"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9dbd0aa6-0f1e-42ad-8034-cd01b272fc18"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9e83ff4e-ef36-425c-ba21-b8e1a05fcf44"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a196a36b-74fb-44bd-a1a9-ba37ab539066"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a288bef4-8905-4300-a0e2-1d14000e68f3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a28c7408-0ba2-4f58-b615-27516694253c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a2ee2ff5-9d29-46df-a78c-000910e93f0e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a39623fc-4636-4e29-b502-5394c69d9065"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a4694977-da72-4c91-9407-b0140625d24e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a4c9a2bf-6a5d-47aa-bc40-f674bc3b435d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a4f9f04a-105a-4d96-af70-8c4a7b641a19"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a576f03a-15bb-4268-b5b8-dc9d947cb15e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a675363b-5e8e-4306-9756-224f544ecc7f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a8171906-f4e2-4256-af4b-1e6c47e8b418"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("aad09014-acef-45bd-9153-08f7b9b5ba74"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("abb05532-2b39-4318-8275-5c69fe4b869a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("aca91f4f-104f-47d8-bc63-b2692c387d69"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ae6e8ef5-7495-4410-a513-4c59c5b5c13b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b0f831c7-692e-42ba-88c7-b6d2398fc9d5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b18226b0-0583-4305-a64a-2625b24904ff"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b1969a2e-39c0-4104-a78b-c54304c28b49"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b1cb9b8a-fbb8-4f06-bf7d-0228d5258e32"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b31ae1d7-3f51-4c90-ae29-7a47c8bea919"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b58d798a-0d0f-470a-9686-f35b25bfb9ec"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b813d010-c10f-4b5d-8e0b-e32651cedbfd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b88df9f2-716d-47eb-8966-062ef5b64bd7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b8be23c0-f571-4aba-b84d-c9fb001ed78c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b8ea9329-956e-417d-973f-64b40b90fc4c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ba88f8c9-dd0f-4e34-8bef-4e8eb31f2e21"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bb442cdb-f672-49eb-8523-85b16d2cc2b2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bd2ba5c5-36a1-4092-aed7-9fac93b993e4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bd701cb8-2c4f-4fec-af95-f00801deed12"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bdb23732-588f-4dc7-8c7d-b575edb715bf"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bebe0eeb-4717-45ed-9ae0-4d8e183ae0e9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bf01e0c6-3693-4614-b168-f05a3452d80a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c0291438-ad32-45c8-ae33-c4c019f0ae74"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c0e1a73f-92d0-42b9-984a-2c19c155c1ec"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c0f23a64-2a64-4789-b664-2cfa913666a2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c11eed80-793c-4c9c-87d4-e60c9be1e089"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c2daa5d0-4794-4bbd-81f2-a27571f38f03"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c322ae53-52b9-45d0-9b02-6015f1d21022"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c32a9d66-e612-4711-89bd-e871c774e8e9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c43fe27e-eb2d-41a1-81d1-cf47949ee517"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c4871c96-5d0c-465a-ae26-91fd0eb4c17b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c6e9c970-23b1-4159-a8f4-db45b2bfa82f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c78bffe2-8047-4761-892e-47eeea478e8b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c85fcae9-7d3a-4a10-a758-cf32cc165a67"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c87f3eac-0704-4184-a1f0-551f99c7c5cd"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c887238d-6ffb-496e-a8ed-513bee0f4614"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c8a3923f-46c6-49f4-97cf-e41c5c1e5610"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c9e2b00b-7220-42fd-8a2d-4d6c74400c5c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ca56f0b0-184e-4976-b5b7-f11a74703605"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cb018346-a152-421d-aabb-7af5ecc834ba"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cb22b11b-c581-41f0-873d-24b33a7171bb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cd9f6890-9a74-49dc-9e2e-71d5b18c4546"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce709a46-990c-4ae5-87ec-c225629a02eb"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cfff8aa2-2484-4e4d-81ab-db94b019aca3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d0897546-946d-4f81-a0a6-19965c45cee8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d09d7e95-2fb6-458c-84bc-d6feca212387"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d2384bb0-720d-41d3-8494-4d9cccd08258"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d280d028-740c-4a2a-ac20-d6683e130a8d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d3f969d2-6354-4b65-b72b-2bd773215a21"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d4833f05-7ae8-454b-8426-fe9a8ca56eb7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d93536c5-d9c4-4dfc-b680-84936f4996a9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d9d11873-44be-4408-b3d2-e06d429d3019"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("dab97cb6-3dfc-426d-98fb-27c31891df6c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("dc2795e6-e9f0-4c61-9870-a22c01834e86"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("df0f6c17-b7b0-468a-8104-182dec75fc24"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("df6e6595-8c07-429b-9768-2a1c234d4913"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("dfe566dd-869c-45bb-ac34-ec7eb6035689"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e0055c55-2e1a-40f7-b06a-a4774889ffd5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e39cbf62-0c3d-4cca-b644-d4fa03df451b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e3e09600-fbe3-4e2d-b09e-3d6250c4bbee"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e4d96c48-29bf-42c3-83b5-23a525061e01"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e729980a-4d53-4801-8b22-6331c838d9d0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e785e91f-f676-4bc0-900b-3ba6afae109b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e9359b61-3c6c-4fe2-9d0a-4ff780b1f9dc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e995ac27-d035-4f1e-acc7-1465f263314a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e9dd2a9b-55c5-498a-82f0-23a0f5e3c5e6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eb067139-0777-49db-adc4-dff4c8f4b584"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eb695dda-0ac4-4282-93f5-026e249773b2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ee58d43d-fc13-482b-9001-64d418c2eb24"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("eeb16d3e-c885-4c62-8a65-238474cc2402"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("efd9c894-a3e2-4d2f-9a8d-dc60e0f2342c"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f041993c-24db-4af1-b76e-2e20334bbd48"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f3d33ce3-9f73-40f0-a71d-34c7151f8512"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f3ec9649-2675-4991-985c-61d503d1bfae"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f6d4a646-e60f-4106-b690-53a2630284c7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f6dc333d-7239-49c8-b23e-dcace8e70a13"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f809e7ab-e69e-488c-a041-fc6a2598ec58"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f81a5992-6381-40d5-b092-774c02789c84"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fa2bca3c-d374-4661-9be8-004c3bdd3124"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fa6636db-a3dc-4eb8-a0c7-c10b45f78e61"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fb35590e-4853-4880-a1c2-6062413fa45e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fc01d26a-0b44-4999-b1d4-0ac911067104"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fcfe7f3d-cef7-4f6b-ad80-c628d56bcd0a"));

            migrationBuilder.UpdateData(
                 table: "User",
                 keyColumn: "Id",
                 keyValue: new Guid("2e1e45de-8f69-4b7a-8a52-924c6c08e9ae"),
                 column: "Unit",
                 value: "Customer Service");

            migrationBuilder.UpdateData(
                 table: "User",
                 keyColumn: "Id",
                 keyValue: new Guid("038ec42b-a09a-462f-beb4-35658993d174"),
                 column: "Unit",
                 value: "Customer Service");

            migrationBuilder.UpdateData(
                 table: "User",
                 keyColumn: "Id",
                 keyValue: new Guid("ffd3a51e-3f36-455e-9c22-117e6adae361"),
                 column: "Unit",
                 value: "Customer Service");
        }
    }
}
