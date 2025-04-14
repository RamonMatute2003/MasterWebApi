using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigrationsSecurity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("7d29e596-1473-446d-8b74-80b49673b694"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("862ff55c-3281-47c8-ac15-5711f402a5bd"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("887fb9ab-7c9f-4d8b-a3da-9b3b5bcfaf38"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("9e7690e7-8691-41b0-8a3b-76ab5cee6a57"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("a327543f-06e2-4fc7-936d-7b70378201bc"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("a68536d7-7e4c-4ccc-862d-47c6751cb42c"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("ca4fc4ae-8a1f-4eb7-822d-1357affa07f5"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("d4563293-6959-4e05-bca8-5fd6a43dadce"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("dd7e3774-7f16-4911-80cc-0cf30a155f18"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("07768234-23ee-4a80-8f55-e1fd4a32ce69"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("258270b9-1d3c-4e98-865f-cf9f229bf85e"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("330c6c8f-d180-40da-96d9-645e1cd02532"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("6035653a-c70d-45e2-8bda-39c280d5feb8"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("77a79ddd-4fed-4857-ba9f-1965b1d03a76"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("ba85ece5-b0b4-4844-83cf-88addc32164e"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("c726c8f1-a385-4e13-848a-2547c304d314"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("cf087082-d8d6-4e98-97fe-506240c8f639"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("cf098d4c-daae-4d7a-913c-0a3279d99bf2"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("dc0792af-9b93-4348-aeee-8dc68306b3dd"));

            migrationBuilder.DeleteData(
                table: "prices",
                keyColumn: "Id",
                keyValue: new Guid("59934f2e-5ed5-4282-8250-2eff23f0cdbc"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Career = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90079424-840d-4bf2-a927-a10b9b91ccac", null, "ADMIN", "ADMIN" },
                    { "b073edae-22a6-466c-9629-1873560c678b", null, "CLIENT", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("094ec9f7-717b-4faa-9add-6dc9969767e2"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2656), "Small Metal Shoes" },
                    { new Guid("19388ded-e92e-40f5-b7ea-a3d4142ac15f"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2356), "Tasty Concrete Table" },
                    { new Guid("31a21aab-908d-4087-b896-2b5b7144ae81"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2612), "Unbranded Steel Soap" },
                    { new Guid("3222b9e6-412c-4ea6-86e4-a079dbd91b6f"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2564), "Ergonomic Concrete Pants" },
                    { new Guid("666df67b-cd32-49e5-8d9d-f4cafec7d917"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2646), "Incredible Granite Mouse" },
                    { new Guid("90a22150-b541-453a-aa4d-04ca913d7a62"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2623), "Handcrafted Fresh Pizza" },
                    { new Guid("a3aab660-c4e0-4a7c-a53a-6496ea48381e"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2603), "Unbranded Granite Chicken" },
                    { new Guid("aff45fd0-1824-49df-9120-1b046829e845"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2553), "Handcrafted Granite Cheese" },
                    { new Guid("e145ffd7-a5e6-44ec-857b-72d87d1aa14b"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 1, 8, 9, 22, 29, 670, DateTimeKind.Utc).AddTicks(2636), "Fantastic Wooden Sausages" }
                });

            migrationBuilder.InsertData(
                table: "instructors",
                columns: new[] { "Id", "Grade", "LastName", "Name" },
                values: new object[,]
                {
                    { new Guid("0a72ed3c-321f-4f14-b27e-7aded4d89c67"), "Direct Mobility Manager", "Ernser", "Jamaal" },
                    { new Guid("203ac93a-a3cb-4851-aed3-558ce0e7f0e7"), "Legacy Branding Developer", "Simonis", "Abner" },
                    { new Guid("418dbe8b-9954-4634-bfaa-a2d35e78affc"), "Senior Security Associate", "Stiedemann", "Percy" },
                    { new Guid("4a5d5223-0497-4b1c-ab7a-96d7d5e79097"), "Human Accounts Liaison", "Haag", "Bernard" },
                    { new Guid("5758dc76-0a36-4305-8791-4b729c74a2e4"), "Global Markets Coordinator", "Berge", "Chanelle" },
                    { new Guid("980dd2c9-f7c0-4854-9473-9272fc1bb064"), "Senior Data Orchestrator", "Hermann", "Adam" },
                    { new Guid("a505b4ba-c744-42a1-8f77-5cae59cdc682"), "Chief Identity Architect", "Kertzmann", "Sister" },
                    { new Guid("bb8afc3d-0636-4cfd-9e43-501e60305c29"), "Global Assurance Director", "Tillman", "Clyde" },
                    { new Guid("d39325a6-68df-48f7-a1a1-aede66d00bfc"), "Global Mobility Developer", "Roberts", "Ariane" },
                    { new Guid("dea77a28-6631-4a6b-b811-9c9063ebfeb9"), "Human Assurance Manager", "O'Connell", "Justine" }
                });

            migrationBuilder.InsertData(
                table: "prices",
                columns: new[] { "Id", "CurrentPrice", "Name", "PromotionalPrice" },
                values: new object[] { new Guid("9276886a-6b8d-4107-8849-fc5eca0221e8"), 10.0m, "Precio Regular", 8.0m });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICES", "COURSE_READ", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 2, "POLICES", "COURSE_UPDATE", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 3, "POLICES", "COURSE_WRITE", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 4, "POLICES", "COURSE_DELETE", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 5, "POLICES", "INSTRUCTOR_CREATE", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 6, "POLICES", "INSTRUCTOR_READ", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 7, "POLICES", "INSTRUCTOR_UPDATE", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 8, "POLICES", "COMMENT_READ", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 9, "POLICES", "COMMENT_DELETE", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 10, "POLICES", "COMMENT_CREATE", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 11, "POLICES", "COURSE_READ", "b073edae-22a6-466c-9629-1873560c678b" },
                    { 12, "POLICES", "INSTRUCTOR_READ", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 13, "POLICES", "COMMENT_READ", "90079424-840d-4bf2-a927-a10b9b91ccac" },
                    { 14, "POLICES", "COMMENT_CREATE", "90079424-840d-4bf2-a927-a10b9b91ccac" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("094ec9f7-717b-4faa-9add-6dc9969767e2"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("19388ded-e92e-40f5-b7ea-a3d4142ac15f"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("31a21aab-908d-4087-b896-2b5b7144ae81"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("3222b9e6-412c-4ea6-86e4-a079dbd91b6f"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("666df67b-cd32-49e5-8d9d-f4cafec7d917"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("90a22150-b541-453a-aa4d-04ca913d7a62"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("a3aab660-c4e0-4a7c-a53a-6496ea48381e"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("aff45fd0-1824-49df-9120-1b046829e845"));

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "Id",
                keyValue: new Guid("e145ffd7-a5e6-44ec-857b-72d87d1aa14b"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("0a72ed3c-321f-4f14-b27e-7aded4d89c67"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("203ac93a-a3cb-4851-aed3-558ce0e7f0e7"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("418dbe8b-9954-4634-bfaa-a2d35e78affc"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("4a5d5223-0497-4b1c-ab7a-96d7d5e79097"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("5758dc76-0a36-4305-8791-4b729c74a2e4"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("980dd2c9-f7c0-4854-9473-9272fc1bb064"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("a505b4ba-c744-42a1-8f77-5cae59cdc682"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("bb8afc3d-0636-4cfd-9e43-501e60305c29"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("d39325a6-68df-48f7-a1a1-aede66d00bfc"));

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: new Guid("dea77a28-6631-4a6b-b811-9c9063ebfeb9"));

            migrationBuilder.DeleteData(
                table: "prices",
                keyColumn: "Id",
                keyValue: new Guid("9276886a-6b8d-4107-8849-fc5eca0221e8"));

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("7d29e596-1473-446d-8b74-80b49673b694"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3630), "Small Soft Mouse" },
                    { new Guid("862ff55c-3281-47c8-ac15-5711f402a5bd"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3621), "Handmade Steel Salad" },
                    { new Guid("887fb9ab-7c9f-4d8b-a3da-9b3b5bcfaf38"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3582), "Intelligent Steel Shirt" },
                    { new Guid("9e7690e7-8691-41b0-8a3b-76ab5cee6a57"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3612), "Sleek Concrete Bacon" },
                    { new Guid("a327543f-06e2-4fc7-936d-7b70378201bc"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3601), "Intelligent Fresh Keyboard" },
                    { new Guid("a68536d7-7e4c-4ccc-862d-47c6751cb42c"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3509), "Licensed Fresh Fish" },
                    { new Guid("ca4fc4ae-8a1f-4eb7-822d-1357affa07f5"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3531), "Licensed Granite Shoes" },
                    { new Guid("d4563293-6959-4e05-bca8-5fd6a43dadce"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3523), "Refined Granite Mouse" },
                    { new Guid("dd7e3774-7f16-4911-80cc-0cf30a155f18"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 1, 6, 20, 13, 2, 904, DateTimeKind.Utc).AddTicks(3298), "Awesome Cotton Keyboard" }
                });

            migrationBuilder.InsertData(
                table: "instructors",
                columns: new[] { "Id", "Grade", "LastName", "Name" },
                values: new object[,]
                {
                    { new Guid("07768234-23ee-4a80-8f55-e1fd4a32ce69"), "Forward Usability Representative", "Spinka", "Shane" },
                    { new Guid("258270b9-1d3c-4e98-865f-cf9f229bf85e"), "Direct Marketing Manager", "Gulgowski", "Dora" },
                    { new Guid("330c6c8f-d180-40da-96d9-645e1cd02532"), "Future Directives Consultant", "Muller", "Ursula" },
                    { new Guid("6035653a-c70d-45e2-8bda-39c280d5feb8"), "Future Intranet Officer", "Pollich", "Isaac" },
                    { new Guid("77a79ddd-4fed-4857-ba9f-1965b1d03a76"), "Central Accountability Administrator", "Grant", "Gabe" },
                    { new Guid("ba85ece5-b0b4-4844-83cf-88addc32164e"), "Forward Security Producer", "Emard", "Juwan" },
                    { new Guid("c726c8f1-a385-4e13-848a-2547c304d314"), "Investor Research Producer", "Homenick", "Mallie" },
                    { new Guid("cf087082-d8d6-4e98-97fe-506240c8f639"), "Regional Creative Specialist", "Osinski", "Casimir" },
                    { new Guid("cf098d4c-daae-4d7a-913c-0a3279d99bf2"), "Dynamic Implementation Manager", "O'Connell", "Reanna" },
                    { new Guid("dc0792af-9b93-4348-aeee-8dc68306b3dd"), "Dynamic Operations Developer", "Pfannerstill", "Laurence" }
                });

            migrationBuilder.InsertData(
                table: "prices",
                columns: new[] { "Id", "CurrentPrice", "Name", "PromotionalPrice" },
                values: new object[] { new Guid("59934f2e-5ed5-4282-8250-2eff23f0cdbc"), 10.0m, "Precio Regular", 8.0m });
        }
    }
}
