﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesAspTest.Models;

namespace MoviesAspTest.Migrations
{
    [DbContext(typeof(MoviesTestContext))]
    partial class MoviesActorsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

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

                    b.HasIndex("Id");

                    b.ToTable("Actor");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b29c004-8a90-4414-9a93-c6a691a9a155"),
                            Description = "Russian television host, presenter, actor, musician and producer.",
                            Name = "Ivan Urgant"
                        },
                        new
                        {
                            Id = new Guid("2d5f4e98-c33a-46cf-885f-1e9f6eedf911"),
                            Description = "Russian comedian, film and television actor, TV host, producer, screenwriter.",
                            Name = "Sergei Svetlakov"
                        },
                        new
                        {
                            Id = new Guid("96d2223b-3851-4a46-a35d-2cb82e069ac7"),
                            Description = "American actor and producer.",
                            Name = "Matthew McConaughey"
                        },
                        new
                        {
                            Id = new Guid("51c52faf-95fe-442b-86a5-ece12c3968a6"),
                            Description = "American actor and filmmaker.",
                            Name = "Vin Diesel"
                        },
                        new
                        {
                            Id = new Guid("6fd10610-712e-42eb-aa23-b16eb3897fe1"),
                            Description = "American actor, comedian, writer, producer, and singer.",
                            Name = "Eddie Murphy"
                        },
                        new
                        {
                            Id = new Guid("4a39374f-c565-4c2f-8b0a-a79249398c33"),
                            Description = "American actor, voice actor, and writer.",
                            Name = "Mark Hamill"
                        },
                        new
                        {
                            Id = new Guid("f3a180c4-691c-4267-a0f2-4005137faef0"),
                            Description = "American actor, pilot, and environmental activist.",
                            Name = "Harrison Ford"
                        });
                });

            modelBuilder.Entity("MoviesAspTest.Models.ActorLike", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

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

                    b.HasData(
                        new
                        {
                            MovieId = new Guid("20968f49-1971-41b7-9c1e-e106a365bc15"),
                            ActorId = new Guid("4b29c004-8a90-4414-9a93-c6a691a9a155")
                        },
                        new
                        {
                            MovieId = new Guid("8614f13c-2603-47a2-8e98-681f1937d250"),
                            ActorId = new Guid("4b29c004-8a90-4414-9a93-c6a691a9a155")
                        },
                        new
                        {
                            MovieId = new Guid("20968f49-1971-41b7-9c1e-e106a365bc15"),
                            ActorId = new Guid("2d5f4e98-c33a-46cf-885f-1e9f6eedf911")
                        },
                        new
                        {
                            MovieId = new Guid("8614f13c-2603-47a2-8e98-681f1937d250"),
                            ActorId = new Guid("2d5f4e98-c33a-46cf-885f-1e9f6eedf911")
                        },
                        new
                        {
                            MovieId = new Guid("a0ceef38-9a24-479a-9112-1153d423af03"),
                            ActorId = new Guid("96d2223b-3851-4a46-a35d-2cb82e069ac7")
                        },
                        new
                        {
                            MovieId = new Guid("14234ee8-5710-49f6-a0cb-4674f823bd8f"),
                            ActorId = new Guid("96d2223b-3851-4a46-a35d-2cb82e069ac7")
                        },
                        new
                        {
                            MovieId = new Guid("f7d726e9-9e26-49e0-814a-bb49d56aec08"),
                            ActorId = new Guid("51c52faf-95fe-442b-86a5-ece12c3968a6")
                        },
                        new
                        {
                            MovieId = new Guid("ec192292-7c03-493c-88bb-efceff4eccea"),
                            ActorId = new Guid("6fd10610-712e-42eb-aa23-b16eb3897fe1")
                        },
                        new
                        {
                            MovieId = new Guid("5fe3f4c6-9f10-461d-b297-30048c1a1848"),
                            ActorId = new Guid("4a39374f-c565-4c2f-8b0a-a79249398c33")
                        },
                        new
                        {
                            MovieId = new Guid("5fe3f4c6-9f10-461d-b297-30048c1a1848"),
                            ActorId = new Guid("f3a180c4-691c-4267-a0f2-4005137faef0")
                        });
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

                    b.HasIndex("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = new Guid("94618846-b1e5-4879-b26a-4ca25a93b559"),
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = new Guid("6c29f249-ec41-4ff2-a0b1-f3674021c82f"),
                            Name = "Sci-fi"
                        },
                        new
                        {
                            Id = new Guid("0dc28c97-923c-43c8-8c8e-15eb014235fa"),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = new Guid("f314017f-f72f-4264-8475-641c16e19dbb"),
                            Name = "Action"
                        },
                        new
                        {
                            Id = new Guid("33cc77b1-49df-4d6a-b3e8-dfbcf292d7e4"),
                            Name = "Animation"
                        },
                        new
                        {
                            Id = new Guid("d52ad1a8-7042-4346-ab83-ff2462abea90"),
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = new Guid("1276dbcb-27bf-48a5-9da9-53562e08056f"),
                            Name = "Detective"
                        });
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

                    b.HasIndex("Id");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a0ceef38-9a24-479a-9112-1153d423af03"),
                            Description = "Epic science fiction film co-written, directed and produced by Christopher Nolan.",
                            Duration = new TimeSpan(0, 2, 49, 0, 0),
                            Name = "Interstellar",
                            ReleaseDate = new DateTime(2014, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("f7d726e9-9e26-49e0-814a-bb49d56aec08"),
                            Description = "American action film directed by Justin Lin from a screenplay by Daniel Casey and Lin.",
                            Duration = new TimeSpan(0, 2, 23, 0, 0),
                            Name = "Fast & Furious 9",
                            ReleaseDate = new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("20968f49-1971-41b7-9c1e-e106a365bc15"),
                            Description = "Russian comedy film, sequel to Yolki.",
                            Duration = new TimeSpan(0, 1, 40, 0, 0),
                            Name = "Yolki 2",
                            ReleaseDate = new DateTime(2011, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("14234ee8-5710-49f6-a0cb-4674f823bd8f"),
                            Description = "American science fantasy Western action film directed and co-written by Nikolaj Arcel.",
                            Duration = new TimeSpan(0, 1, 35, 0, 0),
                            Name = "The Dark Tower",
                            ReleaseDate = new DateTime(2017, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("ec192292-7c03-493c-88bb-efceff4eccea"),
                            Description = "American computer-animated comedy film loosely based on the 1990 picture book Shrek! by William Steig.",
                            Duration = new TimeSpan(0, 1, 32, 0, 0),
                            Name = "Shrek 2",
                            ReleaseDate = new DateTime(2004, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("8614f13c-2603-47a2-8e98-681f1937d250"),
                            Description = "Russian comedy film. It is a prequel to the 2013 film Yolki 3.",
                            Duration = new TimeSpan(0, 1, 49, 0, 0),
                            Name = "Yolki 1914",
                            ReleaseDate = new DateTime(2014, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("5fe3f4c6-9f10-461d-b297-30048c1a1848"),
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

                    b.HasIndex("GenreId");

                    b.ToTable("MovieGenreJunction");

                    b.HasData(
                        new
                        {
                            MovieId = new Guid("a0ceef38-9a24-479a-9112-1153d423af03"),
                            GenreId = new Guid("0dc28c97-923c-43c8-8c8e-15eb014235fa")
                        },
                        new
                        {
                            MovieId = new Guid("a0ceef38-9a24-479a-9112-1153d423af03"),
                            GenreId = new Guid("d52ad1a8-7042-4346-ab83-ff2462abea90")
                        },
                        new
                        {
                            MovieId = new Guid("a0ceef38-9a24-479a-9112-1153d423af03"),
                            GenreId = new Guid("1276dbcb-27bf-48a5-9da9-53562e08056f")
                        },
                        new
                        {
                            MovieId = new Guid("f7d726e9-9e26-49e0-814a-bb49d56aec08"),
                            GenreId = new Guid("f314017f-f72f-4264-8475-641c16e19dbb")
                        },
                        new
                        {
                            MovieId = new Guid("f7d726e9-9e26-49e0-814a-bb49d56aec08"),
                            GenreId = new Guid("d52ad1a8-7042-4346-ab83-ff2462abea90")
                        },
                        new
                        {
                            MovieId = new Guid("20968f49-1971-41b7-9c1e-e106a365bc15"),
                            GenreId = new Guid("94618846-b1e5-4879-b26a-4ca25a93b559")
                        },
                        new
                        {
                            MovieId = new Guid("14234ee8-5710-49f6-a0cb-4674f823bd8f"),
                            GenreId = new Guid("d52ad1a8-7042-4346-ab83-ff2462abea90")
                        },
                        new
                        {
                            MovieId = new Guid("14234ee8-5710-49f6-a0cb-4674f823bd8f"),
                            GenreId = new Guid("f314017f-f72f-4264-8475-641c16e19dbb")
                        },
                        new
                        {
                            MovieId = new Guid("14234ee8-5710-49f6-a0cb-4674f823bd8f"),
                            GenreId = new Guid("6c29f249-ec41-4ff2-a0b1-f3674021c82f")
                        },
                        new
                        {
                            MovieId = new Guid("ec192292-7c03-493c-88bb-efceff4eccea"),
                            GenreId = new Guid("94618846-b1e5-4879-b26a-4ca25a93b559")
                        },
                        new
                        {
                            MovieId = new Guid("ec192292-7c03-493c-88bb-efceff4eccea"),
                            GenreId = new Guid("33cc77b1-49df-4d6a-b3e8-dfbcf292d7e4")
                        },
                        new
                        {
                            MovieId = new Guid("ec192292-7c03-493c-88bb-efceff4eccea"),
                            GenreId = new Guid("d52ad1a8-7042-4346-ab83-ff2462abea90")
                        },
                        new
                        {
                            MovieId = new Guid("8614f13c-2603-47a2-8e98-681f1937d250"),
                            GenreId = new Guid("94618846-b1e5-4879-b26a-4ca25a93b559")
                        },
                        new
                        {
                            MovieId = new Guid("5fe3f4c6-9f10-461d-b297-30048c1a1848"),
                            GenreId = new Guid("6c29f249-ec41-4ff2-a0b1-f3674021c82f")
                        },
                        new
                        {
                            MovieId = new Guid("5fe3f4c6-9f10-461d-b297-30048c1a1848"),
                            GenreId = new Guid("d52ad1a8-7042-4346-ab83-ff2462abea90")
                        },
                        new
                        {
                            MovieId = new Guid("5fe3f4c6-9f10-461d-b297-30048c1a1848"),
                            GenreId = new Guid("f314017f-f72f-4264-8475-641c16e19dbb")
                        });
                });

            modelBuilder.Entity("MoviesAspTest.Models.MovieLike", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieLike");
                });

            modelBuilder.Entity("MoviesAspTest.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesAspTest.Models.ActorLike", b =>
                {
                    b.HasOne("MoviesAspTest.Models.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesAspTest.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoviesAspTest.Models.ActorParticipation", b =>
                {
                    b.HasOne("MoviesAspTest.Models.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesAspTest.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesAspTest.Models.MovieGenreJunction", b =>
                {
                    b.HasOne("MoviesAspTest.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesAspTest.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesAspTest.Models.MovieLike", b =>
                {
                    b.HasOne("MoviesAspTest.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesAspTest.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
