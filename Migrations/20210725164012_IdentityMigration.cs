using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAspTest.Migrations
{
    public partial class IdentityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("0484c6b2-799c-41e0-a8a2-23ab0f739d4f"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("07e87fb1-656f-4328-bf88-4600d1a4b299"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("1710f25c-fe35-4612-b73b-be17fc5af122"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("8aff3bb4-8822-410b-9046-d938c3aa9a70"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("c70d343b-23b9-4fe0-9a57-d254ab08f533"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("cafd141a-b828-4cbe-a98e-49bcf67042e3"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("f11ef9e6-afdb-4485-8905-c351cb33dfc2"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                table: "Movie",
                columns: new[] { "Id", "Description", "Duration", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("bd6ef8d1-575c-4b3f-89bb-aec375f728c7"), "Epic science fiction film co-written, directed and produced by Christopher Nolan.", new TimeSpan(0, 2, 49, 0, 0), "Interstellar", new DateTime(2014, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43309611-e9df-44b3-ab13-a57a57e8bbd7"), "American action film directed by Justin Lin from a screenplay by Daniel Casey and Lin.", new TimeSpan(0, 2, 23, 0, 0), "Fast & Furious 9", new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f216899e-c14a-4ce3-8e7d-f1208186d09b"), "Russian comedy film, sequel to Yolki.", new TimeSpan(0, 1, 40, 0, 0), "Yolki 2", new DateTime(2011, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a11d99b-9670-4fff-b74b-8287fe78d13c"), "American science fantasy Western action film directed and co-written by Nikolaj Arcel.", new TimeSpan(0, 1, 35, 0, 0), "The Dark Tower", new DateTime(2017, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("58449f5b-8438-43e2-b391-41137b1ad808"), "American computer-animated comedy film loosely based on the 1990 picture book Shrek! by William Steig.", new TimeSpan(0, 1, 32, 0, 0), "Shrek 2", new DateTime(2004, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7df6df7f-5e03-4306-87c1-4fb30c03d097"), "Russian comedy film. It is a prequel to the 2013 film Yolki 3.", new TimeSpan(0, 1, 49, 0, 0), "Yolki 1914", new DateTime(2014, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("356652fb-a40c-4333-885f-f0073ee5edbc"), "American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new TimeSpan(0, 2, 1, 0, 0), "Star Wars IV", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

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
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("356652fb-a40c-4333-885f-f0073ee5edbc"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("43309611-e9df-44b3-ab13-a57a57e8bbd7"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("58449f5b-8438-43e2-b391-41137b1ad808"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("7df6df7f-5e03-4306-87c1-4fb30c03d097"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("9a11d99b-9670-4fff-b74b-8287fe78d13c"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("bd6ef8d1-575c-4b3f-89bb-aec375f728c7"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("f216899e-c14a-4ce3-8e7d-f1208186d09b"));

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "Duration", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("8aff3bb4-8822-410b-9046-d938c3aa9a70"), "Epic science fiction film co-written, directed and produced by Christopher Nolan.", new TimeSpan(0, 2, 49, 0, 0), "Interstellar", new DateTime(2014, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cafd141a-b828-4cbe-a98e-49bcf67042e3"), "American action film directed by Justin Lin from a screenplay by Daniel Casey and Lin.", new TimeSpan(0, 2, 23, 0, 0), "Fast & Furious 9", new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("07e87fb1-656f-4328-bf88-4600d1a4b299"), "Russian comedy film, sequel to Yolki.", new TimeSpan(0, 1, 40, 0, 0), "Yolki 2", new DateTime(2011, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1710f25c-fe35-4612-b73b-be17fc5af122"), "American science fantasy Western action film directed and co-written by Nikolaj Arcel.", new TimeSpan(0, 1, 35, 0, 0), "The Dark Tower", new DateTime(2017, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c70d343b-23b9-4fe0-9a57-d254ab08f533"), "American computer-animated comedy film loosely based on the 1990 picture book Shrek! by William Steig.", new TimeSpan(0, 1, 32, 0, 0), "Shrek 2", new DateTime(2004, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0484c6b2-799c-41e0-a8a2-23ab0f739d4f"), "Russian comedy film. It is a prequel to the 2013 film Yolki 3.", new TimeSpan(0, 1, 49, 0, 0), "Yolki 1914", new DateTime(2014, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f11ef9e6-afdb-4485-8905-c351cb33dfc2"), "American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new TimeSpan(0, 2, 1, 0, 0), "Star Wars IV", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
