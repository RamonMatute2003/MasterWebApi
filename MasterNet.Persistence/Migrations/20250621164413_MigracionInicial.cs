using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7be52fc3-4ff7-48b8-a7cd-679e75324720", null, "ADMIN", "ADMIN" },
                    { "d298c85c-a5a1-4846-b323-2a8f3d055b08", null, "CLIENT", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "Description", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("62888f55-78f3-4b06-9474-0fff99dfdf7a"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6596), "Handmade Wooden Pizza" },
                    { new Guid("8c7aa1db-63e4-4939-995f-314e9d0e103d"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6568), "Incredible Concrete Computer" },
                    { new Guid("9b01b651-064c-4811-87ca-6542c2343699"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6679), "Gorgeous Frozen Gloves" },
                    { new Guid("b9a10894-3c72-4fd7-bccd-5fc79756ecd7"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6582), "Practical Concrete Salad" },
                    { new Guid("bbd15c36-7f5c-4669-bae5-eb995c1d3003"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6526), "Rustic Rubber Pants" },
                    { new Guid("bc1cc2da-08df-4b1f-883c-e43c2c0805aa"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6699), "Rustic Rubber Bike" },
                    { new Guid("e61ce275-9dc4-4ad9-8930-161dbd027ac9"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6665), "Awesome Cotton Towels" },
                    { new Guid("eccf2eb4-1e47-4938-bdd9-e48f486f3b7e"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6553), "Handmade Fresh Chair" },
                    { new Guid("f8a678b8-a5ee-4e37-b79a-3b9435310dc5"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2025, 6, 21, 16, 44, 12, 987, DateTimeKind.Utc).AddTicks(6690), "Licensed Soft Shoes" }
                });

            migrationBuilder.InsertData(
                table: "instructors",
                columns: new[] { "Id", "Grade", "LastName", "Name" },
                values: new object[,]
                {
                    { new Guid("025b2317-daaf-457e-add9-103979300b61"), "Dynamic Assurance Director", "Schmitt", "Josie" },
                    { new Guid("086b6999-bc45-4301-a7ae-dbdac2fef302"), "Dynamic Tactics Representative", "Sawayn", "Mose" },
                    { new Guid("33522ec1-c5ac-4891-b036-fe54e841cf49"), "Investor Program Director", "Schmitt", "Mario" },
                    { new Guid("5971a58d-0105-4a55-8ff1-ff5c5b7ad2cc"), "Principal Identity Specialist", "Kiehn", "Stephania" },
                    { new Guid("5f2b7aa7-bd04-4968-aaa0-c348b45a911b"), "Product Operations Orchestrator", "Renner", "Waino" },
                    { new Guid("5f69b20a-3f42-4b67-a2ff-b14130039fe9"), "Senior Paradigm Representative", "Okuneva", "Kristin" },
                    { new Guid("801b2a76-a5ac-4559-893c-d7ade8bf3abd"), "Product Usability Strategist", "Stokes", "Tod" },
                    { new Guid("a9d4d6c8-833d-4062-abf0-57bc814415d2"), "Internal Optimization Specialist", "Parisian", "Pinkie" },
                    { new Guid("d21e6f49-6915-4d1c-969e-b96b824640f2"), "Human Implementation Supervisor", "Bailey", "Marques" },
                    { new Guid("fee2f4bd-eca5-4309-9492-b72d172da57d"), "Human Creative Officer", "Kertzmann", "Jennifer" }
                });

            migrationBuilder.InsertData(
                table: "prices",
                columns: new[] { "Id", "CurrentPrice", "Name", "PromotionalPrice" },
                values: new object[] { new Guid("439b36a5-0f53-4fd0-a894-bce4418bd3f1"), 10.0m, "Precio Regular", 8.0m });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICES", "COURSE_READ", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 2, "POLICES", "COURSE_UPDATE", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 3, "POLICES", "COURSE_WRITE", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 4, "POLICES", "COURSE_DELETE", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 5, "POLICES", "INSTRUCTOR_CREATE", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 6, "POLICES", "INSTRUCTOR_READ", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 7, "POLICES", "INSTRUCTOR_UPDATE", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 8, "POLICES", "COMMENT_READ", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 9, "POLICES", "COMMENT_DELETE", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 10, "POLICES", "COMMENT_CREATE", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 11, "POLICES", "COURSE_READ", "d298c85c-a5a1-4846-b323-2a8f3d055b08" },
                    { 12, "POLICES", "INSTRUCTOR_READ", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 13, "POLICES", "COMMENT_READ", "7be52fc3-4ff7-48b8-a7cd-679e75324720" },
                    { 14, "POLICES", "COMMENT_CREATE", "7be52fc3-4ff7-48b8-a7cd-679e75324720" }
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
                name: "courseInstructors");

            migrationBuilder.DropTable(
                name: "coursePrices");

            migrationBuilder.DropTable(
                name: "evaluations");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "instructors");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
