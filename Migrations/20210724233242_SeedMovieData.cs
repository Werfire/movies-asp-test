using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAspTest.Migrations
{
    public partial class SeedMovieData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "User",
                newName: "SignIn");
        }
    }
}
