using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrcApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserandRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "UserRoleMap",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00670a0d-dbb5-4b9d-b7c1-ec77ced4f63b") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00fecf89-bb70-4e62-a76b-cd1794d6a21f") },
                    { new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("04a192db-f039-49c7-bbc9-f7d7b4085ecd") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("04a192db-f039-49c7-bbc9-f7d7b4085ecd") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("0668bb60-8c7a-4392-9a92-d1ec04924a48") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("068e132d-97ae-4ebe-88a1-2787c944be70") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("068e132d-97ae-4ebe-88a1-2787c944be70") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("0b0fdcae-d8af-4505-88b4-88e42f5e43ab") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("0b0fdcae-d8af-4505-88b4-88e42f5e43ab") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("0c0245d8-95bd-4c59-8518-2e6ec44685fc") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("0c093023-fb37-4f46-ada0-849afaae7f99") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("15e02e42-4ad1-4f38-b074-10c9cdac4767") },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("15e02e42-4ad1-4f38-b074-10c9cdac4767") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("15e02e42-4ad1-4f38-b074-10c9cdac4767") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("16473b29-42ad-4763-b1ef-11f0e02b3bca") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("18d63e3e-1940-4f80-8c69-29bcc9392b80") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("1f3a321c-a151-400b-a619-dcebde93c73f") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("219903d2-54d5-42e2-9916-1bd7420e1cc1") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("3720bdd2-8bf3-4f07-80e1-89e087e7347d") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("39eab3e1-ec3c-4e46-b220-72f24a1a9b6a") },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a") },
                    { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("3d1dd8c9-46df-47d6-bfe5-e6707937301c") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("3fc9a856-df88-4bc8-88b1-cf4b65f3928d") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("404f4298-bfca-4709-b9d4-652509d7f604") },
                    { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("414dc8d2-233b-443f-b7da-181aa1cadb3f") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("414dc8d2-233b-443f-b7da-181aa1cadb3f") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("453e760b-1dee-4706-b2ea-f06826f46bac") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("4ed59e86-27c2-4270-bc10-060676cec0a0") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("5074d70a-7471-46a7-8064-605b9710ac74") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("5074d70a-7471-46a7-8064-605b9710ac74") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("5074d70a-7471-46a7-8064-605b9710ac74") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("517580ef-82c5-43eb-aeb7-2a82eb2e8546") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("53cc8c36-4366-45cc-b329-8d42b48ff515") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("53cc8c36-4366-45cc-b329-8d42b48ff515") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("53d973cc-d395-4789-8b8f-f394b2dd0b2f") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("5438428c-8c2b-48bd-b1d1-2382c488ca9a") },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5438428c-8c2b-48bd-b1d1-2382c488ca9a") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("5438428c-8c2b-48bd-b1d1-2382c488ca9a") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("57c976a7-a9e0-4f31-bec1-99d5d290996e") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("57c976a7-a9e0-4f31-bec1-99d5d290996e") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("57cda194-4fae-482d-a09f-43c397d373d1") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("59a83afc-7720-4f57-bbea-80d8358f9b0d") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("5e902748-0188-405d-8a9b-cb3e22098d1b") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("5e902748-0188-405d-8a9b-cb3e22098d1b") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("6209fd2d-95d0-4927-9ada-460ecd424e54") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("62db3f26-b6bd-4a06-9a89-dc93c249c73d") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("62db3f26-b6bd-4a06-9a89-dc93c249c73d") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("663cc78c-a538-4ca0-84a3-7d182e8c2292") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("663cc78c-a538-4ca0-84a3-7d182e8c2292") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("68b49eca-2285-46d4-8449-4cf78a8a730d") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("6de1a7fc-b57e-4283-8e46-edea9631ce32") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("6de1a7fc-b57e-4283-8e46-edea9631ce32") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("703c42fa-406c-453c-b3cf-a2fb3ad354a1") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("703c42fa-406c-453c-b3cf-a2fb3ad354a1") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("73355329-e14d-4c0f-9836-ebf962a9298f") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("744e925b-6aa7-45fa-824c-0b505a04e20a") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("744e925b-6aa7-45fa-824c-0b505a04e20a") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("7b13db39-3b27-4ddf-822e-c96a0514434e") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("7e265aed-6c39-4043-92b0-28f64a9c099d") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("8024d065-906b-4708-821c-1a2eb3aacae1") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("8024d065-906b-4708-821c-1a2eb3aacae1") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("8024d065-906b-4708-821c-1a2eb3aacae1") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("82d94cb6-6e22-476b-b8a2-a6c996636c73") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("82d94cb6-6e22-476b-b8a2-a6c996636c73") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9") },
                    { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9") },
                    { new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"), new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("86de4f7d-fe4c-4a54-a0bc-a894883424c5") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("8c5d8d3e-587b-4ad7-8333-5ff668390cf3") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("8c5d8d3e-587b-4ad7-8333-5ff668390cf3") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("8e4a4569-dbae-4cec-a86b-d43bf743955e") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("9435698f-d64b-413a-b334-f476bd3ed548") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("9435698f-d64b-413a-b334-f476bd3ed548") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("984b9023-c774-4e90-a16e-3af0aad05a3c") },
                    { new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("984b9023-c774-4e90-a16e-3af0aad05a3c") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("98fc4263-5311-4a1b-8889-aaf3541781e3") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("98fc4263-5311-4a1b-8889-aaf3541781e3") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("9e27a329-52f7-4004-8a1a-090ddcac29d0") },
                    { new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("9e27a329-52f7-4004-8a1a-090ddcac29d0") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("a038cd54-b443-4779-8506-bcc586c64a7d") },
                    { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("a038cd54-b443-4779-8506-bcc586c64a7d") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("a038cd54-b443-4779-8506-bcc586c64a7d") },
                    { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("a038cd54-b443-4779-8506-bcc586c64a7d") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("a17fba1c-a1c8-47c1-b0fd-577aa740757a") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("a33da7fb-c2d8-43ea-a5af-48df82c586a7") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("a8292054-64b5-48ee-8269-81c84c18f424") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("aa8b94de-4efb-48ed-95f2-3efb1e980555") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("aa8b94de-4efb-48ed-95f2-3efb1e980555") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("ac871e3a-fb51-427a-83a3-54d3ccd726c0") },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ac871e3a-fb51-427a-83a3-54d3ccd726c0") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("b15d21ae-9e86-4380-924d-d06662ce1e0e") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("b241d596-f089-434b-a94c-16114c0a4b4b") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("b57ffb70-5d09-4349-bbad-54eecfa9fbae") },
                    { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("b57ffb70-5d09-4349-bbad-54eecfa9fbae") },
                    { new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"), new Guid("b57ffb70-5d09-4349-bbad-54eecfa9fbae") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("b64e0d40-6f17-4e47-a0be-6674b9b2ac18") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("be485a1a-1e6b-452d-a797-dd2dfe5a6902") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("c6492702-c4f5-4099-b360-be3d0f37180b") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("ce6623a1-3821-460e-88c2-e5082838840e") },
                    { new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"), new Guid("ce6623a1-3821-460e-88c2-e5082838840e") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("d700564f-1a2f-4396-8f6f-e769eb6e7af8") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("d70df12b-96fd-46b2-ba74-7898b8cf828f") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("d74a1b81-b74f-4cda-a602-c6d46c4d61e9") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("d8ed93b7-a3da-4745-ba17-486a11fe10df") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("dc3c4bd1-3d0a-4275-86a0-54d0a058b6df") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("dc3c4bd1-3d0a-4275-86a0-54d0a058b6df") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("dc3c4bd1-3d0a-4275-86a0-54d0a058b6df") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("ea045141-2b65-497c-8b97-6ca1ecd8885e") },
                    { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("eac59325-3b9c-4701-ac63-b4dc55d65872") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("eac59325-3b9c-4701-ac63-b4dc55d65872") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("ebcf8632-14fe-4c88-9684-93f01986a209") },
                    { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("ebcf8632-14fe-4c88-9684-93f01986a209") },
                    { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("eeb105a0-8b43-4528-95ef-90c4efce1ee7") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("f0a8aaf4-89ae-4a13-bb10-e6f5104646bd") },
                    { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("f19317cd-ef8b-425d-abcd-ee6f3f9bc2a8") },
                    { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("fd313524-5a4f-4667-b2f9-219b64558435") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("00670a0d-dbb5-4b9d-b7c1-ec77ced4f63b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("00fecf89-bb70-4e62-a76b-cd1794d6a21f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("45089255-78cf-43e9-b63d-94eebc2030b2"), new Guid("04a192db-f039-49c7-bbc9-f7d7b4085ecd") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("04a192db-f039-49c7-bbc9-f7d7b4085ecd") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("0668bb60-8c7a-4392-9a92-d1ec04924a48") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("068e132d-97ae-4ebe-88a1-2787c944be70") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("068e132d-97ae-4ebe-88a1-2787c944be70") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("0b0fdcae-d8af-4505-88b4-88e42f5e43ab") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("0b0fdcae-d8af-4505-88b4-88e42f5e43ab") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("0c0245d8-95bd-4c59-8518-2e6ec44685fc") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("0c093023-fb37-4f46-ada0-849afaae7f99") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("15e02e42-4ad1-4f38-b074-10c9cdac4767") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("15e02e42-4ad1-4f38-b074-10c9cdac4767") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("15e02e42-4ad1-4f38-b074-10c9cdac4767") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("16473b29-42ad-4763-b1ef-11f0e02b3bca") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("18d63e3e-1940-4f80-8c69-29bcc9392b80") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("1f3a321c-a151-400b-a619-dcebde93c73f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("219903d2-54d5-42e2-9916-1bd7420e1cc1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("3720bdd2-8bf3-4f07-80e1-89e087e7347d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("39eab3e1-ec3c-4e46-b220-72f24a1a9b6a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("3a44ee98-b7e7-4148-9ed7-07ed7d56d938") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d15ab00-f3ba-4b7f-ab78-6b0dbcfae65c"), new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("3ae3659c-c92e-4d73-aaa9-a804f8d4618a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("3d1dd8c9-46df-47d6-bfe5-e6707937301c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("3fc9a856-df88-4bc8-88b1-cf4b65f3928d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("404f4298-bfca-4709-b9d4-652509d7f604") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2056820f-51e8-43c2-80d4-512346cc813c"), new Guid("414dc8d2-233b-443f-b7da-181aa1cadb3f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("414dc8d2-233b-443f-b7da-181aa1cadb3f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("453e760b-1dee-4706-b2ea-f06826f46bac") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("4ed59e86-27c2-4270-bc10-060676cec0a0") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("5074d70a-7471-46a7-8064-605b9710ac74") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("5074d70a-7471-46a7-8064-605b9710ac74") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("5074d70a-7471-46a7-8064-605b9710ac74") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("517580ef-82c5-43eb-aeb7-2a82eb2e8546") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("53cc8c36-4366-45cc-b329-8d42b48ff515") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("53cc8c36-4366-45cc-b329-8d42b48ff515") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("53d973cc-d395-4789-8b8f-f394b2dd0b2f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("5438428c-8c2b-48bd-b1d1-2382c488ca9a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("5438428c-8c2b-48bd-b1d1-2382c488ca9a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("5438428c-8c2b-48bd-b1d1-2382c488ca9a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("57c976a7-a9e0-4f31-bec1-99d5d290996e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("57c976a7-a9e0-4f31-bec1-99d5d290996e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("57cda194-4fae-482d-a09f-43c397d373d1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("59a83afc-7720-4f57-bbea-80d8358f9b0d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("5e902748-0188-405d-8a9b-cb3e22098d1b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("5e902748-0188-405d-8a9b-cb3e22098d1b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("6209fd2d-95d0-4927-9ada-460ecd424e54") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("62db3f26-b6bd-4a06-9a89-dc93c249c73d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("62db3f26-b6bd-4a06-9a89-dc93c249c73d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("663cc78c-a538-4ca0-84a3-7d182e8c2292") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("663cc78c-a538-4ca0-84a3-7d182e8c2292") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("68b49eca-2285-46d4-8449-4cf78a8a730d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("6de1a7fc-b57e-4283-8e46-edea9631ce32") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("6de1a7fc-b57e-4283-8e46-edea9631ce32") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("703c42fa-406c-453c-b3cf-a2fb3ad354a1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("703c42fa-406c-453c-b3cf-a2fb3ad354a1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("73355329-e14d-4c0f-9836-ebf962a9298f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("744e925b-6aa7-45fa-824c-0b505a04e20a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("744e925b-6aa7-45fa-824c-0b505a04e20a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("7a9b6dd1-4514-4d19-b7ec-ca8a6d777718") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("7b13db39-3b27-4ddf-822e-c96a0514434e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("7e265aed-6c39-4043-92b0-28f64a9c099d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("8024d065-906b-4708-821c-1a2eb3aacae1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("8024d065-906b-4708-821c-1a2eb3aacae1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("8024d065-906b-4708-821c-1a2eb3aacae1") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("82d94cb6-6e22-476b-b8a2-a6c996636c73") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("82d94cb6-6e22-476b-b8a2-a6c996636c73") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"), new Guid("83647770-2777-4104-b6aa-ea4b4e558ed9") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("86de4f7d-fe4c-4a54-a0bc-a894883424c5") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("8c5d8d3e-587b-4ad7-8333-5ff668390cf3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("8c5d8d3e-587b-4ad7-8333-5ff668390cf3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("8e4a4569-dbae-4cec-a86b-d43bf743955e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("9435698f-d64b-413a-b334-f476bd3ed548") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("9435698f-d64b-413a-b334-f476bd3ed548") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("984b9023-c774-4e90-a16e-3af0aad05a3c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e8a6dd2a-a84f-4061-a772-318ff57ed62c"), new Guid("984b9023-c774-4e90-a16e-3af0aad05a3c") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("98fc4263-5311-4a1b-8889-aaf3541781e3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("98fc4263-5311-4a1b-8889-aaf3541781e3") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("9a4483a7-b80b-48c7-9de1-156d2e9972ff") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("9e27a329-52f7-4004-8a1a-090ddcac29d0") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ccf43e87-d594-459f-a4e9-f87f9f189fa8"), new Guid("9e27a329-52f7-4004-8a1a-090ddcac29d0") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("a038cd54-b443-4779-8506-bcc586c64a7d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("48ee8ecc-dc9f-4c6a-89ea-80e638a18980"), new Guid("a038cd54-b443-4779-8506-bcc586c64a7d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("a038cd54-b443-4779-8506-bcc586c64a7d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9998f0e2-81ba-4c0b-96b2-419b8040a47d"), new Guid("a038cd54-b443-4779-8506-bcc586c64a7d") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("a17fba1c-a1c8-47c1-b0fd-577aa740757a") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("a33da7fb-c2d8-43ea-a5af-48df82c586a7") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("a8292054-64b5-48ee-8269-81c84c18f424") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("aa8b94de-4efb-48ed-95f2-3efb1e980555") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("aa8b94de-4efb-48ed-95f2-3efb1e980555") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("ac871e3a-fb51-427a-83a3-54d3ccd726c0") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("ac871e3a-fb51-427a-83a3-54d3ccd726c0") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("b15d21ae-9e86-4380-924d-d06662ce1e0e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("b241d596-f089-434b-a94c-16114c0a4b4b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("b57ffb70-5d09-4349-bbad-54eecfa9fbae") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("86f372a0-24ee-4dd8-a5d1-1d45badccd8a"), new Guid("b57ffb70-5d09-4349-bbad-54eecfa9fbae") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8f71ed24-a521-48f2-b10e-d382b52a023e"), new Guid("b57ffb70-5d09-4349-bbad-54eecfa9fbae") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("b64e0d40-6f17-4e47-a0be-6674b9b2ac18") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("be485a1a-1e6b-452d-a797-dd2dfe5a6902") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("c6492702-c4f5-4099-b360-be3d0f37180b") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("ce6623a1-3821-460e-88c2-e5082838840e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e4758094-c3a9-4a80-94dd-d317d31cc4f1"), new Guid("ce6623a1-3821-460e-88c2-e5082838840e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("d700564f-1a2f-4396-8f6f-e769eb6e7af8") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("d70df12b-96fd-46b2-ba74-7898b8cf828f") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("d74a1b81-b74f-4cda-a602-c6d46c4d61e9") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("d8ed93b7-a3da-4745-ba17-486a11fe10df") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("dc3c4bd1-3d0a-4275-86a0-54d0a058b6df") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("dc3c4bd1-3d0a-4275-86a0-54d0a058b6df") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("dc3c4bd1-3d0a-4275-86a0-54d0a058b6df") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("ea045141-2b65-497c-8b97-6ca1ecd8885e") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("33e96674-c7b5-4c3c-98d8-613015a019f4"), new Guid("eac59325-3b9c-4701-ac63-b4dc55d65872") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("eac59325-3b9c-4701-ac63-b4dc55d65872") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("ebcf8632-14fe-4c88-9684-93f01986a209") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5af3368c-48c9-4aea-ba95-0f361ac82cc6"), new Guid("ebcf8632-14fe-4c88-9684-93f01986a209") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2af614d4-7a34-4393-b626-7e2580bf51d1"), new Guid("eeb105a0-8b43-4528-95ef-90c4efce1ee7") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("f0a8aaf4-89ae-4a13-bb10-e6f5104646bd") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d94774a-bd57-491a-bcec-b1e6c547bb4b"), new Guid("f19317cd-ef8b-425d-abcd-ee6f3f9bc2a8") });

            migrationBuilder.DeleteData(
                table: "UserRoleMap",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d834a22-463e-4553-a2ac-030b1a21f88b"), new Guid("fd313524-5a4f-4667-b2f9-219b64558435") });
        }
    }
}
