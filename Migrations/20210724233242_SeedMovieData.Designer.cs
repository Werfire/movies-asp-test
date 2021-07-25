﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAspTest.Models;

namespace MoviesAspTest.Migrations
{
    [DbContext(typeof(MoviesActorsContext))]
    [Migration("20210724233242_SeedMovieData")]
    partial class SeedMovieData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesAspTest.Models.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nchar(512)")
                        .IsFixedLength(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasDefaultValueSql("('ACTOR_NAME')");

                    b.HasKey("Id");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("MoviesAspTest.Models.ActorLike", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("ActorLike");
                });

            modelBuilder.Entity("MoviesAspTest.Models.ActorParticipation", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("ActorParticipation");
                });

            modelBuilder.Entity("MoviesAspTest.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasDefaultValueSql("('GENRE_NAME')");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MoviesAspTest.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasDefaultValueSql("('MOVIE_NAME')");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8aff3bb4-8822-410b-9046-d938c3aa9a70"),
                            Description = "Epic science fiction film co-written, directed and produced by Christopher Nolan.",
                            Duration = new TimeSpan(0, 2, 49, 0, 0),
                            Name = "Interstellar",
                            ReleaseDate = new DateTime(2014, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("cafd141a-b828-4cbe-a98e-49bcf67042e3"),
                            Description = "American action film directed by Justin Lin from a screenplay by Daniel Casey and Lin.",
                            Duration = new TimeSpan(0, 2, 23, 0, 0),
                            Name = "Fast & Furious 9",
                            ReleaseDate = new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("07e87fb1-656f-4328-bf88-4600d1a4b299"),
                            Description = "Russian comedy film, sequel to Yolki.",
                            Duration = new TimeSpan(0, 1, 40, 0, 0),
                            Name = "Yolki 2",
                            ReleaseDate = new DateTime(2011, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("1710f25c-fe35-4612-b73b-be17fc5af122"),
                            Description = "American science fantasy Western action film directed and co-written by Nikolaj Arcel.",
                            Duration = new TimeSpan(0, 1, 35, 0, 0),
                            Name = "The Dark Tower",
                            ReleaseDate = new DateTime(2017, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("c70d343b-23b9-4fe0-9a57-d254ab08f533"),
                            Description = "American computer-animated comedy film loosely based on the 1990 picture book Shrek! by William Steig.",
                            Duration = new TimeSpan(0, 1, 32, 0, 0),
                            Name = "Shrek 2",
                            ReleaseDate = new DateTime(2004, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("0484c6b2-799c-41e0-a8a2-23ab0f739d4f"),
                            Description = "Russian comedy film. It is a prequel to the 2013 film Yolki 3.",
                            Duration = new TimeSpan(0, 1, 49, 0, 0),
                            Name = "Yolki 1914",
                            ReleaseDate = new DateTime(2014, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("f11ef9e6-afdb-4485-8905-c351cb33dfc2"),
                            Description = "American epic space-opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.",
                            Duration = new TimeSpan(0, 2, 1, 0, 0),
                            Name = "Star Wars IV",
                            ReleaseDate = new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MoviesAspTest.Models.MovieGenreJunction", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MovieId", "GenreId");

                    b.ToTable("MovieGenreJunction");
                });

            modelBuilder.Entity("MoviesAspTest.Models.MovieLike", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieLike");
                });

            modelBuilder.Entity("MoviesAspTest.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MoviesAspTest.Models.ActorLike", b =>
                {
                    b.HasOne("MoviesAspTest.Models.Actor", "Actor")
                        .WithMany("ActorLikes")
                        .HasForeignKey("ActorId")
                        .HasConstraintName("FK_ActorLike_Actor")
                        .IsRequired();

                    b.HasOne("MoviesAspTest.Models.User", "User")
                        .WithMany("ActorLikes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ActorLike_User")
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesAspTest.Models.ActorParticipation", b =>
                {
                    b.HasOne("MoviesAspTest.Models.Actor", "Actor")
                        .WithMany("ActorParticipations")
                        .HasForeignKey("ActorId")
                        .HasConstraintName("FK_ActorParticipation_Actor")
                        .IsRequired();

                    b.HasOne("MoviesAspTest.Models.Movie", "Movie")
                        .WithMany("ActorParticipations")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_ActorParticipation_Movie")
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesAspTest.Models.MovieLike", b =>
                {
                    b.HasOne("MoviesAspTest.Models.Movie", "Movie")
                        .WithMany("MovieLikes")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieLike_Movie")
                        .IsRequired();

                    b.HasOne("MoviesAspTest.Models.User", "User")
                        .WithMany("MovieLikes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_MovieLike_User")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesAspTest.Models.Actor", b =>
                {
                    b.Navigation("ActorLikes");

                    b.Navigation("ActorParticipations");
                });

            modelBuilder.Entity("MoviesAspTest.Models.Movie", b =>
                {
                    b.Navigation("ActorParticipations");

                    b.Navigation("MovieLikes");
                });

            modelBuilder.Entity("MoviesAspTest.Models.User", b =>
                {
                    b.Navigation("ActorLikes");

                    b.Navigation("MovieLikes");
                });
#pragma warning restore 612, 618
        }
    }
}
