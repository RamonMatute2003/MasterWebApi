using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Grade = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    PromotionalPrice = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "evaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Student = table.Column<string>(type: "TEXT", nullable: true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evaluations_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_images_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courseInstructors",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstructorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseInstructors", x => new { x.InstructorId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_courseInstructors_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courseInstructors_instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coursePrices",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PriceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coursePrices", x => new { x.PriceId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_coursePrices_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coursePrices_prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_courseInstructors_CourseId",
                table: "courseInstructors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_coursePrices_CourseId",
                table: "coursePrices",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_evaluations_CourseId",
                table: "evaluations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_images_CourseId",
                table: "images",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courseInstructors");

            migrationBuilder.DropTable(
                name: "coursePrices");

            migrationBuilder.DropTable(
                name: "evaluations");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
