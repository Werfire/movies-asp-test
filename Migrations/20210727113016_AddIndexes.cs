using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAspTest.Migrations
{
    public partial class AddIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.CreateIndex(
                name: "IX_Movie_Id",
                table: "Movie",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Id",
                table: "Genre",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Actor_Id",
                table: "Actor",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.DropIndex(
		        name: "IX_Movie_Id",
		        table: "Movie");

	        migrationBuilder.DropIndex(
		        name: "IX_Genre_Id",
		        table: "Genre");

	        migrationBuilder.DropIndex(
		        name: "IX_Actor_Id",
		        table: "Actor");
        }
    }
}
