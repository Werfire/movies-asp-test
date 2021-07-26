using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAspTest.Migrations
{
    public partial class ApplicationUserLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.DropTable(
		        name: "MovieLike");

	        migrationBuilder.DropTable(
		        name: "ActorLike");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
	            name: "ActorLike",
	            columns: table => new
	            {
		            UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
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
		            UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
	            name: "MovieLike");

            migrationBuilder.DropTable(
	            name: "ActorLike");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(32)", maxLength:32, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(32)", maxLength:32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
	            name: "ActorLike",
	            columns: table => new
	            {
		            UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
			            principalTable: "User",
			            principalColumn: "Id",
			            onDelete: ReferentialAction.Restrict);
	            });

            migrationBuilder.CreateTable(
	            name: "MovieLike",
	            columns: table => new
	            {
		            UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
			            principalTable: "User",
			            principalColumn: "Id",
			            onDelete: ReferentialAction.Restrict);
	            });
		}
    }
}
