using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAspTest.Migrations
{
    public partial class CascadeDeleteAndSeedRemainingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.CreateTable(
		        name: "MovieGenreJunction",
		        columns: table => new
		        {
			        MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
			        GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
		        },
		        constraints: table =>
		        {
			        table.PrimaryKey("PK_MovieGenreJunction", x => new { x.MovieId, x.GenreId });
			        table.ForeignKey(
				        name: "FK_MovieGenreJunction_Movie",
				        column: x => x.MovieId,
				        principalTable: "Movie",
				        principalColumn: "Id",
				        onDelete: ReferentialAction.Restrict);
			        table.ForeignKey(
				        name: "FK_MovieGenreJunction_Genre",
				        column: x => x.GenreId,
				        principalTable: "Genre",
				        principalColumn: "Id",
				        onDelete: ReferentialAction.Restrict);
		        });

            migrationBuilder.CreateTable(
                name: "ActorParticipation",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorParticipation", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_ActorParticipation_Actor",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorParticipation_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActorLike",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength:450, nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorLike", x => new { x.UserId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_ActorLike_Actor",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorLike_User",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieLike",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength:450, nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLike", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieLike_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieLike_User",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            

	        migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("98310d45-71d9-4074-9eb1-6685d3e812af"), "Russian television host, presenter, actor, musician and producer.", "Ivan Urgant" },
                    { new Guid("32719add-dd52-4b0a-85af-a9ac5e6683ac"), "Russian comedian, film and television actor, TV host, producer, screenwriter.", "Sergei Svetlakov" },
                    { new Guid("37c43778-09c9-4384-9b3a-12319eb2a29c"), "American actor and producer.", "Matthew McConaughey" },
                    { new Guid("21dd2c0a-bcb7-4462-825f-4645d8b4fabf"), "American actor and filmmaker.", "Vin Diesel" },
                    { new Guid("5660ebcd-2f62-484b-a3de-9c3aae6e5c2d"), "American actor, comedian, writer, producer, and singer.", "Eddie Murphy" },
                    { new Guid("a33ae310-9b7c-40ae-9b90-0d5080ab308a"), "American actor, voice actor, and writer.", "Mark Hamill" },
                    { new Guid("0b401827-f9aa-441d-b075-b617d2e46d87"), "American actor, pilot, and environmental activist.", "Harrison Ford" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("36fd0bfa-0df7-4b90-9668-744c0982f035"), "Detective" },
                    { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), "Adventure" },
                    { new Guid("41784ed0-1dab-466d-bfcf-d30b90c40734"), "Animation" },
                    { new Guid("a1d0e17a-7c53-4acb-bde3-b386ed43afb4"), "Action" },
                    { new Guid("61b3c6fb-80e7-469d-812c-bebf1caa73fe"), "Drama" },
                    { new Guid("301af3bb-4f23-4a0e-88cf-308eeb6849dd"), "Sci-fi" },
                    { new Guid("a2822920-ec5a-4ec8-86b1-fe3e0cc8db3e"), "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Description", "Duration", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71"), "Epic science fiction film co-written, directed and produced by Christopher Nolan.", new TimeSpan(0, 2, 49, 0, 0), "Interstellar", new DateTime(2014, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0b51a839-20ea-462a-acab-56ed45276f57"), "American action film directed by Justin Lin from a screenplay by Daniel Casey and Lin.", new TimeSpan(0, 2, 23, 0, 0), "Fast & Furious 9", new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11d7acef-a535-42aa-9087-88e227e056d5"), "Russian comedy film, sequel to Yolki.", new TimeSpan(0, 1, 40, 0, 0), "Yolki 2", new DateTime(2011, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7"), "American science fantasy Western action film directed and co-written by Nikolaj Arcel.", new TimeSpan(0, 1, 35, 0, 0), "The Dark Tower", new DateTime(2017, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49264b49-7514-4691-bc58-80afad1ababb"), "American computer-animated comedy film loosely based on the 1990 picture book Shrek! by William Steig.", new TimeSpan(0, 1, 32, 0, 0), "Shrek 2", new DateTime(2004, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9e8ccaf1-4e28-421f-bb8d-a62edd9de82d"), "Russian comedy film. It is a prequel to the 2013 film Yolki 3.", new TimeSpan(0, 1, 49, 0, 0), "Yolki 1914", new DateTime(2014, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f"), "American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", new TimeSpan(0, 2, 1, 0, 0), "Star Wars IV", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ActorParticipation",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("37c43778-09c9-4384-9b3a-12319eb2a29c"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") },
                    { new Guid("0b401827-f9aa-441d-b075-b617d2e46d87"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") },
                    { new Guid("a33ae310-9b7c-40ae-9b90-0d5080ab308a"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") },
                    { new Guid("21dd2c0a-bcb7-4462-825f-4645d8b4fabf"), new Guid("0b51a839-20ea-462a-acab-56ed45276f57") },
                    { new Guid("32719add-dd52-4b0a-85af-a9ac5e6683ac"), new Guid("9e8ccaf1-4e28-421f-bb8d-a62edd9de82d") },
                    { new Guid("98310d45-71d9-4074-9eb1-6685d3e812af"), new Guid("9e8ccaf1-4e28-421f-bb8d-a62edd9de82d") },
                    { new Guid("98310d45-71d9-4074-9eb1-6685d3e812af"), new Guid("11d7acef-a535-42aa-9087-88e227e056d5") },
                    { new Guid("32719add-dd52-4b0a-85af-a9ac5e6683ac"), new Guid("11d7acef-a535-42aa-9087-88e227e056d5") },
                    { new Guid("37c43778-09c9-4384-9b3a-12319eb2a29c"), new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7") },
                    { new Guid("5660ebcd-2f62-484b-a3de-9c3aae6e5c2d"), new Guid("49264b49-7514-4691-bc58-80afad1ababb") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenreJunction",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("301af3bb-4f23-4a0e-88cf-308eeb6849dd"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") },
                    { new Guid("a2822920-ec5a-4ec8-86b1-fe3e0cc8db3e"), new Guid("9e8ccaf1-4e28-421f-bb8d-a62edd9de82d") },
                    { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("49264b49-7514-4691-bc58-80afad1ababb") },
                    { new Guid("41784ed0-1dab-466d-bfcf-d30b90c40734"), new Guid("49264b49-7514-4691-bc58-80afad1ababb") },
                    { new Guid("a2822920-ec5a-4ec8-86b1-fe3e0cc8db3e"), new Guid("49264b49-7514-4691-bc58-80afad1ababb") },
                    { new Guid("a1d0e17a-7c53-4acb-bde3-b386ed43afb4"), new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7") },
                    { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") },
                    { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7") },
                    { new Guid("a2822920-ec5a-4ec8-86b1-fe3e0cc8db3e"), new Guid("11d7acef-a535-42aa-9087-88e227e056d5") },
                    { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("0b51a839-20ea-462a-acab-56ed45276f57") },
                    { new Guid("a1d0e17a-7c53-4acb-bde3-b386ed43afb4"), new Guid("0b51a839-20ea-462a-acab-56ed45276f57") },
                    { new Guid("36fd0bfa-0df7-4b90-9668-744c0982f035"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") },
                    { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") },
                    { new Guid("61b3c6fb-80e7-469d-812c-bebf1caa73fe"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") },
                    { new Guid("301af3bb-4f23-4a0e-88cf-308eeb6849dd"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") },
                    { new Guid("301af3bb-4f23-4a0e-88cf-308eeb6849dd"), new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7") },
                    { new Guid("a1d0e17a-7c53-4acb-bde3-b386ed43afb4"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("21dd2c0a-bcb7-4462-825f-4645d8b4fabf"), new Guid("0b51a839-20ea-462a-acab-56ed45276f57") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("32719add-dd52-4b0a-85af-a9ac5e6683ac"), new Guid("11d7acef-a535-42aa-9087-88e227e056d5") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("98310d45-71d9-4074-9eb1-6685d3e812af"), new Guid("11d7acef-a535-42aa-9087-88e227e056d5") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("0b401827-f9aa-441d-b075-b617d2e46d87"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("a33ae310-9b7c-40ae-9b90-0d5080ab308a"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("5660ebcd-2f62-484b-a3de-9c3aae6e5c2d"), new Guid("49264b49-7514-4691-bc58-80afad1ababb") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("37c43778-09c9-4384-9b3a-12319eb2a29c"), new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("37c43778-09c9-4384-9b3a-12319eb2a29c"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("32719add-dd52-4b0a-85af-a9ac5e6683ac"), new Guid("9e8ccaf1-4e28-421f-bb8d-a62edd9de82d") });

            migrationBuilder.DeleteData(
                table: "ActorParticipation",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("98310d45-71d9-4074-9eb1-6685d3e812af"), new Guid("9e8ccaf1-4e28-421f-bb8d-a62edd9de82d") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("a1d0e17a-7c53-4acb-bde3-b386ed43afb4"), new Guid("0b51a839-20ea-462a-acab-56ed45276f57") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("0b51a839-20ea-462a-acab-56ed45276f57") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("a2822920-ec5a-4ec8-86b1-fe3e0cc8db3e"), new Guid("11d7acef-a535-42aa-9087-88e227e056d5") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("301af3bb-4f23-4a0e-88cf-308eeb6849dd"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("a1d0e17a-7c53-4acb-bde3-b386ed43afb4"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("41784ed0-1dab-466d-bfcf-d30b90c40734"), new Guid("49264b49-7514-4691-bc58-80afad1ababb") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("a2822920-ec5a-4ec8-86b1-fe3e0cc8db3e"), new Guid("49264b49-7514-4691-bc58-80afad1ababb") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("49264b49-7514-4691-bc58-80afad1ababb") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("301af3bb-4f23-4a0e-88cf-308eeb6849dd"), new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("a1d0e17a-7c53-4acb-bde3-b386ed43afb4"), new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("301af3bb-4f23-4a0e-88cf-308eeb6849dd"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("36fd0bfa-0df7-4b90-9668-744c0982f035"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("61b3c6fb-80e7-469d-812c-bebf1caa73fe"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"), new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71") });

            migrationBuilder.DeleteData(
                table: "MovieGenreJunction",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { new Guid("a2822920-ec5a-4ec8-86b1-fe3e0cc8db3e"), new Guid("9e8ccaf1-4e28-421f-bb8d-a62edd9de82d") });

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("0b401827-f9aa-441d-b075-b617d2e46d87"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("21dd2c0a-bcb7-4462-825f-4645d8b4fabf"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("32719add-dd52-4b0a-85af-a9ac5e6683ac"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("37c43778-09c9-4384-9b3a-12319eb2a29c"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("5660ebcd-2f62-484b-a3de-9c3aae6e5c2d"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("98310d45-71d9-4074-9eb1-6685d3e812af"));

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: new Guid("a33ae310-9b7c-40ae-9b90-0d5080ab308a"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("301af3bb-4f23-4a0e-88cf-308eeb6849dd"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("36fd0bfa-0df7-4b90-9668-744c0982f035"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("41784ed0-1dab-466d-bfcf-d30b90c40734"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("61b3c6fb-80e7-469d-812c-bebf1caa73fe"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("a1d0e17a-7c53-4acb-bde3-b386ed43afb4"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("a2822920-ec5a-4ec8-86b1-fe3e0cc8db3e"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("e1d7a7a1-6ec6-4824-bdf2-03dc8c5f9dfe"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("0b51a839-20ea-462a-acab-56ed45276f57"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("11d7acef-a535-42aa-9087-88e227e056d5"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("45a1cccb-afa2-4295-a9b2-51f5883b0c1f"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("49264b49-7514-4691-bc58-80afad1ababb"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("741f1f1b-90d7-4a84-bc77-1ebbf9ff6aa7"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("9177f1ec-3d57-41d8-ae30-be6c67878f71"));

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: new Guid("9e8ccaf1-4e28-421f-bb8d-a62edd9de82d"));

            migrationBuilder.DropTable("ActorLike");

            migrationBuilder.DropTable("MovieLike");

            migrationBuilder.DropTable("ActorParticipation");

            migrationBuilder.DropTable("MovieGenreJunction");
        }
    }
}
