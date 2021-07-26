using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAspTest.Migrations
{
    public partial class UserClassExtension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "MovieLike",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ActorLike",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieLike_ApplicationUserId",
                table: "MovieLike",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorLike_ApplicationUserId",
                table: "ActorLike",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorLike_AspNetUsers_ApplicationUserId",
                table: "ActorLike",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieLike_AspNetUsers_ApplicationUserId",
                table: "MovieLike",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorLike_AspNetUsers_ApplicationUserId",
                table: "ActorLike");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieLike_AspNetUsers_ApplicationUserId",
                table: "MovieLike");

            migrationBuilder.DropIndex(
                name: "IX_MovieLike_ApplicationUserId",
                table: "MovieLike");

            migrationBuilder.DropIndex(
                name: "IX_ActorLike_ApplicationUserId",
                table: "ActorLike");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "MovieLike");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ActorLike");
        }
    }
}
