using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class InternalAuditUserRoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {         

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Business", "CreatedBy", "CreatedOnUtc", "DeletedBy", "Email", "IsDeleted", "ModifiedBy", "ModifiedOnUtc", "Name", "Unit", "UnitId", "UserRoleId" },
                values: new object[,]
                {
                    { new Guid("02b69850-949a-44ac-9028-cbbbbdbe22e8"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(724), null, "adebayo.fagbola@arm.com.ng", false, null, null, "Adebayo Fagbola", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("8d667eed-04db-481c-9ae0-1c7e614e4507") },
                    { new Guid("2a1b982c-6215-4391-a581-de31ba0bc504"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(729), null, "Ezekiel.solomon@arm.com.ng", false, null, null, "Ezekiel Solomon", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("8d667eed-04db-481c-9ae0-1c7e614e4507") },
                    { new Guid("c8105f69-5751-4843-bdf0-cdb91bb815b6"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(711), null, "Jumoke.ogundare@arm.com.ng", false, null, null, "Jumoke Ogundare", "ARM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("e20991e8-6233-4635-8829-4ee12bf7004d") },
                    { new Guid("df4dee28-497e-49ce-aa1c-9ce7f72d6da0"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(717), null, "Wale.odutola@arm.com.ng", false, null, null, "Wale Odutola", "ARM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("e20991e8-6233-4635-8829-4ee12bf7004d") },
                    { new Guid("1c307f5f-55d8-492c-8f24-97d8651e429c"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(656), null, "Mounir.bouba@arm.com.ng", false, null, null, "Mounir Bouba", "ARM IM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("546bf847-dc60-4cd6-b98e-2e135ca36fe7"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(661), null, "Vwede.edah@arm.com.ng", false, null, null, "Vwede Edah", "ARM Securities", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("25521cef-adf1-4812-86f4-c18ce8993d93"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(674), null, "uche.azubuike@arm.com.ng", false, null, null, "Uche Azubuike", "RFL", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("6630093a-a794-45ed-856a-8d337f1c7fce"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(695), null, "Rachel.moreoshodi@arm.com.ng", false, null, null, "Rachel Moreoshodi", "ARMHIIL", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("710e83b4-954c-47b9-932b-f0ea367cb148"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(667), null, "Moronke.bamgbala@arm.com.ng", false, null, null, "Moronke Bamgbala", "ARM Trustees", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("7320c4a5-b8b9-4b29-bf72-76f2229ac3b2"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(700), null, "Damilare.mesimo@arm.com.ng", false, null, null, "Damilare Mmesimo", "DFS", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("86e0cb44-e8cf-411f-aaed-47b2988e6326"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(689), null, "yusuf.agbolahan@arm.com.ng", false, null, null, "Yusuf Agbolahan", "Investment Banking", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("b62f76fd-0ad3-42bc-9e6c-c1a63fc89c29"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(651), null, "Kai.orga@arm.com.ng", false, null, null, "Kai Orga", "ARM IM", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("d85b78da-b179-47a7-8f5e-06484a8cd456"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(706), null, "Funmilayo.Adeyemi@arm.com.ng", false, null, null, "Funmilayo Adeyemi", "DFS", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("fca960a3-f8ad-4bf1-a3a9-870a77b2ba02"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(679), null, "Wilfird.korsaga@arm.com.ng", false, null, null, "Wilfird Korsaga", "AAFML", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980") },
                    { new Guid("3ec017c1-f178-429b-a912-2de0dea220c7"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(640), null, "Oluwabunmi.abiodunwright@arm.com.ng", false, null, null, "Oluwabunmi Abiodun-Wright", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") },                                      
                    { new Guid("92014858-0d5a-4ab3-ab1a-d86f4f065de7"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(610), null, "Babatunde.abimbola@arm.com.ng", false, null, null, "Babatunde Abimbola", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8") },
                    { new Guid("243fc519-943a-4c76-91df-0fe58843dc73"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(620), null, "adebayo.fagbola@arm.com.ng", false, null, null, "Adebayo Fagbola", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") },
                    { new Guid("c8ebdfda-0673-4253-b56a-d6afdc57dab7"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(630), null, "Maryann.kakulu@arm.com.ng", false, null, null, "Maryann Kakulu", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") },
                    { new Guid("d4661c8c-0e7e-4da7-8621-9af212f35d66"), "ARM SharedService", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2024, 11, 25, 18, 35, 49, 445, DateTimeKind.Utc).AddTicks(625), null, "Ezekiel.solomon@arm.com.ng", false, null, null, "Ezekiel Solomon", "Internal Audit", new Guid("3b8d7739-f07b-4196-89a1-fc679fc2994a"), new Guid("45089255-78cf-43e9-b63d-94eebc2030b2") },

                });


        }
              
    }
}
